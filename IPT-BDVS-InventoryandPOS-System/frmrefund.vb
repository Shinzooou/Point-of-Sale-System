Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmrefund
    Private Sub frmrefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        LoadProducts()
    End Sub
    Private Sub LoadProducts()
        sql = "SELECT * FROM tblreturneditems"
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

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub
End Class