Public Class frmItemList

    Public formname As String
    Public myOwner As Form


    Dim selStart As Long
    Public strItem As String
    Public strSel As String

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strSel = strItem
        txtSelitm.Text = Replace(strItem, ",", Environment.NewLine)
        txtSelitm.SelectionStart = 0
        txtSelitm.SelectionLength = 0
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If MsgBox("Are you sure to clear the list?", MsgBoxStyle.YesNo, "Message") = MsgBoxResult.Yes Then
            txtSelitm.Text = ""
            txtSelitm.Focus()
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim tmp_str As String

        strSel = txtSelitm.Text
        strSel = Replace(strSel, " ", "")
        strSel = Replace(strSel, "'", "")
        strSel = Replace(strSel, "%", "")

        strSel = Replace(strSel, Environment.NewLine, ",")

        Do While InStr(strSel, ",,") > 0
            strSel = Replace(strSel, ",,", ",")
        Loop

        If Microsoft.VisualBasic.Left(strSel, 1) = "," Then
            strSel = Microsoft.VisualBasic.Right(strSel, Len(strSel) - 1)
        End If
        If Microsoft.VisualBasic.Right(strSel, 1) = "," Then
            strSel = Microsoft.VisualBasic.Left(strSel, Len(strSel) - 1)
        End If

        'BSP00005.txtItmList.Text = strSel
        'BSP00005.prevImg.Text = Replace(strSel, ",", Chr(13) + Chr(10))
        If formname = "IMM00004" Then
            Call IMM00004.settxtItemList(strSel)
        End If

        If formname = "IMR00021" Then

            Call IMR00021.settxtItemList(strSel)
        End If

        If formname = "IMR00022_1" Then

            Call IMR00022.settxtItemList(strSel)

            'tmp_str = IMR00022.txtCustAls.Text

            ''IMR00022.Hide()
            ''IMR00022.Show()

            'IMR00022.txtItemList.Text = strSel

            'IMR00022.txtCustAls.Text = tmp_str

            'IMR00022.Refresh()
        End If

        If formname = "IMR00022_2" Then


            Call IMR00022.settxtCustAls(strSel)

            'tmp_str = IMR00022.txtItemList.Text
            ''IMR00022.Hide()
            ''IMR00022.Show()

            'IMR00022.txtCustAls.Text = strSel

            'IMR00022.txtItemList.Text = tmp_str

            ''IMR00022.Refresh()
        End If

        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub


    Private Sub txtSelitm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSelitm.KeyPress
        Dim temp As String
        Dim line As Integer
        If Asc(e.KeyChar) = 27 Then
            cmdCancel.PerformClick()
        End If

        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then  'single quote and comma are blocked
            e.KeyChar = Chr(0)
        End If

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'The following keep check the length of item no on each line
        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 13 Then
            If Split(txtSelitm.Text, Environment.NewLine).Length > 0 Then
                line = txtSelitm.GetLineFromCharIndex(txtSelitm.SelectionStart()).ToString()
                temp = Split(txtSelitm.Text, Environment.NewLine)(line)

                If temp.Length >= 20 Then
                    e.KeyChar = Chr(0)
                End If
            Else
                If txtSelitm.Text.Length >= 20 Then
                    e.KeyChar = Chr(0)
                End If
            End If
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        Exit Sub
    End Sub
    Public Function getform(ByVal formnameA As String)
        formname = formnameA
    End Function
End Class