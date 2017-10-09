Imports System.IO


Public Class SHM00001_2

    Public ma As SHM00001

    Dim rs As DataSet
    Dim rs_pd As DataSet

    Public rs_SHIPGDTL_dis As New DataSet
    Public rs_SHIPGDTL_display As New DataSet
    Public rs_SHPCKDIM_copy As New DataSet


    Dim TmpSort As String
    Dim TtlCtn As Integer
    Dim ActVol As Double
    Dim TtlAmt As Double

    Dim TtlGrs As Double
    Dim TtlNet As Double



    Private Sub cboCtr_Click()


        cboInv.Text = "<< ALL >>"

        If cboCtr.Text = "<< ALL >>" Then
            rs.Tables("RESULT").DefaultView.RowFilter = ""
        Else
            rs.Tables("RESULT").DefaultView.RowFilter = "hid_ctrcfs = '" + cboCtr.Text + "'"
        End If

        Call TotalAmount()


        DataGrid1.DataSource = rs.Tables("result").DefaultView
        Call displayGrid()
    End Sub

    Private Sub cboInv_Click()

        cboCtr.Text = "<< ALL >>"
        If cboInv.Text = "<< ALL >>" Then
            rs.Tables("RESULT").DefaultView.RowFilter = ""
        Else
            rs.Tables("RESULT").DefaultView.RowFilter = "hid_invno = '" + cboInv.Text + "'"
        End If
        Call TotalAmount()

        DataGrid1.DataSource = rs.Tables("result").DefaultView
        Call displayGrid()
    End Sub

    Private Sub cboSort1_Click()


        If (cboSort1.Text = cboSort2.Text Or cboSort1.Text = cboSort3.Text) And _
            (cboSort1.Text <> "N/A") Then
            MsgBox("Sort key duplicated")
            cboSort1.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort1.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort2.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort3.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If




        If TmpSort <> "" Then
            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"
        End If

    End Sub

    Private Sub cboSort2_Click()
        Dim TmpSort As String

        If (cboSort2.Text = cboSort1.Text Or cboSort2.Text = cboSort3.Text) And _
            (cboSort2.Text <> "N/A") Then
            MsgBox("Sort key duplicated")
            cboSort2.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If TmpSort <> "" Then
            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"
        End If
    End Sub

    Private Sub cboSort3_Click()
        Dim TmpSort As String

        If (cboSort3.Text = cboSort1.Text Or cboSort3.Text = cboSort2.Text) And _
            (cboSort3.Text <> "N/A") Then
            MsgBox("Sort key duplicated")
            cboSort3.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If TmpSort <> "" Then
            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"
        End If
    End Sub

    Private Sub Command1_Click()

        Me.Close()

    End Sub

    Private Sub cmdOK_Click()
        Me.Close()

    End Sub

Private Sub frmshm1_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sFilter As String
        Dim tmp_CartonFactor As Integer

        'Call Formstartup(Me.Name)
        rs = ma.rs_SHIPGDTL.Copy
        rs_pd = ma.rs_SHPCKDIM.Copy
        rs_SHPCKDIM_copy = ma.rs_SHPCKDIM.Copy
        cboUntAmt.Text = ma.cboUntAmt.Text

        For index9 As Integer = 0 To rs.Tables("result").Rows.Count - 1
            For index99 As Integer = 0 To rs_pd.Tables("result").Rows.Count - 1

                If rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 5 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 6 Then
                    tmp_CartonFactor = 1
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 4 Then
                    tmp_CartonFactor = 2
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 7 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 12 Then
                    tmp_CartonFactor = 3
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 13 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 20 Then
                    tmp_CartonFactor = 4
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 21 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 30 Then
                    tmp_CartonFactor = 5
                End If

                If rs.Tables("result").Rows(index9)("hid_shpno") = rs_pd.Tables("result").Rows(index99)("hpd_shpno") _
                And rs.Tables("result").Rows(index9)("hid_shpseq") = rs_pd.Tables("result").Rows(index99)("hpd_shpseq") _
                And rs.Tables("result").Rows(index9)("hid_ctnftr") = tmp_CartonFactor _
                And rs_pd.Tables("result").Rows(index99)("hpd_dimtyp") = "Mod" Then

                    rs.Tables("result").Rows(index9)("hid_mtrdcm") = rs_pd.Tables("result").Rows(index99)("hpd_l_cm")
                    rs.Tables("result").Rows(index9)("hid_mtrwcm") = rs_pd.Tables("result").Rows(index99)("hpd_w_cm")
                    rs.Tables("result").Rows(index9)("hid_mtrhcm") = rs_pd.Tables("result").Rows(index99)("hpd_h_cm")

                End If
            Next
        Next

        Dim TmpCtr As String
        TmpCtr = "~!@#$%^&*()_+"
        sFilter = "hid_ctrcfs ASC"


        If rs.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        rs.Tables("RESULT").DefaultView.Sort = sFilter
        cboCtr.Items.Add("<< ALL >>")
        For index As Integer = 0 To rs.Tables("RESULT").DefaultView.Count - 1
            If TmpCtr <> rs.Tables("RESULT").DefaultView(index)("hid_ctrcfs") Then
                TmpCtr = rs.Tables("RESULT").DefaultView(index)("hid_ctrcfs")
                cboCtr.Items.Add(TmpCtr)
            End If
        Next


        TmpCtr = "~!@#$%^&*()_+"
        sFilter = "hid_invno ASC"
        rs.Tables("RESULT").DefaultView.Sort = sFilter
        cboInv.Items.Add("<< ALL >>")
        For index As Integer = 0 To rs.Tables("RESULT").DefaultView.Count - 1
            If TmpCtr <> rs.Tables("RESULT").DefaultView(index)("hid_invno") Then
                TmpCtr = rs.Tables("RESULT").DefaultView(index)("hid_invno")
                cboInv.Items.Add(TmpCtr)
            End If
        Next


        cboCtr.SelectedIndex = 0
        cboInv.SelectedIndex = 0


        cboSort1.Items.Add("N/A")
        cboSort1.Items.Add("Container")
        cboSort1.Items.Add("Invoice")
        cboSort1.Items.Add("SC#")
        cboSort1.Items.Add("Cust PO")
        cboSort1.SelectedIndex = 0

        cboSort2.Items.Add("N/A")
        cboSort2.Items.Add("Container")
        cboSort2.Items.Add("Invoice")
        cboSort2.Items.Add("SC#")
        cboSort2.Items.Add("Cust PO")
        cboSort2.SelectedIndex = 0

        cboSort3.Items.Add("N/A")
        cboSort3.Items.Add("Container")
        cboSort3.Items.Add("Invoice")
        cboSort3.Items.Add("SC#")
        cboSort3.Items.Add("Cust PO")
        cboSort3.SelectedIndex = 0

        cboUntAmt.Text = ma.cboUntAmt.Text

        txtTtlCtn.Enabled = False
        txtActVol.Enabled = False
        txtTtlAmt.Enabled = False
        cboUntAmt.Enabled = False

        Call TotalAmount()




        reset_dis()
        Call reset_display()
        Call displayGrid()

        'DataGrid1.AllowUpdate = False

        cmdOK.Focus()

    End Sub

    Private Sub TotalAmount()
        Dim sFilter As String
        Dim rs_tmp_SHIPGDTL As DataSet
        Dim tmp_CartonFactor As Integer
        Dim tmp_mod_vol As Decimal = 0
        Dim tmp_mod_gw As Decimal = 0
        Dim tmp_mod_nw As Decimal = 0

         
        rs_tmp_SHIPGDTL = rs.Copy

        TtlCtn = 0
        ActVol = 0
        TtlAmt = 0
        TtlGrs = 0
        TtlNet = 0
        txtActVol.Text = "0"
        txtTtlGrs.Text = "0"
        txtTtlNet.Text = "0"
        '   sFilter = ""
        ' rs.Tables("RESULT").DefaultView.RowFilter = sFilter
        '1021
        If rs Is Nothing Then
            Exit Sub
        End If
        If rs.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        For index As Integer = 0 To rs.Tables("RESULT").DefaultView.Count - 1
            TtlCtn = TtlCtn + rs.Tables("RESULT").DefaultView(index)("hid_ttlctn")
            '            ActVol = ActVol + rs.Tables("RESULT").DefaultView(index)("hid_ttlvol")
            TtlAmt = TtlAmt + rs.Tables("RESULT").DefaultView(index)("hid_ttlamt")
            TtlGrs = TtlGrs + rs.Tables("RESULT").DefaultView(index)("hid_ttlgrs")
            TtlNet = TtlNet + rs.Tables("RESULT").DefaultView(index)("hid_ttlnet")


            For index99 As Integer = 0 To rs_pd.Tables("RESULT").Rows.Count - 1

                If rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 5 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 6 Then
                    tmp_CartonFactor = 1
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 4 Then
                    tmp_CartonFactor = 2
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 7 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 12 Then
                    tmp_CartonFactor = 3
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 13 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 20 Then
                    tmp_CartonFactor = 4
                ElseIf rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 21 And rs_pd.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 30 Then
                    tmp_CartonFactor = 5
                End If

                If IsDBNull(rs.Tables("RESULT").DefaultView(index)("hid_ctnftr")) Then
                    Exit Sub
                End If
                If rs.Tables("RESULT").DefaultView(index)("hid_shpno") = rs_pd.Tables("RESULT").Rows(index99)("hpd_shpno") And _
                        rs.Tables("RESULT").DefaultView(index)("hid_shpseq") = rs_pd.Tables("RESULT").Rows(index99)("hpd_shpseq") And _
                            rs_pd.Tables("RESULT").Rows(index99)("hpd_dimtyp") = "Mod" And _
                tmp_CartonFactor = rs.Tables("RESULT").DefaultView(index)("hid_ctnftr") Then
                    'temp mod

                    'rs.Tables("RESULT").DefaultView(index)("hid_ttlvol") = rs.Tables("RESULT").DefaultView(index)("hid_ttlvol") + rs_pd.Tables("RESULT").Rows(index99)("hpd_ttlcbm_cm")
                    tmp_mod_vol = rs_pd.Tables("RESULT").Rows(index99)("hpd_ttlcbm_cm")

                    tmp_mod_gw = rs_pd.Tables("RESULT").Rows(index99)("hpd_ttlgw_kg")
                    tmp_mod_nw = rs_pd.Tables("RESULT").Rows(index99)("hpd_ttlnw_kg")

                End If
            Next

            txtActVol.Text = Val(txtActVol.Text) + tmp_mod_vol
            txtTtlGrs.Text = Val(txtTtlGrs.Text) + tmp_mod_gw
            txtTtlNet.Text = Val(txtTtlNet.Text) + tmp_mod_nw

        Next



        txtTtlCtn.Text = TtlCtn
        '        txtActVol.Text = ActVol
        txtTtlAmt.Text = TtlAmt
        ' txtTtlGrs.Text = TtlGrs
        '      txtTtlNet.Text = TtlNet

    End Sub


    Private Sub displayGrid()
        If rs_SHIPGDTL_display Is Nothing Then
            Exit Sub
        End If

        If rs_SHIPGDTL_display.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If


        For j As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").Columns.Count - 1
            rs_SHIPGDTL_display.Tables("RESULT").Columns(j).ReadOnly = True
        Next j

        DataGrid1.DataSource = rs_SHIPGDTL_display.Tables("RESULT").DefaultView

        Dim i As Integer

        For i = 0 To rs_SHIPGDTL_display.Tables("RESULT").Columns.Count - 1
            DataGrid1.Columns(i).Width = 0
            DataGrid1.Columns(i).Visible = False
        Next

        With DataGrid1

            .Columns("hid_shpseq").Width = 700 / 12
            .Columns("hid_shpseq").HeaderText = "Ship Seq"
            .Columns("hid_shpseq").Visible = True

            .Columns("hid_ctrcfs").Width = 1000 / 12
            .Columns("hid_ctrcfs").HeaderText = "CTR/CFS"
            .Columns("hid_ctrcfs").Visible = True

            .Columns("hid_invno").Width = 1000 / 12
            .Columns("hid_invno").HeaderText = "Invoice No."
            .Columns("hid_invno").Visible = True

            .Columns("hid_ordno").Width = 1000 / 12
            .Columns("hid_ordno").HeaderText = "S/C #"
            .Columns("hid_ordno").Visible = True

            .Columns("hid_ordseq").Width = 700 / 12
            .Columns("hid_ordseq").HeaderText = "S/C Seq."
            .Columns("hid_ordseq").Visible = True

            .Columns("hid_jobno").Width = 1500 / 12
            .Columns("hid_jobno").HeaderText = "Job No."
            .Columns("hid_jobno").Visible = True

            'added in 20170321
            .Columns("hid_sealno").Width = 1000 / 12
            .Columns("hid_sealno").HeaderText = "Seal No."
            .Columns("hid_sealno").Visible = True

            .Columns("hid_cuspo").Width = 1000 / 12
            .Columns("hid_cuspo").HeaderText = "Cust PO"
            .Columns("hid_cuspo").Visible = True

            .Columns("hid_itmno").Width = 1000 / 12
            .Columns("hid_itmno").HeaderText = "Item No."
            .Columns("hid_itmno").Visible = True

            .Columns("hid_colpck").Width = 4000 / 12
            .Columns("hid_colpck").HeaderText = "Col./UM/Inner/Master/CBM"
            .Columns("hid_colpck").Visible = True

            .Columns("hid_shpqty").Width = 1000 / 12
            .Columns("hid_shpqty").HeaderText = "Ship Qty"
            .Columns("hid_shpqty").Visible = True

            .Columns("hid_untcde").Width = 1000 / 12
            .Columns("hid_untcde").HeaderText = "UM"
            .Columns("hid_untcde").Visible = True


            .Columns("hid_ttlctn").Width = 1000 / 12
            .Columns("hid_ttlctn").HeaderText = "Ttl Ctn"
            .Columns("hid_ttlctn").Visible = True

            .Columns("hid_mtrdcm").Width = 1000 / 12
            .Columns("hid_mtrdcm").HeaderText = "Length"
            .Columns("hid_mtrdcm").Visible = True

            .Columns("hid_mtrwcm").Width = 1000 / 12
            .Columns("hid_mtrwcm").HeaderText = "Width"
            .Columns("hid_mtrwcm").Visible = True

            .Columns("hid_mtrhcm").Width = 1000 / 12
            .Columns("hid_mtrhcm").HeaderText = "Height"
            .Columns("hid_mtrhcm").Visible = True

            .Columns("hid_ttlvol").Width = 1300 / 12
            .Columns("hid_ttlvol").HeaderText = "Ttl Mod Cbm"
            .Columns("hid_ttlvol").Visible = True

            .Columns("hid_ttlamt").Width = 1000 / 12
            .Columns("hid_ttlamt").HeaderText = "Ttl Amt"
            .Columns("hid_ttlamt").Visible = True

            .Columns("hid_grswgt").Width = 1300 / 12
            .Columns("hid_grswgt").HeaderText = "Mod Gross Wgt"
            .Columns("hid_grswgt").Visible = True

            .Columns("hid_netwgt").Width = 1300 / 12
            .Columns("hid_netwgt").HeaderText = "Mod Net Wgt"
            .Columns("hid_netwgt").Visible = True

            .Columns("hid_ttlgrs").Width = 1300 / 12
            .Columns("hid_ttlgrs").HeaderText = "Mod Ttl Gross Wgt"
            .Columns("hid_ttlgrs").Visible = True

            .Columns("hid_ttlnet").Width = 1300 / 12
            .Columns("hid_ttlnet").HeaderText = "Mod Ttl Net Wgt"
            .Columns("hid_ttlnet").Visible = True

            .Columns("hid_creusr").Width = 0 / 12
            .Columns("hid_creusr").HeaderText = "Status"
            .Columns("hid_creusr").Visible = False

            .Columns("hid_ctnstr").Width = 1000 / 12
            .Columns("hid_ctnstr").HeaderText = "CTN Start"
            .Columns("hid_ctnstr").Visible = True

            .Columns("hid_ctnend").Width = 1000 / 12
            .Columns("hid_ctnend").HeaderText = "CTN End"
            .Columns("hid_ctnend").Visible = True

        End With


        'Check Same Item
        For index_i As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
            For index_j As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                If index_i <> index_j Then
                    If rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_i)("hid_shpseq").ToString() = rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_j)("hid_shpseq").ToString() Then
                        DataGrid1.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                        DataGrid1.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                        'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub Label3_Click()

    End Sub

    Private Sub Label51_Click()

    End Sub



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()

    End Sub

    Private Sub cboSort1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSort1.SelectedIndexChanged
        cboSort2.SelectedIndex = -1
        cboSort3.SelectedIndex = -1


        If (cboSort1.Text = cboSort2.Text Or cboSort1.Text = cboSort3.Text) And _
            (cboSort1.Text <> "N/A") Then
            MsgBox("Sort key duplicated")
            cboSort1.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort1.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort2.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        ElseIf cboSort3.Text = "Cust PO" Then
            TmpSort = TmpSort + "hid_cuspo,"
        End If




        If TmpSort <> "" Then

            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"

            'Check Same Item
            For index_i As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                For index_j As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                    If index_i <> index_j Then
                        If rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_i)("hid_shpseq").ToString() = rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_j)("hid_shpseq").ToString() Then
                            DataGrid1.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                            DataGrid1.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                            'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                        End If
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub cboSort2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSort2.SelectedIndexChanged
        cboSort3.SelectedIndex = -1

        Dim TmpSort As String

        If (cboSort2.Text = cboSort1.Text Or cboSort2.Text = cboSort3.Text) And _
                        (cboSort2.Text <> "N/A") And (cboSort2.Text.Trim <> "") Then
            MsgBox("Sort key duplicated")
            cboSort2.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If TmpSort <> "" Then
            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"
            'Check Same Item
            For index_i As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                For index_j As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                    If index_i <> index_j Then
                        If rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_i)("hid_shpseq").ToString() = rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_j)("hid_shpseq").ToString() Then
                            DataGrid1.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                            DataGrid1.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                            'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                        End If
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub cboSort3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSort3.SelectedIndexChanged
        Dim TmpSort As String

        If (cboSort3.Text = cboSort1.Text Or cboSort3.Text = cboSort2.Text) And _
            (cboSort3.Text <> "N/A") And (cboSort3.Text.Trim <> "") Then
            MsgBox("Sort key duplicated")
            cboSort3.SelectedIndex = 0
            Exit Sub
        End If

        TmpSort = ""

        If cboSort1.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort1.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort1.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort2.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort2.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort2.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If cboSort3.Text = "Container" Then
            TmpSort = TmpSort + "hid_ctrcfs,"
        ElseIf cboSort3.Text = "Invoice" Then
            TmpSort = TmpSort + "hid_invno,"
        ElseIf cboSort3.Text = "SC#" Then
            TmpSort = TmpSort + "hid_ordno,hid_ordseq,"
        End If

        If TmpSort <> "" Then
            TmpSort = Microsoft.VisualBasic.Left(TmpSort, Len(TmpSort) - 1)
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Sort = TmpSort + " ASC"
            'Check Same Item
            For index_i As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                For index_j As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").DefaultView.Count - 1
                    If index_i <> index_j Then
                        If rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_i)("hid_shpseq").ToString() = rs_SHIPGDTL_display.Tables("RESULT").DefaultView(index_j)("hid_shpseq").ToString() Then
                            DataGrid1.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                            DataGrid1.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                            'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                        End If
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub cboCtr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtr.SelectedIndexChanged
        If rs_SHIPGDTL_display Is Nothing Then
            Exit Sub
        End If

        If rs_SHIPGDTL_display.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        cboInv.Text = "<< ALL >>"

        If cboCtr.Text = "<< ALL >>" Then
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.RowFilter = ""
            rs.Tables("RESULT").DefaultView.RowFilter = ""
        Else
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.RowFilter = "hid_ctrcfs = '" + cboCtr.Text + "'"
            rs.Tables("RESULT").DefaultView.RowFilter = "hid_ctrcfs = '" + cboCtr.Text + "'"
        End If

        Call TotalAmount()


        DataGrid1.DataSource = rs_SHIPGDTL_display.Tables("RESULT").DefaultView
        Call displayGrid()

    End Sub

    Private Sub cboInv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInv.SelectedIndexChanged
        If rs_SHIPGDTL_display Is Nothing Then
            Exit Sub
        End If

        If rs_SHIPGDTL_display.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        cboCtr.Text = "<< ALL >>"
        If cboInv.Text = "<< ALL >>" Then
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.RowFilter = ""
            rs.Tables("RESULT").DefaultView.RowFilter = ""
        Else
            rs_SHIPGDTL_display.Tables("RESULT").DefaultView.RowFilter = "hid_invno = '" + cboInv.Text + "'"
            rs.Tables("RESULT").DefaultView.RowFilter = "hid_invno = '" + cboInv.Text + "'"
        End If
        Call TotalAmount()

        DataGrid1.DataSource = rs_SHIPGDTL_display.Tables("RESULT").DefaultView
        Call displayGrid()
    End Sub


    Private Function update_SHIPGDTL_dis(ByVal shpseq As Integer, ByVal index_dis As Integer)
        Dim loc As Integer
        For index_f As Integer = 0 To rs_SHIPGDTL_dis.Tables("result").Rows.Count - 1
            If index_f < rs_SHIPGDTL_dis.Tables("result").Rows.Count Then
                If rs_SHIPGDTL_dis.Tables("result").Rows(index_f).RowState <> DataRowState.Deleted Then
                    If rs_SHIPGDTL_dis.Tables("result").Rows(index_f)("hid_shpseq") = shpseq Then
                        rs_SHIPGDTL_dis.Tables("result").Rows(index_f).Delete()
                        index_f = index_f - 1
                        rs_SHIPGDTL_dis.Tables("result").AcceptChanges()

                    End If
                End If
            End If
        Next


        Dim last_dis_ As Integer

        If index_dis <> 111 Then
            'temp
            For index_insert As Integer = 0 To index_dis - 1
                Call insertdis(shpseq, True)
                last_dis_ = rs_SHIPGDTL_dis.Tables("result").Rows.Count - 1


                Dim tmp_CartonFactor As Integer

                For index99 As Integer = 0 To rs_SHPCKDIM_copy.Tables("result").Rows.Count - 1

                    If rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 5 And rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 6 Then
                        tmp_CartonFactor = 1
                    ElseIf rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 4 Then
                        tmp_CartonFactor = 2
                    ElseIf rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 7 And rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 12 Then
                        tmp_CartonFactor = 3
                    ElseIf rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 13 And rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 20 Then
                        tmp_CartonFactor = 4
                    ElseIf rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") >= 21 And rs_SHPCKDIM_copy.Tables("RESULT").Rows(index99)("hpd_pdnum") <= 30 Then
                        tmp_CartonFactor = 5
                    End If

                    If rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_shpno") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_shpno") _
                    And rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_shpseq") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_shpseq") _
                    And rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_ctnftr") = tmp_CartonFactor _
                    And rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_shpseq") = shpseq _
                    And rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_pdnum") = get_pdnum(tmp_CartonFactor, index_insert) _
                    And rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_dimtyp") = "Mod" Then

                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_mtrdcm") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_l_cm")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_mtrwcm") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_w_cm")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_mtrhcm") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_h_cm")

                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_actvol") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_cbm_cm")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_ttlvol") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_ttlcbm_cm")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_grswgt") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_gw_kg")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_ttlgrs") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_ttlgw_kg")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_netwgt") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_nw_kg")
                        rs_SHIPGDTL_dis.Tables("result").Rows(last_dis_)("hid_ttlnet") = rs_SHPCKDIM_copy.Tables("result").Rows(index99)("hpd_ttlnw_kg")



                    End If
                Next



            Next

        End If
    End Function
    Function reset_dis()

        rs_SHIPGDTL_dis = rs.Copy
        For i As Integer = 0 To rs_SHIPGDTL_dis.Tables("RESULT").Columns.Count - 1
            rs_SHIPGDTL_dis.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        For index_dis As Integer = 0 To rs.Tables("result").Rows.Count - 1
            If IsDBNull(rs.Tables("result").Rows(index_dis)("hid_ctnftr")) Then
                Exit Function
            End If
            '            If rs.Tables("result").Rows(index_dis)("hid_ctnftr") > 1 Then
            update_SHIPGDTL_dis(rs.Tables("result").Rows(index_dis)("hid_shpseq"), rs.Tables("result").Rows(index_dis)("hid_ctnftr"))
            'End If
        Next


        'display
    End Function

    Function reset_display()
        Dim shpseq As Integer
        Dim loc As Integer

        rs_SHIPGDTL_display = Nothing

        gspStr = "sp_list_SHIPGDTL '','' "
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_display, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_SHIPGDTL :" & rtnStr)
            Exit Function
        End If

        For i As Integer = 0 To rs_SHIPGDTL_display.Tables("RESULT").Columns.Count - 1
            rs_SHIPGDTL_display.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        If rs_SHIPGDTL_dis Is Nothing Then
            Exit Function
        End If
        For i As Integer = 0 To rs_SHIPGDTL_dis.Tables("result").Rows.Count - 1
            rs_SHIPGDTL_display.Tables("RESULT").Rows.Add()
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("Del") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("Del")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("Cov") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("Cov")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_cocde") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_cocde")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_shpno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_shpno")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_shpseq") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_shpseq")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_invno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_invno")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ctrsiz") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ctrsiz")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ctrcfs") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ctrcfs")


            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_cuspo") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_cuspo")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_jobno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_jobno")
            'added in 20170321
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_sealno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_sealno")

            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ordno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ordno")

            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ordseq") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ordseq")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_colpck") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_colpck")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mtrwcm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mtrwcm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mtrhcm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mtrhcm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_purord") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_purord")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_itmno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_itmno")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_cusitm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_cusitm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_cuscol") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_cuscol")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_shpqty") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_shpqty")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_untcde") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_untcde")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ttlctn") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ttlctn")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ctnstr") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ctnstr")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ctnend") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ctnend")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mtrdcm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mtrdcm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mtrwcm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mtrwcm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mtrhcm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mtrhcm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_actvol") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_actvol")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ttlvol") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ttlvol")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_grswgt") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_grswgt")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ttlgrs") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ttlgrs")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_netwgt") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_netwgt")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ttlnet") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ttlnet")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_paytrm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_paytrm")
            '    rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_paytrmdsc") = ""
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_prctrm") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_prctrm")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_selprc") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_selprc")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_untsel") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_untsel")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_untamt") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_untamt")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_ttlamt") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_ttlamt")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_mannam") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_mannam")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_venno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_venno")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_cusven") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_cusven")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_pckrmk") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_pckrmk")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_creusr") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_creusr")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_alsitmno") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_alsitmno")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_alscolcde") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_alscolcde")
            rs_SHIPGDTL_display.Tables("RESULT").Rows(i).Item("hid_custum") = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_custum")

        Next


    End Function


    Private Function insertdis(ByVal shpseq As Integer, ByVal addnew As Boolean)
        Dim loc As Integer
        Dim index As Integer

        For indextest As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1

            If shpseq = rs.Tables("RESULT").Rows(indextest)("hid_shpseq") Then
                index = indextest
            End If

        Next


        If addnew = True Then
            'Dim i As Integer
            'For i = 0 To rs_SHIPGDTL_dis.Tables("RESULT").Rows.Count - 1
            '    If rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_shpseq") > shpseq Then
            '        shpseq = rs_SHIPGDTL_dis.Tables("RESULT").Rows(i).Item("hid_shpseq")
            '    End If
            'Next i
            'shpseq = shpseq + 1

            'insertdis = shpseq

            rs_SHIPGDTL_dis.Tables("RESULT").Rows.Add()

            loc = rs_SHIPGDTL_dis.Tables("RESULT").Rows.Count - 1
        Else
            ''should be the cur one, instead of last item
            ' ''shpseq = rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("hid_shpseq")
            'loc = loc
            ''shpseq = rs_SHIPGDTL_dis.Tables("RESULT").Rows(rs_SHIPGDTL_dis.Tables("RESULT").Rows.Count - 1).Item("hid_shpseq")
        End If


        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("Del") = rs.Tables("RESULT").Rows(index)("Del")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("Cov") = rs.Tables("RESULT").Rows(index)("Cov")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("mode") = rs.Tables("RESULT").Rows(index)("mode")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cocde") = rs.Tables("RESULT").Rows(index)("hid_cocde")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_shpno") = rs.Tables("RESULT").Rows(index)("hid_shpno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_shpseq") = rs.Tables("RESULT").Rows(index)("hid_shpseq")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctrcfs") = rs.Tables("RESULT").Rows(index)("hid_ctrcfs")


        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctrsiz") = rs.Tables("RESULT").Rows(index)("hid_ctrsiz")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_pckrmk") = rs.Tables("RESULT").Rows(index)("hid_pckrmk")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctrsiz") = rs.Tables("RESULT").Rows(index)("hid_ctrsiz")

        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_jobno") = rs.Tables("RESULT").Rows(index)("hid_jobno")
        'added in 20170321
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_sealno") = rs.Tables("RESULT").Rows(index)("hid_sealno")


        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ordno") = rs.Tables("RESULT").Rows(index)("hid_ordno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ordseq") = rs.Tables("RESULT").Rows(index)("hid_ordseq")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cuspo") = rs.Tables("RESULT").Rows(index)("hid_cuspo")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cusitm") = rs.Tables("RESULT").Rows(index)("hid_cusitm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_itmno") = rs.Tables("RESULT").Rows(index)("hid_itmno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_itmtyp") = rs.Tables("RESULT").Rows(index)("hid_itmtyp")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_itmdsc") = rs.Tables("RESULT").Rows(index)("hid_itmdsc")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_colcde") = rs.Tables("RESULT").Rows(index)("hid_colcde")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cuscol") = rs.Tables("RESULT").Rows(index)("hid_cuscol")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_coldsc") = rs.Tables("RESULT").Rows(index)("hid_coldsc")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_shpqty") = rs.Tables("RESULT").Rows(index)("hid_shpqty")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_untcde") = rs.Tables("RESULT").Rows(index)("hid_untcde")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctnstr") = rs.Tables("RESULT").Rows(index)("hid_ctnstr")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctnend") = rs.Tables("RESULT").Rows(index)("hid_ctnend")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_inrctn") = rs.Tables("RESULT").Rows(index)("hid_inrctn")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_mtrctn") = rs.Tables("RESULT").Rows(index)("hid_mtrctn")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_vol") = rs.Tables("RESULT").Rows(index)("hid_vol")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_mtrdcm") = rs.Tables("RESULT").Rows(index)("hid_mtrdcm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_mtrwcm") = rs.Tables("RESULT").Rows(index)("hid_mtrwcm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_mtrhcm") = rs.Tables("RESULT").Rows(index)("hid_mtrhcm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_actvol") = rs.Tables("RESULT").Rows(index)("hid_actvol")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_grswgt") = rs.Tables("RESULT").Rows(index)("hid_grswgt")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_netwgt") = rs.Tables("RESULT").Rows(index)("hid_netwgt")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_itmshm") = rs.Tables("RESULT").Rows(index)("hid_itmshm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cmprmk") = rs.Tables("RESULT").Rows(index)("hid_cmprmk")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_mannam") = rs.Tables("RESULT").Rows(index)("hid_mannam")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_manadr") = rs.Tables("RESULT").Rows(index)("hid_manadr")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ttlvol") = rs.Tables("RESULT").Rows(index)("hid_ttlvol")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ttlnet") = rs.Tables("RESULT").Rows(index)("hid_ttlnet")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ttlgrs") = rs.Tables("RESULT").Rows(index)("hid_ttlgrs")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ttlctn") = rs.Tables("RESULT").Rows(index)("hid_ttlctn")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_untsel") = rs.Tables("RESULT").Rows(index)("hid_untsel")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_selprc") = rs.Tables("RESULT").Rows(index)("hid_selprc")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_untamt") = rs.Tables("RESULT").Rows(index)("hid_untamt")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ttlamt") = rs.Tables("RESULT").Rows(index)("hid_ttlamt")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_invno") = rs.Tables("RESULT").Rows(index)("hid_invno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_prctrm") = rs.Tables("RESULT").Rows(index)("hid_prctrm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_paytrm") = rs.Tables("RESULT").Rows(index)("hid_paytrm")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_purord") = rs.Tables("RESULT").Rows(index)("hid_purord")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_purseq") = rs.Tables("RESULT").Rows(index)("hid_purseq")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_venno") = rs.Tables("RESULT").Rows(index)("hid_venno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cusven") = rs.Tables("RESULT").Rows(index)("hid_cusven")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_cusstyno") = rs.Tables("RESULT").Rows(index)("hid_cusstyno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_consolno") = rs.Tables("RESULT").Rows(index)("hid_consolno")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_replacement") = rs.Tables("RESULT").Rows(index)("hid_replacement")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_colpck") = rs.Tables("RESULT").Rows(index)("hid_colpck")

        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_ctnftr") = rs.Tables("RESULT").Rows(index)("hid_ctnftr")

        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_updusr") = rs.Tables("RESULT").Rows(index)("hid_updusr")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("hid_credat") = rs.Tables("RESULT").Rows(index).Item("hid_credat")
        rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc).Item("hid_upddat") = rs.Tables("RESULT").Rows(index).Item("hid_upddat")
        ' rs_SHIPGDTL_dis.Tables("RESULT").Rows(loc)("hid_creusr") = "mis"


    End Function
    Function get_pdnum(ByVal tmp_CartonFactor, ByVal index_insert) As Integer
        If tmp_CartonFactor = 1 Then
            get_pdnum = index_insert + 5
        ElseIf tmp_CartonFactor = 2 Then
            get_pdnum = index_insert * 2 + 1
        ElseIf tmp_CartonFactor = 3 Then
            get_pdnum = index_insert * 2 + 7
        ElseIf tmp_CartonFactor = 4 Then
            get_pdnum = index_insert * 2 + 13
        ElseIf tmp_CartonFactor = 5 Then
            get_pdnum = index_insert * 2 + 21
        End If
        get_pdnum = get_pdnum + 1
        'mod
    End Function

    Private Sub DataGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid1.CellContentClick

    End Sub

    Private Sub DataGrid1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid1.CellEndEdit

    End Sub
End Class





