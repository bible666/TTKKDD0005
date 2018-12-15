Public Partial Class confirm
    Inherits System.Web.UI.Page

    Private Judge As String
    Private Acc As String
    Private Pre As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Judge = Request.QueryString("Judge")

        Dim Auther1_Acc As String = Request.QueryString("Auther1_Acc")
        Dim Auther1_Pre As String = Request.QueryString("Auther1_Pre")
        Dim Auther2_Acc As String = Request.QueryString("Auther2_Acc")
        Dim Auther2_Pre As String = Request.QueryString("Auther2_Pre")

        Response.Write("Jude[" & Judge & "] Acc1 [" & Auther1_Acc & "] Pre1 [" & Auther1_Pre & "] Acc2 [" & Auther2_Acc & "] Pre2 [" & Auther2_Pre & "]")

        If Not IO.Directory.Exists(Server.MapPath("\PoomsaeScoreData\")) Then
            IO.Directory.CreateDirectory(Server.MapPath("\PoomsaeScoreData\"))
        End If

        Dim FileName As String = Server.MapPath("\PoomsaeScoreData\C_" & Judge & "_" & Format(Now, "yyyyMMddHHmmss") & ".txt")
        Dim Fs As New System.IO.FileStream(FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Write)
        Dim Sw As New System.IO.StreamWriter(Fs)
        Try
            'SendHeader()

            Sw.WriteLine(Judge & "C" & vbTab & Auther1_Acc & vbTab & Auther1_Pre & vbTab & Auther2_Acc & vbTab & Auther2_Pre)

            Sw.Close()
            Fs.Close()
        Catch ex As Exception
            Response.Write("Error" + ex.Message)
        End Try
    End Sub


End Class