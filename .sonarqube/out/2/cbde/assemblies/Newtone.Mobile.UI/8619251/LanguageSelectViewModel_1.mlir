func @_Newtone.Mobile.UI.ViewModels.LanguageSelectViewModel.ChangeLanguage$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :80 :8) {
^entry (%_lang : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :80 :36)
cbde.store %_lang, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :80 :36)
br ^0

^0: // BinaryBranchBlock
// Entity from another assembly: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :82 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :82 :12) // GlobalData.Current.CurrentLanguage (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :82 :49) // Not a variable of known type: lang
// Entity from another assembly: Localization
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :83 :12) // Localization.RefreshLanguage() (InvocationExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :84 :16) // Not a variable of known type: NextPage
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :84 :28) // "permissions" (StringLiteralExpression)
%7 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :84 :16) // comparison of unknown type: NextPage == "permissions"
cond_br %7, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :84 :16)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: App
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :85 :16) // App.Instance (SimpleMemberAccessExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :85 :16) // App.Instance.MainPage (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :85 :40) // new PermissionPage() (ObjectCreationExpression)
br ^3

^2: // BinaryBranchBlock
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :86 :21) // Not a variable of known type: NextPage
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :86 :33) // "firststart" (StringLiteralExpression)
%13 = cbde.unknown : i1  loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :86 :21) // comparison of unknown type: NextPage == "firststart"
cond_br %13, ^4, ^3 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :86 :21)

^4: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: App
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :87 :16) // App.Instance (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :87 :16) // App.Instance.MainPage (SimpleMemberAccessExpression)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\ViewModels\\LanguageSelectViewModel.cs" :87 :40) // new FirstStartPage() (ObjectCreationExpression)
br ^3

^3: // ExitBlock
return

}
