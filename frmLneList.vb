Public Class frmLneList
    Public ma As BSP00004

    Public txtBox As TextBox
    Private rs_From As DataSet
    'Dim bolFromHightLight As Boolean
    'Dim bolToHightLight As Boolean
    'Dim startindex, endindex, lastindex As Integer

    Private Sub FillInLstBox()
        Dim S As String
        Dim rs As DataSet
        S = "sp_list_SYLNEINF "

        Cursor = Cursors.WaitCursor
        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_From, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
        End If

        Call FillLstBox()
        Cursor = Cursors.Default
    End Sub

    Private Function FillLstBox()
        Cursor = Cursors.WaitCursor

        lstFrom.items.Clear()
        lstTo.items.Clear()
        'If (Not rs_From Is Null) And (rs_From.Tables("RESULT").Rows.Count > 0) Then
        If (rs_From.Tables("RESULT").Rows.Count > 0) Then

            With rs_From
                For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                    lstFrom.Items.Add(rs_From.Tables("RESULT").Rows(index)("yli_lnecde"))
                Next
            End With

        End If
        Cursor = Cursors.Default
    End Function

    Private Sub setTxtItems()
        '    Private Function setTxtItems()
        Dim i As Integer
        Me.txtResult.Text = ""
        For i = 0 To lstTo.Items.Count - 1
            Me.txtResult.Text = Me.txtResult.Text & "," & lstTo.Items(i)
        Next i
        If Me.txtResult.Text <> "" Then
            Me.txtResult.Text = Microsoft.VisualBasic.Right(Me.txtResult.Text, Len(Me.txtResult.Text) - 1)
        End If
    End Sub

    Private Sub cmdAdd_Click()
        Call addItemTO()
    End Sub
    Private Sub addItemTO()
        Dim i As Integer
        Dim strTemp As String

        If (lstFrom.SelectedItems.Count + lstTo.Items.Count) > 100 Then
            MsgBox("The Result List will be more than 100 Records" & vbLf & "It Is Not Allowed!", vbCritical + vbOKOnly + vbDefaultButton1)
            Exit Sub
        End If

        While lstFrom.SelectedItems.Count > 0
            strTemp = lstFrom.SelectedItems(0)
            lstTo.Items.Add(strTemp)
            lstFrom.Items.Remove(lstFrom.SelectedItems(0))
        End While
        'tempz


        'If lstFrom.SelectedItems.Count = 1 Then
        '    strTemp = lstFrom.Text

        '    lstFrom.SetSelected(lstFrom.SelectedIndices(0), False)

        '    'For ii As Integer = 0 To lstFrom.Items.Count - 1
        '    '    lstFrom.SetSelected(ii, False)
        '    'Next
        '    'lstFrom.Selected(lstFrom.ListIndex) = False
        '    'goto  listBox1.Items.Remove(listBox1.SelectedItems[0])

        '    lstTo.Items.Add(strTemp)
        '    lstFrom.Items.Remove(lstFrom.SelectedItems[0])

        'ElseIf lstFrom.SelCount > 1 Then


        '    'For i = lstFrom.Items.Count - 1 To 0 Step -1
        '    '    If lstFrom.Selected(i) Then
        '    '        strTemp = lstFrom.Items(i)
        '    '        lstFrom.Selected(i) = False
        '    '        lstTo.AddItem(strTemp)
        '    '        lstFrom.RemoveItem(i)
        '    '    End If
        '    'Next i
        'End If
        Call setTxtItems()
    End Sub

    Private Sub CmdDelete_Click()
        Call deleteITemFrom()
    End Sub
    Private Sub deleteITemFrom()
        Dim i As Integer
        Dim strTemp As String

        While lstTo.SelectedItems.Count > 0
            strTemp = lstTo.SelectedItems(0)
            lstFrom.Items.Add(strTemp)
            lstTo.Items.Remove(lstTo.SelectedItems(0))
        End While

        'If lstTo.SelCount = 1 Then
        '    lstFrom.AddItem(lstTo.Text)
        '    lstTo.RemoveItem(lstTo.ListIndex)
        'ElseIf lstTo.SelCount > 1 Then
        '    For i = lstTo.ListCount - 1 To 0 Step -1
        '        If lstTo.Selected(i) Then
        '            lstFrom.AddItem(lstTo.Items(i))
        '            lstTo.RemoveItem(i)
        '        End If
        '    Next i
        'End If
        Call setTxtItems()
    End Sub

    Private Sub Command1_Click()
        '        Me.txtBox.Text = Me.txtResult.Text
        ma.txtPLneList.Text = Me.txtResult.Text

        Me.Close()

    End Sub

    Private Sub Command2_Click()
        Call FillLstBox()
    End Sub

    Private Sub Command3_Click()
        Me.Close()

    End Sub

    Private Sub Form_Load()
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        If Me.txtBox.Text <> "" Then
            Me.txtResult.Text = Me.txtBox.Text
        End If
        Me.txtResult.Enabled = False
        Call FillInLstBox()
        If Me.txtBox.Text <> "" Then
            Call initLstTO()
        End If
    End Sub

    Private Function initLstTO()

        '#X   this is another approch
        '#X   the product line string in the previous
        '#X   form will be add to the list box
        '#X   but user should take care not to delete these records

        Dim strTemp As String
        Dim strInput As String
        Dim i, j As Integer
        Dim intCount As Integer
        strInput = Me.txtBox.Text
        intCount = UBound(Split(strInput, ","))
        If intCount = 0 And strInput <> "" Then
            strTemp = strInput

            For j = 0 To lstFrom.Items.Count - 1
                If (lstFrom.Items(j) = strTemp) Then
                    lstFrom.Items.Remove(j)
                    lstTo.Items.Add(strTemp)
                    Exit For
                End If
            Next j
        ElseIf (intCount > 0) Then
            For i = 0 To intCount
                strTemp = Split(strInput, ",")(i)
                For j = 0 To lstFrom.Items.Count - 1
                    If (lstFrom.Items(j) = strTemp) Then
                        lstFrom.Items.Remove(j)
                        lstTo.Items.Add(strTemp)
                        Exit For
                    End If
                Next j
            Next i
        End If
    End Function


    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Call cmdAdd_Click()

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Call CmdDelete_Click()

    End Sub

    Private Sub frmLneList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        Call Command1_Click()

    End Sub
End Class