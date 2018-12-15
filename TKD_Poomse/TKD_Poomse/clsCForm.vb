Imports TKD_Poomse.EnumData
Imports System.IO
Imports System.Diagnostics


Public Class clsCForm

    Private frmCtl As New frmScreenControl
    Private frmShow As New frmScreenShow
    Private PlaySound As New clsPlaySound

    Public joyCtl As New clsJoyControl(frmCtl)

    Public CaptionCtl As String = ""
    Public CaptionShow As String = ""

    Public TypeId As Integer = -1
    Public TypeDesc As String = ""

    Public AgeId As Integer = -1
    Public AgeDesc As String = ""

    Public SexId As Integer = -1
    Public SexDesc As String = ""

    Public LevelId As Integer = -1
    Public LevelDesc As String = ""

    Public AthleteId As Integer = -1
    Public RoundMax As Integer = 2 'จำนวนรอบสูงสุดต่อ 1 Game

    Public TimeType As frmScreenControl.CountStatus = frmScreenControl.CountStatus.MaxToMin

    Public ComfirmJoy1 As Integer = 0
    Public ComfirmJoy2 As Integer = 0
    Public ComfirmJoy3 As Integer = 0
    Public ComfirmJoy4 As Integer = 0
    Public ComfirmJoy5 As Integer = 0
    Public ComfirmJoy6 As Integer = 0
    Public ComfirmJoy7 As Integer = 0

#Region " Property "
    ''' <summary>
    ''' รันแบบต่อกับฐานข้อมูล
    ''' </summary>
    ''' <remarks></remarks>
    Private bCon As Boolean = False
    ''' <summary>
    ''' รันแบบต่อกับฐานข้อมูล
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConnDb() As Boolean
        Get
            Return bCon
        End Get
        Set(ByVal value As Boolean)
            bCon = value
        End Set
    End Property

    Private iSoundId As Integer = 0
    ''' <summary>
    ''' Set Sound ID 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SoundId() As Integer
        Get
            Return iSoundId
        End Get
        Set(ByVal value As Integer)
            iSoundId = value
        End Set
    End Property

    Private mGameStatus As GameStatusType = GameStatusType.None
    Public Property GameStatus() As GameStatusType
        Get
            Return mGameStatus
        End Get
        Set(ByVal value As GameStatusType)
            mGameStatus = value
            UpdateStatusOnScreen()
            Select Case value
                Case GameStatusType.EndRound
                    iNowTime = iRoundTime
                    PlaySound.Play_Sound_RoundEndNum(iSoundId)
                Case GameStatusType.EndGame
                    iNowTime = iRoundTime
                    PlaySound.Play_Sound_RoundEndNum(iSoundId)
            End Select
        End Set
    End Property

    Private iRoundTime As Integer = 90 ' วินาที 
    ''' <summary>
    ''' เวลาในการแข่งขันแต่ละรอบ เป็น วินาที
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RoundTime() As Integer
        Get
            Return iRoundTime
        End Get
        Set(ByVal value As Integer)
            iRoundTime = value
        End Set
    End Property

    ''' <summary>
    ''' เวลาแข่งขันปัจจุบัน เป็น วินาที
    ''' </summary>
    ''' <remarks></remarks>
    Private iNowTime As Integer = 90
    Public Property NowTime() As Integer
        Get
            Return iNowTime
        End Get
        Set(ByVal value As Integer)

            iNowTime = value
            'frmShow
        End Set
    End Property

    Private sFightType As String = ""
    Public Property FightType() As String
        Get
            Return sFightType
        End Get
        Set(ByVal value As String)
            sFightType = value
            UpdateType(sFightType, sFightAge, sSex, sLevel)
        End Set
    End Property

    Private sFightAge As String = ""
    Public Property FightAge() As String
        Get
            Return sFightAge
        End Get
        Set(ByVal value As String)
            sFightAge = value
            UpdateType(sFightType, sFightAge, sSex, sLevel)
        End Set
    End Property

    Private sSex As String = ""
    Public Property FightSex() As String
        Get
            Return sSex
        End Get
        Set(ByVal value As String)
            sSex = value
            UpdateType(sFightType, sFightAge, sSex, sLevel)
        End Set
    End Property

    Private sLevel As String = ""
    Public Property FightLevel() As String
        Get
            Return sLevel
        End Get
        Set(ByVal value As String)
            sLevel = value
            UpdateType(sFightType, sFightAge, sSex, sLevel)
        End Set
    End Property

    Private iRoundRun As Integer = 1 ' รอบปัจจุบัน
    ''' <summary>
    ''' รอบปัจจุบันที่กำลังจะทำการแข่งขัน
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RoundRun() As Integer
        Get
            Return iRoundRun
        End Get
        Set(ByVal value As Integer)
            iRoundRun = value
            UpdateRound()
        End Set
    End Property

    Private iK As Integer = 0
    Private iK2 As Integer = 0

    ''' <summary>
    ''' Get or Set K Value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property K() As Integer
        Get
            Return iK
        End Get
        Set(ByVal value As Integer)
            iK = value
            Update_K_Value()
            UpdateFinalScore()
        End Set
    End Property

    ''' <summary>
    ''' Get or Set K2 Value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property K2() As Integer
        Get
            Return iK2
        End Get
        Set(ByVal value As Integer)
            iK2 = value
            Update_K2_Value()
            UpdateFinalScore()
        End Set
    End Property

#Region " Property Jude Count จำนวนของมุ่มที่กรรมการอยู่ "
    Private iJudeCount As Integer = 3
    ''' <summary>
    ''' จำนวนของ มุมที่กรรมการอยู่
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JudeCount() As Integer
        Get
            Return iJudeCount
        End Get
        Set(ByVal value As Integer)
            iJudeCount = value
        End Set
    End Property
#End Region

#Region " Property Acc Origin คะแนนต้นฉบับ ของ Acc "
    Private iAccOrigin As Double = 4.0
    ''' <summary>
    ''' Set or Get Acc Origin
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AccOrigin() As Double
        Get
            Return iAccOrigin
        End Get
        Set(ByVal value As Double)
            iAccOrigin = value
            joyCtl.SetAccOriginAllJoy(iAccOrigin)
            AccClearAll()
        End Set
    End Property
#End Region

#Region " Property Acc Cut  "
    Private iAccCut As Double = 0.1
    ''' <summary>
    ''' Set or Get Acc Cut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AccCut() As Double
        Get
            Return iAccCut
        End Get
        Set(ByVal value As Double)
            iAccCut = value
            joyCtl.SetAccCutAllJoy(iAccCut)
        End Set
    End Property
#End Region

#Region " Property Pre Origin คะแนนต้นฉบับ ของ Pre "
    Private iPreOrigin As Double = 6.0
    ''' <summary>
    ''' Set or Get Pre Origin
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreOrigin() As Double
        Get
            Return iPreOrigin
        End Get
        Set(ByVal value As Double)
            iPreOrigin = value
            joyCtl.SetPreOriginAllJoy(iPreOrigin)
            PreClearAll()
        End Set
    End Property
#End Region

#Region " Property Acc Cut  "
    Private iPreCut As Double = 0.3
    ''' <summary>
    ''' Set or Get Pre Cut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PreCut() As Double
        Get
            Return iPreCut
        End Get
        Set(ByVal value As Double)
            iPreCut = value
            joyCtl.SetPreCutAllJoy(iPreCut)
        End Set
    End Property
#End Region

#Region " Property Set Athlete ชือผู้เข้าแข่งขัน "
    Private sAthlete As String
    ''' <summary>
    ''' ชือผู้ที่จะเข้าแข่งขัน
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Athlete() As String
        Get
            Return sAthlete
        End Get
        Set(ByVal value As String)
            sAthlete = value
            UpdateAhtlete(sAthlete)
        End Set
    End Property
#End Region

    Private sTeam As String = ""
    ''' <summary>
    ''' Set up Team Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TeamName() As String
        Get
            Return sTeam
        End Get
        Set(ByVal value As String)
            sTeam = value
            UpdateTeam()
        End Set
    End Property

#End Region

    ''' <summary>
    ''' Update K Value To Screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Update_K_Value()
        frmCtl.lblK.Text = iK
        frmShow.lblK.Text = iK
    End Sub

    ''' <summary>
    ''' Update K2 Value To Screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Update_K2_Value()
        frmCtl.lblK2.Text = iK2
        frmShow.lblK2.Text = iK2
    End Sub

    ''' <summary>
    ''' Start Program
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Show()
        frmCtl.ctl = Me
        CaptionCtl = frmCtl.Text
        CaptionShow = frmShow.Text
        frmCtl.Show()
        frmShow.Show()
    End Sub

#Region " Acc Control "
    Public Sub AccSet(ByVal JoyNo As JoyId, ByVal AccValue As Double)
        joyCtl.AccSet(JoyNo, AccValue)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub
    Public Sub AccCutScore_1(ByVal JoyNo As JoyId)
        joyCtl.AccCut_1(JoyNo)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub

    Public Sub AccCutScore_3(ByVal JoyNo As JoyId)
        joyCtl.AccCut_3(JoyNo)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub

    Public Sub AccClear(ByVal JoyNo As JoyId)
        joyCtl.AccClear(JoyNo)
        RefressScore(JoyNo)
    End Sub

    Public Sub AccClearAll()
        AccClear(JoyId.Joy1)
        AccClear(JoyId.Joy2)
        AccClear(JoyId.Joy3)
        AccClear(JoyId.Joy4)
        AccClear(JoyId.Joy5)
        AccClear(JoyId.Joy6)
        AccClear(JoyId.Joy7)
    End Sub
#End Region

#Region " Pre Control "
    Public Sub PreSet(ByVal JoyNo As JoyId, ByVal PreValue As Double)
        joyCtl.PreSet(JoyNo, PreValue)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub
    Public Sub PreCutScore_1(ByVal JoyNo As JoyId)
        joyCtl.PreCut_1(JoyNo)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub

    Public Sub PreCutScore_3(ByVal JoyNo As JoyId)
        joyCtl.PreCut_3(JoyNo)
        RefressScore(JoyNo)
        UnComfirmJoy(JoyNo)
    End Sub

    Public Sub PreClear(ByVal JoyNo As JoyId)
        joyCtl.PreClear(JoyNo)
        RefressScore(JoyNo)
    End Sub
    Public Sub PreClearAll()
        PreClear(JoyId.Joy1)
        PreClear(JoyId.Joy2)
        PreClear(JoyId.Joy3)
        PreClear(JoyId.Joy4)
        PreClear(JoyId.Joy5)
        PreClear(JoyId.Joy6)
        PreClear(JoyId.Joy7)
    End Sub
#End Region

#Region " Final Score "
    ''' <summary>
    ''' Get Final Score By Joy
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FinalScore(ByVal JoyNo As JoyId) As Double
        Return joyCtl.GetFinalScore(JoyNo)
    End Function

    ''' <summary>
    ''' Get Acc Score By Joy
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AccScore(ByVal JoyNo As JoyId) As Double
        Return joyCtl.GetAccScore(JoyNo)
    End Function

    ''' <summary>
    ''' Get Pre Score By Joy
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PreScore(ByVal JoyNo As JoyId) As Double
        Return joyCtl.GetPreScore(JoyNo)
    End Function

    Public Sub UpdateFinalScore1()
        If ConnDb AndAlso AthleteId > 0 Then
            Dim sql As String
            Dim Round1Score As Double = 0
            Dim Round2Score As Double = 0
            Dim TotalScore As Double = 0

            If IsNumeric(frmCtl.txtRound1.Text) Then
                Round1Score = CDbl(frmCtl.txtRound1.Text)
            End If
            If IsNumeric(frmCtl.txtRound2.Text) Then
                Round2Score = CDbl(frmCtl.txtRound2.Text)
            End If
            If IsNumeric(frmCtl.lblFinalScore.Text) Then
                TotalScore = CDbl(frmCtl.txtTotal.Text)
            End If
            If RoundRun = 2 Then
                sql = "  UPDATE Poomse_Score"
                sql &= " SET Total_Round1_1 = " & Format(Round1Score, "0.00")
                sql &= "    ,Total_Round2_1 = " & Format(Round2Score, "0.00")
                sql &= "    ,Total_AllRound_1 = " & Format(TotalScore, "0.00")
                sql &= " WHERE Athlete_Id = " & AthleteId
                sql &= "    AND Round = 2"
                clsSys.conn.runSQL(sql)
                MessageBox.Show(sql)
            End If

        End If
    End Sub

    Public Sub UpdateFinalScore2()
        If ConnDb AndAlso AthleteId > 0 Then
            Dim sql As String
            Dim Round1Score As Double = 0
            Dim Round2Score As Double = 0
            Dim DivValue As Double = 0
            Dim TotalScore As Double = 0

            If IsNumeric(frmCtl.txtRound1_1.Text) Then
                Round1Score = CDbl(frmCtl.txtRound1_1.Text)
            End If
            If IsNumeric(frmCtl.txtRound2_1.Text) Then
                Round2Score = CDbl(frmCtl.txtRound2_1.Text)
            End If
            If IsNumeric(frmCtl.txtRoundCount.Text) Then
                DivValue = CDbl(frmCtl.txtRoundCount.Text)
            End If
            If IsNumeric(frmCtl.lblFinalScore.Text) Then
                TotalScore = CDbl(frmCtl.txtTotal2.Text)
            End If
            If RoundRun = 2 Then
                sql = "  UPDATE Poomse_Score"
                sql &= " SET Total_Round1_2 = " & Format(Round1Score, "0.00")
                sql &= "    ,Total_Round2_2 = " & Format(Round2Score, "0.00")
                sql &= "    ,Total_AllRound_2 = " & Format(TotalScore, "0.00")
                sql &= "    ,Total_Div_2 = " & Format(DivValue, "0.00")
                sql &= " WHERE Athlete_Id = " & AthleteId
                sql &= "    AND Round = 2"
                clsSys.conn.runSQL(sql)
                'MessageBox.Show(sql)
            End If

        End If
    End Sub

    Public Sub CheckUpdateTable()
        If ConnDb Then
            Dim sql As String
            Dim dtTable As New DataTable
            sql = "  SELECT T.name as TableName,T.object_id,C.name as ColName"
            sql &= " FROM Sys.objects T INNER JOIN sys.columns C ON T.object_id = C.object_id"
            sql &= " where T.[type] = 'U' AND T.name = 'Poomse_Score' AND C.name = 'Total_Round1_1'"
            clsSys.conn.getData(sql, dtTable)
            If Not (Not IsNothing(dtTable) AndAlso dtTable.Rows.Count > 0) Then
                'ไม่มี Column ใหม่
                sql = " ALTER TABLE Poomse_Score ADD Total_Round1_1 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_Round2_1 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_AllRound_1 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_Round1_2 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_Round2_2 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_Div_2 decimal(18,5)"
                clsSys.conn.runSQL(sql)
                sql = " ALTER TABLE Poomse_Score ADD Total_AllRound_2 decimal(18,5)"
                clsSys.conn.runSQL(sql)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update Final Score when end time and save to DB
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateFinalScore()
        Dim iScore As Double = Nothing
        Dim dAcc As Double = Nothing
        Dim dPre As Double = Nothing
        dAcc = GetAccScore()
        dPre = GetPreScore()
        iScore = dAcc + dPre ' GetFinalScore()
        If iScore >= 0 AndAlso iK > 0 Then
            iScore -= iK * 0.3
            If iK2 > 0 Then
                iScore -= iK2 * 0.1
            End If
        End If
        If iScore < 0 Then
            With frmCtl
                .lblFinalScore.Text = ""
                .lblFinalScore.Refresh()
            End With

            With frmShow
                .lblFinalScore.Text = ""
                .lblFinalScore.Refresh()
            End With
        Else
           
            frmCtl.lblFinalScore.Text = Format(iScore, "0.00")
            frmCtl.lblFinalScore.Refresh()

            frmCtl.lblTotalAcc.Text = Format(dAcc, "0.00")
            frmCtl.lblTotalPre.Text = Format(dPre, "0.00")

            If Me.RoundRun = 1 Then
                frmCtl.lblAccRound1.Text = "Acc:" & Format(dAcc, "0.00")
                frmCtl.lblPreRound1.Text = "Pre:" & Format(dPre, "0.00")
                frmCtl.lblTotalRound1.Text = "Total:" & Format(iScore, "0.00")

                frmCtl.txtRound1.Text = Format(iScore, "0.00")
                frmCtl.txtRound1.Refresh()

                frmCtl.txtRound1_1.Text = Format(iScore, "0.00")
                frmCtl.txtRound1_1.Refresh()
            Else
                frmCtl.lblAccRound2.Text = "Acc:" & Format(dAcc, "0.00")
                frmCtl.lblPreRound2.Text = "Pre:" & Format(dPre, "0.00")
                frmCtl.lblTotalRound2.Text = "Total:" & Format(iScore, "0.00")

                Dim dPreRound1 As Double = 0
                Dim dAccRound1 As Double = 0
                Try
                    dAccRound1 = frmCtl.lblAccRound1.Text.Replace("Acc:", "")
                Catch ex As Exception
                    dAccRound1 = 0
                End Try

                Try
                    dPreRound1 = frmCtl.lblPreRound1.Text.Replace("Pre:", "")
                Catch ex As Exception
                    dPreRound1 = 0
                End Try

                frmCtl.lblAccSummary.Text = "Acc:" & Format(dAccRound1 + dAcc, "0.00")
                frmCtl.lblPreSummary.Text = "Pre:" & Format(dPreRound1 + dPre, "0.00")
                frmCtl.lblTotalSummary.Text = "Total:" & Format(CDbl(frmCtl.txtRound1.Text.Trim) + iScore, "0.00")

                frmCtl.txtRound2.Text = Format(iScore, "0.00")
                frmCtl.txtRound2.Refresh()

                frmCtl.txtTotal.Text = Format(CDbl(frmCtl.txtRound1.Text.Trim) + iScore, "0.00")
                frmCtl.txtTotal.Refresh()

                frmCtl.txtRound2_1.Text = Format(iScore, "0.00")
                frmCtl.txtRound2_1.Refresh()
                frmCtl.txtTotal_1.Text = Format(CDbl(frmCtl.txtRound1.Text.Trim) + iScore, "0.00")
                frmCtl.txtTotal_1.Refresh()
            End If

            If ConnDb Then
                Dim dao As New dao_Poomse_Score
                With dao
                    .Athlete_Id = AthleteId
                    .Round = Me.RoundRun
                    .Final = iScore

                    .Acc_1 = 0
                    .Acc_2 = 0
                    .Acc_3 = 0
                    .Acc_4 = 0
                    .Acc_5 = 0
                    .Acc_6 = 0
                    .Acc_7 = 0
                    .Pre_1 = 0
                    .Pre_2 = 0
                    .Pre_3 = 0
                    .Pre_4 = 0
                    .Pre_5 = 0
                    .Pre_6 = 0
                    .Pre_7 = 0

                    If ComfirmJoy1 = 1 Then
                        .Acc_1 = joyCtl.GetAccScore(JoyId.Joy1)
                        .Pre_1 = joyCtl.GetPreScore(JoyId.Joy1)
                    End If

                    If ComfirmJoy2 = 1 Then
                        .Acc_2 = joyCtl.GetAccScore(JoyId.Joy2)
                        .Pre_2 = joyCtl.GetPreScore(JoyId.Joy2)
                    End If

                    If ComfirmJoy3 = 1 Then
                        .Acc_3 = joyCtl.GetAccScore(JoyId.Joy3)
                        .Pre_3 = joyCtl.GetPreScore(JoyId.Joy3)
                    End If

                    If ComfirmJoy4 = 1 Then
                        .Acc_4 = joyCtl.GetAccScore(JoyId.Joy4)
                        .Pre_4 = joyCtl.GetPreScore(JoyId.Joy4)
                    End If

                    If ComfirmJoy5 = 1 Then
                        .Acc_5 = joyCtl.GetAccScore(JoyId.Joy5)
                        .Pre_5 = joyCtl.GetPreScore(JoyId.Joy5)
                    End If

                    If ComfirmJoy6 = 1 Then
                        .Acc_6 = joyCtl.GetAccScore(JoyId.Joy6)
                        .Pre_6 = joyCtl.GetPreScore(JoyId.Joy6)
                    End If

                    If ComfirmJoy7 = 1 Then
                        .Acc_7 = joyCtl.GetAccScore(JoyId.Joy7)
                        .Pre_7 = joyCtl.GetPreScore(JoyId.Joy7)
                    End If

                    .K = (iK * 0.3) + (iK2 * 0.1)

                    If ConnDb Then
                        If .chkKey Then
                            .updKey()
                        Else
                            .insRec()
                        End If
                    End If

                End With

            End If

        End If

    End Sub
#End Region

#Region " Test Joy Input กระพริบ "

    Public Sub Joy1Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude1.BackColor = Color.Red
                .lblJude1.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude1.BackColor = Color.Green
                .lblJude1.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude1.BackColor = Color.Yellow
                .lblJude1.Refresh()
            End With
        Next

    End Sub

    Public Sub Joy2Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude2.BackColor = Color.Red
                .lblJude2.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude2.BackColor = Color.Green
                .lblJude2.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude2.BackColor = Color.Yellow
                .lblJude2.Refresh()
            End With
        Next

    End Sub

    Public Sub Joy3Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude3.BackColor = Color.Red
                .lblJude3.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude3.BackColor = Color.Green
                .lblJude3.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude3.BackColor = Color.Yellow
                .lblJude3.Refresh()
            End With
        Next
    End Sub

    Public Sub Joy4Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude4.BackColor = Color.Red
                .lblJude4.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude4.BackColor = Color.Green
                .lblJude4.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude4.BackColor = Color.Yellow
                .lblJude4.Refresh()
            End With
        Next
    End Sub

    Public Sub Joy5Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude5.BackColor = Color.Red
                .lblJude5.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude5.BackColor = Color.Green
                .lblJude5.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude5.BackColor = Color.Yellow
                .lblJude5.Refresh()
            End With
        Next
    End Sub

    Public Sub Joy6Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude6.BackColor = Color.Red
                .lblJude6.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude6.BackColor = Color.Green
                .lblJude6.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude6.BackColor = Color.Yellow
                .lblJude6.Refresh()
            End With
        Next
    End Sub

    Public Sub Joy7Input()
        For i As Integer = 1 To 5
            With frmCtl
                .lblJude7.BackColor = Color.Red
                .lblJude7.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude7.BackColor = Color.Green
                .lblJude7.Refresh()
                System.Threading.Thread.Sleep(100)
                .lblJude7.BackColor = Color.Yellow
                .lblJude7.Refresh()
            End With
        Next
    End Sub

#End Region

#Region " Reset show Score "
    ''' <summary>
    ''' Reset Final Score to empty
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetFinalScore()
        frmCtl.lblFinalScore.Text = ""
        frmShow.lblFinalScore.Text = ""
    End Sub
    ''' <summary>
    ''' Reset Score value and update to screen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetScoreAll()
        joyCtl.AccClear(JoyId.Joy1)
        joyCtl.PreClear(JoyId.Joy1)
        joyCtl.AccClear(JoyId.Joy2)
        joyCtl.PreClear(JoyId.Joy2)
        joyCtl.AccClear(JoyId.Joy3)
        joyCtl.PreClear(JoyId.Joy3)
        joyCtl.AccClear(JoyId.Joy4)
        joyCtl.PreClear(JoyId.Joy4)
        joyCtl.AccClear(JoyId.Joy5)
        joyCtl.PreClear(JoyId.Joy5)
        joyCtl.AccClear(JoyId.Joy6)
        joyCtl.PreClear(JoyId.Joy6)
        joyCtl.AccClear(JoyId.Joy7)
        joyCtl.PreClear(JoyId.Joy7)
        RefressScore(JoyId.Joy1)
        RefressScore(JoyId.Joy2)
        RefressScore(JoyId.Joy3)
        RefressScore(JoyId.Joy4)
        RefressScore(JoyId.Joy5)
        RefressScore(JoyId.Joy6)
        RefressScore(JoyId.Joy7)
        ClearComfiremJoyAll()

        'Clear Control Form
        With frmCtl
            .lblTotalAcc.Text = ""
            .lblTotalPre.Text = ""
            .txtRound2.Text = ""
            .txtTotal.Text = ""
            .txtTotal2.Text = ""

            If iRoundRun = 1 Then
                .txtRound1.Text = ""
                .txtRound1_1.Text = ""
                .lblAccRound1.Text = ""
                .lblPreRound1.Text = ""
                .lblTotalRound1.Text = ""
            End If

            .txtRoundCount.Text = ""

            .txtRound2_1.Text = ""
            .txtTotal_1.Text = ""


            .lblAccRound2.Text = ""
            .lblAccSummary.Text = ""


            .lblPreRound2.Text = ""
            .lblPreSummary.Text = ""


            .lblTotalRound2.Text = ""
            .lblTotalSummary.Text = ""
        End With
        

        With frmShow
            '.lblTotalAcc.Text = ""
            '.lblTotalPre.Text = ""

            If iRoundRun = 1 Then
                .lblAccRound1.Text = ""
                .lblPreRound1.Text = ""
                .lblTotalRound1.Text = ""
            End If


            .lblAccRound2.Text = ""
            .lblPreRound2.Text = ""
            .lblTotalRound2.Text = ""

            .lblAccSummary.Text = ""
            .lblPreSummary.Text = ""
            .lblTotalSummary.Text = ""

            .lbl_1_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy1), "0.0")
            .lbl_1_Acc.Refresh()
            .lbl_1_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy1), "0.0")
            .lbl_1_Pre.Refresh()
            '.lbl_1_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy1) + joyCtl.GetPreScore(JoyId.Joy1), "0.0")
            '.lbl_1_Final.Refresh()

            .lbl_2_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy2), "0.0")
            .lbl_2_Acc.Refresh()
            .lbl_2_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy2), "0.0")
            .lbl_2_Pre.Refresh()
            '.lbl_2_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy2) + joyCtl.GetPreScore(JoyId.Joy2), "0.0")
            '.lbl_2_Final.Refresh()
        End With


        With frmShow
            .lbl_3_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy3), "0.0")
            .lbl_3_Acc.Refresh()
            .lbl_3_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy3), "0.0")
            .lbl_3_Pre.Refresh()
            '.lbl_3_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy3) + joyCtl.GetPreScore(JoyId.Joy3), "0.0")
            '.lbl_3_Final.Refresh()
        End With

        With frmShow
            .lbl_4_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy4), "0.0")
            .lbl_4_Acc.Refresh()
            .lbl_4_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy4), "0.0")
            .lbl_4_Pre.Refresh()
            '.lbl_4_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy4) + joyCtl.GetPreScore(JoyId.Joy4), "0.0")
            '.lbl_4_Final.Refresh()
        End With

        With frmShow
            .lbl_5_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy5), "0.0")
            .lbl_5_Acc.Refresh()
            .lbl_5_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy5), "0.0")
            .lbl_5_Pre.Refresh()
            '.lbl_5_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy5) + joyCtl.GetPreScore(JoyId.Joy5), "0.0")
            '.lbl_5_Final.Refresh()
        End With

        'With frmShow
        '    .lbl_6_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Acc.Refresh()
        '    .lbl_6_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Pre.Refresh()
        '    .lbl_6_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy6) + joyCtl.GetPreScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Final.Refresh()
        'End With

        'With frmShow
        '    .lbl_7_Acc.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Acc.Refresh()
        '    .lbl_7_Pre.Text = "" 'Format(joyCtl.GetPreScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Pre.Refresh()
        '    .lbl_7_Final.Text = "" 'Format(joyCtl.GetAccScore(JoyId.Joy7) + joyCtl.GetPreScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Final.Refresh()
        'End With

    End Sub

    ''' <summary>
    ''' Update Score to Screen
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <remarks></remarks>
    Public Sub RefressScore(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                RefressScore_Joy1()
            Case JoyId.Joy2
                RefressScore_Joy2()
            Case JoyId.Joy3
                RefressScore_Joy3()
            Case JoyId.Joy4
                RefressScore_Joy4()
            Case JoyId.Joy5
                RefressScore_Joy5()
            Case JoyId.Joy6
                RefressScore_Joy6()
            Case JoyId.Joy7
                RefressScore_Joy7()
        End Select
    End Sub

    Delegate Sub _RefressScore_Joy1()
    ''' <summary>
    ''' Update Score Joy 1
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy1()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy1(AddressOf RefressScore_Joy1))
            Exit Sub
        End If
        With frmCtl
            .lbl_1_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy1), "0.0")
            .lbl_1_Acc.Refresh()
            .lbl_1_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy1), "0.0")
            .lbl_1_Pre.Refresh()
            .lbl_1_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy1) + joyCtl.GetPreScore(JoyId.Joy1), "0.0")
            .lbl_1_Final.Refresh()
        End With

        'With frmShow
        '    .lbl_1_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy1), "0.0")
        '    .lbl_1_Acc.Refresh()
        '    .lbl_1_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy1), "0.0")
        '    .lbl_1_Pre.Refresh()
        '    '.lbl_1_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy1) + joyCtl.GetPreScore(JoyId.Joy1), "0.0")
        '    '.lbl_1_Final.Refresh()
        'End With

    End Sub

    Delegate Sub _RefressScore_Joy2()
    ''' <summary>
    ''' Update Joy 2
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy2()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy2(AddressOf RefressScore_Joy2))
            Exit Sub
        End If
        With frmCtl
            .lbl_2_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy2), "0.0")
            .lbl_2_Acc.Refresh()
            .lbl_2_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy2), "0.0")
            .lbl_2_Pre.Refresh()
            .lbl_2_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy2) + joyCtl.GetPreScore(JoyId.Joy2), "0.0")
            .lbl_2_Final.Refresh()
        End With
        'With frmShow
        '    .lbl_2_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy2), "0.0")
        '    .lbl_2_Acc.Refresh()
        '    .lbl_2_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy2), "0.0")
        '    .lbl_2_Pre.Refresh()
        '    '.lbl_2_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy2) + joyCtl.GetPreScore(JoyId.Joy2), "0.0")
        '    '.lbl_2_Final.Refresh()
        'End With

    End Sub

    Delegate Sub _RefressScore_Joy3()
    ''' <summary>
    ''' Update Score Joy 3
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy3()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy3(AddressOf RefressScore_Joy3))
            Exit Sub
        End If
        With frmCtl
            .lbl_3_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy3), "0.0")
            .lbl_3_Acc.Refresh()
            .lbl_3_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy3), "0.0")
            .lbl_3_Pre.Refresh()
            .lbl_3_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy3) + joyCtl.GetPreScore(JoyId.Joy3), "0.0")
            .lbl_3_Final.Refresh()
        End With
        'With frmShow
        '    .lbl_3_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy3), "0.0")
        '    .lbl_3_Acc.Refresh()
        '    .lbl_3_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy3), "0.0")
        '    .lbl_3_Pre.Refresh()
        '    '.lbl_3_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy3) + joyCtl.GetPreScore(JoyId.Joy3), "0.0")
        '    '.lbl_3_Final.Refresh()
        'End With

    End Sub

    Delegate Sub _RefressScore_Joy4()
    ''' <summary>
    ''' Update Score Joy 4
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy4()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy4(AddressOf RefressScore_Joy4))
            Exit Sub
        End If
        With frmCtl
            .lbl_4_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy4), "0.0")
            .lbl_4_Acc.Refresh()
            .lbl_4_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy4), "0.0")
            .lbl_4_Pre.Refresh()
            .lbl_4_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy4) + joyCtl.GetPreScore(JoyId.Joy4), "0.0")
            .lbl_4_Final.Refresh()
        End With
        'With frmShow
        '    .lbl_4_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy4), "0.0")
        '    .lbl_4_Acc.Refresh()
        '    .lbl_4_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy4), "0.0")
        '    .lbl_4_Pre.Refresh()
        '    '.lbl_4_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy4) + joyCtl.GetPreScore(JoyId.Joy4), "0.0")
        '    '.lbl_4_Final.Refresh()
        'End With
    End Sub

    Delegate Sub _RefressScore_Joy5()
    ''' <summary>
    ''' Update Score Joy 5
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy5()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy5(AddressOf RefressScore_Joy5))
            Exit Sub
        End If
        With frmCtl
            .lbl_5_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy5), "0.0")
            .lbl_5_Acc.Refresh()
            .lbl_5_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy5), "0.0")
            .lbl_5_Pre.Refresh()
            .lbl_5_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy5) + joyCtl.GetPreScore(JoyId.Joy5), "0.0")
            .lbl_5_Final.Refresh()
        End With
        'With frmShow
        '    .lbl_5_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy5), "0.0")
        '    .lbl_5_Acc.Refresh()
        '    .lbl_5_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy5), "0.0")
        '    .lbl_5_Pre.Refresh()
        '    '.lbl_5_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy5) + joyCtl.GetPreScore(JoyId.Joy5), "0.0")
        '    '.lbl_5_Final.Refresh()
        'End With
    End Sub

    Delegate Sub _RefressScore_Joy6()
    ''' <summary>
    ''' Update Score Joy 6
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy6()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy6(AddressOf RefressScore_Joy6))
            Exit Sub
        End If
        With frmCtl
            .lbl_6_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy6), "0.0")
            .lbl_6_Acc.Refresh()
            .lbl_6_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy6), "0.0")
            .lbl_6_Pre.Refresh()
            .lbl_6_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy6) + joyCtl.GetPreScore(JoyId.Joy6), "0.0")
            .lbl_6_Final.Refresh()
        End With

        'With frmShow
        '    .lbl_6_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Acc.Refresh()
        '    .lbl_6_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Pre.Refresh()
        '    .lbl_6_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy6) + joyCtl.GetPreScore(JoyId.Joy6), "0.0")
        '    .lbl_6_Final.Refresh()
        'End With
    End Sub

    Delegate Sub _RefressScore_Joy7()
    ''' <summary>
    ''' Update Score Joy 7
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefressScore_Joy7()
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy7(AddressOf RefressScore_Joy7))
            Exit Sub
        End If
        With frmCtl
            .lbl_7_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy7), "0.0")
            .lbl_7_Acc.Refresh()
            .lbl_7_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy7), "0.0")
            .lbl_7_Pre.Refresh()
            .lbl_7_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy7) + joyCtl.GetPreScore(JoyId.Joy7), "0.0")
            .lbl_7_Final.Refresh()
        End With

        'With frmShow
        '    .lbl_7_Acc.Text = Format(joyCtl.GetAccScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Acc.Refresh()
        '    .lbl_7_Pre.Text = Format(joyCtl.GetPreScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Pre.Refresh()
        '    .lbl_7_Final.Text = Format(joyCtl.GetAccScore(JoyId.Joy7) + joyCtl.GetPreScore(JoyId.Joy7), "0.0")
        '    .lbl_7_Final.Refresh()
        'End With
    End Sub

#End Region

#Region " Update Screen Status "
    ''' <summary>
    ''' Update Status On Screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateStatusOnScreen()
        With frmCtl
            Select Case GameStatus
                Case GameStatusType.None
                    .Text = CaptionCtl
                Case GameStatusType.Start
                    .Text = CaptionCtl & " [Start] "
                Case GameStatusType.Break
                    .Text = CaptionCtl & " [Break] "
                Case GameStatusType.EndGame
                    .Text = CaptionCtl & " [End Game] "
                Case GameStatusType.EndRound
                    .Text = CaptionCtl & " [End Round] "
            End Select
        End With

        With frmShow
            Select Case GameStatus
                Case GameStatusType.None
                    .Text = CaptionShow
                Case GameStatusType.Start
                    .Text = CaptionShow & " [Start] "
                Case GameStatusType.Break
                    .Text = CaptionShow & " [Break] "
                Case GameStatusType.EndGame
                    .Text = CaptionShow & " [End Game] "
                Case GameStatusType.EndRound
                    .Text = CaptionShow & " [End Round] "
            End Select
        End With

    End Sub
#End Region

    ''' <summary>
    ''' Update Team ที่แข่งขัน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateRound()
        'frmCtl.lblRound.Text = "Round : " & iRoundRun
        If AthleteId >= 0 Then
            frmCtl.txtRound2.Text = ""
            frmCtl.txtRound2_1.Text = ""
            frmCtl.txtTotal.Text = ""
            frmCtl.txtTotal_1.Text = ""
            If iRoundRun = 1 Then
                frmCtl.txtRound1.Text = ""
                frmCtl.txtRound1_1.Text = ""
            Else
                Dim sql As String = ""
                Dim dt As New DataTable
                sql = " SELECT * FROM Poomse_Score WHERE Athlete_Id = " & AthleteId & " AND Round = 1"
                clsSys.conn.getData(sql, dt)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    frmCtl.txtRound1.Text = dt.Rows(0)("Final")
                    frmCtl.txtRound1_1.Text = dt.Rows(0)("Final")
                Else
                    frmCtl.txtRound1.Text = ""
                    frmCtl.txtRound1_1.Text = ""
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update Team ที่เข้าแข่งขัน
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateTeam()
        frmCtl.lblTeam.Text = "ทีม : " & sTeam.Trim
        frmShow.lblTeam.Text = "ทีม : " & sTeam.Trim
    End Sub

    ''' <summary>
    ''' Update ชือ ผู้เข้าแข่งขัน
    ''' </summary>
    ''' <param name="sAthlete"></param>
    ''' <remarks></remarks>
    Private Sub UpdateAhtlete(ByVal sAthlete As String)
        Dim str() As String = sAthlete.Split(vbNewLine)
        With frmCtl
            Select Case str.Length
                Case 1
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 26, FontStyle.Bold)
                Case 2
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 22, FontStyle.Bold)
                Case 3
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 18, FontStyle.Bold)
                Case 4
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 16, FontStyle.Bold)
                Case 5
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 14, FontStyle.Bold)

            End Select
            .lblAthlete.Text = ""
            For i As Integer = 0 To str.Length - 1
                .lblAthlete.Text &= str(i).Trim & "    " 'vbNewLine
            Next
        End With

        With frmShow
            Select Case str.Length
                Case 1
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 30, FontStyle.Bold)
                Case 2
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 24, FontStyle.Bold)
                Case 3
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 22, FontStyle.Bold)
                Case 4
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 20, FontStyle.Bold)
                Case 5
                    .lblAthlete.Font = New System.Drawing.Font(frmCtl.lblAthlete.Font.FontFamily, 20, FontStyle.Bold)

            End Select
            .lblAthlete.Text = ""
            For i As Integer = 0 To str.Length - 1
                If i = 3 Then
                    .lblAthlete.Text &= vbNewLine
                End If
                .lblAthlete.Text &= str(i).Trim & "    "
            Next
        End With
    End Sub

    ''' <summary>
    ''' Update Header
    ''' </summary>
    ''' <param name="sPoomseType">คู่ เดียว ผสม</param>
    ''' <param name="Age">รุ่นอายุ 8-12 ปี</param>
    ''' <param name="Sex">ชาย หญิง ผสม</param>
    ''' <param name="Level">สาย ดำ แดง</param>
    ''' <remarks></remarks>
    Public Sub UpdateType(ByVal sPoomseType As String, ByVal Age As String, ByVal Sex As String, ByVal Level As String)
        With frmCtl
            .lblType.Text = "POOMSAE   "
            .lblAge.Text = "รุ่นอายุ   " & Age & "   " & Sex & "   สาย   " & Level & " " & sPoomseType
        End With

        With frmShow
            '.lblType.Text = "POOMSAE   "
            .lblAge.Text = "รุ่นอายุ   " & Age & "   " & Sex & "   สาย   " & Level & " " & sPoomseType
        End With
    End Sub


    ''' <summary>
    ''' แสดง เวลา Update
    ''' </summary>
    ''' <param name="Time"></param>
    ''' <remarks></remarks>
    Public Sub ShowTime(ByVal Time As DateTime)
        With frmCtl
            .lblTime.Text = Format(Time, "mm:ss")
            .lblTime.Refresh()
        End With

        With frmShow
            .lblTime.Text = Format(Time, "mm:ss")
            .lblTime.Refresh()
        End With
    End Sub

    Delegate Sub _UnComfirmJoy(ByVal JoyNo As JoyId)
    ''' <summary>
    ''' Set Uncomfirem By Joy NO
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <remarks></remarks>
    Public Sub UnComfirmJoy(ByVal JoyNo As JoyId)
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _RefressScore_Joy5(AddressOf RefressScore_Joy5))
            Exit Sub
        End If
        With frmCtl
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = "Unconfirm"
                    .lbl_Comfirm_Joy1.Refresh()
                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = "Unconfirm"
                    .lbl_Comfirm_Joy2.Refresh()
                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = "Unconfirm"
                    .lbl_Comfirm_Joy3.Refresh()
                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = "Unconfirm"
                    .lbl_Comfirm_Joy4.Refresh()
                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = "Unconfirm"
                    .lbl_Comfirm_Joy5.Refresh()
                Case JoyId.Joy6
                    .lbl_Comfirm_Joy6.Text = "Unconfirm"
                    .lbl_Comfirm_Joy6.Refresh()
                Case JoyId.Joy7
                    .lbl_Comfirm_Joy7.Text = "Unconfirm"
                    .lbl_Comfirm_Joy7.Refresh()
            End Select
        End With

        With frmShow
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = ""
                    .lbl_Comfirm_Joy1.Refresh()
                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = ""
                    .lbl_Comfirm_Joy2.Refresh()
                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = ""
                    .lbl_Comfirm_Joy3.Refresh()
                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = ""
                    .lbl_Comfirm_Joy4.Refresh()
                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = ""
                    .lbl_Comfirm_Joy5.Refresh()
                    'Case JoyId.Joy6
                    '    .lbl_Comfirm_Joy6.Text = "Unconfirm"
                    '    .lbl_Comfirm_Joy6.Refresh()
                    'Case JoyId.Joy7
                    '    .lbl_Comfirm_Joy7.Text = "Unconfirm"
                    '    .lbl_Comfirm_Joy7.Refresh()
            End Select
        End With

    End Sub



    Delegate Sub _ComfirmJoy(ByVal JoyNo As JoyId)
    ''' <summary>
    ''' Comfirm Joy By Joy No
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <remarks></remarks>
    Public Sub ComfirmJoy(ByVal JoyNo As JoyId)
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _ComfirmJoy(AddressOf ComfirmJoy), JoyNo)
            Exit Sub
        End If
        With frmCtl
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = "OK"
                    .lbl_Comfirm_Joy1.Refresh()
                    ComfirmJoy1 = 1

                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = "OK"
                    .lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 1

                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = "OK"
                    .lbl_Comfirm_Joy3.Refresh()
                    ComfirmJoy3 = 1

                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = "OK"
                    .lbl_Comfirm_Joy4.Refresh()
                    ComfirmJoy4 = 1

                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = "OK"
                    .lbl_Comfirm_Joy5.Refresh()
                    ComfirmJoy5 = 1

                Case JoyId.Joy6
                    .lbl_Comfirm_Joy6.Text = "OK"
                    .lbl_Comfirm_Joy6.Refresh()
                    ComfirmJoy6 = 1

                Case JoyId.Joy7
                    .lbl_Comfirm_Joy7.Text = "OK"
                    .lbl_Comfirm_Joy7.Refresh()
                    ComfirmJoy7 = 1
            End Select
        End With

        With frmShow
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = "OK"
                    .lbl_Comfirm_Joy1.Refresh()
                    ComfirmJoy1 = 1

                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = "OK"
                    .lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 1

                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = "OK"
                    .lbl_Comfirm_Joy3.Refresh()
                    ComfirmJoy3 = 1

                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = "OK"
                    .lbl_Comfirm_Joy4.Refresh()
                    ComfirmJoy4 = 1

                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = "OK"
                    .lbl_Comfirm_Joy5.Refresh()
                    ComfirmJoy5 = 1

                    '        Case JoyId.Joy6
                    '            .lbl_Comfirm_Joy6.Text = "OK"
                    '            .lbl_Comfirm_Joy6.Refresh()
                    '            ComfirmJoy6 = 1

                    '        Case JoyId.Joy7
                    '            .lbl_Comfirm_Joy7.Text = "OK"
                    '            .lbl_Comfirm_Joy7.Refresh()
                    '            ComfirmJoy7 = 1
            End Select
        End With

        UpdateFinalScore()
    End Sub

    ''' <summary>
    ''' Comfirm Joy By Joy No
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <remarks></remarks>
    Public Sub ShowJoyToOutForm(ByVal JoyNo As JoyId)
        If frmCtl.InvokeRequired Then
            frmCtl.Invoke(New _ComfirmJoy(AddressOf ComfirmJoy), JoyNo)
            Exit Sub
        End If
        With frmCtl
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = "OK"
                    .lbl_Comfirm_Joy1.Refresh()
                    ComfirmJoy1 = 1

                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = "OK"
                    .lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 1

                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = "OK"
                    .lbl_Comfirm_Joy3.Refresh()
                    ComfirmJoy3 = 1

                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = "OK"
                    .lbl_Comfirm_Joy4.Refresh()
                    ComfirmJoy4 = 1

                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = "OK"
                    .lbl_Comfirm_Joy5.Refresh()
                    ComfirmJoy5 = 1

                Case JoyId.Joy6
                    .lbl_Comfirm_Joy6.Text = "OK"
                    .lbl_Comfirm_Joy6.Refresh()
                    ComfirmJoy6 = 1

                Case JoyId.Joy7
                    .lbl_Comfirm_Joy7.Text = "OK"
                    .lbl_Comfirm_Joy7.Refresh()
                    ComfirmJoy7 = 1
            End Select
        End With

        With frmShow
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_1_Acc.Text = frmCtl.lbl_1_Acc.Text
                    .lbl_1_Pre.Text = frmCtl.lbl_1_Pre.Text
                    '.lbl_1_Final.Text = frmCtl.lbl_1_Final.Text
                    ComfirmJoy1 = 1

                Case JoyId.Joy2
                    .lbl_2_Acc.Text = frmCtl.lbl_2_Acc.Text
                    .lbl_2_Pre.Text = frmCtl.lbl_2_Pre.Text
                    '.lbl_2_Final.Text = frmCtl.lbl_2_Final.Text
                    ComfirmJoy2 = 1

                Case JoyId.Joy3
                    .lbl_3_Acc.Text = frmCtl.lbl_3_Acc.Text
                    .lbl_3_Pre.Text = frmCtl.lbl_3_Pre.Text
                    '.lbl_3_Final.Text = frmCtl.lbl_3_Final.Text
                    ComfirmJoy3 = 1

                Case JoyId.Joy4
                    .lbl_4_Acc.Text = frmCtl.lbl_4_Acc.Text
                    .lbl_4_Pre.Text = frmCtl.lbl_4_Pre.Text
                    '.lbl_4_Final.Text = frmCtl.lbl_4_Final.Text
                    ComfirmJoy4 = 1

                Case JoyId.Joy5
                    .lbl_5_Acc.Text = frmCtl.lbl_5_Acc.Text
                    .lbl_5_Pre.Text = frmCtl.lbl_5_Pre.Text
                    '.lbl_5_Final.Text = frmCtl.lbl_5_Final.Text
                    ComfirmJoy5 = 1

                Case JoyId.Joy6
                    '.lbl_6_Acc.Text = frmCtl.lbl_6_Acc.Text
                    '.lbl_6_Pre.Text = frmCtl.lbl_6_Pre.Text
                    '.lbl_6_Final.Text = frmCtl.lbl_6_Final.Text
                    ComfirmJoy6 = 1

                Case JoyId.Joy7
                    '.lbl_7_Acc.Text = frmCtl.lbl_7_Acc.Text
                    '.lbl_7_Pre.Text = frmCtl.lbl_7_Pre.Text
                    '.lbl_7_Final.Text = frmCtl.lbl_7_Final.Text
                    ComfirmJoy7 = 1
            End Select
        End With

        UpdateFinalScore()
    End Sub

    ''' <summary>
    ''' Clear Comfirem ของทุก Joy
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearComfiremJoyAll()
        ClearComfiremJoy(JoyId.Joy1)
        ClearComfiremJoy(JoyId.Joy2)
        ClearComfiremJoy(JoyId.Joy3)
        ClearComfiremJoy(JoyId.Joy4)
        ClearComfiremJoy(JoyId.Joy5)
        ClearComfiremJoy(JoyId.Joy6)
        ClearComfiremJoy(JoyId.Joy7)
    End Sub

    ''' <summary>
    ''' Clear Comfirem Joy By Joy No
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <remarks></remarks>
    Private Sub ClearComfiremJoy(ByVal JoyNo As JoyId)
        With frmCtl
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = ""
                    .lbl_Comfirm_Joy1.Refresh()
                    ComfirmJoy1 = 0

                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = ""
                    .lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 0

                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = ""
                    .lbl_Comfirm_Joy3.Refresh()
                    ComfirmJoy3 = 0

                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = ""
                    .lbl_Comfirm_Joy4.Refresh()
                    ComfirmJoy4 = 0

                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = ""
                    .lbl_Comfirm_Joy5.Refresh()
                    ComfirmJoy5 = 0

                Case JoyId.Joy6
                    .lbl_Comfirm_Joy6.Text = ""
                    .lbl_Comfirm_Joy6.Refresh()
                    ComfirmJoy6 = 0

                Case JoyId.Joy7
                    .lbl_Comfirm_Joy7.Text = ""
                    .lbl_Comfirm_Joy7.Refresh()
                    ComfirmJoy7 = 0
            End Select
        End With

        With frmShow
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_Comfirm_Joy1.Text = ""
                    .lbl_Comfirm_Joy1.Refresh()
                    ComfirmJoy1 = 0

                Case JoyId.Joy2
                    .lbl_Comfirm_Joy2.Text = ""
                    .lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 0

                Case JoyId.Joy3
                    .lbl_Comfirm_Joy3.Text = ""
                    .lbl_Comfirm_Joy3.Refresh()
                    ComfirmJoy3 = 0

                Case JoyId.Joy4
                    .lbl_Comfirm_Joy4.Text = ""
                    .lbl_Comfirm_Joy4.Refresh()
                    ComfirmJoy4 = 0

                Case JoyId.Joy5
                    .lbl_Comfirm_Joy5.Text = ""
                    .lbl_Comfirm_Joy5.Refresh()
                    ComfirmJoy5 = 0

                    'Case JoyId.Joy6
                    '    .lbl_Comfirm_Joy6.Text = ""
                    '    .lbl_Comfirm_Joy6.Refresh()
                    '    ComfirmJoy6 = 0

                    'Case JoyId.Joy7
                    '    .lbl_Comfirm_Joy7.Text = ""
                    '    .lbl_Comfirm_Joy7.Refresh()
                    '    ComfirmJoy7 = 0
            End Select
        End With

        With frmShow
            Select Case JoyNo
                Case JoyId.Joy1
                    .lbl_1_Acc.Text = ""
                    .lbl_1_Acc.Refresh()
                    .lbl_1_Pre.Text = ""
                    '.lbl_1_Final.Text = ""
                    ComfirmJoy1 = 0

                Case JoyId.Joy2
                    .lbl_2_Acc.Text = ""
                    .lbl_2_Pre.Text = ""
                    '.lbl_2_Final.Text = ""
                    '.lbl_Comfirm_Joy2.Refresh()
                    ComfirmJoy2 = 0

                Case JoyId.Joy3
                    .lbl_3_Acc.Text = ""
                    .lbl_3_Pre.Text = ""
                    '.lbl_3_Final.Text = ""
                    ComfirmJoy3 = 0

                Case JoyId.Joy4
                    .lbl_4_Acc.Text = ""
                    .lbl_4_Pre.Text = ""
                    '.lbl_4_Final.Text = ""
                    ComfirmJoy4 = 0

                Case JoyId.Joy5
                    .lbl_5_Acc.Text = ""
                    .lbl_5_Pre.Text = ""
                    '.lbl_5_Final.Text = ""
                    ComfirmJoy5 = 0

                    'Case JoyId.Joy6
                    '    .lbl_6_Acc.Text = ""
                    '    .lbl_6_Pre.Text = ""
                    '    .lbl_6_Final.Text = ""
                    '    ComfirmJoy6 = 0

                    'Case JoyId.Joy7
                    '    .lbl_7_Acc.Text = ""
                    '    .lbl_7_Pre.Text = ""
                    '    .lbl_7_Final.Text = ""
                    '    ComfirmJoy7 = 0
            End Select
        End With
    End Sub

    Public Sub SetTotal()
        Dim total As Double = 0
        Dim Round1 As Double = 0
        Dim Round2 As Double = 0
        Try
            Round1 = CDbl(frmCtl.txtRound1.Text.Trim)
        Catch ex As Exception
            Round1 = 0
        End Try
        Try
            Round2 = CDbl(frmCtl.txtRound2.Text.Trim)
        Catch ex As Exception
            Round2 = 0
        End Try

        frmCtl.txtTotal.Text = Round1 + Round2


        'With frmShow
        '    .lblFinalScore.Text = Round1 + Round2
        '    .lblFinalScore.Refresh()
        'End With
    End Sub

    Public Sub SetTotal2()
        Dim total As Double = 0
        Dim Round1 As Double = 0
        Dim Round2 As Double = 0
        Dim RoundDiv As Double = 0

        Try
            Round1 = CDbl(frmCtl.txtRound1_1.Text.Trim)
        Catch ex As Exception
            Round1 = 0
        End Try
        Try
            Round2 = CDbl(frmCtl.txtRound2_1.Text.Trim)
        Catch ex As Exception
            Round2 = 0
        End Try

        Try
            RoundDiv = CDbl(frmCtl.txtRoundCount.Text.Trim)
        Catch ex As Exception
            RoundDiv = 0
        End Try

        frmCtl.txtTotal_1.Text = Round1 + Round2

        If RoundDiv > 0 Then
            frmCtl.txtTotal2.Text = Format((Round1 + Round2) / RoundDiv, "0.00")
        Else
            frmCtl.txtTotal2.Text = ""
        End If

        'With frmShow
        '    .lblFinalScore.Text = Round1 + Round2
        '    .lblFinalScore.Refresh()
        'End With
    End Sub


#Region " Calcualte Final Score "

    ''' <summary>
    ''' คำนวน Final Score ทุกแบบ + คิดค่า K
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFinalScore() As Double
        Dim ret As Double = 0.0
        Dim ComCount As Integer = 0

        ComCount += ComfirmJoy1
        ComCount += ComfirmJoy2
        ComCount += ComfirmJoy3
        ComCount += ComfirmJoy4
        ComCount += ComfirmJoy5
        ComCount += ComfirmJoy6
        ComCount += ComfirmJoy7

        Select Case JudeCount
            Case 1
                If ComCount >= 1 Then
                    ret = GetFinalScoreFor_1_Jude()
                Else
                    ret = -1
                End If

            Case 3
                If ComCount >= 3 Then
                    ret = GetFinalScoreFor_3_Jude()
                Else
                    ret = -1
                End If

            Case 5
                If ComCount >= 5 Then
                    ret = GetFinalScoreFor_5_Jude()
                Else
                    ret = -1
                End If

            Case 7
                If ComCount >= 7 Then
                    ret = GetFinalScoreFor_7_Jude()
                Else
                    ret = -1
                End If

        End Select

        If ret >= 0 AndAlso iK > 0 Then
            ret -= iK * 0.3
        End If
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Final Score ของ 7 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFinalScoreFor_7_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += FinalScore(JoyId.Joy1)
            If FinalScore(JoyId.Joy1) > Max Then
                Max = FinalScore(JoyId.Joy1)
            End If
            If FinalScore(JoyId.Joy1) < Min Then
                Min = FinalScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += FinalScore(JoyId.Joy2)
            If FinalScore(JoyId.Joy2) > Max Then
                Max = FinalScore(JoyId.Joy2)
            End If
            If FinalScore(JoyId.Joy2) < Min Then
                Min = FinalScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += FinalScore(JoyId.Joy3)
            If FinalScore(JoyId.Joy3) > Max Then
                Max = FinalScore(JoyId.Joy3)
            End If
            If FinalScore(JoyId.Joy3) < Min Then
                Min = FinalScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += FinalScore(JoyId.Joy4)
            If FinalScore(JoyId.Joy4) > Max Then
                Max = FinalScore(JoyId.Joy4)
            End If
            If FinalScore(JoyId.Joy4) < Min Then
                Min = FinalScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += FinalScore(JoyId.Joy5)
            If FinalScore(JoyId.Joy5) > Max Then
                Max = FinalScore(JoyId.Joy5)
            End If
            If FinalScore(JoyId.Joy5) < Min Then
                Min = FinalScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += FinalScore(JoyId.Joy6)
            If FinalScore(JoyId.Joy6) > Max Then
                Max = FinalScore(JoyId.Joy6)
            End If
            If FinalScore(JoyId.Joy6) < Min Then
                Min = FinalScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += FinalScore(JoyId.Joy7)
            If FinalScore(JoyId.Joy7) > Max Then
                Max = FinalScore(JoyId.Joy7)
            End If
            If FinalScore(JoyId.Joy7) < Min Then
                Min = FinalScore(JoyId.Joy7)
            End If
        End If
        ret = System.Math.Round((ret - Max - Min) / 5, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Final Score ของ 5 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFinalScoreFor_5_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += FinalScore(JoyId.Joy1)
            If FinalScore(JoyId.Joy1) > Max Then
                Max = FinalScore(JoyId.Joy1)
            End If
            If FinalScore(JoyId.Joy1) < Min Then
                Min = FinalScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += FinalScore(JoyId.Joy2)
            If FinalScore(JoyId.Joy2) > Max Then
                Max = FinalScore(JoyId.Joy2)
            End If
            If FinalScore(JoyId.Joy2) < Min Then
                Min = FinalScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += FinalScore(JoyId.Joy3)
            If FinalScore(JoyId.Joy3) > Max Then
                Max = FinalScore(JoyId.Joy3)
            End If
            If FinalScore(JoyId.Joy3) < Min Then
                Min = FinalScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += FinalScore(JoyId.Joy4)
            If FinalScore(JoyId.Joy4) > Max Then
                Max = FinalScore(JoyId.Joy4)
            End If
            If FinalScore(JoyId.Joy4) < Min Then
                Min = FinalScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += FinalScore(JoyId.Joy5)
            If FinalScore(JoyId.Joy5) > Max Then
                Max = FinalScore(JoyId.Joy5)
            End If
            If FinalScore(JoyId.Joy5) < Min Then
                Min = FinalScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += FinalScore(JoyId.Joy6)
            If FinalScore(JoyId.Joy6) > Max Then
                Max = FinalScore(JoyId.Joy6)
            End If
            If FinalScore(JoyId.Joy6) < Min Then
                Min = FinalScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += FinalScore(JoyId.Joy7)
            If FinalScore(JoyId.Joy7) > Max Then
                Max = FinalScore(JoyId.Joy7)
            End If
            If FinalScore(JoyId.Joy7) < Min Then
                Min = FinalScore(JoyId.Joy7)
            End If
        End If
        ret = System.Math.Round((ret - Max - Min) / 3, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Final Score ของ 3 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFinalScoreFor_3_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            ret += FinalScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            ret += FinalScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            ret += FinalScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            ret += FinalScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            ret += FinalScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            ret += FinalScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            ret += FinalScore(JoyId.Joy7)
        End If
        ret = System.Math.Round(ret / 3, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function


    ''' <summary>
    ''' คำนวน Final Score ของ 1 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFinalScoreFor_1_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            Return FinalScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            Return FinalScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            Return FinalScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            Return FinalScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            Return FinalScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            Return FinalScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            Return FinalScore(JoyId.Joy7)
        End If

        Return ret
    End Function
#End Region

#Region "Get Acc Score "
    ''' <summary>
    ''' คำนวน Final Score ทุกแบบ + คิดค่า K
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccScore() As Double
        Dim ret As Double = 0.0
        Dim ComCount As Integer = 0

        ComCount += ComfirmJoy1
        ComCount += ComfirmJoy2
        ComCount += ComfirmJoy3
        ComCount += ComfirmJoy4
        ComCount += ComfirmJoy5
        ComCount += ComfirmJoy6
        ComCount += ComfirmJoy7

        Select Case JudeCount
            Case 1
                If ComCount >= 1 Then
                    ret = GetAccScoreFor_1_Jude()
                Else
                    ret = -1
                End If

            Case 3
                If ComCount >= 3 Then
                    ret = GetAccScoreFor_3_Jude()
                Else
                    ret = -1
                End If

            Case 5
                If ComCount >= 5 Then
                    ret = GetAccScoreFor_5_Jude()
                Else
                    ret = -1
                End If

            Case 7
                If ComCount >= 7 Then
                    ret = GetAccScoreFor_7_Jude()
                Else
                    ret = -1
                End If

        End Select

        'If ret >= 0 AndAlso iK > 0 Then
        '    ret -= iK * 0.3
        'End If
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Acc Score ของ 1 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccScoreFor_1_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            ret += AccScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            ret += AccScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            ret += AccScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            ret += AccScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            ret += AccScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            ret += AccScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            ret += AccScore(JoyId.Joy7)
        End If
        ret = System.Math.Round(ret, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Acc Score ของ 3 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccScoreFor_3_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            ret += AccScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            ret += AccScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            ret += AccScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            ret += AccScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            ret += AccScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            ret += AccScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            ret += AccScore(JoyId.Joy7)
        End If
        ret = System.Math.Round((ret / 3) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Acc Score ของ 5 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccScoreFor_5_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += AccScore(JoyId.Joy1)
            If AccScore(JoyId.Joy1) > Max Then
                Max = AccScore(JoyId.Joy1)
            End If
            If AccScore(JoyId.Joy1) < Min Then
                Min = AccScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += AccScore(JoyId.Joy2)
            If AccScore(JoyId.Joy2) > Max Then
                Max = AccScore(JoyId.Joy2)
            End If
            If AccScore(JoyId.Joy2) < Min Then
                Min = AccScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += AccScore(JoyId.Joy3)
            If AccScore(JoyId.Joy3) > Max Then
                Max = AccScore(JoyId.Joy3)
            End If
            If AccScore(JoyId.Joy3) < Min Then
                Min = AccScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += AccScore(JoyId.Joy4)
            If AccScore(JoyId.Joy4) > Max Then
                Max = AccScore(JoyId.Joy4)
            End If
            If AccScore(JoyId.Joy4) < Min Then
                Min = AccScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += AccScore(JoyId.Joy5)
            If AccScore(JoyId.Joy5) > Max Then
                Max = AccScore(JoyId.Joy5)
            End If
            If AccScore(JoyId.Joy5) < Min Then
                Min = AccScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += AccScore(JoyId.Joy6)
            If AccScore(JoyId.Joy6) > Max Then
                Max = AccScore(JoyId.Joy6)
            End If
            If AccScore(JoyId.Joy6) < Min Then
                Min = AccScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += AccScore(JoyId.Joy7)
            If AccScore(JoyId.Joy7) > Max Then
                Max = AccScore(JoyId.Joy7)
            End If
            If AccScore(JoyId.Joy7) < Min Then
                Min = AccScore(JoyId.Joy7)
            End If
        End If

        ret = System.Math.Round(((ret - Max - Min) / 3) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Acc Score ของ 7 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccScoreFor_7_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += AccScore(JoyId.Joy1)
            If AccScore(JoyId.Joy1) > Max Then
                Max = AccScore(JoyId.Joy1)
            End If
            If AccScore(JoyId.Joy1) < Min Then
                Min = AccScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += AccScore(JoyId.Joy2)
            If AccScore(JoyId.Joy2) > Max Then
                Max = AccScore(JoyId.Joy2)
            End If
            If AccScore(JoyId.Joy2) < Min Then
                Min = AccScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += AccScore(JoyId.Joy3)
            If AccScore(JoyId.Joy3) > Max Then
                Max = AccScore(JoyId.Joy3)
            End If
            If AccScore(JoyId.Joy3) < Min Then
                Min = AccScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += AccScore(JoyId.Joy4)
            If AccScore(JoyId.Joy4) > Max Then
                Max = AccScore(JoyId.Joy4)
            End If
            If AccScore(JoyId.Joy4) < Min Then
                Min = AccScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += AccScore(JoyId.Joy5)
            If AccScore(JoyId.Joy5) > Max Then
                Max = AccScore(JoyId.Joy5)
            End If
            If AccScore(JoyId.Joy5) < Min Then
                Min = AccScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += AccScore(JoyId.Joy6)
            If AccScore(JoyId.Joy6) > Max Then
                Max = AccScore(JoyId.Joy6)
            End If
            If AccScore(JoyId.Joy6) < Min Then
                Min = AccScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += AccScore(JoyId.Joy7)
            If AccScore(JoyId.Joy7) > Max Then
                Max = AccScore(JoyId.Joy7)
            End If
            If AccScore(JoyId.Joy7) < Min Then
                Min = AccScore(JoyId.Joy7)
            End If
        End If
        ret = System.Math.Round(((ret - Max - Min) / 5) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function
#End Region

#Region "Get PRE Score "
    ''' <summary>
    ''' คำนวน Final Score ทุกแบบ + คิดค่า K
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreScore() As Double
        Dim ret As Double = 0.0
        Dim ComCount As Integer = 0

        ComCount += ComfirmJoy1
        ComCount += ComfirmJoy2
        ComCount += ComfirmJoy3
        ComCount += ComfirmJoy4
        ComCount += ComfirmJoy5
        ComCount += ComfirmJoy6
        ComCount += ComfirmJoy7

        Select Case JudeCount
            Case 1
                If ComCount >= 1 Then
                    ret = GetPreScoreFor_1_Jude()
                Else
                    ret = -1
                End If

            Case 3
                If ComCount >= 3 Then
                    ret = GetPreScoreFor_3_Jude()
                Else
                    ret = -1
                End If

            Case 5
                If ComCount >= 5 Then
                    ret = GetPreScoreFor_5_Jude()
                Else
                    ret = -1
                End If

            Case 7
                If ComCount >= 7 Then
                    ret = GetPreScoreFor_7_Jude()
                Else
                    ret = -1
                End If

        End Select

        'If ret >= 0 AndAlso iK > 0 Then
        '    ret -= iK * 0.3
        'End If
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Pre Score ของ 1 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreScoreFor_1_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            ret += PreScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            ret += PreScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            ret += PreScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            ret += PreScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            ret += PreScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            ret += PreScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            ret += PreScore(JoyId.Joy7)
        End If
        ret = System.Math.Round(ret, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Pre Score ของ 3 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreScoreFor_3_Jude() As Double
        Dim ret As Double = 0.0
        If ComfirmJoy1 = 1 Then
            ret += PreScore(JoyId.Joy1)
        End If
        If ComfirmJoy2 = 1 Then
            ret += PreScore(JoyId.Joy2)
        End If
        If ComfirmJoy3 = 1 Then
            ret += PreScore(JoyId.Joy3)
        End If
        If ComfirmJoy4 = 1 Then
            ret += PreScore(JoyId.Joy4)
        End If
        If ComfirmJoy5 = 1 Then
            ret += PreScore(JoyId.Joy5)
        End If
        If ComfirmJoy6 = 1 Then
            ret += PreScore(JoyId.Joy6)
        End If
        If ComfirmJoy7 = 1 Then
            ret += PreScore(JoyId.Joy7)
        End If
        ret = System.Math.Round((ret / 3) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Pre Score ของ 5 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreScoreFor_5_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += PreScore(JoyId.Joy1)
            If PreScore(JoyId.Joy1) > Max Then
                Max = PreScore(JoyId.Joy1)
            End If
            If PreScore(JoyId.Joy1) < Min Then
                Min = PreScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += PreScore(JoyId.Joy2)
            If PreScore(JoyId.Joy2) > Max Then
                Max = PreScore(JoyId.Joy2)
            End If
            If PreScore(JoyId.Joy2) < Min Then
                Min = PreScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += PreScore(JoyId.Joy3)
            If PreScore(JoyId.Joy3) > Max Then
                Max = PreScore(JoyId.Joy3)
            End If
            If PreScore(JoyId.Joy3) < Min Then
                Min = PreScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += PreScore(JoyId.Joy4)
            If PreScore(JoyId.Joy4) > Max Then
                Max = PreScore(JoyId.Joy4)
            End If
            If PreScore(JoyId.Joy4) < Min Then
                Min = PreScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += PreScore(JoyId.Joy5)
            If PreScore(JoyId.Joy5) > Max Then
                Max = PreScore(JoyId.Joy5)
            End If
            If PreScore(JoyId.Joy5) < Min Then
                Min = PreScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += PreScore(JoyId.Joy6)
            If PreScore(JoyId.Joy6) > Max Then
                Max = PreScore(JoyId.Joy6)
            End If
            If PreScore(JoyId.Joy6) < Min Then
                Min = PreScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += PreScore(JoyId.Joy7)
            If PreScore(JoyId.Joy7) > Max Then
                Max = PreScore(JoyId.Joy7)
            End If
            If PreScore(JoyId.Joy7) < Min Then
                Min = PreScore(JoyId.Joy7)
            End If
        End If
        ret = System.Math.Round(((ret - Max - Min) / 3) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function

    ''' <summary>
    ''' คำนวน Pre Score ของ 7 Joy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreScoreFor_7_Jude() As Double
        Dim ret As Double = 0.0
        Dim Max As Double = 0.0
        Dim Min As Double = 500.0

        If ComfirmJoy1 = 1 Then
            ret += PreScore(JoyId.Joy1)
            If PreScore(JoyId.Joy1) > Max Then
                Max = PreScore(JoyId.Joy1)
            End If
            If PreScore(JoyId.Joy1) < Min Then
                Min = PreScore(JoyId.Joy1)
            End If
        End If
        If ComfirmJoy2 = 1 Then
            ret += PreScore(JoyId.Joy2)
            If PreScore(JoyId.Joy2) > Max Then
                Max = PreScore(JoyId.Joy2)
            End If
            If PreScore(JoyId.Joy2) < Min Then
                Min = PreScore(JoyId.Joy2)
            End If
        End If
        If ComfirmJoy3 = 1 Then
            ret += PreScore(JoyId.Joy3)
            If PreScore(JoyId.Joy3) > Max Then
                Max = PreScore(JoyId.Joy3)
            End If
            If PreScore(JoyId.Joy3) < Min Then
                Min = PreScore(JoyId.Joy3)
            End If
        End If
        If ComfirmJoy4 = 1 Then
            ret += PreScore(JoyId.Joy4)
            If PreScore(JoyId.Joy4) > Max Then
                Max = PreScore(JoyId.Joy4)
            End If
            If PreScore(JoyId.Joy4) < Min Then
                Min = PreScore(JoyId.Joy4)
            End If
        End If
        If ComfirmJoy5 = 1 Then
            ret += PreScore(JoyId.Joy5)
            If PreScore(JoyId.Joy5) > Max Then
                Max = PreScore(JoyId.Joy5)
            End If
            If PreScore(JoyId.Joy5) < Min Then
                Min = PreScore(JoyId.Joy5)
            End If
        End If
        If ComfirmJoy6 = 1 Then
            ret += PreScore(JoyId.Joy6)
            If PreScore(JoyId.Joy6) > Max Then
                Max = PreScore(JoyId.Joy6)
            End If
            If PreScore(JoyId.Joy6) < Min Then
                Min = PreScore(JoyId.Joy6)
            End If
        End If
        If ComfirmJoy7 = 1 Then
            ret += PreScore(JoyId.Joy7)
            If PreScore(JoyId.Joy7) > Max Then
                Max = PreScore(JoyId.Joy7)
            End If
            If PreScore(JoyId.Joy7) < Min Then
                Min = PreScore(JoyId.Joy7)
            End If
        End If
        ret = System.Math.Round(((ret - Max - Min) / 5) - 0.005, 2, MidpointRounding.AwayFromZero)
        Return ret
    End Function
#End Region

#Region "Clear Round 2"
    Public Sub ClearRound2()
        GameStatus = GameStatusType.EndRound
        RoundRun = 1
        With frmCtl
            .lblPreRound2.Text = ""
            .lblAccRound2.Text = ""
            .lblTotalRound2.Text = ""

            .lblPreSummary.Text = ""
            .lblAccSummary.Text = ""
            .lblTotalSummary.Text = ""
            .txtRound2.Text = ""
            .txtRound2_1.Text = ""

            .lblTotalAcc.Text = ""
            .lblTotalPre.Text = ""
            .lblFinalScore.Text = ""
        End With

        With frmShow
            .lblPreRound2.Text = ""
            .lblAccRound2.Text = ""
            .lblTotalRound2.Text = ""

            .lblPreSummary.Text = ""
            .lblAccSummary.Text = ""
            .lblTotalSummary.Text = ""

            '.lblTotalAcc.Text = ""
            '.lblTotalPre.Text = ""
            .lblFinalScore.Text = ""
        End With
       
    End Sub
#End Region

#Region "Clear Round 1"
    Public Sub ClearRound1()
        GameStatus = GameStatusType.None
        RoundRun = 1
        K = 0
        ClearComfiremJoyAll()
        With frmCtl
            .lblPreRound1.Text = ""
            .lblAccRound1.Text = ""
            .lblTotalRound1.Text = ""

            .lblPreRound2.Text = ""
            .lblAccRound2.Text = ""
            .lblTotalRound2.Text = ""

            .lblPreSummary.Text = ""
            .lblAccSummary.Text = ""
            .lblTotalSummary.Text = ""

            .txtRound1.Text = ""
            .txtRound2.Text = ""

            .txtRound1_1.Text = ""
            .txtRound2_1.Text = ""

            .lblTotalAcc.Text = ""
            .lblTotalPre.Text = ""
            .lblFinalScore.Text = ""
        End With

        With frmShow
            .lblPreRound1.Text = ""
            .lblAccRound1.Text = ""
            .lblTotalRound1.Text = ""

            .lblPreRound2.Text = ""
            .lblAccRound2.Text = ""
            .lblTotalRound2.Text = ""

            .lblPreSummary.Text = ""
            .lblAccSummary.Text = ""
            .lblTotalSummary.Text = ""

            '.lblTotalAcc.Text = ""
            '.lblTotalPre.Text = ""
            .lblFinalScore.Text = ""
        End With

    End Sub
#End Region

    Public Sub setImage(ByVal sFileName)
        frmCtl.picImage.ImageLocation = sFileName
        frmCtl.picImage.Refresh()

        frmShow.picImage.ImageLocation = sFileName
        frmShow.picImage.Refresh()
    End Sub

    Public Sub setKoryoType(ByVal pText)
        frmShow.lblKoryoType.Text = pText
    End Sub

    Public Sub setRound1()

        frmShow.lblFinalScore.Text = frmCtl.lblFinalScore.Text

        'frmShow.lblTotalAcc.Text = frmCtl.lblTotalAcc.Text
        'frmShow.lblTotalPre.Text = frmCtl.lblTotalPre.Text
        frmShow.lblAccRound1.Text = frmCtl.lblAccRound1.Text.Replace("Acc:", "")
        frmShow.lblPreRound1.Text = frmCtl.lblPreRound1.Text.Replace("Pre:", "")
        frmShow.lblTotalRound1.Text = frmCtl.lblTotalRound1.Text.Replace("Total:", "")

        setValueToAllJudge()
    End Sub

    Public Sub setRound2()

        setRound1()

        frmShow.lblAccRound2.Text = frmCtl.lblAccRound2.Text.Replace("Acc:", "")
        frmShow.lblPreRound2.Text = frmCtl.lblPreRound2.Text.Replace("Pre:", "")
        frmShow.lblTotalRound2.Text = frmCtl.lblTotalRound2.Text.Replace("Total:", "")
       
    End Sub

    Public Sub setTotalRound()
        setRound2()
        frmShow.lblAccSummary.Text = frmCtl.lblAccSummary.Text.Replace("Acc:", "")
        frmShow.lblPreSummary.Text = frmCtl.lblPreSummary.Text.Replace("Pre:", "")
        frmShow.lblTotalSummary.Text = frmCtl.lblTotalSummary.Text.Replace("Total:", "")
        frmShow.lblFinalScore.Text = frmCtl.lblTotalSummary.Text.Replace("Total:", "")
    End Sub

    Private Sub setValueToAllJudge()
        If frmCtl.lblJude1.Checked Then
            frmShow.lbl_1_Acc.Text = frmCtl.lbl_1_Acc.Text
            frmShow.lbl_1_Pre.Text = frmCtl.lbl_1_Pre.Text
            'frmShow.lbl_1_Final.Text = frmCtl.lbl_1_Final.Text
        Else
            frmShow.lbl_1_Acc.Text = ""
            frmShow.lbl_1_Pre.Text = ""
            'frmShow.lbl_1_Final.Text = ""
        End If

        If frmCtl.lblJude2.Checked Then
            frmShow.lbl_2_Acc.Text = frmCtl.lbl_2_Acc.Text
            frmShow.lbl_2_Pre.Text = frmCtl.lbl_2_Pre.Text
            'frmShow.lbl_2_Final.Text = frmCtl.lbl_2_Final.Text
        Else
            frmShow.lbl_2_Acc.Text = ""
            frmShow.lbl_2_Pre.Text = ""
            'frmShow.lbl_2_Final.Text = ""
        End If

        If frmCtl.lblJude3.Checked Then
            frmShow.lbl_3_Acc.Text = frmCtl.lbl_3_Acc.Text
            frmShow.lbl_3_Pre.Text = frmCtl.lbl_3_Pre.Text
            'frmShow.lbl_3_Final.Text = frmCtl.lbl_3_Final.Text
        Else
            frmShow.lbl_3_Acc.Text = ""
            frmShow.lbl_3_Pre.Text = ""
            'frmShow.lbl_3_Final.Text = ""
        End If

        If frmCtl.lblJude4.Checked Then
            frmShow.lbl_4_Acc.Text = frmCtl.lbl_4_Acc.Text
            frmShow.lbl_4_Pre.Text = frmCtl.lbl_4_Pre.Text
            'frmShow.lbl_4_Final.Text = frmCtl.lbl_4_Final.Text
        Else
            frmShow.lbl_4_Acc.Text = ""
            frmShow.lbl_4_Pre.Text = ""
            'frmShow.lbl_4_Final.Text = ""
        End If

        If frmCtl.lblJude5.Checked Then
            frmShow.lbl_5_Acc.Text = frmCtl.lbl_5_Acc.Text
            frmShow.lbl_5_Pre.Text = frmCtl.lbl_5_Pre.Text
            'frmShow.lbl_5_Final.Text = frmCtl.lbl_5_Final.Text
        Else
            frmShow.lbl_5_Acc.Text = ""
            frmShow.lbl_5_Pre.Text = ""
            'frmShow.lbl_5_Final.Text = ""
        End If

        'If frmCtl.lblJude6.Checked Then
        '    frmShow.lbl_6_Acc.Text = frmCtl.lbl_6_Acc.Text
        '    frmShow.lbl_6_Pre.Text = frmCtl.lbl_6_Pre.Text
        '    frmShow.lbl_6_Final.Text = frmCtl.lbl_6_Final.Text
        'Else
        '    frmShow.lbl_6_Acc.Text = ""
        '    frmShow.lbl_6_Pre.Text = ""
        '    frmShow.lbl_6_Final.Text = ""
        'End If

        'If frmCtl.lblJude7.Checked Then
        '    frmShow.lbl_7_Acc.Text = frmCtl.lbl_7_Acc.Text
        '    frmShow.lbl_7_Pre.Text = frmCtl.lbl_7_Pre.Text
        '    frmShow.lbl_7_Final.Text = frmCtl.lbl_7_Final.Text
        'Else
        '    frmShow.lbl_7_Acc.Text = ""
        '    frmShow.lbl_7_Pre.Text = ""
        '    frmShow.lbl_7_Final.Text = ""
        'End If
    End Sub

    Public Sub setFinalTotal(ByVal pValue As Double)
        frmCtl.lblFinalScore.Text = Format(pValue, "0.00")
        frmShow.lblFinalScore.Text = Format(pValue, "0.00")
    End Sub
End Class
