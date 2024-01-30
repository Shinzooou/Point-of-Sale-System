Imports System.Data.OleDb

Public Class frmpostransactionrecord
    Private Sub frmpostransactionrecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        Call LoadProducts()
    End Sub
    Private Sub LoadProducts()
        ' Retrieve the start and end dates from the DateTimePicker controls
        Dim startDate As String = dtpStartDate.Value.ToString("yyyy-MM-dd")
        Dim endDate As String = dtpEndDate.Value.ToString("yyyy-MM-dd")

        ' Update the SQL query to filter by the selected date range
        sql = "SELECT * FROM tblTransactions WHERE TransDate >= @startDate AND TransDate <= @endDate"
        cmd = New OleDbCommand(sql, cn)

        ' Add parameters to prevent SQL injection
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)

        dr = cmd.ExecuteReader

        ListView2.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("TransNo").ToString)
            x.SubItems.Add(dr("TransDate").ToString)
            x.SubItems.Add(dr("TransTime").ToString)
            x.SubItems.Add(dr("TotalAmount").ToString)
            x.SubItems.Add(dr("Change").ToString)
            x.SubItems.Add(dr("VAT").ToString)
            x.SubItems.Add(dr("VatableSales").ToString)
            x.SubItems.Add(dr("CashierName").ToString)
            ListView2.Items.Add(x)
        Loop
        Call GetTotal()
    End Sub
    Private Sub GetTotal()
        Const col As Integer = 3
        Dim total As Integer
        Dim lvsi As ListViewItem.ListViewSubItem
        For i As Integer = 0 To ListView2.Items.Count - 1
            lvsi = ListView2.Items(i).SubItems(col)
            total += Double.Parse(lvsi.Text)
        Next
        lblTotal.Text = Format(Val(total), "0.00")
    End Sub



    Private Sub ListView2_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView2.MouseClick
        If ListView2.Items.Count > 0 Then
            Dim i As ListViewItem = ListView2.SelectedItems(0)
        End If

    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        If ListView2.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView2.SelectedItems(0)
            TransferItemToRefund(selectedItem)
        Else
            MessageBox.Show("Please select an item to refund.")
        End If
    End Sub

    Private Sub TransferItemToRefund(item As ListViewItem)
        Try
            cn.Open()
            Dim cm As New OleDbCommand("INSERT INTO tblreturneditems (TransNo, TransDate, TransTime, TotalAmount, Change, VAT, VatableSales, CashierName) VALUES (@TransNo, @TransDate, @TransTime, @TotalAmount, @Change, @VAT, @VatableSales, @CashierName)", cn)
            cm.Parameters.AddWithValue("TransNo", item.SubItems(0).Text)
            cm.Parameters.AddWithValue("TransDate", item.SubItems(1).Text)
            cm.Parameters.AddWithValue("TransTime", item.SubItems(2).Text)
            cm.Parameters.AddWithValue("TotalAmount", item.SubItems(3).Text)
            cm.Parameters.AddWithValue("Change", item.SubItems(4).Text)
            cm.Parameters.AddWithValue("VAT", item.SubItems(5).Text)
            cm.Parameters.AddWithValue("VatableSales", item.SubItems(6).Text)
            cm.Parameters.AddWithValue("CashierName", item.SubItems(7).Text)
            cm.ExecuteNonQuery()

            cm = New OleDbCommand("DELETE FROM tblTransactions WHERE TransNo = ?", cn)
            cm.Parameters.AddWithValue("?", item.SubItems(0).Text)
            cm.ExecuteNonQuery()

            LoadProducts() ' Reload sold items
        Catch ex As Exception
            MessageBox.Show("Select to Refund")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Call LoadProducts()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmrefund.ShowDialog()
    End Sub

End Class