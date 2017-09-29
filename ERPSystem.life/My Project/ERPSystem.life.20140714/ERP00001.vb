Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class ERP00001


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
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents cboCoGrp As System.Windows.Forms.ComboBox
    Friend WithEvents txtUsrID As System.Windows.Forms.TextBox
    Friend WithEvents lblUpddat As System.Windows.Forms.Label
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents lblDBSvr As System.Windows.Forms.Label
    Friend WithEvents lblRptSvr As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblUserID = New System.Windows.Forms.Label
        Me.lblPwd = New System.Windows.Forms.Label
        Me.txtUsrID = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoGrp = New System.Windows.Forms.ComboBox
        Me.cmdLogin = New System.Windows.Forms.Button
        Me.lblUpddat = New System.Windows.Forms.Label
        Me.lblVer = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDBSvr = New System.Windows.Forms.Label
        Me.lblRptSvr = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblUserID
        '
        Me.lblUserID.Location = New System.Drawing.Point(14, 45)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(100, 20)
        Me.lblUserID.TabIndex = 0
        Me.lblUserID.Text = "User ID"
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPwd
        '
        Me.lblPwd.Location = New System.Drawing.Point(14, 74)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(100, 20)
        Me.lblPwd.TabIndex = 1
        Me.lblPwd.Text = "Password"
        Me.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsrID
        '
        Me.txtUsrID.Location = New System.Drawing.Point(122, 46)
        Me.txtUsrID.MaxLength = 12
        Me.txtUsrID.Name = "txtUsrID"
        Me.txtUsrID.Size = New System.Drawing.Size(128, 20)
        Me.txtUsrID.TabIndex = 2
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(122, 74)
        Me.txtPwd.MaxLength = 10
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(128, 20)
        Me.txtPwd.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 34)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "United Chinese Group"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Company Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCoGrp
        '
        Me.cboCoGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoGrp.Location = New System.Drawing.Point(122, 109)
        Me.cboCoGrp.Name = "cboCoGrp"
        Me.cboCoGrp.Size = New System.Drawing.Size(184, 21)
        Me.cboCoGrp.TabIndex = 6
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(122, 138)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(80, 28)
        Me.cmdLogin.TabIndex = 7
        Me.cmdLogin.Text = "Login"
        '
        'lblUpddat
        '
        Me.lblUpddat.Location = New System.Drawing.Point(106, 179)
        Me.lblUpddat.Name = "lblUpddat"
        Me.lblUpddat.Size = New System.Drawing.Size(72, 14)
        Me.lblUpddat.TabIndex = 8
        Me.lblUpddat.Text = "01-01-2008"
        '
        'lblVer
        '
        Me.lblVer.Location = New System.Drawing.Point(193, 179)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(113, 14)
        Me.lblVer.TabIndex = 9
        Me.lblVer.Text = "Ver 1.0"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 14)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Last Update:"
        '
        'lblDBSvr
        '
        Me.lblDBSvr.AutoSize = True
        Me.lblDBSvr.Location = New System.Drawing.Point(63, 202)
        Me.lblDBSvr.Name = "lblDBSvr"
        Me.lblDBSvr.Size = New System.Drawing.Size(48, 13)
        Me.lblDBSvr.TabIndex = 11
        Me.lblDBSvr.Text = "lblDBSvr"
        '
        'lblRptSvr
        '
        Me.lblRptSvr.AutoSize = True
        Me.lblRptSvr.Location = New System.Drawing.Point(63, 215)
        Me.lblRptSvr.Name = "lblRptSvr"
        Me.lblRptSvr.Size = New System.Drawing.Size(50, 13)
        Me.lblRptSvr.TabIndex = 12
        Me.lblRptSvr.Text = "lblRptSvr"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "DB Svr"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Rpt Svr"
        '
        'ERP00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 233)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblRptSvr)
        Me.Controls.Add(Me.lblDBSvr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.lblUpddat)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.cboCoGrp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUsrID)
        Me.Controls.Add(Me.lblPwd)
        Me.Controls.Add(Me.lblUserID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "ERP00001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login (ERP00001)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ERP00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Initialize
        rtnLong = getConnStr(gsConnStr, rtnStr, "CON-DB")

        rtnLong = getConnStr(gsConnStrADO, rtnStr, "ADO-DB")

        rtnLong = getConnStr(gsConnStrRpt, rtnStr, "CON-RPT")

        rtnLong = getConnStr(gsConnStrRptADO, rtnStr, "ADO-RPT")

        gsERPVer = "Ver. 18.0.a.09"

        lblVer.Text = gsERPVer
        lblUpddat.Text = "07/10/2014"

        'cboCoGrp
        cboCoGrp.Items.Add("UCP/UCPP/PG/EW/TT/HB")
        'cboCoGrp.Items.Add("MS")
        cboCoGrp.Text = "UCP/UCPP/PG/EW/TT/HB"

        'Date Format Checking
        If CStr(System.DateTime.Today) <> CStr(Format(System.DateTime.Today, "MM/dd/yyyy")) Then
            MsgBox("Please Set System Date Format to MM/dd/yyyy")
            Me.Close()
        End If

        ''Time Format Checking
        'If CStr(System.DateTime.Today) <> CStr(Format(System.DateTime.Today, "MM/dd/yyyy H:mm:ss")) Then
        '    MsgBox("Please Set System Date Format to MM/dd/yyyy")
        '    Me.Close()
        'End If



        'Version Checking
        Dim result As New DataSet
        Dim para(1) As Object
        para(0) = "UCPP"
        para(1) = "1"

        gspStr = "sp_select_LOGIN 'UCPP','1'"
        rtnLong = execute_SQLStatement(gspStr, result, rtnStr)
        If rtnLong = RC_SUCCESS Then
            Dim tmpERPVer As String
            tmpERPVer = result.Tables("RESULT").Rows(0).Item("ERP_VERSION")
            If tmpERPVer <> gsERPVer Then
                MsgBox("Your current ERP version was outdated, please upgrade!")
                Me.Close()
            End If
        Else
            MsgBox("Calling sp_select_LOGIN fail!")
            Me.Close()
        End If

        lblDBSvr.Text = gsDBSvr & " : " & gsDB
        lblRptSvr.Text = gsDBSvrRpt & " : " & gsDBRpt

        'txtUsrID.Text = "mis"
        'txtPwd.Text = "mis"
        Call GetCompanyName()

    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click

        If txtUsrID.Text = "" Then
            MsgBox("Please input your User ID!")
            txtUsrID.Focus()
            Exit Sub
        End If

        If txtPwd.Text = "" Then
            MsgBox("Please input your password!")
            txtPwd.Focus()
            Exit Sub
        End If

        gsUsrID = txtUsrID.Text

        'Dim rs_SYUSRPRF As New DataSet
        gspStr = "sp_select_SYUSRPRF_1 'UCPP','" & txtUsrID.Text.Trim & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF, rtnStr)

        If rtnLong = RC_SUCCESS Then

            If rs_SYUSRPRF.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("User ID not found, please try again")
                Me.txtUsrID.Focus()
                Me.txtUsrID.SelectAll()
                Exit Sub
            End If

            '1.Password Checking
            Dim pwd As String
            pwd = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yup_paswrd")

            Dim lenpwd As Integer
            Dim Y, i As Integer
            Dim x As String
            Dim password As String

            password = ""
            lenpwd = Len(pwd)
            Y = 1

            For i = 0 To lenpwd - 1
                If Y <= lenpwd Then
                    x = Mid(pwd, Y, 1)
                    password = password + Chr(Mid(pwd, Y + 1, x))
                    Y = Y + x + 1
                End If
            Next

            If password <> txtPwd.Text Then
                MsgBox("User ID or Password is incorrect, please try again")
                Me.txtPwd.Focus()
                Me.txtPwd.SelectAll()
                Exit Sub
            End If

            Dim currentdat As String
            currentdat = CStr(Format(System.DateTime.Today, "yyyyMMdd"))

            '2. Check User Password and Account Expiry Date
            Dim passexpdat As String
            Dim accexpdat As String
            passexpdat = CStr(Format(rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yup_expdat"), "yyyyMMdd"))
            accexpdat = CStr(Format(rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yup_accexp"), "yyyyMMdd"))

            If currentdat > passexpdat Or currentdat > accexpdat Then
                MsgBox("Login ID is overdue, please contact System Administrator")
                txtUsrID.Focus()
                Exit Sub
            End If

            '3. Warning for account overdue


            '4. Initial Global Const
            For i = 0 To rs_SYUSRPRF.Tables("RESULT").Rows.Count() - 1
                If rs_SYUSRPRF.Tables("RESULT").Rows(i).Item("yuc_flgdef") = "Y" Then
                    gsDefaultCompany = rs_SYUSRPRF.Tables("RESULT").Rows(i).Item("yuc_cocde")
                    Exit For
                End If
            Next


            gsCompany = gsDefaultCompany
            gsUsrGrp = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yuc_usrgrp")
            gsFlgCst = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yuc_flgcst")
            gsFlgCstExt = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yuc_flgcstext")
            gsFlgRel = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yuc_flgrel")
            gsUsrRank = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("yuc_usrank")
            gsSalTem = rs_SYUSRPRF.Tables("RESULT").Rows(0).Item("ysr_saltem")

            gsCompanyGroup = "UCG"



            '5. Show Main Form
            Me.Hide()
            Dim MainForm As New ERP00000

            MainForm.Text = "United Chinese Group: New ERP System " & gsERPVer & "     (Env: " & gsDBSvr & " - " & gsDB & " ; Login: " & gsUsrID & ")"
            MainForm.Owner = Me
            MainForm.Show()



        ElseIf rtnLong = RC_NOTFOUND Then
            MsgBox("User Not Found!")
            txtUsrID.Focus()
            Exit Sub
        Else
            MsgBox("Calling sp_select_SYUSRPRF_1 fail!")
            Me.Close()
        End If

    End Sub




    Private Sub txtPwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPwd.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            cmdLogin_Click(sender, e)
        End If
    End Sub



    Private Sub txtUsrID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsrID.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            txtPwd.Focus()
        End If
    End Sub

    Private Sub txtUsrID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsrID.TextChanged

    End Sub

    Private Sub txtPwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPwd.TextChanged

    End Sub

    Private Sub lblVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVer.Click

    End Sub
End Class

