Imports System.Data.OleDb

Module DatabaseConnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public sql As String

    Public Sub Connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matts\Downloads\IPT-BDVS-InventoryandPOS-System 1\IPT-BDVS-InventoryandPOS-System\IPT-BDVS-InventoryandPOS-System\IPT-BDVS-InventoryandPOS-System\bin\Debug\bdvsdatabase.accdb"
        cn.Open()
    End Sub

End Module
