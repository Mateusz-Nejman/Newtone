// Skipping function AudioSlider_ValueNewChanged(none, none), it contains poisonous unsupported syntaxes

// Skipping function PageDisappearing(none, none), it contains poisonous unsupported syntaxes

// Skipping function PageAppearing(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Views.TV.FullScreenPage.Block$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :49 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :51 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :51 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :51 :32) // true
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.TV.FullScreenPage.Unblock$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :54 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :56 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :56 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :56 :32) // false
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.TV.FullScreenPage.IsBlocked$$() -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :59 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :61 :19) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :61 :19) // blocker.IsVisible (SimpleMemberAccessExpression)
return %1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\FullScreenPage.xaml.cs" :61 :12)

^1: // ExitBlock
cbde.unreachable

}
