
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim blnTeste As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("Teste").ToString)

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Page.IsPostBack Then
            If Not blnTeste Then
                Session("Usuario") = 0
            Else
                Session("Usuario") = 1
            End If

            If Session("Usuario") = 0 Or Session("Usuario") Is Nothing Then
                Session.Abandon()
                Response.Redirect("http://www.google.com.br")
            End If
        End If

    End Sub


End Class

