func @_Newtone.Mobile.UI.Views.NormalPage.Block$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :32 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :34 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :34 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :34 :32) // true
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.NormalPage.Unblock$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :37 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :39 :12) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :39 :12) // blocker.IsVisible (SimpleMemberAccessExpression)
%2 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :39 :32) // false
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.NormalPage.IsBlocked$$() -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :41 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :43 :19) // Not a variable of known type: blocker
%1 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :43 :19) // blocker.IsVisible (SimpleMemberAccessExpression)
return %1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :43 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function PageDisappearing(none, none), it contains poisonous unsupported syntaxes

// Skipping function PageAppearing(none, none), it contains poisonous unsupported syntaxes

// Skipping function Entry_Completed(none, none), it contains poisonous unsupported syntaxes

// Skipping function Entry_Focused(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Views.NormalPage.Entry_Unfocused$object.Xamarin.Forms.FocusEventArgs$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :70 :8) {
^entry (%_sender : none, %_e : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :70 :37)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :70 :37)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :70 :52)
cbde.store %_e, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :70 :52)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :72 :12) // Not a variable of known type: ViewModel
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :72 :12) // ViewModel.SearchSuggestionsVisible (SimpleMemberAccessExpression)
%4 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\NormalPage.xaml.cs" :72 :49) // false
br ^1

^1: // ExitBlock
return

}
// Skipping function Entry_TextChanged(none, none), it contains poisonous unsupported syntaxes

// Skipping function SuggestionList_ItemSelected(none, none), it contains poisonous unsupported syntaxes

