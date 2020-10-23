func @_Newtone.Core.Media.MediaSource.Clone$$() -> none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :25 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :27 :19) // new MediaSource()              {                  Title = this.Title,                  Artist = this.Artist,                  Duration = this.Duration,                  FilePath = this.FilePath,                  Image = this.Image,                  Type = this.Type              } (ObjectCreationExpression)
%1 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :29 :24) // this (ThisExpression)
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :29 :24) // this.Title (SimpleMemberAccessExpression)
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :30 :25) // this (ThisExpression)
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :30 :25) // this.Artist (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :31 :27) // this (ThisExpression)
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :31 :27) // this.Duration (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :32 :27) // this (ThisExpression)
%8 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :32 :27) // this.FilePath (SimpleMemberAccessExpression)
%9 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :33 :24) // this (ThisExpression)
%10 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :33 :24) // this.Image (SimpleMemberAccessExpression)
%11 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :34 :23) // this (ThisExpression)
%12 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :34 :23) // this.Type (SimpleMemberAccessExpression)
return %0 : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Core\\Media\\MediaSource.cs" :27 :12)

^1: // ExitBlock
cbde.unreachable

}
