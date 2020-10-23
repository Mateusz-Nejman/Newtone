func @_Newtone.Core.Media.LocalPlayerController.Completed$Newtone.Core.Media.CrossPlayer$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :5 :8) {
^entry (%_player : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :5 :30)
cbde.store %_player, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :5 :30)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :7 :12) // Not a variable of known type: player
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :7 :12) // player.Next() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Core.Media.LocalPlayerController.Load$Newtone.Core.Media.CrossPlayer.string$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :10 :8) {
^entry (%_player : none, %_filepath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :10 :25)
cbde.store %_player, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :10 :25)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :10 :45)
cbde.store %_filepath, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :10 :45)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :12 :12) // Not a variable of known type: player
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :12 :12) // player.BasePlayer (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :12 :35) // Not a variable of known type: filepath
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :12 :12) // player.BasePlayer.Load(filepath) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Core.Media.LocalPlayerController.Prepared$Newtone.Core.Media.CrossPlayer$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :15 :8) {
^entry (%_player : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :15 :29)
cbde.store %_player, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :15 :29)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :17 :12) // Not a variable of known type: player
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :17 :12) // player.Play() (InvocationExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :18 :12) // Not a variable of known type: player
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :18 :12) // player.IsLoading (SimpleMemberAccessExpression)
%5 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\LocalPlayerController.cs" :18 :31) // false
br ^1

^1: // ExitBlock
return

}
