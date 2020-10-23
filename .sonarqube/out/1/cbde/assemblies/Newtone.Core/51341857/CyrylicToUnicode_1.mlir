func @_Newtone.Core.Logic.CyrylicToUnicode.Convert$string$(none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :8 :8) {
^entry (%_cyrylicString : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :8 :37)
cbde.store %_cyrylicString, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :8 :37)
br ^0

^0: // ForInitializerBlock
%1 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :12 :36) // cyrylicChars (IdentifierName)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :12 :55) // ';' (CharacterLiteralExpression)
// Entity from another assembly: StringSplitOptions
%3 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :12 :60) // StringSplitOptions.None (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :12 :36) // cyrylicChars.Split(';', StringSplitOptions.None) (InvocationExpression)
%6 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :13 :36) // cyrylicToUnicodeChars (IdentifierName)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :13 :64) // ';' (CharacterLiteralExpression)
// Entity from another assembly: StringSplitOptions
%8 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :13 :69) // StringSplitOptions.None (SimpleMemberAccessExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :13 :36) // cyrylicToUnicodeChars.Split(';', StringSplitOptions.None) (InvocationExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :15 :39) // Not a variable of known type: cyrylicString
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :15 :39) // cyrylicString.Clone() (InvocationExpression)
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :15 :31) // (string)cyrylicString.Clone() (CastExpression)
%15 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :24)
%16 = cbde.alloca i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :20) // a
cbde.store %15, %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :20)
br ^1

^1: // BinaryBranchBlock
%17 = cbde.load %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :27)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :31) // Not a variable of known type: cyrylicArray
%19 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :31) // cyrylicArray.Length (SimpleMemberAccessExpression)
%20 = cmpi "slt", %17, %19 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :27)
cond_br %20, ^2, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :27)

^2: // SimpleBlock
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :28) // Not a variable of known type: newString
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :46) // Not a variable of known type: cyrylicArray
%23 = cbde.load %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :59)
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :46) // cyrylicArray[a] (ElementAccessExpression)
%25 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :63) // Not a variable of known type: unicodeArray
%26 = cbde.load %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :76)
%27 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :63) // unicodeArray[a] (ElementAccessExpression)
%28 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :19 :28) // newString.Replace(cyrylicArray[a], unicodeArray[a]) (InvocationExpression)
br ^4

^4: // SimpleBlock
%29 = cbde.load %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :52)
%30 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :52)
%31 = addi %29, %30 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :52)
cbde.store %31, %16 : memref<i32> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :17 :52)
br ^1

^3: // JumpBlock
%32 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :22 :19) // Not a variable of known type: newString
return %32 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\CyrylicToUnicode.cs" :22 :12)

^5: // ExitBlock
cbde.unreachable

}
// Skipping function IsCyrylic(none), it contains poisonous unsupported syntaxes

