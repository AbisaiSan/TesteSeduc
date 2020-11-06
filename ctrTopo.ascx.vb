
Partial Class NewExtranet_ctrTopo
    Inherits System.Web.UI.UserControl

    Protected Sub NewExtranet_ctrTopo_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        End If

    End Sub

    Protected Sub Sair()
        Session.Abandon()
        Response.Redirect("http://www.google.com.br")
    End Sub


End Class
