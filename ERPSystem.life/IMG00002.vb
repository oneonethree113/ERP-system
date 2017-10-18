Imports System.IO

Public Class IMG00002
    Dim m_count As Integer

    Const strUcpno As String = "UCP No."
    Const strVenItm As String = "Vendor Item No."
    Const strInternal As String = "Internal"
    Const strExternal As String = "External"
    Const expItem As String = ""

    Dim serverName As String
    Dim appPath As String
    Dim defaultSource As String
    Dim defaultSourceUploaded As String
    Dim defaultSourceExp As String
    Dim defaultDest As String

    Dim h_gstrExtImgPath As String
    Dim h_gstrIntImgPath As String
    Dim l_gstrExtImgPath As String
    Dim l_gstrIntImgPath As String
    Dim h_gstrExtImgdbPath As String
    Dim l_gstrExtImgdbPath As String
    Dim gstrExtColPath As String
    Dim gstrIntColPath As String

    Dim curVenitm As String
    Dim curUcpno As String
    Dim prodType As String
    Dim h_subDirOdm As String
    Dim expErrMsg As String

    Dim validPath As Boolean
    Dim goBack As Boolean
    Dim filSourcePath As String
    Dim FilePattern As String = "*.jpg"

    Private Sub IMG00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()
        drvSource.Items.Clear()
        Dim sDrive As String
        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        If getPath() = False Then
            cmdDefSource.Enabled = False
            cmdRefresh.Enabled = False
            cmdCopyMove.Enabled = False
            chkView.Enabled = False
            chkViewCont.Enabled = False
            dirSource.Enabled = False
            drvSource.Enabled = False
            filSource.Enabled = False
            txtLog.Enabled = False
        End If

        goBack = True
        lblServerName.Text = "Default Server : " & serverName
        lblFilname.Text = ""

        lblNumFilSource.Text = filSource.Items.Count
        cboImgNamFormat.Items.Add(strVenItm)
        cboImgNamFormat.Items.Add(strUcpno)

        setDefault()

        txtLog.ReadOnly = True
        grpFolders.Enabled = False
        dirDest.Enabled = False
        filDest.Enabled = False

        If validPath = False Then
            drvSource.Enabled = False
            dirSource.Enabled = False
            filSource.Enabled = False
            drvDest.Enabled = False
            dirDest.Enabled = False
            filDest.Enabled = False
            cmdDefSource.Enabled = False
            cmdRefresh.Enabled = False
            chkOverwrite.Enabled = False
            cmdCopyMove.Enabled = False
            chkView.Enabled = False
            chkViewCont.Enabled = False
            cmdRefreshLst.Enabled = False
            cmdSelectAll.Enabled = False
            cboImgNamFormat.Enabled = False
            grpPreview.Enabled = False
        End If

        cmdCopyMove.Select()
    End Sub

    Private Sub cmdCopyMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyMove.Click

        ' MsgBox("Is this Folder correct?" & dirSource.SelectedNode.FullPath)


        If validPath = False Then
            MsgBox("Source Directory - " & defaultSource & " or destination directory - " & defaultDest & " not found, no upload will be processed, please consult system administrator.")
            Exit Sub
        End If

        If dirSource.SelectedNode Is Nothing Then
            Exit Sub
        End If
        If dirSource.SelectedNode.FullPath Is Nothing Then
            Exit Sub
        End If

         If MsgBox("Upload images under the selected folder " & dirSource.SelectedNode.FullPath & "?", MsgBoxStyle.YesNo, "Image Upload Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If

        If filSource.Items.Count = 0 Then
            MsgBox("The source directory contains no image", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        ElseIf filSource.SelectedItems.Count = 0 Then
            MsgBox("No file has been selected for upload", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        End If

        cmdCopyMove.Enabled = False

        Static start_time As Date
        Dim stop_time As Date
        Dim strRmk As String

        Dim FilCount As Integer   '*** Number of file copied or moved
        Dim ExpCount As Integer   '*** Number of exceptions
        Dim numOfPrompt As Integer
        Dim errOccur As Integer    '*** At least 1 error has occur during the iterations
        Dim numOfExistFile As Integer
        Dim strLocSrcFolder As String '*** Variable for source folder
        Dim strLocDesFolder As String
        Dim found As Boolean      '*** Found or not?
        Dim bolFileExist As Boolean
        Dim message As String
        Dim TmpItmNo As String

        Dim h_tmp As String
        Dim h_subDir As String      '*** Current sub-directory
        Dim h_revFilName As String  '*** Filename revised
        Dim h_confirm As Integer
        Dim h_destpth As String     '*** high res. image Destination path
        Dim h_copyStatus As Integer

        Dim l_tmp As String
        Dim l_subDir As String      '*** Low res. sub-directory
        Dim l_revFilName As String  '*** Low res. Filename revised
        Dim l_confirm As Integer
        Dim l_destpth As String     '*** Low res. image Destination path
        Dim l_destdbpth As String     '*** Low res. image Destination path
        Dim l_copyStatus As Integer

        FilCount = 0
        numOfPrompt = 0
        errOccur = 0
        numOfExistFile = 0
        ExpCount = 0
        lblOther.Text = "0"
        lblDup.Text = "0"
        lblNumFil.Text = "0"
        lblExcept.Text = "0"

        setSubDir()

        txtLog.Text = "Copying Files from " & dirSource.SelectedNode.FullPath & " to " & drvDest.Text & Environment.NewLine & _
                        "=================================================================================================" & Environment.NewLine
        start_time = DateTime.Now

        strLocSrcFolder = BaseName(dirSource.SelectedNode.FullPath, "\")
        Dim tmpMth As String = "0" & Date.Now.Month.ToString
        Dim tmpDay As String = "0" & Date.Now.Day.ToString
        strLocDesFolder = "_(" & Date.Now.Year.ToString & tmpMth.Substring(tmpMth.Length - 2, 2) & tmpDay.Substring(tmpDay.Length - 2, 2) & ")"

        Dim rs_insert As New DataSet
        Dim rs_update As New DataSet

        For i As Integer = 0 To filSource.Items.Count - 1
            If filSource.SelectedIndices.Contains(i) Then
                tmpCount.Text = CStr(i + 1)

                '*** Revised the High Res. image file name
                h_revFilName = filSource.Items(i).ToString
                h_revFilName = Replace(h_revFilName, " ", "")

                '*** Revised the Low Res. image file name
                l_revFilName = filSource.Items(i).ToString
                l_revFilName = Replace(l_revFilName, "-", "_")
                l_revFilName = Replace(l_revFilName, " ", "")

                '*** Determine the image sub-folder name
                h_tmp = h_revFilName
                l_tmp = l_revFilName

                h_subDir = ""
                l_subDir = ""
                h_confirm = MsgBoxResult.Yes
                l_confirm = MsgBoxResult.Yes
                found = True
                curUcpno = ""
                h_subDirOdm = ""
                h_subDir = h_itmExist(h_tmp) '*** Decide the sub-folder name
                l_subDir = l_itmExist(l_tmp) '*** Decide the sub-folder name

                '*** Either operating on an item image folder or an item exception list
                If h_subDir <> expItem Then
                    '*** Define a regular path for the destination
                    h_revFilName = curUcpno + ".JPG"
                    h_destpth = dirDest.SelectedNode.FullPath & IIf(dirDest.SelectedNode.FullPath.Substring(dirDest.SelectedNode.FullPath.Length - 1, 1) = "\", "", "\") & h_subDir

                    If h_subDirOdm <> "" Then
                        h_subDirOdm = dirDest.SelectedNode.FullPath & IIf(dirDest.SelectedNode.FullPath.Substring(dirDest.SelectedNode.FullPath.Length - 1, 1) = "\", "", "\") & h_subDirOdm
                    End If
                Else
                    '*** The operation is not working on the exception item list
                    'lblStatus.Text = "Item (" & tmp & ") not exist in Item Master!"

                    If cboImgNamFormat.Text = strVenItm Then
                        lblStatus.Text = "Vendor Item (" & h_tmp & ") " & expErrMsg

                    ElseIf cboImgNamFormat.Text = strUcpno Then
                        lblStatus.Text = "UCP Item (" & h_tmp & ") " & expErrMsg
                    End If

                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                    errOccur = 1

                    If UCase((dirSource.SelectedNode.FullPath + "\expItem").Substring(0, defaultSourceExp.Length)) <> UCase(defaultSourceExp) Then
                        '*** A path for the exception items
                        h_destpth = defaultSourceExp
                        found = False
                    Else
                        h_confirm = MsgBoxResult.No
                    End If
                End If

                If l_subDir <> expItem Then
                    '*** Define a regular path for the destination
                    l_revFilName = curVenitm + ".JPG"

                    l_revFilName = Replace(l_revFilName, "-", "_")
                    l_revFilName = Replace(l_revFilName, " ", "")
                    'l_revFilName = Replace(l_revFilName, "/", "")

                    l_destpth = l_gstrExtImgPath & IIf(l_gstrExtImgPath.Substring(l_gstrExtImgPath.Length - 1, 1) = "\", "", "\") & l_subDir
                    l_destdbpth = l_gstrExtImgdbPath & IIf(l_gstrExtImgPath.Substring(l_gstrExtImgPath.Length - 1, 1) = "\", "", "\") & l_subDir
                Else
                    '*** The operation is not working on the exception item list
                    lblStatus.Text = "Item (" & l_tmp & ") not exist in Item Master!"
                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                    l_confirm = MsgBoxResult.No
                End If

                If dirSource.SelectedNode.FullPath = h_destpth Then
                    lblStatus.Text = "Failed to upload high res. image " & defaultSource & "\" & filSource.Items(i)
                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine & _
                                  "(Source and Hign Res. Destination Folders are the same)" & Environment.NewLine
                    h_confirm = MsgBoxResult.No
                End If

                If dirSource.SelectedNode.FullPath = l_destpth Then
                    lblStatus.Text = "Failed to upload high res. image " & defaultSource & "\" & filSource.Items(i)
                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine & _
                                  "(Source and Low Res. Destination Folders are the same)" & Environment.NewLine
                    l_confirm = MsgBoxResult.No
                End If

                '***************************************************************************
                '*** Start to copy or move the Low Res. image file to the destination folder
                '***************************************************************************
                bolFileExist = False
                If l_confirm = MsgBoxResult.Yes Then
                    If Dir(l_destpth + "\" + l_revFilName) <> "" Then
                        If chkOverwrite.Checked = False Then
                            bolFileExist = True
                            message = "Are you sure to replace low res. image " & Environment.NewLine & _
                                      "'" & l_destpth & "\" & l_revFilName & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(l_destpth & "\" & l_revFilName), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(l_destpth & "\" & l_revFilName), "MM/dd/yyyy HH:mm:ss") & "with" & Environment.NewLine & _
                                      "'" & dirSource.SelectedNode.FullPath & "\" & filSource.Items(i) & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(dirSource.SelectedNode.FullPath + "\" + filSource.Items(i)), "MM/dd/yyyy HH:mm:ss") & "?"
                            l_confirm = MsgBox(message, MsgBoxStyle.YesNoCancel, "Overwrite Prompt")

                        Else
                            l_confirm = MsgBoxResult.Yes
                        End If

                        If l_confirm = MsgBoxResult.Yes Then
                            numOfExistFile = numOfExistFile + 1
                            lblDup.Text = CStr(numOfExistFile)
                        End If
                    End If
                End If

                If l_confirm = MsgBoxResult.Cancel Then
                    strRmk = "Cancel By User"
                    GoTo jump
                End If

                If l_confirm = MsgBoxResult.Yes Then
                    lblStatus.Text = "Copying file " & Trim(Str(i + 1)) & ": " & l_destpth & "\" & l_revFilName

                    defaultSourceUploaded = filSourcePath + "\UPLOADED"

                    If found = True Then
                        l_copyStatus = L_FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), l_destpth, l_revFilName, True, defaultSourceUploaded)
                    Else
                        l_copyStatus = L_FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), l_destpth, l_revFilName, True, "")
                    End If

                    If l_copyStatus = 0 Or l_copyStatus = 3 Then
                        If found = True Then
                            lblStatus.Text = "Success to upload low res. image " & defaultSource & "\" & filSource.Items(i)
                            txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        End If

                        If l_copyStatus = 3 Then
                            lblStatus.Text = "Failed to copy low res. image " & defaultSource & "\" & filSource.Items(i)
                            txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                            errOccur = 1
                        End If

                        If found = True Then
                            FilCount = FilCount + 1 '*** Number of files accepted

                            TmpItmNo = Replace(filSource.Items(i), " ", "")
                            TmpItmNo = Replace(TmpItmNo, "-", "_")
                            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
                            TmpItmNo = Replace(TmpItmNo, ".jpg", "")
                            TmpItmNo = Replace(TmpItmNo, "/", "_")
                            TmpItmNo = Replace(TmpItmNo, "\", "")

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor

                            gspStr = "sp_insert_IMAGE_UPLOAD '','" & l_revFilName & "','" & l_destdbpth & "\" & l_revFilName & "','" & _
                                     IIf(bolFileExist = True, "Y", "N") & "','" & gsUsrID & "','E'"
                            rtnLong = execute_SQLStatement(gspStr, rs_insert, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Windows.Forms.Cursors.Default
                                lblStatus.Text = "Failed to update low res. image info (" & l_revFilName & ") to IM"
                                txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                                errOccur = 1
                                Me.cmdCopyMove.Enabled = True
                                MsgBox("Error on inserting IMG00002 #005 sp_insert_IMAGE_UPLOAD : " & rtnStr)
                                strRmk = "Cannot Update Low Res. Image Path/Save Upload Record, Exist"
                                GoTo jump
                                Exit Sub
                            End If

                            gspStr = "sp_update_IMAGE_UPLOAD_IMG00002 '','" & curUcpno & "','" & l_destdbpth & "\" & l_revFilName & _
                                     "','" & gsUsrID & "','E'"
                            rtnLong = execute_SQLStatement(gspStr, rs_update, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Windows.Forms.Cursors.Default
                                lblStatus.Text = "Failed to update low res. image info (" & l_revFilName & ") to IM"
                                txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                                errOccur = 1
                                Me.cmdCopyMove.Enabled = True
                                MsgBox("Error on inserting IMG00002 #006 sp_update_IMAGE_UPLOAD_IMG00002 : " & rtnStr)
                                strRmk = "Cannot Update Low Res. Image Path/Save Upload Record, Exist"
                                GoTo jump
                                Exit Sub
                            End If

                            Me.Cursor = Windows.Forms.Cursors.Default

                            lblStatus.Text = "Success to update low res. image info (" & l_revFilName & ") to IM"
                            txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                        Else
                            ExpCount = ExpCount + 1 '*** Number of files excepted
                        End If

                    ElseIf l_copyStatus = 1 Then
                        lblStatus.Text = "Failed to copy low res. image to " + l_destpth + "\" + l_revFilName
                        txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        errOccur = 1
                    Else
                        lblStatus.Text = "Failed to delete low res. image " & dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)
                        txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        errOccur = 1
                    End If

                    rs_insert = Nothing
                    rs_update = Nothing
                End If

                '*****************************************************************************
                '*** Start to copy or move the high res. image file to the destination folder
                '*****************************************************************************

                bolFileExist = False

                If h_confirm = MsgBoxResult.Yes Then
                    If Dir(h_destpth + "\" + h_revFilName) <> "" Then
                        If chkOverwrite.Checked = False Then
                            bolFileExist = True
                            message = "Are you sure to replace high res. image " & Environment.NewLine & _
                                      "'" & h_destpth & h_revFilName & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(h_destpth & "\" & h_revFilName), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(h_destpth & "\" & h_revFilName), "MM/dd/yyyy HH:mm:ss") & Environment.NewLine & _
                                      "with" & Environment.NewLine & _
                                      "'" & dirSource.SelectedNode.FullPath & "\" & filSource.Items(i) & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)), "MM/dd/yyyy HH:mm:ss") & "?"
                            h_confirm = MsgBox(message, MsgBoxStyle.YesNoCancel, "Prompt")
                        Else
                            h_confirm = MsgBoxResult.Yes
                        End If
                        If h_confirm = MsgBoxResult.Yes Then
                            numOfExistFile = numOfExistFile + 1
                            lblDup.Text = CStr(numOfExistFile)
                        End If
                    End If
                End If

                If h_confirm = MsgBoxResult.Cancel Then
                    strRmk = "Cancel By User"
                    GoTo jump
                End If

                If h_confirm = MsgBoxResult.Yes Then
                    lblStatus.Text = "Copying file " & Trim(Str(i + 1)) + ": " & h_destpth & h_revFilName
                    '                    lblStatus.Text = "Copying file " & Trim(Str(i + 1)) + ": " & h_destpth & "\" & h_revFilName

                    If found = True Then
                        If h_subDirOdm <> "" Then
                            h_copyStatus = H_FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), h_subDirOdm, h_revFilName, True, defaultSourceUploaded)
                            h_subDirOdm = ""
                        End If
                        h_copyStatus = H_FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), h_destpth, h_revFilName, True, defaultSourceUploaded)
                    Else
                        h_copyStatus = H_FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), h_destpth, h_revFilName, True, "")
                    End If

                    If h_copyStatus = 0 Or h_copyStatus = 3 Then
                        If found = True Then
                            lblStatus.Text = "Success to upload high res. image " & defaultSource & "\" & filSource.Items(i)
                            txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        End If

                        If h_copyStatus = 3 Then
                            lblStatus.Text = "Failed to copy high res. image " & defaultSource & "\" & filSource.Items(i)


                            '                            lblStatus.Text = "Failed to copy high res. image " & dirSource & "\" & filSource.Items(i)
                            '                            lblStatus.Text = "Failed to copy high res. image " & defaultSource & "\" & filSource.Items(i)
                            txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                            errOccur = 1
                        End If

                        If found = True Then
                            FilCount = FilCount + 1 '*** Number of files accepted

                            If cboImgNamFormat.Text = strVenItm Then
                                TmpItmNo = Replace(filSource.Items(i), " ", "")
                                'TmpItmNo = Replace(TmpItmNo, "-", "_")
                                TmpItmNo = Replace(TmpItmNo, ".JPG", "")
                                TmpItmNo = Replace(TmpItmNo, ".jpg", "")
                                TmpItmNo = Replace(TmpItmNo, "/", "_")
                                TmpItmNo = Replace(TmpItmNo, "\", "")
                            ElseIf cboImgNamFormat.Text = strUcpno Then
                                TmpItmNo = Replace(filSource.Items(i), " ", "")
                                TmpItmNo = Replace(TmpItmNo, ".JPG", "")
                                TmpItmNo = Replace(TmpItmNo, ".jpg", "")
                            End If

                            gspStr = "sp_update_IMBASINF_IMG00002 '','" & curUcpno & "','" & _
                                     Replace(h_destpth & IIf(h_destpth.Substring(h_destpth.Length - 1, 1) = "\", "", "\"), "'", "''") & h_revFilName & _
                                     "','" & gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor

                            rtnLong = execute_SQLStatement(gspStr, rs_update, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Windows.Forms.Cursors.Default
                                lblStatus.Text = "Failed to update high resolution image path (" & filSource.Items(i) & ") to IM"
                                txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                                errOccur = 1
                                cmdCopyMove.Enabled = True
                                MsgBox("Error on updating IMG00002 #006 sp_update_IMAGE_UPLOAD_IMG00002 : " & rtnStr)
                                strRmk = "Cannot Update High Resolution Image Path/Save Upload Record, Exist"
                                GoTo jump
                            End If

                            gspStr = "sp_insert_IMAGE_UPLOAD '','" & h_revFilName & "','" & _
                                    Replace(h_destpth, "'", "''") & IIf(h_destpth.Substring(h_destpth.Length - 1, 1) = "\", "", "\") & h_revFilName & _
                                     "','" & IIf(bolFileExist = True, "Y", "N") & "','" & gsUsrID & "','E'"
                            rtnLong = execute_SQLStatement(gspStr, rs_insert, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                Me.Cursor = Windows.Forms.Cursors.Default
                                lblStatus.Text = "Failed to update high res. image info (" & filSource.Items(i) & ") to IM"
                                txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                                errOccur = 1
                                cmdCopyMove.Enabled = True
                                MsgBox("Error on inserting IMG00002 #007 sp_insert_IMAGE_UPLOAD : " & rtnStr)
                                strRmk = "Cannot Update high res. Image Path/Save Upload Record, Exist"
                                GoTo jump
                            End If

                            Me.Cursor = Windows.Forms.Cursors.Default

                            If prodType = "ODM" Then
                                prodType = "OEM+S.R."
                            End If
                            lblStatus.Text = "Success to update high res. image info (" & h_revFilName & ")[" & prodType & "] to IM"
                            txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                        Else
                            ExpCount = ExpCount + 1 '*** Number of files excepted
                        End If
                    ElseIf h_copyStatus = 1 Then
                        lblStatus.Text = "Failed to copy high res. image to " & h_destpth & "\" & h_revFilName
                        txtLog.Text = txtLog.Text + Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        errOccur = 1
                    Else
                        lblStatus.Text = "Failed to delete high res. image " & dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)
                        txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        errOccur = 1
                    End If
                End If
            End If
        Next
        filSource.Refresh()
        strRmk = "Upload Success"

jump:
        '*** Refresh the source and destination

        cmdRefresh.PerformClick()
        lblNumFil.Text = CStr(FilCount)
        lblExcept.Text = CStr(ExpCount)
        lblOther.Text = CInt(Trim(lblNumFilSource.Text)) - CInt(lblNumFil.Text) - CInt(lblExcept.Text) - CInt(lblDup.Text)

        stop_time = DateTime.Now

        If (stop_time - start_time).TotalSeconds >= 1 Then
            Call Image_upload_audit(strRmk, (stop_time - start_time).TotalSeconds)
        Else
            Call Image_upload_audit(strRmk, 0)
        End If

        cmdCopyMove.Enabled = True
        lblStatus.Text = "File Copied"

    End Sub

    Private Sub setSubDir()
        Dim Myarray() As String
        Dim MyNewPath As String
        Dim i As Integer

        On Error GoTo errHandle
        defaultSourceUploaded = filSourcePath + "\uploaded"
        If Dir(defaultSourceUploaded, vbDirectory) = "" Then
            Myarray = Split(defaultSourceUploaded, "\")
            MyNewPath = Myarray(0)
            For i = 1 To UBound(Myarray)
                If Dir(MyNewPath & "\" & Myarray(i), vbDirectory) = "" Then
                    MkDir(MyNewPath & "\" & Myarray(i))
                End If
                MyNewPath = MyNewPath & "\" & Myarray(i)
            Next i
        End If

        defaultSourceExp = filSourcePath + "\ExpItem"
        If Dir(defaultSourceExp, vbDirectory) = "" Then
            Myarray = Split(defaultSourceExp, "\")
            MyNewPath = Myarray(0)
            'MyNewPath = filSourcePath '1
            For i = 1 To UBound(Myarray)
                If Dir(MyNewPath & "\" & Myarray(i), vbDirectory) = "" Then
                    MkDir(MyNewPath & "\" & Myarray(i))
                End If
                MyNewPath = MyNewPath & "\" & Myarray(i)
            Next i
        End If
        Exit Sub

errHandle:
        MsgBox("Error : " & Err.Description, MsgBoxStyle.Critical)
    End Sub

    Private Function BaseName(ByVal str As String, ByVal strDelimiter As String) As String
        On Error GoTo Err_No_Deliminator
        If str.Substring(str.Length - 1, 1) = "\" Then
            str = str.Substring(0, str.Length - 1)
        End If
        BaseName = Trim(Split(str, strDelimiter)(UBound(Split(str, strDelimiter))))
        Exit Function
Err_No_Deliminator:
        BaseName = ""
        Err.Clear()
    End Function

    Private Function h_itmExist(ByVal TmpItmNo As String) As String
        '*** Distribute the item images to appropriate folders
        '*** Return the sub-folder name if exist; else return the subfolder for exception
        Dim rs As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If cboImgNamFormat.Text = strVenItm Then
            TmpItmNo = Replace(TmpItmNo, " ", "")
            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
            TmpItmNo = Replace(TmpItmNo, ".jpg", "")
            TmpItmNo = Replace(TmpItmNo, "/", "_")
            TmpItmNo = Replace(TmpItmNo, "\", "")

            If InStr(TmpItmNo, "_") > 0 Then
                If Not Len(Split(TmpItmNo, "_")(1)) = 4 Then
                    MsgBox("Image name must contains   valid  '_venno' ! ")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    h_itmExist = ""
                    Exit Function
                End If
                If Not IsNumeric(Split(TmpItmNo, "_")(1)) Then
                    MsgBox("Image name must contains   valid  '_venno' ! ")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    h_itmExist = ""
                    Exit Function
                End If
                'If Not CInt(Split(TmpItmNo, "_")(1)) < 2000 Then
                '    MsgBox("Image name must contains   valid  '_venno' ! ")
                '    Me.Cursor = Windows.Forms.Cursors.Default
                '    h_itmExist = ""
                '    Exit Function
                'End If

            Else
                MsgBox("Image name must contains   '_venno' ! ")
                Me.Cursor = Windows.Forms.Cursors.Default
                h_itmExist = ""
                Exit Function
            End If

            gspStr = "sp_list_IMVENINF_IMG00002 '','" & Split(TmpItmNo, "_")(0) & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMG00002 #001 sp_list_IMVENINF_IMG00002 : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                h_itmExist = ""
                Exit Function
            End If
        ElseIf cboImgNamFormat.Text = strUcpno Then
            TmpItmNo = Replace(TmpItmNo, " ", "")
            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
            TmpItmNo = Replace(TmpItmNo, ".jpg", "")

            gspStr = "sp_list_IMBASINF_IMG00002 '','" & TmpItmNo & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMG00002 #002 sp_list_IMBASINF_IMG00002 : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                h_itmExist = ""
                Exit Function
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

        If rs.Tables("RESULT").Rows.Count > 0 Then
            If Not rs.Tables("RESULT").Rows(0)("ibi_prdtyp") Is Nothing Then
                If rs.Tables("RESULT").Rows(0)("ibi_prdtyp") <> "" Then
                    If Trim(rs.Tables("RESULT").Rows(0)("ibi_prdtyp")) = "SHOWROOM" Then
                        h_itmExist = rs.Tables("RESULT").Rows(0)("ibi_prdtyp") & "\" & rs.Tables("RESULT").Rows(0)("YrSn") & "\" & rs.Tables("RESULT").Rows(0)("lnecde") & "\"
                    ElseIf Trim(rs.Tables("RESULT").Rows(0)("ibi_prdtyp")) = "OEM" Then
                        If Not rs.Tables("RESULT").Rows(0)("icn_cusno") Is Nothing Or Not rs.Tables("RESULT").Rows(0)("cbi_cussna") Is Nothing Then
                            If Trim(rs.Tables("RESULT").Rows(0)("icn_cusno")) <> "" Or Trim(rs.Tables("RESULT").Rows(0)("cbi_cussna")) <> "" Then
                                h_itmExist = rs.Tables("RESULT").Rows(0)("ibi_prdtyp") & "\" & rs.Tables("RESULT").Rows(0)("icn_cusno") & "_" & _
                                             rs.Tables("RESULT").Rows(0)("cbi_cussna") & "\" & rs.Tables("RESULT").Rows(0)("YrSn") & "\"
                            Else
                                expErrMsg = "is OEM without Customer number!"
                                h_itmExist = expItem
                            End If
                        Else
                            expErrMsg = "is OEM without Customer number!"
                            h_itmExist = expItem
                        End If
                    ElseIf Trim(rs.Tables("RESULT").Rows(0)("ibi_prdtyp")) = "ODM" Then
                        h_itmExist = "SHOWROOM" & "\" & rs.Tables("RESULT").Rows(0)("YrSn") & "\" & rs.Tables("RESULT").Rows(0)("lnecde") & "\"
                        If Not rs.Tables("RESULT").Rows(0)("icn_cusno") Is Nothing Or Not rs.Tables("RESULT").Rows(0)("cbi_cussna") Is Nothing Then
                            If Trim(rs.Tables("RESULT").Rows(0)("icn_cusno")) <> "" Or Trim(rs.Tables("RESULT").Rows(0)("cbi_cussna")) <> "" Then
                                h_subDirOdm = "OEM" & "\" & rs.Tables("RESULT").Rows(0)("icn_cusno") & "_" & rs.Tables("RESULT").Rows(0)("cbi_cussna") & "\" & rs.Tables("RESULT").Rows(0)("YrSn") & "\"
                            Else
                                expErrMsg = "is OEM+S.R. without Customer number!"
                                h_subDirOdm = ""
                            End If
                        Else
                            expErrMsg = "is OEM+S.R. without Customer number!"
                            h_subDirOdm = ""
                        End If
                    Else
                        expErrMsg = "with invalid product type - " & RTrim(LTrim(rs.Tables("RESULT").Rows(0)("ibi_prdtyp"))) & "!"
                        h_itmExist = expItem
                    End If
                Else
                    expErrMsg = expErrMsg = "without item product type!"
                    h_itmExist = expItem
                End If
            Else
                expErrMsg = expErrMsg = "without item product type!"
                h_itmExist = expItem
            End If
        Else
            expErrMsg = "IM not found!"
            h_itmExist = expItem  '*** Exception
        End If

        If h_itmExist = "" Then
            '*** The UCPP line code or the UCP vendor code has not been etnered yet
            h_itmExist = expItem  '*** Exception
        End If

        If h_itmExist <> expItem Then
            curUcpno = rs.Tables("RESULT").Rows(0)("ibi_itmno")
            prodType = RTrim(LTrim(rs.Tables("RESULT").Rows(0)("ibi_prdtyp")))
        End If
    End Function

    Private Function l_itmExist(ByVal TmpItmNo As String) As String
        '*** Distribute the item images to appropriate folders
        '*** Return the sub-folder name if exist; else return the subfolder for exception

        Dim rs As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If cboImgNamFormat.Text = strVenItm Then
            TmpItmNo = Replace(TmpItmNo, " ", "")
            TmpItmNo = Replace(TmpItmNo, "-", "_")
            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
            TmpItmNo = Replace(TmpItmNo, ".jpg", "")
            TmpItmNo = Replace(TmpItmNo, "/", "_")
            TmpItmNo = Replace(TmpItmNo, "\", "")

            gspStr = "sp_select_IMAGE_UPLOAD '','" & TmpItmNo & "','E'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMG00002 #003 sp_select_IMAGE_UPLOAD : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                l_itmExist = ""
                Exit Function
            End If
        ElseIf cboImgNamFormat.Text = strUcpno Then
            TmpItmNo = Replace(TmpItmNo, " ", "")
            TmpItmNo = Replace(TmpItmNo, ".JPG", "")
            TmpItmNo = Replace(TmpItmNo, ".jpg", "")
            TmpItmNo = Replace(TmpItmNo, "_", "-")

            gspStr = "sp_select_IMAGE_UPLOAD_UCPNO '','" & TmpItmNo & "','E'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMG00002 #004 sp_select_IMAGE_UPLOAD_UCPNO : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                l_itmExist = ""
                Exit Function
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default

        If rs.Tables("RESULT").Rows.Count > 0 Then
            l_itmExist = Replace(Replace(Replace(rs.Tables("RESULT").Rows(0)("ibi_venno"), " ", ""), "-", "_"), "/", "_")
        Else
            l_itmExist = expItem
        End If

        If l_itmExist = "" Then
            '*** The UCPP line code or the UCP vendor code has not been etnered yet
            l_itmExist = expItem  '*** Exception
        End If

        If l_itmExist <> expItem Then
            curVenitm = rs.Tables("RESULT").Rows(0)(0)
        End If

    End Function

    Private Function L_FileCopy_Move(ByVal sourcepth As String, ByVal sourcefil As String, ByVal destpth As String, ByVal destfil As String, _
                               ByVal Move As Boolean, ByVal uploadpath As String) As Integer
        'Dim strDate As String

        If Dir(destpth, vbDirectory) = "" Then
            MkDir(destpth)
        End If

        '*** Copy the file from source folder to destination folder
        On Error GoTo on_Error_Filecopy_Move1
        '****    Add for check file exist of not while copy file
        If Dir(destpth, vbDirectory) <> "" Then
            FileCopy(sourcepth + IIf(sourcepth.Substring(sourcepth.Length - 1, 1) = "\", "", "\") & sourcefil, destpth & IIf(destpth.Substring(destpth.Length - 1, 1) = "\", "", "\") & destfil)
            On Error GoTo 0
        End If

        If uploadpath <> "" Then
            On Error GoTo on_Error_Filecopy_Move3
            If Dir(uploadpath, vbDirectory) = "" Then
                MkDir(uploadpath)
            End If
            If Dir(uploadpath, vbDirectory) <> "" Then
                FileCopy(sourcepth + IIf(sourcepth.Substring(sourcepth.Length - 1, 1) = "\", "", "\") & sourcefil, uploadpath + IIf(uploadpath.Substring(uploadpath.Length - 1, 1) = "\", "", "\") + sourcefil)
                On Error GoTo 0
            End If
        End If

        Return 0

on_Error_Filecopy_Move1:
        Return 1
on_Error_Filecopy_Move2:
        Return 2
on_Error_Filecopy_Move3:
        Return 3
    End Function

    Private Function H_FileCopy_Move(ByVal sourcepth As String, ByVal sourcefil As String, ByVal destpth As String, ByVal destfil As String, _
                               ByVal Move As Boolean, ByVal uploadpath As String) As Integer
        Dim strDate As String
        Dim i As Integer
        Dim Myarray() As String
        Dim MyNewPath As String

        'If the destination path not completely exist, make it.
        On Error GoTo on_Error_Filecopy_Move4
        If Dir(destpth, vbDirectory) = "" Then
            If destpth.Substring(destpth.Length - 1, 1) = "\" Then
                destpth = destpth.Substring(0, destpth.Length - 1)
            End If
            Myarray = Split(destpth, "\")
            MyNewPath = Myarray(0)
            For i = 1 To UBound(Myarray)
                If (i > 3) Then
                    If Dir(MyNewPath & "\" & Myarray(i), vbDirectory) = "" Then
                        MkDir(MyNewPath & "\" & Myarray(i))
                    End If
                End If
                MyNewPath = MyNewPath & "\" & Myarray(i)
            Next i
        End If
        On Error GoTo 0

        '*** Copy the file from source folder to destination folder
        On Error GoTo on_Error_Filecopy_Move1
        '****    Add for check file exist of not while copy file by Lewis on 20 May 2003 ***********************
        If Dir(destpth, vbDirectory) <> "" Then
            FileCopy(sourcepth & IIf(sourcepth.Substring(sourcepth.Length - 1, 1) = "\", "", "\") & sourcefil, destpth & IIf(destpth.Substring(destpth.Length - 1, 1) = "\", "", "\") & destfil)
            On Error GoTo 0
        End If


        If uploadpath <> "" Then
            On Error GoTo on_Error_Filecopy_Move3
            If Dir(uploadpath, vbDirectory) = "" Then
                MkDir(uploadpath)
            End If
            If Dir(uploadpath, vbDirectory) <> "" Then
                FileCopy(sourcepth & IIf(sourcepth.Substring(sourcepth.Length - 1, 1) = "\", "", "\") & sourcefil, uploadpath & IIf(uploadpath.Substring(uploadpath.Length - 1, 1) = "\", "", "\") & sourcefil)
                On Error GoTo 0
            End If
        End If

        '*** If the move option is on, delete the file in the source

        If Move = True And dirSource.SelectedNode.FullPath <> uploadpath And h_subDirOdm = "" Then

            On Error GoTo on_Error_Filecopy_Move2
            Kill(dirSource.SelectedNode.FullPath + "\" + sourcefil)
            On Error GoTo 0
        End If
        H_FileCopy_Move = 0
        Exit Function

on_Error_Filecopy_Move1:
        Return 1
on_Error_Filecopy_Move2:
        Return 2
on_Error_Filecopy_Move3:
        Return 3
on_Error_Filecopy_Move4:
        MsgBox("Error : " & Err.Description, MsgBoxStyle.Critical)
        Exit Function

    End Function

    Private Sub Image_upload_audit(ByVal strRmk As String, ByVal elpTime As Double)
        Dim rs As DataSet
        Dim ttlimg As Integer
        Dim cpyimg As Integer
        Dim expimg As Integer
        Dim dupimg As Integer
        Dim otherimg As Integer
        Dim lastimg As Integer


        ttlimg = CInt(Trim(IIf(lblNumFilSource.Text = "", "0", lblNumFilSource.Text)))
        cpyimg = CInt(Trim(IIf(lblNumFil.Text = "", "0", lblNumFil.Text)))
        expimg = CInt(Trim(IIf(lblExcept.Text = "", "0", lblExcept.Text)))
        dupimg = CInt(Trim(IIf(lblDup.Text = "", "0", lblDup.Text)))
        otherimg = CInt(Trim(IIf(lblOther.Text = "", "0", lblOther.Text)))
        lastimg = CInt(Trim(IIf(tmpCount.Text = "", "0", tmpCount.Text)))

        gspStr = "sp_insert_Image_Upload_aud '','" & ttlimg & "','" & cpyimg & "','" & expimg & "','" & dupimg & "','" & _
                 otherimg & "','" & lastimg & "','" & elpTime & "','" & strRmk & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on inserting IMG00002 #008 sp_insert_Image_Upload_aud : " & rtnStr)
            Exit Sub
        End If

    End Sub

    Private Function getPath() As String

        Dim S As String
        appPath = ""

        Try
            Using sr As New StreamReader("path.ini")
                While sr.Peek <> -1
                    'S = sr.ReadToEnd().ToString
                    S = sr.ReadLine().ToString

                    If S.IndexOf(" = ") > 0 Then
                        Select Case S.Substring(0, S.IndexOf(" = ")).ToUpper
                            Case "EXT_IMG_HIRESOL_PATH"
                                h_gstrExtImgPath = Trim(Split(S, " = ")(1))
                            Case "INT_IMG_HIRESOL_PATH"
                                h_gstrIntImgPath = Trim(Split(S, " = ")(1))
                            Case "EXT_IMG_PATH"
                                l_gstrExtImgPath = Trim(Split(S, " = ")(1))
                            Case "INT_IMG_PATH"
                                l_gstrIntImgPath = Trim(Split(S, " = ")(1))
                            Case "EXT_IMG_DB_PATH"
                                l_gstrExtImgdbPath = Trim(Split(S, " = ")(1))
                            Case "UPLOADED_PATH"
                                appPath = Trim(Split(S, " = ")(1))
                        End Select
                    End If

                End While
            End Using
        Catch ex As Exception
            MsgBox("Unable to determine file path: path.ini")
            Return False
        End Try

        If h_gstrExtImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If h_gstrIntImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "INT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(h_gstrExtImgPath) Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(h_gstrIntImgPath) Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "INT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        Return True
    End Function

    Private Sub setDefault()
        If rs_SYUSRPRF.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_SYUSRPRF.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count - 1
            If rs_SYUSRPRF.Tables("RESULT").Rows(i)("yuc_flgdef") = "Y" Then
                'cboImgNamFormat.SelectedText = strVenItm
                cboImgNamFormat.SelectedIndex = cboImgNamFormat.Items.IndexOf(strVenItm)
                setCompany()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub setCompany()
        serverName = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.IndexOf("\") + 1)
        If appPath <> "" Then
            serverName = IIf(appPath.Substring(appPath.Length - 1, 1) = "\", appPath.Substring(0, appPath.Length - 1), appPath)
        End If

        defaultSource = "U:\"  'should be the seelcted folder

        defaultSourceUploaded = defaultSource + "Uploaded"
        defaultSourceExp = defaultSource + "expItem"
        defaultDest = IIf(h_gstrExtImgPath.Substring(h_gstrExtImgPath.Length - 1, 1) = "\", h_gstrExtImgPath.Substring(0, h_gstrExtImgPath.Length - 1), h_gstrExtImgPath)

        validPath = True

        If Not Directory.Exists(defaultSource) Then
            MsgBox("Source Directory - " & defaultSource & " does not exist, consult system administrator.")
            validPath = False
            Exit Sub
        End If

        If Not Directory.Exists(defaultDest) Then
            MsgBox("Default Destination Directory - " & defaultDest & " does not exist, consult system administrator.")
            validPath = False
            Exit Sub
        End If

        optUploadImgFolder.PerformClick()
    End Sub

    Private Sub optOper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUploadImgFolder.Click, optExceptImgFolder.Click
        Dim strSrcTgc As String

        If optUploadImgFolder.Checked = True Then
            If goBack = True Then
                strSrcTgc = "src"
                drvSource.SelectedIndex = drvSource.Items.IndexOf(defaultSource)
                dirSource.Nodes(0).Expand()
            End If
            strSrcTgc = "tgc"
            drvDest.Items.Add(defaultDest)
            drvDest.SelectedIndex = drvDest.Items.IndexOf(defaultDest)
        ElseIf optExceptImgFolder.Checked = True Then
            If goBack = True Then
                strSrcTgc = "src"
                drvSource.SelectedText = defaultSourceExp
            End If
            strSrcTgc = "tgc"
            drvDest.SelectedText = defaultDest
        End If

        'If optOper(0).Value Then
        '    If goBack > 0 Then
        '        strSrcTgc = "src"
        '        '            drvSource.Drive = defaultSourceUpload
        '        '            dirSource.path = defaultSourceUpload
        '        drvSource.Drive = defaultSource
        '        dirSource.path = defaultSource + "\"
        '    End If
        '    strSrcTgc = "tgc"
        '    drvDest.Drive = defaultDest
        '    dirDest.path = defaultDest

        'ElseIf optOper(1).Value Then
        '    If goBack > 0 Then
        '        strSrcTgc = "src"
        '        drvSource.Drive = defaultSourceExp
        '        dirSource.path = defaultSourceExp

        '    End If
        '    strSrcTgc = "tgc"
        '    drvDest.Drive = defaultDest
        '    dirDest.path = defaultDest
        'End If
        'Exit Sub
    End Sub

    Private Sub drvSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drvSource.SelectedIndexChanged
        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub drvSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.TextChanged

        'Cursor.Current = Cursors.WaitCursor
        'dirSource.Nodes.Clear()
        'dirSource.Nodes.Add(drvSource.Text)
        'AddDirectories(dirSource.Nodes(0))
        'Cursor.Current = Cursors.Default

        'Try
        '    dirSource.Nodes(0).Expand()
        '    filSourcePath = drvSource.Text
        '    dirSource.SelectedNode = dirSource.Nodes(0)
        'Catch ex As Exception
        '    Exit Sub
        'End Try
    End Sub

    Private Sub dirSource_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles dirSource.BeforeExpand

        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirSource.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirSource.EndUpdate()
        End If

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        On Error GoTo FILE_ACCESS_ERROR

        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        filSourcePath = Dir.FullName

        drvSource.Text = filSourcePath


        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        'filSource.Items.Clear()

        'For Each File In Files
        '    'Add the file name to the lstFiles listbox
        '    filSource.Items.Add(File.Name)
        'Next

        filSourcePath = Dir.FullName
        '   dirSource.SelectedNode.FullPath = Dir.FullName

        '        defaultSource = Dir.FullName
        '       defaultSourceUploaded = defaultSource + "Uploaded"
        '      defaultSourceExp = defaultSource + "expItem"
        '     defaultDest = IIf(h_gstrExtImgPath.Substring(h_gstrExtImgPath.Length - 1, 1) = "\", h_gstrExtImgPath.Substring(0, h_gstrExtImgPath.Length - 1), h_gstrExtImgPath)

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")


        'If e.Node.Nodes(0).Text = "*" Then
        '    ' Disable redraw.
        '    dirSource.BeginUpdate()

        '    e.Node.Nodes.Clear()
        '    AddDirectories(e.Node)

        '    ' Enable redraw.
        '    dirSource.EndUpdate()
        'End If

        'expandDir(True, e.Node)

        ' Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)
        '    filSourcePath = Dir.FullName

    End Sub

    Private Sub drvDest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvDest.TextChanged
        Cursor.Current = Cursors.WaitCursor
        dirDest.Nodes.Clear()
        dirDest.Nodes.Add(drvDest.Text)
        AddDirectories(dirDest.Nodes(0))
        Cursor.Current = Cursors.Default

        Try
            dirDest.Nodes(0).Expand()
            dirDest.SelectedNode = dirDest.Nodes(0)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dirDest_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles dirDest.BeforeExpand
        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirDest.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirDest.EndUpdate()
        End If

        expandDir(False, e.Node)
    End Sub

    Private Sub expandDir(ByVal src As Boolean, ByVal node As TreeNode)
        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New  _
            System.IO.DirectoryInfo(node.FullPath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.filSourcePath that match
        '    FilePattern.
        On Error GoTo FILE_ACCESS_ERROR
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)
        'filSourcePath = Dir.FullName

        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        If src = True Then
            filSource.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filSource.Items.Add(File.Name)
            Next

            filSourcePath = node.FullPath
            lblNumFilSource.Text = filSource.Items.Count
        Else
            filDest.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filDest.Items.Add(File.Name)
            Next
        End If

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub

    Private Sub AddDirectories(ByVal Node As TreeNode)
        Try
            'Construct a DirectoryInfo object of Node.FullPath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)

            'Construct a DirectoryInfo object array of all the folders inside Node.FullPath.

            Dim Folders As System.IO.DirectoryInfo

            'For Each Folders In Dir.GetDirectories
            '    ' Add node for the directory.
            '    Dim NewNode As New TreeNode(Folders.Name)
            '    Node.Nodes.Add(NewNode)
            '    NewNode.Nodes.Add("*")
            'Next

            Dim NewNode_old() As String
            Dim counter_i As Integer
            counter_i = 0
            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                ReDim Preserve NewNode_old(counter_i)
                NewNode_old(counter_i) = Folders.Name
                counter_i = counter_i + 1
            Next

            bubbleSort(NewNode_old, UBound(NewNode_old))

            For ii As Integer = 0 To UBound(NewNode_old)
                Dim NewNode As New TreeNode(NewNode_old(ii))
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next


        Catch
            'This error trap prevents a crash when attempting to access restricted folders.
        End Try
    End Sub
    'Private Sub AddDirectories(ByVal Node As TreeNode)
    '    Try
    '        'Construct a DirectoryInfo object of Node.filSourcePath
    '        Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)
    '        'Construct a DirectoryInfo object array of all the 
    '        '    folders inside Node.filSourcePath.

    '        Dim Folders As System.IO.DirectoryInfo

    '        For Each Folders In Dir.GetDirectories
    '            ' Add node for the directory.
    '            Dim NewNode As New TreeNode(Folders.Name)
    '            Node.Nodes.Add(NewNode)
    '            NewNode.Nodes.Add("*")
    '        Next
    '        'MsgBox(dirNode.filSourcePath)
    '    Catch
    '        'This error trap prevents a crash when attempting 
    '        '    to access restricted folders.
    '    End Try
    'End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        m_count = 0

        For i As Integer = 0 To filSource.Items.Count - 1
            filSource.SetSelected(i, True)
        Next
    End Sub

    Private Sub cmdRefreshLst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshLst.Click
        m_count = 0
        refreshFiles("source")
    End Sub

    Private Sub cmdDefSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefSource.Click
        txtLog.Text = ""
        chkView.Checked = False
        chkViewCont.Checked = False
        setDefault()
        optUploadImgFolder.Checked = True
        'Rest Source Directory View
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        dirSource.Nodes(0).Expand()
        dirSource.SelectedNode = dirSource.Nodes(0)

        'Reset Destination Directory View
        dirDest.Nodes.Clear()
        dirDest.Nodes.Add(drvDest.Text)
        AddDirectories(dirDest.Nodes(0))
        dirDest.Nodes(0).Expand()
        dirDest.SelectedNode = dirDest.Nodes(0)

        lblNumFil.Text = "0"
        lblExcept.Text = "0"
        lblOther.Text = CInt(Trim(lblNumFilSource.Text)) - CInt(lblNumFil.Text) - CInt(lblExcept.Text) - CInt(lblDup.Text)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        lblStatus.Text = "Refreshing"
        cmdRefresh.Enabled = False
        If dirSource.SelectedNode Is Nothing Then
            cmdRefresh.Enabled = True
            Exit Sub
        End If
        If dirSource.SelectedNode.FullPath Is Nothing Then
            cmdRefresh.Enabled = True
            Exit Sub
        End If

        Dim srcPath As String = dirSource.SelectedNode.FullPath & "\"
        Dim dstPath As String = dirDest.SelectedNode.FullPath & "\"

        'Refresh Source Directory
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        dirSource.Nodes(0).Expand()
        dirSource.SelectedNode = getNode(parsePath(srcPath, True), dirSource.Nodes, True)
        refreshFiles("source")

        'Refresh Destination Directory
        dirDest.Nodes.Clear()
        dirDest.Nodes.Add(drvDest.Text)
        AddDirectories(dirDest.Nodes(0))
        dirDest.Nodes(0).Expand()
        dirDest.SelectedNode = getNode(parsePath(dstPath, False), dirDest.Nodes, True)
        refreshFiles("destination")

        cmdRefresh.Enabled = True
        lblStatus.Text = ""
    End Sub

    Private Sub refreshFiles(ByVal location As String)
        If location = "source" Then
            If (dirSource.SelectedNode Is Nothing) Then
                MsgBox("Directory Not Selected")
                Exit Sub
            End If

            '*** Refresh the source
            filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")
        Else
            If (dirDest.SelectedNode Is Nothing) Then
                MsgBox("Directory Not Selected")
                Exit Sub
            End If

            '*** Refresh the source
            filSourcePath = dirDest.SelectedNode.FullPath
        End If

        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New  _
            System.IO.DirectoryInfo(filSourcePath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.filSourcePath that match
        '    FilePattern.
        Dim Files As System.IO.FileInfo() = _
                Dir.GetFiles(FilePattern)

        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        If location = "source" Then
            filSource.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filSource.Items.Add(File.Name)
            Next
            filSource.Refresh()
            lblNumFilSource.Text = filSource.Items.Count
        Else
            filDest.Items.Clear()
            For Each File In Files
                'Add the file name to the lstFiles listbox
                filDest.Items.Add(File.Name)
            Next
            filDest.Refresh()
        End If
    End Sub

    Private Function parsePath(ByVal path As String, ByVal src As Boolean) As ArrayList
        Dim nodeTree As New ArrayList
        If src = True Then
            nodeTree.Add(drvSource.Text)
            path = path.Substring(drvSource.Text.Length + 1, path.Length - drvSource.Text.Length - 1)
        Else
            'path = Replace(path, "\\", "")
            'nodeTree.Add("\\" & path.Substring(0, path.IndexOf("\")))
            nodeTree.Add(drvDest.Text)
            path = path.Substring(drvDest.Text.Length + 1, path.Length - drvDest.Text.Length - 1)
            'path = path.Substring(nodeTree.Item(nodeTree.Count - 1).length, path.Length - nodeTree.Item(nodeTree.Count - 1).length)
        End If
        Dim temp As String
        While (path.IndexOf("\") < path.Length And path.IndexOf("\") <> -1)
            temp = path.Substring(0, path.IndexOf("\"))
            nodeTree.Add(temp)
            path = path.Substring(temp.Length + 1, path.Length - temp.Length - 1)
        End While
        Return nodeTree
    End Function

    Private Function getNode(ByVal list As ArrayList, ByVal nodes As TreeNodeCollection, ByVal source As Boolean) As TreeNode
        For i As Integer = 0 To nodes.Count - 1
            If nodes(i).Text = list.Item(0) Then
                nodes(i).Expand()
                list.RemoveAt(0)
                getNode = nodes(i)
                If list.Count > 0 Then
                    getNode = getNode(list, nodes(i).Nodes, True)
                End If
                Return getNode
            End If
        Next
    End Function

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    Private Sub chkView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkView.CheckedChanged
        If chkView.Checked = True Then
            If Not filSource.SelectedItem Is Nothing Then
                displayImage(filSource.SelectedItem.ToString)
            End If
        Else
            displayImage(Nothing)
        End If
    End Sub

    Private Sub displayImage(ByVal image As String)
        If Not image Is Nothing Then
            pBxImage.Load(dirSource.SelectedNode.FullPath & "\" & image)
            pBxImage.SizeMode = PictureBoxSizeMode.Zoom
            lblFilname.Text = image
        Else
            pBxImage.Image = Nothing
            lblFilname.Text = ""
        End If
    End Sub

    Private Sub chkViewCont_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewCont.CheckedChanged
        If chkViewCont.Checked = True Then
            cmdCopyMove.Enabled = False
            dirDest.Enabled = True
            filDest.Enabled = True
        Else
            cmdCopyMove.Enabled = True

            'Reset Destination Directory View
            dirDest.Nodes.Clear()
            dirDest.Nodes.Add(drvDest.Text)
            AddDirectories(dirDest.Nodes(0))
            dirDest.Nodes(0).Expand()
            dirDest.SelectedNode = dirDest.Nodes(0)

            dirDest.Enabled = False
            filDest.Enabled = False
        End If
    End Sub

    Private Sub filSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles filSource.Click
        If m_count = 0 Then
            For i As Integer = 0 To filSource.Items.Count - 1
                filSource.SetSelected(i, True)
            Next
            m_count = m_count + 1
        End If

    End Sub

    Private Sub filSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filSource.SelectedIndexChanged
        If chkView.Checked = Enabled Then
            If Not filSource.SelectedItem Is Nothing Then
                displayImage(filSource.SelectedItem.ToString)
            End If
        End If
    End Sub

    Private Sub pBxImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pBxImage.DoubleClick
        If filSource.SelectedItem Is Nothing Then
            Exit Sub
        End If

        Try
            frmImage.pbImage.Load(dirSource.SelectedNode.FullPath & "\" & filSource.SelectedItem.ToString)
        Catch ex As Exception

        End Try

        frmImage.ShowDialog()
    End Sub

    Private Sub txtLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLog.TextChanged
        txtLog.ScrollToCaret()
    End Sub

    Private Sub dirSource_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles dirSource.AfterSelect

        If e.Node.Nodes.Count = 0 Then
            Exit Sub
        End If

        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirSource.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirSource.EndUpdate()
        End If

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        On Error GoTo FILE_ACCESS_ERROR

        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        filSourcePath = Dir.FullName

        drvSource.Text = filSourcePath


        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        filSourcePath = Dir.FullName
        '   dirSource.SelectedNode.FullPath = Dir.FullName

        '        defaultSource = Dir.FullName
        '       defaultSourceUploaded = defaultSource + "Uploaded"
        '      defaultSourceExp = defaultSource + "expItem"
        '     defaultDest = IIf(h_gstrExtImgPath.Substring(h_gstrExtImgPath.Length - 1, 1) = "\", h_gstrExtImgPath.Substring(0, h_gstrExtImgPath.Length - 1), h_gstrExtImgPath)

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")


        'If e.Node.Nodes(0).Text = "*" Then
        '    ' Disable redraw.
        '    dirSource.BeginUpdate()

        '    e.Node.Nodes.Clear()
        '    AddDirectories(e.Node)

        '    ' Enable redraw.
        '    dirSource.EndUpdate()
        'End If

        'expandDir(True, e.Node)

        ' Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)
        '    filSourcePath = Dir.FullName

    End Sub
    Sub bubbleSort(ByVal dataset() As String, ByVal n As Integer)
        n = n + 1
        Dim i, j As Integer

        For i = 0 To n Step 1

            For j = n - 1 To i + 1 Step -1

                If (dataset(j) < dataset(j - 1)) Then



                    Dim temp As String = dataset(j)

                    dataset(j) = dataset(j - 1)

                    dataset(j - 1) = temp



                End If



            Next

        Next

    End Sub
End Class