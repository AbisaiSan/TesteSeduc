<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">

    </section>
    <section class="content">
        <h4 class="page-header">Formulario Cadastro Padrão</h4>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Nome">Nome:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtNome" name="Nome" placeholder="Ex.: João" maxlength="50"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Sobrenome">Sobrenome:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtSobrenome" name="Sobrenome" placeholder="Ex.: da Silva" maxlength="250"/>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="CPF">CPF:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtCPF" name="CPF" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Nacionalidade">Nacionalidade:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtNacionalidade" name="Nacionalidade" placeholder="Ex.: brasileira" maxlength="50" />
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="CEP">CEP:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtCEP" name="CEP" placeholder="Ex.: 01011-100" maxlength="8"/>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="Estado">Estado:</label>
                            <asp:DropDownList runat="server" required="required" id="drpEstado" class="form-control" name="Estado">
                                <asp:ListItem value="">Selecione</asp:ListItem>
                                <asp:ListItem value="MA">Maranhão</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="Cidade">Cidade:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtCidade" name="Cidade" maxlength="50" placeholder="Ex.: São Luis"/>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="Logradouro">Logradouro:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtLogradouro" name="Logradouro" placeholder="Ex.: Rua Boa Vista 253" maxlength="100"/>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Email">E-mail:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtEmail" name="Email" placeholder="Ex.: email@email.com" maxlength="100"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="Telefone">Telefone:</label>
                            <asp:TextBox runat="server" required="required" type="tel" class="form-control" id="txtTelefone" name="Telefone" placeholder="Ex.: (11) 2020-3030" maxlength="15"/>
                        </div>
                    </div>
                </div>
                
        </div>
        <div class="box-footer">
            <div class="col-md-6">
                <asp:Button class="btn btn-primary" runat="server" ID="btnSalvar" Text="Salvar" />
            </div>
        </div>

        <div class="box-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-aqua" />
                    <asp:GridView id="grdAluno" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI01_ID_ALUNO">
	                    <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CI01_ID_ALUNO" SortExpression="CI01_ID_ALUNO" HeaderText="Codigo" />
                            <asp:BoundField DataField="CI01_NM_ALUNO" SortExpression="CI01_NM_ALUNO" HeaderText="Nome"/>
                            <asp:BoundField DataField="CI01_NU_CPF" SortExpression="CI01_NU_CPF" HeaderText="CPF" DataFormatString="{0:###.###.###-##}"/>
		                    <asp:BoundField DataField="CI01_NM_CIDADE" SortExpression="CI01_NM_CIDADE" HeaderText="Cidade"/>
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <asp:LinkButton ID="lnkExcluirAluno" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirAluno">
                                            <i id="iExcluirAluno" runat="server" class="fa fa-mortar-board"></i>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
