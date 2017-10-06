Option Explicit On
Imports Microsoft.Office.Interop
Imports System.IO

Public Class IMXLS006

    Private Const loc_1_venitm As Integer = 1
    Private Const loc_1_engdsc As Integer = 2
    Private Const loc_1_fcA As Integer = 3
    Private Const loc_1_fcB As Integer = 4
    Private Const loc_1_fcC As Integer = 5
    Private Const loc_1_fcD As Integer = 6
    Private Const loc_1_fcTran As Integer = 7
    Private Const loc_1_fcPack As Integer = 8
    Private Const loc_1_ftycst As Integer = 9
    Private Const loc_1_inrqty As Integer = 10
    Private Const loc_1_mtrqty As Integer = 11
    Private Const loc_1_cft As Integer = 12
    Private Const loc_1_untcde As Integer = 13
    Private Const loc_1_conftr As Integer = 14
    Private Const loc_1_inrmsr As Integer = 15
    Private Const loc_1_mtrmsr As Integer = 16
    Private Const loc_1_remark As Integer = 17
    Private Const loc_1_confirm As Integer = 18
    Private Const loc_1_condat As Integer = 19
    Private Const loc_1_period As Integer = 20
    Private Const loc_1_prctrm As Integer = 21
    Private Const loc_1_trantrm As Integer = 22
    Private Const loc_1_pckitr As Integer = 23
    Private Const loc_1_inrpck As Integer = 24
    Private Const loc_1_mtrpck As Integer = 25
    Private Const loc_1_mat As Integer = 26
    Private Const loc_1_cus1no As Integer = 27
    Private Const loc_1_cus1nam As Integer = 28
    Private Const loc_1_cus2no As Integer = 29
    Private Const loc_1_cus2nam As Integer = 30
    Private Const loc_1_tempflg As Integer = 31
    Private Const loc_1_lnecde As Integer = 32
    Private Const loc_1_catlvl4 As Integer = 33

    Private Const loc_2_venitm As Integer = 1
    Private Const loc_2_acsno As Integer = 2
    Private Const loc_2_itmdsc As Integer = 3
    Private Const loc_2_qty As Integer = 4
    Private Const loc_2_vend As Integer = 5
    Private Const loc_2_bomprc As Integer = 6
    Private Const loc_2_prccur As Integer = 7
    Private Const loc_2_bomcst As Integer = 8
    Private Const loc_2_cstcur As Integer = 9
    Private Const loc_2_period As Integer = 10

    Private Const loc_3_venitm As Integer = 1
    Private Const loc_3_acsno As Integer = 2
    Private Const loc_3_itmdsc As Integer = 3
    Private Const loc_3_colcde As Integer = 4
    Private Const loc_3_untcde As Integer = 5
    Private Const loc_3_conftr As Integer = 6
    Private Const loc_3_inrqty As Integer = 7
    Private Const loc_3_mtrqty As Integer = 8
    Private Const loc_3_period As Integer = 9

    Dim rs_data As DataSet
    Dim rs_EXCEL As DataSet
    Dim myExcel As Excel.Application
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""

    Private Sub IMXLS006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim filCount As Integer
        Dim xlsPath As String
        Dim xlsDate As String
        Dim rs_IMPCITMDAT As New DataSet
        Dim rs_prep As New DataSet

        Dim oldCI As Globalization.CultureInfo

        txtProcess.Text = ""

        If filSource.Items.Count = 0 Then
            MsgBox("No Excel file in the directory!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        setErrMsg("Clearing Cached Items... Please Wait")

        ' **** Update any items in IMITMDAT which has not been entered into IM ****
        gspStr = "sp_IMPCITMDAT_refresh"
        rtnLong = execute_SQLStatement(gspStr, rs_prep, rtnStr)
        Application.DoEvents()

        gspStr = "sp_IMPCUPDDAT"
        rtnLong = execute_SQLStatement(gspStr, rs_prep, rtnStr)
        Application.DoEvents()

        gspStr = "sp_IMPCINSDAT"
        rtnLong = execute_SQLStatement(gspStr, rs_prep, rtnStr)
        Application.DoEvents()

        Err.Clear()
        filCount = 0

        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim venitmI As String = "", tempflgI As String = "", itmseqI As String = ""
        Dim stageI As String = "", cus1noI As String = "", itmtypI As String = ""
        Dim cus1namI As String = "", cus2noI As String = "", cus2namI As String = "", engdscI As String = ""
        Dim lnecdeI As String = "", catlvl4I As String = "", untcdeI As String = "", inrqtyI As String = ""
        Dim mtrqtyI As String = "", inrmsrI As String = "", mtrmsrI As String = "", cftI As String = ""
        Dim conftrI As String = "", ftycstI As String = "", ftycstAI As String = "", ftycstBI As String = ""
        Dim ftycstCI As String = "", ftycstDI As String = "", ftycstTranI As String = "", ftycstPackI As String = ""
        Dim rmkI As String = "", confirmI As String = "", condatI As String = "", periodI As String = ""
        Dim cstexpdatI As String = "", prctrmI As String = "", trantrmI As String = "", pckitrI As String = ""
        Dim inrpckI As String = "", mtrpckI As String = "", matI As String = ""

        Dim venitmB As String = "", acsnoB As String = "", itmdscB As String = "", qtyB As String = ""
        Dim veninfB As String = "", bomprcB As String = "", prccurB As String = "", bomcstB As String = ""
        Dim cstcurB As String = "", periodB As String = ""

        Dim venitmA As String = "", acsnoA As String = "", itmdscA As String = "", colcdeA As String = ""
        Dim untcdeA As String = "", conftrA As String = "", inrqtyA As String = "", mtrqtyA As String = ""
        Dim periodA As String = ""

        Do While filCount < filSource.Items.Count
            myExcel = New Excel.Application
            On Error GoTo Data_Error
            setErrMsg("Uploading - " & filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(filCount))
            setErrMsg("Processing... Please Wait")

            xlsPath = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & filSource.Items(filCount)
            If xlsPath = "" Then
                MsgBox("Invalid Directory", MsgBoxStyle.Exclamation, "Directory Error")
            End If

            xlsDate = Format(FileDateTime(xlsPath), "MM/dd/yyyy HH:MM:ss")

            Dim row As Integer = 3
            Dim sheet As Integer = 1

            With myExcel
                'On Error GoTo Error_Hld_Excel
                .Workbooks.Open(xlsPath)        'Open the excel file

                ' -- Retrieve Next Item Sequence Number
                gspStr = "sp_select_SQL '','Select isnull(max(ipd_itmseq),0)  + 1 from IMPCITMDAT'"
                rtnLong = execute_SQLStatement(gspStr, rs_prep, rtnStr)
                itmseqI = rs_prep.Tables("RESULT").Rows(0)(0)

                gspStr = "sp_select_SQL '','Select isnull(max(ipd_itmseq),0)  + 1 from IMPCITMDATH'"
                rtnLong = execute_SQLStatement(gspStr, rs_prep, rtnStr)
                If itmseqI < rs_prep.Tables("RESULT").Rows(0)(0) Then
                    itmseqI = rs_prep.Tables("RESULT").Rows(0)(0)
                End If

ReadRow:
                .Sheets(sheet).Select()         'Select the first sheet
                If (sheet = 1 And Not (.Cells(row, 1).Value Is Nothing)) Then

                    If (Not (.Cells(row, loc_1_venitm).Value Is Nothing)) Then              ' Item Number
                        If Trim(.Cells(row, loc_1_venitm).Value.ToString) <> "" Then
                            venitmI = Replace(Trim(.Cells(row, loc_1_venitm).Value.ToString), "'", "''")
                        Else
                            venitmI = ""
                        End If
                    Else
                        venitmI = ""
                    End If

                    If (Not (.Cells(row, loc_1_engdsc).Value Is Nothing)) Then              ' English Description
                        If Trim(.Cells(row, loc_1_engdsc).Value.ToString) <> "" Then
                            engdscI = Replace(Trim(.Cells(row, loc_1_engdsc).Value.ToString), "'", "''")
                        Else
                            engdscI = ""
                        End If
                    Else
                        engdscI = ""
                    End If

                    If (Not (.Cells(row, loc_1_fcA).Value Is Nothing)) Then                 ' Factory Cost (A)
                        If Trim(.Cells(row, loc_1_fcA).Value.ToString) <> "" Then
                            ftycstAI = Replace(Trim(.Cells(row, loc_1_fcA).Value.ToString), "'", "''")
                        Else
                            ftycstAI = "0"
                        End If
                    Else
                        ftycstAI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_fcB).Value Is Nothing)) Then                 ' Factory Cost (B)
                        If Trim(.Cells(row, loc_1_fcB).Value.ToString) <> "" Then
                            ftycstBI = Replace(Trim(.Cells(row, loc_1_fcB).Value.ToString), "'", "''")
                        Else
                            ftycstBI = "0"
                        End If
                    Else
                        ftycstBI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_fcC).Value Is Nothing)) Then                 ' Factory Cost (C)
                        If Trim(.Cells(row, loc_1_fcC).Value.ToString) <> "" Then
                            ftycstCI = Replace(Trim(.Cells(row, loc_1_fcC).Value.ToString), "'", "''")
                        Else
                            ftycstCI = "0"
                        End If
                    Else
                        ftycstCI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_fcD).Value Is Nothing)) Then                 ' Factory Cost (D)
                        If Trim(.Cells(row, loc_1_fcD).Value.ToString) <> "" Then
                            ftycstDI = Replace(Trim(.Cells(row, loc_1_fcD).Value.ToString), "'", "''")
                        Else
                            ftycstDI = "0"
                        End If
                    Else
                        ftycstDI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_fcTran).Value Is Nothing)) Then              ' Factory Cost (Transportation)
                        If Trim(.Cells(row, loc_1_fcTran).Value.ToString) <> "" Then
                            ftycstTranI = Replace(Trim(.Cells(row, loc_1_fcTran).Value.ToString), "'", "''")
                        Else
                            ftycstTranI = "0"
                        End If
                    Else
                        ftycstTranI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_fcPack).Value Is Nothing)) Then              ' Factory Cost (Packing)
                        If Trim(.Cells(row, loc_1_fcPack).Value.ToString) <> "" Then
                            ftycstPackI = Replace(Trim(.Cells(row, loc_1_fcPack).Value.ToString), "'", "''")
                        Else
                            ftycstPackI = "0"
                        End If
                    Else
                        ftycstPackI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_ftycst).Value Is Nothing)) Then              ' Factory Cost
                        If Trim(.Cells(row, loc_1_ftycst).Value.ToString) <> "" Then
                            ftycstI = Replace(Trim(.Cells(row, loc_1_ftycst).Value.ToString), "'", "''")
                        Else
                            ftycstI = "0"
                        End If
                    Else
                        ftycstI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_inrqty).Value Is Nothing)) Then              ' Inner Quantity
                        If Trim(myExcel.Cells(row, loc_1_inrqty).Value.ToString) <> "" Then
                            inrqtyI = Replace(Trim(.Cells(row, loc_1_inrqty).Value.ToString), "'", "''")
                        Else
                            inrqtyI = "0"
                        End If
                    Else
                        inrqtyI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_mtrqty).Value Is Nothing)) Then              ' Master Quantity
                        If Trim(myExcel.Cells(row, loc_1_mtrqty).Value.ToString) <> "" Then
                            mtrqtyI = Replace(Trim(.Cells(row, loc_1_mtrqty).Value.ToString), "'", "''")
                        Else
                            mtrqtyI = "0"
                        End If
                    Else
                        mtrqtyI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_cft).Value Is Nothing)) Then                 ' CFT
                        If Trim(.Cells(row, loc_1_cft).Value.ToString) <> "" Then
                            cftI = Replace(Trim(.Cells(row, loc_1_cft).Value.ToString), "'", "''")
                        Else
                            cftI = "0"
                        End If
                    Else
                        cftI = "0"
                    End If

                    If (Not (.Cells(row, loc_1_untcde).Value Is Nothing)) Then              ' UM
                        If Trim(.Cells(row, loc_1_untcde).Value.ToString) <> "" Then
                            untcdeI = Replace(Trim(.Cells(row, loc_1_untcde).Value.ToString), "'", "''")
                        Else
                            untcdeI = ""
                        End If
                    Else
                        untcdeI = ""
                    End If

                    If (Not (.Cells(row, loc_1_conftr).Value Is Nothing)) Then              ' Conversion Factor
                        If Trim(.Cells(row, loc_1_conftr).Value.ToString) <> "" Then
                            conftrI = Replace(Trim(.Cells(row, loc_1_conftr).Value.ToString), "'", "''")
                        Else
                            conftrI = "1"
                        End If
                    Else
                        conftrI = "1"
                    End If

                    If (Not (.Cells(row, loc_1_inrmsr).Value Is Nothing)) Then              ' Inner Measurement
                        inrmsrI = Replace(Trim(.Cells(row, loc_1_inrmsr).Value.ToString), "'", "''")
                    Else
                        inrmsrI = ""
                    End If

                    If (Not (.Cells(row, loc_1_mtrmsr).Value Is Nothing)) Then              ' Master Measurement
                        mtrmsrI = Replace(Trim(.Cells(row, loc_1_mtrmsr).Value.ToString), "'", "''")
                    Else
                        mtrmsrI = ""
                    End If

                    If (Not (.Cells(row, loc_1_remark).Value Is Nothing)) Then              ' Remark
                        rmkI = Replace(Trim(.Cells(row, loc_1_remark).Value.ToString), "'", "''")
                    Else
                        rmkI = ""
                    End If

                    If (Not (.Cells(row, loc_1_confirm).Value Is Nothing)) Then             ' Confirm Flag
                        confirmI = Replace(Trim(.Cells(row, loc_1_confirm).Value.ToString), "'", "''")
                    Else
                        confirmI = ""
                    End If

                    If (Not (.Cells(row, loc_1_condat).Value Is Nothing)) Then              ' Confirm Date
                        condatI = Replace(Trim(.Cells(row, loc_1_condat).Value.ToString), "'", "''")
                    Else
                        condatI = ""
                    End If

                    If (Not (.Cells(row, loc_1_period).Value Is Nothing)) Then              ' Period
                        If Trim(.Cells(row, loc_1_period).Value.ToString) <> "" Then
                            periodI = Replace(Trim(.Cells(row, loc_1_period).Value.ToString), "'", "''")
                            periodI = periodI + "-01"
                        Else
                            periodI = "1900-01-01"
                        End If
                    Else
                        periodI = "1900-01-01"
                    End If

                    If (Not (.Cells(row, loc_1_prctrm).Value Is Nothing)) Then              ' Price Term
                        If Trim(.Cells(row, loc_1_prctrm).Value.ToString) <> "" Then
                            prctrmI = Replace(Trim(.Cells(row, loc_1_prctrm).Value.ToString), "'", "''")
                        Else
                            prctrmI = ""
                        End If
                    Else
                        prctrmI = ""
                    End If

                    If (Not (.Cells(row, loc_1_trantrm).Value Is Nothing)) Then             ' Transportation Term
                        If Trim(.Cells(row, loc_1_trantrm).Value.ToString) <> "" Then
                            trantrmI = Replace(Trim(.Cells(row, loc_1_trantrm).Value.ToString), "'", "''")
                        Else
                            trantrmI = ""
                        End If
                    Else
                        trantrmI = ""
                    End If

                    If (Not (.Cells(row, loc_1_pckitr).Value Is Nothing)) Then              ' Packing Instruction
                        If Trim(.Cells(row, loc_1_pckitr).Value.ToString) <> "" Then
                            pckitrI = Replace(Trim(.Cells(row, loc_1_pckitr).Value.ToString), "'", "''")
                        Else
                            pckitrI = ""
                        End If
                    Else
                        pckitrI = ""
                    End If

                    If (Not (.Cells(row, loc_1_inrpck).Value Is Nothing)) Then              ' Inner Packing Measurement
                        If Trim(.Cells(row, loc_1_inrpck).Value.ToString) <> "" Then
                            inrpckI = Replace(Trim(.Cells(row, loc_1_inrpck).Value.ToString), "'", "''")
                        Else
                            inrpckI = ""
                        End If
                    Else
                        inrpckI = ""
                    End If

                    If (Not (.Cells(row, loc_1_mtrpck).Value Is Nothing)) Then              ' Master Packing Measurement
                        If Trim(.Cells(row, loc_1_mtrpck).Value.ToString) <> "" Then
                            mtrpckI = Replace(Trim(.Cells(row, loc_1_mtrpck).Value.ToString), "'", "''")
                        Else
                            mtrpckI = ""
                        End If
                    Else
                        mtrpckI = ""
                    End If
                    If (Not (.Cells(row, loc_1_mat).Value Is Nothing)) Then                 ' Material
                        If Trim(.Cells(row, loc_1_mat).Value.ToString) <> "" Then
                            matI = Replace(Trim(.Cells(row, loc_1_mat).Value.ToString), "'", "''")
                        Else
                            matI = ""
                        End If
                    Else
                        matI = ""
                    End If

                    If (Not (.Cells(row, loc_1_cus1no).Value Is Nothing)) Then              ' Primary Customer Number
                        If Trim(.Cells(row, loc_1_cus1no).Value.ToString) <> "" Then
                            cus1noI = Replace(Trim(.Cells(row, loc_1_cus1no).Value.ToString), "'", "''")
                        Else
                            cus1noI = ""
                        End If
                    Else
                        cus1noI = ""
                    End If
                    If (Not (.Cells(row, loc_1_cus1nam).Value Is Nothing)) Then             ' Primary Customer Name
                        If Trim(.Cells(row, loc_1_cus1nam).Value.ToString) <> "" Then
                            cus1namI = Replace(Trim(.Cells(row, loc_1_cus1nam).Value.ToString), "'", "''")
                        Else
                            cus1namI = ""
                        End If
                    Else
                        cus1namI = ""
                    End If

                    If (Not (.Cells(row, loc_1_cus2no).Value Is Nothing)) Then              ' Secondary Customer Number
                        If Trim(.Cells(row, loc_1_cus2no).Value.ToString) <> "" Then
                            cus2noI = Replace(Trim(.Cells(row, loc_1_cus2no).Value.ToString), "'", "''")
                        Else
                            cus2noI = ""
                        End If
                    Else
                        cus2noI = ""
                    End If

                    If (Not (.Cells(row, loc_1_cus2nam).Value Is Nothing)) Then             ' Secondary Customer Name
                        If Trim(.Cells(row, loc_1_cus2nam).Value.ToString) <> "" Then
                            cus2namI = Replace(Trim(.Cells(row, loc_1_cus2nam).Value.ToString), "'", "''")
                        Else
                            cus2namI = ""
                        End If
                    Else
                        cus2namI = ""
                    End If

                    If (Not (.Cells(row, loc_1_tempflg).Value Is Nothing)) Then             ' Temporary Item Flag
                        If Trim(.Cells(row, loc_1_tempflg).Value.ToString) <> "" Then
                            tempflgI = Replace(Trim(.Cells(row, loc_1_tempflg).Value.ToString), "'", "''")
                        Else
                            tempflgI = "Y"
                        End If
                    Else
                        tempflgI = "Y"
                    End If

                    If (Not (.Cells(row, loc_1_lnecde).Value Is Nothing)) Then             ' Line Code
                        If Trim(.Cells(row, loc_1_lnecde).Value.ToString) <> "" Then
                            lnecdeI = Replace(Trim(.Cells(row, loc_1_lnecde).Value.ToString), "'", "''")
                        Else
                            lnecdeI = ""
                        End If
                    Else
                        lnecdeI = ""
                    End If

                    If (Not (.Cells(row, loc_1_catlvl4).Value Is Nothing)) Then             ' Category 4
                        If Trim(.Cells(row, loc_1_catlvl4).Value.ToString) <> "" Then
                            catlvl4I = Replace(Trim(.Cells(row, loc_1_catlvl4).Value.ToString), "'", "''")
                        Else
                            catlvl4I = ""
                        End If
                    Else
                        catlvl4I = ""
                    End If

                    ' Determine Item Type
                    itmtypI = "REG"
                    .Sheets(3).Select()
                    Dim i As Integer = 3
                    While (Not (.Cells(i, 1).Value Is Nothing))
                        If Trim(.Cells(i, 1).Value.ToString) <> "" Then
                            If venitmI = Trim(.Cells(i, 1).Value.ToString) Then
                                itmtypI = "ASS"
                            End If
                        End If
                        i = i + 1
                    End While
                    .Sheets(sheet).Select()

                ElseIf (sheet = 2 And Not (.Cells(row, 1).Value Is Nothing)) Then
                    If (Not (.Cells(row, loc_2_venitm).Value Is Nothing)) Then              ' Item Number
                        If Trim(.Cells(row, loc_2_venitm).Value.ToString) <> "" Then
                            venitmB = Replace(Trim(.Cells(row, loc_2_venitm).Value.ToString), "'", "''")
                        Else
                            venitmB = ""
                        End If
                    Else
                        venitmB = ""
                    End If

                    If (Not (.Cells(row, loc_2_acsno).Value Is Nothing)) Then               ' BOM Number
                        If Trim(.Cells(row, loc_2_acsno).Value.ToString) <> "" Then
                            acsnoB = Replace(Trim(.Cells(row, loc_2_acsno).Value.ToString), "'", "''")
                        Else
                            acsnoB = ""
                        End If
                    Else
                        acsnoB = ""
                    End If

                    If (Not (.Cells(row, loc_2_itmdsc).Value Is Nothing)) Then              ' Item Description
                        If Trim(.Cells(row, loc_2_itmdsc).Value.ToString) <> "" Then
                            itmdscB = Replace(Trim(.Cells(row, loc_2_itmdsc).Value.ToString), "'", "''")
                        Else
                            itmdscB = ""
                        End If
                    Else
                        itmdscB = ""
                    End If

                    If (Not (.Cells(row, loc_2_qty).Value Is Nothing)) Then                 ' Quantity Information
                        If Trim(.Cells(row, loc_2_qty).Value.ToString) <> "" Then
                            qtyB = Replace(Trim(.Cells(row, loc_2_qty).Value.ToString), "'", "''")
                            qtyB = qtyB.Substring(0, qtyB.IndexOf(" "))
                        Else
                            qtyB = ""
                        End If
                    Else
                        qtyB = ""
                    End If

                    If (Not (.Cells(row, loc_2_vend).Value Is Nothing)) Then                ' Vendor Information
                        If Trim(.Cells(row, loc_2_vend).Value.ToString) <> "" Then
                            veninfB = Replace(Trim(.Cells(row, loc_2_vend).Value.ToString), "'", "''")
                        Else
                            veninfB = ""
                        End If
                    Else
                        veninfB = ""
                    End If

                    If (Not (.Cells(row, loc_2_bomprc).Value Is Nothing)) Then              ' Purchase Cost
                        If Trim(.Cells(row, loc_2_bomprc).Value.ToString) <> "" Then
                            bomprcB = Replace(Trim(.Cells(row, loc_2_bomprc).Value.ToString), "'", "''")
                        Else
                            bomprcB = "0"
                        End If
                    Else
                        bomprcB = "0"
                    End If

                    If (Not (.Cells(row, loc_2_prccur).Value Is Nothing)) Then               ' Purchase Cost Currency
                        If Trim(.Cells(row, loc_2_prccur).Value.ToString) <> "" Then
                            prccurB = Replace(Trim(.Cells(row, loc_2_prccur).Value.ToString), "'", "''")
                        Else
                            prccurB = ""
                        End If
                    Else
                        prccurB = ""
                    End If

                    If (Not (.Cells(row, loc_2_bomcst).Value Is Nothing)) Then              ' BOM Cost
                        If Trim(.Cells(row, loc_2_bomcst).Value.ToString) <> "" Then
                            bomcstB = Replace(Trim(.Cells(row, loc_2_bomcst).Value.ToString), "'", "''")
                        Else
                            bomcstB = "0"
                        End If
                    Else
                        bomcstB = "0"
                    End If

                    If (Not (.Cells(row, loc_2_cstcur).Value Is Nothing)) Then               ' BOM Cost Currency
                        If Trim(.Cells(row, loc_2_cstcur).Value.ToString) <> "" Then
                            cstcurB = Replace(Trim(.Cells(row, loc_2_cstcur).Value.ToString), "'", "''")
                        Else
                            cstcurB = ""
                        End If
                    Else
                        cstcurB = ""
                    End If

                    If (Not (.Cells(row, loc_2_period).Value Is Nothing)) Then              ' Period
                        If Trim(.Cells(row, loc_2_period).Value.ToString) <> "" Then
                            periodB = Replace(Trim(.Cells(row, loc_2_period).Value.ToString), "'", "''")
                            periodB = periodB + "-01"
                        Else
                            periodB = "1900-01-01"
                        End If
                    Else
                        periodB = "1900-01-01"
                    End If

                ElseIf (sheet = 3 And Not (.Cells(row, 1).Value Is Nothing)) Then
                    If (Not (.Cells(row, loc_3_venitm).Value Is Nothing)) Then              ' Item Number
                        If Trim(.Cells(row, loc_3_venitm).Value.ToString) <> "" Then
                            venitmA = Replace(Trim(.Cells(row, loc_3_venitm).Value.ToString), "'", "''")
                        Else
                            venitmA = ""
                        End If
                    Else
                        venitmA = ""
                    End If

                    If (Not (.Cells(row, loc_3_acsno).Value Is Nothing)) Then               ' BOM Number
                        If Trim(.Cells(row, loc_3_acsno).Value.ToString) <> "" Then
                            acsnoA = Replace(Trim(.Cells(row, loc_3_acsno).Value.ToString), "'", "''")
                        Else
                            acsnoA = ""
                        End If
                    Else
                        acsnoA = ""
                    End If

                    If (Not (.Cells(row, loc_3_itmdsc).Value Is Nothing)) Then              ' Item Description
                        If Trim(.Cells(row, loc_3_itmdsc).Value.ToString) <> "" Then
                            itmdscA = Replace(Trim(.Cells(row, loc_3_itmdsc).Value.ToString), "'", "''")
                        Else
                            itmdscA = ""
                        End If
                    Else
                        itmdscA = ""
                    End If

                    If (Not (.Cells(row, loc_3_colcde).Value Is Nothing)) Then              ' Colour Code
                        If Trim(.Cells(row, loc_3_colcde).Value.ToString) <> "" Then
                            colcdeA = Replace(Trim(.Cells(row, loc_3_colcde).Value.ToString), "'", "''")
                        Else
                            colcdeA = ""
                        End If
                    Else
                        colcdeA = ""
                    End If

                    If (Not (.Cells(row, loc_3_untcde).Value Is Nothing)) Then              ' UM
                        If Trim(.Cells(row, loc_3_untcde).Value.ToString) <> "" Then
                            untcdeA = Replace(Trim(.Cells(row, loc_3_untcde).Value.ToString), "'", "''")
                        Else
                            untcdeA = ""
                        End If
                    Else
                        untcdeA = ""
                    End If

                    If (Not (.Cells(row, loc_3_conftr).Value Is Nothing)) Then              ' Conversion Factor
                        If Trim(.Cells(row, loc_3_conftr).Value.ToString) <> "" Then
                            conftrA = Replace(Trim(.Cells(row, loc_3_conftr).Value.ToString), "'", "''")
                        Else
                            conftrA = "1"
                        End If
                    Else
                        conftrA = "1"
                    End If

                    If (Not (.Cells(row, loc_3_inrqty).Value Is Nothing)) Then              ' Inner Quantity
                        If Trim(.Cells(row, loc_3_inrqty).Value.ToString) <> "" Then
                            inrqtyA = Replace(Trim(.Cells(row, loc_3_inrqty).Value.ToString), "'", "''")
                        Else
                            inrqtyA = "0"
                        End If
                    Else
                        inrqtyA = "0"
                    End If

                    If (Not (.Cells(row, loc_3_mtrqty).Value Is Nothing)) Then              ' Master Quantity
                        If Trim(.Cells(row, loc_3_mtrqty).Value.ToString) <> "" Then
                            mtrqtyA = Replace(Trim(.Cells(row, loc_3_mtrqty).Value.ToString), "'", "''")
                        Else
                            mtrqtyA = "0"
                        End If
                    Else
                        mtrqtyA = "0"
                    End If

                    If (Not (.Cells(row, loc_3_period).Value Is Nothing)) Then              ' Master Quantity
                        If Trim(.Cells(row, loc_3_period).Value.ToString) <> "" Then
                            periodA = Replace(Trim(.Cells(row, loc_3_period).Value.ToString), "'", "''")
                            periodA = periodA + "-01"
                        Else
                            periodA = "1900-01-01"
                        End If
                    Else
                        periodA = "1900-01-01"
                    End If
                End If


                If sheet = 1 Then                                                           ' ITEM Spreadsheet
                    If Not (.Cells(3, 1).Value Is Nothing) Then
                        If Trim(.Cells(row, loc_1_venitm).Value.ToString) <> "" Then
                            gspStr = "sp_insert_IMPCITMDAT '" & "UCPP" & "','" & venitmI & "','" & tempflgI & _
                                     "','" & filSource.Items(filCount) & "','" & xlsDate & _
                                     "','" & cus1noI & "','" & cus1namI & "','" & cus2noI & "','" & cus2namI & _
                                     "','" & engdscI & "','" & lnecdeI & "','" & catlvl4I & "','" & untcdeI & _
                                     "','" & inrqtyI & "','" & mtrqtyI & "','" & inrmsrI & "','" & mtrmsrI & _
                                     "','" & cftI & "','" & conftrI & "','" & "HKD" & "','" & ftycstI & _
                                     "','" & ftycstAI & "','" & ftycstBI & "','" & ftycstCI & "','" & ftycstDI & _
                                     "','" & ftycstTranI & "','" & ftycstPackI & "','" & rmkI & "','" & confirmI & _
                                     "','" & condatI & "','" & periodI & "','" & prctrmI & "','" & trantrmI & _
                                     "','" & pckitrI & "','" & inrpckI & "','" & mtrpckI & "','" & matI & _
                                     "','" & itmseqI & "','" & itmtypI & "','" & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading IMXLS006 sp_IMPCITMDAT : " & rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf sheet = 2 Then
                    If Not (.Cells(3, 1).Value Is Nothing) Then
                        If Trim(.Cells(row, loc_2_venitm).Value.ToString) <> "" Then
                            gspStr = "sp_insert_IMPCBOMDAT '" & "UCPP" & "','" & venitmB & "','" & acsnoB & _
                                     "','" & itmdscB & "','" & qtyB & "','" & veninfB & "','" & bomprcB & _
                                     "','" & prccurB & "','" & bomcstB & "','" & cstcurB & "','" & periodB & _
                                     "','" & filSource.Items(filCount) & "','" & xlsDate & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading IMXLS006 sp_IMPCBOMDAT : " & rtnStr)
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf sheet = 3 Then
                    If Not (.Cells(3, 1).Value Is Nothing) Then
                        If Trim(.Cells(row, loc_3_venitm).Value.ToString) <> "" Then
                            gspStr = "sp_insert_IMPCASSDAT '" & "UCPP" & "','" & venitmA & "','" & acsnoA & _
                                     "','" & itmdscA & "','" & colcdeA & "','" & untcdeA & "','" & conftrA & _
                                     "','" & inrqtyA & "','" & mtrqtyA & "','" & periodA & _
                                     "','" & filSource.Items(filCount) & "','" & xlsDate & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading IMXLS006 sp_IMPCASSDAT : " & rtnStr)
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                '========================================
                '===== Go to Next Row or Next Sheet =====
                '========================================
                If (Not (.Cells(row + 1, 1).Value Is Nothing)) Then '*** Go to the next row
                    row = row + 1
                    GoTo ReadRow
                Else
                    If sheet = 1 Then               ' Goto "BOM" Spreadsheet
                        sheet = 2
                        row = 3
                        GoTo ReadRow
                    ElseIf sheet = 2 Then           ' Goto "ASS" Spreadsheet
                        sheet = 3
                        row = 3
                        GoTo ReadRow
                    End If
                End If

                myExcel.Workbooks.Close()
                myExcel.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
                myExcel = Nothing

                ' move file to new directory....
                moveFile(filSource.Items(filCount), xlsPath, ".old")

                filCount = filCount + 1

            End With

            GoTo Next_Record

Data_Error:
            On Error Resume Next
            myExcel.Workbooks.Close()
            myExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
            myExcel = Nothing

            setErrMsg("An error has occured for " & filSource.Items(filCount) & "... Aborting Upload")
            moveFile(filSource.Items(filCount), xlsPath, ".err")

            filCount = filCount + 1
            GoTo Next_Record

Next_Record:

        Loop

        gspStr = "sp_IMPCITMDAT_itmtyp"
        rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMXLS006 sp_IMPCITMDAT_itmtyp : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_update_IMPCITMDAT_UM"
        rtnLong = execute_SQLStatement(gspStr, rs_data, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMXLS005 sp_update_IMPCITMDAT_UM : " & rtnStr)
            Exit Sub
        End If

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        setErrMsg("Request Complete!")
        Me.Cursor = Windows.Forms.Cursors.Default
        cmdRefresh.PerformClick()

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

    Private Sub moveFile(ByVal xlsFile As String, ByVal curPath As String, ByVal extension As String)
        Dim strFileCopy As String

        If Dir(filSourcePath + "\ItemExcelOldABCD", vbDirectory) = "" Then
            MkDir(filSourcePath + "\ItemExcelOldABCD")
        End If
        strFileCopy = filSourcePath & IIf(filSourcePath.Substring(filSourcePath.Length - 1, 1) = "\", "", "\") & _
                  "ItemExcelOldABCD\" & LTrim(xlsFile.Substring(0, xlsFile.Length - 4)) & extension

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
        Err.Clear()
        Me.Cursor = Windows.Forms.Cursors.Default
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
End Class