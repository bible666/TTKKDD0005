Partial Public Class ProcessInput2
    Inherits System.Web.UI.Page

    Private Judge As String
    Private ScoreTpye As _Default.ScoreType = _Default.ScoreType.Acc_4_Pre_6
    Private AutherId1 As String
    Private AutherId2 As String
    Private AutherName1 As String
    Private AutherName2 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Judge = Request.QueryString("Judge")
        ScoreTpye = Request.QueryString("ScoreType")
        AutherId1 = Request.QueryString("AutherId1")
        AutherName1 = Request.QueryString("AutherName1")
        AutherId2 = Request.QueryString("AutherId2")
        AutherName2 = Request.QueryString("AutherName2")

        lblJudge.Text = Judge
        'Auther1.Text = AutherId1 & " : " & AutherName1
        'Auther2.Text = AutherId2 & " : " & AutherName2
        If ScoreTpye = _Default.ScoreType.Acc_4_Pre_6 Then
            lblAccAuther1.Text = "4.00"
            lblAccAuther2.Text = "4.00"
            lblPreAuther1.Text = "6.00"
            lblPreAuther2.Text = "6.00"
        ElseIf ScoreTpye = _Default.ScoreType.Acc_6_Pre_4 Then
            lblAccAuther1.Text = "6.00"
            lblAccAuther2.Text = "6.00"
            lblPreAuther1.Text = "4.00"
            lblPreAuther2.Text = "4.00"
        End If

    End Sub

End Class