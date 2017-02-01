namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module SPAnimation =
    type Attribute =
        | PositionX = 0
        | PositionY = 1
        | Height = 2
        | Width = 3
        | Opacity = 4

    and ID =
        | Basic_Show = 0
        | Basic_SlowShow = 1
        | Basic_Fade = 2
        | Basic_Move = 3
        | Basic_Size = 4
        | Content_SlideInFadeInRight = 5
        | Content_SlideInFadeInRightInc = 6
        | Content_SlideOutFadeOutRight = 7
        | Content_SlideInFadeInLeft = 8
        | Content_SlideInFadeInLeftInc = 9
        | SmallObject_SlideInFadeInTop = 10
        | SmallObject_SlideInFadeInLeft = 11
        | Test_Instant = 12
        | Test_Hold = 13
        | Basic_Opacity = 14
        | Basic_QuickShow = 15
        | Basic_QuickFade = 16
        | Content_SlideInFadeInGeneric = 17
        | Basic_StrikeThrough = 18
        | SmallObject_SlideInFadeInBottom = 19
        | SmallObject_SlideOutFadeOutBottom = 20
        | Basic_QuickSize = 21

    and [<AllowNullLiteral>] [<Import("Settings","SPAnimation")>] Settings() =
        static member DisableAnimation(): unit = jsNative
        static member DisableSessionAnimation(): unit = jsNative
        static member IsAnimationEnabled(): bool = jsNative

    and [<AllowNullLiteral>] [<Import("State","SPAnimation")>] State() =
        member __.SetAttribute(attributeId: Attribute, value: float): unit = jsNative
        member __.GetAttribute(attributeId: Attribute): float = jsNative
        member __.GetDataIndex(attributeId: Attribute): float = jsNative

    and [<AllowNullLiteral>] [<Import("Object","SPAnimation")>] Object(animationID: ID, delay: float, element: ResizeArray<HTMLElement>, finalState: State, ?finishFunc: Func<obj, unit>, ?data: obj) =
        member __.RunAnimation(): unit = jsNative



module SPAnimationUtility =
    type [<AllowNullLiteral>] [<Import("BasicAnimator","SPAnimationUtility")>] BasicAnimator() =
        static member FadeIn(element: HTMLElement, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member FadeOut(element: HTMLElement, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member Move(element: HTMLElement, posX: float, posY: float, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member StrikeThrough(element: HTMLElement, strikeThroughWidth: float, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member Resize(element: HTMLElement, newHeight: float, newWidth: float, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member CommonResize(element: HTMLElement, newHeight: float, newWidth: float, finishFunc: Func<obj, unit>, data: obj, animationId: SPAnimation.ID): unit = jsNative
        static member QuickResize(element: HTMLElement, newHeight: float, newWidth: float, ?finishFunc: Func<obj, unit>, ?data: obj): unit = jsNative
        static member ResizeContainerAndFillContent(element: HTMLElement, newHeight: float, newWidth: float, finishFunc: Func<unit, unit>, fAddToEnd: bool): unit = jsNative
        static member GetWindowScrollPosition(): obj = jsNative
        static member GetLeftOffset(element: HTMLElement): float = jsNative
        static member GetTopOffset(element: HTMLElement): float = jsNative
        static member GetRightOffset(element: HTMLElement): float = jsNative
        static member PositionElement(element: HTMLElement, topValue: float, leftValue: float, heightValue: float, widthValue: float): unit = jsNative
        static member PositionAbsolute(element: HTMLElement): unit = jsNative
        static member PositionRelative(element: HTMLElement): unit = jsNative
        static member PositionRelativeExact(element: HTMLElement, topValue: float, leftValue: float, heightValue: float, widthValue: float): unit = jsNative
        static member PositionAbsoluteExact(element: HTMLElement, topValue: float, leftValue: float, heightValue: float, widthValue: float): unit = jsNative
        static member IsPositioned(element: HTMLElement): bool = jsNative



