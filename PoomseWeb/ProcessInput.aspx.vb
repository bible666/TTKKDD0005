Partial Public Class ProcessInput
    Inherits System.Web.UI.Page

    Private Judge As String
    Private ScoreTpye As _Default1.ScoreType = _Default1.ScoreType.Acc_4_Pre_6

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Judge = Request.QueryString("Judge")
        ScoreTpye = Request.QueryString("ScoreType")

        lblJudge.Text = Judge

        If ScoreTpye = _Default1.ScoreType.Acc_4_Pre_6 Then
            lblAcc.Text = "4.00"
            lblPre.Text = "6.00"
        ElseIf ScoreTpye = _Default1.ScoreType.Acc_6_Pre_4 Then
            lblAcc.Text = "6.00"
            lblPre.Text = "4.00"
        End If

        'btnCom.Attributes.Add("onClick", "javascript:if(confirm('Do you want to confirm?')==false)return false;")
    End Sub

    'Private Sub btnCom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCom.Click

    '    '    Response.Redirect("confirm.aspx?Judge=" & lblJudge.Text & "&Acc=" & lblAcc.Text & "&Pre=" & lblPre.Text)
    'End Sub
End Class