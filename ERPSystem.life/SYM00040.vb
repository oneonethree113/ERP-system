Public Class SYM00040
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
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00040))
        Me.dgCharge = New System.Windows.Forms.DataGridView
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
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(0, 6)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowTemplate.Height = 24
        Me.dgCharge.Size = New System.Drawing.Size(954, 583)
        Me.dgCharge.TabIndex = 5
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 2113
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
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 2114
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 19)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgCharge)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(954, 589)
        Me.GroupBox1.TabIndex = 2115
        Me.GroupBox1.TabStop = False
        '
        'SYM00040
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "SYM00040"
        Me.Text = "SYM00040 - AQL Maintenance (SYM40)"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYMAQL As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer


    Private Sub SYM00040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        validcheck = 1
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right



            gsCompany = "UCP"
            gspStr = "sp_list_SYMAQL'" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYMAQL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00040 #001 sp_list_SYMAQL : " & rtnStr)
            Else
                dgCharge.DataSource = rs_SYMAQL.Tables("RESULT").DefaultView

                rs_SYMAQL.Tables("RESULT").Columns(0).ReadOnly = False
                'rs_SYMAQL.Tables("RESULT").Columns(2).ReadOnly = False
                'rs_SYMAQL.Tables("RESULT").Columns(3).ReadOnly = False
                rs_SYMAQL.Tables("RESULT").Columns(4).ReadOnly = False
                rs_SYMAQL.Tables("RESULT").Columns(5).ReadOnly = False
                rs_SYMAQL.Tables("RESULT").Columns(6).ReadOnly = False


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

        Dim dv2 As DataView = rs_SYMAQL.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "yal_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yal_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yal_upddat"), "MM/dd/yyyy") & " " & drv.Item("yal_updusr")

            dv2.Sort = Nothing
        End If



    End Sub



    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Me.StatusBar.Items("lblLeft").Text = "Record Row Delete"
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
        Dim dt As DataTable = rs_SYMAQL.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next

            For Each dr As DataRow In dt.Rows
                dr.Item("yal_del") = ""
            Next
            rs_SYMAQL.AcceptChanges()
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
            '0
            .Columns(i).Width = 0
            .Columns(i).HeaderText = "co"
            .Columns(i).Visible = False
            i = i + 1
            '1
            .Columns(i).Width = 90
            .Columns(i).HeaderText = "From"
            i = i + 1
            '2
            .Columns(i).Width = 99
            .Columns(i).HeaderText = "to"
            i = i + 1
            '3
            .Columns(i).Width = 65
            .Columns(i).HeaderText = "Sample"
            i = i + 1

            .Columns(i).Width = 55
            .Columns(i).HeaderText = "15"
            i = i + 1

            .Columns(i).Width = 55
            .Columns(i).HeaderText = "25"
            i = i + 1

            Dim j As Integer
            For j = i To dgCharge.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim addnewrow As Boolean

        addnewrow = True

        Call SetStatusBar("InsRow")
        Call setStatus("InsRow")

        If addnewrow = True Then
            dsNewRow = rs_SYMAQL.Tables("RESULT").NewRow()

            dsNewRow.Item("yal_creusr") = "~*ADD*~"
            dsNewRow.Item("yal_del") = ""

            rs_SYMAQL.Tables("RESULT").Rows.Add(dsNewRow)
            For Each drr As DataGridViewRow In dgCharge.Rows
                'If IsDBNull(drr.Cells(3).Value) Then
                '    dgCharge.CurrentCell = drr.Cells(1)
                '    dgCharge.CurrentCell.ReadOnly = False
                '    dgCharge.BeginEdit(True)
                'End If

                drr.Cells(0).ReadOnly = False
                drr.Cells(2).ReadOnly = False
                drr.Cells(3).ReadOnly = False
                drr.Cells(4).ReadOnly = False
                drr.Cells(5).ReadOnly = False
                drr.Cells(6).ReadOnly = False
            Next
        End If


        mmdClear.Enabled = True

    End Sub






    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick

    End Sub

    Private Sub dgCharge_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellDoubleClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then


            If e.ColumnIndex = 0 Then

                If row.Cells("yal_del").Value.ToString = "" Or row.Cells("yal_del").Value.ToString = "N" Then
                    row.Cells("yal_del").Value = "Y"
                Else
                    row.Cells("yal_del").Value = "N"
                End If

            End If



        End If

        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub dgCharge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEndEdit

        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String



        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim
        If e.ColumnIndex = 0 Then
            If strNewVal <> "Y" And strNewVal <> "N" Then
                row.Cells(e.ColumnIndex).Value = ""
            End If
        Else
            If Not IsNumeric(strNewVal) Then
                row.Cells(e.ColumnIndex).Value = "0"
            End If

            'If check_overlap() = True Then
            '    MsgBox("From to of this row is  Overlapped!")
            '    row.Cells(e.ColumnIndex).Value = "0"
            '    Exit Sub
            'End If

            'If check_fromto() = True Then
            '    MsgBox("From should not be larger than To!")
            '    row.Cells(e.ColumnIndex).Value = "0"
            'End If
            If row.Cells("yal_creusr").Value <> "~*ADD*~" Then
                row.Cells("yal_creusr").Value = "~*UPD*~"
                mmdSave.Enabled = Enq_right_local


            End If
        End If

    End Sub

    Private Sub dgCharge_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEnter

        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If e.ColumnIndex = 0 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
            row.Cells(e.ColumnIndex).ReadOnly = False
            'dgCharge.BeginEdit(True)
        Else
            row.Cells(e.ColumnIndex).ReadOnly = True
        End If

        If row.Cells("yal_del").Value.ToString <> "Y" And row.Cells("yal_creusr").Value.ToString = "~*ADD*~" Then
            row.Cells(e.ColumnIndex).ReadOnly = False
            'dgCharge.BeginEdit(True)
        Else
            '''''''''''''''''''''''''''''''''''''''                row.Cells(e.ColumnIndex).ReadOnly = True

        End If


    End Sub



    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If row.Cells("yal_del").Value.ToString = "" Or row.Cells("yal_del").Value.ToString = "N" Then
                row.Cells("yal_del").Value = "Y"
                ' cellStyle.BackColor = Color.LightBlue
            Else
                row.Cells("yal_del").Value = "N"
                '  cellStyle.BackColor = Nothing
            End If
            row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle

            Call setStatus("DelRow")
            Call SetStatusBar("DelRow")
        End If

    End Sub


    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click

        If check_overlap() = True Then
            MsgBox("From to of this row is  Overlapped!")
            Exit Sub
        End If

        If check_fromto() = True Then
            MsgBox("From should not be larger than To!")
            Exit Sub
        End If


        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            'save_ok = True
            'bindSrc.EndEdit()




            gspStr = ""
            For Each dr As DataRow In rs_SYMAQL.Tables("RESULT").Rows

                'If dr.RowState = DataRowState.Modified Then
                gsCompany = ""
                If dr.Item("yal_del") = "Y" Then

                    gspStr = "sp_physical_delete_SYMAQL '" & gsCompany & "','" & _
                                dr.Item("yal_lotfm").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_lotto").ToString.Replace("'", "''").Trim & "'"
                ElseIf dr.Item("yal_creusr") = "~*UPD*~" Then
                    gspStr = "sp_update_SYMAQL '" & gsCompany & "','" & _
                              dr.Item("yal_lotfm").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_lotto").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_sample").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_aql15").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_aql25").ToString.Replace("'", "''").Trim & "','" & _
                                gsUsrID & "'"

                ElseIf dr.Item("yal_creusr") = "~*ADD*~" Then
                    gspStr = "sp_insert_SYMAQL '" & gsCompany & "','" & _
                                     dr.Item("yal_lotfm").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_lotto").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_sample").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_aql15").ToString.Replace("'", "''").Trim & "','" & _
                                dr.Item("yal_aql25").ToString.Replace("'", "''").Trim & "','" & _
                                  gsUsrID & "'"
                Else
                End If

                If gspStr <> "" Then
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00040 sp_update_SYMAQL : " & rtnStr)
                        flgErr = True
                        Exit For
                    End If
                    gspStr = ""
                End If
            Next

            If Not flgErr Then
                rs_SYMAQL.AcceptChanges()
                Call setStatus("Save")
                SetStatusBar("Save")
                Call SYM00040_Load(sender, e)
            Else
                save_ok = False
                rs_SYMAQL.RejectChanges()
                MsgBox("Record Not Updated!")
            End If


        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_SYMAQL.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_SYMAQL.Tables("RESULT").Rows
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
                Call SYM00040_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00040_Load(sender, e)
        End If
    End Sub




    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then

            mmdSave.Enabled = Enq_right_local
            mmdAdd.Enabled = False
            'cmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = False

            mmdSearch.Enabled = False

            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True


            mmdExit.Enabled = True


            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Change Status" Then
            mmdSave.Enabled = True
            mmdDelete.Enabled = False
            mmdDelRow.Enabled = True
            mmdClear.Enabled = True
        ElseIf mode = "InsRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            mmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00040_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            mmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False


            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Function check_overlap() As Boolean
        For i As Integer = 0 To rs_SYMAQL.Tables("result").Rows.Count - 1
            For j As Integer = 0 To rs_SYMAQL.Tables("result").Rows.Count - 1
                If i <> j Then
                    If (Not IsDBNull(rs_SYMAQL.Tables("result").Rows(i)("yal_lotfm"))) And _
 ((rs_SYMAQL.Tables("result").Rows(i)("yal_del")) <> "Y") And _
 ((rs_SYMAQL.Tables("result").Rows(j)("yal_del")) <> "Y") And _
 (Not IsDBNull(rs_SYMAQL.Tables("result").Rows(i)("yal_lotto"))) And _
 (Not IsDBNull(rs_SYMAQL.Tables("result").Rows(j)("yal_lotfm"))) And _
 (Not IsDBNull(rs_SYMAQL.Tables("result").Rows(j)("yal_lotto"))) Then
                        If (rs_SYMAQL.Tables("result").Rows(i)("yal_lotfm") >= rs_SYMAQL.Tables("result").Rows(j)("yal_lotfm") And rs_SYMAQL.Tables("result").Rows(i)("yal_lotfm") <= rs_SYMAQL.Tables("result").Rows(j)("yal_lotto")) _
Or (rs_SYMAQL.Tables("result").Rows(i)("yal_lotto") >= rs_SYMAQL.Tables("result").Rows(j)("yal_lotfm") And rs_SYMAQL.Tables("result").Rows(i)("yal_lotto") <= rs_SYMAQL.Tables("result").Rows(j)("yal_lotto")) Then
                            Return True
                        End If
                    End If
                End If
            Next
        Next

        Return False
    End Function

    Function check_fromto() As Boolean
        For i As Integer = 0 To rs_SYMAQL.Tables("result").Rows.Count - 1

            If (Not IsDBNull(rs_SYMAQL.Tables("result").Rows(i)("yal_lotfm"))) And _
             ((rs_SYMAQL.Tables("result").Rows(i)("yal_del")) <> "Y") And _
(Not IsDBNull(rs_SYMAQL.Tables("result").Rows(i)("yal_lotto"))) Then
                If (rs_SYMAQL.Tables("result").Rows(i)("yal_lotfm") >= rs_SYMAQL.Tables("result").Rows(i)("yal_lotto")) Then
                    Return True
                End If

            End If


        Next
        Return False
    End Function

    Private Sub dgCharge_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgCharge.DataError
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub
End Class


