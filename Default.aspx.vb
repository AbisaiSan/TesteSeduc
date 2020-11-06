Enum ColunasGrid_grdAluno As Integer
    Selecionar
    ID_ALUNO
    buttons
End Enum
Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
        Validacao.Outros(txtCPF, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(txtTelefone, False, "CPF",, Validacao.eFormato.CELULAR)
        Validacao.Outros(txtCEP, False, "CPF",, Validacao.eFormato.CEP)
        Validacao.Outros(txtEmail, False, "CPF",, Validacao.eFormato.EMAIL)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

#Region "Funções de Cadastro"
    Private Function VerificarCpf() As Boolean
        Dim objAluno As New Aluno
        Dim Existe As Boolean = False

        With objAluno.Pesquisar(,,, Replace(Replace(txtCPF.Text, ".", ""), "-", ""))
            If .Rows.Count > 0 Then
                MsgBox("CPF já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objAluno = Nothing
        Return Existe
    End Function

    Private Sub LimparCampos()

        txtCPF.Text = ""
        txtNome.Text = ""
        txtNacionalidade.Text = ""
        txtNacionalidade.Text = ""
        txtCEP.Text = ""
        txtCidade.Text = ""
        txtLogradouro.Text = ""
        txtEmail.Text = ""
        txtTelefone.Text = ""

        drpEstado.ClearSelection()

        txtNome.Focus()
    End Sub

    Private Sub Salvar()
        Dim objAluno As New Aluno(ViewState("Codigo"))
        With objAluno
            .NomeAluno = Trim(Validacao.RetirarEspacos(txtNome.Text)) + txtSobrenome.Text
            If VerificarCpf() = True Then
                Exit Sub
            End If
            .CPF = Replace(Replace(txtCPF.Text, ".", ""), "-", "")
            .Nacionalidade = txtNacionalidade.Text
            .Cep = Replace(Replace(txtCEP.Text, ".", ""), "-", "")
            .Estado = drpEstado.SelectedValue
            .Cidade = txtCidade.Text
            .Logradouro = txtLogradouro.Text
            .Email = txtEmail.Text
            .Telefone = txtTelefone.Text

            .Salvar()
        End With
        objAluno = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoAluno As Integer)
        Dim objAluno As New Aluno

        If objAluno.Excluir(CodigoAluno) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objAluno = Nothing

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
        Dim objAluno As New Aluno

        grdAluno.DataSource = objAluno.Pesquisar(ViewState("OrderBy"))
        grdAluno.DataBind()

        objAluno = Nothing

        lblRegistros.Text = DirectCast(grdAluno.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"
    Protected Sub grdAluno_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAluno.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdAluno.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub grdTurma_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAluno.PageIndexChanging
        grdAluno.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Private Sub grdTurma_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdAluno.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Private Sub grdAluno_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAluno.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow

                Dim lnkExcluirAluno As New LinkButton
                lnkExcluirAluno = DirectCast(e.Row.Cells(ColunasGrid_grdAluno.buttons).FindControl("lnkExcluirAluno"), LinkButton)
                lnkExcluirAluno.CommandArgument = e.Row.RowIndex
                lnkExcluirAluno = Nothing

        End Select
    End Sub



#End Region
End Class
