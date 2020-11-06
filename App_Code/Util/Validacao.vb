Imports Microsoft.VisualBasic
Imports AjaxControlToolkit
Imports System.Web.UI.WebControls

Public Class Validacao

    Private Shared strValidacoes As String = ""

    Public Shared Sub Combo(ByVal Controle As DropDownList, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objCompareValidator As New CompareValidator

        With objCompareValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValueToCompare = "0"
            .Type = ValidationDataType.Integer
            .Operator = ValidationCompareOperator.GreaterThan
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "CompareValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objCompareValidator)
    End Sub

    Public Shared Sub ComboString(ByVal Controle As DropDownList, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objCompareValidator As New CompareValidator

        With objCompareValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValueToCompare = "0"
            .Type = ValidationDataType.String
            .Operator = ValidationCompareOperator.GreaterThan
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "CompareValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objCompareValidator)
    End Sub

    Public Shared Sub ListBox(ByVal Controle As ListBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objCompareValidator As New CompareValidator

        With objCompareValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValueToCompare = "0"
            .Type = ValidationDataType.Integer
            .Operator = ValidationCompareOperator.GreaterThan
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "CompareValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objCompareValidator)
    End Sub

    Public Shared Sub ComboSimNao(ByVal Controle As DropDownList, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objCompareValidator As New CompareValidator

        With objCompareValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValueToCompare = -1
            .Type = ValidationDataType.String
            .Operator = ValidationCompareOperator.GreaterThan
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "CompareValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objCompareValidator)
    End Sub

    Public Shared Sub Radio(ByVal Controle As RadioButtonList, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objCompareValidator As New CompareValidator

        With objCompareValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValueToCompare = ""
            .Type = ValidationDataType.String
            .Operator = ValidationCompareOperator.NotEqual
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "CompareValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objCompareValidator)
    End Sub

    Public Shared Sub Monetario(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal ValorMinimo As String = "0", Optional ByVal ValorMaximo As String = "9999999")
        Dim objMaskedEditExtender As New MaskedEditExtender

        With objMaskedEditExtender
            .TargetControlID = Controle.ID
            .MaskType = MaskedEditType.Number
            .ClearMaskOnLostFocus = True
            .Mask = "99999,99"
            .AutoComplete = True
            .InputDirection = MaskedEditInputDirection.RightToLeft
            .EnableClientState = True
            .EnableViewState = True
            .DisplayMoney = MaskedEditShowSymbol.None

            .ID = "MaskedEditExtender" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditExtender)

        Dim objMaskedEditValidator As New MaskedEditValidator

        With objMaskedEditValidator
            .ControlExtender = objMaskedEditExtender.ID
            .ControlToValidate = Controle.ID

            .InvalidValueMessage = String.Format("Campo {0} Inválido", TituloCampo)
            .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)

            .MinimumValue = ValorMinimo
            .MinimumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, ValorMinimo)

            .MaximumValue = ValorMaximo
            .MaximumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, ValorMaximo)

            If Requerido Then
                .IsValidEmpty = False
                .EmptyValueMessage = String.Format("Campo {0} Requerido", TituloCampo)
            Else
                .IsValidEmpty = True
            End If

            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "MaskedEditValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditValidator)
    End Sub

    Public Shared Sub Livre(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        If Not Requerido Then Exit Sub

        Dim objRequiredFieldValidator As New RequiredFieldValidator

        With objRequiredFieldValidator
            .ControlToValidate = Controle.ID
            .ErrorMessage = String.Format("Campo {0} Requerido", TituloCampo)
            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "RequiredFieldValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objRequiredFieldValidator)
    End Sub

    Public Shared Sub Data(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal DataMinima As String = "01/01/1800", Optional ByVal DataMaxima As String = "31/12/2100")
        Dim objMaskedEditExtender As New MaskedEditExtender

        With objMaskedEditExtender
            .TargetControlID = Controle.ID
            .MaskType = MaskedEditType.Date
            .ClearMaskOnLostFocus = True
            .Mask = "99/99/9999"
            .AutoComplete = False
            .InputDirection = MaskedEditInputDirection.RightToLeft
            .EnableClientState = True
            .EnableViewState = True

            .ID = "MaskedEditExtender" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditExtender)

        Dim objMaskedEditValidator As New MaskedEditValidator

        With objMaskedEditValidator
            .ControlExtender = objMaskedEditExtender.ID
            .ControlToValidate = Controle.ID

            .InvalidValueMessage = String.Format("Campo {0} Inválido", TituloCampo)
            .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)

            .MinimumValue = DataMinima
            .MinimumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, DataMinima)

            .MaximumValue = DataMaxima
            .MaximumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, DataMaxima)

            If Requerido Then
                .IsValidEmpty = False
                .EmptyValueMessage = String.Format("Campo {0} Requerido", TituloCampo)
            Else
                .IsValidEmpty = True
            End If

            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "MaskedEditValidator" & Controle.ID

        End With

        Controle.Parent.Controls.Add(objMaskedEditValidator)
    End Sub

    Public Shared Sub Hora(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao")
        Dim objMaskedEditExtender As New MaskedEditExtender

        With objMaskedEditExtender
            .TargetControlID = Controle.ID
            .MaskType = MaskedEditType.Time
            .ClearMaskOnLostFocus = True
            .Mask = "99:99"
            .AutoComplete = False
            .InputDirection = MaskedEditInputDirection.RightToLeft
            .EnableClientState = True
            .EnableViewState = True

            .ID = "MaskedEditExtender" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditExtender)

        Dim objMaskedEditValidator As New MaskedEditValidator

        With objMaskedEditValidator
            .ControlExtender = objMaskedEditExtender.ID
            .ControlToValidate = Controle.ID

            .InvalidValueMessage = String.Format("Campo {0} Inválido", TituloCampo)
            .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)

            If Requerido Then
                .IsValidEmpty = False
                .EmptyValueMessage = String.Format("Campo {0} Requerido", TituloCampo)
            Else
                .IsValidEmpty = True
            End If

            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "MaskedEditValidator" & Controle.ID

        End With

        Controle.Parent.Controls.Add(objMaskedEditValidator)
    End Sub

    Public Shared Sub Valor(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal Formato As String = "999999", Optional ByVal ValorMinimo As String = "0", Optional ByVal ValorMaximo As String = "999999", Optional ByVal ExibirCifrao As Boolean = False, Optional ByVal ClearMaskOnLostFocus As Boolean = True)
        Dim objMaskedEditExtender As New MaskedEditExtender

        With objMaskedEditExtender
            .TargetControlID = Controle.ID
            .MaskType = MaskedEditType.Number
            .ClearMaskOnLostFocus = ClearMaskOnLostFocus
            .Mask = Formato
            .AutoComplete = False
            .InputDirection = MaskedEditInputDirection.RightToLeft
            .EnableClientState = True
            .EnableViewState = True

            If ExibirCifrao Then
                .DisplayMoney = MaskedEditShowSymbol.Left
            End If

            .ID = "MaskedEditExtender" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditExtender)

        Dim objMaskedEditValidator As New MaskedEditValidator

        With objMaskedEditValidator
            .ControlExtender = objMaskedEditExtender.ID
            .ControlToValidate = Controle.ID

            .InvalidValueMessage = String.Format("Campo {0} Inválido", TituloCampo)
            .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)

            .MinimumValue = ValorMinimo
            .MinimumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, ValorMinimo)

            .MaximumValue = ValorMaximo
            .MaximumValueMessage = String.Format("Campo {0} não pode ser menor que {1}", TituloCampo, ValorMaximo)

            If Requerido Then
                .IsValidEmpty = False
                .EmptyValueMessage = String.Format("Campo {0} Requerido", TituloCampo)
            Else
                .IsValidEmpty = True
            End If

            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "MaskedEditValidator" & Controle.ID
        End With

        Controle.Parent.Controls.Add(objMaskedEditValidator)
    End Sub

    Public Enum eFormato As Short
        CPF = 0
        CNPJ = 1
        TELEFONE = 2
        CEP = 3
        EMAIL = 4
        CELULAR = 5
        RG = 6
    End Enum

    Public Shared Sub Outros(ByVal Controle As TextBox, ByVal Requerido As Boolean, ByVal TituloCampo As String, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal Formato As eFormato = Nothing)
        Dim objMaskedEditExtender As New MaskedEditExtender

        With objMaskedEditExtender
            .TargetControlID = Controle.ID
            .MaskType = MaskedEditType.None
            .ClearMaskOnLostFocus = False

            Select Case Formato
                Case eFormato.CPF
                    .Mask = "999,999,999-99"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='___.___.___-__') document.getElementById('{0}').value='';", Controle.ClientID)

                Case eFormato.RG
                    .Mask = "999999999999"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='____________') document.getElementById('{0}').value='';", Controle.ClientID)

                Case eFormato.CNPJ
                    .Mask = "99,999,999/9999-99"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='__.___.___/____-__') document.getElementById('{0}').value='';", Controle.ClientID)

                Case eFormato.TELEFONE
                    .Mask = "(99)9999-9999"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='(__)____-____') document.getElementById('{0}').value='';", Controle.ClientID)

                Case eFormato.CEP
                    .Mask = "99,999-999"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='__.___-___') document.getElementById('{0}').value='';", Controle.ClientID)

                Case eFormato.CELULAR
                    .Mask = "(99)99999-9999"
                    strValidacoes += String.Format("if (document.getElementById('{0}').value=='(__)____-____') document.getElementById('{0}').value='';", Controle.ClientID)

            End Select

            .AutoComplete = False
            .InputDirection = MaskedEditInputDirection.RightToLeft
            .EnableClientState = True
            .EnableViewState = True

            .ID = "MaskedEditExtender" & Controle.ID
        End With

        If objMaskedEditExtender.Mask <> "" Then
            Controle.Parent.Controls.Add(objMaskedEditExtender)
        End If

        Dim objMaskedEditValidator As New MaskedEditValidator

        With objMaskedEditValidator
            .ControlExtender = objMaskedEditExtender.ID
            .ControlToValidate = Controle.ID

            .InvalidValueMessage = String.Format("Campo {0} Inválido", TituloCampo)
            .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)


            Select Case Formato
                Case eFormato.CPF
                    .ValidationExpression = "^\d{3}\.\d{3}\.\d{3}\-\d{2}$"

                Case eFormato.RG
                    .ValidationExpression = "^\d{12}$"

                Case eFormato.CNPJ
                    .ValidationExpression = "^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$"

                Case eFormato.TELEFONE
                    .ValidationExpression = "^\(\d{2}\)\d{4}\-\d{4}$"

                Case eFormato.CEP
                    .ValidationExpression = "^\d{2}\.\d{3}\-\d{3}$"

                Case eFormato.CELULAR
                    .ValidationExpression = "^\(\d{2}\)\d{5}\-\d{4}$"


            End Select


            If Requerido Then
                .IsValidEmpty = False
                .EmptyValueMessage = String.Format("Campo {0} Requerido", TituloCampo)
            Else
                .IsValidEmpty = True
            End If

            .ValidationGroup = GrupoValidacao
            .Display = ValidatorDisplay.None
            .SetFocusOnError = True
            .EnableViewState = True

            .ID = "MaskedEditValidator" & Controle.ID
        End With

        If objMaskedEditExtender.Mask <> "" Then
            Controle.Parent.Controls.Add(objMaskedEditValidator)
        End If

        Select Case Formato
            Case eFormato.EMAIL
                Dim objRegularExpressionValidator As New RegularExpressionValidator

                With objRegularExpressionValidator
                    .ControlToValidate = Controle.ID
                    .ErrorMessage = String.Format("Campo {0} Inválido", TituloCampo)
                    .ValidationExpression = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                    .ValidationGroup = GrupoValidacao
                    .Display = ValidatorDisplay.None
                    .SetFocusOnError = True
                    .EnableViewState = True

                    .ID = "RegularExpressionValidator" & Controle.ID
                End With

                Controle.Parent.Controls.Add(objRegularExpressionValidator)

                If Requerido Then
                    Livre(Controle, True, TituloCampo, GrupoValidacao)
                End If

        End Select

    End Sub

    Public Shared Sub Finalizar(ByVal Botao As Button, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal ExibirConfirmacao As Boolean = False)
        Dim objValidationSummary As New ValidationSummary

        With objValidationSummary
            .ShowSummary = False
            .ShowMessageBox = True
            .ValidationGroup = GrupoValidacao
            .EnableViewState = True

            .ID = "ValidationSummary" & Botao.ID
        End With

        Botao.ValidationGroup = GrupoValidacao
        Botao.CausesValidation = True

        If ExibirConfirmacao Then
            strValidacoes = "if (!confirm('Deseja Salvar as Informações?')) { return(false); } else { " & strValidacoes & " } "
        End If

        Botao.Attributes.Add("OnClick", strValidacoes)

        strValidacoes = ""

        Botao.Parent.Controls.Add(objValidationSummary)


    End Sub

    Public Shared Sub Finalizar(ByVal Botao As LinkButton, Optional ByVal GrupoValidacao As String = "validacao", Optional ByVal ExibirConfirmacao As Boolean = False)
        Dim objValidationSummary As New ValidationSummary

        With objValidationSummary
            .ShowSummary = False
            .ShowMessageBox = True
            .ValidationGroup = GrupoValidacao
            .EnableViewState = True

            .ID = "ValidationSummary" & Botao.ID
        End With

        Botao.ValidationGroup = GrupoValidacao
        Botao.CausesValidation = True

        If ExibirConfirmacao Then
            strValidacoes = "if (!confirm('Deseja Salvar as Informações?')) { return(false); } else { " & strValidacoes & " } "
        End If

        Botao.Attributes.Add("OnClick", strValidacoes)

        strValidacoes = ""

        Botao.Parent.Controls.Add(objValidationSummary)


    End Sub

    Public Shared Function RetirarEspacos(ByVal str As String) As String
        Dim separador() As Char = New Char() {" "c}
        Dim Palavras As String() = str.Split(separador, StringSplitOptions.RemoveEmptyEntries)
        Dim Retorno As String

        Retorno = Join(Palavras, " ")

        Return Retorno
    End Function



End Class
