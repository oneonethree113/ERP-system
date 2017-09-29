Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMXLS004

    Dim rs_EXCEL As DataSet
    Dim myExcel As Excel.Application
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""
    Dim numError As Integer

    Dim rs_check As New DataSet
    Dim rs_data As New DataSet
    Dim rs_check_hdr As New DataSet
    Dim rs_approve As New DataSet
    Dim colApv As Long
    Public uploadBatch As Date

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub IMXLS004_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        drvSource.Items.AddRange(System.IO.Directory.GetLogicalDrives)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()

        drvSource.Items.Clear()

        Dim sDrive As String

        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        Dim i As Integer

        For Each sDrive In drvSource.Items
            If sDrive.ToString.ToUpper.Equals("C:\") Then
                drvSource.SelectedIndex = i
            End If
            i += 1
        Next

        If drvSource.SelectedIndex = -1 Then
            Try
                drvSource.SelectedIndex = 1
            Catch
                MessageBox.Show("No fixed disks found!", "Drive Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        dirSource.Nodes(0).Expand()
        dirSource.SelectedNode = dirSource.Nodes(0)

        txtProcess.Text = ""
        txtProcess.Refresh()

        Call Formstartup(Me.Name)

        btcIMXLS004.SelectedIndex = 0
        btcIMXLS004.TabPages(0).Enabled = True
        btcIMXLS004.TabPages(1).Enabled = False
    End Sub

    Private Sub btcIMXLS004_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcIMXLS004.SelectedIndexChanged
        If btcIMXLS004.SelectedIndex = 1 Then
            optStatusA.Checked = True
        End If
    End Sub

    Private Sub drvSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.SelectedIndexChanged
        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub AddDirectories(ByVal Node As TreeNode)
        Try
            'Construct a DirectoryInfo object of Node.FullPath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)
            'Construct a DirectoryInfo object array of all the 
            '    folders inside Node.FullPath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
            'MsgBox(dirNode.FullPath)
        Catch
            'This error trap prevents a crash when attempting 
            '    to access restricted folders.
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

        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.FullPath that match
        '    FilePattern.
        On Error GoTo FILE_ACCESS_ERROR

        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        filSourcePath = Dir.FullName
        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next
        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub

    Private Sub setErrMsg(ByVal strMsg As String)
        If Trim(txtProcess.Text) = "" Then
            txtProcess.Text = Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        Else
            txtProcess.Text = txtProcess.Text & vbCrLf & Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        End If
        txtProcess.Refresh()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Call cmdRefreshClick()
    End Sub

    Private Sub cmdRefreshClick()
        If (dirSource.SelectedNode Is Nothing) Then
            MsgBox("Directory Not Selected")
            Exit Sub
        End If
        '*** Refresh the source
        filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")

        'Construct a DirectoryInfo object of 
        '    the selected Node.
        Dim Dir As New  _
            System.IO.DirectoryInfo(filSourcePath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.FullPath that match
        '    FilePattern.
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        'Create a FileInfo object (File) for the 
        '    For-Each loop and clear the lstFiles 
        '    listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        filSource.Refresh()
    End Sub

    Private Sub moveFile(ByVal xlsFile As String, ByVal curPath As String, ByVal extension As String)
        Dim strFileCopy As String

        If Dir(filSourcePath + "\ItemExcelOld", vbDirectory) = "" Then
            MkDir(filSourcePath + "\ItemExcelOld")
        End If

        strFileCopy = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & _
                  "ItemExcelOld\" & LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & extension

        On Error GoTo err_Handle_File_Access_Error

        If Dir(strFileCopy) = (LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & extension) Then
            Kill(strFileCopy)
            'Name xlsPath As strFileCopy  ''Rename the Excel File to "XXX.old" format
            File.Move(curPath, strFileCopy)
        Else
            'Name xlsPath As strFileCopy  ''Rename the Excel File to "XXX.old" format
            If File.Exists(curPath) = True Then
                File.Move(curPath, strFileCopy)
            End If
        End If
        Exit Sub

err_Handle_File_Access_Error:
        MsgBox(Err.Description & vbCrLf & xlsFile, vbOKOnly + vbCritical, "File Access Error")
        setErrMsg("An error has occurred during upload. Upload has been terminated")
        Err.Clear()
        On Error GoTo 0
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim rs As New DataSet
        Dim rs_tmp As New DataSet

        Dim myExcel As New Excel.Application

        Dim intCount As Integer
        Dim intRow As Integer
        Dim xlsPath As String
        Dim strFileDate As String

        Dim itmNo As String
        Dim cusno As String
        Dim cusStyNo As String
        Dim seq As Integer
        Dim filnam As String

        Dim strFileCopy As String
        Dim intCopy As Integer

        Dim inValidFileName As String

        Dim oldCI As Globalization.CultureInfo

        intRow = 0
        txtProcess.Text = ""

        If filSource.Items.Count = 0 Then
            MsgBox("No Excel file in the directory!")
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Err.Clear()
        intCount = 0

        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If Dir(filSourcePath + "\ItemExcelOld", vbDirectory) = "" Then
            MkDir(filSourcePath + "\ItemExcelOld")
        End If

        myExcel = New Excel.Application

        Try
            Do While intCount < filSource.Items.Count
                itmNo = ""
                cusno = ""
                cusStyNo = ""
                seq = 0
                filnam = ""

                setErrMsg("Uploading - " & filSourcePath & IIf(Microsoft.VisualBasic.Right(filSourcePath, 1) = "\", "", "\") & filSource.Items(intCount) & ", please wait...")
                xlsPath = filSourcePath & IIf(Microsoft.VisualBasic.Right(filSourcePath, 1) = "\", "", "\") & filSource.Items(intCount)
                strFileDate = Format(FileDateTime(xlsPath), "MM/dd/yyyy HH:MM:SS")

                With myExcel
                    .Workbooks.Open(xlsPath)        'Open the excel file
                    .Sheets(1).Select()               'Select the first sheet

                    intRow = 2
                    uploadBatch = Now()

                    Do While Not (.Cells(intRow, 1).Value) Is Nothing
                        If (Not (.Cells(intRow, 1).Value Is Nothing)) Then
                            itmNo = Replace(Trim(.Cells(intRow, 1).Value.ToString), "'", "''")
                        Else
                            itmNo = ""
                        End If
                        If (Not (.Cells(intRow, 2).Value Is Nothing)) Then
                            cusno = Replace(Trim(.Cells(intRow, 2).Value.ToString), "'", "''")
                        Else
                            cusno = ""
                        End If
                        If (Not (.Cells(intRow, 3).Value Is Nothing)) Then
                            cusStyNo = Replace(Trim(.Cells(intRow, 3).Value.ToString), "'", "''")
                        Else
                            cusStyNo = ""
                        End If
                        seq = intRow - 1
                        filnam = filSource.Items(intCount)

                        'S = "㊣IMITMCUSSTY※A※" & uploadBatch & _
                        '    "※" & seq & "※" & itmNo & _
                        '    "※" & cusno & "※" & cusStyNo & _
                        '    "※" & filnam & "※" & gsUsrID
                        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

                        gspStr = "sp_insert_IMITMCUSSTY '" & gsCompany & "','" & uploadBatch & _
                                                    "','" & seq & "','" & itmNo & _
                                                    "','" & cusno & "','" & cusStyNo & _
                                                    "','" & filnam & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        gspStr = ""

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdOK_Click sp_insert_IMITMCUSSTY :" & rtnStr)
                            Exit Sub
                        End If

                        intRow = intRow + 1
                    Loop
                End With
                Err.Clear()

                myExcel.Workbooks.Close()
                myExcel.Quit()
                myExcel = Nothing

                Call moveFile(filSource.Items(intCount), xlsPath, ".old")

                intCount = intCount + 1
            Loop

            Call cmdRefreshClick()
            MsgBox("Excel File Upload Finished!")

            btcIMXLS004.TabPages(1).Enabled = True
            btcIMXLS004.SelectedIndex = 1
            Call cmdShowClick()
            Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.ToString)
            myExcel.Workbooks.Close()
            myExcel.Quit()
            myExcel = Nothing
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtFromApply_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromApply.GotFocus
        txtFromApply.SelectAll()
    End Sub

    Private Sub txtFromApply_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromApply.KeyPress
        If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtToApply_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToApply.GotFocus
        txtToApply.SelectAll()
    End Sub

    Private Sub txtToApply_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToApply.KeyPress
        If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cmdShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShowClick()
    End Sub

    Private Sub cmdShowClick()
        'S = "㊣IMITMCUSSTY※S※" & uploadBatch & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_IMITMCUSSTY '" & gsCompany & "','" & uploadBatch & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_approve, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdShowClick sp_select_IMITMCUSSTY :" & rtnStr)
            Exit Sub
        End If

        If rs_approve.Tables("RESULT").DefaultView.Count > 0 Then
            Call fillCount()
            grdItem.DataSource = rs_approve.Tables("RESULT").DefaultView
            txtFromApply.Text = 1
            txtToApply.Text = rs_approve.Tables("RESULT").DefaultView.Count
            Call displayGrid()
        End If
    End Sub

    Private Sub fillCount()
        For index As Integer = 0 To rs_approve.Tables("RESULT").DefaultView.Count - 1
            rs_approve.Tables("RESULT").Columns("no").ReadOnly = False
            rs_approve.Tables("RESULT").DefaultView(index)("no") = index + 1
            rs_approve.Tables("RESULT").Columns("no").ReadOnly = True
        Next
    End Sub

    Private Sub displayGrid()
        With grdItem
            Dim col As Integer

            col = 0

            .Columns(col).ReadOnly = True
            .Columns(col).HeaderText = "ID"
            .Columns(col).Width = 30

            col = col + 1
            colApv = col
            '.Columns(col).Button = True
            .Columns(col).ReadOnly = True
            .Columns(col).HeaderText = "Apv"
            .Columns(col).Width = 35

            col = col + 1
            .Columns(col).HeaderText = "Item number"
            .Columns(col).Width = 100

            col = col + 1
            .Columns(col).HeaderText = "Cust. No"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 80

            col = col + 1
            .Columns(col).HeaderText = "Cust. Style No."
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 110

            col = col + 1
            .Columns(col).HeaderText = "Mode"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 55

            col = col + 1
            .Columns(col).HeaderText = "Message"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 150

            col = col + 1
            .Columns(col).HeaderText = "Excel File"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 140

            col = col + 1
            .Columns(col).HeaderText = "Upload"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 130

            col = col + 1
            .Columns(col).HeaderText = "Seq"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 30

            col = col + 1
            .Columns(col).HeaderText = "Create user"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 90

            col = col + 1
            .Columns(col).HeaderText = "Update user"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 90

            col = col + 1
            .Columns(col).HeaderText = "Create date"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 120

            col = col + 1
            .Columns(col).HeaderText = "Update date"
            .Columns(col).ReadOnly = True
            .Columns(col).Width = 120
        End With
    End Sub

    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If rs_approve.Tables.Count = 0 Then Exit Sub
        If rs_approve.Tables("RESULT").Rows.Count <= 0 Then Exit Sub

        Dim strStatus As String

        If optStatusW.Checked = True Then
            strStatus = "W"
        ElseIf optStatusA.Checked = True Then
            strStatus = "A"
        Else
            strStatus = "R"
        End If

        If Val(txtFromApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Val(txtToApply.Text) > rs_approve.Tables("RESULT").Rows.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            txtToApply.SelectAll()
            Exit Sub
        End If

        If Val(txtFromApply.Text) > Val(txtToApply.Text) Then
            MsgBox("The apply range is invalid.")
            txtToApply.SelectAll()
            Exit Sub
        End If

        Dim intFm As Integer = CInt(txtFromApply.Text)
        Dim intTo As Integer = CInt(txtToApply.Text)

        If intTo > rs_approve.Tables("RESULT").Rows.Count Then
            intTo = rs_approve.Tables("RESULT").Rows.Count
        End If

        If rs_approve.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = intFm To intTo
                rs_approve.Tables("RESULT").Columns("iic_sts").ReadOnly = False
                rs_approve.Tables("RESULT").Rows(index - 1)("iic_sts") = strStatus
                rs_approve.Tables("RESULT").Columns("iic_sts").ReadOnly = True
            Next
            rs_approve.Tables("RESULT").AcceptChanges()
        End If

        strStatus = ""
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call cmdClearClick()
    End Sub

    Private Sub cmdClearClick()
        If Not grdItem.DataSource Is Nothing Then grdItem.DataSource = Nothing
    End Sub

    Private Sub grdItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItem.CellClick
        If rs_approve.Tables("RESULT").DefaultView.Count > 0 Then
            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                If rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts").ToString = "A" Then
                    rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts") = "R"
                ElseIf rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts").ToString = "R" Then
                    rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts") = "W"
                ElseIf rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts").ToString = "W" Then
                    rs_approve.Tables("RESULT").DefaultView(e.RowIndex)("iic_sts") = "A"
                End If
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If rs_approve.Tables.Count = 0 Then Exit Sub
        If rs_approve.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        Dim rs As New DataSet
        Dim rs_OldRej As New DataSet

        If MsgBox("Confirm to approve marked item(s)?", vbYesNo + vbQuestion) = vbNo Then
            Exit Sub
        End If

        If rs_approve.Tables("RESULT").DefaultView.Count > 0 Then
            With rs_approve
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    If .Tables("RESULT").DefaultView(index)("iic_sts").ToString = "A" Then
                        'S = "㊣IMCUSSTY※U※" & .Fields("iic_cusno") & "※" & .Fields("iic_cusstyno") & "※" & .Fields("iic_itmno") & "※" & gsUsrID
                        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

                        Cursor = Cursors.WaitCursor

                        gspStr = "sp_update_IMCUSSTY '" & gsCompany & "','" & .Tables("RESULT").DefaultView(index)("iic_cusno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_cusstyno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_itmno") & "','" & _
                                                        gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        gspStr = ""

                        Cursor = Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSave_Click sp_update_IMCUSSTY :" & rtnStr)
                            Exit Sub
                        End If

                        'S = "㊣IMCUSSTY※A※" & .Fields("iic_cusno") & "※" & .Fields("iic_cusstyno") & "※" & .Fields("iic_itmno") & "※" & gsUsrID
                        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

                        Cursor = Cursors.WaitCursor

                        gspStr = "sp_insert_IMCUSSTY '" & gsCompany & "','" & .Tables("RESULT").DefaultView(index)("iic_cusno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_cusstyno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_itmno") & "','" & _
                                                        gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        gspStr = ""

                        Cursor = Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSave_Click sp_insert_IMCUSSTY :" & rtnStr)
                            Exit Sub
                        End If
                    End If

                    If .Tables("RESULT").DefaultView(index)("iic_sts").ToString = "A" Or .Tables("RESULT").DefaultView(index)("iic_sts").ToString = "R" Then
                        'S = "㊣IMITMCUSSTY※U※" & .Fields("iic_upload") & "※" & .Fields("iic_seq") & _
                        '    "※" & .Fields("iic_sts") & "※" & .Fields("iic_itmno") & "※" & .Fields("iic_cusno") & _
                        '    "※" & .Fields("iic_cusstyno") & "※" & .Fields("iic_mode") & "※" & .Fields("iic_sysmsg") & _
                        '    "※" & .Fields("iic_filnam") & "※" & .Fields("iic_creusr") & "※" & .Fields("iic_updusr") & _
                        '    "※" & .Fields("iic_credat") & "※" & .Fields("iic_upddat") & _
                        '    "※" & gsUsrID
                        'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

                        Cursor = Cursors.WaitCursor

                        gspStr = "sp_update_IMITMCUSSTY '" & gsCompany & "','" & .Tables("RESULT").DefaultView(index)("iic_upload") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_seq") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_sts") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_itmno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_cusno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_cusstyno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_mode") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_sysmsg") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_filnam") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_creusr") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_updusr") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_credat") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_upddat") & "','" & _
                                                        gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        gspStr = ""

                        Cursor = Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSave_Click sp_update_IMITMCUSSTY 1 :" & rtnStr)
                            Exit Sub
                        End If

                        ' Move old record to history table
                        'S = "㊣IMITMCUSSTY_old※S※" & .Fields("iic_itmno") & "※" & .Fields("iic_cusno")
                        'rsh = objBSGate.Enquire(gsConnStr, "sp_general", S)

                        Cursor = Cursors.WaitCursor

                        gspStr = "sp_select_IMITMCUSSTY_old '" & gsCompany & "','" & .Tables("RESULT").DefaultView(index)("iic_itmno") & "','" & _
                                                        .Tables("RESULT").DefaultView(index)("iic_cusno") & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_OldRej, rtnStr)
                        gspStr = ""

                        Cursor = Cursors.Default

                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSave_Click sp_select_IMITMCUSSTY_old :" & rtnStr)
                            Exit Sub
                        End If

                        If rs_OldRej.Tables("RESULT").Rows.Count > 0 Then
                            With rs_OldRej
                                For index1 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                                    'S = "㊣IMITMCUSSTY※U※" & .Fields("iic_upload") & "※" & .Fields("iic_seq") & _
                                    '    "※" & .Fields("iic_sts") & "※" & .Fields("iic_itmno") & "※" & .Fields("iic_cusno") & _
                                    '    "※" & .Fields("iic_cusstyno") & "※" & .Fields("iic_mode") & "※" & .Fields("iic_sysmsg") & _
                                    '    "※" & .Fields("iic_filnam") & "※" & .Fields("iic_creusr") & "※" & .Fields("iic_updusr") & _
                                    '    "※" & .Fields("iic_credat") & "※" & .Fields("iic_upddat") & _
                                    '    "※" & gsUsrID
                                    'rs = objBSGate.Modify(gsConnStr, "sp_general", S)

                                    Cursor = Cursors.WaitCursor

                                    gspStr = "sp_update_IMITMCUSSTY '" & gsCompany & "','" & .Tables("RESULT").DefaultView(index1)("iic_upload") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_seq") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_sts") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_itmno") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_cusno") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_cusstyno") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_mode") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_sysmsg") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_filnam") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_creusr") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_updusr") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_credat") & "','" & _
                                                                    .Tables("RESULT").DefaultView(index1)("iic_upddat") & "','" & _
                                                                    gsUsrID & "'"
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    gspStr = ""

                                    Cursor = Cursors.Default

                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading cmdSave_Click sp_update_IMITMCUSSTY 2 :" & rtnStr)
                                        Exit Sub
                                    End If
                                Next
                            End With
                        End If
                    End If
                Next
            End With

            MsgBox("Update Item(s), Finished!")
        Else
            MsgBox("No record mark approve!")
        End If

        Call cmdClearClick()
        Call cmdShowClick()
    End Sub
End Class