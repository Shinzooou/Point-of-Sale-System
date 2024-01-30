Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices.RuntimeHelpers
Public Class frmPOS
    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        Call getTransactionNo()
        LoadItems()
        LoadCategories() ' Populate categories in dropdown box
    End Sub
    Private Sub getTransactionNo()
        sql = "Select TransNo from tblTransactions order by TransNo desc"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            lblTransNo.Text = Val(dr(0)) + 1
        Else
            lblTransNo.Text = 1000001
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString
        lblTime.Text = Now.ToShortTimeString
    End Sub
    Private Sub clearText()
        txtcode.Clear()
        txtamount.Clear()
        txtcriticallevel.Clear()
        txtproductname.Clear()
        txtquantity.Clear()
        txtstatus.Text = "*****"
    End Sub
    Dim l As ListViewItem
    Dim amount As Double
    Private Sub btnaddtocart_Click(sender As Object, e As EventArgs) Handles btnaddtocart.Click
        Dim a As String = InputBox("Enter number of products?", "Quantity")
        If txtproductname.Text = "" Or txtcode.Text = "" Or txtquantity.Text = "" Or txtamount.Text = "" Or txtquantity.Text = "" Then
            MsgBox("Please Complete the details", MsgBoxStyle.Exclamation)
        Else
        End If
        If a = "" Or a = 0 Then
            MsgBox("Please enter number of products")
        Else
            If Val(a) > Val(txtquantity.Text) Then
                MsgBox("Number of products is greater than the available products", MsgBoxStyle.Exclamation, "Re-enter number of products")
            Else
                txtquantity.Text = Val(txtquantity.Text) - Val(a)
                amount = Val(txtamount.Text) * Val(a)
                l = Me.ListView1.Items.Add(txtcode.Text)
                l.SubItems.Add(txtproductname.Text)
                l.SubItems.Add(txtamount.Text)
                l.SubItems.Add(a)
                l.SubItems.Add(amount)
                If Val(txtquantity.Text) = 0 Then
                    txtstatus.Text = "OUT OF STOCK"
                ElseIf Val(txtquantity.Text) <= Val(txtcriticallevel.Text) Then
                    txtstatus.Text = "CRITICAL LEVEL"
                End If

            End If

        End If
        GetTotal()
        GetTotalItem()
        getVAT()
    End Sub
    Private Sub GetTotal()
        Const col As Integer = 4
        Dim total As Integer
        Dim lvsi As ListViewItem.ListViewSubItem
        For i As Integer = 0 To ListView1.Items.Count - 1
            lvsi = ListView1.Items(i).SubItems(col)
            total += Double.Parse(lvsi.Text)
        Next
        lblTotal.Text = Format(Val(total), "0.00")
    End Sub

    Private Sub GetTotalItem()
        Const col As Integer = 3
        Dim total As Integer
        Dim lvsi As ListViewItem.ListViewSubItem
        For i As Integer = 0 To ListView1.Items.Count - 1
            lvsi = ListView1.Items(i).SubItems(col)
            total += Double.Parse(lvsi.Text)
        Next
        lbltotalitems.Text = Val(total)
    End Sub

    Private Sub btnremove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        If MsgBox("Remove Product?", vbQuestion + vbYesNo) = vbYes Then
            If ListView1.Items.Count = 0 Then
                MsgBox("No Products on the list", MsgBoxStyle.Critical)
            Else
                If ListView1.SelectedItems.Count > 0 Then
                    Dim lvalue As Integer = Integer.Parse(ListView1.SelectedItems(0).SubItems(3).Text)
                    Dim newQty As Integer = lvalue + Val(txtquantity.Text)
                    txtquantity.Text = newQty
                    ListView1.Items.Remove(ListView1.FocusedItem)
                    If Val(txtquantity.Text) > Val(txtcriticallevel.Text) Then
                        txtstatus.Text = "Available"
                    End If
                    GetTotalItem()
                    GetTotal()
                    getVAT()
                End If

            End If
        End If
    End Sub

    Private Sub btnpayment_Click(sender As Object, e As EventArgs) Handles btnpayment.Click
        frmPayments.Show()
        frmPayments.lblGrandTotal.Text = Me.lblTotal.Text
    End Sub
    Private Sub getVAT()
        Dim vatableSales As Double
        vatableSales = lblTotal.Text / 1.12
        lblvatamount.Text = Format(Val(vatableSales), "0.00")
        lblvatavlesales.Text = Val(lblTotal.Text) - Val(lblvatamount.Text)
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If MsgBox("Save Transaction?", vbQuestion + vbYesNo) = vbYes Then

            If Val(lblamountpaid.Text) < Val(lblTotal.Text) Then
                MsgBox("Insufficient Amount Paid", MsgBoxStyle.Critical, "Please Re-Enter Payment")
            Else
                'saving transaction
                sql = "Insert into tblTransactions(TransNo,TransDate,TransTime,TotalAmount,Change,VAT,VatableSales,CashierName)values(@TransNo,@TransDate,@TransTime,@TotalAmount,@Change,@VAT,@VatableSales,@CashierName)"
                cmd = New OleDbCommand(sql, cn)
                With cmd
                    .Parameters.AddWithValue("@TransNo", lblTransNo.Text)
                    .Parameters.AddWithValue("@TransDate", lblDate.Text)
                    .Parameters.AddWithValue("@TransTime", lblTime.Text)
                    .Parameters.AddWithValue("@TotalAmount", lblTotal.Text)
                    .Parameters.AddWithValue("@Change", lblamountchange.Text)
                    .Parameters.AddWithValue("@VAT", lblvatamount.Text)
                    .Parameters.AddWithValue("@VatableSales", lblvatavlesales.Text)
                    .Parameters.AddWithValue("@CashierName", lblcashier.Text)
                    .ExecuteNonQuery()
                End With

                For Each i As ListViewItem In ListView1.Items
                    sql = "Insert into tblTransactionDetails(TransNo,ProductCode,Amount,Qty,Total)Values(@TransNo,@ProductCode,@Amount,@Qty,@Total)"
                    cmd = New OleDbCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@TransNo", lblTransNo.Text)
                    cmd.Parameters.AddWithValue("@ProductCode", i.Text)
                    cmd.Parameters.AddWithValue("@Amount", i.SubItems(2).Text)
                    cmd.Parameters.AddWithValue("@Qty", i.SubItems(3).Text)
                    cmd.Parameters.AddWithValue("@Total", i.SubItems(4).Text)
                    cmd.ExecuteNonQuery()
                Next

                sql = "Insert into tblpayments(TransNo,TotalAmount,AmountPaid,AmountChange,MOP,RefNo)Values(@TransNo,@TotalAmount,@AmountPaid,@AmountChange,@MOP,@RefNo)"
                cmd = New OleDbCommand(sql, cn)
                cmd.Parameters.AddWithValue("@TransNo", lblTransNo.Text)
                cmd.Parameters.AddWithValue("@TotalAmount", lblTotal.Text)
                cmd.Parameters.AddWithValue("@AmountPaid", lblamountpaid.Text)
                cmd.Parameters.AddWithValue("@AmountChange", lblamountchange.Text)
                cmd.Parameters.AddWithValue("@MOP", lblmodepayment.Text)
                cmd.Parameters.AddWithValue("@RefNo", lblreferencenumber.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Transaction Successfully Saved", MsgBoxStyle.Information)
                ListView1.Items.Clear()
                Call resetCurrency()
            End If
            sql = "update tblProducts set Quantity=@Quantity where ProductCode=@ProductCode"
            cmd = New OleDbCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@Quantity", txtquantity.Text)
                .Parameters.AddWithValue("@ProductCode", txtcode.Text)
                .ExecuteNonQuery()

            End With
        End If
        Call getTransactionNo()
    End Sub
    Private Sub resetCurrency()
        lblamountpaid.Text = "0.00"
        lblvatamount.Text = "0.00"
        lblvatavlesales.Text = "0.00"
        lbltotalitems.Text = "0.00"
        lblmodepayment.Text = "******"
        lblreferencenumber.Text = "*****"
        lblTotal.Text = "0.00"
        lblamountchange.Text = "0.00"
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call ResetText()
        Call clearText()
        ListView1.Items.Clear()
        Call resetCurrency()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Log out account?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Good bye" & lblcashier.Text & "  " & " Have a nice day!!!", MsgBoxStyle.Information, "USER LOGOUT")
            Me.Hide()
            'Login.Show()

        End If
    End Sub

    Private Sub txtcode_TextChanged_1(sender As Object, e As EventArgs) Handles txtcode.TextChanged
        sql = "Select prodName,Amount,Quantity,CriticalLevel,Status from qryProducts where productCode= '" & txtcode.Text & "' and Quantity> '0'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            txtproductname.Text = dr(0)        'Productname
            txtamount.Text = dr(1)             'Amount
            txtquantity.Text = dr(2)           'Quantity
            txtcriticallevel.Text = dr(3)      'CriticalLevel
            txtstatus.Text = dr(4)             'Status
        Else
            MsgBox("Items Not Found or out of Stocked", MsgBoxStyle.Critical)
            clearText()
        End If
    End Sub
    Private Sub LoadItems()
        sql = "SELECT * FROM tblProducts"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView2.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("ProductCode").ToString)
            x.SubItems.Add(dr("ProdName").ToString)
            x.SubItems.Add(dr("ProdDescription").ToString)
            x.SubItems.Add(dr("Category").ToString)
            ListView2.Items.Add(x)
        Loop
        'dr.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmpostransactionrecord.ShowDialog()
    End Sub
    Private Sub LoadItems(Optional ByVal category As String = "")
        Dim sql As String
        If String.IsNullOrEmpty(category) Then
            sql = "SELECT * FROM tblProducts"
        Else
            sql = "SELECT * FROM tblProducts WHERE Category = @Category"
        End If

        cmd = New OleDbCommand(sql, cn)
        If Not String.IsNullOrEmpty(category) Then
            cmd.Parameters.AddWithValue("@Category", category)
        End If
        dr = cmd.ExecuteReader()

        ListView2.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("ProductCode").ToString)
            x.SubItems.Add(dr("ProdName").ToString)
            x.SubItems.Add(dr("ProdDescription").ToString)
            x.SubItems.Add(dr("Category").ToString)
            ListView2.Items.Add(x)
        Loop
        dr.Close()
    End Sub

    Private Sub LoadCategories()
        Dim sql As String = "SELECT DISTINCT Category FROM tblProducts"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader()

        While dr.Read()
            ComboBoxCategory.Items.Add(dr("Category").ToString)
        End While
        dr.Close()
    End Sub

    Private Sub ListView2_ItemActivate(sender As Object, e As EventArgs) Handles ListView2.ItemActivate
        If ListView2.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView2.SelectedItems(0)
            Dim productCode As String = selectedItem.SubItems(0).Text
            Dim prodName As String = selectedItem.SubItems(1).Text
            Dim prodDescription As String = selectedItem.SubItems(2).Text
            Dim category As String = selectedItem.SubItems(3).Text

        End If
    End Sub

    Private Sub ComboBoxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCategory.SelectedIndexChanged
        Dim selectedCategory As String = ComboBoxCategory.SelectedItem.ToString()
        LoadItems(selectedCategory)
    End Sub

    Private Sub ListView2_Click(sender As Object, e As EventArgs) Handles ListView2.Click
        If ListView2.SelectedItems.Count > 0 Then
            txtcode.Text = ListView2.SelectedItems(0).SubItems(0).Text
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmreturn.ShowDialog()
    End Sub
End Class