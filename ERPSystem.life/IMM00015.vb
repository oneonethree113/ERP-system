Imports System.IO
Imports Microsoft.Office.Interop

Public Class IMM00015

    Const xls_IMASSEXDAT As Integer = 3
    Const xls_IMBOMEXDAT As Integer = 2
    Const xls_IMITMEXDAT As Integer = 1
    Const xls_IMMBDEXDAT As Integer = 4
    Const xls_RowOffset As Integer = 2
    Const xls_RowOffset_IMITMEXDAT As Integer = 4

    Const dir_export As String = "C:\IM XLS"
    Const tmp_ext As String = ".xls"
    Const tmp_filname As String = "External Item Excel Template v37_3"
    Const tmp_version As String = "37.0.0"

    Dim recordStatus As Boolean

    Dim rs_Export_IMASSEXDAT As DataSet
    Dim rs_Export_IMBOMEXDAT As DataSet
    Dim rs_Export_IMITMEXDAT As DataSet
    Dim rs_Export_IMMBDEXDAT As DataSet
    Dim rs_Item_IMASSEXDAT As DataSet
    Dim rs_Item_IMBOMEXDAT As DataSet
    Dim rs_Item_IMITMEXDAT As DataSet
    Dim rs_Item_IMMBDEXDAT As DataSet

    Dim oldCI As Globalization.CultureInfo

    Dim dgExport_Sel As Integer
    Dim dgItem_Sel As Integer

    Private Sub IMM00015_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        setStatus("INIT")
    End Sub

    Private Sub setStatus(ByVal mode As String)
        Select Case UCase(mode)
            Case "INIT"
                mmdAdd.Enabled = True
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = False
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdExit.Enabled = True

                mmdPrint.Enabled = False
                mmdAttach.Enabled = False
                mmdFunction.Enabled = False
                mmdLink.Enabled = False

                grpItem.Enabled = False
                txtItmNo.Enabled = False
                cmdItmSearch.Enabled = False
                cmdItmClr.Enabled = False
                cmdItmAll.Enabled = False
                cmdItmAdd.Enabled = False
                dgItem.Enabled = False


                txtItmNo.Text = ""
                dgItem.DataSource = Nothing

                grpExport.Enabled = False
                txtItmCount.Enabled = False
                cmdXLSClr.Enabled = False
                cmdXLSAll.Enabled = False
                cmdXLSRemove.Enabled = False
                txtFilNam.Enabled = False
                cmdFilNamReset.Enabled = False
                cmdExport.Enabled = False
                dgExport.Enabled = False

                txtItmCount.Text = ""
                txtFilNam.Text = ""
                dgExport.DataSource = Nothing

                recordStatus = False
                rs_Export_IMASSEXDAT = Nothing
                rs_Export_IMBOMEXDAT = Nothing
                rs_Export_IMITMEXDAT = Nothing
                rs_Export_IMMBDEXDAT = Nothing
                rs_Item_IMASSEXDAT = Nothing
                rs_Item_IMBOMEXDAT = Nothing
                rs_Item_IMITMEXDAT = Nothing
                rs_Item_IMMBDEXDAT = Nothing

                initialize_DataSet()
            Case "ADD"
                mmdAdd.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = True
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdExit.Enabled = True

                grpItem.Enabled = True
                txtItmNo.Enabled = True
                cmdItmSearch.Enabled = True
                cmdItmClr.Enabled = False
                cmdItmAll.Enabled = False
                cmdItmAdd.Enabled = False
                dgItem.Enabled = True



                If rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count = 0 Then
                    initialize_DataSet()
                    display_dgItem()

                    grpExport.Enabled = True
                    txtItmCount.Enabled = False
                    cmdXLSClr.Enabled = False
                    cmdXLSAll.Enabled = False
                    cmdXLSRemove.Enabled = False
                    txtFilNam.Enabled = False
                    cmdFilNamReset.Enabled = False
                    cmdExport.Enabled = False
                    dgExport.Enabled = False

                    txtItmCount.Text = "0"
                    txtFilNam.Text = ""
                    display_dgExport()

                    recordStatus = False
                Else
                    initialize_DataSet(True)
                    display_dgItem()
                    display_dgExport()

                    grpExport.Enabled = True
                    txtItmCount.Enabled = False
                    cmdXLSClr.Enabled = True
                    cmdXLSAll.Enabled = True
                    cmdXLSRemove.Enabled = True
                    txtFilNam.Enabled = True
                    cmdFilNamReset.Enabled = True
                    cmdExport.Enabled = True
                    dgExport.Enabled = True

                    If txtFilNam.Text = "" Then
                        txtFilNam.Text = rs_Export_IMITMEXDAT.Tables("RESULT").Rows(0)("ibi_itmno") & "-" & Format(CDate(Date.Today), "yyyyMMdd")
                    End If

                    recordStatus = True
                End If
            Case "SELECT"
                mmdAdd.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdCopy.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = True
                mmdSearch.Enabled = False
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdExit.Enabled = True

                grpItem.Enabled = True
                txtItmNo.Enabled = True
                cmdItmSearch.Enabled = True
                cmdItmClr.Enabled = True
                cmdItmAll.Enabled = True
                cmdItmAdd.Enabled = True
                dgItem.Enabled = True

                If rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count = 0 Then
                    grpExport.Enabled = True
                    txtItmCount.Enabled = False
                    cmdXLSClr.Enabled = False
                    cmdXLSAll.Enabled = False
                    cmdXLSRemove.Enabled = False
                    txtFilNam.Enabled = False
                    cmdFilNamReset.Enabled = False
                    cmdExport.Enabled = False
                    dgExport.Enabled = False

                    recordStatus = False
                Else
                    grpExport.Enabled = True
                    txtItmCount.Enabled = False
                    cmdXLSClr.Enabled = True
                    cmdXLSAll.Enabled = True
                    cmdXLSRemove.Enabled = True
                    txtFilNam.Enabled = True
                    cmdFilNamReset.Enabled = True
                    cmdExport.Enabled = True
                    dgExport.Enabled = True

                    display_dgExport()

                    recordStatus = True
                End If
        End Select
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        setStatus("ADD")
    End Sub

    Private Sub initialize_DataSet(Optional ByVal itemOnly As Boolean = False)
        gspStr = "sp_select_IMM00015_IMITMEXDAT ''"
        rs_Item_IMITMEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMITMEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #001 sp_select_IMM00015_IMITMEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMITMEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            If itemOnly = False Then
                rs_Export_IMITMEXDAT = rs_Item_IMITMEXDAT.Clone()
            End If
        End If

        gspStr = "sp_select_IMM00015_IMBOMEXDAT ''"
        rs_Item_IMBOMEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMBOMEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #002 sp_select_IMM00015_IMBOMEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMBOMEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMBOMEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            If itemOnly = False Then
                rs_Export_IMBOMEXDAT = rs_Item_IMBOMEXDAT.Clone()
            End If
        End If

        gspStr = "sp_select_IMM00015_IMASSEXDAT ''"
        rs_Item_IMASSEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMASSEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #003 sp_select_IMM00015_IMASSEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMASSEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMASSEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            If itemOnly = False Then
                rs_Export_IMASSEXDAT = rs_Item_IMASSEXDAT.Clone()
            End If
        End If

        gspStr = "sp_select_IMM00015_IMMBDEXDAT ''"
        rs_Item_IMMBDEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMMBDEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #004 sp_select_IMM00015_IMASSEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMMBDEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMMBDEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            If itemOnly = False Then
                rs_Export_IMMBDEXDAT = rs_Item_IMMBDEXDAT.Clone()
            End If
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If recordStatus = True Then
            Dim answer As Integer = MsgBox("Unsaved data has been detect." & Environment.NewLine & "Export data before clearing?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, Me.Name & " - Clear")
            If answer = MsgBoxResult.Yes Then
                If cmdExport.Enabled = False Then
                    MsgBox("No data has been selected for export", MsgBoxStyle.Information, Me.Name & " - Data Export")
                    Exit Sub
                Else
                    cmdExport.PerformClick()
                    setStatus("INIT")
                End If
            ElseIf answer = MsgBoxResult.No Then
                setStatus("INIT")
            Else
                Exit Sub
            End If
        Else
            setStatus("INIT")
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub IMM00015_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If recordStatus = True Then
            Dim answer As Integer = MsgBox("Unsaved data has been detect." & Environment.NewLine & "Export data before exit?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, Me.Name & " - Exit")
            If answer = MsgBoxResult.Yes Then
                If cmdExport.Enabled = False Then
                    MsgBox("No data has been selected for export", MsgBoxStyle.Information, Me.Name & " - Data Export")
                    e.Cancel = True
                Else
                    cmdExport.PerformClick()
                End If
            ElseIf answer = MsgBoxResult.No Then
                Exit Sub
            ElseIf answer = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtItmNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmdItmSearch.PerformClick()
        End If
    End Sub

    Private Sub cmdItmSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItmSearch.Click
        If Trim(txtItmNo.Text).Length = 0 Then
            MsgBox("Please enter an Item Number", MsgBoxStyle.Information, Me.Name & " - Search")
            Exit Sub
        Else
            txtItmNo.Text = UCase(Trim(txtItmNo.Text))
        End If

        gspStr = "sp_select_IMM00015_IMITMEXDAT '" & txtItmNo.Text & "'"
        rs_Item_IMITMEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMITMEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #005 sp_select_IMM00015_IMITMEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMITMEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            If rs_Item_IMITMEXDAT.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, Me.Name & " - Search")
                initialize_DataSet(True)
                display_dgItem()
                setStatus("ADD")
                Exit Sub
            Else
                If rs_Item_IMITMEXDAT.Tables("RESULT").Rows(0)("status") <> "" Then
                    MsgBox("Item Number is not an external item", MsgBoxStyle.Information, Me.Name & " - Search")
                    initialize_DataSet(True)
                    display_dgItem()
                    setStatus("ADD")
                    Exit Sub
                End If
            End If
        End If

        gspStr = "sp_select_IMM00015_IMBOMEXDAT '" & txtItmNo.Text & "'"
        rs_Item_IMBOMEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMBOMEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #006 sp_select_IMM00015_IMBOMEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMBOMEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMBOMEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        gspStr = "sp_select_IMM00015_IMASSEXDAT '" & txtItmNo.Text & "'"
        rs_Item_IMASSEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMASSEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #007 sp_select_IMM00015_IMASSEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMASSEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMASSEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        gspStr = "sp_select_IMM00015_IMMBDEXDAT '" & txtItmNo.Text & "'"
        rs_Item_IMMBDEXDAT = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Item_IMMBDEXDAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #008 sp_select_IMM00015_IMASSEXDAT : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_Item_IMMBDEXDAT.Tables("RESULT").Columns.Count - 1
                rs_Item_IMMBDEXDAT.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        setStatus("SELECT")
        display_dgItem()
    End Sub

    Private Sub cmdItmClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItmClr.Click
        dgItem.ClearSelection()

        For i As Integer = 0 To rs_Item_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            rs_Item_IMITMEXDAT.Tables("RESULT").Rows(i)("status") = ""
        Next
    End Sub

    Private Sub cmdItmAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItmAll.Click
        dgItem.ClearSelection()

        For i As Integer = 0 To rs_Item_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            rs_Item_IMITMEXDAT.Tables("RESULT").Rows(i)("status") = "Y"
        Next
    End Sub

    Private Sub dgItem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellClick
        If dgItem.CurrentCell Is Nothing Then
            Exit Sub
        End If

        If dgItem.CurrentCell.ColumnIndex = dgItem_Sel Then
            If dgItem.CurrentCell.Value = "" Then
                dgItem.CurrentCell.Value = "Y"
            Else
                dgItem.CurrentCell.Value = ""
            End If
        End If
    End Sub

    Private Sub cmdItmAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItmAdd.Click
        Dim dr() As DataRow = rs_Item_IMITMEXDAT.Tables("RESULT").Select("status = 'Y'")
        If dr.Length = 0 Then
            MsgBox("No items selected", MsgBoxStyle.Information, Me.Name & " - Add")
            Exit Sub
        Else
            Dim drExport() As DataRow
            Dim newRow As DataRow
            For i As Integer = 0 To dr.Length - 1
                ' Copy IMITMEXDAT
                drExport = Nothing
                drExport = rs_Export_IMITMEXDAT.Tables("RESULT").Select("ibi_itmno = '" & dr(i)("ibi_itmno") & "' and " & _
                                                                        "ivi_venno = '" & dr(i)("ivi_venno") & "' and " & _
                                                                        "ipi_pckunt = '" & dr(i)("ipi_pckunt") & "' and " & _
                                                                        "ipi_inrqty = '" & dr(i)("ipi_inrqty") & "' and " & _
                                                                        "ipi_mtrqty = '" & dr(i)("ipi_mtrqty") & "' and " & _
                                                                        "imu_cus1no = '" & dr(i)("imu_cus1no") & "' and " & _
                                                                        "imu_cus2no = '" & dr(i)("imu_cus2no") & "' and " & _
                                                                        "imu_ftyprctrm = '" & dr(i)("imu_ftyprctrm") & "' and " & _
                                                                        "imu_hkprctrm = '" & dr(i)("imu_hkprctrm") & "' and " & _
                                                                        "imu_trantrm = '" & dr(i)("imu_trantrm") & "'")
                If drExport.Length = 0 Then
                    newRow = Nothing
                    newRow = rs_Export_IMITMEXDAT.Tables("RESULT").NewRow
                    newRow(0) = ""
                    For j As Integer = 1 To rs_Export_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
                        newRow(j) = dr(i)(j)
                    Next
                    rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Add(newRow)
                    rs_Export_IMITMEXDAT.AcceptChanges()
                    txtItmCount.Text = CInt(txtItmCount.Text) + 1
                End If

                ' Copy IMBOMEXDAT
                drExport = Nothing
                drExport = rs_Export_IMBOMEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                If drExport.Length = 0 Then
                    drExport = Nothing
                    drExport = rs_Item_IMBOMEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            newRow = Nothing
                            newRow = rs_Export_IMBOMEXDAT.Tables("RESULT").NewRow
                            For k As Integer = 0 To rs_Export_IMBOMEXDAT.Tables("RESULT").Columns.Count - 1
                                newRow(k) = drExport(j)(k)
                            Next
                            rs_Export_IMBOMEXDAT.Tables("RESULT").Rows.Add(newRow)
                            rs_Export_IMBOMEXDAT.AcceptChanges()
                        Next
                    End If
                End If

                ' Copy IMASSEXDAT
                drExport = Nothing
                drExport = rs_Export_IMASSEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                If drExport.Length = 0 Then
                    drExport = Nothing
                    drExport = rs_Item_IMASSEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            newRow = Nothing
                            newRow = rs_Export_IMASSEXDAT.Tables("RESULT").NewRow
                            For k As Integer = 0 To rs_Export_IMASSEXDAT.Tables("RESULT").Columns.Count - 1
                                newRow(k) = drExport(j)(k)
                            Next
                            rs_Export_IMASSEXDAT.Tables("RESULT").Rows.Add(newRow)
                            rs_Export_IMASSEXDAT.AcceptChanges()
                        Next
                    End If
                End If

                ' Copy IMMBDEXDAT
                drExport = Nothing
                drExport = rs_Export_IMMBDEXDAT.Tables("RESULT").Select("ibm_itmno = '" & dr(i)("ibi_itmno") & "'")
                If drExport.Length = 0 Then
                    drExport = Nothing
                    drExport = rs_Item_IMMBDEXDAT.Tables("RESULT").Select("ibm_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            newRow = Nothing
                            newRow = rs_Export_IMMBDEXDAT.Tables("RESULT").NewRow
                            For k As Integer = 0 To rs_Export_IMMBDEXDAT.Tables("RESULT").Columns.Count - 1
                                newRow(k) = drExport(j)(k)
                            Next
                            rs_Export_IMMBDEXDAT.Tables("RESULT").Rows.Add(newRow)
                            rs_Export_IMMBDEXDAT.AcceptChanges()
                        Next
                    End If
                End If
            Next

            If rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count > 0 Then
                setStatus("ADD")
            Else
                setStatus("SELECT")
            End If
            cmdItmClr.PerformClick()
        End If
    End Sub

    Private Sub display_dgItem()
        dgItem.DataSource = rs_Item_IMITMEXDAT.Tables("RESULT").DefaultView

        For i As Integer = 0 To rs_Item_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
            Select Case rs_Item_IMITMEXDAT.Tables("RESULT").Columns(i).ColumnName
                Case "status"
                    dgItem_Sel = i
                    dgItem.Columns(i).HeaderText = "SEL"
                    dgItem.Columns(i).Width = 40
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "ibi_venno"
                    dgItem.Columns(i).HeaderText = "DV"
                    dgItem.Columns(i).Width = 40
                Case "ivi_venno"
                    dgItem.Columns(i).HeaderText = "PV"
                    dgItem.Columns(i).Width = 40
                Case "ibi_cusven"
                    dgItem.Columns(i).HeaderText = "CV"
                    dgItem.Columns(i).Width = 40
                Case "imu_cus1no"
                    dgItem.Columns(i).HeaderText = "Pri Cust."
                    dgItem.Columns(i).Width = 60
                Case "imu_cus2no"
                    dgItem.Columns(i).HeaderText = "Sec Cust."
                    dgItem.Columns(i).Width = 60
                Case "ivi_venitm"
                    dgItem.Columns(i).HeaderText = "Vendor Item No."
                    dgItem.Columns(i).Width = 90
                Case "ibi_itmno"
                    dgItem.Columns(i).HeaderText = "Item No."
                    dgItem.Columns(i).Width = 100
                Case "ibi_dsgno"
                    dgItem.Columns(i).HeaderText = "Design Item No."
                    dgItem.Columns(i).Width = 90
                Case "ibi_typ"
                    dgItem.Columns(i).HeaderText = "Type"
                    dgItem.Columns(i).Width = 40
                Case "ibi_catlvl4"
                    dgItem.Columns(i).HeaderText = "Cat. (Lvl 4)"
                    dgItem.Columns(i).Width = 80
                Case "ibi_engdsc"
                    dgItem.Columns(i).HeaderText = "English Description"
                    dgItem.Columns(i).Width = 180
                Case "ibi_chndsc"
                    dgItem.Columns(i).HeaderText = "Chinese Description"
                    dgItem.Columns(i).Width = 180
                Case "ibi_material"
                    dgItem.Columns(i).HeaderText = "Key Material"
                    dgItem.Columns(i).Width = 90
                Case "ibi_itmnat"
                    dgItem.Columns(i).HeaderText = "Item Nat."
                    dgItem.Columns(i).Width = 70
                Case "ibi_prdtyp"
                    dgItem.Columns(i).HeaderText = "Prd Grp."
                    dgItem.Columns(i).Width = 55
                Case "ibi_prdsizeval"
                    dgItem.Columns(i).HeaderText = "Prd Value"
                    dgItem.Columns(i).Width = 60
                Case "ibi_prdsizeunt"
                    dgItem.Columns(i).HeaderText = "Prd Unit"
                    dgItem.Columns(i).Width = 55
                Case "ibi_prdsizetyp"
                    dgItem.Columns(i).HeaderText = "Prd Type"
                    dgItem.Columns(i).Width = 60
                Case "icf_colcde"
                    dgItem.Columns(i).HeaderText = "Col Cde"
                    dgItem.Columns(i).Width = 50
                Case "icf_coldsc"
                    dgItem.Columns(i).HeaderText = "Col Desc"
                    dgItem.Columns(i).Width = 60
                Case "icf_vencol"
                    dgItem.Columns(i).HeaderText = "Vnd Col Cde"
                    dgItem.Columns(i).Width = 60
                Case "ibi_lnecde"
                    dgItem.Columns(i).HeaderText = "Prd Line"
                    dgItem.Columns(i).Width = 65
                Case "ipi_pckunt"
                    dgItem.Columns(i).HeaderText = "UM"
                    dgItem.Columns(i).Width = 50
                    dgItem.Columns(i).DisplayIndex = 4
                Case "ipi_conftr"
                    dgItem.Columns(i).HeaderText = "Con Ftr"
                    dgItem.Columns(i).Width = 35
                    dgItem.Columns(i).DisplayIndex = 5
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrqty"
                    dgItem.Columns(i).HeaderText = "Inr"
                    dgItem.Columns(i).Width = 35
                    dgItem.Columns(i).DisplayIndex = 6
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrqty"
                    dgItem.Columns(i).HeaderText = "Mtr"
                    dgItem.Columns(i).Width = 35
                    dgItem.Columns(i).DisplayIndex = 7
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrdin"
                    dgItem.Columns(i).HeaderText = "Inr (L)"
                    dgItem.Columns(i).Width = 45
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrwin"
                    dgItem.Columns(i).HeaderText = "Inr (W)"
                    dgItem.Columns(i).Width = 48
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrhin"
                    dgItem.Columns(i).HeaderText = "Inr (H)"
                    dgItem.Columns(i).Width = 48
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrdin"
                    dgItem.Columns(i).HeaderText = "Mtr (L)"
                    dgItem.Columns(i).Width = 48
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrwin"
                    dgItem.Columns(i).HeaderText = "Mtr (W)"
                    dgItem.Columns(i).Width = 48
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrhin"
                    dgItem.Columns(i).HeaderText = "Mtr (H)"
                    dgItem.Columns(i).Width = 48
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_cft"
                    dgItem.Columns(i).HeaderText = "CFT"
                    dgItem.Columns(i).Width = 45
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_pckmsr"
                    dgItem.Columns(i).HeaderText = "Pck Msr"
                    dgItem.Columns(i).Width = 40
                Case "ipi_grswgt"
                    dgItem.Columns(i).HeaderText = "GW"
                    dgItem.Columns(i).Width = 30
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_netwgt"
                    dgItem.Columns(i).HeaderText = "NW"
                    dgItem.Columns(i).Width = 30
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_pckitr"
                    dgItem.Columns(i).HeaderText = "Packing Instruction"
                    dgItem.Columns(i).Width = 150
                Case "imu_ftyprctrm"
                    dgItem.Columns(i).HeaderText = "Fty Prc Trm"
                    dgItem.Columns(i).Width = 70
                    dgItem.Columns(i).DisplayIndex = 10
                Case "imu_hkprctrm"
                    dgItem.Columns(i).HeaderText = "HK Prc Trm"
                    dgItem.Columns(i).Width = 70
                    dgItem.Columns(i).DisplayIndex = 11
                Case "imu_trantrm"
                    dgItem.Columns(i).HeaderText = "Tran Trm"
                    dgItem.Columns(i).Width = 70
                    dgItem.Columns(i).DisplayIndex = 12
                Case "imu_curcde"
                    dgItem.Columns(i).HeaderText = "CCY"
                    dgItem.Columns(i).Width = 40
                Case "imu_ftyprc"
                    dgItem.Columns(i).HeaderText = "Fty Prc"
                    dgItem.Columns(i).Width = 55
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "imm_moqunttyp"
                    dgItem.Columns(i).HeaderText = "MOQ UM"
                    dgItem.Columns(i).Width = 40
                Case "imm_moqctn"
                    dgItem.Columns(i).HeaderText = "MOQ Qty"
                    dgItem.Columns(i).Width = 60
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "imm_curcde"
                    dgItem.Columns(i).HeaderText = "MOQ CCY"
                    dgItem.Columns(i).Width = 65
                Case "imm_moa"
                    dgItem.Columns(i).HeaderText = "MOQ Amt"
                    dgItem.Columns(i).Width = 60
                    dgItem.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_qutdat"
                    dgItem.Columns(i).HeaderText = "Qut Date"
                    dgItem.Columns(i).Width = 70
                Case "imu_expdat"
                    dgItem.Columns(i).HeaderText = "Exp Date"
                    dgItem.Columns(i).Width = 70
                Case "ibi_rmk"
                    dgItem.Columns(i).HeaderText = "Int Rmk"
                    dgItem.Columns(i).Width = 150
                Case "ici_cstrmk"
                    dgItem.Columns(i).HeaderText = "Cst Rmk"
                    dgItem.Columns(i).Width = 100
                Case "imu_estprcflg"
                    dgItem.Columns(i).HeaderText = "Est Prc Flg"
                    dgItem.Columns(i).Width = 30
                Case "imu_estprcref"
                    dgItem.Columns(i).HeaderText = "Est Prc Ref"
                    dgItem.Columns(i).Width = 100
                Case Else
                    dgItem.Columns(i).Visible = False
            End Select
        Next

        dgItem.ClearSelection()
    End Sub

    Private Sub display_dgExport()
        dgExport.DataSource = rs_Export_IMITMEXDAT.Tables("RESULT").DefaultView

        For i As Integer = 0 To rs_Export_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
            Select Case rs_Export_IMITMEXDAT.Tables("RESULT").Columns(i).ColumnName
                Case "status"
                    dgExport_Sel = i
                    dgExport.Columns(i).HeaderText = "SEL"
                    dgExport.Columns(i).Width = 40
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "ibi_venno"
                    dgExport.Columns(i).HeaderText = "DV"
                    dgExport.Columns(i).Width = 40
                Case "ivi_venno"
                    dgExport.Columns(i).HeaderText = "PV"
                    dgExport.Columns(i).Width = 40
                Case "ibi_cusven"
                    dgExport.Columns(i).HeaderText = "CV"
                    dgExport.Columns(i).Width = 40
                Case "imu_cus1no"
                    dgExport.Columns(i).HeaderText = "Pri Cust."
                    dgExport.Columns(i).Width = 60
                Case "imu_cus2no"
                    dgExport.Columns(i).HeaderText = "Sec Cust."
                    dgExport.Columns(i).Width = 60
                Case "ivi_venitm"
                    dgExport.Columns(i).HeaderText = "Vendor Item No."
                    dgExport.Columns(i).Width = 90
                Case "ibi_itmno"
                    dgExport.Columns(i).HeaderText = "Item No."
                    dgExport.Columns(i).Width = 100
                Case "ibi_dsgno"
                    dgExport.Columns(i).HeaderText = "Design Item No."
                    dgExport.Columns(i).Width = 90
                Case "ibi_typ"
                    dgExport.Columns(i).HeaderText = "Type"
                    dgExport.Columns(i).Width = 40
                Case "ibi_catlvl4"
                    dgExport.Columns(i).HeaderText = "Cat. (Lvl 4)"
                    dgExport.Columns(i).Width = 80
                Case "ibi_engdsc"
                    dgExport.Columns(i).HeaderText = "English Description"
                    dgExport.Columns(i).Width = 180
                Case "ibi_chndsc"
                    dgExport.Columns(i).HeaderText = "Chinese Description"
                    dgExport.Columns(i).Width = 180
                Case "ibi_material"
                    dgExport.Columns(i).HeaderText = "Key Material"
                    dgExport.Columns(i).Width = 90
                Case "ibi_itmnat"
                    dgExport.Columns(i).HeaderText = "Item Nat."
                    dgExport.Columns(i).Width = 70
                Case "ibi_prdtyp"
                    dgExport.Columns(i).HeaderText = "Prd Grp."
                    dgExport.Columns(i).Width = 55
                Case "ibi_prdsizeval"
                    dgExport.Columns(i).HeaderText = "Prd Value"
                    dgExport.Columns(i).Width = 60
                Case "ibi_prdsizeunt"
                    dgExport.Columns(i).HeaderText = "Prd Unit"
                    dgExport.Columns(i).Width = 55
                Case "ibi_prdsizetyp"
                    dgExport.Columns(i).HeaderText = "Prd Type"
                    dgExport.Columns(i).Width = 60
                Case "icf_colcde"
                    dgExport.Columns(i).HeaderText = "Col Cde"
                    dgExport.Columns(i).Width = 50
                Case "icf_coldsc"
                    dgExport.Columns(i).HeaderText = "Col Desc"
                    dgExport.Columns(i).Width = 60
                Case "icf_vencol"
                    dgExport.Columns(i).HeaderText = "Vnd Col Cde"
                    dgExport.Columns(i).Width = 60
                Case "ibi_lnecde"
                    dgExport.Columns(i).HeaderText = "Prd Line"
                    dgExport.Columns(i).Width = 65
                Case "ipi_pckunt"
                    dgExport.Columns(i).HeaderText = "UM"
                    dgExport.Columns(i).Width = 50
                    dgExport.Columns(i).DisplayIndex = 4
                Case "ipi_conftr"
                    dgExport.Columns(i).HeaderText = "Con Ftr"
                    dgExport.Columns(i).Width = 35
                    dgExport.Columns(i).DisplayIndex = 5
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrqty"
                    dgExport.Columns(i).HeaderText = "Inr"
                    dgExport.Columns(i).Width = 35
                    dgExport.Columns(i).DisplayIndex = 6
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrqty"
                    dgExport.Columns(i).HeaderText = "Mtr"
                    dgExport.Columns(i).Width = 35
                    dgExport.Columns(i).DisplayIndex = 7
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrdin"
                    dgExport.Columns(i).HeaderText = "Inr (L)"
                    dgExport.Columns(i).Width = 45
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrwin"
                    dgExport.Columns(i).HeaderText = "Inr (W)"
                    dgExport.Columns(i).Width = 48
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_inrhin"
                    dgExport.Columns(i).HeaderText = "Inr (H)"
                    dgExport.Columns(i).Width = 48
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrdin"
                    dgExport.Columns(i).HeaderText = "Mtr (L)"
                    dgExport.Columns(i).Width = 48
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrwin"
                    dgExport.Columns(i).HeaderText = "Mtr (W)"
                    dgExport.Columns(i).Width = 48
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_mtrhin"
                    dgExport.Columns(i).HeaderText = "Mtr (H)"
                    dgExport.Columns(i).Width = 48
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_cft"
                    dgExport.Columns(i).HeaderText = "CFT"
                    dgExport.Columns(i).Width = 45
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_pckmsr"
                    dgExport.Columns(i).HeaderText = "Pck Msr"
                    dgExport.Columns(i).Width = 40
                Case "ipi_grswgt"
                    dgExport.Columns(i).HeaderText = "GW"
                    dgExport.Columns(i).Width = 30
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_netwgt"
                    dgExport.Columns(i).HeaderText = "NW"
                    dgExport.Columns(i).Width = 30
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_pckitr"
                    dgExport.Columns(i).HeaderText = "Packing Instruction"
                    dgExport.Columns(i).Width = 150
                Case "imu_ftyprctrm"
                    dgExport.Columns(i).HeaderText = "Fty Prc Trm"
                    dgExport.Columns(i).Width = 70
                    dgExport.Columns(i).DisplayIndex = 10
                Case "imu_hkprctrm"
                    dgExport.Columns(i).HeaderText = "HK Prc Trm"
                    dgExport.Columns(i).Width = 70
                    dgExport.Columns(i).DisplayIndex = 11
                Case "imu_trantrm"
                    dgExport.Columns(i).HeaderText = "Tran Trm"
                    dgExport.Columns(i).Width = 70
                    dgExport.Columns(i).DisplayIndex = 12
                Case "imu_curcde"
                    dgExport.Columns(i).HeaderText = "CCY"
                    dgExport.Columns(i).Width = 40
                Case "imu_ftyprc"
                    dgExport.Columns(i).HeaderText = "Fty Prc"
                    dgExport.Columns(i).Width = 55
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "imm_moqunttyp"
                    dgExport.Columns(i).HeaderText = "MOQ UM"
                    dgExport.Columns(i).Width = 40
                Case "imm_moqctn"
                    dgExport.Columns(i).HeaderText = "MOQ Qty"
                    dgExport.Columns(i).Width = 60
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "imm_curcde"
                    dgExport.Columns(i).HeaderText = "MOQ CCY"
                    dgExport.Columns(i).Width = 65
                Case "imm_moa"
                    dgExport.Columns(i).HeaderText = "MOQ Amt"
                    dgExport.Columns(i).Width = 60
                    dgExport.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "ipi_qutdat"
                    dgExport.Columns(i).HeaderText = "Qut Date"
                    dgExport.Columns(i).Width = 70
                Case "imu_expdat"
                    dgExport.Columns(i).HeaderText = "Exp Date"
                    dgExport.Columns(i).Width = 70
                Case "ibi_rmk"
                    dgExport.Columns(i).HeaderText = "Int Rmk"
                    dgExport.Columns(i).Width = 150
                Case "ici_cstrmk"
                    dgExport.Columns(i).HeaderText = "Cst Rmk"
                    dgExport.Columns(i).Width = 100
                Case "imu_estprcflg"
                    dgExport.Columns(i).HeaderText = "Est Prc Flg"
                    dgExport.Columns(i).Width = 30
                Case "imu_estprcref"
                    dgExport.Columns(i).HeaderText = "Est Prc Ref"
                    dgExport.Columns(i).Width = 100
                Case Else
                    dgExport.Columns(i).Visible = False
            End Select
        Next

        dgExport.ClearSelection()
    End Sub

    Private Sub cmdXLSClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXLSClr.Click
        dgExport.ClearSelection()

        For i As Integer = 0 To rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            rs_Export_IMITMEXDAT.Tables("RESULT").Rows(i)("status") = ""
        Next
    End Sub

    Private Sub cmdXLSAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXLSAll.Click
        dgExport.ClearSelection()

        For i As Integer = 0 To rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            rs_Export_IMITMEXDAT.Tables("RESULT").Rows(i)("status") = "Y"
        Next
    End Sub

    Private Sub cmdXLSRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXLSRemove.Click
        Dim dr() As DataRow = rs_Export_IMITMEXDAT.Tables("RESULT").Select("status = 'Y'")
        If dr.Length = 0 Then
            MsgBox("No items selected", MsgBoxStyle.Information, Me.Name & " - Remove")
            Exit Sub
        Else
            Dim drExport() As DataRow
            For i As Integer = 0 To dr.Length - 1
                ' Check IMITMEXDAT if Item remains
                drExport = Nothing
                drExport = rs_Export_IMITMEXDAT.Tables("RESULT").Select("ibi_itmno = '" & dr(i)("ibi_itmno") & "' and " & _
                                                                        "status <> 'Y'")
                If drExport.Length = 0 Then
                    ' Remove IMBOMEXDAT
                    drExport = Nothing
                    drExport = rs_Export_IMBOMEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            drExport(j).Delete()
                            rs_Export_IMBOMEXDAT.AcceptChanges()
                        Next
                    End If
                    ' Remove IMASSEXDAT
                    drExport = Nothing
                    drExport = rs_Export_IMASSEXDAT.Tables("RESULT").Select("iba_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            drExport(j).Delete()
                            rs_Export_IMBOMEXDAT.AcceptChanges()
                        Next
                    End If
                    ' Remove IMMBDEXDAT
                    drExport = Nothing
                    drExport = rs_Export_IMMBDEXDAT.Tables("RESULT").Select("ibm_itmno = '" & dr(i)("ibi_itmno") & "'")
                    If drExport.Length > 0 Then
                        For j As Integer = 0 To drExport.Length - 1
                            drExport(j).Delete()
                            rs_Export_IMBOMEXDAT.AcceptChanges()
                        Next
                    End If
                End If

                ' Remove IMITMEXDAT
                dr(i).Delete()
                rs_Export_IMITMEXDAT.AcceptChanges()
                txtItmCount.Text = CInt(txtItmCount.Text) - 1
            Next

            If rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count > 0 Then
                setStatus("ADD")
            Else
                setStatus("SELECT")
            End If
            cmdItmClr.PerformClick()
        End If
    End Sub

    Private Sub cmdFilNamReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilNamReset.Click
        txtFilNam.Text = rs_Export_IMITMEXDAT.Tables("RESULT").Rows(0)("ibi_itmno") & "-" & Format(CDate(Date.Today), "yyyyMMdd")
    End Sub

    Private Sub dgExport_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgExport.CellClick
        If dgExport.CurrentCell Is Nothing Then
            Exit Sub
        End If

        If dgExport.CurrentCell.ColumnIndex = dgExport_Sel Then
            If dgExport.CurrentCell.Value = "" Then
                dgExport.CurrentCell.Value = "Y"
            Else
                dgExport.CurrentCell.Value = ""
            End If
        End If
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Dim cur_Process() As Process
        Dim new_Process() As Process

        Dim fil_src As String = Environment.CurrentDirectory & "\IMTemplate\" & tmp_filname & tmp_ext
        Dim fil_dst As String = dir_export & "\" & txtFilNam.Text & tmp_ext

        dgExport.ClearSelection()

        If Trim(txtFilNam.Text) = "" Then
            MsgBox("Filanem is missing.", MsgBoxStyle.Information, Me.Name & " - Export")
            Exit Sub
        ElseIf rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record has been selected for export.", MsgBoxStyle.Information, Me.Name & " - Export")
            Exit Sub
        ElseIf File.Exists(fil_dst) = True Then
            If MsgBox("Filename already exists." & Environment.NewLine & "Confirm to overwrite", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Name & " - Export") = MsgBoxResult.Yes Then
                Try
                    File.Delete(fil_dst)
                Catch ex As Exception
                    MsgBox("Error on deleting " & fil_dst & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Name & " - Export")
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If
        End If

        ' Check output Directory
        If Directory.Exists(dir_export) = False Then
            Directory.CreateDirectory(dir_export)
        End If

        Dim myExcel As Excel.Application
        ' Check File Exists
        If File.Exists(fil_src) = False Then
            MsgBox("Missing source file: " & Environment.NewLine & "Path: " & fil_src, MsgBoxStyle.Exclamation, Me.Name & " - Export")
            Exit Sub
        Else
            cur_Process = Nothing
            cur_Process = Process.GetProcessesByName("EXCEL")
            ' Check Version Number
            oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            myExcel = New Excel.Application
            new_Process = Nothing
            new_Process = Process.GetProcessesByName("EXCEL")
            myExcel.Workbooks.Open(fil_src)
            myExcel.Sheets(xls_IMITMEXDAT).Select()
            If myExcel.Cells(1, 4).Value <> tmp_version Then
                MsgBox("Incorrect template version used: Version " & tmp_version & " required", MsgBoxStyle.Information, Me.Name & " - Export")
                myExcel.Workbooks.Close()
                myExcel.Quit()
                myExcel = Nothing
                killProcess(cur_Process, new_Process)
                Exit Sub
            End If

            myExcel.Workbooks.Close()
            myExcel.Quit()
            myExcel = Nothing
            killProcess(cur_Process, new_Process)

            ' Copy Template to Export Directory
            Try
                File.Copy(fil_src, fil_dst)
            Catch ex As Exception
                MsgBox("Error on copying " & fil_src & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Name & " - Export")
                Exit Sub
            End Try
        End If

        ' Populate data to destination file
        cur_Process = Nothing
        cur_Process = Process.GetProcessesByName("EXCEL")
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        myExcel = Nothing
        myExcel = New Excel.Application
        new_Process = Nothing
        new_Process = Process.GetProcessesByName("EXCEL")
        myExcel.Workbooks.Open(fil_dst)

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ' Populate IMITMEXDAT Data
        myExcel.Sheets(xls_IMITMEXDAT).Select()
        Dim entry_IMITMEXDAT(54) As Object
        For i As Integer = 0 To rs_Export_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            For j As Integer = 1 To rs_Export_IMITMEXDAT.Tables("RESULT").Columns.Count - 1
                entry_IMITMEXDAT(j - 1) = rs_Export_IMITMEXDAT.Tables("RESULT").Rows(i)(j)
            Next
            myExcel.Range(myExcel.Cells(i + xls_RowOffset_IMITMEXDAT, 1), myExcel.Cells(i + xls_RowOffset_IMITMEXDAT, rs_Export_IMITMEXDAT.Tables("RESULT").Columns.Count - 1)).Value = entry_IMITMEXDAT
        Next

        ' Populate IMBOMEXDAT Data
        If rs_Export_IMBOMEXDAT.Tables("RESULT").Rows.Count > 0 Then
            myExcel.Sheets(xls_IMBOMEXDAT).Select()
            Dim entry_IMBOMEXDAT(rs_Export_IMBOMEXDAT.Tables("RESULT").Columns.Count) As Object
            For i As Integer = 0 To rs_Export_IMBOMEXDAT.Tables("RESULT").Rows.Count - 1
                For j As Integer = 0 To rs_Export_IMBOMEXDAT.Tables("RESULT").Columns.Count - 1
                    entry_IMBOMEXDAT(j) = rs_Export_IMBOMEXDAT.Tables("RESULT").Rows(i)(j)
                Next
                myExcel.Range(myExcel.Cells(i + xls_RowOffset, 1), myExcel.Cells(i + xls_RowOffset, rs_Export_IMBOMEXDAT.Tables("RESULT").Columns.Count)).Value = entry_IMBOMEXDAT
            Next
        End If

        ' Populate IMASSEXDAT Data
        If rs_Export_IMASSEXDAT.Tables("RESULT").Rows.Count > 0 Then
            myExcel.Sheets(xls_IMASSEXDAT).Select()
            Dim entry_IMASSEXDAT(rs_Export_IMASSEXDAT.Tables("RESULT").Columns.Count) As Object
            For i As Integer = 0 To rs_Export_IMASSEXDAT.Tables("RESULT").Rows.Count - 1
                For j As Integer = 0 To rs_Export_IMASSEXDAT.Tables("RESULT").Columns.Count - 1
                    entry_IMASSEXDAT(j) = rs_Export_IMASSEXDAT.Tables("RESULT").Rows(i)(j)
                Next
                myExcel.Range(myExcel.Cells(i + xls_RowOffset, 1), myExcel.Cells(i + xls_RowOffset, rs_Export_IMASSEXDAT.Tables("RESULT").Columns.Count)).Value = entry_IMASSEXDAT
            Next
        End If

        ' Populate IMMBDEXDAT Data
        If rs_Export_IMMBDEXDAT.Tables("RESULT").Rows.Count > 0 Then
            myExcel.Sheets(xls_IMMBDEXDAT).Select()
            Dim entry_IMMBDEXDAT(rs_Export_IMMBDEXDAT.Tables("RESULT").Columns.Count) As Object
            For i As Integer = 0 To rs_Export_IMMBDEXDAT.Tables("RESULT").Rows.Count - 1
                For j As Integer = 0 To rs_Export_IMMBDEXDAT.Tables("RESULT").Columns.Count - 1
                    entry_IMMBDEXDAT(j) = rs_Export_IMMBDEXDAT.Tables("RESULT").Rows(i)(j)
                Next
                myExcel.Range(myExcel.Cells(i + xls_RowOffset, 1), myExcel.Cells(i + xls_RowOffset, rs_Export_IMMBDEXDAT.Tables("RESULT").Columns.Count)).Value = entry_IMMBDEXDAT
            Next
        End If

        myExcel.DisplayAlerts = False
        myExcel.AlertBeforeOverwriting = False
        myExcel.Save()
        myExcel.Workbooks.Close()
        myExcel.Quit()
        myExcel = Nothing
        killProcess(cur_Process, new_Process)
        Me.Cursor = Windows.Forms.Cursors.Default
        MsgBox("Data Exportation Completed" & Environment.NewLine & "File saved at " & fil_dst, MsgBoxStyle.Information, Me.Name & " - Export")
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


