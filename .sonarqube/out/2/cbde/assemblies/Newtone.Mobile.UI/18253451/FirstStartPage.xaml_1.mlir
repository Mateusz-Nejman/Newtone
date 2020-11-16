func @_Newtone.Mobile.UI.Views.FirstStartPage.SetPage$Xamarin.Forms.ContentView$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :22 :8) {
^entry (%_view : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :22 :28)
cbde.store %_view, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :22 :28)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :24 :12) // Not a variable of known type: mainGrid
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :24 :12) // mainGrid.Children (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :24 :12) // mainGrid.Children.Clear() (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :12) // Not a variable of known type: mainGrid
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :12) // mainGrid.Children (SimpleMemberAccessExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :34) // Not a variable of known type: view
%7 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :40)
%8 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :43)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\FirstStartPage.xaml.cs" :25 :12) // mainGrid.Children.Add(view, 0, 0) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
