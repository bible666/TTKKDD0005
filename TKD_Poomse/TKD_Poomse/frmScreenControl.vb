Imports TKD_Poomse.EnumData
Imports System.IO
Imports System.Diagnostics

Public Class frmScreenControl
    Public Enum CountStatus
        MaxToMin = 1
        MinToMax = 2
    End Enum
    Public ctl As clsCForm

    Private RunTime As DateTime
    Private m_WatchDirectory As String = ""
    Private m_FileSystemWatcher As FileSystemWatcher
    Private sFileSerial As String = ""
   
#Region " Control Joy 1 "
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy1)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude1.Checked AndAlso lblJude1.Enabled = True Then
                ctl.Joy1Input()
            ElseIf lblJude1.Checked AndAlso lblJude1.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy1)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy1)
                            ctl.UnComfirmJoy(JoyId.Joy1)
                    End Select
                Next
            End If
        End If


    End Sub
#End Region

#Region " Control Joy 2 "
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy2)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude2.Checked AndAlso lblJude2.Enabled = True Then
                ctl.Joy2Input()
            ElseIf lblJude2.Checked AndAlso lblJude2.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy2)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy2)
                            ctl.UnComfirmJoy(JoyId.Joy2)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Control Joy 3 "
    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy3)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude3.Checked AndAlso lblJude3.Enabled = True Then
                ctl.Joy3Input()
            ElseIf lblJude3.Checked AndAlso lblJude3.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy3)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy3)
                            ctl.UnComfirmJoy(JoyId.Joy3)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Control Joy 4 "
    Private Sub Timer4_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy4)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude4.Checked AndAlso lblJude4.Enabled = True Then
                ctl.Joy4Input()
            ElseIf lblJude4.Checked AndAlso lblJude4.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy4)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy4)
                            ctl.UnComfirmJoy(JoyId.Joy4)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Control Joy 5 "
    Private Sub Timer5_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy5)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude5.Checked AndAlso lblJude5.Enabled = True Then
                ctl.Joy5Input()
            ElseIf lblJude5.Checked AndAlso lblJude5.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy5)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy5)
                            ctl.UnComfirmJoy(JoyId.Joy5)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Control Joy 6 "
    Private Sub Timer6_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy6)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then
            If Not lblJude6.Checked AndAlso lblJude6.Enabled = True Then
                ctl.Joy6Input()
            ElseIf lblJude6.Checked AndAlso lblJude6.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy6)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy6)
                            ctl.UnComfirmJoy(JoyId.Joy6)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Control Joy 7 "
    Private Sub Timer7_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        Dim input As List(Of JoyInputType)
        Dim str As String = ""
        input = ctl.joyCtl.GetInput(JoyId.Joy7)
        If IsNothing(input) Then
            Exit Sub
        End If
        If input.Count > 0 Then

            If Not lblJude7.Checked AndAlso lblJude7.Enabled = True Then
                ctl.Joy7Input()
            ElseIf lblJude7.Checked AndAlso lblJude7.Enabled = False Then
                For Each c As JoyInputType In input
                    Select Case c
                        Case JoyInputType.วงกลม
                            ctl.ComfirmJoy(JoyId.Joy7)
                            ctl.UpdateFinalScore()
                        Case JoyInputType.L1
                            ctl.AccCutScore_3(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                        Case JoyInputType.Up
                            ctl.AccCutScore_1(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                        Case JoyInputType.L2
                            ctl.AccClear(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                        Case JoyInputType.R1
                            ctl.PreCutScore_3(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                        Case JoyInputType.สามเหลี่ยม
                            ctl.PreCutScore_1(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                        Case JoyInputType.R2
                            ctl.PreClear(JoyId.Joy7)
                            ctl.UnComfirmJoy(JoyId.Joy7)
                    End Select
                Next
            End If
        End If
    End Sub
#End Region

#Region " Exit Program "
    Private Sub frmScreenControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("คุณต้องการออกจาก โปรแกรม", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub
#End Region

    Private Sub CheckBoxAllEnable()
        lblJude1.Enabled = True
        lblJude2.Enabled = True
        lblJude3.Enabled = True
        lblJude4.Enabled = True
        lblJude5.Enabled = True
        lblJude6.Enabled = True
        lblJude7.Enabled = True
    End Sub

    Private Sub CheckBoxAllDisable()
        lblJude1.Enabled = False
        lblJude2.Enabled = False
        lblJude3.Enabled = False
        lblJude4.Enabled = False
        lblJude5.Enabled = False
        lblJude6.Enabled = False
        lblJude7.Enabled = False
    End Sub

    Private Function GetCheckdCount() As Integer
        Dim ret As Integer = 0
        If lblJude1.Checked Then
            ret += 1
        End If
        If lblJude2.Checked Then
            ret += 1
        End If
        If lblJude3.Checked Then
            ret += 1
        End If
        If lblJude4.Checked Then
            ret += 1
        End If
        If lblJude5.Checked Then
            ret += 1
        End If
        If lblJude6.Checked Then
            ret += 1
        End If
        If lblJude7.Checked Then
            ret += 1
        End If

        Return ret
    End Function

    Private Sub ResetTime()
        RunTime = New DateTime(2013, 1, 1, 0, 0, 0)
        If ctl.TimeType = CountStatus.MaxToMin Then
            RunTime = RunTime.AddSeconds(ctl.NowTime)
        End If

        ctl.ShowTime(RunTime)
    End Sub
    Private Sub StartGame()
        'Check Jude
        If ctl.JudeCount = GetCheckdCount() Then
            ResetTime()
            ctl.GameStatus = GameStatusType.Start
            CheckBoxAllDisable()
            tmTime.Start()
        Else
            MessageBox.Show("กรุณาระบุจำนวน Jude ให้ครบ [" & ctl.JudeCount & "]")
        End If
    End Sub
    Private Sub CheckKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            ChangePoomsaeStatus()
        End If
    End Sub

    Private Sub ChangePoomsaeStatus()
        Select Case ctl.GameStatus
            Case GameStatusType.None
                'None --> Start
                ctl.RoundRun = 1
                StartGame()

            Case GameStatusType.Start
                'Start --> Break
                ctl.GameStatus = GameStatusType.Break
                tmTime.Stop()
            Case GameStatusType.EndRound
                ctl.RoundRun += 1
                ctl.ResetFinalScore()
                ctl.ResetScoreAll()
                ctl.K = 0
                ctl.K2 = 0
                StartGame()
            Case GameStatusType.Break
                'Break --> Start
                ctl.GameStatus = GameStatusType.Start
                tmTime.Start()
        End Select
    End Sub

    Private Sub lblJude1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblJude1.GotFocus, lblJude2.GotFocus, _
                   lblJude3.GotFocus, lblJude4.GotFocus, lblJude5.GotFocus, lblJude6.GotFocus, lblJude7.GotFocus
        Me.Focus()
    End Sub


    Private Sub frmScreenControl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, lblJude1.KeyDown, _
                                 lblJude2.KeyDown, lblJude3.KeyDown, lblJude4.KeyDown, lblJude5.KeyDown, lblJude6.KeyDown, lblJude7.KeyDown, txtRound1.KeyDown, _
                                txtRound1_1.KeyDown, txtRound2.KeyDown, txtRound2_1.KeyDown, txtRoundCount.KeyDown, txtTotal.KeyDown, txtTotal_1.KeyDown, txtTotal2.KeyDown, _
                                Button1.KeyDown, Button2.KeyDown, Button3.KeyDown, Button4.KeyDown, Button5.KeyDown, Button6.KeyDown, btnPic.KeyDown
        Dim name As String = sender.name

        CheckKeyDown(e)
        If name.Length > 3 AndAlso name.Substring(0, 3).ToLower = "lbl" Then
            Dim b As Boolean = sender.checked

            If e.KeyCode = Keys.Space Then
                e.Handled = True
            End If
        Else
            'Dim Alt As String = ""
            'If e.Alt Then
            '    Alt = " ALT "
            'End If
            'MessageBox.Show(Alt & " " & e.KeyCode)
            'If RunTime.Minute = 0 And RunTime.Second = 0 Then
            If e.KeyCode = EnumData.KeyBoardInput.F1 Then
                ctl.K += 1
            End If

            If e.KeyCode = EnumData.KeyBoardInput.F2 Then
                ctl.K2 += 1
            End If

            If e.KeyCode = EnumData.KeyBoardInput.F3 Then
                ctl.K = 0
            End If

            If e.KeyCode = EnumData.KeyBoardInput.F4 Then
                ctl.K2 = 0
            End If
            'End If



            CheckKeyInput_Joy1(e)
            CheckKeyInput_Joy2(e)
            CheckKeyInput_Joy3(e)
            CheckKeyInput_Joy4(e)
            CheckKeyInput_Joy5(e)
            CheckKeyInput_Joy6(e)
            CheckKeyInput_Joy7(e)
        End If
    End Sub

    Private Sub CheckKeyInput_Joy1(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude1.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy1_AccCut.ToUpper
                        ctl.AccCutScore_1(JoyId.Joy1)
                    Case clsSys.Joy1_AccClear.ToUpper ' EnumData.KeyBoardInput.q
                        ctl.AccClear(JoyId.Joy1)
                    Case clsSys.Joy1_PreCut.ToUpper ' EnumData.KeyBoardInput.a
                        ctl.PreCutScore_1(JoyId.Joy1)
                    Case clsSys.Joy1_PreClear.ToUpper ' EnumData.KeyBoardInput.z
                        ctl.PreClear(JoyId.Joy1)

                End Select

            End If
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy1_AccCut.ToUpper
                        ctl.AccCutScore_3(JoyId.Joy1)
                    Case clsSys.Joy1_PreCut.ToUpper ' EnumData.KeyBoardInput.a
                        ctl.PreCutScore_3(JoyId.Joy1)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy1_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy1)
            End If

        End If
    End Sub
    Private Sub CheckKeyInput_Joy2(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude2.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy2_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy2)
                    Case clsSys.Joy2_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy2)
                    Case clsSys.Joy2_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy2)
                    Case clsSys.Joy2_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy2)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy2_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy2)
                    Case clsSys.Joy2_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy2)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy2_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy2)
            End If
        End If
    End Sub

    Private Sub CheckKeyInput_Joy3(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude3.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy3_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy3)
                    Case clsSys.Joy3_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy3)
                    Case clsSys.Joy3_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy3)
                    Case clsSys.Joy2_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy3)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy3_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy3)
                    Case clsSys.Joy3_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy3)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy3_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy3)
            End If
        End If
    End Sub

    Private Sub CheckKeyInput_Joy4(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude4.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy4_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy4)
                    Case clsSys.Joy4_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy4)
                    Case clsSys.Joy4_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy4)
                    Case clsSys.Joy4_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy4)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy4_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy4)
                    Case clsSys.Joy4_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy4)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy4_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy4)
            End If
        End If
    End Sub

    Private Sub CheckKeyInput_Joy5(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude5.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy5_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy5)
                    Case clsSys.Joy5_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy5)
                    Case clsSys.Joy5_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy5)
                    Case clsSys.Joy5_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy5)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy5_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy5)
                    Case clsSys.Joy5_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy5)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy5_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy5)
            End If
        End If
    End Sub

    Private Sub CheckKeyInput_Joy6(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude6.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy6_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy6)
                    Case clsSys.Joy6_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy6)
                    Case clsSys.Joy6_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy6)
                    Case clsSys.Joy6_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy6)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy6_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy6)
                    Case clsSys.Joy6_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy6)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy6_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy6)
            End If
        End If
    End Sub

    Private Sub CheckKeyInput_Joy7(ByVal e As System.Windows.Forms.KeyEventArgs)
        If lblJude7.Checked Then
            If ctl.GameStatus = GameStatusType.Start AndAlso e.Alt = False AndAlso e.Control = False Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy7_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_1(JoyId.Joy7)
                    Case clsSys.Joy7_AccClear.ToUpper ' EnumData.KeyBoardInput.w
                        ctl.AccClear(JoyId.Joy7)
                    Case clsSys.Joy7_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_1(JoyId.Joy7)
                    Case clsSys.Joy7_PreClear.ToUpper ' EnumData.KeyBoardInput.x
                        ctl.PreClear(JoyId.Joy7)
                End Select
            End If

            If ctl.GameStatus = GameStatusType.Start AndAlso e.Control = True Then
                Select Case e.KeyCode.ToString
                    Case clsSys.Joy7_AccCut.ToUpper ' EnumData.KeyBoardInput.N_2
                        ctl.AccCutScore_3(JoyId.Joy7)
                    Case clsSys.Joy7_PreCut.ToUpper ' EnumData.KeyBoardInput.s
                        ctl.PreCutScore_3(JoyId.Joy7)
                End Select
            End If

            If e.KeyCode.ToString = clsSys.Joy7_OK.ToUpper And e.Alt Then
                ctl.ComfirmJoy(JoyId.Joy7)
            End If
        End If
    End Sub



    Private Sub frmScreenControl_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer4.Start()
        Timer5.Start()
        Timer6.Start()
        Timer7.Start()

        ctl.GameStatus = GameStatusType.None
        'Clear Time
        ResetTime()
        'Clear Score
        ctl.ResetScoreAll()
        ctl.ResetFinalScore()
        'ClearConfirm Score
        ctl.ClearComfiremJoyAll()

        'Clear Check Disable
        CheckBoxAllEnable()

        'Clear Athlete
        ctl.Athlete = ""
        'Update Header
        ctl.UpdateType("ผสม", "รุ่นอาย ", "ชาย", "สาย ดำ")
        'Clear Score
        ctl.ResetScoreAll()

        'Clear Round to 1
        ctl.RoundRun = 1
        ctl.K = 0
        ctl.K2 = 0

        If System.IO.Directory.Exists(clsSys.WebFilePath) Then
            m_FileSystemWatcher = New FileSystemWatcher
            With m_FileSystemWatcher
                .Path = clsSys.WebFilePath
                .NotifyFilter = NotifyFilters.DirectoryName
                .NotifyFilter = .NotifyFilter Or _
                                IO.NotifyFilters.FileName
                .NotifyFilter = .NotifyFilter Or _
                                           IO.NotifyFilters.Attributes
            End With
            AddHandler m_FileSystemWatcher.Created, AddressOf logchange
            AddHandler m_FileSystemWatcher.Changed, AddressOf logchange

            'Set this property to true to start watching
            m_FileSystemWatcher.EnableRaisingEvents = True
        Else
            MessageBox.Show("ใส่ ชือ Folder ผิดพลาดใน config file")

        End If
        ComboBox1.SelectedIndex = 10
        txtRound1.Focus()
    End Sub

    Private Sub logchange(ByVal source As Object, ByVal e As  _
                        System.IO.FileSystemEventArgs)
        If e.ChangeType = IO.WatcherChangeTypes.Created Then
            ProcessFile(e.FullPath)
        End If
        If e.ChangeType = IO.WatcherChangeTypes.Deleted Then
            'txt_folderactivity.Text &= "File " & e.FullPath & _
            '                        " has been deleted" & vbCrLf
        End If
    End Sub

    Private Function CheckFileUse(ByVal FileName As String) As Boolean
        Try
            Dim Fs As New System.IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Dim Sr As New System.IO.StreamReader(Fs)
            Sr.Close()
            Fs.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Process a file.
    Private Sub ProcessFile(ByVal file_name As String)
        Dim str() As String = file_name.Split("\")
        Dim sFile As String = str(str.Length - 1)

        'ตัวอย่าง Message [ 0:1:สนาม A 001 ] [ 1:0:0 ]
        While Not CheckFileUse(file_name)
            System.Threading.Thread.Sleep(10)
        End While

        'System.Threading.Thread.Sleep(500)

        Dim Fs As New System.IO.FileStream(file_name, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        Dim Sr As New System.IO.StreamReader(Fs)
        Dim sLine As String = ""

        Try
            Do
                sLine = Sr.ReadLine
                Dim sLineA() As String = sLine.Split(vbTab)
                If sLineA.Length >= 3 Then
                    Dim Acc As Double = sLineA(1)
                    Dim Pre As Double = sLineA(2)
                    Acc = Math.Round(Acc, 2)
                    Pre = Math.Round(Pre, 2)
                    Select Case sLineA(0)
                        Case 1
                            If ctl.ComfirmJoy1 = 0 Then
                                ctl.AccSet(JoyId.Joy1, Acc)
                                ctl.PreSet(JoyId.Joy1, Pre)
                            End If
                        Case 2
                            If ctl.ComfirmJoy2 = 0 Then
                                ctl.AccSet(JoyId.Joy2, Acc)
                                ctl.PreSet(JoyId.Joy2, Pre)
                            End If

                        Case 3
                            If ctl.ComfirmJoy3 = 0 Then
                                ctl.AccSet(JoyId.Joy3, Acc)
                                ctl.PreSet(JoyId.Joy3, Pre)
                            End If

                        Case 4
                            If ctl.ComfirmJoy4 = 0 Then
                                ctl.AccSet(JoyId.Joy4, Acc)
                                ctl.PreSet(JoyId.Joy4, Pre)
                            End If

                        Case 5
                            If ctl.ComfirmJoy5 = 0 Then
                                ctl.AccSet(JoyId.Joy5, Acc)
                                ctl.PreSet(JoyId.Joy5, Pre)
                            End If

                        Case 6
                            If ctl.ComfirmJoy6 = 0 Then
                                ctl.AccSet(JoyId.Joy6, Acc)
                                ctl.PreSet(JoyId.Joy6, Pre)
                            End If

                        Case 7
                            If ctl.ComfirmJoy7 = 0 Then
                                ctl.AccSet(JoyId.Joy7, Acc)
                                ctl.PreSet(JoyId.Joy7, Pre)
                            End If

                        Case "1C"
                            If ctl.ComfirmJoy1 = 0 Then
                                ctl.AccSet(JoyId.Joy1, Acc)
                                ctl.PreSet(JoyId.Joy1, Pre)
                                ctl.ComfirmJoy(JoyId.Joy1)
                            End If

                        Case "2C"
                            If ctl.ComfirmJoy2 = 0 Then
                                ctl.AccSet(JoyId.Joy2, Acc)
                                ctl.PreSet(JoyId.Joy2, Pre)
                                ctl.ComfirmJoy(JoyId.Joy2)
                            End If

                        Case "3C"
                            If ctl.ComfirmJoy3 = 0 Then
                                ctl.AccSet(JoyId.Joy3, Acc)
                                ctl.PreSet(JoyId.Joy3, Pre)
                                ctl.ComfirmJoy(JoyId.Joy3)
                            End If

                        Case "4C"
                            If ctl.ComfirmJoy4 = 0 Then
                                ctl.AccSet(JoyId.Joy4, Acc)
                                ctl.PreSet(JoyId.Joy4, Pre)
                                ctl.ComfirmJoy(JoyId.Joy4)
                            End If

                        Case "5C"
                            If ctl.ComfirmJoy5 = 0 Then
                                ctl.AccSet(JoyId.Joy5, Acc)
                                ctl.PreSet(JoyId.Joy5, Pre)
                                ctl.ComfirmJoy(JoyId.Joy5)
                            End If

                        Case "6C"
                            If ctl.ComfirmJoy6 = 0 Then
                                ctl.AccSet(JoyId.Joy6, Acc)
                                ctl.PreSet(JoyId.Joy6, Pre)
                                ctl.ComfirmJoy(JoyId.Joy6)
                            End If

                        Case "7C"
                            If ctl.ComfirmJoy7 = 0 Then
                                ctl.AccSet(JoyId.Joy7, Acc)
                                ctl.PreSet(JoyId.Joy7, Pre)
                                ctl.ComfirmJoy(JoyId.Joy7)
                            End If

                    End Select
                End If

            Loop Until Sr.Peek = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Sr.Close()
            Fs.Close()
        End Try
        Debug.WriteLine(file_name)
        While Not CheckFileUse(file_name)
            System.Threading.Thread.Sleep(10)
        End While
        IO.File.Delete(file_name)
    End Sub

    Private Sub RefressScoreAllJoy()
        ctl.RefressScore(JoyId.Joy1)
        ctl.RefressScore(JoyId.Joy2)
        ctl.RefressScore(JoyId.Joy3)
        ctl.RefressScore(JoyId.Joy4)
        ctl.RefressScore(JoyId.Joy5)
        ctl.RefressScore(JoyId.Joy6)
        ctl.RefressScore(JoyId.Joy7)
    End Sub

    Private Sub tmTime_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmTime.Tick
        Static i As Integer
        If i >= 1000 Then
            If ctl.TimeType = CountStatus.MaxToMin Then
                RunTime = RunTime.AddSeconds(-1)
                ctl.ShowTime(RunTime)
                If RunTime.Minute = 0 AndAlso RunTime.Second = 0 Then
                    tmTime.Stop()
                    If ctl.RoundRun = ctl.RoundMax Then
                        ctl.GameStatus = GameStatusType.EndGame
                    Else
                        ctl.GameStatus = GameStatusType.EndRound
                    End If

                    ctl.UpdateFinalScore()
                End If
            Else
                RunTime = RunTime.AddSeconds(1)
                ctl.ShowTime(RunTime)
                If ((RunTime.Minute * 60) + RunTime.Second) >= ctl.NowTime Then
                    tmTime.Stop()
                    If ctl.RoundRun = ctl.RoundMax Then
                        ctl.GameStatus = GameStatusType.EndGame
                    Else
                        ctl.GameStatus = GameStatusType.EndRound
                    End If

                    ctl.UpdateFinalScore()
                End If
            End If


            i = 0
        Else
            i += 100
        End If
    End Sub

    Private Sub btnSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        Dim frm As New frmControlSet
        frm.frmCtl = ctl
        frm.ShowDialog()

        If frm.okStatus Then
            tmTime.Stop()
            ctl.GameStatus = GameStatusType.None
            RunTime = New DateTime(2013, 1, 1, 0, 0, 0)

            If ctl.TimeType = CountStatus.MaxToMin Then
                RunTime = RunTime.AddSeconds(ctl.NowTime)
            End If

            ctl.K = 0
            ctl.K2 = 0
            ctl.RoundRun = 1
            ctl.ShowTime(RunTime)
            ctl.ResetScoreAll()
            ctl.ResetFinalScore()

        End If
        lblJude1.Checked = False
        lblJude2.Checked = False
        lblJude3.Checked = False
        lblJude4.Checked = False
        lblJude5.Checked = False
        lblJude6.Checked = False
        lblJude7.Checked = False

        lblJude1.Enabled = True
        lblJude2.Enabled = True
        lblJude3.Enabled = True
        lblJude4.Enabled = True
        lblJude5.Enabled = True
        lblJude6.Enabled = True
        lblJude7.Enabled = True
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ctl.GameStatus = GameStatusType.None
        'Clear Time
        tmTime.Stop()
        ResetTime()
        'Clear Score
        ctl.RoundRun = 1
        ctl.ResetScoreAll()
        ctl.ResetFinalScore()
        'ClearConfirm Score
        ctl.ClearComfiremJoyAll()

        'Clear Check Disable
        'CheckBoxAllEnable()

        'Clear Athlete
        ctl.Athlete = ctl.Athlete
        'Update Header
        ctl.UpdateType(ctl.TypeDesc, ctl.AgeDesc, ctl.SexDesc, ctl.LevelDesc)
        'Clear Score
        ctl.ResetScoreAll()

        'Clear Round to 1
        ctl.RoundRun = 1
        ctl.K = 0
        ctl.K2 = 0
        Label40.BackColor = System.Drawing.Color.Blue
        Label41.BackColor = System.Drawing.Color.Blue
        Label42.BackColor = System.Drawing.Color.Blue
        If ctl.ConnDb Then
            'Connection To Database
            Dim sql As String = ""
            Dim dt As New DataTable

            sql = " SELECT * from dbo.Poomse_Athlete"
            sql &= " where Level_Id = " & ctl.LevelId & " and Age_Id = " & ctl.AgeId
            sql &= "       and Sex_Id = " & ctl.SexId & " and [TYPE_ID] = " & ctl.TypeId
            sql &= "       AND Athlete_Id > " & ctl.AthleteId
            sql &= " ORDER BY Athlete_Id"

            clsSys.conn.getData(sql, dt)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                ctl.AthleteId = dt.Rows(0)("Athlete_Id")
                ctl.Athlete = dt.Rows(0)("Athlete_Name")
                ctl.TeamName = dt.Rows(0)("Athlete_Team")
            Else
                MessageBox.Show("ไม่สามารถ Next ได้ กรุณา เลือกเงือนไขอื่น ๆ จาก Setup")
            End If

        End If
    End Sub


    Private Sub btnSetup_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSetup.MouseDown
        btnSetup.BackColor = Color.Black
    End Sub

    Private Sub btnSetup_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSetup.MouseUp
        btnSetup.BackColor = Color.White

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ctl.SetTotal()
    End Sub

    Private Sub lblStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStartStop.Click
        ChangLabelWhenClick(sender)
        ChangePoomsaeStatus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ctl.SetTotal2()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ctl.SetTotal2()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        ChangLabelWhenClick(sender)
        ctl.ClearRound2()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        ChangLabelWhenClick(sender)
        ctl.ClearRound1()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ctl.setKoryoType(ComboBox1.Text)
        txtRound1.Focus()
    End Sub

    Private Sub btnPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPic.Click
        Dim dag As New OpenFileDialog()

        If dag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ctl.setImage(dag.FileName)
            'picImage.ImageLocation = dag.FileName
            'MessageBox.Show(dag.FileName)
        End If

        txtRound1.Focus()
    End Sub

    Private Sub ChangLabelWhenClick(ByVal sender As System.Object)
        sender.BackColor = System.Drawing.Color.AliceBlue
        sender.Refresh()
        System.Threading.Thread.Sleep(300)
        sender.BackColor = System.Drawing.Color.Gold
        sender.Refresh()
    End Sub
    Private Sub Label40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label40.Click
        ChangLabelWhenClick(sender)
        ctl.setRound1()
    End Sub

    Private Sub Label41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label41.Click
        ChangLabelWhenClick(sender)
        ctl.setRound2()
    End Sub

    Private Sub Label42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label42.Click
        ChangLabelWhenClick(sender)
        ctl.setTotalRound()
    End Sub


    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        ChangLabelWhenClick(sender)
        If IsNumeric(txtTotal.Text) Then
            ctl.setFinalTotal(CDbl(txtTotal.Text))
            ctl.CheckUpdateTable()
            ctl.UpdateFinalScore1()
        Else
            MessageBox.Show("ผลรวมไม่ถูกต้องไม่สามารถแสดงได้")
        End If

    End Sub

    Private Sub Label39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label39.Click
        ChangLabelWhenClick(sender)
        If IsNumeric(txtTotal2.Text) Then
            ctl.setFinalTotal(CDbl(txtTotal2.Text))
            ctl.CheckUpdateTable()
            ctl.UpdateFinalScore2()
        Else
            MessageBox.Show("ผลรวมไม่ถูกต้องไม่สามารถแสดงได้")
        End If

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        ChangLabelWhenClick(sender)
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Dim dlg As New SaveFileDialog
        dlg.Filter = "Image(*.BMP)|*.BMP"
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            screenshot.Save(dlg.FileName, Imaging.ImageFormat.Bmp)
        End If

    End Sub

    Private Sub lblEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEnd.Click
        If ctl.TimeType = CountStatus.MaxToMin Then
            RunTime = New DateTime(2016, 5, 5, 0, 0, 2)
        Else
            RunTime = New DateTime(2016, 5, 5, 0, 0, 0)
            RunTime = RunTime.AddSeconds(ctl.NowTime - 2)
        End If

        ctl.ShowTime(RunTime)
    End Sub


End Class