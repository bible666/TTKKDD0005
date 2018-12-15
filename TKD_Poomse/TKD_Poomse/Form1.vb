Imports System.Management
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Private sFileSerial As String = ""

    Private Function Write_Serial_File(ByVal pSerial As String) As Boolean
        Dim Fs As New System.IO.FileStream(sFileSerial, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Write)
        Dim Sw As New System.IO.StreamWriter(Fs)
        Try
            'SendHeader()

            Sw.WriteLine(pSerial)

            Sw.Close()
            Fs.Close()
        Catch ex As Exception

        End Try
    End Function

    Private Function Read_Serial_File() As String
        Dim Fs As New System.IO.FileStream(sFileSerial, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        Dim Sw As New System.IO.StreamReader(Fs)
        Dim ret As String = ""
        Try
            'SendHeader()

            ret = Sw.ReadToEnd

            Sw.Close()
            Fs.Close()
        Catch ex As Exception

        End Try
        Return ret
    End Function

    Private Function getCPU_ID() As String
        Dim cpuID As String = String.Empty
        Dim mc As ManagementClass = New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            If (cpuID = String.Empty) Then
                cpuID = mo.Properties("ProcessorId").Value.ToString()
            End If
        Next
        Return cpuID
    End Function
    Private Function CheckSerial(ByRef EnData As String) As Boolean
        'ไม่ check key
        'Dim ret As Boolean = True


        'Check Key
        Dim ret As Boolean = False
        Dim frm As New frmInput_Serial
        EnData = ""
        frm.Label1.Text = getCPU_ID()
        frm.ShowDialog()
        If frm.RetStatus Then
            EnData = EncodeData(getCPU_ID, "bible6666")
            EnData = EncodeData(EnData, "Amagadon99")
            If frm.TextBox1.Text = EnData Then
                ret = True
            End If
        End If


        '----------------------------------
        Return ret
    End Function
    Private Function EncodeData(ByVal Data As String, ByVal Key As String) As String
        Dim ret As String = ""
        Dim encrip As New System.IO.MemoryStream
        Dim RC2 As New RC2CryptoServiceProvider
        RC2.Key = Encoding.ASCII.GetBytes(Key)
        Dim iv() As Byte = {11, 12, 33, 50, 78, 25, 72, 84}
        RC2.IV = iv
        Dim myEn As ICryptoTransform = RC2.CreateEncryptor
        Dim pwd() As Byte = Encoding.ASCII.GetBytes(Data)
        Dim myCry As New CryptoStream(encrip, myEn, CryptoStreamMode.Write)
        myCry.Write(pwd, 0, pwd.Length)
        myCry.Close()
        ret = Convert.ToBase64String(encrip.ToArray())
        Return ret
    End Function
    Private Function DecodeData(ByVal Data As String, ByVal Key As String) As String
        Dim ret As String = ""
        Try
            Dim Decode As New System.IO.MemoryStream
            Dim rc2 As New RC2CryptoServiceProvider
            rc2.Key = Encoding.ASCII.GetBytes(Key)
            Dim iv() As Byte = {11, 12, 33, 50, 78, 25, 72, 84}
            rc2.IV = iv
            Dim Myde As ICryptoTransform = rc2.CreateDecryptor
            Dim enPass() As Byte = Convert.FromBase64String(Data)
            Dim Mycry As New CryptoStream(Decode, Myde, CryptoStreamMode.Write)
            Mycry.Write(enPass, 0, enPass.Length)
            Mycry.Close()
            ret = Encoding.ASCII.GetString(Decode.ToArray())
        Catch ex As Exception
            ret = ""
        End Try

        Return ret
    End Function

    Private Function UpdateKeyBoardStr(ByVal str As String) As String
        Dim ret As String = ""
        Select Case str
            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                ret = "D" & str
            Case Else
                ret = str
        End Select
        Return ret
    End Function
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'Check Serial 
        'sFileSerial = Application.ExecutablePath
        'sFileSerial = sFileSerial.ToUpper.Replace(".EXE", ".SVR")
        'If Not System.IO.File.Exists(sFileSerial) Then
        '    'not have file
        '    Dim EnData As String = "ScoreFighting" ' Input Serial Data
        '    If CheckSerial(EnData) Then
        '        Write_Serial_File(EnData)
        '    Else
        '        Application.Exit()
        '    End If
        'Else
        '    'Have Data File
        '    Dim EnData As String = Read_Serial_File()
        '    If EnData.Trim = "" Then
        '        If CheckSerial(EnData) Then
        '            Write_Serial_File(EnData)
        '        Else
        '            Application.Exit()
        '        End If
        '    Else
        '        EnData = DecodeData(EnData, "Amagadon99")
        '        EnData = DecodeData(EnData, "bible6666")
        '        If EnData <> getCPU_ID() Then
        '            If CheckSerial(EnData) Then
        '                Write_Serial_File(EnData)
        '            Else
        '                Application.Exit()
        '            End If
        '        End If
        '    End If

        'End If

        Dim ctl As New clsCForm
        Dim sPath As String = Application.StartupPath
        Dim FS As New System.IO.FileStream(sPath & "\Keyboardconfig.ini", IO.FileMode.Open)
        Dim FR As New System.IO.StreamReader(FS)
        Dim line As String = ""
        Dim str() As String

        lbl.Text = " Read Config File "
        lbl.Refresh()

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy1_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy1_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy1_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy1_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy1_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy2_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy2_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy2_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy2_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy2_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy3_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy3_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy3_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy3_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy3_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy4_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy4_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy4_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy4_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy4_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy5_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy5_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy5_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy5_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy5_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy6_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy6_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy6_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy6_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy6_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy7_AccCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy7_AccClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy7_PreCut = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Joy7_PreClear = UpdateKeyBoardStr(str(1).Trim)
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            Dim a() As String = str(1).Trim.Split("+")
            If a.Length >= 2 Then
                clsSys.Joy7_OK = UpdateKeyBoardStr(a(1).Trim)
            End If
        End If

        lbl.Text = " Read Database Config File "
        lbl.Refresh()

        FS = New System.IO.FileStream(sPath & "\config.ini", IO.FileMode.Open)
        FR = New System.IO.StreamReader(FS)
        line = ""

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.ServerName = str(1).Trim
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.DBName = str(1).Trim
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Login = str(1).Trim
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.Pass = str(1).Trim
        End If

        line = FR.ReadLine
        str = line.Split("=")
        If str.Length >= 2 Then
            clsSys.WebFilePath = str(1).Trim
        End If

        FR.Close()
        FS.Close()


        If MessageBox.Show("ต้องการทำงานแบบ ต่อฐานข้อมูลใช่หรือไม่ [ Yes ] ต่อ [ No ] ไม่ต่อ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            ctl.ConnDb = True

            Dim m_ConnStr1 As String = ""
            m_ConnStr1 = "Server=" & clsSys.ServerName & ";uid=" & clsSys.Login & ";pwd=" & clsSys.Pass & ";Database=" & clsSys.DBName
            'clsSys.conn.setConnString("Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" & sDBFile & ";Uid=;Pwd=;")

            lbl.Text = " Connection To Server "
            lbl.Refresh()
            clsSys.conn.setConnString(m_ConnStr1)
            If Not clsSys.conn.openDB() Then
                MessageBox.Show("ไม่สามารถต่อกับฐานข้อมูลได้ โปรดตรวจสอบ config.ini ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Else
            ctl.ConnDb = False
        End If


        lbl.Text = " Start Program "
        lbl.Refresh()


        ctl.Show()
        Me.Hide()
    End Sub
End Class
