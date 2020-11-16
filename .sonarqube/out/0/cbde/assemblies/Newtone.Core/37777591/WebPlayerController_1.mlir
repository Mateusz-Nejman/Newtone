func @_Newtone.Core.Media.WebPlayerController.Completed$Newtone.Core.Media.CrossPlayer$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :12 :8) {
^entry (%_player : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :12 :30)
cbde.store %_player, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :12 :30)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :14 :12) // Not a variable of known type: player
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :14 :12) // player.Next() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function Load(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Media.WebPlayerController.Prepared$Newtone.Core.Media.CrossPlayer$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :34 :8) {
^entry (%_player : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :34 :29)
cbde.store %_player, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :34 :29)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :36 :12) // Not a variable of known type: player
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :36 :12) // player.Play() (InvocationExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :37 :12) // Not a variable of known type: player
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :37 :12) // player.IsLoading (SimpleMemberAccessExpression)
%5 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\WebPlayerController.cs" :37 :31) // false
br ^1

^1: // ExitBlock
return

}
