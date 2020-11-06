

Public Class Utilidades

    Public Shared Function CPF_Valido(ByVal CPF As String) As Boolean
        Dim dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim

        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 14 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next

        'remove a maskara
        CPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12)

        For x = 0 To 1
            n1 = 0

            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next

            n2 = 11 - (n1 - (Int(n1 / 11) * 11))

            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Shared Function CNPJ_Valido(ByVal CNPJ As String) As Boolean
        Dim dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
        Dim ii As Integer

        '1º passo
        CNPJ = CNPJ.Trim
        For ii = 0 To dadosArray.Length - 1
            If CNPJ.Length <> 18 Or dadosArray(ii).Equals(CNPJ) Then
                Return False
            End If
        Next
        'remove a maskara
        CNPJ = CNPJ.Substring(0, 2) + CNPJ.Substring(3, 3) + CNPJ.Substring(7, 3) + CNPJ.Substring(11, 4) + CNPJ.Substring(16)


        '2º passo 
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim resultado1 As Integer
        Dim resultado2 As Integer
        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(CNPJ.Substring(i, 1))
        Next
        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + _
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + _
                         Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Public Shared Function DataCompleta(ByVal dteData As Date, Optional ByVal Cidade As String = "") As String
        Dim strMes As String

        Select Case Month(dteData)
            Case 1
                strMes = "Janeiro"
            Case 2
                strMes = "Fevereiro"
            Case 3
                strMes = "Março"
            Case 4
                strMes = "Abril"
            Case 5
                strMes = "Maio"
            Case 6
                strMes = "Junho"
            Case 7
                strMes = "Julho"
            Case 8
                strMes = "Agosto"
            Case 9
                strMes = "Setembro"
            Case 10
                strMes = "Outubro"
            Case 11
                strMes = "Novembro"
            Case 12
                strMes = "Dezembro"
            Case Else

                strMes = ""

        End Select

        Return IIf(Cidade <> "", Cidade & ", ", "") & Day(dteData) & " de " & strMes & " de " & Year(dteData)

    End Function

    Public Shared Function Meses(Optional ByVal PrimeiroItem As String = "") As Data.DataTable
        Dim dtMeses As New Data.DataTable
        Dim drMeses As Data.DataRow

        dtMeses.Columns.Add("CODIGO")
        dtMeses.Columns.Add("DESCRICAO")

        drMeses = dtMeses.NewRow
        drMeses("CODIGO") = ""
        drMeses("DESCRICAO") = PrimeiroItem
        dtMeses.Rows.Add(drMeses)

        For x = 1 To 12
            drMeses = dtMeses.NewRow
            drMeses("CODIGO") = x
            Select Case x
                Case 1
                    drMeses("DESCRICAO") = "JANEIRO"
                Case 2
                    drMeses("DESCRICAO") = "FEVEREIRO"
                Case 3
                    drMeses("DESCRICAO") = "MARÇO"
                Case 4
                    drMeses("DESCRICAO") = "ABRIL"
                Case 5
                    drMeses("DESCRICAO") = "MAIO"
                Case 6
                    drMeses("DESCRICAO") = "JUNHO"
                Case 7
                    drMeses("DESCRICAO") = "JULHO"
                Case 8
                    drMeses("DESCRICAO") = "AGOSTO"
                Case 9
                    drMeses("DESCRICAO") = "SETEMBRO"
                Case 10
                    drMeses("DESCRICAO") = "OUTUBRO"
                Case 11
                    drMeses("DESCRICAO") = "NOVEMBRO"
                Case 12
                    drMeses("DESCRICAO") = "DEZEMBRO"
            End Select
            dtMeses.Rows.Add(drMeses)
        Next

        Return dtMeses
    End Function

    Public Shared Sub DownloadFile_Rem(ByVal Sender As Object, ByVal fname As String, ByVal dname As String, ByVal forceDownload As Boolean, Optional ByVal Type As String = "")
        Dim fullpath As String = System.IO.Path.GetFullPath(fname)
        Dim name As String = System.IO.Path.GetFileName(fullpath)
        Dim ext As String = System.IO.Path.GetExtension(fullpath)

        If Not IsDBNull(ext) Then
            ext = LCase(ext)
        End If

        If Type = "" Then
            Select Case ext
                Case ".htm", ".html"
                    Type = "text/HTML"
                Case ".txt"
                    Type = "text/plain"
                Case ".doc", ".rtf"
                    Type = "Application/msword"
                Case ".csv", ".xls"
                    Type = "Application/x-msexcel"
                Case ".pdf"
                    Type = "application/pdf"
                Case Else
                    Type = "text/plain"
            End Select
        End If

        If (forceDownload) Then
            Sender.Response.AppendHeader("content-disposition", "attachment; filename=" + dname)
        End If

        If Type <> "" Then
            Sender.Response.ContentType = Type
        End If

        Sender.Response.WriteFile(fullpath)
        Sender.Response.End()

    End Sub

    Public Shared Sub DownloadFile(ByVal CaminhoOrigem As String, ByVal NomeDestino As String)

        Dim executingPage As Object = HttpContext.Current.Handler
        Dim fullpath As String = System.IO.Path.GetFullPath(CaminhoOrigem)
        Dim name As String = System.IO.Path.GetFileName(fullpath)
        Dim ext As String = System.IO.Path.GetExtension(fullpath).ToLower
        Dim Type As String = ""

        Select Case ext
            Case ".htm", ".html"
                Type = "text/HTML"
            Case ".txt"
                Type = "text/plain"
            Case ".doc", ".rtf"
                Type = "Application/msword"
            Case ".csv", ".xls"
                Type = "Application/x-msexcel"
            Case ".pdf"
                Type = "application/pdf"
            Case Else
                Type = "text/plain"
        End Select

        Try
            executingPage.Response.AppendHeader("content-disposition", "attachment; filename=" + NomeDestino)
            executingPage.Response.ContentType = Type
            executingPage.Response.WriteFile(fullpath)
            executingPage.Response.End()

        Catch
            MsgBox("Arquivo não Encontrado!")
        End Try

    End Sub

    Public Shared Function SenhaRandomica(Optional ByVal Tamanho As Integer = 6, Optional ByVal UsarLetras As Boolean = True, Optional ByVal UsarNumeros As Boolean = True) As String
        'a - z = 97 - 122
        '0 - 9 = 48 - 57
        Dim x As String

        SenhaRandomica = ""

        If UsarLetras = False And UsarNumeros = False Then
            Return SenhaRandomica
        End If

        While Len(SenhaRandomica) < Tamanho
            Randomize()
            'Int((Rnd * (Maximo * 1000) - 1) / 1000) + 1
            x = CInt(Rnd() * 1000)
            If (x >= 48 And x <= 57 And UsarNumeros = True) Or (x >= 97 And x <= 122 And UsarLetras = True) Then
                SenhaRandomica = SenhaRandomica & Chr(x)
            End If
        End While
    End Function

    Public Shared Function ObterAtributoStringConexao(ByVal StringConexao As String, ByVal Atributo As String) As String
        Return Mid(Mid(StringConexao, InStr(StringConexao, Atributo, Microsoft.VisualBasic.CompareMethod.Text), InStr(InStr(StringConexao, Atributo, Microsoft.VisualBasic.CompareMethod.Text), StringConexao, ";", Microsoft.VisualBasic.CompareMethod.Text) - InStr(StringConexao, Atributo, Microsoft.VisualBasic.CompareMethod.Text)), Len(Atributo) + 2)
    End Function

    Public Shared Function ObterImagemExtensaoArquivo(ByVal ContentType As String) As String
        Dim Extensao As String = "default"

        Select Case ContentType
            Case "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/msword", "application/octet-stream"
                Extensao = "doc"
            Case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel"
                Extensao = "xls"
            Case "application/vnd.openxmlformats-officedocument.presentationml.presentation", "application/vnd.ms-powerpoint"
                Extensao = "ppt"
            Case "application/pdf"
                Extensao = "pdf"
                'Case "application/octet-stream"
                '    Extensao = "zip"
            Case "application/x-zip-compressed"
                Extensao = "zip"
            Case "application/octet-stream"
                Extensao = "rar"
            Case "application/octet-stream"
                Extensao = "rar"
            Case "image/pjpeg"
                Extensao = "jpg"
            Case "video/x-ms-wmv", "video/mpeg"
                Extensao = "mp3"
        End Select

        Return String.Format("<img src=""Imagens/Icones/{0}.gif"" />", Extensao)
    End Function

    Public Shared Function ObterTamanhoArquivo(ByVal TamanhoBytes As Integer) As String
        Dim Tamanho As Double = TamanhoBytes

        'Tamanho em Kb
        Tamanho = Tamanho / 1024

        If Tamanho > 1000 Then
            'Tamanho em Mb
            Tamanho = Tamanho / 1024
            Return Tamanho.ToString("0.00") & "Mb"
        Else
            Return Tamanho.ToString("0.00") & "Kb"

        End If

    End Function

    Public Shared Function ImageResize(ByVal image As System.Drawing.Image, ByVal width As Int32, ByVal height As Int32) As System.Drawing.Image
        Dim bitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(width, height, image.PixelFormat)
        If bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Format1bppIndexed Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Format4bppIndexed Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Format8bppIndexed Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Undefined Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.DontCare Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Format16bppArgb1555 Or _
            bitmap.PixelFormat = Drawing.Imaging.PixelFormat.Format16bppGrayScale Then
            'More Info http://msdn.microsoft.com/library/default.asp?_   
            'url=/library/en-us/cpref/html/frlrfSystemDrawingGraphicsClassFromImageTopic.asp   
            Throw New NotSupportedException("Pixel format of the image is not supported.")
        End If
        Dim graphicsImage As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
        graphicsImage.SmoothingMode = Drawing.Drawing2D.SmoothingMode.HighQuality
        graphicsImage.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        graphicsImage.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height)
        graphicsImage.Dispose()
        Return bitmap
    End Function

    Public Shared Function DataAtual() As DateTime
        Return (New Conexao).AbrirDataTable("Select DATA=GetDate()").Rows(0)("DATA")
    End Function

End Class