Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmreturn
    Private Sub frmreturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        LoadProducts()
    End Sub

    Private Sub LoadProducts(Optional ByVal productCode As String = "", Optional ByVal transNo As String = "")
        Dim sql As String = "SELECT * FROM tblTransactionDetails WHERE 1 = 1"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView2.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("TransNo").ToString)
            x.SubItems.Add(dr("ProductCode").ToString)
            x.SubItems.Add(dr("Amount").ToString)
            x.SubItems.Add(dr("Qty").ToString)
            x.SubItems.Add(dr("Total").ToString)
            ListView2.Items.Add(x)
        Loop
        'dr.Close()
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
            ' Ask the user for the quantity to return
            Dim returnQty As Integer = InputBox("Enter the quantity to return:", "Return Quantity", 1)

            ' Validate return quantity
            If returnQty <= 0 OrElse returnQty > Convert.ToInt32(item.SubItems(3).Text) Then
                MessageBox.Show("Invalid return quantity.")
                Exit Sub
            End If

            cn.Open()
            ' Insert into tblreturneditems
            Dim cm As New OleDbCommand("INSERT INTO tblreturneditems (TransNo, ProductCode, Amount, Qty, Total) VALUES (@TransNo, @Product, @Amount, @Qty, @Total)", cn)
            cm.Parameters.AddWithValue("TransNo", item.SubItems(0).Text)
            cm.Parameters.AddWithValue("ProductCode", item.SubItems(1).Text)
            cm.Parameters.AddWithValue("Amount", item.SubItems(2).Text)
            cm.Parameters.AddWithValue("Qty", returnQty)
            cm.Parameters.AddWithValue("Total", Convert.ToDecimal(item.SubItems(2).Text) * returnQty)
            cm.ExecuteNonQuery()

            ' Update or delete from tblTransactionDetails
            Dim remainingQty As Integer = Convert.ToInt32(item.SubItems(3).Text) - returnQty
            If remainingQty > 0 Then
                cm = New OleDbCommand("UPDATE tblTransactionDetails SET Qty = ?, Total = ? WHERE TransNo = ? AND ProductCode = ?", cn)
                cm.Parameters.AddWithValue("?", remainingQty)
                cm.Parameters.AddWithValue("?", Convert.ToDecimal(item.SubItems(2).Text) * remainingQty)
                cm.Parameters.AddWithValue("?", item.SubItems(0).Text)
                cm.Parameters.AddWithValue("?", item.SubItems(1).Text)
            Else
                cm = New OleDbCommand("DELETE FROM tblTransactionDetails WHERE TransNo = ? AND ProductCode = ?", cn)
                cm.Parameters.AddWithValue("?", item.SubItems(0).Text)
                cm.Parameters.AddWithValue("?", item.SubItems(1).Text)
            End If
            cm.ExecuteNonQuery()

            LoadProducts() ' Reload sold items
        Catch ex As Exception
            MessageBox.Show("Error processing refund: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub bntFilter_Click(sender As Object, e As EventArgs) Handles bntFilter.Click
        LoadProducts(txtProductCode.Text, txtTransNo.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmrefund.ShowDialog()
    End Sub

End Class