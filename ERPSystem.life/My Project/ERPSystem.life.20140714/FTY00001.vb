Imports System.IO

Public Class FTY00001

    Const imgMaxHeight As Integer = 1200
    Const imgMaxWidth As Integer = 1000
    Const fileExtension As String = ".pdf"
    Const filePattern As String = "*.jpg"

    Dim recordStatus As Boolean

    Dim rs_FYDELLIS As DataSet
    Dim rs_FYFTYINF As DataSet
    Dim rs_FYJOBSMK As DataSet
    Dim rs_FYJOBINF As DataSet
    Dim rs_FYJOBSMK_ori As DataSet
    Dim rs_POJBBDTL As DataSet
    Dim rs_POR00005_PDO As DataSet
    Dim rs_POR00005_PDO_Assortment As DataSet
    Dim rs_POR00005_PDO_AttchList As DataSet
    Dim rs_POR00005_PDO_Attachment As DataSet
    Dim rs_POR00005_PDO_ShpDat As DataSet

    Dim dir_app As String
    Dim dir_chk As String
    Dim dir_new As String
    Dim dir_old As String
    Dim dir_SAPEDI As String
    Dim dir_smk As String
    Dim dir_tmp As String

    Private Sub FTY00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        'enq_right_local = Enq_right
        'del_right_local = Del_right

        FillCompCombo(LCase(gsUsrID), cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        setStatus("INIT")
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        getDefault_Path()
    End Sub

    Private Sub txtBJNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBJNo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmdNext.PerformClick()
        End If
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If Trim(txtBJNo.Text) = "" Then
            MsgBox("Batch Job No. must not be empty", MsgBoxStyle.Exclamation, "FTY00001 - Empty Batch Job No.")
            Exit Sub
        Else
            txtBJNo.Text = Trim(UCase(txtBJNo.Text))
        End If

        Dim rs_tmp As DataSet
        gspStr = "sp_physical_delete_FYJOBINF '" & cboCoCde.Text & "'"
        rs_tmp = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on deleting FTY00001 #001 sp_physical_delete_FYJOBINF : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_PJDHONG_PDO '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POJBBDTL = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_POJBBDTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #002 sp_select_PJDHONG_PDO : " & rtnStr)
            Exit Sub
        Else
            If rs_POJBBDTL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "FTY00001 - Batch Job No")
                txtBJNo.Focus()
                txtBJNo.SelectAll()
                Exit Sub
            Else
                For i As Integer = 0 To rs_POJBBDTL.Tables("RESULT").Columns.Count - 1
                    rs_POJBBDTL.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If
        End If

        loadBatchNo()

        Dim jobno As String
        For i As Integer = 0 To rs_POJBBDTL.Tables("RESULT").Rows.Count - 1
            jobno = txtBJNo.Text & "-" & rs_POJBBDTL.Tables("RESULT").Rows(i)("pjd_batseq")
            lstNewOrder.Items.Add(jobno)
            gspStr = "sp_insert_FYJOBINF '" & cboCoCde.Text & "','" & jobno & "','" & rs_POJBBDTL.Tables("RESULT").Rows(i)("vencde") & _
                     "','" & rs_POJBBDTL.Tables("RESULT").Rows(i)("pod_itmno") & "','" & rs_POJBBDTL.Tables("RESULT").Rows(i)("pod_scno") & _
                     "','" & LCase(gsUsrID) & "'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on saving FTY00001 #008 sp_insert_FYJOBINF : " & rtnStr)
                Exit Sub
            End If

            ' Retrieve previously attached attachments
            gspStr = "sp_list_FYDOCSMK '" & cboCoCde.Text & "','" & jobno & ".pdf'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading FTY00001 #009 sp_list_FYDOCSMK : " & rtnStr)
                Exit Sub
            Else
                Dim dr() As DataRow
                Dim newRow As DataRow
                For j As Integer = 0 To rs_tmp.Tables("RESULT").Rows.Count - 1
                    dr = Nothing
                    dr = rs_FYJOBSMK.Tables("RESULT").Select("fsm_jobno = '" & jobno & "' and fsm_smkno = '" & rs_tmp.Tables("RESULT").Rows(j)("stm_smkno") & "'")
                    If dr.Length = 0 Then
                        newRow = Nothing
                        newRow = rs_FYJOBSMK.Tables("RESULT").NewRow
                        newRow("fsm_cocde") = cboCoCde.Text
                        newRow("fsm_jobno") = jobno
                        newRow("fsm_smkno") = rs_tmp.Tables("RESULT").Rows(j)("stm_smkno")
                        newRow("fsm_creusr") = rs_tmp.Tables("RESULT").Rows(j)("stm_creusr")
                        rs_FYJOBSMK.Tables("RESULT").Rows.Add(newRow)
                        rs_FYJOBSMK.AcceptChanges()
                    End If
                Next
            End If

            rs_FYJOBSMK_ori = rs_FYJOBSMK.Copy()
        Next

        setStatus("NEXT")

    End Sub

    Private Sub lstNewOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNewOrder.SelectedIndexChanged
        Dim dr() As DataRow = rs_POJBBDTL.Tables("RESULT").Select("pjd_batseq = '" & Split(lstNewOrder.SelectedItem.ToString, "-")(1) & "'")
        If dr.Length > 0 Then
            lblFty.Text = dr(0)("vencde")
        End If

        dr = Nothing
        dr = rs_FYJOBSMK.Tables("RESULT").Select("fsm_jobno = '" & lstNewOrder.SelectedItem.ToString & "' and fsm_creusr <> 'DEL'", "fsm_smkno")
        lstSelShipMark.Items.Clear()
        If dr.Length > 0 Then
            For i As Integer = 0 To dr.Length - 1
                If lstSelShipMark.Items.Contains(dr(i)("fsm_smkno")) = False Then
                    lstSelShipMark.Items.Add(dr(i)("fsm_smkno"))
                End If
            Next
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If lstShipMark.SelectedItems.Count = 0 Then
            MsgBox("Shipmark Attachment must be selected", MsgBoxStyle.Information, "FTY00001 - Add Attachment")
            Exit Sub
        End If

        If lstNewOrder.SelectedItems.Count = 0 Then
            MsgBox("Job Order must be selected", MsgBoxStyle.Information, "FTY00001 - Add Attachment")
            Exit Sub
        End If

        If lstSelShipMark.Items.Contains(lstShipMark.SelectedItem) = False Then
            Dim newRow As DataRow = rs_FYJOBSMK.Tables("RESULT").NewRow
            newRow("fsm_cocde") = cboCoCde.Text
            newRow("fsm_jobno") = lstNewOrder.SelectedItem
            newRow("fsm_smkno") = lstShipMark.SelectedItem
            Dim dr() As DataRow = rs_FYJOBSMK_ori.Tables("RESULT").Select("fsm_jobno = '" & lstNewOrder.SelectedItem & "' and fsm_smkno = '" & lstShipMark.SelectedItem & "'")
            If dr.Length = 0 Then
                newRow("fsm_creusr") = "ADD"
            Else
                newRow("fsm_creusr") = "UPD"
            End If
            rs_FYJOBSMK.Tables("RESULT").Rows.Add(newRow)
            rs_FYJOBSMK.AcceptChanges()

            lstSelShipMark.Items.Add(lstShipMark.SelectedItem)
        End If

        lstShipMark.ClearSelected()
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If lstSelShipMark.SelectedItems.Count = 0 Then
            MsgBox("Shipmark Attachment must be selected", MsgBoxStyle.Information, "FTY00001 - Remove Attachment")
            Exit Sub
        End If

        If lstNewOrder.SelectedItems.Count = 0 Then
            MsgBox("Job Order must be selected", MsgBoxStyle.Information, "FTY00001 - Add Attachment")
            Exit Sub
        End If

        Dim dr() As DataRow = rs_FYJOBSMK_ori.Tables("RESULT").Select("fsm_jobno = '" & lstNewOrder.SelectedItem.ToString & "' and fsm_smkno = '" & lstSelShipMark.SelectedItem & "'")
        If dr.Length = 0 Then
            dr = Nothing
            dr = rs_FYJOBSMK.Tables("RESULT").Select("fsm_jobno = '" & lstNewOrder.SelectedItem.ToString & "' and fsm_smkno = '" & lstSelShipMark.SelectedItem & "'")
            Dim newRow As DataRow = dr(0)
            rs_FYJOBSMK.Tables("RESULT").Rows.Remove(newRow)
            rs_FYJOBSMK.AcceptChanges()
        Else
            dr = Nothing
            dr = rs_FYJOBSMK.Tables("RESULT").Select("fsm_jobno = '" & lstNewOrder.SelectedItem.ToString & "' and fsm_smkno = '" & lstSelShipMark.SelectedItem & "'")
            dr(0)("fsm_creusr") = "DEL"
            rs_FYJOBSMK.AcceptChanges()
        End If

        lstSelShipMark.Items.Remove(lstSelShipMark.SelectedItem)
    End Sub

    Private Sub lstShipMark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstShipMark.SelectedIndexChanged
        displayPreview()
    End Sub

    Private Sub chkPreview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreview.CheckedChanged
        displayPreview()
    End Sub

    Private Sub cmdGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerate.Click
        Dim rs_tmp As DataSet
        Dim rs_tmp_attachment As DataSet
        Dim rs_files As New DataSet

        If MsgBox("Please click Yes to confirm generate Production Note", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "FTY00001 - Generate PN") = MsgBoxResult.No Then
            Exit Sub
        End If

        ' Create dataset for document record
        Dim dt As New DataTable("RESULT")
        Dim dc As DataColumn
        For i As Integer = 0 To 3
            Select Case i
                Case 0
                    dc = New DataColumn("ftycde")
                Case 1
                    dc = New DataColumn("filnam")
                Case 2
                    dc = New DataColumn("filsrc")
                Case 3
                    dc = New DataColumn("fildst")
                Case Else
                    Continue For
            End Select

            dc.DataType = System.Type.GetType("System.String")
            dt.Columns.Add(dc)
        Next
        rs_files.Tables.Add(dt)

        ' Check for shipmark attachment directory
        If Directory.Exists(dir_smk) = False Then
            MsgBox("Missing directory: " & dir_smk, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
            Exit Sub
        End If

        ' Remove previously copied shipmark attachments from local directory
        Dim Dir As New System.IO.DirectoryInfo(dir_smk)
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(filePattern)
        For i As Integer = 0 To Files.Length - 1
            Try
                File.Delete(dir_smk & Files(i).Name)
            Catch ex As Exception
                MsgBox("Error on deleting " & dir_smk & Files(i).Name & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                Exit Sub
            End Try
        Next

        ' Copy shipmark files to local directory
        For i As Integer = 0 To rs_FYJOBSMK.Tables("RESULT").Rows.Count - 1
            If File.Exists(dir_smk & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_smkno")) = False Then
                Try
                    File.Copy(gs_PDO_SMImg & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_smkno"), dir_smk & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_smkno"))
                Catch ex As Exception
                    MsgBox("Error on copying file to destination source " & dir_smk & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_smkno") & _
                           Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                End Try

            End If
        Next

        ' Update Job No. to SCTRSMRK
        For i As Integer = 0 To rs_POJBBDTL.Tables("RESULT").Rows.Count - 1
            'gspStr = "sp_update_SCTPSMRK_JOBNO '" & cboCoCde.Text & "','" & txtBJNo.Text & "-" & _
            '         rs_POJBBDTL.Tables("RESULT").Rows(i)("pjd_batseq") & ".pdf','"
            gspStr = "sp_update_SCTPSMRK_JOBNO '" & cboCoCde.Text & "','" & txtBJNo.Text & "-" & rs_POJBBDTL.Tables("RESULT").Rows(i)("pjd_batseq") & ".pdf'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on saving FTY00001 #010 sp_update_SCTPSMRK_JOBNO : " & rtnStr)
                Exit Sub
            End If
        Next

        ' Update ship mark record to SCTRSMRK
        For i As Integer = 0 To rs_FYJOBSMK.Tables("RESULT").Rows.Count - 1
            gspStr = "sp_insert_syntsmk '" & cboCoCde.Text & "','" & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_jobno") & ".pdf','" & _
                     rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_smkno") & "','" & rs_FYJOBSMK.Tables("RESULT").Rows(i)("fsm_creusr") & _
                     "','" & LCase(gsUsrID) & "'"
            rs_tmp = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on saving FTY00001 #011 sp_insert_syntsmk : " & rtnStr)
                Exit Sub
            End If
        Next

        ' Delete ship mark record to FYJOBSMK
        gspStr = "sp_physical_delete_FYJOBSMK '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_tmp = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on deleting FTY00001 #012 sp_physical_delete_FYJOBSMK : " & rtnStr)
            Exit Sub
        End If

        ' Delete File mapping from FYJFILMAP
        gspStr = "sp_physical_delete_FYFILMAP '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_tmp = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on deleting FTY00001 #013 sp_physical_delete_FYFILMAP : " & rtnStr)
            Exit Sub
        End If

        ' Insert ship mark record to FYJOBSMK
        Dim dr_FYJOBSMK() As DataRow
        dr_FYJOBSMK = rs_FYJOBSMK.Tables("RESULT").Select("fsm_creusr <> 'DEL'")
        If dr_FYJOBSMK.Length > 0 Then
            For i As Integer = 0 To dr_FYJOBSMK.Length - 1
                gspStr = "sp_insert_FYJOBSMK '" & cboCoCde.Text & "','" & dr_FYJOBSMK(i)("fsm_jobno") & _
                         "','" & dr_FYJOBSMK(i)("fsm_smkno") & "','" & LCase(gsUsrID) & "'"
                rs_tmp = Nothing
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    'MsgBox("Error on saving FTY00001 #015 sp_insert_FYJOBSMK : " & rtnStr)
                End If
            Next
        End If

        'Generate Report
        gspStr = "sp_select_POR00005_PDO_2 '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POR00005_PDO = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POR00005_PDO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #016 sp_select_POR00005_PDO_2 : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_POR00005_PDO.Tables("RESULT").Columns.Count - 1
                rs_POR00005_PDO.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        Dim dv As DataView = rs_POR00005_PDO.Tables("RESULT").DefaultView
        dv.Sort = "poh_venno, batch"
        rs_POR00005_PDO.Tables.Remove("RESULT")
        rs_POR00005_PDO.Tables.Add(dv.ToTable)

        gspStr = "sp_select_POR00005_PDO_ShpDat '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POR00005_PDO_ShpDat = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POR00005_PDO_ShpDat, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #017 sp_select_POR00005_PDO_2 : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_POR00005_PDO_Assortment_2 '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POR00005_PDO_Assortment = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POR00005_PDO_Assortment, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #018 sp_select_POR00005_PDO_Assortment_2 : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_POR00005_PDO_AttchList '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POR00005_PDO_AttchList = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POR00005_PDO_AttchList, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #019 sp_select_POR00005_PDO_AttchList : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_POR00005_PDO_Attachment '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        rs_POR00005_PDO_Attachment = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_POR00005_PDO_Attachment, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #020 sp_select_POR00005_PDO_Attachment : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_POR00005_PDO_Attachment.Tables("RESULT").Columns.Count - 1
                rs_POR00005_PDO_Attachment.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        ' Retrieve Delivery List
        gspStr = "sp_list_FYDELLIS '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_FYDELLIS = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_FYDELLIS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #022 sp_list_FYDELLIS : " & rtnStr)
            Exit Sub
        End If

        Dim dr_assortment() As DataRow
        Dim dr_attachlist() As DataRow
        For i As Integer = 0 To rs_POR00005_PDO.Tables("RESULT").Rows.Count - 1
            dr_assortment = Nothing
            dr_assortment = rs_POR00005_PDO_Assortment.Tables("RESULT").Select("batch = '" & rs_POR00005_PDO.Tables("RESULT").Rows(i)("batch") & "'")
            If dr_assortment.Length > 0 Then
                rs_POR00005_PDO.Tables("RESULT").Rows(i)("assortment") = "Y"
            End If

            dr_attachlist = Nothing
            dr_attachlist = rs_POR00005_PDO_AttchList.Tables("RESULT").Select("batch = '" & rs_POR00005_PDO.Tables("RESULT").Rows(i)("batch") & "'")
            If dr_attachlist.Length > 0 Then
                rs_POR00005_PDO.Tables("RESULT").Rows(i)("attachlist") = "Y"
            End If

            If rs_POR00005_PDO_Attachment.Tables("RESULT").Rows.Count > 0 Then
                dr_attachlist = Nothing
                dr_attachlist = rs_POR00005_PDO_Attachment.Tables("RESULT").Select("poh_venno = '" & rs_POR00005_PDO.Tables("RESULT").Rows(i)("poh_venno") & "'")
                If dr_attachlist.Length > 0 Then
                    rs_POR00005_PDO.Tables("RESULT").Rows(i)("attachment") = "Y"
                End If
            End If
        Next

        ' Convert Image Filepaths to Image Byte Array
        Dim image As DataColumn
        image = New DataColumn("image", System.Type.GetType("System.Byte[]"))
        rs_POR00005_PDO_Attachment.Tables("RESULT").Columns.Add(image)
        rs_POR00005_PDO_Attachment.Tables("RESULT").Columns("image").ReadOnly = False

        Dim imgAttachment As Byte()
        For i As Integer = 0 To rs_POR00005_PDO_Attachment.Tables("RESULT").Rows.Count - 1
            'rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("filepath") = gs_PDO_SMImg & rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("fsm_smkno")
            rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("filepath") = dir_smk & rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("fsm_smkno")
            imgAttachment = Nothing
            'imgAttachment = resizeImageToByteArray(gs_PDO_SMImg & rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("fsm_smkno"))
            imgAttachment = resizeImageToByteArray(dir_smk & rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("fsm_smkno"))
            rs_POR00005_PDO_Attachment.Tables("RESULT").Rows(i)("image") = imgAttachment
        Next
        rs_POR00005_PDO_Attachment.AcceptChanges()

        Dim objRpt As POR00005_PDORpt

        Dim copyRow As DataRow
        Dim dr() As DataRow
        Dim dr_ftycde() As DataRow
        Dim dr_tmp() As DataRow
        Dim ftycde As String
        Dim filename As String

        If rs_POR00005_PDO.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Unable to generate PDF: No records found", MsgBoxStyle.Critical, "FTY00001 - Generate PN")
            Exit Sub
        Else
            ftycde = rs_POR00005_PDO.Tables("RESULT").Rows(0)("poh_venno")
        End If

        rs_tmp = Nothing
        rs_tmp = rs_POR00005_PDO.Clone()
        rs_tmp.AcceptChanges()

        For i As Integer = 0 To rs_POR00005_PDO.Tables("RESULT").Rows.Count - 1
            If rs_POR00005_PDO.Tables("RESULT").Rows(i)("poh_venno") = ftycde Then
                copyRow = Nothing
                copyRow = rs_tmp.Tables("RESULT").NewRow
                For j As Integer = 0 To rs_POR00005_PDO.Tables("RESULT").Columns.Count - 1
                    copyRow(j) = rs_POR00005_PDO.Tables("RESULT").Rows(i)(j)
                Next
                rs_tmp.Tables("RESULT").Rows.Add(copyRow)
                rs_tmp.AcceptChanges()
            Else
                rs_tmp_attachment = Nothing
                rs_tmp_attachment = rs_POR00005_PDO_Attachment.Clone()
                rs_tmp_attachment.AcceptChanges()

                dr = Nothing
                dr = rs_POR00005_PDO_Attachment.Tables("RESULT").Select("poh_venno = '" & ftycde & "'")
                If dr.Length > 0 Then

                    For j As Integer = 0 To dr.Length - 1
                        copyRow = Nothing
                        copyRow = rs_tmp_attachment.Tables("RESULT").NewRow
                        For k As Integer = 0 To rs_POR00005_PDO_Attachment.Tables("RESULT").Columns.Count - 1
                            copyRow(k) = dr(j)(k)
                        Next
                        rs_tmp_attachment.Tables("RESULT").Rows.Add(copyRow)
                        rs_tmp_attachment.AcceptChanges()
                    Next
                End If

                dr = Nothing
                dr = rs_POJBBDTL.Tables("RESULT").Select("pjd_batseq = '" & Split(rs_tmp.Tables("RESULT").Rows(rs_tmp.Tables("RESULT").Rows.Count - 1)("batch").ToString, "-")(1) & "'")
                If dr.Length > 0 Then
                    dr_ftycde = Nothing
                    dr_ftycde = rs_FYFTYINF.Tables("RESULT").Select("ffi_orgfty = '" & dr(0)("vencde") & "'")
                    If dr_ftycde.Length > 0 Then
                        dr_tmp = Nothing
                        dr_tmp = rs_FYDELLIS.Tables("RESULT").Select("fdl_sendcde = '" & dr_ftycde(0)("ffi_ftycde") & "'")
                        If dr_tmp.Length = 0 Then
                            dr_tmp = rs_FYDELLIS.Tables("RESULT").Select("fdl_sendcde = '" & "OTH" & "'")
                        End If
                        filename = generateFileName(dr_ftycde(0)("ffi_ftycde"))
                        If dr_tmp.Length > 0 Then
                            Dim newRow As DataRow
                            For j As Integer = 0 To dr_tmp.Length - 1
                                newRow = Nothing
                                newRow = rs_files.Tables("RESULT").NewRow
                                newRow("ftycde") = dr_ftycde(0)("ffi_ftycde")
                                newRow("filnam") = filename
                                newRow("filsrc") = dir_tmp & filename
                                newRow("fildst") = "\" & dr_tmp(j)("fdl_recicde") & "\inbox\" & filename
                                rs_files.Tables("RESULT").Rows.Add(newRow)
                            Next
                        End If
                    Else
                        filename = generateFileName("XXX")
                        MsgBox("Error occur during PDF filename generation - Missing Factory Code" & Environment.NewLine & _
                           "Generate Default filename: " & filename, MsgBoxStyle.Exclamation, "FTY00001 - Generate PN")
                    End If
                Else
                    filename = generateFileName("XXX")
                    MsgBox("Error occur during PDF filename generation - Missing Factory Code" & Environment.NewLine & _
                       "Generate Default filename: " & filename, MsgBoxStyle.Exclamation, "FTY00001 - Generate PN")
                End If

                objRpt = Nothing
                objRpt = New POR00005_PDORpt
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                objRpt.Database.Tables("POR00005_PDO").SetDataSource(rs_tmp.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_ShpDat").SetDataSource(rs_POR00005_PDO_ShpDat.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_Assortment").SetDataSource(rs_POR00005_PDO_Assortment.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_AttchList").SetDataSource(rs_POR00005_PDO_AttchList.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_Attachment").SetDataSource(rs_tmp_attachment.Tables("RESULT"))
                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dir_tmp & filename)

                Me.Cursor = Windows.Forms.Cursors.Default

                ' Register job number and file name to FYPDOHIS
                For j As Integer = 0 To rs_tmp.Tables("RESULT").Rows.Count - 1
                    gspStr = "sp_insert_FYPDOHIS '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                             rs_tmp.Tables("RESULT").Rows(j)("pod_jobord") & "','" & filename & "','" & LCase(gsUsrID) & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving FTY00001 #024 sp_insert_FYPDOHIS : " & rtnStr)
                        Exit Sub
                    End If
                Next

                rs_tmp = Nothing
                rs_tmp = rs_POR00005_PDO.Clone()
                rs_tmp.AcceptChanges()

                ftycde = rs_POR00005_PDO.Tables("RESULT").Rows(i)("poh_venno")
                copyRow = Nothing
                copyRow = rs_tmp.Tables("RESULT").NewRow
                For j As Integer = 0 To rs_POR00005_PDO.Tables("RESULT").Columns.Count - 1
                    copyRow(j) = rs_POR00005_PDO.Tables("RESULT").Rows(i)(j)
                Next
                rs_tmp.Tables("RESULT").Rows.Add(copyRow)
                rs_tmp.AcceptChanges()
            End If

            'Generate Report for last Document
            If i >= rs_POR00005_PDO.Tables("RESULT").Rows.Count - 1 Then
                rs_tmp_attachment = Nothing
                rs_tmp_attachment = rs_POR00005_PDO_Attachment.Clone()
                rs_tmp_attachment.AcceptChanges()

                dr = Nothing
                dr = rs_POR00005_PDO_Attachment.Tables("RESULT").Select("poh_venno = '" & ftycde & "'")
                If dr.Length > 0 Then

                    For j As Integer = 0 To dr.Length - 1
                        copyRow = Nothing
                        copyRow = rs_tmp_attachment.Tables("RESULT").NewRow
                        For k As Integer = 0 To rs_POR00005_PDO_Attachment.Tables("RESULT").Columns.Count - 1
                            copyRow(k) = dr(j)(k)
                        Next
                        rs_tmp_attachment.Tables("RESULT").Rows.Add(copyRow)
                        rs_tmp_attachment.AcceptChanges()
                    Next
                End If

                dr = Nothing
                dr = rs_POJBBDTL.Tables("RESULT").Select("pjd_batseq = '" & Split(rs_tmp.Tables("RESULT").Rows(rs_tmp.Tables("RESULT").Rows.Count - 1)("batch").ToString, "-")(1) & "'")
                If dr.Length > 0 Then
                    dr_ftycde = Nothing
                    dr_ftycde = rs_FYFTYINF.Tables("RESULT").Select("ffi_orgfty = '" & dr(0)("vencde") & "'")
                    If dr_ftycde.Length > 0 Then
                        dr_tmp = Nothing
                        dr_tmp = rs_FYDELLIS.Tables("RESULT").Select("fdl_sendcde = '" & dr_ftycde(0)("ffi_ftycde") & "'")
                        If dr_tmp.Length = 0 Then
                            dr_tmp = rs_FYDELLIS.Tables("RESULT").Select("fdl_sendcde = '" & "OTH" & "'")
                        End If
                        filename = generateFileName(dr_ftycde(0)("ffi_ftycde"))
                        If dr_tmp.Length > 0 Then
                            Dim newRow As DataRow
                            For j As Integer = 0 To dr_tmp.Length - 1
                                newRow = Nothing
                                newRow = rs_files.Tables("RESULT").NewRow
                                newRow("ftycde") = dr_ftycde(0)("ffi_ftycde")
                                newRow("filnam") = filename
                                newRow("filsrc") = dir_tmp & filename
                                newRow("fildst") = "\" & dr_tmp(j)("fdl_recicde") & "\inbox\" & filename
                                rs_files.Tables("RESULT").Rows.Add(newRow)
                            Next
                        End If
                    Else
                        filename = generateFileName("XXX")
                        MsgBox("Error occur during PDF filename generation - Missing Factory Code" & Environment.NewLine & _
                           "Generate Default filename: " & filename, MsgBoxStyle.Exclamation, "FTY00001 - Generate PN")
                    End If
                Else
                    filename = generateFileName("XXX")
                    MsgBox("Error occur during PDF filename generation - Missing Factory Code" & Environment.NewLine & _
                       "Generate Default filename: " & filename, MsgBoxStyle.Exclamation, "FTY00001 - Generate PN")
                End If

                objRpt = Nothing
                objRpt = New POR00005_PDORpt
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                objRpt.Database.Tables("POR00005_PDO").SetDataSource(rs_tmp.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_ShpDat").SetDataSource(rs_POR00005_PDO_ShpDat.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_Assortment").SetDataSource(rs_POR00005_PDO_Assortment.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_AttchList").SetDataSource(rs_POR00005_PDO_AttchList.Tables("RESULT"))
                objRpt.Subreports.Item("POR00005_PDO_Attachment").SetDataSource(rs_tmp_attachment.Tables("RESULT"))
                objRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dir_tmp & filename)
                Me.Cursor = Windows.Forms.Cursors.Default

                ' Register job number and file name to FYPDOHIS
                For j As Integer = 0 To rs_tmp.Tables("RESULT").Rows.Count - 1
                    gspStr = "sp_insert_FYPDOHIS '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                             rs_tmp.Tables("RESULT").Rows(j)("pod_jobord") & "','" & filename & "','" & LCase(gsUsrID) & "'"
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on saving FTY00001 #024 sp_insert_FYPDOHIS : " & rtnStr)
                        Exit Sub
                    End If
                Next
            End If
        Next

        ' Send documents to recipient directories
        For i As Integer = 0 To rs_files.Tables("RESULT").Rows.Count - 1
            ' Remove existing document filename from destination
            If File.Exists(rs_files.Tables("RESULT").Rows(i)("filsrc")) Then
                If File.Exists(gs_PDO_FtpDrive & rs_files.Tables("RESULT").Rows(i)("fildst")) Then
                    Try
                        File.Delete(gs_PDO_FtpDrive & rs_files.Tables("RESULT").Rows(i)("fildst"))
                    Catch ex As Exception
                        MsgBox("Error on deleting " & gs_PDO_FtpDrive & rs_files.Tables("RESULT").Rows(i)("fildst") & Environment.NewLine & _
                           ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                    End Try
                End If
                gspStr = "sp_insert_FYFILMAP '" & cboCoCde.Text & "','" & rs_files.Tables("RESULT").Rows(i)("filsrc") & _
                         "','" & rs_files.Tables("RESULT").Rows(i)("fildst") & "','" & LCase(gsUsrID) & "'"
                rs_tmp = Nothing
                rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading FTY00001 #023 sp_insert_FYFILMAP : " & rtnStr)
                    Exit Sub
                End If
                Try
                    File.Copy(rs_files.Tables("RESULT").Rows(i)("filsrc"), gs_PDO_FtpDrive & rs_files.Tables("RESULT").Rows(i)("fildst"))
                Catch ex As Exception
                    MsgBox("Error on copying file to destination source " & gs_PDO_FtpDrive & rs_files.Tables("RESULT").Rows(i)("fildst") & _
                           Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                End Try

            Else
                MsgBox("Missing source file: " & rs_files.Tables("RESULT").Rows(i)("filsrc") & Environment.NewLine & _
                       "File will not be copied to destination " & rs_files.Tables("RESULT").Rows(i)("fildst") & _
                       Environment.NewLine & "Please contact your systems administrator", MsgBoxStyle.Exclamation, "FTY00001 - Generate PN")
            End If
        Next

        ' Backup documents to old folder
        For i As Integer = 0 To rs_files.Tables("RESULT").Rows.Count - 1
            If File.Exists(rs_files.Tables("RESULT").Rows(i)("filsrc")) Then
                If File.Exists(dir_old & rs_files.Tables("RESULT").Rows(i)("filnam")) Then
                    Try
                        File.Delete(dir_old & rs_files.Tables("RESULT").Rows(i)("filnam"))
                    Catch ex As Exception
                        MsgBox("Error on deleting " & dir_old & rs_files.Tables("RESULT").Rows(i)("filnam") & Environment.NewLine & _
                           ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                    End Try
                End If

                Try
                    File.Copy(rs_files.Tables("RESULT").Rows(i)("filsrc"), dir_old & rs_files.Tables("RESULT").Rows(i)("filnam"))
                Catch ex As Exception
                    MsgBox("Error on copying file to destination source " & dir_old & rs_files.Tables("RESULT").Rows(i)("filnam") & _
                           Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                End Try

                ' Delete file source of copied document
                Try
                    File.Delete(rs_files.Tables("RESULT").Rows(i)("filsrc"))
                Catch ex As Exception
                    MsgBox("Error on deleting " & rs_files.Tables("RESULT").Rows(i)("filsrc") & Environment.NewLine & _
                           ex.Message, MsgBoxStyle.Critical, "FTY00001 - Generate PN")
                End Try
            End If
        Next

        MsgBox("Production Note Genereation Success", MsgBoxStyle.Information, "FTY00001 - Generate PN")
        recordStatus = False
        cmdClear.PerformClick()
    End Sub

    Private Sub cmdDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisplay.Click

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to clear?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "FTY00001 - Clear Data") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        setStatus("INIT")
    End Sub

    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to exit?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "FTY00001 - Exit Program") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub pboxPreview_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxPreview.DoubleClick
        If lstShipMark.SelectedItems.Count > 0 Then
            Dim imgPreview As New frmImgPrevw
            imgPreview.setImagePath(gs_PDO_SMImg & lstShipMark.SelectedItem.ToString)
            imgPreview.ShowDialog()
        End If
    End Sub

    Private Sub loadBatchNo()
        AccessRight(Me.Name)
        filllstShipMark()

        dir_app = Application.StartupPath
        If dir_app.Substring(dir_app.Length - 1, 1) <> "\" Then
            dir_app = gs_PDO_localpath
        End If

        'If Directory.Exists(dir_app & "new\") = False Then
        '    Directory.CreateDirectory(dir_app & "new\")
        'End If

        dir_tmp = dir_app & "temp\"
        If Directory.Exists(dir_tmp) = False Then
            Directory.CreateDirectory(dir_tmp)
        End If

        'dir_chk = dir_app & "check\"
        'If Directory.Exists(dir_chk) = False Then
        '    Directory.CreateDirectory(dir_chk)
        'End If

        'dir_SAPEDI = dir_app & "sapedi\"
        'If Directory.Exists(dir_SAPEDI) = False Then
        '    Directory.CreateDirectory(dir_SAPEDI)
        'End If

        'dir_new = dir_app & "new\"
        'If Directory.Exists(dir_new) = False Then
        '    Directory.CreateDirectory(dir_new)
        'End If

        dir_old = dir_app & "old\" & Format(Date.Today, "MMddyyyy").ToString & "\"
        If Directory.Exists(dir_old) = False Then
            Directory.CreateDirectory(dir_old)
        End If

        dir_smk = dir_app & "FYJOBSMK\"
        If Directory.Exists(dir_smk) = False Then
            Directory.CreateDirectory(dir_smk)
        End If

        If Directory.GetFiles(dir_smk).Length > 0 Then
            Dim files() As String = Directory.GetFiles(dir_smk)
            For i As Integer = 0 To files.Length - 1
                Try
                    File.Delete(files(i))
                Catch ex As Exception
                    MsgBox("Error on deleting " & files(i) & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, "FTY00001 - Loading Batch No")
                    Exit Sub
                End Try
            Next
        End If

        Dim rs_tmp As DataSet
        gspStr = "sp_list_FYFTYINF '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_FYFTYINF = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_FYFTYINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #004 sp_list_FYFTYINF : " & rtnStr)
            Exit Sub
        Else
            If rs_FYFTYINF.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No FTY information in FYFTYINF")
            Else
                For i As Integer = 0 To rs_FYFTYINF.Tables("RESULT").Columns.Count - 1
                    rs_FYFTYINF.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If
        End If

        '' Delete File mapping from FYJFILMAP
        'gspStr = "sp_physical_delete_FYFILMAP '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        'rs_tmp = Nothing
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on deleting FTY00001 #005 sp_physical_delete_FYFILMAP : " & rtnStr)
        '    Exit Sub
        'End If

        ' Delete ship mark record to FYJOBSMK
        gspStr = "sp_physical_delete_FYJOBSMK '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_tmp = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on deleting FTY00001 #006 sp_physical_delete_FYJOBSMK : " & rtnStr)
            Exit Sub
        End If

        ' GET EMPTY STRUCTURE FROM FYJOBSMK
        gspStr = "sp_list_FYJOBSMK '" & cboCoCde.Text & "','" & LCase(gsUsrID) & "'"
        rs_FYJOBSMK = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_FYJOBSMK, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #007 sp_list_FYJOBSMK : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_FYJOBSMK.Tables("RESULT").Columns.Count - 1
                rs_FYJOBSMK.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If
    End Sub

    Private Sub filllstShipMark()
        If Not Directory.Exists(gs_PDO_SMImg) Then
            MsgBox("Directory Not Exist!" & Environment.NewLine & gs_PDO_SMImg)
            Exit Sub
        End If

        Dim Dir As New System.IO.DirectoryInfo(gs_PDO_SMImg)
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(filePattern)
        Dim File As System.IO.FileInfo
        lstShipMark.Items.Clear()
        For Each File In Files
            'Add the file name to the lstFiles listbox
            lstShipMark.Items.Add(File.Name)
        Next
        lstShipMark.Sorted = True
        lstShipMark.Refresh()
    End Sub

    Private Sub displayPreview()
        If chkPreview.Checked Then
            If Not lstShipMark.SelectedItem Is Nothing Then
                pboxPreview.Load(gs_PDO_SMImg & lstShipMark.SelectedItem.ToString)
                pboxPreview.SizeMode = PictureBoxSizeMode.Zoom
                pboxPreview.Visible = True
            Else
                pboxPreview.Visible = False
            End If
        Else
            pboxPreview.Image = Nothing
            pboxPreview.Visible = False
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            cboCoCde.Enabled = True
            txtCoNam.Enabled = False
            txtCoNam.ReadOnly = True
            txtBJNo.Enabled = True
            cmdNext.Enabled = True

            lstNewOrder.Items.Clear()
            lstNewOrder.Enabled = False
            lstSelShipMark.Items.Clear()
            lstSelShipMark.Enabled = False
            cmdAdd.Enabled = False
            cmdRemove.Enabled = False
            lstShipMark.Items.Clear()
            lstShipMark.Enabled = False
            lblFty.Enabled = False
            lblFty.ReadOnly = True
            chkPreview.Checked = False
            chkPreview.Enabled = False
            cmdGenerate.Enabled = False
            cmdDisplay.Enabled = False
            cmdClear.Enabled = True
            cmdQuit.Enabled = True

            recordStatus = False
            ClearScreen()
        ElseIf mode = "NEXT" Then
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False
            txtCoNam.ReadOnly = True
            txtBJNo.Enabled = False
            cmdNext.Enabled = False

            'lstNewOrder.Items.Clear()
            lstNewOrder.Enabled = True
            'lstSelShipMark.Items.Clear()
            lstSelShipMark.Enabled = True
            cmdAdd.Enabled = True
            cmdRemove.Enabled = True
            'lstShipMark.Items.Clear()
            lstShipMark.Enabled = True
            lblFty.Enabled = True
            lblFty.ReadOnly = True
            chkPreview.Checked = False
            chkPreview.Enabled = True
            cmdGenerate.Enabled = True
            cmdDisplay.Enabled = True
            cmdClear.Enabled = True
            cmdQuit.Enabled = True

            recordStatus = True
        End If
    End Sub

    Private Sub ClearScreen()
        txtBJNo.Text = ""
        lblFty.Text = ""
    End Sub

    Private Function resizeImageToByteArray(ByVal ImageFilePath As String) As Byte()
        Dim _tempByte() As Byte = Nothing

        If ImageFilePath = "" Then
            Return Nothing
        End If

        If String.IsNullOrEmpty(ImageFilePath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If

        Try
            Dim bm_source As New Bitmap(ImageFilePath)
            Dim scaleFactor As Double = 1

            Dim imageHeight As Integer = bm_source.Height
            Dim imageWidth As Integer = bm_source.Width

            If imageHeight <= imgMaxHeight And imageWidth <= imgMaxWidth Then
                'scaleFactor = 1
                If (imgMaxHeight / imageHeight) < (imgMaxWidth / imageWidth) Then
                    scaleFactor = imgMaxHeight / imageHeight
                Else
                    scaleFactor = imgMaxWidth / imageWidth
                End If
            ElseIf imageHeight > imgMaxHeight And imageWidth <= imgMaxWidth Then
                scaleFactor = imgMaxHeight / imageHeight
            ElseIf imageHeight <= imgMaxHeight And imageWidth > imgMaxWidth Then
                scaleFactor = imgMaxWidth / imageWidth
            Else
                If (imgMaxHeight / imageHeight) < (imgMaxWidth / imageWidth) Then
                    scaleFactor = imgMaxHeight / imageHeight
                Else
                    scaleFactor = imgMaxWidth / imageWidth
                End If
            End If

            Dim bm_dest As New Bitmap(CInt(bm_source.Width * scaleFactor), CInt(bm_source.Height * scaleFactor))

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

            Using stream As New System.IO.MemoryStream
                bm_dest.Save(stream, bm_source.RawFormat)
                _tempByte = stream.ToArray
            End Using

            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function generateFileName(ByVal ftycde As String) As String
        Dim rs_tmp As DataSet
        Dim filename As String

        gspStr = "sp_select_FYPDODOC_generate '" & cboCoCde.Text & "','" & ftycde & "','" & fileExtension & "','" & LCase(gsUsrID) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FTY00001 #021 sp_select_FYPDODOC : " & rtnStr)
            Exit Function
        Else
            If rs_tmp.Tables("RESULT").Rows.Count > 0 Then
                filename = rs_tmp.Tables("RESULT").Rows(0)("fpd_filnam")
            Else
                filename = ftycde & Format(Date.Today, "MMdd") & "01" & fileExtension
            End If
        End If

        Return filename
    End Function
End Class