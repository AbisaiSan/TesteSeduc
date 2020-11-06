Imports System.Data

Public Module Formulario

    Public Enum eTipoAcesso As Short
        LEITURA = 1
        ESCRITA = 2
    End Enum

    Public Enum eMaterial As Short
        UNIDADE = 1
        KIT = 4
    End Enum


    Public Enum eTipoNivel As Short
        FUNDAMENTAL = 1
        MEDIO = 2
        MEDIO_E_FUNDAMENTAL = 3
        INDIGENA = 4
        QUILOMBOLA = 5
        FUNDAMENTAL_EJA = 6
        MEDIO_EJA = 7
    End Enum

    Public Enum eGrupoEscola As Short
        REGULAR = 1
        INDIGENA = 2
        QUILOMBOLA = 3
        CASA_FAM_RURAL = 4
        CASA_FAM_AGRICOLA = 5
    End Enum

    'Public Sub CarregarComboTabela(ByRef Controle As Object, ByRef objClasse As Object, Optional ByVal PrimeiroItem As String = "")
    '    With Controle
    '        .DataValueField = "CODIGO"
    '        .DataTextField = "DESCRICAO"

    '        .DataSource = objClasse.ObterTabela()
    '        .DataBind()

    '        If TypeOf Controle Is DropDownList Then
    '            .Items.Insert(0, New ListItem(PrimeiroItem, 0))
    '        End If
    '    End With

    '    'objClasse.Encerrar()
    '    objClasse = Nothing
    'End Sub

    Public Sub CarregarComboTabela(ByRef Controle As Object, ByRef objClasse As Object, _
                                   Optional ByVal PrimeiroItem As String = "", Optional ByVal CondicaoDeBusca As String = "")
        With Controle
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"

            If CondicaoDeBusca <> "" Then
                .DataSource = objClasse.ObterTabela(CondicaoDeBusca)
            Else
                .DataSource = objClasse.ObterTabela()
            End If

            .DataBind()

            If TypeOf Controle Is DropDownList Then
                .Items.Insert(0, New ListItem(PrimeiroItem, 0))
            End If
        End With

        'objClasse.Encerrar()
        objClasse = Nothing
    End Sub

    Public Sub CarregarComboTabelaRelacionada(ByRef Controle As Object, ByRef objClasse As Object, _
                                              ByVal CodigoChave As Integer, Optional ByVal PrimeiroItem As String = "", _
                                              Optional ByVal OutroParametro As Boolean = False)
        With Controle
            .DataValueField = "CODIGO"
            .DataTextField = "DESCRICAO"

            If OutroParametro = True Then
                .datasource = objClasse.ObterTabelaParametro(CodigoChave)
            Else
                .DataSource = objClasse.ObterTabela(CodigoChave)
            End If

            .DataBind()

            If TypeOf Controle Is DropDownList Then
                .Items.Insert(0, New ListItem(PrimeiroItem, 0))
            End If
        End With

    End Sub

    Public Sub CarregarComboSimNao(ByVal Controle As Object, Optional ByVal ValorPadrao As String = "-1", Optional ByVal ValorSim As String = "1", Optional ByVal ValorNao As String = "0")
        With Controle
            .Items.Add(New ListItem("SIM", ValorSim))
            .Items.Add(New ListItem("NÃO", ValorNao))

            If TypeOf Controle Is DropDownList Then
                .Items.Insert(0, New ListItem("", ValorPadrao))
            End If
        End With
    End Sub

    Public Sub SelecionarCombo(ByRef Controle As Object, ByVal Codigo As Object, Optional ByVal PesquisarPorTexto As Boolean = False)
        Controle.ClearSelection()
        If Not PesquisarPorTexto Then
            If Not Controle.Items.FindByValue(Codigo) Is Nothing Then
                Controle.Items.FindByValue(Codigo).Selected = True
            End If
        Else
            If Not Controle.Items.FindByText(Codigo) Is Nothing Then
                Controle.Items.FindByText(Codigo).Selected = True
            End If
        End If
    End Sub

    Public Sub SelecionarComboRelacionado(ByRef Controle As Object, ByRef ControlePai As Object, ByRef objClasse As Object, ByRef PropriedadeClassePai As String, ByRef Codigo As Integer, Optional ByVal PesquisarPorTexto As Boolean = False)
        objClasse.Obter(Codigo)

        SelecionarCombo(ControlePai, CallByName(objClasse, PropriedadeClassePai, CallType.Method), PesquisarPorTexto)
        CarregarComboTabelaRelacionada(Controle, objClasse, CallByName(objClasse, PropriedadeClassePai, CallType.Method))
        SelecionarCombo(Controle, Codigo, PesquisarPorTexto)

        'objClasse.Encerrar()
        objClasse = Nothing
    End Sub

    Public Function ObterRegistroRelacionado(ByVal objClasse As Object, ByVal objClassePai As Object, ByVal PropriedadeChave As String, ByVal PropriedadeRetorno As String, ByVal PropriedadeRetornoPai As String, ByVal Codigo As Integer) As String
        Dim strRetorno As String

        If Codigo <= 0 Then
            Return ""
        End If

        objClasse.Obter(Codigo)
        objClassePai.Obter(CallByName(objClasse, PropriedadeChave, CallType.Method))

        strRetorno = CallByName(objClasse, PropriedadeRetorno, CallType.Method) & " - " & CallByName(objClassePai, PropriedadeRetornoPai, CallType.Method)

        'objClasse.Encerrar()
        objClasse = Nothing

        objClassePai.Encerrar()
        objClassePai = Nothing

        Return strRetorno
    End Function

    Public Sub ObterCheckListBox(ByRef Controle As Object, ByRef objClasse As Object, ByRef Codigo As Integer)
        Controle.ClearSelection()

        For Each Item As ListItem In Controle.Items
            Item.Selected = objClasse.Obter(Codigo, Item.Value)
        Next

        'objClasse.Encerrar()
        objClasse = Nothing
    End Sub

    Public Sub SalvarCheckListBox(ByRef Controle As Object, ByRef objClasse As Object, ByRef Codigo As Integer)
        For Each Item As ListItem In Controle.Items
            If Item.Selected Then
                objClasse.Salvar(Codigo, Item.Value)
            Else
                objClasse.Excluir(Codigo, Item.Value)
            End If
        Next

        'objClasse.Encerrar()
        objClasse = Nothing
    End Sub

    Public Enum eTipoValor As Short
        CHAVE = 0
        DATA = 1
        TEXTO = 2
        NUMERO_INTEIRO = 3
        NUMERO_DECIMAL = 4
        DATA_COMPLETA = 5
        BOOLEANO = 6
        TEXTO_LIVRE = 7
        MONETARIO = 8
        BOOLEANO_NULO = 9
    End Enum

    Public Function ProBanco(ByRef Valor As Object, ByVal TipoValor As eTipoValor) As Object
        Dim Campo As Object = Nothing

        Select Case TipoValor
            Case eTipoValor.CHAVE
                If Valor > 0 Then
                    Campo = Valor
                Else
                    Campo = DBNull.Value
                End If
            Case eTipoValor.DATA, eTipoValor.DATA_COMPLETA
                If IsDate(Valor) Then
                    Campo = Convert.ToDateTime(Valor)
                Else
                    Campo = DBNull.Value
                End If
            Case eTipoValor.TEXTO
                If Valor <> "" Then
                    Campo = RemoverAcento(Valor.ToString.ToUpper.Trim.Replace("  ", " "))
                Else
                    Campo = ""
                End If
            Case eTipoValor.TEXTO_LIVRE
                If Valor <> "" Then
                    Campo = Valor
                Else
                    Campo = ""
                End If
            Case eTipoValor.NUMERO_INTEIRO
                If IsNumeric(Valor) Then
                    Campo = Convert.ToInt64(Valor)
                Else
                    Campo = DBNull.Value
                End If
            Case eTipoValor.NUMERO_DECIMAL
                If IsNumeric(Valor) Then
                    Campo = Convert.ToDouble(Valor)
                Else
                    Campo = DBNull.Value
                End If
            Case eTipoValor.MONETARIO
                If IsNumeric(Replace(Valor, ".", "")) Then
                    Campo = Convert.ToDouble(Replace(Valor, ".", ""))
                Else
                    Campo = DBNull.Value
                End If
            Case eTipoValor.BOOLEANO
                Campo = Convert.ToBoolean(Valor)
            Case eTipoValor.BOOLEANO_NULO
                If Valor = vbNull Then
                    Campo = DBNull.Value
                Else
                    Campo = Convert.ToBoolean(Valor)
                End If
        End Select

        Return Campo
    End Function

    Public Function DoBanco(ByRef Campo As Object, ByVal TipoValor As eTipoValor) As Object
        Dim Valor As Object = Nothing

        Select Case TipoValor
            Case eTipoValor.CHAVE
                If Not IsDBNull(Campo) Then
                    Valor = Campo
                Else
                    Valor = 0
                End If
            Case eTipoValor.DATA
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToDateTime(Campo).ToString("dd/MM/yyyy")
                Else
                    Valor = ""
                End If
            Case eTipoValor.DATA_COMPLETA
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToDateTime(Campo).ToString("dd/MM/yyyy HH:mm:ss")
                Else
                    Valor = ""
                End If
            Case eTipoValor.TEXTO, eTipoValor.TEXTO_LIVRE
                If Not IsDBNull(Campo) Then
                    Valor = Campo
                Else
                    Valor = ""
                End If
            Case eTipoValor.NUMERO_INTEIRO
                If Not IsDBNull(Campo) Then
                    Valor = Campo
                Else
                    Valor = ""
                End If
            Case eTipoValor.NUMERO_DECIMAL
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToDouble(Campo).ToString("#0.00")
                Else
                    Valor = ""
                End If
            Case eTipoValor.MONETARIO
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToDouble(Campo).ToString("#0.00")
                Else
                    Valor = ""
                End If
            Case eTipoValor.BOOLEANO
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToBoolean(Campo)
                Else
                    Valor = False
                End If
            Case eTipoValor.BOOLEANO_NULO
                If Not IsDBNull(Campo) Then
                    Valor = Convert.ToBoolean(Campo)
                Else
                    Valor = vbNull
                End If

        End Select

        Return Valor
    End Function

    Public Function RemoverAcento(ByVal Palavra As String, Optional ByVal ApenasAZ As Boolean = False) As String
        Dim Antes As String = "ÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÑÒÓÔÕÖÙÚÛÜÝàáâãäåçèéêëìíîïñòóôõöùúûüýÿ"
        Dim Depois As String = "AAAAAACEEEEIIIINOOOOOUUUUYaaaaaaceeeeiiiinooooouuuuuu"
        Dim SemAcento As String = ""

        For x As Integer = 0 To Antes.Length - 1
            Palavra = Palavra.Replace(Antes.Substring(x, 1), Depois.Substring(x, 1))
        Next

        Palavra = LTrim(RTrim((Palavra)))

        Palavra = Replace(Palavra, "  ", " ")
        Palavra = Replace(Palavra, "'", "%")
        Palavra = UCase(Palavra)

        If ApenasAZ Then
            'O que não for de A a Z, remove
            For x As Integer = 0 To Palavra.Length - 1
                If (Asc(Palavra.Substring(x, 1)) >= 65 And Asc(Palavra.Substring(x, 1)) <= 90) Or Asc(Palavra.Substring(x, 1)) = 32 Then
                    SemAcento += Palavra.Substring(x, 1)
                End If
            Next
        Else
            SemAcento = Palavra
        End If

        Return SemAcento
    End Function

    Public Sub ExibirRelatorio(ByVal NomeRelatorio As String, ByVal FiltroRelatorio As String, Optional ByVal ParametroNome As String = "", Optional ByVal ParametroValor As String = "", Optional ByVal ParametroNumeroAno As String = "", Optional ByVal ParametroAno As String = "")
        HttpContext.Current.Session("NomeRelatorio") = NomeRelatorio
        HttpContext.Current.Session("FiltroRelatorio") = FiltroRelatorio
        If ParametroNome <> "" Then
            HttpContext.Current.Session("ParametroNome") = ParametroNome
        End If

        If ParametroValor <> "" Then
            HttpContext.Current.Session("ParametroValor") = ParametroValor
        End If

        If ParametroNumeroAno <> "" Then
            HttpContext.Current.Session("ParametroNumeroAno") = ParametroNumeroAno
        End If

        If ParametroAno <> "" Then
            HttpContext.Current.Session("ParametroAno") = ParametroAno
        End If

        JavaScript.DoPostBack()
    End Sub

    Public Sub ExibirDownload(ByVal NomeArquivo As String)
        HttpContext.Current.Session("NomeArquivo") = NomeArquivo
        JavaScript.DoPostBack()
    End Sub

    Public Function ValidarTexto(ByVal Controle As TextBox, ByVal Descricao As String) As Boolean
        If RemoverAcento(Controle.Text) = "" Then
            MsgBox("Campo " & Descricao & " Obrigatório!")
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ValidarData(ByVal Controle As TextBox, ByVal Descricao As String) As Boolean
        If Not ValidarTexto(Controle, Descricao) Then
            Return False
        End If

        If Not IsDate(Controle.Text.Trim) Then
            MsgBox("Campo " & Descricao & " Incorreto!")
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ValidarNumero(ByVal Controle As TextBox, ByVal Descricao As String) As Boolean
        If Not ValidarTexto(Controle, Descricao) Then
            Return False
        End If

        If Not IsNumeric(Controle.Text.Trim) Then
            MsgBox("Campo " & Descricao & " Incorreto!")
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ValidarCombo(ByVal Controle As DropDownList, ByVal Descricao As String) As Boolean
        If Controle.SelectedIndex <= 0 Then
            MsgBox("Campo " & Descricao & " Obrigatório!")
            Return False
        End If

        If Controle.SelectedValue = "0" Then
            MsgBox("Campo " & Descricao & " Obrigatório!")
            Return False
        Else
            Return True
        End If
    End Function

    Public Enum eTipoProdutor As Short
        REPRESENTANTE_FORMAL = 1
        REPRESENTANTE_INFORMAL = 2
        FORNECEDOR_PARTICIPANTE = 3
        FORNECEDOR_INDIVIDUAL = 4
    End Enum

End Module
