Public Class frmPOShipMark
    Dim rs_POSHPMRK As DataSet

    Dim Cocde As String
    Dim CoNam As String
    Dim PONo As String
    Dim SCNo As String


    Public Sub New(ByVal _Cocde As String, ByVal _PONo As String, ByVal _SCNo As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim rs As New DataSet
        gspStr = "sp_select_SYCOMINF_M '', '" & _Cocde & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmPOShipMark : " & rtnStr)
            Exit Sub
        End If

        Cocde = _Cocde
        CoNam = rs.Tables("RESULT").Rows(0).Item("yco_conam")
        PONo = _PONo
        SCNo = _SCNo

        gspStr = "sp_select_POSHPMRK '" & Cocde & "','" & PONo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POSHPMRK, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmPOShipMark : " & rtnStr)
            Exit Sub
        End If

        SetTxtBoxReadOnly(True)
        DisplayForm()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub DisplayForm()
        'Reset TextBox
        txtShpMrk.Text = ""
        txtImgPth.Text = ""
        txtSEngDsc.Text = ""
        txtSChnDsc.Text = ""
        txtEngRmk.Text = ""
        txtChnRmk.Text = ""
        imgShpMrk.Image = Nothing

        Dim opt As String = If(optMain.Checked = True, "M", If(optInner.Checked = True, "I", "S"))

        Dim dr() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = '" & opt & "'")

        If rs_POSHPMRK.Tables("RESULT").Rows.Count > 0 Then
            'rs_POSHPMRK.MoveFirst()
            Dim drPOSHPMRK() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = " & "'" & opt & "'")

            If drPOSHPMRK.Length() > 0 Then
                txtShpMrk.Text = drPOSHPMRK(0).Item("psm_imgnam")
                txtImgPth.Text = drPOSHPMRK(0).Item("psm_imgpth")
                txtSEngDsc.Text = drPOSHPMRK(0).Item("psm_engdsc")
                txtSChnDsc.Text = drPOSHPMRK(0).Item("psm_chndsc")
                txtEngRmk.Text = drPOSHPMRK(0).Item("psm_engrmk")
                txtChnRmk.Text = drPOSHPMRK(0).Item("psm_chnrmk")
                On Error Resume Next
                imgShpMrk.Load(drPOSHPMRK(0).Item("psm_imgpth"))
            End If
        End If

    End Sub

    Private Sub cmdShpmrkAttchmnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpmrkAttchmnt.Click
        Dim ShipmrkAttchmnt As New SCM00001_ShpmrkAtchmt

        ShipmrkAttchmnt.setCompanyCode(Cocde, CoNam)
        ShipmrkAttchmnt.setSCNo(ScNo)

        ShipmrkAttchmnt.ShowDialog()
    End Sub

    Public Sub SetTxtBoxReadOnly(ByVal flag As Boolean)
        txtShpMrk.ReadOnly = flag
        txtImgPth.ReadOnly = flag
        txtSEngDsc.ReadOnly = flag
        txtSChnDsc.ReadOnly = flag
        txtEngRmk.ReadOnly = flag
        txtChnRmk.ReadOnly = flag

    End Sub

    Private Sub optMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMain.Click, optInner.Click, optSide.Click
        DisplayForm()
    End Sub







End Class