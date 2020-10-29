// Skipping function Add(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Logic.ObservableBridge$T$.GetItems$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :28 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :30 :19) // Not a variable of known type: items
return %0 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :30 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Logic.ObservableBridge$T$.Clear$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :33 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :35 :12) // Not a variable of known type: items
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\ObservableBridge.cs" :35 :12) // items.Clear() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
