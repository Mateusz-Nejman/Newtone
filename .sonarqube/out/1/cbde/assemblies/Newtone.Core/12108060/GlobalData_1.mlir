func @_Newtone.Core.GlobalData.Initialize$$() -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :85 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :87 :22) // new Dictionary<string, List<string>>() (ObjectCreationExpression)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :88 :21) // new Dictionary<string, Newtone.Core.Media.MediaSource>() (ObjectCreationExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :89 :24) // new Dictionary<string, MediaSourceTag>() (ObjectCreationExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :90 :28) // new List<string>() (ObjectCreationExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :91 :30) // new List<Newtone.Core.Media.MediaSource>() (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :92 :34) // new Dictionary<string, string>() (ObjectCreationExpression)
// Entity from another assembly: System
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :23) // System.Environment (SimpleMemberAccessExpression)
// Entity from another assembly: System
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :56) // System.Environment (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :56) // System.Environment.SpecialFolder (SimpleMemberAccessExpression)
%9 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :56) // System.Environment.SpecialFolder.LocalApplicationData (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :93 :23) // System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) (InvocationExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :95 :22) // new List<Newtone.Core.Models.HistoryModel>() (ObjectCreationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%12 = constant 5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :96 :61)
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :96 :29) // Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayType)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :96 :25) // new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayCreationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%15 = constant 5 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :97 :61)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :97 :29) // Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayType)
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :97 :25) // new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST] (ArrayCreationExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :25) // Not a variable of known type: PlayerMode
%19 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :99 :25) // PlayerMode.All (SimpleMemberAccessExpression)
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :100 :24) // new Dictionary<string, List<string>>() (ObjectCreationExpression)
%21 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\GlobalData.cs" :102 :28) // new List<string>() (ObjectCreationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function LoadConfig(), it contains poisonous unsupported syntaxes

// Skipping function SaveConfig(), it contains poisonous unsupported syntaxes

// Skipping function SaveTags(), it contains poisonous unsupported syntaxes

// Skipping function LoadTags(), it contains poisonous unsupported syntaxes

