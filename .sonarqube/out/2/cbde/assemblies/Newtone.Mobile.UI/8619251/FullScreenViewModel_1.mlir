// Skipping function Appearing(), it contains poisonous unsupported syntaxes

// Skipping function Disappearing(), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.ViewModels.FullScreenViewModel.AudioSlider_ValueNewChanged$Newtone.Mobile.UI.Views.Custom.AudioSliderControl.ValueChangedArgs$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :293 :8) {
^entry (%_e : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :293 :48)
cbde.store %_e, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :293 :48)
br ^0

^0: // BinaryBranchBlock
// Entity from another assembly: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :295 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :295 :16) // GlobalData.Current.MediaPlayer (SimpleMemberAccessExpression)
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :295 :16) // GlobalData.Current.MediaPlayer.IsPlaying (SimpleMemberAccessExpression)
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :295 :16)

^1: // SimpleBlock
// Entity from another assembly: GlobalData
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :297 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :297 :16) // GlobalData.Current.MediaPlayer (SimpleMemberAccessExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :297 :52) // Not a variable of known type: e
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :297 :52) // e.Value (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\FullScreenViewModel.cs" :297 :16) // GlobalData.Current.MediaPlayer.Seek(e.Value) (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
// Skipping function Tick(), it contains poisonous unsupported syntaxes

