Imports Microsoft.VisualBasic

Public Class CrystalReport

    Public Structure ParametroRelatorio
        Public Titulo As String
        Public Valor As String

        Public Sub New(ByVal _Titulo As String, ByVal _Valor As String)
            Titulo = _Titulo
            Valor = _Valor
        End Sub

    End Structure

    Public Shared Function Gerar(NomeRelatorio As String, Filtro As String, Optional Parametros As List(Of ParametroRelatorio) = Nothing, Optional cnn As Object = Nothing) As String
        Dim crReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim LoginBanco As New CrystalDecisions.Shared.TableLogOnInfo
        Dim info As New CrystalDecisions.Shared.ConnectionInfo

        Dim strDataBase As CrystalDecisions.CrystalReports.Engine.Database
        Dim strTabela As CrystalDecisions.CrystalReports.Engine.Table
        Dim strTabelas As CrystalDecisions.CrystalReports.Engine.Tables

        Dim crDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
        Dim crExportOptions As CrystalDecisions.Shared.ExportOptions

        'Dim strStringConexao As String = (New Conexao).ConnectionString
        Dim strStringConexao As String
        If cnn Is Nothing Then
            strStringConexao = (New Conexao).ConnectionString
        Else
            strStringConexao = cnn.ConnectionString
        End If

        Dim strArquivoDestino As String

        Dim Pagina As Page = DirectCast(HttpContext.Current.Handler, Page)

        'strArquivoDestino = "Temp/" & Pagina.Session.SessionID & Now.ToString("ddMMyyyyhhmmss") & ".pdf"
        If Pagina.Session("FormatoRelatorio") = "pdf" Then
            strArquivoDestino = "Temp/" & Pagina.Session.SessionID & Now.ToString("ddMMyyyyhhmmss") & ".pdf"

        ElseIf Pagina.Session("FormatoRelatorio") = "xls" Then
            strArquivoDestino = "Temp/" & Pagina.Session.SessionID & Now.ToString("ddMMyyyyhhmmss") & ".xls"

        ElseIf Pagina.Session("FormatoRelatorio") = "doc" Then
            strArquivoDestino = "Temp/" & Pagina.Session.SessionID & Now.ToString("ddMMyyyyhhmmss") & ".doc"

        Else
            strArquivoDestino = "Temp/" & Pagina.Session.SessionID & Now.ToString("ddMMyyyyhhmmss") & ".pdf"
        End If

        crReportDocument.Load(Pagina.Server.MapPath("Relatorios/" & NomeRelatorio))

        info.DatabaseName = ObterAtributoStringConexao(strStringConexao, "Initial Catalog")
        info.UserID = ObterAtributoStringConexao(strStringConexao, "User id")
        info.Password = ObterAtributoStringConexao(strStringConexao, "Password")
        info.ServerName = ObterAtributoStringConexao(strStringConexao, "Data Source")
        info.IntegratedSecurity = False

        'LogWriteEntry("String de Conexão: [" & strStringConexao & "]")
        'LogWriteEntry("Initial Catalog: [" & info.DatabaseName & "]")
        'LogWriteEntry("UserID: [" & info.UserID & "]")
        'LogWriteEntry("Password: [" & info.Password & "]")
        'LogWriteEntry("ServerName: [" & info.ServerName & "]")

        strDataBase = crReportDocument.Database
        strTabelas = strDataBase.Tables

        'For Each strTabela In strTabelas
        '    LoginBanco = strTabela.LogOnInfo
        '    LoginBanco.ConnectionInfo = info
        '    strTabela.ApplyLogOnInfo(LoginBanco)
        'Next
        'crReportDocument.SetDatabaseLogon(info.UserID, info.Password, info.ServerName, info.DatabaseName)

        For Each strTabela In strTabelas
            Dim TableLogInfo As CrystalDecisions.Shared.TableLogOnInfo = strTabela.LogOnInfo
            TableLogInfo.ConnectionInfo = info
            strTabela.ApplyLogOnInfo(TableLogInfo)
        Next
        crReportDocument.SetDatabaseLogon(info.UserID, info.Password, info.ServerName, info.DatabaseName)

        crReportDocument.RecordSelectionFormula = Filtro
        crExportOptions = crReportDocument.ExportOptions
        'crDiskFileDestinationOptions.DiskFileName = Pagina.Server.MapPath(strArquivoDestino)
        crDiskFileDestinationOptions.DiskFileName = Pagina.Server.MapPath("~/" & strArquivoDestino)

        'LogWriteEntry("caminho do arquivo")
        'LogWriteEntry(crDiskFileDestinationOptions.DiskFileName)

        If Parametros IsNot Nothing Then
            For Each x As ParametroRelatorio In Parametros
                crReportDocument.SetParameterValue(x.Titulo, x.Valor)
            Next
        End If

        With crReportDocument.ExportOptions
            .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            .DestinationOptions = crDiskFileDestinationOptions
            '.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

            If Pagina.Session("FormatoRelatorio") = "pdf" Then
                .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            ElseIf Pagina.Session("FormatoRelatorio") = "xls" Then
                .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.Excel
            ElseIf Pagina.Session("FormatoRelatorio") = "doc" Then
                .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            Else
                .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End With

        Try
            crReportDocument.Export()
            'LogWriteEntry("arquivo gravado com sucesso")

        Catch exp1 As CrystalDecisions.CrystalReports.Engine.LogOnException
            'strErro = exp1.ToString
            'LogWriteEntry("erro na gravação do arquivo")
            'LogWriteEntry(exp1.ToString)

        Finally
            crReportDocument.Close()
            'LogWriteEntry("relatório encerrado")

        End Try

        Return strArquivoDestino 'retorna o pdf local
    End Function

    Private Shared Function ObterAtributoStringConexao(ByVal StringConexao As String, ByVal Atributo As String) As String
        Return Mid(Mid(StringConexao, InStr(StringConexao, Atributo, CompareMethod.Text), InStr(InStr(StringConexao, Atributo, CompareMethod.Text), StringConexao, ";", CompareMethod.Text) - InStr(StringConexao, Atributo, CompareMethod.Text)), Len(Atributo) + 2)
    End Function

    'Private Shared Sub LogWriteEntry(ByVal strMessage As String)
    '    Dim file As System.IO.StreamWriter = New System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Temp/") & "PaineldeGestaoLog.txt", True)

    '    file.WriteLine(Now.ToString & " - " & strMessage)
    '    file.Close()
    'End Sub

End Class
