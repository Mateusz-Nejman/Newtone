func @_Newtone.Mobile.UI.Views.TV.ViewCells.SettingsViewCell.SettingsViewCell_LayoutChanged$object.System.EventArgs$(none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :16 :8) {
^entry (%_sender : none, %_e : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :16 :52)
cbde.store %_sender, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :16 :52)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :16 :67)
cbde.store %_e, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :16 :67)
br ^0

^0: // SimpleBlock
// Entity from another assembly: LayoutOptions
%2 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\TV\\ViewCells\\SettingsViewCell.xaml.cs" :18 :32) // LayoutOptions.StartAndExpand (SimpleMemberAccessExpression)
br ^1

^1: // ExitBlock
return

}
