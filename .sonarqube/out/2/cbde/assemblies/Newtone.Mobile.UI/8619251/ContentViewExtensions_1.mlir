func @_Newtone.Mobile.UI.Logic.ContentViewExtensions.IsTimerView$Xamarin.Forms.ContentView$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :7 :8) {
^entry (%_contentView : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :7 :39)
cbde.store %_contentView, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :7 :39)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :9 :19) // Not a variable of known type: contentView
%2 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :9 :19) // contentView is ITimerContent (IsExpression)
return %2 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContentViewExtensions.cs" :9 :12)

^1: // ExitBlock
cbde.unreachable

}
