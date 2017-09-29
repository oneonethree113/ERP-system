Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxBitmap(GetType(TabControl))> _
Public Class BaseTabControl
    Inherits System.Windows.Forms.TabControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.DrawMode = TabDrawMode.OwnerDrawFixed
    End Sub

    'BaseTabControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer. 
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
    End Sub

#End Region

#Region "--- Disabled Pages Functionality ---"

    Private Const WM_LBUTTONDOWN As Integer = &H201

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_LBUTTONDOWN Then
            Dim pt As New Point(m.LParam.ToInt32)

            For i As Integer = 0 To Me.TabPages.Count - 1
                If Me.GetTabRect(i).Contains(pt) Then
                    If Me.TabPages(i).Enabled Then
                        MyBase.WndProc(m)
                    End If
                    Exit For
                End If
            Next
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal ke As System.Windows.Forms.KeyEventArgs)
        If Me.Focused Then
            Dim selIndex As Integer = Me.SelectedIndex

            If ke.KeyCode = Keys.Left AndAlso Not ke.Control AndAlso Not ke.Alt Then
                For i As Integer = selIndex - 1 To 0 Step -1
                    If Me.TabPages(i).Enabled Then
                        Me.SelectedIndex = i
                        Exit For
                    End If
                Next
                ke.Handled = True
            ElseIf ke.KeyCode = Keys.Right AndAlso Not ke.Control AndAlso Not ke.Alt Then
                For i As Integer = selIndex + 1 To TabPages.Count - 1
                    If Me.TabPages(i).Enabled Then
                        Me.SelectedIndex = i
                        Exit For
                    End If
                Next
                ke.Handled = True
            End If
        End If
        MyBase.OnKeyDown(ke)
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim leftImgOffset, topImgOffset As Integer
        Dim rBack As Rectangle
        Dim rText As RectangleF
        Dim img As Bitmap
        Dim format As New StringFormat
        Dim foreBrush As Brush
        Dim backBrush As New SolidBrush(Me.TabPages(e.Index).BackColor)

        If Me.TabPages(e.Index).Enabled Then
            foreBrush = New SolidBrush(Me.TabPages(e.Index).ForeColor)
        Else
            foreBrush = New SolidBrush(SystemColors.ControlDark)
        End If

        If Me.TabPages(e.Index).ImageIndex <> -1 Then
            img = CType(Me.ImageList.Images(Me.TabPages(e.Index).ImageIndex), Bitmap)
            rText = New RectangleF(e.Bounds.X + (img.Width \ 2), e.Bounds.Y, _
                                   e.Bounds.Width, e.Bounds.Height)
        Else
            rText = New RectangleF(e.Bounds.X, e.Bounds.Y, _
                                   e.Bounds.Width, e.Bounds.Height)
        End If

        If e.State = DrawItemState.Selected Then
            If e.Index = 0 Then
                rBack = New Rectangle(e.Bounds.X + 4, e.Bounds.Y, _
                                      e.Bounds.Width - 4, e.Bounds.Height)
            Else
                rBack = e.Bounds
            End If

            e.Graphics.FillRectangle(backBrush, rBack)

            leftImgOffset = 6
            topImgOffset = 5
        Else
            leftImgOffset = 2
            topImgOffset = 2
        End If

        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(Me.TabPages(e.Index).Text, e.Font, foreBrush, rText, format)

        If Me.TabPages(e.Index).ImageIndex <> -1 Then
            Me.ImageList.Draw(e.Graphics, e.Bounds.X + leftImgOffset, _
                              e.Bounds.Top + topImgOffset, Me.TabPages(e.Index).ImageIndex)
        End If

        MyBase.OnDrawItem(e)
    End Sub

    Private Sub Tab_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is TabPage Then
            Me.Invalidate(Me.GetTabRect(DirectCast(sender, TabPage).TabIndex))
        End If
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            AddHandler e.Control.EnabledChanged, AddressOf Tab_EnabledChanged
        End If
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            RemoveHandler e.Control.EnabledChanged, AddressOf Tab_EnabledChanged
        End If
        MyBase.OnControlRemoved(e)
    End Sub

#End Region

End Class
