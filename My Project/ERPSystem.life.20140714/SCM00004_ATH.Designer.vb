<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00004_ATH
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
        Me.pBoxImage = New System.Windows.Forms.PictureBox
        CType(Me.pBoxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pBoxImage
        '
        Me.pBoxImage.Location = New System.Drawing.Point(25, 22)
        Me.pBoxImage.Name = "pBoxImage"
        Me.pBoxImage.Size = New System.Drawing.Size(181, 196)
        Me.pBoxImage.TabIndex = 0
        Me.pBoxImage.TabStop = False
        '
        'SCM00004_ATH
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(238, 255)
        Me.Controls.Add(Me.pBoxImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "SCM00004_ATH"
        Me.Text = "預覽運輸標籤"
        CType(Me.pBoxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pBoxImage As System.Windows.Forms.PictureBox
End Class
