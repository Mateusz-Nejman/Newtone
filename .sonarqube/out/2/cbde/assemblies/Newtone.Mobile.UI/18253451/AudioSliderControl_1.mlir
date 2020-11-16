// Skipping function AudioSlider_ValueChanged(none, none), it contains poisonous unsupported syntaxes

func @_Newtone.Mobile.UI.Views.Custom.AudioSliderControl.OnValueWithoutBaseEventsChanged$Xamarin.Forms.BindableObject.object.object$(none, none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :8) {
^entry (%_bindable : none, %_oldValue : none, %_newValue : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :60)
cbde.store %_bindable, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :60)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :85)
cbde.store %_oldValue, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :85)
%2 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :102)
cbde.store %_newValue, %2 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :55 :102)
br ^0

^0: // SimpleBlock
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :57 :12) // Not a variable of known type: Instance
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :57 :12) // Instance.ValueWithoutBaseEvents (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :57 :54) // Not a variable of known type: newValue
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :57 :46) // (double)newValue (CastExpression)
br ^1

^1: // ExitBlock
return

}
func @_Newtone.Mobile.UI.Views.Custom.AudioSliderControl.OnMaxWithoutBaseEventsChanged$Xamarin.Forms.BindableObject.object.object$(none, none, none) -> () loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :8) {
^entry (%_bindable : none, %_oldValue : none, %_newValue : none):
%0 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :58)
cbde.store %_bindable, %0 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :58)
%1 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :83)
cbde.store %_oldValue, %1 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :83)
%2 = cbde.alloca none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :100)
cbde.store %_newValue, %2 : memref<none> loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :60 :100)
br ^0

^0: // SimpleBlock
%3 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :62 :12) // Not a variable of known type: Instance
%4 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :62 :12) // Instance.MaxWithoutBaseEvents (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :62 :52) // Not a variable of known type: newValue
%6 = cbde.unknown : none loc("D:\\Projekty\\CS\\Newtone\\Newtone.Mobile.UI\\Views\\Custom\\AudioSliderControl.cs" :62 :44) // (double)newValue (CastExpression)
br ^1

^1: // ExitBlock
return

}
