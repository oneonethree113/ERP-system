Public Class SYM00107
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
    Friend WithEvents ssBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.ssBar = New System.Windows.Forms.StatusBar
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.dgCharge = New System.Windows.Forms.DataGridView
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "&Delete"
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 474)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(752, 22)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(646, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(566, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(606, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(464, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(526, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(408, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 15
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(340, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "Searc&h"
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(12, 46)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCharge.Size = New System.Drawing.Size(728, 422)
        Me.dgCharge.TabIndex = 7
        '
        'SYM00107
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.dgCharge)
        Me.Controls.Add(Me.ssBar)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SYM00107"
        Me.Text = "SYM00107 - Claims Email Statement Maintenance"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYEMLSTS As New DataSet

    Public convertSTS As New DataTable
    Dim STS As New DataSet

    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer


    Private Sub SYM00107_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        validcheck = 1
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right




            gsCompany = "UCP"
            gspStr = "sp_list_SYEMLSTS'" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYEMLSTS, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00107 #001 sp_list_SYEMLSTS : " & rtnStr)
            Else
               


                '**********create a DATATABLE convertSTS for rearrange the interface between SYEMLSTS and datagrid******'
                convertSTS = New DataTable("STSsplit")
                Dim del As DataColumn = New DataColumn("Del")
                del.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(del)
                Dim clmode As DataColumn = New DataColumn("Mode")
                clmode.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(clmode)
                Dim clmodecase As DataColumn = New DataColumn("Modecase")
                clmodecase.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(clmodecase)
                Dim dsc As DataColumn = New DataColumn("Description")
                dsc.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(dsc)
                Dim tmpcde As DataColumn = New DataColumn("Tmpcde")
                tmpcde.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(tmpcde)
                Dim claim As DataColumn = New DataColumn("Claim")
                claim.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(claim)
                Dim ship As DataColumn = New DataColumn("Shipping")
                ship.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(ship)
                Dim act As DataColumn = New DataColumn("Accounting")
                act.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(act)
                Dim mgt As DataColumn = New DataColumn("Management")
                mgt.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(mgt)
                Dim sale As DataColumn = New DataColumn("Sales")
                sale.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(sale)
                Dim usrid As DataColumn = New DataColumn("Usrid")
                usrid.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(usrid)
                Dim ccdept As DataColumn = New DataColumn("CCdept")
                ccdept.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(ccdept)
                Dim ccusrid As DataColumn = New DataColumn("CCusrid")
                ccusrid.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(ccusrid)
                
                Dim creusr As DataColumn = New DataColumn("Creusr")
                creusr.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(creusr)
                Dim updusr As DataColumn = New DataColumn("Updusr")
                updusr.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(updusr)
                Dim credat As DataColumn = New DataColumn("Credat")
                credat.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(credat)
                Dim upddat As DataColumn = New DataColumn("Upddat")
                upddat.DataType = System.Type.GetType("System.String")
                convertSTS.Columns.Add(upddat)

                Dim i As Integer
                Dim a As Integer
                Dim rowSTS As DataRow
                Dim splitdept() As String
                rowSTS = convertSTS.NewRow
                '*********** pass data to convertSTS from SYEMLSTS*****'
                For i = 0 To rs_SYEMLSTS.Tables("RESULT").Rows.Count - 1
                    convertSTS.Rows.Add()
                    convertSTS.Rows(i).Item("Del") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_del").ToString.Trim
                    convertSTS.Rows(i).Item("Mode") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_mod").ToString.Trim
                    convertSTS.Rows(i).Item("Modecase") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_modcase").ToString.Trim
                    convertSTS.Rows(i).Item("Description") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dsc").ToString.Trim
                    convertSTS.Rows(i).Item("Tmpcde") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_tmpcde").ToString.Trim
                    If CharCount(rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString, ",") > 0 Then
                        splitdept = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Split(New Char() {","c})
                        For a = 0 To splitdept.Length - 1
                            If splitdept(a).Trim = "CLAIM" Then
                                convertSTS.Rows(i).Item("Claim") = "Y"
                            ElseIf splitdept(a).Trim = "SHIPPING" Then
                                convertSTS.Rows(i).Item("Shipping") = "Y"
                            ElseIf splitdept(a).Trim = "ACCOUNTING" Then
                                convertSTS.Rows(i).Item("Accounting") = "Y"
                            ElseIf splitdept(a).Trim = "MANAGEMENT" Then
                                convertSTS.Rows(i).Item("Management") = "Y"
                            ElseIf splitdept(a).Trim = "SALES" Then
                                convertSTS.Rows(i).Item("Sales") = "Y"
                            End If

                        Next
                    Else
                        If rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Trim = "CLAIM" Then
                            convertSTS.Rows(i).Item("Claim") = "Y"
                        ElseIf rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Trim = "SHIPPING" Then
                            convertSTS.Rows(i).Item("Shipping") = "Y"
                        ElseIf rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Trim = "ACCOUNTING" Then
                            convertSTS.Rows(i).Item("Accounting") = "Y"
                        ElseIf rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Trim = "MANAGEMENT" Then
                            convertSTS.Rows(i).Item("Management") = "Y"
                        ElseIf rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_dept").ToString.Trim = "SALES" Then
                            convertSTS.Rows(i).Item("Sales") = "Y"
                        End If
                    End If
                    

                    convertSTS.Rows(i).Item("Usrid") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_usrid").ToString.Trim
                    convertSTS.Rows(i).Item("CCdept") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_ccdept").ToString.Trim
                    convertSTS.Rows(i).Item("CCusrid") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_ccusrid").ToString.Trim

                    convertSTS.Rows(i).Item("Creusr") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_creusr").ToString.Trim
                    convertSTS.Rows(i).Item("Updusr") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_updusr").ToString.Trim
                    convertSTS.Rows(i).Item("Credat") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_credat").ToString.Trim
                    convertSTS.Rows(i).Item("Upddat") = rs_SYEMLSTS.Tables("RESULT").Rows(i).Item("yes_upddat").ToString.Trim
                Next
                '************ bind the datagrid with DATATABLE convertSTS********'
                dgCharge.DataSource = convertSTS.DefaultView
                convertSTS.Columns(0).ReadOnly = False
                '***********use <dgCharge.AllowUserToAddRows = False> to delete the automatic created row that is undesire******'
                dgCharge.AllowUserToAddRows = False
                Call format_dgCharge()
                Call setDataRowAttr()
                Call SetStatusBar("Init")
                mode = "INIT"
                Call SetStatus(mode)
                For Each row As DataGridViewRow In dgCharge.Rows
                    If row.Cells("Creusr").ToString <> "~*ADD*~" Then
                        row.Cells("Mode").ReadOnly = True
                        row.Cells("Modecase").ReadOnly = True
                        row.Cells("Description").ReadOnly = True
                        row.Cells("Tmpcde").ReadOnly = True
                    End If
                Next
            End If
            Call Formstartup(Me.Name)

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try



    End Sub
    '****************** CellBeginEdit identifies in which stituation should forbin the data edit *****'
    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dgCharge.CellBeginEdit

        'Dim dgv As DataGridView = CType(sender, DataGridView)

        '' 是否可以进行编辑的条件检查

        'If dgv.Columns(e.ColumnIndex).Name = "Column1" AndAlso Not CBool(dgv("Column2", e.RowIndex).Value) Then

        '    ' 取消编辑

        '    e.Cancel = True
        'End If
        For Each row As DataGridViewRow In dgCharge.Rows
            If row.Cells("Creusr").Value.ToString.Trim <> "~*ADD*~" Then
                e.Cancel = True
                row.Cells("Del").ReadOnly = True
                row.Cells("Claim").ReadOnly = True
                row.Cells("Shipping").ReadOnly = True
                row.Cells("Accounting").ReadOnly = True
                row.Cells("Management").ReadOnly = True
                row.Cells("Sales").ReadOnly = True
                row.Cells("Mode").ReadOnly = True
                row.Cells("Modecase").ReadOnly = True
                row.Cells("Description").ReadOnly = True
                row.Cells("Tmpcde").ReadOnly = True
            Else
                e.Cancel = False
            End If
        Next

        For Each row As DataGridViewRow In dgCharge.Rows
            If row.Cells("Creusr").Value.ToString.Trim = "~*ADD*~" Then
                row.Cells("Del").ReadOnly = True
                row.Cells("Claim").ReadOnly = True
                row.Cells("Shipping").ReadOnly = True
                row.Cells("Accounting").ReadOnly = True
                row.Cells("Management").ReadOnly = True
                row.Cells("Sales").ReadOnly = True
                row.Cells("Mode").ReadOnly = True
                row.Cells("Modecase").ReadOnly = True
                row.Cells("Description").ReadOnly = False
                row.Cells("Tmpcde").ReadOnly = False
            End If
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.ssBar.Text = "Init" Then
            Me.Close()
        Else

            If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call cmdSave_Click(sender, e)

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
            Me.ssBar.Text = "Init"
        ElseIf m = "InsRow" Then
            Me.ssBar.Text = "Insert Row"
        ElseIf m = "Updating" Then
            Me.ssBar.Text = "Updating"
        ElseIf m = "Save" Then
            Me.ssBar.Text = "Record Saved"
        ElseIf m = "DelRow" Then
            Me.ssBar.Text = "Record Row Deleted"
        ElseIf m = "ReadOnly" Then
            Me.ssBar.Text = "Read Only"
        ElseIf m = "Clear" Then
            Me.ssBar.Text = "Clear Screen"
        ElseIf m = "Change Status" Then
            Me.ssBar.Text = "Change Status"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.ssBar.Text = ""
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = convertSTS

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next

            For Each dr As DataRow In dt.Rows
                dr.Item("Del") = ""
            Next
            convertSTS.AcceptChanges()
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
            .Columns(i).Width = 60
            .Columns(i).HeaderText = "Module"
            i = i + 1
            .Columns(i).Width = 80
            .Columns(i).HeaderText = "Statuation"
            i = i + 1
            '2
            .Columns(i).Width = 120
            .Columns(i).HeaderText = "Desc"
            i = i + 1

            .Columns(i).Width = 75
            .Columns(i).HeaderText = "Temp Code"
            i = i + 1
            '3
            .Columns(i).Width = 50
            .Columns(i).HeaderText = "Claim"
            i = i + 1

            .Columns(i).Width = 65
            .Columns(i).HeaderText = "Shipping"
            i = i + 1

            .Columns(i).Width = 75
            .Columns(i).HeaderText = "Accounting"
            i = i + 1

            .Columns(i).Width = 88
            .Columns(i).HeaderText = "Management"
            i = i + 1

            .Columns(i).Width = 52
            .Columns(i).HeaderText = "Sales"
            i = i + 1

            Dim j As Integer
            For j = i To dgCharge.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim addnewrow As Boolean

        addnewrow = False

        Call SetStatusBar("InsRow")
        Call SetStatus("InsRow")


        If convertSTS.Rows.Count = 0 Then
            addnewrow = True
        ElseIf convertSTS.Rows(convertSTS.Rows.Count - 1).Item("Mode").ToString = "" Or convertSTS.Rows(convertSTS.Rows.Count - 1).Item("Modecase").ToString = "" Or convertSTS.Rows(convertSTS.Rows.Count - 1).Item("Description").ToString = "" Or convertSTS.Rows(convertSTS.Rows.Count - 1).Item("Tmpcde").ToString = "" Then

            addnewrow = False
            MsgBox("Please insert the information (code, description and temp code) first before adding the new row")

            'MsgBox("Please insert the right information format first before add the new row")

            For Each row As DataGridViewRow In dgCharge.Rows
                If row.Cells("Mode").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("Mode")
                ElseIf row.Cells("Modecase").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("Modecase")
                ElseIf row.Cells("Description").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("Description")
                End If
            Next

        ElseIf convertSTS.Rows(convertSTS.Rows.Count - 1).Item("Creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 Then
                addnewrow = True
            Else
                MsgBox("Please insert the right information format first before adding the new row")
                addnewrow = False
            End If
        End If


        If addnewrow = True Then
            dsNewRow = convertSTS.NewRow()

            dsNewRow.Item("Creusr") = "~*ADD*~"
            dsNewRow.Item("Del") = ""

            convertSTS.Rows.Add(dsNewRow)
            For Each drr As DataGridViewRow In dgCharge.Rows
                If IsDBNull(drr.Cells(3).Value) Then
                    dgCharge.CurrentCell = drr.Cells(1)
                    dgCharge.CurrentCell.ReadOnly = False
                    dgCharge.BeginEdit(True)
                End If
            Next
        End If


        cmdClear.Enabled = True

    End Sub



    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then

                If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If
                row.Cells("Del").ReadOnly = True
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then

                If row.Cells("Del").Value.ToString = "" And row.Cells("Creusr").Value.ToString = "~*ADD*~" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    dgCharge.BeginEdit(True)

                Else
                    'row.Cells(e.ColumnIndex).ReadOnly = True
                    row.Cells("Mode").ReadOnly = True
                    row.Cells("Modecase").ReadOnly = True
                    row.Cells("Description").ReadOnly = True
                    row.Cells("Tmpcde").ReadOnly = True
                End If

            End If

            If (e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7) And Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                If e.ColumnIndex = 5 Then

                    If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                        If row.Cells("Claim").Value.ToString = "" Then
                            row.Cells("Claim").Value = "Y"
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("Claim").Value = ""
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If

                    End If
                    row.Cells("Claim").ReadOnly = True

                End If
                If e.ColumnIndex = 6 Then

                    If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                        If row.Cells("Shipping").Value.ToString = "" Then
                            row.Cells("Shipping").Value = "Y"
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("Shipping").Value = ""
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If
                    row.Cells("Shipping").ReadOnly = True
                End If
                If e.ColumnIndex = 7 Then

                    If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                        If row.Cells("Accounting").Value.ToString = "" Then
                            row.Cells("Accounting").Value = "Y"
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("Accounting").Value = ""
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If
                    row.Cells("Accounting").ReadOnly = True

                End If

                If e.ColumnIndex = 8 Then

                    If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                        If row.Cells("Management").Value.ToString = "" Then
                            row.Cells("Management").Value = "Y"
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("Management").Value = ""
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If
                    row.Cells("Management").ReadOnly = True

                End If

                If e.ColumnIndex = 9 Then

                    If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                        If row.Cells("Sales").Value.ToString = "" Then
                            row.Cells("Sales").Value = "Y"
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        Else
                            row.Cells("Sales").Value = ""
                            Call SetStatus("Change Status")
                            Call SetStatusBar("Change Status")

                        End If
                    End If
                    row.Cells("Sales").ReadOnly = True

                End If
            End If
        End If
        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub dgCharge_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEnter

        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then

            If row.Cells("Del").Value.ToString = "" And row.Cells("Creusr").Value.ToString = "~*ADD*~" Then
                row.Cells(e.ColumnIndex).ReadOnly = False
                dgCharge.BeginEdit(True)

            Else
                'row.Cells(e.ColumnIndex).ReadOnly = True
                row.Cells("Mode").ReadOnly = True
                row.Cells("Modecase").ReadOnly = True
                row.Cells("Description").ReadOnly = True
                row.Cells("Tmpcde").ReadOnly = True
            End If
        End If

    End Sub



    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCharge.CellValidating
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String

        If cmdExit.Focused Then
            Return
        End If

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("Mode"), "String", 2) Then

                    row.DataGridView.CurrentCell = row.Cells("Mode")

                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True

                ElseIf row.Cells("Mode").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in Modules!")
                    row.DataGridView.CurrentCell = row.Cells("Mode")

                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True

                ElseIf Not (row.Cells("Mode").EditedFormattedValue.ToString.Length <= 2) Then
                    MsgBox("Length of Modules should be no more than 2!")
                    row.DataGridView.CurrentCell = row.Cells("Mode")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                Else
                    validcheck = 1
                End If



            End If



            If e.ColumnIndex = 2 Then
                If Not chkGrdCellValue(row.Cells("Modecase"), "String", 4) Then

                    row.DataGridView.CurrentCell = row.Cells("Modecase")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True

                ElseIf row.Cells("Modecase").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in Situation!")
                    row.DataGridView.CurrentCell = row.Cells("Modecase")

                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True

                ElseIf Not (row.Cells("Modecase").EditedFormattedValue.ToString.Length <= 4) Then
                    MsgBox("Length of Situation should be no more than 4 digit!")
                    row.DataGridView.CurrentCell = row.Cells("Modecase")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True

                End If

                If row.Cells("Creusr").Value.ToString = "~*ADD*~" Then
                    For Each drr As DataGridViewRow In dgCharge.Rows

                        If drr.Index <> row.Index Then
                            If drr.Cells("Mode").Value.ToString.ToUpper = row.Cells("Mode").Value.ToString.ToUpper And _
                               drr.Cells("Modecase").Value.ToString.ToUpper = row.Cells("Modecase").Value.ToString.ToUpper Then
                                MsgBox("Duplicated combination of Modules and Situation !")
                                validcheck = 0
                                'row.DataGridView.CurrentCell = row.Cells("Mode")
                                Exit Sub
                            Else
                                validcheck = 1
                            End If
                        End If
                    Next
                End If
            End If


            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("Description"), "String", 40) Then

                    row.DataGridView.CurrentCell = row.Cells("Description")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                ElseIf row.Cells("Description").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in Description!")
                    row.DataGridView.CurrentCell = row.Cells("Description")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("Tmpcde"), "Z+Numeric", 2) Then

                    row.DataGridView.CurrentCell = row.Cells("Tmpcde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                ElseIf row.Cells("Tmpcde").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in temp code!")
                    row.DataGridView.CurrentCell = row.Cells("Tmpcde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                ElseIf Not (row.Cells("Tmpcde").EditedFormattedValue.ToString.Length = 2) Then
                    MsgBox("Length of temp code is not 2 digit!")
                    row.DataGridView.CurrentCell = row.Cells("Tmpcde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    e.Cancel = True
                Else
                    If row.Cells("Creusr").Value.ToString = "~*ADD*~" Then
                        For Each drr As DataGridViewRow In dgCharge.Rows

                            If drr.Index <> row.Index Then
                                If drr.Cells("Mode").Value.ToString.ToUpper = row.Cells("Mode").Value.ToString.ToUpper And _
                                   drr.Cells("Modecase").Value.ToString.ToUpper = row.Cells("Modecase").Value.ToString.ToUpper Then
                                    MsgBox("Duplicated combination of Modules and Situation !")
                                    validcheck = 0
                                    Exit Sub
                                Else
                                    validcheck = 1
                                End If
                            End If
                        Next
                    End If

                End If

            End If


        End If

        If e.ColumnIndex = 8 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
            If row.Cells("Sales").Value.ToString <> "Y" Or row.Cells("Sales").Value.ToString <> "" Then
                row.Cells("Sales").Value = ""
            End If
            If row.Cells("Claim").Value.ToString <> "Y" Or row.Cells("Sales").Value.ToString <> "" Then
                row.Cells("Claim").Value = ""
            End If
            If row.Cells("Shipping").Value.ToString <> "Y" Or row.Cells("Sales").Value.ToString <> "" Then
                row.Cells("Shipping").Value = ""
            End If
            If row.Cells("Accounting").Value.ToString <> "Y" Or row.Cells("Sales").Value.ToString <> "" Then
                row.Cells("Accounting").Value = ""
            End If
            If row.Cells("Management").Value.ToString <> "Y" Or row.Cells("Sales").Value.ToString <> "" Then
                row.Cells("Management").Value = ""
            End If
        End If




    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("Mode").Value.ToString = "" And Not row.Cells("Modecase").Value.ToString = "" Then
                If row.Cells("Del").Value.ToString = "" Then
                    row.Cells("Del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("Del").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call SetStatus("DelRow")
                Call SetStatusBar("DelRow")

            End If
        End If
    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows


                If row.Cells("Del").Value.ToString = "" Then



                    If Not chkGrdCellValue(row.Cells("Mode"), "String", 2) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("Mode")

                    ElseIf Not (row.Cells("Mode").EditedFormattedValue.ToString.Length <= 2) Then
                        MsgBox("Length of Modules should no more than 2!")
                        row.DataGridView.CurrentCell = row.Cells("Mode")
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("Modecase"), "String", 4) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("Modecase")

                    ElseIf Not (row.Cells("Modecase").EditedFormattedValue.ToString.Length <= 4) Then
                        MsgBox("Length of Situation should no more than 4!")
                        row.DataGridView.CurrentCell = row.Cells("Modecase")
                        save_ok = False
                        flgReAct = True
                    ElseIf Not (row.Cells("Tmpcde").EditedFormattedValue.ToString.Length = 2) Then
                        MsgBox("Length of temp code is not 2 digit!")
                        row.DataGridView.CurrentCell = row.Cells("Tmpcde")
                        save_ok = False
                        flgReAct = True


                    ElseIf row.Cells("Description").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Description should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("Description")
                    Else
                        If row.Cells("Credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("Mode").Value.ToString.ToUpper = row.Cells("Mode").Value.ToString.ToUpper And _
                                       drr.Cells("Del").Value.ToString = "" And _
                                       drr.Cells("Modecase").Value.ToString.ToUpper = row.Cells("Modecase").Value.ToString.ToUpper Then
                                        MsgBox("Duplicated combination of Modules and Situation!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("Mode")
                                    End If
                                End If
                            Next
                        End If
                    End If

                    For Each dr2 As DataRow In convertSTS.Rows
                        Dim deptcomb2 As String


                        deptcomb2 = ""

                        If dr2.Item("Claim").ToString.Trim = "Y" Then
                            deptcomb2 = deptcomb2 + "CLAIM" + ","
                        End If
                        If dr2.Item("Shipping").ToString.Trim = "Y" Then
                            deptcomb2 = deptcomb2 + "SHIPPING" + ","
                        End If
                        If dr2.Item("Accounting").ToString.Trim = "Y" Then
                            deptcomb2 = deptcomb2 + "ACCOUNTING" + ","
                        End If
                        If dr2.Item("Management").ToString.Trim = "Y" Then
                            deptcomb2 = deptcomb2 + "MANAGEMENT" + ","
                        End If
                        If dr2.Item("Sales").ToString.Trim = "Y" Then
                            deptcomb2 = deptcomb2 + "SALES" + ","
                        End If

                        deptcomb2 = deptcomb2.Trim
                        If deptcomb2.Length < 1 Then
                            MsgBox("Please take the department(s) need to receive email on the statution you insert")
                            save_ok = False
                            flgReAct = True
                        End If
                    Next
                End If

                If Not save_ok Then
                    Exit For
                End If
            Next

            If Not save_ok Then
                dgCharge.BeginEdit(True)
                Exit Sub
            Else

                gspStr = ""
                For Each dr As DataRow In convertSTS.Rows
                    Dim deptcomb As String

                    deptcomb = ""

                    If dr.Item("Claim").ToString.Trim = "Y" Then
                        deptcomb = deptcomb + "CLAIM" + ","
                    End If
                    If dr.Item("Shipping").ToString.Trim = "Y" Then
                        deptcomb = deptcomb + "SHIPPING" + ","
                    End If
                    If dr.Item("Accounting").ToString.Trim = "Y" Then
                        deptcomb = deptcomb + "ACCOUNTING" + ","
                    End If
                    If dr.Item("Management").ToString.Trim = "Y" Then
                        deptcomb = deptcomb + "MANAGEMENT" + ","
                    End If
                    If dr.Item("Sales").ToString.Trim = "Y" Then
                        deptcomb = deptcomb + "SALES" + ","
                    End If

                    deptcomb = deptcomb.Trim

                    deptcomb = Mid(deptcomb, 1, Len(deptcomb) - 1)
                    deptcomb = UCase(deptcomb)
                    If dr.RowState = DataRowState.Modified Then

                        If dr.Item("Del") = "Y" Then

                            gspStr = "sp_physical_delete_SYEMLSTS '" & gsCompany & "','" & _
                                        dr.Item("Mode").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Modecase").ToString.Replace("'", "''").Trim & "'"
                        Else

                            gspStr = "sp_update_SYEMLSTS '" & gsCompany & "','" & _
                                        dr.Item("Mode").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Modecase").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Description").ToString.Replace("'", "''").Trim & "','" & _
                                        deptcomb & "','" & _
                                        "ALL".ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("CCdept").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("CCusrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Tmpcde").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("Del") = "Y" Then

                        If dr.Item("Credat").ToString.Trim = "" Then

                            gspStr = "sp_insert_SYEMLSTS '" & gsCompany & "','" & _
                                        dr.Item("Mode").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Modecase").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Description").ToString.Replace("'", "''").Trim & "','" & _
                                         deptcomb & "','" & _
                                        "ALL".ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("CCdept").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("CCusrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("Tmpcde").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00107 sp_update_SYEMLSTS : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If

                Next

                If Not flgErr Then
                    rs_SYEMLSTS.AcceptChanges()
                    Call SetStatus("Save")
                    SetStatusBar("Save")
                    Call SYM00107_Load(sender, e)
                Else
                    save_ok = False
                    rs_SYEMLSTS.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not convertSTS Is Nothing Then
            For Each dr As DataRow In convertSTS.Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If


        If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Or Me.ssBar.Text = "Change Status" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call cmdSave_Click(sender, e)

                If save_ok Then

                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00107_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00107_Load(sender, e)
        End If
    End Sub




    Private Sub SetStatus(ByVal mode As String)
        If mode = "INIT" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        ElseIf mode = "Change Status" Then
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = False
            Me.cmdDelRow.Enabled = True
            Me.cmdClear.Enabled = True
        ElseIf mode = "InsRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Me.cmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00107_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Me.cmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Public Function CharCount(ByVal OrigString As String, _
      ByVal Chars As String, Optional ByVal CaseSensitive As Boolean = False) _
      As Long

        '**********************************************
        'PURPOSE: Returns Number of occurrences of a character or
        'or a character sequencence within a string

        'PARAMETERS:
        'OrigString: String to Search in
        'Chars: Character(s) to search for
        'CaseSensitive (Optional): Do a case sensitive search
        'Defaults to false

        'RETURNS:
        'Number of Occurrences of Chars in OrigString

        'EXAMPLES:
        'Debug.Print CharCount("FreeVBCode.com", "E") -- returns 3
        'Debug.Print CharCount("FreeVBCode.com", "E", True) -- returns 0
        'Debug.Print CharCount("FreeVBCode.com", "co") -- returns 2
        ''**********************************************


        Dim lLen As Long
        Dim lCharLen As Long
        Dim lAns As Long
        Dim sInput As String
        Dim sChar As String
        Dim lCtr As Long
        Dim lEndOfLoop As Long
        Dim bytCompareType As Byte

        sInput = OrigString
        If sInput = "" Then Exit Function
        lLen = Len(sInput)
        lCharLen = Len(Chars)
        lEndOfLoop = (lLen - lCharLen) + 1
        bytCompareType = IIf(CaseSensitive, vbBinaryCompare, _
           vbTextCompare)

        For lCtr = 1 To lEndOfLoop
            sChar = Mid(sInput, lCtr, lCharLen)
            If StrComp(sChar, Chars, bytCompareType) = 0 Then _
                lAns = lAns + 1
        Next

        CharCount = lAns

    End Function

End Class
