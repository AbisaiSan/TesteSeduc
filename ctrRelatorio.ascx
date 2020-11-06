<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrRelatorio.ascx.vb" Inherits="ctrRelatorio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Label ID="lblModalRelatorio" runat="server" Text="" />

<cc1:ModalPopupExtender ID="mpeModal" runat="server" PopupControlID="pnlRelatorio" TargetControlID="lblModalRelatorio" BackgroundCssClass="modalBackground" />                

<asp:Panel ID="pnlRelatorio" runat="server" CssClass="modalPanel" style="display:none;">
    <div class="modal-dialog modal-md">
        <div class="modal-content teste">
            <div class="modal-header">
                <h4 class="modal-title"><asp:Label ID="lblTitulo" runat="server" /></h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group col-sm-12 text-center">
                        <br />
                            <asp:HyperLink ID="lnkVisualizar" runat="server" CssClass="btn btn-primary" Target="_blank"><span class="fa fa-eye"></span> Visualizar </asp:HyperLink>
                            <asp:LinkButton ID="lbtDownload" runat="Server" CssClass="btn btn-primary"><span class="fa fa-save"></span> Salvar </asp:LinkButton>
                            <asp:LinkButton ID="lbtFechar" runat="Server" CssClass="btn btn-primary"><span class="fa fa-mail-reply"></span> Voltar </asp:LinkButton>
                        <br />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <div class="row">
                    <div class="form-group col-sm-12 text-left">
                        É necessário ter instalado no dispositivo um aplicativo para leitura de arquivos pdf
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>