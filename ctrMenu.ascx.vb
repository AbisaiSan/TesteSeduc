
Partial Class NewExtranet_ctrMenu
    Inherits System.Web.UI.UserControl
    Dim blnParaTestar As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste"))

    Protected Sub NewExtranet_ctrMenu_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        End If

    End Sub

    Protected Sub lnkSair_Click(sender As Object, e As EventArgs) Handles lnkSair.Click
        Response.Redirect("http://www.google.com.br")
    End Sub
End Class
