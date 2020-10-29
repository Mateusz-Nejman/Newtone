// Skipping function Load(), it contains poisonous unsupported syntaxes

// Skipping function AddTrack(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Loaders.GlobalLoader.RemoveTrack$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :43 :8) {
^entry (%_filePath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :43 :39)
cbde.store %_filePath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :43 :39)
br ^0

^0: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :45 :33) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :45 :33) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :45 :59) // Not a variable of known type: filePath
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :45 :33) // GlobalData.Current.Audios[filePath] (ElementAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :12) // GlobalData.Current.Artists (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :39) // Not a variable of known type: source
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :39) // source.Artist (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :12) // GlobalData.Current.Artists[source.Artist] (ElementAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :61) // Not a variable of known type: source
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :61) // source.FilePath (SimpleMemberAccessExpression)
%13 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :12) // GlobalData.Current.Artists[source.Artist].Remove(source.FilePath) (InvocationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16) // GlobalData.Current.Artists (SimpleMemberAccessExpression)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :43) // Not a variable of known type: source
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :43) // source.Artist (SimpleMemberAccessExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16) // GlobalData.Current.Artists[source.Artist] (ElementAccessExpression)
%19 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16) // GlobalData.Current.Artists[source.Artist].Count (SimpleMemberAccessExpression)
%20 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :67)
%21 = cmpi "eq", %19, %20 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16)
cond_br %21, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :16)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%23 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current.ArtistsNeedRefresh (SimpleMemberAccessExpression)
%24 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :56) // true
br ^2

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%25 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :50 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%26 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :50 :16) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%27 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :50 :54) // Not a variable of known type: filePath
%28 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :50 :16) // GlobalData.Current.Audios.ContainsKey(filePath) (InvocationExpression)
cond_br %28, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :50 :16)

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%29 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%30 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%31 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :49) // Not a variable of known type: filePath
%32 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current.Audios.Remove(filePath) (InvocationExpression)
br ^4

^4: // ExitBlock
return

}
// Skipping function ChangeTrack(none, none), it contains poisonous unsupported syntaxes

