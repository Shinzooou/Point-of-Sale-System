Imports System.Data.OleDb
Imports System.Runtime.CompilerServices.RuntimeHelpers

Public Class frmproduct
    Private Sub frmproduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        Call getTransactionNo()
        LoadProducts()
    End Sub
    Private Sub getTransactionNo()
        sql = "Select TransNo from tblstockintrans order by TransNo desc"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            lblTransNo.Text = Val(dr(0)) + 1
        Else
            lblTransNo.Text = 1000001
        End If
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Call ChecItemCode()
    End Sub
    Private Sub txtcode_TextChanged_1(sender As Object, e As EventArgs) Handles txtcode.TextChanged
        sql = "Select prodName,Amount,Quantity,CriticalLevel,Status,ProdDescription,Category from qryProducts where productCode= '" & txtcode.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            txtproductname.Text = dr(0)        'Productname
            txtprice.Text = dr(1)             'Amount
            txtquantity.Text = dr(2)           'Quantity
            txtcritical.Text = dr(3)      'CriticalLevel
            cbostatus.Text = dr(4)
            txtdescription.Text = dr(5)
            cbocategory.Text = dr(6)
        Else
            clearText()
        End If
    End Sub
    Private Sub clearText()
        txtproductname.Clear()
        txtprice.Clear()
        txtquantity.Clear()
        txtcritical.Clear()
        txtdescription.Clear()
        txtdescription.Clear()
    End Sub
    Private Sub SaveData()
        sql = "Insert into qryall([ProductCode],[ProdName],[ProdDescription],[Category],[Amount],[Quantity],[CriticalLevel],[Status],[SupplierName],[SupplierContact],[TransNo],[TransDate],[TransTime]) values ([@ProdCode],[@ProdName],[@ProdDescription],[@Category],[@Amount],[@Quantity],[@CriticalLevel],[@Status],[@SupplierName],[@SupplierContact],[@TransNo],[@TransDate],[@TransTime])"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("[@ProductCode]", txtcode.Text)
            .Parameters.AddWithValue("[@ProdName]", txtproductname.Text)
            .Parameters.AddWithValue("[@ProdDescription]", txtdescription.Text)
            .Parameters.AddWithValue("[@Category]", cbocategory.Text)
            .Parameters.AddWithValue("[@Amount]", txtprice.Text)
            .Parameters.AddWithValue("[@Quantity]", txtquantity.Text)
            .Parameters.AddWithValue("[@CriticalLevel]", txtcritical.Text)
            .Parameters.AddWithValue("[@Status]", cbostatus.Text)
            .Parameters.AddWithValue("[@SupplierName]", txtsupplier.Text)
            .Parameters.AddWithValue("[@SupplierContact]", txtsuppliercontact.Text)
            .Parameters.AddWithValue("[@TransNo]", lblTransNo.Text)
            .Parameters.AddWithValue("[@TransDate]", lblDate.Text)
            .Parameters.AddWithValue("[@TransTime]", lblTime.Text)
            .ExecuteNonQuery()
        End With
        MsgBox("Product Successfully Save", MsgBoxStyle.Information, "Save Data")
        clearText()
    End Sub
    Private Sub LoadProducts()
        sql = "SELECT * FROM tblProducts"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView1.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("ProdName").ToString)
            x.SubItems.Add(dr("ProductCode").ToString)
            x.SubItems.Add(dr("Quantity").ToString)
            x.SubItems.Add(dr("Amount").ToString)
            x.SubItems.Add(dr("ProdDescription").ToString)
            x.SubItems.Add(dr("Category").ToString)
            ListView1.Items.Add(x)
        Loop

    End Sub


    ' Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
    '  Dim qt As String = txtquantity.Text
    '  Dim st As String = txtaddstock.Text
    '   Dim add As String = (qt + st)

    '  sql = "update tblProducts set Quantity=@Quantity where ProductCode='" & txtcode.Text & "'"
    '  cmd = New OleDbCommand(sql, cn)
    '  With cmd
    '   .Parameters.AddWithValue("@Quatity", (qt) + (st))
    ' .Parameters.AddWithValue("@ProductCode", txtcode.Text)
    ' .ExecuteNonQuery()

    'End With


    ' End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim qt As String = txtquantity.Text
        Dim st As String = txtaddstock.Text
        Dim qtInt As Integer
        Dim stInt As Integer

        ' Convert qt and st to integers
        If Integer.TryParse(qt, qtInt) AndAlso Integer.TryParse(st, stInt) Then
            Dim add As Integer = qtInt + stInt

            sql = "update tblProducts set Quantity=@Quantity where ProductCode=@ProductCode"
            cmd = New OleDbCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@Quantity", add)
                .Parameters.AddWithValue("@ProductCode", txtcode.Text)

                ' Execute the query
                .ExecuteNonQuery()
            End With
            MsgBox("Product Successfully Save", MsgBoxStyle.Information, "Save Data")
        Else

        End If
        Call SaveData()
        Call LoadProducts()
        Call getTransactionNo()
    End Sub
    Private Sub ChecItemCode()
        sql = "Select ProductCode from tblProducts where ProductCode='" & txtcode.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            MsgBox("Product Already Exists", MsgBoxStyle.Exclamation)
        ElseIf String.IsNullOrWhiteSpace(txtcode.Text) OrElse String.IsNullOrWhiteSpace(txtproductname.Text) OrElse String.IsNullOrWhiteSpace(txtdescription.Text) _
   OrElse String.IsNullOrWhiteSpace(cbocategory.Text) OrElse String.IsNullOrWhiteSpace(txtprice.Text) OrElse String.IsNullOrWhiteSpace(txtquantity.Text) _
   OrElse String.IsNullOrWhiteSpace(txtcritical.Text) OrElse String.IsNullOrWhiteSpace(cbostatus.Text) OrElse String.IsNullOrWhiteSpace(txtsupplier.Text) _
   OrElse String.IsNullOrWhiteSpace(txtsuppliercontact.Text) Then
            MsgBox("All fields are required!", vbCritical, "Error")
            Return
        Else
            If MsgBox("Saved Successfully!", MsgBoxStyle.Information, "Updated Product Info Saved") Then
                SaveData()
            Else
                MsgBox("User not saved.", MsgBoxStyle.Information, "Operation Canceled")
            End If

        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString
        lblTime.Text = Now.ToShortTimeString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        frmstockinrecord.ShowDialog()
    End Sub
    Private Sub UpdateData()
        sql = "Update qryall set ProdName=@ProdName, ProdDescription=@ProdDescription, Category=@Category, Amount=@Amount, Quantity=@Quantity, CriticalLevel=@CriticalLevel, Status=@Status, SupplierName=@SupplierName, SupplierContact=@SupplierContact  where ProductCode=@ProductCode"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@ProdName", txtproductname.Text)
            .Parameters.AddWithValue("@ProdDescription", txtdescription.Text)
            .Parameters.AddWithValue("@Category", cbocategory.Text)
            .Parameters.AddWithValue("@Amount", txtprice.Text)
            .Parameters.AddWithValue("@Quantity", txtquantity.Text)
            .Parameters.AddWithValue("@CriticalLevel", txtcritical.ToString)
            .Parameters.AddWithValue("@Status", cbostatus.Text)
            .Parameters.AddWithValue("@SupplierName", txtsupplier.Text)
            .Parameters.AddWithValue("@SupplierContact", txtsuppliercontact.Text)
            .Parameters.AddWithValue("@ProductCode", txtcode.Text)
            .ExecuteNonQuery()

        End With
        clearText()
        LoadProducts()

    End Sub
    Private Sub btnupdate1_click(sender As Object, e As EventArgs) Handles btnupdate1.Click
        If txtcode.Text <> txtcode.Text Then
            MsgBox("Enter Existing Code", MsgBoxStyle.Critical)
        ElseIf String.IsNullOrWhiteSpace(txtcode.Text) OrElse String.IsNullOrWhiteSpace(txtproductname.Text) OrElse String.IsNullOrWhiteSpace(txtdescription.Text) _
        OrElse String.IsNullOrWhiteSpace(cbocategory.Text) OrElse String.IsNullOrWhiteSpace(txtprice.Text) OrElse String.IsNullOrWhiteSpace(txtquantity.Text) _
        OrElse String.IsNullOrWhiteSpace(txtcritical.Text) OrElse String.IsNullOrWhiteSpace(cbostatus.Text) OrElse String.IsNullOrWhiteSpace(txtsupplier.Text) _
        OrElse String.IsNullOrWhiteSpace(txtsuppliercontact.Text) Then
            MsgBox("All fields are required!", vbCritical, "Error")
            Return
        Else
            If MsgBox("Are you sure you want to update product info?", vbQuestion + vbYesNo) = vbYes Then
                MsgBox("Saved Successfully!", MsgBoxStyle.Information, "Updated Product Info Saved")
                UpdateData()
            Else
                MsgBox("User not saved.", MsgBoxStyle.Information, "Operation Canceled")
            End If

        End If

    End Sub
End Class