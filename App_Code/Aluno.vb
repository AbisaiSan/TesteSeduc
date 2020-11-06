Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text


Public Class Aluno
    Private CI01_ID_ALUNO As Integer
    Private CI01_NM_ALUNO As String
    Private CI01_NU_CPF As String
    Private CI01_NM_NACIONALIDADE As String
    Private CI01_NU_CEP As String
    Private CI01_NU_ESTADO As String
    Private CI01_NM_CIDADE As String
    Private CI01_NM_LOGRADOURO As String
    Private CI01_NM_EMAIL As String
    Private CI01_NU_TELEFONE As String


    Public Property Codigo() As Integer
        Get
            Return CI01_ID_ALUNO
        End Get
        Set(ByVal Value As Integer)
            CI01_ID_ALUNO = Value
        End Set
    End Property

    Public Property NomeAluno() As String
        Get
            Return CI01_NM_ALUNO
        End Get
        Set(ByVal Value As String)
            CI01_NM_ALUNO = Value
        End Set
    End Property

    Public Property CPF() As String
        Get
            Return CI01_NU_CPF
        End Get
        Set(ByVal Value As String)
            CI01_NU_CPF = Value
        End Set
    End Property
    Public Property Nacionalidade() As String
        Get
            Return CI01_NM_NACIONALIDADE
        End Get
        Set(ByVal Value As String)
            CI01_NM_NACIONALIDADE = Value
        End Set
    End Property
    Public Property Cep() As String
        Get
            Return CI01_NU_CEP
        End Get
        Set(ByVal Value As String)
            CI01_NU_CEP = Value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return CI01_NU_ESTADO
        End Get
        Set(ByVal Value As String)
            CI01_NU_ESTADO = Value
        End Set
    End Property
    Public Property Cidade() As String
        Get
            Return CI01_NM_CIDADE
        End Get
        Set(ByVal Value As String)
            CI01_NM_CIDADE = Value
        End Set
    End Property
    Public Property Logradouro() As String
        Get
            Return CI01_NM_LOGRADOURO
        End Get
        Set(ByVal Value As String)
            CI01_NM_LOGRADOURO = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return CI01_NM_EMAIL
        End Get
        Set(ByVal Value As String)
            CI01_NM_EMAIL = Value
        End Set
    End Property
    Public Property Telefone() As String
        Get
            Return CI01_NU_TELEFONE
        End Get
        Set(ByVal Value As String)
            CI01_NU_TELEFONE = Value
        End Set
    End Property

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI01_ALUNO")
        strSQL.Append(" where CI01_ID_ALUNO = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("CI01_ID_ALUNO") = ProBanco(CI01_ID_ALUNO, eTipoValor.CHAVE)
        dr("CI01_NM_ALUNO") = ProBanco(CI01_NM_ALUNO, eTipoValor.TEXTO)
        dr("CI01_NU_CPF") = ProBanco(CI01_NU_CPF, eTipoValor.TEXTO_LIVRE)
        dr("CI01_NM_NACIONALIDADE") = ProBanco(CI01_NM_NACIONALIDADE, eTipoValor.TEXTO)
        dr("CI01_NU_CEP") = ProBanco(CI01_NU_CEP, eTipoValor.TEXTO_LIVRE)
        dr("CI01_NU_ESTADO") = ProBanco(CI01_NU_ESTADO, eTipoValor.TEXTO)
        dr("CI01_NM_CIDADE") = ProBanco(CI01_NM_CIDADE, eTipoValor.TEXTO)
        dr("CI01_NM_LOGRADOURO") = ProBanco(CI01_NM_LOGRADOURO, eTipoValor.TEXTO)
        dr("CI01_NM_EMAIL") = ProBanco(CI01_NM_EMAIL, eTipoValor.TEXTO_LIVRE)
        dr("CI01_NU_TELEFONE") = ProBanco(CI01_NU_TELEFONE, eTipoValor.TEXTO_LIVRE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI01_ALUNO")
        strSQL.Append(" where CI01_ID_ALUNO = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CI01_ID_ALUNO = DoBanco(dr("CI01_ID_ALUNO"), eTipoValor.CHAVE)
            CI01_NM_ALUNO = DoBanco(dr("CI01_NM_ALUNO"), eTipoValor.TEXTO)
            CI01_NU_CPF = DoBanco(dr("CI01_NU_CPF"), eTipoValor.TEXTO_LIVRE)
            CI01_NM_NACIONALIDADE = DoBanco(dr("CI01_NM_NACIONALIDADE"), eTipoValor.TEXTO)
            CI01_NU_CEP = DoBanco(dr("CI01_NU_CEP"), eTipoValor.TEXTO_LIVRE)
            CI01_NU_ESTADO = DoBanco(dr("CI01_NU_ESTADO"), eTipoValor.TEXTO)
            CI01_NM_CIDADE = DoBanco(dr("CI01_NM_CIDADE"), eTipoValor.TEXTO)
            CI01_NM_LOGRADOURO = DoBanco(dr("CI01_NM_LOGRADOURO"), eTipoValor.TEXTO)
            CI01_NM_EMAIL = DoBanco(dr("CI01_NM_EMAIL"), eTipoValor.TEXTO_LIVRE)
            CI01_NU_TELEFONE = DoBanco(dr("CI01_NU_TELEFONE"), eTipoValor.TEXTO_LIVRE)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional ByVal Codigo As Integer = 0,
                              Optional ByVal NomeAluno As String = "",
                              Optional ByVal CPF As String = "",
                              Optional ByVal Nacionalidade As String = "",
                              Optional ByVal Cep As String = "",
                              Optional ByVal Estado As String = "",
                              Optional ByVal Cidade As String = "",
                              Optional ByVal Logradouro As String = "",
                              Optional ByVal Email As String = "",
                              Optional ByVal Telefone As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI01_ALUNO")
        strSQL.Append(" where CI01_ID_ALUNO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and CI01_ID_ALUNO = " & Codigo)
        End If

        If NomeAluno <> "" Then
            strSQL.Append(" and upper(CI01_NM_ALUNO) like '%" & NomeAluno.ToUpper & "%'")
        End If

        If CPF <> "" Then
            strSQL.Append(" and upper(CI01_NU_CPF) like '%" & CPF.ToUpper & "%'")
        End If

        If Nacionalidade <> "" Then
            strSQL.Append(" and upper(CI01_NM_NACIONALIDADE) like '%" & Nacionalidade.ToUpper & "%'")
        End If

        If Cep <> "" Then
            strSQL.Append(" and upper(CI01_NU_CEP) like '%" & Cep.ToUpper & "%'")
        End If

        If Estado <> "" Then
            strSQL.Append(" and upper(CI01_NU_ESTADO) like '%" & Estado.ToUpper & "%'")
        End If

        If Cidade <> "" Then
            strSQL.Append(" and upper(CI01_NM_CIDADE) like '%" & Cidade.ToUpper & "%'")
        End If

        If Logradouro <> "" Then
            strSQL.Append(" and upper(CI01_NM_LOGRADOURO) like '%" & Logradouro.ToUpper & "%'")
        End If

        If Email <> "" Then
            strSQL.Append(" and upper(CI01_NM_EMAIL) like '%" & Email.ToUpper & "%'")
        End If

        If Telefone <> "" Then
            strSQL.Append(" and upper(CI01_NU_TELEFONE) like '%" & Telefone.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CI01_NM_ALUNO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select CI01_ID_ALUNO as CODIGO, CI01_NM_ALUNO as DESCRICAO")
        strSQL.Append(" from CI01_ALUNO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        '
        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(CI01_ID_ALUNO) from CI01_ALUNO")

        With cnn.AbrirDataTable(strSQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                CodigoUltimo = .Rows(0)(0)
            Else
                CodigoUltimo = 0
            End If
        End With

        '
        cnn = Nothing

        Return CodigoUltimo

    End Function

    Public Function Excluir(ByVal Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from CI01_ALUNO")
        strSQL.Append(" where CI01_ID_ALUNO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        '
        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
