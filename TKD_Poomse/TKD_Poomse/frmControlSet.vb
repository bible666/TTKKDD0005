Public Class frmControlSet
    Public okStatus As Boolean = False
    Private iRedId As Integer = -1
    Private iBlueId As Integer = -1
    Private ctl As New clsPlaySound
    Private isLoadAthlete As Boolean = False
    Private isFirstLoad As Boolean = True

    Public frmCtl As clsCForm

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        With frmCtl
            .RoundTime = CInt(txtTime.Text) ' Set Max Time Per Round
            .NowTime = CInt(txtNowTime.Text) 'set เวลาคงเหลือ

            'Set Joy Value
            .AccOrigin = CDbl(txtAcc.Text.Trim)
            .AccCut = CDbl(txtAccCut.Text.Trim)
            .PreOrigin = CDbl(txtPre.Text.Trim)
            .PreCut = CDbl(txtPreCut.Text.Trim)

            'Refress Score
            .ResetScoreAll()

            'Set Time Type
            If rdbTimeBack.Checked Then
                .TimeType = frmScreenControl.CountStatus.MaxToMin
            ElseIf rdbTimeForward.Checked Then
                .TimeType = frmScreenControl.CountStatus.MinToMax
            End If

            'Set Rund
            .RoundMax = CInt(txtShowRound.Text.Trim)
            .RoundRun = CInt(txtNowRound.Text.Trim)
            If frmCtl.ConnDb Then
                'Set Type
                .TypeId = cboType.SelectedValue
                .TypeDesc = cboType.Text.Trim
                'Set Age
                .AgeId = cboAge.SelectedValue
                .AgeDesc = cboAge.Text.Trim
                'Set Level
                .LevelId = cboLevel.SelectedValue
                .LevelDesc = cboLevel.Text.Trim
                'Set Sex
                .SexId = cboSex.SelectedValue
                .SexDesc = cboSex.Text.Trim

                .AthleteId = cboAthlete.SelectedValue

                LoadAthleteAndTeam()
            Else
                'Set Type
                .TypeDesc = cboType.Text.Trim
                'Set Age
                .AgeDesc = cboAge.Text.Trim
                'Set Level
                .LevelDesc = cboLevel.Text.Trim
            End If

            'set Jude
            If rdbJudge1.Checked Then
                .JudeCount = 1
            ElseIf rdbJudge3.Checked Then
                .JudeCount = 3
            ElseIf rdbJudge5.Checked Then
                .JudeCount = 5
            ElseIf rdbJudge7.Checked Then
                .JudeCount = 7
            End If

            frmCtl.FightType = cboType.Text.Trim
            frmCtl.FightAge = cboAge.Text.Trim
            frmCtl.FightLevel = cboLevel.Text.Trim
            frmCtl.FightSex = cboSex.Text.Trim
            .Athlete = txtName.Text.Trim

            frmCtl.SoundId = cboSound.SelectedIndex
            frmCtl.TeamName = txtTeam.Text.Trim
        End With

        okStatus = True

        Me.Close()
    End Sub

    Private Sub LoadAthleteAndTeam()
        isLoadAthlete = True
        If cboType.SelectedIndex >= 0 And Not IsNothing(cboType.DataSource) _
           AndAlso cboAge.SelectedIndex >= 0 And Not IsNothing(cboAge.DataSource) _
           AndAlso cboLevel.SelectedIndex >= 0 AndAlso cboSex.SelectedIndex >= 0 And Not IsNothing(cboSex.DataSource) Then
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = " SELECT * from dbo.Poomse_Athlete"
            sql &= " where Level_Id = " & cboLevel.SelectedValue & " and Age_Id = " & cboAge.SelectedValue
            sql &= "       and Sex_Id = " & cboSex.SelectedValue & " and [TYPE_ID] = " & cboType.SelectedValue

            clsSys.conn.getData(sql, dt)
            With cboAthlete
                .DataSource = dt.Copy
                .DisplayMember = "Athlete_Id"
                .ValueMember = "Athlete_Id"
                .SelectedIndex = -1
                .Text = ""
            End With
        Else
            cboAthlete.DataSource = Nothing
            cboAthlete.SelectedIndex = -1
            cboAthlete.Text = ""
        End If
        isLoadAthlete = False
    End Sub
    Private Sub frmControlSet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtTime.Text = frmCtl.RoundTime
        txtNowTime.Text = frmCtl.NowTime
        txtAcc.Text = frmCtl.AccOrigin
        txtAccCut.Text = frmCtl.AccCut
        txtPre.Text = frmCtl.PreOrigin
        txtPreCut.Text = frmCtl.PreCut
        cboSound.SelectedIndex = frmCtl.SoundId
        'Set Rund
        txtShowRound.Text = frmCtl.RoundMax
        txtNowRound.Text = frmCtl.RoundRun

        'SetTimeType
        Select Case frmCtl.TimeType
            Case frmScreenControl.CountStatus.MinToMax
                rdbTimeForward.Checked = True
            Case frmScreenControl.CountStatus.MaxToMin
                rdbTimeBack.Checked = True
        End Select

        Select Case frmCtl.JudeCount
            Case 1
                rdbJudge1.Checked = True
            Case 3
                rdbJudge3.Checked = True
            Case 5
                rdbJudge5.Checked = True
            Case 7
                rdbJudge7.Checked = True
        End Select

        If frmCtl.ConnDb Then
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = "select * from dbo.Poomse_Type order by Type_Seq"
            clsSys.conn.getData(sql, dt)

            With cboType
                .DataSource = dt.Copy
                .DisplayMember = "Type_Desc"
                .ValueMember = "Type_Id"
                .SelectedValue = frmCtl.TypeId
            End With

            sql = "select * from dbo.Poomse_Age order by Age_Seq"
            clsSys.conn.getData(sql, dt)
            With cboAge
                .DataSource = dt.Copy
                .DisplayMember = "Age_Desc"
                .ValueMember = "Age_Id"
                .SelectedValue = frmCtl.AgeId
            End With

            sql = "select * from dbo.Poomse_Level"
            clsSys.conn.getData(sql, dt)
            With cboLevel
                .DataSource = dt.Copy
                .DisplayMember = "Level_Desc"
                .ValueMember = "Level_Id"
                .SelectedValue = frmCtl.LevelId
            End With

            sql = "select * from dbo.Poomse_Sex order by Sex_Seq"
            clsSys.conn.getData(sql, dt)
            With cboSex
                .DataSource = dt.Copy
                .DisplayMember = "Sex_Desc"
                .ValueMember = "Sex_Id"
                .SelectedValue = frmCtl.SexId
            End With

            LoadAthleteAndTeam()

            cboAthlete.SelectedValue = frmCtl.AthleteId

            txtName.Text = frmCtl.Athlete
            txtTeam.Text = frmCtl.TeamName
        Else
            cboType.Text = frmCtl.FightType
            cboAge.Text = frmCtl.FightAge
            cboLevel.Text = frmCtl.FightLevel
            cboSex.Text = frmCtl.FightSex
            txtName.Text = frmCtl.Athlete
            txtTeam.Text = frmCtl.TeamName
        End If
        

        'If clsScoreControl.ConnType = clsScoreControl.eDBType.Connection Then
        '    txtField.Visible = False
        '    cboField.Visible = True
        '    Dim dt As New DataTable
        '    Dim sql As String = " SELECT * FROM M_Field"
        '    clsSys.conn.getData(sql, dt)
        '    If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
        '        cboField.DataSource = dt
        '        cboField.DisplayMember = "FieldNameTh"
        '        cboField.ValueMember = "FieldId"
        '        cboField.SelectedValue = clsScoreControl.FieldId
        '    End If
        'Else
        '    'Not Connection DB
        '    cboField.Visible = False
        '    txtField.Visible = True
        '    txtField.Text = clsScoreControl.FieldName
        'End If

        'txtBreak.Text = clsScoreControl.TimeBreak
        'cboSound.SelectedIndex = clsScoreControl.iSoundId
        'txtTime.Text = clsScoreControl.min
        'txtKyeShi.Text = clsScoreControl.KyeShi
        'txtPoint.Text = clsScoreControl.MaxPoint
        'txtRound.Text = clsScoreControl.FieldSeq
        'txtShowRound.Text = clsScoreControl.Round

        'Select Case clsScoreControl.MaxRound
        '    Case 1 : rdbRound1.Checked = True
        '    Case 2 : rdbRound2.Checked = True
        '    Case 3 : rdbRound3.Checked = True
        '    Case 4 : rdbGapPoint.Checked = True
        'End Select

        'If clsScoreControl.eRoundType = clsScoreControl.RoundType.Auto Then
        '    rdbRoundAuto.Checked = True
        'ElseIf clsScoreControl.eRoundType = clsScoreControl.RoundType.Manula Then
        '    rdbRoundM.Checked = True
        '    txtShowRound.Text = clsScoreControl.Round
        'End If

        'iRedId = clsScoreControl.iRedId
        'txtRed.Text = clsScoreControl.sRedName
        'txtRedTeam.Text = clsScoreControl.sRedTeam
        'iBlueId = clsScoreControl.iBlueId
        'txtBlue.Text = clsScoreControl.sBlueName
        'txtBlueTeam.Text = clsScoreControl.sBlueTeam
        'txtIP.Text = clsScoreControl.sServer_IP


    End Sub

    Private Function GetAthleteData(ByVal FieldId As Integer, ByVal ShowSeq As Double) As DataTable
        Dim dt As New DataTable
        Dim sql As String = String.Empty
        sql = " select P1.Prefix_Name + ' ' + A1.Names  + ' ' + A1.Lastname as Blue,A1.AthleteID as BlueID,"
        sql &= "       P2.Prefix_Name + ' ' + A2.Names  + ' ' + A2.Lastname as Red,A2.AthleteID as RedID,"
        sql &= "       A1.Team as BlueTeam,A2.Team as RedTeam"
        sql &= " from DataLine D LEFT JOIN M_Athlete A1 ON D.Athlete_1 = A1.AthleteID"
        sql &= "           LEFT JOIN M_Prefix P1 ON A1.Prefix = P1.Prefix_ID"
        sql &= "           LEFT JOIN M_Athlete A2 ON D.Athlete_2 = A2.AthleteID"
        sql &= "           LEFT JOIN M_Prefix P2 ON A2.Prefix = P2.Prefix_ID"
        sql &= " Where D.FieldId = " & FieldId & " and D.ShowSeq = " & ShowSeq
        clsSys.conn.getData(sql, dt)
        Return dt
    End Function

    'Private Sub txtRound_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTime.KeyPress _
    '                                                               , txtRound.KeyPress, txtNowRound.KeyPress, txtNowTime.KeyPress
    '    Select Case e.KeyChar
    '        Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", vbBack
    '            e.Handled = False
    '        Case Else
    '            e.Handled = True
    '    End Select
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboSound.SelectedIndex >= 0 Then
            Select Case cboSound.SelectedIndex
                Case 0
                    ctl.Play_Sound_RoundEnd()
                Case Else
                    ctl.Play_Sound_RoundEndNum(cboSound.SelectedIndex)
            End Select
        End If
    End Sub

  
    Private Sub cboLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLevel.SelectedIndexChanged, cboAge.SelectedIndexChanged, cboSex.SelectedIndexChanged, cboType.SelectedIndexChanged
        If isFirstLoad = False AndAlso frmCtl.ConnDb Then
            LoadAthleteAndTeam()
        End If
    End Sub

    Private Sub cboAthlete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAthlete.SelectedIndexChanged
        If isLoadAthlete = False AndAlso cboAthlete.SelectedIndex >= 0 Then
            Dim dr As DataRowView
            dr = cboAthlete.SelectedItem
            txtName.Text = dr("Athlete_Name")
            txtTeam.Text = dr("Athlete_Team")
        End If
    End Sub

    Private Sub frmControlSet_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        isFirstLoad = False
    End Sub
End Class