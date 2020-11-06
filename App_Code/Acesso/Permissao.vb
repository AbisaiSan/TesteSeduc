Imports Microsoft.VisualBasic

Public Class Permissao
    Private Liberado_ As Integer

    Public Property Liberado() As Integer
        Get
            Return Liberado_
        End Get
        Set(ByVal Value As Integer)
            Liberado_ = Value
        End Set
    End Property
    'Meramente Ilustrativo
    Public Function Funcionalidade(ByVal CodigoUsuario As Integer, ByVal CodigoFuncionalidade As Integer) As Integer
        If CodigoUsuario <> Nothing And CodigoFuncionalidade <> Nothing Then
            Return 1
        End If
        Return 0
    End Function
    'Meramente Ilustrativo
    Public Function ObterPerfil(ByVal CodigoUsuario As Integer, ByVal CodigoFuncionalidade As Integer) As Integer
        If CodigoUsuario <> Nothing And CodigoFuncionalidade <> Nothing Then
            Return 1
        End If
        Return 0
    End Function
End Class
