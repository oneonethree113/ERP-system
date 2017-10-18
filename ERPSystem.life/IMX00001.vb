Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMX00001

    Private Const loc1_venno As Integer = 1
    Private Const loc1_cus1no As Integer = 2
    Private Const loc1_cus2no As Integer = 3
    Private Const loc1_ftytmp As Integer = 4
    Private Const loc1_venitm As Integer = 5
    Private Const loc1_engdsc As Integer = 6
    Private Const loc1_chndsc As Integer = 7
    Private Const loc1_lnecde As Integer = 8
    Private Const loc1_catlvl4 As Integer = 9
    Private Const loc1_untcde As Integer = 10
    Private Const loc1_inrqty As Integer = 11
    Private Const loc1_mtrqty As Integer = 12
    Private Const loc1_cft As Integer = 13
    Private Const loc1_conftr As Integer = 14
    Private Const loc1_sapum As Integer = 15
    Private Const loc1_curcde As Integer = 16
    Private Const loc1_ftycstA As Integer = 17
    Private Const loc1_ftycstB As Integer = 18
    Private Const loc1_ftycstC As Integer = 19
    Private Const loc1_ftycstD As Integer = 20

    Private Const loc1_ftycstE As Integer = 21

    Private Const loc1_ftycstTran As Integer = 22
    Private Const loc1_ftycstPack As Integer = 23
    Private Const loc1_ftycst As Integer = 24
    Private Const loc1_ftyprcA As Integer = 25
    Private Const loc1_ftyprcB As Integer = 26
    Private Const loc1_ftyprcC As Integer = 27
    Private Const loc1_ftyprcD As Integer = 28

    Private Const loc1_ftyprcE As Integer = 29

    Private Const loc1_ftyprcTran As Integer = 30
    Private Const loc1_ftyprcPack As Integer = 31
    Private Const loc1_ftyprc As Integer = 32
    Private Const loc1_ftyprctrm As Integer = 33
    Private Const loc1_hkprctrm As Integer = 33
    Private Const loc1_trantrm As Integer = 34
    Private Const loc1_inrdin As Integer = 35
    Private Const loc1_inrwin As Integer = 36
    Private Const loc1_inrhin As Integer = 37
    Private Const loc1_mtrdin As Integer = 38
    Private Const loc1_mtrwin As Integer = 39
    Private Const loc1_mtrhin As Integer = 40
    Private Const loc1_grswgt As Integer = 41
    Private Const loc1_netwgt As Integer = 42
    Private Const loc1_pckitr As Integer = 43
    Private Const loc1_bomitm As Integer = 44
    Private Const loc1_orgdvenno As Integer = 45
    Private Const loc1_moq As Integer = 46
    Private Const loc1_inrsze As Integer = 47
    Private Const loc1_mtrsze As Integer = 48
    Private Const loc1_mat As Integer = 49
    Private Const loc1_BOMcurcde As Integer = 50
    Private Const loc1_BOMwastage As Integer = 51
    Private Const loc1_rmk As Integer = 52
    Private Const loc1_cusven As Integer = 53
    Private Const loc1_alsitmno As Integer = 54
    Private Const loc1_alscolcde As Integer = 55
    Private Const loc1_AlsTmpItmno As Integer = 56
    Private Const loc1_numass As Integer = 57
    Private Const loc1_itmnat As Integer = 58
    Private Const loc1_negprc As Integer = 59
    Private Const loc1_period As Integer = 60
    Private Const loc1_expdat As Integer = 61

    Private Const loc2_venitm As Integer = 1
    Private Const loc2_colcde As Integer = 2
    Private Const loc2_coldsc As Integer = 3

    Private Const loc3_venitm As Integer = 1
    Private Const loc3_cosmth As Integer = 2
    Private Const loc3_compon As Integer = 3
    Private Const loc3_asstive As Integer = 4
    Private Const loc3_rmk As Integer = 5

    Private Const loc4_venitm As Integer = 1
    Private Const loc4_assitm As Integer = 2
    Private Const loc4_assdsc As Integer = 3
    Private Const loc4_colcde As Integer = 4
    Private Const loc4_untcde As Integer = 5
    Private Const loc4_conftr As Integer = 6
    Private Const loc4_qty As Integer = 7
    Private Const loc4_period As Integer = 8

    Private Const loc5_venitm As Integer = 1
    Private Const loc5_assitm As Integer = 2
    Private Const loc5_colcde As Integer = 3
    Private Const loc5_untcde As Integer = 4
    Private Const loc5_conftr As Integer = 5
    Private Const loc5_inrqty As Integer = 6
    Private Const loc5_mtrqty As Integer = 7
    Private Const loc5_period As Integer = 8

    Private Const xlsItem As Integer = 1
    Private Const xlsColor As Integer = 2
    Private Const xlsMaterial As Integer = 3
    Private Const xlsBOM As Integer = 4
    Private Const xlsAssorted As Integer = 5

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
        Dim rs_XLS As DataSet

        Dim excel As Excel.Application

        Dim curRow As Integer
        Dim numError As Integer = 0

        Dim cur_Process() As Process
        Dim new_Process() As Process

        Dim iid_itmseq As String
        Dim iid_prdven As String
        'Dim iid_stage As String
        'Dim iid_sysmsg As String
        'Dim iid_refresh As String
        'Dim imd_itmseq As String

        Dim xls1_venno As String
        Dim xls1_cus1no As String
        Dim xls1_cus2no As String
        Dim xls1_ftytmp As String
        Dim xls1_venitm As String
        Dim xls1_engdsc As String
        Dim xls1_chndsc As String
        Dim xls1_lnecde As String
        Dim xls1_catlvl4 As String
        Dim xls1_untcde As String
        Dim xls1_inrqty As String
        Dim xls1_mtrqty As String
        Dim xls1_cft As String
        Dim xls1_conftr As String
        Dim xls1_sapum As String
        Dim xls1_curcde As String
        Dim xls1_ftycstA As String
        Dim xls1_ftycstB As String
        Dim xls1_ftycstC As String
        Dim xls1_ftycstD As String

        Dim xls1_ftycstE As String

        Dim xls1_ftycstTran As String
        Dim xls1_ftycstPack As String
        Dim xls1_ftycst As String
        Dim xls1_ftyprcA As String
        Dim xls1_ftyprcB As String
        Dim xls1_ftyprcC As String
        Dim xls1_ftyprcD As String

        Dim xls1_ftyprcE As String

        Dim xls1_ftyprcTran As String
        Dim xls1_ftyprcPack As String
        Dim xls1_ftyprc As String
        Dim xls1_ftyprctrm As String
        Dim xls1_hkprctrm As String
        Dim xls1_trantrm As String
        Dim xls1_inrdin As String
        Dim xls1_inrwin As String
        Dim xls1_inrhin As String
        Dim xls1_mtrdin As String
        Dim xls1_mtrwin As String
        Dim xls1_mtrhin As String
        Dim xls1_grswgt As String
        Dim xls1_netwgt As String
        Dim xls1_pckitr As String
        Dim xls1_bomitm As String
        Dim xls1_orgdvenno As String
        Dim xls1_moq As String
        Dim xls1_inrsze As String
        Dim xls1_mtrsze As String
        Dim xls1_mat As String
        Dim xls1_BOMcurcde As String
        Dim xls1_BOMwastage As String
        Dim xls1_rmk As String
        Dim xls1_cusven As String
        Dim xls1_alsitmno As String
        Dim xls1_alscolcde As String
        Dim xls1_alstmpitmno As String
        Dim xls1_numass As String
        Dim xls1_itmnat As String
        Dim xls1_negprc As String
        Dim xls1_period As String
        Dim xls1_expdat As String

        Dim xls2_venitm As String
        Dim xls2_colcde As String
        Dim xls2_coldsc As String

        Dim xls3_venitm As String
        Dim xls3_cosmth As String
        Dim xls3_compon As String
        Dim xls3_asstive As String
        Dim xls3_rmk As String

        Dim xls4_venitm As String
        Dim xls4_assitm As String
        Dim xls4_assdsc As String
        Dim xls4_colcde As String
        Dim xls4_untcde As String
        Dim xls4_conftr As String
        Dim xls4_qty As String
        Dim xls4_period As String

        Dim xls5_venitm As String
        Dim xls5_assitm As String
        Dim xls5_colcde As String
        Dim xls5_untcde As String
        Dim xls5_conftr As String
        Dim xls5_inrqty As String
        Dim xls5_mtrqty As String
        Dim xls5_period As String

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

                gspStr = "sp_select_IMITMDAT_ItmSeq"
                rs_XLS = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading " & Me.Name & " #001 sp_select_IMITMDAT_ItmSeq : " & rtnStr)
                    killProcess(cur_Process, new_Process)
                    Exit Sub
                Else
                    iid_itmseq = rs_XLS.Tables("RESULT").Rows(0)("iid_itmseq").ToString
                End If

                'gspStr = "sp_select_IMCOMDAT_ItmSeq"
                'rs_XLS = Nothing
                'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                'rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                'Me.Cursor = Windows.Forms.Cursors.Default
                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on loading " & Me.Name & " #002 sp_select_IMCOMDAT_ItmSeq : " & rtnStr)
                '    Exit Sub
                'Else
                '    imd_itmseq = rs_XLS.Tables("RESULT").Rows(0)("imd_itmseq").ToString
                'End If

                For j As Integer = 1 To excel.Sheets.Count
                    excel.Sheets(j).Select()
                    Select Case j
                        Case xlsItem
                            curRow = 4

                            If Format(Date.Now, "yyyy/MM/dd") > "2003/10/01" Then
                                If Trim(excel.Cells(1, 2).Value.ToString) <> "UCPP" Or Trim(excel.Cells(1, 6).Value.ToString) <> xlsVer Then
                                    setErrMsg("Error - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(i))
                                    setErrMsg("Incorrect Excel file version, upload aborted")
                                    Throw New Exception("Incorrect Excel file version")
                                End If
                            End If

                            If (Not (excel.Cells(1, 4).Value Is Nothing)) Then
                                iid_prdven = Replace(Trim(excel.Cells(1, 4).Value.ToString), "'", "''")
                                If iid_prdven Is Nothing Then
                                    iid_prdven = ""
                                End If
                            Else
                                iid_prdven = ""
                            End If

                            Do While (Not excel.Cells(curRow, loc1_venno).Value Is Nothing)
                                'iid_stage = "W"
                                'iid_sysmsg = ""
                                'iid_refresh = "N"

                                If (Not (excel.Cells(curRow, loc1_venno).Value Is Nothing)) Then
                                    xls1_venno = Replace(Trim(excel.Cells(curRow, loc1_venno).Value.ToString), "'", "''")
                                    If xls1_venno Is Nothing Then
                                        xls1_venno = ""
                                    End If
                                Else
                                    xls1_venno = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_cus1no).Value Is Nothing)) Then
                                    xls1_cus1no = Replace(Trim(excel.Cells(curRow, loc1_cus1no).Value.ToString), "'", "''")
                                    If xls1_cus1no Is Nothing Then
                                        xls1_cus1no = ""
                                    End If
                                Else
                                    xls1_cus1no = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_cus2no).Value Is Nothing)) Then
                                    xls1_cus2no = Replace(Trim(excel.Cells(curRow, loc1_cus2no).Value.ToString), "'", "''")
                                    If xls1_cus2no Is Nothing Then
                                        xls1_cus2no = ""
                                    End If
                                Else
                                    xls1_cus2no = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftytmp).Value Is Nothing)) Then
                                    xls1_ftytmp = Replace(Trim(excel.Cells(curRow, loc1_ftytmp).Value.ToString), "'", "''")
                                    If xls1_ftytmp <> "N" And xls1_ftytmp <> "Y" Then
                                        xls1_ftytmp = "N"
                                    End If
                                Else
                                    xls1_ftytmp = "N"
                                End If

                                If (Not (excel.Cells(curRow, loc1_venitm).Value Is Nothing)) Then
                                    xls1_venitm = Replace(Trim(excel.Cells(curRow, loc1_venitm).Value.ToString), "'", "''")
                                    If xls1_venitm = Nothing Then
                                        xls1_venitm = ""
                                    End If
                                Else
                                    xls1_venitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_engdsc).Value Is Nothing)) Then
                                    xls1_engdsc = Replace(Trim(excel.Cells(curRow, loc1_engdsc).Value.ToString), "'", "''")
                                    If xls1_engdsc = Nothing Then
                                        xls1_engdsc = ""
                                    End If
                                Else
                                    xls1_engdsc = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_chndsc).Value Is Nothing)) Then
                                    xls1_chndsc = Replace(Trim(excel.Cells(curRow, loc1_chndsc).Value.ToString), "'", "''")
                                    If xls1_chndsc = Nothing Then
                                        xls1_chndsc = ""
                                    End If
                                Else
                                    xls1_chndsc = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_lnecde).Value Is Nothing)) Then
                                    xls1_lnecde = Replace(Trim(excel.Cells(curRow, loc1_lnecde).Value.ToString), "'", "''")
                                    If xls1_lnecde = Nothing Then
                                        xls1_lnecde = ""
                                    End If
                                Else
                                    xls1_lnecde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_catlvl4).Value Is Nothing)) Then
                                    xls1_catlvl4 = Replace(Trim(excel.Cells(curRow, loc1_catlvl4).Value.ToString), "'", "''")
                                    If xls1_catlvl4 = Nothing Then
                                        xls1_catlvl4 = ""
                                    End If
                                Else
                                    xls1_catlvl4 = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_untcde).Value Is Nothing)) Then
                                    xls1_untcde = Replace(Trim(excel.Cells(curRow, loc1_untcde).Value.ToString), "'", "''")
                                    If xls1_untcde = Nothing Then
                                        xls1_untcde = ""
                                    End If
                                Else
                                    xls1_untcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_inrqty).Value Is Nothing)) Then
                                    xls1_inrqty = Replace(Trim(excel.Cells(curRow, loc1_inrqty).Value.ToString), "'", "''")
                                    If xls1_inrqty = "" Or Integer.TryParse(xls1_inrqty, xls1_inrqty) = False Then
                                        xls1_inrqty = "0"
                                    End If
                                Else
                                    xls1_inrqty = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_mtrqty).Value Is Nothing)) Then
                                    xls1_mtrqty = Replace(Trim(excel.Cells(curRow, loc1_mtrqty).Value.ToString), "'", "''")
                                    If xls1_mtrqty = "" Or Integer.TryParse(xls1_mtrqty, xls1_mtrqty) = False Then
                                        xls1_mtrqty = "0"
                                    End If
                                Else
                                    xls1_mtrqty = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_cft).Value Is Nothing)) Then
                                    xls1_cft = Replace(Trim(excel.Cells(curRow, loc1_cft).Value.ToString), "'", "''")
                                    If xls1_cft = "" Or IsNumeric(xls1_cft) = False Then
                                        xls1_cft = "0"
                                    End If
                                Else
                                    xls1_cft = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_conftr).Value Is Nothing)) Then
                                    xls1_conftr = Replace(Trim(excel.Cells(curRow, loc1_conftr).Value.ToString), "'", "''")
                                    If xls1_conftr = "" Or Integer.TryParse(xls1_conftr, xls1_conftr) = False Then
                                        xls1_conftr = "0"
                                    End If
                                Else
                                    xls1_conftr = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_sapum).Value Is Nothing)) Then
                                    xls1_sapum = Replace(Trim(excel.Cells(curRow, loc1_sapum).Value.ToString), "'", "''")
                                    If xls1_sapum = Nothing Then
                                        xls1_sapum = ""
                                    End If
                                Else
                                    xls1_sapum = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_curcde).Value Is Nothing)) Then
                                    xls1_curcde = Replace(Trim(excel.Cells(curRow, loc1_curcde).Value.ToString), "'", "''")
                                    If xls1_curcde = Nothing Then
                                        xls1_curcde = ""
                                    End If
                                Else
                                    xls1_curcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstA).Value Is Nothing)) Then
                                    xls1_ftycstA = Replace(Trim(excel.Cells(curRow, loc1_ftycstA).Value.ToString), "'", "''")
                                    If xls1_ftycstA = "" Or IsNumeric(xls1_ftycstA) = False Then
                                        xls1_ftycstA = "0"
                                    End If
                                Else
                                    xls1_ftycstA = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstB).Value Is Nothing)) Then
                                    xls1_ftycstB = Replace(Trim(excel.Cells(curRow, loc1_ftycstB).Value.ToString), "'", "''")
                                    If xls1_ftycstB = "" Or IsNumeric(xls1_ftycstB) = False Then
                                        xls1_ftycstB = "0"
                                    End If
                                Else
                                    xls1_ftycstB = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstC).Value Is Nothing)) Then
                                    xls1_ftycstC = Replace(Trim(excel.Cells(curRow, loc1_ftycstC).Value.ToString), "'", "''")
                                    If xls1_ftycstC = "" Or IsNumeric(xls1_ftycstC) = False Then
                                        xls1_ftycstC = "0"
                                    End If
                                Else
                                    xls1_ftycstC = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstD).Value Is Nothing)) Then
                                    xls1_ftycstD = Replace(Trim(excel.Cells(curRow, loc1_ftycstD).Value.ToString), "'", "''")
                                    If xls1_ftycstD = "" Or IsNumeric(xls1_ftycstD) = False Then
                                        xls1_ftycstD = "0"
                                    End If
                                Else
                                    xls1_ftycstD = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstE).Value Is Nothing)) Then
                                    xls1_ftycstE = Replace(Trim(excel.Cells(curRow, loc1_ftycstE).Value.ToString), "'", "''")
                                    If xls1_ftycstE = "" Or IsNumeric(xls1_ftycstE) = False Then
                                        xls1_ftycstE = "0"
                                    End If
                                Else
                                    xls1_ftycstE = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstTran).Value Is Nothing)) Then
                                    xls1_ftycstTran = Replace(Trim(excel.Cells(curRow, loc1_ftycstTran).Value.ToString), "'", "''")
                                    If xls1_ftycstTran = "" Or IsNumeric(xls1_ftycstTran) = False Then
                                        xls1_ftycstTran = "0"
                                    End If
                                Else
                                    xls1_ftycstTran = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycstPack).Value Is Nothing)) Then
                                    xls1_ftycstPack = Replace(Trim(excel.Cells(curRow, loc1_ftycstPack).Value.ToString), "'", "''")
                                    If xls1_ftycstPack = "" Or IsNumeric(xls1_ftycstPack) = False Then
                                        xls1_ftycstPack = "0"
                                    End If
                                Else
                                    xls1_ftycstPack = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftycst).Value Is Nothing)) Then
                                    xls1_ftycst = Replace(Trim(excel.Cells(curRow, loc1_ftycst).Value.ToString), "'", "''")
                                    If xls1_ftycst = "" Or IsNumeric(xls1_ftycst) = False Then
                                        xls1_ftycst = "0"
                                    End If
                                Else
                                    xls1_ftycst = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcA).Value Is Nothing)) Then
                                    xls1_ftyprcA = Replace(Trim(excel.Cells(curRow, loc1_ftyprcA).Value.ToString), "'", "''")
                                    If xls1_ftyprcA = "" Or IsNumeric(xls1_ftyprcA) = False Then
                                        xls1_ftyprcA = "0"
                                    End If
                                Else
                                    xls1_ftyprcA = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcB).Value Is Nothing)) Then
                                    xls1_ftyprcB = Replace(Trim(excel.Cells(curRow, loc1_ftyprcB).Value.ToString), "'", "''")
                                    If xls1_ftyprcB = "" Or IsNumeric(xls1_ftyprcB) = False Then
                                        xls1_ftyprcB = "0"
                                    End If
                                Else
                                    xls1_ftyprcB = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcC).Value Is Nothing)) Then
                                    xls1_ftyprcC = Replace(Trim(excel.Cells(curRow, loc1_ftyprcC).Value.ToString), "'", "''")
                                    If xls1_ftyprcC = "" Or IsNumeric(xls1_ftyprcC) = False Then
                                        xls1_ftyprcC = "0"
                                    End If
                                Else
                                    xls1_ftyprcC = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcD).Value Is Nothing)) Then
                                    xls1_ftyprcD = Replace(Trim(excel.Cells(curRow, loc1_ftyprcD).Value.ToString), "'", "''")
                                    If xls1_ftyprcD = "" Or IsNumeric(xls1_ftyprcD) = False Then
                                        xls1_ftyprcD = "0"
                                    End If
                                Else
                                    xls1_ftyprcD = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcE).Value Is Nothing)) Then
                                    xls1_ftyprcE = Replace(Trim(excel.Cells(curRow, loc1_ftyprcE).Value.ToString), "'", "''")
                                    If xls1_ftyprcE = "" Or IsNumeric(xls1_ftyprcE) = False Then
                                        xls1_ftyprcE = "0"
                                    End If
                                Else
                                    xls1_ftyprcE = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcTran).Value Is Nothing)) Then
                                    xls1_ftyprcTran = Replace(Trim(excel.Cells(curRow, loc1_ftyprcTran).Value.ToString), "'", "''")
                                    If xls1_ftyprcTran = "" Or IsNumeric(xls1_ftyprcTran) = False Then
                                        xls1_ftyprcTran = "0"
                                    End If
                                Else
                                    xls1_ftyprcTran = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprcPack).Value Is Nothing)) Then
                                    xls1_ftyprcPack = Replace(Trim(excel.Cells(curRow, loc1_ftyprcPack).Value.ToString), "'", "''")
                                    If xls1_ftyprcPack = "" Or IsNumeric(xls1_ftyprcPack) = False Then
                                        xls1_ftyprcPack = "0"
                                    End If
                                Else
                                    xls1_ftyprcPack = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprc).Value Is Nothing)) Then
                                    xls1_ftyprc = Replace(Trim(excel.Cells(curRow, loc1_ftyprc).Value.ToString), "'", "''")
                                    If xls1_ftyprc = "" Or IsNumeric(xls1_ftyprc) = False Then
                                        xls1_ftyprc = "0"
                                    End If
                                Else
                                    xls1_ftyprc = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_ftyprctrm).Value Is Nothing)) Then
                                    xls1_ftyprctrm = Replace(Trim(excel.Cells(curRow, loc1_ftyprctrm).Value.ToString), "'", "''")
                                    If xls1_ftyprctrm Is Nothing Then
                                        xls1_ftyprctrm = ""
                                    End If
                                Else
                                    xls1_ftyprctrm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_hkprctrm).Value Is Nothing)) Then
                                    xls1_hkprctrm = Replace(Trim(excel.Cells(curRow, loc1_hkprctrm).Value.ToString), "'", "''")
                                    If xls1_hkprctrm Is Nothing Then
                                        xls1_hkprctrm = ""
                                    End If
                                Else
                                    xls1_hkprctrm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_trantrm).Value Is Nothing)) Then
                                    xls1_trantrm = Replace(Trim(excel.Cells(curRow, loc1_trantrm).Value.ToString), "'", "''")
                                    If xls1_trantrm Is Nothing Then
                                        xls1_trantrm = ""
                                    End If
                                Else
                                    xls1_trantrm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_inrdin).Value Is Nothing)) Then
                                    xls1_inrdin = Replace(Trim(excel.Cells(curRow, loc1_inrdin).Value.ToString), "'", "''")
                                    If xls1_inrdin = "" Or IsNumeric(xls1_inrdin) = False Then
                                        xls1_inrdin = "0"
                                    End If
                                Else
                                    xls1_inrdin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_inrwin).Value Is Nothing)) Then
                                    xls1_inrwin = Replace(Trim(excel.Cells(curRow, loc1_inrwin).Value.ToString), "'", "''")
                                    If xls1_inrwin = "" Or IsNumeric(xls1_inrwin) = False Then
                                        xls1_inrwin = "0"
                                    End If
                                Else
                                    xls1_inrwin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_inrhin).Value Is Nothing)) Then
                                    xls1_inrhin = Replace(Trim(excel.Cells(curRow, loc1_inrhin).Value.ToString), "'", "''")
                                    If xls1_inrhin = "" Or IsNumeric(xls1_inrhin) = False Then
                                        xls1_inrhin = "0"
                                    End If
                                Else
                                    xls1_inrhin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_mtrdin).Value Is Nothing)) Then
                                    xls1_mtrdin = Replace(Trim(excel.Cells(curRow, loc1_mtrdin).Value.ToString), "'", "''")
                                    If xls1_mtrdin = "" Or IsNumeric(xls1_mtrdin) = False Then
                                        xls1_mtrdin = "0"
                                    End If
                                Else
                                    xls1_mtrdin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_mtrwin).Value Is Nothing)) Then
                                    xls1_mtrwin = Replace(Trim(excel.Cells(curRow, loc1_mtrwin).Value.ToString), "'", "''")
                                    If xls1_mtrwin = "" Or IsNumeric(xls1_mtrwin) = False Then
                                        xls1_mtrwin = "0"
                                    End If
                                Else
                                    xls1_mtrwin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_mtrhin).Value Is Nothing)) Then
                                    xls1_mtrhin = Replace(Trim(excel.Cells(curRow, loc1_mtrhin).Value.ToString), "'", "''")
                                    If xls1_mtrhin = "" Or IsNumeric(xls1_mtrhin) = False Then
                                        xls1_mtrhin = "0"
                                    End If
                                Else
                                    xls1_mtrhin = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_grswgt).Value Is Nothing)) Then
                                    xls1_grswgt = Replace(Trim(excel.Cells(curRow, loc1_grswgt).Value.ToString), "'", "''")
                                    If xls1_grswgt = "" Or IsNumeric(xls1_grswgt) = False Then
                                        xls1_grswgt = "0"
                                    End If
                                Else
                                    xls1_grswgt = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_netwgt).Value Is Nothing)) Then
                                    xls1_netwgt = Replace(Trim(excel.Cells(curRow, loc1_netwgt).Value.ToString), "'", "''")
                                    If xls1_netwgt = "" Or IsNumeric(xls1_netwgt) = False Then
                                        xls1_netwgt = "0"
                                    End If
                                Else
                                    xls1_netwgt = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_pckitr).Value Is Nothing)) Then
                                    xls1_pckitr = Replace(Trim(excel.Cells(curRow, loc1_pckitr).Value.ToString), "'", "''")
                                    If xls1_pckitr Is Nothing Then
                                        xls1_pckitr = ""
                                    End If
                                Else
                                    xls1_pckitr = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_bomitm).Value Is Nothing)) Then
                                    xls1_bomitm = Replace(Trim(excel.Cells(curRow, loc1_bomitm).Value.ToString), "'", "''")
                                    If xls1_bomitm <> "N" And xls1_bomitm <> "Y" Then
                                        xls1_bomitm = "N"
                                    End If
                                Else
                                    xls1_bomitm = "N"
                                End If

                                If (Not (excel.Cells(curRow, loc1_orgdvenno).Value Is Nothing)) Then
                                    xls1_orgdvenno = Replace(Trim(excel.Cells(curRow, loc1_orgdvenno).Value.ToString), "'", "''")
                                    If xls1_orgdvenno = "" Then
                                        xls1_orgdvenno = xls1_venno
                                    End If
                                Else
                                    xls1_orgdvenno = xls1_venno
                                End If

                                If (Not (excel.Cells(curRow, loc1_moq).Value Is Nothing)) Then
                                    xls1_moq = Replace(Trim(excel.Cells(curRow, loc1_moq).Value.ToString), "'", "''")
                                    If xls1_moq = "" Or Integer.TryParse(xls1_moq, xls1_moq) = False Then
                                        xls1_moq = "0"
                                    End If
                                Else
                                    xls1_moq = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_inrsze).Value Is Nothing)) Then
                                    xls1_inrsze = Replace(Trim(excel.Cells(curRow, loc1_inrsze).Value.ToString), "'", "''")
                                    If xls1_inrsze Is Nothing Then
                                        xls1_inrsze = ""
                                    End If
                                Else
                                    xls1_inrsze = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_mtrsze).Value Is Nothing)) Then
                                    xls1_mtrsze = Replace(Trim(excel.Cells(curRow, loc1_mtrsze).Value.ToString), "'", "''")
                                    If xls1_mtrsze Is Nothing Then
                                        xls1_mtrsze = ""
                                    End If
                                Else
                                    xls1_mtrsze = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_mat).Value Is Nothing)) Then
                                    xls1_mat = Replace(Trim(excel.Cells(curRow, loc1_mat).Value.ToString), "'", "''")
                                    If xls1_mat Is Nothing Then
                                        xls1_mat = ""
                                    End If
                                Else
                                    xls1_mat = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_BOMcurcde).Value Is Nothing)) Then
                                    xls1_BOMcurcde = Replace(Trim(excel.Cells(curRow, loc1_BOMcurcde).Value.ToString), "'", "''")
                                    If xls1_BOMcurcde Is Nothing Then
                                        xls1_BOMcurcde = ""
                                    End If
                                Else
                                    xls1_BOMcurcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_BOMwastage).Value Is Nothing)) Then
                                    xls1_BOMwastage = Replace(Trim(excel.Cells(curRow, loc1_BOMwastage).Value.ToString), "'", "''")
                                    If xls1_BOMwastage = "" Or IsNumeric(xls1_BOMwastage) = False Then
                                        xls1_BOMwastage = "0"
                                    End If
                                Else
                                    xls1_BOMwastage = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_rmk).Value Is Nothing)) Then
                                    xls1_rmk = Replace(Trim(excel.Cells(curRow, loc1_rmk).Value.ToString), "'", "''")
                                    If xls1_rmk Is Nothing Then
                                        xls1_rmk = ""
                                    End If
                                Else
                                    xls1_rmk = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_cusven).Value Is Nothing)) Then
                                    xls1_cusven = Replace(Trim(excel.Cells(curRow, loc1_cusven).Value.ToString), "'", "''")
                                    If xls1_cusven = "" Then
                                        xls1_cusven = xls1_venno
                                    End If
                                Else
                                    xls1_cusven = xls1_venno
                                End If

                                If (Not (excel.Cells(curRow, loc1_alsitmno).Value Is Nothing)) Then
                                    xls1_alsitmno = Replace(Trim(excel.Cells(curRow, loc1_alsitmno).Value.ToString), "'", "''")
                                    If xls1_alsitmno Is Nothing Then
                                        xls1_alsitmno = ""
                                    End If
                                Else
                                    xls1_alsitmno = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_alscolcde).Value Is Nothing)) Then
                                    xls1_alscolcde = Replace(Trim(excel.Cells(curRow, loc1_alscolcde).Value.ToString), "'", "''")
                                    If xls1_alscolcde Is Nothing Then
                                        xls1_alscolcde = ""
                                    End If
                                Else
                                    xls1_alscolcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_AlsTmpItmno).Value Is Nothing)) Then
                                    xls1_alstmpitmno = Replace(Trim(excel.Cells(curRow, loc1_AlsTmpItmno).Value.ToString), "'", "''")
                                    If xls1_alstmpitmno Is Nothing Then
                                        xls1_alstmpitmno = ""
                                    End If
                                Else
                                    xls1_alstmpitmno = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_numass).Value Is Nothing)) Then
                                    xls1_numass = Replace(Trim(excel.Cells(curRow, loc1_numass).Value.ToString), "'", "''")
                                    If xls1_numass = "" Or Integer.TryParse(xls1_numass, xls1_numass) = False Then
                                        xls1_numass = "0"
                                    End If
                                Else
                                    xls1_numass = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_itmnat).Value Is Nothing)) Then
                                    xls1_itmnat = Replace(Trim(excel.Cells(curRow, loc1_itmnat).Value.ToString), "'", "''")
                                    If xls1_itmnat Is Nothing Then
                                        xls1_itmnat = ""
                                    End If
                                Else
                                    xls1_itmnat = ""
                                End If

                                If (Not (excel.Cells(curRow, loc1_negprc).Value Is Nothing)) Then
                                    xls1_negprc = Replace(Trim(excel.Cells(curRow, loc1_negprc).Value.ToString), "'", "''")
                                    If xls1_negprc = "" Or IsNumeric(xls1_negprc) = False Then
                                        xls1_negprc = "0"
                                    End If
                                Else
                                    xls1_negprc = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc1_period).Value Is Nothing)) Then
                                    xls1_period = Replace(Trim(excel.Cells(curRow, loc1_period).Value.ToString), "'", "''")
                                    If xls1_period = "" Or IsDate(xls1_period) = False Then
                                        xls1_period = "1900-01-01"
                                    Else
                                        xls1_period = Format(CDate(xls1_period), "yyyy-MM-01 00:00:00.000")
                                    End If
                                Else
                                    xls1_period = "1900-01-01"
                                End If

                                If (Not (excel.Cells(curRow, loc1_expdat).Value Is Nothing)) Then
                                    xls1_expdat = Replace(Trim(excel.Cells(curRow, loc1_expdat).Value.ToString), "'", "''")
                                    If xls1_expdat = "" Or IsDate(xls1_expdat) = False Then
                                        xls1_expdat = "1900-01-01"
                                    Else
                                        xls1_expdat = Format(CDate(xls1_expdat), "yyyy-MM-dd 23:59:59.990")
                                    End If
                                Else
                                    xls1_expdat = "1900-01-01"
                                End If

                                Dim periodI
                                Dim cstexpdatI

                                If (Not (excel.Cells(curRow, loc1_period).Value Is Nothing)) Then          ' Period
                                    'If Trim(.Cells(row, loc_1_Period).Value.ToString) Then
                                    periodI = Replace(Trim(excel.Cells(curRow, loc1_period).Value.ToString), "'", "''")
                                    periodI = periodI + "-01"
                                Else
                                    periodI = ""
                                End If


                                If (Not (excel.Cells(curRow, loc1_expdat).Value Is Nothing)) Then       ' Cost Expiry Date
                                    cstexpdatI = Replace(Trim(excel.Cells(curRow, loc1_expdat).Value.ToString), "'", "''")
                                    Dim tempM As String = "0" + CStr(Month(cstexpdatI))
                                    Dim tempD As String = "0" + CStr(DatePart(DateInterval.Day, DateValue(cstexpdatI)))
                                    cstexpdatI = CStr(Year(cstexpdatI) & "-" & tempM.Substring(tempM.Length - 2, 2) & "-" & tempD.Substring(tempD.Length - 2, 2))
                                    If Not IsDate(cstexpdatI) Then
                                        cstexpdatI = "1900-01-01"
                                    End If
                                Else
                                    If IsDate(periodI) Then
                                        Dim expdat As DateTime = periodI
                                        expdat = DateAdd("yyyy", 1, expdat)
                                        expdat = DateAdd(DateInterval.Second, -1, expdat)
                                        Dim expM As String = "0" + CStr(Month(expdat))
                                        Dim expD As String = "0" + CStr(DatePart(DateInterval.Day, DateValue(expdat)))
                                        cstexpdatI = CStr(expdat.Year) + "-" + expM.Substring(expM.Length - 2, 2) + "-" + expD.Substring(expD.Length - 2, 2)
                                    Else
                                        cstexpdatI = "1900-01-01"
                                    End If
                                End If




                                ' Insert into IMITMDAT
                                gspStr = "sp_insert_IMITMDAT '" & "" & "','" & iid_itmseq & "','" & xlsFile & "','" & _
                                         xlsDate & "','" & iid_prdven & "','" & xls1_venno & "','" & xls1_cus1no & _
                                         "','" & xls1_cus2no & "','" & xls1_ftytmp & "','" & xls1_venitm & "','" & _
                                         xls1_engdsc & "','" & xls1_chndsc & "','" & xls1_lnecde & "','" & xls1_catlvl4 & _
                                         "','" & xls1_untcde & "','" & xls1_inrqty & "','" & xls1_mtrqty & "','" & _
                                         xls1_cft & "','" & xls1_conftr & "','" & xls1_sapum & "','" & xls1_curcde & _
                                         "','" & xls1_ftycstA & "','" & xls1_ftycstB & "','" & xls1_ftycstC & "','" & _
                                         xls1_ftycstD & "','" & xls1_ftycstE & "','" & xls1_ftycstTran & "','" & xls1_ftycstPack & "','" & _
                                         xls1_ftycst & "','" & xls1_ftyprcA & "','" & xls1_ftyprcB & "','" & _
                                         xls1_ftyprcC & "','" & xls1_ftyprcD & "','" & xls1_ftyprcE & "','" & xls1_ftyprcTran & "','" & _
                                         xls1_ftyprcPack & "','" & xls1_ftyprc & "','" & xls1_ftyprctrm & "','" & _
                                         xls1_hkprctrm & "','" & xls1_trantrm & "','" & xls1_inrdin & "','" & _
                                         xls1_inrwin & "','" & xls1_inrhin & "','" & xls1_mtrdin & "','" & xls1_mtrwin & _
                                         "','" & xls1_mtrhin & "','" & xls1_grswgt & "','" & xls1_netwgt & "','" & _
                                         xls1_pckitr & "','" & xls1_bomitm & "','" & xls1_orgdvenno & "','" & xls1_moq & _
                                         "','" & xls1_inrsze & "','" & xls1_mtrsze & "','" & xls1_mat & "','" & _
                                         xls1_BOMcurcde & "','" & xls1_BOMwastage & "','" & xls1_rmk & "','" & _
                                         xls1_cusven & "','" & xls1_alsitmno & "','" & xls1_alscolcde & "','" & _
                                         xls1_alstmpitmno & "','" & xls1_numass & "','" & xls1_itmnat & "','" & _
                                         xls1_negprc & "','" & xls1_period & "','" & cstexpdatI & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rs_XLS = Nothing
                                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on saving " & Me.Name & " #002 sp_insert_IMITMDAT : " & rtnStr)
                                    killProcess(cur_Process, new_Process)
                                    Exit Sub
                                End If

                                curRow += 1
                            Loop ' Next Line
                        Case xlsColor
                            curRow = 2

                            Do While (Not excel.Cells(curRow, loc2_venitm).Value Is Nothing)
                                If (Not (excel.Cells(curRow, loc2_venitm).Value Is Nothing)) Then
                                    xls2_venitm = Replace(Trim(excel.Cells(curRow, loc2_venitm).Value.ToString), "'", "''")
                                    If xls2_venitm = Nothing Then
                                        xls2_venitm = ""
                                    End If
                                Else
                                    xls2_venitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc2_colcde).Value Is Nothing)) Then
                                    xls2_colcde = Replace(Trim(excel.Cells(curRow, loc2_colcde).Value.ToString), "'", "''")
                                    If xls2_colcde = Nothing Then
                                        xls2_colcde = ""
                                    End If
                                Else
                                    xls2_colcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc2_coldsc).Value Is Nothing)) Then
                                    xls2_coldsc = Replace(Trim(excel.Cells(curRow, loc2_coldsc).Value.ToString), "'", "''")
                                    If xls2_coldsc = Nothing Then
                                        xls2_coldsc = ""
                                    End If
                                Else
                                    xls2_coldsc = ""
                                End If

                                ' Insert into IMCOLDAT
                                gspStr = "sp_insert_IMCOLDAT '" & "" & "','" & iid_itmseq & "','" & xlsFile & "','" & _
                                         xlsDate & "','" & xls2_venitm & "','" & xls2_colcde & "','" & xls2_coldsc & _
                                         "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rs_XLS = Nothing
                                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on saving " & Me.Name & " #003 sp_insert_IMCOLDAT : " & rtnStr)
                                    killProcess(cur_Process, new_Process)
                                    Exit Sub
                                End If

                                curRow += 1
                            Loop
                        Case xlsMaterial
                            curRow = 2

                            Do While (Not excel.Cells(curRow, loc3_venitm).Value Is Nothing)
                                If (Not (excel.Cells(curRow, loc3_venitm).Value Is Nothing)) Then
                                    xls3_venitm = Replace(Trim(excel.Cells(curRow, loc3_venitm).Value.ToString), "'", "''")
                                    If xls3_venitm = Nothing Then
                                        xls3_venitm = ""
                                    End If
                                Else
                                    xls3_venitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc3_cosmth).Value Is Nothing)) Then
                                    xls3_cosmth = Replace(Trim(excel.Cells(curRow, loc3_cosmth).Value.ToString), "'", "''")
                                    If xls3_cosmth = Nothing Then
                                        xls3_cosmth = ""
                                    End If
                                Else
                                    xls3_cosmth = ""
                                End If

                                If (Not (excel.Cells(curRow, loc3_compon).Value Is Nothing)) Then
                                    xls3_compon = Replace(Trim(excel.Cells(curRow, loc3_compon).Value.ToString), "'", "''")
                                    If xls3_compon = Nothing Then
                                        xls3_compon = ""
                                    End If
                                Else
                                    xls3_compon = ""
                                End If

                                If (Not (excel.Cells(curRow, loc3_asstive).Value Is Nothing)) Then
                                    xls3_asstive = Replace(Trim(excel.Cells(curRow, loc3_asstive).Value.ToString), "'", "''")
                                    If xls3_asstive = "" Or Integer.TryParse(xls3_asstive, xls3_asstive) = False Then
                                        xls3_asstive = "0"
                                    End If
                                Else
                                    xls3_asstive = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc3_rmk).Value Is Nothing)) Then
                                    xls3_rmk = Replace(Trim(excel.Cells(curRow, loc3_rmk).Value.ToString), "'", "''")
                                    If xls3_rmk = Nothing Then
                                        xls3_rmk = ""
                                    End If
                                Else
                                    xls3_rmk = ""
                                End If

                                ' Insert into IMCOMDAT
                                gspStr = "sp_insert_IMCOMDAT '" & "" & "','" & iid_itmseq & "','" & xlsFile & "','" & _
                                         xlsDate & "','" & xls3_venitm & "','" & xls3_cosmth & "','" & xls3_compon & _
                                         "','" & xls3_asstive & "','" & xls3_rmk & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rs_XLS = Nothing
                                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on saving " & Me.Name & " #004 sp_insert_IMCOMDAT : " & rtnStr)
                                    killProcess(cur_Process, new_Process)
                                    Exit Sub
                                End If

                                curRow += 1
                            Loop
                        Case xlsBOM
                            curRow = 2

                            Do While (Not excel.Cells(curRow, loc4_venitm).Value Is Nothing)
                                If (Not (excel.Cells(curRow, loc4_venitm).Value Is Nothing)) Then
                                    xls4_venitm = Replace(Trim(excel.Cells(curRow, loc4_venitm).Value.ToString), "'", "''")
                                    If xls4_venitm = Nothing Then
                                        xls4_venitm = ""
                                    End If
                                Else
                                    xls4_venitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc4_assitm).Value Is Nothing)) Then
                                    xls4_assitm = Replace(Trim(excel.Cells(curRow, loc4_assitm).Value.ToString), "'", "''")
                                    If xls4_assitm = Nothing Then
                                        xls4_assitm = ""
                                    End If
                                Else
                                    xls4_assitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc4_assdsc).Value Is Nothing)) Then
                                    xls4_assdsc = Replace(Trim(excel.Cells(curRow, loc4_assdsc).Value.ToString), "'", "''")
                                    If xls4_assdsc = Nothing Then
                                        xls4_assdsc = ""
                                    End If
                                Else
                                    xls4_assdsc = ""
                                End If

                                If (Not (excel.Cells(curRow, loc4_colcde).Value Is Nothing)) Then
                                    xls4_colcde = Replace(Trim(excel.Cells(curRow, loc4_colcde).Value.ToString), "'", "''")
                                    If xls4_colcde = Nothing Then
                                        xls4_colcde = ""
                                    End If
                                Else
                                    xls4_colcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc4_untcde).Value Is Nothing)) Then
                                    xls4_untcde = Replace(Trim(excel.Cells(curRow, loc4_untcde).Value.ToString), "'", "''")
                                    If xls4_untcde = Nothing Then
                                        xls4_untcde = ""
                                    End If
                                Else
                                    xls4_untcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc4_conftr).Value Is Nothing)) Then
                                    xls4_conftr = Replace(Trim(excel.Cells(curRow, loc4_conftr).Value.ToString), "'", "''")
                                    If xls4_conftr = "" Or Integer.TryParse(xls4_conftr, xls4_conftr) = False Then
                                        xls4_conftr = "0"
                                    End If
                                Else
                                    xls4_conftr = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc4_qty).Value Is Nothing)) Then
                                    xls4_qty = Replace(Trim(excel.Cells(curRow, loc4_qty).Value.ToString), "'", "''")
                                    If xls4_qty = "" Or Integer.TryParse(xls4_qty, xls4_qty) = False Then
                                        xls4_qty = "0"
                                    End If
                                Else
                                    xls4_qty = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc4_period).Value Is Nothing)) Then
                                    xls4_period = Replace(Trim(excel.Cells(curRow, loc4_period).Value.ToString), "'", "''")
                                    If xls4_period = "" Or IsDate(xls4_period) = False Then
                                        xls4_period = "1900-01-01"
                                    Else
                                        xls4_period = Format(CDate(xls4_period), "yyyy-MM-01 00:00:00.00")
                                    End If
                                Else
                                    xls4_period = "1900-01-01"
                                End If

                                ' Insert into IMBOMDAT
                                gspStr = "sp_insert_IMBOMDAT '" & "" & "','" & iid_itmseq & "','" & xlsFile & "','" & _
                                         xlsDate & "','" & xls4_venitm & "','" & xls4_assitm & "','" & xls4_assdsc & _
                                         "','" & xls4_colcde & "','" & xls4_untcde & "','" & xls4_conftr & "','" & _
                                         xls4_qty & "','" & xls4_period & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rs_XLS = Nothing
                                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on saving " & Me.Name & " #005 sp_insert_IMBOMDAT : " & rtnStr)
                                    killProcess(cur_Process, new_Process)
                                    Exit Sub
                                End If

                                curRow += 1
                            Loop
                        Case xlsAssorted
                            curRow = 2

                            Do While (Not excel.Cells(curRow, loc5_venitm).Value Is Nothing)
                                If (Not (excel.Cells(curRow, loc5_venitm).Value Is Nothing)) Then
                                    xls5_venitm = Replace(Trim(excel.Cells(curRow, loc5_venitm).Value.ToString), "'", "''")
                                    If xls5_venitm = Nothing Then
                                        xls5_venitm = ""
                                    End If
                                Else
                                    xls5_venitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc5_assitm).Value Is Nothing)) Then
                                    xls5_assitm = Replace(Trim(excel.Cells(curRow, loc5_assitm).Value.ToString), "'", "''")
                                    If xls5_assitm = Nothing Then
                                        xls5_assitm = ""
                                    End If
                                Else
                                    xls5_assitm = ""
                                End If

                                If (Not (excel.Cells(curRow, loc5_colcde).Value Is Nothing)) Then
                                    xls5_colcde = Replace(Trim(excel.Cells(curRow, loc5_colcde).Value.ToString), "'", "''")
                                    If xls5_colcde = Nothing Then
                                        xls5_colcde = ""
                                    End If
                                Else
                                    xls5_colcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc5_untcde).Value Is Nothing)) Then
                                    xls5_untcde = Replace(Trim(excel.Cells(curRow, loc5_untcde).Value.ToString), "'", "''")
                                    If xls5_untcde = Nothing Then
                                        xls5_untcde = ""
                                    End If
                                Else
                                    xls5_untcde = ""
                                End If

                                If (Not (excel.Cells(curRow, loc5_conftr).Value Is Nothing)) Then
                                    xls5_conftr = Replace(Trim(excel.Cells(curRow, loc5_conftr).Value.ToString), "'", "''")
                                    If xls5_conftr = "" Or Integer.TryParse(xls5_conftr, xls5_conftr) = False Then
                                        xls5_conftr = "0"
                                    End If
                                Else
                                    xls5_conftr = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc5_inrqty).Value Is Nothing)) Then
                                    xls5_inrqty = Replace(Trim(excel.Cells(curRow, loc5_inrqty).Value.ToString), "'", "''")
                                    If xls5_inrqty = "" Or Integer.TryParse(xls5_inrqty, xls5_inrqty) = False Then
                                        xls5_inrqty = "0"
                                    End If
                                Else
                                    xls5_inrqty = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc5_mtrqty).Value Is Nothing)) Then
                                    xls5_mtrqty = Replace(Trim(excel.Cells(curRow, loc5_mtrqty).Value.ToString), "'", "''")
                                    If xls5_mtrqty = "" Or Integer.TryParse(xls5_mtrqty, xls5_mtrqty) = False Then
                                        xls5_mtrqty = "0"
                                    End If
                                Else
                                    xls5_mtrqty = "0"
                                End If

                                If (Not (excel.Cells(curRow, loc5_period).Value Is Nothing)) Then
                                    xls5_period = Replace(Trim(excel.Cells(curRow, loc5_period).Value.ToString), "'", "''")
                                    If xls5_period = "" Or IsDate(xls5_period) = False Then
                                        xls5_period = "1900-01-01"
                                    Else
                                        xls5_period = Format(CDate(xls5_period), "yyyy-MM-01 00:00:00.00")
                                    End If
                                Else
                                    xls5_period = "1900-01-01"
                                End If

                                ' Insert into IMASSDAT
                                gspStr = "sp_insert_IMASSDAT '" & "" & "','" & iid_itmseq & "','" & xlsFile & "','" & _
                                         xlsDate & "','" & xls5_venitm & "','" & xls5_assitm & "','" & xls5_colcde & _
                                         "','" & xls5_untcde & "','" & xls5_conftr & "','" & xls5_inrqty & "','" & _
                                         xls5_mtrqty & "','" & xls5_period & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rs_XLS = Nothing
                                rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on saving " & Me.Name & " #006 sp_insert_IMASSDAT : " & rtnStr)
                                    killProcess(cur_Process, new_Process)
                                    Exit Sub
                                End If

                                curRow += 1
                            Loop
                    End Select
                Next 'Next Worksheet

            Catch ex As Exception
                numError += 1

                excel.Workbooks.Close()
                excel.Quit()
                excel = Nothing
                killProcess(cur_Process, new_Process)

                setErrMsg("An error has occured for " & filSource.Items(i) & "... Aborting Upload")
                moveFile(filSource.Items(i), xlsPath, ".err", True)
                Continue For
            End Try

            excel.Workbooks.Close()
            excel.Quit()
            excel = Nothing
            killProcess(cur_Process, new_Process)

            moveFile(filSource.Items(i), xlsPath, ".old", True)
        Next ' Next File

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        ' Detyermine Item Type, Calculate Basic Price
        gspStr = "sp_update_IMITMDAT_XLS '" & "" & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on saving " & Me.Name & " #007 sp_update_IMITMDAT_XLS : " & rtnStr)
            Exit Sub
        End If

        ' Detyermine Conftr
        gspStr = "sp_update_IMITMDAT_XLS_conftr '" & "" & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on saving " & Me.Name & " #007 sp_update_IMITMDAT_XLS : " & rtnStr)
            Exit Sub
        End If

        ' Remove Overwritten
        gspStr = "sp_update_IMCLRDAT_XLS '" & "" & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_XLS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on saving " & Me.Name & " #008 sp_update_IMCLRDAT_XLS : " & rtnStr)
            Exit Sub
        End If

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