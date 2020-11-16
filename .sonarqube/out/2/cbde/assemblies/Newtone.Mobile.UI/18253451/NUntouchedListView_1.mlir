// Skipping function OnIsNFocusedChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function OrientationChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function ItemSourceChanged(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function NItemSource_CollectionChanged(none, none), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NUntouchedListView.CreateItem$Nejman.Xamarin.FocusLibrary.NListViewItem$(none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :357 :8) {
^entry (%_item : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :357 :33)
cbde.store %_item, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :357 :33)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :359 :26) // new Frame()              {                  Padding = 10,                  Margin = 0,                  BorderColor = Color.Transparent,                  BackgroundColor = Color.Transparent,                  VerticalOptions = LayoutOptions.Center,                  HorizontalOptions = LayoutOptions.Center,                  WidthRequest = NItemWidth,                  HeightRequest = NItemHeight,              } (ObjectCreationExpression)
%2 = constant 10 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :361 :26)
%3 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :362 :25)
// Entity from another assembly: Color
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :363 :30) // Color.Transparent (SimpleMemberAccessExpression)
// Entity from another assembly: Color
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :364 :34) // Color.Transparent (SimpleMemberAccessExpression)
// Entity from another assembly: LayoutOptions
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :365 :34) // LayoutOptions.Center (SimpleMemberAccessExpression)
// Entity from another assembly: LayoutOptions
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :366 :36) // LayoutOptions.Center (SimpleMemberAccessExpression)
%8 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :367 :31) // Not a variable of known type: NItemWidth
%9 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :368 :32) // Not a variable of known type: NItemHeight
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :370 :23) // Not a variable of known type: NItemTemplate
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :370 :44) // Not a variable of known type: item
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :370 :23) // NItemTemplate.Invoke(item) (InvocationExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :371 :12) // Not a variable of known type: view
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :371 :12) // view.VerticalOptions (SimpleMemberAccessExpression)
// Entity from another assembly: LayoutOptions
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :371 :35) // LayoutOptions.CenterAndExpand (SimpleMemberAccessExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :372 :12) // Not a variable of known type: view
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :372 :12) // view.HorizontalOptions (SimpleMemberAccessExpression)
// Entity from another assembly: LayoutOptions
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :372 :37) // LayoutOptions.CenterAndExpand (SimpleMemberAccessExpression)
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :373 :12) // Not a variable of known type: frame
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :373 :12) // frame.Content (SimpleMemberAccessExpression)
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :373 :28) // Not a variable of known type: view
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :375 :19) // Not a variable of known type: frame
return %24 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :375 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function FocusPrev(), it contains poisonous unsupported syntaxes

// Skipping function FocusSpecified(i32, i32), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NUntouchedListView.SetActive$bool$(i1) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :408 :8) {
^entry (%_active : i1):
%0 = cbde.alloca i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :408 :30)
cbde.store %_active, %0 : memref<i1> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :408 :30)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :410 :12) // this (ThisExpression)
%2 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :410 :12) // this.active (SimpleMemberAccessExpression)
%3 = cbde.load %0 : memref<i1> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :410 :26)
br ^1

^1: // ExitBlock
return

}
// Skipping function GetFrame(i32), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NUntouchedListView.GetCurrentItemView$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :417 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :419 :16) // Not a variable of known type: NFocusedIndex
%1 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :419 :32)
%2 = cmpi "slt", %0, %1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :419 :16)
cond_br %2, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :419 :16)

^1: // JumpBlock
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :420 :23) // Not a variable of known type: container
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :420 :23) // container.Children (SimpleMemberAccessExpression)
%5 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :420 :42)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :420 :23) // container.Children[0] (ElementAccessExpression)
return %6 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :420 :16)

^2: // BinaryBranchBlock
%7 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :16) // Not a variable of known type: NFocusedIndex
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :33) // Not a variable of known type: container
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :33) // container.Children (SimpleMemberAccessExpression)
%10 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :33) // container.Children.Count (SimpleMemberAccessExpression)
%11 = cmpi "sge", %7, %10 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :16)
cond_br %11, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :422 :16)

^3: // JumpBlock
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :23) // Not a variable of known type: container
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :23) // container.Children (SimpleMemberAccessExpression)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :42) // Not a variable of known type: container
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :42) // container.Children (SimpleMemberAccessExpression)
%16 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :42) // container.Children.Count (SimpleMemberAccessExpression)
%17 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :69)
%18 = subi %16, %17 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :42)
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :23) // container.Children[container.Children.Count - 1] (ElementAccessExpression)
return %19 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :423 :16)

^4: // JumpBlock
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :425 :19) // Not a variable of known type: container
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :425 :19) // container.Children (SimpleMemberAccessExpression)
%22 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :425 :38) // Not a variable of known type: NFocusedIndex
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :425 :19) // container.Children[NFocusedIndex] (ElementAccessExpression)
return %23 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :425 :12)

^5: // ExitBlock
cbde.unreachable

}
// Skipping function FocusLeft(), it contains poisonous unsupported syntaxes

// Skipping function FocusRight(), it contains poisonous unsupported syntaxes

// Skipping function FocusUp(), it contains poisonous unsupported syntaxes

// Skipping function FocusDown(), it contains poisonous unsupported syntaxes

// Skipping function FocusAction(), it contains poisonous unsupported syntaxes

// Skipping function LongFocusAction(), it contains poisonous unsupported syntaxes

// Skipping function FocusNext(), it contains poisonous unsupported syntaxes

func @_Nejman.Xamarin.FocusLibrary.NUntouchedListView.Rerender$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :526 :8) {
^entry :
br ^0

^0: // ForInitializerBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: NItemSource_CollectionChanged
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :528 :42) // null (NullLiteralExpression)
// Entity from another assembly: NotifyCollectionChangedAction
%1 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :528 :85) // NotifyCollectionChangedAction.Reset (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :528 :48) // new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset) (ObjectCreationExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :528 :12) // NItemSource_CollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)) (InvocationExpression)
%4 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :25)
%5 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :21) // a
cbde.store %4, %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :21)
br ^1

^1: // BinaryBranchBlock
%6 = cbde.load %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :28)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :32) // Not a variable of known type: NItemSource
%8 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :32) // NItemSource.Count (SimpleMemberAccessExpression)
%9 = cmpi "slt", %6, %8 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :28)
cond_br %9, ^2, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :28)

^2: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: NItemSource_CollectionChanged
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :46) // null (NullLiteralExpression)
// Entity from another assembly: NotifyCollectionChangedAction
%11 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :89) // NotifyCollectionChangedAction.Add (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :124) // Not a variable of known type: NItemSource
%13 = cbde.load %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :136)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :124) // NItemSource[a] (ElementAccessExpression)
%15 = cbde.load %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :140)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :52) // new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, NItemSource[a], a) (ObjectCreationExpression)
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :531 :16) // NItemSource_CollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, NItemSource[a], a)) (InvocationExpression)
br ^4

^4: // SimpleBlock
%18 = cbde.load %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :51)
%19 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :51)
%20 = addi %18, %19 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :51)
cbde.store %20, %5 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\FocusLibrary\\NUntouchedListView.cs" :529 :51)
br ^1

^3: // ExitBlock
return

}
