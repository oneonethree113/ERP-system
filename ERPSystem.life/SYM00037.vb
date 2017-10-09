Public Class SYM00037
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdRel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdApv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00037))
        Me.dgCharge = New System.Windows.Forms.DataGridView
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdRel = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdApv = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(0, 27)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowTemplate.Height = 24
        Me.dgCharge.Size = New System.Drawing.Size(954, 577)
        Me.dgCharge.TabIndex = 5
        '
        'StatusBar
        '
        Me.StatusBar.AutoSize = False
        Me.StatusBar.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 99
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 19)
        Me.lblLeft.Text = "Init"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 2111
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdRel, Me.mmdApv})
        Me.mmdFunction.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
        Me.mmdFunction.Text = "Function"
        '
        'mmdRel
        '
        Me.mmdRel.Name = "mmdRel"
        Me.mmdRel.Size = New System.Drawing.Size(121, 22)
        Me.mmdRel.Text = "Release"
        '
        'mmdApv
        '
        Me.mmdApv.Name = "mmdApv"
        Me.mmdApv.Size = New System.Drawing.Size(121, 22)
        Me.mmdApv.Text = "Approval"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(36, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'SYM00037
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.dgCharge)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "SYM00037"
        Me.Text = "SYM00037 - Claim Category Maintenance (SYM37)"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYCLMTYP As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer


    Private Sub SYM00037_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        validcheck = 1
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right



            gsCompany = "UCP"
            gspStr = "sp_list_SYCLMTYP'" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYCLMTYP, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00037 #001 sp_list_SYCLMTYP : " & rtnStr)
            Else
                dgCharge.DataSource = rs_SYCLMTYP.Tables("RESULT").DefaultView

                rs_SYCLMTYP.Tables("RESULT").Columns(0).ReadOnly = False


                Call format_dgCharge()
                Call setDataRowAttr()
                Call SetStatusBar("Init")
                mode = "INIT"
                Call setStatus(mode)

            End If
            Call Formstartup(Me.Name)

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try

        Dim dv2 As DataView = rs_SYCLMTYP.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "yct_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yct_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yct_upddat"), "MM/dd/yyyy") & " " & drv.Item("yct_updusr")

            dv2.Sort = Nothing
        End If

    End Sub



    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.StatusBar.Items("lblLeft").Text = "Init" Then
            Me.Close()
        Else

            If Me.StatusBar.Items("lblLeft").Text = "Insert Row" Or Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call mmdSave_Click(sender, e)

                    If save_ok Then


                        Exit Sub
                    End If

                ElseIf YNC = Windows.Forms.DialogResult.No Then
                    Me.Close()

                ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub SetStatusBar(ByVal m As String)

        If m = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf m = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf m = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf m = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf m = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf m = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf m = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        ElseIf m = "Change Status" Then
            Me.StatusBar.Items("lblLeft").Text = "Change Status"
        ElseIf m = "Change Status R-Readonly" Then
            Me.StatusBar.Items("lblLeft").Text = "Change Status R-Readonly"
        ElseIf m = "Change Status A-Add" Then
            Me.StatusBar.Items("lblLeft").Text = "Change Status A-Add"
        ElseIf m = "Change Status C-Cancel" Then
            Me.StatusBar.Items("lblLeft").Text = "Change Status C-Cancel"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.StatusBar.Items("lblLeft").Text = ""
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_SYCLMTYP.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next

            For Each dr As DataRow In dt.Rows
                dr.Item("yct_del") = ""
            Next
            rs_SYCLMTYP.AcceptChanges()
        End If
    End Sub

    Private Sub format_dgCharge()
        Dim i As Integer
        i = 0
        With dgCharge
            '0
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Del"
            i = i + 1
            '1
            .Columns(i).Width = 40
            .Columns(i).HeaderText = "Code"
            i = i + 1
            '2
            .Columns(i).Width = 250
            .Columns(i).HeaderText = "Desc"
            i = i + 1
            '3
            .Columns(i).Width = 65
            .Columns(i).HeaderText = "Customer"
            i = i + 1

            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Vendor"
            i = i + 1

            .Columns(i).Width = 55
            .Columns(i).HeaderText = "UCPPC"
            i = i + 1

            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Sales Aceess Right"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Shipping Aceess Right"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Acct Aceess Right"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "SM approve right"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "SZ approve right"
            i = i + 1
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Ship Mgt approve right"
            i = i + 1
            .Columns(i).Width = 75
            .Columns(i).HeaderText = "Approve Amt (USD)"
            i = i + 1

            Dim j As Integer
            For j = i To dgCharge.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim addnewrow As Boolean

        addnewrow = False

        Call SetStatusBar("InsRow")
        Call setStatus("InsRow")


        If rs_SYCLMTYP.Tables("RESULT").Rows.Count = 0 Then
            addnewrow = True
        ElseIf rs_SYCLMTYP.Tables("RESULT").Rows(rs_SYCLMTYP.Tables("RESULT").Rows.Count - 1).Item("yct_cde").ToString = "" Or rs_SYCLMTYP.Tables("RESULT").Rows(rs_SYCLMTYP.Tables("RESULT").Rows.Count - 1).Item("yct_dsc").ToString = "" Then

            addnewrow = False
            MsgBox("Please insert the information (code and description) first before adding the new row")

            'MsgBox("Please insert the right information format first before add the new row")

            For Each row As DataGridViewRow In dgCharge.Rows
                If row.Cells("yct_cde").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yct_cde")
                ElseIf row.Cells("yct_dsc").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yct_dsc")
                End If
            Next

        ElseIf rs_SYCLMTYP.Tables("RESULT").Rows(rs_SYCLMTYP.Tables("RESULT").Rows.Count - 1).Item("yct_creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 Then
                addnewrow = True
            Else
                MsgBox("Please insert the right information format first before adding the new row")
                addnewrow = False
            End If
        End If


        If addnewrow = True Then
            dsNewRow = rs_SYCLMTYP.Tables("RESULT").NewRow()

            dsNewRow.Item("yct_creusr") = "~*ADD*~"
            dsNewRow.Item("yct_del") = ""

            rs_SYCLMTYP.Tables("RESULT").Rows.Add(dsNewRow)
            For Each drr As DataGridViewRow In dgCharge.Rows
                If IsDBNull(drr.Cells(3).Value) Then
                    dgCharge.CurrentCell = drr.Cells(1)
                    dgCharge.CurrentCell.ReadOnly = False
                    dgCharge.BeginEdit(True)
                End If
            Next
        End If


        mmdClear.Enabled = True

    End Sub






    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then

                If Not row.Cells("yct_cde").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If
                row.Cells("yct_del").ReadOnly = True
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then

                If row.Cells("yct_del").Value.ToString = "" And row.Cells("yct_creusr").Value.ToString = "~*ADD*~" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    dgCharge.BeginEdit(True)

                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True

                End If

            End If

            If ((e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5) Or (e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8) Or (e.ColumnIndex = 9 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11)) And Not row.Cells("yct_cde").Value.ToString = "" Then
                If e.ColumnIndex = 3 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_cus").Value.ToString = "" Then
                            row.Cells("yct_cus").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_cus").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If


                End If
                If e.ColumnIndex = 4 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_ven").Value.ToString = "" Then
                            row.Cells("yct_ven").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_ven").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If

                End If
                If e.ColumnIndex = 5 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_ucp").Value.ToString = "" Then
                            row.Cells("yct_ucp").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_ucp").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If
                End If

                '''6,7,8
                ''' 
                If e.ColumnIndex = 6 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_Salaccrgt").Value.ToString = "" Then
                            row.Cells("yct_Salaccrgt").Value = "R"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status R-Readonly")
                        ElseIf row.Cells("yct_Salaccrgt").Value.ToString = "R" Then
                            row.Cells("yct_Salaccrgt").Value = "A"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status A-Add")
                        ElseIf row.Cells("yct_Salaccrgt").Value.ToString = "A" Then
                            row.Cells("yct_Salaccrgt").Value = "C"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status C-Cancel")
                        Else
                            row.Cells("yct_Salaccrgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If


                End If
                If e.ColumnIndex = 7 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_Shpaccrgt").Value.ToString = "" Then
                            row.Cells("yct_Shpaccrgt").Value = "R"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status R-Readonly")
                        ElseIf row.Cells("yct_Shpaccrgt").Value.ToString = "R" Then
                            row.Cells("yct_Shpaccrgt").Value = "A"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status A-Add")
                        ElseIf row.Cells("yct_Shpaccrgt").Value.ToString = "A" Then
                            row.Cells("yct_Shpaccrgt").Value = "C"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status C-Cancel")
                        Else
                            row.Cells("yct_Shpaccrgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If

                End If
                If e.ColumnIndex = 8 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_Acctaccrgt").Value.ToString = "" Then
                            row.Cells("yct_Acctaccrgt").Value = "R"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status R-Readonly")
                        ElseIf row.Cells("yct_Acctaccrgt").Value.ToString = "R" Then
                            row.Cells("yct_Acctaccrgt").Value = "A"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status A-Add")
                        ElseIf row.Cells("yct_Acctaccrgt").Value.ToString = "A" Then
                            row.Cells("yct_Acctaccrgt").Value = "C"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")
                            Call SetStatusBar("Change Status C-Cancel")
                        Else
                            row.Cells("yct_Acctaccrgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If


                End If

                '''9,10,11
                ''' 
                If e.ColumnIndex = 9 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_SMApprgt").Value.ToString = "" Then
                            row.Cells("yct_SMApprgt").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_SMApprgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If


                End If
                If e.ColumnIndex = 10 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_SZApprgt").Value.ToString = "" Then
                            row.Cells("yct_SZApprgt").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_SZApprgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If

                End If
                If e.ColumnIndex = 11 Then

                    If Not row.Cells("yct_cde").Value.ToString = "" Then
                        If row.Cells("yct_ShpApprgt").Value.ToString = "" Then
                            row.Cells("yct_ShpApprgt").Value = "Y"
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("yct_ShpApprgt").Value = ""
                            Call setStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If


                End If
            End If '''Y/N  /   R/A/C

            If e.ColumnIndex = 12 Then
                row.Cells("yct_AppAmt").ReadOnly = False

                'row.Cells("yct_AppAmt").ReadOnly = False
            End If


        End If

        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub dgCharge_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEnter

        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then

            If row.Cells("yct_del").Value.ToString = "" And row.Cells("yct_creusr").Value.ToString = "~*ADD*~" Then
                row.Cells(e.ColumnIndex).ReadOnly = False
                dgCharge.BeginEdit(True)
            Else
                row.Cells(e.ColumnIndex).ReadOnly = True

            End If

        End If

    End Sub



    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCharge.CellValidating
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String


        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("yct_cde"), "Z+Numeric", 2) Then

                    row.DataGridView.CurrentCell = row.Cells("yct_cde")
                    validcheck = 0
                    'Exit Sub
                    e.Cancel = True
                ElseIf row.Cells("yct_cde").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in function code!")
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    'Exit Sub
                    e.Cancel = True
                ElseIf Not (row.Cells("yct_cde").EditedFormattedValue.ToString.Length = 2) Then
                    MsgBox("Length of function code is not 2 digit!")
                    row.DataGridView.CurrentCell = row.Cells("yct_cde")
                    validcheck = 0
                    'Exit Sub
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yct_cde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated function code!")
                                row.DataGridView.CurrentCell = row.Cells("yct_cde")
                                validcheck = 0
                                Exit Sub
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next

                End If





                If chkGrdCellValue(row.Cells("yct_cde"), "Z+Numeric", 2) Then


                    If row.Cells("yct_cde").EditedFormattedValue.ToString.Length <> 0 Then


                        If row.Cells("yct_cde").EditedFormattedValue.ToString.Length = 2 Then

                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> e.RowIndex Then
                                    If drr.Cells("yct_cde").Value.ToString.ToUpper <> strNewVal.ToUpper Then

                                        validcheck = 1
                                    Else
                                        MsgBox("Duplicated function code!")
                                        validcheck = 0
                                        'Exit Sub
                                        e.Cancel = True
                                        Exit For
                                    End If
                                End If
                            Next
                        End If

                    End If

                End If

            End If
        End If


    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("yct_cde").Value.ToString = "" Then
                If row.Cells("yct_del").Value.ToString = "" Then
                    row.Cells("yct_del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yct_del").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
                Call SetStatusBar("DelRow")

            End If
        End If
    End Sub


    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click

        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows


                If row.Cells("yct_del").Value.ToString = "" Then



                    If Not chkGrdCellValue(row.Cells("yct_cde"), "Z+Numeric", 2) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yct_cde")



                    ElseIf Not (row.Cells("yct_cde").EditedFormattedValue.ToString.Length = 2) Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("The code should be 2 digit!")
                        row.DataGridView.CurrentCell = row.Cells("yct_cde")


                    ElseIf row.Cells("yct_dsc").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Description should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yct_dsc")
                    Else
                        If row.Cells("yct_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yct_cde").Value.ToString.ToUpper = row.Cells("yct_cde").Value.ToString.ToUpper And _
                                       drr.Cells("yct_del").Value.ToString = "" Then
                                        'If drr.Cells("yct_cde").Value.ToString.ToUpper = row.Cells("yct_cde").Value.ToString.ToUpper Then
                                        MsgBox("Duplicated function code " & drr.Cells("yct_cde").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yct_cde")
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

                For Each drr As DataGridViewRow In dgCharge.Rows

                    If drr.Cells("yct_ucp").Value.ToString.ToUpper <> "Y" And _
                        drr.Cells("yct_cus").Value.ToString.ToUpper <> "Y" And _
                        drr.Cells("yct_ven").Value.ToString.ToUpper <> "Y" Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = drr.Cells(0)
                        Me.dgCharge.Rows(drr.Index).Selected = True


                        MsgBox("At least one option selected!")
                        Exit For
                    End If
                Next

                If Not save_ok Then
                    Exit For
                End If
            Next

            If Not save_ok Then
                dgCharge.BeginEdit(True)
                Exit Sub
            Else

                gspStr = ""
                For Each dr As DataRow In rs_SYCLMTYP.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        gsCompany = ""
                        If dr.Item("yct_del") = "Y" Then

                            gspStr = "sp_physical_delete_SYCLMTYP '" & gsCompany & "','" & _
                                        dr.Item("yct_cde").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYCLMTYP '" & gsCompany & "','" & _
                                        dr.Item("yct_cde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_cus").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_ven").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_ucp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_Salaccrgt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_Shpaccrgt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_Acctaccrgt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_SMApprgt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_SZApprgt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_ShpApprgt").ToString.Replace("'", "''").Trim & "'," & _
                                        IIf(IsDBNull(dr.Item("yct_AppAmt")), 0, dr.Item("yct_AppAmt")) & ",'" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yct_del") = "Y" Then

                        If dr.Item("yct_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCLMTYP '" & gsCompany & "','" & _
                                        dr.Item("yct_cde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_cus").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_ven").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yct_ucp").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00037 sp_update_SYCLMTYP : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_SYCLMTYP.AcceptChanges()
                    Call setStatus("Save")
                    SetStatusBar("Save")
                    Call SYM00037_Load(sender, e)
                Else
                    save_ok = False
                    rs_SYCLMTYP.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_SYCLMTYP.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_SYCLMTYP.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If


        If Me.StatusBar.Items("lblLeft").Text = "Insert Row" Or Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted" Or Me.StatusBar.Items("lblLeft").Text = "Change Status" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call mmdSave_Click(sender, e)

                If save_ok Then

                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00037_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00037_Load(sender, e)
        End If
    End Sub




    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = False

            Me.mmdSearch.Enabled = False

            Me.mmdInsRow.Enabled = True
            Me.mmdDelRow.Enabled = True


            Me.mmdExit.Enabled = True


            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Change Status" Then
            Me.mmdSave.Enabled = True
            Me.mmdDelete.Enabled = False
            Me.mmdDelRow.Enabled = True
            Me.mmdClear.Enabled = True
        ElseIf mode = "InsRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Me.mmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00037_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Me.mmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub


End Class
