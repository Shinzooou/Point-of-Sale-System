<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrefund
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TransNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TransDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TransTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Change = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VatableSales = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VAT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CashierName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.MediumPurple
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TransNo, Me.TransDate, Me.TransTime, Me.TotalAmount, Me.Change, Me.VatableSales, Me.VAT, Me.CashierName})
        Me.ListView2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.GridLines = True
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(24, 151)
        Me.ListView2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1093, 297)
        Me.ListView2.TabIndex = 2
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'TransNo
        '
        Me.TransNo.Text = "Trans Number"
        Me.TransNo.Width = 130
        '
        'TransDate
        '
        Me.TransDate.Text = "Date"
        Me.TransDate.Width = 130
        '
        'TransTime
        '
        Me.TransTime.Text = "Time"
        Me.TransTime.Width = 137
        '
        'TotalAmount
        '
        Me.TotalAmount.Text = "Total Amount"
        Me.TotalAmount.Width = 215
        '
        'Change
        '
        Me.Change.Text = "Change"
        Me.Change.Width = 166
        '
        'VatableSales
        '
        Me.VatableSales.Text = "Vatable Sales"
        Me.VatableSales.Width = 191
        '
        'VAT
        '
        Me.VAT.Text = "VAT"
        Me.VAT.Width = 180
        '
        'CashierName
        '
        Me.CashierName.Text = "Cashier"
        Me.CashierName.Width = 564
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Impact", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(419, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(302, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "LIST OF RETURNED ITEMS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1149, 100)
        Me.Panel1.TabIndex = 4
        '
        'frmrefund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Indigo
        Me.ClientSize = New System.Drawing.Size(1148, 480)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListView2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmrefund"
        Me.Text = "frmrefund"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView2 As ListView
    Friend WithEvents TransNo As ColumnHeader
    Friend WithEvents TransDate As ColumnHeader
    Friend WithEvents TransTime As ColumnHeader
    Friend WithEvents TotalAmount As ColumnHeader
    Friend WithEvents Change As ColumnHeader
    Friend WithEvents VatableSales As ColumnHeader
    Friend WithEvents VAT As ColumnHeader
    Friend WithEvents CashierName As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
End Class
