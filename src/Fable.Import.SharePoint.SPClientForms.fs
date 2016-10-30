namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module SPClientForms =
    type FormManagerEvents =
        | Event_OnControlValueChanged = 0
        | Event_OnControlInitializedCallback = 1
        | Event_OnControlFocusSetCallback = 2
        | Event_GetControlValueCallback = 3
        | Event_OnControlValidationError = 4
        | Event_RegisterControlValidator = 5
        | Event_GetHasValueChangedCallback = 6

    and [<AllowNullLiteral>] [<Import("ClientForm","SPClientForms")>] ClientForm(qualifier: string) =
        member __.RenderClientForm(): unit = jsNative
        member __.SubmitClientForm(): bool = jsNative
        member __.NotifyControlEvent(eventName: FormManagerEvents, fldName: string, eventArg: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientFormManager","SPClientForms")>] ClientFormManager() =
        static member GetClientForm(qualifier: string): ClientForm = jsNative
        static member RegisterClientForm(qualifier: string): unit = jsNative
        static member SubmitClientForm(qualifier: string): bool = jsNative

    module ClientValidation =
        type [<AllowNullLiteral>] [<Import("ClientValidation.ValidationResult","SPClientForms")>] ValidationResult(hasErrors: bool, errorMsg: string) =
            class end

        and [<AllowNullLiteral>] [<Import("ClientValidation.ValidatorSet","SPClientForms")>] ValidatorSet() =
            member __.RegisterValidator(validator: IValidator): unit = jsNative

        and [<AllowNullLiteral>] IValidator =
            abstract Validate: value: obj -> ValidationResult

        and [<AllowNullLiteral>] [<Import("ClientValidation.RequiredValidator","SPClientForms")>] RequiredValidator() =
            interface IValidator with
                member __.Validate(value: obj): ValidationResult = jsNative


        and [<AllowNullLiteral>] [<Import("ClientValidation.RequiredFileValidator","SPClientForms")>] RequiredFileValidator() =
            interface IValidator with
                member __.Validate(value: obj): ValidationResult = jsNative


        and [<AllowNullLiteral>] [<Import("ClientValidation.RequiredRichTextValidator","SPClientForms")>] RequiredRichTextValidator() =
            interface IValidator with
                member __.Validate(value: obj): ValidationResult = jsNative


        and [<AllowNullLiteral>] [<Import("ClientValidation.MaxLengthUrlValidator","SPClientForms")>] MaxLengthUrlValidator() =
            interface IValidator with
                member __.Validate(value: obj): ValidationResult = jsNative






