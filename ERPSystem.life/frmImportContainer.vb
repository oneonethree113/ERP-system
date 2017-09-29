Imports System.Collections.Generic


Public Class frmImportContainer

    Inherits System.Windows.Forms.Form

    Public ma As SHM00001
    Private Const sMODULE As String = "SH"
    Dim rs_SHIPGDTL_cov_list As DataSet
    Public flag_ok_click As Boolean = False




    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Call ma.check_conatiner(txtCtrCfs.Text)
        Dim ctncfs_a = Split(txtCtrCfs.Text, ";")
        Dim already_insert As Boolean
        flag_ok_click = False

        Dim result As Integer = MessageBox.Show("After import cov shippment will be save automatically, Are you sure?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Me.Close()
        ElseIf result = DialogResult.Yes Then

            flag_ok_click = True
            For i As Integer = 0 To UBound(ctncfs_a) - 1
                already_insert = False
                For j As Integer = 0 To i - 1
                    If ctncfs_a(i) = ctncfs_a(j) Then
                        already_insert = True
                    End If
                Next
                If already_insert = False Then
                    Call ma.Insert_container(ctncfs_a(i))
                End If
            Next


            ''        for index9 As Integer = 0 to rs_SHIPGDTL_cov_list.Tables("RESULT").
            'Dim rs_tmp As DataSet
            'Dim hid_shpno As String
            'rs_tmp = rs_SHIPGDTL_cov_list.Copy
            'rs_tmp.Tables("result").DefaultView.RowFilter = "hid_ctrcfs = '" & txtCtrCfs.Text.Trim & "'"
            'If rs_tmp.Tables("result").DefaultView.Count > 0 Then
            '    hid_shpno = rs_tmp.Tables("result").DefaultView(0)("hid_shpno")
            'End If

            ma.flag_need_delete_container = True
            ma.delete_container_number = txtCtrCfs.Text.Trim
            MsgBox("After shipment saved, the container:" & ma.delete_container_number & " will be deleted from the COV!")

            '''
            ''Call ma.cmdSaveClick()
            Me.Close()
        End If
    End Sub


    Private Sub frmImportContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_list_shipgdtl_cov  '" & ma.cboCoCde.Text.Trim & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_cov_list, rtnStr)


        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAddClick sp_select_SHIPGDTL :" & rtnStr)
            Exit Sub
        End If

        For i As Integer = 0 To rs_SHIPGDTL_cov_list.Tables("RESULT").Columns.Count - 1
            rs_SHIPGDTL_cov_list.Tables("RESULT").Columns(i).ReadOnly = True
        Next i

        Call display_cov_list()



    End Sub


    Private Sub display_cov_list()


        If rs_SHIPGDTL_cov_list Is Nothing Then
            Exit Sub
        End If

        If rs_SHIPGDTL_cov_list.Tables("result") Is Nothing Then
            Exit Sub
        End If

        dgcov.DataSource = rs_SHIPGDTL_cov_list.Tables("result").DefaultView
        dgcov.Refresh()

        With dgcov
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Conainer Number"
                        .Columns(i).Width = 249
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

    End Sub

    Private Sub dgcov_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcov.CellContentClick

    End Sub

    Private Sub dgcov_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcov.CellDoubleClick



        txtCtrCfs.Text = txtCtrCfs.Text & rs_SHIPGDTL_cov_list.Tables("result").DefaultView(e.RowIndex)("hid_ctrcfs") & ";"

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    
End Class