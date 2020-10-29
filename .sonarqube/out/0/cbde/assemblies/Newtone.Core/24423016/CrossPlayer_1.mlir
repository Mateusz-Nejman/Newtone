func @_Newtone.Core.Media.CrossPlayer.SetNativeActions$System.Action.System.Action.System.Action.System.Action$(none, none, none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :8) {
^entry (%_play : none, %_pause : none, %_next : none, %_prev : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :37)
cbde.store %_play, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :37)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :57)
cbde.store %_pause, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :57)
%2 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :78)
cbde.store %_next, %2 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :78)
%3 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :98)
cbde.store %_prev, %3 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :80 :98)
br ^0

^0: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :82 :25) // Not a variable of known type: play
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :83 :26) // Not a variable of known type: pause
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :84 :25) // Not a variable of known type: next
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :85 :25) // Not a variable of known type: prev
br ^1

^1: // ExitBlock
return

}
// Skipping function LoadPlaylist(none, i32, i1, i1), it contains poisonous unsupported syntaxes

// Skipping function LoadPlaylist(none, i32, none, i1, i1), it contains poisonous unsupported syntaxes

// Skipping function LoadPlaylist(none, i32, i1, i1), it contains poisonous unsupported syntaxes

// Skipping function Load(none), it contains poisonous unsupported syntaxes

// Skipping function Play(), it contains poisonous unsupported syntaxes

// Skipping function Stop(), it contains poisonous unsupported syntaxes

// Skipping function Pause(), it contains poisonous unsupported syntaxes

// Skipping function Next(), it contains poisonous unsupported syntaxes

// Skipping function Prev(), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Media.CrossPlayer.Reset$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :290 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Stop
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :292 :12) // Stop() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function Seek(none), it contains poisonous unsupported syntaxes

// Skipping function SetVolume(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Media.CrossPlayer.GetVolume$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :306 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :308 :19) // Not a variable of known type: BasePlayer
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :308 :19) // BasePlayer.GetVolume() (InvocationExpression)
return %1 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :308 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Media.CrossPlayer.Error$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :311 :8) {
^entry (%_error : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :311 :26)
cbde.store %_error, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :311 :26)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :313 :31) // Not a variable of known type: error
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :315 :16) // Not a variable of known type: error
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :315 :25) // GlobalData.ERROR_FILE_EXISTS (SimpleMemberAccessExpression)
%5 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :315 :16) // comparison of unknown type: error == GlobalData.ERROR_FILE_EXISTS
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :315 :16)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Localization
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :316 :28) // Localization.SnackFileExists (SimpleMemberAccessExpression)
br ^3

^2: // BinaryBranchBlock
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :317 :21) // Not a variable of known type: error
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :317 :30) // GlobalData.ERROR_CORRUPTED (SimpleMemberAccessExpression)
%9 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :317 :21) // comparison of unknown type: error == GlobalData.ERROR_CORRUPTED
cond_br %9, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :317 :21)

^4: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Localization
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :318 :28) // Localization.FileCorrupted (SimpleMemberAccessExpression)
br ^3

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :12) // GlobalData.Current.Messenger (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: MessageGenerator
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :46) // MessageGenerator.EMessageType (SimpleMemberAccessExpression)
%14 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :46) // MessageGenerator.EMessageType.Snackbar (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :86) // Not a variable of known type: errorText
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :320 :12) // GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Snackbar, errorText) (InvocationExpression)
br ^5

^5: // ExitBlock
return

}
func @_Newtone.Core.Media.CrossPlayer.GetRandom$int$(i32) -> i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :324 :8) {
^entry (%_max : i32):
%0 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :324 :30)
cbde.store %_max, %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :324 :30)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :326 :16) // Not a variable of known type: randomIndexes
%2 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :326 :16) // randomIndexes.Count (SimpleMemberAccessExpression)
%3 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :326 :39)
%4 = cmpi "eq", %2, %3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :326 :16)
cond_br %4, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :326 :16)

^1: // SimpleBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :327 :16) // Not a variable of known type: randomIndexes
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :327 :16) // randomIndexes.Clear() (InvocationExpression)
br ^2

^2: // BinaryBranchBlock
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :31) // Not a variable of known type: Random
%8 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :43)
%9 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :45)
%10 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :31) // Random.Next(0,max) (InvocationExpression)
%11 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :16) // randomNumber
cbde.store %10, %11 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :329 :16)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :331 :16) // Not a variable of known type: randomIndexes
%13 = cbde.load %11 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :331 :39)
%14 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :331 :16) // randomIndexes.Contains(randomNumber) (InvocationExpression)
cond_br %14, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :331 :16)

^3: // JumpBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GetRandom
%15 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :332 :33)
%16 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :332 :23) // GetRandom(max) (InvocationExpression)
return %16 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :332 :16)

^4: // JumpBlock
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :335 :16) // Not a variable of known type: randomIndexes
%18 = cbde.load %11 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :335 :34)
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :335 :16) // randomIndexes.Add(randomNumber) (InvocationExpression)
%20 = cbde.load %11 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :336 :23)
return %20 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :336 :16)

^5: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Media.CrossPlayer.SetPlayerController$Newtone.Core.Media.IPlayerController$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :339 :8) {
^entry (%_playerController : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :339 :41)
cbde.store %_playerController, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :339 :41)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :341 :31) // Not a variable of known type: playerController
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Core.Media.CrossPlayer.IsLocalPath$string$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :344 :8) {
^entry (%_filepath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :344 :33)
cbde.store %_filepath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :344 :33)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :346 :19) // Not a variable of known type: filepath
%2 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :346 :19) // filepath.Length (SimpleMemberAccessExpression)
%3 = constant 11 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :346 :37)
%4 = cmpi "sgt", %2, %3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :346 :19)
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :346 :12)

^1: // ExitBlock
cbde.unreachable

}
