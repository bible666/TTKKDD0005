Imports Microsoft.DirectX.DirectInput
Imports System.Text
Imports TKD_Poomse.EnumData

Public Class clsJoyControl

    Private joystickDevice1 As New clsJoy
    Private joystickDevice2 As New clsJoy
    Private joystickDevice3 As New clsJoy
    Private joystickDevice4 As New clsJoy
    Private joystickDevice5 As New clsJoy
    Private joystickDevice6 As New clsJoy
    Private joystickDevice7 As New clsJoy

    Private frmctl As frmScreenControl

    Public Sub New(ByVal pfrmCtl As frmScreenControl)
        frmctl = pfrmCtl
        'Get Joy Control
        GetJoyStick()
    End Sub

    Private Sub GetJoyStick()
        ' List of attached joysticks
        Dim gameControllerList As DeviceList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly)

        ' There is one controller at least?
        If (gameControllerList.Count > 0) Then
            For i As Integer = 0 To gameControllerList.Count - 1
                ' Create an object instance
                gameControllerList.MoveNext()
                Dim deviceInstance As DeviceInstance = gameControllerList.Current
                Select Case i
                    Case 0
                        joystickDevice1 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 1
                        joystickDevice2 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 2
                        joystickDevice3 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 3
                        joystickDevice4 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 4
                        joystickDevice5 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 5
                        joystickDevice6 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                    Case 6
                        joystickDevice7 = New clsJoy(deviceInstance.InstanceGuid, frmctl)
                End Select
            Next

        End If
    End Sub

    Public Function GetInput(ByVal JoyNo As JoyId) As List(Of JoyInputType)
        Select Case JoyNo
            Case JoyId.Joy1
                If Not IsNothing(joystickDevice1) Then
                    Return joystickDevice1.getInput
                Else
                    Return Nothing
                End If

            Case JoyId.Joy2
                If Not IsNothing(joystickDevice2) Then
                    Return joystickDevice2.getInput
                Else
                    Return Nothing
                End If
            Case JoyId.Joy3
                If Not IsNothing(joystickDevice3) Then
                    Return joystickDevice3.getInput
                Else
                    Return Nothing
                End If

            Case JoyId.Joy4
                If Not IsNothing(joystickDevice4) Then
                    Return joystickDevice4.getInput
                Else
                    Return Nothing
                End If
            Case JoyId.Joy5
                If Not IsNothing(joystickDevice5) Then
                    Return joystickDevice5.getInput
                Else
                    Return Nothing
                End If

            Case JoyId.Joy6
                If Not IsNothing(joystickDevice6) Then
                    Return joystickDevice6.getInput
                Else
                    Return Nothing
                End If
            Case JoyId.Joy7
                If Not IsNothing(joystickDevice7) Then
                    Return joystickDevice7.getInput
                Else
                    Return Nothing
                End If
            Case Else
                If Not IsNothing(joystickDevice1) Then
                    Return joystickDevice1.getInput
                Else
                    Return Nothing
                End If
        End Select

    End Function

#Region " Pre Score Control "
    Public Sub PreSet(ByVal JoyNo As JoyId, ByVal PreValue As Double)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.PreScore = PreValue
            Case JoyId.Joy2
                joystickDevice2.PreScore = PreValue
            Case JoyId.Joy3
                joystickDevice3.PreScore = PreValue
            Case JoyId.Joy4
                joystickDevice4.PreScore = PreValue
            Case JoyId.Joy5
                joystickDevice5.PreScore = PreValue
            Case JoyId.Joy6
                joystickDevice6.PreScore = PreValue
            Case JoyId.Joy7
                joystickDevice7.PreScore = PreValue
        End Select
    End Sub
    Public Sub PreCut_1(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.PreScore -= 0.1 ' joystickDevice1.PreCut
            Case JoyId.Joy2
                joystickDevice2.PreScore -= 0.1 ' joystickDevice2.PreCut
            Case JoyId.Joy3
                joystickDevice3.PreScore -= 0.1 ' joystickDevice3.PreCut
            Case JoyId.Joy4
                joystickDevice4.PreScore -= 0.1 ' joystickDevice4.PreCut
            Case JoyId.Joy5
                joystickDevice5.PreScore -= 0.1 ' joystickDevice5.PreCut
            Case JoyId.Joy6
                joystickDevice6.PreScore -= 0.1 ' joystickDevice6.PreCut
            Case JoyId.Joy7
                joystickDevice7.PreScore -= 0.1 ' joystickDevice7.PreCut
        End Select
    End Sub

    Public Sub PreCut_3(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.PreScore -= 0.3 ' joystickDevice1.PreCut
            Case JoyId.Joy2
                joystickDevice2.PreScore -= 0.3 ' joystickDevice2.PreCut
            Case JoyId.Joy3
                joystickDevice3.PreScore -= 0.3 ' joystickDevice3.PreCut
            Case JoyId.Joy4
                joystickDevice4.PreScore -= 0.3 ' joystickDevice4.PreCut
            Case JoyId.Joy5
                joystickDevice5.PreScore -= 0.3 ' joystickDevice5.PreCut
            Case JoyId.Joy6
                joystickDevice6.PreScore -= 0.3 ' joystickDevice6.PreCut
            Case JoyId.Joy7
                joystickDevice7.PreScore -= 0.3 ' joystickDevice7.PreCut
        End Select
    End Sub

    Public Sub PreClear(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.PreScore = joystickDevice1.PreOrigin
            Case JoyId.Joy2
                joystickDevice2.PreScore = joystickDevice2.PreOrigin
            Case JoyId.Joy3
                joystickDevice3.PreScore = joystickDevice3.PreOrigin
            Case JoyId.Joy4
                joystickDevice4.PreScore = joystickDevice4.PreOrigin
            Case JoyId.Joy5
                joystickDevice5.PreScore = joystickDevice5.PreOrigin
            Case JoyId.Joy6
                joystickDevice6.PreScore = joystickDevice6.PreOrigin
            Case JoyId.Joy7
                joystickDevice7.PreScore = joystickDevice7.PreOrigin
        End Select
    End Sub

    Public Sub SetPreOriginAllJoy(ByVal dValue As Double)
        joystickDevice1.PreOrigin = dValue
        joystickDevice2.PreOrigin = dValue
        joystickDevice3.PreOrigin = dValue
        joystickDevice4.PreOrigin = dValue
        joystickDevice5.PreOrigin = dValue
        joystickDevice6.PreOrigin = dValue
        joystickDevice7.PreOrigin = dValue
    End Sub


    Public Sub SetPreCutAllJoy(ByVal dValue As Double)
        joystickDevice1.PreCut = dValue
        joystickDevice2.PreCut = dValue
        joystickDevice3.PreCut = dValue
        joystickDevice4.PreCut = dValue
        joystickDevice5.PreCut = dValue
        joystickDevice6.PreCut = dValue
        joystickDevice7.PreCut = dValue
    End Sub

    Public Function GetPreScore(ByVal JoyNo As JoyId) As Double
        Select Case JoyNo
            Case JoyId.Joy1
                Return joystickDevice1.PreScore
            Case JoyId.Joy2
                Return joystickDevice2.PreScore
            Case JoyId.Joy3
                Return joystickDevice3.PreScore
            Case JoyId.Joy4
                Return joystickDevice4.PreScore
            Case JoyId.Joy5
                Return joystickDevice5.PreScore
            Case JoyId.Joy6
                Return joystickDevice6.PreScore
            Case JoyId.Joy7
                Return joystickDevice7.PreScore
            Case Else
                Return 0
        End Select
    End Function

#End Region

#Region " Acc Score Control "
    Public Sub AccSet(ByVal JoyNo As JoyId, ByVal AccValue As Double)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.AccScore = AccValue
            Case JoyId.Joy2
                joystickDevice2.AccScore = AccValue
            Case JoyId.Joy3
                joystickDevice3.AccScore = AccValue
            Case JoyId.Joy4
                joystickDevice4.AccScore = AccValue
            Case JoyId.Joy5
                joystickDevice5.AccScore = AccValue
            Case JoyId.Joy6
                joystickDevice6.AccScore = AccValue
            Case JoyId.Joy7
                joystickDevice7.AccScore = AccValue
        End Select
    End Sub
    Public Sub AccCut_1(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.AccScore -= 0.1 'joystickDevice1.AccCut
            Case JoyId.Joy2
                joystickDevice2.AccScore -= 0.1 'joystickDevice2.AccCut
            Case JoyId.Joy3
                joystickDevice3.AccScore -= 0.1 'joystickDevice3.AccCut
            Case JoyId.Joy4
                joystickDevice4.AccScore -= 0.1 'joystickDevice4.AccCut
            Case JoyId.Joy5
                joystickDevice5.AccScore -= 0.1 'joystickDevice5.AccCut
            Case JoyId.Joy6
                joystickDevice6.AccScore -= 0.1 'joystickDevice6.AccCut
            Case JoyId.Joy7
                joystickDevice7.AccScore -= 0.1 'joystickDevice7.AccCut
        End Select
    End Sub

    Public Sub AccCut_3(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.AccScore -= 0.3 'joystickDevice1.AccCut
            Case JoyId.Joy2
                joystickDevice2.AccScore -= 0.3 'joystickDevice2.AccCut
            Case JoyId.Joy3
                joystickDevice3.AccScore -= 0.3 'joystickDevice3.AccCut
            Case JoyId.Joy4
                joystickDevice4.AccScore -= 0.3 'joystickDevice4.AccCut
            Case JoyId.Joy5
                joystickDevice5.AccScore -= 0.3 'joystickDevice5.AccCut
            Case JoyId.Joy6
                joystickDevice6.AccScore -= 0.3 'joystickDevice6.AccCut
            Case JoyId.Joy7
                joystickDevice7.AccScore -= 0.3 'joystickDevice7.AccCut
        End Select
    End Sub

    Public Sub AccClear(ByVal JoyNo As JoyId)
        Select Case JoyNo
            Case JoyId.Joy1
                joystickDevice1.AccScore = joystickDevice1.AccOrigin
            Case JoyId.Joy2
                joystickDevice2.AccScore = joystickDevice2.AccOrigin
            Case JoyId.Joy3
                joystickDevice3.AccScore = joystickDevice3.AccOrigin
            Case JoyId.Joy4
                joystickDevice4.AccScore = joystickDevice4.AccOrigin
            Case JoyId.Joy5
                joystickDevice5.AccScore = joystickDevice5.AccOrigin
            Case JoyId.Joy6
                joystickDevice6.AccScore = joystickDevice6.AccOrigin
            Case JoyId.Joy7
                joystickDevice7.AccScore = joystickDevice7.AccOrigin
        End Select
    End Sub

    ''' <summary>
    ''' Get Acc Score ปัจจุบัน
    ''' </summary>
    ''' <param name="JoyNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAccScore(ByVal JoyNo As JoyId) As Double
        Select Case JoyNo
            Case JoyId.Joy1
                Return joystickDevice1.AccScore
            Case JoyId.Joy2
                Return joystickDevice2.AccScore
            Case JoyId.Joy3
                Return joystickDevice3.AccScore
            Case JoyId.Joy4
                Return joystickDevice4.AccScore
            Case JoyId.Joy5
                Return joystickDevice5.AccScore
            Case JoyId.Joy6
                Return joystickDevice6.AccScore
            Case JoyId.Joy7
                Return joystickDevice7.AccScore
            Case Else
                Return 0
        End Select
    End Function

    Public Sub SetAccOriginAllJoy(ByVal dValue As Double)
        joystickDevice1.AccOrigin = dValue
        joystickDevice1.AccScore = dValue

        joystickDevice2.AccOrigin = dValue
        joystickDevice2.AccScore = dValue

        joystickDevice3.AccOrigin = dValue
        joystickDevice3.AccScore = dValue

        joystickDevice4.AccOrigin = dValue
        joystickDevice4.AccScore = dValue

        joystickDevice5.AccOrigin = dValue
        joystickDevice5.AccScore = dValue

        joystickDevice6.AccOrigin = dValue
        joystickDevice6.AccScore = dValue

        joystickDevice7.AccOrigin = dValue
        joystickDevice7.AccScore = dValue
    End Sub

    Public Sub SetAccCutAllJoy(ByVal dValue As Double)
        joystickDevice1.AccCut = dValue
        joystickDevice2.AccCut = dValue
        joystickDevice3.AccCut = dValue
        joystickDevice4.AccCut = dValue
        joystickDevice5.AccCut = dValue
        joystickDevice6.AccCut = dValue
        joystickDevice7.AccCut = dValue
    End Sub

#End Region

    Public Function GetFinalScore(ByVal JoyNo As JoyId) As Double
        Select Case JoyNo
            Case JoyId.Joy1
                Return joystickDevice1.AccScore + joystickDevice1.PreScore
            Case JoyId.Joy2
                Return joystickDevice2.AccScore + joystickDevice2.PreScore
            Case JoyId.Joy3
                Return joystickDevice3.AccScore + joystickDevice3.PreScore
            Case JoyId.Joy4
                Return joystickDevice4.AccScore + joystickDevice4.PreScore
            Case JoyId.Joy5
                Return joystickDevice5.AccScore + joystickDevice5.PreScore
            Case JoyId.Joy6
                Return joystickDevice6.AccScore + joystickDevice6.PreScore
            Case JoyId.Joy7
                Return joystickDevice7.AccScore + joystickDevice7.PreScore
            Case Else
                Return 0
        End Select
    End Function
End Class
