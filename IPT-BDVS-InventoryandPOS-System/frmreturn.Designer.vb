<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmreturn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmreturn))
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TransNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProductCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTransNo = New System.Windows.Forms.TextBox()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.bntFilter = New System.Windows.Forms.Button()
        Me.btnRefund = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.MediumPurple
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TransNo, Me.ProductCode, Me.Amount, Me.Qty, Me.Total})
        Me.ListView2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.GridLines = True
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(11, 213)
        Me.ListView2.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1064, 297)
        Me.ListView2.TabIndex = 3
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'TransNo
        '
        Me.TransNo.Text = "Trans Number"
        Me.TransNo.Width = 298
        '
        'ProductCode
        '
        Me.ProductCode.Text = "Product Code"
        Me.ProductCode.Width = 187
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 193
        '
        'Qty
        '
        Me.Qty.Text = "Qty"
        Me.Qty.Width = 215
        '
        'Total
        '
        Me.Total.Text = "Total"
        Me.Total.Width = 166
        '
        'txtTransNo
        '
        Me.txtTransNo.Location = New System.Drawing.Point(164, 117)
        Me.txtTransNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(128, 20)
        Me.txtTransNo.TabIndex = 59
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(164, 146)
        Me.txtProductCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(128, 20)
        Me.txtProductCode.TabIndex = 58
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 117)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 17)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Transaction Number"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 146)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 17)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Product Code"
        '
        'bntFilter
        '
        Me.bntFilter.BackColor = System.Drawing.Color.Transparent
        Me.bntFilter.Image = CType(resources.GetObject("bntFilter.Image"), System.Drawing.Image)
        Me.bntFilter.Location = New System.Drawing.Point(296, 117)
        Me.bntFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.bntFilter.Name = "bntFilter"
        Me.bntFilter.Size = New System.Drawing.Size(56, 49)
        Me.bntFilter.TabIndex = 60
        Me.bntFilter.UseVisualStyleBackColor = False
        '
        'btnRefund
        '
        Me.btnRefund.BackColor = System.Drawing.Color.Transparent
        Me.btnRefund.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefund.Image = CType(resources.GetObject("btnRefund.Image"), System.Drawing.Image)
        Me.btnRefund.Location = New System.Drawing.Point(11, 514)
        Me.btnRefund.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRefund.Name = "btnRefund"
        Me.btnRefund.Size = New System.Drawing.Size(58, 57)
        Me.btnRefund.TabIndex = 61
        Me.btnRefund.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Impact", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(404, 28)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(254, 43)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Returned Items"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1027, 164)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(47, 45)
        Me.Button3.TabIndex = 96
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1085, 100)
        Me.Panel1.TabIndex = 97
        '
        'frmreturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Indigo
        Me.ClientSize = New System.Drawing.Size(1085, 651)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnRefund)
        Me.Controls.Add(Me.bntFilter)
        Me.Controls.Add(Me.txtTransNo)
        Me.Controls.Add(Me.txtProductCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ListView2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmreturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmreturn"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView2 As ListView
    Friend WithEvents TransNo As ColumnHeader
    Friend WithEvents ProductCode As ColumnHeader
    Friend WithEvents Amount As ColumnHeader
    Friend WithEvents Qty As ColumnHeader
    Friend WithEvents Total As ColumnHeader
    Friend WithEvents txtTransNo As TextBox
    Friend WithEvents txtProductCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents bntFilter As Button
    Friend WithEvents btnRefund As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel1 As Panel
End Class
