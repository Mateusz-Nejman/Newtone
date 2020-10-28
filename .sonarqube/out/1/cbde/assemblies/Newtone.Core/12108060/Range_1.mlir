func @_Newtone.Core.Logic.Range.GetRangeInt$int.int.int$(i32, i32, i32) -> i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :8) {
^entry (%_min : i32, %_max : i32, %_current : i32):
%0 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :38)
cbde.store %_min, %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :38)
%1 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :47)
cbde.store %_max, %1 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :47)
%2 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :56)
cbde.store %_current, %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :5 :56)
br ^0

^0: // BinaryBranchBlock
%3 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :7 :16)
%4 = cbde.load %1 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :7 :23)
%5 = cmpi "eq", %3, %4 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :7 :16)
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :7 :16)

^1: // JumpBlock
%6 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :8 :23)
return %6 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :8 :16)

^2: // BinaryBranchBlock
%7 = cbde.load %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :10 :16)
%8 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :10 :26)
%9 = cmpi "slt", %7, %8 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :10 :16)
cond_br %9, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :10 :16)

^3: // JumpBlock
%10 = cbde.load %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :27)
%11 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :37)
%12 = subi %10, %11 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :27)
%13 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :43)
%14 = addi %12, %13 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :27)
%15 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :20) // newC
cbde.store %14, %15 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :12 :20)
%16 = cbde.load %1 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :14 :23)
%17 = cbde.load %15 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :14 :29)
%18 = subi %16, %17 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :14 :23)
return %18 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :14 :16)

^4: // BinaryBranchBlock
%19 = cbde.load %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :17 :16)
%20 = cbde.load %1 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :17 :26)
%21 = cmpi "sgt", %19, %20 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :17 :16)
cond_br %21, ^5, ^6 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :17 :16)

^5: // JumpBlock
%22 = cbde.load %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :27)
%23 = cbde.load %1 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :37)
%24 = subi %22, %23 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :27)
%25 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :43)
%26 = subi %24, %25 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :27)
%27 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :20) // newC
cbde.store %26, %27 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :19 :20)
%28 = cbde.load %0 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :20 :23)
%29 = cbde.load %27 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :20 :29)
%30 = addi %28, %29 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :20 :23)
return %30 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :20 :16)

^6: // JumpBlock
%31 = cbde.load %2 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :23 :19)
return %31 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :23 :12)

^7: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Logic.Range.GetRangeDbl$double.double.double$(none, none, none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :8) {
^entry (%_min : none, %_max : none, %_current : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :41)
cbde.store %_min, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :41)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :53)
cbde.store %_max, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :53)
%2 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :65)
cbde.store %_current, %2 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :26 :65)
br ^0

^0: // BinaryBranchBlock
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :28 :16) // Not a variable of known type: min
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :28 :23) // Not a variable of known type: max
%5 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :28 :16) // comparison of unknown type: min == max
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :28 :16)

^1: // JumpBlock
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :29 :23) // Not a variable of known type: min
return %6 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :29 :16)

^2: // BinaryBranchBlock
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :31 :16) // Not a variable of known type: current
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :31 :26) // Not a variable of known type: min
%9 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :31 :16) // comparison of unknown type: current < min
cond_br %9, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :31 :16)

^3: // JumpBlock
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :33 :30) // Not a variable of known type: current
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :33 :40) // Not a variable of known type: min
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :33 :30) // Binary expression on unsupported types current - min
%13 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :33 :46)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :33 :30) // Binary expression on unsupported types current - min + 1
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :35 :23) // Not a variable of known type: max
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :35 :29) // Not a variable of known type: newC
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :35 :23) // Binary expression on unsupported types max - newC
return %18 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :35 :16)

^4: // BinaryBranchBlock
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :38 :16) // Not a variable of known type: current
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :38 :26) // Not a variable of known type: max
%21 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :38 :16) // comparison of unknown type: current > max
cond_br %21, ^5, ^6 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :38 :16)

^5: // JumpBlock
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :40 :30) // Not a variable of known type: current
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :40 :40) // Not a variable of known type: max
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :40 :30) // Binary expression on unsupported types current - max
%25 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :40 :46)
%26 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :40 :30) // Binary expression on unsupported types current - max - 1
%28 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :41 :23) // Not a variable of known type: min
%29 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :41 :29) // Not a variable of known type: newC
%30 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :41 :23) // Binary expression on unsupported types min + newC
return %30 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :41 :16)

^6: // JumpBlock
%31 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :44 :19) // Not a variable of known type: current
return %31 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\Range.cs" :44 :12)

^7: // ExitBlock
cbde.unreachable

}
// Skipping function InRangeInt(i32, i32, i32), it contains poisonous unsupported syntaxes

