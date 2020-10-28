// Skipping function Connect(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Processing.SyncProcessing.Disconnect$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :91 :8) {
^entry :
br ^0

^0: // BinaryBranchBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :93 :34) // null (NullLiteralExpression)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :94 :15) // Not a variable of known type: CurrentConnection
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :94 :36) // null (NullLiteralExpression)
%3 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :94 :15) // comparison of unknown type: CurrentConnection != null
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :94 :15)

^1: // SimpleBlock
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :96 :16) // Not a variable of known type: CurrentConnection
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :96 :16) // CurrentConnection.Close() (InvocationExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :97 :16) // Not a variable of known type: CurrentConnection
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :97 :16) // CurrentConnection.Dispose() (InvocationExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :98 :36) // null (NullLiteralExpression)
br ^2

^2: // SimpleBlock
%9 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :100 :25)
%10 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :101 :20)
%11 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :102 :22) // false
br ^3

^3: // ExitBlock
return

}
// Skipping function ListenReceiver(), it contains poisonous unsupported syntaxes

// Skipping function Receive(), it contains poisonous unsupported syntaxes

// Skipping function Send(), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Processing.SyncProcessing.AddFile$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :269 :8) {
^entry (%_filepath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :269 :35)
cbde.store %_filepath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :269 :35)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :271 :17) // Not a variable of known type: Audios
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :271 :33) // Not a variable of known type: filepath
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :271 :17) // Audios.Contains(filepath) (InvocationExpression)
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :271 :16) // !Audios.Contains(filepath) (LogicalNotExpression)
cond_br %4, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :271 :16)

^1: // SimpleBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :272 :16) // Not a variable of known type: Audios
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :272 :27) // Not a variable of known type: filepath
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :272 :16) // Audios.Add(filepath) (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
// Skipping function AddFiles(none), it contains poisonous unsupported syntaxes

// Skipping function Verify(none), it contains poisonous unsupported syntaxes

// Skipping function ChceckEnabled(i1, i32, i1), it contains poisonous unsupported syntaxes

// Skipping function PrepareFilesToSend(none), it contains poisonous unsupported syntaxes

// Skipping function Unpack(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Processing.SyncProcessing.ToHex$System.Net.IPAddress$(none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :392 :8) {
^entry (%_addr : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :392 :36)
cbde.store %_addr, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :392 :36)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :30) // Not a variable of known type: addr
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :30) // addr.GetAddressBytes() (InvocationExpression)
%3 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :53)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :30) // addr.GetAddressBytes()[0] (ElementAccessExpression)
%5 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :25) // (int)addr.GetAddressBytes()[0] (CastExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :66) // "X" (StringLiteralExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :24) // ((int)addr.GetAddressBytes()[0]).ToString("X") (InvocationExpression)
%8 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :79)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :82) // '0' (CharacterLiteralExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :394 :24) // ((int)addr.GetAddressBytes()[0]).ToString("X").PadLeft(2, '0') (InvocationExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :30) // Not a variable of known type: addr
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :30) // addr.GetAddressBytes() (InvocationExpression)
%14 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :53)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :30) // addr.GetAddressBytes()[1] (ElementAccessExpression)
%16 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :25) // (int)addr.GetAddressBytes()[1] (CastExpression)
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :66) // "X" (StringLiteralExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :24) // ((int)addr.GetAddressBytes()[1]).ToString("X") (InvocationExpression)
%19 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :79)
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :82) // '0' (CharacterLiteralExpression)
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :395 :24) // ((int)addr.GetAddressBytes()[1]).ToString("X").PadLeft(2, '0') (InvocationExpression)
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :30) // Not a variable of known type: addr
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :30) // addr.GetAddressBytes() (InvocationExpression)
%25 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :53)
%26 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :30) // addr.GetAddressBytes()[2] (ElementAccessExpression)
%27 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :25) // (int)addr.GetAddressBytes()[2] (CastExpression)
%28 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :66) // "X" (StringLiteralExpression)
%29 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :24) // ((int)addr.GetAddressBytes()[2]).ToString("X") (InvocationExpression)
%30 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :79)
%31 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :82) // '0' (CharacterLiteralExpression)
%32 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :396 :24) // ((int)addr.GetAddressBytes()[2]).ToString("X").PadLeft(2, '0') (InvocationExpression)
%34 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :30) // Not a variable of known type: addr
%35 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :30) // addr.GetAddressBytes() (InvocationExpression)
%36 = constant 3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :53)
%37 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :30) // addr.GetAddressBytes()[3] (ElementAccessExpression)
%38 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :25) // (int)addr.GetAddressBytes()[3] (CastExpression)
%39 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :66) // "X" (StringLiteralExpression)
%40 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :24) // ((int)addr.GetAddressBytes()[3]).ToString("X") (InvocationExpression)
%41 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :79)
%42 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :82) // '0' (CharacterLiteralExpression)
%43 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :397 :24) // ((int)addr.GetAddressBytes()[3]).ToString("X").PadLeft(2, '0') (InvocationExpression)
%45 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :19) // string (PredefinedType)
%46 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :33) // Not a variable of known type: c1
%47 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :36) // Not a variable of known type: c2
%48 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :39) // Not a variable of known type: c3
%49 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :42) // Not a variable of known type: c4
%50 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :19) // string.Concat(c1,c2,c3,c4) (InvocationExpression)
return %50 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :398 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Processing.SyncProcessing.FromHex$string$(none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :401 :8) {
^entry (%_hex : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :401 :41)
cbde.store %_hex, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :401 :41)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :24) // Not a variable of known type: hex
%2 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :28)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :24) // hex[0] (ElementAccessExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :24) // hex[0].ToString() (InvocationExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :44) // Not a variable of known type: hex
%6 = constant 1 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :48)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :44) // hex[1] (ElementAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :44) // hex[1].ToString() (InvocationExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :403 :24) // Binary expression on unsupported types hex[0].ToString() + hex[1].ToString()
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :24) // Not a variable of known type: hex
%12 = constant 2 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :28)
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :24) // hex[2] (ElementAccessExpression)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :24) // hex[2].ToString() (InvocationExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :44) // Not a variable of known type: hex
%16 = constant 3 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :48)
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :44) // hex[3] (ElementAccessExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :44) // hex[3].ToString() (InvocationExpression)
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :404 :24) // Binary expression on unsupported types hex[2].ToString() + hex[3].ToString()
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :24) // Not a variable of known type: hex
%22 = constant 4 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :28)
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :24) // hex[4] (ElementAccessExpression)
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :24) // hex[4].ToString() (InvocationExpression)
%25 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :44) // Not a variable of known type: hex
%26 = constant 5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :48)
%27 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :44) // hex[5] (ElementAccessExpression)
%28 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :44) // hex[5].ToString() (InvocationExpression)
%29 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :405 :24) // Binary expression on unsupported types hex[4].ToString() + hex[5].ToString()
%31 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :24) // Not a variable of known type: hex
%32 = constant 6 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :28)
%33 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :24) // hex[6] (ElementAccessExpression)
%34 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :24) // hex[6].ToString() (InvocationExpression)
%35 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :44) // Not a variable of known type: hex
%36 = constant 7 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :48)
%37 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :44) // hex[7] (ElementAccessExpression)
%38 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :44) // hex[7].ToString() (InvocationExpression)
%39 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :406 :24) // Binary expression on unsupported types hex[6].ToString() + hex[7].ToString()
%41 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :42) //  (OmittedArraySizeExpression)
%42 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :37) // byte[] (ArrayType)
%43 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :33) // new byte[] { (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) } (ArrayCreationExpression)
%44 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :52) // int (PredefinedType)
%45 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :62) // Not a variable of known type: h1
// Entity from another assembly: System
%46 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :66) // System.Globalization.NumberStyles (SimpleMemberAccessExpression)
%47 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :66) // System.Globalization.NumberStyles.HexNumber (SimpleMemberAccessExpression)
%48 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :52) // int.Parse(h1, System.Globalization.NumberStyles.HexNumber) (InvocationExpression)
%49 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :46) // (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber) (CastExpression)
%50 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :118) // int (PredefinedType)
%51 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :128) // Not a variable of known type: h2
// Entity from another assembly: System
%52 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :132) // System.Globalization.NumberStyles (SimpleMemberAccessExpression)
%53 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :132) // System.Globalization.NumberStyles.HexNumber (SimpleMemberAccessExpression)
%54 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :118) // int.Parse(h2, System.Globalization.NumberStyles.HexNumber) (InvocationExpression)
%55 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :112) // (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber) (CastExpression)
%56 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :184) // int (PredefinedType)
%57 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :194) // Not a variable of known type: h3
// Entity from another assembly: System
%58 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :198) // System.Globalization.NumberStyles (SimpleMemberAccessExpression)
%59 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :198) // System.Globalization.NumberStyles.HexNumber (SimpleMemberAccessExpression)
%60 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :184) // int.Parse(h3, System.Globalization.NumberStyles.HexNumber) (InvocationExpression)
%61 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :178) // (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber) (CastExpression)
%62 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :250) // int (PredefinedType)
%63 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :260) // Not a variable of known type: h4
// Entity from another assembly: System
%64 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :264) // System.Globalization.NumberStyles (SimpleMemberAccessExpression)
%65 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :264) // System.Globalization.NumberStyles.HexNumber (SimpleMemberAccessExpression)
%66 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :250) // int.Parse(h4, System.Globalization.NumberStyles.HexNumber) (InvocationExpression)
%67 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :244) // (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) (CastExpression)
%68 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :19) // new IPAddress(new byte[] { (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) }) (ObjectCreationExpression)
return %68 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Processing\\SyncProcessing.cs" :408 :12)

^1: // ExitBlock
cbde.unreachable

}
