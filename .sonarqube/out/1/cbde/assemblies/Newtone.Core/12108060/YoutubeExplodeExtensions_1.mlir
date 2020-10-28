func @_Newtone.Core.Logic.YoutubeExplodeExtensions.GetVideoMixPlaylistId$YoutubeExplode.Videos.Video$(none) -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :9 :8) {
^entry (%_video : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :9 :51)
cbde.store %_video, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :9 :51)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :11 :19) // "RD" (StringLiteralExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :11 :26) // Not a variable of known type: video
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :11 :26) // video.Id (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :11 :19) // Binary expression on unsupported types "RD" + video.Id
return %4 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :11 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_Newtone.Core.Logic.YoutubeExplodeExtensions.ValidateVideoId$string$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :17 :8) {
^entry (%_videoId : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :17 :43)
cbde.store %_videoId, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :17 :43)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :19 :16) // string (PredefinedType)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :19 :42) // Not a variable of known type: videoId
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :19 :16) // string.IsNullOrWhiteSpace(videoId) (InvocationExpression)
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :19 :16)

^1: // JumpBlock
%4 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :20 :23) // false
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :20 :16)

^2: // BinaryBranchBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :23 :16) // Not a variable of known type: videoId
%6 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :23 :16) // videoId.Length (SimpleMemberAccessExpression)
%7 = constant 11 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :23 :34)
%8 = cmpi "ne", %6, %7 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :23 :16)
cond_br %8, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :23 :16)

^3: // JumpBlock
%9 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :24 :23) // false
return %9 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :24 :16)

^4: // JumpBlock
// Entity from another assembly: Regex
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :26 :34) // Not a variable of known type: videoId
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :26 :43) // @"[^0-9a-zA-Z_\-]" (StringLiteralExpression)
%12 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :26 :20) // Regex.IsMatch(videoId, @"[^0-9a-zA-Z_\-]") (InvocationExpression)
%13 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :26 :19) // !Regex.IsMatch(videoId, @"[^0-9a-zA-Z_\-]") (LogicalNotExpression)
return %13 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :26 :12)

^5: // ExitBlock
cbde.unreachable

}
// Skipping function TryParseVideoId(none, none), it contains poisonous unsupported syntaxes

// Skipping function ValidatePlaylistId(none), it contains poisonous unsupported syntaxes

// Skipping function TryParsePlaylistId(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Logic.YoutubeExplodeExtensions.ValidateUsername$string$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :145 :8) {
^entry (%_username : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :145 :44)
cbde.store %_username, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :145 :44)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :147 :16) // string (PredefinedType)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :147 :42) // Not a variable of known type: username
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :147 :16) // string.IsNullOrWhiteSpace(username) (InvocationExpression)
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :147 :16)

^1: // JumpBlock
%4 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :148 :23) // false
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :148 :16)

^2: // BinaryBranchBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :151 :16) // Not a variable of known type: username
%6 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :151 :16) // username.Length (SimpleMemberAccessExpression)
%7 = constant 20 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :151 :34)
%8 = cmpi "sgt", %6, %7 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :151 :16)
cond_br %8, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :151 :16)

^3: // JumpBlock
%9 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :152 :23) // false
return %9 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :152 :16)

^4: // JumpBlock
// Entity from another assembly: Regex
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :154 :34) // Not a variable of known type: username
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :154 :44) // @"[^0-9a-zA-Z]" (StringLiteralExpression)
%12 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :154 :20) // Regex.IsMatch(username, @"[^0-9a-zA-Z]") (InvocationExpression)
%13 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :154 :19) // !Regex.IsMatch(username, @"[^0-9a-zA-Z]") (LogicalNotExpression)
return %13 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :154 :12)

^5: // ExitBlock
cbde.unreachable

}
// Skipping function TryParseUsername(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Logic.YoutubeExplodeExtensions.ValidateChannelId$string$(none) -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :181 :8) {
^entry (%_channelId : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :181 :45)
cbde.store %_channelId, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :181 :45)
br ^0

^0: // BinaryBranchBlock
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :183 :16) // string (PredefinedType)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :183 :42) // Not a variable of known type: channelId
%3 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :183 :16) // string.IsNullOrWhiteSpace(channelId) (InvocationExpression)
cond_br %3, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :183 :16)

^1: // JumpBlock
%4 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :184 :23) // false
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :184 :16)

^2: // BinaryBranchBlock
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :17) // Not a variable of known type: channelId
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :38) // "UC" (StringLiteralExpression)
// Entity from another assembly: StringComparison
%7 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :44) // StringComparison.Ordinal (SimpleMemberAccessExpression)
%8 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :17) // channelId.StartsWith("UC", StringComparison.Ordinal) (InvocationExpression)
%9 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :16) // !channelId.StartsWith("UC", StringComparison.Ordinal) (LogicalNotExpression)
cond_br %9, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :187 :16)

^3: // JumpBlock
%10 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :188 :23) // false
return %10 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :188 :16)

^4: // BinaryBranchBlock
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :191 :16) // Not a variable of known type: channelId
%12 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :191 :16) // channelId.Length (SimpleMemberAccessExpression)
%13 = constant 24 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :191 :36)
%14 = cmpi "ne", %12, %13 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :191 :16)
cond_br %14, ^5, ^6 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :191 :16)

^5: // JumpBlock
%15 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :192 :23) // false
return %15 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :192 :16)

^6: // JumpBlock
// Entity from another assembly: Regex
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :194 :34) // Not a variable of known type: channelId
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :194 :45) // @"[^0-9a-zA-Z_\-]" (StringLiteralExpression)
%18 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :194 :20) // Regex.IsMatch(channelId, @"[^0-9a-zA-Z_\-]") (InvocationExpression)
%19 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :194 :19) // !Regex.IsMatch(channelId, @"[^0-9a-zA-Z_\-]") (LogicalNotExpression)
return %19 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Logic\\YoutubeExplodeExtensions.cs" :194 :12)

^7: // ExitBlock
cbde.unreachable

}
// Skipping function TryParseChannelId(none, none), it contains poisonous unsupported syntaxes

