// Skipping function BuildKeyboard(), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.OnIsNFocusedChanged$Xamarin.Forms.BindableObject.object.object$(none, none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :8) {
^entry (%_bindable : none, %_oldValue : none, %_newValue : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :48)
cbde.store %_bindable, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :48)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :73)
cbde.store %_oldValue, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :73)
%2 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :90)
cbde.store %_newValue, %2 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :315 :90)
br ^0

^0: // BinaryBranchBlock
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :317 :59) // Not a variable of known type: bindable
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :317 :42) // (NScreenKeyboard)bindable (CastExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :318 :35) // Not a variable of known type: newValue
%7 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :318 :29) // (bool)newValue (CastExpression)
%8 = cbde.alloca i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :318 :17) // isFocused
cbde.store %7, %8 : memref<i1> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :318 :17)
%9 = cbde.load %8 : memref<i1> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :320 :15)
cond_br %9, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :320 :15)

^1: // SimpleBlock
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :321 :16) // Not a variable of known type: focusButton
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :321 :16) // focusButton.FocusFirst() (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
// Skipping function OnElementChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function OnBackColorChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function OnFocusColorChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function OnFontColorChanged(none, none, none), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusFirst$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :421 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :13) // Identifier from another assembly: Children
%1 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :22)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :13) // Children[0] (ElementAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :13) // Children[0] as INFocusElement (AsExpression)
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :12) // (Children[0] as INFocusElement).IsNFocused (SimpleMemberAccessExpression)
%5 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :423 :57) // true
br ^1

^1: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusLeft$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :427 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :429 :35) // this (ThisExpression)
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :429 :12) // FocusContext.FocusLeft(this) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusRight$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :432 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :434 :36) // this (ThisExpression)
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :434 :12) // FocusContext.FocusRight(this) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusUp$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :437 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :439 :33) // this (ThisExpression)
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :439 :12) // FocusContext.FocusUp(this) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusDown$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :442 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :444 :35) // this (ThisExpression)
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :444 :12) // FocusContext.FocusDown(this) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NScreenKeyboard.FocusAction$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NScreenKeyboard.cs" :447 :8) {
^entry :
br ^0

^0: // ExitBlock
return

}
