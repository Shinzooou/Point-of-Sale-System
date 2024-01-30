Imports System.Data.OleDb

Public Class frmstockinrecord

    Private Sub frmstockinrecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
        LoadProducts()
    End Sub


    Private Sub LoadProducts()
        sql = "SELECT * FROM qryall"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView1.Items.Clear()
        Do While dr.Read()
            Dim x As New ListViewItem(dr("TransNo").ToString)
            x.SubItems.Add(dr("transDate").ToString)
            x.SubItems.Add(dr("TransTime").ToString)
            x.SubItems.Add(dr("ProdName").ToString)
            x.SubItems.Add(dr("ProdDescription").ToString)
            x.SubItems.Add(dr("Category").ToString)
            x.SubItems.Add(dr("Amount").ToString)
            x.SubItems.Add(dr("Quantity").ToString)
            x.SubItems.Add(dr("CriticalLevel").ToString)
            x.SubItems.Add(dr("Status").ToString)
            ListView1.Items.Add(x)
        Loop

    End Sub
End Class