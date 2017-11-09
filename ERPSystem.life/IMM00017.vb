Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMM00017

    Private Const loc1_itmno As Integer = 1
    Private Const loc1_remark As Integer = 2

    Private Const filext As String = "*.xls"
    Private Const xlsVer As String = "4.0.28"

    Dim filSourcePath As String = ""

    Private Sub IMXLS001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

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
                MessageBox.Show("No fixed disks found!", _
                        "Drive Error!", MessageBoxButtons.OK, _
                        MessageBoxIcon.Exclamation)
            End Try
        End If

        dirSource.Nodes(0).Expand()

        dirSource.SelectedNode = dirSource.Nodes(0)

        txtProcess.Text = ""
        txtProcess.Refresh()
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
        Dim Dir As New  _
            System.IO.DirectoryInfo(e.Node.FullPath)
        'Construct a FileInfo object array of all the 
        '    files inside e.Node.FullPath that match
        '    FilePattern.
        On Error GoTo FILE_ACCESS_ERROR
        Dim Files As System.IO.FileInfo() = _
                Dir.GetFiles(filext)
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

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        cmdOK.Enabled = False

        Dim excel As Excel.Application

        Dim curRow As Integer
        Dim numError As Integer = 0

        Dim cur_Process() As Process
        Dim new_Process() As Process

        Dim xls1_itmno As String

        Dim xlsDate As String
        Dim xlsFile As String
        Dim xlsPath As String

        If filSource.Items.Count = 0 Then
            MsgBox("No Excel file in the directory!")
            cmdOK.Enabled = True
            Exit Sub
        Else
            txtProcess.Text = ""
        End If

        Dim oldCI As Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim itmnolist As String
        itmnolist = ""
        Dim i As Integer
        For i = 0 To filSource.Items.Count - 1
            cur_Process = Nothing
            cur_Process = Process.GetProcessesByName("EXCEL")
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            excel = Nothing
            excel = New Excel.Application
            Me.Cursor = Windows.Forms.Cursors.Default
            new_Process = Nothing
            new_Process = Process.GetProcessesByName("EXCEL")
            Try
                setErrMsg("Uploading - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                setErrMsg("Processing... Please Wait")

                xlsPath = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i)
                If xlsPath = "" Then
                    MsgBox("Invalid Directory", MsgBoxStyle.Exclamation, "Directory Error")
                    Throw New Exception("Invalid Directory")
                End If
                xlsFile = filSource.Items(i)
                xlsDate = Format(FileDateTime(xlsPath), "yyyy-MM-dd HH:mm:ss")
                excel.Workbooks.Open(xlsPath)
                xls1_itmno = ""


                curRow = 1

                Do While (Not excel.Cells(curRow, loc1_itmno).Value Is Nothing)


                    If (Not (excel.Cells(curRow, loc1_itmno).Value Is Nothing)) Then
                        xls1_itmno = Replace(Trim(excel.Cells(curRow, loc1_itmno).Value.ToString), "'", "''")
                        If xls1_itmno Is Nothing Then
                            xls1_itmno = ""
                        Else
                            xls1_itmno = "," + xls1_itmno
                        End If
                    Else
                        xls1_itmno = ""
                    End If
                    itmnolist = itmnolist & xls1_itmno

                    curRow += 1
                Loop
                'gspStr = "sp_select_IMM00017 '" & itmnolist & "'"
                'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                'rs_XLS = Nothing
                'rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                'Me.Cursor = Windows.Forms.Cursors.Default
                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on saving " & Me.Name & " #001 sp_insert_IMQURMK : " & rtnStr)
                '    killProcess(cur_Process, new_Process)
                '    Exit Sub
                'End If
            Catch ex As Exception
                numError += 1

                excel.Workbooks.Close()
                excel.Quit()
                excel = Nothing
                killProcess(cur_Process, new_Process)

                setErrMsg("An error has occured for " & filSource.Items(i) & "... Aborting Upload")

                Continue For
            End Try

            excel.Workbooks.Close()
            excel.Quit()
            excel = Nothing
            killProcess(cur_Process, new_Process)

            moveFile(filSource.Items(i), xlsPath, ".old", True)
        Next ' Next File
        exportReport(itmnolist)

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


        If numError = 0 Then
            setErrMsg("Request Completed!")
        Else
            setErrMsg("Partial Request Completed!")
            setErrMsg(numError & " error(s) has been detected")
        End If

        cmdOK.Enabled = True
        cmdRefresh.PerformClick()
    End Sub

    Private Sub setErrMsg(ByVal strMsg As String)
        If Trim(txtProcess.Text) = "" Then
            txtProcess.Text = Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        Else
            txtProcess.Text = txtProcess.Text & vbCrLf & Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        End If
        txtProcess.Refresh()
    End Sub
    Private Sub moveFile(ByVal xlsFile As String, ByVal curPath As String, ByVal extension As String, ByVal internal As String)
        Dim strFileCopy As String

        If internal = True Then
            If Dir(filSourcePath + "\ItemExcelOld", vbDirectory) = "" Then
                MkDir(filSourcePath + "\ItemExcelOld")
            End If
            strFileCopy = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & _
                      "ItemExcelOld\" & LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & extension
        Else
            If Dir(filSourcePath + "\ItemExcelOldExt", vbDirectory) = "" Then
                MkDir(filSourcePath + "\ItemExcelOldExt")
            End If
            strFileCopy = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & _
                      "ItemExcelOldExt\" & LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & extension
        End If

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


    '    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

    '        If (dirSource.SelectedNode Is Nothing) Then
    '            MsgBox("Directory Not Selected")
    '            Exit Sub
    '        End If
    '        '*** Refresh the source
    '        filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")


    '        'Construct a DirectoryInfo object of 
    '        '    the selected Node.
    '        Dim Dir As New  _
    '            System.IO.DirectoryInfo(filSourcePath)
    '        'Construct a FileInfo object array of all the 
    '        '    files inside e.Node.FullPath that match
    '        '    FilePattern.
    '        Dim Files As System.IO.FileInfo() = _
    '                Dir.GetFiles(filext)

    '        'Create a FileInfo object (File) for the 
    '        '    For-Each loop and clear the lstFiles 
    '        '    listbox before filling it.
    '        Dim File As System.IO.FileInfo
    '        filSource.Items.Clear()
    '        For Each File In Files
    '            'Add the file name to the lstFiles listbox
    '            filSource.Items.Add(File.Name)
    '        Next

    '        filSource.Refresh()
    '    End Sub

    Private Sub killProcess(ByVal before As Process(), ByVal after As Process())
        Dim exists As Boolean
        If Not before Is Nothing And Not after Is Nothing Then

            For i As Integer = 0 To after.Length - 1
                exists = False
                For j As Integer = 0 To before.Length - 1
                    If after(i).Id = before(j).Id Then
                        exists = True
                        Exit For
                    End If
                Next

                If exists = False Then
                    after(i).Kill()
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        exportReport(txtfake.Text)
    End Sub

    Private Sub exportReport(ByVal itemnoList As String)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Dim rs_IMM00017 As DataSet
        rs_IMM00017 = Nothing

        Dim getDataSuccess As Boolean
        getDataSuccess = getQuoteRemarkData(itemnoList, rs_IMM00017)

        If Not getDataSuccess Then
            MsgBox("Fail to get data!")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If rs_IMM00017.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        generateReportExcel(rs_IMM00017)

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Function getQuoteRemarkData(ByVal itemnoList As String, ByRef rs_IMM00017 As DataSet) As Boolean
        gspStr = "sp_select_IMQUORMK '" & itemnoList & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMM00017, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading sp_select_IMM00017 : " & rtnStr)
            Return False
        End If
        Return True
    End Function


    Private Sub generateReportExcel(ByRef rs_IMM00017 As DataSet)
        ''''Start: Dont care about this part. This is the code farmat to call a excel'''''''
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet
        ''''End: Dont care about this part. This is the code farmat to call a excel''''''''''''

        exportQuoteRemark(rs_IMM00017, xlsApp)

        xlsApp.Visible = True


        ' Release reference
        rs_IMM00017 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub exportQuoteRemark(ByRef rs_IMM00017 As DataSet, ByVal xlsApp As Excel.Application)
        fillContent(rs_IMM00017, xlsApp)
        setFormat(xlsApp)
    End Sub

    Private Sub fillContent(ByVal rs_IMM00017 As DataSet, ByVal xlsApp As Excel.Application)
        With xlsApp
            For i As Integer = 0 To rs_IMM00017.Tables("RESULT").Rows.Count - 1
                Dim quoteRmk As Boolean = rs_IMM00017.Tables("RESULT").Rows(i)("iqr_period").ToString <> ""
                Dim curCol As Integer = 1
                .Cells(2 + i, curCol) = rs_IMM00017.Tables("RESULT").Rows(i)("trueitmno").ToString
                curCol = curCol + 1
                .Cells(2 + i, curCol) = rs_IMM00017.Tables("RESULT").Rows(i)("itmnoinIM").ToString
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_period").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = rs_IMM00017.Tables("RESULT").Rows(i)("seq").ToString
                curCol = curCol + 1
                .Cells(2 + i, curCol) = rs_IMM00017.Tables("RESULT").Rows(i)("iqr_itmno").ToString
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_pckreq").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_spreq").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_cus1no").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_cus2no").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_sal").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_qudat").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_codgrp").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_pckgrp").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_cstgrp").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_devgrp").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("iqr_rmk").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, rs_IMM00017.Tables("RESULT").Rows(i)("cus1na").ToString, "")
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_cus1no").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_cus2no").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_period").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_pckunt").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_conftr").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_inrqty").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_mtrqty").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_cft").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_ftyprctrm").ToString)
                curCol = curCol + 1
                .Cells(2 + i, curCol) = If(quoteRmk, "", rs_IMM00017.Tables("RESULT").Rows(i)("imu_trantrm").ToString)
            Next
        End With
    End Sub


    Private Sub setFormat(ByVal xlsApp As Excel.Application)
        Dim curCol As Integer = 1
        With xlsApp
            'Header Initialization

            .Cells(1, curCol).Value = "對應貨號" + Environment.NewLine + "存在於IM"
            .Columns(curCol).ColumnWidth = 10
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

            curCol = curCol + 1

            .Cells(1, curCol).Value = "貨號存" + Environment.NewLine + "在於IM"
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "物料期間"
            .Columns(curCol).ColumnWidth = 8
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "no"
            .Columns(curCol).ColumnWidth = 4
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Columns(curCol).WrapText = True
            curCol = curCol + 1

            .Cells(1, curCol).Value = "貨號"
            .Columns(curCol).ColumnWidth = 17
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Cells(2, curCol + 1).Select() 'Freeze cell
            .ActiveWindow.FreezePanes = True
            curCol = curCol + 1

            .Cells(1, curCol).Value = "包裝要求"
            .Columns(curCol).ColumnWidth = 20
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "特別要求/ 對應貨號"
            .Columns(curCol).ColumnWidth = 30
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "第一客人"
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "第二客人"
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "營業員"
            .Columns(curCol).ColumnWidth = 15
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "詢問日期"
            .Columns(curCol).ColumnWidth = 11
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            .Columns(curCol).NumberFormat = "MM/dd/yyyy"
            curCol = curCol + 1

            .Cells(1, curCol).Value = "編碼組"
            .Columns(curCol).ColumnWidth = 20
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "包裝部"
            .Columns(curCol).ColumnWidth = 20
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "計價組"
            .Columns(curCol).ColumnWidth = 20
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "開發部/客務部"
            .Columns(curCol).ColumnWidth = 20
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "備注"
            .Columns(curCol).ColumnWidth = 25
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "第一客人名稱"
            .Columns(curCol).ColumnWidth = 22
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Pri" + Environment.NewLine + "Cust."
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Sec" + Environment.NewLine + "Cust."
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Period"
            .Columns(curCol).ColumnWidth = 8
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            curCol = curCol + 1

            .Cells(1, curCol).Value = "UM"
            .Columns(curCol).ColumnWidth = 7
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Ftr"
            .Columns(curCol).ColumnWidth = 5
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Inr"
            .Columns(curCol).ColumnWidth = 5
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Mtr"
            .Columns(curCol).ColumnWidth = 5
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "CFT"
            .Columns(curCol).ColumnWidth = 9
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Fty Prc Term"
            .Columns(curCol).ColumnWidth = 8
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Cells(1, curCol).Value = "Tran Term"
            .Columns(curCol).ColumnWidth = 5
            .Columns(curCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            curCol = curCol + 1

            .Range(xlsApp.Cells(1, 1), xlsApp.Cells(1, curCol)).AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)



        End With
        With xlsApp
            .Rows(1).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            '.Rows(1).Font.Bold = True
            .Range(xlsApp.Cells(1, 1), xlsApp.Cells(1, curCol)).AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)

            .Range(.Columns(1), .Columns(curCol)).WrapText = True
            .Range(.Columns(1), .Columns(curCol)).VerticalAlignment = Excel.Constants.xlCenter

            'Set page name 
        End With
    End Sub

End Class