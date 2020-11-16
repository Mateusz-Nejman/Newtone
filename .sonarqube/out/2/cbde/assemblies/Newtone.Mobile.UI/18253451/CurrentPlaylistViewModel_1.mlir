func @_Newtone.Mobile.UI.ViewModels.CurrentPlaylistViewModel.TrackListView_ItemSelected$object.Xamarin.Forms.SelectedItemChangedEventArgs$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :85 :8) {
^entry (%_sender : none, %_e : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :85 :47)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :85 :47)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :85 :62)
cbde.store %_e, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :85 :62)
br ^0

^0: // BinaryBranchBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :87 :12) // Not a variable of known type: ItemSelected
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :87 :33) // Not a variable of known type: e
%4 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :87 :33) // e.SelectedItemIndex (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :87 :12) // ItemSelected.Execute(e.SelectedItemIndex) (InvocationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%6 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :88 :16) // Global.TV (SimpleMemberAccessExpression)
%7 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :88 :15) // !Global.TV (LogicalNotExpression)
cond_br %7, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :88 :15)

^1: // SimpleBlock
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :90 :17) // Not a variable of known type: sender
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :90 :17) // sender as Xamarin.Forms.ListView (AsExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :90 :16) // (sender as Xamarin.Forms.ListView).SelectedItem (SimpleMemberAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\CurrentPlaylistViewModel.cs" :90 :66) // null (NullLiteralExpression)
br ^2

^2: // ExitBlock
return

}
// Skipping function Tick(), it contains poisonous unsupported syntaxes

