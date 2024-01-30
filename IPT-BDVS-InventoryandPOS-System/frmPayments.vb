Imports System.Data.OleDb
Public Class frmPayments
    Private Sub frmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadMOP()
    End Sub
    Private Sub loadMOP()
        sql = "Select distinct PaymentMode from tblPaymentMode where status='1'"
        cmd = New OleDbCommand(sql, cn)
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        cboMOP.DataSource = dt
        cboMOP.DisplayMember = "PaymentMode"
    End Sub

    Private Sub cboMOP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMOP.SelectedIndexChanged
        If cboMOP.Text = "Cash" Then
            txtRefNo.ReadOnly = True
            txtAmountPaid.Clear()
            txtAmountPaid.Enabled = True
        Else
            txtRefNo.ReadOnly = False
            txtAmountPaid.Text = lblGrandTotal.Text
            txtChange.Text = "0.00"
            txtAmountPaid.Enabled = False
        End If
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        Dim change As Double
        change = Val(txtAmountPaid.Text) - Val(lblGrandTotal.Text)
        txtChange.Text = Format(Val(change), "0.00")
    End Sub

    Private Sub btnEnterpayment_Click(sender As Object, e As EventArgs) Handles btnEnterpayment.Click
        If Val(txtAmountPaid.Text) < Val(lblGrandTotal.Text) Then
            MsgBox("Insufficient Payment", MsgBoxStyle.Critical)
        Else
            frmPOS.lblamountpaid.Text = Me.txtAmountPaid.Text
            frmPOS.lblamountchange.Text = Me.txtChange.Text
            frmPOS.lblmodepayment.Text = Me.cboMOP.Text
            frmPOS.lblreferencenumber.Text = Me.txtRefNo.Text
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As String = InputBox("Enter mode of payment")
        sql = "Insert into tblPaymentMode(PaymentMode,Status)values(@PaymentMode,@Status)"
        cmd = New OleDbCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@PaymentMode", a)
            .Parameters.AddWithValue("@Status", "1")
            .ExecuteNonQuery()
        End With
    End Sub
End Class