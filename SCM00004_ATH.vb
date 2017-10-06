Public Class SCM00004_ATH

    Dim posX As Integer
    Dim posY As Integer

    Dim maxX As Integer
    Dim maxY As Integer

    Const minX As Integer = 100
    Const minY As Integer = 100

    Dim isMove As Boolean

    Public myOwner As SCM00004

    Private Sub SCM00004_ATH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        pBoxImage.Load(gs_PDO_SMImg & myOwner.lstShipMark.SelectedItem.ToString)
        Dim img As Image = Image.FromFile(gs_PDO_SMImg & myOwner.lstShipMark.SelectedItem.ToString)
        maxX = img.Size.Width
        maxY = img.Size.Height
        pBoxImage.Size = New Size(maxX, maxY)
        pBoxImage.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub pBoxImage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pBoxImage.MouseDown
        posX = e.X
        posY = e.Y
        isMove = True
    End Sub

    Private Sub pBoxImage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pBoxImage.MouseMove
        If isMove Then
            pBoxImage.Location = New Point(pBoxImage.Location.X + e.X - posX, pBoxImage.Location.Y + e.Y - posY)
        End If
    End Sub

    Private Sub pBoxImage_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pBoxImage.MouseUp
        isMove = False
    End Sub

    Private Sub SCM00004_ATH_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        'MsgBox(e.Delta)
        If e.Delta > 0 Then
            ' Contract
            If pBoxImage.Size.Width > minX And pBoxImage.Size.Height > minY Then
                pBoxImage.Size = New Size(pBoxImage.Size.Width * 0.9, pBoxImage.Size.Height * 0.9)
            End If
        Else
            ' Expand
            If pBoxImage.Size.Width < maxX And pBoxImage.Size.Height < maxY Then
                pBoxImage.Size = New Size(pBoxImage.Size.Width * 1.1, pBoxImage.Size.Height * 1.1)
            End If
        End If
    End Sub
End Class