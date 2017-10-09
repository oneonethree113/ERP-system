Public Class SYM00104
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
        Me.ssBar.Location = New System.Drawing.Point(0, 472)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(895, 22)
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
        Me.cmdInsRow.TabIndex = 7
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
        Me.dgCharge.Size = New System.Drawing.Size(872, 422)
        Me.dgCharge.TabIndex = 5
        '
        'SYM00104
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(895, 494)
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
        Me.Name = "SYM00104"
        Me.Text = "SYM00104 - Claim Category Maintenance"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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


    Private Sub SYM00104_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
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
                MsgBox("Error on loading SYM00104 #001 sp_list_SYCLMTYP : " & rtnStr)
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
        ElseIf m = "Change Status R-Readonly" Then
            Me.ssBar.Text = "Change Status R-Readonly"
        ElseIf m = "Change Status A-Add" Then
            Me.ssBar.Text = "Change Status A-Add"
        ElseIf m = "Change Status C-Cancel" Then
            Me.ssBar.Text = "Change Status C-Cancel"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.ssBar.Text = ""
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
            .Columns(i).Width = 199
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
            .Columns(i).Width = 55
            .Columns(i).HeaderText = "Approve Amt (USD)"
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


        cmdClear.Enabled = True

    End Sub






    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then

                If Not row.Cells("yct_cde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
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

        If cmdExit.Focused Then
            Return
        End If

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

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
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


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

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
                            MsgBox("Error on loading SYM00104 sp_update_SYCLMTYP : " & rtnStr)
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
                    Call SYM00104_Load(sender, e)
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



    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
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


        If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Or Me.ssBar.Text = "Change Status" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call cmdSave_Click(sender, e)

                If save_ok Then

                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00104_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00104_Load(sender, e)
        End If
    End Sub




    Private Sub setStatus(ByVal mode As String)
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
            Call SYM00104_Load(Nothing, Nothing)

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





End Class
