Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmmanageacc
    Private Sub frmmanageacc_Load(sender As Object, e As EventArgs)
        Call Connection()
        LoadAccounts()
    End Sub
    Private Sub SaveData()
        sql = "Insert Into tblUsers([EmpID], [Lastname], [Firstname], [Middlename], [ContactNumber], [Email], [Bdate], [Sex], [Role], [AccStatus]) values([@EmpID], [@Lastname], [@Firstname], [@Middlename], [@ContactNumber], [@Email], [@Bdate], [@Sex], [@Role], [@AccStatus])"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("[@EmpID]", txtEmpID.Text)
            .Parameters.AddWithValue("[@Lastname]", txtLName.Text)
            .Parameters.AddWithValue("[@Firstname]", txtFName.Text)
            .Parameters.AddWithValue("[@Middlename]", txtMName.Text)
            .Parameters.AddWithValue("[@ContactNumber]", txtCNumber.Text)
            .Parameters.AddWithValue("[@Email]", txtEmail.Text)
            .Parameters.AddWithValue("[@Bdate]", dtpBday.Value.ToString)
            .Parameters.AddWithValue("[@Sex]", cbSex.Text)
            .Parameters.AddWithValue("[@Role]", cbRole.Text)
            .Parameters.AddWithValue("[@AccStatus]", cbStatus.Text)
            .ExecuteNonQuery()
        End With
        clear()
        LoadAccounts()
    End Sub
    Private Sub CheckUser()
        sql = "Select EmpID from tblUsers where EmpID='" & txtEmpID.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            MsgBox("User is already Exist", MsgBoxStyle.Exclamation)
        ElseIf String.IsNullOrWhiteSpace(txtEmpID.Text) OrElse String.IsNullOrWhiteSpace(txtLName.Text) OrElse String.IsNullOrWhiteSpace(txtFName.Text) _
            OrElse String.IsNullOrWhiteSpace(txtMName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) OrElse String.IsNullOrWhiteSpace(txtCNumber.Text) _
            OrElse String.IsNullOrWhiteSpace(cbSex.Text) OrElse String.IsNullOrWhiteSpace(dtpBday.Text) OrElse String.IsNullOrWhiteSpace(cbRole.Text) _
            OrElse String.IsNullOrWhiteSpace(cbStatus.Text) Then
            MsgBox("All fields are required!", vbCritical, "Error")
            Return
        Else
            If MsgBox("Are you sure you want to add new user?", vbQuestion + vbYesNo) = vbYes Then
                MsgBox("New User Added!", MsgBoxStyle.Information, "New User Saved")
                SavePass()

            Else
                MsgBox("User not saved.", MsgBoxStyle.Information, "Operation Canceled")
            End If
        End If


    End Sub
    Private Sub SavePass()
        If txtPassword.Text <> txtRePass.Text Then
            MsgBox("Pin Mismatch", MsgBoxStyle.Critical, "Re-Type PIN")
        Else

            sql = "Insert Into tblPassword ([EmpID], [Password]) values ([@EmpID], [@Password])"
            cmd = New OleDbCommand(sql, cn)

            With cmd
                .Parameters.AddWithValue("[@EmpID]", txtEmpID.Text)
                .Parameters.AddWithValue("[@Password]", txtPassword.Text)
                .ExecuteNonQuery()
            End With
            SaveData()
        End If
    End Sub
    Private Sub clear()
        txtLName.Clear()
        txtFName.Clear()
        txtMName.Clear()
        txtCNumber.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        txtRePass.Clear()
        cbSex.Text = " "
        cbRole.Text = " "
        cbStatus.Text = " "
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        CheckUser()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()

    End Sub
    Private Sub UpdateData()
        sql = "Update tblUsers set Lastname=@Lastname, Firstname=@Firstname, Middlename=@Middlename, ContactNumber=@ContactNumber, Email=@Email, Bdate=@Bdate, Sex=@Sex, Role=@Role, AccStatus=@AccStatus where EmpID=@EmpID"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@Lastname", txtLName.Text)
            .Parameters.AddWithValue("@Firstname", txtFName.Text)
            .Parameters.AddWithValue("@Middlename", txtMName.Text)
            .Parameters.AddWithValue("@ContactNumber", txtCNumber.Text)
            .Parameters.AddWithValue("@Email", txtEmail.Text)
            .Parameters.AddWithValue("@Bdate", dtpBday.Value.ToString)
            .Parameters.AddWithValue("@Sex", cbSex.Text)
            .Parameters.AddWithValue("@Role", cbRole.Text)
            .Parameters.AddWithValue("@AccStatus", cbStatus.Text)
            .Parameters.AddWithValue("@EmpID", txtEmpID.Text)
            .ExecuteNonQuery()

        End With
        UpdatePass()
        clear()
        LoadAccounts()

    End Sub
    Private Sub UpdatePass()
        sql = "UPDATE tblPassword set [Password] = @Password where [EmpID] = @EmpID"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@Password", txtPassword.Text)
            .Parameters.AddWithValue("@EmpID", txtEmpID.Text)
            .ExecuteNonQuery()

        End With
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtPassword.Text <> txtRePass.Text Then
            MsgBox("PIN and Re-PIN mismatched", MsgBoxStyle.Critical)
        ElseIf String.IsNullOrWhiteSpace(txtEmpID.Text) OrElse String.IsNullOrWhiteSpace(txtLName.Text) OrElse String.IsNullOrWhiteSpace(txtFName.Text) _
            OrElse String.IsNullOrWhiteSpace(txtMName.Text) OrElse String.IsNullOrWhiteSpace(txtEmail.Text) OrElse String.IsNullOrWhiteSpace(txtCNumber.Text) _
            OrElse String.IsNullOrWhiteSpace(cbSex.Text) OrElse String.IsNullOrWhiteSpace(dtpBday.Text) OrElse String.IsNullOrWhiteSpace(cbRole.Text) _
            OrElse String.IsNullOrWhiteSpace(cbStatus.Text) Then
            MsgBox("All fields are required!", vbCritical, "Error")
            Return
        Else
            If MsgBox("Are you sure you want to update user info?", vbQuestion + vbYesNo) = vbYes Then
                MsgBox("Saved Successfully!", MsgBoxStyle.Information, "Updated User Info Saved")
                UpdateData()
            Else
                MsgBox("User not saved.", MsgBoxStyle.Information, "Operation Canceled")
            End If

        End If
    End Sub
    Private Sub LoadAccounts()
        sql = "Select * from qryUsers"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        Dim x As ListViewItem
        ListView1.Items.Clear()
        Do While dr.Read = True

            x = New ListViewItem(dr("EmpID").ToString)
            x.SubItems.Add(dr("Lastname").ToString & " " & dr("Firstname").ToString)
            x.SubItems.Add(dr("Role").ToString)
            x.SubItems.Add(dr("Sex").ToString)
            x.SubItems.Add(dr("Bdate").ToString)
            x.SubItems.Add(dr("ContactNumber").ToString)
            x.SubItems.Add(dr("Email").ToString)
            x.SubItems.Add(dr("Password").ToString)
            x.SubItems.Add(dr("AccStatus").ToString)
            ListView1.Items.Add(x)
        Loop
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            txtEmpID.Text = ListView1.SelectedItems(0).SubItems(0).Text
        End If
    End Sub
    Private Sub txtEmpID_TextChanged(sender As Object, e As EventArgs) Handles txtEmpID.TextChanged
        sql = "Select Lastname, Firstname, Middlename, ContactNumber, Email, Sex, Role, Password, AccStatus, Bdate from qryUsers where EmpID='" & txtEmpID.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then      'Productname
            txtLName.Text = dr(0)             'Amount   
            txtFName.Text = dr(1)           'Quantity
            txtMName.Text = dr(2)      'CriticalLevel
            txtCNumber.Text = dr(3)
            txtEmail.Text = dr(4)
            cbSex.Text = dr(5)
            cbRole.Text = dr(6)
            txtPassword.Text = dr(7)
            cbStatus.Text = dr(8)
            dtpBday.Text = dr(9)

        Else
            clear()
        End If
    End Sub

    Private Sub frmmanageacc_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        LoadAccounts()
    End Sub
End Class