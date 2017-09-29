Public Class frmImage

    Private Sub frmImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        originalPGSize = New Size(CInt(Math.Round(Me.Size.Width - 18)), _
                                       CInt(Math.Round(Me.Size.Height - 80)))
        'init this from here or a method depending on your needs
        If pbImage.Image IsNot Nothing Then
            originalSize = pbImage.Image.Size
            pbImage.Size = originalSize
            pbImage.SizeMode = PictureBoxSizeMode.Zoom
            Dim sh = originalPGSize.Height / pbImage.Image.Size.Height
            Dim sw = originalPGSize.Width / pbImage.Image.Size.Width
            scale = sh
            If sw < sh Then
                scale = sw
            End If
            pbImage.Size = New Size(CInt(Math.Round(originalSize.Width * scale)), _
                                            CInt(Math.Round(originalSize.Height * scale)))
        End If
        
    End Sub
    Private originalSize As Size = Nothing
    Private originalPGSize As Size = Nothing
    Private scale As Single = 1
    Private scaleDelta As Single = 0.0005
    Private Sub frmImage_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Panel1.Height = Me.Size.Height - 78
        Panel1.Width = Me.Size.Width - 16
    End Sub

    Private Sub frmImage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        pbImage.Image = Nothing
        pbImage.SizeMode = PictureBoxSizeMode.AutoSize
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        scaleDelta = Math.Sqrt(pbImage.Width * pbImage.Height) * 0.0001
        scale += scaleDelta
        pbImage.Size = New Size(CInt(Math.Round(originalSize.Width * scale)), _
                                    CInt(Math.Round(originalSize.Height * scale)))
    End Sub

    Private Sub BtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoomOut.Click
        scaleDelta = Math.Sqrt(pbImage.Width * pbImage.Height) * 0.0001
        scale -= scaleDelta
        pbImage.Size = New Size(CInt(Math.Round(originalSize.Width * scale)), _
                                    CInt(Math.Round(originalSize.Height * scale)))
    End Sub
End Class