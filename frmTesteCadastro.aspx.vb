Enum ColunasGrid_grdDocumento As Integer
    Selecionar
    ID_ALUNO
    buttons
End Enum
Partial Class frmTesteCadastro

    Inherits System.Web.UI.Page
    'Var global para obter codigo aqui'
    Public Shared CODIGO As Integer
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
        Validacao.Outros(txtCPFMae, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(txtCPFPai, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(numRG, False, "CPF",, Validacao.eFormato.RG)
        Validacao.Outros(numResponsavel, False, "CPF",, Validacao.eFormato.CELULAR)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)


    End Sub



#Region "Funções de Cadastro"
    Private Function VerificarRg() As Boolean
        Dim objDocumento As New Documentos 'aqui deve sr '
        Dim Existe As Boolean = False

        With objDocumento.Pesquisar(,,,,,,,, numRG.Text)
            If .Rows.Count > 0 Then
                MsgBox("RG já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objDocumento = Nothing
        Return Existe
    End Function

    Private Sub LimparCampos()

        txtCPFMae.Text = ""
        txtCPFPai.Text = ""
        numRG.Text = ""
        numResponsavel.Text = ""
        dataemissaoRg.Text = ""
        DropDownList1.Text = ""
        DataNascimento.Text = ""


        DropDownList1.ClearSelection()

    End Sub

    Private Sub Salvar()
        Dim objDocumento As New Documentos(ViewState("Codigo"))
        With objDocumento
            .Codigo = CODIGO
            .RgAluno = numRG.Text
            If VerificarRg() = True Then
                Exit Sub
            End If
            .EmissaoRgAluno = Date.Parse(dataemissaoRg.Text)
            .SexoAluno = Convert.ToChar(DropDownList1.Text)
            .DataNascimentoAluno = Date.Parse(DataNascimento.Text)
            .NomeMae = TextBox1.Text
            .CPFMae = txtCPFMae.Text
            .NomePai = TextBox2.Text
            .CPFPai = txtCPFPai.Text
            .TelefoneResponsavel = numResponsavel.Text
            .Cadastro = DateAndTime.Now

            .Salvar()
        End With
        objDocumento = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoAluno As Integer)
        Dim objDocumento As New Documentos

        If objDocumento.Excluir(CodigoAluno) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objDocumento = Nothing

        LimparCampos()
        CarregarGrid()
    End Sub

    'cod'
    Private Sub Obter(ByVal CodigoAluno As Integer)
        Dim objDocumento As New Documentos

        CODIGO = CodigoAluno

        objDocumento = Nothing

        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub Voltar()
        Response.Redirect(Request.Url.ToString)

        LimparCampos()
    End Sub

#End Region


#Region "Eventos de Cadastro"
    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub

#End Region

#Region "Funções de Listagem"
    Private Sub CarregarGrid()
        Dim objDocumento As New Aluno

        grdDocumento.DataSource = objDocumento.Pesquisar(ViewState("OrderBy"))
        grdDocumento.DataBind()

        objDocumento = Nothing

        lblRegistros.Text = DirectCast(grdDocumento.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"

    Protected Sub grdDocumento_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDocumento.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdDocumento.DataKeys(e.CommandArgument).Item(0))
        ElseIf e.CommandName = "CARREGAR" Then
            Obter(e.CommandArgument)
        End If
    End Sub

    'o QUE SERIA ESSE grdTurma_PageIndexChanging?'
    Private Sub grdTurma_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDocumento.PageIndexChanging
        grdDocumento.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Private Sub grdTurma_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdDocumento.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Private Sub grdDocumento_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDocumento.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow

                Dim lnkExcluirAluno As New LinkButton
                lnkExcluirAluno = DirectCast(e.Row.Cells(ColunasGrid_grdDocumento.buttons).FindControl("lnkExcluirAluno"), LinkButton)
                lnkExcluirAluno.CommandArgument = e.Row.RowIndex
                lnkExcluirAluno = Nothing

        End Select
    End Sub



#End Region
End Class
