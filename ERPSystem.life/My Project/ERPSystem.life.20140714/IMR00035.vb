Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class IMR00035

    Dim rs_IMR00035 As New DataSet

    Private Sub IMR00035_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        If gsFlgCst = 1 Then
            chkIntRpt.Enabled = True
            chkIntRpt.Checked = True
        Else
            chkIntRpt.Enabled = False
        End If

        If gsFlgCstExt = 1 Then
            chkExtRpt.Enabled = True
            chkExtRpt.Checked = True
        Else
            chkExtRpt.Enabled = False
        End If

        Dim month As String
        Dim day As String
        month = "0" + Date.Today.Month.ToString
        day = "0" + Date.Today.Day.ToString
        txt_S_UpddatTo.Text = month.Substring(month.Length - 2, 2) + "/" + day.Substring(day.Length - 2, 2) + "/" + Date.Today.Year.ToString
        txt_S_UpddatFm.Text = month.Substring(month.Length - 2, 2) + "/" + day.Substring(day.Length - 2, 2) + "/" + (Date.Today.Year - 2).ToString

        txt_S_ItmNo.Focus()
        txt_S_ItmNo.Select()
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        If Len(Trim(txt_S_ItmNo.Text)) > 1000 Then
            MsgBox("Item Number list exceeds maximum allowable length (1000 Characters).", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_ItmNo.Focus()
            txt_S_ItmNo.SelectAll()
            Exit Sub
        End If

        If txt_S_UpddatFm.Text <> "  /  /" Then
            If IsDate(txt_S_UpddatFm) Then
                MsgBox("Invalid Start Date", MsgBoxStyle.Exclamation, "Invalid Input")
                txt_S_UpddatFm.Focus()
                txt_S_UpddatFm.SelectAll()
                Exit Sub
            End If
        End If

        If txt_S_UpddatTo.Text <> "  /  /" Then
            If IsDate(txt_S_UpddatTo) Then
                MsgBox("Invalid End Date", MsgBoxStyle.Exclamation, "Invalid Input")
                txt_S_UpddatTo.Focus()
                txt_S_UpddatTo.SelectAll()
                Exit Sub
            End If
        End If

        If Mid(txt_S_UpddatFm.Text, 7) > Mid(txt_S_UpddatTo.Text, 7) Then
            MsgBox("Create Date: End Date < Start Date (YY)", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_UpddatFm.Focus()
            txt_S_UpddatFm.Select(6, 4)
            Exit Sub
        ElseIf Mid(txt_S_UpddatFm.Text, 7) = Mid(txt_S_UpddatTo.Text, 7) Then
            If txt_S_UpddatFm.Text.Substring(0, 2) > txt_S_UpddatTo.Text.Substring(0, 2) Then
                MsgBox("Create Date: End Date < Start Date (MM)", MsgBoxStyle.Exclamation, "Invalid Input")
                txt_S_UpddatFm.Focus()
                txt_S_UpddatFm.Select(0, 2)
                Exit Sub
            ElseIf txt_S_UpddatFm.Text.Substring(0, 2) = txt_S_UpddatTo.Text.Substring(0, 2) Then
                If txt_S_UpddatFm.Text.Substring(3, 2) > txt_S_UpddatTo.Text.Substring(3, 2) Then
                    MsgBox("Create Date: End Date < Start Date (DD)", MsgBoxStyle.Exclamation, "Invalid Input")
                    txt_S_UpddatFm.Focus()
                    txt_S_UpddatFm.Select(3, 2)
                    Exit Sub
                End If
            End If
        End If

        Dim itmno As String
        Dim upldatto As String
        Dim upldatFrom As String

        itmno = txt_S_ItmNo.Text
        itmno = itmno.Replace("'", "''")

        If txt_S_UpddatFm.Text = "  /  /" Then
            upldatFrom = "01/01/1900"
        Else
            upldatFrom = txt_S_UpddatFm.Text
        End If

        If txt_S_UpddatTo.Text = "  /  /" Then
            upldatto = "01/01/1900"
        Else
            upldatto = txt_S_UpddatTo.Text
        End If

        If upldatFrom = "01/01/1900" And upldatto = "01/01/1900" Then
            MsgBox("Create Date must have values!", MsgBoxStyle.Exclamation, "Invalid Input")
            txt_S_UpddatFm.Focus()
            txt_S_UpddatFm.SelectAll()
            Exit Sub
        End If

        Dim rptmode As String
        If chkIntRpt.Checked = True And chkExtRpt.Checked = False Then
            rptmode = "INT"
        ElseIf chkIntRpt.Checked = False And chkExtRpt.Checked = True Then
            rptmode = "EXT"
        ElseIf chkIntRpt.Checked = True And chkExtRpt.Checked = True Then
            rptmode = "ALL"
        Else
            MsgBox("Please select a report mode", MsgBoxStyle.Exclamation, "Invalid Input")
            rptmode = ""
            Exit Sub
        End If

        gspStr = "sp_list_IMR00035 'UCPP','" & itmno & "','" & upldatFrom & "','" & upldatto & "','" & rptmode & "','" & gsUsrID & "'"
        'gspStr = "sp_list_IMR00035 'UCPP','" & itmno & "','" & upldatFrom & "','" & upldatto & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00035, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00035 sp_list_IMR00035 : " & rtnStr)
            Exit Sub
        End If

        If rs_IMR00035.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!", MsgBoxStyle.Information, "Information")
        Else
            ExportExcel()
        End If
    End Sub

    Private Sub ExportExcel()
        If rs_IMR00035.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Dim strCompany As String
        Dim strTitle As String

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        strCompany = "UNITED CHINESE GROUP"
        strTitle = "PRICE CHANGE REPORT"

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        With xlsApp
            'Header Initialization
            .Range(.Cells(1, 1), .Cells(2, 1)).MergeCells = True
            .Range(.Cells(1, 1), .Cells(2, 1)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 1), .Cells(2, 1)).Value = "Item No."
            .Range(.Cells(1, 2), .Cells(2, 2)).MergeCells = True
            .Range(.Cells(1, 2), .Cells(2, 2)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 2), .Cells(2, 2)).Value = "Item Type"
            .Range(.Cells(1, 3), .Cells(2, 3)).MergeCells = True
            .Range(.Cells(1, 3), .Cells(2, 3)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 3), .Cells(2, 3)).Value = "DV"
            .Range(.Cells(1, 4), .Cells(2, 4)).MergeCells = True
            .Range(.Cells(1, 4), .Cells(2, 4)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 4), .Cells(2, 4)).Value = "PV"
            .Range(.Cells(1, 5), .Cells(2, 5)).MergeCells = True
            .Range(.Cells(1, 5), .Cells(2, 5)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 5), .Cells(2, 5)).Value = "UM"
            .Range(.Cells(1, 6), .Cells(2, 6)).MergeCells = True
            .Range(.Cells(1, 6), .Cells(2, 6)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 6), .Cells(2, 6)).Value = "Inr"
            .Range(.Cells(1, 7), .Cells(2, 7)).MergeCells = True
            .Range(.Cells(1, 7), .Cells(2, 7)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 7), .Cells(2, 7)).Value = "Mtr"
            .Range(.Cells(1, 8), .Cells(2, 8)).MergeCells = True
            .Range(.Cells(1, 8), .Cells(2, 8)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 8), .Cells(2, 8)).Value = "CFT"
            .Range(.Cells(1, 9), .Cells(2, 9)).MergeCells = True
            .Range(.Cells(1, 9), .Cells(2, 9)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 9), .Cells(2, 9)).Value = "Pri Cus"
            .Range(.Cells(1, 10), .Cells(2, 10)).MergeCells = True
            .Range(.Cells(1, 10), .Cells(2, 10)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 10), .Cells(2, 10)).Value = "Sec Cus"
            .Range(.Cells(1, 11), .Cells(2, 11)).MergeCells = True
            .Range(.Cells(1, 11), .Cells(2, 11)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 11), .Cells(2, 11)).WrapText = True
            .Range(.Cells(1, 11), .Cells(2, 11)).Value = "FTY Price Term"
            .Range(.Cells(1, 12), .Cells(2, 12)).MergeCells = True
            .Range(.Cells(1, 12), .Cells(2, 12)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 12), .Cells(2, 12)).WrapText = True
            .Range(.Cells(1, 12), .Cells(2, 12)).Value = "HK Price Term"

            .Range(.Cells(1, 13), .Cells(2, 13)).MergeCells = True
            .Range(.Cells(1, 13), .Cells(2, 13)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 13), .Cells(2, 13)).WrapText = True
            .Range(.Cells(1, 13), .Cells(2, 13)).Value = "Transport" & Environment.NewLine & "Term"

            .Range(.Cells(1, 14), .Cells(2, 14)).MergeCells = True
            .Range(.Cells(1, 14), .Cells(2, 14)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 14), .Cells(2, 14)).WrapText = True
            .Range(.Cells(1, 14), .Cells(2, 14)).Value = "Price Change Date"
            .Range(.Cells(1, 15), .Cells(2, 15)).MergeCells = True
            .Range(.Cells(1, 15), .Cells(2, 15)).VerticalAlignment = Excel.Constants.xlCenter
            .Range(.Cells(1, 15), .Cells(2, 15)).WrapText = True
            .Range(.Cells(1, 15), .Cells(2, 15)).Value = "Price Change Reason"

            .Range(.Cells(1, 16), .Cells(1, 42)).MergeCells = True
            .Range(.Cells(1, 16), .Cells(1, 42)).Value = "Before"
            .Cells(2, 16) = "Effective Date"
            .Cells(2, 17) = "Expiry Date"
            .Cells(2, 18) = "CCY"
            .Cells(2, 19) = "FTY Cst TTL"
            .Cells(2, 20) = "FTY Cst A"
            .Cells(2, 21) = "FTY Cst B"
            .Cells(2, 22) = "FTY Cst C"
            .Cells(2, 23) = "FTY Cst D"
            .Cells(2, 24) = "FTY Cst Tran"
            .Cells(2, 25) = "FTY Cst Pack"
            .Cells(2, 26) = "FTY Prc TTL"
            .Cells(2, 27) = "FTY Prc A"
            .Cells(2, 28) = "FTY Prc B"
            .Cells(2, 29) = "FTY Prc C"
            .Cells(2, 30) = "FTY Prc D"
            .Cells(2, 31) = "FTY Prc Tran"
            .Cells(2, 32) = "FTY Prc Pack"
            .Cells(2, 33) = "BOM Cst"
            .Cells(2, 34) = "TTL Cst"
            .Cells(2, 35) = "Neg Prc"
            .Cells(2, 36) = "Markup"
            .Cells(2, 37) = "Basic CCY"
            .Cells(2, 38) = "Item Prc"
            .Cells(2, 39) = "BOM Prc"
            .Cells(2, 40) = "Basic Prc"
            .Cells(2, 41) = "Period"
            .Cells(2, 42) = "Cost Change Date"
            .Range(.Cells(1, 43), .Cells(1, 69)).MergeCells = True
            .Range(.Cells(1, 43), .Cells(1, 69)).Value = "After"
            .Cells(2, 43) = "Effective Date"
            .Cells(2, 44) = "Expiry Date"
            .Cells(2, 45) = "CCY"
            .Cells(2, 46) = "FTY Cst TTL"
            .Cells(2, 47) = "FTY Cst A"
            .Cells(2, 48) = "FTY Cst B"
            .Cells(2, 49) = "FTY Cst C"
            .Cells(2, 50) = "FTY Cst D"
            .Cells(2, 51) = "FTY Cst Tran"
            .Cells(2, 52) = "FTY Cst Pack"
            .Cells(2, 53) = "FTY Prc TTL"
            .Cells(2, 54) = "FTY Prc A"
            .Cells(2, 55) = "FTY Prc B"
            .Cells(2, 56) = "FTY Prc C"
            .Cells(2, 57) = "FTY Prc D"
            .Cells(2, 58) = "FTY Prc Tran"
            .Cells(2, 59) = "FTY Prc Pack"
            .Cells(2, 60) = "BOM Cst"
            .Cells(2, 61) = "TTL Cst"
            .Cells(2, 62) = "Neg Prc"
            .Cells(2, 63) = "Markup"
            .Cells(2, 64) = "Basic CCY"
            .Cells(2, 65) = "Item Prc"
            .Cells(2, 66) = "BOM Prc"
            .Cells(2, 67) = "Basic Prc"
            .Cells(2, 68) = "Period"
            .Cells(2, 69) = "Cost Change Date"
        End With

        With xlsApp
            For i As Integer = 0 To rs_IMR00035.Tables("RESULT").Rows.Count - 1
                .Cells(3 + i, 1) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_itmno").ToString
                .Cells(3 + i, 2) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_typ").ToString
                .Cells(3 + i, 3) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_venno").ToString
                .Cells(3 + i, 4) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_prdven").ToString
                .Cells(3 + i, 5) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_pckunt").ToString
                .Cells(3 + i, 6) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_inrqty").ToString
                .Cells(3 + i, 7) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_mtrqty").ToString
                .Cells(3 + i, 8) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_cft").ToString
                .Cells(3 + i, 9) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_cus1no").ToString
                .Cells(3 + i, 10) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_cus2no").ToString
                .Cells(3 + i, 11) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprctrm").ToString
                .Cells(3 + i, 12) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_hkprctrm").ToString
                .Cells(3 + i, 13) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_trantrm").ToString
                .Cells(3 + i, 14) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_chgdat").ToString
                .Cells(3 + i, 15) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_chgreason").ToString
                .Cells(3 + i, 16) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_effdat_before").ToString
                .Cells(3 + i, 17) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_expdat_before").ToString
                .Cells(3 + i, 18) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_curcde_before").ToString
                .Cells(3 + i, 19) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycst_before").ToString
                .Cells(3 + i, 20) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstA_before").ToString
                .Cells(3 + i, 21) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstB_before").ToString
                .Cells(3 + i, 22) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstC_before").ToString
                .Cells(3 + i, 23) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstD_before").ToString
                .Cells(3 + i, 24) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstTran_before").ToString
                .Cells(3 + i, 25) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstPack_before").ToString
                .Cells(3 + i, 26) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprc_before").ToString
                .Cells(3 + i, 27) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcA_before").ToString
                .Cells(3 + i, 28) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcB_before").ToString
                .Cells(3 + i, 29) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcC_before").ToString
                .Cells(3 + i, 30) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcD_before").ToString
                .Cells(3 + i, 31) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcTran_before").ToString
                .Cells(3 + i, 32) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcPack_before").ToString
                .Cells(3 + i, 33) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bomcst_before").ToString
                .Cells(3 + i, 34) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ttlcst_before").ToString
                .Cells(3 + i, 35) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_negprc_before").ToString
                .Cells(3 + i, 36) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_fmlopt_before").ToString
                .Cells(3 + i, 37) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bcurcde_before").ToString
                .Cells(3 + i, 38) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_itmprc_before").ToString
                .Cells(3 + i, 39) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bomprc_before").ToString
                .Cells(3 + i, 40) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_basprc_before").ToString
                .Cells(3 + i, 41) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_period_before").ToString
                .Cells(3 + i, 42) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_cstchgdat_before").ToString
                .Cells(3 + i, 43) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_effdat_after").ToString
                .Cells(3 + i, 44) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_expdat_after").ToString
                .Cells(3 + i, 45) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_curcde_after").ToString
                .Cells(3 + i, 46) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycst_after").ToString
                .Cells(3 + i, 47) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstA_after").ToString
                .Cells(3 + i, 48) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstB_after").ToString
                .Cells(3 + i, 49) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstC_after").ToString
                .Cells(3 + i, 50) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstD_after").ToString
                .Cells(3 + i, 51) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstTran_after").ToString
                .Cells(3 + i, 52) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftycstPack_after").ToString
                .Cells(3 + i, 53) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprc_after").ToString
                .Cells(3 + i, 54) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcA_after").ToString
                .Cells(3 + i, 55) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcB_after").ToString
                .Cells(3 + i, 56) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcC_after").ToString
                .Cells(3 + i, 57) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcD_after").ToString
                .Cells(3 + i, 58) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcTran_after").ToString
                .Cells(3 + i, 59) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ftyprcPack_after").ToString
                .Cells(3 + i, 60) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bomcst_after").ToString
                .Cells(3 + i, 61) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_ttlcst_after").ToString
                .Cells(3 + i, 62) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_negprc_after").ToString
                .Cells(3 + i, 63) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_fmlopt_after").ToString
                .Cells(3 + i, 64) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bcurcde_after").ToString
                .Cells(3 + i, 65) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_itmprc_after").ToString
                .Cells(3 + i, 66) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_bomprc_after").ToString
                .Cells(3 + i, 67) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_basprc_after").ToString
                .Cells(3 + i, 68) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_period_after").ToString
                .Cells(3 + i, 69) = rs_IMR00035.Tables("RESULT").Rows(i)("imu_cstchgdat_after").ToString
            Next
        End With

        With xlsApp
            '.Range(.Cells(7, 1), .Cells(7, 1)).ColumnWidth = 15
            '.Range(.Cells(7, 2), .Cells(7, 2)).ColumnWidth = 5.57
            '.Range(.Cells(7, 3), .Cells(1, 7)).ColumnWidth = 4.57
            .Columns("A:BQ").EntireColumn.AutoFit()
            .Columns(13).ColumnWidth = 10
            .Columns("A:BQ").EntireColumn.HorizontalAlignment = Excel.Constants.xlCenter
            .Rows("1:2").Font.Bold = True
        End With

        xlsApp.Visible = True

        ' Release reference
        rs_IMR00035 = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmd_S_ItmNoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNoAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text
        frmComSearch.cmdSVClear.Enabled = False
        frmComSearch.cmdPVClear.Enabled = False
        frmComSearch.cmdAllClear.Enabled = False

        frmComSearch.show_frmS(Me.cmd_S_ItmNoAll)
    End Sub

    Private Sub highlight_date(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_UpddatTo.GotFocus, txt_S_UpddatFm.GotFocus
        'If sender.Text.ToString.Substring(0, 2) <> "  " Then
        sender.SelectAll()
        'End If
    End Sub
End Class