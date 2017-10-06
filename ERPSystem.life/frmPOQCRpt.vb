Public Class frmPOQCRpt
    Dim rs_QCRpt As DataSet
    Dim reportLoc_global As String


    Public Sub New(ByVal pono As String, ByRef mdiParent As Form)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtPONo.Text = pono
        If Not (mdiParent Is Nothing) Then
            Me.MdiParent = mdiParent
        End If
        Call cmdOK_Click()

    End Sub

    Private Sub cmdOK_Click()
        gspStr = "sp_list_POQCRPT '','" & txtPONo.Text & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_QCRpt, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdOK_Click #001 sp_list_POQCRPT : " & rtnStr)
        Else
            If rs_QCRpt.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record found!")
                Me.Close()

            Else
                'dgqcrpt.DataSource = rs.Tables("RESULT").DefaultView

                Call format_dgQCRpt()
                txtPONo.Enabled = False
                cmdOK.Enabled = True
                cmdClear.Enabled = True
                Me.Show()
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        gspStr = "sp_list_POQCRPT '','" & txtPONo.Text & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_QCRpt, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdOK_Click #001 sp_list_POQCRPT : " & rtnStr)
        Else
            If rs_QCRpt.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record found!")
            Else
                'dgqcrpt.DataSource = rs.Tables("RESULT").DefaultView

                Call format_dgQCRpt()
                txtPONo.Enabled = False
                cmdOK.Enabled = True
                cmdClear.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmPOQCRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
    End Sub

    Private Sub format_dgQCRpt()
        dgQCRpt.DataSource = rs_QCRpt.Tables("RESULT").DefaultView

        dgQCRpt.RowHeadersWidth = 18
        dgQCRpt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgQCRpt.ColumnHeadersHeight = 18
        dgQCRpt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgQCRpt.AllowUserToResizeColumns = True
        dgQCRpt.AllowUserToResizeRows = False
        dgQCRpt.RowTemplate.Height = 18
        dgQCRpt.AllowUserToOrderColumns = True

        With dgQCRpt
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "PO No"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 1
                        .Columns(i).HeaderText = "Rpt ID"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "QC Req No."
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Item No"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Cust Item"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Item Dsc"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Insp Date"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "QC Type"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "QC Status"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Result"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Final Status"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Shipment Approval"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        dgQCRpt.ClearSelection()
        dgQCRpt.CurrentCell = Nothing
        dgQCRpt.Refresh()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dgQCRpt.DataSource = Nothing
        txtPONo.Enabled = False
        cmdOK.Enabled = True
        cmdClear.Enabled = True
    End Sub

    Private Sub imgShipMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If reportLoc_global <> "" Then
            server_QC_destpth = "\\192.168.1.219\ERPQCAttachment\test\"
            System.Diagnostics.Process.Start(server_QC_destpth & "\" & reportLoc_global)
        End If

    End Sub

    Private Sub dgQCRpt_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQCRpt.CellClick
        reportLoc_global = dgQCRpt.Rows(e.RowIndex).Cells(12).Value.ToString

        For i As Integer = 0 To dgQCRpt.Rows.Count - 1
            dgQCRpt.Rows(i).DefaultCellStyle.BackColor = Color.White
        Next
        dgQCRpt.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue

    End Sub

    Private Sub dgQCRpt_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQCRpt.CellContentClick

    End Sub

    Private Sub dgQCRpt_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQCRpt.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim reportLoc As String = dgQCRpt.Rows(e.RowIndex).Cells(12).Value.ToString

            If reportLoc <> "" Then
                server_QC_destpth = "\\192.168.1.219\ERPQCAttachment\test\"
                System.Diagnostics.Process.Start(server_QC_destpth & "\" & reportLoc)




            End If
        End If
    End Sub
End Class