Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMX00005

    Const templateVersion As String = "37.0.0"

    ' "ITEM" Spreadsheet
    Private Const loc_1_DV As Integer = 1
    Private Const loc_1_PV As Integer = 2
    Private Const loc_1_CV As Integer = 3
    Private Const loc_1_PriCus As Integer = 4
    Private Const loc_1_SecCus As Integer = 5
    Private Const loc_1_VenItm As Integer = 6
    Private Const loc_1_UCPNo As Integer = 7
    Private Const loc_1_DItmno As Integer = 8
    Private Const loc_1_Itmtyp As Integer = 9
    Private Const loc_1_CatLvl4 As Integer = 10
    Private Const loc_1_EngDsc As Integer = 11
    Private Const loc_1_ChnDsc As Integer = 12
    Private Const loc_1_Matl As Integer = 13
    Private Const loc_1_ItmNat As Integer = 14
    Private Const loc_1_PrdGrp As Integer = 15
    Private Const loc_1_PrdIcon As Integer = 16
    Private Const loc_1_PrdTyp As Integer = 17
    Private Const loc_1_PrdSzVal As Integer = 18
    Private Const loc_1_PrdSzUnt As Integer = 19
    Private Const loc_1_PrdSzTyp As Integer = 20
    Private Const loc_1_VenCol As Integer = 21
    Private Const loc_1_VenColDsc As Integer = 22
    Private Const loc_1_VenCol2 As Integer = 23

    Private Const loc_1_LneCde As Integer = 24
    Private Const loc_1_UM As Integer = 25
    Private Const loc_1_ConvToPC As Integer = 26
    Private Const loc_1_INR As Integer = 27
    Private Const loc_1_MTR As Integer = 28

    Private Const loc_1_InrL As Integer = 29
    Private Const loc_1_InrW As Integer = 30
    Private Const loc_1_InrH As Integer = 31
    Private Const loc_1_MtrL As Integer = 32
    Private Const loc_1_MtrW As Integer = 33
    Private Const loc_1_MtrH As Integer = 34
    Private Const loc_1_CFT As Integer = 35
    Private Const loc_1_PckM As Integer = 36
    Private Const loc_1_GW As Integer = 37
    Private Const loc_1_NW As Integer = 38
    Private Const loc_1_PckInst As Integer = 39
    Private Const loc_1_FtyPrcTrm As Integer = 40
    Private Const loc_1_HKPrcTrm As Integer = 41
    Private Const loc_1_TranTrm As Integer = 42
    Private Const loc_1_CCY As Integer = 43
    Private Const loc_1_FtyPrcTtl As Integer = 44
    Private Const loc_1_MoqUM As Integer = 45
    Private Const loc_1_MoqQty As Integer = 46
    Private Const loc_1_MoaCCY As Integer = 47
    Private Const loc_1_Moa As Integer = 48
    Private Const loc_1_QutDate As Integer = 49
    Private Const loc_1_ExpDate As Integer = 50
    Private Const loc_1_IntRmk As Integer = 51
    Private Const loc_1_CstRmk As Integer = 52
    Private Const loc_1_EstPrcFlg As Integer = 53
    Private Const loc_1_EstPrcRef As Integer = 54


    ' "BOM Parent"Spreadsheet
    Private Const loc_2_UCPNo As Integer = 1
    Private Const loc_2_BOMno As Integer = 2
    Private Const loc_2_ColCde As Integer = 3
    Private Const loc_2_UM As Integer = 4
    Private Const loc_2_ConvToPC As Integer = 5
    Private Const loc_2_Qty As Integer = 6


    ' "Assortment Parent" Spreadsheet
    Private Const loc_3_UCPNo As Integer = 1
    Private Const loc_3_ASSno As Integer = 2
    Private Const loc_3_ColCde As Integer = 3
    Private Const loc_3_UM As Integer = 4
    Private Const loc_3_ConvToPc As Integer = 5
    Private Const loc_3_INR As Integer = 6
    Private Const loc_3_MTR As Integer = 7

    ' "Material Cost Breakdown" Spreadsheet
    Private Const loc_4_UCPNo As Integer = 1
    Private Const loc_4_MatlBkd As Integer = 2
    Private Const loc_4_CstPer As Integer = 3
    Private Const loc_4_CstCCY As Integer = 4
    Private Const loc_4_CstAmt As Integer = 5
    Private Const loc_4_WgtPer As Integer = 6

    Dim rs_data As DataSet
    Dim rs_EXCEL As DataSet
    Dim myExcel As Excel.Application
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""

    Private Sub IMXLS005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Dir.GetFiles(FilePattern)
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

        Dim filCount As Integer
        Dim xlsPath As String
        Dim xlsDate As String

        Dim oldCI As Globalization.CultureInfo

        txtProcess.Text = ""

        If filSource.Items.Count = 0 Then
            MsgBox("No Excel file in the directory!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If Dir(filSourcePath + "\ItemExcelOldExt", vbDirectory) = "" Then
            MkDir(filSourcePath + "\ItemExcelOldExt")
        End If

        Err.Clear()
        filCount = 0

        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        ' Declaring local variables for spreadsheet
        ' "Item" spreadsheet
        Dim vennoI As String
        Dim prdvenI As String
        Dim cusvenI As String
        Dim cus1noI As String
        Dim cus2noI As String
        Dim venitmI As String
        Dim ucpnoI As String
        Dim ditmnoI As String
        Dim itmtypI As String
        Dim catlvl4I As String
        Dim engdscI As String
        Dim chndscI As String
        Dim matlI As String
        Dim itmnatI As String
        Dim prdgrpI As String
        Dim prdicnI As String
        Dim prdtypI As String
        Dim prdsztypI As String
        Dim prdszvalI As String
        Dim prdszuntI As String
        Dim vencolI As String
        Dim vencoldscI As String
        Dim vencol2I As String
        Dim lnecdeI As String
        Dim untcdeI As String
        Dim inrqtyI As String
        Dim mtrqtyI As String
        Dim cftI As String
        Dim conftrI As String
        Dim inrlinI As String
        Dim inrwinI As String
        Dim inrhinI As String
        Dim mtrlinI As String
        Dim mtrwinI As String
        Dim mtrhinI As String
        Dim pckmI As String
        Dim grswgtI As String
        Dim netwgtI As String
        Dim pckitrI As String
        Dim ftyprctrmI As String
        Dim hkprctrmI As String
        Dim trantrmI As String
        Dim curcdeI As String
        Dim fcurcdeI As String
        Dim ftycstI As String
        Dim ftyprcI As String
        Dim moqumI As String
        Dim moqtyI As String
        Dim moaccyI As String
        Dim moaI As String
        Dim qutdatI As String
        Dim expdatI As String
        Dim intrmkI As String
        Dim cstrmkI As String
        Dim estprcflgI As String
        Dim estprcrefI As String

        ' "BOM" spreadsheet
        Dim ucpnoB As String
        Dim bomnoB As String
        Dim colcdeB As String
        Dim untcdeB As String
        Dim conftrB As String
        Dim bomqtyB As String
        ' "Assortment" spreadsheet
        Dim ucpnoA As String
        Dim assdnoA As String
        Dim colcdeA As String
        Dim untcdeA As String
        Dim inrqtyA As String
        Dim mtrqtyA As String
        Dim conftrA As String
        ' "Material Breakdown" spreadsheet
        Dim ucpnoM As String
        Dim matlbkdM As String
        Dim cstperM As String
        Dim cstccyM As String
        Dim cstamtM As String
        Dim wgtperM As String

        Do While filCount < filSource.Items.Count
            vennoI = ""
            prdvenI = ""
            cusvenI = ""
            cus1noI = ""
            cus2noI = ""
            venitmI = ""
            ucpnoI = ""
            ditmnoI = ""
            itmtypI = ""
            catlvl4I = ""
            engdscI = ""
            chndscI = ""
            matlI = ""
            itmnatI = ""
            prdgrpI = ""
            prdicnI = ""
            prdtypI = ""
            prdsztypI = ""
            prdszvalI = ""
            prdszuntI = ""
            vencolI = ""
            vencoldscI = ""
            vencol2I = ""
            lnecdeI = ""
            untcdeI = ""
            inrqtyI = ""
            mtrqtyI = ""
            cftI = ""
            conftrI = ""
            inrlinI = ""
            inrwinI = ""
            inrhinI = ""
            mtrlinI = ""
            mtrwinI = ""
            mtrhinI = ""
            pckmI = ""
            grswgtI = ""
            netwgtI = ""
            pckitrI = ""
            ftyprctrmI = ""
            hkprctrmI = ""
            trantrmI = ""
            curcdeI = ""
            fcurcdeI = ""
            ftycstI = ""
            ftyprcI = ""
            moqumI = ""
            moqtyI = ""
            moaccyI = ""
            moaI = ""
            qutdatI = ""
            expdatI = ""
            intrmkI = ""
            cstrmkI = ""
            estprcflgI = ""
            estprcrefI = ""
            ' "BOM" spreadsheet
            ucpnoB = ""
            bomnoB = ""
            colcdeB = ""
            untcdeB = ""
            conftrB = ""
            bomqtyB = ""
            ' "Assortment" spreadsheet
            ucpnoA = ""
            assdnoA = ""
            colcdeA = ""
            untcdeA = ""
            inrqtyA = ""
            mtrqtyA = ""
            conftrA = ""
            ' "Material Breakdown" spreadsheet
            ucpnoM = ""
            matlbkdM = ""
            cstperM = ""
            cstccyM = ""
            cstamtM = ""
            wgtperM = ""

            myExcel = New Excel.Application
            'On Error GoTo Data_Error
            setErrMsg("Uploading - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(filCount))
            setErrMsg("Processing... Please Wait")
            xlsPath = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(filCount)
            xlsDate = Format(FileDateTime(xlsPath), "MM/dd/yyyy HH:MM:ss")

            gspStr = "sp_list_xlsfildat '','" & filSource.Items(filCount) & "','" & xlsDate & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_EXCEL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading IMXLS005 #001 sp_list_xlsfildat : " & rtnStr)
                setErrMsg("An error has occurred during upload. Upload has been terminated")
                Exit Sub
            End If
            If rs_EXCEL.Tables("RESULT").Rows.Count > 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Excel file has already been uploaded!")
                setErrMsg("'" & filSource.Items(filCount) & "' has already been uploaded")
                setErrMsg("Upload Process Terminated")
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If

            Dim row As Integer = 4
            Dim sheet As Integer = 1

            With myExcel
                'On Error GoTo Error_Hld_Excel
                .Workbooks.Open(xlsPath)        'Open the excel file
                .Sheets(sheet).Select()         'Select the first sheet
                If .Cells(1, 4).Value Is Nothing Then
                    setErrMsg("'" & filSource.Items(filCount) & "' - Unrecognizable template version number")
                    setErrMsg("Upload Process Terminated")
                    Me.Cursor = Windows.Forms.Cursors.Default
                    Exit Sub
                Else
                    If .Cells(1, 4).Value.ToString <> templateVersion Then
                        setErrMsg("'" & filSource.Items(filCount) & "' - Outdated template used")
                        setErrMsg("Upload Process Terminated")
                        Me.Cursor = Windows.Forms.Cursors.Default
                        Exit Sub
                    End If
                End If

ReadRow:
                .Sheets(sheet).Select()         'Select the first sheet
                If (sheet = "1" And Not (.Cells(row, 1).Value Is Nothing)) Then         ' ITEM Spreadsheet
                    If (Not (.Cells(row, loc_1_DV).Value Is Nothing)) Then              ' Design Vendor
                        vennoI = Replace(Trim(.Cells(row, loc_1_DV).Value.ToString), "'", "''")
                    Else
                        vennoI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PV).Value Is Nothing)) Then              ' Prod. Vendor
                        prdvenI = Replace(Trim(.Cells(row, loc_1_PV).Value.ToString), "'", "''")
                    Else
                        prdvenI = ""
                    End If
                    If (Not (.Cells(row, loc_1_CV).Value Is Nothing)) Then              ' Cust. Vendor
                        cusvenI = Replace(Trim(.Cells(row, loc_1_CV).Value.ToString), "'", "''")
                    Else
                        cusvenI = vennoI
                    End If
                    If (Not (.Cells(row, loc_1_PriCus).Value Is Nothing)) Then          ' Prim. Customer
                        cus1noI = Replace(Trim(.Cells(row, loc_1_PriCus).Value.ToString), "'", "''")
                    Else
                        cus1noI = ""
                    End If
                    If (Not (.Cells(row, loc_1_SecCus).Value Is Nothing)) Then          ' Sec. Custoner
                        cus2noI = Replace(Trim(.Cells(row, loc_1_SecCus).Value.ToString), "'", "''")
                    Else
                        cus2noI = ""
                    End If
                    If (Not (.Cells(row, loc_1_VenItm).Value Is Nothing)) Then          ' Vendor Item #
                        venitmI = Replace(Trim(.Cells(row, loc_1_VenItm).Value.ToString), "'", "''")
                    Else
                        venitmI = ""
                    End If
                    If (Not (.Cells(row, loc_1_UCPNo).Value Is Nothing)) Then           ' UCP #
                        ucpnoI = Replace(Trim(.Cells(row, loc_1_UCPNo).Value.ToString), "'", "''")
                    Else
                        ucpnoI = ""
                    End If
                    If (Not (.Cells(row, loc_1_DItmno).Value Is Nothing)) Then          ' Design Item #
                        ditmnoI = Replace(Trim(.Cells(row, loc_1_DItmno).Value.ToString), "'", "''")
                    Else
                        ditmnoI = ""
                    End If
                    If (Not (.Cells(row, loc_1_Itmtyp).Value Is Nothing)) Then          ' Item Type
                        itmtypI = Replace(Trim(.Cells(row, loc_1_Itmtyp).Value.ToString), "'", "''")
                    Else
                        itmtypI = ""
                    End If
                    If (Not (.Cells(row, loc_1_CatLvl4).Value Is Nothing)) Then         ' Cat. Level 4
                        catlvl4I = Replace(Trim(.Cells(row, loc_1_CatLvl4).Value.ToString), "'", "''")
                    Else
                        catlvl4I = ""
                    End If
                    If (Not (.Cells(row, loc_1_EngDsc).Value Is Nothing)) Then          ' English Desc.
                        engdscI = Replace(Trim(.Cells(row, loc_1_EngDsc).Value.ToString), "'", "''")
                    Else
                        engdscI = ""
                    End If
                    If (Not (.Cells(row, loc_1_ChnDsc).Value Is Nothing)) Then          ' Chinese Desc.
                        chndscI = Replace(Trim(.Cells(row, loc_1_ChnDsc).Value.ToString), "'", "''")
                    Else
                        chndscI = ""
                    End If
                    If (Not (.Cells(row, loc_1_Matl).Value Is Nothing)) Then            ' Key Material
                        matlI = Replace(Trim(.Cells(row, loc_1_Matl).Value.ToString), "'", "''")
                    Else
                        matlI = ""
                    End If
                    If (Not (.Cells(row, loc_1_ItmNat).Value Is Nothing)) Then          ' Item Nature
                        itmnatI = Replace(Trim(.Cells(row, loc_1_ItmNat).Value.ToString), "'", "''")
                    Else
                        itmnatI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PrdGrp).Value Is Nothing)) Then          ' Product Group
                        prdgrpI = Replace(Trim(.Cells(row, loc_1_PrdGrp).Value.ToString), "'", "''")
                    Else
                        prdgrpI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PrdIcon).Value Is Nothing)) Then         ' Product Icon
                        prdicnI = Replace(Trim(.Cells(row, loc_1_PrdIcon).Value.ToString), "'", "''")
                    Else
                        prdicnI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PrdTyp).Value Is Nothing)) Then          ' Product Type
                        prdtypI = Replace(Trim(.Cells(row, loc_1_PrdTyp).Value.ToString), "'", "''")
                        If (prdtypI = "OEM+S.R.") Then
                            prdtypI = "ODM"
                        End If
                    Else
                        prdtypI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PrdSzVal).Value Is Nothing)) Then        ' Product Size Value
                        prdszvalI = Replace(Trim(.Cells(row, loc_1_PrdSzVal).Value.ToString), "'", "''")
                    Else
                        prdszvalI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_PrdSzUnt).Value Is Nothing)) Then        ' Product Size Unit
                        prdszuntI = Replace(Trim(.Cells(row, loc_1_PrdSzUnt).Value.ToString), "'", "''")
                    Else
                        prdszuntI = ""
                    End If
                    If (Not (.Cells(row, loc_1_PrdSzTyp).Value Is Nothing)) Then        ' Product Size Type
                        prdsztypI = Replace(Trim(.Cells(row, loc_1_PrdSzTyp).Value.ToString), "'", "''")
                    Else
                        prdsztypI = ""
                    End If
                    If (Not (.Cells(row, loc_1_VenCol).Value Is Nothing)) Then          ' Color Code
                        vencolI = Replace(Trim(.Cells(row, loc_1_VenCol).Value.ToString), "'", "''")
                    Else
                        vencolI = ""
                    End If
                    If (Not (.Cells(row, loc_1_VenColDsc).Value Is Nothing)) Then       ' Color Desc.
                        vencoldscI = Replace(Trim(.Cells(row, loc_1_VenColDsc).Value.ToString), "'", "''")
                    Else
                        vencoldscI = ""
                    End If
                    If (Not (.Cells(row, loc_1_VenCol2).Value Is Nothing)) Then         ' Vendor Color Code
                        vencol2I = Replace(Trim(.Cells(row, loc_1_VenCol2).Value.ToString), "'", "''")
                    Else
                        vencol2I = ""
                    End If
                    If (Not (.Cells(row, loc_1_LneCde).Value Is Nothing)) Then          ' Product Line Code
                        lnecdeI = Replace(Trim(.Cells(row, loc_1_LneCde).Value.ToString), "'", "''")
                    Else
                        lnecdeI = ""
                    End If
                    If (Not (.Cells(row, loc_1_UM).Value Is Nothing)) Then              ' UM
                        untcdeI = Replace(Trim(.Cells(row, loc_1_UM).Value.ToString), "'", "''")
                    Else
                        untcdeI = ""
                    End If
                    If (Not (.Cells(row, loc_1_INR).Value Is Nothing)) Then             ' Inner Quantity
                        inrqtyI = Replace(Trim(.Cells(row, loc_1_INR).Value.ToString), "'", "''")
                    Else
                        inrqtyI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_MTR).Value Is Nothing)) Then             ' Master Quantity
                        mtrqtyI = Replace(Trim(.Cells(row, loc_1_MTR).Value.ToString), "'", "''")
                    Else
                        mtrqtyI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_CFT).Value Is Nothing)) Then             ' CFT
                        cftI = Replace(Trim(.Cells(row, loc_1_CFT).Value.ToString), "'", "''")
                    Else
                        cftI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_ConvToPC).Value Is Nothing)) Then        ' Conversion Factor
                        conftrI = Replace(Trim(.Cells(row, loc_1_ConvToPC).Value.ToString), "'", "''")
                    Else
                        conftrI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_InrL).Value Is Nothing)) Then            ' Inner Dimension (L)
                        inrlinI = Replace(Trim(.Cells(row, loc_1_InrL).Value.ToString), "'", "''")
                    Else
                        inrlinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_InrW).Value Is Nothing)) Then            ' Inner Dimension (W)
                        inrwinI = Replace(Trim(.Cells(row, loc_1_InrW).Value.ToString), "'", "''")
                    Else
                        inrwinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_InrH).Value Is Nothing)) Then            ' Inner Dimension (H)
                        inrhinI = Replace(Trim(.Cells(row, loc_1_InrH).Value.ToString), "'", "''")
                    Else
                        inrhinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_MtrL).Value Is Nothing)) Then            ' Master Dimension (L)
                        mtrlinI = Replace(Trim(.Cells(row, loc_1_MtrL).Value.ToString), "'", "''")
                    Else
                        mtrlinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_MtrW).Value Is Nothing)) Then            ' Master Dimension (W)
                        mtrwinI = Replace(Trim(.Cells(row, loc_1_MtrW).Value.ToString), "'", "''")
                    Else
                        mtrwinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_MtrH).Value Is Nothing)) Then            ' Master Dimension (H)
                        mtrhinI = Replace(Trim(.Cells(row, loc_1_MtrH).Value.ToString), "'", "''")
                    Else
                        mtrhinI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_PckM).Value Is Nothing)) Then            ' Packing Measurement
                        pckmI = Replace(Trim(.Cells(row, loc_1_PckM).Value.ToString), "'", "''")
                    Else
                        pckmI = ""
                    End If
                    If (Not (.Cells(row, loc_1_GW).Value Is Nothing)) Then              ' Gross Weight
                        grswgtI = Replace(Trim(.Cells(row, loc_1_GW).Value.ToString), "'", "''")
                    Else
                        grswgtI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_NW).Value Is Nothing)) Then              ' Net Weight
                        netwgtI = Replace(Trim(.Cells(row, loc_1_NW).Value.ToString), "'", "''")
                    Else
                        netwgtI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_PckInst).Value Is Nothing)) Then         ' Packing Instruction
                        pckitrI = Replace(Trim(.Cells(row, loc_1_PckInst).Value.ToString), "'", "''")
                    Else
                        pckitrI = ""
                    End If
                    If (Not (.Cells(row, loc_1_FtyPrcTrm).Value Is Nothing)) Then       ' Factory Price Term
                        ftyprctrmI = Replace(Trim(.Cells(row, loc_1_FtyPrcTrm).Value.ToString), "'", "''")
                    Else
                        ftyprctrmI = ""
                    End If
                    If (Not (.Cells(row, loc_1_HKPrcTrm).Value Is Nothing)) Then        ' HK Price Term
                        hkprctrmI = Replace(Trim(.Cells(row, loc_1_HKPrcTrm).Value.ToString), "'", "''")
                    Else
                        hkprctrmI = ""
                    End If
                    If (Not (.Cells(row, loc_1_TranTrm).Value Is Nothing)) Then        ' Transport Term
                        trantrmI = Replace(Trim(.Cells(row, loc_1_TranTrm).Value.ToString), "'", "''")
                    Else
                        trantrmI = ""
                    End If
                    If (Not (.Cells(row, loc_1_CCY).Value Is Nothing)) Then             ' Currency
                        curcdeI = Replace(Trim(.Cells(row, loc_1_CCY).Value.ToString), "'", "''")
                    Else
                        curcdeI = ""
                    End If
                    '** For External Factory upload, fcurcde, bcurcde for BOM is same as curcde from Excel **
                    fcurcdeI = curcdeI                                                  ' Factory Currency Code
                    ftycstI = 0                                                         ' Factory Cost
                    If (Not (.Cells(row, loc_1_FtyPrcTtl).Value Is Nothing)) Then       ' Factory Pricing
                        ftyprcI = Replace(Trim(.Cells(row, loc_1_FtyPrcTtl).Value.ToString), "'", "''")
                    Else
                        ftyprcI = "0"
                    End If
                    If (Not (.Cells(row, loc_1_MoqUM).Value Is Nothing)) Then           ' MOQ UM
                        moqumI = Replace(Trim(.Cells(row, loc_1_MoqUM).Value.ToString), "'", "''")
                    Else
                        moqumI = ""
                    End If
                    If (Not (.Cells(row, loc_1_MoqQty).Value Is Nothing)) Then          ' MOQ Quantity
                        moqtyI = Replace(Trim(.Cells(row, loc_1_MoqQty).Value.ToString), "'", "''")
                    Else
                        moqtyI = ""
                    End If
                    If (Not (.Cells(row, loc_1_MoaCCY).Value Is Nothing)) Then          ' MOA Currency
                        moaccyI = Replace(Trim(.Cells(row, loc_1_MoaCCY).Value.ToString), "'", "''")
                    Else
                        moaccyI = ""
                    End If
                    If (Not (.Cells(row, loc_1_Moa).Value Is Nothing)) Then             ' MOA
                        moaI = Replace(Trim(.Cells(row, loc_1_Moa).Value.ToString), "'", "''")
                    Else
                        moaI = ""
                    End If
                    If (Not (.Cells(row, loc_1_QutDate).Value Is Nothing)) Then         ' Quote Date
                        qutdatI = Replace(Trim(.Cells(row, loc_1_QutDate).Value.ToString), "'", "''")
                        'qutdatI = Format(qutdatI, "MM/dd/yyyy HH:mm:ss")
                    Else
                        qutdatI = ""
                    End If
                    If (Not (.Cells(row, loc_1_ExpDate).Value Is Nothing)) Then         ' Cost Expiry Date
                        expdatI = Replace(Trim(.Cells(row, loc_1_ExpDate).Value.ToString), "'", "''")
                    Else
                        expdatI = ""
                    End If
                    If (Not (.Cells(row, loc_1_IntRmk).Value Is Nothing)) Then          ' Internal Remark
                        intrmkI = Replace(Trim(.Cells(row, loc_1_IntRmk).Value.ToString), "'", "''")
                    Else
                        intrmkI = ""
                    End If
                    If (Not (.Cells(row, loc_1_CstRmk).Value Is Nothing)) Then          ' Cost Remark
                        cstrmkI = Replace(Trim(.Cells(row, loc_1_CstRmk).Value.ToString), "'", "''")
                    Else
                        cstrmkI = ""
                    End If
                    If (Not (.Cells(row, loc_1_EstPrcFlg).Value Is Nothing)) Then       ' Estimated Price Flag
                        If UCase(Trim(.Cells(row, loc_1_EstPrcFlg).Value.ToString)) = "N" Then
                            estprcflgI = "N"
                        Else
                            estprcflgI = "Y"
                        End If
                    Else
                        estprcflgI = "Y"
                    End If
                    If (Not (.Cells(row, loc_1_EstPrcRef).Value Is Nothing)) Then       ' Estimated Price Reference Number
                        estprcrefI = Replace(Trim(.Cells(row, loc_1_EstPrcRef).Value.ToString), "'", "''")
                    Else
                        estprcrefI = ""
                    End If

                ElseIf (sheet = "2" And Not (.Cells(row, 1).Value Is Nothing)) Then     ' BOM Spreadsheet
                    If (Not (.Cells(row, loc_2_UCPNo).Value Is Nothing)) Then           ' UCP #
                        ucpnoB = Replace(Trim(.Cells(row, loc_2_UCPNo).Value.ToString), "'", "''")
                    Else
                        ucpnoB = ""
                    End If
                    If (Not (.Cells(row, loc_2_BOMno).Value Is Nothing)) Then           ' BOM #
                        bomnoB = Replace(Trim(.Cells(row, loc_2_BOMno).Value.ToString), "'", "''")
                    Else
                        bomnoB = ""
                    End If
                    If (Not (.Cells(row, loc_2_ColCde).Value Is Nothing)) Then          ' Color Code
                        colcdeB = Replace(Trim(.Cells(row, loc_2_ColCde).Value.ToString), "'", "''")
                    Else
                        colcdeB = ""
                    End If
                    If (Not (.Cells(row, loc_2_UM).Value Is Nothing)) Then              ' UM
                        untcdeB = Replace(Trim(.Cells(row, loc_2_UM).Value.ToString), "'", "''")
                    Else
                        untcdeB = ""
                    End If
                    If (Not (.Cells(row, loc_2_ConvToPC).Value Is Nothing)) Then        ' Conversion Factor
                        conftrB = Replace(Trim(.Cells(row, loc_2_ConvToPC).Value.ToString), "'", "''")
                    Else
                        conftrB = ""
                    End If
                    If (Not (.Cells(row, loc_2_Qty).Value Is Nothing)) Then             ' BOM Quantity
                        bomqtyB = Replace(Trim(.Cells(row, loc_2_Qty).Value.ToString), "'", "''")
                    Else
                        bomqtyB = ""
                    End If

                ElseIf (sheet = "3" And Not (.Cells(row, 1).Value Is Nothing)) Then     ' ASSORTMENT spreadsheet
                    If (Not (.Cells(row, loc_3_UCPNo).Value Is Nothing)) Then           ' UCP #
                        ucpnoA = Replace(Trim(.Cells(row, loc_3_UCPNo).Value.ToString), "'", "''")
                    Else
                        ucpnoA = ""
                    End If
                    If (Not (.Cells(row, loc_3_ASSno).Value Is Nothing)) Then           ' Assortment #
                        assdnoA = Replace(Trim(.Cells(row, loc_3_ASSno).Value.ToString), "'", "''")
                    Else
                        assdnoA = ""
                    End If
                    If (Not (.Cells(row, loc_3_ColCde).Value Is Nothing)) Then          ' Color Code
                        colcdeA = Replace(Trim(.Cells(row, loc_3_ColCde).Value.ToString), "'", "''")
                    Else
                        colcdeA = ""
                    End If
                    If (Not (.Cells(row, loc_3_UM).Value Is Nothing)) Then              ' UM
                        untcdeA = Replace(Trim(.Cells(row, loc_3_UM).Value.ToString), "'", "''")
                    Else
                        untcdeA = ""
                    End If
                    If (Not (.Cells(row, loc_3_INR).Value Is Nothing)) Then             ' Inner Quantity
                        inrqtyA = Replace(Trim(.Cells(row, loc_3_INR).Value.ToString), "'", "''")
                    Else
                        inrqtyA = ""
                    End If
                    If (Not (.Cells(row, loc_3_MTR).Value Is Nothing)) Then             ' Master Quantity
                        mtrqtyA = Replace(Trim(.Cells(row, loc_3_MTR).Value.ToString), "'", "''")
                    Else
                        mtrqtyA = ""
                    End If
                    If (Not (.Cells(row, loc_3_ConvToPc).Value Is Nothing)) Then        ' Conversion Factor
                        conftrA = Replace(Trim(.Cells(row, loc_3_ConvToPc).Value.ToString), "'", "''")
                    Else
                        conftrA = ""
                    End If

                ElseIf (sheet = "4" And Not (.Cells(row, 1).Value Is Nothing)) Then     ' MATERIAL BREAKDOWN spreadsheet
                    If (Not (.Cells(row, loc_4_UCPNo).Value Is Nothing)) Then           ' UCP #
                        ucpnoM = Replace(Trim(.Cells(row, loc_4_UCPNo).Value.ToString), "'", "''")
                    Else
                        ucpnoM = ""
                    End If
                    If (Not (.Cells(row, loc_4_MatlBkd).Value Is Nothing)) Then         ' Material Breakdown
                        matlbkdM = Replace(Trim(.Cells(row, loc_4_MatlBkd).Value.ToString), "'", "''")
                    Else
                        matlbkdM = ""
                    End If
                    If (Not (.Cells(row, loc_4_CstPer).Value Is Nothing)) Then          ' Cost Percentage
                        cstperM = Replace(Trim(.Cells(row, loc_4_CstPer).Value.ToString), "'", "''")
                    Else
                        cstperM = ""
                    End If
                    If (Not (.Cells(row, loc_4_CstCCY).Value Is Nothing)) Then          ' Currency
                        cstccyM = Replace(Trim(.Cells(row, loc_4_CstCCY).Value.ToString), "'", "''")
                    Else
                        cstccyM = ""
                    End If
                    If (Not (.Cells(row, loc_4_CstAmt).Value Is Nothing)) Then          ' Cost Amount
                        cstamtM = Replace(Trim(.Cells(row, loc_4_CstAmt).Value.ToString), "'", "''")
                    Else
                        cstamtM = ""
                    End If
                    If (Not (.Cells(row, loc_4_WgtPer).Value Is Nothing)) Then          ' Weight Percentage
                        wgtperM = Replace(Trim(.Cells(row, loc_4_WgtPer).Value.ToString), "'", "''")
                    Else
                        wgtperM = ""
                    End If
                End If

                '========================================
                '===== Insert into Table ITMITEXDAT =====
                '========================================

                If sheet = 1 Then

                    ' Empty strings to satisfy Stored Procedure
                    Dim finishI As String = ""
                    Dim pbagI As String = ""
                    Dim sfoamI As String = ""
                    Dim bpackI As String = ""

                    gspStr = "sp_insert_imitmexdat '','" & vennoI & "','" & prdvenI & "','" & cusvenI & _
                             "','" & cus1noI & "','" & cus2noI & "','" & venitmI & _
                             "','" & ucpnoI & "','" & ditmnoI & "','" & itmtypI & _
                             "','" & catlvl4I & "','" & engdscI & "','" & chndscI & _
                             "','" & finishI & "','" & matlI & "','" & itmnatI & _
                             "','" & prdtypI & "','" & prdsztypI & "','" & prdszuntI & _
                             "','" & prdszvalI & "','" & vencolI & "','" & vencoldscI & "','" & vencol2I & _
                             "','" & lnecdeI & "','" & untcdeI & "','" & inrqtyI & _
                             "','" & mtrqtyI & "','" & cftI & "','" & conftrI & _
                             "','" & inrlinI & "','" & inrwinI & "','" & inrhinI & _
                             "','" & mtrlinI & "','" & mtrwinI & "','" & mtrhinI & _
                             "','" & grswgtI & "','" & netwgtI & "','" & pckitrI & _
                             "','" & filSource.Items(filCount) & "','" & xlsDate & _
                             "','" & pbagI & "','" & sfoamI & "','" & bpackI & _
                             "','" & ftyprctrmI & "','" & curcdeI & "','" & ftycstI & _
                             "','" & ftyprcI & "','" & moqumI & "','" & moqtyI & _
                             "','" & moaccyI & "','" & moaI & "','" & qutdatI & _
                             "','" & expdatI & "','" & fcurcdeI & "','" & pckmI & _
                             "','" & prdgrpI & "','" & prdicnI & _
                             "','" & intrmkI & "','" & cstrmkI & "','" & hkprctrmI & "','" & trantrmI & _
                             "','" & estprcflgI & "','" & estprcrefI & "','END','" & LCase(gsUsrID) & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading IMXLS005 sp_insert_IMITMEXDAT : " & rtnStr)
                        setErrMsg("An error has occurred during upload. Upload has been terminated")
                        Exit Sub
                    End If

                ElseIf sheet = 2 And ucpnoB <> "" Then
                    gspStr = "sp_insert_imbomexdat '','" & ucpnoB & "','" & bomnoB & _
                             "','" & colcdeB & "','" & bomqtyB & "','" & untcdeB & _
                             "','" & conftrB & "','" & filSource.Items(filCount) & _
                             "','" & xlsDate & "','" & LCase(gsUsrID) & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading IMXLS005 sp_insert_IMBOMEXDAT : " & rtnStr)
                        setErrMsg("An error has occurred during upload. Upload has been terminated")
                        Exit Sub
                    End If

                    ucpnoB = ""

                ElseIf sheet = 3 And ucpnoA <> "" Then
                    gspStr = "sp_insert_imassexdat '','" & ucpnoA & "','" & assdnoA & _
                             "','" & colcdeA & "','" & inrqtyA & "','" & mtrqtyA & _
                             "','" & untcdeA & "','" & conftrA & _
                             "','" & filSource.Items(filCount) & "','" & xlsDate & "','" & LCase(gsUsrID) & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading IMXLS005 sp_insert_IMASSEXDAT : " & rtnStr)
                        setErrMsg("An error has occurred during upload. Upload has been terminated")
                        Exit Sub
                    End If

                    ucpnoA = ""

                ElseIf sheet = 4 And ucpnoM <> "" Then
                    gspStr = "sp_insert_immbdexdat '','" & ucpnoM & "','" & matlbkdM & _
                             "','" & cstperM & "','" & cstccyM & "','" & cstamtM & _
                             "','" & wgtperM & "','" & filSource.Items(filCount) & _
                             "','" & xlsDate & "','" & LCase(gsUsrID) & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("Error on loading IMXLS005 sp_insert_IMMBDEXDAT : " & rtnStr)
                        setErrMsg("An error has occurred during upload. Upload has been terminated")
                        Exit Sub
                    End If

                    ucpnoM = ""

                End If

                '========================================
                '===== Go to Next Row or Next Sheet =====
                '========================================
                If (Not (.Cells(row + 1, 1).Value Is Nothing)) Then '*** Go to the next row
                    row = row + 1
                    GoTo ReadRow
                Else
                    If sheet = 1 Then               ' Go to "BOM Parent" Spreadsheet
                        sheet = 2
                        row = 2
                        GoTo ReadRow
                    ElseIf sheet = 2 Then           ' Go to "Assortment" Spreadsheet
                        sheet = 3
                        row = 2
                        GoTo ReadRow
                    ElseIf sheet = 3 Then           ' Go to "Material Breakdown" Spreadsheet
                        sheet = 4
                        row = 2
                        GoTo ReadRow
                    ElseIf sheet = 4 Then
                        '*** Check Equal of Assortment Packing and Assorted Item Packing Sum ***
                        gspStr = "sp_list_asspckchk '','" & filSource.Items(filCount) & "','" & xlsDate & "','" & LCase(gsUsrID) & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            MsgBox("Error on loading IMXLS005 sp_insert_asspckchk : " & rtnStr)
                            setErrMsg("An error has occurred during upload. Upload has been terminated")
                            Exit Sub
                        End If

                        '*** CLose processed Excel file ***
                        myExcel.Workbooks.Close()
                        myExcel.Quit()
                        myExcel = Nothing

                        ' move file to new directory....
                        moveFile(filSource.Items(filCount), xlsPath, ".old")

                        filCount = filCount + 1

                    End If
                End If

            End With

            GoTo Next_Record

Data_Error:
            On Error Resume Next
            myExcel.Workbooks.Close()
            myExcel.Quit()
            myExcel = Nothing

            moveFile(filSource.Items(filCount), xlsPath, ".err")

            filCount = filCount + 1
            GoTo Next_Record

Next_Record:

        Loop

        gspStr = "sp_update_IMITMEXDAT_itmtyp ''"
        rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading IMXLS005 sp_update_IMITMEXDAT_itmtyp : " & rtnStr)
            setErrMsg("An error has occurred during upload. Upload has been terminated")
            Exit Sub
        End If

        gspStr = "sp_insert_IMCLREXDAT '','" & LCase(gsUsrID) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading IMXLS005 sp_insert_IMCLREXDAT : " & rtnStr)
            setErrMsg("An error has occurred during upload. Upload has been terminated")
            Exit Sub
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        setErrMsg("Upload Completed!")
        Me.Cursor = Windows.Forms.Cursors.Default
        cmdRefresh.PerformClick()

    End Sub

    Private Sub moveFile(ByVal xlsFile As String, ByVal curPath As String, ByVal ext As String)
        Dim strFileCopy As String

        strFileCopy = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & _
                      "ItemExcelOldExt\" & LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & ext
        On Error GoTo err_Handle_File_Access_Error
        If Dir(strFileCopy) = (LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & ext) Then
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
        Err.Clear()
        On Error GoTo 0
    End Sub

    Private Sub setErrMsg(ByVal strMsg As String)
        If Trim(txtProcess.Text) = "" Then
            txtProcess.Text = Format(Now(), "MM-dd-yyyy HH:MM:ss") & " " & strMsg
        Else
            txtProcess.Text = txtProcess.Text & vbCrLf & Format(Now(), "MM-dd-yyyy HH:MM:ss") & " " & strMsg
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
                Dir.GetFiles(FilePattern)

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
End Class