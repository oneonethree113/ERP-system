Public Class SAM00003_1

    Public Sub New(ByVal rs_SAREQASS As DataSet)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        rs_SAREQASS.Tables("RESULT").DefaultView.AllowEdit = False
        grdAss.DataSource = rs_SAREQASS.Tables("RESULT").DefaultView

        Call Display_Assortment()
    End Sub



    Private Sub Display_Assortment()
        With grdAss
            '.Columns(0).Width = 1400
            '.Columns(1).Width = 1600
            '.Columns(2).Width = 1400
            '.Columns(3).Width = 1500
            '.Columns(4).Width = 1000
            '.Columns(5).Width = 1100
            '.Columns(6).Width = 900
            '.Columns(7).Width = 700
            '.Columns(8).Width = 1100
            '.Columns(9).Width = 1150
        End With
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub grdAss_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAss.CellContentClick

    End Sub
End Class