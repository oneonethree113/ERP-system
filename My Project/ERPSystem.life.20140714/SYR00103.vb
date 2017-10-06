Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class SYR00103
    Dim rs_VNTRDTRM As New DataSet

    Private Sub SYR00103_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboVendor.Text = "All"
        FillComboComGrp()
        Call Formstartup(Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Dim vendorno As String
        Me.Cursor = Cursors.WaitCursor

        If cboVendor.Text = "All" Then
            gspStr = "sp_list_SYR00103 '" & _
                 gsCompany & "',''"
        Else
            vendorno = cboVendor.Text.Trim.Split("-")(0)
            gspStr = "sp_list_SYR00103 '" & gsCompany & "','" & vendorno & "'"
        End If

        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYR00103 #001 sp_list_SYR00103 : " & rtnStr)
        Else
            If rs.RecordCount = 0 Then
                MsgBox("No record found!")
            Else
                Call ExportToExcel(rs)
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExportToExcel(ByVal rs_EXCEL As ADODB.Recordset)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim strCocde As String = String.Empty

        If rs_EXCEL.RecordCount >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim i As Integer
        For i = 0 To rs_EXCEL.Fields.Count - 1
            xlsApp.Cells(1, i + 1) = rs_EXCEL.Fields(i).Name
        Next

        xlsWS.Rows(1).Font.Bold = True

        xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL)
        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()
    End Sub

    Private Sub FillComboComGrp()
        Dim rs_comgrp As New DataSet
        Dim i As Integer
        cboVendor.Items.Clear()
        Try
            gspStr = "sp_list_VNTRDTRM '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_comgrp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_list_VNTRDTRM : " & rtnStr)
            Else
                Me.cboVendor.Items.Add("All")
                Dim dr() As DataRow = rs_comgrp.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    Me.cboVendor.Items.Add(dr(i).Item("vtt_venno").ToString + " - " + dr(i).Item("vtt_vensna").ToString)
                Next i
            End If
        Finally
            rs_comgrp = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class