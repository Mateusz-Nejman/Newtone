// Skipping function Load(none), it contains poisonous unsupported syntaxes

// Skipping function Play(), it contains poisonous unsupported syntaxes

// Skipping function Stop(), it contains poisonous unsupported syntaxes

// Skipping function Pause(), it contains poisonous unsupported syntaxes

// Skipping function Next(), it contains poisonous unsupported syntaxes

// Skipping function Prev(), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Media.CrossPlayer.Reset$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :202 :8) {
^entry :
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Stop
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :204 :12) // Stop() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function Seek(none), it contains poisonous unsupported syntaxes

// Skipping function SetVolume(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Media.CrossPlayer.GetVolume$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :218 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :220 :19) // Not a variable of known type: BasePlayer
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :220 :19) // BasePlayer.GetVolume() (InvocationExpression)
return %1 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :220 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Media.CrossPlayer.Error$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :223 :8) {
^entry (%_error : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :223 :26)
cbde.store %_error, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :223 :26)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :225 :31) // Not a variable of known type: error
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :227 :16) // Not a variable of known type: error
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :227 :25) // GlobalData.ERROR_FILE_EXISTS (SimpleMemberAccessExpression)
%5 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :227 :16) // comparison of unknown type: error == GlobalData.ERROR_FILE_EXISTS
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :227 :16)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Localization
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :228 :28) // Localization.SnackFileExists (SimpleMemberAccessExpression)
br ^3

^2: // BinaryBranchBlock
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :229 :21) // Not a variable of known type: error
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :229 :30) // GlobalData.ERROR_CORRUPTED (SimpleMemberAccessExpression)
%9 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :229 :21) // comparison of unknown type: error == GlobalData.ERROR_CORRUPTED
cond_br %9, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :229 :21)

^4: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Localization
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :230 :28) // Localization.FileCorrupted (SimpleMemberAccessExpression)
br ^3

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :12) // GlobalData.Current.Messenger (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: MessageGenerator
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :46) // MessageGenerator.EMessageType (SimpleMemberAccessExpression)
%14 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :46) // MessageGenerator.EMessageType.Snackbar (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :86) // Not a variable of known type: errorText
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :232 :12) // GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Snackbar, errorText) (InvocationExpression)
br ^5

^5: // ExitBlock
return

}
func @_Newtone.Core.Media.CrossPlayer.SetPlayerController$Newtone.Core.Media.IPlayerController$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :236 :8) {
^entry (%_playerController : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :236 :41)
cbde.store %_playerController, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :236 :41)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :238 :31) // Not a variable of known type: playerController
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Core.Media.CrossPlayer.IsLocalPath$string$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :241 :8) {
^entry (%_filepath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :241 :33)
cbde.store %_filepath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :241 :33)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :243 :19) // Not a variable of known type: filepath
%2 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :243 :19) // filepath.Length (SimpleMemberAccessExpression)
%3 = constant 11 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :243 :37)
%4 = cmpi "sgt", %2, %3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :243 :19)
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\CrossPlayer.cs" :243 :12)

^1: // ExitBlock
cbde.unreachable

}
