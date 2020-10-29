func @_Newtone.Core.Processing.DownloadProcessing.GetModels$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :34 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :36 :19) // Not a variable of known type: Downloads
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :36 :19) // Downloads.Values (SimpleMemberAccessExpression)
return %1 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :36 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Processing.DownloadProcessing.GetDownloads$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :39 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :41 :19) // Not a variable of known type: Downloads
return %0 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :41 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function AddRange(none, none, none, i1), it contains poisonous unsupported syntaxes

// Skipping function Add(none, none, none, none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Processing.DownloadProcessing.SetProgress$string.double$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :181 :8) {
^entry (%_id : none, %_progress : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :181 :40)
cbde.store %_id, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :181 :40)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :181 :51)
cbde.store %_progress, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :181 :51)
br ^0

^0: // BinaryBranchBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :183 :15) // Not a variable of known type: Downloads
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :183 :37) // Not a variable of known type: id
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :183 :15) // Downloads.ContainsKey(id) (InvocationExpression)
cond_br %4, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :183 :15)

^1: // SimpleBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :185 :16) // Not a variable of known type: Downloads
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :185 :26) // Not a variable of known type: id
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :185 :16) // Downloads[id] (ElementAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :185 :16) // Downloads[id].Progress (SimpleMemberAccessExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\DownloadProcessing.cs" :185 :41) // Not a variable of known type: progress
br ^2

^2: // ExitBlock
return

}
// Skipping function TaskAction(), it contains poisonous unsupported syntaxes

// Skipping function Download(none), it contains poisonous unsupported syntaxes

