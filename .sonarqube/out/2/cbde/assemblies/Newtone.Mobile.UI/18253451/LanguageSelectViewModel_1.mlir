func @_Newtone.Mobile.UI.ViewModels.LanguageSelectViewModel.ChangeLanguage$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :64 :8) {
^entry (%_lang : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :64 :36)
cbde.store %_lang, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :64 :36)
br ^0

^0: // BinaryBranchBlock
// Entity from another assembly: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :66 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :66 :12) // GlobalData.Current.CurrentLanguage (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :66 :49) // Not a variable of known type: lang
// Entity from another assembly: Localization
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :67 :12) // Localization.RefreshLanguage() (InvocationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%5 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :68 :15) // Global.TV (SimpleMemberAccessExpression)
cond_br %5, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :68 :15)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: App
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :69 :16) // App.Instance (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :69 :16) // App.Instance.MainPage (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :69 :40) // new Views.TV.PermissionPage() (ObjectCreationExpression)
br ^3

^2: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: App
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :72 :16) // App.Instance (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :72 :16) // App.Instance.MainPage (SimpleMemberAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :72 :40) // new PermissionPage() (ObjectCreationExpression)
br ^3

^3: // ExitBlock
return

}
