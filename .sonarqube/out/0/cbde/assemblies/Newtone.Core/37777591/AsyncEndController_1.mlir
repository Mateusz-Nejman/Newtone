func @_Newtone.Core.Logic.AsyncEndController.Invoke$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :10 :8) {
^entry (%_name : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :10 :27)
cbde.store %_name, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :10 :27)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :12 :16) // Not a variable of known type: listeners
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :12 :38) // Not a variable of known type: name
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :12 :16) // listeners.ContainsKey(name) (InvocationExpression)
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :12 :16)

^1: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :13 :16) // Not a variable of known type: listeners
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :13 :26) // Not a variable of known type: name
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :13 :16) // listeners[name] (ElementAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :13 :16) // listeners[name].AsyncEnd() (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
func @_Newtone.Core.Logic.AsyncEndController.Add$string.Newtone.Core.Logic.IAsyncEndListener$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :18 :8) {
^entry (%_name : none, %_listener : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :18 :24)
cbde.store %_name, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :18 :24)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :18 :37)
cbde.store %_listener, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :18 :37)
br ^0

^0: // BinaryBranchBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :20 :17) // Not a variable of known type: listeners
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :20 :39) // Not a variable of known type: name
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :20 :17) // listeners.ContainsKey(name) (InvocationExpression)
%5 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :20 :16) // !listeners.ContainsKey(name) (LogicalNotExpression)
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :20 :16)

^1: // SimpleBlock
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :21 :16) // Not a variable of known type: listeners
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :21 :30) // Not a variable of known type: name
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :21 :36) // Not a variable of known type: listener
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\AsyncEndController.cs" :21 :16) // listeners.Add(name, listener) (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
