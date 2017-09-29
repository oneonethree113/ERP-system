Imports System.IO

Public Class IMG00001

    Const strInternal As String = "Internal and Joint Venture"
    Const strExternal As String = "External"
    Const expItem As String = ""

    Dim appPath As String
    Dim gstrExtImgPath As String
    Dim gstrIntImgPath As String
    Dim gstrExtColPath As String
    Dim gstrIntColPath As String

    Dim serverName As String
    Dim defaultSource As String
    Dim defaultSourceUpload As String
    Dim defaultSourceUploaded As String
    Dim defaultSourceExp As String
    Dim defaultDest As String

    Dim validPath As Boolean
    Dim goBack As Boolean
    Dim filSourcePath As String
    Dim FilePattern As String = "*.jpg"

    Private Sub IMG00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()
        drvSource.Items.Clear()
        Dim sDrive As String
        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        If getPath() = False Then
            validPath = False
            checkValidPath()
        End If

        goBack = True
        lblServerName.Text = "Default Server : " & serverName
        lblFilname.Text = ""

        lblNumFilSource.Text = filSource.Items.Count
        cboCoCde.Items.Add(strInternal)
        cboCoCde.Items.Add(strExternal)

        setDefault()

        txtLog.ReadOnly = True
        'grpFolders.Enabled = False
        dirDest.Enabled = False
        filDest.Enabled = False

        checkValidPath()

        cmdCopyMove.Select()
    End Sub

    Private Sub cmdCopyMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyMove.Click
        If validPath = False Then
            MsgBox("Source Directory - " & defaultSource & " or destination directory - " & defaultDest & " not found, no upload will be processed, please consult system administrator.")
            Exit Sub
        End If

        If MsgBox("Upload images under the selected folder?", MsgBoxStyle.YesNo, "Image Upload Confirmation") = MsgBoxResult.No Then
            Exit Sub
        End If

        If filSource.Items.Count = 0 Then
            MsgBox("The source directory contains no image", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        ElseIf filSource.SelectedItems.Count = 0 Then
            MsgBox("No file has been selected for upload", MsgBoxStyle.Information, "Upload Error")
            Exit Sub
        End If

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
        Dim tmp As String
        Dim subDir As String      '*** Current sub-directory
        Dim found As Boolean      '*** Found or not?
        Dim bolFileExist As Boolean
        Dim message As String
        Dim TmpItmNo As String

        Dim revFilName As String  '*** Filename revised
        Dim confirm As Integer
        Dim destpth As String     '*** high res. image Destination path
        Dim copyStatus As Integer

        FilCount = 0
        numOfPrompt = 0
        errOccur = 0
        numOfExistFile = 0
        ExpCount = 0
        lblOther.Text = "0"
        lblDup.Text = "0"
        lblNumFil.Text = "0"
        lblExcept.Text = "0"

        txtLog.Text = "Copying Files from " & dirSource.SelectedNode.FullPath & " to " & drvDest.Text & Environment.NewLine & _
                        "=================================================================================================" & Environment.NewLine
        start_time = DateTime.Now

        strLocSrcFolder = BaseName(dirSource.SelectedNode.FullPath, "\")
        Dim tmpMth As String = "0" & Date.Now.Month.ToString
        Dim tmpDay As String = "0" & Date.Now.Day.ToString
        strLocDesFolder = strLocSrcFolder & "_(" & Date.Now.Year.ToString & tmpMth.Substring(tmpMth.Length - 2, 2) & tmpDay.Substring(tmpDay.Length - 2, 2) & ")"

        Dim rs_insert As New DataSet

        For i As Integer = 0 To filSource.Items.Count - 1
            If filSource.SelectedIndices.Contains(i) Then
                tmpCount.Text = CStr(i + 1)

                '*** Revised the image file name
                revFilName = filSource.Items(i)
                revFilName = Replace(revFilName, "-", "_")
                revFilName = Replace(revFilName, " ", "")

                '*** Determine the image sub-folder name
                tmp = revFilName
                subDir = ""
                confirm = MsgBoxResult.Yes
                found = True
                subDir = itmExist(tmp) '*** Decide the sub-folder name

                If subDir <> expItem Then
                    destpth = dirDest.SelectedNode.FullPath & IIf(dirDest.SelectedNode.FullPath.Substring(dirDest.SelectedNode.FullPath.Length - 1, 1) = "\", "", "\") & subDir
                Else
                    lblStatus.Text = "Item (" & tmp & ") not exist in Item Master!"
                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                    errOccur = 1

                    If UCase(dirSource.SelectedNode.FullPath.Substring(0, defaultSourceExp.Length)) <> UCase(defaultSourceExp) Then
                        destpth = defaultSourceExp & IIf(defaultSourceExp.Substring(defaultSourceExp.Length - 1) = "\", "", "\") & strLocDesFolder
                        found = True
                    Else
                        confirm = MsgBoxResult.No
                    End If
                End If

                If dirSource.SelectedNode.FullPath = destpth Then
                    lblStatus.Text = "Failed to upload " & defaultSource & "\" & filSource.Items(i)
                    txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") + "  " & lblStatus.Text & Environment.NewLine & _
                                  "(Source and Destination Folders are the same)" & Environment.NewLine
                    confirm = MsgBoxResult.No
                End If

                '*** Start to copy or move the file to the destination folder
                'If confirm = vbYes And chkPrompt.Value = 1 Then
                bolFileExist = False
                If confirm = MsgBoxResult.Yes Then
                    If Dir(destpth + "\" + revFilName) <> "" Then '*** If file is existed
                        If chkOverwrite.Checked = False Then
                            bolFileExist = True
                            message = "Are you sure to replace low res. image " & Environment.NewLine & _
                                      "'" & destpth & "\" & revFilName & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(destpth & "\" & revFilName), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(destpth & "\" & revFilName), "MM/dd/yyyy HH:mm:ss") & "with" & Environment.NewLine & _
                                      "'" & dirSource.SelectedNode.FullPath & filSource.Items(i) & "'" & Environment.NewLine & _
                                      "File Size: " & Format(FileLen(dirSource.SelectedNode.FullPath & "\" & filSource.Items(i)), "##,###") & " KB " & Environment.NewLine & _
                                      "Last Modified On: " & Format(FileDateTime(dirSource.SelectedNode.FullPath + "\" + filSource.Items(i)), "MM/dd/yyyy HH:mm:ss") & "?"
                            confirm = MsgBox(message, MsgBoxStyle.YesNoCancel, "Overwrite Prompt")
                        Else
                            confirm = MsgBoxResult.Yes
                        End If

                        If confirm = MsgBoxResult.Yes Then
                            numOfExistFile = numOfExistFile + 1
                            lblDup.Text = CStr(numOfExistFile)
                        End If
                    End If
                End If

                If confirm = MsgBoxResult.Cancel Then
                    strRmk = "Cancel By User"
                    GoTo jump
                End If

                If confirm = MsgBoxResult.Yes Then
                    lblStatus.Text = "Copying file " & Trim(Str(i + 1)) & ": " & destpth & "\" & revFilName

                    If found = True Then
                        copyStatus = FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), destpth, revFilName, True, _
                            defaultSourceUploaded & IIf(defaultSourceUploaded.Substring(defaultSourceUploaded.Length - 1, 1) = "\", "", "\") & strLocDesFolder)
                    Else
                        copyStatus = FileCopy_Move(dirSource.SelectedNode.FullPath, filSource.Items(i), destpth, revFilName, True, "")
                    End If

                    If copyStatus = 0 Or copyStatus = 3 Then
                        If found = True Then
                            lblStatus.Text = "Success to upload " & defaultSource & "\" & filSource.Items(i)
                            txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        End If

                        If copyStatus = 3 Then
                            lblStatus.Text = "Failed to copy " & defaultSource & "\" & filSource.Items(i)
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

                            gspStr = "sp_insert_IMAGE_UPLOAD '','" & filSource.Items(i) & "','" & destpth & "\" & revFilName & _
                                     "','" & IIf(bolFileExist = True, "Y", "N") & "','" & gsUsrID & "','" & _
                                     IIf(cboCoCde.Text = strInternal, "I", "E") & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor

                            rtnLong = execute_SQLStatement(gspStr, rs_insert, rtnStr)

                            Me.Cursor = Windows.Forms.Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                lblStatus.Text = "Failed to update image info (" & filSource.Items(i) & ") to IM"
                                txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                                errOccur = 1
                                cmdCopyMove.Enabled = True
                                MsgBox("Error on inserting IMG00002 #002 sp_insert_IMAGE_UPLOAD : " & rtnStr)
                                strRmk = "Cannot Update Image Path/Save Upload Record, Exist"
                                GoTo jump
                            End If

                            lblStatus.Text = "Success to update image info (" & filSource.Items(i) & ") to IM"
                            txtLog.Text = txtLog.Text & "_________________" & "  " & lblStatus.Text & Environment.NewLine
                        Else
                            ExpCount = ExpCount + 1 '*** Number of files excepted
                        End If
                    ElseIf copyStatus = 1 Then
                        lblStatus.Text = "Failed to copy to " & destpth + "\" & revFilName
                        txtLog.Text = txtLog.Text & Format(Now, "MM/dd/yyyy HH:mm:ss") & "  " & lblStatus.Text & Environment.NewLine
                        errOccur = 1
                    Else
                        lblStatus.Text = "Failed to delete " & dirSource.SelectedNode.FullPath + "\" + filSource.Items(i)
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

    Private Function getPath() As String

        Dim S As String
        appPath = ""

        Try
            Using sr As New StreamReader("path.ini")
                While sr.Peek <> -1
                    'S = sr.ReadToEnd().ToString
                    S = sr.ReadLine().ToString

                    If S.IndexOf(" = ") > 0 Then
                        If gsCompanyGroup = "MSG" Then
                            Select Case S.Substring(0, S.IndexOf(" = ")).ToUpper
                                Case "MS_EXT_IMG_PATH"
                                    gstrExtImgPath = Trim(Split(S, " = ")(1))
                                Case "MS_INT_IMG_PATH"
                                    gstrIntImgPath = Trim(Split(S, " = ")(1))
                                Case "UPLOADED_PATH"
                                    appPath = Trim(Split(S, " = ")(1))
                            End Select
                        Else
                            Select Case UCase(Split(S, " = ")(0))
                                Case "EXT_IMG_PATH"
                                    gstrExtImgPath = Trim(Split(S, " = ")(1))
                                Case "INT_IMG_PATH"
                                    gstrIntImgPath = Trim(Split(S, " = ")(1))
                                Case "UPLOADED_PATH"
                                    appPath = Trim(Split(S, " = ")(1))
                            End Select
                        End If
                    End If

                End While
            End Using
        Catch ex As Exception
            MsgBox("Unable to determine file path: path.ini")
            Return False
        End Try

        If gstrExtImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If gstrIntImgPath = "" Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "INT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(gstrExtImgPath) Then
            MsgBox(IIf(gsCompanyGroup = "MSG", "MS_", "") & "EXT_IMG_HIRESOL_PATH value invalid!")
            Return False
        End If

        If Not Directory.Exists(gstrIntImgPath) Then
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
                If rs_SYUSRPRF.Tables("RESULT").Rows(i)("yuc_cocde") = "UCP" Then
                    cboCoCde.Text = strExternal
                Else
                    cboCoCde.Text = strInternal
                End If
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

        If cboCoCde.Text = strInternal Then
            defaultSource = serverName & "\Image_Upload\Internal_and_Joint_Venture"
            defaultSourceUpload = defaultSource & "\Upload"
            defaultSourceUploaded = defaultSource & "\Uploaded"
            defaultSourceExp = defaultSource & "\ExpItem"
            defaultDest = gstrIntImgPath
        ElseIf cboCoCde.Text = strExternal Then
            defaultSource = serverName & "\Image_Upload\External"
            defaultSourceUpload = defaultSource & "\Upload"
            defaultSourceUploaded = defaultSource & "\Uploaded"
            defaultSourceExp = defaultSource & "\ExpItem"
            defaultDest = gstrExtImgPath
        End If

        validPath = True

        optUploadImgFolder.PerformClick()
    End Sub

    Private Sub optOper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUploadImgFolder.Click, optExceptImgFolder.Click
        Dim strSrcTgc As String

        If optUploadImgFolder.Checked = True Then
            If goBack = True Then
                strSrcTgc = "src"
                drvSource.SelectedIndex = drvSource.Items.IndexOf(defaultSourceUpload.Substring(0, defaultSourceUpload.IndexOf("\\") + 1))
                dirSource.Nodes(0).Expand()
                dirSource.SelectedNode = getNode(parsePath(defaultSourceUpload & "\", True), dirSource.Nodes, True)

                If dirSource.SelectedNode Is Nothing Then
                    MsgBox("Source Directory '" & defaultSourceUpload & "\' Not Found!")
                    validPath = False
                    checkValidPath()
                Else
                    validPath = True
                End If
            End If
            strSrcTgc = "tgc"
            drvDest.Items.Clear()
            drvDest.Items.Add(defaultDest)
            drvDest.SelectedIndex = drvDest.Items.IndexOf(defaultDest)
        ElseIf optExceptImgFolder.Checked = True Then
            If goBack = True Then
                strSrcTgc = "src"
                drvSource.SelectedIndex = drvSource.Items.IndexOf(defaultSourceExp.Substring(0, defaultSourceExp.IndexOf("\\") + 1))
                dirSource.Nodes(0).Expand()
                dirSource.SelectedNode = getNode(parsePath(defaultSourceExp & "\", True), dirSource.Nodes, True)

                If dirSource.SelectedNode Is Nothing Then
                    MsgBox("Source Directory '" & defaultSourceExp & "\' Not Found!")
                    validPath = False
                    checkValidPath()
                Else
                    validPath = True
                End If
            End If
            strSrcTgc = "tgc"
            drvDest.Items.Clear()
            drvDest.Items.Add(defaultDest)
            drvDest.SelectedIndex = drvDest.Items.IndexOf(defaultDest)
        End If
    End Sub

    Private Sub checkValidPath()
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
            cboCoCde.Enabled = False
            grpFolders.Enabled = False
            chkOverwrite.Checked = False
            chkView.Checked = False
            chkViewCont.Checked = False
        End If
    End Sub

    Private Sub drvSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.TextChanged

        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default

        Try
            dirSource.Nodes(0).Expand()
            filSourcePath = drvSource.Text
            dirSource.SelectedNode = dirSource.Nodes(0)
        Catch ex As Exception
            Exit Sub
        End Try
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

        expandDir(True, e.Node)
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
            'Construct a DirectoryInfo object of Node.filSourcePath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)
            'Construct a DirectoryInfo object array of all the 
            '    folders inside Node.filSourcePath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
            'MsgBox(dirNode.filSourcePath)
        Catch
            'This error trap prevents a crash when attempting 
            '    to access restricted folders.
        End Try
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For i As Integer = 0 To filSource.Items.Count - 1
            filSource.SetSelected(i, True)
        Next
    End Sub

    Private Sub cmdRefreshLst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshLst.Click
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

    Private Function itmExist(ByVal TmpItmNo As String) As String
        '*** Distribute the item images to appropriate folders
        '*** Return the sub-folder name if exist; else return the subfolder for exception
        Dim rs As New DataSet

        TmpItmNo = Replace(TmpItmNo, " ", "")
        TmpItmNo = Replace(TmpItmNo, "-", "_")
        TmpItmNo = Replace(TmpItmNo, ".JPG", "")
        TmpItmNo = Replace(TmpItmNo, ".jpg", "")
        TmpItmNo = Replace(TmpItmNo, "/", "_")
        TmpItmNo = Replace(TmpItmNo, "\", "")

        gspStr = "sp_select_IMAGE_UPLOAD '','" & TmpItmNo & "','" & IIf(cboCoCde.Text = strInternal, "I", "E")

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMG00001 #001 sp_select_IMAGE_UPLOAD : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Return ""
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            If cboCoCde.Text = strInternal Then
                itmExist = Replace(Replace(Replace(rs.Tables("RESULT").Rows(0)("ibi_lnecde"), " ", ""), "-", "_"), "/", "_")
            Else
                itmExist = Replace(Replace(Replace(rs.Tables("RESULT").Rows(0)("ibi_venno"), " ", ""), "-", "_"), "/", "_")
            End If
        Else
            itmExist = expitem  '*** Exception
        End If

        If itmExist = "" Then
            '*** The UCPP line code or the UCP vendor code has not been etnered yet
            itmExist = expItem  '*** Exception
        End If
    End Function

    Private Function FileCopy_Move(ByVal sourcepth As String, ByVal sourcefil As String, _
                               ByVal destpth As String, ByVal destfil As String, _
                               ByVal Move As Boolean, ByVal uploadpath As String) As Integer
        Dim strDate As String

        If Dir(destpth, vbDirectory) = "" Then
            MkDir(destpth)
        End If
        '*** Copy the file from source folder to destination folder
        On Error GoTo on_Error_Filecopy_Move1
        '****    Add for check file exist of not while copy file by Lewis on 20 May 2003 ***********************
        If Dir(destpth, vbDirectory) <> "" Then
            FileCopy(sourcepth & "\" & sourcefil, destpth & "\" & destfil)
            On Error GoTo 0
        End If

        If uploadpath <> "" Then
            On Error GoTo on_Error_Filecopy_Move3
            If Dir(uploadpath, vbDirectory) = "" Then
                MkDir(uploadpath)
            End If
            If Dir(uploadpath, vbDirectory) <> "" Then
                FileCopy(sourcepth & "\" & sourcefil, uploadpath & "\" & sourcefil)
                On Error GoTo 0
            End If
        End If


        '     MsgBox "From " + sourcepth + "\" + sourcefil + " to " + destpth + "\" + destfil
        '*** If the move option is on, delete the file in the source

        If Move = True And dirSource.SelectedNode.FullPath <> uploadpath Then
            On Error GoTo on_Error_Filecopy_Move2
            Kill(dirSource.SelectedNode.FullPath & "\" & sourcefil)
            On Error GoTo 0
        End If
        FileCopy_Move = 0
        Exit Function

on_Error_Filecopy_Move1:
        FileCopy_Move = 1
        Exit Function
on_Error_Filecopy_Move2:
        FileCopy_Move = 2
        Exit Function
on_Error_Filecopy_Move3:
        FileCopy_Move = 3
        Exit Function
    End Function

    Private Sub Image_upload_audit(ByVal strRmk As String, ByVal elpTime As Double)
        Dim rs As New DataSet
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
            MsgBox("Error on inserting IMG00002 #003 sp_insert_Image_Upload_aud : " & rtnStr)
            Exit Sub
        End If

    End Sub

    Private Sub txtLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLog.TextChanged
        txtLog.ScrollToCaret()
    End Sub
End Class