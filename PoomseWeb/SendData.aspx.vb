Public Partial Class SendData
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Jude As String = Request.QueryString("Jude")

        Dim Auther1_Acc As String = Request.QueryString("Auther1_Acc")
        Dim Auther1_Pre As String = Request.QueryString("Auther1_Pre")
        Dim Auther2_Acc As String = Request.QueryString("Auther2_Acc")
        Dim Auther2_Pre As String = Request.QueryString("Auther2_Pre")


        Dim FileName As String = Server.MapPath("\PoomsaeScoreData\C_" & Jude & "_" & Format(Now, "yyyyMMddHHmmss") & ".txt")
        Dim Fs As New System.IO.FileStream(FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Write)
        Dim Sw As New System.IO.StreamWriter(Fs)
        Try
            'SendHeader()

            Sw.WriteLine(Jude & vbTab & Auther1_Acc & vbTab & Auther1_Pre & vbTab & Auther2_Acc & vbTab & Auther2_Pre)

            Sw.Close()
            Fs.Close()
        Catch ex As Exception

        End Try
        'Response.Write(DateTime.Now.ToString & "[Jude : " & Jude & "][Acc : " & Acc & "][Pre :" & Pre & "]")
    End Sub

End Class