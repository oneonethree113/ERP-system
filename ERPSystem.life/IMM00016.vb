Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMM00016

    Private Const col_period As Integer = 1
    Private Const col_itmno As Integer = 3
    Private Const col_pckreq As Integer = 4
    Private Const col_spreq As Integer = 5
    Private Const col_cus1no As Integer = 6
    Private Const col_cus2no As Integer = 7
    Private Const col_sal As Integer = 8
    Private Const col_qudat As Integer = 9
    Private Const col_codgrp As Integer = 10
    Private Const col_pckgrp As Integer = 11
    Private Const col_cstgrp As Integer = 12
    Private Const col_devgrp As Integer = 13
    Private Const col_rmk As Integer = 14
    Private Const col_creusr As Integer = 15
    Private Const col_updusr As Integer = 16
    Private Const col_credat As Integer = 17
    Private Const col_upddat As Integer = 18


    Private Const filext As String = "*.xls"
    Private Const xlsVer As String = "4.0.28"

    Dim filSourcePath As String = ""
    Dim rs_CUBASINF_P As DataSet = Nothing

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


        gspStr = "sp_select_CUBASINF_P '','Primary'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUM00001  sp_select_CUBASINF_P : " & rtnStr)
            Exit Sub
        End If

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

        Dim iqr_period As String
        Dim iqr_itmno As String
        Dim iqr_pckreq As String
        Dim iqr_spreq As String
        Dim iqr_cus1no As String
        Dim iqr_cus2no As String
        Dim iqr_sal As String
        Dim iqr_qudat As String
        Dim iqr_codgrp As String
        Dim iqr_pckgrp As String
        Dim iqr_cstgrp As String
        Dim iqr_devgrp As String
        Dim iqr_rmk As String


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


                curRow = 2

                Do While (Not excel.Cells(curRow, col_period).Value Is Nothing)
                    If (Not (excel.Cells(curRow, col_period).Value Is Nothing)) Then
                        iqr_period = Replace(Trim(excel.Cells(curRow, col_period).Value.ToString), "'", "''")
                        If iqr_period Is Nothing Then
                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("Period is mandatory field")
                            Throw New Exception("Missing mandatory field")
                        End If
                    Else
                        setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                        setErrMsg("Period is mandatory field")
                        Throw New Exception("Missing mandatory field")
                    End If

                    If (Not (excel.Cells(curRow, col_itmno).Value Is Nothing)) Then
                        iqr_itmno = Replace(Trim(excel.Cells(curRow, col_itmno).Value.ToString), "'", "''")
                        If iqr_itmno Is Nothing Then
                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("Item no is mandatory field")
                            Throw New Exception("Missing mandatory field")
                        End If
                    Else
                        setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                        setErrMsg("Item no is mandatory field")
                        Throw New Exception("Missing mandatory field")
                    End If

                    If (Not (excel.Cells(curRow, col_pckreq).Value Is Nothing)) Then
                        iqr_pckreq = Replace(Trim(excel.Cells(curRow, col_pckreq).Value.ToString), "'", "''")
                        If iqr_pckreq Is Nothing Then
                            iqr_pckreq = ""
                        End If
                    Else
                        iqr_pckreq = ""
                    End If

                    If (Not (excel.Cells(curRow, col_spreq).Value Is Nothing)) Then
                        iqr_spreq = Replace(Trim(excel.Cells(curRow, col_spreq).Value.ToString), "'", "''")
                        If iqr_spreq Is Nothing Then
                            iqr_spreq = ""
                        End If
                    Else
                        iqr_spreq = ""
                    End If


                    If (Not (excel.Cells(curRow, col_cus1no).Value Is Nothing)) Then
                        iqr_cus1no = Replace(Trim(excel.Cells(curRow, col_cus1no).Value.ToString), "'", "''")
                        If iqr_cus1no Is Nothing Then
                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("Pri. Cust is mandatory field")
                            Throw New Exception("Missing mandatory field")
                        End If
                        rs_CUBASINF_P.Tables("RESULT").DefaultView.RowFilter = "cbi_cusno='" + iqr_cus1no + "'"
                        If (iqr_cus1no <> "B" And iqr_cus1no <> "I" And (iqr_cus1no.Substring(0, 1) <> "5" Or (rs_CUBASINF_P.Tables("result").DefaultView.Count = 0 And iqr_cus1no.Substring(0, 1) = "5"))) Then

                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("Pri. Cust value is not valid")
                            Throw New Exception("Missing mandatory field")
                        End If
                        rs_CUBASINF_P.Tables("RESULT").DefaultView.RowFilter = ""
                    Else
                        setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                        setErrMsg("Pri. Cust is mandatory field")
                        Throw New Exception("Missing mandatory field")
                    End If

                    If (Not (excel.Cells(curRow, col_cus2no).Value Is Nothing)) Then
                        iqr_cus2no = Replace(Trim(excel.Cells(curRow, col_cus2no).Value.ToString), "'", "''")
                        If iqr_cus2no Is Nothing Then
                            iqr_cus2no = ""
                        End If
                    Else
                        iqr_cus2no = ""
                    End If

                    If (Not (excel.Cells(curRow, col_sal).Value Is Nothing)) Then
                        iqr_sal = Replace(Trim(excel.Cells(curRow, col_sal).Value.ToString), "'", "''")
                        If iqr_sal Is Nothing Then
                            iqr_sal = ""
                        End If
                    Else
                        iqr_sal = ""
                    End If

                    If (Not (excel.Cells(curRow, col_qudat).Value Is Nothing)) Then
                        iqr_qudat = Replace(Trim(excel.Cells(curRow, col_qudat).Value.ToString), "'", "''")
                        If iqr_qudat Is Nothing Then
                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("詢問日期 is mandatory field")
                            Throw New Exception("Incorrect Excel file version")
                        End If
                        If IsDate(iqr_qudat) = False Then
                            setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                            setErrMsg("詢問日期 is not a date")
                            Throw New Exception("Data error")
                        End If
                        iqr_qudat = Format(CDate(iqr_qudat), "yyyy-MM-dd 00:00:00.000")
                    Else
                        setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                        setErrMsg("詢問日期 is mandatory field")
                        Throw New Exception("Missing mandatory field")
                    End If

                    If (Not (excel.Cells(curRow, col_codgrp).Value Is Nothing)) Then
                        iqr_codgrp = Replace(Trim(excel.Cells(curRow, col_codgrp).Value.ToString), "'", "''")
                        If iqr_codgrp Is Nothing Then
                            iqr_codgrp = ""
                        End If
                    Else
                        iqr_codgrp = ""
                    End If

                    If (Not (excel.Cells(curRow, col_pckgrp).Value Is Nothing)) Then
                        iqr_pckgrp = Replace(Trim(excel.Cells(curRow, col_pckgrp).Value.ToString), "'", "''")
                        If iqr_pckgrp Is Nothing Then
                            iqr_pckgrp = ""
                        End If
                    Else
                        iqr_pckgrp = ""
                    End If

                    If (Not (excel.Cells(curRow, col_cstgrp).Value Is Nothing)) Then
                        iqr_cstgrp = Replace(Trim(excel.Cells(curRow, col_cstgrp).Value.ToString), "'", "''")
                        If iqr_cstgrp Is Nothing Then
                            iqr_cstgrp = ""
                        End If
                    Else
                        iqr_cstgrp = ""
                    End If

                    If (Not (excel.Cells(curRow, col_devgrp).Value Is Nothing)) Then
                        iqr_devgrp = Replace(Trim(excel.Cells(curRow, col_devgrp).Value.ToString), "'", "''")
                        If iqr_devgrp Is Nothing Then
                            iqr_devgrp = ""
                        End If
                    Else
                        iqr_devgrp = ""
                    End If

                    If (Not (excel.Cells(curRow, col_rmk).Value Is Nothing)) Then
                        iqr_rmk = Replace(Trim(excel.Cells(curRow, col_rmk).Value.ToString), "'", "''")
                        If iqr_rmk Is Nothing Then
                            iqr_rmk = ""
                        End If
                    Else
                        iqr_rmk = ""
                    End If

                    gspStr = "sp_insert_IMQUORMK '" & _
                                 Trim(iqr_period) & "','" & _
                                 Trim(iqr_itmno) & "','" & _
                                 Trim(iqr_pckreq) & "','" & _
                                 Trim(iqr_spreq) & "','" & _
                                 Trim(iqr_cus1no) & "','" & _
                                 Trim(iqr_cus2no) & "','" & _
                                 Trim(iqr_sal) & "','" & _
                                 Trim(iqr_qudat) & "','" & _
                                 Trim(iqr_codgrp) & "','" & _
                                 Trim(iqr_pckgrp) & "','" & _
                                 Trim(iqr_cstgrp) & "','" & _
                                 Trim(iqr_devgrp) & "','" & _
                                 Trim(iqr_rmk) & "','" & _
                                 LCase(gsUsrID) & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Dim rs_XLS As DataSet
                    rs_XLS = Nothing
                    rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving " & Me.Name & " #001 sp_insert_IMQURMK : " & rtnStr)
                        killProcess(cur_Process, new_Process)
                        Exit Sub
                    End If

                    curRow += 1
                Loop
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
        'exportReport(itmnolist)

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

    Private Sub setErrMsg(ByVal strMsg As String)
        If Trim(txtProcess.Text) = "" Then
            txtProcess.Text = Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        Else
            txtProcess.Text = txtProcess.Text & vbCrLf & Format(Now(), "MM-dd-yyyy HH:mm:ss") & " " & strMsg
        End If
        txtProcess.Refresh()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

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
        Dim Files As System.IO.FileInfo() = _
                Dir.GetFiles(filext)

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

    Private Sub killProcess(ByVal before As Process(), ByVal after As Process())
        Dim exists As Boolean
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
    End Sub

End Class