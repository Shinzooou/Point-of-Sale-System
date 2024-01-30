Imports System.Data.OleDb
Public Class frmemployeelogin

    Private Sub frmemployeelogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()

    End Sub


    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        sql = "Select * from qryAcc where EmpID='" & txtEmpID.Text & "' and Password='" & txtPassword.Text & "' and AccStatus='Active'"

        cmd = New OleDbCommand(sql, cn)

        dr = cmd.ExecuteReader

        If dr.Read = True Then
            frmempdashboard.lblAccNo.Text = dr("EmpID").ToString
            MsgBox("Login in Sucess", MsgBoxStyle.Information)
            frmempdashboard.Show()
            Me.Hide()




        Else

            MsgBox("Login in Failed", MsgBoxStyle.Critical)

            lblattempts.Text = lblattempts.Text - 1

            If lblattempts.Text = "0" Then

                MsgBox("You reached the maximum attempt limits", MsgBoxStyle.Critical)

                Call DisabledAccount()

                btnLogin.Enabled = False

            End If

        End If


        ''End If

    End Sub

    Private Sub DisabledAccount()
        sql = "Update tblUsers SET AccStatus = @AcctStatus where EmpID = @EmpID"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@AccStatus", "Disable")
            .Parameters.AddWithValue("@EmpID", txtEmpID.Text)
            .ExecuteNonQuery()

        End With

        MsgBox("You're Account is disabled, contact the nearest branch to activate your account", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub CheckIfDisabled()
        sql = "Select AccStatus from qryAcc where EmpID = '" & txtEmpID.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows = True Then
            MsgBox("This Account is disabled", MsgBoxStyle.Critical)
        Else

            If lblattempts.Text = "0" Then
                MsgBox("You reached the maximum attempt limits", MsgBoxStyle.Critical)
                Call DisabledAccount()
                btnLogin.Enabled = False
            End If
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
