// Skipping function PageDisappearing(none, none), it contains poisonous unsupported syntaxes

// Skipping function PageAppearing(none, none), it contains poisonous unsupported syntaxes

// Skipping function Tick(), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Views.ModalPage.Block$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :65 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :67 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :67 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :67 :32) // true
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.ModalPage.Unblock$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :70 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :72 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :72 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :72 :32) // false
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.ModalPage.IsBlocked$$() -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :75 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :77 :19) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :77 :19) // blocker.IsVisible (SimpleMemberAccessExpression)
return %1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\ModalPage.xaml.cs" :77 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function GetContentType(), it contains poisonous unsupported syntaxes

