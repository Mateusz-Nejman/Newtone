// Skipping function BuildForTrack(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Logic.ContextMenuBuilder.BuildForPlaylist$Xamarin.Forms.View.string$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :40 :8) {
^entry (%_sender : none, %_playlistName : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :40 :44)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :40 :44)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :40 :57)
cbde.store %_playlistName, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :40 :57)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :36) // new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue, Localization.ChangeName, Localization.TrackMenuDelete } (ObjectCreationExpression)
// Entity from another assembly: Localization
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :57) // Localization.PlaylistPlay (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :84) // Localization.TrackMenuPlaylist (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :116) // Localization.TrackMenuQueue (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :145) // Localization.ChangeName (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :42 :170) // Localization.TrackMenuDelete (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :44 :12) // Global.ContextMenuBuilder (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :44 :55) // Not a variable of known type: sender
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :44 :63) // Not a variable of known type: playlistName
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :44 :77) // Not a variable of known type: elements
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: PlaylistAction
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :44 :12) // Global.ContextMenuBuilder.BuildForPlaylist(sender, playlistName, elements, PlaylistAction) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Logic.ContextMenuBuilder.BuildForArtist$Xamarin.Forms.View.string$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :47 :8) {
^entry (%_sender : none, %_artistName : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :47 :42)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :47 :42)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :47 :55)
cbde.store %_artistName, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :47 :55)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :49 :36) // new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue } (ObjectCreationExpression)
// Entity from another assembly: Localization
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :49 :57) // Localization.PlaylistPlay (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :49 :84) // Localization.TrackMenuPlaylist (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :49 :116) // Localization.TrackMenuQueue (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :51 :12) // Global.ContextMenuBuilder (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :51 :53) // Not a variable of known type: sender
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :51 :61) // Not a variable of known type: artistName
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :51 :73) // Not a variable of known type: elements
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: ArtistAction
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :51 :12) // Global.ContextMenuBuilder.BuildForArtist(sender, artistName, elements, ArtistAction) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Logic.ContextMenuBuilder.BuildForSearchResult$Xamarin.Forms.View.string$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :54 :8) {
^entry (%_sender : none, %_modelInfo : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :54 :48)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :54 :48)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :54 :61)
cbde.store %_modelInfo, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :54 :61)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :56 :36) // new List<string>() { Localization.Download, Localization.TrackMenuPlaylist } (ObjectCreationExpression)
// Entity from another assembly: Localization
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :56 :57) // Localization.Download (SimpleMemberAccessExpression)
// Entity from another assembly: Localization
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :56 :80) // Localization.TrackMenuPlaylist (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: Global
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :58 :12) // Global.ContextMenuBuilder (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :58 :59) // Not a variable of known type: sender
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :58 :67) // Not a variable of known type: modelInfo
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :58 :78) // Not a variable of known type: elements
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: SearchResultAction
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Logic\\ContextMenuBuilder.cs" :58 :12) // Global.ContextMenuBuilder.BuildForSearchResult(sender, modelInfo, elements, SearchResultAction) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function TrackAction(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function PlaylistAction(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function ArtistAction(none, none, none), it contains poisonous unsupported syntaxes

// Skipping function SearchResultAction(none, none, none), it contains poisonous unsupported syntaxes

