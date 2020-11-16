// Skipping function Load(), it contains poisonous unsupported syntaxes

// Skipping function AddTrack(none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Loaders.GlobalLoader.RemoveTrack$string$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :44 :8) {
^entry (%_filePath : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :44 :39)
cbde.store %_filePath, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :44 :39)
br ^0

^0: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :33) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :33) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :59) // Not a variable of known type: filePath
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :46 :33) // GlobalData.Current.Audios[filePath] (ElementAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :12) // GlobalData.Current (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :12) // GlobalData.Current.Artists (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :39) // Not a variable of known type: source
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :39) // source.Artist (SimpleMemberAccessExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :12) // GlobalData.Current.Artists[source.Artist] (ElementAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :61) // Not a variable of known type: source
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :61) // source.FilePath (SimpleMemberAccessExpression)
%13 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :47 :12) // GlobalData.Current.Artists[source.Artist].Remove(source.FilePath) (InvocationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current.Artists (SimpleMemberAccessExpression)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :43) // Not a variable of known type: source
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :43) // source.Artist (SimpleMemberAccessExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current.Artists[source.Artist] (ElementAccessExpression)
%19 = cbde.unknown : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16) // GlobalData.Current.Artists[source.Artist].Count (SimpleMemberAccessExpression)
%20 = constant 0 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :67)
%21 = cmpi "eq", %19, %20 : i32 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16)
cond_br %21, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :48 :16)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :49 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%23 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :49 :16) // GlobalData.Current.ArtistsNeedRefresh (SimpleMemberAccessExpression)
%24 = constant 1 : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :49 :56) // true
br ^2

^2: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%25 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%26 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%27 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :54) // Not a variable of known type: filePath
%28 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16) // GlobalData.Current.Audios.ContainsKey(filePath) (InvocationExpression)
cond_br %28, ^3, ^4 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :51 :16)

^3: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%29 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :52 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%30 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :52 :16) // GlobalData.Current.Audios (SimpleMemberAccessExpression)
%31 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :52 :49) // Not a variable of known type: filePath
%32 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :52 :16) // GlobalData.Current.Audios.Remove(filePath) (InvocationExpression)
br ^4

^4: // ExitBlock
return

}
// Skipping function ChangeTrack(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Core.Loaders.GlobalLoader.AddSavedTrack$YoutubeExplode.Videos.Video$(none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :93 :8) {
^entry (%_video : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :93 :41)
cbde.store %_video, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :93 :41)
br ^0

^0: // BinaryBranchBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :16) // GlobalData.Current.SavedTracks (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :59) // Not a variable of known type: video
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :59) // video.Id (SimpleMemberAccessExpression)
%5 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :16) // GlobalData.Current.SavedTracks.ContainsKey(video.Id) (InvocationExpression)
%6 = cbde.unknown : i1 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :15) // !GlobalData.Current.SavedTracks.ContainsKey(video.Id) (LogicalNotExpression)
cond_br %6, ^1, ^2 loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :95 :15)

^1: // SimpleBlock
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :16) // GlobalData.Current.SavedTracks (SimpleMemberAccessExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :51) // Not a variable of known type: video
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :51) // video.Id (SimpleMemberAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :61) // new MediaSource() { Artist = video.Author, Title = video.Title, Duration = video.Duration, FilePath = video.Id, Type = MediaSource.SourceType.Web } (ObjectCreationExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :90) // Not a variable of known type: video
%13 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :90) // video.Author (SimpleMemberAccessExpression)
%14 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :112) // Not a variable of known type: video
%15 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :112) // video.Title (SimpleMemberAccessExpression)
%16 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :136) // Not a variable of known type: video
%17 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :136) // video.Duration (SimpleMemberAccessExpression)
%18 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :163) // Not a variable of known type: video
%19 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :163) // video.Id (SimpleMemberAccessExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: MediaSource
%20 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :180) // MediaSource.SourceType (SimpleMemberAccessExpression)
%21 = constant unit loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :180) // MediaSource.SourceType.Web (SimpleMemberAccessExpression)
%22 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :97 :16) // GlobalData.Current.SavedTracks.Add(video.Id, new MediaSource() { Artist = video.Author, Title = video.Title, Duration = video.Duration, FilePath = video.Id, Type = MediaSource.SourceType.Web }) (InvocationExpression)
// Skipped because MethodDeclarationSyntax or ClassDeclarationSyntax or NamespaceDeclarationSyntax: GlobalData
%23 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :98 :16) // GlobalData.Current (SimpleMemberAccessExpression)
%24 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Loaders\\GlobalLoader.cs" :98 :16) // GlobalData.Current.SaveSavedTracks() (InvocationExpression)
br ^2

^2: // ExitBlock
return

}
// Skipping function RemoveSavedTrack(none), it contains poisonous unsupported syntaxes

// Skipping function ReplaceSavedTrack(none, none), it contains poisonous unsupported syntaxes

