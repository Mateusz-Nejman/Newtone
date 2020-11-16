// Skipping function CheckChanges(), it contains poisonous unsupported syntaxes

// Skipping function FocusAction(), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Models.TrackModel.LongFocusAction$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :223 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :225 :12) // Not a variable of known type: OpenMenu
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :225 :29) // this (ThisExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :225 :29) // this.ParentListView (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :225 :29) // this.ParentListView.GetCurrentItemView() (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Models\\TrackModel.cs" :225 :12) // OpenMenu.Execute(this.ParentListView.GetCurrentItemView()) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
