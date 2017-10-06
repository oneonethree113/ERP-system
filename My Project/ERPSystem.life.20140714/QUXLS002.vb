Imports Microsoft.Office.Interop
Imports System.IO

Public Class QUXLS002
    Inherits System.Windows.Forms.Form

    Dim filSourcePath As String = ""
    Dim numError As Integer


    Public uploadBatch As Date

    Public rs_Excel_template As New DataSet

    Private Const sMODULE As String = "QU"

    Dim pth As String
    Public rs_CUBASINF_rounding As New DataSet
    Public cus1_rounding As Integer

    Public rs_QUR0000excel As New DataSet
    Public rs_QUASSINF As New DataSet ' for Assortment Item information
    Dim rs_QUPRCEMT_MU As New DataSet

    Dim temp_NumberFormat As String

    Dim rs_lightspec As New DataSet
    Dim gc_excel_int As Integer
    Dim gc_excel_ext As Integer

    Dim xlsApp_com As New Excel.ApplicationClass
    Dim xlsWB_com As Excel.Workbook = Nothing
    Dim xlsWS_com As Excel.Worksheet = Nothing
    Dim rs_CUBASINF_P As New DataSet ' for Secondary Customer of Primary Customer






    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        drvSource.Refresh()
        drvSource.SelectedIndex = 1

        drvSource.Update()

        drvSource.SelectedIndex = 0

        dirSource.Refresh()

    End Sub
    Private Sub QUXLS002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'chkQutNew.Enabled = False
        'Call fillParameter()
        Call FillCompCombo_local(gsUsrID, cboCoCde)         'Get availble Company
        'Call GetDefaultCompany(cboCoCde, txtCoNam)

        Call fillcbodiv()

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


        cboCoCde.Text = "All"
        cboSalDiv.Text = "All"
        cboCus1No.Text = "All"


        Cursor.Current = Cursors.Default
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

            'Construct a DirectoryInfo object array of all the folders inside Node.FullPath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
        Catch
            'This error trap prevents a crash when attempting to access restricted folders.
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

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        On Error GoTo FILE_ACCESS_ERROR


        filSourcePath = Dir.FullName

        drvSource.Text = filSourcePath


        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo



        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Dim NewCopy As String
        Dim filDePath As String

        Dim tmp_cocde As String
        Dim tmp_cus1no As String
        Dim tmp_qutno As String



        filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")
        Dim YesNoCancel As Integer
        YesNoCancel = MsgBox("Save to folder " & filSourcePath & " ?", MsgBoxStyle.YesNoCancel)
        If YesNoCancel <> vbYes Then
            Exit Sub
        End If



        Dim input_cocde = cboCoCde.Text.ToString.Trim
        Dim input_saldiv = Split(cboSalDiv.Text.ToString.Trim, " - ")(0)
        Dim input_cus1no = Split(cboCus1No.Text.ToString.Trim, " - ")(0)

        gspStr = "sp_select_QU_Excel_template '" & input_cocde & "','" & input_saldiv & "','" & input_cus1no & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Excel_template, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_Excel_template :" & rtnStr)
            Exit Sub
        End If

        If rs_Excel_template.Tables("RESULT").Rows.Count = 0 Then
            MsgBox(".")
            Exit Sub
        Else 'gen

            Cursor = Cursors.WaitCursor


            If optStatusE.Checked <> True Then
                xlsApp_com = New Excel.Application

                xlsWB_com = xlsApp_com.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_6.xlsx")
                For index As Integer = 0 To rs_Excel_template.Tables("RESULT").Rows.Count - 1
                    'for each record
                    tmp_cocde = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_cocde")
                    tmp_cus1no = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_cus1no")
                    tmp_qutno = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_qutno")
                    Call Gen_each_int(tmp_cocde, tmp_cus1no, tmp_qutno)
                Next
                xlsWS_com = Nothing
                xlsWB_com = Nothing
                xlsApp_com = Nothing
            End If



            If optStatusI.Checked <> True Then
                xlsApp_com = New Excel.Application

                xlsWB_com = xlsApp_com.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_8.xlsx")
                For index As Integer = 0 To rs_Excel_template.Tables("RESULT").Rows.Count - 1
                    'for each record
                    tmp_cocde = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_cocde")
                    tmp_cus1no = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_cus1no")
                    tmp_qutno = rs_Excel_template.Tables("RESULT").Rows(index).Item("tmp_qutno")
                    Call Gen_each_ext(tmp_cocde, tmp_cus1no, tmp_qutno)
                Next
                xlsWS_com = Nothing
                xlsWB_com = Nothing
                xlsApp_com = Nothing

            End If

        End If



        MsgBox("Excel templates generated!")
        Cursor = Cursors.Default

    End Sub

    Private Sub Gen_each_int(ByVal tmp_cocde As String, ByVal tmp_cus1no As String, ByVal tmp_qutno As String)

        Cursor = Cursors.WaitCursor
        Dim sorting As String
        Dim Message As String

        gspStr = "sp_select_QURExporttoExcel '" & tmp_cocde & "','" & tmp_qutno & "','" & tmp_qutno & "','" & sorting & "'"
        Message = "sp_select_QURExporttoExcel"
        rtnLong = execute_SQLStatement(gspStr, rs_QUR0000excel, rtnStr)

        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QURExporttoExcel " & Message & " :" & rtnStr)
            Exit Sub
        End If

        If rs_QUR0000excel.Tables("RESULT").Rows.Count = 0 Then

        Else

            '*** Open excel format option
            If rs_QUR0000excel.Tables("RESULT").Rows.Count > 30000 Then
                Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                If answer = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If


            Call exportExcel_QURExportToExcel_int(tmp_cocde, tmp_cus1no, tmp_qutno)

            Exit Sub
        End If
        Cursor = Cursors.Default

    End Sub


    Private Sub Gen_each_ext(ByVal tmp_cocde As String, ByVal tmp_cus1no As String, ByVal tmp_qutno As String)

        Cursor = Cursors.WaitCursor
        Dim sorting As String
        Dim Message As String

        gspStr = "sp_select_QURExporttoExcel '" & tmp_cocde & "','" & tmp_qutno & "','" & tmp_qutno & "','" & sorting & "'"
        Message = "sp_select_QURExporttoExcel"
        rtnLong = execute_SQLStatement(gspStr, rs_QUR0000excel, rtnStr)

        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_QURExporttoExcel " & Message & " :" & rtnStr)
            Exit Sub
        End If

        If rs_QUR0000excel.Tables("RESULT").Rows.Count = 0 Then

        Else

            '*** Open excel format option
            If rs_QUR0000excel.Tables("RESULT").Rows.Count > 30000 Then
                Dim answer As String = MsgBox("Number of records are over 30000! Only the first 30000 records will be shown.", MsgBoxStyle.YesNo, "Exceeding Maximum Allowable Lines")
                If answer = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If


            Call exportExcel_QURExportToExcel_ext(tmp_cocde, tmp_cus1no, tmp_qutno)

            Exit Sub
        End If
        Cursor = Cursors.Default

    End Sub


    Private Function imageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing

        If ImageFilePath = "" Then
            Return Nothing
        End If

        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If

        Try
            Dim _fileInfo As New IO.FileInfo(ImageFilePath)
            Dim _NumBytes As Long = _fileInfo.Length
            Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)

            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))

            _fileInfo = Nothing
            _NumBytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()

            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    Private Sub filSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim file_to_upload As String
        'file_to_upload = filSourcePath + filSource.Text
        drvSource.Text = filSourcePath

    End Sub

    Private Sub dirSource_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles dirSource.AfterSelect

    End Sub

    Private Sub exportExcel_QURExportToExcel_int(ByVal tmp_cocde, ByVal tmp_cus1no, ByVal tmp_qutno)

        Dim Message As String
        Dim tmp_cat As String

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 3000 Then
            MsgBox("There are more than 3000 records!")
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim sFilter As String
        Dim temp_qud_venno As String

        Cursor = Cursors.WaitCursor

        sFilter = " ( qud_venno >= 'A' and qud_venno <='Z' )  OR   ( qud_venno >= 'a' and qud_venno <='z')  "
        rs_QUR0000excel.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_QUR0000excel.Tables("RESULT").DefaultView.Sort = "qud_qutseq"
        sFilter = ""

        If rs_QUR0000excel.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Sub
        End If

        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp_com.Visible = True
        xlsApp_com.UserControl = False

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ''xlsWB_com = xlsApp_com.Workbooks.Open("C:\QU_6.xlsx")
        ''xlsWB_com = xlsApp_com.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")

        xlsApp_com.Sheets(1).Activate()
        xlsWS_com = xlsWB_com.ActiveSheet

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Clear Sheet 1 
        'except row1, delete rows
        'For index7 As Integer = 0 To 3000
        '    '            xlsWS_com.Range(index7, 1).EntireRow.Delete()
        '    '           xlsWS_com.Range("A" + (index7 + 4).ToString).Select()
        '    xlsWS_com.Range("A" + (index7 + 4).ToString).EntireRow.Delete()

        'Next

        'For int & ext
        '        temp_qud_venno = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_venno").ToString.Trim
        Try
            'With xlsApp_com
            '    For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 2
            '        .Range("A3:BE3").Copy()
            '        .Range("A" + (i + 4).ToString).Select()
            '        xlsWS_com.Paste()
            '    Next
            '    .Range("A88:A88").Copy()
            'End With

            With xlsApp_com
                '                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 1
                For i As Integer = 0 To 0

                    Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc"))
                    Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")), 1, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr"))

                    Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp"))
                    Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde"))
                    Dim temp_flag_is_ass As Integer

                    Dim test_str As String
                    Dim test_DateTime As Date

                    temp_flag_is_ass = 0

                    If Not IsNumeric(temp_qud_conftr) Then
                        temp_qud_conftr = 1
                    End If

                    If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                        temp_flag_is_ass = 1
                    End If


                    tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat"))
                    If tmp_cat = "XMASTREE" Then
                        tmp_cat = "XMAS TREE"
                    End If
                    .Range("A" + (i + 3).ToString).Value = tmp_cat

                    .Range("B" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_imrmk")

                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_credat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")

                    .Range("D" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus1no")

                    '''20130909
                    'rounding
                    cus1_rounding = 4
                    If i = 0 Then
                        gsCompany = Trim(tmp_cocde)
                        Call Update_gs_Value(gsCompany)

                        gspStr = "sp_select_CUBASINF_rounding '" & tmp_cocde & "','" & .Range("D" + (i + 3).ToString).Value & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_rounding, rtnStr)

                        If rtnLong <> RC_SUCCESS Then
                            'MsgBox("Error on loading Display_Header rs_CUBASINF_rounding:" & rtnStr)
                            'Exit Sub
                        End If
                        ''
                        If Not rs_CUBASINF_rounding.Tables("RESULT") Is Nothing Then
                            If rs_CUBASINF_rounding.Tables("RESULT").Rows.Count > 0 Then
                                cus1_rounding = rs_CUBASINF_rounding.Tables("RESULT").Rows(0)("cbi_rounding")
                            End If
                        End If
                    End If

                    .Range("E" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus2no")

                    .Range("G" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_venno")
                    .Range("H" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_vensna")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")) Then
                        ' If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat") <> "" Then

                        test_str = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")
                        test_DateTime = DateTime.Parse(test_str)

                        .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)
                        'Else
                        'End If
                    End If

                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("K" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd")

                    .Range("L" + (i + 3).ToString).NumberFormat = "@"
                    .Range("L" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno")

                    ''assortment #s
                    gspStr = "sp_select_QUASSINF '" & tmp_cocde & "','" & tmp_qutno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_select_QUASSINF :" & rtnStr)
                        'Exit Sub
                    End If

                    sFilter = ""
                    sFilter = "qai_itmno= '" & .Range("L" + (i + 3).ToString).Value.ToString.Trim & "'"
                    rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter

                    rs_QUASSINF.Tables("RESULT").DefaultView.Sort = "qai_assitm"

                    Dim temp_ass_num As String
                    temp_ass_num = ""

                    For index2 As Integer = 0 To rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                        If index2 = rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1 Then
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            End If
                        Else
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            End If
                        End If
                    Next

                    .Range("F" + (i + 3).ToString).Value = temp_ass_num

                    .Range("M" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_colcde")

                    .Range("N" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmdsc")

                    ''
                    If temp_flag_is_ass = 1 Then
                        .Range("I" + (i + 3).ToString).Value = "ST" & temp_qud_conftr.ToString
                    Else
                        .Range("I" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If

                    If temp_flag_is_ass = 1 Then
                        .Range("O" + (i + 3).ToString).Value = "PC"
                    Else
                        .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If

                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                        .Range("P" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                            .Range("P" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty") * temp_qud_conftr
                            Else
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")
                            End If
                        End If
                    End If


                    '.Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mtrqty")
                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                        .Range("Q" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                            .Range("Q" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty") * temp_qud_conftr
                            Else
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")
                            End If
                        End If
                    End If

                    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cft")


                    .Range("S" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")
                    If temp_flag_is_ass = 1 Then
                        .Range("S" + (i + 3).ToString).Value = 1
                    End If
                    '
                    '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")
                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_fcurcde")
                    If .Range("T" + (i + 3).ToString).Value = "" Then
                        .Range("T" + (i + 3).ToString).Value = "USD"
                    End If


                    Dim temp_cur As String
                    temp_cur = .Range("T" + (i + 3).ToString).Value

                    .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA")
                    .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB")
                    .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC")
                    .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD")
                    .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran")
                    .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack")
                    If temp_flag_is_ass = 1 Then
                        .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA") / temp_qud_conftr
                        .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB") / temp_qud_conftr
                        .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC") / temp_qud_conftr
                        .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD") / temp_qud_conftr
                        .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran") / temp_qud_conftr
                        .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack") / temp_qud_conftr
                    End If


                    Dim temp_ftyprc As Double

                    If temp_flag_is_ass = 1 Then
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")) / temp_qud_conftr
                    Else
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc"))
                    End If

                    Dim temp_FTY_cost As Decimal
                    Dim temp_FTY_mu As Decimal

                    temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)

                    If IsNumeric(temp_FTY_cost) And IsNumeric(temp_ftyprc) Then
                        If Val(temp_FTY_cost) <> 0 Then

                            If temp_flag_is_ass = 1 Then
                                ' .Range("AL" + (i + 3).ToString).Value = temp_qud_conftr * Val(temp_ftyprc) / Val(temp_FTY_cost)
                                temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                                '.Range("AL" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            Else
                                '.Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(temp_FTY_cost)
                                temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                                '.Range("AL" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            End If

                        End If
                    End If

                    .Range("AM" + (i + 3).ToString).Value = temp_ftyprc

                    If temp_FTY_cost <> 0 Then
                        '   temp_ftyprc = temp_FTY_cost * temp_FTY_mu
                    Else
                        temp_FTY_mu = 1
                        .Range("AM" + (i + 3).ToString).Value = temp_ftyprc
                    End If

                    Dim temp_basprc As Decimal
                    Dim temp_adjprc As Decimal

                    If temp_flag_is_ass = 1 Then
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")) / temp_qud_conftr
                    Else
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc"))
                    End If

                    'for cal
                    Dim temp_hk_mu As Decimal

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") <> "USD" Then
                            'assuem HKD ,same cur
                        Else
                            If temp_cur = "HKD" And rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") = "USD" Then
                                temp_ftyprc = temp_ftyprc / 7.75
                            End If
                        End If
                    End If

                    If temp_ftyprc <> 0 Then
                        temp_hk_mu = temp_basprc / temp_ftyprc
                    Else
                        temp_hk_mu = 1
                    End If

                    .Range("AN" + (i + 3).ToString).Value = round(temp_hk_mu, 2)

                    .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_pckitr")
                    .Range("AC" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrdin")
                    .Range("AD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrwin")
                    .Range("AE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrhin")
                    .Range("AF" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrdin")
                    .Range("AG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrwin")
                    .Range("AH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrhin")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec") <> "" Then
                            .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")
                        Else
                            gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno") & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                            gspStr = ""
                            Cursor = Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                                Exit Sub
                            End If

                            If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                                .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                            Else
                                .Range("AK" + (i + 3).ToString).Value = ""
                            End If

                        End If
                    End If

                    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_prctrm")
                    '''TRAN TERM
                    .Range("AQ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_trantrm")

                    'New Template     
                    '                    .Range("AS" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg") <> "Y" Then
                            .Range("AS" + (i + 3).ToString).Value = "N"
                        Else
                            .Range("AS" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                        End If
                    Else
                        .Range("AS" + (i + 3).ToString).Value = "N"
                    End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")) Then
                        .Range("AU" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AU" + (i + 3).ToString).Value = .Range("AU" + (i + 3).ToString).Value / temp_qud_conftr
                        End If

                    Else
                        .Range("AU" + (i + 3).ToString).Value = "0"
                    End If

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")) Then
                        .Range("AW" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AW" + (i + 3).ToString).Value = .Range("AW" + (i + 3).ToString).Value / temp_qud_conftr
                        End If
                    Else
                        .Range("AW" + (i + 3).ToString).Value = 0

                    End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu")) Then
                        .Range("BD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu") / 100
                    Else
                        .Range("BD" + (i + 3).ToString).Value = "0"
                    End If

                    '20130909
                    temp_NumberFormat = "#,###."
                    For index3 As Integer = 0 To cus1_rounding - 1
                        temp_NumberFormat = temp_NumberFormat & "0"
                    Next
                    .Range("BE" + (i + 3).ToString).NumberFormat = temp_NumberFormat

                Next

                'Mark Up Table Sheet
                gspStr = "sp_select_QUPRCEMT_MU '" & .Range("D3").Value.ToString.Trim & "','INT'"
                Message = "sp_select_QUPRCEMT_MU"
                rtnLong = execute_SQLStatement(gspStr, rs_QUPRCEMT_MU, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click " & Message & " :" & rtnStr)
                    Exit Sub
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Clear Sheet(2)
                'Start
                '
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'MarkUp Page
                .Sheets(2).Activate()

                .Range("D17").Value = "-"
                .Range("E17").Value = "-"
                .Range("F17").Value = "-"
                .Range("G17").Value = "-"

                '2
                .Range("I17").Value = "-"
                .Range("J17").Value = "-"
                .Range("K17").Value = "-"
                .Range("L17").Value = "-"

                'CAT, Same Value

                .Range("D4").Value = 0
                .Range("D5").Value = 0

                .Range("D6").Value = 0

                .Range("D8").Value = 0
                .Range("D9").Value = 0
                .Range("D10").Value = 0
                .Range("D11").Value = 0

                .Range("D13").Value = 0
                .Range("D14").Value = 0
                .Range("D15").Value = 0

                .Range("D20").Value = 0
                .Range("D22").Value = 0

                '2

                .Range("I4").Value = 0
                .Range("I5").Value = 0

                .Range("I6").Value = 0

                .Range("I8").Value = 0
                .Range("I9").Value = 0
                .Range("I10").Value = 0
                .Range("I11").Value = 0

                .Range("I13").Value = 0
                .Range("I14").Value = 0
                .Range("I15").Value = 0

                .Range("I20").Value = 0
                .Range("I22").Value = 0
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '
                'End -Clear Sheet(2)
                '
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                If rs_QUPRCEMT_MU.Tables("result").Rows.Count > 0 Then

                    'MarkUp Page
                    .Sheets(2).Activate()

                    For i As Integer = 0 To rs_QUPRCEMT_MU.Tables("result").Rows.Count - 1

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("D17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                     .Range("D19").Value = .Range("D17").Value + .Range("D18").Value
                        End If

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("E17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                      .Range("E19").Value = .Range("D17").Value + .Range("E18").Value
                        End If

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("F17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                       .Range("F19").Value = .Range("D17").Value + .Range("F18").Value
                        End If

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("G17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                        .Range("G19").Value = .Range("D17").Value + .Range("G18").Value
                        End If

                        '2
                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("I17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If

                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("J17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If

                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("K17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If

                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("L17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If

                        'CAT, Same Value

                        If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" Then

                            .Range("D4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("D5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("D6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("D8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("D9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("D10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("D11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("D13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("D14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("D15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("D20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("D22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                        '2
                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMAS TREE" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "XMASTREE") Then

                            .Range("I4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("I5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("I6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("I8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("I9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("I10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("I11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("I13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("I14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("I15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("I20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("I22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                    Next

                Else
                    'no markup price
                End If

            End With

            With xlsApp_com
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    'xlsWS_com = Nothing
                    'xlsWB_com = Nothing
                    'xlsApp_com = Nothing
                    exportExcel_QURExportToExcel_int(tmp_cocde, tmp_cus1no, tmp_qutno)
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR000011 - Excel Error")
            End If
        End Try

        'Show the excel after creating process is completed
        Try
            filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")
            xlsWB_com.SaveAs(Filename:=filSourcePath + "\" + tmp_cocde + "_" + tmp_cus1no + "_int", FileFormat:=52)

        Catch ex As Exception
            MsgBox("Files at folder " + filSourcePath + " already exist. Please delete it before export a new one.")
        End Try

        xlsApp_com.Visible = True
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        ' Release reference


        Cursor = Cursors.Default
    End Sub





    Private Sub exportExcel_QURExportToExcel_ext(ByVal tmp_cocde, ByVal tmp_cus1no, ByVal tmp_qutno)
        Dim Message As String
        Dim tmp_cat As String

        If rs_QUR0000excel.Tables("RESULT").Rows.Count >= 3000 Then
            MsgBox("There are more than 3000 records!")
            rs_QUR0000excel = Nothing
            Exit Sub
        End If

        Dim hdrRow As Integer = 1
        Dim type As String = ""

        Dim sFilter As String
        Dim temp_qud_venno As String

        Cursor = Cursors.WaitCursor

        ''' not
        sFilter = " not (( qud_venno >= 'A' and qud_venno <='Z' )  OR   ( qud_venno >= 'a' and qud_venno <='z')  )"
        rs_QUR0000excel.Tables("RESULT").DefaultView.RowFilter = sFilter
        rs_QUR0000excel.Tables("RESULT").DefaultView.Sort = "qud_qutseq"
        sFilter = ""

        If rs_QUR0000excel.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Sub
        End If


        'xlsApp_com = New Excel.Application

        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp_com.Visible = True
        xlsApp_com.UserControl = False


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        '
        'xlsWB_com = xlsApp_com.Workbooks.Open("C:\QU_8.xlsx")
        'xlsWB_com = xlsApp_com.Workbooks.Open("C:\Program Files\ERPSystem\bin\QUTemplate\QU_6.xlsm")
        '        xlsWB_com = xlsApp_com.Workbooks.Open(Application.StartupPath + "\QUTemplate\QU_8.xlsx")

        xlsApp_com.Sheets(1).Activate()

        xlsWS_com = xlsWB_com.ActiveSheet

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Clear Sheet 1 
        'except row1, delete rows
        'For index7 As Integer = 0 To 3000
        '    '            xlsWS_com.Range(index7, 1).EntireRow.Delete()
        '    '           xlsWS_com.Range("A" + (index7 + 4).ToString).Select()
        '    xlsWS_com.Range("A" + (index7 + 4).ToString).EntireRow.Delete()

        'Next


        'For int & ext
        '        temp_qud_venno = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_venno").ToString.Trim

        Try



            'With xlsApp_com
            '    For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 2
            '        .Range("A3:BE3").Copy()

            '        .Range("A" + (i + 4).ToString).Select()
            '        xlsWS_com.Paste()
            '    Next
            '    .Range("A88:A88").Copy()
            'End With


            With xlsApp_com
                '                For i As Integer = 0 To rs_QUR0000excel.Tables("RESULT").DefaultView.Count - 1
                For i As Integer = 0 To 0

                    Dim temp_qud_contopc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc")), "N", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_contopc"))
                    Dim temp_qud_conftr = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")), 1, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr"))


                    Dim temp_qud_itmtyp = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp")), "REG", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmtyp"))
                    Dim temp_qud_um = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde")), "PC", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_untcde"))
                    Dim temp_flag_is_ass As Integer

                    Dim test_str As String
                    Dim test_DateTime As Date

                    temp_flag_is_ass = 0

                    If Not IsNumeric(temp_qud_conftr) Then
                        temp_qud_conftr = 1
                    End If

                    ''If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" And temp_qud_um = "PC" Then
                    If temp_qud_contopc = "Y" And temp_qud_conftr > 1 And temp_qud_itmtyp = "ASS" Then
                        temp_flag_is_ass = 1
                    End If

                    'New Template     
                    '                    .Range("A" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("ibi_catlvl3")

                    '## Either "XMASTREE"


                    tmp_cat = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat")), "STANDARD", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_cat"))
                    If tmp_cat = "XMASTREE" Then
                        tmp_cat = "XMAS TREE"
                    End If
                    .Range("A" + (i + 3).ToString).Value = tmp_cat




                    .Range("B" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_imrmk")

                    'test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat"))
                    'may need another filed for DTL input date
                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_credat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("C" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd HH:mm")


                    .Range("D" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus1no")
                    .Range("E" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("quh_cus2no")

                    .Range("G" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_venno")
                    .Range("H" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("vbi_vensna")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")) Then
                        ' If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat") <> "" Then

                        test_str = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_qutdat")
                        test_DateTime = DateTime.Parse(test_str)

                        .Range("J" + (i + 3).ToString).Value = Microsoft.VisualBasic.Left(test_DateTime.ToString("yyyy-MM-dd"), 7)


                        'Else
                        'End If
                    End If


                    test_str = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat")), "01/01/1900", rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_expdat"))
                    test_DateTime = DateTime.Parse(test_str)
                    .Range("K" + (i + 3).ToString).Value = test_DateTime.ToString("yyyy-MM-dd")

                    .Range("L" + (i + 3).ToString).NumberFormat = "@"
                    .Range("L" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno")

                    ''assortment #s
                    rs_QUASSINF.Tables.Clear()

                    gspStr = "sp_select_QUASSINF '" & tmp_cocde & "','" & tmp_qutno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_select_QUASSINF :" & rtnStr)
                        'Exit Sub
                    End If


                    sFilter = ""
                    sFilter = "qai_itmno= '" & .Range("L" + (i + 3).ToString).Value.ToString.Trim & "'"
                    rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter

                    rs_QUASSINF.Tables("RESULT").DefaultView.Sort = "qai_assitm"

                    Dim temp_ass_num As String
                    temp_ass_num = ""

                    For index2 As Integer = 0 To rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                        If index2 = rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1 Then
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde")
                            End If
                        Else
                            If rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty") = 0 Or rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString = "" Then
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_mtrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            Else
                                temp_ass_num = temp_ass_num & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_assitm") & " x " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_inrqty").ToString & " " & rs_QUASSINF.Tables("RESULT").DefaultView(index2)("qai_untcde") & " , "
                            End If
                        End If
                    Next


                    .Range("F" + (i + 3).ToString).Value = temp_ass_num




                    .Range("M" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_colcde")

                    .Range("N" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmdsc")



                    ''
                    If temp_flag_is_ass = 1 Then
                        .Range("I" + (i + 3).ToString).Value = "ST" & temp_qud_conftr.ToString
                    Else
                        .Range("I" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If


                    If temp_flag_is_ass = 1 Then
                        .Range("O" + (i + 3).ToString).Value = "PC"
                    Else
                        .Range("O" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_untcde")
                    End If

                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                        .Range("P" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")) Then
                            .Range("P" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty") * temp_qud_conftr
                            Else
                                .Range("P" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrqty")
                            End If
                        End If
                    End If



                    '.Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mtrqty")
                    If IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                        .Range("Q" + (i + 3).ToString).Value = 0
                    Else
                        If Not IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")) Then
                            .Range("Q" + (i + 3).ToString).Value = 0
                        Else
                            If temp_flag_is_ass = 1 Then
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty") * temp_qud_conftr
                            Else
                                .Range("Q" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrqty")
                            End If
                        End If
                    End If

                    .Range("R" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_cft")


                    .Range("S" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_conftr")
                    If temp_flag_is_ass = 1 Then
                        .Range("S" + (i + 3).ToString).Value = 1
                    End If
                    '
                    '                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")
                    .Range("T" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fcurcde")
                    If .Range("T" + (i + 3).ToString).Value = "" Then
                        .Range("T" + (i + 3).ToString).Value = "USD"
                    End If


                    Dim temp_cur As String
                    temp_cur = .Range("T" + (i + 3).ToString).Value

                    .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA")
                    .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB")
                    .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC")
                    .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD")
                    .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran")
                    .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack")
                    If temp_flag_is_ass = 1 Then
                        .Range("U" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstA") / temp_qud_conftr
                        .Range("V" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstB") / temp_qud_conftr
                        .Range("W" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstC") / temp_qud_conftr
                        .Range("X" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstD") / temp_qud_conftr
                        .Range("Y" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstTran") / temp_qud_conftr
                        .Range("Z" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycstPack") / temp_qud_conftr
                    End If

                    If temp_flag_is_ass = 1 Then
                        .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst") / temp_qud_conftr
                    Else
                        .Range("AA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftycst")
                    End If


                    Dim temp_ftyprc As Double

                    If temp_flag_is_ass = 1 Then
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")) / temp_qud_conftr
                    Else
                        temp_ftyprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc"))
                    End If

                    Dim temp_FTY_cost As Decimal
                    Dim temp_FTY_mu As Decimal

                    temp_FTY_cost = Val(.Range("AA" + (i + 3).ToString).Value)

                    If IsNumeric(temp_FTY_cost) And IsNumeric(temp_ftyprc) Then
                        If Val(temp_FTY_cost) <> 0 Then

                            'If temp_flag_is_ass = 1 Then
                            '    .Range("AL" + (i + 3).ToString).Value = temp_qud_conftr * Val(temp_ftyprc) / Val(temp_FTY_cost)
                            '    temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                            '    .Range("AL" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'Else
                            .Range("AL" + (i + 3).ToString).Value = Val(temp_ftyprc) / Val(temp_FTY_cost)
                            temp_FTY_mu = .Range("AL" + (i + 3).ToString).Value
                            .Range("AL" + (i + 3).ToString).Value = round(temp_FTY_mu, 2)
                            'End If

                        End If
                    End If


                    .Range("AM" + (i + 3).ToString).Value = temp_ftyprc



                    If temp_FTY_cost <> 0 Then
                        '   temp_ftyprc = temp_FTY_cost * temp_FTY_mu
                    Else
                        temp_FTY_mu = 0

                        '.Range("AM" + (i + 3).ToString).Value = temp_ftyprc
                        .Range("AA" + (i + 3).ToString).Value = 0
                    End If


                    Dim temp_basprc As Decimal


                    If temp_flag_is_ass = 1 Then
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")) / temp_qud_conftr
                    Else
                        temp_basprc = IIf(IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")), 0, rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc"))
                    End If




                    'for cal
                    Dim temp_hk_mu As Decimal

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") <> "USD" Then
                            'assuem HKD ,same cur
                        Else
                            If temp_cur = "HKD" And rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_curcde") = "USD" Then
                                temp_ftyprc = temp_ftyprc / 7.75
                            End If

                        End If
                    End If

                    If temp_ftyprc <> 0 Then
                        temp_hk_mu = temp_basprc / temp_ftyprc
                    Else
                        temp_hk_mu = 1
                    End If


                    .Range("AN" + (i + 3).ToString).Value = round(temp_hk_mu, 2)


                    'If temp_flag_is_ass = 1 Then
                    '    temp_basprc = temp_basprc / temp_qud_conftr
                    'End If
                    'If temp_flag_is_ass = 1 Then
                    '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc") / temp_qud_conftr
                    'Else
                    '    .Range("AO" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_basprc")
                    'End If


                    .Range("AB" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_pckitr")
                    .Range("AC" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrdin")
                    .Range("AD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrwin")
                    .Range("AE" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_inrhin")
                    .Range("AF" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrdin")
                    .Range("AG" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrwin")
                    .Range("AH" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_mtrhin")

                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec") <> "" Then
                            .Range("AK" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_lightspec")
                        Else
                            gspStr = "sp_select_lightspec '" & rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qud_itmno") & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_lightspec, rtnStr)
                            gspStr = ""
                            Cursor = Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading cmdShow_Click " & "sp_select_lightspec" & " :" & rtnStr)
                                Exit Sub
                            End If

                            If (rs_lightspec.Tables("RESULT").Rows.Count > 0) Then
                                .Range("AK" + (i + 3).ToString).Value = rs_lightspec.Tables("RESULT").Rows(0)("lightspec")
                            Else
                                .Range("AK" + (i + 3).ToString).Value = ""
                            End If

                        End If
                    End If


                    ' .Range("AL" + (i + 3).ToString).Value = "1.18"
                    '.Range("AM" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_ftyprc")
                    ' .Range("AN" + (i + 3).ToString).Value = "1.15"

                    .Range("AP" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_prctrm")
                    '''TRAN TERM
                    .Range("AQ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_trantrm")

                    'New Template     
                    '                    .Range("AS" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")) Then
                        If rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg") <> "Y" Then
                            .Range("AS" + (i + 3).ToString).Value = "N"
                        Else
                            .Range("AS" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_fml_ventranflg")
                        End If
                    Else
                        .Range("AS" + (i + 3).ToString).Value = "N"
                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper")) Then
                    '    .Range("AT" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_subttlper") / 100
                    'Else
                    '    .Range("AT" + (i + 3).ToString).Value = "0"
                    'End If



                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")) Then
                        .Range("AU" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_pkgper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AU" + (i + 3).ToString).Value = .Range("AU" + (i + 3).ToString).Value / temp_qud_conftr
                        End If

                    Else
                        .Range("AU" + (i + 3).ToString).Value = "0"
                    End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper")) Then
                    '    .Range("AV" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_comper") / 100
                    'Else
                    '    .Range("AV" + (i + 3).ToString).Value = "0"
                    'End If


                    If Not IsDBNull(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")) Then
                        .Range("AW" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_icmper")

                        If temp_flag_is_ass = 1 Then
                            .Range("AW" + (i + 3).ToString).Value = .Range("AW" + (i + 3).ToString).Value / temp_qud_conftr
                        End If
                    Else
                        .Range("AW" + (i + 3).ToString).Value = 0

                    End If


                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper")) Then
                    '    .Range("AZ" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_cushcstbufper") / 100
                    'Else
                    '    .Range("AZ" + (i + 3).ToString).Value = "0"
                    'End If

                    'If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper")) Then
                    '    .Range("BA" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_othdisper") / 100
                    'Else
                    '    .Range("BA" + (i + 3).ToString).Value = "0"
                    'End If

                    If IsNumeric(rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu")) Then
                        .Range("BD" + (i + 3).ToString).Value = rs_QUR0000excel.Tables("RESULT").DefaultView(i)("qpe_mu") / 100
                    Else
                        .Range("BD" + (i + 3).ToString).Value = "0"
                    End If

                    '.Range(.Cells(hdrRow + 1 + i, 1), .Cells(hdrRow + 1 + i, rs_QUR0000excel.Tables("RESULT").Columns.Count)).Value = entry
                Next



                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Clear Sheet(2)
                'Start
                '
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'MarkUp Page
                .Sheets(2).Activate()

                .Range("D17").Value = "-"
                .Range("E17").Value = "-"
                .Range("F17").Value = "-"
                .Range("G17").Value = "-"

                '2
                .Range("I17").Value = "-"
                .Range("J17").Value = "-"
                .Range("K17").Value = "-"
                .Range("L17").Value = "-"

                'CAT, Same Value

                .Range("D4").Value = 0
                .Range("D5").Value = 0

                .Range("D6").Value = 0

                .Range("D8").Value = 0
                .Range("D9").Value = 0
                .Range("D10").Value = 0
                .Range("D11").Value = 0

                .Range("D13").Value = 0
                .Range("D14").Value = 0
                .Range("D15").Value = 0

                .Range("D20").Value = 0
                .Range("D22").Value = 0

                '2

                .Range("I4").Value = 0
                .Range("I5").Value = 0

                .Range("I6").Value = 0

                .Range("I8").Value = 0
                .Range("I9").Value = 0
                .Range("I10").Value = 0
                .Range("I11").Value = 0

                .Range("I13").Value = 0
                .Range("I14").Value = 0
                .Range("I15").Value = 0

                .Range("I20").Value = 0
                .Range("I22").Value = 0
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '
                'End -Clear Sheet(2)
                '
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                'Mark Up Table Sheet
                gspStr = "sp_select_QUPRCEMT_MU '" & .Range("D3").Value.ToString.Trim & "','EXT'"
                Message = "sp_select_QUPRCEMT_MU"
                rtnLong = execute_SQLStatement(gspStr, rs_QUPRCEMT_MU, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdShow_Click " & Message & " :" & rtnStr)
                    Exit Sub
                End If

                If rs_QUPRCEMT_MU.Tables("result").Rows.Count > 0 Then

                    'MarkUp Page
                    .Sheets(2).Activate()

                    For i As Integer = 0 To rs_QUPRCEMT_MU.Tables("result").Rows.Count - 1


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("D17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                     .Range("D19").Value = .Range("D17").Value + .Range("D18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("E17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                      .Range("E19").Value = .Range("D17").Value + .Range("E18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("F17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                       .Range("F19").Value = .Range("D17").Value + .Range("F18").Value
                        End If


                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("G17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                        .Range("G19").Value = .Range("D17").Value + .Range("G18").Value
                        End If

                        '2FLORAL FTY			

                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("I17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("J17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("K17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("L17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If

                        '''3MAGICSILK			
                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("N17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                         .Range("I19").Value = .Range("I17").Value + .Range("I18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "FCL") Then
                            .Range("O17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                          .Range("J19").Value = .Range("I17").Value + .Range("J18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FOB" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("P17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                           .Range("K19").Value = .Range("I17").Value + .Range("K18").Value
                        End If


                        If ((rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") And _
                            Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_prctrm"), 3) = "FCA" _
                            And Microsoft.VisualBasic.Left(rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm"), 3) = "LCL") Then
                            .Range("Q17").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_thccusper")
                            '                            .Range("L19").Value = .Range("I17").Value + .Range("L18").Value
                        End If


                        '''''''''''''''''''''''''''''''''''
                        'CAT, Same Value

                        If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "STANDARD" Then

                            .Range("D4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")

                            ''2 margin value
                            If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm") = "FCL" Then
                                .Range("D5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")
                            End If
                            If rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_trantrm") = "LCL" Then
                                .Range("F5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")
                            End If

                            .Range("D6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("D8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("D9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("D10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("D11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("D13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("D14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("D15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("D20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("D22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If

                        '2
                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORAL FTY" Or rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "FLORALFTY") Then

                            .Range("I4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("I5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("I6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("I8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("I9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("I10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("I11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("I13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("I14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("I15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("I20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("I22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If


                        '3

                        If (rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cat") = "MAGICSILK") Then

                            .Range("N4").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cumu")
                            .Range("N5").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pm")

                            .Range("N6").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cstbufper")

                            .Range("N8").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_upsper")
                            .Range("N9").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_labper")
                            .Range("N10").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_faper")
                            .Range("N11").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_othper")

                            .Range("N13").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_pliper")
                            .Range("N14").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_dmdper")
                            .Range("N15").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_rbtper")

                            .Range("N20").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_comper")
                            .Range("N22").Value = rs_QUPRCEMT_MU.Tables("RESULT").Rows(i).Item("ccf_cush")
                        End If


                    Next

                Else
                    'no markup price
                End If



            End With


            With xlsApp_com

            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS_com = Nothing
                    xlsWB_com = Nothing
                    xlsApp_com = Nothing
                    exportExcel_QURExportToExcel_ext(tmp_cocde, tmp_cus1no, tmp_qutno)
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERPSystem_QUR00003 - Excel Error")
            End If
        End Try




        'Show the excel after creating process is completed
        Try

            filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")
            xlsWB_com.SaveAs(Filename:=filSourcePath + "\" + tmp_cocde + "_" + tmp_cus1no + "_ext", FileFormat:=52)

        Catch ex As Exception
            MsgBox("Files at folder " + filSourcePath + " already exist. Please delete it before export a new one.")
        End Try

        ' xlsWB_com.SaveAs(Filename:="C:\" + tmp_qutno, ReadOnlyRecommended:=False)

        xlsApp_com.Visible = True

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Release reference





        Cursor = Cursors.Default
    End Sub


    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function

    Private Sub cboCoCde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        Call cboCoCdeClick()
    End Sub

    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'Call getDefault_Path()

    End Sub

    Private Sub cboCoCde_DropDownStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.DropDownStyleChanged

    End Sub
    Private Sub cboCoCde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        Call auto_search_combo(cboCoCde, e.KeyCode)
        Dim orgPos As Integer
        orgPos = cboCoCde.SelectedIndex
        If orgPos = -1 Then
            orgPos = 0
        End If
        cboCoCde.SelectedIndex = orgPos
        txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)
    End Sub

    Private Sub cboCoCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.LostFocus
        Call cboCoCdeClick()
    End Sub


    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)

        gspStr = "sp_select_CUBASINF_P '" & cboCoCde.Text & "','Primary'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUXLS001  sp_select_CUBASINF_P : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_CUBASINF_PRI '" & cboCoCde.Text & "','" & gsUsrID & "','" & "QU" & "'"
        'Fixing global company code problem at 20100420
        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading QUM00001  sp_select_CUBASINF_PRI : " & rtnStr)
            Exit Sub
        Else
            rs_CUBASINF_P = rs.Copy() '*** Cus for company
        End If
        Call fillcboPriCust() '

    End Sub

    Private Sub fillcboPriCust()

        Dim dr() As DataRow
        '        If addFlag = True Then
        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then
            cboCus1No.Items.Clear()

            cboCus1No.Items.Add("All")
            For i As Integer = 0 To dr.Length - 1
                cboCus1No.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

    End Sub


    Private Sub fillcbodiv()



        cboSalDiv.Items.Clear()



        cboSalDiv.Items.Add("All")
        cboSalDiv.Items.Add("1 - Sale Division 1")
        cboSalDiv.Items.Add("2 - Sale Division 2")
        cboSalDiv.Items.Add("3 - Sale Division 3")
        cboSalDiv.Items.Add("4 - Sale Division 4")

    End Sub



    Public Sub FillCompCombo_local(ByVal userid As String, ByVal cbobox As ComboBox)
        Dim rs_SYMUSRCO As New DataSet
        Dim gspStr As String
        Dim frm As Form
        frm = CType(cbobox.FindForm, Form)

        If cbobox.Items.Count > 0 Then
            Exit Sub
        End If

        If gsConnStr = "" Then
            gsConnStr = getConnStr(gsConnStr, rtnStr, "CON-DB")
        End If

        gspStr = "sp_select_SYUSRGRP_COMP '','" & gsUsrID & "','" & frm.Name.ToString & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYUSRGRP_COMP : " & rtnStr)
        Else
            cbobox.Items.Add("All")

            For Each dr As DataRow In rs_SYMUSRCO.Tables("RESULT").Rows
                If gsCompanyGroup = "UCG" Then
                    If dr.Item("yuc_cocde").ToString <> "MS" Then
                        cbobox.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                ElseIf gsCompanyGroup = "MSG" Then
                    If dr.Item("yuc_cocde").ToString = "MS" Then
                        cbobox.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                End If
            Next
        End If
        rs_SYMUSRCO = Nothing

    End Sub



    Private Sub optStatusB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusB.CheckedChanged

    End Sub

    Private Sub optStatusB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStatusB.Click
        optStatusB.Checked = True
        optStatusI.Checked = False
        optStatusE.Checked = False
    End Sub

    Private Sub optStatusI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusI.CheckedChanged

    End Sub

    Private Sub optStatusI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStatusI.Click
        optStatusB.Checked = False
        optStatusI.Checked = True
        optStatusE.Checked = False

    End Sub

    Private Sub optStatusE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusE.CheckedChanged

    End Sub

    Private Sub optStatusE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStatusE.Click
        optStatusB.Checked = False
        optStatusI.Checked = False
        optStatusE.Checked = True
    End Sub
End Class