func @_Newtone.Core.GlobalData.Initialize$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :89 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :91 :22) // new Dictionary<string, List<string>>() (ObjectCreationExpression)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :92 :21) // new Dictionary<string, Newtone.Core.Media.MediaSource>() (ObjectCreationExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :26) // new Dictionary<string, MediaSource>() (ObjectCreationExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :94 :24) // new Dictionary<string, MediaSourceTag>() (ObjectCreationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :95 :28) // new List<string>() (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :96 :30) // new List<Newtone.Core.Media.MediaSource>() (ObjectCreationExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :97 :34) // new Dictionary<string, string>() (ObjectCreationExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :98 :34) // new Dictionary<string, string>() (ObjectCreationExpression)
// Entity from another assembly: System
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :23) // System.Environment (SimpleMemberAccessExpression)
// Entity from another assembly: System
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :56) // System.Environment (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :56) // System.Environment.SpecialFolder (SimpleMemberAccessExpression)
%11 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :56) // System.Environment.SpecialFolder.LocalApplicationData (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :23) // System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) (InvocationExpression)
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :101 :22) // new List<Newtone.Core.Models.HistoryModel>() (ObjectCreationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%14 = constant 5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :102 :61)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :102 :29) // Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayType)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :102 :25) // new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayCreationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%17 = constant 5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :103 :61)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :103 :29) // Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayType)
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :103 :25) // new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayCreationExpression)
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :105 :25) // Not a variable of known type: PlayerMode
%21 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :105 :25) // PlayerMode.All (SimpleMemberAccessExpression)
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :106 :24) // new Dictionary<string, List<string>>() (ObjectCreationExpression)
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :108 :28) // new List<string>() (ObjectCreationExpression)
%24 = constant 0 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :109 :30) // false
br ^1

^1: // ExitBlock
return

}
// Skipping function LoadConfig(), it contains poisonous unsupported syntaxes

// Skipping function SaveConfig(), it contains poisonous unsupported syntaxes

// Skipping function SaveTags(), it contains poisonous unsupported syntaxes

// Skipping function LoadTags(), it contains poisonous unsupported syntaxes

// Skipping function SaveSavedTracks(), it contains poisonous unsupported syntaxes

// Skipping function LoadSavedTracks(), it contains poisonous unsupported syntaxes

