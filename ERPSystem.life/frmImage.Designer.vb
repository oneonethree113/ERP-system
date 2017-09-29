<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImage))
        Me.pbImage = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnZoomOut = New System.Windows.Forms.Button
        Me.btnZoomIn = New System.Windows.Forms.Button
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImage
        '
        Me.pbImage.BackColor = System.Drawing.Color.White
        Me.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbImage.InitialImage = Nothing
        Me.pbImage.Location = New System.Drawing.Point(1, 0)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(360, 480)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbImage.TabIndex = 74
        Me.pbImage.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pbImage)
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 482)
        Me.Panel1.TabIndex = 75
        '
        'BtnZoomOut
        '
        Me.BtnZoomOut.Image = CType(resources.GetObject("BtnZoomOut.Image"), System.Drawing.Image)
        Me.BtnZoomOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnZoomOut.Location = New System.Drawing.Point(41, 0)
        Me.BtnZoomOut.Name = "BtnZoomOut"
        Me.BtnZoomOut.Size = New System.Drawing.Size(40, 40)
        Me.BtnZoomOut.TabIndex = 77
        Me.BtnZoomOut.UseVisualStyleBackColor = True
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), System.Drawing.Image)
        Me.btnZoomIn.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnZoomIn.Location = New System.Drawing.Point(1, 0)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(40, 40)
        Me.btnZoomIn.TabIndex = 56
        Me.btnZoomIn.UseVisualStyleBackColor = True
        '
        'frmImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 522)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.BtnZoomOut)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmImage"
        Me.Text = "frmImage"
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
End Class
