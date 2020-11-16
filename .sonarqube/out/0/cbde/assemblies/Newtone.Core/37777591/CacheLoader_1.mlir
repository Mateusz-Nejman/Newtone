func @_Newtone.Core.Loaders.CacheLoader.IsCacheAvailable$$() -> i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :12 :8) {
^entry :
br ^0

^0: // JumpBlock
// Entity from another assembly: File
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :31) // GlobalData.Current (SimpleMemberAccessExpression)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :31) // GlobalData.Current.DataPath (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :61) // "/cache.nsec2" (StringLiteralExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :31) // Binary expression on unsupported types GlobalData.Current.DataPath + "/cache.nsec2"
%4 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :19) // File.Exists(GlobalData.Current.DataPath + "/cache.nsec2") (InvocationExpression)
return %4 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\CacheLoader.cs" :14 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function LoadCache(), it contains poisonous unsupported syntaxes

// Skipping function SaveCache(), it contains poisonous unsupported syntaxes

