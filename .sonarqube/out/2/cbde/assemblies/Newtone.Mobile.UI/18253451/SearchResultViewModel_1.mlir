// Skipping function Item_Selected(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.ViewModels.SearchResultViewModel.SearchListView_ItemAppearing$int$(i32) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :230 :8) {
^entry (%_itemIndex : i32):
%0 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :230 :49)
cbde.store %_itemIndex, %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :230 :49)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :232 :12) // Not a variable of known type: ItemAppearing
%2 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :232 :34)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\SearchResultViewModel.cs" :232 :12) // ItemAppearing.Execute(itemIndex) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
