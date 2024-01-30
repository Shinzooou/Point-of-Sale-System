Imports System.Data.OleDb

Public Class frmcreateacc
    Private Sub frmcreateacc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        Dim acctnum As New Random
        txtaccountnumber.Text = acctnum.Next(0, 1000000000)
    End Sub

    Private Sub btncreate_Click(sender As Object, e As EventArgs) Handles btncreate.Click
        If txtaccountnumber.Text = "" Or txtlastname.Text = "" Or txtfirstname.Text = "" Or txtpin.Text = "" Or txtreenterpin.Text = "" Then
            MsgBox("Please fill up all", MsgBoxStyle.Exclamation)
        Else
            Call checkaccounts()
        End If
    End Sub

    Private Sub savedata()
        sql = "SELECT AccountNo FROM tblAccounts WHERE AccountNo = @AccounttNo"
        cmd = New OleDbCommand(sql, cn)
        cmd.Parameters.AddWithValue("@AccounttNo", txtaccountnumber.Text)
        dr = cmd.ExecuteReader

        If String.IsNullOrWhiteSpace(txtaccountnumber.Text) Or String.IsNullOrWhiteSpace(txtlastname.Text) Or String.IsNullOrWhiteSpace(txtfirstname.Text) Or String.IsNullOrWhiteSpace(txtmiddlename.Text) Or String.IsNullOrWhiteSpace(txtaddress.Text) Or String.IsNullOrWhiteSpace(txtcontactno.Text) Or String.IsNullOrWhiteSpace(txtemail.Text) Or String.IsNullOrWhiteSpace(txtage.Text) Or String.IsNullOrWhiteSpace(DateTimePicker1.Text) Or String.IsNullOrWhiteSpace(cbosex.Text) Then
            MsgBox("The form is incomplete", vbCritical, "Please fill all the boxes")
            Exit Sub
        ElseIf txtaccountnumber.TextLength < 10 Then
            MsgBox("Account must be at least 10 characters", vbCritical, "Please Retype Your Account Number")
            Exit Sub
        ElseIf dr.Read Then
            MsgBox("Account Number Already Exists", vbCritical, "Please Retype Your Account Number")
            dr.Close()
            Exit Sub
        ElseIf txtpin.Text <> txtreenterpin.Text Then
            MsgBox("PIN is mismatch", vbCritical, "Retype your PIN")
            Exit Sub
        ElseIf txtpin.TextLength < 8 Then
            MsgBox("Pin must be at least 8 characters", vbCritical, "Please Retype Your PIN")
            Exit Sub
        End If

        sql = "Insert into tblAccounts([AccountNo], [Lastname], [Firstname], [MiddleName], [Address], [ContactNumber], [EmailAdd], [Age], [BirthDate], [Sex], [AccountStatus]) values ([@AccountNo], [@Lastname], [@Firstname], [@MiddleName], [@Address], [@ContactNumber], [@EmailAdd], [@Age], [@BirthDate], [@Sex], [@AccountStatus])"
        cmd = New OleDbCommand(sql, cn)
        cmd.Parameters.AddWithValue("[@AccountNo]", txtaccountnumber.Text)
        cmd.Parameters.AddWithValue("[@Lastname]", txtlastname.Text)
        cmd.Parameters.AddWithValue("[@Firstname]", txtfirstname.Text)
        cmd.Parameters.AddWithValue("[@MiddleName]", txtmiddlename.Text)
        cmd.Parameters.AddWithValue("[@Address]", txtaddress.Text)
        cmd.Parameters.AddWithValue("[@ContactNumber]", txtcontactno.Text)
        cmd.Parameters.AddWithValue("[@EmailAdd]", txtemail.Text)
        cmd.Parameters.AddWithValue("[@Age]", txtage.Text)
        cmd.Parameters.AddWithValue("[@BirthDate]", DateTimePicker1.Value.ToString)
        cmd.Parameters.AddWithValue("[@Sex]", cbosex.Text)
        cmd.Parameters.AddWithValue("[@AccountStatus]", "Active")
        cmd.ExecuteNonQuery()
        MsgBox("New Account Successfully Created", MsgBoxStyle.Information, "Client Account")
    End Sub
    Private Sub SavePin()
        If txtpin.Text <> txtreenterpin.Text Then
            MsgBox("Pin is mismatch", MsgBoxStyle.Critical, "Re-type PIN")
        Else
            sql = "Insert into tblPin(AccountNo, PIN) values (@AccountNo, @PIN)"
            cmd = New OleDbCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@AccountNo", txtaccountnumber.Text)
                .Parameters.AddWithValue("@PIN", txtpin.Text)
                .ExecuteNonQuery()
            End With
        End If
        savedata()
    End Sub

    Private Sub checkaccounts()
        sql = "Select AccountNo from tblAccounts where AccountNo='" & txtaccountnumber.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            MsgBox("Account already exists", MsgBoxStyle.Exclamation)
        Else
            SavePin()
        End If

    End Sub
End Class