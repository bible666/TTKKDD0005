Partial Public Class _Default
    Inherits System.Web.UI.Page

    Public Enum ScoreType
        Acc_4_Pre_6 = 0
        Acc_6_Pre_4 = 1
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim Judge As Integer = 0
        Dim ScoreType As ScoreType = _Default.ScoreType.Acc_4_Pre_6

        If rdb1.Checked Then
            Judge = 1
        ElseIf rdb2.Checked Then
            Judge = 2
        ElseIf rdb3.Checked Then
            Judge = 3
        ElseIf rdb4.Checked Then
            Judge = 4
        ElseIf rdb5.Checked Then
            Judge = 5
        ElseIf rdb6.Checked Then
            Judge = 6
        ElseIf rdb7.Checked Then
            Judge = 7
        End If

        If rdbType1.Checked Then
            ScoreType = _Default.ScoreType.Acc_4_Pre_6
        ElseIf rdbType2.Checked Then
            ScoreType = _Default.ScoreType.Acc_6_Pre_4
        End If

        Response.Redirect("ProcessInput.aspx?Judge=" & Judge & "&ScoreType=" & ScoreType & "&AutherId1=" & AutherId1.Text.Trim & "&AutherName1=" & AutherName1.Text.Trim & "&AutherId2=" & AutherId2.Text.Trim & "&AutherName2=" & AutherName2.Text.Trim)
    End Sub
End Class