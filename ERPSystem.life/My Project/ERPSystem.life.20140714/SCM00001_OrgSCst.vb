Public Class SCM00001_OrgSCst

    Public myOwner As SCM00001

    Dim rs_SCORDDTL_SUB As DataSet

    Private Sub SCM00001_OrgSCst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs_SCORDDTL_SUB = myOwner.rs_SCORDDTL_SUB.Copy()

        Dim sFilter As String
        sFilter = "sod_ordseq = " & myOwner.rs_SCORDDTL.Tables("RESULT").Rows(myOwner.currentRow)("sod_ordseq")

        rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.RowFilter = sFilter

        lblVenno.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_venno_org").ToString
        lblIMPeriod.Text = CDate(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_imqutdat_org").ToString).Year.ToString & "-" & _
                           Microsoft.VisualBasic.Right("00" & CDate(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_imqutdat_org")).Month.ToString, 2)

        lblItmCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_fcurcde_org")
        txtItmCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_ftycst_org"), "#0.0000")
        lblTtlBOMCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_fcurcde_org")
        txtTtlBOMCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_bomcst_org"), "#0.0000")
        lblTtlCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_fcurcde_org")
        txtTtlCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_ftyprc_org"), "#0.0000")

        lblDVItmCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvfcurcde_org")
        txtDVItmCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvftycst_org"), "#0.0000")
        lblDVTtlBOMCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvfcurcde_org")
        txtDVTtlBOMCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvbomcst_org"), "#0.0000")
        lblDVTtlCstCur_org.Text = rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvfcurcde_org")
        txtDVTtlCst_org.Text = Format(rs_SCORDDTL_SUB.Tables("RESULT").DefaultView.Item(0)("sod_dvftyprc_org"), "#0.0000")
    End Sub

    Private Sub cmdOK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Close()
    End Sub
End Class