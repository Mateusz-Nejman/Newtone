func @_Newtone.Core.Logic.ConsoleDebug.WriteLine$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :11 :8) {
^entry (%_text : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :11 :37)
cbde.store %_text, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :11 :37)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :28) // "[" (StringLiteralExpression)
// Entity from another assembly: DateTime
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :34) // DateTime.Now (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :34) // DateTime.Now.ToString() (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString()
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :60) // "]: " (StringLiteralExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: "
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :68) // Not a variable of known type: text
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :13 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: " + text
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :14 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%11 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :14 :16) // GlobalData.Current.IsDebugMode (SimpleMemberAccessExpression)
cond_br %11, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :14 :16)

^1: // SimpleBlock
// Entity from another assembly: Console
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :15 :34) // Not a variable of known type: output
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :15 :16) // Console.WriteLine(output) (InvocationExpression)
br ^2

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: IsLogFile
%14 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :17 :16) // IsLogFile() (InvocationExpression)
cond_br %14, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :17 :16)

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: WriteLog
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :18 :25) // Not a variable of known type: output
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :18 :16) // WriteLog(output) (InvocationExpression)
br ^4

^4: // ExitBlock
return

}
func @_Newtone.Core.Logic.ConsoleDebug.WriteLine$System.Exception$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :21 :8) {
^entry (%_e : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :21 :37)
cbde.store %_e, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :21 :37)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :28) // "[" (StringLiteralExpression)
// Entity from another assembly: DateTime
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :34) // DateTime.Now (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :34) // DateTime.Now.ToString() (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString()
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :60) // "]: " (StringLiteralExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: "
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :68) // Not a variable of known type: e
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :23 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: " + e
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :24 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%11 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :24 :16) // GlobalData.Current.IsDebugMode (SimpleMemberAccessExpression)
cond_br %11, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :24 :16)

^1: // SimpleBlock
// Entity from another assembly: Console
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :25 :34) // Not a variable of known type: output
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :25 :16) // Console.WriteLine(output) (InvocationExpression)
br ^2

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: IsLogFile
%14 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :27 :16) // IsLogFile() (InvocationExpression)
cond_br %14, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :27 :16)

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: WriteLog
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :28 :25) // Not a variable of known type: output
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :28 :16) // WriteLog(output) (InvocationExpression)
br ^4

^4: // ExitBlock
return

}
func @_Newtone.Core.Logic.ConsoleDebug.WriteLine$object$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :31 :8) {
^entry (%_o : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :31 :37)
cbde.store %_o, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :31 :37)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :28) // "[" (StringLiteralExpression)
// Entity from another assembly: DateTime
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :34) // DateTime.Now (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :34) // DateTime.Now.ToString() (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString()
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :60) // "]: " (StringLiteralExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: "
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :68) // Not a variable of known type: o
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :33 :28) // Binary expression on unsupported types "[" + DateTime.Now.ToString() + "]: " + o
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :34 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%11 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :34 :16) // GlobalData.Current.IsDebugMode (SimpleMemberAccessExpression)
cond_br %11, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :34 :16)

^1: // SimpleBlock
// Entity from another assembly: Console
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :35 :34) // Not a variable of known type: output
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :35 :16) // Console.WriteLine(output) (InvocationExpression)
br ^2

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: IsLogFile
%14 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :37 :16) // IsLogFile() (InvocationExpression)
cond_br %14, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :37 :16)

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: WriteLog
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :38 :25) // Not a variable of known type: output
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :38 :16) // WriteLog(output) (InvocationExpression)
br ^4

^4: // ExitBlock
return

}
func @_Newtone.Core.Logic.ConsoleDebug.SetLogfile$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :41 :8) {
^entry (%_filepath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :41 :38)
cbde.store %_filepath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :41 :38)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :43 :23) // Not a variable of known type: filepath
br ^1

^1: // ExitBlock
return

}
// Skipping function WriteLog(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Logic.ConsoleDebug.IsLogFile$$() -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :61 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :63 :20) // string (PredefinedType)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :63 :41) // Not a variable of known type: savePath
%2 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :63 :20) // string.IsNullOrEmpty(savePath) (InvocationExpression)
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :63 :19) // !string.IsNullOrEmpty(savePath) (LogicalNotExpression)
return %3 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ConsoleDebug.cs" :63 :12)

^1: // ExitBlock
cbde.unreachable

}
