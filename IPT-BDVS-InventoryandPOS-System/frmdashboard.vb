Imports System.Data.OleDb
Public Class frmdashboard


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        frmPOS.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        frmproduct.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Do you want to Logout?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("BDVS Inventory and Point Of Sale System")

            frmaccesiblity.Show()
            Me.Hide()

        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmmanageacc.ShowDialog()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class