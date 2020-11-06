<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmTesteCadastro.aspx.vb" Inherits="frmTesteCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">

    </section>
    <section class="content">
           <h4 class="page-header">Teste Formulario Cadastro</h4>
           <div class="box-body">
           
               <div class="row">
                    <div class="col-md-3 ml-md-auto">
                        <div class="form-group">
                            <label for="RG">RG aluno:</label>
                            <asp:TextBox runat="server" required="required" type="text" class="form-control" id="numRG"  name="RG" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>
                    <div class="col-md-3 ml-md-auto">
                        <div class="form-group row">
                              <label for="example-date-input" class="col-2 col-form-label">Data de emissão</label>
                              <div class="col-10">
                               
                                <asp:TextBox runat="server" required="required" class="form-control" type="date" value="2011-08-19" id="dataemissaoRg" name="RG" placeholder="Ex.: 000000000000-0" maxlength="8"/>
                              </div>
                        </div>
                    </div>
                   <div class="col-md-3 ml-md-auto">
                        <div class="form-group">
                            <label for="SEXO_ALUNO">Sexo:</label>
                            <asp:DropDownList runat="server" required="required" id="DropDownList1" class="form-control" name="SEXO_ALUNO">
                                <asp:ListItem value="M">Masculino</asp:ListItem>
                                <asp:ListItem value="F">Feminino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2 ml-md-auto">
                        <div class="form-group row">
                              <label for="date-nascimento" class="col-2 col-form-label">Data de Nascimento</label>
                              <div class="col-10">
                                
                                  <asp:TextBox runat="server" required="required" class="form-control" type="date" value="2011-08-19" id="DataNascimento" name="DataNascimento" placeholder="Ex.: 15/02/1995" maxlength="8"/>
                              </div>
                        </div>
                    </div>
                    
                </div>
               

              <div class="row">
                  <div class="col-md-6">
                        <div class="form-group">
                            <label for="Nome">Nome da Mãe:</label>
                            <asp:TextBox runat="server" required="required" type="text"  class="form-control" id="TextBox1" name="Nome" placeholder="Ex.: Maria Sales Souza" maxlength="50"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="CPF">CPF:</label>
                            <asp:TextBox runat="server" required="required" type="text"  class="form-control" id="txtCPFMae" name="CPF" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>

                </div>

               <div class="row">
                  <div class="col-md-6">
                        <div class="form-group">
                            <label for="Nome">Nome da Pai:</label>
                            <asp:TextBox runat="server"  type="text"  class="form-control" id="TextBox2" name="Nome" placeholder="Ex.: João Gomes Sales Sousa" maxlength="50"/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="CPF">CPF:</label>
                            <asp:TextBox runat="server" type="text"  class="form-control" id="txtCPFPai" name="CPF" placeholder="Ex.: 010.011.111-00" maxlength="14"/>
                        </div>
                    </div>
                </div>

               <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="TELEFONE">Contato do Responsável:</label>
                            <asp:TextBox runat="server"  type="text" class="form-control" id="numResponsavel" name="numResponsavel" placeholder="Ex.: 01011-100" maxlength="8"/>
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
                    <asp:GridView id="grdDocumento" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI01_ID_ALUNO">
	                    <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CI01_ID_ALUNO" SortExpression="CI01_ID_ALUNO" HeaderText="Codigo" />
                            <asp:BoundField DataField="CI01_NM_ALUNO" SortExpression="CI01_NM_ALUNO" HeaderText="Nome"/>
                            <asp:BoundField DataField="CI01_NU_CPF" SortExpression="CI01_NU_CPF" HeaderText="CPF" DataFormatString="{0:###.###.###-##}"/>
		                    <asp:BoundField DataField="CI01_NM_CIDADE" SortExpression="CI01_NM_CIDADE" HeaderText="Cidade"/>
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <asp:LinkButton ID="lnkExcluirAluno" runat="server" class="btn btn-social-icon bg-blue" CommandName="CARREGAR" CommandArgument="CI01_ID_ALUNO" ToolTip="Cadastrar Documentos">
                                            <i id="iExcluirAluno" runat="server" class="fas fa-user-edit"></i>
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
