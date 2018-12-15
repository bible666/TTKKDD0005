Imports System.Reflection
Imports System.Text
Imports System.Data.SqlClient

Namespace DAO

    Public Class daoBase
        Inherits Util.DBUtil_SQL

#Region " CONSTRUCTURE "
        Public Sub New()
            clr()
        End Sub
#End Region

#Region " OVERRIDABLE FUNCTION "
        Protected Overridable Function tableName() As String
            Dim t As Type = Me.GetType()
            Return t.Name.Substring(3)
        End Function
        Protected Overridable Function isIdentity(ByVal sFieldName As String) As Boolean
            Return False
        End Function
        Protected Overridable Function Key() As String
            Return ""
        End Function
        Protected Overridable Function fieldName(ByVal sFieldName As String) As String
            Return sFieldName
        End Function
#End Region

#Region " Public Function "
        ''' <summary>
        ''' Clear Value in All Field
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub clr()
            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo
            For Each fi In t.GetFields()
                Select Case fi.FieldType.ToString()
                    Case "System.String"
                        CallByName(Me, fi.Name, CallType.Let, "")
                    Case "System.DateTime"
                        CallByName(Me, fi.Name, CallType.Let, DateTime.MinValue)
                    Case Else
                        CallByName(Me, fi.Name, CallType.Let, 0)
                End Select
            Next
        End Sub

        ''' <summary>
        ''' Update Field Where By Primary Key
        ''' </summary>
        ''' <param name="strSet">Set Columns Value Ex. A = 'B'</param>
        ''' <param name="pErr">Error Message</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function updKey(Optional ByVal strSet As String = "", Optional ByRef pErr As String = "") As Boolean
            Dim sWhere As String = makeWhere()

            If sWhere <> "" Then
                If updRec(sWhere, strSet, pErr) Then
                    Return True
                End If
            End If
            Return False

        End Function

        ''' <summary>
        ''' Delete Data By Primary Key
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function delKey() As Boolean
            Dim sWhere As String = makeWhere()

            If sWhere <> "" Then
                Return delRec(sWhere)
            End If
            Return False

        End Function

        Public Function chkField(ByVal pDbType As DbType, ByVal sField As String, ByVal sWhere As String) As Boolean
            Dim Result As New Object
            Dim sSQL As String
            'Dim sWhere As String = makeWhere()
            If sWhere = "" Then
                Return False
            End If
            sSQL = String.Format("SELECT 1 FROM {1} WHERE {2}", sField, tableName(), sWhere)
            If exeScalar(sSQL, Result) = m_SQL_OK Then
                If Result Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Check Duplicate Primary Key
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function chkKey() As Boolean
            Dim sWhere As String = makeWhere()
            Dim sSQL As String
            Dim result As New Object

            If sWhere = "" Then
                Return False
            End If

            sSQL = "SELECT 1 FROM " & tableName() & " WHERE " & sWhere
            If exeScalar(sSQL, result) = m_SQL_OK Then
                If result Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' Get Data By Primary Key
        ''' ถ้าหาเจอ จะ set Field ด้วยค่าที่หาได้
        ''' </summary>
        ''' <returns>True หาเจอ False หาไม่เจอ</returns>
        ''' <remarks></remarks>
        Public Function getKey() As Boolean
            Dim ds As DataTable
            Dim sWhere As String = ""
            Dim param As New Hashtable
            makeWhere(sWhere, param)

            If sWhere = "" Then
                Return False
            End If

            ds = getRec(sWhere, param)
            If ds Is Nothing Then
                Return False
            End If

            If ds.Rows.Count = 0 Then
                Return False
            End If

            Return setRec(ds.Rows(0))

        End Function

        ''' <summary>
        ''' set value จาก data row ไปยังตัวแปร Field
        ''' </summary>
        ''' <param name="row"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function setRec(ByVal row As DataRow) As Boolean
            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo
            Dim ret As Boolean
            Try
                For Each fi In t.GetFields()
                    Try
                        If row(fieldName(fi.Name)) Is DBNull.Value Then
                            Select Case fi.FieldType.ToString()
                                Case "System.String", "System.DateTime"
                                    CallByName(Me, fi.Name, CallType.Let, "")
                                Case Else
                                    CallByName(Me, fi.Name, CallType.Let, 0)
                            End Select
                        Else
                            CallByName(Me, fi.Name, CallType.Let, row(fieldName(fi.Name)))
                        End If
                    Catch ex As Exception
                        Select Case fi.FieldType.ToString()
                            Case "System.String", "System.DateTime"
                                CallByName(Me, fi.Name, CallType.Let, "")
                            Case Else
                                CallByName(Me, fi.Name, CallType.Let, 0)
                        End Select
                    End Try
                Next
                ret = True
            Catch ex As Exception
                MsgBox("setRec:" & ex.Message, MsgBoxStyle.Critical, Application.ProductName)
                ret = False
            End Try
            Return ret
        End Function

        ''' <summary>
        ''' set value จาก data row ไปยังตัวแปร Field
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Sub row2Rec(ByVal row As DataRow)
            'Dim t As Type = Me.GetType()
            'Dim fi As FieldInfo

            'For Each fi In t.GetFields()
            For Each PropertyItem As System.Reflection.PropertyInfo In Me.GetType().GetProperties()
                Try
                    If row(PropertyItem.Name) Is DBNull.Value Then
                        Select Case PropertyItem.PropertyType.FullName
                            Case "System.String", "System.DateTime"
                                CallByName(Me, PropertyItem.Name, CallType.Let, "")
                            Case Else
                                CallByName(Me, PropertyItem.Name, CallType.Let, 0)
                        End Select
                    Else
                        CallByName(Me, PropertyItem.Name, CallType.Let, row(PropertyItem.Name))
                    End If
                Catch ex As Exception

                End Try
            Next
        End Sub

        ''' <summary>
        ''' set value จาก data row ไปยังตัวแปร Field
        ''' </summary>
        ''' <param name="dr"></param>
        ''' <remarks></remarks>
        Public Sub setValue(ByVal dr As DataRow)
            'Clear Data
            Me.clr()

            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo
            For Each fi In t.GetFields()
                Select Case fi.FieldType.ToString()
                    Case "System.String"
                        Dim str As String = ""
                        Try
                            str = IIf(IsDBNull(dr.Item(fi.Name)), "", dr.Item(fi.Name))
                        Catch ex As Exception
                            str = ""
                        End Try
                        CallByName(Me, fi.Name, CallType.Let, str)
                    Case "System.DateTime"
                        'getDateFromControl(fi.Name, ctls, dt)
                        Dim d As DateTime
                        Try
                            d = dr.Item(fi.Name)

                        Catch ex As Exception
                            d = Now
                        End Try
                        CallByName(Me, fi.Name, CallType.Let, d)
                    Case "System.Int32"
                        Dim val As Integer = 0
                        'getIntegerDataFromControl(fi.Name, ctls, val)
                        Try
                            If IsDBNull(dr.Item(fi.Name)) Then
                                val = 0
                            Else
                                val = dr.Item(fi.Name)
                            End If

                        Catch ex As Exception
                            val = 0
                        End Try

                        CallByName(Me, fi.Name, CallType.Let, val)
                    Case "System.Double"
                        Dim val As Double = 0
                        Try
                            If IsDBNull(dr.Item(fi.Name)) Then
                                val = 0
                            Else
                                val = dr.Item(fi.Name)
                            End If
                        Catch ex As Exception
                            val = 0
                        End Try
                        CallByName(Me, fi.Name, CallType.Let, val)
                    Case Else
                        CallByName(Me, fi.Name, CallType.Let, 0)
                End Select
            Next
        End Sub

        ''' <summary>
        ''' Insert Data 1 Row To Data base By use Field Value
        ''' </summary>
        ''' <param name="pErr">Error Message</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function insRec(Optional ByRef pErr As String = "") As Boolean
            Dim sqlCmd As New SqlCommand

            sqlCmd.Connection = Me.getConnection
            sqlCmd.CommandText = getInsStr()

            If Me.isInTrans Then
                sqlCmd.Transaction = Me.getTransaction
            End If
            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo

            For Each fi In t.GetFields()
                Dim str As String = fi.Name
                Select Case fi.FieldType.ToString
                    Case "System.String"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = System.DBNull.Value
                        Else
                            sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = CallByName(Me, fi.Name, CallType.Get)
                        End If

                    Case "System.Int32"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = System.DBNull.Value
                        Else
                            If CallByName(Me, fi.Name, CallType.Get) = -9999 Then
                                sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = System.DBNull.Value
                            Else

                                sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = CallByName(Me, fi.Name, CallType.Get)
                            End If

                        End If

                    Case "System.Double"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = System.DBNull.Value
                        Else
                            If CallByName(Me, fi.Name, CallType.Get) = 0 Then
                                sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = System.DBNull.Value
                            Else
                                sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = CallByName(Me, fi.Name, CallType.Get)
                            End If

                        End If
                    Case "System.DateTime"
                        If CallByName(Me, fi.Name, CallType.Get).date = Date.MinValue Then
                            sqlCmd.Parameters.Add(str, SqlDbType.DateTime).Value = System.DBNull.Value
                        Else
                            sqlCmd.Parameters.Add(str, SqlDbType.DateTime).Value = CallByName(Me, fi.Name, CallType.Get)
                        End If
                    Case Else
                        sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = CallByName(Me, fi.Name, CallType.Get)
                End Select

            Next

            Try
                sqlCmd.ExecuteNonQuery()
            Catch ex As SqlException
                pErr = ex.Message
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Update Recode in Database By use Field Value
        ''' </summary>
        ''' <param name="strWhere">Condition for update</param>
        ''' <param name="strSet">ข้อมูลที่ต้องการ update ถ้าไม่กำหนด คือเอาทุก Field</param>
        ''' <param name="pErr">Error Message</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function updRec(ByVal strWhere As String, Optional ByVal strSet As String = "", Optional ByRef pErr As String = "") As Integer
            Dim sqlCmd As New SqlCommand

            sqlCmd.Connection = Me.getConnection
            sqlCmd.CommandText = getUpdStr(strWhere, strSet)

            If Me.isInTrans Then
                sqlCmd.Transaction = Me.getTransaction
            End If
            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo

            'For Each fi In t.GetFields()
            For Each fi In t.GetFields()
                Dim str As String = "@" & fi.Name ' 
                Select Case fi.FieldType.ToString
                    Case "System.String"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = System.DBNull.Value
                        Else
                            sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = CallByName(Me, fi.Name, CallType.Get)
                        End If

                    Case "System.Int32"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = System.DBNull.Value
                        Else
                            If CallByName(Me, fi.Name, CallType.Get) = -9999 Then
                                sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = System.DBNull.Value
                            Else

                                sqlCmd.Parameters.Add(str, SqlDbType.Int).Value = CallByName(Me, fi.Name, CallType.Get)
                            End If

                        End If

                    Case "System.Double"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = System.DBNull.Value
                        Else
                            If CallByName(Me, fi.Name, CallType.Get) = -9999 Then
                                sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = System.DBNull.Value
                            Else
                                sqlCmd.Parameters.Add(str, SqlDbType.Decimal).Value = CallByName(Me, fi.Name, CallType.Get)
                            End If

                        End If
                    Case "System.Date", "System.DateTime"
                        If IsNothing(CallByName(Me, fi.Name, CallType.Get)) Then
                            sqlCmd.Parameters.Add(str, SqlDbType.DateTime).Value = System.DBNull.Value
                        Else
                            If CallByName(Me, fi.Name, CallType.Get) = Date.MinValue Then
                                sqlCmd.Parameters.Add(str, SqlDbType.DateTime).Value = System.DBNull.Value
                            Else
                                sqlCmd.Parameters.Add(str, SqlDbType.DateTime).Value = CallByName(Me, fi.Name, CallType.Get)
                            End If

                        End If
                    Case Else
                        sqlCmd.Parameters.Add(str, SqlDbType.NVarChar).Value = CallByName(Me, fi.Name, CallType.Get)
                End Select

            Next

            Try
                sqlCmd.ExecuteNonQuery()
            Catch ex As SqlException
                pErr = ex.Message
                Return False
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Delete Data in Database 
        ''' </summary>
        ''' <param name="strWhere">เงือนไขในการลบ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function delRec(ByVal strWhere As String) As Boolean
            If runSQL(getDelStr(strWhere)) Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' ค้นหาข้อมูลจาก Database
        ''' </summary>
        ''' <param name="strWhere">ถ้าไม่กำหนดคือเอาทุกเงือนไข</param>
        ''' <param name="strColumns">ถ้าไม่กำหนดคือเอาทุก Coloumns</param>
        ''' <param name="strOrder">Sord Columns</param>
        ''' <returns>Data Table</returns>
        ''' <remarks></remarks>
        Public Overloads Function getRec(Optional ByVal strWhere As String = "", Optional ByVal strColumns As String = "", Optional ByVal strOrder As String = "") As DataTable
            Dim ds As New DataSet
            Dim str As String = ""
            Try
                str = getSelStr(strWhere, strColumns, strOrder)
                If getData(str, ds) = m_SQL_OK Then
                    If ds.Tables.Count > 0 Then
                        Return ds.Tables(0)
                    Else
                        Return Nothing
                    End If

                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Sql Error [" & str & "]")
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' ค้นหาข้อมูลจาก Database
        ''' </summary>
        ''' <param name="strWhere">ถ้าไม่กำหนดคือเอาทุกเงือนไข</param>
        ''' <param name="strColumns">ถ้าไม่กำหนดคือเอาทุก Coloumns</param>
        ''' <param name="strOrder">Sord Columns</param>
        ''' <returns>Data Table</returns>
        ''' <remarks></remarks>
        Public Overloads Function getRec(ByVal strWhere As String, ByVal pParam As Hashtable, Optional ByVal strColumns As String = "", Optional ByVal strOrder As String = "") As DataTable
            Dim ds As New DataSet
            Dim str As String = ""
            If IsNothing(pParam) Then
                Return Nothing
            End If
            Try
                str = getSelStr(strWhere, strColumns, strOrder)
                If getData(str, pParam, ds) = m_SQL_OK Then
                    If ds.Tables.Count > 0 Then
                        Return ds.Tables(0)
                    Else
                        Return Nothing
                    End If

                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Sql Error [" & str & "]")
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' ใช้ในการหาค่า Max Value ของ Field ที่กำหนด
        ''' </summary>
        ''' <param name="sField">Field Name ที่ต้องการหาค่า Max</param>
        ''' <param name="sWhere">เงือนไขในการหาค่า Max</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getMaxField(ByVal sField As String, Optional ByVal sWhere As String = "") As Double
            Dim Max As Object = 0
            Dim sSQL As String = ""
            If sWhere = "" Then
                sSQL = String.Format("SELECT MAX({0}) FROM {1}", sField, tableName())
            Else
                sSQL = String.Format("SELECT MAX({0}) FROM {1} WHERE {2}", sField, tableName(), sWhere)
            End If

            Dim ret As Double = Me.exeScalar(sSQL, Max)
            If Max Is DBNull.Value Then
                Return 0
            End If
            Return Max
        End Function

#End Region

#Region " Private Function "
        ''' <summary>
        ''' Create Query for insert Data
        ''' </summary>
        ''' <returns>Query For Insert Data</returns>
        ''' <remarks></remarks>
        Private Function getInsStr() As String
            Dim sSQL As String
            Dim sFields As StringBuilder = New StringBuilder("")
            Dim sValues As StringBuilder = New StringBuilder("")

            Dim t As Type = Me.GetType()
            Dim fi As FieldInfo
            Dim i As Integer = 0

            For Each fi In t.GetFields()
                If i > 0 Then
                    sFields.Append(",")
                    sValues.Append(",")
                End If
                sFields.Append(fieldName(fi.Name))

                'fix test
                sValues.Append(String.Format("@{0}", fi.Name))
                'Select Case fi.FieldType.ToString()
                '    Case "System.String", "System.DateTime"
                '        sValues.Append(String.Format("'{0}'", Replace(CallByName(Me, fi.Name, CallType.Get), "'", "''")))
                '    Case Else
                '        If CallByName(Me, fi.Name, CallType.Get) = clsDefaultValue.DefaultValue.NullNumValue Then
                '            sValues.Append(String.Format("{0}", "NULL"))
                '        Else
                '            sValues.Append(String.Format("{0}", CallByName(Me, fi.Name, CallType.Get)))
                '        End If

                'End Select

                i = i + 1
            Next

            sSQL = "INSERT INTO " & tableName() & " (" & sFields.ToString() & ") VALUES (" & sValues.ToString() & ")"
            Return sSQL
        End Function

        ''' <summary>
        ''' Create Query for update data
        ''' </summary>
        ''' <param name="strWhere">Where Condition</param>
        ''' <param name="strSet">Set Value ถ้าไม่กำหนด คือ Update ทุก Columns</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getUpdStr(ByVal strWhere As String, ByVal strSet As String) As String

            Dim sSQL As String
            Dim sSets As StringBuilder = New StringBuilder("")

            If strSet = "" Then

                Dim t As Type = Me.GetType()
                Dim fi As FieldInfo
                Dim i As Integer = 0

                For Each fi In t.GetFields()
                    If Not isIdentity(fi.Name) Then
                        If i > 0 Then
                            sSets.Append(",")
                        End If
                        sSets.Append(fieldName(fi.Name))
                        sSets.Append("=")
                        'fix test
                        sSets.Append(String.Format("@{0}", fi.Name))
                        'Select Case fi.FieldType.ToString()
                        '    Case "System.String", "System.DateTime"
                        '        sSets.Append(String.Format("'{0}'", Replace(CallByName(Me, fi.Name, CallType.Get), "'", "''")))
                        '    Case Else
                        '        If CallByName(Me, fi.Name, CallType.Get) = clsDefaultValue.DefaultValue.NullNumValue Then
                        '            sSets.Append(String.Format("{0}", "NULL"))
                        '        Else
                        '            sSets.Append(String.Format("{0}", CallByName(Me, fi.Name, CallType.Get)))
                        '        End If
                        '        'sSets.Append(String.Format("{0}", CallByName(Me, fi.Name, CallType.Get)))
                        'End Select

                        i = i + 1
                    End If
                Next
            Else
                sSets.Append(strSet)
            End If

            sSQL = "UPDATE " & tableName() & " SET " & sSets.ToString()

            If strWhere <> "" Then
                sSQL = sSQL & " WHERE " & strWhere
            End If

            Return sSQL

        End Function

        ''' <summary>
        ''' Create Query for Delete Data
        ''' </summary>
        ''' <param name="strWhere">Where Condition</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getDelStr(ByVal strWhere As String) As String
            Dim sSQL As String

            sSQL = "DELETE FROM " & tableName()
            If strWhere <> "" Then
                sSQL = sSQL & " WHERE " & strWhere
            End If

            Return sSQL
        End Function

        ''' <summary>
        ''' Create Query for Select Data
        ''' </summary>
        ''' <param name="strWhere">Where Condition</param>
        ''' <param name="strCollumn">กำหนด Column ที่จะค้นหา ถ้าไม่กำหนด คือเอาหมด</param>
        ''' <param name="strOrder">Sort Data</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSelStr(ByVal strWhere As String, ByVal strCollumn As String, ByVal strOrder As String) As String
            Dim sSQL As String

            If strCollumn = "" Then
                sSQL = "SELECT *"
            Else
                sSQL = "SELECT " & strCollumn
            End If
            sSQL = sSQL & " FROM " & tableName()
            If strWhere <> "" Then
                sSQL = sSQL & " WHERE " & strWhere
            End If

            If strOrder <> "" Then
                sSQL = sSQL & " ORDER BY " & strOrder
            End If

            Return sSQL

        End Function

        ''' <summary>
        ''' สร้างเงือนไขการค้นหาตาม Primary Key
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Overloads Function makeWhere() As String
            Dim sWhere As String
            Dim aKeys() As String
            Dim i, n As Integer
            Dim sKey As String = Key()

            If sKey = "" Then
                Return ""
            End If

            aKeys = sKey.Split(",")
            n = aKeys.Length()
            sWhere = ""
            For i = 0 To n - 1
                If i > 0 Then
                    sWhere = sWhere & " AND "
                End If
                
                sWhere = sWhere & "(" & fieldName(aKeys(i)) & "=" & CallByName(Me, Trim(aKeys(i)), CallType.Get) & ")"
            Next
            Return sWhere
        End Function

        ''' <summary>
        ''' สร้างเงือนไขการค้นหาตาม Primary Key
        ''' </summary>
        ''' <param name="sWhere">เงือนไขที่ได้สำหรับการ Where</param>
        ''' <param name="pParam">Parameter ที่จำเป็นในการ Where</param>
        ''' <returns>True : OK , False : Create Where Error</returns>
        ''' <remarks></remarks>
        Private Overloads Function makeWhere(ByRef sWhere As String, ByRef pParam As Hashtable) As Boolean
            Dim aKeys() As String
            Dim i, n As Integer
            Dim sKey As String = Key()

            'Clear Old Parameter
            pParam = New Hashtable
            pParam.Clear()

            If sKey = "" Then
                sWhere = ""
                Return True
            End If

            aKeys = sKey.Split(",")
            n = aKeys.Length()
            sWhere = ""
            For i = 0 To n - 1
                If i > 0 Then
                    sWhere = sWhere & " AND "
                End If
                sWhere = sWhere & "(" & fieldName(aKeys(i)) & "= ?)" '& fieldName(aKeys(i)) & "
                pParam.Add(fieldName(aKeys(i)), CallByName(Me, Trim(aKeys(i)), CallType.Get))
            Next
            Return True
        End Function
#End Region

    End Class
End Namespace