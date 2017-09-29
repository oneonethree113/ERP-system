Public Class frmCombineImage

    Dim rs_IMBOMASS_IMVENINF As New DataSet

    Dim sDirectory As String
    Dim sImagePath As String
    Dim sFileName As String
    Dim sVenTyp As String

    Private Sub frmCombineImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call cmdCombine_Click(sender, e)
    End Sub

    Private Sub cmdCombine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCombine.Click
        gspStr = "sp_select_IMBOMASS_IMVENINF '', '" & txtItmNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS_IMVENINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmCombineImage_Load sp_select_IMBOMASS_IMVENINF :" & rtnStr)
            Exit Sub
        End If

        Dim dr() As DataRow = rs_IMBOMASS_IMVENINF.Tables("RESULT").Select("TYP = 'C'")

        Dim MergedImage As Image ' This will be the finished merged image
        Dim Wide, High As Integer ' Size of merged image
        Dim pageType As String
        Dim sWide, sHigh As Integer 'Size of small image
        Dim xCount, yCount As Integer 'Size of small image

        pageType = ""


        Dim image_count As Integer
        image_count = dr.Length
        'For test only



        If image_count < 2 Or image_count > 20 Then
            MsgBox("Processing images cannot below 2 over 20!")
            Exit Sub
        End If

        Select Case image_count
            Case 2 '2x1 L
                pageType = "Landscape"
                xCount = 2
                yCount = 1
            Case 3, 4 '2x2 P
                pageType = "Portrait"
                xCount = 2
                yCount = 2
            Case 5, 6 '3x2 L
                pageType = "Landscape"
                xCount = 3
                yCount = 2
            Case 7, 8, 9 '3x3 P
                pageType = "Portrait"
                xCount = 3
                yCount = 3
            Case 10, 11, 12 '4x3 L
                pageType = "Landscape"
                xCount = 4
                yCount = 3
            Case 13, 14, 15, 16 '4x4 P
                pageType = "Portrait"
                xCount = 4
                yCount = 4
            Case 17, 18, 19, 20 '5x4 L
                pageType = "Landscape"
                xCount = 5
                yCount = 4
            Case Else
        End Select

        If pageType = "Landscape" Then
            Wide = 540
            High = 400
        Else
            Wide = 400
            High = 540
        End If

        sWide = Wide / xCount
        sHigh = High / yCount

        ' Create an empty Bitmap the correct size to hold both images side by side 
        Dim bm As New Bitmap(Wide, High)
        ' Get the Graphics object for this bitmap
        Dim gr As Graphics = Graphics.FromImage(bm)
        gr.Clear(Color.White)

        Dim xloc As Integer
        Dim yloc As Integer

        xloc = 0
        yloc = 0

        'For test only
        Dim Pic As Image
        'Pic = Image.FromFile("\\uchkimgsrv\guest-share\ucppc\itemimg\17E_BXXW\00B17EVG072A1.jpg")
        '   Pic(1) = Image.FromFile("\\UCHKIMGSRV\guest-share\ucppc\itemimg\82D_B00W\00B82DTT075AK.JPG")
        Dim sWide_final As Integer
        Dim sHigh_final As Integer

        Dim i As Integer
        For i = 0 To image_count - 1
            If dr(i).Item("ibi_imgpth") <> "" Then
                Pic = Image.FromFile(dr(i).Item("ibi_imgpth"))

                'Fix for 4:3 size
                If Pic.Width > Pic.Height Then
                    If sWide < sHigh Then
                        sWide_final = sWide
                        sHigh_final = sWide * 3 / 4
                    Else
                        sWide_final = sHigh
                        sHigh_final = sHigh * 3 / 4
                    End If
                Else
                    If sWide < sHigh Then
                        sHigh_final = sWide
                        sWide_final = sWide * 3 / 4
                    Else
                        sHigh_final = sHigh
                        sWide_final = sHigh * 3 / 4
                    End If
                End If
                gr.DrawImage(Pic, xloc * sWide, yloc * sHigh, sWide_final, sHigh_final)
            End If

            Pic = Nothing
            xloc = xloc + 1

            If xloc = xCount Then
                yloc = yloc + 1
                xloc = 0
            End If
        Next i

        MergedImage = bm
        PictureBox1.Image = MergedImage


        Dim drAss() As DataRow = rs_IMBOMASS_IMVENINF.Tables("RESULT").Select("TYP = 'P' and ivi_def = 'Y'")
        If drAss.Length = 1 Then

            If drAss(0).Item("vbi_ventyp") = "E" Then
                sDirectory = "\\Uchkimgsrv\itemimg\ucp\itemimg\" & drAss(0).Item("ivi_venno")
                sImagePath = sDirectory & "\" & revisedItmno(drAss(0).Item("ivi_venitm")) & "_" & drAss(0).Item("ivi_venno") & ".JPG"
                sFileName = revisedItmno(drAss(0).Item("ivi_venitm")) & "_" & drAss(0).Item("ivi_venno") & ".JPG"
                sVenTyp = "E"
            Else
                sDirectory = "\\Uchkimgsrv\itemimg\ucppc\itemimg\" & revisedItmno(drAss(0).Item("ibi_lnecde"))
                sImagePath = sDirectory & "\" & revisedItmno(drAss(0).Item("ivi_itmno")) & ".JPG"
                sFileName = revisedItmno(drAss(0).Item("ivi_itmno")) & ".JPG"
                sVenTyp = "I"
            End If



        Else
            MsgBox("Upload path Error!")
            Exit Sub
        End If

        gr.Dispose()
    End Sub

    Public Function revisedItmno(ByVal itmNo As String) As String
        '*** converting format of item no:
        itmNo = Replace(itmNo, " /", "_")
        itmNo = Replace(itmNo, "/", "_")
        itmNo = Replace(itmNo, "-", "_")
        itmNo = Replace(itmNo, " ", "")
        revisedItmno = itmNo
    End Function


    Private Sub UploadImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadImageToolStripMenuItem.Click
        'For live
        If System.IO.Directory.Exists(sDirectory) = False Then
            System.IO.Directory.CreateDirectory(sDirectory)
        End If
        PictureBox1.Image.Save(sImagePath)

        'Save for image path
        gspStr = "sp_insert_IMAGE_UPLOAD '', '" & sFileName & "','" & sImagePath & "','Y','" & gsUsrID & "','" & sVenTyp & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmCombineImage_Load sp_insert_Upload_Image :" & rtnStr)
            Exit Sub
        End If


        MsgBox("Upload Completed!")

        'For Testing
        '        Label1.Text = sImagePath
        '        PictureBox1.Image.Save("C:\abc.jpg")
    End Sub

    Private Sub DiscardImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiscardImageToolStripMenuItem.Click

    End Sub

    Private Sub ReloadImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadImageToolStripMenuItem.Click
        Call cmdCombine_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
