Public Class dao_Poomse_Score
    Inherits DAO.daoBase

    Public Athlete_Id As Integer
    Public Round As Integer
    Public Final As Double
    Public Acc_1 As Double
    Public Acc_2 As Double
    Public Acc_3 As Double
    Public Acc_4 As Double
    Public Acc_5 As Double
    Public Acc_6 As Double
    Public Acc_7 As Double

    Public Pre_1 As Double
    Public Pre_2 As Double
    Public Pre_3 As Double
    Public Pre_4 As Double
    Public Pre_5 As Double
    Public Pre_6 As Double
    Public Pre_7 As Double

    Public K As Double

    Protected Overrides Function tableName() As String
        Return "Poomse_Score"
    End Function

    Protected Overrides Function Key() As String
        Return "Athlete_Id,Round"
    End Function

End Class
