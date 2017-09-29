Public Class SHM00001_1
    Public ma As SHM00001

    Private Sub cmdOK_Click()

        Me.Close()

    End Sub

    Private Sub Form_Load()
    End Sub
    Private Sub display_Assortment()
        grdAss.DataSource = ma.rs_SHASSINF.Tables("result").DefaultView


        With grdAss
            For i As Integer = 0 To ma.rs_SHASSINF.Tables("RESULT").Columns.Count - 1
                ma.rs_SHASSINF.Tables("RESULT").Columns(i).ReadOnly = True
                If i = 7 Then
                    ma.rs_SHASSINF.Tables("RESULT").Columns(i).ReadOnly = False
                End If
                If i = 20 Then
                    ma.rs_SHASSINF.Tables("RESULT").Columns(i).ReadOnly = False
                End If



                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

                Select Case i
                    Case 6
                        .Columns(i).HeaderText = "Assorted Item #"
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Item Description"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = False
                    Case 8
                        .Columns(i).HeaderText = "Cust Item #"
                        .Columns(i).Width = 120
                        '.Columns(i).ReadOnly = False
                    Case 9
                        .Columns(i).HeaderText = "Color Code"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Color Description"
                        .Columns(i).Width = 140
                        '.Columns(i).ReadOnly = False
                    Case 11
                        .Columns(i).HeaderText = "SKU #"
                        .Columns(i).Width = 100
                        '.Columns(i).ReadOnly = False
                    Case 18
                        .Columns(i).HeaderText = "Customer Sty No"
                        .Columns(i).Width = 105
                        '.Columns(i).ReadOnly = False
                    Case 12
                        .Columns(i).HeaderText = "UPC#/EAN#"
                        .Columns(i).Width = 100
                        '.Columns(i).ReadOnly = False
                    Case 13
                        'grdAss_CusRtl = i
                        .Columns(i).HeaderText = "Cust. Retail"
                        .Columns(i).Width = 90
                        '.Columns(i).ReadOnly = False
                    Case 17
                        .Columns(i).HeaderText = "ASSd IM Period"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "Qty Per Inner"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Qty Per Master"
                        .Columns(i).Width = 105
                        .Columns(i).ReadOnly = True
                    Case 19
                        'grdAss_TOOrdno = i
                        .Columns(i).HeaderText = "Tentative #"
                        .Columns(i).Width = 80
                        '.Columns(i).ReadOnly = False
                    Case 20
                        'grdAss_TOOrdSeq = i
                        .Columns(i).HeaderText = "Tentative Seq"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 21
                        .Columns(i).Visible = False
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 0
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).Visible = False
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 0
                        .Columns(i).ReadOnly = True
                    Case 23
                        .Columns(i).Visible = False
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 0
                        .Columns(i).ReadOnly = True
                    Case 24
                        .Columns(i).Visible = False
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 0
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 0
                        .Columns(i).ReadOnly = True
                End Select
            Next
        End With
    End Sub
    Private Sub Display_Ass()

        If ma.rs_SHASSINF.Tables("result") Is Nothing Then
            Exit Sub
        End If
        grdAss.DataSource = ma.rs_SHASSINF.Tables("result")

        With grdAss

            .Columns(0).Width = 1400 / 12
            .Columns(1).Width = 1600 / 12
            .Columns(2).Width = 1400 / 12
            .Columns(3).Width = 1500 / 12
            .Columns(4).Width = 1000 / 12
            .Columns(5).Width = 1100 / 12
            .Columns(6).Width = 900 / 12
            .Columns(7).Width = 700 / 12
            .Columns(8).Width = 1100 / 12
            .Columns(9).Width = 1150 / 12
        End With

    End Sub


    Private Sub SHM00001_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        '        grdAss.DataSource = ma.rs_SHASSINF
        'grdAss.AllowUpdate = False

        display_Assortment()
        cmdOK.Focus()

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()

    End Sub

    Private Sub grdAss_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAss.CellContentClick

    End Sub

    Private Sub grdAss_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAss.CellEndEdit

        If ma.rs_SHASSINF.Tables("RESULT").DefaultView(e.RowIndex)("hai_creusr") <> "~*ADD*~" And _
   ma.rs_SHASSINF.Tables("RESULT").DefaultView(e.RowIndex)("hai_creusr") <> "~*DEL*~" And _
   ma.rs_SHASSINF.Tables("RESULT").DefaultView(e.RowIndex)("hai_creusr") <> "~*NEW*~" Then

            ma.rs_SHASSINF.Tables("RESULT").DefaultView(e.RowIndex)("hai_creusr") = "~*UPD*~"


            ' ma.rs_SHASSINF.Tables("RESULT").DefaultView(e.RowIndex)("hai_creusr") = "~*UPD*~"

        End If

        '''
        ma.Recordstatus = True
    End Sub
End Class