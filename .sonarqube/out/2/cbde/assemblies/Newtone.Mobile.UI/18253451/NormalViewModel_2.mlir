// Skipping function Appearing(), it contains poisonous unsupported syntaxes

// Skipping function Disappearing(), it contains poisonous unsupported syntaxes

// Skipping function Tick(), it contains poisonous unsupported syntaxes

// Skipping function RefreshSuggestion(), it contains poisonous unsupported syntaxes

// Skipping function SuggestionItem_Selected(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.ViewModels.TV.NormalViewModel.Toggle$int$(i32) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :519 :8) {
^entry (%_buttonIndex : i32):
%0 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :519 :28)
cbde.store %_buttonIndex, %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :519 :28)
br ^0

^0: // SimpleBlock
%1 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :521 :34)
%2 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :521 :49)
%3 = cmpi "eq", %1, %2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :521 :34)
%4 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :522 :35)
%5 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :522 :50)
%6 = cmpi "eq", %4, %5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :522 :35)
%7 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :523 :37)
%8 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :523 :52)
%9 = cmpi "eq", %7, %8 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :523 :37)
%10 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :524 :36)
%11 = constant 3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :524 :51)
%12 = cmpi "eq", %10, %11 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :524 :36)
%13 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\TV\\NormalViewModel.cs" :525 :33)
br ^1

^1: // ExitBlock
return

}
// Skipping function SetContainer(none, none), it contains poisonous unsupported syntaxes

