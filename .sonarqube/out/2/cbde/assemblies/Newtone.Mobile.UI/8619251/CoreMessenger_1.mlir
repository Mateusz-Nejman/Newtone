func @_Newtone.Mobile.UI.Logic.CoreMessenger.ShowError$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :9 :8) {
^entry (%_message : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :9 :30)
cbde.store %_message, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :9 :30)
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: ShowMessage
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :11 :24) // Not a variable of known type: message
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :11 :12) // ShowMessage(message) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function ShowMessage(none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Logic.CoreMessenger.ShowSnackbar$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :22 :8) {
^entry (%_message : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :22 :33)
cbde.store %_message, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :22 :33)
br ^0

^0: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :24 :12) // Global.Application (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :24 :44) // Not a variable of known type: message
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\CoreMessenger.cs" :24 :12) // Global.Application.ShowSnackbar(message) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
