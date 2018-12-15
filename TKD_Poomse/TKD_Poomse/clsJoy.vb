Imports Microsoft.DirectX.DirectInput

Imports TKD_Poomse.EnumData

Public Class clsJoy
    Private joystickDevice As Device = Nothing

    Private iAccScore As Double = 4.0
    Public Property AccScore() As Double
        Get
            Return iAccScore
        End Get
        Set(ByVal value As Double)
            iAccScore = value
        End Set
    End Property

    Private iAccCut As Double = 0.1
    Public Property AccCut() As Double
        Get
            Return iAccCut
        End Get
        Set(ByVal value As Double)
            iAccCut = value
        End Set
    End Property

    Private iAccOrigin As Double = 4.0
    Public Property AccOrigin() As Double
        Get
            Return iAccOrigin
        End Get
        Set(ByVal value As Double)
            iAccOrigin = value
        End Set
    End Property

    Private iPreScore As Double = 6.0
    Public Property PreScore() As Double
        Get
            Return iPreScore
        End Get
        Set(ByVal value As Double)
            iPreScore = value
        End Set
    End Property

    Private iPreCut As Double = 0.3
    Public Property PreCut() As Double
        Get
            Return iPreCut
        End Get
        Set(ByVal value As Double)
            iPreCut = value
        End Set
    End Property

    Private iPreOrigin As Double = 6.0
    Public Property PreOrigin() As Double
        Get
            Return iPreOrigin
        End Get
        Set(ByVal value As Double)
            iPreOrigin = value
        End Set
    End Property

    Private iFinalScore As Double = 0
    Public Property FinalScore() As Double
        Get
            Return iFinalScore
        End Get
        Set(ByVal value As Double)
            iFinalScore = value
        End Set
    End Property

    Public Sub New(ByVal deviceGuid As System.Guid, ByVal parent As System.Windows.Forms.Control)
        joystickDevice = New Device(deviceGuid)
        With joystickDevice
            .SetCooperativeLevel(parent, CooperativeLevelFlags.Background Or CooperativeLevelFlags.NonExclusive)
            .SetDataFormat(DeviceDataFormat.Joystick)
            .Acquire()
        End With
    End Sub

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Get Event From JoyStick 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function getInput() As List(Of JoyInputType)
        Dim Input As New List(Of JoyInputType)
        Static bBtn0 As Boolean = False
        Static bBtn1 As Boolean = False
        Static bBtn2 As Boolean = False
        Static bBtn3 As Boolean = False
        Static bBtn4 As Boolean = False
        Static bBtn5 As Boolean = False
        Static bBtn6 As Boolean = False
        Static bBtn7 As Boolean = False
        Static bDown As Boolean = False
        Static bUp As Boolean = False
        Static bRight As Boolean = False
        Static bLeft As Boolean = False

        If IsNothing(joystickDevice) Then
            Return Input
        End If
        Try
            joystickDevice.Poll()
            Dim state As JoystickState = joystickDevice.CurrentJoystickState

            If state.Y = 65535 Then ' Down Key
                If Not bDown Then
                    Input.Add(JoyInputType.Down)
                    bDown = True
                End If
            Else
                bDown = False
            End If

            If state.Y = 0 Then 'Up Key
                If Not bUp Then
                    Input.Add(JoyInputType.Up)
                    bUp = True
                End If
            Else
                bUp = False
            End If


            If state.X = 65535 Then
                If Not bRight Then
                    Input.Add(JoyInputType.Right)
                    bRight = True
                End If

            Else
                bRight = False
            End If

            If state.X = 0 Then
                If Not bLeft Then
                    Input.Add(JoyInputType.Left)
                    bLeft = True
                End If
            Else
                bLeft = False
            End If


            If state.GetButtons(6) > 0 Then ' L1 Key
                If Not bBtn6 Then
                    Input.Add(JoyInputType.L1)
                    bBtn6 = True
                End If
            Else
                bBtn6 = False
            End If

            If state.GetButtons(4) > 0 Then ' L2 Key
                If Not bBtn4 Then
                    Input.Add(JoyInputType.L2)
                    bBtn4 = True
                End If
            Else
                bBtn4 = False
            End If

            If state.GetButtons(2) > 0 Then ' X Key
                If Not bBtn2 Then
                    Input.Add(JoyInputType.X)
                    bBtn2 = True
                End If
            Else
                bBtn2 = False
            End If

            If state.GetButtons(3) > 0 Then ' X Key
                If Not bBtn3 Then
                    Input.Add(JoyInputType.สี่เหลี่ยม)
                    bBtn3 = True
                End If
            Else
                bBtn3 = False
            End If

            If state.GetButtons(0) > 0 Then ' /_\ Key
                If Not bBtn0 Then
                    Input.Add(JoyInputType.สามเหลี่ยม)
                    bBtn0 = True
                End If
            Else
                bBtn0 = False
            End If

            If state.GetButtons(1) > 0 Then
                If Not bBtn1 Then
                    Input.Add(JoyInputType.วงกลม)
                    bBtn1 = True
                End If
            Else
                bBtn1 = False
            End If

            If state.GetButtons(7) > 0 Then ' R1 Key
                If Not bBtn7 Then
                    Input.Add(JoyInputType.R1)
                    bBtn7 = True
                End If
            Else
                bBtn7 = False
            End If

            If state.GetButtons(5) > 0 Then ' R2 Key
                If Not bBtn5 Then
                    Input.Add(JoyInputType.R2)
                    bBtn5 = True
                End If
            Else
                bBtn5 = False
            End If

        Catch ex As Exception
        Finally

        End Try
        Return Input
    End Function
End Class
