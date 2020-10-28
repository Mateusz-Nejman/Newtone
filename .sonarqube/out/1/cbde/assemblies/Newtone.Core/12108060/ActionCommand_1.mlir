func @_Newtone.Core.Logic.ActionCommand.CanExecute$object$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ActionCommand.cs" :21 :8) {
^entry (%_parameter : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ActionCommand.cs" :21 :31)
cbde.store %_parameter, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ActionCommand.cs" :21 :31)
br ^0

^0: // JumpBlock
%1 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ActionCommand.cs" :23 :19) // true
return %1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ActionCommand.cs" :23 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function Execute(none), it contains poisonous unsupported syntaxes

