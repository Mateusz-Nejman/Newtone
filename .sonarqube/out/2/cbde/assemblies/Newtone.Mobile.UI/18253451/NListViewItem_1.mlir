// Skipping function OnIsNFocusedChanged(), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NListViewItem.FocusLeft$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :67 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :69 :16) // Not a variable of known type: ParentListView
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :69 :16) // ParentListView.NOrientation (SimpleMemberAccessExpression)
// Entity from another assembly: ScrollOrientation
%2 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :69 :47) // ScrollOrientation.Horizontal (SimpleMemberAccessExpression)
%3 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :69 :16) // comparison of unknown type: ParentListView.NOrientation == ScrollOrientation.Horizontal
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :69 :16)

^1: // SimpleBlock
// Entity from another assembly: System
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :71 :16) // System.Diagnostics.Debug (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :71 :51) // "Horizontal" (StringLiteralExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :71 :16) // System.Diagnostics.Debug.WriteLine("Horizontal") (InvocationExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :72 :16) // Not a variable of known type: ParentListView
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :72 :16) // ParentListView.FocusLeft() (InvocationExpression)
br ^3

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :76 :42) // this (ThisExpression)
%10 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :76 :19) // FocusContext.FocusLeft(this) (InvocationExpression)
cond_br %10, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :76 :19)

^4: // SimpleBlock
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :78 :20) // Not a variable of known type: ParentListView
%12 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :78 :45) // false
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :78 :20) // ParentListView.SetActive(false) (InvocationExpression)
br ^3

^3: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.FocusRight$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :83 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :85 :16) // Not a variable of known type: ParentListView
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :85 :16) // ParentListView.NOrientation (SimpleMemberAccessExpression)
// Entity from another assembly: ScrollOrientation
%2 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :85 :47) // ScrollOrientation.Horizontal (SimpleMemberAccessExpression)
%3 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :85 :16) // comparison of unknown type: ParentListView.NOrientation == ScrollOrientation.Horizontal
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :85 :16)

^1: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :87 :16) // Not a variable of known type: ParentListView
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :87 :16) // ParentListView.FocusRight() (InvocationExpression)
br ^3

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :92 :43) // this (ThisExpression)
%7 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :92 :19) // FocusContext.FocusRight(this) (InvocationExpression)
cond_br %7, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :92 :19)

^4: // SimpleBlock
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :94 :20) // Not a variable of known type: ParentListView
%9 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :94 :45) // false
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :94 :20) // ParentListView.SetActive(false) (InvocationExpression)
br ^3

^3: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.FocusUp$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :99 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :101 :16) // Not a variable of known type: ParentListView
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :101 :16) // ParentListView.NOrientation (SimpleMemberAccessExpression)
// Entity from another assembly: ScrollOrientation
%2 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :101 :47) // ScrollOrientation.Vertical (SimpleMemberAccessExpression)
%3 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :101 :16) // comparison of unknown type: ParentListView.NOrientation == ScrollOrientation.Vertical
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :101 :16)

^1: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :103 :16) // Not a variable of known type: ParentListView
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :103 :16) // ParentListView.FocusUp() (InvocationExpression)
br ^3

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :107 :41) // this (ThisExpression)
%7 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :107 :20) // FocusContext.FocusUp(this) (InvocationExpression)
cond_br %7, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :107 :20)

^4: // SimpleBlock
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :109 :20) // Not a variable of known type: ParentListView
%9 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :109 :45) // false
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :109 :20) // ParentListView.SetActive(false) (InvocationExpression)
br ^3

^3: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.FocusDown$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :114 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :116 :16) // Not a variable of known type: ParentListView
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :116 :16) // ParentListView.NOrientation (SimpleMemberAccessExpression)
// Entity from another assembly: ScrollOrientation
%2 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :116 :47) // ScrollOrientation.Vertical (SimpleMemberAccessExpression)
%3 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :116 :16) // comparison of unknown type: ParentListView.NOrientation == ScrollOrientation.Vertical
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :116 :16)

^1: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :118 :16) // Not a variable of known type: ParentListView
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :118 :16) // ParentListView.FocusDown() (InvocationExpression)
br ^3

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: FocusContext
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :122 :43) // this (ThisExpression)
%7 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :122 :20) // FocusContext.FocusDown(this) (InvocationExpression)
cond_br %7, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :122 :20)

^4: // SimpleBlock
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :124 :20) // Not a variable of known type: ParentListView
%9 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :124 :45) // false
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :124 :20) // ParentListView.SetActive(false) (InvocationExpression)
br ^3

^3: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.FocusAction$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :129 :8) {
^entry :
br ^0

^0: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.LongFocusAction$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :134 :8) {
^entry :
br ^0

^0: // ExitBlock
return

}
func @_Nejman.Xamarin.FocusLibrary.NListViewItem.SetFrame$Xamarin.Forms.Frame$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :139 :8) {
^entry (%_frame : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :139 :29)
cbde.store %_frame, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :139 :29)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :141 :12) // this (ThisExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :141 :12) // this.frame (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NListViewItem.cs" :141 :25) // Not a variable of known type: frame
br ^1

^1: // ExitBlock
return

}
// Skipping function OnPropertyChanged(none), it contains poisonous unsupported syntaxes

// Skipping function OnPropertyChanged(none), it contains poisonous unsupported syntaxes

