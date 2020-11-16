�
4D:\Projekty\CS\Newtone\Newtone.Mobile.UI\App.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
{ 
public 

partial 
class 
App 
: 
Application *
{		 
public 
static 
App 
Instance "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
App 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
Instance 
= 
this 
; 
if 
( 
Global 
. 
Permissions "
." #
IsValid# *
(* +
)+ ,
&&- /
File0 4
.4 5
Exists5 ;
(; <

GlobalData< F
.F G
CurrentG N
.N O
DataPathO W
+X Y
$strZ j
)j k
)k l
{ 
if 
( 
Global 
. 
TV 
) 
{ 
MainPage 
= 
new "
Views# (
.( )
TV) +
.+ ,

NormalPage, 6
(6 7
)7 8
;8 9
} 
else 
{ 
MainPage 
= 
new "

NormalPage# -
(- .
). /
;/ 0
} 
} 
else 
{ 
if 
( 
Global 
. 
TV 
) 
{   
MainPage!! 
=!! 
new!! "
Views!!# (
.!!( )
TV!!) +
.!!+ ,
LanguageSelectPage!!, >
(!!> ?
)!!? @
;!!@ A
}"" 
else## 
{$$ 
MainPage%% 
=%% 
new%% "
LanguageSelectPage%%# 5
(%%5 6
)%%6 7
;%%7 8
}&& 
}'' 
}(( 	
}** 
}++ �
8D:\Projekty\CS\Newtone\Newtone.Mobile.UI\AssemblyInfo.cs
[ 
assembly 	
:	 

XamlCompilation 
( "
XamlCompilationOptions 1
.1 2
Compile2 9
)9 :
]: ;�
2D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Colors.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
{ 
public 

static 
class 
Colors 
{ 
public 
static 
Color 
ColorPrimary (
=>) +
Color, 1
.1 2
FromHex2 9
(9 :
$str: C
)C D
;D E
public

 
static

 
Color

 
ColorSecondary

 *
=>

+ -
Color

. 3
.

3 4
FromHex

4 ;
(

; <
$str

< E
)

E F
;

F G
public 
static 
Color 
ColorThirdary )
=>* ,
Color- 2
.2 3
FromHex3 :
(: ;
$str; D
)D E
;E F
public 
static 
Color 
	TextColor %
=>& (
Color) .
.. /
FromHex/ 6
(6 7
$str7 @
)@ A
;A B
public 
static 
Color 

BadgeColor &
=>' )
Color* /
./ 0
FromHex0 7
(7 8
$str8 A
)A B
;B C
public 
static 
Color 
ProgressBarColor ,
=>- /
Color0 5
.5 6
FromHex6 =
(= >
$str> G
)G H
;H I
} 
} �2
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\FocusContext.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

static 
class 
FocusContext $
{ 
private 
static 
readonly 
List  $
<$ %
INFocusElement% 3
>3 4
elements5 =
=> ?
new@ C
ListD H
<H I
INFocusElementI W
>W X
(X Y
)Y Z
;Z [
public 
static 
bool 
	FocusLeft $
($ %
INFocusElement% 3
element4 ;
); <
{		 	
return

 
ChangeFocus

 
(

 
element

 &
,

& '
element

( /
.

/ 0
NextFocusLeft

0 =
)

= >
;

> ?
} 	
public 
static 
bool 

FocusRight %
(% &
INFocusElement& 4
element5 <
)< =
{ 	
return 
ChangeFocus 
( 
element &
,& '
element( /
./ 0
NextFocusRight0 >
)> ?
;? @
} 	
public 
static 
bool 
FocusUp "
(" #
INFocusElement# 1
element2 9
)9 :
{ 	
return 
ChangeFocus 
( 
element &
,& '
element( /
./ 0
NextFocusUp0 ;
); <
;< =
} 	
public 
static 
bool 
	FocusDown $
($ %
INFocusElement% 3
element4 ;
); <
{ 	
return 
ChangeFocus 
( 
element &
,& '
element( /
./ 0
NextFocusDown0 =
)= >
;> ?
} 	
public 
static 
void 
Register #
(# $
INFocusElement$ 2
element3 :
): ;
{ 	
if 
( 
! 
elements 
. 
Contains "
(" #
element# *
)* +
)+ ,
elements 
. 
Add 
( 
element $
)$ %
;% &
}   	
public"" 
static"" 
void"" 

Unregister"" %
(""% &
INFocusElement""& 4
element""5 <
)""< =
{## 	
if$$ 
($$ 
elements$$ 
.$$ 
Contains$$ !
($$! "
element$$" )
)$$) *
)$$* +
elements%% 
.%% 
Remove%% 
(%%  
element%%  '
)%%' (
;%%( )
}&& 	
public(( 
static(( 
INFocusElement(( $
GetFocusElement((% 4
(((4 5
)((5 6
{)) 	
INFocusElement** 
focusElement** '
=**( )
null*** .
;**. /
foreach++ 
(++ 
var++ 
element++ 
in++  "
elements++# +
)+++ ,
{,, 
if-- 
(-- 
element-- 
.-- 

IsNFocused-- &
)--& '
focusElement..  
=..! "
element..# *
;..* +
}// 
if11 
(11 
focusElement11 
!=11 
null11  $
)11$ %
return22 
focusElement22 #
;22# $
if44 
(44 
elements44 
.44 
Count44 
>44  
$num44! "
)44" #
{55 
elements66 
[66 
$num66 
]66 
.66 

IsNFocused66 &
=66' (
true66) -
;66- .
return77 
elements77 
[77  
$num77  !
]77! "
;77" #
}88 
return:: 
null:: 
;:: 
};; 	
public== 
static== 
bool== 
ChangeFocus== &
(==& '
INFocusElement==' 5

oldElement==6 @
,==@ A
INFocusElement==B P

newElement==Q [
)==[ \
{>> 	
if?? 
(?? 

oldElement?? 
!=?? 
null?? !
)??! "

oldElement@@ 
.@@ 

IsNFocused@@ %
=@@& '
true@@( ,
;@@, -
ifAA 
(AA 

newElementAA 
!=AA 
nullAA "
)AA" #
SystemBB 
.BB 
DiagnosticsBB "
.BB" #
DebugBB# (
.BB( )
	WriteLineBB) 2
(BB2 3

newElementBB3 =
.BB= >
GetTypeBB> E
(BBE F
)BBF G
)BBG H
;BBH I
ifDD 
(DD 

oldElementDD 
==DD 

newElementDD (
)DD( )
{EE 
returnFF 
falseFF 
;FF 
}GG 
ifII 
(II 

newElementII 
!=II 
nullII "
)II" #
{JJ 
ifKK 
(KK 

oldElementKK 
!=KK !
nullKK" &
)KK& '
{LL 

oldElementMM 
.MM 

IsNFocusedMM )
=MM* +
falseMM, 1
;MM1 2
}NN 

UnfocusAllOO 
(OO 
)OO 
;OO 

newElementPP 
.PP 

IsNFocusedPP %
=PP& '
truePP( ,
;PP, -
returnQQ 
trueQQ 
;QQ 
}RR 
returnTT 
falseTT 
;TT 
}UU 	
publicWW 
staticWW 
voidWW 

UnfocusAllWW %
(WW% &
)WW& '
{XX 	
foreachYY 
(YY 
varYY 
elementYY  
inYY! #
elementsYY$ ,
)YY, -
{ZZ 
element[[ 
.[[ 

IsNFocused[[ "
=[[# $
false[[% *
;[[* +
}\\ 
}]] 	
}^^ 
}__ �
GD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\INFocusContent.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

	interface 
INFocusContent #
{ 
INFocusElement 

TopElement !
{" #
get$ '
;' (
set) ,
;, -
}. /
INFocusElement 
BottomElement $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} �
GD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\INFocusElement.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

	interface 
INFocusElement #
{ 
INFocusElement 
NextFocusLeft $
{% &
get' *
;* +
set, /
;/ 0
}1 2
INFocusElement 
NextFocusRight %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
INFocusElement 
NextFocusUp "
{# $
get% (
;( )
set* -
;- .
}/ 0
INFocusElement 
NextFocusDown $
{% &
get' *
;* +
set, /
;/ 0
}1 2
bool		 

IsNFocused		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
void 
	FocusLeft 
( 
) 
; 
void 

FocusRight 
( 
) 
; 
void 
FocusUp 
( 
) 
; 
void 
	FocusDown 
( 
) 
; 
void 
FocusAction 
( 
) 
; 
} 
} �N
@D:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NButton.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

class 
NButton 
: 
Button !
,! "
INFocusElement# 1
{ 
public		 
static		 
readonly		 
BindableProperty		 /
IsNFocusedProperty		0 B
=		C D
BindableProperty

 
.

 
Create

 #
(

# $
$str

$ 0
,

0 1
typeof

2 8
(

8 9
bool

9 =
)

= >
,

> ?
typeof

@ F
(

F G
NButton

G N
)

N O
,

O P
false

Q V
,

V W
propertyChanged

X g
:

g h
OnIsNFocusedChanged

i |
)

| }
;

} ~
public 
static 
readonly 
BindableProperty /
NFocusColorProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
Color: ?
)? @
,@ A
typeofB H
(H I
NButtonI P
)P Q
,Q R
ColorS X
.X Y
WhiteY ^
)^ _
;_ `
public 
static 
readonly 
BindableProperty /!
NextFocusLeftProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NButtonT [
)[ \
)\ ]
;] ^
public 
static 
readonly 
BindableProperty /"
NextFocusRightProperty0 F
=G H
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
INFocusElement= K
)K L
,L M
typeofN T
(T U
NButtonU \
)\ ]
)] ^
;^ _
public 
static 
readonly 
BindableProperty /
NextFocusUpProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
INFocusElement: H
)H I
,I J
typeofK Q
(Q R
NButtonR Y
)Y Z
)Z [
;[ \
public 
static 
readonly 
BindableProperty /!
NextFocusDownProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NButtonT [
)[ \
)\ ]
;] ^
public 
static 
readonly 
BindableProperty /
NCommandProperty0 @
=A B
BindableProperty 
. 
Create #
(# $
$str$ .
,. /
typeof0 6
(6 7
ICommand7 ?
)? @
,@ A
typeofB H
(H I
NButtonI P
)P Q
)Q R
;R S
public 
bool 

IsNFocused 
{ 	
set 
{ 
SetValue 
( 
IsNFocusedProperty -
,- .
value/ 4
)4 5
;5 6
}7 8
get 
{ 
return 
( 
bool 
) 
GetValue '
(' (
IsNFocusedProperty( :
): ;
;; <
}= >
} 	
public 
Color 
NFocusColor  
{   	
set!! 
{!! 
SetValue!! 
(!! 
NFocusColorProperty!! .
,!!. /
value!!0 5
)!!5 6
;!!6 7
}!!8 9
get"" 
{"" 
return"" 
("" 
Color"" 
)""  
GetValue""  (
(""( )
NFocusColorProperty"") <
)""< =
;""= >
}""? @
}## 	
public%% 
INFocusElement%% 
NextFocusLeft%% +
{&& 	
set'' 
{'' 
SetValue'' 
('' !
NextFocusLeftProperty'' 0
,''0 1
value''2 7
)''7 8
;''8 9
}'': ;
get(( 
{(( 
return(( 
((( 
INFocusElement(( (
)((( )
GetValue(() 1
(((1 2!
NextFocusLeftProperty((2 G
)((G H
;((H I
}((J K
})) 	
public++ 
INFocusElement++ 
NextFocusRight++ ,
{,, 	
set-- 
{-- 
SetValue-- 
(-- "
NextFocusRightProperty-- 1
,--1 2
value--3 8
)--8 9
;--9 :
}--; <
get.. 
{.. 
return.. 
(.. 
INFocusElement.. (
)..( )
GetValue..) 1
(..1 2"
NextFocusRightProperty..2 H
)..H I
;..I J
}..K L
}// 	
public11 
INFocusElement11 
NextFocusUp11 )
{22 	
set33 
{33 
SetValue33 
(33 
NextFocusUpProperty33 .
,33. /
value330 5
)335 6
;336 7
}338 9
get44 
{44 
return44 
(44 
INFocusElement44 (
)44( )
GetValue44) 1
(441 2
NextFocusUpProperty442 E
)44E F
;44F G
}44H I
}55 	
public77 
INFocusElement77 
NextFocusDown77 +
{88 	
set99 
{99 
SetValue99 
(99 !
NextFocusDownProperty99 0
,990 1
value992 7
)997 8
;998 9
}99: ;
get:: 
{:: 
return:: 
(:: 
INFocusElement:: (
)::( )
GetValue::) 1
(::1 2!
NextFocusDownProperty::2 G
)::G H
;::H I
}::J K
};; 	
public== 
ICommand== 
NCommand==  
{>> 	
set?? 
{?? 
SetValue?? 
(?? 
NCommandProperty?? +
,??+ ,
value??- 2
)??2 3
;??3 4
}??5 6
get@@ 
{@@ 
return@@ 
(@@ 
ICommand@@ "
)@@" #
GetValue@@# +
(@@+ ,
NCommandProperty@@, <
)@@< =
;@@= >
}@@? @
}AA 	
publicDD 
NButtonDD 
(DD 
)DD 
{EE 	
FocusContextFF 
.FF 
RegisterFF !
(FF! "
thisFF" &
)FF& '
;FF' (
thisGG 
.GG 
BorderWidthGG 
=GG 
$numGG  
;GG  !
}HH 	
~JJ 	
NButtonJJ	 
(JJ 
)JJ 
{KK 	
FocusContextLL 
.LL 

UnregisterLL #
(LL# $
thisLL$ (
)LL( )
;LL) *
}MM 	
privatePP 
staticPP 
voidPP 
OnIsNFocusedChangedPP /
(PP/ 0
BindableObjectPP0 >
bindablePP? G
,PPG H
objectPPI O
oldValuePPP X
,PPX Y
objectPPZ `
newValuePPa i
)PPi j
{QQ 	
NButtonRR 
focusButtonRR 
=RR  !
(RR" #
NButtonRR# *
)RR* +
bindableRR+ 3
;RR3 4
boolSS 
	isFocusedSS 
=SS 
(SS 
boolSS "
)SS" #
newValueSS# +
;SS+ ,
focusButtonTT 
.TT 
BorderColorTT #
=TT$ %
	isFocusedTT& /
?TT0 1
focusButtonTT2 =
.TT= >
NFocusColorTT> I
:TTJ K
ColorTTL Q
.TTQ R
TransparentTTR ]
;TT] ^
}UU 	
publicXX 
voidXX 
	FocusLeftXX 
(XX 
)XX 
{YY 	
FocusContextZZ 
.ZZ 
	FocusLeftZZ "
(ZZ" #
thisZZ# '
)ZZ' (
;ZZ( )
}[[ 	
public]] 
void]] 

FocusRight]] 
(]] 
)]]  
{^^ 	
FocusContext__ 
.__ 

FocusRight__ #
(__# $
this__$ (
)__( )
;__) *
}`` 	
publicbb 
voidbb 
FocusUpbb 
(bb 
)bb 
{cc 	
FocusContextdd 
.dd 
FocusUpdd  
(dd  !
thisdd! %
)dd% &
;dd& '
}ee 	
publicgg 
voidgg 
	FocusDowngg 
(gg 
)gg 
{hh 	
FocusContextii 
.ii 
	FocusDownii "
(ii" #
thisii# '
)ii' (
;ii( )
}jj 	
publicll 
voidll 
FocusActionll 
(ll  
)ll  !
{mm 	
ifnn 
(nn 
NCommandnn 
?nn 
.nn 

CanExecutenn $
(nn$ %
CommandParameternn% 5
)nn5 6
==nn7 9
truenn: >
)nn> ?
NCommandoo 
.oo 
Executeoo  
(oo  !
CommandParameteroo! 1
)oo1 2
;oo2 3
}pp 	
}rr 
}ss �E
?D:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NEntry.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

class 
NEntry 
: 
Entry 
,  
INFocusElement! /
{ 
public 
static 
readonly 
BindableProperty /
IsNFocusedProperty0 B
=C D
BindableProperty		 
.		 
Create		 #
(		# $
$str		$ 0
,		0 1
typeof		2 8
(		8 9
bool		9 =
)		= >
,		> ?
typeof		@ F
(		F G
NEntry		G M
)		M N
,		N O
false		P U
,		U V
propertyChanged		W f
:		f g
OnIsNFocusedChanged		h {
)		{ |
;		| }
public

 
static

 
readonly

 
BindableProperty

 /
NFocusColorProperty

0 C
=

D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
Color: ?
)? @
,@ A
typeofB H
(H I
NEntryI O
)O P
,P Q
ColorR W
.W X
FromRgbaX `
(` a
$numa d
,d e
$numf i
,i j
$numk n
,n o
$nump r
)r s
)s t
;t u
public 
static 
readonly 
BindableProperty /!
NextFocusLeftProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NEntryT Z
)Z [
)[ \
;\ ]
public 
static 
readonly 
BindableProperty /"
NextFocusRightProperty0 F
=G H
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
INFocusElement= K
)K L
,L M
typeofN T
(T U
NEntryU [
)[ \
)\ ]
;] ^
public 
static 
readonly 
BindableProperty /
NextFocusUpProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
INFocusElement: H
)H I
,I J
typeofK Q
(Q R
NEntryR X
)X Y
)Y Z
;Z [
public 
static 
readonly 
BindableProperty /!
NextFocusDownProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NEntryT Z
)Z [
)[ \
;\ ]
public 
bool 

IsNFocused 
{ 	
set 
{ 
SetValue 
( 
IsNFocusedProperty -
,- .
value/ 4
)4 5
;5 6
}7 8
get 
{ 
return 
( 
bool 
) 
GetValue '
(' (
IsNFocusedProperty( :
): ;
;; <
}= >
} 	
public 
Color 
NFocusColor  
{ 	
set 
{ 
SetValue 
( 
NFocusColorProperty .
,. /
value0 5
)5 6
;6 7
}8 9
get 
{ 
return 
( 
Color 
)  
GetValue  (
(( )
NFocusColorProperty) <
)< =
;= >
}? @
}   	
public"" 
INFocusElement"" 
NextFocusLeft"" +
{## 	
set$$ 
{$$ 
SetValue$$ 
($$ !
NextFocusLeftProperty$$ 0
,$$0 1
value$$2 7
)$$7 8
;$$8 9
}$$: ;
get%% 
{%% 
return%% 
(%% 
INFocusElement%% (
)%%( )
GetValue%%) 1
(%%1 2!
NextFocusLeftProperty%%2 G
)%%G H
;%%H I
}%%J K
}&& 	
public(( 
INFocusElement(( 
NextFocusRight(( ,
{)) 	
set** 
{** 
SetValue** 
(** "
NextFocusRightProperty** 1
,**1 2
value**3 8
)**8 9
;**9 :
}**; <
get++ 
{++ 
return++ 
(++ 
INFocusElement++ (
)++( )
GetValue++) 1
(++1 2"
NextFocusRightProperty++2 H
)++H I
;++I J
}++K L
},, 	
public.. 
INFocusElement.. 
NextFocusUp.. )
{// 	
set00 
{00 
SetValue00 
(00 
NextFocusUpProperty00 .
,00. /
value000 5
)005 6
;006 7
}008 9
get11 
{11 
return11 
(11 
INFocusElement11 (
)11( )
GetValue11) 1
(111 2
NextFocusUpProperty112 E
)11E F
;11F G
}11H I
}22 	
public44 
INFocusElement44 
NextFocusDown44 +
{55 	
set66 
{66 
SetValue66 
(66 !
NextFocusDownProperty66 0
,660 1
value662 7
)667 8
;668 9
}66: ;
get77 
{77 
return77 
(77 
INFocusElement77 (
)77( )
GetValue77) 1
(771 2!
NextFocusDownProperty772 G
)77G H
;77H I
}77J K
}88 	
public;; 
NEntry;; 
(;; 
);; 
{<< 	
FocusContext== 
.== 
Register== !
(==! "
this==" &
)==& '
;==' (
}>> 	
~@@ 	
NEntry@@	 
(@@ 
)@@ 
{AA 	
FocusContextBB 
.BB 

UnregisterBB #
(BB# $
thisBB$ (
)BB( )
;BB) *
}CC 	
privateFF 
staticFF 
voidFF 
OnIsNFocusedChangedFF /
(FF/ 0
BindableObjectFF0 >
bindableFF? G
,FFG H
objectFFI O
oldValueFFP X
,FFX Y
objectFFZ `
newValueFFa i
)FFi j
{GG 	
NEntryHH 
focusButtonHH 
=HH  
(HH! "
NEntryHH" (
)HH( )
bindableHH) 1
;HH1 2
boolII 
	isFocusedII 
=II 
(II 
boolII "
)II" #
newValueII# +
;II+ ,
focusButtonKK 
.KK 
BackgroundColorKK '
=KK( )
	isFocusedKK* 3
?KK4 5
focusButtonKK6 A
.KKA B
NFocusColorKKB M
:KKN O
ColorKKP U
.KKU V
TransparentKKV a
;KKa b
}LL 	
publicOO 
voidOO 
	FocusLeftOO 
(OO 
)OO 
{PP 	
FocusContextQQ 
.QQ 
	FocusLeftQQ "
(QQ" #
thisQQ# '
)QQ' (
;QQ( )
}RR 	
publicTT 
voidTT 

FocusRightTT 
(TT 
)TT  
{UU 	
FocusContextVV 
.VV 

FocusRightVV #
(VV# $
thisVV$ (
)VV( )
;VV) *
}WW 	
publicYY 
voidYY 
FocusUpYY 
(YY 
)YY 
{ZZ 	
FocusContext[[ 
.[[ 
FocusUp[[  
([[  !
this[[! %
)[[% &
;[[& '
}\\ 	
public^^ 
void^^ 
	FocusDown^^ 
(^^ 
)^^ 
{__ 	
FocusContext`` 
.`` 
	FocusDown`` "
(``" #
this``# '
)``' (
;``( )
}aa 	
publiccc 
voidcc 
FocusActioncc 
(cc  
)cc  !
{dd 	
baseee 
.ee 
Focusee 
(ee 
)ee 
;ee 
}ff 	
}hh 
}ii �O
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NImageButton.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

class 
NImageButton 
: 
ImageButton  +
,+ ,
INFocusElement- ;
{ 
public		 
static		 
readonly		 
BindableProperty		 /
IsNFocusedProperty		0 B
=		C D
BindableProperty

 
.

 
Create

 #
(

# $
$str

$ 0
,

0 1
typeof

2 8
(

8 9
bool

9 =
)

= >
,

> ?
typeof

@ F
(

F G
NImageButton

G S
)

S T
,

T U
false

V [
,

[ \
propertyChanged

] l
:

l m 
OnIsNFocusedChanged	

n �
)


� �
;


� �
public 
static 
readonly 
BindableProperty /
NFocusColorProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
Color: ?
)? @
,@ A
typeofB H
(H I
NImageButtonI U
)U V
,V W
ColorX ]
.] ^
White^ c
)c d
;d e
public 
static 
readonly 
BindableProperty /!
NextFocusLeftProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NImageButtonT `
)` a
)a b
;b c
public 
static 
readonly 
BindableProperty /"
NextFocusRightProperty0 F
=G H
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
INFocusElement= K
)K L
,L M
typeofN T
(T U
NImageButtonU a
)a b
)b c
;c d
public 
static 
readonly 
BindableProperty /
NextFocusUpProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
INFocusElement: H
)H I
,I J
typeofK Q
(Q R
NImageButtonR ^
)^ _
)_ `
;` a
public 
static 
readonly 
BindableProperty /!
NextFocusDownProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NImageButtonT `
)` a
)a b
;b c
public 
static 
readonly 
BindableProperty /
NCommandProperty0 @
=A B
BindableProperty 
. 
Create #
(# $
$str$ .
,. /
typeof0 6
(6 7
ICommand7 ?
)? @
,@ A
typeofB H
(H I
NImageButtonI U
)U V
)V W
;W X
public 
bool 

IsNFocused 
{ 	
set 
{ 
SetValue 
( 
IsNFocusedProperty -
,- .
value/ 4
)4 5
;5 6
}7 8
get 
{ 
return 
( 
bool 
) 
GetValue '
(' (
IsNFocusedProperty( :
): ;
;; <
}= >
} 	
public 
Color 
NFocusColor  
{   	
set!! 
{!! 
SetValue!! 
(!! 
NFocusColorProperty!! .
,!!. /
value!!0 5
)!!5 6
;!!6 7
}!!8 9
get"" 
{"" 
return"" 
("" 
Color"" 
)""  
GetValue""  (
(""( )
NFocusColorProperty"") <
)""< =
;""= >
}""? @
}## 	
public%% 
INFocusElement%% 
NextFocusLeft%% +
{&& 	
set'' 
{'' 
SetValue'' 
('' !
NextFocusLeftProperty'' 0
,''0 1
value''2 7
)''7 8
;''8 9
}'': ;
get(( 
{(( 
return(( 
((( 
INFocusElement(( (
)((( )
GetValue(() 1
(((1 2!
NextFocusLeftProperty((2 G
)((G H
;((H I
}((J K
})) 	
public++ 
INFocusElement++ 
NextFocusRight++ ,
{,, 	
set-- 
{-- 
SetValue-- 
(-- "
NextFocusRightProperty-- 1
,--1 2
value--3 8
)--8 9
;--9 :
}--; <
get.. 
{.. 
return.. 
(.. 
INFocusElement.. (
)..( )
GetValue..) 1
(..1 2"
NextFocusRightProperty..2 H
)..H I
;..I J
}..K L
}// 	
public11 
INFocusElement11 
NextFocusUp11 )
{22 	
set33 
{33 
SetValue33 
(33 
NextFocusUpProperty33 .
,33. /
value330 5
)335 6
;336 7
}338 9
get44 
{44 
return44 
(44 
INFocusElement44 (
)44( )
GetValue44) 1
(441 2
NextFocusUpProperty442 E
)44E F
;44F G
}44H I
}55 	
public77 
INFocusElement77 
NextFocusDown77 +
{88 	
set99 
{99 
SetValue99 
(99 !
NextFocusDownProperty99 0
,990 1
value992 7
)997 8
;998 9
}99: ;
get:: 
{:: 
return:: 
(:: 
INFocusElement:: (
)::( )
GetValue::) 1
(::1 2!
NextFocusDownProperty::2 G
)::G H
;::H I
}::J K
};; 	
public== 
ICommand== 
NCommand==  
{>> 	
set?? 
{?? 
SetValue?? 
(?? 
NCommandProperty?? +
,??+ ,
value??- 2
)??2 3
;??3 4
}??5 6
get@@ 
{@@ 
return@@ 
(@@ 
ICommand@@ "
)@@" #
GetValue@@# +
(@@+ ,
NCommandProperty@@, <
)@@< =
;@@= >
}@@? @
}AA 	
publicDD 
NImageButtonDD 
(DD 
)DD 
{EE 	
FocusContextFF 
.FF 
RegisterFF !
(FF! "
thisFF" &
)FF& '
;FF' (
thisGG 
.GG 
BorderWidthGG 
=GG 
$numGG  
;GG  !
}HH 	
~JJ 	
NImageButtonJJ	 
(JJ 
)JJ 
{KK 	
FocusContextLL 
.LL 

UnregisterLL #
(LL# $
thisLL$ (
)LL( )
;LL) *
}MM 	
privatePP 
staticPP 
voidPP 
OnIsNFocusedChangedPP /
(PP/ 0
BindableObjectPP0 >
bindablePP? G
,PPG H
objectPPI O
oldValuePPP X
,PPX Y
objectPPZ `
newValuePPa i
)PPi j
{QQ 	
NImageButtonRR 
focusButtonRR $
=RR% &
(RR' (
NImageButtonRR( 4
)RR4 5
bindableRR5 =
;RR= >
boolSS 
	isFocusedSS 
=SS 
(SS 
boolSS "
)SS" #
newValueSS# +
;SS+ ,
focusButtonUU 
.UU 
BorderColorUU #
=UU$ %
	isFocusedUU& /
?UU0 1
focusButtonUU2 =
.UU= >
NFocusColorUU> I
:UUJ K
ColorUUL Q
.UUQ R
TransparentUUR ]
;UU] ^
}VV 	
publicYY 
voidYY 
	FocusLeftYY 
(YY 
)YY 
{ZZ 	
FocusContext[[ 
.[[ 
	FocusLeft[[ "
([[" #
this[[# '
)[[' (
;[[( )
}\\ 	
public^^ 
void^^ 

FocusRight^^ 
(^^ 
)^^  
{__ 	
FocusContext`` 
.`` 

FocusRight`` #
(``# $
this``$ (
)``( )
;``) *
}aa 	
publiccc 
voidcc 
FocusUpcc 
(cc 
)cc 
{dd 	
FocusContextee 
.ee 
FocusUpee  
(ee  !
thisee! %
)ee% &
;ee& '
}ff 	
publichh 
voidhh 
	FocusDownhh 
(hh 
)hh 
{ii 	
FocusContextjj 
.jj 
	FocusDownjj "
(jj" #
thisjj# '
)jj' (
;jj( )
}kk 	
publicmm 
voidmm 
FocusActionmm 
(mm  
)mm  !
{nn 	
ifoo 
(oo 
NCommandoo 
?oo 
.oo 

CanExecuteoo $
(oo$ %
CommandParameteroo% 5
)oo5 6
==oo7 9
trueoo: >
)oo> ?
NCommandpp 
.pp 
Executepp  
(pp  !
CommandParameterpp! 1
)pp1 2
;pp2 3
}qq 	
}ss 
}tt �H
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NListViewItem.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{		 
public

 

abstract

 
class

 
NListViewItem

 '
:

( )
INFocusElement

* 8
,

8 9
IPropertyChangeBase

: M
{ 
public 
event '
PropertyChangedEventHandler 0
PropertyChanged1 @
;@ A
private 
Frame 
frame 
; 
private 
bool 

isNFocused 
=  !
false" '
;' (
public 
bool 

IsNFocused 
{ 	
get 
=> 

isNFocused 
; 
set 
{ 

isNFocused 
= 
value "
;" #
OnIsNFocusedChanged #
(# $
)$ %
;% &
} 
} 	
public 
Color 
NFocusColor  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
Color1 6
.6 7
White7 <
;< =
public   
INFocusElement   
NextFocusLeft   +
{  , -
get  . 1
;  1 2
set  3 6
;  6 7
}  8 9
public"" 
INFocusElement"" 
NextFocusRight"" ,
{""- .
get""/ 2
;""2 3
set""4 7
;""7 8
}""9 :
public$$ 
INFocusElement$$ 
NextFocusUp$$ )
{$$* +
get$$, /
;$$/ 0
set$$1 4
;$$4 5
}$$6 7
public&& 
INFocusElement&& 
NextFocusDown&& +
{&&, -
get&&. 1
;&&1 2
set&&3 6
;&&6 7
}&&8 9
public(( 
NUntouchedListView(( !
ParentListView((" 0
{((1 2
get((3 6
;((6 7
set((8 ;
;((; <
}((= >
	protected++ 
NListViewItem++ 
(++  
)++  !
{,, 	
FocusContext-- 
.-- 
Register-- !
(--! "
this--" &
)--& '
;--' (
}.. 	
~00 	
NListViewItem00	 
(00 
)00 
{11 	
FocusContext22 
.22 

Unregister22 #
(22# $
this22$ (
)22( )
;22) *
}33 	
private66 
void66 
OnIsNFocusedChanged66 (
(66( )
)66) *
{77 	
if88 
(88 
frame88 
!=88 
null88 
)88 
{99 
frame:: 
.:: 
BorderColor:: !
=::" #

IsNFocused::$ .
?::/ 0
NFocusColor::1 <
:::= >
Color::? D
.::D E
Transparent::E P
;::P Q
};; 
if== 
(== 

IsNFocused== 
&&== 
ParentListView== +
.==+ ,
NItemAppearing==, :
?==: ;
.==; <

CanExecute==< F
(==F G
ParentListView==G U
.==U V
NFocusedIndex==V c
)==c d
====e g
true==h l
)==l m
{>> 
ParentListView?? 
.?? 
NItemAppearing?? -
???- .
.??. /
Execute??/ 6
(??6 7
ParentListView??7 E
.??E F
NFocusedIndex??F S
)??S T
;??T U
}@@ 
}AA 	
publicDD 
voidDD 
	FocusLeftDD 
(DD 
)DD 
{EE 	
ifFF 
(FF 
ParentListViewFF 
.FF 
NOrientationFF +
==FF, .
ScrollOrientationFF/ @
.FF@ A

HorizontalFFA K
)FFK L
{GG 
SystemHH 
.HH 
DiagnosticsHH "
.HH" #
DebugHH# (
.HH( )
	WriteLineHH) 2
(HH2 3
$strHH3 ?
)HH? @
;HH@ A
ParentListViewII 
.II 
	FocusLeftII (
(II( )
)II) *
;II* +
}JJ 
elseKK 
{LL 
ifMM 
(MM 
FocusContextMM 
.MM  
	FocusLeftMM  )
(MM) *
thisMM* .
)MM. /
)MM/ 0
{NN 
ParentListViewOO "
.OO" #
	SetActiveOO# ,
(OO, -
falseOO- 2
)OO2 3
;OO3 4
}PP 
}QQ 
}RR 	
publicTT 
voidTT 

FocusRightTT 
(TT 
)TT  
{UU 	
ifVV 
(VV 
ParentListViewVV 
.VV 
NOrientationVV +
==VV, .
ScrollOrientationVV/ @
.VV@ A

HorizontalVVA K
)VVK L
{WW 
ParentListViewXX 
.XX 

FocusRightXX )
(XX) *
)XX* +
;XX+ ,
}ZZ 
else[[ 
{\\ 
if]] 
(]] 
FocusContext]] 
.]]  

FocusRight]]  *
(]]* +
this]]+ /
)]]/ 0
)]]0 1
{^^ 
ParentListView__ "
.__" #
	SetActive__# ,
(__, -
false__- 2
)__2 3
;__3 4
}`` 
}aa 
}bb 	
publicdd 
voiddd 
FocusUpdd 
(dd 
)dd 
{ee 	
ifff 
(ff 
ParentListViewff 
.ff 
NOrientationff +
==ff, .
ScrollOrientationff/ @
.ff@ A
VerticalffA I
)ffI J
{gg 
ParentListViewhh 
.hh 
FocusUphh &
(hh& '
)hh' (
;hh( )
}ii 
elsejj 
{kk 
ifll 
(ll 
FocusContextll  
.ll  !
FocusUpll! (
(ll( )
thisll) -
)ll- .
)ll. /
{mm 
ParentListViewnn "
.nn" #
	SetActivenn# ,
(nn, -
falsenn- 2
)nn2 3
;nn3 4
}oo 
}pp 
}qq 	
publicss 
voidss 
	FocusDownss 
(ss 
)ss 
{tt 	
ifuu 
(uu 
ParentListViewuu 
.uu 
NOrientationuu +
==uu, .
ScrollOrientationuu/ @
.uu@ A
VerticaluuA I
)uuI J
{vv 
ParentListViewww 
.ww 
	FocusDownww (
(ww( )
)ww) *
;ww* +
}xx 
elseyy 
{zz 
if{{ 
({{ 
FocusContext{{  
.{{  !
	FocusDown{{! *
({{* +
this{{+ /
){{/ 0
){{0 1
{|| 
ParentListView}} "
.}}" #
	SetActive}}# ,
(}}, -
false}}- 2
)}}2 3
;}}3 4
}~~ 
} 
}
�� 	
public
�� 
virtual
�� 
void
�� 
FocusAction
�� '
(
��' (
)
��( )
{
�� 	
}
�� 	
public
�� 
virtual
�� 
void
�� 
LongFocusAction
�� +
(
��+ ,
)
��, -
{
�� 	
}
�� 	
public
�� 
void
�� 
SetFrame
�� 
(
�� 
Frame
�� "
frame
��# (
)
��( )
{
�� 	
this
�� 
.
�� 
frame
�� 
=
�� 
frame
�� 
;
�� 
}
�� 	
public
�� 
void
�� 
OnPropertyChanged
�� %
<
��% &
T
��& '
>
��' (
(
��( )

Expression
��) 3
<
��3 4
Func
��4 8
<
��8 9
T
��9 :
>
��: ;
>
��; <
property
��= E
)
��E F
{
�� 	
PropertyChanged
�� 
?
�� 
.
�� 
Invoke
�� #
(
��# $
this
��$ (
,
��( )
new
��* -&
PropertyChangedEventArgs
��. F
(
��F G
(
��G H
property
��H P
.
��P Q
Body
��Q U
as
��V X
MemberExpression
��Y i
)
��i j
.
��j k
Member
��k q
.
��q r
Name
��r v
)
��v w
)
��w x
;
��x y
}
�� 	
public
�� 
void
�� 
OnPropertyChanged
�� %
(
��% &
[
��& '
CallerMemberName
��' 7
]
��7 8
string
��9 ?
propertyName
��@ L
=
��M N
null
��O S
)
��S T
{
�� 	
PropertyChanged
�� 
?
�� 
.
�� 
Invoke
�� #
(
��# $
this
��$ (
,
��( )
new
��* -&
PropertyChangedEventArgs
��. F
(
��F G
propertyName
��G S
)
��S T
)
��T U
;
��U V
}
�� 	
}
�� 
}�� �m
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NPressGestureMask.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

class 
NPressGestureMask "
:# $
Frame% *
,* +
INFocusElement, :
{ 
public		 
static		 
readonly		 
BindableProperty		 /
IsNFocusedProperty		0 B
=		C D
BindableProperty

 
.

 
Create

 #
(

# $
$str

$ 0
,

0 1
typeof

2 8
(

8 9
bool

9 =
)

= >
,

> ?
typeof

@ F
(

F G
NPressGestureMask

G X
)

X Y
,

Y Z
false

[ `
,

` a
propertyChanged

b q
:

q r 
OnIsNFocusedChanged	

s �
)


� �
;


� �
public 
static 
readonly 
BindableProperty /
NFocusColorProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
Color: ?
)? @
,@ A
typeofB H
(H I
NPressGestureMaskI Z
)Z [
,[ \
Color] b
.b c
FromRgbac k
(k l
$numl o
,o p
$nump s
,s t
$numt w
,w x
$numx z
)z {
){ |
;| }
public 
static 
readonly 
BindableProperty /!
NextFocusLeftProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NPressGestureMaskT e
)e f
)f g
;g h
public 
static 
readonly 
BindableProperty /"
NextFocusRightProperty0 F
=G H
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
INFocusElement= K
)K L
,L M
typeofN T
(T U
NPressGestureMaskU f
)f g
)g h
;h i
public 
static 
readonly 
BindableProperty /
NextFocusUpProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
INFocusElement: H
)H I
,I J
typeofK Q
(Q R
NPressGestureMaskR c
)c d
)d e
;e f
public 
static 
readonly 
BindableProperty /!
NextFocusDownProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NPressGestureMaskT e
)e f
)f g
;g h
public 
static 
readonly 
BindableProperty /
CommandProperty0 ?
=@ A
BindableProperty 
. 
Create #
(# $
$str$ -
,- .
typeof/ 5
(5 6
ICommand6 >
)> ?
,? @
typeofA G
(G H
NPressGestureMaskH Y
)Y Z
)Z [
;[ \
public 
static 
readonly 
BindableProperty /
LongCommandProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
ICommand: B
)B C
,C D
typeofE K
(K L
NPressGestureMaskL ]
)] ^
)^ _
;_ `
public 
static 
readonly 
BindableProperty /$
CommandParameterProperty0 H
=I J
BindableProperty 
. 
Create #
(# $
$str$ 6
,6 7
typeof8 >
(> ?
object? E
)E F
,F G
typeofH N
(N O
NPressGestureMaskO `
)` a
)a b
;b c
public 
static 
readonly 
BindableProperty /(
LongCommandParameterProperty0 L
=M N
BindableProperty 
. 
Create #
(# $
$str$ :
,: ;
typeof< B
(B C
objectC I
)I J
,J K
typeofL R
(R S
NPressGestureMaskS d
)d e
)e f
;f g
public!! 
bool!! 

IsNFocused!! 
{"" 	
set## 
{## 
SetValue## 
(## 
IsNFocusedProperty## -
,##- .
value##/ 4
)##4 5
;##5 6
}##7 8
get$$ 
{$$ 
return$$ 
($$ 
bool$$ 
)$$ 
GetValue$$ '
($$' (
IsNFocusedProperty$$( :
)$$: ;
;$$; <
}$$= >
}%% 	
public'' 
Color'' 
NFocusColor''  
{(( 	
set)) 
{)) 
SetValue)) 
()) 
NFocusColorProperty)) .
,)). /
value))0 5
)))5 6
;))6 7
}))8 9
get** 
{** 
return** 
(** 
Color** 
)**  
GetValue**  (
(**( )
NFocusColorProperty**) <
)**< =
;**= >
}**? @
}++ 	
public-- 
INFocusElement-- 
NextFocusLeft-- +
{.. 	
set// 
{// 
SetValue// 
(// !
NextFocusLeftProperty// 0
,//0 1
value//2 7
)//7 8
;//8 9
}//: ;
get00 
{00 
return00 
(00 
INFocusElement00 (
)00( )
GetValue00) 1
(001 2!
NextFocusLeftProperty002 G
)00G H
;00H I
}00J K
}11 	
public33 
INFocusElement33 
NextFocusRight33 ,
{44 	
set55 
{55 
SetValue55 
(55 "
NextFocusRightProperty55 1
,551 2
value553 8
)558 9
;559 :
}55; <
get66 
{66 
return66 
(66 
INFocusElement66 (
)66( )
GetValue66) 1
(661 2"
NextFocusRightProperty662 H
)66H I
;66I J
}66K L
}77 	
public99 
INFocusElement99 
NextFocusUp99 )
{:: 	
set;; 
{;; 
SetValue;; 
(;; 
NextFocusUpProperty;; .
,;;. /
value;;0 5
);;5 6
;;;6 7
};;8 9
get<< 
{<< 
return<< 
(<< 
INFocusElement<< (
)<<( )
GetValue<<) 1
(<<1 2
NextFocusUpProperty<<2 E
)<<E F
;<<F G
}<<H I
}== 	
public?? 
INFocusElement?? 
NextFocusDown?? +
{@@ 	
setAA 
{AA 
SetValueAA 
(AA !
NextFocusDownPropertyAA 0
,AA0 1
valueAA2 7
)AA7 8
;AA8 9
}AA: ;
getBB 
{BB 
returnBB 
(BB 
INFocusElementBB (
)BB( )
GetValueBB) 1
(BB1 2!
NextFocusDownPropertyBB2 G
)BBG H
;BBH I
}BBJ K
}CC 	
publicEE 
ICommandEE 
CommandEE 
{FF 	
setGG 
{GG 
SetValueGG 
(GG 
CommandPropertyGG *
,GG* +
valueGG, 1
)GG1 2
;GG2 3
}GG4 5
getHH 
{HH 
returnHH 
(HH 
ICommandHH "
)HH" #
GetValueHH# +
(HH+ ,
CommandPropertyHH, ;
)HH; <
;HH< =
}HH> ?
}II 	
publicKK 
ICommandKK 
LongCommandKK #
{LL 	
setMM 
{MM 
SetValueMM 
(MM 
LongCommandPropertyMM .
,MM. /
valueMM0 5
)MM5 6
;MM6 7
}MM8 9
getNN 
{NN 
returnNN 
(NN 
ICommandNN "
)NN" #
GetValueNN# +
(NN+ ,
LongCommandPropertyNN, ?
)NN? @
;NN@ A
}NNB C
}OO 	
publicQQ 
objectQQ 
CommandParameterQQ &
{RR 	
setSS 
{SS 
SetValueSS 
(SS $
CommandParameterPropertySS 3
,SS3 4
valueSS5 :
)SS: ;
;SS; <
}SS= >
getTT 
{TT 
returnTT 
GetValueTT !
(TT! "$
CommandParameterPropertyTT" :
)TT: ;
;TT; <
}TT= >
}UU 	
publicWW 
objectWW  
LongCommandParameterWW *
{XX 	
setYY 
{YY 
SetValueYY 
(YY (
LongCommandParameterPropertyYY 7
,YY7 8
valueYY9 >
)YY> ?
;YY? @
}YYA B
getZZ 
{ZZ 
returnZZ 
GetValueZZ !
(ZZ! "(
LongCommandParameterPropertyZZ" >
)ZZ> ?
;ZZ? @
}ZZA B
}[[ 	
public^^ 
NPressGestureMask^^  
(^^  !
)^^! "
{__ 	
FocusContext`` 
.`` 
Register`` !
(``! "
this``" &
)``& '
;``' (
thisaa 
.aa 
BackgroundColoraa  
=aa! "
Coloraa# (
.aa( )
Transparentaa) 4
;aa4 5
thisbb 
.bb 
BorderColorbb 
=bb 
Colorbb $
.bb$ %
Transparentbb% 0
;bb0 1
}cc 	
~ee 	
NPressGestureMaskee	 
(ee 
)ee 
{ff 	
FocusContextgg 
.gg 

Unregistergg #
(gg# $
thisgg$ (
)gg( )
;gg) *
}hh 	
privatekk 
statickk 
voidkk 
OnIsNFocusedChangedkk /
(kk/ 0
BindableObjectkk0 >
bindablekk? G
,kkG H
objectkkI O
oldValuekkP X
,kkX Y
objectkkZ `
newValuekka i
)kki j
{ll 	
NPressGestureMaskmm 

focusFramemm (
=mm) *
(mm+ ,
NPressGestureMaskmm, =
)mm= >
bindablemm> F
;mmF G
boolnn 
	isFocusednn 
=nn 
(nn 
boolnn "
)nn" #
newValuenn# +
;nn+ ,

focusFramepp 
.pp 
BackgroundColorpp &
=pp' (
	isFocusedpp) 2
?pp3 4

focusFramepp5 ?
.pp? @
NFocusColorpp@ K
:ppL M
ColorppN S
.ppS T
TransparentppT _
;pp_ `
}qq 	
publictt 
voidtt 
	FocusLefttt 
(tt 
)tt 
{uu 	
FocusContextvv 
.vv 
	FocusLeftvv "
(vv" #
thisvv# '
)vv' (
;vv( )
}ww 	
publicyy 
voidyy 

FocusRightyy 
(yy 
)yy  
{zz 	
FocusContext{{ 
.{{ 

FocusRight{{ #
({{# $
this{{$ (
){{( )
;{{) *
}|| 	
public~~ 
void~~ 
FocusUp~~ 
(~~ 
)~~ 
{ 	
FocusContext
�� 
.
�� 
FocusUp
��  
(
��  !
this
��! %
)
��% &
;
��& '
}
�� 	
public
�� 
void
�� 
	FocusDown
�� 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 
	FocusDown
�� "
(
��" #
this
��# '
)
��' (
;
��( )
}
�� 	
public
�� 
void
�� 
FocusAction
�� 
(
��  
)
��  !
{
�� 	
if
�� 
(
�� 
Command
�� 
?
�� 
.
�� 

CanExecute
�� #
(
��# $
CommandParameter
��$ 4
)
��4 5
==
��6 8
true
��9 =
)
��= >
Command
�� 
.
�� 
Execute
�� 
(
��  
CommandParameter
��  0
)
��0 1
;
��1 2
}
�� 	
public
�� 
void
�� 

LongAction
�� 
(
�� 
)
��  
{
�� 	
if
�� 
(
�� 
LongCommand
�� 
?
�� 
.
�� 

CanExecute
�� '
(
��' ("
LongCommandParameter
��( <
)
��< =
==
��> @
true
��A E
)
��E F
LongCommand
�� 
.
�� 
Execute
�� #
(
��# $"
LongCommandParameter
��$ 8
)
��8 9
;
��9 :
}
�� 	
}
�� 
}�� �
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NScreenKeyboard.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public		 

class		 
NScreenKeyboard		  
:		! "
Grid		# '
,		' (
INFocusElement		) 7
{

 
public 
event 
KeyboardClicked $
OnKeyboardClicked% 6
;6 7
public 
delegate 
void 
KeyboardClicked ,
(, -
string- 3
clickedButton4 A
)A B
;B C
public 
const 
string 
EnterButton '
=( )
$str* .
;. /
public 
const 
string 
RemoveButton (
=) *
$str+ /
;/ 0
private 
readonly 
char 
[ 
, 
]  
letters! (
=) *
new+ .
char/ 3
[3 4
$num4 5
,5 6
$num7 8
]8 9
{ 	
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char! $
,$ %
$char% (
}) *
,* +
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char! $
,$ %
$char% (
}) *
,* +
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char! $
,$ %
$char% (
}) *
,* +
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char! $
,$ %
$char% )
}* +
} 	
;	 

private 
readonly 
char 
[ 
, 
]  
variantLetters! /
=0 1
new2 5
char6 :
[: ;
$num; <
,< =
$num> ?
]? @
{ 	
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char! $
,$ %
$char% (
}) *
,* +
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char" %
,% &
$char& )
}* +
,+ ,
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char" %
,% &
$char& )
}* +
,+ ,
{ 
$char 
, 
$char 
, 
$char 
, 
$char 
, 
$char  
,  !
$char" %
,% &
$char& )
}* +
}   	
;  	 

private"" 
readonly"" 
char"" 
["" 
,"" 
]""  
numbers""! (
="") *
new""+ .
char""/ 3
[""3 4
$num""4 5
,""5 6
$num""7 8
]""8 9
{## 	
{$$ 
$char$$ 
,$$ 
$char$$ 
,$$ 
$char$$ 
,$$ 
$char$$ 
,$$ 
$char$$  
,$$  !
$char$$! $
,$$$ %
$char$$% (
}$$) *
,$$* +
{%% 
$char%% 
,%% 
$char%% 
,%% 
$char%% 
,%% 
$char%% 
,%% 
$char%%  
,%%  !
$char%%! $
,%%$ %
$char%%% (
}%%) *
,%%* +
{&& 
$char&& 
,&& 
$char&& 
,&& 
$char&& 
,&& 
$char&& 
,&& 
$char&&  
,&&  !
$char&&! $
,&&$ %
$char&&% (
}&&) *
,&&* +
{'' 
$char'' 
,'' 
$char'' 
,'' 
$char'' 
,'' 
$char'' 
,'' 
$char'' !
,''! "
$char''" %
,''% &
$char''& )
}''* +
}(( 	
;((	 

private** 
int** 
keyboardPage**  
=**! "
$num**# $
;**$ %
private++ 
readonly++ 

Dictionary++ #
<++# $
int++$ '
,++' (
int++) ,
[++, -
]++- .
>++. /
indexes++0 7
=++8 9
new++: =

Dictionary++> H
<++H I
int++I L
,++L M
int++N Q
[++Q R
]++R S
>++S T
(++T U
)++U V
;++V W
public.. 
static.. 
readonly.. 
BindableProperty.. /
IsNFocusedProperty..0 B
=..C D
BindableProperty// 
.// 
Create// #
(//# $
$str//$ 0
,//0 1
typeof//2 8
(//8 9
bool//9 =
)//= >
,//> ?
typeof//@ F
(//F G
NScreenKeyboard//G V
)//V W
,//W X
false//Y ^
,//^ _
propertyChanged//` o
://o p 
OnIsNFocusedChanged	//q �
)
//� �
;
//� �
public00 
static00 
readonly00 
BindableProperty00 /
NFocusColorProperty000 C
=00D E
BindableProperty11 
.11 
Create11 #
(11# $
$str11$ 1
,111 2
typeof113 9
(119 :
Color11: ?
)11? @
,11@ A
typeof11B H
(11H I
NScreenKeyboard11I X
)11X Y
,11Y Z
Color11[ `
.11` a
White11a f
,11f g
propertyChanged11h w
:11w x 
OnFocusColorChanged	11y �
)
11� �
;
11� �
public33 
static33 
readonly33 
BindableProperty33 /!
NextFocusLeftProperty330 E
=33F G
BindableProperty44 
.44 
Create44 #
(44# $
$str44$ 3
,443 4
typeof445 ;
(44; <
INFocusElement44< J
)44J K
,44K L
typeof44M S
(44S T
NScreenKeyboard44T c
)44c d
,44d e
propertyChanged44f u
:44u v
OnElementChanged	44w �
)
44� �
;
44� �
public55 
static55 
readonly55 
BindableProperty55 /"
NextFocusRightProperty550 F
=55G H
BindableProperty66 
.66 
Create66 #
(66# $
$str66$ 4
,664 5
typeof666 <
(66< =
INFocusElement66= K
)66K L
,66L M
typeof66N T
(66T U
NScreenKeyboard66U d
)66d e
,66e f
propertyChanged66g v
:66v w
OnElementChanged	66x �
)
66� �
;
66� �
public77 
static77 
readonly77 
BindableProperty77 /
NextFocusUpProperty770 C
=77D E
BindableProperty88 
.88 
Create88 #
(88# $
$str88$ 1
,881 2
typeof883 9
(889 :
INFocusElement88: H
)88H I
,88I J
typeof88K Q
(88Q R
NScreenKeyboard88R a
)88a b
,88b c
propertyChanged88d s
:88s t
OnElementChanged	88u �
)
88� �
;
88� �
public99 
static99 
readonly99 
BindableProperty99 /!
NextFocusDownProperty990 E
=99F G
BindableProperty:: 
.:: 
Create:: #
(::# $
$str::$ 3
,::3 4
typeof::5 ;
(::; <
INFocusElement::< J
)::J K
,::K L
typeof::M S
(::S T
NScreenKeyboard::T c
)::c d
,::d e
propertyChanged::f u
:::u v
OnElementChanged	::w �
)
::� �
;
::� �
public<< 
static<< 
readonly<< 
BindableProperty<< /
NBackColorProperty<<0 B
=<<C D
BindableProperty== 
.== 
Create== #
(==# $
$str==$ 0
,==0 1
typeof==2 8
(==8 9
Color==9 >
)==> ?
,==? @
typeof==A G
(==G H
NScreenKeyboard==H W
)==W X
,==X Y
Color==Z _
.==_ `
White==` e
,==e f
propertyChanged==g v
:==v w
OnBackColorChanged	==x �
)
==� �
;
==� �
public>> 
static>> 
readonly>> 
BindableProperty>> /
NFontColorProperty>>0 B
=>>C D
BindableProperty?? 
.?? 
Create?? #
(??# $
$str??$ 0
,??0 1
typeof??2 8
(??8 9
Color??9 >
)??> ?
,??? @
typeof??A G
(??G H
NScreenKeyboard??H W
)??W X
,??X Y
Color??Z _
.??_ `
Black??` e
,??e f
propertyChanged??g v
:??v w
OnFontColorChanged	??x �
)
??� �
;
??� �
publicAA 
boolAA 

IsNFocusedAA 
{BB 	
setCC 
{CC 
SetValueCC 
(CC 
IsNFocusedPropertyCC -
,CC- .
valueCC/ 4
)CC4 5
;CC5 6
}CC7 8
getDD 
{DD 
returnDD 
(DD 
boolDD 
)DD 
GetValueDD '
(DD' (
IsNFocusedPropertyDD( :
)DD: ;
;DD; <
}DD= >
}EE 	
publicGG 
ColorGG 
NFocusColorGG  
{HH 	
setII 
{II 
SetValueII 
(II 
NFocusColorPropertyII .
,II. /
valueII0 5
)II5 6
;II6 7
}II8 9
getJJ 
{JJ 
returnJJ 
(JJ 
ColorJJ 
)JJ  
GetValueJJ  (
(JJ( )
NFocusColorPropertyJJ) <
)JJ< =
;JJ= >
}JJ? @
}KK 	
publicMM 
ColorMM 

NBackColorMM 
{NN 	
setOO 
{OO 
SetValueOO 
(OO 
NBackColorPropertyOO -
,OO- .
valueOO/ 4
)OO4 5
;OO5 6
}OO7 8
getPP 
{PP 
returnPP 
(PP 
ColorPP 
)PP  
GetValuePP  (
(PP( )
NBackColorPropertyPP) ;
)PP; <
;PP< =
}PP> ?
}QQ 	
publicSS 
ColorSS 

NFontColorSS 
{TT 	
setUU 
{UU 
SetValueUU 
(UU 
NFontColorPropertyUU -
,UU- .
valueUU/ 4
)UU4 5
;UU5 6
}UU7 8
getVV 
{VV 
returnVV 
(VV 
ColorVV 
)VV  
GetValueVV  (
(VV( )
NFontColorPropertyVV) ;
)VV; <
;VV< =
}VV> ?
}WW 	
publicYY 
INFocusElementYY 
NextFocusLeftYY +
{ZZ 	
set[[ 
{[[ 
SetValue[[ 
([[ !
NextFocusLeftProperty[[ 0
,[[0 1
value[[2 7
)[[7 8
;[[8 9
}[[: ;
get\\ 
{\\ 
return\\ 
(\\ 
INFocusElement\\ (
)\\( )
GetValue\\) 1
(\\1 2!
NextFocusLeftProperty\\2 G
)\\G H
;\\H I
}\\J K
}]] 	
public__ 
INFocusElement__ 
NextFocusRight__ ,
{`` 	
setaa 
{aa 
SetValueaa 
(aa "
NextFocusRightPropertyaa 1
,aa1 2
valueaa3 8
)aa8 9
;aa9 :
}aa; <
getbb 
{bb 
returnbb 
(bb 
INFocusElementbb (
)bb( )
GetValuebb) 1
(bb1 2"
NextFocusRightPropertybb2 H
)bbH I
;bbI J
}bbK L
}cc 	
publicee 
INFocusElementee 
NextFocusUpee )
{ff 	
setgg 
{gg 
SetValuegg 
(gg 
NextFocusUpPropertygg .
,gg. /
valuegg0 5
)gg5 6
;gg6 7
}gg8 9
gethh 
{hh 
returnhh 
(hh 
INFocusElementhh (
)hh( )
GetValuehh) 1
(hh1 2
NextFocusUpPropertyhh2 E
)hhE F
;hhF G
}hhH I
}ii 	
publickk 
INFocusElementkk 
NextFocusDownkk +
{ll 	
setmm 
{mm 
SetValuemm 
(mm !
NextFocusDownPropertymm 0
,mm0 1
valuemm2 7
)mm7 8
;mm8 9
}mm: ;
getnn 
{nn 
returnnn 
(nn 
INFocusElementnn (
)nn( )
GetValuenn) 1
(nn1 2!
NextFocusDownPropertynn2 G
)nnG H
;nnH I
}nnJ K
}oo 	
privaterr 
ICommandrr 
ButtonCommandrr &
=>rr' )
newrr* -
ActionCommandrr. ;
(rr; <
	parameterrr< E
=>rrF H
{ss 	
stringtt 
clickedtt 
=tt 
	parametertt &
.tt& '
ToStringtt' /
(tt/ 0
)tt0 1
;tt1 2
ifuu 
(uu 
clickeduu 
.uu 
Lengthuu 
<=uu !
$numuu" #
)uu# $
OnKeyboardClickedvv !
?vv! "
.vv" #
Invokevv# )
(vv) *
clickedvv* 1
)vv1 2
;vv2 3
elseww 
{xx 
ifyy 
(yy 
clickedyy 
==yy 
$stryy ,
)yy, -
{zz 
if{{ 
({{ 
keyboardPage{{ $
!={{% '
$num{{( )
){{) *
{|| 
for}} 
(}} 
int}}  
x}}! "
=}}# $
$num}}% &
;}}& '
x}}( )
<}}* +
$num}}, -
;}}- .
x}}/ 0
++}}0 2
)}}2 3
{~~ 
for 
(  !
int! $
y% &
=' (
$num) *
;* +
y, -
<. /
$num0 1
;1 2
y3 4
++4 6
)6 7
{
�� 
var
��  #
kp
��$ &
=
��' (
indexes
��) 0
.
��0 1
First
��1 6
(
��6 7
keypair
��7 >
=>
��? A
keypair
��B I
.
��I J
Value
��J O
[
��O P
$num
��P Q
]
��Q R
==
��S U
x
��V W
&&
��X Z
keypair
��[ b
.
��b c
Value
��c h
[
��h i
$num
��i j
]
��j k
==
��l n
y
��o p
)
��p q
;
��q r
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
Text
��> B
=
��C D
variantLetters
��E S
[
��S T
y
��T U
,
��U V
x
��W X
]
��X Y
.
��Y Z
ToString
��Z b
(
��b c
)
��c d
;
��d e
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
CommandParameter
��> N
=
��O P
variantLetters
��Q _
[
��_ `
y
��` a
,
��a b
x
��c d
]
��d e
.
��e f
ToString
��f n
(
��n o
)
��o p
;
��p q
}
�� 
}
�� 
keyboardPage
�� $
=
��% &
$num
��' (
;
��( )
}
�� 
else
�� 
{
�� 
for
�� 
(
�� 
int
��  
x
��! "
=
��# $
$num
��% &
;
��& '
x
��( )
<
��* +
$num
��, -
;
��- .
x
��/ 0
++
��0 2
)
��2 3
{
�� 
for
�� 
(
��  !
int
��! $
y
��% &
=
��' (
$num
��) *
;
��* +
y
��, -
<
��. /
$num
��0 1
;
��1 2
y
��3 4
++
��4 6
)
��6 7
{
�� 
var
��  #
kp
��$ &
=
��' (
indexes
��) 0
.
��0 1
First
��1 6
(
��6 7
keypair
��7 >
=>
��? A
keypair
��B I
.
��I J
Value
��J O
[
��O P
$num
��P Q
]
��Q R
==
��S U
x
��V W
&&
��X Z
keypair
��[ b
.
��b c
Value
��c h
[
��h i
$num
��i j
]
��j k
==
��l n
y
��o p
)
��p q
;
��q r
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
Text
��> B
=
��C D
letters
��E L
[
��L M
y
��M N
,
��N O
x
��P Q
]
��Q R
.
��R S
ToString
��S [
(
��[ \
)
��\ ]
;
��] ^
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
CommandParameter
��> N
=
��O P
letters
��Q X
[
��X Y
y
��Y Z
,
��Z [
x
��\ ]
]
��] ^
.
��^ _
ToString
��_ g
(
��g h
)
��h i
;
��i j
}
�� 
}
�� 
keyboardPage
�� $
=
��% &
$num
��' (
;
��( )
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
clicked
��  
==
��! #
$str
��$ /
)
��/ 0
{
�� 
if
�� 
(
�� 
keyboardPage
�� $
!=
��% '
$num
��( )
)
��) *
{
�� 
for
�� 
(
�� 
int
��  
x
��! "
=
��# $
$num
��% &
;
��& '
x
��( )
<
��* +
$num
��, -
;
��- .
x
��/ 0
++
��0 2
)
��2 3
{
�� 
for
�� 
(
��  !
int
��! $
y
��% &
=
��' (
$num
��) *
;
��* +
y
��, -
<
��. /
$num
��0 1
;
��1 2
y
��3 4
++
��4 6
)
��6 7
{
�� 
var
��  #
kp
��$ &
=
��' (
indexes
��) 0
.
��0 1
First
��1 6
(
��6 7
keypair
��7 >
=>
��? A
keypair
��B I
.
��I J
Value
��J O
[
��O P
$num
��P Q
]
��Q R
==
��S U
x
��V W
&&
��X Z
keypair
��[ b
.
��b c
Value
��c h
[
��h i
$num
��i j
]
��j k
==
��l n
y
��o p
)
��p q
;
��q r
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
Text
��> B
=
��C D
numbers
��E L
[
��L M
y
��M N
,
��N O
x
��P Q
]
��Q R
.
��R S
ToString
��S [
(
��[ \
)
��\ ]
;
��] ^
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
CommandParameter
��> N
=
��O P
numbers
��Q X
[
��X Y
y
��Y Z
,
��Z [
x
��\ ]
]
��] ^
.
��^ _
ToString
��_ g
(
��g h
)
��h i
;
��i j
}
�� 
}
�� 
keyboardPage
�� $
=
��% &
$num
��' (
;
��( )
}
�� 
else
�� 
{
�� 
for
�� 
(
�� 
int
��  
x
��! "
=
��# $
$num
��% &
;
��& '
x
��( )
<
��* +
$num
��, -
;
��- .
x
��/ 0
++
��0 2
)
��2 3
{
�� 
for
�� 
(
��  !
int
��! $
y
��% &
=
��' (
$num
��) *
;
��* +
y
��, -
<
��. /
$num
��0 1
;
��1 2
y
��3 4
++
��4 6
)
��6 7
{
�� 
var
��  #
kp
��$ &
=
��' (
indexes
��) 0
.
��0 1
First
��1 6
(
��6 7
keypair
��7 >
=>
��? A
keypair
��B I
.
��I J
Value
��J O
[
��O P
$num
��P Q
]
��Q R
==
��S U
x
��V W
&&
��X Z
keypair
��[ b
.
��b c
Value
��c h
[
��h i
$num
��i j
]
��j k
==
��l n
y
��o p
)
��p q
;
��q r
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
Text
��> B
=
��C D
letters
��E L
[
��L M
y
��M N
,
��N O
x
��P Q
]
��Q R
.
��R S
ToString
��S [
(
��[ \
)
��\ ]
;
��] ^
(
��  !
Children
��! )
[
��) *
kp
��* ,
.
��, -
Key
��- 0
]
��0 1
as
��2 4
NButton
��5 <
)
��< =
.
��= >
CommandParameter
��> N
=
��O P
letters
��Q X
[
��X Y
y
��Y Z
,
��Z [
x
��\ ]
]
��] ^
.
��^ _
ToString
��_ g
(
��g h
)
��h i
;
��i j
}
�� 
}
�� 
keyboardPage
�� $
=
��% &
$num
��' (
;
��( )
}
�� 
}
�� 
}
�� 
}
�� 	
)
��	 

;
��
 
public
�� 
NScreenKeyboard
�� 
(
�� 
)
��  
{
�� 	
FocusContext
�� 
.
�� 
Register
�� !
(
��! "
this
��" &
)
��& '
;
��' (
RowDefinitions
�� 
=
�� 
new
��  %
RowDefinitionCollection
��! 8
(
��8 9
)
��9 :
{
�� 
new
�� 
RowDefinition
�� !
(
��! "
)
��" #
{
��$ %
Height
��& ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��? @
,
��@ A
new
�� 
RowDefinition
�� !
(
��! "
)
��" #
{
��$ %
Height
��& ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��? @
,
��@ A
new
�� 
RowDefinition
�� !
(
��! "
)
��" #
{
��$ %
Height
��& ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��? @
,
��@ A
new
�� 
RowDefinition
�� !
(
��! "
)
��" #
{
��$ %
Height
��& ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��? @
,
��@ A
new
�� 
RowDefinition
�� !
(
��! "
)
��" #
{
��$ %
Height
��& ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��? @
}
�� 
;
�� 
ColumnDefinitions
�� 
=
�� 
new
��  #(
ColumnDefinitionCollection
��$ >
(
��> ?
)
��? @
{
�� 
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .

GridLength
��/ 9
.
��9 :
Star
��: >
}
��> ?
,
��? @
new
�� 
ColumnDefinition
�� $
(
��$ %
)
��% &
{
��& '
Width
��' ,
=
��- .
new
��/ 2

GridLength
��3 =
(
��= >
$num
��> A
,
��A B
GridUnitType
��C O
.
��O P
Star
��P T
)
��T U
}
��U V
,
��V W
}
�� 
;
�� 
this
�� 
.
�� 
ColumnSpacing
�� 
=
��  
$num
��! "
;
��" #
this
�� 
.
�� 

RowSpacing
�� 
=
�� 
$num
�� 
;
��  
BuildKeyboard
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
~
�� 	
NScreenKeyboard
��	 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 

Unregister
�� #
(
��# $
this
��$ (
)
��( )
;
��) *
}
�� 	
private
�� 
void
�� 
BuildKeyboard
�� "
(
��" #
)
��# $
{
�� 	
this
�� 
.
�� 
Children
�� 
.
�� 
Clear
�� 
(
��  
)
��  !
;
��! "
indexes
�� 
.
�� 
Clear
�� 
(
�� 
)
�� 
;
�� 
char
�� 
[
�� 
,
�� 
]
�� 
currentPage
�� 
=
��  !
null
��" &
;
��& '
if
�� 
(
�� 
keyboardPage
�� 
==
�� 
$num
��  !
)
��! "
currentPage
�� 
=
�� 
variantLetters
�� ,
;
��, -
else
�� 
if
�� 
(
�� 
keyboardPage
�� !
==
��" $
$num
��% &
)
��& '
currentPage
�� 
=
�� 
numbers
�� %
;
��% &
else
�� 
currentPage
�� 
=
�� 
letters
�� %
;
��% &
for
�� 
(
�� 
int
�� 
x
�� 
=
�� 
$num
�� 
;
�� 
x
�� 
<
�� 
$num
��  !
;
��! "
x
��# $
++
��$ &
)
��& '
{
�� 
for
�� 
(
�� 
int
�� 
y
�� 
=
�� 
$num
�� 
;
�� 
y
��  !
<
��" #
$num
��$ %
;
��% &
y
��' (
++
��( *
)
��* +
{
�� 
this
�� 
.
�� 
Children
�� !
.
��! "
Add
��" %
(
��% &
new
��& )
NButton
��* 1
(
��1 2
)
��2 3
{
��4 5
Text
��6 :
=
��; <
currentPage
��= H
[
��H I
y
��I J
,
��J K
x
��L M
]
��M N
.
��N O
ToString
��O W
(
��W X
)
��X Y
,
��Y Z
BackgroundColor
��[ j
=
��k l

NBackColor
��m w
,
��w x
	TextColor��y �
=��� �

NFontColor��� �
,��� �
NFocusColor��� �
=��� �
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
currentPage��� �
[��� �
y��� �
,��� �
x��� �
]��� �
.��� �
ToString��� �
(��� �
)��� �
,��� �
Margin��� �
=��� �
$num��� �
,��� �
Padding��� �
=��� �
$num��� �
}��� �
,��� �
x��� �
,��� �
y��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
��  
this
��  $
.
��$ %
Children
��% -
.
��- .
Count
��. 3
-
��4 5
$num
��6 7
,
��7 8
new
��9 <
int
��= @
[
��@ A
]
��A B
{
��C D
x
��E F
,
��F G
y
��H I
}
��J K
)
��K L
;
��L M
}
�� 
}
�� 
this
�� 
.
�� 
Children
�� 
.
�� 
Add
�� 
(
�� 
new
�� !
NButton
��" )
(
��) *
)
��* +
{
��, -
Text
��. 2
=
��3 4
$str
��5 <
,
��< =
BackgroundColor
��> M
=
��N O

NBackColor
��P Z
,
��Z [
	TextColor
��\ e
=
��f g

NFontColor
��h r
,
��r s
NFocusColor
��t 
=��� �
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
RemoveButton��� �
}��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
�� 
this
�� 
.
�� 
Children
�� %
.
��% &
Count
��& +
-
��, -
$num
��. /
,
��/ 0
new
��1 4
int
��5 8
[
��8 9
]
��9 :
{
��; <
$num
��= >
,
��> ?
$num
��@ A
}
��B C
)
��C D
;
��D E
this
�� 
.
�� 
Children
�� 
.
�� 
Add
�� 
(
�� 
new
�� !
NButton
��" )
(
��) *
)
��* +
{
��, -
Text
��. 2
=
��3 4
$str
��5 :
,
��: ;
BackgroundColor
��< K
=
��L M

NBackColor
��N X
,
��X Y
	TextColor
��Z c
=
��d e

NFontColor
��f p
,
��p q
NFocusColor
��r }
=
��~ 
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
$str��� �
}��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
�� 
this
�� 
.
�� 
Children
�� %
.
��% &
Count
��& +
-
��, -
$num
��. /
,
��/ 0
new
��1 4
int
��5 8
[
��8 9
]
��9 :
{
��; <
$num
��= >
,
��> ?
$num
��@ A
}
��B C
)
��C D
;
��D E
this
�� 
.
�� 
Children
�� 
.
�� 
Add
�� 
(
�� 
new
�� !
NButton
��" )
(
��) *
)
��* +
{
��, -
Text
��. 2
=
��3 4
$str
��5 :
,
��: ;
BackgroundColor
��< K
=
��L M

NBackColor
��N X
,
��X Y
	TextColor
��Z c
=
��d e

NFontColor
��f p
,
��p q
NFocusColor
��r }
=
��~ 
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
$str��� �
}��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
�� 
this
�� 
.
�� 
Children
�� %
.
��% &
Count
��& +
-
��, -
$num
��. /
,
��/ 0
new
��1 4
int
��5 8
[
��8 9
]
��9 :
{
��; <
$num
��= >
,
��> ?
$num
��@ A
}
��B C
)
��C D
;
��D E
this
�� 
.
�� 
Children
�� 
.
�� 
Add
�� 
(
�� 
new
�� !
NButton
��" )
(
��) *
)
��* +
{
��, -
Text
��. 2
=
��3 4
$str
��5 <
,
��< =
BackgroundColor
��> M
=
��N O

NBackColor
��P Z
,
��Z [
	TextColor
��\ e
=
��f g

NFontColor
��h r
,
��r s
NFocusColor
��t 
=��� �
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
EnterButton��� �
}��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
�� 
this
�� 
.
�� 
Children
�� %
.
��% &
Count
��& +
-
��, -
$num
��. /
,
��/ 0
new
��1 4
int
��5 8
[
��8 9
]
��9 :
{
��; <
$num
��= >
,
��> ?
$num
��@ A
}
��B C
)
��C D
;
��D E
this
�� 
.
�� 
Children
�� 
.
�� 
Add
�� 
(
�� 
new
�� !
NButton
��" )
(
��) *
)
��* +
{
��, -
Text
��. 2
=
��3 4
$str
��5 <
,
��< =
BackgroundColor
��> M
=
��N O

NBackColor
��P Z
,
��Z [
	TextColor
��\ e
=
��f g

NFontColor
��h r
,
��r s
NFocusColor
��t 
=��� �
NFocusColor��� �
,��� �
NCommand��� �
=��� �
ButtonCommand��� �
,��� � 
CommandParameter��� �
=��� �
$str��� �
}��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
,��� �
$num��� �
)��� �
;��� �
indexes
�� 
.
�� 
Add
�� 
(
�� 
this
�� 
.
�� 
Children
�� %
.
��% &
Count
��& +
-
��, -
$num
��. /
,
��/ 0
new
��1 4
int
��5 8
[
��8 9
]
��9 :
{
��; <
$num
��= >
,
��> ?
$num
��@ A
}
��B C
)
��C D
;
��D E
(
�� 
this
�� 
.
�� 
Children
�� 
[
�� 
this
�� 
.
��  
Children
��  (
.
��( )
Count
��) .
-
��/ 0
$num
��1 2
]
��2 3
as
��4 6
INFocusElement
��7 E
)
��E F
.
��F G
NextFocusDown
��G T
=
��U V
NextFocusDown
��W d
;
��d e
for
�� 
(
�� 
int
�� 
x
�� 
=
�� 
$num
�� 
;
�� 
x
�� 
<
�� 
$num
��  !
;
��! "
x
��# $
++
��$ &
)
��& '
{
�� 
for
�� 
(
�� 
int
�� 
y
�� 
=
�� 
$num
�� 
;
�� 
y
��  !
<
��" #
$num
��$ %
;
��% &
y
��' (
++
��( *
)
��* +
{
�� 
bool
�� 
left
�� 
=
�� 
x
��  !
>
��" #
$num
��$ %
;
��% &
bool
�� 
up
�� 
=
�� 
y
�� 
>
��  !
$num
��" #
;
��# $
bool
�� 
down
�� 
=
�� 
y
��  !
<
��" #
$num
��$ %
;
��% &
bool
�� 
right
�� 
=
��  
x
��! "
<
��# $
$num
��% &
;
��& '
var
�� 
kp
�� 
=
�� 
indexes
�� $
.
��$ %
First
��% *
(
��* +
keypair
��+ 2
=>
��3 5
keypair
��6 =
.
��= >
Value
��> C
[
��C D
$num
��D E
]
��E F
==
��G I
x
��J K
&&
��L N
keypair
��O V
.
��V W
Value
��W \
[
��\ ]
$num
��] ^
]
��^ _
==
��` b
y
��c d
)
��d e
;
��e f
if
�� 
(
�� 
left
�� 
)
�� 
{
�� 
var
�� 
kpl
�� 
=
��  !
indexes
��" )
.
��) *
First
��* /
(
��/ 0
keypair
��0 7
=>
��8 :
keypair
��; B
.
��B C
Value
��C H
[
��H I
$num
��I J
]
��J K
==
��L N
x
��O P
-
��Q R
$num
��S T
&&
��U W
keypair
��X _
.
��_ `
Value
��` e
[
��e f
$num
��f g
]
��g h
==
��i k
y
��l m
)
��m n
;
��n o
(
�� 
Children
�� !
[
��! "
kpl
��" %
.
��% &
Key
��& )
]
��) *
as
��+ -
INFocusElement
��. <
)
��< =
.
��= >
NextFocusRight
��> L
=
��M N
(
��O P
Children
��P X
[
��X Y
kp
��Y [
.
��[ \
Key
��\ _
]
��_ `
as
��a c
INFocusElement
��d r
)
��r s
;
��s t
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusLeft
��= J
=
��K L
(
��M N
Children
��N V
[
��V W
kpl
��W Z
.
��Z [
Key
��[ ^
]
��^ _
as
��` b
INFocusElement
��c q
)
��q r
;
��r s
}
�� 
else
�� 
{
�� 
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusLeft
��= J
=
��K L
NextFocusLeft
��M Z
;
��Z [
}
�� 
if
�� 
(
�� 
right
�� 
)
�� 
{
�� 
var
�� 
kpr
�� 
=
��  !
indexes
��" )
.
��) *
First
��* /
(
��/ 0
keypair
��0 7
=>
��8 :
keypair
��; B
.
��B C
Value
��C H
[
��H I
$num
��I J
]
��J K
==
��L N
x
��O P
+
��Q R
$num
��S T
&&
��U W
keypair
��X _
.
��_ `
Value
��` e
[
��e f
$num
��f g
]
��g h
==
��i k
y
��l m
)
��m n
;
��n o
(
�� 
Children
�� !
[
��! "
kpr
��" %
.
��% &
Key
��& )
]
��) *
as
��+ -
INFocusElement
��. <
)
��< =
.
��= >
NextFocusLeft
��> K
=
��L M
(
��N O
Children
��O W
[
��W X
kp
��X Z
.
��Z [
Key
��[ ^
]
��^ _
as
��` b
INFocusElement
��c q
)
��q r
;
��r s
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusRight
��= K
=
��L M
(
��N O
Children
��O W
[
��W X
kpr
��X [
.
��[ \
Key
��\ _
]
��_ `
as
��a c
INFocusElement
��d r
)
��r s
;
��s t
}
�� 
else
�� 
{
�� 
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusRight
��= K
=
��L M
NextFocusRight
��N \
;
��\ ]
}
�� 
if
�� 
(
�� 
up
�� 
)
�� 
{
�� 
var
�� 
kpu
�� 
=
��  !
indexes
��" )
.
��) *
First
��* /
(
��/ 0
keypair
��0 7
=>
��8 :
keypair
��; B
.
��B C
Value
��C H
[
��H I
$num
��I J
]
��J K
==
��L N
x
��O P
&&
��Q S
keypair
��T [
.
��[ \
Value
��\ a
[
��a b
$num
��b c
]
��c d
==
��e g
y
��h i
-
��i j
$num
��j k
)
��k l
;
��l m
(
�� 
Children
�� !
[
��! "
kpu
��" %
.
��% &
Key
��& )
]
��) *
as
��+ -
INFocusElement
��. <
)
��< =
.
��= >
NextFocusDown
��> K
=
��L M
(
��N O
Children
��O W
[
��W X
kp
��X Z
.
��Z [
Key
��[ ^
]
��^ _
as
��` b
INFocusElement
��c q
)
��q r
;
��r s
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusUp
��= H
=
��I J
(
��K L
Children
��L T
[
��T U
kpu
��U X
.
��X Y
Key
��Y \
]
��\ ]
as
��^ `
INFocusElement
��a o
)
��o p
;
��p q
}
�� 
else
�� 
{
�� 
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusUp
��= H
=
��I J
NextFocusUp
��K V
;
��V W
}
�� 
if
�� 
(
�� 
down
�� 
)
�� 
{
�� 
var
�� 
kpd
�� 
=
��  !
indexes
��" )
.
��) *
First
��* /
(
��/ 0
keypair
��0 7
=>
��8 :
keypair
��; B
.
��B C
Value
��C H
[
��H I
$num
��I J
]
��J K
==
��L N
x
��O P
&&
��Q S
keypair
��T [
.
��[ \
Value
��\ a
[
��a b
$num
��b c
]
��c d
==
��e g
y
��h i
+
��j k
$num
��l m
)
��m n
;
��n o
(
�� 
Children
�� !
[
��! "
kpd
��" %
.
��% &
Key
��& )
]
��) *
as
��+ -
INFocusElement
��. <
)
��< =
.
��= >
NextFocusUp
��> I
=
��J K
(
��L M
Children
��M U
[
��U V
kp
��V X
.
��X Y
Key
��Y \
]
��\ ]
as
��^ `
INFocusElement
��a o
)
��o p
;
��p q
(
�� 
Children
�� !
[
��! "
kp
��" $
.
��$ %
Key
��% (
]
��( )
as
��* ,
INFocusElement
��- ;
)
��; <
.
��< =
NextFocusDown
��= J
=
��K L
(
��M N
Children
��N V
[
��V W
kpd
��W Z
.
��Z [
Key
��[ ^
]
��^ _
as
��` b
INFocusElement
��c q
)
��q r
;
��r s
}
�� 
else
�� 
{
�� 
var
�� 
kpd
�� 
=
��  !
indexes
��" )
.
��) *
First
��* /
(
��/ 0
keypair
��0 7
=>
��8 :
keypair
��; B
.
��B C
Value
��C H
[
��H I
$num
��I J
]
��J K
==
��L N
x
��O P
&&
��Q S
keypair
��T [
.
��[ \
Value
��\ a
[
��a b
$num
��b c
]
��c d
==
��e g
$num
��h i
)
��i j
;
��j k
(
�� 
Children
�� !
[
��! "
Children
��" *
.
��* +
Count
��+ 0
-
��1 2
$num
��3 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusUp
��I T
=
��U V
(
��W X
Children
��X `
[
��` a
Children
��a i
.
��i j
Count
��j o
-
��p q
$num
��r s
]
��s t
as
��u w
INFocusElement��x �
)��� �
;��� �
(
�� 
Children
�� !
[
��! "
kpd
��" %
.
��% &
Key
��& )
]
��) *
as
��+ -
INFocusElement
��. <
)
��< =
.
��= >
NextFocusDown
��> K
=
��L M
(
��N O
Children
��O W
[
��W X
Children
��X `
.
��` a
Count
��a f
-
��g h
$num
��i j
]
��j k
as
��l n
INFocusElement
��o }
)
��} ~
;
��~ 
}
�� 
}
�� 
}
�� 
(
�� 
Children
�� 
[
�� 
$num
�� 
]
�� 
as
�� 
INFocusElement
�� *
)
��* +
.
��+ ,

IsNFocused
��, 6
=
��7 8
true
��9 =
;
��= >
}
�� 	
private
�� 
static
�� 
void
�� !
OnIsNFocusedChanged
�� /
(
��/ 0
BindableObject
��0 >
bindable
��? G
,
��G H
object
��I O
oldValue
��P X
,
��X Y
object
��Z `
newValue
��a i
)
��i j
{
�� 	
NScreenKeyboard
�� 
focusButton
�� '
=
��( )
(
��* +
NScreenKeyboard
��+ :
)
��: ;
bindable
��; C
;
��C D
bool
�� 
	isFocused
�� 
=
�� 
(
�� 
bool
�� "
)
��" #
newValue
��# +
;
��+ ,
if
�� 
(
�� 
	isFocused
�� 
)
�� 
focusButton
�� 
.
�� 

FocusFirst
�� &
(
��& '
)
��' (
;
��( )
}
�� 	
private
�� 
static
�� 
void
�� 
OnElementChanged
�� ,
(
��, -
BindableObject
��- ;
bindable
��< D
,
��D E
object
��F L
oldValue
��M U
,
��U V
object
��W ]
newValue
��^ f
)
��f g
{
�� 	
NScreenKeyboard
�� 
focusButton
�� '
=
��( )
(
��* +
NScreenKeyboard
��+ :
)
��: ;
bindable
��; C
;
��C D
for
�� 
(
�� 
int
�� 
x
�� 
=
�� 
$num
�� 
;
�� 
x
�� 
<
�� 
$num
��  !
;
��! "
x
��# $
++
��$ &
)
��& '
{
�� 
for
�� 
(
�� 
int
�� 
y
�� 
=
�� 
$num
�� 
;
�� 
y
��  !
<
��" #
$num
��$ %
;
��% &
y
��' (
++
��( *
)
��* +
{
�� 
bool
�� 
left
�� 
=
�� 
x
��  !
>
��" #
$num
��$ %
;
��% &
bool
�� 
up
�� 
=
�� 
y
�� 
>
��  !
$num
��" #
;
��# $
bool
�� 
down
�� 
=
�� 
y
��  !
<
��" #
$num
��$ %
;
��% &
bool
�� 
right
�� 
=
��  
x
��! "
<
��# $
$num
��% &
;
��& '
var
�� 
kp
�� 
=
�� 
focusButton
�� (
.
��( )
indexes
��) 0
.
��0 1
First
��1 6
(
��6 7
keypair
��7 >
=>
��? A
keypair
��B I
.
��I J
Value
��J O
[
��O P
$num
��P Q
]
��Q R
==
��S U
x
��V W
&&
��X Z
keypair
��[ b
.
��b c
Value
��c h
[
��h i
$num
��i j
]
��j k
==
��l n
y
��o p
)
��p q
;
��q r
if
�� 
(
�� 
left
�� 
)
�� 
{
�� 
var
�� 
kpl
�� 
=
��  !
focusButton
��" -
.
��- .
indexes
��. 5
.
��5 6
First
��6 ;
(
��; <
keypair
��< C
=>
��D F
keypair
��G N
.
��N O
Value
��O T
[
��T U
$num
��U V
]
��V W
==
��X Z
x
��[ \
-
��] ^
$num
��_ `
&&
��a c
keypair
��d k
.
��k l
Value
��l q
[
��q r
$num
��r s
]
��s t
==
��u w
y
��x y
)
��y z
;
��z {
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kpl
��. 1
.
��1 2
Key
��2 5
]
��5 6
as
��7 9
INFocusElement
��: H
)
��H I
.
��I J
NextFocusRight
��J X
=
��Y Z
(
��[ \
focusButton
��\ g
.
��g h
Children
��h p
[
��p q
kp
��q s
.
��s t
Key
��t w
]
��w x
as
��y {
INFocusElement��| �
)��� �
;��� �
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusLeft
��I V
=
��W X
(
��Y Z
focusButton
��Z e
.
��e f
Children
��f n
[
��n o
kpl
��o r
.
��r s
Key
��s v
]
��v w
as
��x z
INFocusElement��{ �
)��� �
;��� �
}
�� 
else
�� 
{
�� 
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusLeft
��I V
=
��W X
focusButton
��Y d
.
��d e
NextFocusLeft
��e r
;
��r s
}
�� 
if
�� 
(
�� 
right
�� 
)
�� 
{
�� 
var
�� 
kpr
�� 
=
��  !
focusButton
��" -
.
��- .
indexes
��. 5
.
��5 6
First
��6 ;
(
��; <
keypair
��< C
=>
��D F
keypair
��G N
.
��N O
Value
��O T
[
��T U
$num
��U V
]
��V W
==
��X Z
x
��[ \
+
��] ^
$num
��_ `
&&
��a c
keypair
��d k
.
��k l
Value
��l q
[
��q r
$num
��r s
]
��s t
==
��u w
y
��x y
)
��y z
;
��z {
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kpr
��. 1
.
��1 2
Key
��2 5
]
��5 6
as
��7 9
INFocusElement
��: H
)
��H I
.
��I J
NextFocusLeft
��J W
=
��X Y
(
��Z [
focusButton
��[ f
.
��f g
Children
��g o
[
��o p
kp
��p r
.
��r s
Key
��s v
]
��v w
as
��x z
INFocusElement��{ �
)��� �
;��� �
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusRight
��I W
=
��X Y
(
��Z [
focusButton
��[ f
.
��f g
Children
��g o
[
��o p
kpr
��p s
.
��s t
Key
��t w
]
��w x
as
��y {
INFocusElement��| �
)��� �
;��� �
}
�� 
else
�� 
{
�� 
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusRight
��I W
=
��X Y
focusButton
��Z e
.
��e f
NextFocusRight
��f t
;
��t u
}
�� 
if
�� 
(
�� 
up
�� 
)
�� 
{
�� 
var
�� 
kpu
�� 
=
��  !
focusButton
��" -
.
��- .
indexes
��. 5
.
��5 6
First
��6 ;
(
��; <
keypair
��< C
=>
��D F
keypair
��G N
.
��N O
Value
��O T
[
��T U
$num
��U V
]
��V W
==
��X Z
x
��[ \
&&
��] _
keypair
��` g
.
��g h
Value
��h m
[
��m n
$num
��n o
]
��o p
==
��q s
y
��t u
-
��v w
$num
��x y
)
��y z
;
��z {
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kpu
��. 1
.
��1 2
Key
��2 5
]
��5 6
as
��7 9
INFocusElement
��: H
)
��H I
.
��I J
NextFocusDown
��J W
=
��X Y
(
��Z [
focusButton
��[ f
.
��f g
Children
��g o
[
��o p
kp
��p r
.
��r s
Key
��s v
]
��v w
as
��x z
INFocusElement��{ �
)��� �
;��� �
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusUp
��I T
=
��U V
(
��W X
focusButton
��X c
.
��c d
Children
��d l
[
��l m
kpu
��m p
.
��p q
Key
��q t
]
��t u
as
��v x
INFocusElement��y �
)��� �
;��� �
}
�� 
else
�� 
{
�� 
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusUp
��I T
=
��U V
focusButton
��W b
.
��b c
NextFocusUp
��c n
;
��n o
}
�� 
if
�� 
(
�� 
down
�� 
)
�� 
{
�� 
var
�� 
kpd
�� 
=
��  !
focusButton
��" -
.
��- .
indexes
��. 5
.
��5 6
First
��6 ;
(
��; <
keypair
��< C
=>
��D F
keypair
��G N
.
��N O
Value
��O T
[
��T U
$num
��U V
]
��V W
==
��X Z
x
��[ \
&&
��] _
keypair
��` g
.
��g h
Value
��h m
[
��m n
$num
��n o
]
��o p
==
��q s
y
��t u
+
��v w
$num
��x y
)
��y z
;
��z {
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kpd
��. 1
.
��1 2
Key
��2 5
]
��5 6
as
��7 9
INFocusElement
��: H
)
��H I
.
��I J
NextFocusUp
��J U
=
��V W
(
��X Y
focusButton
��Y d
.
��d e
Children
��e m
[
��m n
kp
��n p
.
��p q
Key
��q t
]
��t u
as
��v x
INFocusElement��y �
)��� �
;��� �
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kp
��. 0
.
��0 1
Key
��1 4
]
��4 5
as
��6 8
INFocusElement
��9 G
)
��G H
.
��H I
NextFocusDown
��I V
=
��W X
(
��Y Z
focusButton
��Z e
.
��e f
Children
��f n
[
��n o
kpd
��o r
.
��r s
Key
��s v
]
��v w
as
��x z
INFocusElement��{ �
)��� �
;��� �
}
�� 
else
�� 
{
�� 
var
�� 
kpd
�� 
=
��  !
focusButton
��" -
.
��- .
indexes
��. 5
.
��5 6
First
��6 ;
(
��; <
keypair
��< C
=>
��D F
keypair
��G N
.
��N O
Value
��O T
[
��T U
$num
��U V
]
��V W
==
��X Z
x
��[ \
&&
��] _
keypair
��` g
.
��g h
Value
��h m
[
��m n
$num
��n o
]
��o p
==
��q s
$num
��t u
)
��u v
;
��v w
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
focusButton
��. 9
.
��9 :
Children
��: B
.
��B C
Count
��C H
-
��I J
$num
��K L
]
��L M
as
��N P
INFocusElement
��Q _
)
��_ `
.
��` a
NextFocusUp
��a l
=
��m n
(
��o p
focusButton
��p {
.
��{ |
Children��| �
[��� �
focusButton��� �
.��� �
Children��� �
.��� �
Count��� �
-��� �
$num��� �
]��� �
as��� �
INFocusElement��� �
)��� �
;��� �
(
�� 
focusButton
�� $
.
��$ %
Children
��% -
[
��- .
kpd
��. 1
.
��1 2
Key
��2 5
]
��5 6
as
��7 9
INFocusElement
��: H
)
��H I
.
��I J
NextFocusDown
��J W
=
��X Y
(
��Z [
focusButton
��[ f
.
��f g
Children
��g o
[
��o p
focusButton
��p {
.
��{ |
Children��| �
.��� �
Count��� �
-��� �
$num��� �
]��� �
as��� �
INFocusElement��� �
)��� �
;��� �
}
�� 
}
�� 
}
�� 
}
�� 	
private
�� 
static
�� 
void
��  
OnBackColorChanged
�� .
(
��. /
BindableObject
��/ =
bindable
��> F
,
��F G
object
��H N
oldValue
��O W
,
��W X
object
��Y _
newValue
��` h
)
��h i
{
�� 	
NScreenKeyboard
�� 
focusButton
�� '
=
��( )
(
��* +
NScreenKeyboard
��+ :
)
��: ;
bindable
��; C
;
��C D
Color
�� 
newColor
�� 
=
�� 
(
�� 
Color
�� #
)
��# $
newValue
��$ ,
;
��, -
foreach
�� 
(
�� 
var
�� 
element
�� 
in
��  "
focusButton
��# .
.
��. /
Children
��/ 7
)
��7 8
{
�� 
(
�� 
element
�� 
as
�� 
NButton
�� #
)
��# $
.
��$ %
BackgroundColor
��% 4
=
��5 6
newColor
��7 ?
;
��? @
}
�� 
}
�� 	
private
�� 
static
�� 
void
�� !
OnFocusColorChanged
�� /
(
��/ 0
BindableObject
��0 >
bindable
��? G
,
��G H
object
��I O
oldValue
��P X
,
��X Y
object
��Z `
newValue
��a i
)
��i j
{
�� 	
NScreenKeyboard
�� 
focusButton
�� '
=
��( )
(
��* +
NScreenKeyboard
��+ :
)
��: ;
bindable
��; C
;
��C D
Color
�� 
newColor
�� 
=
�� 
(
�� 
Color
�� #
)
��# $
newValue
��$ ,
;
��, -
foreach
�� 
(
�� 
var
�� 
element
��  
in
��! #
focusButton
��$ /
.
��/ 0
Children
��0 8
)
��8 9
{
�� 
(
�� 
element
�� 
as
�� 
NButton
�� #
)
��# $
.
��$ %
NFocusColor
��% 0
=
��1 2
newColor
��3 ;
;
��; <
}
�� 
}
�� 	
private
�� 
static
�� 
void
��  
OnFontColorChanged
�� .
(
��. /
BindableObject
��/ =
bindable
��> F
,
��F G
object
��H N
oldValue
��O W
,
��W X
object
��Y _
newValue
��` h
)
��h i
{
�� 	
NScreenKeyboard
�� 
focusButton
�� '
=
��( )
(
��* +
NScreenKeyboard
��+ :
)
��: ;
bindable
��; C
;
��C D
Color
�� 
newColor
�� 
=
�� 
(
�� 
Color
�� #
)
��# $
newValue
��$ ,
;
��, -
foreach
�� 
(
�� 
var
�� 
element
��  
in
��! #
focusButton
��$ /
.
��/ 0
Children
��0 8
)
��8 9
{
�� 
(
�� 
element
�� 
as
�� 
NButton
�� #
)
��# $
.
��$ %
	TextColor
��% .
=
��/ 0
newColor
��1 9
;
��9 :
}
�� 
}
�� 	
private
�� 
void
�� 

FocusFirst
�� 
(
��  
)
��  !
{
�� 	
(
�� 
Children
�� 
[
�� 
$num
�� 
]
�� 
as
�� 
INFocusElement
�� *
)
��* +
.
��+ ,

IsNFocused
��, 6
=
��7 8
true
��9 =
;
��= >
}
�� 	
public
�� 
void
�� 
	FocusLeft
�� 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 
	FocusLeft
�� "
(
��" #
this
��# '
)
��' (
;
��( )
}
�� 	
public
�� 
void
�� 

FocusRight
�� 
(
�� 
)
��  
{
�� 	
FocusContext
�� 
.
�� 

FocusRight
�� #
(
��# $
this
��$ (
)
��( )
;
��) *
}
�� 	
public
�� 
void
�� 
FocusUp
�� 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 
FocusUp
��  
(
��  !
this
��! %
)
��% &
;
��& '
}
�� 	
public
�� 
void
�� 
	FocusDown
�� 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 
	FocusDown
�� "
(
��" #
this
��# '
)
��' (
;
��( )
}
�� 	
public
�� 
void
�� 
FocusAction
�� 
(
��  
)
��  !
{
�� 	
}
�� 	
}
�� 
}�� �&
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NToggleButton.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public 

class 
NToggleButton 
:  
NImageButton! -
,- .
INFocusElement/ =
{ 
public

 
event

 
EventHandler

 !
<

! "
ToggledEventArgs

" 2
>

2 3
Toggled

4 ;
;

; <
public 
static 
readonly 
BindableProperty /
IsToggledProperty0 A
=B C
BindableProperty 
. 
Create #
(# $
$str$ /
,/ 0
typeof1 7
(7 8
bool8 <
)< =
,= >
typeof? E
(E F
NToggleButtonF S
)S T
,T U
falseV [
,[ \
propertyChanged$ 3
:3 4
OnIsToggledChanged5 G
)G H
;H I
public 
bool 
	IsToggled 
{ 	
set 
{ 
SetValue 
( 
IsToggledProperty ,
,, -
value. 3
)3 4
;4 5
}6 7
get 
{ 
return 
( 
bool 
) 
GetValue '
(' (
IsToggledProperty( 9
)9 :
;: ;
}< =
} 	
public 
static 
readonly 
BindableProperty /
TagProperty0 ;
=< =
BindableProperty 
. 
Create #
(# $
$str$ )
,) *
typeof+ 1
(1 2
string2 8
)8 9
,9 :
typeof; A
(A B
NToggleButtonB O
)O P
,P Q
defaultR Y
(Y Z
stringZ `
)` a
)a b
;b c
public 
string 
Tag 
{ 	
set 
{ 
SetValue 
( 
TagProperty &
,& '
value( -
)- .
;. /
}0 1
get 
{ 
return 
( 
string  
)  !
GetValue! )
() *
TagProperty* 5
)5 6
;6 7
}8 9
} 	
public!! 
NToggleButton!! 
(!! 
)!! 
{"" 	
FocusContext## 
.## 
Register## !
(##! "
this##" &
)##& '
;##' (
this$$ 
.$$ 
BorderWidth$$ 
=$$ 
$num$$  
;$$  !
}%% 	
~'' 	
NToggleButton''	 
('' 
)'' 
{(( 	
FocusContext)) 
.)) 

Unregister)) #
())# $
this))$ (
)))( )
;))) *
}** 	
private-- 
static-- 
void-- 
OnIsToggledChanged-- .
(--. /
BindableObject--/ =
bindable--> F
,--F G
object--H N
oldValue--O W
,--W X
object--Y _
newValue--` h
)--h i
{.. 	
NToggleButton// 
toggleButton// &
=//' (
(//) *
NToggleButton//* 7
)//7 8
bindable//8 @
;//@ A
bool00 
	isToggled00 
=00 
(00 
bool00 "
)00" #
newValue00# +
;00+ ,
toggleButton33 
.33 
Toggled33  
?33  !
.33! "
Invoke33" (
(33( )
toggleButton33) 5
,335 6
new337 :
ToggledEventArgs33; K
(33K L
	isToggled33L U
)33U V
)33V W
;33W X
Debug44 
.44 
	WriteLine44 
(44 
$str44 /
+440 1
	isToggled442 ;
)44; <
;44< =
VisualStateManager66 
.66 
	GoToState66 (
(66( )
toggleButton66) 5
,665 6
	isToggled667 @
?66A B
$str66C N
:66O P
$str66Q Y
)66Y Z
;66Z [
}77 	
public:: 
new:: 
void:: 
FocusAction:: #
(::# $
)::$ %
{;; 	
base<< 
.<< 
FocusAction<< 
(<< 
)<< 
;<< 
VisualStateManager== 
.== 
	GoToState== (
(==( )
this==) -
,==- .
	IsToggled==/ 8
?==9 :
$str==; F
:==G H
$str==I Q
)==Q R
;==R S
}>> 	
}@@ 
}AA ��
KD:\Projekty\CS\Newtone\Newtone.Mobile.UI\FocusLibrary\NUntouchedListView.cs
	namespace 	
Nejman
 
. 
Xamarin 
. 
FocusLibrary %
{ 
public		 

class		 
NUntouchedListView		 #
:		$ %

ScrollView		& 0
,		0 1
INFocusElement		2 @
{

 
	protected 
StackLayout 
	container '
;' (
private 
bool 
active 
= 
false #
;# $
public 
static 
readonly 
BindableProperty /
IsNFocusedProperty0 B
=C D
BindableProperty 
. 
Create #
(# $
$str$ 0
,0 1
typeof2 8
(8 9
bool9 =
)= >
,> ?
typeof@ F
(F G
NUntouchedListViewG Y
)Y Z
,Z [
false\ a
,a b
propertyChangedc r
:r s 
OnIsNFocusedChanged	t �
)
� �
;
� �
public 
static 
readonly 
BindableProperty /
NFocusColorProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
Color: ?
)? @
,@ A
typeofB H
(H I
NUntouchedListViewI [
)[ \
,\ ]
Color^ c
.c d
Whited i
)i j
;j k
public 
static 
readonly 
BindableProperty /!
NextFocusLeftProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NUntouchedListViewT f
)f g
)g h
;h i
public 
static 
readonly 
BindableProperty /"
NextFocusRightProperty0 F
=G H
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
INFocusElement= K
)K L
,L M
typeofN T
(T U
NUntouchedListViewU g
)g h
)h i
;i j
public 
static 
readonly 
BindableProperty /
NextFocusUpProperty0 C
=D E
BindableProperty 
. 
Create #
(# $
$str$ 1
,1 2
typeof3 9
(9 :
INFocusElement: H
)H I
,I J
typeofK Q
(Q R
NUntouchedListViewR d
)d e
)e f
;f g
public 
static 
readonly 
BindableProperty /!
NextFocusDownProperty0 E
=F G
BindableProperty 
. 
Create #
(# $
$str$ 3
,3 4
typeof5 ;
(; <
INFocusElement< J
)J K
,K L
typeofM S
(S T
NUntouchedListViewT f
)f g
)g h
;h i
public 
static 
readonly 
BindableProperty / 
NOrientationProperty0 D
=E F
BindableProperty 
. 
Create #
(# $
$str$ 2
,2 3
typeof4 :
(: ;
ScrollOrientation; L
)L M
,M N
typeofO U
(U V
NUntouchedListViewV h
)h i
,i j
propertyChangedk z
:z {
OrientationChanged	| �
)
� �
;
� �
public!! 
static!! 
readonly!! 
BindableProperty!! /
NItemSourceProperty!!0 C
=!!D E
BindableProperty"" 
."" 
Create"" #
(""# $
$str""$ 1
,""1 2
typeof""3 9
(""9 : 
ObservableCollection"": N
<""N O
NListViewItem""O \
>""\ ]
)""] ^
,""^ _
typeof""` f
(""f g
NUntouchedListView""g y
)""y z
,""z {
propertyChanged	""| �
:
""� �
ItemSourceChanged
""� �
)
""� �
;
""� �
public$$ 
static$$ 
readonly$$ 
BindableProperty$$ /!
NItemTemplateProperty$$0 E
=$$F G
BindableProperty%% 
.%% 
Create%% #
(%%# $
$str%%$ 3
,%%3 4
typeof%%5 ;
(%%; <
Func%%< @
<%%@ A
NListViewItem%%A N
,%%N O
View%%P T
>%%T U
)%%U V
,%%V W
typeof%%X ^
(%%^ _
NUntouchedListView%%_ q
)%%q r
)%%r s
;%%s t
public'' 
static'' 
readonly'' 
BindableProperty'' /!
NFocusedIndexProperty''0 E
=''F G
BindableProperty(( 
.(( 
Create(( #
(((# $
$str(($ 3
,((3 4
typeof((5 ;
(((; <
int((< ?
)((? @
,((@ A
typeof((B H
(((H I
NUntouchedListView((I [
)(([ \
,((\ ]
-((^ _
$num((_ `
,((` a
BindingMode)) 
.)) 
TwoWay)) "
,))" #
propertyChanged))$ 3
:))3 4
null))5 9
)))9 :
;)): ;
public++ 
static++ 
readonly++ 
BindableProperty++ /
NItemWidthProperty++0 B
=++C D
BindableProperty,, 
.,, 
Create,, #
(,,# $
$str,,$ 0
,,,0 1
typeof,,2 8
(,,8 9
int,,9 <
),,< =
,,,= >
typeof,,? E
(,,E F
NUntouchedListView,,F X
),,X Y
,,,Y Z
-,,[ \
$num,,\ ]
),,] ^
;,,^ _
public-- 
static-- 
readonly-- 
BindableProperty-- /
NItemHeightProperty--0 C
=--D E
BindableProperty.. 
... 
Create.. #
(..# $
$str..$ 1
,..1 2
typeof..3 9
(..9 :
int..: =
)..= >
,..> ?
typeof..@ F
(..F G
NUntouchedListView..G Y
)..Y Z
,..Z [
-..\ ]
$num..] ^
)..^ _
;.._ `
public00 
static00 
readonly00 
BindableProperty00 /!
NItemSelectedProperty000 E
=00F G
BindableProperty11 
.11 
Create11 #
(11# $
$str11$ 3
,113 4
typeof115 ;
(11; <
ICommand11< D
)11D E
,11E F
typeof11G M
(11M N
NUntouchedListView11N `
)11` a
)11a b
;11b c
public33 
static33 
readonly33 
BindableProperty33 /"
NItemAppearingProperty330 F
=33G H
BindableProperty44 
.44 
Create44 #
(44# $
$str44$ 4
,444 5
typeof446 <
(44< =
ICommand44= E
)44E F
,44F G
typeof44H N
(44N O
NUntouchedListView44O a
)44a b
)44b c
;44c d
public66 
bool66 

IsNFocused66 
{77 	
set88 
{88 
SetValue88 
(88 
IsNFocusedProperty88 -
,88- .
value88/ 4
)884 5
;885 6
}887 8
get99 
{99 
return99 
(99 
bool99 
)99 
GetValue99 '
(99' (
IsNFocusedProperty99( :
)99: ;
;99; <
}99= >
}:: 	
public<< 
Color<< 
NFocusColor<<  
{== 	
set>> 
{>> 
SetValue>> 
(>> 
NFocusColorProperty>> .
,>>. /
value>>0 5
)>>5 6
;>>6 7
}>>8 9
get?? 
{?? 
return?? 
(?? 
Color?? 
)??  
GetValue??  (
(??( )
NFocusColorProperty??) <
)??< =
;??= >
}??? @
}@@ 	
publicBB 
INFocusElementBB 
NextFocusLeftBB +
{CC 	
setDD 
{DD 
SetValueDD 
(DD !
NextFocusLeftPropertyDD 0
,DD0 1
valueDD2 7
)DD7 8
;DD8 9
}DD: ;
getEE 
{EE 
returnEE 
(EE 
INFocusElementEE (
)EE( )
GetValueEE) 1
(EE1 2!
NextFocusLeftPropertyEE2 G
)EEG H
;EEH I
}EEJ K
}FF 	
publicHH 
INFocusElementHH 
NextFocusRightHH ,
{II 	
setJJ 
{JJ 
SetValueJJ 
(JJ "
NextFocusRightPropertyJJ 1
,JJ1 2
valueJJ3 8
)JJ8 9
;JJ9 :
}JJ; <
getKK 
{KK 
returnKK 
(KK 
INFocusElementKK (
)KK( )
GetValueKK) 1
(KK1 2"
NextFocusRightPropertyKK2 H
)KKH I
;KKI J
}KKK L
}LL 	
publicNN 
INFocusElementNN 
NextFocusUpNN )
{OO 	
setPP 
{PP 
SetValuePP 
(PP 
NextFocusUpPropertyPP .
,PP. /
valuePP0 5
)PP5 6
;PP6 7
}PP8 9
getQQ 
{QQ 
returnQQ 
(QQ 
INFocusElementQQ (
)QQ( )
GetValueQQ) 1
(QQ1 2
NextFocusUpPropertyQQ2 E
)QQE F
;QQF G
}QQH I
}RR 	
publicTT 
INFocusElementTT 
NextFocusDownTT +
{UU 	
setVV 
{VV 
SetValueVV 
(VV !
NextFocusDownPropertyVV 0
,VV0 1
valueVV2 7
)VV7 8
;VV8 9
}VV: ;
getWW 
{WW 
returnWW 
(WW 
INFocusElementWW (
)WW( )
GetValueWW) 1
(WW1 2!
NextFocusDownPropertyWW2 G
)WWG H
;WWH I
}WWJ K
}XX 	
publicZZ 
FuncZZ 
<ZZ 
NListViewItemZZ !
,ZZ! "
ViewZZ# '
>ZZ' (
NItemTemplateZZ) 6
{[[ 	
set\\ 
{\\ 
SetValue\\ 
(\\ !
NItemTemplateProperty\\ 0
,\\0 1
value\\2 7
)\\7 8
;\\8 9
}\\: ;
get]] 
{]] 
return]] 
(]] 
Func]] 
<]] 
NListViewItem]] ,
,]], -
View]]. 2
>]]2 3
)]]3 4
GetValue]]4 <
(]]< =!
NItemTemplateProperty]]= R
)]]R S
;]]S T
}]]U V
}^^ 	
public`` 
ScrollOrientation``  
NOrientation``! -
{aa 	
setbb 
{bb 
SetValuebb 
(bb  
NOrientationPropertybb /
,bb/ 0
valuebb1 6
)bb6 7
;bb7 8
}bb9 :
getcc 
{cc 
returncc 
(cc 
ScrollOrientationcc +
)cc+ ,
GetValuecc, 4
(cc4 5 
NOrientationPropertycc5 I
)ccI J
;ccJ K
}ccL M
}dd 	
publicff  
ObservableCollectionff #
<ff# $
NListViewItemff$ 1
>ff1 2
NItemSourceff3 >
{gg 	
sethh 
{hh 
SetValuehh 
(hh 
NItemSourcePropertyhh .
,hh. /
valuehh0 5
)hh5 6
;hh6 7
}hh8 9
getii 
{ii 
returnii 
(ii  
ObservableCollectionii .
<ii. /
NListViewItemii/ <
>ii< =
)ii= >
GetValueii> F
(iiF G
NItemSourcePropertyiiG Z
)iiZ [
;ii[ \
}ii] ^
}jj 	
publicll 
intll 
NFocusedIndexll  
{mm 	
setnn 
{oo 
intpp 
oldpp 
=pp 
NFocusedIndexpp '
;pp' (
SetValueqq 
(qq !
NFocusedIndexPropertyqq .
,qq. /
valueqq0 5
)qq5 6
;qq6 7
FocusSpecifiedrr 
(rr 
oldrr "
,rr" #
valuerr$ )
)rr) *
;rr* +
NItemSelectedss 
?ss 
.ss 
Executess &
(ss& '
valuess' ,
)ss, -
;ss- .
iftt 
(tt 
	containertt 
.tt 
Childrentt %
.tt% &
Counttt& +
>tt, -
valuett. 3
)tt3 4
{uu 
thisvv 
.vv 
ScrollToAsyncvv &
(vv& '
	containervv' 0
.vv0 1
Childrenvv1 9
[vv9 :
valuevv: ?
]vv? @
,vv@ A
ScrollToPositionvvB R
.vvR S
MakeVisiblevvS ^
,vv^ _
falsevv` e
)vve f
;vvf g
}ww 
}yy 
getzz 
{zz 
returnzz 
(zz 
intzz 
)zz 
GetValuezz &
(zz& '!
NFocusedIndexPropertyzz' <
)zz< =
;zz= >
}zz? @
}{{ 	
public}} 
int}} 

NItemWidth}} 
{~~ 	
set 
{ 
SetValue 
( 
NItemWidthProperty -
,- .
value/ 4
)4 5
;5 6
}7 8
get
�� 
{
�� 
return
�� 
(
�� 
int
�� 
)
�� 
GetValue
�� &
(
��& ' 
NItemWidthProperty
��' 9
)
��9 :
;
��: ;
}
��< =
}
�� 	
public
�� 
int
�� 
NItemHeight
�� 
{
�� 	
set
�� 
{
�� 
SetValue
�� 
(
�� !
NItemHeightProperty
�� .
,
��. /
value
��0 5
)
��5 6
;
��6 7
}
��8 9
get
�� 
{
�� 
return
�� 
(
�� 
int
�� 
)
�� 
GetValue
�� &
(
��& '!
NItemHeightProperty
��' :
)
��: ;
;
��; <
}
��= >
}
�� 	
public
�� 
ICommand
�� 
NItemSelected
�� %
{
�� 	
set
�� 
{
�� 
SetValue
�� 
(
�� #
NItemSelectedProperty
�� 0
,
��0 1
value
��2 7
)
��7 8
;
��8 9
}
��: ;
get
�� 
{
�� 
return
�� 
(
�� 
ICommand
�� "
)
��" #
GetValue
��# +
(
��+ ,#
NItemSelectedProperty
��, A
)
��A B
;
��B C
}
��D E
}
�� 	
public
�� 
ICommand
�� 
NItemAppearing
�� &
{
�� 	
set
�� 
{
�� 
SetValue
�� 
(
�� $
NItemAppearingProperty
�� 1
,
��1 2
value
��3 8
)
��8 9
;
��9 :
}
��; <
get
�� 
{
�� 
return
�� 
(
�� 
ICommand
�� "
)
��" #
GetValue
��# +
(
��+ ,$
NItemAppearingProperty
��, B
)
��B C
;
��C D
}
��E F
}
�� 	
public
��  
NUntouchedListView
�� !
(
��! "
)
��" #
{
�� 	
FocusContext
�� 
.
�� 
Register
�� !
(
��! "
this
��" &
)
��& '
;
��' (
	container
�� 
=
�� 
new
�� 
StackLayout
�� '
{
�� 
Spacing
�� 
=
�� 
$num
�� 
}
�� 
;
�� 
Content
�� 
=
�� 
	container
�� 
;
��  
this
�� 
.
�� 
	IsEnabled
�� 
=
�� 
false
�� "
;
��" #
}
�� 	
~
�� 	 
NUntouchedListView
��	 
(
�� 
)
�� 
{
�� 	
FocusContext
�� 
.
�� 

Unregister
�� #
(
��# $
this
��$ (
)
��( )
;
��) *
}
�� 	
private
�� 
static
�� 
void
�� !
OnIsNFocusedChanged
�� /
(
��/ 0
BindableObject
��0 >
bindable
��? G
,
��G H
object
��I O
oldValue
��P X
,
��X Y
object
��Z `
newValue
��a i
)
��i j
{
�� 	 
NUntouchedListView
�� 
focusButton
�� *
=
��+ ,
(
��- . 
NUntouchedListView
��. @
)
��@ A
bindable
��A I
;
��I J
bool
�� 
	isFocused
�� 
=
�� 
(
�� 
bool
�� "
)
��" #
newValue
��# +
;
��+ ,
if
�� 
(
�� 
	isFocused
�� 
)
�� 
{
�� 
focusButton
�� 
.
�� 
active
�� "
=
��# $
true
��% )
;
��) *
}
�� 
if
�� 
(
�� 
	isFocused
�� 
&&
�� 
focusButton
�� '
.
��' (
NItemSource
��( 3
.
��3 4
Count
��4 9
>
��: ;
$num
��< =
&&
��> @
focusButton
��A L
.
��L M
NFocusedIndex
��M Z
==
��[ ]
-
��^ _
$num
��_ `
)
��` a
{
�� 
focusButton
�� 
.
�� 
NFocusedIndex
�� )
=
��* +
$num
��, -
;
��- .
focusButton
�� 
.
�� 
NItemSource
�� '
[
��' (
$num
��( )
]
��) *
.
��* +

IsNFocused
��+ 5
=
��6 7
true
��8 <
;
��< =
(
�� 
focusButton
�� 
.
�� 
	container
�� &
.
��& '
Children
��' /
[
��/ 0
$num
��0 1
]
��1 2
as
��3 5
Frame
��6 ;
)
��; <
.
��< =
BorderColor
��= H
=
��I J
focusButton
��K V
.
��V W
NFocusColor
��W b
;
��b c
}
�� 
if
�� 
(
�� 
	isFocused
�� 
&&
�� 
focusButton
�� '
.
��' (
NFocusedIndex
��( 5
>=
��6 8
$num
��9 :
)
��: ;
{
�� 
focusButton
�� 
.
�� 
NItemSource
�� '
[
��' (
focusButton
��( 3
.
��3 4
NFocusedIndex
��4 A
]
��A B
.
��B C

IsNFocused
��C M
=
��N O
true
��P T
;
��T U
(
�� 
focusButton
�� 
.
�� 
	container
�� &
.
��& '
Children
��' /
[
��/ 0
focusButton
��0 ;
.
��; <
NFocusedIndex
��< I
]
��I J
as
��K M
Frame
��N S
)
��S T
.
��T U
BorderColor
��U `
=
��a b
focusButton
��c n
.
��n o
NFocusColor
��o z
;
��z {
}
�� 
}
�� 	
private
�� 
static
�� 
void
��  
OrientationChanged
�� .
(
��. /
BindableObject
��/ =
bindable
��> F
,
��F G
object
��H N
oldValue
��O W
,
��W X
object
��Y _
newValue
��` h
)
��h i
{
�� 	
ScrollOrientation
�� 
orientation
�� )
=
��* +
(
��, -
ScrollOrientation
��- >
)
��> ?
newValue
��? G
;
��G H 
NUntouchedListView
�� 
listView
�� '
=
��( )
bindable
��* 2
as
��3 5 
NUntouchedListView
��6 H
;
��H I
listView
�� 
.
�� 
Orientation
��  
=
��! "
orientation
��# .
;
��. /
listView
�� 
.
�� 
	container
�� 
.
�� 
Orientation
�� *
=
��+ ,
orientation
��- 8
==
��9 ;
ScrollOrientation
��< M
.
��M N

Horizontal
��N X
?
��Y Z
StackOrientation
��[ k
.
��k l

Horizontal
��l v
:
��w x
StackOrientation��y �
.��� �
Vertical��� �
;��� �
}
�� 	
private
�� 
static
�� 
void
�� 
ItemSourceChanged
�� -
(
��- .
BindableObject
��. <
bindable
��= E
,
��E F
object
��G M
oldValue
��N V
,
��V W
object
��X ^
newValue
��_ g
)
��g h
{
�� 	 
NUntouchedListView
�� 
listView
�� '
=
��( )
bindable
��* 2
as
��3 5 
NUntouchedListView
��6 H
;
��H I
Device
�� 
.
�� %
BeginInvokeOnMainThread
�� *
(
��* +
listView
��+ 3
.
��3 4
Rerender
��4 <
)
��< =
;
��= >
if
�� 
(
�� 
oldValue
�� 
is
�� "
ObservableCollection
�� 0
<
��0 1
NListViewItem
��1 >
>
��> ?
oldList
��@ G
)
��G H
{
�� 
oldList
�� 
.
�� 
CollectionChanged
�� )
-=
��* ,
listView
��- 5
.
��5 6+
NItemSource_CollectionChanged
��6 S
;
��S T
}
�� 
if
�� 
(
�� 
newValue
�� 
is
�� "
ObservableCollection
�� 0
<
��0 1
NListViewItem
��1 >
>
��> ?
newList
��@ G
)
��G H
{
�� 
listView
�� 
.
�� 
NItemSource
�� $
.
��$ %
CollectionChanged
��% 6
+=
��7 9
listView
��: B
.
��B C+
NItemSource_CollectionChanged
��C `
;
��` a
}
�� 
}
�� 	
	protected
�� 
void
�� +
NItemSource_CollectionChanged
�� 4
(
��4 5
object
��5 ;
sender
��< B
,
��B C.
 NotifyCollectionChangedEventArgs
��D d
e
��e f
)
��f g
{
�� 	
if
�� 
(
�� 
e
�� 
.
�� 
Action
�� 
==
�� +
NotifyCollectionChangedAction
�� 8
.
��8 9
Add
��9 <
)
��< =
{
�� 
	container
�� 
.
�� 
Children
�� "
.
��" #
Insert
��# )
(
��) *
e
��* +
.
��+ ,
NewStartingIndex
��, <
,
��< =

CreateItem
��> H
(
��H I
(
��I J
NListViewItem
��J W
)
��W X
e
��X Y
.
��Y Z
NewItems
��Z b
[
��b c
$num
��c d
]
��d e
)
��e f
)
��f g
;
��g h
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
NFocusColor
��0 ;
=
��< =
NFocusColor
��> I
;
��I J
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
ParentListView
��0 >
=
��? @
this
��A E
;
��E F
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
SetFrame
��0 8
(
��8 9
	container
��9 B
.
��B C
Children
��C K
[
��K L
e
��L M
.
��M N
NewStartingIndex
��N ^
]
��^ _
as
��` b
Frame
��c h
)
��h i
;
��i j
if
�� 
(
�� 
e
�� 
.
�� 
NewStartingIndex
�� %
==
��& (
$num
��) *
&&
��+ -

IsNFocused
��. 8
)
��8 9
{
�� 
NItemSource
�� 
[
��  
$num
��  !
]
��! "
.
��" #

IsNFocused
��# -
=
��. /
true
��0 4
;
��4 5
}
�� 
bool
�� 
prev
�� 
=
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
>
��/ 0
$num
��1 2
;
��2 3
bool
�� 
next
�� 
=
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
<
��/ 0
NItemSource
��1 <
.
��< =
Count
��= B
-
��C D
$num
��E F
;
��F G
if
�� 
(
�� 
NOrientation
��  
==
��! #
ScrollOrientation
��$ 5
.
��5 6

Horizontal
��6 @
)
��@ A
{
�� 
if
�� 
(
�� 
prev
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusRight
��< J
=
��K L
NItemSource
��M X
[
��X Y
e
��Y Z
.
��Z [
NewStartingIndex
��[ k
]
��k l
;
��l m
}
�� 
if
�� 
(
�� 
next
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
+
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusLeft
��< I
=
��J K
NItemSource
��L W
[
��W X
e
��X Y
.
��Y Z
NewStartingIndex
��Z j
]
��j k
;
��k l
}
�� 
NItemSource
�� 
[
��  
e
��  !
.
��! "
NewStartingIndex
��" 2
]
��2 3
.
��3 4
NextFocusUp
��4 ?
=
��@ A
NextFocusUp
��B M
;
��M N
NItemSource
�� 
[
��  
e
��  !
.
��! "
NewStartingIndex
��" 2
]
��2 3
.
��3 4
NextFocusDown
��4 A
=
��B C
NextFocusDown
��D Q
;
��Q R
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
prev
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusDown
��< I
=
��J K
NItemSource
��L W
[
��W X
e
��X Y
.
��Y Z
NewStartingIndex
��Z j
]
��j k
;
��k l
}
�� 
if
�� 
(
�� 
next
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
+
��6 7
$num
��7 8
]
��8 9
.
��9 :
NextFocusUp
��: E
=
��F G
NItemSource
��H S
[
��S T
e
��T U
.
��U V
NewStartingIndex
��V f
]
��f g
;
��g h
}
�� 
NItemSource
�� 
[
��  
e
��  !
.
��! "
NewStartingIndex
��" 2
]
��2 3
.
��3 4
NextFocusLeft
��4 A
=
��B C
NextFocusLeft
��D Q
;
��Q R
NItemSource
�� 
[
��  
e
��  !
.
��! "
NewStartingIndex
��" 2
]
��2 3
.
��3 4
NextFocusRight
��4 B
=
��C D
NextFocusRight
��E S
;
��S T
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
Action
�� 
==
�� +
NotifyCollectionChangedAction
��  =
.
��= >
Remove
��> D
)
��D E
{
�� 
	container
�� 
.
�� 
Children
�� "
.
��" #
RemoveAt
��# +
(
��+ ,
e
��, -
.
��- .
OldStartingIndex
��. >
)
��> ?
;
��? @
bool
�� 
prev
�� 
=
�� 
e
�� 
.
�� 
OldStartingIndex
�� .
>
��/ 0
$num
��1 2
;
��2 3
bool
�� 
next
�� 
=
�� 
e
�� 
.
�� 
OldStartingIndex
�� .
<
��/ 0
NItemSource
��1 <
.
��< =
Count
��= B
-
��C D
$num
��E F
;
��F G
if
�� 
(
�� 
	container
�� 
.
�� 
Children
�� &
.
��& '
Count
��' ,
>
��- .
$num
��/ 0
&&
��1 3
NFocusedIndex
��4 A
>=
��B D
	container
��E N
.
��N O
Children
��O W
.
��W X
Count
��X ]
)
��] ^
{
�� 
NFocusedIndex
�� !
=
��" #
	container
��$ -
.
��- .
Children
��. 6
.
��6 7
Count
��7 <
-
��= >
$num
��? @
;
��@ A
}
�� 
if
�� 
(
�� 
NOrientation
��  
==
��! #
ScrollOrientation
��$ 5
.
��5 6

Horizontal
��6 @
)
��@ A
{
�� 
if
�� 
(
�� 
prev
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
OldStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusRight
��< J
=
��K L
next
��M Q
?
��R S
NItemSource
��T _
[
��_ `
e
��` a
.
��a b
OldStartingIndex
��b r
]
��r s
:
��t u
null
��v z
;
��z {
}
�� 
if
�� 
(
�� 
next
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
OldStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusLeft
��8 E
=
��F G
prev
��H L
?
��M N
NItemSource
��O Z
[
��Z [
e
��[ \
.
��\ ]
OldStartingIndex
��] m
-
��m n
$num
��n o
]
��o p
:
��q r
null
��s w
;
��w x
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
prev
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
OldStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusDown
��< I
=
��J K
next
��L P
?
��Q R
NItemSource
��S ^
[
��^ _
e
��_ `
.
��` a
OldStartingIndex
��a q
]
��q r
:
��s t
null
��u y
;
��y z
}
�� 
if
�� 
(
�� 
next
�� 
)
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
OldStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusUp
��8 C
=
��D E
prev
��F J
?
��K L
NItemSource
��M X
[
��X Y
e
��Y Z
.
��Z [
OldStartingIndex
��[ k
-
��l m
$num
��n o
]
��o p
:
��q r
null
��s w
;
��w x
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
Action
�� 
==
�� +
NotifyCollectionChangedAction
��  =
.
��= >
Replace
��> E
)
��E F
{
�� 
	container
�� 
.
�� 
Children
�� "
[
��" #
e
��# $
.
��$ %
NewStartingIndex
��% 5
]
��5 6
=
��7 8

CreateItem
��9 C
(
��C D
(
��D E
NListViewItem
��E R
)
��R S
e
��S T
.
��T U
NewItems
��U ]
[
��] ^
$num
��^ _
]
��_ `
)
��` a
;
��a b
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
NFocusColor
��0 ;
=
��< =
NFocusColor
��> I
;
��I J
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
ParentListView
��0 >
=
��? @
this
��A E
;
��E F
NItemSource
�� 
[
�� 
e
�� 
.
�� 
NewStartingIndex
�� .
]
��. /
.
��/ 0
SetFrame
��0 8
(
��8 9
	container
��9 B
.
��B C
Children
��C K
[
��K L
e
��L M
.
��M N
NewStartingIndex
��N ^
]
��^ _
as
��` b
Frame
��c h
)
��h i
;
��i j
if
�� 
(
�� 
e
�� 
.
�� 
NewStartingIndex
�� &
==
��' )
NFocusedIndex
��* 7
&&
��8 :
active
��; A
)
��A B
{
�� 
NItemSource
�� 
[
��  
e
��  !
.
��! "
NewStartingIndex
��" 2
]
��2 3
.
��3 4

IsNFocused
��4 >
=
��? @
true
��A E
;
��E F
}
�� 
if
�� 
(
�� 
e
�� 
.
�� 
NewStartingIndex
�� &
>
��' (
$num
��) *
)
��* +
{
�� 
if
�� 
(
�� 
NOrientation
�� $
==
��% '
ScrollOrientation
��( 9
.
��9 :

Horizontal
��: D
)
��D E
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusRight
��< J
=
��K L
NItemSource
��M X
[
��X Y
e
��Y Z
.
��Z [
NewStartingIndex
��[ k
]
��k l
;
��l m
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusLeft
��8 E
=
��F G
NItemSource
��H S
[
��S T
e
��T U
.
��U V
NewStartingIndex
��V f
-
��g h
$num
��i j
]
��j k
;
��k l
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusUp
��8 C
=
��D E
NextFocusUp
��F Q
;
��Q R
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusDown
��8 E
=
��F G
NextFocusDown
��H U
;
��U V
}
�� 
else
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
-
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusDown
��< I
=
��J K
NItemSource
��L W
[
��W X
e
��X Y
.
��Y Z
NewStartingIndex
��Z j
]
��j k
;
��k l
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusUp
��8 C
=
��D E
NItemSource
��F Q
[
��Q R
e
��R S
.
��S T
NewStartingIndex
��T d
-
��e f
$num
��g h
]
��h i
;
��i j
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusLeft
��8 E
=
��F G
NextFocusLeft
��H U
;
��U V
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusRight
��8 F
=
��G H
NextFocusRight
��I W
;
��W X
}
�� 
}
�� 
if
�� 
(
�� 
e
�� 
.
�� 
NewStartingIndex
�� &
<
��' (
NItemSource
��) 4
.
��4 5
Count
��5 :
-
��; <
$num
��= >
)
��> ?
{
�� 
if
�� 
(
�� 
NOrientation
�� $
==
��% '
ScrollOrientation
��( 9
.
��9 :

Horizontal
��: D
)
��D E
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
+
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusLeft
��< I
=
��J K
NItemSource
��L W
[
��W X
e
��X Y
.
��Y Z
NewStartingIndex
��Z j
]
��j k
;
��k l
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusRight
��8 F
=
��G H
NItemSource
��I T
[
��T U
e
��U V
.
��V W
NewStartingIndex
��W g
+
��h i
$num
��j k
]
��k l
;
��l m
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusUp
��8 C
=
��D E
NextFocusUp
��F Q
;
��Q R
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusDown
��8 E
=
��F G
NextFocusDown
��H U
;
��U V
}
�� 
else
�� 
{
�� 
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
+
��7 8
$num
��9 :
]
��: ;
.
��; <
NextFocusUp
��< G
=
��H I
NItemSource
��J U
[
��U V
e
��V W
.
��W X
NewStartingIndex
��X h
]
��h i
;
��i j
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusDown
��8 E
=
��F G
NItemSource
��H S
[
��S T
e
��T U
.
��U V
NewStartingIndex
��V f
+
��g h
$num
��i j
]
��j k
;
��k l
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusLeft
��8 E
=
��F G
NextFocusLeft
��H U
;
��U V
NItemSource
�� #
[
��# $
e
��$ %
.
��% &
NewStartingIndex
��& 6
]
��6 7
.
��7 8
NextFocusRight
��8 F
=
��G H
NextFocusRight
��I W
;
��W X
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
Action
�� 
==
�� +
NotifyCollectionChangedAction
��  =
.
��= >
Reset
��> C
)
��C D
{
�� 
	container
�� 
.
�� 
Children
�� "
.
��" #
Clear
��# (
(
��( )
)
��) *
;
��* +
}
�� 
	container
�� 
.
�� 
	IsVisible
�� 
=
��  !
true
��" &
;
��& '
}
�� 	
private
�� 
Frame
�� 

CreateItem
��  
(
��  !
NListViewItem
��! .
item
��/ 3
)
��3 4
{
�� 	
Frame
�� 
frame
�� 
=
�� 
new
�� 
Frame
�� #
(
��# $
)
��$ %
{
�� 
Padding
�� 
=
�� 
$num
�� 
,
�� 
Margin
�� 
=
�� 
$num
�� 
,
�� 
BorderColor
�� 
=
�� 
Color
�� #
.
��# $
Transparent
��$ /
,
��/ 0
BackgroundColor
�� 
=
��  !
Color
��" '
.
��' (
Transparent
��( 3
,
��3 4
VerticalOptions
�� 
=
��  !
LayoutOptions
��" /
.
��/ 0
Center
��0 6
,
��6 7
HorizontalOptions
�� !
=
��" #
LayoutOptions
��$ 1
.
��1 2
Center
��2 8
,
��8 9
WidthRequest
�� 
=
�� 

NItemWidth
�� )
,
��) *
HeightRequest
�� 
=
�� 
NItemHeight
��  +
,
��+ ,
}
�� 
;
�� 
var
�� 
view
�� 
=
�� 
NItemTemplate
�� $
.
��$ %
Invoke
��% +
(
��+ ,
item
��, 0
)
��0 1
;
��1 2
view
�� 
.
�� 
VerticalOptions
��  
=
��! "
LayoutOptions
��# 0
.
��0 1
CenterAndExpand
��1 @
;
��@ A
view
�� 
.
�� 
HorizontalOptions
�� "
=
��# $
LayoutOptions
��% 2
.
��2 3
CenterAndExpand
��3 B
;
��B C
frame
�� 
.
�� 
Content
�� 
=
�� 
view
��  
;
��  !
return
�� 
frame
�� 
;
�� 
}
�� 	
private
�� 
bool
�� 
	FocusPrev
�� 
(
�� 
)
��  
{
�� 	
if
�� 
(
�� 
NFocusedIndex
�� 
-
�� 
$num
��  !
>=
��" $
$num
��% &
&&
��' )
NFocusedIndex
��* 7
-
��8 9
$num
��: ;
<
��< =
NItemSource
��> I
.
��I J
Count
��J O
)
��O P
{
�� 
NFocusedIndex
�� 
--
�� 
;
��  
return
�� 
true
�� 
;
�� 
}
�� 
return
�� 
false
�� 
;
�� 
}
�� 	
private
�� 
void
�� 
FocusSpecified
�� #
(
��# $
int
��$ '
old
��( +
,
��+ ,
int
��- 0
index
��1 6
)
��6 7
{
�� 	
INFocusElement
�� 

oldElement
�� %
=
��& '
null
��( ,
;
��, -
INFocusElement
�� 

newElement
�� %
=
��& '
null
��( ,
;
��, -
if
�� 
(
�� 
old
�� 
>=
�� 
$num
�� 
&&
�� 
old
�� 
<
��  
NItemSource
��! ,
.
��, -
Count
��- 2
)
��2 3
{
�� 

oldElement
�� 
=
�� 
NItemSource
�� (
[
��( )
old
��) ,
]
��, -
;
��- .
}
�� 
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� "
<
��# $
NItemSource
��% 0
.
��0 1
Count
��1 6
)
��6 7
{
�� 

newElement
�� 
=
�� 
NItemSource
�� (
[
��( )
index
��) .
]
��. /
;
��/ 0
}
�� 
FocusContext
�� 
.
�� 
ChangeFocus
�� $
(
��$ %

oldElement
��% /
,
��/ 0

newElement
��1 ;
)
��; <
;
��< =
}
�� 	
public
�� 
void
�� 
	SetActive
�� 
(
�� 
bool
�� "
active
��# )
)
��) *
{
�� 	
this
�� 
.
�� 
active
�� 
=
�� 
active
��  
;
��  !
}
�� 	
public
�� 
Frame
�� 
GetFrame
�� 
(
�� 
int
�� !
index
��" '
)
��' (
{
�� 	
return
�� 
index
�� 
>=
�� 
$num
�� 
&&
��  
index
��! &
<
��' (
NItemSource
��) 4
.
��4 5
Count
��5 :
?
��; <
	container
��= F
.
��F G
Children
��G O
[
��O P
index
��P U
]
��U V
as
��W Y
Frame
��Z _
:
��` a
null
��b f
;
��f g
}
�� 	
public
�� 
View
��  
GetCurrentItemView
�� &
(
��& '
)
��' (
{
�� 	
if
�� 
(
�� 
NFocusedIndex
�� 
<
�� 
$num
��  !
)
��! "
return
�� 
	container
��  
.
��  !
Children
��! )
[
��) *
$num
��* +
]
��+ ,
;
��, -
if
�� 
(
�� 
NFocusedIndex
�� 
>=
��  
	container
��! *
.
��* +
Children
��+ 3
.
��3 4
Count
��4 9
)
��9 :
return
�� 
	container
��  
.
��  !
Children
��! )
[
��) *
	container
��* 3
.
��3 4
Children
��4 <
.
��< =
Count
��= B
-
��C D
$num
��E F
]
��F G
;
��G H
return
�� 
	container
�� 
.
�� 
Children
�� %
[
��% &
NFocusedIndex
��& 3
]
��3 4
;
��4 5
}
�� 	
public
�� 
void
�� 
	FocusLeft
�� 
(
�� 
)
�� 
{
�� 	
if
�� 
(
�� 
NOrientation
�� 
==
�� 
ScrollOrientation
�� 0
.
��0 1

Horizontal
��1 ;
)
��; <
{
�� 
if
�� 
(
�� 
!
�� 
	FocusPrev
�� 
(
�� 
)
�� 
&&
��  "
FocusContext
��# /
.
��/ 0
	FocusLeft
��0 9
(
��9 :
this
��: >
)
��> ?
)
��? @
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
FocusContext
��  
.
��  !
	FocusLeft
��! *
(
��* +
this
��+ /
)
��/ 0
)
��0 1
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 

FocusRight
�� 
(
�� 
)
��  
{
�� 	
if
�� 
(
�� 
NOrientation
�� 
==
�� 
ScrollOrientation
��  1
.
��1 2

Horizontal
��2 <
)
��< =
{
�� 
if
�� 
(
�� 
!
�� 
	FocusNext
�� 
(
�� 
)
�� 
&&
��  "
FocusContext
��# /
.
��/ 0

FocusRight
��0 :
(
��: ;
this
��; ?
)
��? @
)
��@ A
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
FocusContext
�� 
.
��  

FocusRight
��  *
(
��* +
this
��+ /
)
��/ 0
)
��0 1
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
FocusUp
�� 
(
�� 
)
�� 
{
�� 	
if
�� 
(
�� 
NOrientation
�� 
==
�� 
ScrollOrientation
��  1
.
��1 2
Vertical
��2 :
)
��: ;
{
�� 
if
�� 
(
�� 
!
�� 
	FocusPrev
�� 
(
�� 
)
�� 
&&
��  "
FocusContext
��# /
.
��/ 0
FocusUp
��0 7
(
��7 8
this
��8 <
)
��< =
)
��= >
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
FocusContext
�� 
.
��  
FocusUp
��  '
(
��' (
this
��( ,
)
��, -
)
��- .
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
	FocusDown
�� 
(
�� 
)
�� 
{
�� 	
if
�� 
(
�� 
NOrientation
�� 
==
�� 
ScrollOrientation
��  1
.
��1 2
Vertical
��2 :
)
��: ;
{
�� 
if
�� 
(
�� 
!
�� 
	FocusNext
�� 
(
�� 
)
�� 
&&
��  "
FocusContext
��# /
.
��/ 0
	FocusDown
��0 9
(
��9 :
this
��: >
)
��> ?
)
��? @
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
FocusContext
��  
.
��  !
	FocusDown
��! *
(
��* +
this
��+ /
)
��/ 0
)
��0 1
{
�� 
active
�� 
=
�� 
false
�� "
;
��" #
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
FocusAction
�� 
(
��  
)
��  !
{
�� 	
if
�� 
(
�� 
NFocusedIndex
�� 
>=
�� 
$num
��  !
&&
��" $
NFocusedIndex
��% 2
<
��3 4
NItemSource
��5 @
.
��@ A
Count
��A F
)
��F G
{
�� 
NItemSource
�� 
[
�� 
NFocusedIndex
�� )
]
��) *
.
��* +
FocusAction
��+ 6
(
��6 7
)
��7 8
;
��8 9
}
�� 
}
�� 	
public
�� 
void
�� 
LongFocusAction
�� #
(
��# $
)
��$ %
{
�� 	
if
�� 
(
�� 
NFocusedIndex
�� 
>=
��  
$num
��! "
&&
��# %
NFocusedIndex
��& 3
<
��4 5
NItemSource
��6 A
.
��A B
Count
��B G
)
��G H
{
�� 
NItemSource
�� 
[
�� 
NFocusedIndex
�� )
]
��) *
.
��* +
LongFocusAction
��+ :
(
��: ;
)
��; <
;
��< =
}
�� 
}
�� 	
private
�� 
bool
�� 
	FocusNext
�� 
(
�� 
)
��  
{
�� 	
if
�� 
(
�� 
NFocusedIndex
�� 
+
�� 
$num
��  !
>=
��" $
$num
��% &
&&
��' )
NFocusedIndex
��* 7
+
��8 9
$num
��: ;
<
��< =
NItemSource
��> I
.
��I J
Count
��J O
)
��O P
{
�� 
NFocusedIndex
�� 
++
�� 
;
��  
return
�� 
true
�� 
;
�� 
}
�� 
return
�� 
false
�� 
;
�� 
}
�� 	
public
�� 
void
�� 
Rerender
�� 
(
�� 
)
�� 
{
�� 	+
NItemSource_CollectionChanged
�� )
(
��) *
null
��* .
,
��. /
new
��0 3.
 NotifyCollectionChangedEventArgs
��4 T
(
��T U+
NotifyCollectionChangedAction
��U r
.
��r s
Reset
��s x
)
��x y
)
��y z
;
��z {
for
�� 
(
�� 
int
�� 
a
�� 
=
�� 
$num
�� 
;
�� 
a
�� 
<
�� 
NItemSource
��  +
.
��+ ,
Count
��, 1
;
��1 2
a
��3 4
++
��4 6
)
��6 7
{
�� +
NItemSource_CollectionChanged
�� -
(
��- .
null
��. 2
,
��2 3
new
��4 7.
 NotifyCollectionChangedEventArgs
��8 X
(
��X Y+
NotifyCollectionChangedAction
��Y v
.
��v w
Add
��w z
,
��z {
NItemSource��| �
[��� �
a��� �
]��� �
,��� �
a��� �
)��� �
)��� �
;��� �
}
�� 
}
�� 	
}
�� 
}�� �
1D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Fonts.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
{ 
public 

static 
class 
Fonts 
{ 
public 
const 
string 
Black !
=" #
$str$ I
;I J
public 
const 
string 
Bold  
=! "
$str# F
;F G
public 
const 
string 
Regular #
=$ %
$str& O
;O P
public		 
const		 
string		 
Medium		 "
=		# $
$str		% L
;		L M
public

 
const

 
string

 
Light

 !
=

" #
$str

$ I
;

I J
public 
const 
string 
Thin  
=! "
$str# F
;F G
} 
} �
2D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Global.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
{ 
public 

static 
class 
Global 
{ 
public 
static 
IPermission !
Permissions" -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public		 
static		 
IApplication		 "
Application		# .
{		/ 0
get		1 4
;		4 5
set		6 9
;		9 :
}		; <
public

 
static

 
IImageProcessing

 &
ImageProcessing

' 6
{

7 8
get

9 <
;

< =
set

> A
;

A B
}

C D
public 
static 
IContextMenuBuilder )
ContextMenuBuilder* <
{= >
get? B
;B C
setD G
;G H
}I J
public 
static 
bool 
Loaded !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
static 
bool 
TV 
{ 
get  #
;# $
set% (
;( )
}* +
public 
static 
NavigationWrapper '
NavigationInstance( :
{; <
get= @
;@ A
setB E
;E F
}G H
public 
static 
Page 
Page 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} �
GD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\ContentViewExtensions.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

static 
class !
ContentViewExtensions -
{ 
public 
static 
bool 
IsTimerView &
(& '
this' +
ContentView, 7
contentView8 C
)C D
{		 	
return

 
contentView

 
is

 !
ITimerContent

" /
;

/ 0
} 	
} 
} ��
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\ContextMenuBuilder.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

static 
class 
ContextMenuBuilder *
{ 
private 
static 
string 
CurrentModelInfo .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
static 
void 
BuildForTrack (
(( )
Xamarin) 0
.0 1
Forms1 6
.6 7
View7 ;
sender< B
,B C
stringD J
	modelInfoK T
)T U
{ 	
CurrentModelInfo 
= 
	modelInfo (
;( )
string 
[ 
] 
elems 
= 
CurrentModelInfo -
.- .
Split. 3
(3 4

GlobalData4 >
.> ?
	SEPARATOR? H
,H I
SystemJ P
.P Q
StringSplitOptionsQ c
.c d
Noned h
)h i
;i j
string 
filePath 
= 
elems #
[# $
$num$ %
]% &
;& '
string 
playlistName 
=  !
elems" '
[' (
$num( )
]) *
;* +
List   
<   
string   
>   
	menuItems   "
=  # $
new  % (
List  ) -
<  - .
string  . 4
>  4 5
(  5 6
)  6 7
{  8 9
filePath  : B
.  B C
Length  C I
==  J L
$num  M O
?  P Q
Localization  R ^
.  ^ _
Download  _ g
:  h i
Localization  j v
.  v w
TrackMenuEdit	  w �
,
  � �
Localization
  � �
.
  � �
TrackMenuPlaylist
  � �
,
  � �
Localization
  � �
.
  � �
TrackMenuQueue
  � �
}
  � �
;
  � �
if!! 
(!! 
!!! 
string!! 
.!! 
IsNullOrEmpty!! %
(!!% &
playlistName!!& 2
)!!2 3
)!!3 4
	menuItems"" 
."" 
Add"" 
("" 
Localization"" *
.""* +
SyncAddPlaylist""+ :
)"": ;
;""; <
	menuItems$$ 
.$$ 
Add$$ 
($$ 
Localization$$ &
.$$& '
TrackMenuDelete$$' 6
)$$6 7
;$$7 8
Global&& 
.&& 
ContextMenuBuilder&& %
.&&% &
BuildForTrack&&& 3
(&&3 4
sender&&4 :
,&&: ;
	modelInfo&&< E
,&&E F
filePath&&G O
,&&O P
playlistName&&Q ]
,&&] ^
	menuItems&&_ h
,&&h i
TrackAction&&j u
)&&u v
;&&v w
}'' 	
public)) 
static)) 
void)) 
BuildForPlaylist)) +
())+ ,
View)), 0
sender))1 7
,))7 8
string))9 ?
playlistName))@ L
)))L M
{** 	
List++ 
<++ 
string++ 
>++ 
elements++ !
=++" #
new++$ '
List++( ,
<++, -
string++- 3
>++3 4
(++4 5
)++5 6
{++7 8
Localization++9 E
.++E F
PlaylistPlay++F R
,++R S
Localization++T `
.++` a
TrackMenuPlaylist++a r
,++r s
Localization	++t �
.
++� �
TrackMenuQueue
++� �
,
++� �
Localization
++� �
.
++� �

ChangeName
++� �
,
++� �
Localization
++� �
.
++� �
TrackMenuDelete
++� �
}
++� �
;
++� �
Global-- 
.-- 
ContextMenuBuilder-- %
.--% &
BuildForPlaylist--& 6
(--6 7
sender--7 =
,--= >
playlistName--? K
,--K L
elements--M U
,--U V
PlaylistAction--W e
)--e f
;--f g
}.. 	
public00 
static00 
void00 
BuildForArtist00 )
(00) *
View00* .
sender00/ 5
,005 6
string007 =

artistName00> H
)00H I
{11 	
List22 
<22 
string22 
>22 
elements22 !
=22" #
new22$ '
List22( ,
<22, -
string22- 3
>223 4
(224 5
)225 6
{227 8
Localization229 E
.22E F
PlaylistPlay22F R
,22R S
Localization22T `
.22` a
TrackMenuPlaylist22a r
,22r s
Localization	22t �
.
22� �
TrackMenuQueue
22� �
}
22� �
;
22� �
Global44 
.44 
ContextMenuBuilder44 %
.44% &
BuildForArtist44& 4
(444 5
sender445 ;
,44; <

artistName44= G
,44G H
elements44I Q
,44Q R
ArtistAction44S _
)44_ `
;44` a
}55 	
public77 
static77 
void77  
BuildForSearchResult77 /
(77/ 0
View770 4
sender775 ;
,77; <
string77= C
	modelInfo77D M
)77M N
{88 	
List99 
<99 
string99 
>99 
elements99 !
=99" #
new99$ '
List99( ,
<99, -
string99- 3
>993 4
(994 5
)995 6
{997 8
Localization999 E
.99E F
Download99F N
,99N O
Localization99P \
.99\ ]
TrackMenuPlaylist99] n
}99o p
;99p q
Global;; 
.;; 
ContextMenuBuilder;; %
.;;% & 
BuildForSearchResult;;& :
(;;: ;
sender;;; A
,;;A B
	modelInfo;;C L
,;;L M
elements;;N V
,;;V W
SearchResultAction;;X j
);;j k
;;;k l
}<< 	
private?? 
static?? 
async?? 
Task?? !
TrackAction??" -
(??- .
string??. 4
filePath??5 =
,??= >
string??? E
item??F J
,??J K
string??L R
playlistName??S _
)??_ `
{@@ 	
PageAA 
pageAA 
=AA 
GlobalAA 
.AA 
PageAA #
;AA# $
ifCC 
(CC 
filePathCC 
.CC 
LengthCC 
==CC !
$numCC" $
&&CC% '
!CC( )

GlobalDataCC) 3
.CC3 4
CurrentCC4 ;
.CC; <
SavedTracksCC< G
.CCG H
ContainsKeyCCH S
(CCS T
filePathCCT \
)CC\ ]
)CC] ^
{DD 
YoutubeClientEE 
clientEE $
=EE% &
newEE' *
YoutubeClientEE+ 8
(EE8 9
)EE9 :
;EE: ;
varFF 
videoFF 
=FF 
awaitFF !
clientFF" (
.FF( )
VideosFF) /
.FF/ 0
GetAsyncFF0 8
(FF8 9
filePathFF9 A
)FFA B
;FFB C
varHH 
mediaSourceHH 
=HH  !
newHH" %
CoreHH& *
.HH* +
MediaHH+ 0
.HH0 1
MediaSourceHH1 <
(HH< =
)HH= >
{II 
ArtistJJ 
=JJ 
videoJJ "
.JJ" #
AuthorJJ# )
,JJ) *
DurationKK 
=KK 
videoKK $
.KK$ %
DurationKK% -
,KK- .
FilePathLL 
=LL 
videoLL $
.LL$ %
IdLL% '
,LL' (
TitleMM 
=MM 
videoMM !
.MM! "
TitleMM" '
,MM' (
TypeNN 
=NN 
CoreNN 
.NN  
MediaNN  %
.NN% &
MediaSourceNN& 1
.NN1 2

SourceTypeNN2 <
.NN< =
WebNN= @
}OO 
;OO 
tryQQ 
{RR 
usingSS 
	WebClientSS #
	webClientSS$ -
=SS. /
newSS0 3
	WebClientSS4 =
(SS= >
)SS> ?
;SS? @
byteTT 
[TT 
]TT 
	thumbDataTT $
=TT% &
	webClientTT' 0
.TT0 1
DownloadDataTT1 =
(TT= >
videoTT> C
.TTC D

ThumbnailsTTD N
.TTN O
MediumResUrlTTO [
)TT[ \
;TT\ ]
mediaSourceUU 
.UU  
ImageUU  %
=UU& '
	thumbDataUU( 1
;UU1 2
}VV 
catchWW 
{XX 
}ZZ 

GlobalData\\ 
.\\ 
Current\\ "
.\\" #
SavedTracks\\# .
.\\. /
Add\\/ 2
(\\2 3
filePath\\3 ;
,\\; <
mediaSource\\= H
)\\H I
;\\I J

GlobalData]] 
.]] 
Current]] "
.]]" #
SaveSavedTracks]]# 2
(]]2 3
)]]3 4
;]]4 5
}^^ 
var__ 
track__ 
=__ 
filePath__  
.__  !
Length__! '
==__( *
$num__+ -
?__. /

GlobalData__0 :
.__: ;
Current__; B
.__B C
SavedTracks__C N
[__N O
filePath__O W
]__W X
:__Y Z

GlobalData__[ e
.__e f
Current__f m
.__m n
Audios__n t
[__t u
filePath__u }
]__} ~
;__~ 
ifaa 
(aa 
trackaa 
==aa 
nullaa 
)aa 
{bb 
Globalcc 
.cc 
Applicationcc "
.cc" #
ShowSnackbarcc# /
(cc/ 0
Localizationcc0 <
.cc< =
SnackFileExistscc= L
)ccL M
;ccM N
returndd 
;dd 
}ee 
ifgg 
(gg 
itemgg 
==gg 
Localizationgg $
.gg$ %
TrackMenuEditgg% 2
)gg2 3
{hh 
stringii 
titleii 
;ii 
stringjj 
artistjj 
;jj 
ifll 
(ll 

GlobalDatall 
.ll 
Currentll &
.ll& '
	AudioTagsll' 0
.ll0 1
ContainsKeyll1 <
(ll< =
filePathll= E
)llE F
)llF G
{mm 
artistnn 
=nn 

GlobalDatann '
.nn' (
Currentnn( /
.nn/ 0
	AudioTagsnn0 9
[nn9 :
filePathnn: B
]nnB C
.nnC D
AuthornnD J
;nnJ K
titleoo 
=oo 

GlobalDataoo &
.oo& '
Currentoo' .
.oo. /
	AudioTagsoo/ 8
[oo8 9
filePathoo9 A
]ooA B
.ooB C
TitleooC H
;ooH I
}pp 
elseqq 
{rr 
artistss 
=ss 

GlobalDatass '
.ss' (
Currentss( /
.ss/ 0
Audiosss0 6
[ss6 7
filePathss7 ?
]ss? @
.ss@ A
ArtistssA G
;ssG H
titlett 
=tt 

GlobalDatatt &
.tt& '
Currenttt' .
.tt. /
Audiostt/ 5
[tt5 6
filePathtt6 >
]tt> ?
.tt? @
Titlett@ E
;ttE F
}uu 
stringww 

userArtistww !
=ww" #
awaitww$ )
pageww* .
.ww. /
DisplayPromptAsyncww/ A
(wwA B
LocalizationwwB N
.wwN O
ArtistwwO U
,wwU V
artistwwW ]
,ww] ^
$strww_ c
,wwc d
Localizationwwe q
.wwq r
Cancelwwr x
,wwx y
artist	wwz �
,
ww� �
-
ww� �
$num
ww� �
,
ww� �
null
ww� �
,
ww� �
artist
ww� �
)
ww� �
;
ww� �
stringxx 
	userTitlexx  
=xx! "
awaitxx# (
pagexx) -
.xx- .
DisplayPromptAsyncxx. @
(xx@ A
LocalizationxxA M
.xxM N
TitlexxN S
,xxS T
titlexxU Z
,xxZ [
$strxx\ `
,xx` a
Localizationxxb n
.xxn o
Cancelxxo u
,xxu v
titlexxw |
,xx| }
-xx~ 
$num	xx �
,
xx� �
null
xx� �
,
xx� �
title
xx� �
)
xx� �
;
xx� �
ifzz 
(zz 

userArtistzz 
!=zz !
nullzz" &
&&zz' )
	userTitlezz* 3
!=zz4 6
nullzz7 ;
)zz; <
{{{ 
if|| 
(|| 
!|| 

GlobalData|| #
.||# $
Current||$ +
.||+ ,
	AudioTags||, 5
.||5 6
ContainsKey||6 A
(||A B
filePath||B J
)||J K
)||K L
{}} 

GlobalData~~ "
.~~" #
Current~~# *
.~~* +
	AudioTags~~+ 4
.~~4 5
Add~~5 8
(~~8 9
filePath~~9 A
,~~A B
new~~C F
Newtone~~G N
.~~N O
Core~~O S
.~~S T
Media~~T Y
.~~Y Z
MediaSourceTag~~Z h
(~~h i
)~~i j
{~~k l
Author~~m s
=~~t u

userArtist	~~v �
,
~~� �
Title
~~� �
=
~~� �
	userTitle
~~� �
}
~~� �
)
~~� �
;
~~� �
} 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
	AudioTags
��' 0
[
��0 1
filePath
��1 9
]
��9 :
.
��: ;
Author
��; A
=
��B C

userArtist
��D N
;
��N O

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
	AudioTags
��' 0
[
��0 1
filePath
��1 9
]
��9 :
.
��: ;
Title
��; @
=
��A B
	userTitle
��C L
;
��L M
var
�� 
	newSource
�� !
=
��" #

GlobalData
��$ .
.
��. /
Current
��/ 6
.
��6 7
Audios
��7 =
[
��= >
filePath
��> F
]
��F G
.
��G H
Clone
��H M
(
��M N
)
��N O
;
��O P
	newSource
�� 
.
�� 
Title
�� #
=
��$ %
	userTitle
��& /
;
��/ 0
	newSource
�� 
.
�� 
Artist
�� $
=
��% &

userArtist
��' 1
;
��1 2
GlobalLoader
��  
.
��  !
ChangeTrack
��! ,
(
��, -

GlobalData
��- 7
.
��7 8
Current
��8 ?
.
��? @
Audios
��@ F
[
��F G
filePath
��G O
]
��O P
,
��P Q
	newSource
��R [
)
��[ \
;
��\ ]

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
SaveTags
��' /
(
��/ 0
)
��0 1
;
��1 2
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
Ready
��A F
)
��F G
;
��G H
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuPlaylist
��* ;
)
��; <
{
�� 
List
�� 
<
�� 
string
�� 
>
�� 
	positions
�� &
=
��' (
new
��) ,
List
��- 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
)
��: ;
{
�� 
Localization
��  
.
��  !
NewPlaylist
��! ,
}
�� 
;
�� 
foreach
�� 
(
�� 
string
�� 
playlist
��  (
in
��) +

GlobalData
��, 6
.
��6 7
Current
��7 >
.
��> ?
	Playlists
��? H
.
��H I
Keys
��I M
)
��M N
	positions
�� 
.
�� 
Add
�� !
(
��! "
playlist
��" *
)
��* +
;
��+ ,
string
�� 
answer
�� 
=
�� 
await
��  %
page
��& *
.
��* + 
DisplayActionSheet
��+ =
(
��= >
Localization
��> J
.
��J K
ChoosePlaylist
��K Y
,
��Y Z
Localization
��[ g
.
��g h
Cancel
��h n
,
��n o
null
��p t
,
��t u
	positions
��v 
.�� �
ToArray��� �
(��� �
)��� �
)��� �
;��� �
if
�� 
(
�� 
answer
�� 
==
�� 
Localization
�� *
.
��* +
NewPlaylist
��+ 6
)
��6 7
{
�� 
string
�� 
playlist
�� #
=
��$ %
await
��& +
page
��, 0
.
��0 1 
DisplayPromptAsync
��1 C
(
��C D
Localization
��D P
.
��P Q
NewPlaylist
��Q \
,
��\ ]
Localization
��^ j
.
��j k
NewPlaylistHint
��k z
,
��z {
Localization��| �
.��� �
Add��� �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
Playlist��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
Localization��� �
.��� �
NewPlaylist��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 
string
�� 
.
��  
IsNullOrEmpty
��  -
(
��- .
playlist
��. 6
)
��6 7
)
��7 8
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
.
��8 9
ContainsKey
��9 D
(
��D E
playlist
��E M
)
��M N
)
��N O

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
playlist
��9 A
]
��A B
.
��B C
Add
��C F
(
��F G
track
��G L
.
��L M
FilePath
��M U
)
��U V
;
��V W
else
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
.
��8 9
Add
��9 <
(
��< =
playlist
��= E
,
��E F
new
��G J
List
��K O
<
��O P
string
��P V
>
��V W
(
��W X
)
��X Y
{
��Z [
track
��\ a
.
��a b
FilePath
��b j
}
��k l
)
��l m
;
��m n

GlobalData
�� "
.
��" #
Current
��# *
.
��* +"
PlaylistsNeedRefresh
��+ ?
=
��@ A
true
��B F
;
��F G

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SnackPlaylist
��E R
)
��R S
;
��S T
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
	Playlists
��, 5
.
��5 6
ContainsKey
��6 A
(
��A B
answer
��B H
)
��H I
)
��I J
{
�� 
if
�� 
(
�� 
!
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
	Playlists
��, 5
[
��5 6
answer
��6 <
]
��< =
.
��= >
Contains
��> F
(
��F G
filePath
��G O
)
��O P
)
��P Q

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
	Playlists
��+ 4
[
��4 5
answer
��5 ;
]
��; <
.
��< =
Add
��= @
(
��@ A
filePath
��A I
)
��I J
;
��J K

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

SaveConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
SnackPlaylist
��A N
)
��N O
;
��O P
}
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #"
PlaylistsNeedRefresh
��# 7
=
��8 9
true
��: >
;
��> ?
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuDelete
��* 9
)
��9 :
{
�� 
bool
�� 
answer
�� 
=
�� 
await
�� #
page
��$ (
.
��( )
DisplayAlert
��) 5
(
��5 6
Localization
��6 B
.
��B C
Question
��C K
,
��K L
Localization
��M Y
.
��Y Z
QuestionDelete
��Z h
+
��i j
$str
��k n
+
��o p
track
��q v
.
��v w
Title
��w |
+
��} ~
(�� �
playlistName��� �
!=��� �
$str��� �
?��� �
$str��� �
+��� �
Localization��� �
.��� �*
QuestionDeleteFromPlaylist��� �
+��� �
$str��� �
:��� �
$str��� �
)��� �
,��� �
Localization��� �
.��� �
Yes��� �
,��� �
Localization��� �
.��� �
No��� �
)��� �
;��� �
if
�� 
(
�� 
answer
�� 
)
�� 
{
�� 
if
�� 
(
�� 
playlistName
�� $
==
��% '
$str
��( *
)
��* +
{
�� 
if
�� 
(
�� 
File
��  
.
��  !
Exists
��! '
(
��' (
filePath
��( 0
)
��0 1
)
��1 2
File
��  
.
��  !
Delete
��! '
(
��' (
filePath
��( 0
)
��0 1
;
��1 2
if
�� 
(
�� 
filePath
�� #
.
��# $
Length
��$ *
==
��+ -
$num
��. 0
)
��0 1
{
�� 
GlobalLoader
�� (
.
��( )
RemoveSavedTrack
��) 9
(
��9 :
filePath
��: B
)
��B C
;
��C D
}
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Artists
��/ 6
[
��6 7
track
��7 <
.
��< =
Artist
��= C
]
��C D
.
��D E
Contains
��E M
(
��M N
track
��N S
.
��S T
FilePath
��T \
)
��\ ]
)
��] ^

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Artists
��/ 6
[
��6 7
track
��7 <
.
��< =
Artist
��= C
]
��C D
.
��D E
Remove
��E K
(
��K L
track
��L Q
.
��Q R
FilePath
��R Z
)
��Z [
;
��[ \
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Artists
��/ 6
[
��6 7
track
��7 <
.
��< =
Artist
��= C
]
��C D
.
��D E
Count
��E J
==
��K M
$num
��N O
)
��O P
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Artists
��/ 6
.
��6 7
Remove
��7 =
(
��= >
track
��> C
.
��C D
Artist
��D J
)
��J K
;
��K L

GlobalData
�� &
.
��& '
Current
��' .
.
��. / 
ArtistsNeedRefresh
��/ A
=
��B C
true
��D H
;
��H I
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
Audios
��+ 1
.
��1 2
Remove
��2 8
(
��8 9
filePath
��9 A
)
��A B
;
��B C
foreach
�� 
(
��  !
var
��! $
playlist
��% -
in
��. 0

GlobalData
��1 ;
.
��; <
Current
��< C
.
��C D
	Playlists
��D M
.
��M N
Keys
��N R
)
��R S
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
[
��< =
playlist
��= E
]
��E F
.
��F G
Contains
��G O
(
��O P
filePath
��P X
)
��X Y
)
��Y Z
{
�� 

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
[
��< =
playlist
��= E
]
��E F
.
��F G
Remove
��G M
(
��M N
filePath
��N V
)
��V W
;
��W X

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3"
PlaylistsNeedRefresh
��3 G
=
��H I
true
��J N
;
��N O
}
�� 
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
playlistName
��9 E
]
��E F
.
��F G
Contains
��G O
(
��O P
filePath
��P X
)
��X Y
)
��Y Z
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
playlistName
��9 E
]
��E F
.
��F G
Remove
��G M
(
��M N
filePath
��N V
)
��V W
;
��W X

GlobalData
�� &
.
��& '
Current
��' .
.
��. /"
PlaylistsNeedRefresh
��/ C
=
��D E
true
��F J
;
��J K
}
�� 
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

SaveConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
Ready
��A F
)
��F G
;
��G H
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuQueue
��* 8
)
��8 9
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
CurrentPlaylist
��' 6
.
��6 7
Count
��7 <
>
��= >
$num
��? @
)
��@ A
{
�� 
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
QueuePosition
��+ 8
<
��9 :

GlobalData
��; E
.
��E F
Current
��F M
.
��M N
PlaylistPosition
��N ^
||
��_ a

GlobalData
��b l
.
��l m
Current
��m t
.
��t u
QueuePosition��u �
>��� �

GlobalData��� �
.��� �
Current��� �
.��� �
CurrentPlaylist��� �
.��� �
Count��� �
)��� �
{
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
QueuePosition
��+ 8
=
��9 :

GlobalData
��; E
.
��E F
Current
��F M
.
��M N
PlaylistPosition
��N ^
;
��^ _
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
CurrentPlaylist
��' 6
.
��6 7
Insert
��7 =
(
��= >

GlobalData
��> H
.
��H I
Current
��I P
.
��P Q
QueuePosition
��Q ^
+
��_ `
$num
��a b
,
��b c
filePath
��d l
.
��l m
Length
��m s
==
��t v
$num
��w y
?
��z {

GlobalData��| �
.��� �
Current��� �
.��� �
SavedTracks��� �
[��� �
filePath��� �
]��� �
:��� �

GlobalData��� �
.��� �
Current��� �
.��� �
Audios��� �
[��� �
filePath��� �
]��� �
)��� �
;��� �

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
QueuePosition
��' 4
++
��4 6
;
��6 7
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A

SnackQueue
��A K
)
��K L
;
��L M
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� (
.
��( )
Download
��) 1
)
��1 2
{
��  
DownloadProcessing
�� "
.
��" #
Add
��# &
(
��& '
filePath
��' /
,
��/ 0
track
��1 6
.
��6 7
Title
��7 <
,
��< =
$str
��> @
,
��@ A
$str
��B D
)
��D E
;
��E F
Global
�� 
.
�� 
Application
�� "
.
��" #
ShowSnackbar
��# /
(
��/ 0
Localization
��0 <
.
��< =
Ready
��= B
)
��B C
;
��C D
}
�� 
}
�� 	
private
�� 
static
�� 
async
�� 
Task
�� !
PlaylistAction
��" 0
(
��0 1
View
��1 5
sender
��6 <
,
��< =
string
��> D
playlistName
��E Q
,
��Q R
string
��S Y
item
��Z ^
)
��^ _
{
�� 	
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� $
.
��$ %
PlaylistPlay
��% 1
)
��1 2
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
	Playlists
��' 0
[
��0 1
playlistName
��1 =
]
��= >
.
��> ?
Count
��? D
>
��E F
$num
��G H
)
��H I
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @

GlobalData
��@ J
.
��J K
Current
��K R
.
��R S
	Playlists
��S \
[
��\ ]
playlistName
��] i
]
��i j
,
��j k
$num
��l m
,
��m n
true
��o s
,
��s t
true
��u y
)
��y z
;
��z {
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuPlaylist
��* ;
)
��; <
{
�� 
Page
�� 
page
�� 
=
�� 
UI
�� 
.
�� 
Global
�� %
.
��% &
Page
��& *
;
��* +
List
�� 
<
�� 
string
�� 
>
�� 
	positions
�� &
=
��' (
new
��) ,
List
��- 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
)
��: ;
{
�� 
Localization
��  
.
��  !
NewPlaylist
��! ,
}
�� 
;
�� 
foreach
�� 
(
�� 
string
�� 
playlist
��  (
in
��) +

GlobalData
��, 6
.
��6 7
Current
��7 >
.
��> ?
	Playlists
��? H
.
��H I
Keys
��I M
)
��M N
	positions
�� 
.
�� 
Add
�� !
(
��! "
playlist
��" *
)
��* +
;
��+ ,
string
�� 
answer
�� 
=
�� 
await
��  %
page
��& *
.
��* + 
DisplayActionSheet
��+ =
(
��= >
Localization
��> J
.
��J K
ChoosePlaylist
��K Y
,
��Y Z
Localization
��[ g
.
��g h
Cancel
��h n
,
��n o
null
��p t
,
��t u
	positions
��v 
.�� �
ToArray��� �
(��� �
)��� �
)��� �
;��� �
if
�� 
(
�� 
answer
�� 
==
�� 
Localization
�� *
.
��* +
NewPlaylist
��+ 6
)
��6 7
{
�� 
string
�� 
playlist
�� #
=
��$ %
await
��& +
page
��, 0
.
��0 1 
DisplayPromptAsync
��1 C
(
��C D
Localization
��D P
.
��P Q
NewPlaylist
��Q \
,
��\ ]
Localization
��^ j
.
��j k
NewPlaylistHint
��k z
,
��z {
Localization��| �
.��� �
Add��� �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
Playlist��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
Localization��� �
.��� �
NewPlaylist��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 
string
�� 
.
��  
IsNullOrEmpty
��  -
(
��- .
playlist
��. 6
)
��6 7
)
��7 8
{
�� 
foreach
�� 
(
��  !
var
��! $
playlistItem
��% 1
in
��2 4

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
	Playlists
��H Q
[
��Q R
playlistName
��R ^
]
��^ _
)
��_ `
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
ContainsKey
��= H
(
��H I
playlist
��I Q
)
��Q R
)
��R S

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
[
��< =
playlist
��= E
]
��E F
.
��F G
Add
��G J
(
��J K
playlistItem
��K W
)
��W X
;
��X Y
else
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
Add
��= @
(
��@ A
playlist
��A I
,
��I J
new
��K N
List
��O S
<
��S T
string
��T Z
>
��Z [
(
��[ \
)
��\ ]
{
��^ _
playlistItem
��` l
}
��m n
)
��n o
;
��o p
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SnackPlaylist
��E R
)
��R S
;
��S T
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
	Playlists
��, 5
.
��5 6
ContainsKey
��6 A
(
��A B
answer
��B H
)
��H I
)
��I J
{
�� 
foreach
�� 
(
�� 
var
��  
playlistItem
��! -
in
��. 0

GlobalData
��1 ;
.
��; <
Current
��< C
.
��C D
	Playlists
��D M
[
��M N
playlistName
��N Z
]
��Z [
)
��[ \
{
�� 
if
�� 
(
�� 
!
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
	Playlists
��0 9
[
��9 :
answer
��: @
]
��@ A
.
��A B
Contains
��B J
(
��J K
playlistItem
��K W
)
��W X
)
��X Y

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
answer
��9 ?
]
��? @
.
��@ A
Add
��A D
(
��D E
playlistItem
��E Q
)
��Q R
;
��R S
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

SaveConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
SnackPlaylist
��A N
)
��N O
;
��O P
}
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #"
PlaylistsNeedRefresh
��# 7
=
��8 9
true
��: >
;
��> ?
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
TV
�� 
)
�� 
{
�� 
(
�� 
sender
�� 
as
�� 
PlaylistGridItem
�� /
)
��/ 0
.
��0 1
Page
��1 5
.
��5 6
Init
��6 :
(
��: ;
)
��; <
;
��< =
}
�� 
}
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� $
.
��$ %

ChangeName
��% /
)
��/ 0
{
�� 
string
�� 
answer
�� 
=
�� 
await
��  %
Global
��& ,
.
��, -
Page
��- 1
.
��1 2 
DisplayPromptAsync
��2 D
(
��D E
Localization
��E Q
.
��Q R

ChangeName
��R \
,
��\ ]
Localization
��^ j
.
��j k
NewPlaylistHint
��k z
,
��z {
$str��| �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
NewPlaylistHint��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
playlistName��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 
string
�� 
.
�� 
IsNullOrEmpty
�� )
(
��) *
answer
��* 0
)
��0 1
)
��1 2
{
�� 
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
	Playlists
��+ 4
.
��4 5
ContainsKey
��5 @
(
��@ A
answer
��A G
)
��G H
)
��H I
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
PlaylistExists
��E S
)
��S T
;
��T U
else
�� 
{
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
	Playlists
��+ 4
.
��4 5
Add
��5 8
(
��8 9
answer
��9 ?
,
��? @
new
��A D
List
��E I
<
��I J
string
��J P
>
��P Q
(
��Q R

GlobalData
��R \
.
��\ ]
Current
��] d
.
��d e
	Playlists
��e n
[
��n o
playlistName
��o {
]
��{ |
)
��| }
)
��} ~
;
��~ 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
	Playlists
��+ 4
.
��4 5
Remove
��5 ;
(
��; <
playlistName
��< H
)
��H I
;
��I J
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /!
WebToLocalPlaylists
��/ B
.
��B C
ContainsValue
��C P
(
��P Q
playlistName
��Q ]
)
��] ^
)
��^ _
{
�� 
var
�� 
key
��  #
=
��$ %

GlobalData
��& 0
.
��0 1
Current
��1 8
.
��8 9!
WebToLocalPlaylists
��9 L
.
��L M
First
��M R
(
��R S
keyPair
��S Z
=>
��[ ]
keyPair
��^ e
.
��e f
Value
��f k
==
��l n
playlistName
��o {
)
��{ |
.
��| }
Key��} �
;��� �
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3!
WebToLocalPlaylists
��3 F
.
��F G
ContainsKey
��G R
(
��R S
key
��S V
)
��V W
)
��W X

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3!
WebToLocalPlaylists
��3 F
[
��F G
key
��G J
]
��J K
=
��L M
answer
��N T
;
��T U
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8

GlobalData
�� "
.
��" #
Current
��# *
.
��* +"
PlaylistsNeedRefresh
��+ ?
=
��@ A
true
��B F
;
��F G
if
�� 
(
�� 
!
�� 
Global
�� #
.
��# $
TV
��$ &
)
��& '
{
�� 
(
�� 
sender
�� #
as
��$ &
PlaylistGridItem
��' 7
)
��7 8
.
��8 9
Page
��9 =
.
��= >
Init
��> B
(
��B C
)
��C D
;
��D E
}
�� 
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
Ready
��E J
)
��J K
;
��K L
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuDelete
��* 9
)
��9 :
{
�� 
bool
�� 
answer
�� 
=
�� 
await
�� #
Global
��$ *
.
��* +
Page
��+ /
.
��/ 0
DisplayAlert
��0 <
(
��< =
Localization
��= I
.
��I J
Question
��J R
,
��R S
Localization
��T `
.
��` a$
QuestionDeletePlaylist
��a w
+
��x y
$str
��z }
+
��~ 
playlistName��� �
+��� �
$str��� �
,��� �
Localization��� �
.��� �
Yes��� �
,��� �
Localization��� �
.��� �
No��� �
)��� �
;��� �
if
�� 
(
�� 
answer
�� 
)
�� 
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
	Playlists
��' 0
.
��0 1
Remove
��1 7
(
��7 8
playlistName
��8 D
)
��D E
;
��E F
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +!
WebToLocalPlaylists
��+ >
.
��> ?
ContainsValue
��? L
(
��L M
playlistName
��M Y
)
��Y Z
)
��Z [
{
�� 
var
�� 
key
�� 
=
��  !

GlobalData
��" ,
.
��, -
Current
��- 4
.
��4 5!
WebToLocalPlaylists
��5 H
.
��H I
First
��I N
(
��N O
keyPair
��O V
=>
��W Y
keyPair
��Z a
.
��a b
Value
��b g
==
��h j
playlistName
��k w
)
��w x
.
��x y
Key
��y |
;
��| }
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /!
WebToLocalPlaylists
��/ B
.
��B C
ContainsKey
��C N
(
��N O
key
��O R
)
��R S
)
��S T

GlobalData
�� &
.
��& '
Current
��' .
.
��. /!
WebToLocalPlaylists
��/ B
.
��B C
Remove
��C I
(
��I J
key
��J M
)
��M N
;
��N O
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

SaveConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
Ready
��A F
)
��F G
;
��G H

GlobalData
�� 
.
�� 
Current
�� &
.
��& '"
PlaylistsNeedRefresh
��' ;
=
��< =
true
��> B
;
��B C
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
TV
�� !
)
��! "
{
�� 
(
�� 
sender
�� 
as
��  "
PlaylistGridItem
��# 3
)
��3 4
.
��4 5
Page
��5 9
.
��9 :
Init
��: >
(
��> ?
)
��? @
;
��@ A
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuQueue
��* 8
)
��8 9
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
CurrentPlaylist
��' 6
.
��6 7
Count
��7 <
>
��= >
$num
��? @
)
��@ A
{
�� 
foreach
�� 
(
�� 
var
��  
playlistTrack
��! .
in
��/ 1

GlobalData
��2 <
.
��< =
Current
��= D
.
��D E
	Playlists
��E N
[
��N O
playlistName
��O [
]
��[ \
)
��\ ]
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Audios
��/ 5
.
��5 6
ContainsKey
��6 A
(
��A B
playlistTrack
��B O
)
��O P
)
��P Q
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
QueuePosition
��3 @
<
��A B

GlobalData
��C M
.
��M N
Current
��N U
.
��U V
PlaylistPosition
��V f
||
��g i

GlobalData
��j t
.
��t u
Current
��u |
.
��| }
QueuePosition��} �
>��� �

GlobalData��� �
.��� �
Current��� �
.��� �
CurrentPlaylist��� �
.��� �
Count��� �
)��� �
{
�� 

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
QueuePosition
��3 @
=
��A B

GlobalData
��C M
.
��M N
Current
��N U
.
��U V
PlaylistPosition
��V f
;
��f g
}
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
CurrentPlaylist
��/ >
.
��> ?
Insert
��? E
(
��E F

GlobalData
��F P
.
��P Q
Current
��Q X
.
��X Y
QueuePosition
��Y f
+
��g h
$num
��i j
,
��j k

GlobalData
��l v
.
��v w
Current
��w ~
.
��~ 
Audios�� �
[��� �
playlistTrack��� �
]��� �
)��� �
;��� �

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
QueuePosition
��/ <
++
��< >
;
��> ?
}
�� 
}
�� 
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A

SnackQueue
��A K
)
��K L
;
��L M
}
�� 
}
�� 
}
�� 	
private
�� 
static
�� 
async
�� 
Task
�� !
ArtistAction
��" .
(
��. /
View
��/ 3
sender
��4 :
,
��: ;
string
��< B

artistName
��C M
,
��M N
string
��O U
item
��V Z
)
��Z [
{
�� 	
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� $
.
��$ %
PlaylistPlay
��% 1
)
��1 2
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
Artists
��' .
[
��. /

artistName
��/ 9
]
��9 :
.
��: ;
Count
��; @
>
��A B
$num
��C D
)
��D E
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @

GlobalData
��@ J
.
��J K
Current
��K R
.
��R S
Artists
��S Z
[
��Z [

artistName
��[ e
]
��e f
,
��f g
$num
��h i
,
��i j
true
��k o
,
��o p
true
��q u
)
��u v
;
��v w
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuPlaylist
��* ;
)
��; <
{
�� 
Page
�� 
page
�� 
=
�� 
Global
�� "
.
��" #
Page
��# '
;
��' (
List
�� 
<
�� 
string
�� 
>
�� 
	positions
�� &
=
��' (
new
��) ,
List
��- 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
)
��: ;
{
�� 
Localization
��  
.
��  !
NewPlaylist
��! ,
}
�� 
;
�� 
foreach
�� 
(
�� 
string
�� 
playlist
��  (
in
��) +

GlobalData
��, 6
.
��6 7
Current
��7 >
.
��> ?
	Playlists
��? H
.
��H I
Keys
��I M
)
��M N
	positions
�� 
.
�� 
Add
�� !
(
��! "
playlist
��" *
)
��* +
;
��+ ,
string
�� 
answer
�� 
=
�� 
await
��  %
page
��& *
.
��* + 
DisplayActionSheet
��+ =
(
��= >
Localization
��> J
.
��J K
ChoosePlaylist
��K Y
,
��Y Z
Localization
��[ g
.
��g h
Cancel
��h n
,
��n o
null
��p t
,
��t u
	positions
��v 
.�� �
ToArray��� �
(��� �
)��� �
)��� �
;��� �
if
�� 
(
�� 
answer
�� 
==
�� 
Localization
�� *
.
��* +
NewPlaylist
��+ 6
)
��6 7
{
�� 
string
�� 
playlist
�� #
=
��$ %
await
��& +
page
��, 0
.
��0 1 
DisplayPromptAsync
��1 C
(
��C D
Localization
��D P
.
��P Q
NewPlaylist
��Q \
,
��\ ]
Localization
��^ j
.
��j k
NewPlaylistHint
��k z
,
��z {
Localization��| �
.��� �
Add��� �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
Playlist��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
Localization��� �
.��� �
NewPlaylist��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 
string
�� 
.
��  
IsNullOrEmpty
��  -
(
��- .
playlist
��. 6
)
��6 7
)
��7 8
{
�� 
foreach
�� 
(
��  !
var
��! $
playlistItem
��% 1
in
��2 4

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
Artists
��H O
[
��O P

artistName
��P Z
]
��Z [
)
��[ \
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
ContainsKey
��= H
(
��H I
playlist
��I Q
)
��Q R
)
��R S

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
[
��< =
playlist
��= E
]
��E F
.
��F G
Add
��G J
(
��J K
playlistItem
��K W
)
��W X
;
��X Y
else
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
Add
��= @
(
��@ A
playlist
��A I
,
��I J
new
��K N
List
��O S
<
��S T
string
��T Z
>
��Z [
(
��[ \
)
��\ ]
{
��^ _
playlistItem
��` l
}
��m n
)
��n o
;
��o p
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SnackPlaylist
��E R
)
��R S
;
��S T
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
	Playlists
��, 5
.
��5 6
ContainsKey
��6 A
(
��A B
answer
��B H
)
��H I
)
��I J
{
�� 
foreach
�� 
(
�� 
var
��  
playlistItem
��! -
in
��. 0

GlobalData
��1 ;
.
��; <
Current
��< C
.
��C D
Artists
��D K
[
��K L

artistName
��L V
]
��V W
)
��W X
{
�� 
if
�� 
(
�� 
!
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
	Playlists
��0 9
[
��9 :
answer
��: @
]
��@ A
.
��A B
Contains
��B J
(
��J K
playlistItem
��K W
)
��W X
)
��X Y

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
answer
��9 ?
]
��? @
.
��@ A
Add
��A D
(
��D E
playlistItem
��E Q
)
��Q R
;
��R S
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

SaveConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
}
�� 
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
TV
�� 
)
�� 
{
�� 
(
�� 
sender
�� 
as
�� 
ArtistGridItem
�� -
)
��- .
.
��. /
Page
��/ 3
.
��3 4
Init
��4 8
(
��8 9
)
��9 :
;
��: ;
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuQueue
��* 8
)
��8 9
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
CurrentPlaylist
��' 6
.
��6 7
Count
��7 <
>
��= >
$num
��? @
)
��@ A
{
�� 
foreach
�� 
(
�� 
var
��  
artistTrack
��! ,
in
��- /

GlobalData
��0 :
.
��: ;
Current
��; B
.
��B C
Artists
��C J
[
��J K

artistName
��K U
]
��U V
)
��V W
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
Audios
��/ 5
.
��5 6
ContainsKey
��6 A
(
��A B
artistTrack
��B M
)
��M N
)
��N O
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
QueuePosition
��3 @
<
��A B

GlobalData
��C M
.
��M N
Current
��N U
.
��U V
PlaylistPosition
��V f
||
��g i

GlobalData
��j t
.
��t u
Current
��u |
.
��| }
QueuePosition��} �
>��� �

GlobalData��� �
.��� �
Current��� �
.��� �
CurrentPlaylist��� �
.��� �
Count��� �
)��� �
{
�� 

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
QueuePosition
��3 @
=
��A B

GlobalData
��C M
.
��M N
Current
��N U
.
��U V
PlaylistPosition
��V f
;
��f g
}
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
CurrentPlaylist
��/ >
.
��> ?
Insert
��? E
(
��E F

GlobalData
��F P
.
��P Q
Current
��Q X
.
��X Y
QueuePosition
��Y f
+
��g h
$num
��i j
,
��j k

GlobalData
��l v
.
��v w
Current
��w ~
.
��~ 
Audios�� �
[��� �
artistTrack��� �
]��� �
)��� �
;��� �

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
QueuePosition
��/ <
++
��< >
;
��> ?
}
�� 
}
�� 
}
�� 
}
�� 
}
�� 	
private
�� 
static
�� 
async
�� 
Task
�� ! 
SearchResultAction
��" 4
(
��4 5
View
��5 9
sender
��: @
,
��@ A
string
��B H
tag
��I L
,
��L M
string
��N T
item
��U Y
)
��Y Z
{
�� 	
Page
�� 
page
�� 
=
�� 
Global
�� 
.
�� 
Page
�� #
;
��# $
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� $
.
��$ %
Download
��% -
)
��- .
{
�� 
string
�� 
[
�� 
]
�� 
elems
�� 
=
��  
tag
��! $
.
��$ %
Split
��% *
(
��* +

GlobalData
��+ 5
.
��5 6
	SEPARATOR
��6 ?
)
��? @
;
��@ A
YoutubeClient
�� 
client
�� $
=
��% &
new
��' *
YoutubeClient
��+ 8
(
��8 9
)
��9 :
;
��: ;
string
�� 

playlistId
�� !
=
��" #
$str
��$ &
;
��& '
string
�� 
playlistName
�� #
=
��$ %
$str
��& (
;
��( )
var
�� 
urlType
�� 
=
�� 
SearchProcessing
�� .
.
��. /
	CheckLink
��/ 8
(
��8 9
elems
��9 >
[
��> ?
$num
��? @
]
��@ A
)
��A B
;
��B C
if
�� 
(
�� 
urlType
�� 
.
�� 
ContainsKey
�� '
(
��' (
SearchProcessing
��( 8
.
��8 9
Query
��9 >
.
��> ?
Playlist
��? G
)
��G H
)
��H I
{
�� 
if
�� 
(
�� 
urlType
�� 
.
��  
ContainsKey
��  +
(
��+ ,
SearchProcessing
��, <
.
��< =
Query
��= B
.
��B C
Video
��C H
)
��H I
)
��I J
{
�� 
if
�� 
(
�� 
await
�� !
Global
��" (
.
��( )
Page
��) -
.
��- .
DisplayAlert
��. :
(
��: ;
Localization
��; G
.
��G H
Question
��H P
,
��P Q
Localization
��R ^
.
��^ _
PlaylistOrTrack
��_ n
,
��n o
Localization
��p |
.
��| }
Track��} �
,��� �
Localization��� �
.��� �
Playlist��� �
)��� �
)��� �
{
�� 

playlistId
�� &
=
��' (
$str
��) +
;
��+ ,
}
�� 
else
�� 
{
�� 

playlistId
�� &
=
��' (
urlType
��) 0
[
��0 1
SearchProcessing
��1 A
.
��A B
Query
��B G
.
��G H
Playlist
��H P
]
��P Q
;
��Q R
if
�� 
(
��  
await
��  %
Global
��& ,
.
��, -
Page
��- 1
.
��1 2
DisplayAlert
��2 >
(
��> ?
Localization
��? K
.
��K L
Question
��L T
,
��T U
Localization
��V b
.
��b c
PlaylistDownload
��c s
,
��s t
Localization��u �
.��� �
Yes��� �
,��� �
Localization��� �
.��� �
No��� �
)��� �
)��� �
{
�� 
var
��  #
playlist
��$ ,
=
��- .
await
��/ 4
client
��5 ;
.
��; <
	Playlists
��< E
.
��E F
GetAsync
��F N
(
��N O
urlType
��O V
[
��V W
SearchProcessing
��W g
.
��g h
Query
��h m
.
��m n
Playlist
��n v
]
��v w
)
��w x
;
��x y
string
��  &
newPlaylistName
��' 6
=
��7 8
await
��9 >
Global
��? E
.
��E F
Page
��F J
.
��J K 
DisplayPromptAsync
��K ]
(
��] ^
Localization
��^ j
.
��j k
NewPlaylist
��k v
,
��v w
Localization��x �
.��� �
NewPlaylistHint��� �
,��� �
$str��� �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
NewPlaylist��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
playlist��� �
.��� �
Title��� �
)��� �
;��� �
playlistName
��  ,
=
��- .
string
��/ 5
.
��5 6 
IsNullOrWhiteSpace
��6 H
(
��H I
newPlaylistName
��I X
)
��X Y
?
��Z [
$str
��\ ^
:
��_ `
newPlaylistName
��a p
;
��p q
}
�� 
}
�� 
}
�� 
}
�� 
if
�� 
(
�� 

playlistId
�� 
==
�� !
$str
��" $
)
��$ %
{
��  
DownloadProcessing
�� &
.
��& '
Add
��' *
(
��* +
$str
��+ -
,
��- .
elems
��/ 4
[
��4 5
$num
��5 6
]
��6 7
,
��7 8
elems
��9 >
[
��> ?
$num
��? @
]
��@ A
,
��A B
$str
��C E
)
��E F
;
��F G
}
�� 
else
�� 
{
��  
DownloadProcessing
�� &
.
��& '
AddRange
��' /
(
��/ 0
await
��0 5
client
��6 <
.
��< =
	Playlists
��= F
.
��F G
GetVideosAsync
��G U
(
��U V

playlistId
��V `
)
��` a
,
��a b
playlistName
��c o
,
��o p

playlistId
��q {
)
��{ |
;
��| }
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
item
�� 
==
�� 
Localization
�� )
.
��) *
TrackMenuPlaylist
��* ;
)
��; <
{
�� 
string
�� 
[
�� 
]
�� 
elems
�� 
=
��  
tag
��! $
.
��$ %
Split
��% *
(
��* +

GlobalData
��+ 5
.
��5 6
	SEPARATOR
��6 ?
)
��? @
;
��@ A
YoutubeClient
�� 
client
�� $
=
��% &
new
��' *
YoutubeClient
��+ 8
(
��8 9
)
��9 :
;
��: ;
var
�� 
urlType
�� 
=
�� 
SearchProcessing
�� .
.
��. /
	CheckLink
��/ 8
(
��8 9
elems
��9 >
[
��> ?
$num
��? @
]
��@ A
)
��A B
;
��B C
if
�� 
(
�� 
urlType
�� 
.
�� 
ContainsKey
�� '
(
��' (
SearchProcessing
��( 8
.
��8 9
Query
��9 >
.
��> ?
Video
��? D
)
��D E
)
��E F
{
�� 
List
�� 
<
�� 
string
�� 
>
��  
	positions
��! *
=
��+ ,
new
��- 0
List
��1 5
<
��5 6
string
��6 <
>
��< =
(
��= >
)
��> ?
{
�� 
Localization
�� $
.
��$ %
NewPlaylist
��% 0
}
�� 
;
�� 
foreach
�� 
(
�� 
string
�� #
playlist
��$ ,
in
��- /

GlobalData
��0 :
.
��: ;
Current
��; B
.
��B C
	Playlists
��C L
.
��L M
Keys
��M Q
)
��Q R
	positions
�� !
.
��! "
Add
��" %
(
��% &
playlist
��& .
)
��. /
;
��/ 0
string
�� 
answer
�� !
=
��" #
await
��$ )
page
��* .
.
��. / 
DisplayActionSheet
��/ A
(
��A B
Localization
��B N
.
��N O
ChoosePlaylist
��O ]
,
��] ^
Localization
��_ k
.
��k l
Cancel
��l r
,
��r s
null
��t x
,
��x y
	positions��z �
.��� �
ToArray��� �
(��� �
)��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
SavedTracks
��+ 6
.
��6 7
ContainsKey
��7 B
(
��B C
urlType
��C J
[
��J K
SearchProcessing
��K [
.
��[ \
Query
��\ a
.
��a b
Video
��b g
]
��g h
)
��h i
)
��i j
{
�� 
var
�� 
video
�� !
=
��" #
await
��$ )
client
��* 0
.
��0 1
Videos
��1 7
.
��7 8
GetAsync
��8 @
(
��@ A
urlType
��A H
[
��H I
SearchProcessing
��I Y
.
��Y Z
Query
��Z _
.
��_ `
Video
��` e
]
��e f
)
��f g
;
��g h
var
�� 
mediaSource
�� '
=
��( )
new
��* -
Core
��. 2
.
��2 3
Media
��3 8
.
��8 9
MediaSource
��9 D
(
��D E
)
��E F
{
�� 
Artist
�� "
=
��# $
video
��% *
.
��* +
Author
��+ 1
,
��1 2
Duration
�� $
=
��% &
video
��' ,
.
��, -
Duration
��- 5
,
��5 6
FilePath
�� $
=
��% &
video
��' ,
.
��, -
Id
��- /
,
��/ 0
Title
�� !
=
��" #
video
��$ )
.
��) *
Title
��* /
,
��/ 0
Type
��  
=
��! "
Core
��# '
.
��' (
Media
��( -
.
��- .
MediaSource
��. 9
.
��9 :

SourceType
��: D
.
��D E
Web
��E H
}
�� 
;
�� 
try
�� 
{
�� 
using
�� !
	WebClient
��" +
	webClient
��, 5
=
��6 7
new
��8 ;
	WebClient
��< E
(
��E F
)
��F G
;
��G H
byte
��  
[
��  !
]
��! "
	thumbData
��# ,
=
��- .
	webClient
��/ 8
.
��8 9
DownloadData
��9 E
(
��E F
video
��F K
.
��K L

Thumbnails
��L V
.
��V W
MediumResUrl
��W c
)
��c d
;
��d e
mediaSource
�� '
.
��' (
Image
��( -
=
��. /
	thumbData
��0 9
;
��9 :
}
�� 
catch
�� 
{
�� 
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
SavedTracks
��+ 6
.
��6 7
Add
��7 :
(
��: ;
urlType
��; B
[
��B C
SearchProcessing
��C S
.
��S T
Query
��T Y
.
��Y Z
Video
��Z _
]
��_ `
,
��` a
mediaSource
��b m
)
��m n
;
��n o

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
SaveSavedTracks
��+ :
(
��: ;
)
��; <
;
��< =
}
�� 
if
�� 
(
�� 
answer
�� 
==
�� !
Localization
��" .
.
��. /
NewPlaylist
��/ :
)
��: ;
{
�� 
string
�� 
playlist
�� '
=
��( )
await
��* /
page
��0 4
.
��4 5 
DisplayPromptAsync
��5 G
(
��G H
Localization
��H T
.
��T U
NewPlaylist
��U `
,
��` a
Localization
��b n
.
��n o
NewPlaylistHint
��o ~
,
��~ 
Localization��� �
.��� �
Add��� �
,��� �
Localization��� �
.��� �
Cancel��� �
,��� �
Localization��� �
.��� �
Playlist��� �
,��� �
-��� �
$num��� �
,��� �
null��� �
,��� �
Localization��� �
.��� �
NewPlaylist��� �
)��� �
;��� �
if
�� 
(
�� 
!
�� 
string
�� #
.
��# $
IsNullOrEmpty
��$ 1
(
��1 2
playlist
��2 :
)
��: ;
)
��; <
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
ContainsKey
��= H
(
��H I
playlist
��I Q
)
��Q R
)
��R S

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
[
��< =
playlist
��= E
]
��E F
.
��F G
Add
��G J
(
��J K
urlType
��K R
[
��R S
SearchProcessing
��S c
.
��c d
Query
��d i
.
��i j
Video
��j o
]
��o p
)
��p q
;
��q r
else
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
	Playlists
��3 <
.
��< =
Add
��= @
(
��@ A
playlist
��A I
,
��I J
new
��K N
List
��O S
<
��S T
string
��T Z
>
��Z [
(
��[ \
)
��\ ]
{
��^ _
urlType
��` g
[
��g h
SearchProcessing
��h x
.
��x y
Query
��y ~
.
��~ 
Video�� �
]��� �
}��� �
)��� �
;��� �

GlobalData
�� &
.
��& '
Current
��' .
.
��. /"
PlaylistsNeedRefresh
��/ C
=
��D E
true
��F J
;
��J K

GlobalData
�� &
.
��& '
Current
��' .
.
��. /

SaveConfig
��/ 9
(
��9 :
)
��: ;
;
��; <
Global
�� "
.
��" #
Application
��# .
.
��. /
ShowSnackbar
��/ ;
(
��; <
Localization
��< H
.
��H I
SnackPlaylist
��I V
)
��V W
;
��W X
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
	Playlists
��0 9
.
��9 :
ContainsKey
��: E
(
��E F
answer
��F L
)
��L M
)
��M N
{
�� 
if
�� 
(
�� 
!
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
	Playlists
��0 9
[
��9 :
answer
��: @
]
��@ A
.
��A B
Contains
��B J
(
��J K
urlType
��K R
[
��R S
SearchProcessing
��S c
.
��c d
Query
��d i
.
��i j
Video
��j o
]
��o p
)
��p q
)
��q r

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
answer
��9 ?
]
��? @
.
��@ A
Add
��A D
(
��D E
urlType
��E L
[
��L M
SearchProcessing
��M ]
.
��] ^
Query
��^ c
.
��c d
Video
��d i
]
��i j
)
��j k
;
��k l

GlobalData
�� "
.
��" #
Current
��# *
.
��* +"
PlaylistsNeedRefresh
��+ ?
=
��@ A
true
��B F
;
��F G

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SnackPlaylist
��E R
)
��R S
;
��S T
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
?D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\CoreMessenger.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

class 
CoreMessenger 
:  
ICoreMessage! -
{		 
public

 
void

 
	ShowError

 
(

 
string

 $
message

% ,
)

, -
{ 	
ShowMessage 
( 
message 
)  
;  !
} 	
public 
void 
ShowMessage 
(  
string  &
message' .
). /
{ 	
Device 
. #
BeginInvokeOnMainThread *
(* +
async+ 0
(1 2
)2 3
=>4 6
{ 
await 
Global 
. 
Page !
.! "
DisplayAlert" .
(. /
Localization/ ;
.; <
Warning< C
,C D
messageE L
,L M
$strN R
)R S
;S T
} 
) 
; 
} 	
public 
void 
ShowSnackbar  
(  !
string! '
message( /
)/ 0
{ 	
Global 
. 
Application 
. 
ShowSnackbar +
(+ ,
message, 3
)3 4
;4 5
} 	
} 
} �
>D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\IApplication.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

	interface 
IApplication !
{ 
string 

GetVersion 
( 
) 
; 
bool 
HasInternet 
( 
) 
; 
void 
ShowSnackbar 
( 
string  
message! (
)( )
;) *
void 
AddFolderToScan 
( 
) 
; 
}		 
}

 �
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\IContextMenuBuilder.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

	interface 
IContextMenuBuilder (
{		 
void

 
BuildForTrack

 
(

 
View

 
sender

  &
,

& '
string

( .
	modelInfo

/ 8
,

8 9
string

: @
filePath

A I
,

I J
string

K Q
playlistName

R ^
,

^ _
List

` d
<

d e
string

e k
>

k l
elements

m u
,

u v
Func

w {
<

{ |
string	

| �
,


� �
string


� �
,


� �
string


� �
,


� �
Task


� �
>


� �
action


� �
)


� �
;


� �
void 
BuildForSyncList 
( 
View "
sender# )
,) *
string+ 1
	modelInfo2 ;
,; <
List= A
<A B
stringB H
>H I
elementsJ R
,R S
ActionT Z
<Z [
string[ a
>a b
actionc i
)i j
;j k
void 
BuildForPlaylist 
( 
View "
sender# )
,) *
string+ 1
playlistName2 >
,> ?
List@ D
<D E
stringE K
>K L
elementsM U
,U V
FuncW [
<[ \
View\ `
,` a
stringb h
,h i
stringj p
,p q
Taskr v
>v w
actionx ~
)~ 
;	 �
void 
BuildForArtist 
( 
View  
sender! '
,' (
string) /

artistName0 :
,: ;
List< @
<@ A
stringA G
>G H
elementsI Q
,Q R
FuncS W
<W X
ViewX \
,\ ]
string^ d
,d e
stringf l
,l m
Taskn r
>r s
actiont z
)z {
;{ |
void  
BuildForSearchResult !
(! "
View" &
sender' -
,- .
string/ 5
	modelInfo6 ?
,? @
ListA E
<E F
stringF L
>L M
elementsN V
,V W
FuncX \
<\ ]
View] a
,a b
stringc i
,i j
stringk q
,q r
Tasks w
>w x
actiony 
)	 �
;
� �
} 
} �
BD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\IImageProcessing.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

	interface 
IImageProcessing %
{		 
ImageSource

 
Blur

 
(

 
byte

 
[

 
]

 
source

  &
)

& '
;

' (
ImageSource 
Blur 
( 
ImageSource $
source% +
)+ ,
;, -
} 
} �
=D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\IPermission.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{ 
public 

	interface 
IPermission  
{ 
bool 
IsValid 
( 
) 
; 
void 
Request 
( 
) 
; 
} 
} �K
CD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Logic\NavigationWrapper.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Logic !
{		 
public

 

class

 
NavigationWrapper

 "
{ 
private 
INavigation 

Navigation &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
IReadOnlyList 
< 
Page !
>! "
NavigationStack# 2
{ 	
get 
=> 

Navigation 
. 
NavigationStack -
;- .
} 	
public 
IReadOnlyList 
< 
Page !
>! "

ModalStack# -
{ 	
get 
=> 

Navigation 
. 

ModalStack (
;( )
} 	
public 
NavigationWrapper  
(  !
INavigation! ,
nav- 0
)0 1
{ 	

Navigation 
= 
nav 
; 
} 	
public 
async 
Task 
	PushAsync #
(# $
Page$ (
page) -
)- .
{   	
if!! 
(!! 

Navigation!! 
.!! 
NavigationStack!! *
.!!* +
Count!!+ 0
>!!1 2
$num!!3 4
)!!4 5
{"" 
if## 
(## 

Navigation## 
.## 
NavigationStack## .
.##. /
Last##/ 3
(##3 4
)##4 5
is##6 8 
INavigationContainer##9 M
	container##N W
)##W X
{$$ 
if%% 
(%% 
!%% 
	container%% "
.%%" #
	IsBlocked%%# ,
(%%, -
)%%- .
)%%. /
{&& 
	container'' !
.''! "
Block''" '
(''' (
)''( )
;'') *
await(( 

Navigation(( (
?((( )
.(() *
	PushAsync((* 3
(((3 4
page((4 8
)((8 9
;((9 :
})) 
}** 
}++ 
else,, 
await-- 

Navigation--  
?--  !
.--! "
	PushAsync--" +
(--+ ,
page--, 0
)--0 1
;--1 2
}.. 	
public00 
async00 
Task00 
PushModalAsync00 (
(00( )
Page00) -
page00. 2
)002 3
{11 	
bool22 

navBlocked22 
=22 
false22 #
;22# $
bool33 
modalBlocked33 
=33 
false33  %
;33% &
if44 
(44 

Navigation44 
.44 
NavigationStack44 *
.44* +
Count44+ 0
>441 2
$num443 4
)444 5
{55 
if66 
(66 

Navigation66 
.66 
NavigationStack66 .
.66. /
Last66/ 3
(663 4
)664 5
is666 8 
INavigationContainer669 M
	container66N W
)66W X
{77 
	container88 
.88 
Block88 #
(88# $
)88$ %
;88% &

navBlocked99 
=99  
true99! %
;99% &
}:: 
};; 
else<< 

navBlocked== 
=== 
true== !
;==! "
if?? 
(?? 

Navigation?? 
.?? 

ModalStack?? %
.??% &
Count??& +
>??, -
$num??. /
)??/ 0
{@@ 
ifAA 
(AA 

NavigationAA 
.AA 

ModalStackAA )
.AA) *
LastAA* .
(AA. /
)AA/ 0
isAA1 3 
INavigationContainerAA4 H
	containerAAI R
)AAR S
{BB 
	containerCC 
.CC 
BlockCC #
(CC# $
)CC$ %
;CC% &
modalBlockedDD  
=DD! "
trueDD# '
;DD' (
varEE 
modalEE 
=EE 

NavigationEE  *
.EE* +

ModalStackEE+ 5
.EE5 6
LastEE6 :
(EE: ;
)EE; <
;EE< =
varFF 
modal1FF 
=FF  
pageFF! %
;FF% &
ifHH 
(HH 
modalHH 
.HH 
GetTypeHH %
(HH% &
)HH& '
!=HH( *
modal1HH+ 1
.HH1 2
GetTypeHH2 9
(HH9 :
)HH: ;
)HH; <
modalBlockedII $
=II% &
falseII' ,
;II, -
ifKK 
(KK 
modalKK 
isKK 
ViewsKK  %
.KK% &
TVKK& (
.KK( )
	ModalPageKK) 2
modalTVPage1KK3 ?
&&KK@ B
modal1KKC I
isKKJ L
ViewsKKM R
.KKR S
TVKKS U
.KKU V
	ModalPageKKV _
modalTVPage2KK` l
)KKl m
{LL 
ifMM 
(MM 
modalTVPage1MM (
.MM( )
GetContentTypeMM) 7
(MM7 8
)MM8 9
!=MM: <
modalTVPage2MM= I
.MMI J
GetContentTypeMMJ X
(MMX Y
)MMY Z
)MMZ [
modalBlockedNN (
=NN) *
falseNN+ 0
;NN0 1
}OO 
ifQQ 
(QQ 
modalQQ 
isQQ  
	ModalPageQQ! *

modalPage1QQ+ 5
&&QQ6 8
modal1QQ9 ?
isQQ@ B
	ModalPageQQC L

modalPage2QQM W
)QQW X
{RR 
ifSS 
(SS 

modalPage1SS &
.SS& '
GetContentTypeSS' 5
(SS5 6
)SS6 7
!=SS8 :

modalPage2SS; E
.SSE F
GetContentTypeSSF T
(SST U
)SSU V
)SSV W
modalBlockedTT (
=TT) *
falseTT+ 0
;TT0 1
}UU 
}VV 
}WW 
ifYY 
(YY 
!YY 

navBlockedYY 
||YY 
!YY  
modalBlockedYY  ,
)YY, -
{ZZ 
await[[ 

Navigation[[  
?[[  !
.[[! "
PushModalAsync[[" 0
([[0 1
page[[1 5
)[[5 6
;[[6 7
}\\ 
}^^ 	
public`` 
async`` 
Task`` 
PopAsync`` "
(``" #
)``# $
{aa 	
awaitbb 

Navigationbb 
?bb 
.bb 
PopAsyncbb &
(bb& '
)bb' (
;bb( )
ifcc 
(cc 

Navigationcc 
.cc 
NavigationStackcc *
.cc* +
Countcc+ 0
>cc1 2
$numcc3 4
)cc4 5
{dd 
ifee 
(ee 

Navigationee 
.ee 
NavigationStackee .
.ee. /
Lastee/ 3
(ee3 4
)ee4 5
isee6 8 
INavigationContaineree9 M
	containereeN W
)eeW X
	containerff 
.ff 
Unblockff %
(ff% &
)ff& '
;ff' (
}gg 
}hh 	
publicii 
asyncii 
Taskii 
PopModalAsyncii '
(ii' (
)ii( )
{jj 	
trykk 
{ll 
awaitmm 

Navigationmm  
?mm  !
.mm! "
PopModalAsyncmm" /
(mm/ 0
)mm0 1
;mm1 2
}nn 
catchoo 
{pp 
}rr 
ifss 
(ss 

Navigationss 
.ss 
NavigationStackss *
.ss* +
Countss+ 0
>ss1 2
$numss3 4
)ss4 5
{tt 
ifuu 
(uu 

Navigationuu 
.uu 
NavigationStackuu .
.uu. /
Lastuu/ 3
(uu3 4
)uu4 5
isuu6 8 
INavigationContaineruu9 M
	containeruuN W
)uuW X
	containervv 
.vv 
Unblockvv %
(vv% &
)vv& '
;vv' (
}ww 
ifyy 
(yy 

Navigationyy 
.yy 

ModalStackyy %
.yy% &
Countyy& +
>yy, -
$numyy. /
)yy/ 0
{zz 
if{{ 
({{ 

Navigation{{ 
.{{ 

ModalStack{{ )
.{{) *
Last{{* .
({{. /
){{/ 0
is{{1 3 
INavigationContainer{{4 H
	container{{I R
){{R S
	container|| 
.|| 
Unblock|| %
(||% &
)||& '
;||' (
}}} 
}~~ 	
public 
async 
void 
Pop 
( 
) 
{
�� 	
if
�� 
(
�� 

Navigation
�� 
.
�� 

ModalStack
�� %
.
��% &
Count
��& +
>
��, -
$num
��. /
)
��/ 0
await
�� 
PopModalAsync
�� #
(
��# $
)
��$ %
;
��% &
else
�� 
{
�� 
if
�� 
(
�� 

Navigation
�� 
.
�� 
NavigationStack
�� .
.
��. /
Count
��/ 4
>
��5 6
$num
��7 8
)
��8 9
await
�� 
PopAsync
�� "
(
��" #
)
��# $
;
��$ %
}
�� 
}
�� 	
}
�� 
}�� �
9D:\Projekty\CS\Newtone\Newtone.Mobile.UI\MainPage.xaml.cs
	namespace		 	$
XamarinMobileProjectTest		
 "
{

 
public 

partial 
class 
MainPage !
:" #
ContentPage$ /
{ 
public 
MainPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �)
>D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\ArtistModel.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Models

 "
{ 
public 

class 
ArtistModel 
: 
NListViewItem ,
{ 
private 
string 
name 
; 
private 
int 

trackCount 
; 
private 
ImageSource 
image !
;! "
public 
Xamarin 
. 
Forms 
. 
View !
View" &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
Name 
{ 	
get 
=> 
name 
; 
set 
{ 
name 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
OnPropertyChanged !
(! "
(" #
)# $
=>% '
	TrackElem( 1
)1 2
;2 3
} 
} 	
public 
int 

TrackCount 
{   	
get!! 
=>!! 

trackCount!! 
;!! 
set"" 
{## 

trackCount$$ 
=$$ 
value$$ "
;$$" #
OnPropertyChanged%% !
(%%! "
)%%" #
;%%# $
OnPropertyChanged&& !
(&&! "
(&&" #
)&&# $
=>&&% '
	TrackElem&&( 1
)&&1 2
;&&2 3
}'' 
}(( 	
public)) 
string)) 
	TrackElem)) 
{** 	
get++ 
{,, 
return-- 
string-- 
.-- 
Concat-- $
(--$ %
Localization--% 1
.--1 2
Tracks--2 8
,--8 9
$str--: >
,--> ?

GlobalData--@ J
.--J K
Current--K R
.--R S
Artists--S Z
[--Z [
name--[ _
]--_ `
.--` a
Count--a f
)--f g
;--g h
}.. 
}// 	
public00 
ImageSource00 
Image00  
{11 	
get22 
=>22 
image22 
;22 
set33 
{44 
image55 
=55 
value55 
;55 
OnPropertyChanged66 !
(66! "
)66" #
;66# $
}77 
}88 	
private;; 
ICommand;; 
longPressedCommand;; +
;;;+ ,
public<< 
ICommand<< 
LongPressedCommand<< *
{== 	
get>> 
{?? 
if@@ 
(@@ 
longPressedCommand@@ &
==@@' )
null@@* .
)@@. /
longPressedCommandAA &
=AA' (
newAA) ,
ActionCommandAA- :
(AA: ;
	parameterAA; D
=>AAE G
{BB 
ContextMenuBuilderCC *
.CC* +
BuildForArtistCC+ 9
(CC9 :
ViewCC: >
,CC> ?
NameCC@ D
)CCD E
;CCE F
}DD 
)DD 
;DD 
returnFF 
longPressedCommandFF )
;FF) *
}GG 
}HH 	
privateJJ 
ICommandJJ 
pressedCommandJJ '
;JJ' (
publicKK 
ICommandKK 
PressedCommandKK &
{LL 	
getMM 
{NN 
ifOO 
(OO 
pressedCommandOO "
==OO# %
nullOO& *
)OO* +
pressedCommandPP "
=PP# $
newPP% (
ActionCommandPP) 6
(PP6 7
asyncPP7 <
(PP= >
	parameterPP> G
)PPG H
=>PPI K
{QQ 
awaitRR 
GlobalRR $
.RR$ %
NavigationInstanceRR% 7
.RR7 8
PushModalAsyncRR8 F
(RRF G
newRRG J
	ModalPageRRK T
(RRT U
newRRU X
CurrentTracksPageRRY j
(RRj k

GlobalDataRRk u
.RRu v
CurrentRRv }
.RR} ~
Artists	RR~ �
[
RR� �
Name
RR� �
]
RR� �
,
RR� �
$str
RR� �
)
RR� �
,
RR� �
Name
RR� �
)
RR� �
)
RR� �
;
RR� �
}SS 
)SS 
;SS 
returnTT 
pressedCommandTT %
;TT% &
}UU 
}VV 	
publicYY 
overrideYY 
voidYY 
FocusActionYY (
(YY( )
)YY) *
{ZZ 	
PressedCommand[[ 
.[[ 
Execute[[ "
([[" #
null[[# '
)[[' (
;[[( )
}\\ 	
public^^ 
override^^ 
void^^ 
LongFocusAction^^ ,
(^^, -
)^^- .
{__ 	
LongPressedCommand`` 
.`` 
Execute`` &
(``& '
null``' +
)``+ ,
;``, -
}aa 	
}cc 
}dd �
@D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\DownloadModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Models "
{ 
public 

class 
DownloadModel 
:  
Newtone! (
.( )
Core) -
.- .
Models. 4
.4 5
DownloadModel5 B
{ 
private 
string  
progressStringMobile +
;+ ,
public		 
string		  
ProgressStringMobile		 *
{

 	
get 
{ 
return  
progressStringMobile +
;+ ,
} 
set 
{  
progressStringMobile $
=% &
value' ,
;, -
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
DownloadModel 
( 
Newtone $
.$ %
Core% )
.) *
Models* 0
.0 1
DownloadModel1 >
model? D
)D E
{ 	
this 
. 
Id 
= 
model 
. 
Id 
; 
this 
. 
PlaylistName 
= 
model  %
.% &
PlaylistName& 2
;2 3
this 
. 
Progress 
= 
model !
.! "
Progress" *
;* +
this 
.  
ProgressStringMobile %
=& '
model( -
.- .
ProgressString. <
;< =
this 
. 
Title 
= 
model 
. 
Title $
;$ %
} 	
}   
}!! �2
@D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\PlaylistModel.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Models

 "
{ 
public 

class 
PlaylistModel 
:  
NListViewItem! .
{ 
private 
ImageSource 
image !
;! "
private 
string 
name 
; 
private 
int 

trackCount 
; 
private 
string 
webUrl 
; 
public 
ImageSource 
Image  
{ 	
get 
=> 
image 
; 
set 
{ 
image 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
string 
Name 
{   	
get!! 
=>!! 
name!! 
;!! 
set"" 
{## 
name$$ 
=$$ 
value$$ 
;$$ 
OnPropertyChanged%% !
(%%! "
)%%" #
;%%# $
OnPropertyChanged&& !
(&&! "
(&&" #
)&&# $
=>&&% '
	TrackElem&&( 1
)&&1 2
;&&2 3
}'' 
}(( 	
public)) 
int)) 

TrackCount)) 
{** 	
get++ 
=>++ 

trackCount++ 
;++ 
set,, 
{-- 

trackCount.. 
=.. 
value.. "
;.." #
OnPropertyChanged// !
(//! "
)//" #
;//# $
OnPropertyChanged00 !
(00! "
(00" #
)00# $
=>00% '
	TrackElem00( 1
)001 2
;002 3
}11 
}22 	
public33 
string33 
	TrackElem33 
{44 	
get55 
{66 
return77 
string77 
.77 
Concat77 $
(77$ %
Localization77% 1
.771 2
Tracks772 8
,778 9
$str77: >
,77> ?

GlobalData77@ J
.77J K
Current77K R
.77R S
	Playlists77S \
[77\ ]
name77] a
]77a b
.77b c
Count77c h
)77h i
;77i j
}88 
}99 	
public:: 
string:: 
WebUrl:: 
{;; 	
get<< 
=><< 
webUrl<< 
;<< 
set== 
{>> 
webUrl?? 
=?? 
value?? 
;?? 
OnPropertyChanged@@ !
(@@! "
)@@" #
;@@# $
}AA 
}BB 	
publicDD 
ViewDD 
ViewDD 
{DD 
getDD 
;DD 
setDD  #
;DD# $
}DD% &
privateGG 
ICommandGG 
longPressedCommandGG +
;GG+ ,
publicHH 
ICommandHH 
LongPressedCommandHH *
{II 	
getJJ 
{KK 
ifLL 
(LL 
longPressedCommandLL &
==LL' )
nullLL* .
)LL. /
longPressedCommandMM &
=MM' (
newMM) ,
ActionCommandMM- :
(MM: ;
	parameterMM; D
=>MME G
{NN 
ifOO 
(OO 
stringOO "
.OO" #
IsNullOrEmptyOO# 0
(OO0 1
WebUrlOO1 7
)OO7 8
)OO8 9
ContextMenuBuilderPP .
.PP. /
BuildForPlaylistPP/ ?
(PP? @
ViewPP@ D
,PPD E
NamePPF J
)PPJ K
;PPK L
}QQ 
)QQ 
;QQ 
returnSS 
longPressedCommandSS )
;SS) *
}TT 
}UU 	
privateWW 
ICommandWW 
pressedCommandWW '
;WW' (
publicXX 
ICommandXX 
PressedCommandXX &
{YY 	
getZZ 
{[[ 
if\\ 
(\\ 
pressedCommand\\ "
==\\# %
null\\& *
)\\* +
pressedCommand]] "
=]]# $
new]]% (
ActionCommand]]) 6
(]]6 7
async]]7 <
(]]= >
	parameter]]> G
)]]G H
=>]]I K
{^^ 
if__ 
(__ 
string__ "
.__" #
IsNullOrEmpty__# 0
(__0 1
WebUrl__1 7
)__7 8
)__8 9
{`` 
awaitaa !
Globalaa" (
.aa( )
NavigationInstanceaa) ;
.aa; <
PushModalAsyncaa< J
(aaJ K
newaaK N
	ModalPageaaO X
(aaX Y
newaaY \
CurrentTracksPageaa] n
(aan o

GlobalDataaao y
.aay z
Current	aaz �
.
aa� �
	Playlists
aa� �
[
aa� �
Name
aa� �
]
aa� �
,
aa� �
Name
aa� �
)
aa� �
,
aa� �
Name
aa� �
)
aa� �
)
aa� �
;
aa� �
}bb 
elsecc 
{dd 
awaitee !
Globalee" (
.ee( )
NavigationInstanceee) ;
.ee; <
PushModalAsyncee< J
(eeJ K
neweeK N
	ModalPageeeO X
(eeX Y
neweeY \
SearchResultPageee] m
(eem n
WebUrleen t
)eet u
,eeu v
Nameeew {
)ee{ |
)ee| }
;ee} ~
}ff 
}gg 
)gg 
;gg 
returnhh 
pressedCommandhh %
;hh% &
}ii 
}jj 	
publicmm 
overridemm 
voidmm 
FocusActionmm (
(mm( )
)mm) *
{nn 	
PressedCommandoo 
.oo 
Executeoo "
(oo" #
nulloo# '
)oo' (
;oo( )
}pp 	
publicrr 
overriderr 
voidrr 
LongFocusActionrr ,
(rr, -
)rr- .
{ss 	
LongPressedCommandtt 
.tt 
Executett &
(tt& '
nulltt' +
)tt+ ,
;tt, -
}uu 	
}ww 
}xx ��
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\SearchResultModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Models "
{ 
public 

class 
SearchResultModel "
:# $
NListViewItem% 2
{ 
private 
string 
title 
; 
private 
string 
author 
; 
private 
string 
id 
; 
private 
string 
mixId 
; 
private 
byte 
[ 
] 
image 
; 
private 
TimeSpan 
duration !
;! "
private 
string 
thumbUrl 
;  
private 
string 
	videoData  
;  !
private 
ImageSource 
thumb !
;! "
public   
ImageSource   
Thumb    
{!! 	
get"" 
{## 

CheckThumb$$ 
($$ 
)$$ 
;$$ 
return%% 
thumb%% 
;%% 
}&& 
set'' 
{(( 
if)) 
()) 
thumb)) 
!=)) 
value)) "
)))" #
{** 
thumb++ 
=++ 
value++ !
;++! "
OnPropertyChanged,, %
(,,% &
),,& '
;,,' (
}-- 
}.. 
}// 	
public00 
string00 
Title00 
{11 	
get22 
=>22 
title22 
;22 
set33 
{44 
title55 
=55 
value55 
;55 
OnPropertyChanged66 !
(66! "
)66" #
;66# $
}77 
}88 	
public99 
string99 
Author99 
{:: 	
get;; 
=>;; 
author;; 
;;; 
set<< 
{== 
author>> 
=>> 
value>> 
;>> 
OnPropertyChanged?? !
(??! "
)??" #
;??# $
}@@ 
}AA 	
publicBB 
stringBB 
IdBB 
{CC 	
getDD 
=>DD 
idDD 
;DD 
setEE 
{FF 
idGG 
=GG 
valueGG 
;GG 
OnPropertyChangedHH !
(HH! "
)HH" #
;HH# $
}II 
}JJ 	
publicKK 
stringKK 
MixIdKK 
{LL 	
getMM 
=>MM 
mixIdMM 
;MM 
setNN 
{OO 
mixIdPP 
=PP 
valuePP 
;PP 
OnPropertyChangedQQ !
(QQ! "
)QQ" #
;QQ# $
}RR 
}SS 	
publicTT 
byteTT 
[TT 
]TT 
ImageTT 
{UU 	
getVV 
=>VV 
imageVV 
;VV 
setWW 
{XX 
imageYY 
=YY 
valueYY 
;YY 
OnPropertyChangedZZ !
(ZZ! "
)ZZ" #
;ZZ# $
}[[ 
}\\ 	
public]] 
TimeSpan]] 
Duration]]  
{^^ 	
get__ 
=>__ 
duration__ 
;__ 
set`` 
{aa 
durationbb 
=bb 
valuebb  
;bb  !
OnPropertyChangedcc !
(cc! "
)cc" #
;cc# $
OnPropertyChangeddd !
(dd! "
(dd" #
)dd# $
=>dd% '
DurationStringdd( 6
)dd6 7
;dd7 8
}ee 
}ff 	
publicgg 
stringgg 
ThumbUrlgg 
{hh 	
getii 
=>ii 
thumbUrlii 
;ii 
setjj 
{kk 
thumbUrlll 
=ll 
valuell  
;ll  !
OnPropertyChangedmm !
(mm! "
)mm" #
;mm# $
}nn 
}oo 	
publicpp 
stringpp 
	VideoDatapp 
{qq 	
getrr 
=>rr 
	videoDatarr 
;rr 
setss 
{tt 
	videoDatauu 
=uu 
valueuu !
;uu! "
OnPropertyChangedvv !
(vv! "
)vv" #
;vv# $
}ww 
}xx 	
publicyy 
stringyy 
DurationStringyy $
{zz 	
get{{ 
{|| 
return}} 
Duration}} 
.}}  
ToString}}  (
(}}( )
$str}}) 2
)}}2 3
;}}3 4
}~~ 
} 	
public
�� 
bool
�� 
	IsOffline
�� 
{
�� 	
get
�� 
{
�� 
return
�� 
id
�� 
.
�� 
Length
��  
>
��! "
$num
��# %
;
��% &
}
�� 
}
�� 	
public
�� 
Color
�� 
BackgroundColor
�� $
{
�� 	
get
�� 
=>
�� 
	IsOffline
�� 
?
�� 
Color
�� $
.
��$ %
FromHex
��% ,
(
��, -
$str
��- 6
)
��6 7
:
��8 9
Color
��: ?
.
��? @
Transparent
��@ K
;
��K L
}
�� 	
public
�� 
bool
�� 
	IsVisible
�� 
=>
��  
!
��! "
	IsOffline
��" +
;
��+ ,
private
�� 
ICommand
�� 
downloadClicked
�� (
;
��( )
public
�� 
ICommand
�� 
DownloadClicked
�� '
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
downloadClicked
�� #
==
��$ &
null
��' +
)
��+ ,
downloadClicked
�� #
=
��$ %
new
��& )
ActionCommand
��* 7
(
��7 8
	parameter
��8 A
=>
��B D
{
��  
ContextMenuBuilder
�� *
.
��* +"
BuildForSearchResult
��+ ?
(
��? @
	parameter
��@ I
as
��J L
View
��M Q
,
��Q R
	VideoData
��S \
)
��\ ]
;
��] ^
}
�� 
)
�� 
;
�� 
return
�� 
downloadClicked
�� &
;
��& '
}
�� 
set
�� 
=>
�� 
downloadClicked
�� "
=
��# $
value
��% *
;
��* +
}
�� 	
public
�� 
SearchResultModel
��  
(
��  !
Newtone
��! (
.
��( )
Core
��) -
.
��- .
Models
��. 4
.
��4 5
SearchResultModel
��5 F
model
��G L
)
��L M
{
�� 	
this
�� 
.
�� 
Author
�� 
=
�� 
model
�� 
.
��  
Author
��  &
;
��& '
this
�� 
.
�� 
Duration
�� 
=
�� 
model
�� !
.
��! "
Duration
��" *
;
��* +
this
�� 
.
�� 
Id
�� 
=
�� 
model
�� 
.
�� 
Id
�� 
;
�� 
this
�� 
.
�� 
Image
�� 
=
�� 
model
�� 
.
�� 
Image
�� $
;
��$ %
this
�� 
.
�� 
MixId
�� 
=
�� 
model
�� 
.
�� 
MixId
�� $
;
��$ %
this
�� 
.
�� 
ThumbUrl
�� 
=
�� 
model
�� !
.
��! "
ThumbUrl
��" *
;
��* +
this
�� 
.
�� 
Title
�� 
=
�� 
model
�� 
.
�� 
Title
�� $
;
��$ %
this
�� 
.
�� 
	VideoData
�� 
=
�� 
model
�� "
.
��" #
	VideoData
��# ,
;
��, -
}
�� 	
public
�� 
void
�� 
CheckChanges
��  
(
��  !
)
��! "
{
�� 	

CheckThumb
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
public
�� 
MediaSource
�� 
ToMediaSource
�� (
(
��( )
)
��) *
{
�� 	
return
�� 
new
�� 
MediaSource
�� "
(
��" #
)
��# $
{
�� 
Artist
�� 
=
�� 
Author
�� 
,
��  
Duration
�� 
=
�� 
Duration
�� #
,
��# $
FilePath
�� 
=
�� 
Id
�� 
,
�� 
Image
�� 
=
�� 
Image
�� 
,
�� 
Title
�� 
=
�� 
Title
�� 
,
�� 
Type
�� 
=
�� 
Id
�� 
.
�� 
Length
��  
==
��! #
$num
��$ &
?
��' (
MediaSource
��) 4
.
��4 5

SourceType
��5 ?
.
��? @
Web
��@ C
:
��D E
MediaSource
��F Q
.
��Q R

SourceType
��R \
.
��\ ]
Local
��] b
}
�� 
;
�� 
}
�� 	
public
�� 
override
�� 
async
�� 
void
�� "
FocusAction
��# .
(
��. /
)
��/ 0
{
�� 	 
NUntouchedListView
�� 
listView
�� '
=
��( )
ParentListView
��* 8
;
��8 9
int
�� 
index
�� 
=
�� 
listView
��  
.
��  !
NFocusedIndex
��! .
;
��. /
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� #
<
��$ %
listView
��& .
.
��. /
NItemSource
��/ :
.
��: ;
Count
��; @
)
��@ A
{
�� 
var
�� 
item
�� 
=
�� 
listView
�� #
.
��# $
NItemSource
��$ /
[
��/ 0
index
��0 5
]
��5 6
as
��7 9
SearchResultModel
��: K
;
��K L

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
CurrentPlaylist
��# 2
.
��2 3
Clear
��3 8
(
��8 9
)
��9 :
;
��: ;
if
�� 
(
�� 
string
�� 
.
�� 
IsNullOrEmpty
�� (
(
��( )
item
��) -
.
��- .
MixId
��. 3
)
��3 4
)
��4 5
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
PlaylistPosition
��' 7
=
��8 9
index
��: ?
;
��? @
foreach
�� 
(
�� 
var
��  
_item
��! &
in
��' )
listView
��* 2
.
��2 3
NItemSource
��3 >
)
��> ?
{
�� 
var
�� 
__item
�� "
=
��# $
_item
��% *
as
��+ -
SearchResultModel
��. ?
;
��? @

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
CurrentPlaylist
��+ :
.
��: ;
Add
��; >
(
��> ?
new
��? B
Newtone
��C J
.
��J K
Core
��K O
.
��O P
Media
��P U
.
��U V
MediaSource
��V a
(
��a b
)
��b c
{
�� 
Artist
�� "
=
��# $
__item
��% +
.
��+ ,
Author
��, 2
,
��2 3
Duration
�� $
=
��% &
__item
��' -
.
��- .
Duration
��. 6
,
��6 7
FilePath
�� $
=
��% &
__item
��' -
.
��- .
Id
��. 0
,
��0 1
Image
�� !
=
��" #
__item
��$ *
.
��* +
Image
��+ 0
,
��0 1
Title
�� !
=
��" #
__item
��$ *
.
��* +
Title
��+ 0
,
��0 1
Type
��  
=
��! "
__item
��# )
.
��) *
Id
��* ,
.
��, -
Length
��- 3
==
��4 6
$num
��7 9
?
��: ;
Newtone
��< C
.
��C D
Core
��D H
.
��H I
Media
��I N
.
��N O
MediaSource
��O Z
.
��Z [

SourceType
��[ e
.
��e f
Web
��f i
:
��j k
Core
��l p
.
��p q
Media
��q v
.
��v w
MediaSource��w �
.��� �

SourceType��� �
.��� �
Local��� �
}
�� 
)
�� 
;
�� 
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
=
��3 4

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
CurrentPlaylist
��H W
[
��W X
index
��X ]
]
��] ^
;
��^ _

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @
(
��@ A
)
��A B
=>
��C E
{
�� 
List
�� 
<
�� 
Core
�� !
.
��! "
Media
��" '
.
��' (
MediaSource
��( 3
>
��3 4
newPlaylist
��5 @
=
��A B
listView
��C K
.
��K L
NItemSource
��L W
.
��W X
Select
��X ^
(
��^ _
_item
��_ d
=>
��e g
{
�� 
var
�� 
__item
��  &
=
��' (
_item
��) .
as
��/ 1
SearchResultModel
��2 C
;
��C D
return
�� "
new
��# &
Core
��' +
.
��+ ,
Media
��, 1
.
��1 2
MediaSource
��2 =
(
��= >
)
��> ?
{
�� 
Artist
��  &
=
��' (
__item
��) /
.
��/ 0
Author
��0 6
,
��6 7
Duration
��  (
=
��) *
__item
��+ 1
.
��1 2
Duration
��2 :
,
��: ;
FilePath
��  (
=
��) *
__item
��+ 1
.
��1 2
Id
��2 4
,
��4 5
Image
��  %
=
��& '
__item
��( .
.
��. /
Image
��/ 4
,
��4 5
Title
��  %
=
��& '
__item
��( .
.
��. /
Title
��/ 4
,
��4 5
Type
��  $
=
��% &
__item
��' -
.
��- .
Id
��. 0
.
��0 1
Length
��1 7
==
��8 :
$num
��; =
?
��> ?
Newtone
��@ G
.
��G H
Core
��H L
.
��L M
Media
��M R
.
��R S
MediaSource
��S ^
.
��^ _

SourceType
��_ i
.
��i j
Web
��j m
:
��n o
Core
��p t
.
��t u
Media
��u z
.
��z {
MediaSource��{ �
.��� �

SourceType��� �
.��� �
Local��� �
}
�� 
;
�� 
}
�� 
)
�� 
.
�� 
ToList
�� !
(
��! "
)
��" #
;
��# $
return
�� 
newPlaylist
�� *
;
��* +
}
�� 
,
�� 
index
�� 
,
�� 
true
�� "
,
��" #
true
��$ (
)
��( )
;
��) *
}
�� 
else
�� 
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @
item
��@ D
.
��D E
MixId
��E J
,
��J K
$num
��L M
,
��M N
new
��O R
Newtone
��S Z
.
��Z [
Core
��[ _
.
��_ `
Media
��` e
.
��e f
MediaSource
��f q
(
��q r
)
��r s
{
�� 
Artist
�� 
=
��  
item
��! %
.
��% &
Author
��& ,
,
��, -
Duration
��  
=
��! "
item
��# '
.
��' (
Duration
��( 0
,
��0 1
FilePath
��  
=
��! "
item
��# '
.
��' (
Id
��( *
,
��* +
Image
�� 
=
�� 
item
��  $
.
��$ %
Image
��% *
,
��* +
Title
�� 
=
�� 
item
��  $
.
��$ %
Title
��% *
,
��* +
Type
�� 
=
�� 
Newtone
�� &
.
��& '
Core
��' +
.
��+ ,
Media
��, 1
.
��1 2
MediaSource
��2 =
.
��= >

SourceType
��> H
.
��H I
Web
��I L
}
�� 
,
�� 
true
�� 
,
�� 
true
�� !
)
��! "
;
��" #
}
�� 
await
�� 
Global
�� 
.
��  
NavigationInstance
�� /
.
��/ 0
PushModalAsync
��0 >
(
��> ?
new
��? B
FullScreenPage
��C Q
(
��Q R
)
��R S
)
��S T
;
��T U
}
�� 
}
�� 	
public
�� 
override
�� 
void
�� 
LongFocusAction
�� ,
(
��, -
)
��- .
{
�� 	
DownloadClicked
�� 
.
�� 
Execute
�� #
(
��# $
ParentListView
��$ 2
.
��2 3 
GetCurrentItemView
��3 E
(
��E F
)
��F G
)
��G H
;
��H I
}
�� 	
private
�� 
void
�� 

CheckThumb
�� 
(
��  
)
��  !
{
�� 	
if
�� 
(
�� 
thumb
�� 
==
�� 
null
�� 
&&
��  
Image
��! &
!=
��' )
null
��* .
&&
��/ 1
Image
��2 7
.
��7 8
Length
��8 >
>
��? @
$num
��A B
)
��B C
{
�� 
thumb
�� 
=
�� 
ImageProcessing
�� '
.
��' (
	FromArray
��( 1
(
��1 2
Image
��2 7
)
��7 8
;
��8 9
OnPropertyChanged
�� !
(
��! "
(
��" #
)
��# $
=>
��% '
Thumb
��( -
)
��- .
;
��. /
}
�� 
}
�� 	
}
�� 
}�� �i
@D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\SettingsModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Models "
{		 
public

 

class

 
SettingsModel

 
:

  
NListViewItem

! .
{ 
private 
string 
name 
; 
private 
string 
description "
;" #
public 
string 
Name 
{ 	
get 
=> 
name 
; 
set 
{ 
name 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
string 
Description !
{ 	
get 
=> 
description 
; 
set 
{ 
description 
= 
value #
;# $
OnPropertyChanged   !
(  ! "
)  " #
;  # $
}!! 
}"" 	
public%% 
override%% 
async%% 
void%% "
FocusAction%%# .
(%%. /
)%%/ 0
{&& 	
int'' 
index'' 
='' 
ParentListView'' &
.''& '
NFocusedIndex''' 4
;''4 5
if)) 
()) 
index)) 
>=)) 
$num)) 
&&)) 
index)) #
<))$ %
ParentListView))& 4
.))4 5
NItemSource))5 @
.))@ A
Count))A F
)))F G
{** 
if++ 
(++ 
index++ 
==++ 
$num++ 
)++ 
{,, 
foreach-- 
(-- 
string-- #
filepath--$ ,
in--- /

GlobalData--0 :
.--: ;
Current--; B
.--B C
Audios--C I
.--I J
Keys--J N
)--N O
{.. 
if00 
(00 
!00 

GlobalData00 '
.00' (
Current00( /
.00/ 0
	AudioTags000 9
.009 :
ContainsKey00: E
(00E F
filepath00F N
)00N O
)00O P
{11 
var22 
tag22  #
=22$ %

GlobalData22& 0
.220 1
Current221 8
.228 9
Audios229 ?
[22? @
filepath22@ H
]22H I
;22I J
if33 
(33  
tag33  #
.33# $
Artist33$ *
==33+ -
Localization33. :
.33: ;
UnknownArtist33; H
)33H I
{44 
FileInfo55  (
fileInfo55) 1
=552 3
new554 7
FileInfo558 @
(55@ A
filepath55A I
)55I J
;55J K
string77  &
_name77' ,
=77- .
fileInfo77/ 7
.777 8
Name778 <
.77< =
Replace77= D
(77D E
fileInfo77E M
.77M N
	Extension77N W
,77W X
$str77Y [
)77[ \
;77\ ]
string88  &
[88& '
]88' (
splitted88) 1
=882 3
_name884 9
.889 :
Split88: ?
(88? @
new88@ C
string88D J
[88J K
]88K L
{88M N
$str88O T
,88T U
$str88V [
,88[ \
$str88] a
,88a b
$str88c g
}88h i
,88i j
StringSplitOptions88k }
.88} ~
RemoveEmptyEntries	88~ �
)
88� �
;
88� �
string::  &
artist::' -
=::. /
splitted::0 8
.::8 9
Length::9 ?
==::@ B
$num::C D
?::E F
Localization::G S
.::S T
UnknownArtist::T a
:::b c
splitted::d l
[::l m
$num::m n
]::n o
;::o p
string;;  &
title;;' ,
=;;- .
splitted;;/ 7
[;;7 8
splitted;;8 @
.;;@ A
Length;;A G
==;;H J
$num;;K L
?;;M N
$num;;O P
:;;Q R
$num;;S T
];;T U
;;;U V

GlobalData<<  *
.<<* +
Current<<+ 2
.<<2 3
	AudioTags<<3 <
.<<< =
Add<<= @
(<<@ A
filepath<<A I
,<<I J
new<<K N
MediaSourceTag<<O ]
(<<] ^
)<<^ _
{<<` a
Author<<b h
=<<i j
artist<<k q
,<<q r
Title<<s x
=<<y z
title	<<{ �
}
<<� �
)
<<� �
;
<<� �
}== 
}>> 
}?? 

GlobalData@@ 
.@@ 
Current@@ &
.@@& '
SaveTags@@' /
(@@/ 0
)@@0 1
;@@1 2
GlobalAA 
.AA 
ApplicationAA &
.AA& '
ShowSnackbarAA' 3
(AA3 4
LocalizationAA4 @
.AA@ A
ReadyAAA F
)AAF G
;AAG H
}BB 
elseCC 
ifCC 
(CC 
indexCC 
==CC !
$numCC" #
)CC# $
{DD 
stringEE 
[EE 
]EE 
filesEE "
=EE# $
	DirectoryEE% .
.EE. /
GetFilesEE/ 7
(EE7 8

GlobalDataEE8 B
.EEB C
CurrentEEC J
.EEJ K
DataPathEEK S
,EES T
$strEEU ^
)EE^ _
;EE_ `
foreachGG 
(GG 
stringGG #
fileGG$ (
inGG) +
filesGG, 1
)GG1 2
{HH 
FileII 
.II 
DeleteII #
(II# $
fileII$ (
)II( )
;II) *
}JJ 
UILL 
.LL 
GlobalLL 
.LL 
ApplicationLL )
.LL) *
ShowSnackbarLL* 6
(LL6 7
LocalizationLL7 C
.LLC D
ReadyLLD I
)LLI J
;LLJ K
}MM 
elseNN 
ifNN 
(NN 
indexNN 
==NN !
$numNN" #
)NN# $
{OO 
GlobalPP 
.PP 
ApplicationPP &
.PP& '
AddFolderToScanPP' 6
(PP6 7
)PP7 8
;PP8 9
}QQ 
elseRR 
ifRR 
(RR 
indexRR 
==RR !
$numRR" #
)RR# $
{SS 
stringTT 
newLangTT "
=TT# $
awaitTT% *
GlobalTT+ 1
.TT1 2
PageTT2 6
.TT6 7
DisplayActionSheetTT7 I
(TTI J
LocalizationTTJ V
.TTV W
	Settings5TTW `
,TT` a
LocalizationTTb n
.TTn o
CancelTTo u
,TTu v
nullTTw {
,TT{ |
Localization	TT} �
.
TT� �

LanguagePL
TT� �
,
TT� �
Localization
TT� �
.
TT� �

LanguageEN
TT� �
,
TT� �
Localization
TT� �
.
TT� �

LanguageRU
TT� �
)
TT� �
;
TT� �
ifUU 
(UU 
newLangUU 
==UU  "
LocalizationUU# /
.UU/ 0

LanguagePLUU0 :
)UU: ;

GlobalDataVV "
.VV" #
CurrentVV# *
.VV* +
CurrentLanguageVV+ :
=VV; <
$strVV= A
;VVA B
elseWW 
ifWW 
(WW 
newLangWW $
==WW% '
LocalizationWW( 4
.WW4 5

LanguageENWW5 ?
)WW? @

GlobalDataXX "
.XX" #
CurrentXX# *
.XX* +
CurrentLanguageXX+ :
=XX; <
$strXX= A
;XXA B
elseYY 
ifYY 
(YY 
newLangYY $
==YY% '
LocalizationYY( 4
.YY4 5

LanguageRUYY5 ?
)YY? @

GlobalDataZZ "
.ZZ" #
CurrentZZ# *
.ZZ* +
CurrentLanguageZZ+ :
=ZZ; <
$strZZ= A
;ZZA B
Localization\\  
.\\  !
RefreshLanguage\\! 0
(\\0 1
)\\1 2
;\\2 3

GlobalData]] 
.]] 
Current]] &
.]]& '

SaveConfig]]' 1
(]]1 2
)]]2 3
;]]3 4
Global^^ 
.^^ 
Application^^ &
.^^& '
ShowSnackbar^^' 3
(^^3 4
Localization^^4 @
.^^@ A
SettingsChanges^^A P
)^^P Q
;^^Q R
}__ 
else`` 
if`` 
(`` 
index`` 
==`` !
$num``" #
)``# $
{aa 
stringbb 
	newOptionbb $
=bb% &
awaitbb' ,
Globalbb- 3
.bb3 4
Pagebb4 8
.bb8 9
DisplayActionSheetbb9 K
(bbK L
LocalizationbbL X
.bbX Y
AutoDownloadbbY e
,bbe f
Localizationbbg s
.bbs t
Cancelbbt z
,bbz {
null	bb| �
,
bb� �
Localization
bb� �
.
bb� �
Yes
bb� �
,
bb� �
Localization
bb� �
.
bb� �
No
bb� �
)
bb� �
;
bb� �
ifdd 
(dd 
	newOptiondd !
==dd" $
Localizationdd% 1
.dd1 2
Yesdd2 5
)dd5 6
{ee 

GlobalDataff "
.ff" #
Currentff# *
.ff* +
AutoDownloadff+ 7
=ff8 9
trueff: >
;ff> ?
(gg 
ParentListViewgg '
.gg' (
NItemSourcegg( 3
[gg3 4
$numgg4 5
]gg5 6
asgg7 9
SettingsModelgg: G
)ggG H
.ggH I
DescriptionggI T
=ggU V
LocalizationggW c
.ggc d
Yesggd g
;ggg h
}hh 
elseii 
ifii 
(ii 
	newOptionii &
==ii' )
Localizationii* 6
.ii6 7
Noii7 9
)ii9 :
{jj 

GlobalDatakk "
.kk" #
Currentkk# *
.kk* +
AutoDownloadkk+ 7
=kk8 9
falsekk: ?
;kk? @
(ll 
ParentListViewll '
.ll' (
NItemSourcell( 3
[ll3 4
$numll4 5
]ll5 6
asll7 9
SettingsModelll: G
)llG H
.llH I
DescriptionllI T
=llU V
LocalizationllW c
.llc d
Nolld f
;llf g
}mm 

GlobalDatann 
.nn 
Currentnn &
.nn& '

SaveConfignn' 1
(nn1 2
)nn2 3
;nn3 4
Globaloo 
.oo 
Applicationoo &
.oo& '
ShowSnackbaroo' 3
(oo3 4
Localizationoo4 @
.oo@ A
SettingsChangesooA P
)ooP Q
;ooQ R
}pp 
elseqq 
ifqq 
(qq 
indexqq 
==qq !
$numqq" #
)qq# $
{rr 
stringss 
	newOptionss $
=ss% &
awaitss' ,
Globalss- 3
.ss3 4
Pagess4 8
.ss8 9
DisplayActionSheetss9 K
(ssK L
LocalizationssL X
.ssX Y
	Settings3ssY b
,ssb c
Localizationssd p
.ssp q
Cancelssq w
,ssw x
nullssy }
,ss} ~
Localization	ss �
.
ss� �
Yes
ss� �
,
ss� �
Localization
ss� �
.
ss� �
No
ss� �
)
ss� �
;
ss� �
ifuu 
(uu 
	newOptionuu !
==uu" $
Localizationuu% 1
.uu1 2
Yesuu2 5
)uu5 6
{vv 

GlobalDataww "
.ww" #
Currentww# *
.ww* +
IgnoreAutoFocusww+ :
=ww; <
trueww= A
;wwA B
(xx 
ParentListViewxx '
.xx' (
NItemSourcexx( 3
[xx3 4
$numxx4 5
]xx5 6
asxx7 9
SettingsModelxx: G
)xxG H
.xxH I
DescriptionxxI T
=xxU V
LocalizationxxW c
.xxc d
Yesxxd g
;xxg h
}yy 
elsezz 
ifzz 
(zz 
	newOptionzz &
==zz' )
Localizationzz* 6
.zz6 7
Nozz7 9
)zz9 :
{{{ 

GlobalData|| "
.||" #
Current||# *
.||* +
IgnoreAutoFocus||+ :
=||; <
false||= B
;||B C
(}} 
ParentListView}} '
.}}' (
NItemSource}}( 3
[}}3 4
$num}}4 5
]}}5 6
as}}7 9
SettingsModel}}: G
)}}G H
.}}H I
Description}}I T
=}}U V
Localization}}W c
.}}c d
No}}d f
;}}f g
}~~ 

GlobalData 
. 
Current &
.& '

SaveConfig' 1
(1 2
)2 3
;3 4
Global
�� 
.
�� 
Application
�� &
.
��& '
ShowSnackbar
��' 3
(
��3 4
Localization
��4 @
.
��@ A
Ready
��A F
)
��F G
;
��G H
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
BD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\SuggestionModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Models "
{ 
public 

class 
SuggestionModel  
:! "
NListViewItem# 0
{		 
private 
string 
text 
; 
public 
string 
Text 
{ 	
get 
=> 
text 
; 
set 
{ 
text 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
private 
ICommand 
pressedCommand '
;' (
public 
ICommand 
PressedCommand &
{ 	
get 
{ 
if 
( 
pressedCommand "
==# %
null& *
)* +
pressedCommand "
=# $
new% (
ActionCommand) 6
(6 7
async7 <
(= >
	parameter> G
)G H
=>I K
{   
await!! 
Global!! $
.!!$ %
NavigationInstance!!% 7
.!!7 8
PushModalAsync!!8 F
(!!F G
new!!G J
	ModalPage!!K T
(!!T U
new!!U X
Views!!Y ^
.!!^ _
TV!!_ a
.!!a b
SearchResultPage!!b r
(!!r s
Text!!s w
)!!w x
,!!x y
Text!!z ~
)!!~ 
)	!! �
;
!!� �
}"" 
)"" 
;"" 
return## 
pressedCommand## %
;##% &
}$$ 
}%% 	
public(( 
override(( 
void(( 
FocusAction(( (
(((( )
)(() *
{)) 	
PressedCommand** 
.** 
Execute** "
(**" #
null**# '
)**' (
;**( )
}++ 	
}-- 
}.. ��
=D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Models\TrackModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Models "
{ 
public 

class 

TrackModel 
: 
NListViewItem +
{ 
private 
string 
filePath 
;  
private 
string 
title 
; 
private 
string 
duration 
;  
private 
string 
artist 
; 
private 
bool 
	isVisible 
; 
private 
string 
trackString "
;" #
private 
string 
playlistName #
;# $
private 
ImageSource 
image !
;! "
private 
bool 
allowContextMenu %
;% &
public 
string 
PlaylistName "
{   	
get!! 
=>!! 
playlistName!! 
;!!  
set"" 
{## 
playlistName$$ 
=$$ 
value$$ $
;$$$ %
OnPropertyChanged%% !
(%%! "
)%%" #
;%%# $
OnPropertyChanged&& !
(&&! "
(&&" #
)&&# $
=>&&% '
Info&&( ,
)&&, -
;&&- .
}'' 
}(( 	
public)) 
string)) 
Info)) 
{** 	
get++ 
{,, 
return-- 
string-- 
.-- 
Concat-- $
(--$ %
FilePath--% -
,--- .

GlobalData--/ 9
.--9 :
	SEPARATOR--: C
,--C D
PlaylistName--E Q
)--Q R
;--R S
}.. 
}// 	
public11 
bool11 
	IsVisible11 
{22 	
get33 
{33 
return33 
	isVisible33 "
;33" #
}33$ %
set44 
{55 
if66 
(66 
	isVisible66 
!=66  
value66! &
)66& '
{77 
	isVisible88 
=88 
value88  %
;88% &
OnPropertyChanged99 %
(99% &
)99& '
;99' (
}:: 
};; 
}<< 	
public>> 
string>> 
TrackString>> !
{?? 	
get@@ 
{AA 
returnBB 
trackStringBB "
;BB" #
}CC 
setDD 
{EE 
stringFF 
newValueFF 
=FF  !
valueFF" '
;FF' (
ifGG 
(GG 
newValueGG 
!=GG 
trackStringGG  +
)GG+ ,
{HH 
trackStringII 
=II  !
newValueII" *
;II* +
OnPropertyChangedJJ %
(JJ% &
)JJ& '
;JJ' (
}KK 
}LL 
}MM 	
publicNN 
ImageSourceNN 
ImageNN  
{OO 	
getPP 
=>PP 
imagePP 
;PP 
setQQ 
{RR 
imageSS 
=SS 
valueSS 
;SS 
OnPropertyChangedTT !
(TT! "
)TT" #
;TT# $
}UU 
}VV 	
publicXX 
boolXX 
AllowContextMenuXX $
{YY 	
getZZ 
=>ZZ 
allowContextMenuZZ #
;ZZ# $
set[[ 
{\\ 
allowContextMenu]]  
=]]! "
value]]# (
;]]( )
OnPropertyChanged^^ !
(^^! "
)^^" #
;^^# $
}__ 
}`` 	
publicbb 
stringbb 
FilePathbb 
{cc 	
getdd 
=>dd 
filePathdd 
;dd 
setee 
{ff 
filePathgg 
=gg 
valuegg  
;gg  !
OnPropertyChangedhh !
(hh! "
)hh" #
;hh# $
}ii 
}jj 	
publickk 
stringkk 
Titlekk 
{ll 	
getmm 
=>mm 
titlemm 
;mm 
setnn 
{oo 
titlepp 
=pp 
valuepp 
;pp 
OnPropertyChangedqq !
(qq! "
)qq" #
;qq# $
}rr 
}ss 	
publictt 
stringtt 
Durationtt 
{uu 	
getvv 
=>vv 
durationvv 
;vv 
setww 
{xx 
durationyy 
=yy 
valueyy  
;yy  !
OnPropertyChangedzz !
(zz! "
)zz" #
;zz# $
}{{ 
}|| 	
public~~ 
string~~ 
Artist~~ 
{ 	
get
�� 
=>
�� 
artist
�� 
;
�� 
set
�� 
{
�� 
artist
�� 
=
�� 
value
�� 
;
�� 
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
CurrentPlaylist
�� #
{
��$ %
get
��& )
;
��) *
}
��+ ,
private
�� 
ICommand
�� 
openMenu
�� !
;
��! "
public
�� 
ICommand
�� 
OpenMenu
��  
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
openMenu
�� 
==
�� 
null
��  $
)
��$ %
openMenu
�� 
=
�� 
new
�� "
ActionCommand
��# 0
(
��0 1
	parameter
��1 :
=>
��; =
{
��  
ContextMenuBuilder
�� *
.
��* +
BuildForTrack
��+ 8
(
��8 9
(
��9 :
Xamarin
��: A
.
��A B
Forms
��B G
.
��G H
View
��H L
)
��L M
	parameter
��M V
,
��V W
Info
��X \
)
��\ ]
;
��] ^
}
�� 
)
�� 
;
�� 
return
�� 
openMenu
�� 
;
��  
}
�� 
}
�� 	
public
�� 

TrackModel
�� 
(
�� 
Newtone
�� !
.
��! "
Core
��" &
.
��& '
Models
��' -
.
��- .

TrackModel
��. 8
model
��9 >
,
��> ?
string
��@ F
playlist
��G O
=
��P Q
$str
��R T
,
��T U
bool
��V Z
allowContextMenu
��[ k
=
��l m
true
��n r
,
��r s
bool
��t x
currentPlaylist��y �
=��� �
false��� �
)��� �
{
�� 	
this
�� 
.
�� 
Artist
�� 
=
�� 
model
�� 
.
��  
Artist
��  &
;
��& '
this
�� 
.
�� 
Duration
�� 
=
�� 
model
�� !
.
��! "
Duration
��" *
;
��* +
this
�� 
.
�� 
FilePath
�� 
=
�� 
model
�� !
.
��! "
FilePath
��" *
;
��* +
this
�� 
.
�� 
Title
�� 
=
�� 
model
�� 
.
�� 
Title
�� $
;
��$ %
this
�� 
.
�� 
PlaylistName
�� 
=
�� 
playlist
��  (
;
��( )
this
�� 
.
�� 
AllowContextMenu
�� !
=
��" #
allowContextMenu
��$ 4
;
��4 5
this
�� 
.
�� 
CurrentPlaylist
��  
=
��! "
currentPlaylist
��# 2
;
��2 3
if
�� 
(
�� 
FilePath
�� 
.
�� 
Length
�� 
>
��  !
$num
��" $
)
��$ %
this
�� 
.
�� 
Image
�� 
=
�� 
(
�� 

GlobalData
�� (
.
��( )
Current
��) 0
.
��0 1
Audios
��1 7
[
��7 8
FilePath
��8 @
]
��@ A
.
��A B
Image
��B G
==
��H J
null
��K O
||
��P R

GlobalData
��S ]
.
��] ^
Current
��^ e
.
��e f
Audios
��f l
[
��l m
FilePath
��m u
]
��u v
.
��v w
Image
��w |
.
��| }
Length��} �
==��� �
$num��� �
)��� �
?��� �
ImageSource��� �
.��� �
FromFile��� �
(��� �
$str��� �
)��� �
:��� �
ImageProcessing��� �
.��� �
	FromArray��� �
(��� �

GlobalData��� �
.��� �
Current��� �
.��� �
Audios��� �
[��� �
FilePath��� �
]��� �
.��� �
Image��� �
)��� �
;��� �
else
�� 
{
�� 
Newtone
�� 
.
�� 
Core
�� 
.
�� 
Media
�� "
.
��" #
MediaSource
��# .
source
��/ 5
=
��6 7
null
��8 <
;
��< =
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
SavedTracks
��' 2
.
��2 3
ContainsKey
��3 >
(
��> ?
FilePath
��? G
)
��G H
)
��H I
source
�� 
=
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
SavedTracks
��0 ;
[
��; <
FilePath
��< D
]
��D E
;
��E F
else
�� 
source
�� 
=
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
CurrentPlaylist
��0 ?
.
��? @
Find
��@ D
(
��D E
src
��E H
=>
��I K
src
��L O
.
��O P
FilePath
��P X
==
��Y [
model
��\ a
.
��a b
FilePath
��b j
)
��j k
;
��k l
if
�� 
(
�� 
source
�� 
!=
�� 
null
�� "
)
��" #
this
�� 
.
�� 
Image
�� 
=
��  
(
��! "
source
��" (
.
��( )
Image
��) .
==
��/ 1
null
��2 6
||
��7 9
source
��: @
.
��@ A
Image
��A F
.
��F G
Length
��G M
==
��N P
$num
��Q R
)
��R S
?
��T U
ImageSource
��V a
.
��a b
FromFile
��b j
(
��j k
$str
��k {
)
��{ |
:
��} ~
ImageProcessing�� �
.��� �
	FromArray��� �
(��� �
source��� �
.��� �
Image��� �
)��� �
;��� �
}
�� 
}
�� 	
public
�� 

TrackModel
�� 
CheckChanges
�� &
(
��& '
)
��' (
{
�� 	
	IsVisible
�� 
=
�� 
FilePath
��  
==
��! #

GlobalData
��$ .
.
��. /
Current
��/ 6
.
��6 7
MediaSourcePath
��7 F
;
��F G
TrackString
�� 
=
�� 
Artist
��  
==
��! #
Localization
��$ 0
.
��0 1
UnknownArtist
��1 >
?
��? @
Title
��A F
:
��G H
string
��I O
.
��O P
Concat
��P V
(
��V W
Artist
��W ]
,
��] ^
$str
��_ d
,
��d e
Title
��f k
)
��k l
;
��l m
return
�� 
this
�� 
;
�� 
}
�� 	
public
�� 
override
�� 
void
�� 
FocusAction
�� (
(
��( )
)
��) *
{
�� 	
int
�� 
index
�� 
=
�� 
-
�� 
$num
�� 
;
�� 
List
�� 
<
�� 
MediaSource
�� 
>
�� 
items
�� #
=
��$ %
null
��& *
;
��* +
if
�� 
(
�� 
CurrentPlaylist
�� 
)
�� 
{
�� 
index
�� 
=
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
CurrentPlaylist
��+ :
.
��: ;
	FindIndex
��; D
(
��D E
source
��E K
=>
��L N
source
��O U
.
��U V
FilePath
��V ^
==
��_ a
filePath
��b j
)
��j k
;
��k l
items
�� 
=
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
CurrentPlaylist
��+ :
;
��: ;
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
playlistName
�� 
==
��  "
$str
��# %
)
��% &
{
�� 
List
�� 
<
�� 

TrackModel
�� #
>
��# $
models
��% +
=
��, -
new
��. 1
List
��2 6
<
��6 7

TrackModel
��7 A
>
��A B
(
��B C
)
��C D
;
��D E
foreach
�� 
(
�� 
var
��  
track
��! &
in
��' )

GlobalData
��* 4
.
��4 5
Current
��5 <
.
��< =
Audios
��= C
.
��C D
Values
��D J
.
��J K
ToList
��K Q
(
��Q R
)
��R S
)
��S T
{
�� 
models
�� 
.
�� 
Add
�� "
(
��" #
new
��# &

TrackModel
��' 1
(
��1 2
track
��2 7
)
��7 8
.
��8 9
CheckChanges
��9 E
(
��E F
)
��F G
)
��G H
;
��H I
}
�� 
items
�� 
=
�� 
models
�� "
.
��" #
OrderBy
��# *
(
��* +
item
��+ /
=>
��0 2
item
��3 7
.
��7 8
TrackString
��8 C
)
��C D
.
��D E
Select
��E K
(
��K L
item
��L P
=>
��Q S

GlobalData
��T ^
.
��^ _
Current
��_ f
.
��f g
Audios
��g m
[
��m n
item
��n r
.
��r s
FilePath
��s {
]
��{ |
)
��| }
.
��} ~
ToList��~ �
(��� �
)��� �
;��� �
index
�� 
=
�� 
items
�� !
.
��! "
	FindIndex
��" +
(
��+ ,
item
��, 0
=>
��1 3
item
��4 8
.
��8 9
FilePath
��9 A
==
��B D
FilePath
��E M
)
��M N
;
��N O
}
�� 
else
�� 
{
�� 
items
�� 
=
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
	Playlists
��/ 8
[
��8 9
PlaylistName
��9 E
]
��E F
.
��F G
Select
��G M
(
��M N
item
��N R
=>
��S U

GlobalData
��V `
.
��` a
Current
��a h
.
��h i
Audios
��i o
[
��o p
item
��p t
]
��t u
)
��u v
.
��v w
ToList
��w }
(
��} ~
)
��~ 
;�� �
index
�� 
=
�� 
items
�� !
.
��! "
	FindIndex
��" +
(
��+ ,
item
��, 0
=>
��1 3
item
��4 8
.
��8 9
FilePath
��9 A
==
��B D
FilePath
��E M
)
��M N
;
��N O
}
�� 
}
�� 
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� #
<
��$ %
items
��& +
.
��+ ,
Count
��, 1
)
��1 2
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaPlayer
��# .
.
��. /
LoadPlaylist
��/ ;
(
��; <
items
��< A
.
��A B
Select
��B H
(
��H I
item
��I M
=>
��N P
item
��Q U
.
��U V
FilePath
��V ^
)
��^ _
.
��_ `
ToList
��` f
(
��f g
)
��g h
,
��h i
index
��j o
,
��o p
true
��q u
,
��u v
true
��w {
)
��{ |
;
��| }
}
�� 
}
�� 	
public
�� 
override
�� 
void
�� 
LongFocusAction
�� ,
(
��, -
)
��- .
{
�� 	
OpenMenu
�� 
.
�� 
Execute
�� 
(
�� 
this
�� !
.
��! "
ParentListView
��" 0
.
��0 1 
GetCurrentItemView
��1 C
(
��C D
)
��D E
)
��E F
;
��F G
}
�� 	
}
�� 
}�� �
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Processing\ImageProcessing.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

Processing &
{ 
public 

static 
class 
ImageProcessing '
{ 
public		 
static		 
ImageSource		 !
Blur		" &
(		& '
byte		' +
[		+ ,
]		, -
source		. 4
)		4 5
{

 	
return 
Global 
. 
ImageProcessing )
.) *
Blur* .
(. /
source/ 5
)5 6
;6 7
} 	
public 
static 
ImageSource !
Blur" &
(& '
ImageSource' 2
source3 9
)9 :
{ 	
return 
Global 
. 
ImageProcessing )
.) *
Blur* .
(. /
source/ 5
)5 6
;6 7
} 	
public 
static 
ImageSource !
	FromArray" +
(+ ,
byte, 0
[0 1
]1 2
source3 9
)9 :
{ 	
return 
source 
== 
null !
?" #
ImageSource$ /
./ 0
FromFile0 8
(8 9
$str9 I
)I J
:K L
ImageSourceM X
.X Y

FromStreamY c
(c d
(d e
)e f
=>g i
newj m
MemoryStreamn z
(z {
source	{ �
)
� �
)
� �
;
� �
} 	
} 
} �/
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\ArtistViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
ArtistViewModel  
{ 
public  
ObservableCollection #
<# $
ArtistModel$ /
>/ 0
Items1 6
{7 8
get9 <
;< =
private> E
setF I
;I J
}K L
public  
ObservableCollection #
<# $
NListViewItem$ 1
>1 2
	ListItems3 <
{= >
get? B
;B C
privateD K
setL O
;O P
}Q R
public 
Func 
< 
NListViewItem !
,! "
View# '
>' (
ItemTemplate) 5
{ 	
get 
{ 
return 
item 
=> 
new "
Views# (
.( )
TV) +
.+ ,
	ViewCells, 5
.5 6
ArtistGridItem6 D
(D E
itemE I
)I J
;J K
} 
} 	
public 
bool 
IsInitializing "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
ArtistViewModel 
( 
)  
{ 	
Items 
= 
new  
ObservableCollection ,
<, -
ArtistModel- 8
>8 9
(9 :
): ;
;; <
	ListItems   
=   
new    
ObservableCollection   0
<  0 1
NListViewItem  1 >
>  > ?
(  ? @
)  @ A
;  A B

Initialize!! 
(!! 
)!! 
;!! 
}"" 	
public%% 
void%% 

Initialize%% 
(%% 
)%%  
{&& 	
IsInitializing'' 
='' 
true'' !
;''! "
Items(( 
.(( 
Clear(( 
((( 
)(( 
;(( 
	ListItems)) 
.)) 
Clear)) 
()) 
))) 
;)) 
List** 
<** 
string** 
>** 

beforeSort** #
=**$ %
new**& )
List*** .
<**. /
string**/ 5
>**5 6
(**6 7
)**7 8
;**8 9
string++ 
unknown++ 
=++ 
null++ !
;++! "
foreach-- 
(-- 
string-- 
artist-- "
in--# %

GlobalData--& 0
.--0 1
Current--1 8
.--8 9
Artists--9 @
.--@ A
Keys--A E
)--E F
{.. 
if// 
(// 
artist// 
==// 
Localization// *
.//* +
UnknownArtist//+ 8
)//8 9
unknown00 
=00 
artist00 $
;00$ %
else11 

beforeSort22 
.22 
Add22 "
(22" #
artist22# )
)22) *
;22* +
}33 
List55 
<55 
string55 
>55 
	afterSort55 "
=55# $

beforeSort55% /
.55/ 0
OrderBy550 7
(557 8
o558 9
=>55: <
o55= >
)55> ?
.55? @
ToList55@ F
(55F G
)55G H
;55H I
if77 
(77 
unknown77 
!=77 
null77 
)77  
	afterSort88 
.88 
Add88 
(88 
unknown88 %
)88% &
;88& '
foreach:: 
(:: 
var:: 

artistName:: #
in::$ &
	afterSort::' 0
)::0 1
{;; 
ImageSource<< 
image<< !
=<<" #
ImageSource<<$ /
.<</ 0
FromFile<<0 8
(<<8 9
$str<<9 I
)<<I J
;<<J K
foreach== 
(== 
string== 
filePath==  (
in==) +

GlobalData==, 6
.==6 7
Current==7 >
.==> ?
Artists==? F
[==F G

artistName==G Q
]==Q R
)==R S
{>> 
var?? 
source?? 
=??  

GlobalData??! +
.??+ ,
Current??, 3
.??3 4
Audios??4 :
[??: ;
filePath??; C
]??C D
;??D E
if@@ 
(@@ 
source@@ 
.@@ 
Image@@ $
!=@@% '
null@@( ,
)@@, -
{AA 
imageBB 
=BB 
ImageProcessingBB  /
.BB/ 0
	FromArrayBB0 9
(BB9 :
sourceBB: @
.BB@ A
ImageBBA F
)BBF G
;BBG H
breakCC 
;CC 
}DD 
}EE 
ItemsGG 
.GG 
AddGG 
(GG 
newGG 
ArtistModelGG )
(GG) *
)GG* +
{GG, -
ImageGG. 3
=GG4 5
imageGG6 ;
,GG; <
NameGG= A
=GGB C

artistNameGGD N
,GGN O

TrackCountGGP Z
=GG[ \

GlobalDataGG] g
.GGg h
CurrentGGh o
.GGo p
ArtistsGGp w
[GGw x

artistName	GGx �
]
GG� �
.
GG� �
Count
GG� �
}
GG� �
)
GG� �
;
GG� �
	ListItemsHH 
.HH 
AddHH 
(HH 
ItemsHH #
[HH# $
^HH$ %
$numHH% &
]HH& '
)HH' (
;HH( )
}II 
IsInitializingJJ 
=JJ 
falseJJ "
;JJ" #
}KK 	
}MM 
}NN �;
OD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\CurrentPlaylistViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class $
CurrentPlaylistViewModel )
:* +
PropertyChangedBase, ?
{ 
private 
bool 
isRefreshing !
;! "
public  
ObservableCollection #
<# $

TrackModel$ .
>. /

TrackItems0 :
{; <
get= @
;@ A
setB E
;E F
}G H
public 
bool 
IsRefreshing  
{ 	
get 
=> 
isRefreshing 
;  
set 
{ 
isRefreshing 
= 
value $
;$ %
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
Func 
< 
NListViewItem !
,! "
View# '
>' (
ItemTemplate) 5
{   	
get!! 
=>!! 
item!! 
=>!! 
new!! 
Views!! $
.!!$ %
TV!!% '
.!!' (
	ViewCells!!( 1
.!!1 2
TrackViewCell!!2 ?
(!!? @
item!!@ D
)!!D E
;!!E F
}"" 	
private%% 
ICommand%% 
refresh%%  
;%%  !
public&& 
ICommand&& 
Refresh&& 
{'' 	
get(( 
{)) 
if** 
(** 
refresh** 
==** 
null** #
)**# $
refresh++ 
=++ 
new++ !
ActionCommand++" /
(++/ 0
	parameter++0 9
=>++: <
{,, 
IsRefreshing-- $
=--% &
true--' +
;--+ ,

TrackItems.. "
=..# $
new..% ( 
ObservableCollection..) =
<..= >

TrackModel..> H
>..H I
(..I J
)..J K
;..K L
foreach// 
(//  !
var//! $
track//% *
in//+ -

GlobalData//. 8
.//8 9
Current//9 @
.//@ A
CurrentPlaylist//A P
)//P Q
{00 

TrackItems11 &
.11& '
Add11' *
(11* +
new11+ .

TrackModel11/ 9
(119 :
track11: ?
,11? @
$str11A C
,11C D
false11E J
,11J K
true11L P
)11P Q
)11Q R
;11R S
}22 
IsRefreshing33 $
=33% &
false33' ,
;33, -
}44 
)44 
;44 
return55 
refresh55 
;55 
}66 
}77 	
private99 
ICommand99 
itemSelected99 %
;99% &
public:: 
ICommand:: 
ItemSelected:: $
{;; 	
get<< 
{== 
if>> 
(>> 
itemSelected>>  
==>>! #
null>>$ (
)>>( )
itemSelected??  
=??! "
new??# &
ActionCommand??' 4
(??4 5
	parameter??5 >
=>??? A
{@@ 
intAA 
indexAA !
=AA" #
(AA$ %
intAA% (
)AA( )
	parameterAA) 2
;AA2 3
ifBB 
(BB 
indexBB !
>=BB" $
$numBB% &
&&BB' )
indexBB* /
<BB0 1

TrackItemsBB2 <
.BB< =
CountBB= B
)BBB C
{CC 

GlobalDataDD &
.DD& '
CurrentDD' .
.DD. /
MediaPlayerDD/ :
.DD: ;
LoadPlaylistDD; G
(DDG H

TrackItemsDDH R
.DDR S
SelectDDS Y
(DDY Z
itemDDZ ^
=>DD_ a
itemDDb f
.DDf g
FilePathDDg o
)DDo p
.DDp q
ToListDDq w
(DDw x
)DDx y
,DDy z
index	DD{ �
,
DD� �
true
DD� �
,
DD� �
true
DD� �
)
DD� �
;
DD� �
}EE 
}FF 
)FF 
;FF 
returnGG 
itemSelectedGG #
;GG# $
}HH 
}II 	
publicLL $
CurrentPlaylistViewModelLL '
(LL' (
)LL( )
{MM 	

TrackItemsNN 
=NN 
newNN  
ObservableCollectionNN 1
<NN1 2

TrackModelNN2 <
>NN< =
(NN= >
)NN> ?
;NN? @
foreachOO 
(OO 
varOO 
trackOO 
inOO !

GlobalDataOO" ,
.OO, -
CurrentOO- 4
.OO4 5
CurrentPlaylistOO5 D
)OOD E
{PP 

TrackItemsQQ 
.QQ 
AddQQ 
(QQ 
newQQ "

TrackModelQQ# -
(QQ- .
trackQQ. 3
,QQ3 4
$strQQ5 7
,QQ7 8
falseQQ9 >
,QQ> ?
trueQQ@ D
)QQD E
)QQE F
;QQF G
}RR 
}SS 	
publicVV 
voidVV &
TrackListView_ItemSelectedVV .
(VV. /
objectVV/ 5
senderVV6 <
,VV< =(
SelectedItemChangedEventArgsVV> Z
eVV[ \
)VV\ ]
{WW 	
ItemSelectedXX 
.XX 
ExecuteXX  
(XX  !
eXX! "
.XX" #
SelectedItemIndexXX# 4
)XX4 5
;XX5 6
ifYY 
(YY 
!YY 
GlobalYY 
.YY 
TVYY 
)YY 
{ZZ 
([[ 
sender[[ 
as[[ 
Xamarin[[ "
.[[" #
Forms[[# (
.[[( )
ListView[[) 1
)[[1 2
.[[2 3
SelectedItem[[3 ?
=[[@ A
null[[B F
;[[F G
}\\ 
}]] 	
public__ 
void__ 
Tick__ 
(__ 
)__ 
{`` 	
foreachaa 
(aa 
varaa 
modelaa 
inaa !

TrackItemsaa" ,
.aa, -
ToListaa- 3
(aa3 4
)aa4 5
)aa5 6
modelbb 
.bb 
CheckChangesbb "
(bb" #
)bb# $
;bb$ %
ifdd 
(dd 

GlobalDatadd 
.dd 
Currentdd !
.dd! "&
CurrentPlaylistNeedRefreshdd" <
)dd< =
{ee 

TrackItemsff 
.ff 
Clearff  
(ff  !
)ff! "
;ff" #
foreachhh 
(hh 
varhh 
trackhh !
inhh" $

GlobalDatahh% /
.hh/ 0
Currenthh0 7
.hh7 8
CurrentPlaylisthh8 G
.hhG H
ToListhhH N
(hhN O
)hhO P
)hhP Q
{ii 

TrackItemsjj 
.jj 
Addjj "
(jj" #
newjj# &

TrackModeljj' 1
(jj1 2
trackjj2 7
,jj7 8
$strjj9 ;
,jj; <
falsejj= B
,jjB C
truejjD H
)jjH I
)jjI J
;jjJ K
}kk 

GlobalDatall 
.ll 
Currentll "
.ll" #&
CurrentPlaylistNeedRefreshll# =
=ll> ?
falsell@ E
;llE F
}mm 
}nn 	
}pp 
}qq ��
MD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\CurrentTracksViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class "
CurrentTracksViewModel '
:( )
PropertyChangedBase* =
{ 
private 
bool 
isRefreshing !
;! "
private 
readonly 
List 
< 
string $
>$ %
tracks& ,
;, -
private 
readonly 
string 
playlistName  ,
;, -
public  
ObservableCollection #
<# $

TrackModel$ .
>. /

TrackItems0 :
{; <
get= @
;@ A
privateB I
setJ M
;M N
}O P
public  
ObservableCollection #
<# $
NListViewItem$ 1
>1 2
	ListItems3 <
{= >
get? B
;B C
privateD K
setL O
;O P
}Q R
public 
bool 
IsRefreshing  
{ 	
get 
=> 
isRefreshing 
;  
set 
{ 
isRefreshing   
=   
value   $
;  $ %
OnPropertyChanged!! !
(!!! "
)!!" #
;!!# $
}"" 
}## 	
public%% 
Func%% 
<%% 
NListViewItem%% !
,%%! "
View%%# '
>%%' (
ItemTemplate%%) 5
{&& 	
get'' 
=>'' 
item'' 
=>'' 
new'' 
Views'' $
.''$ %
TV''% '
.''' (
	ViewCells''( 1
.''1 2
TrackViewCell''2 ?
(''? @
item''@ D
)''D E
;''E F
}(( 	
private++ 
ICommand++ 
refresh++  
;++  !
public,, 
ICommand,, 
Refresh,, 
{-- 	
get.. 
{// 
if00 
(00 
refresh00 
==00 
null00 #
)00# $
refresh11 
=11 
new11 !
ActionCommand11" /
(11/ 0
	parameter110 9
=>11: <
{22 
IsRefreshing33 $
=33% &
true33' +
;33+ ,
List44 
<44 

TrackModel44 '
>44' (

beforeSort44) 3
=444 5
new446 9
List44: >
<44> ?

TrackModel44? I
>44I J
(44J K
)44K L
;44L M
foreach55 
(55  !
string55! '
track55( -
in55. 0
tracks551 7
)557 8
{66 
if77 
(77  

GlobalData77  *
.77* +
Current77+ 2
.772 3
Audios773 9
.779 :
ContainsKey77: E
(77E F
track77F K
)77K L
)77L M
{88 

beforeSort99  *
.99* +
Add99+ .
(99. /
new99/ 2

TrackModel993 =
(99= >

GlobalData99> H
.99H I
Current99I P
.99P Q
Audios99Q W
[99W X
track99X ]
]99] ^
,99^ _
playlistName99` l
)99l m
.99m n
CheckChanges99n z
(99z {
)99{ |
)99| }
;99} ~
}:: 
};; 

TrackItems<< "
=<<# $
new<<% ( 
ObservableCollection<<) =
<<<= >

TrackModel<<> H
><<H I
(<<I J
playlistName<<J V
==<<W Y
$str<<Z \
?<<] ^

beforeSort<<_ i
.<<i j
OrderBy<<j q
(<<q r
item<<r v
=><<w y
item<<z ~
.<<~ 
TrackString	<< �
)
<<� �
.
<<� �
ToList
<<� �
(
<<� �
)
<<� �
:
<<� �

beforeSort
<<� �
)
<<� �
;
<<� �
IsRefreshing== $
===% &
false==' ,
;==, -
}>> 
)>> 
;>> 
return?? 
refresh?? 
;?? 
}@@ 
}AA 	
privateCC 
ICommandCC 
itemSelectedCC %
;CC% &
publicDD 
ICommandDD 
ItemSelectedDD $
{EE 	
getFF 
{GG 
ifHH 
(HH 
itemSelectedHH  
==HH! #
nullHH$ (
)HH( )
itemSelectedII  
=II! "
newII# &
ActionCommandII' 4
(II4 5
	parameterII5 >
=>II? A
{JJ 
intKK 
indexKK !
=KK" #
(KK$ %
intKK% (
)KK( )
	parameterKK) 2
;KK2 3
ifLL 
(LL 
indexLL !
>=LL" $
$numLL% &
&&LL' )
indexLL* /
<LL0 1

TrackItemsLL2 <
.LL< =
CountLL= B
)LLB C
{MM 

GlobalDataNN &
.NN& '
CurrentNN' .
.NN. /
MediaPlayerNN/ :
.NN: ;
LoadPlaylistNN; G
(NNG H

TrackItemsNNH R
.NNR S
SelectNNS Y
(NNY Z
itemNNZ ^
=>NN_ a
itemNNb f
.NNf g
FilePathNNg o
)NNo p
.NNp q
ToListNNq w
(NNw x
)NNx y
,NNy z
index	NN{ �
,
NN� �
true
NN� �
,
NN� �
true
NN� �
)
NN� �
;
NN� �
}OO 
}PP 
)PP 
;PP 
returnQQ 
itemSelectedQQ #
;QQ# $
}RR 
}SS 	
publicVV "
CurrentTracksViewModelVV %
(VV% &
ListVV& *
<VV* +
stringVV+ 1
>VV1 2
tracksVV3 9
,VV9 :
stringVV; A
playlistNameVVB N
)VVN O
{WW 	
thisXX 
.XX 
tracksXX 
=XX 
tracksXX  
;XX  !
thisYY 
.YY 
playlistNameYY 
=YY 
playlistNameYY  ,
;YY, -
ListZZ 
<ZZ 

TrackModelZZ 
>ZZ 

beforeSortZZ '
=ZZ( )
newZZ* -
ListZZ. 2
<ZZ2 3

TrackModelZZ3 =
>ZZ= >
(ZZ> ?
)ZZ? @
;ZZ@ A
foreach[[ 
([[ 
string[[ 
track[[ !
in[[" $
tracks[[% +
)[[+ ,
{\\ 
if]] 
(]] 

GlobalData]] 
.]] 
Current]] &
.]]& '
Audios]]' -
.]]- .
ContainsKey]]. 9
(]]9 :
track]]: ?
)]]? @
)]]@ A
{^^ 

beforeSort__ 
.__ 
Add__ "
(__" #
new__# &

TrackModel__' 1
(__1 2

GlobalData__2 <
.__< =
Current__= D
.__D E
Audios__E K
[__K L
track__L Q
]__Q R
,__R S
playlistName__T `
)__` a
.__a b
CheckChanges__b n
(__n o
)__o p
)__p q
;__q r
}`` 
elseaa 
ifaa 
(aa 

GlobalDataaa "
.aa" #
Currentaa# *
.aa* +
SavedTracksaa+ 6
.aa6 7
ContainsKeyaa7 B
(aaB C
trackaaC H
)aaH I
)aaI J
{bb 

beforeSortcc 
.cc 
Addcc "
(cc" #
newcc# &

TrackModelcc' 1
(cc1 2

GlobalDatacc2 <
.cc< =
Currentcc= D
.ccD E
SavedTracksccE P
[ccP Q
trackccQ V
]ccV W
,ccW X
playlistNameccY e
)cce f
.ccf g
CheckChangesccg s
(ccs t
)cct u
)ccu v
;ccv w
}dd 
}ee 

TrackItemsff 
=ff 
newff  
ObservableCollectionff 1
<ff1 2

TrackModelff2 <
>ff< =
(ff= >
playlistNameff> J
==ffK M
$strffN P
?ffQ R

beforeSortffS ]
.ff] ^
OrderByff^ e
(ffe f
itemfff j
=>ffk m
itemffn r
.ffr s
TrackStringffs ~
)ff~ 
.	ff �
ToList
ff� �
(
ff� �
)
ff� �
:
ff� �

beforeSort
ff� �
)
ff� �
;
ff� �
	ListItemsgg 
=gg 
newgg  
ObservableCollectiongg 0
<gg0 1
NListViewItemgg1 >
>gg> ?
(gg? @
)gg@ A
;ggA B
foreachii 
(ii 
varii 
itemii 
inii 

TrackItemsii  *
)ii* +
{jj 
	ListItemskk 
.kk 
Addkk 
(kk 
itemkk "
)kk" #
;kk# $
}ll 
}mm 	
publicqq 
voidqq 
Tickqq 
(qq 
)qq 
{rr 	
ifss 
(ss 

TrackItemsss 
.ss 
Countss  
==ss! #
$numss$ %
)ss% &
{tt 
_uu 
=uu 
Globaluu 
.uu 
NavigationInstanceuu -
.uu- .
PopModalAsyncuu. ;
(uu; <
)uu< =
;uu= >
returnvv 
;vv 
}ww 
ifyy 
(yy 

GlobalDatayy 
.yy 
Currentyy !
.yy! " 
PlaylistsNeedRefreshyy" 6
)yy6 7
{zz 

TrackItems{{ 
.{{ 
Clear{{  
({{  !
){{! "
;{{" #
	ListItems|| 
.|| 
Clear|| 
(||  
)||  !
;||! "
List~~ 
<~~ 

TrackModel~~ 
>~~  

beforeSort~~! +
=~~, -
new~~. 1
List~~2 6
<~~6 7

TrackModel~~7 A
>~~A B
(~~B C
)~~C D
;~~D E
foreach 
( 
string 
track  %
in& (
tracks) /
)/ 0
{
�� 
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
Audios
��+ 1
.
��1 2
ContainsKey
��2 =
(
��= >
track
��> C
)
��C D
)
��D E
{
�� 

beforeSort
�� "
.
��" #
Add
��# &
(
��& '
new
��' *

TrackModel
��+ 5
(
��5 6

GlobalData
��6 @
.
��@ A
Current
��A H
.
��H I
Audios
��I O
[
��O P
track
��P U
]
��U V
,
��V W
playlistName
��X d
)
��d e
.
��e f
CheckChanges
��f r
(
��r s
)
��s t
)
��t u
;
��u v
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
SavedTracks
��0 ;
.
��; <
ContainsKey
��< G
(
��G H
track
��H M
)
��M N
)
��N O
{
�� 

beforeSort
�� "
.
��" #
Add
��# &
(
��& '
new
��' *

TrackModel
��+ 5
(
��5 6

GlobalData
��6 @
.
��@ A
Current
��A H
.
��H I
SavedTracks
��I T
[
��T U
track
��U Z
]
��Z [
,
��[ \
playlistName
��] i
)
��i j
.
��j k
CheckChanges
��k w
(
��w x
)
��x y
)
��y z
;
��z {
}
�� 
}
�� 
var
�� 
	afterSort
�� 
=
�� 
playlistName
��  ,
==
��- /
$str
��0 2
?
��3 4

beforeSort
��5 ?
.
��? @
OrderBy
��@ G
(
��G H
item
��H L
=>
��M O
item
��P T
.
��T U
TrackString
��U `
)
��` a
.
��a b
ToList
��b h
(
��h i
)
��i j
:
��k l

beforeSort
��m w
;
��w x
foreach
�� 
(
�� 
var
�� 
item
��  
in
��! #
	afterSort
��$ -
)
��- .
{
�� 

TrackItems
�� 
.
�� 
Add
�� "
(
��" #
item
��# '
)
��' (
;
��( )
	ListItems
�� 
.
�� 
Add
�� !
(
��! "

TrackItems
��" ,
[
��, -
^
��- .
$num
��. /
]
��/ 0
)
��0 1
;
��1 2
}
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #"
PlaylistsNeedRefresh
��# 7
=
��8 9
false
��: ?
;
��? @
}
�� 
foreach
�� 
(
�� 
var
�� 
model
�� 
in
�� !

TrackItems
��" ,
.
��, -
ToList
��- 3
(
��3 4
)
��4 5
)
��5 6
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
Audios
��' -
.
��- .
ContainsKey
��. 9
(
��9 :
model
��: ?
.
��? @
FilePath
��@ H
)
��H I
)
��I J
{
�� 
var
�� 
source
�� 
=
��  

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
Audios
��4 :
[
��: ;
model
��; @
.
��@ A
FilePath
��A I
]
��I J
;
��J K
if
�� 
(
�� 
model
�� 
.
�� 
Artist
�� $
!=
��% '
source
��( .
.
��. /
Artist
��/ 5
||
��6 8
model
��9 >
.
��> ?
Title
��? D
!=
��E G
source
��H N
.
��N O
Title
��O T
)
��T U
{
�� 
int
�� 
index
�� !
=
��" #

TrackItems
��$ .
.
��. /
IndexOf
��/ 6
(
��6 7
model
��7 <
)
��< =
;
��= >

TrackItems
�� "
[
��" #
index
��# (
]
��( )
.
��) *
Title
��* /
=
��0 1
source
��2 8
.
��8 9
Title
��9 >
;
��> ?

TrackItems
�� "
[
��" #
index
��# (
]
��( )
.
��) *
Artist
��* 0
=
��1 2
source
��3 9
.
��9 :
Artist
��: @
;
��@ A
	ListItems
�� !
[
��! "
index
��" '
]
��' (
=
��) *
model
��+ 0
;
��0 1
}
�� 
model
�� 
.
�� 
CheckChanges
�� &
(
��& '
)
��' (
;
��( )
}
�� 
else
�� 
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
SavedTracks
��+ 6
.
��6 7
ContainsKey
��7 B
(
��B C
model
��C H
.
��H I
FilePath
��I Q
)
��Q R
)
��R S
{
�� 
var
�� 
source
�� 
=
��  

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
SavedTracks
��4 ?
[
��? @
model
��@ E
.
��E F
FilePath
��F N
]
��N O
;
��O P
if
�� 
(
�� 
model
�� 
.
�� 
Artist
�� $
!=
��% '
source
��( .
.
��. /
Artist
��/ 5
||
��6 8
model
��9 >
.
��> ?
Title
��? D
!=
��E G
source
��H N
.
��N O
Title
��O T
)
��T U
{
�� 
int
�� 
index
�� !
=
��" #

TrackItems
��$ .
.
��. /
IndexOf
��/ 6
(
��6 7
model
��7 <
)
��< =
;
��= >

TrackItems
�� "
[
��" #
index
��# (
]
��( )
.
��) *
Title
��* /
=
��0 1
source
��2 8
.
��8 9
Title
��9 >
;
��> ?

TrackItems
�� "
[
��" #
index
��# (
]
��( )
.
��) *
Artist
��* 0
=
��1 2
source
��3 9
.
��9 :
Artist
��: @
;
��@ A
	ListItems
�� !
[
��! "
index
��" '
]
��' (
=
��) *
model
��+ 0
;
��0 1
}
�� 
model
�� 
.
�� 
CheckChanges
�� &
(
��& '
)
��' (
;
��( )
}
�� 
else
�� 
{
�� 

TrackItems
�� 
.
�� 
Remove
�� %
(
��% &
model
��& +
)
��+ ,
;
��, -
Device
�� 
.
�� %
BeginInvokeOnMainThread
�� 2
(
��2 3
(
��3 4
)
��4 5
=>
��6 8
	ListItems
��9 B
.
��B C
Remove
��C I
(
��I J
model
��J O
)
��O P
)
��P Q
;
��Q R
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� (
TrackListView_ItemSelected
�� .
(
��. /
object
��/ 5
sender
��6 <
,
��< =*
SelectedItemChangedEventArgs
��> Z
e
��[ \
)
��\ ]
{
�� 	
ItemSelected
�� 
.
�� 
Execute
��  
(
��  !
e
��! "
.
��" #
SelectedItemIndex
��# 4
)
��4 5
;
��5 6
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
TV
�� 
)
�� 
{
�� 
(
�� 
sender
�� 
as
�� 
Xamarin
�� "
.
��" #
Forms
��# (
.
��( )
ListView
��) 1
)
��1 2
.
��2 3
SelectedItem
��3 ?
=
��@ A
null
��B F
;
��F G
}
�� 
}
�� 	
}
�� 
}�� �U
RD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\Custom\PlayerPanelViewModel.cs
	namespace		 	
Newtone		
 
.		 
Mobile		 
.		 
UI		 
.		 

ViewModels		 &
.		& '
Custom		' -
{

 
public 

class  
PlayerPanelViewModel %
:& '
PropertyChangedBase( ;
{ 
private 
bool !
backgroundGridVisible *
;* +
private 
string 
title 
; 
private 
string 
artist 
; 
private 
ImageSource 
	trackBlur %
;% &
private 
ImageSource 

trackImage &
;& '
private 
ImageSource 

playButton &
;& '
private 
bool 
isPlayImage  
=! "
true# '
;' (
private 
string 
playedTrack "
=# $
$str% '
;' (
private 
bool 
isPanelVisible #
;# $
public 
bool !
BackgroundGridVisible )
{ 	
get 
=> !
backgroundGridVisible (
;( )
set 
{ !
backgroundGridVisible %
=& '
value( -
;- .
OnPropertyChanged   !
(  ! "
)  " #
;  # $
}!! 
}"" 	
public$$ 
string$$ 
Title$$ 
{%% 	
get&& 
=>&& 
title&& 
;&& 
set'' 
{(( 
title)) 
=)) 
value)) 
;)) 
OnPropertyChanged** !
(**! "
)**" #
;**# $
}++ 
},, 	
public.. 
string.. 
Artist.. 
{// 	
get00 
=>00 
artist00 
;00 
set11 
{22 
artist33 
=33 
value33 
;33 
OnPropertyChanged44 !
(44! "
)44" #
;44# $
}55 
}66 	
public88 
ImageSource88 

TrackImage88 %
{99 	
get:: 
=>:: 

trackImage:: 
;:: 
set;; 
{<< 

trackImage== 
=== 
value== "
;==" #
OnPropertyChanged>> !
(>>! "
)>>" #
;>># $
}?? 
}@@ 	
publicBB 
ImageSourceBB 
	TrackBlurBB $
{CC 	
getDD 
=>DD 
	trackBlurDD 
;DD 
setEE 
{FF 
	trackBlurGG 
=GG 
valueGG !
;GG! "
OnPropertyChangedHH !
(HH! "
)HH" #
;HH# $
}II 
}JJ 	
publicLL 
ImageSourceLL 

PlayButtonLL %
{MM 	
getNN 
=>NN 

playButtonNN 
;NN 
setOO 
{PP 

playButtonQQ 
=QQ 
valueQQ "
;QQ" #
OnPropertyChangedRR !
(RR! "
)RR" #
;RR# $
}SS 
}TT 	
publicVV 
boolVV 
IsPanelVisibleVV "
{WW 	
getXX 
=>XX 
isPanelVisibleXX !
;XX! "
setYY 
{ZZ 
isPanelVisible[[ 
=[[  
value[[! &
;[[& '
OnPropertyChanged\\ !
(\\! "
)\\" #
;\\# $
}]] 
}^^ 	
privatebb 
ICommandbb 
playPauseCommandbb )
;bb) *
publiccc 
ICommandcc 
	PlayPausecc !
{dd 	
getee 
{ff 
ifgg 
(gg 
playPauseCommandgg $
==gg% '
nullgg( ,
)gg, -
playPauseCommandhh $
=hh% &
newhh' *
ActionCommandhh+ 8
(hh8 9
	parameterhh9 B
=>hhC E
{ii 
ifjj 
(jj 

GlobalDatajj &
.jj& '
Currentjj' .
.jj. /
MediaSourcejj/ :
!=jj; =
nulljj> B
)jjB C
{kk 
ifll 
(ll  

GlobalDatall  *
.ll* +
Currentll+ 2
.ll2 3
MediaPlayerll3 >
.ll> ?
	IsPlayingll? H
)llH I

GlobalDatamm  *
.mm* +
Currentmm+ 2
.mm2 3
MediaPlayermm3 >
.mm> ?
Pausemm? D
(mmD E
)mmE F
;mmF G
elsenn  

GlobalDataoo  *
.oo* +
Currentoo+ 2
.oo2 3
MediaPlayeroo3 >
.oo> ?
Playoo? C
(ooC D
)ooD E
;ooE F
}pp 
}qq 
)qq 
;qq 
returnss 
playPauseCommandss '
;ss' (
}tt 
}uu 	
privateww 
ICommandww 
gotoPlayerCommandww *
;ww* +
publicxx 
ICommandxx 

GotoPlayerxx "
{yy 	
getzz 
{{{ 
if|| 
(|| 
gotoPlayerCommand|| %
==||& (
null||) -
)||- .
gotoPlayerCommand}} %
=}}& '
new}}( +
ActionCommand}}, 9
(}}9 :
async}}: ?
(}}@ A
	parameter}}A J
)}}J K
=>}}L N
{~~ 
if 
( 

GlobalData &
.& '
Current' .
.. /
MediaSource/ :
!=; =
null> B
)B C
{
�� 
await
�� !
Global
��" (
.
��( ) 
NavigationInstance
��) ;
.
��; <
PushModalAsync
��< J
(
��J K
new
��K N
FullScreenPage
��O ]
(
��] ^
)
��^ _
)
��_ `
;
��` a
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoPlayerCommand
�� (
;
��( )
}
�� 
}
�� 	
public
�� "
PlayerPanelViewModel
�� #
(
��# $
)
��$ %
{
�� 	

PlayButton
�� 
=
�� 
ImageSource
�� $
.
��$ %
FromFile
��% -
(
��- .
$str
��. <
)
��< =
;
��= >

TrackImage
�� 
=
�� 
ImageSource
�� $
.
��$ %
FromFile
��% -
(
��- .
$str
��. >
)
��> ?
;
��? @
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
IsPanelVisible
�� 
=
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0
MediaSource
��0 ;
!=
��< >
null
��? C
;
��C D
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaSource
��# .
!=
��/ 1
null
��2 6
)
��6 7
{
�� 
Artist
�� 
=
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
MediaSource
��, 7
.
��7 8
Artist
��8 >
;
��> ?
Title
�� 
=
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
MediaSource
��+ 6
.
��6 7
Title
��7 <
;
��< =
}
�� 
if
�� 
(
�� 
playedTrack
�� 
!=
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaSourcePath
��2 A
)
��A B
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
.
��2 3
Image
��3 8
!=
��9 ;
null
��< @
&&
��A C

GlobalData
��D N
.
��N O
Current
��O V
.
��V W
MediaSource
��W b
.
��b c
Image
��c h
.
��h i
Length
��i o
>
��p q
$num
��r s
)
��s t
{
�� 

TrackImage
�� 
=
��  
ImageProcessing
��! 0
.
��0 1
	FromArray
��1 :
(
��: ;

GlobalData
��; E
.
��E F
Current
��F M
.
��M N
MediaSource
��N Y
.
��Y Z
Image
��Z _
)
��_ `
;
��` a
	TrackBlur
�� 
=
�� 
ImageProcessing
��  /
.
��/ 0
Blur
��0 4
(
��4 5

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
MediaSource
��H S
.
��S T
Image
��T Y
)
��Y Z
;
��Z [#
BackgroundGridVisible
�� )
=
��* +
true
��, 0
;
��0 1
}
�� 
else
�� 
{
�� 

TrackImage
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 F
)
��F G
;
��G H#
BackgroundGridVisible
�� )
=
��* +
false
��, 1
;
��1 2
}
�� 
playedTrack
�� 
=
�� 

GlobalData
�� (
.
��( )
Current
��) 0
.
��0 1
MediaSourcePath
��1 @
;
��@ A
}
�� 
if
�� 
(
�� 
isPlayImage
�� 
&&
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaPlayer
��2 =
.
��= >
	IsPlaying
��> G
)
��G H
{
�� 

PlayButton
�� 
=
�� 
ImageSource
�� (
.
��( )
FromFile
��) 1
(
��1 2
$str
��2 A
)
��A B
;
��B C
isPlayImage
�� 
=
�� 
false
�� #
;
��# $
}
�� 
if
�� 
(
�� 
!
�� 
isPlayImage
�� 
&&
�� 
!
��  !

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
MediaPlayer
��4 ?
.
��? @
	IsPlaying
��@ I
)
��I J
{
�� 

PlayButton
�� 
=
�� 
ImageSource
�� (
.
��( )
FromFile
��) 1
(
��1 2
$str
��2 @
)
��@ A
;
��A B
isPlayImage
�� 
=
�� 
true
�� "
;
��" #
}
�� 
}
�� 	
}
�� 
}�� �
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\DownloadViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
DownloadViewModel "
{ 
public

  
ObservableCollection

 #
<

# $
DownloadModel

$ 1
>

1 2
Items

3 8
{

9 :
get

; >
;

> ?
private

@ G
set

H K
;

K L
}

M N
public 
DownloadViewModel  
(  !
)! "
{ 	
Items 
= 
new  
ObservableCollection ,
<, -
DownloadModel- :
>: ;
(; <
)< =
;= >
} 	
public 
void 
Tick 
( 
) 
{ 	
if 
( 
Items 
. 
Count 
!= 
DownloadProcessing 1
.1 2
GetDownloads2 >
(> ?
)? @
.@ A
CountA F
)F G
{ 
Items 
. 
Clear 
( 
) 
; 
foreach 
( 
var 
item !
in" $
DownloadProcessing% 7
.7 8
	GetModels8 A
(A B
)B C
)C D
Items 
. 
Add 
( 
item "
)" #
;# $
} 
for 
( 
int 
a 
= 
$num 
; 
a 
< 
Items  %
.% &
Count& +
;+ ,
a- .
++. 0
)0 1
{ 
Items 
[ 
a 
] 
. 
Progress !
=" #
DownloadProcessing$ 6
.6 7
GetDownloads7 C
(C D
)D E
[E F
ItemsF K
[K L
aL M
]M N
.N O
IdO Q
]Q R
.R S
ProgressS [
;[ \
}   
}!! 	
}## 
}$$ �
[D:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\FirstStart\FirstStartSearchViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
.& '

FirstStart' 1
{ 
public 

class %
FirstStartSearchViewModel *
{		 
private 
ICommand 
next 
; 
public 
ICommand 
Next 
{ 	
get 
{ 
if 
( 
next 
== 
null  
)  !
next 
= 
new 
ActionCommand ,
(, -
	parameter- 6
=>7 9
{ 
App 
. 
Instance $
.$ %
MainPage% -
=. /
new0 3

NormalPage4 >
(> ?
)? @
;@ A
Task 
. 
Run  
(  !
async! &
(' (
)( )
=>* ,
{ 
await !
PopToRootAsync" 0
(0 1
)1 2
;2 3
} 
) 
; 
} 
) 
; 
return 
next 
; 
} 
} 	
private   
async   
Task   
PopToRootAsync   )
(  ) *
)  * +
{!! 	
while"" 
("" 
App"" 
."" 
Instance"" 
.""  
MainPage""  (
.""( )

Navigation"") 3
.""3 4

ModalStack""4 >
.""> ?
Count""? D
>""E F
$num""G H
)""H I
{## 
await$$ 
App$$ 
.$$ 
Instance$$ "
.$$" #
MainPage$$# +
.$$+ ,

Navigation$$, 6
.$$6 7
PopModalAsync$$7 D
($$D E
false$$E J
)$$J K
;$$K L
}%% 
}&& 	
}(( 
})) �
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\FullScreenViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
FullScreenViewModel $
:% &
PropertyChangedBase' :
{ 
private 
string 
title 
; 
private 
string 
artist 
; 
private 
ImageSource 

trackImage &
;& '
private 
ImageSource 
	trackBlur %
;% &
private 
string  
trackCurrentPosition +
;+ ,
private 
string 
trackDuration $
;$ %
private 
ImageSource 
middleButton (
;( )
private 
ImageSource 

modeButton &
;& '
private 
bool !
backgroundGridVisible *
;* +
private 
double 
audioSliderMax %
;% &
private 
double 
audioSliderValue '
;' (
private 
readonly 
bool 
	stopTimer '
=( )
false* /
;/ 0
private   
bool   
isPlayImage    
=  ! "
true  # '
;  ' (
private!! 
string!! 
playedTrack!! "
=!!# $
$str!!% '
;!!' (
private"" 

PlayerMode"" 

playerMode"" %
=""& '

PlayerMode""( 2
.""2 3
All""3 6
;""6 7
private## 
IDisposable## 
loopSubscription## ,
;##, -
private$$ 
bool$$ 
isLoadingVisible$$ %
;$$% &
public(( 
string(( 
Title(( 
{)) 	
get** 
=>** 
title** 
;** 
set++ 
{,, 
title-- 
=-- 
value-- 
;-- 
OnPropertyChanged.. !
(..! "
).." #
;..# $
}// 
}00 	
public22 
string22 
Artist22 
{33 	
get44 
=>44 
artist44 
;44 
set55 
{66 
artist77 
=77 
value77 
;77 
OnPropertyChanged88 !
(88! "
)88" #
;88# $
}99 
}:: 	
public<< 
ImageSource<< 

TrackImage<< %
{== 	
get>> 
=>>> 

trackImage>> 
;>> 
set?? 
{@@ 

trackImageAA 
=AA 
valueAA "
;AA" #
OnPropertyChangedBB !
(BB! "
)BB" #
;BB# $
}CC 
}DD 	
publicFF 
ImageSourceFF 
	TrackBlurFF $
{GG 	
getHH 
=>HH 
	trackBlurHH 
;HH 
setII 
{JJ 
	trackBlurKK 
=KK 
valueKK !
;KK! "
OnPropertyChangedLL !
(LL! "
)LL" #
;LL# $
}MM 
}NN 	
publicPP 
stringPP  
TrackCurrentPositionPP *
{QQ 	
getRR 
=>RR  
trackCurrentPositionRR '
;RR' (
setSS 
{TT  
trackCurrentPositionUU $
=UU% &
valueUU' ,
;UU, -
OnPropertyChangedVV !
(VV! "
)VV" #
;VV# $
}WW 
}XX 	
publicZZ 
stringZZ 
TrackDurationZZ #
{[[ 	
get\\ 
=>\\ 
trackDuration\\  
;\\  !
set]] 
{^^ 
trackDuration__ 
=__ 
value__  %
;__% &
OnPropertyChanged`` !
(``! "
)``" #
;``# $
}aa 
}bb 	
publicdd 
booldd !
BackgroundGridVisibledd )
{ee 	
getff 
=>ff !
backgroundGridVisibleff (
;ff( )
setgg 
{hh !
backgroundGridVisibleii %
=ii& '
valueii( -
;ii- .
OnPropertyChangedjj !
(jj! "
)jj" #
;jj# $
}kk 
}ll 	
publicnn 
ImageSourcenn 
MiddleButtonnn '
{oo 	
getpp 
=>pp 
middleButtonpp 
;pp  
setqq 
{rr 
middleButtonss 
=ss 
valuess $
;ss$ %
OnPropertyChangedtt !
(tt! "
)tt" #
;tt# $
}uu 
}vv 	
publicxx 
ImageSourcexx 

ModeButtonxx %
{yy 	
getzz 
=>zz 

modeButtonzz 
;zz 
set{{ 
{|| 

modeButton}} 
=}} 
value}} "
;}}" #
OnPropertyChanged~~ !
(~~! "
)~~" #
;~~# $
} 
}
�� 	
public
�� 
double
�� 
AudioSliderMax
�� $
{
�� 	
get
�� 
=>
�� 
audioSliderMax
�� !
;
��! "
set
�� 
{
�� 
if
�� 
(
�� 
audioSliderMax
�� "
!=
��# %
value
��& +
)
��+ ,
{
�� 
audioSliderMax
�� "
=
��# $
value
��% *
;
��* +
OnPropertyChanged
�� %
(
��% &
)
��& '
;
��' (
}
�� 
}
�� 
}
�� 	
public
�� 
double
�� 
AudioSliderValue
�� &
{
�� 	
get
�� 
=>
�� 
audioSliderValue
�� #
;
��# $
set
�� 
{
�� 
if
�� 
(
�� 
audioSliderValue
�� $
!=
��% '
value
��( -
)
��- .
{
�� 
audioSliderValue
�� $
=
��% &
value
��' ,
;
��, -
OnPropertyChanged
�� %
(
��% &
)
��& '
;
��' (
}
�� 
}
�� 
}
�� 	
public
�� 
bool
�� 
IsLoadingVisible
�� $
{
�� 	
get
�� 
=>
�� 
isLoadingVisible
�� #
;
��# $
set
�� 
{
�� 
isLoadingVisible
��  
=
��! "
value
��# (
;
��( )
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
private
�� 
ICommand
�� 
repeatChange
�� %
;
��% &
public
�� 
ICommand
�� 
RepeatChange
�� $
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
repeatChange
��  
==
��! #
null
��$ (
)
��( )
repeatChange
��  
=
��! "
new
��# &
ActionCommand
��' 4
(
��4 5
	parameter
��5 >
=>
��? A
{
�� 
int
�� 
oldMode
�� #
=
��$ %
(
��& '
int
��' *
)
��* +

GlobalData
��+ 5
.
��5 6
Current
��6 =
.
��= >

PlayerMode
��> H
;
��H I
int
�� 
newMode
�� #
=
��$ %
oldMode
��& -
+
��. /
$num
��0 1
;
��1 2
if
�� 
(
�� 
newMode
�� #
==
��$ &
$num
��' (
)
��( )
newMode
�� #
=
��$ %
$num
��& '
;
��' (

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

PlayerMode
��+ 5
=
��6 7
(
��8 9

PlayerMode
��9 C
)
��C D
newMode
��D K
;
��K L

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
}
�� 
)
�� 
;
�� 
return
�� 
repeatChange
�� #
;
��# $
}
�� 
}
�� 	
private
�� 
ICommand
�� 
previousTrack
�� &
;
��& '
public
�� 
ICommand
�� 
PreviousTrack
�� %
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
previousTrack
�� !
==
��" $
null
��% )
)
��) *
previousTrack
�� !
=
��" #
new
��$ '
ActionCommand
��( 5
(
��5 6
	parameter
��6 ?
=>
��@ B
{
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
MediaPlayer
��+ 6
.
��6 7
Prev
��7 ;
(
��; <
)
��< =
;
��= >
if
�� 
(
�� 
!
�� 
isPlayImage
�� (
)
��( )

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaPlayer
��/ :
.
��: ;
Play
��; ?
(
��? @
)
��@ A
;
��A B
}
�� 
)
�� 
;
�� 
return
�� 
previousTrack
�� $
;
��$ %
}
�� 
}
�� 	
private
�� 
ICommand
�� 
playOrPause
�� $
;
��$ %
public
�� 
ICommand
�� 
PlayOrPause
�� #
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
playOrPause
�� 
==
��  "
null
��# '
)
��' (
playOrPause
�� 
=
��  !
new
��" %
ActionCommand
��& 3
(
��3 4
	parameter
��4 =
=>
��> @
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
!=
��; =
null
��> B
)
��B C
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
	IsPlaying
��? H
)
��H I

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
Pause
��? D
(
��D E
)
��E F
;
��F G
else
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
Play
��? C
(
��C D
)
��D E
;
��E F
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
playOrPause
�� "
;
��" #
}
�� 
}
�� 	
private
�� 
ICommand
�� 
	nextTrack
�� "
;
��" #
public
�� 
ICommand
�� 
	NextTrack
�� !
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
	nextTrack
�� 
==
��  
null
��! %
)
��% &
	nextTrack
�� 
=
�� 
new
��  #
ActionCommand
��$ 1
(
��1 2
	parameter
��2 ;
=>
��< >
{
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
MediaPlayer
��+ 6
.
��6 7
Next
��7 ;
(
��; <
)
��< =
;
��= >
if
�� 
(
�� 
!
�� 
isPlayImage
�� (
)
��( )

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaPlayer
��/ :
.
��: ;
Play
��; ?
(
��? @
)
��@ A
;
��A B
}
�� 
)
�� 
;
�� 
return
�� 
	nextTrack
��  
;
��  !
}
�� 
}
�� 	
private
�� 
ICommand
�� 
menuButtonCommand
�� *
;
��* +
public
�� 
ICommand
�� 
MenuButtonCommand
�� )
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
menuButtonCommand
�� %
==
��& (
null
��) -
)
��- .
menuButtonCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
	parameter
��: C
=>
��D F
{
��  
ContextMenuBuilder
�� *
.
��* +
BuildForTrack
��+ 8
(
��8 9
(
��9 :
Xamarin
��: A
.
��A B
Forms
��B G
.
��G H
View
��H L
)
��L M
	parameter
��M V
,
��V W

GlobalData
��X b
.
��b c
Current
��c j
.
��j k
MediaSource
��k v
.
��v w
FilePath
��w 
+��� �

GlobalData��� �
.��� �
	SEPARATOR��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� 
menuButtonCommand
�� (
;
��( )
}
�� 
}
�� 	
private
�� 
ICommand
�� 

expandList
�� #
;
��# $
public
�� 
ICommand
�� 

ExpandList
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 

expandList
�� 
==
�� !
null
��" &
)
��& '

expandList
�� 
=
��  
new
��! $
ActionCommand
��% 2
(
��2 3
async
��3 8
(
��9 :
	parameter
��: C
)
��C D
=>
��E G
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X!
CurrentPlaylistPage
��Y l
(
��l m
)
��m n
,
��n o
$str
��p r
,
��r s
false
��t y
,
��y z
false��{ �
)��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� 

expandList
�� !
;
��! "
}
�� 
}
�� 	
public
�� !
FullScreenViewModel
�� "
(
��" #
)
��# $
{
�� 	
MiddleButton
�� 
=
�� 
ImageSource
�� &
.
��& '
FromFile
��' /
(
��/ 0
$str
��0 >
)
��> ?
;
��? @

ModeButton
�� 
=
�� 
ImageSource
�� $
.
��$ %
FromFile
��% -
(
��- .
$str
��. >
)
��> ?
;
��? @
}
�� 	
public
�� 
void
�� 
	Appearing
�� 
(
�� 
)
�� 
{
�� 	
var
�� 
src
�� 
=
�� 
System
�� 
.
�� 
Reactive
�� %
.
��% &
Linq
��& *
.
��* +

Observable
��+ 5
.
��5 6
Timer
��6 ;
(
��; <
TimeSpan
��< D
.
��D E
Zero
��E I
,
��I J
TimeSpan
��K S
.
��S T
FromMilliseconds
��T d
(
��d e
$num
��e h
)
��h i
)
��i j
.
��j k
	Timestamp
��k t
(
��t u
)
��u v
;
��v w
loopSubscription
�� 
=
�� 
src
�� "
.
��" #
	Subscribe
��# ,
(
��, -
time
��- 1
=>
��2 4
Tick
��5 9
(
��9 :
)
��: ;
)
��; <
;
��< =
}
�� 	
public
�� 
void
�� 
Disappearing
��  
(
��  !
)
��! "
{
�� 	
loopSubscription
�� 
?
�� 
.
�� 
Dispose
�� %
(
��% &
)
��& '
;
��' (
loopSubscription
�� 
=
�� 
null
�� #
;
��# $
}
�� 	
public
�� 
void
�� )
AudioSlider_ValueNewChanged
�� /
(
��/ 0 
AudioSliderControl
��0 B
.
��B C
ValueChangedArgs
��C S
e
��T U
)
��U V
{
�� 	
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaPlayer
��# .
.
��. /
	IsPlaying
��/ 8
)
��8 9
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaPlayer
��# .
.
��. /
Seek
��/ 3
(
��3 4
e
��4 5
.
��5 6
Value
��6 ;
)
��; <
;
��< =
}
�� 
}
�� 	
private
�� 
bool
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	"
TrackCurrentPosition
��  
=
��! "
TimeSpan
��# +
.
��+ ,
FromSeconds
��, 7
(
��7 8

GlobalData
��8 B
.
��B C
Current
��C J
.
��J K
MediaPlayer
��K V
.
��V W
CurrentPosition
��W f
)
��f g
.
��g h
ToString
��h p
(
��p q
$str
��q z
)
��z {
;
��{ |
TrackDuration
�� 
=
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
.
��: ;
Duration
��; C
.
��C D
ToString
��D L
(
��L M
$str
��M V
)
��V W
;
��W X
Artist
�� 
=
�� 

GlobalData
�� 
.
��  
Current
��  '
.
��' (
MediaSource
��( 3
.
��3 4
Artist
��4 :
;
��: ;
Title
�� 
=
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
.
��2 3
Title
��3 8
;
��8 9
IsLoadingVisible
�� 
=
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaPlayer
��2 =
.
��= >
	IsLoading
��> G
;
��G H
if
�� 
(
�� 
playedTrack
�� 
!=
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaSourcePath
��2 A
)
��A B
{
�� #
BackgroundGridVisible
�� %
=
��& '

GlobalData
��( 2
.
��2 3
Current
��3 :
.
��: ;
MediaSource
��; F
.
��F G
Image
��G L
!=
��M O
null
��P T
;
��T U
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
.
��2 3
Image
��3 8
!=
��9 ;
null
��< @
&&
��A C

GlobalData
��D N
.
��N O
Current
��O V
.
��V W
MediaSource
��W b
.
��b c
Image
��c h
.
��h i
Length
��i o
>
��p q
$num
��r s
)
��s t
{
�� 
	TrackBlur
�� 
=
�� 
ImageProcessing
��  /
.
��/ 0
Blur
��0 4
(
��4 5
ImageProcessing
��5 D
.
��D E
	FromArray
��E N
(
��N O

GlobalData
��O Y
.
��Y Z
Current
��Z a
.
��a b
MediaSource
��b m
.
��m n
Image
��n s
)
��s t
)
��t u
;
��u v

TrackImage
�� 
=
��  
ImageProcessing
��! 0
.
��0 1
	FromArray
��1 :
(
��: ;

GlobalData
��; E
.
��E F
Current
��F M
.
��M N
MediaSource
��N Y
.
��Y Z
Image
��Z _
)
��_ `
;
��` a
}
�� 
else
�� 
{
�� 

TrackImage
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 F
)
��F G
;
��G H
}
�� 
playedTrack
�� 
=
�� 

GlobalData
�� (
.
��( )
Current
��) 0
.
��0 1
MediaSourcePath
��1 @
;
��@ A
}
�� 
if
�� 
(
�� 
isPlayImage
�� 
&&
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaPlayer
��2 =
.
��= >
	IsPlaying
��> G
)
��G H
{
�� 
MiddleButton
�� 
=
�� 
ImageSource
�� *
.
��* +
FromFile
��+ 3
(
��3 4
$str
��4 C
)
��C D
;
��D E
isPlayImage
�� 
=
�� 
false
�� #
;
��# $
}
�� 
if
�� 
(
�� 
!
�� 
isPlayImage
�� 
&&
�� 
!
��  !

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
MediaPlayer
��4 ?
.
��? @
	IsPlaying
��@ I
)
��I J
{
�� 
MiddleButton
�� 
=
�� 
ImageSource
�� *
.
��* +
FromFile
��+ 3
(
��3 4
$str
��4 B
)
��B C
;
��C D
isPlayImage
�� 
=
�� 
true
�� "
;
��" #
}
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaPlayer
��# .
.
��. /
	IsPlaying
��/ 8
)
��8 9
{
�� 
AudioSliderMax
�� 
=
��  

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
MediaPlayer
��4 ?
.
��? @
Duration
��@ H
;
��H I
AudioSliderValue
��  
=
��! "

GlobalData
��# -
.
��- .
Current
��. 5
.
��5 6
MediaPlayer
��6 A
.
��A B
CurrentPosition
��B Q
;
��Q R
}
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #

PlayerMode
��# -
!=
��. 0

playerMode
��1 ;
)
��; <
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

PlayerMode
��' 1
==
��2 4

PlayerMode
��5 ?
.
��? @
All
��@ C
)
��C D

ModeButton
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 F
)
��F G
;
��G H
else
�� 
if
�� 
(
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,

PlayerMode
��, 6
==
��7 9

PlayerMode
��: D
.
��D E
One
��E H
)
��H I

ModeButton
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 I
)
��I J
;
��J K
else
�� 

ModeButton
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 F
)
��F G
;
��G H

playerMode
�� 
=
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0

PlayerMode
��0 :
;
��: ;
}
�� 
return
�� 
!
�� 
	stopTimer
�� 
;
�� 
}
�� 	
}
�� 
}�� �
ND:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\LanguageSelectViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{		 
public

 

class

 #
LanguageSelectViewModel

 (
:

) *
PropertyChangedBase

+ >
{ 
private 
ICommand 
english  
;  !
public 
ICommand 
English 
{ 	
get 
{ 
if 
( 
english 
== 
null #
)# $
english 
= 
new !
ActionCommand" /
(/ 0
	parameter0 9
=>: <
{ 
ChangeLanguage &
(& '
$str' +
)+ ,
;, -
} 
) 
; 
return 
english 
; 
} 
} 	
private 
ICommand 
polish 
;  
public 
ICommand 
Polish 
{ 	
get 
{   
if!! 
(!! 
polish!! 
==!! 
null!! "
)!!" #
polish"" 
="" 
new""  
ActionCommand""! .
("". /
	parameter""/ 8
=>""9 ;
{## 
ChangeLanguage$$ &
($$& '
$str$$' +
)$$+ ,
;$$, -
}%% 
)%% 
;%% 
return'' 
polish'' 
;'' 
}(( 
})) 	
private++ 
ICommand++ 
russian++  
;++  !
public,, 
ICommand,, 
Russian,, 
{-- 	
get.. 
{// 
if00 
(00 
russian00 
==00 
null00 #
)00# $
russian11 
=11 
new11 !
ActionCommand11" /
(11/ 0
	parameter110 9
=>11: <
{22 
ChangeLanguage33 &
(33& '
$str33' +
)33+ ,
;33, -
}44 
)44 
;44 
return66 
russian66 
;66 
}77 
}88 	
public;; #
LanguageSelectViewModel;; &
(;;& '
);;' (
{<< 	
}== 	
privateAA 
voidAA 
ChangeLanguageAA #
(AA# $
stringAA$ *
langAA+ /
)AA/ 0
{BB 	

GlobalDataCC 
.CC 
CurrentCC 
.CC 
CurrentLanguageCC .
=CC/ 0
langCC1 5
;CC5 6
LocalizationDD 
.DD 
RefreshLanguageDD (
(DD( )
)DD) *
;DD* +
ifEE 
(EE 
GlobalEE 
.EE 
TVEE 
)EE 
AppFF 
.FF 
InstanceFF 
.FF 
MainPageFF %
=FF& '
newFF( +
ViewsFF, 1
.FF1 2
TVFF2 4
.FF4 5
PermissionPageFF5 C
(FFC D
)FFD E
;FFE F
elseGG 
{HH 
AppII 
.II 
InstanceII 
.II 
MainPageII %
=II& '
newII( +
PermissionPageII, :
(II: ;
)II; <
;II< =
}JJ 
}KK 	
}MM 
}NN �=
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\ModalViewModel.cs
	namespace		 	
Newtone		
 
.		 
Mobile		 
.		 
UI		 
.		 

ViewModels		 &
{

 
public 

class 
ModalViewModel 
:  !
PropertyChangedBase" 5
{ 
private 
string 

modalTitle !
;! "
private 
string 
badge 
; 
private 
bool 
badgeVisible !
;! "
private 
bool 
topPanelVisible $
;$ %
public 
string 

ModalTitle  
{ 	
get 
=> 

modalTitle 
; 
set 
{ 

modalTitle 
= 
value "
;" #
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
string 
Badge 
{   	
get!! 
=>!! 
badge!! 
;!! 
set"" 
{## 
badge$$ 
=$$ 
value$$ 
;$$ 
OnPropertyChanged%% !
(%%! "
)%%" #
;%%# $
}&& 
}'' 	
public(( 
bool(( 
BadgeVisible((  
{)) 	
get** 
=>** 
badgeVisible** 
;**  
set++ 
{,, 
badgeVisible-- 
=-- 
value-- $
;--$ %
OnPropertyChanged.. !
(..! "
).." #
;..# $
}// 
}00 	
public22 
bool22 
TopPanelVisible22 #
{33 	
get44 
=>44 
topPanelVisible44 "
;44" #
set55 
{66 
topPanelVisible77 
=77  !
value77" '
;77' (
OnPropertyChanged88 !
(88! "
)88" #
;88# $
}99 
}:: 	
public<< 
bool<< 
BackButtonVisible<< %
=><<& (
Device<<) /
.<</ 0
RuntimePlatform<<0 ?
==<<@ B
Device<<C I
.<<I J
iOS<<J M
;<<M N
public>> 
Grid>> 
	Container>> 
{>> 
get>>  #
;>># $
private>>% ,
set>>- 0
;>>0 1
}>>2 3
public?? 
bool?? !
DownloadButtonVisible?? )
=>??* ,
!??- .
(??. /
	Container??/ 8
.??8 9
Children??9 A
.??A B
Count??B G
>??H I
$num??J K
&&??L N
	Container??O X
.??X Y
Children??Y a
[??a b
$num??b c
]??c d
is??e g
DownloadPage??h t
)??t u
;??u v
privateCC 
ICommandCC 
toFullScreenCC %
;CC% &
publicDD 
ICommandDD 
ToFullScreenDD $
{EE 	
getFF 
{GG 
ifHH 
(HH 
toFullScreenHH  
==HH! #
nullHH$ (
)HH( )
toFullScreenII  
=II! "
newII# &
ActionCommandII' 4
(II4 5
asyncII5 :
(II; <
	parameterII< E
)IIE F
=>IIG I
{JJ 
ifKK 
(KK 

GlobalDataKK &
.KK& '
CurrentKK' .
.KK. /
MediaSourceKK/ :
!=KK; =
nullKK> B
)KKB C
{LL 
awaitMM !
GlobalMM" (
.MM( )
NavigationInstanceMM) ;
.MM; <
PushModalAsyncMM< J
(MMJ K
newMMK N
FullScreenPageMMO ]
(MM] ^
)MM^ _
)MM_ `
;MM` a
}NN 
}OO 
)OO 
;OO 
returnQQ 
toFullScreenQQ #
;QQ# $
}RR 
}SS 	
privateUU 
ICommandUU 
toDownloadPageUU '
;UU' (
publicVV 
ICommandVV 
ToDownloadPageVV &
{WW 	
getXX 
{YY 
ifZZ 
(ZZ 
toDownloadPageZZ "
==ZZ# %
nullZZ& *
)ZZ* +
toDownloadPage[[ "
=[[# $
new[[% (
ActionCommand[[) 6
([[6 7
async[[7 <
([[= >
	parameter[[> G
)[[G H
=>[[I K
{\\ 
await]] 
Global]] $
.]]$ %
NavigationInstance]]% 7
.]]7 8
PushModalAsync]]8 F
(]]F G
new]]G J
	ModalPage]]K T
(]]T U
new]]U X
DownloadPage]]Y e
(]]e f
)]]f g
,]]g h
Localization]]i u
.]]u v
TitleDownloads	]]v �
)
]]� �
)
]]� �
;
]]� �
}^^ 
)^^ 
;^^ 
return`` 
toDownloadPage`` %
;``% &
}aa 
}bb 	
privatedd 
ICommanddd 
backCommanddd $
;dd$ %
publicee 
ICommandee 
BackCommandee #
{ff 	
getgg 
{hh 
ifii 
(ii 
backCommandii 
==ii  "
nullii# '
)ii' (
backCommandjj 
=jj  !
newjj" %
ActionCommandjj& 3
(jj3 4
asyncjj4 9
(jj: ;
	parameterjj; D
)jjD E
=>jjF H
{kk 
awaitll 
Globalll $
.ll$ %
NavigationInstancell% 7
.ll7 8
PopModalAsyncll8 E
(llE F
)llF G
;llG H
}mm 
)mm 
;mm 
returnoo 
backCommandoo "
;oo" #
}pp 
}qq 	
publictt 
ModalViewModeltt 
(tt 
Gridtt "
	containertt# ,
,tt, -
stringtt. 4
titlett5 :
,tt: ;
booltt< @
topPanelVisiblettA P
=ttQ R
truettS W
)ttW X
{uu 	

ModalTitlevv 
=vv 
titlevv 
;vv 
TopPanelVisibleww 
=ww 
topPanelVisibleww -
;ww- .
	Containerxx 
=xx 
	containerxx !
;xx! "
}yy 	
public}} 
void}} 
	Appearing}} 
(}} 
)}} 
{~~ 	
}
�� 	
public
�� 
void
�� 
Disappearing
��  
(
��  !
)
��! "
{
�� 	
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
Badge
�� 
=
��  
DownloadProcessing
�� &
.
��& '

BadgeCount
��' 1
.
��1 2
ToString
��2 :
(
��: ;
)
��; <
;
��< =
BadgeVisible
�� 
=
��  
DownloadProcessing
�� -
.
��- .

BadgeCount
��. 8
>
��9 :
$num
��; <
;
��< =
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
&&
��- /
	Container
��0 9
.
��9 :
Children
��: B
[
��B C
$num
��C D
]
��D E
is
��F H
ITimerContent
��I V
content
��W ^
)
��^ _
content
�� 
.
�� 
Tick
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� ğ
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\NormalViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
NormalViewModel  
:! "
PropertyChangedBase# 6
{ 
private 
readonly 

TracksPage #

tracksPage$ .
=/ 0
new1 4

TracksPage5 ?
(? @
)@ A
;A B
private 
readonly 

ArtistPage #

artistPage$ .
=/ 0
new1 4

ArtistPage5 ?
(? @
)@ A
;A B
private 
PlaylistPage 
playlistPage )
;) *
private 
SettingsPage 
settingsPage )
;) *
private 
string 
	pageTitle  
;  !
private 
string 
searchPlaceholder (
;( )
private 
bool 
badgeSyncVisible %
;% &
private   
string   
	badgeSync    
;    !
private!! 
bool!! 
badgeVisible!! !
;!!! "
private"" 
string"" 
badge"" 
;"" 
private## 
int## 
currentButtonIndex## &
=##' (
-##) *
$num##* +
;##+ ,
private$$ 
bool$$ 
titleVisible$$ !
=$$" #
true$$$ (
;$$( )
private%% 
bool%% 
entryVisible%% !
=%%" #
false%%$ )
;%%) *
private&& 
string&& 
	entryText&&  
;&&  !
private(( 
bool(( 
tracksButtonToggled(( (
;((( )
private)) 
bool))  
artistsButtonToggled)) )
;))) *
private** 
bool** "
playlistsButtonToggled** +
;**+ ,
private++ 
bool++ !
settingsButtonToggled++ *
;++* +
private,, 
PlayerPanel,, 
playerPanel,, '
;,,' (
private-- 
IDisposable-- 
loopSubscription-- ,
;--, -
private// 
bool// 
searchCancelVisible// (
;//( )
private00  
ObservableCollection00 $
<00$ %
HistoryModel00% 1
>001 2
suggestionItems003 B
;00B C
private11 
bool11 $
searchSuggestionsVisible11 -
=11. /
false110 5
;115 6
private22 
readonly22 
Entry22 
searchEntry22 *
;22* +
private33 
bool33 
spinnerVisible33 #
;33# $
public77 
string77 
	PageTitle77 
{88 	
get99 
=>99 
	pageTitle99 
;99 
set:: 
{;; 
	pageTitle<< 
=<< 
value<< !
;<<! "
OnPropertyChanged== !
(==! "
)==" #
;==# $
}>> 
}?? 	
publicAA 
boolAA 
BadgeSyncVisibleAA $
{BB 	
getCC 
=>CC 
badgeSyncVisibleCC #
;CC# $
setDD 
{EE 
badgeSyncVisibleFF  
=FF! "
valueFF# (
;FF( )
OnPropertyChangedGG !
(GG! "
)GG" #
;GG# $
}HH 
}II 	
publicKK 
stringKK 
	BadgeSyncKK 
{LL 	
getMM 
=>MM 
	badgeSyncMM 
;MM 
setNN 
{OO 
	badgeSyncPP 
=PP 
valuePP !
;PP! "
OnPropertyChangedQQ !
(QQ! "
)QQ" #
;QQ# $
}RR 
}SS 	
publicUU 
boolUU 
BadgeVisibleUU  
{VV 	
getWW 
=>WW 
badgeVisibleWW 
;WW  
setXX 
{YY 
badgeVisibleZZ 
=ZZ 
valueZZ $
;ZZ$ %
OnPropertyChanged[[ !
([[! "
)[[" #
;[[# $
}\\ 
}]] 	
public__ 
string__ 
Badge__ 
{`` 	
getaa 
=>aa 
badgeaa 
;aa 
setbb 
{cc 
badgedd 
=dd 
valuedd 
;dd 
OnPropertyChangedee !
(ee! "
)ee" #
;ee# $
}ff 
}gg 	
publicii 
Gridii 
	Containerii 
{ii 
getii  #
;ii# $
privateii% ,
setii- 0
;ii0 1
}ii2 3
publickk 
boolkk 
TracksButtonToggledkk '
{ll 	
getmm 
=>mm 
tracksButtonToggledmm &
;mm& '
setnn 
{oo 
tracksButtonToggledpp #
=pp$ %
valuepp& +
;pp+ ,
OnPropertyChangedqq !
(qq! "
)qq" #
;qq# $
}rr 
}ss 	
publicuu 
booluu  
ArtistsButtonToggleduu (
{vv 	
getww 
=>ww  
artistsButtonToggledww '
;ww' (
setxx 
{yy  
artistsButtonToggledzz $
=zz% &
valuezz' ,
;zz, -
OnPropertyChanged{{ !
({{! "
){{" #
;{{# $
}|| 
}}} 	
public 
bool "
PlaylistsButtonToggled *
{
�� 	
get
�� 
=>
�� $
playlistsButtonToggled
�� )
;
��) *
set
�� 
{
�� $
playlistsButtonToggled
�� &
=
��' (
value
��) .
;
��. /
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� #
SettingsButtonToggled
�� )
{
�� 	
get
�� 
=>
�� #
settingsButtonToggled
�� (
;
��( )
set
�� 
{
�� #
settingsButtonToggled
�� %
=
��& '
value
��( -
;
��- .
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
PlayerPanel
�� 
PlayerPanel
�� &
{
�� 	
get
�� 
=>
�� 
playerPanel
�� 
;
�� 
set
�� 
{
�� 
playerPanel
�� 
=
�� 
value
�� #
;
��# $
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
string
�� 
SearchPlaceholder
�� '
{
�� 	
get
�� 
=>
�� 
searchPlaceholder
�� $
;
��$ %
set
�� 
{
�� 
searchPlaceholder
�� !
=
��" #
value
��$ )
;
��) *
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
TitleVisible
��  
{
�� 	
get
�� 
=>
�� 
titleVisible
�� 
;
��  
set
�� 
{
�� 
titleVisible
�� 
=
�� 
value
�� $
;
��$ %
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
EntryVisible
��  
{
�� 	
get
�� 
=>
�� 
entryVisible
�� 
;
��  
set
�� 
{
�� 
entryVisible
�� 
=
�� 
value
�� $
;
��$ %
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
string
�� 
	EntryText
�� 
{
�� 	
get
�� 
=>
�� 
	entryText
�� 
;
�� 
set
�� 
{
�� 
	entryText
�� 
=
�� 
value
�� !
;
��! "
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $!
SearchCancelVisible
�� #
=
��$ %
	entryText
��& /
.
��/ 0
Length
��0 6
>
��7 8
$num
��9 :
;
��: ;
}
�� 
}
�� 	
public
�� 
bool
�� !
SearchCancelVisible
�� '
{
�� 	
get
�� 
=>
�� !
searchCancelVisible
�� &
;
��& '
set
�� 
{
�� !
searchCancelVisible
�� #
=
��$ %
value
��& +
;
��+ ,
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� "
ObservableCollection
�� #
<
��# $
HistoryModel
��$ 0
>
��0 1
SuggestionItems
��2 A
{
�� 	
get
�� 
=>
�� 
suggestionItems
�� "
;
��" #
set
�� 
{
�� 
suggestionItems
�� 
=
��  !
value
��" '
;
��' (
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� &
SearchSuggestionsVisible
�� ,
{
�� 	
get
�� 
=>
�� &
searchSuggestionsVisible
�� +
;
��+ ,
set
�� 
{
�� &
searchSuggestionsVisible
�� (
=
��) *
value
��+ 0
;
��0 1
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
SpinnerVisible
�� "
{
�� 	
get
�� 
=>
�� 
spinnerVisible
�� !
;
��! "
set
�� 
{
�� 
spinnerVisible
�� 
=
��  
value
��! &
;
��& '
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoPlayerCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoPlayer
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoPlayerCommand
�� %
==
��& (
null
��) -
)
��- .
gotoPlayerCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
async
��: ?
(
��@ A
	parameter
��A J
)
��J K
=>
��L N
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
!=
��; =
null
��> B
)
��B C
{
�� 
await
�� !
Global
��" (
.
��( ) 
NavigationInstance
��) ;
.
��; <
PushModalAsync
��< J
(
��J K
new
��K N
FullScreenPage
��O ]
(
��] ^
)
��^ _
)
��_ `
;
��` a
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoPlayerCommand
�� (
;
��( )
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoTracksCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoTracks
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoTracksCommand
�� %
==
��& (
null
��) -
)
��- .
gotoTracksCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
	parameter
��: C
=>
��D F
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
||
��4 6
(
��7 8
	parameter
��8 A
as
��B D
bool
��E I
?
��I J
)
��J K
==
��L N
true
��O S
)
��S T
{
�� 
SetContainer
�� (
(
��( )

tracksPage
��) 3
,
��3 4
Localization
��5 A
.
��A B
Tracks
��B H
)
��H I
;
��I J
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoTracksCommand
�� (
;
��( )
}
�� 
}
�� 	
private
�� 
ICommand
��  
gotoArtistsCommand
�� +
;
��+ ,
public
�� 
ICommand
�� 
GotoArtists
�� #
{
�� 	
get
�� 
{
�� 
if
�� 
(
��  
gotoArtistsCommand
�� &
==
��' )
null
��* .
)
��. / 
gotoArtistsCommand
�� &
=
��' (
new
��) ,
ActionCommand
��- :
(
��: ;
	parameter
��; D
=>
��E G
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
||
��4 6
(
��7 8
	parameter
��8 A
as
��B D
bool
��E I
?
��I J
)
��J K
==
��L N
true
��O S
)
��S T
{
�� 
SetContainer
�� (
(
��( )

artistPage
��) 3
,
��3 4
Localization
��5 A
.
��A B
Artists
��B I
)
��I J
;
��J K
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
��  
gotoArtistsCommand
�� )
;
��) *
}
�� 
}
�� 	
private
�� 
ICommand
�� "
gotoPlaylistsCommand
�� -
;
��- .
public
�� 
ICommand
�� 
GotoPlaylists
�� %
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� "
gotoPlaylistsCommand
�� (
==
��) +
null
��, 0
)
��0 1"
gotoPlaylistsCommand
�� (
=
��) *
new
��+ .
ActionCommand
��/ <
(
��< =
	parameter
��= F
=>
��G I
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
)
��3 4
{
�� 
if
�� 
(
��  
playlistPage
��  ,
==
��- /
null
��0 4
)
��4 5
playlistPage
��  ,
=
��- .
new
��/ 2
PlaylistPage
��3 ?
(
��? @
)
��@ A
;
��A B
SetContainer
�� (
(
��( )
playlistPage
��) 5
,
��5 6
Localization
��7 C
.
��C D
	Playlists
��D M
)
��M N
;
��N O
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
�� "
gotoPlaylistsCommand
�� +
;
��+ ,
}
�� 
}
�� 	
private
�� 
ICommand
�� !
gotoSettingsCommand
�� ,
;
��, -
public
�� 
ICommand
�� 
GotoSettings
�� $
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� !
gotoSettingsCommand
�� '
==
��( *
null
��+ /
)
��/ 0!
gotoSettingsCommand
�� '
=
��( )
new
��* -
ActionCommand
��. ;
(
��; <
	parameter
��< E
=>
��F H
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
)
��3 4
{
�� 
if
�� 
(
��  
settingsPage
��  ,
==
��- /
null
��0 4
)
��4 5
settingsPage
��  ,
=
��- .
new
��/ 2
SettingsPage
��3 ?
(
��? @
)
��@ A
;
��A B
SetContainer
�� (
(
��( )
settingsPage
��) 5
,
��5 6
Localization
��7 C
.
��C D
Settings
��D L
)
��L M
;
��M N
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
�� !
gotoSettingsCommand
�� *
;
��* +
}
�� 
}
�� 	
private
�� 
ICommand
�� !
gotoDownloadCommand
�� ,
;
��, -
public
�� 
ICommand
�� 
GotoDownload
�� $
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� !
gotoDownloadCommand
�� '
==
��( *
null
��+ /
)
��/ 0!
gotoDownloadCommand
�� '
=
��( )
new
��* -
ActionCommand
��. ;
(
��; <
async
��< A
(
��B C
	parameter
��C L
)
��L M
=>
��N P
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X
DownloadPage
��Y e
(
��e f
)
��f g
,
��g h
Localization
��i u
.
��u v
TitleDownloads��v �
)��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� !
gotoDownloadCommand
�� *
;
��* +
}
�� 
}
�� 	
private
�� 
ICommand
��  
clearSearchCommand
�� +
;
��+ ,
public
�� 
ICommand
�� 
ClearSearchText
�� '
{
�� 	
get
�� 
{
�� 
if
�� 
(
��  
clearSearchCommand
�� &
==
��' )
null
��* .
)
��. / 
clearSearchCommand
�� &
=
��' (
new
��) ,
ActionCommand
��- :
(
��: ;
	parameter
��; D
=>
��E G
{
�� 
searchEntry
�� #
.
��# $
Unfocus
��$ +
(
��+ ,
)
��, -
;
��- .
	EntryText
�� !
=
��" #
$str
��$ &
;
��& '
}
�� 
)
�� 
;
�� 
return
��  
clearSearchCommand
�� )
;
��) *
}
�� 
}
�� 	
public
�� 
NormalViewModel
�� 
(
�� 
Grid
�� #
	container
��$ -
,
��- .
PlayerPanel
��/ :
panel
��; @
,
��@ A
Entry
��B G
searchEntry
��H S
)
��S T
{
�� 	
this
�� 
.
�� 
searchEntry
�� 
=
�� 
searchEntry
�� *
;
��* +
SuggestionItems
�� 
=
�� 
new
�� !"
ObservableCollection
��" 6
<
��6 7
HistoryModel
��7 C
>
��C D
(
��D E
)
��E F
;
��F G
	Container
�� 
=
�� 
	container
�� !
;
��! "
PlayerPanel
�� 
=
�� 
panel
�� 
;
��  
SpinnerVisible
�� 
=
�� 
true
�� !
;
��! "
	Directory
�� 
.
�� 
CreateDirectory
�� %
(
��% &

GlobalData
��& 0
.
��0 1
Current
��1 8
.
��8 9
	MusicPath
��9 B
)
��B C
;
��C D
GotoArtists
�� 
.
�� 
Execute
�� 
(
��  
true
��  $
)
��$ %
;
��% &
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
Loaded
�� 
)
�� 
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadTags
��# +
(
��+ ,
)
��, -
;
��- .

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadSavedTracks
��# 2
(
��2 3
)
��3 4
;
��4 5
Task
�� 
task
�� 
=
�� 
Task
��  
.
��  !
Run
��! $
(
��$ %
async
��% *
(
��* +
)
��+ ,
=>
��- /
{
�� 
if
�� 
(
�� 
CacheLoader
�� #
.
��# $
IsCacheAvailable
��$ 4
(
��4 5
)
��5 6
)
��6 7
CacheLoader
�� #
.
��# $
	LoadCache
��$ -
(
��- .
)
��. /
;
��/ 0
await
�� 
GlobalLoader
�� &
.
��& '
Load
��' +
(
��+ ,
)
��, -
;
��- .
}
�� 
)
�� 
;
�� 
task
�� 
.
�� 
ContinueWith
�� !
(
��! "
t
��" #
=>
��$ &
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

LoadConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Loaded
�� !
=
��" #
true
��$ (
;
��( )
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
AutoDownload
��+ 7
&&
��8 :
Global
��; A
.
��A B
Application
��B M
.
��M N
HasInternet
��N Y
(
��Y Z
)
��Z [
)
��[ \
{
�� 
Task
�� 
.
�� 
Run
��  
(
��  !
async
��! &
(
��' (
)
��( )
=>
��* ,
{
�� 
YoutubeClient
�� )
client
��* 0
=
��1 2
new
��3 6
YoutubeClient
��7 D
(
��D E
)
��E F
;
��F G
foreach
�� #
(
��$ %
var
��% (
key
��) ,
in
��- /

GlobalData
��0 :
.
��: ;
Current
��; B
.
��B C!
WebToLocalPlaylists
��C V
.
��V W
Keys
��W [
.
��[ \
ToList
��\ b
(
��b c
)
��c d
)
��d e
{
�� 
if
��  "
(
��# $

GlobalData
��$ .
.
��. /
Current
��/ 6
.
��6 7
	Playlists
��7 @
.
��@ A
ContainsKey
��A L
(
��L M

GlobalData
��M W
.
��W X
Current
��X _
.
��_ `!
WebToLocalPlaylists
��` s
[
��s t
key
��t w
]
��w x
)
��x y
)
��y z 
DownloadProcessing
��$ 6
.
��6 7
AddRange
��7 ?
(
��? @
await
��@ E
client
��F L
.
��L M
	Playlists
��M V
.
��V W
GetVideosAsync
��W e
(
��e f
key
��f i
)
��i j
,
��j k

GlobalData
��l v
.
��v w
Current
��w ~
.
��~ "
WebToLocalPlaylists�� �
[��� �
key��� �
]��� �
,��� �
key��� �
,��� �
true��� �
)��� �
;��� �
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
	Appearing
�� 
(
�� 
)
�� 
{
�� 	
var
�� 
src
�� 
=
�� 
System
�� 
.
�� 
Reactive
�� %
.
��% &
Linq
��& *
.
��* +

Observable
��+ 5
.
��5 6
Timer
��6 ;
(
��; <
TimeSpan
��< D
.
��D E
Zero
��E I
,
��I J
TimeSpan
��K S
.
��S T
FromMilliseconds
��T d
(
��d e
$num
��e h
)
��h i
)
��i j
.
��j k
	Timestamp
��k t
(
��t u
)
��u v
;
��v w
loopSubscription
�� 
=
�� 
src
�� "
.
��" #
	Subscribe
��# ,
(
��, -
time
��- 1
=>
��2 4
Tick
��5 9
(
��9 :
)
��: ;
)
��; <
;
��< =
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
&&
��- /
	Container
��0 9
.
��9 :
Children
��: B
[
��B C
$num
��C D
]
��D E
is
��F H
IVisibleContent
��I X
)
��X Y
(
�� 
	Container
�� 
.
�� 
Children
�� #
[
��# $
$num
��$ %
]
��% &
as
��' )
IVisibleContent
��* 9
)
��9 :
.
��: ;
	Appearing
��; D
(
��D E
)
��E F
;
��F G
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
Audios
��# )
.
��) *
Count
��* /
==
��0 2
$num
��3 4
&&
��5 7

GlobalData
��8 B
.
��B C
Current
��C J
.
��J K
SavedTracks
��K V
.
��V W
Count
��W \
==
��] _
$num
��` a
)
��a b
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadTags
��# +
(
��+ ,
)
��, -
;
��- .
CacheLoader
�� 
.
�� 
	LoadCache
�� %
(
��% &
)
��& '
;
��' (

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadSavedTracks
��# 2
(
��2 3
)
��3 4
;
��4 5

GlobalData
�� 
.
�� 
Current
�� "
.
��" #

LoadConfig
��# -
(
��- .
)
��. /
;
��/ 0
}
�� 
}
�� 	
public
�� 
void
�� 
Disappearing
��  
(
��  !
)
��! "
{
�� 	
loopSubscription
�� 
?
�� 
.
�� 
Dispose
�� %
(
��% &
)
��& '
;
��' (
loopSubscription
�� 
=
�� 
null
�� #
;
��# $
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
SearchPlaceholder
�� 
=
�� 
Localization
��  ,
.
��, -
Search
��- 3
;
��3 4
Badge
�� 
=
��  
DownloadProcessing
�� &
.
��& '

BadgeCount
��' 1
.
��1 2
ToString
��2 :
(
��: ;
)
��; <
;
��< =
BadgeVisible
�� 
=
��  
DownloadProcessing
�� -
.
��- .

BadgeCount
��. 8
>
��9 :
$num
��; <
;
��< =
SpinnerVisible
�� 
=
�� 
	Container
�� &
.
��& '
Children
��' /
.
��/ 0
Count
��0 5
==
��6 8
$num
��9 :
||
��; =
!
��> ?
Global
��? E
.
��E F
Loaded
��F L
;
��L M
PlayerPanel
�� 
?
�� 
.
�� 
Tick
�� 
(
�� 
)
�� 
;
��  
foreach
�� 
(
�� 
var
�� 
children
�� !
in
��" $
	Container
��% .
.
��. /
Children
��/ 7
.
��7 8
ToList
��8 >
(
��> ?
)
��? @
)
��@ A
{
�� 
if
�� 
(
�� 
children
�� 
.
�� 
	IsVisible
�� &
&&
��' )
children
��* 2
is
��3 5
ITimerContent
��6 C
content
��D K
)
��K L
content
�� 
.
�� 
Tick
��  
(
��  !
)
��! "
;
��" #
}
�� 
}
�� 	
public
�� 
void
�� 
RefreshSuggestion
�� %
(
��% &
)
��& '
{
�� 	
string
�� 
searchedText
�� 
=
��  !
	EntryText
��" +
??
��, .
$str
��/ 1
;
��1 2
var
�� 
newList
�� 
=
�� 
SearchProcessing
�� *
.
��* +'
GenerateSearchSuggestions
��+ D
(
��D E
)
��E F
.
��F G
FindAll
��G N
(
��N O
item
�� 
=>
�� 
searchedText
�� $
.
��$ %
ToLowerInvariant
��% 5
(
��5 6
)
��6 7
.
��7 8
Contains
��8 @
(
��@ A
item
��A E
.
��E F
ToLowerInvariant
��F V
(
��V W
)
��W X
)
��X Y
||
��Z \
item
��] a
.
��a b
ToLowerInvariant
��b r
(
��r s
)
��s t
.
��t u
Contains
��u }
(
��} ~
searchedText��~ �
.��� � 
ToLowerInvariant��� �
(��� �
)��� �
)��� �
)��� �
;��� �
SuggestionItems
�� 
.
�� 
Clear
�� !
(
��! "
)
��" #
;
��# $
foreach
�� 
(
�� 
var
�� 
item
�� 
in
��  
newList
��! (
)
��( )
{
�� 
SuggestionItems
�� 
.
��  
Add
��  #
(
��# $
new
��$ '
HistoryModel
��( 4
(
��4 5
)
��5 6
{
��7 8
Text
��9 =
=
��> ?
item
��@ D
}
��E F
)
��F G
;
��G H
}
�� 
}
�� 	
public
�� 
async
�� 
void
�� %
SuggestionItem_Selected
�� 1
(
��1 2
object
��2 8
sender
��9 ?
,
��? @*
SelectedItemChangedEventArgs
��A ]
e
��^ _
)
��_ `
{
�� 	
int
�� 
index
�� 
=
�� 
e
�� 
.
�� 
SelectedItemIndex
�� +
;
��+ ,
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� #
<
��$ %
SuggestionItems
��& 5
.
��5 6
Count
��6 ;
)
��; <
{
�� 
if
�� 
(
�� 
Global
�� 
.
�� 
Application
�� &
.
��& '
HasInternet
��' 2
(
��2 3
)
��3 4
)
��4 5
await
�� 
Global
��  
.
��  ! 
NavigationInstance
��! 3
.
��3 4
PushModalAsync
��4 B
(
��B C
new
��C F
	ModalPage
��G P
(
��P Q
new
��Q T
SearchResultPage
��U e
(
��e f
SuggestionItems
��f u
[
��u v
index
��v {
]
��{ |
.
��| }
Text��} �
)��� �
,��� �
SuggestionItems��� �
[��� �
index��� �
]��� �
.��� �
Text��� �
)��� �
)��� �
;��� �
else
�� 
await
�� 
Global
��  
.
��  !
Page
��! %
.
��% &
DisplayAlert
��& 2
(
��2 3
Localization
��3 ?
.
��? @
Warning
��@ G
,
��G H
Localization
��I U
.
��U V
NoConnection
��V b
,
��b c
Localization
��d p
.
��p q
Cancel
��q w
)
��w x
;
��x y
(
�� 
sender
�� 
as
�� 
ListView
�� #
)
��# $
.
��$ %
SelectedItem
��% 1
=
��2 3
null
��4 8
;
��8 9
}
�� 
}
�� 	
private
�� 
void
�� 
Toggle
�� 
(
�� 
int
�� 
buttonIndex
��  +
=
��, -
$num
��. /
)
��/ 0
{
�� 	!
TracksButtonToggled
�� 
=
��  !
buttonIndex
��" -
==
��. 0
$num
��1 2
;
��2 3"
ArtistsButtonToggled
��  
=
��! "
buttonIndex
��# .
==
��/ 1
$num
��2 3
;
��3 4$
PlaylistsButtonToggled
�� "
=
��# $
buttonIndex
��% 0
==
��1 3
$num
��4 5
;
��5 6#
SettingsButtonToggled
�� !
=
��" #
buttonIndex
��$ /
==
��0 2
$num
��3 4
;
��4 5 
currentButtonIndex
�� 
=
��  
buttonIndex
��! ,
;
��, -
}
�� 	
private
�� 
void
�� 
SetContainer
�� !
(
��! "
ContentView
��" -
content
��. 5
,
��5 6
string
��7 =
title
��> C
)
��C D
{
�� 	
if
�� 
(
�� 
!
�� 
	Container
�� 
.
�� 
Children
�� #
.
��# $
Contains
��$ ,
(
��, -
content
��- 4
)
��4 5
)
��5 6
	Container
�� 
.
�� 
Children
�� "
.
��" #
Add
��# &
(
��& '
content
��' .
)
��. /
;
��/ 0
else
�� 
{
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Remove
��# )
(
��) *
content
��* 1
)
��1 2
;
��2 3
	Container
�� 
.
�� 
Children
�� "
.
��" #
Add
��# &
(
��& '
content
��' .
)
��. /
;
��/ 0
}
�� 
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
)
��, -
{
�� 
foreach
�� 
(
�� 
var
�� 
children
�� %
in
��& (
	Container
��) 2
.
��2 3
Children
��3 ;
)
��; <
{
�� 
if
�� 
(
�� 
children
��  
.
��  !
	IsVisible
��! *
)
��* +
{
�� 
if
�� 
(
�� 
children
�� $
is
��% '
IVisibleContent
��( 7
)
��7 8
(
�� 
children
�� %
as
��& (
IVisibleContent
��) 8
)
��8 9
.
��9 :
Disappearing
��: F
(
��F G
)
��G H
;
��H I
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
false
��- 2
;
��2 3
}
�� 
if
�� 
(
�� 
children
��  
==
��! #
content
��$ +
)
��+ ,
{
�� 
if
�� 
(
�� 
children
�� $
is
��% '
IVisibleContent
��( 7
)
��7 8
(
�� 
children
�� %
as
��& (
IVisibleContent
��) 8
)
��8 9
.
��9 :
	Appearing
��: C
(
��C D
)
��D E
;
��E F
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
true
��- 1
;
��1 2
}
�� 
else
�� 
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
false
��- 2
;
��2 3
}
�� 
}
�� 
	PageTitle
�� 
=
�� 
title
�� 
;
�� 
}
�� 	
}
�� 
}�� �
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\PermissionViewModel.cs
	namespace		 	
Newtone		
 
.		 
Mobile		 
.		 
UI		 
.		 

ViewModels		 &
{

 
public 

class 
PermissionViewModel $
{ 
private 
ICommand 
grant 
; 
public 
ICommand 
Grant 
{ 	
get 
{ 
if 
( 
grant 
== 
null !
)! "
grant 
= 
new 
ActionCommand  -
(- .
	parameter. 7
=>8 :
{ 
System 
. 
Diagnostics *
.* +
Debug+ 0
.0 1
	WriteLine1 :
(: ;
$str; M
)M N
;N O
Global 
. 
Permissions *
.* +
Request+ 2
(2 3
)3 4
;4 5
} 
) 
; 
return 
grant 
; 
} 
} 	
public 
PermissionViewModel "
(" #
)# $
{ 	
Device   
.   

StartTimer   
(   
TimeSpan   &
.  & '
FromSeconds  ' 2
(  2 3
$num  3 6
)  6 7
,  7 8
Check  9 >
)  > ?
;  ? @
}!! 	
private$$ 
bool$$ 
Check$$ 
($$ 
)$$ 
{%% 	
if&& 
(&& 
Global&& 
.&& 
Permissions&& "
.&&" #
IsValid&&# *
(&&* +
)&&+ ,
)&&, -
{'' 

GlobalData(( 
.(( 
Current(( "
.((" #

SaveConfig((# -
(((- .
)((. /
;((/ 0
if** 
(** 
Global** 
.** 
TV** 
)** 
{++ 
App,, 
.,, 
Instance,,  
.,,  !
MainPage,,! )
=,,* +
new,,, /
Views,,0 5
.,,5 6
TV,,6 8
.,,8 9

NormalPage,,9 C
(,,C D
),,D E
;,,E F
}-- 
else.. 
{// 
App00 
.00 
Instance00  
.00  !
MainPage00! )
=00* +
new00, /

NormalPage000 :
(00: ;
)00; <
;00< =
}11 
Task33 
.33 
Run33 
(33 
async33 
(33  
)33  !
=>33" $
{33% &
await44 
PopToRootAsync44 (
(44( )
)44) *
;44* +
}55 
)55 
.55 
Wait55 
(55 
)55 
;55 
return77 
false77 
;77 
}88 
else99 
{:: 
return;; 
true;; 
;;; 
}<< 
}== 	
private?? 
async?? 
Task?? 
PopToRootAsync?? )
(??) *
)??* +
{@@ 	
whileAA 
(AA 
AppAA 
.AA 
InstanceAA 
.AA  
MainPageAA  (
.AA( )

NavigationAA) 3
.AA3 4

ModalStackAA4 >
.AA> ?
CountAA? D
>AAE F
$numAAG H
)AAH I
{BB 
awaitCC 
AppCC 
.CC 
InstanceCC "
.CC" #
MainPageCC# +
.CC+ ,

NavigationCC, 6
.CC6 7
PopModalAsyncCC7 D
(CCD E
falseCCE J
)CCJ K
;CCK L
}DD 
}EE 	
}HH 
}II �.
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\PlaylistViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
PlaylistViewModel "
{ 
public  
ObservableCollection #
<# $
PlaylistModel$ 1
>1 2
Items3 8
{9 :
get; >
;> ?
private@ G
setH K
;K L
}M N
public  
ObservableCollection #
<# $
NListViewItem$ 1
>1 2
	ListItems3 <
{= >
get? B
;B C
privateD K
setL O
;O P
}Q R
public 
Func 
< 
NListViewItem !
,! "
View# '
>' (
ItemTemplate) 5
{ 	
get 
{ 
return 
item 
=> 
new "
Views# (
.( )
TV) +
.+ ,
	ViewCells, 5
.5 6
PlaylistGridItem6 F
(F G
itemG K
)K L
;L M
} 
} 	
public 
bool 
IsInitializing "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
PlaylistViewModel  
(  !
)! "
{ 	
Items   
=   
new    
ObservableCollection   ,
<  , -
PlaylistModel  - :
>  : ;
(  ; <
)  < =
;  = >
	ListItems!! 
=!! 
new!!  
ObservableCollection!! 0
<!!0 1
NListViewItem!!1 >
>!!> ?
(!!? @
)!!@ A
;!!A B

Initialize"" 
("" 
)"" 
;"" 
}## 	
public&& 
void&& 

Initialize&& 
(&& 
)&&  
{'' 	
IsInitializing(( 
=(( 
true(( !
;((! "
Items)) 
.)) 
Clear)) 
()) 
))) 
;)) 
	ListItems** 
.** 
Clear** 
(** 
)** 
;** 
List++ 
<++ 
string++ 
>++ 

beforeSort++ #
=++$ %
new++& )
List++* .
<++. /
string++/ 5
>++5 6
(++6 7
)++7 8
;++8 9
foreach-- 
(-- 
string-- 
playlist-- $
in--% '

GlobalData--( 2
.--2 3
Current--3 :
.--: ;
	Playlists--; D
.--D E
Keys--E I
)--I J
{.. 

beforeSort// 
.// 
Add// 
(// 
playlist// '
)//' (
;//( )
}00 
List22 
<22 
string22 
>22 
	afterSort22 "
=22# $

beforeSort22% /
.22/ 0
OrderBy220 7
(227 8
o228 9
=>22: <
o22= >
)22> ?
.22? @
ToList22@ F
(22F G
)22G H
;22H I
foreach44 
(44 
var44 
playlistName44 %
in44& (
	afterSort44) 2
)442 3
{55 
ImageSource66 
image66 !
=66" #
ImageSource66$ /
.66/ 0
FromFile660 8
(668 9
$str669 I
)66I J
;66J K
foreach77 
(77 
string77 
filePath77  (
in77) +

GlobalData77, 6
.776 7
Current777 >
.77> ?
	Playlists77? H
[77H I
playlistName77I U
]77U V
)77V W
{88 
MediaSource99 
source99  &
=99' (
null99) -
;99- .
if:: 
(:: 
filePath::  
.::  !
Length::! '
==::( *
$num::+ -
)::- .
source;; 
=;;  

GlobalData;;! +
.;;+ ,
Current;;, 3
.;;3 4
SavedTracks;;4 ?
[;;? @
filePath;;@ H
];;H I
;;;I J
else<< 
source== 
===  

GlobalData==! +
.==+ ,
Current==, 3
.==3 4
Audios==4 :
[==: ;
filePath==; C
]==C D
;==D E
if>> 
(>> 
source>> 
.>> 
Image>> $
!=>>% '
null>>( ,
)>>, -
{?? 
image@@ 
=@@ 
ImageProcessing@@  /
.@@/ 0
	FromArray@@0 9
(@@9 :
source@@: @
.@@@ A
Image@@A F
)@@F G
;@@G H
breakAA 
;AA 
}BB 
}CC 
ItemsEE 
.EE 
AddEE 
(EE 
newEE 
PlaylistModelEE +
(EE+ ,
)EE, -
{EE. /
ImageEE0 5
=EE6 7
imageEE8 =
,EE= >
NameEE? C
=EED E
playlistNameEEF R
,EER S

TrackCountEET ^
=EE_ `

GlobalDataEEa k
.EEk l
CurrentEEl s
.EEs t
	PlaylistsEEt }
[EE} ~
playlistName	EE~ �
]
EE� �
.
EE� �
Count
EE� �
}
EE� �
)
EE� �
;
EE� �
	ListItemsFF 
.FF 
AddFF 
(FF 
ItemsFF #
[FF# $
ItemsFF$ )
.FF) *
CountFF* /
-FF0 1
$numFF2 3
]FF3 4
)FF4 5
;FF5 6
}GG 
IsInitializingHH 
=HH 
falseHH "
;HH" #
}II 	
}KK 
}LL Ǥ
LD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\SearchResultViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class !
SearchResultViewModel &
:' (
PropertyChangedBase) <
{ 
private  
ObservableCollection $
<$ %
Models% +
.+ ,
SearchResultModel, =
>= >
items? D
;D E
private 
readonly 
ObservableBridge )
<) *
Newtone* 1
.1 2
Core2 6
.6 7
Models7 =
.= >
SearchResultModel> O
>O P
rawItemsQ Y
;Y Z
private 
int 
currentPage 
=  !
$num" #
;# $
private 
bool 

pageLoaded 
=  !
false" '
;' (
private 
readonly 
string 
searchedText  ,
;, -
private 
bool 
spinnerVisible #
=$ %
false& +
;+ ,
private 
int 
maxItems 
; 
public""  
ObservableCollection"" #
<""# $
Models""$ *
.""* +
SearchResultModel""+ <
>""< =
Items""> C
{## 	
get$$ 
=>$$ 
items$$ 
;$$ 
set%% 
{&& 
items'' 
='' 
value'' 
;'' 
OnPropertyChanged(( !
(((! "
)((" #
;((# $
})) 
}** 	
public,, 
bool,, 
SpinnerVisible,, "
{-- 	
get.. 
=>.. 
spinnerVisible.. !
;..! "
set// 
{00 
spinnerVisible11 
=11  
value11! &
;11& '
OnPropertyChanged22 !
(22! "
)22" #
;22# $
}33 
}44 	
public66  
ObservableCollection66 #
<66# $
NListViewItem66$ 1
>661 2
	ListItems663 <
{66= >
get66? B
;66B C
private66D K
set66L O
;66O P
}66Q R
public77 
Func77 
<77 
NListViewItem77 !
,77! "
View77# '
>77' (
ItemTemplate77) 5
=>776 8
item779 =
=>77> @
new77A D 
SearchResultViewCell77E Y
(77Y Z
item77Z ^
)77^ _
;77_ `
private:: 
ICommand::  
itemAppearingCommand:: -
;::- .
public;; 
ICommand;; 
ItemAppearing;; %
{<< 	
get== 
{>> 
if?? 
(??  
itemAppearingCommand?? (
==??) +
null??, 0
)??0 1 
itemAppearingCommand@@ (
=@@) *
new@@+ .
ActionCommand@@/ <
(@@< =
	parameter@@= F
=>@@G I
{AA 
intBB 
	itemIndexBB %
=BB& '
(BB( )
intBB) ,
)BB, -
	parameterBB- 6
;BB6 7
ifDD 
(DD 

pageLoadedDD &
&&DD' )
	itemIndexDD* 3
==DD4 6
ItemsDD7 <
.DD< =
CountDD= B
-DDC D
$numDDE F
&&DDG I
(DDJ K
maxItemsDDK S
==DDT V
-DDW X
$numDDX Y
||DDZ \
ItemsDD] b
.DDb c
CountDDc h
<DDi j
maxItemsDDk s
)DDs t
)DDt u
{EE 

pageLoadedFF &
=FF' (
falseFF) .
;FF. /
currentPageGG '
++GG' )
;GG) *
TaskII  
.II  !
RunII! $
(II$ %
asyncII% *
(II+ ,
)II, -
=>II. 0
{JJ 
SpinnerVisibleKK  .
=KK/ 0
trueKK1 5
;KK5 6
ifLL  "
(LL# $
GlobalLL$ *
.LL* +
ApplicationLL+ 6
.LL6 7
HasInternetLL7 B
(LLB C
)LLC D
)LLD E
maxItemsMM$ ,
=MM- .
awaitMM/ 4
SearchProcessingMM5 E
.MME F
SearchMMF L
(MML M
searchedTextMMM Y
,MMY Z
rawItemsMM[ c
,MMc d
currentPageMMe p
)MMp q
;MMq r
usingOO  %
(OO& '
	WebClientOO' 0
	webClientOO1 :
=OO; <
newOO= @
	WebClientOOA J
(OOJ K
)OOK L
)OOL M
{PP  !
forQQ$ '
(QQ( )
intQQ) ,
aQQ- .
=QQ/ 0
$numQQ1 2
;QQ2 3
aQQ4 5
<QQ6 7
ItemsQQ8 =
.QQ= >
CountQQ> C
;QQC D
aQQE F
++QQF H
)QQH I
{RR$ %
ifSS( *
(SS+ ,
!SS, -
stringSS- 3
.SS3 4
IsNullOrEmptySS4 A
(SSA B
ItemsSSB G
[SSG H
aSSH I
]SSI J
.SSJ K
ThumbUrlSSK S
)SSS T
)SST U
{TT( )
byteUU, 0
[UU0 1
]UU1 2
dataUU3 7
=UU8 9
	webClientUU: C
.UUC D
DownloadDataUUD P
(UUP Q
ItemsUUQ V
[UUV W
aUUW X
]UUX Y
.UUY Z
ThumbUrlUUZ b
)UUb c
;UUc d
ItemsVV, 1
[VV1 2
aVV2 3
]VV3 4
.VV4 5
ImageVV5 :
=VV; <
dataVV= A
;VVA B
}WW( )
elseXX( ,
{YY( )
ItemsZZ, 1
[ZZ1 2
aZZ2 3
]ZZ3 4
.ZZ4 5
ThumbZZ5 :
=ZZ; <
ImageProcessingZZ= L
.ZZL M
	FromArrayZZM V
(ZZV W
ItemsZZW \
[ZZ\ ]
aZZ] ^
]ZZ^ _
.ZZ_ `
ImageZZ` e
)ZZe f
;ZZf g
}[[( )
Items\\( -
[\\- .
a\\. /
]\\/ 0
.\\0 1
CheckChanges\\1 =
(\\= >
)\\> ?
;\\? @
}]]$ %

pageLoaded__$ .
=__/ 0
true__1 5
;__5 6
}``  !
SpinnerVisiblebb  .
=bb/ 0
falsebb1 6
;bb6 7
}cc 
)cc 
;cc 
}dd 
}ee 
)ee 
;ee 
returngg  
itemAppearingCommandgg +
;gg+ ,
}hh 
}ii 	
publicll !
SearchResultViewModelll $
(ll$ %
stringll% +
searchedTextll, 8
)ll8 9
{mm 	
thisnn 
.nn 
searchedTextnn 
=nn 
searchedTextnn  ,
;nn, -
Itemsoo 
=oo 
newoo  
ObservableCollectionoo ,
<oo, -
Modelsoo- 3
.oo3 4
SearchResultModeloo4 E
>ooE F
(ooF G
)ooG H
;ooH I
	ListItemspp 
=pp 
newpp  
ObservableCollectionpp 0
<pp0 1
NListViewItempp1 >
>pp> ?
(pp? @
)pp@ A
;ppA B
rawItemsrr 
=rr 
newrr 
ObservableBridgerr +
<rr+ ,
Newtonerr, 3
.rr3 4
Corerr4 8
.rr8 9
Modelsrr9 ?
.rr? @
SearchResultModelrr@ Q
>rrQ R
{ss 
Actiontt 
=tt 
modeltt 
=>tt !
{uu 
Devicevv 
.vv #
BeginInvokeOnMainThreadvv 2
(vv2 3
(vv3 4
)vv4 5
=>vv6 8
{ww 
Itemsxx 
.xx 
Addxx !
(xx! "
newxx" %
Modelsxx& ,
.xx, -
SearchResultModelxx- >
(xx> ?
modelxx? D
)xxD E
)xxE F
;xxF G
	ListItemsyy !
.yy! "
Addyy" %
(yy% &
Itemsyy& +
[yy+ ,
^yy, -
$numyy- .
]yy. /
)yy/ 0
;yy0 1
}zz 
)zz 
;zz 
}{{ 
}|| 
;|| 
Task~~ 
.~~ 
Run~~ 
(~~ 
async~~ 
(~~ 
)~~ 
=>~~  
{ 
SpinnerVisible
�� 
=
��  
true
��! %
;
��% &
SearchProcessing
��  
.
��  !
SearchOffline
��! .
(
��. /
searchedText
��/ ;
,
��; <
rawItems
��= E
)
��E F
;
��F G
if
�� 
(
�� 
Global
�� 
.
�� 
Application
�� &
.
��& '
HasInternet
��' 2
(
��2 3
)
��3 4
)
��4 5
maxItems
�� 
=
�� 
await
�� $
SearchProcessing
��% 5
.
��5 6
Search
��6 <
(
��< =
searchedText
��= I
,
��I J
rawItems
��K S
)
��S T
;
��T U
using
�� 
(
�� 
	WebClient
��  
	webClient
��! *
=
��+ ,
new
��- 0
	WebClient
��1 :
(
��: ;
)
��; <
)
��< =
{
�� 
for
�� 
(
�� 
int
�� 
a
�� 
=
��  
$num
��! "
;
��" #
a
��$ %
<
��& '
Items
��( -
.
��- .
Count
��. 3
;
��3 4
a
��5 6
++
��6 8
)
��8 9
{
�� 
if
�� 
(
�� 
!
�� 
string
�� #
.
��# $
IsNullOrEmpty
��$ 1
(
��1 2
Items
��2 7
[
��7 8
a
��8 9
]
��9 :
.
��: ;
ThumbUrl
��; C
)
��C D
)
��D E
{
�� 
byte
��  
[
��  !
]
��! "
data
��# '
=
��( )
	webClient
��* 3
.
��3 4
DownloadData
��4 @
(
��@ A
Items
��A F
[
��F G
a
��G H
]
��H I
.
��I J
ThumbUrl
��J R
)
��R S
;
��S T
Items
�� !
[
��! "
a
��" #
]
��# $
.
��$ %
Image
��% *
=
��+ ,
data
��- 1
;
��1 2
}
�� 
else
�� 
{
�� 
if
�� 
(
��  
Items
��  %
[
��% &
a
��& '
]
��' (
.
��( )
Image
��) .
==
��/ 1
null
��2 6
||
��7 9
Items
��: ?
[
��? @
a
��@ A
]
��A B
.
��B C
Image
��C H
.
��H I
Length
��I O
>
��P Q
$num
��R S
)
��S T
Items
��  %
[
��% &
a
��& '
]
��' (
.
��( )
Thumb
��) .
=
��/ 0
ImageProcessing
��1 @
.
��@ A
	FromArray
��A J
(
��J K
Items
��K P
[
��P Q
a
��Q R
]
��R S
.
��S T
Image
��T Y
)
��Y Z
;
��Z [
else
��  
Items
��  %
[
��% &
a
��& '
]
��' (
.
��( )
Thumb
��) .
=
��/ 0
ImageSource
��1 <
.
��< =
FromFile
��= E
(
��E F
$str
��F V
)
��V W
;
��W X
}
�� 
Items
�� 
[
�� 
a
�� 
]
��  
.
��  !
CheckChanges
��! -
(
��- .
)
��. /
;
��/ 0
Device
�� 
.
�� %
BeginInvokeOnMainThread
�� 6
(
��6 7
(
��7 8
)
��8 9
=>
��: <
{
�� 
if
�� 
(
�� 
a
��  
<
��! "
Items
��# (
.
��( )
Count
��) .
)
��. /
{
�� 
	ListItems
��  )
[
��) *
a
��* +
]
��+ ,
=
��- .
Items
��/ 4
[
��4 5
a
��5 6
]
��6 7
;
��7 8
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 

pageLoaded
�� 
=
��  
true
��! %
;
��% &
}
�� 
SpinnerVisible
�� 
=
��  
false
��! &
;
��& '
}
�� 
)
�� 
;
�� 
}
�� 	
public
�� 
async
�� 
Task
�� 
Item_Selected
�� '
(
��' (
object
��( .
sender
��/ 5
,
��5 6*
SelectedItemChangedEventArgs
��7 S
e
��T U
)
��U V
{
�� 	
int
�� 
index
�� 
=
�� 
e
�� 
.
�� 
SelectedItemIndex
�� +
;
��+ ,
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� #
<
��$ %
Items
��& +
.
��+ ,
Count
��, 1
)
��1 2
{
�� 
var
�� 
item
�� 
=
�� 
Items
��  
[
��  !
index
��! &
]
��& '
;
��' (

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
CurrentPlaylist
��# 2
.
��2 3
Clear
��3 8
(
��8 9
)
��9 :
;
��: ;
if
�� 
(
�� 
string
�� 
.
�� 
IsNullOrEmpty
�� (
(
��( )
item
��) -
.
��- .
MixId
��. 3
)
��3 4
)
��4 5
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
PlaylistPosition
��' 7
=
��8 9
e
��: ;
.
��; <
SelectedItemIndex
��< M
;
��M N
foreach
�� 
(
�� 
var
��  
_item
��! &
in
��' )
Items
��* /
)
��/ 0
{
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
CurrentPlaylist
��+ :
.
��: ;
Add
��; >
(
��> ?
new
��? B
Newtone
��C J
.
��J K
Core
��K O
.
��O P
Media
��P U
.
��U V
MediaSource
��V a
(
��a b
)
��b c
{
�� 
Artist
�� "
=
��# $
_item
��% *
.
��* +
Author
��+ 1
,
��1 2
Duration
�� $
=
��% &
_item
��' ,
.
��, -
Duration
��- 5
,
��5 6
FilePath
�� $
=
��% &
_item
��' ,
.
��, -
Id
��- /
,
��/ 0
Image
�� !
=
��" #
_item
��$ )
.
��) *
Image
��* /
,
��/ 0
Title
�� !
=
��" #
_item
��$ )
.
��) *
Title
��* /
,
��/ 0
Type
��  
=
��! "
_item
��# (
.
��( )
Id
��) +
.
��+ ,
Length
��, 2
==
��3 5
$num
��6 8
?
��9 :
Newtone
��; B
.
��B C
Core
��C G
.
��G H
Media
��H M
.
��M N
MediaSource
��N Y
.
��Y Z

SourceType
��Z d
.
��d e
Web
��e h
:
��i j
Core
��k o
.
��o p
Media
��p u
.
��u v
MediaSource��v �
.��� �

SourceType��� �
.��� �
Local��� �
}
�� 
)
�� 
;
�� 
}
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
=
��3 4

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
CurrentPlaylist
��H W
[
��W X
e
��X Y
.
��Y Z
SelectedItemIndex
��Z k
]
��k l
;
��l m

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @
(
��@ A
)
��A B
=>
��C E
{
�� 
List
�� 
<
�� 
Core
�� !
.
��! "
Media
��" '
.
��' (
MediaSource
��( 3
>
��3 4
newPlaylist
��5 @
=
��A B
Items
��C H
.
��H I
Select
��I O
(
��O P
_item
��P U
=>
��V X
new
��Y \
Core
��] a
.
��a b
Media
��b g
.
��g h
MediaSource
��h s
(
��s t
)
��t u
{
�� 
Artist
�� "
=
��# $
_item
��% *
.
��* +
Author
��+ 1
,
��1 2
Duration
�� $
=
��% &
_item
��' ,
.
��, -
Duration
��- 5
,
��5 6
FilePath
�� $
=
��% &
_item
��' ,
.
��, -
Id
��- /
,
��/ 0
Image
�� !
=
��" #
_item
��$ )
.
��) *
Image
��* /
,
��/ 0
Title
�� !
=
��" #
_item
��$ )
.
��) *
Title
��* /
,
��/ 0
Type
��  
=
��! "
_item
��# (
.
��( )
Id
��) +
.
��+ ,
Length
��, 2
==
��3 5
$num
��6 8
?
��9 :
Newtone
��; B
.
��B C
Core
��C G
.
��G H
Media
��H M
.
��M N
MediaSource
��N Y
.
��Y Z

SourceType
��Z d
.
��d e
Web
��e h
:
��i j
Core
��k o
.
��o p
Media
��p u
.
��u v
MediaSource��v �
.��� �

SourceType��� �
.��� �
Local��� �
}
�� 
)
�� 
.
�� 
ToList
�� !
(
��! "
)
��" #
;
��# $
return
�� 
newPlaylist
�� *
;
��* +
}
�� 
,
�� 
index
�� 
,
�� 
true
�� "
,
��" #
true
��$ (
)
��( )
;
��) *
}
�� 
else
�� 
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaPlayer
��' 2
.
��2 3
LoadPlaylist
��3 ?
(
��? @
item
��@ D
.
��D E
MixId
��E J
,
��J K
$num
��L M
,
��M N
new
��O R
Newtone
��S Z
.
��Z [
Core
��[ _
.
��_ `
Media
��` e
.
��e f
MediaSource
��f q
(
��q r
)
��r s
{
�� 
Artist
�� 
=
��  
item
��! %
.
��% &
Author
��& ,
,
��, -
Duration
��  
=
��! "
item
��# '
.
��' (
Duration
��( 0
,
��0 1
FilePath
��  
=
��! "
item
��# '
.
��' (
Id
��( *
,
��* +
Image
�� 
=
�� 
item
��  $
.
��$ %
Image
��% *
,
��* +
Title
�� 
=
�� 
item
��  $
.
��$ %
Title
��% *
,
��* +
Type
�� 
=
�� 
Newtone
�� &
.
��& '
Core
��' +
.
��+ ,
Media
��, 1
.
��1 2
MediaSource
��2 =
.
��= >

SourceType
��> H
.
��H I
Web
��I L
}
�� 
,
�� 
true
�� 
,
�� 
true
�� !
)
��! "
;
��" #
}
�� 
await
�� 
Global
�� 
.
��  
NavigationInstance
�� /
.
��/ 0
PushModalAsync
��0 >
(
��> ?
new
��? B
FullScreenPage
��C Q
(
��Q R
)
��R S
)
��S T
;
��T U
(
�� 
sender
�� 
as
�� 
Xamarin
�� "
.
��" #
Forms
��# (
.
��( )
ListView
��) 1
)
��1 2
.
��2 3
SelectedItem
��3 ?
=
��@ A
null
��B F
;
��F G
}
�� 
}
�� 	
public
�� 
void
�� *
SearchListView_ItemAppearing
�� 0
(
��0 1
int
��1 4
	itemIndex
��5 >
)
��> ?
{
�� 	
ItemAppearing
�� 
.
�� 
Execute
�� !
(
��! "
	itemIndex
��" +
)
��+ ,
;
��, -
}
�� 	
}
�� 
}�� �[
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\SearchViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
SearchViewModel  
:! "
PropertyChangedBase# 6
{ 
private  
ObservableCollection $
<$ %
HistoryModel% 1
>1 2
items3 8
;8 9
private  
ObservableCollection $
<$ %
HistoryModel% 1
>1 2
suggestionItems3 B
;B C
private 
string 

searchText !
=" #
string$ *
.* +
Empty+ 0
;0 1
private 
bool $
searchSuggestionsVisible -
=. /
false0 5
;5 6
public  
ObservableCollection #
<# $
HistoryModel$ 0
>0 1
Items2 7
{ 	
get 
=> 
items 
; 
set 
{ 
items 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
}   
}!! 	
public##  
ObservableCollection## #
<### $
HistoryModel##$ 0
>##0 1
SuggestionItems##2 A
{$$ 	
get%% 
=>%% 
suggestionItems%% "
;%%" #
set&& 
{'' 
suggestionItems(( 
=((  !
value((" '
;((' (
OnPropertyChanged)) !
())! "
)))" #
;))# $
}** 
}++ 	
public-- 
string-- 

SearchText--  
{.. 	
get// 
=>// 

searchText// 
;// 
set00 
{11 

searchText22 
=22 
value22 "
;22" #
OnPropertyChanged33 !
(33! "
)33" #
;33# $
}44 
}55 	
public77 
bool77 $
SearchSuggestionsVisible77 ,
{88 	
get99 
=>99 $
searchSuggestionsVisible99 +
;99+ ,
set:: 
{;; $
searchSuggestionsVisible<< (
=<<) *
value<<+ 0
;<<0 1
OnPropertyChanged== !
(==! "
)==" #
;==# $
OnPropertyChanged>> !
(>>! "
(>>" #
)>># $
=>>>% ',
 SearchSuggestionsVisibleNegative>>( H
)>>H I
;>>I J
}?? 
}@@ 	
publicBB 
boolBB ,
 SearchSuggestionsVisibleNegativeBB 4
=>BB5 7
!BB8 9$
SearchSuggestionsVisibleBB9 Q
;BBQ R
privateEE 
ICommandEE 
clearCommandEE %
;EE% &
publicFF 
ICommandFF 
	ClearListFF !
{GG 	
getHH 
{II 
ifJJ 
(JJ 
clearCommandJJ  
==JJ! #
nullJJ$ (
)JJ( )
clearCommandKK  
=KK! "
newKK# &
ActionCommandKK' 4
(KK4 5
	parameterKK5 >
=>KK? A
{LL 
ItemsMM 
.MM 
ClearMM #
(MM# $
)MM$ %
;MM% &

GlobalDataNN "
.NN" #
CurrentNN# *
.NN* +
HistoryNN+ 2
.NN2 3
ClearNN3 8
(NN8 9
)NN9 :
;NN: ;

GlobalDataOO "
.OO" #
CurrentOO# *
.OO* +

SaveConfigOO+ 5
(OO5 6
)OO6 7
;OO7 8
}PP 
)PP 
;PP 
returnQQ 
clearCommandQQ #
;QQ# $
}RR 
}SS 	
publicWW 
SearchViewModelWW 
(WW 
)WW  
{XX 	
SuggestionItemsYY 
=YY 
newYY ! 
ObservableCollectionYY" 6
<YY6 7
HistoryModelYY7 C
>YYC D
(YYD E
)YYE F
;YYF G
ItemsZZ 
=ZZ 
newZZ  
ObservableCollectionZZ ,
<ZZ, -
HistoryModelZZ- 9
>ZZ9 :
(ZZ: ;
)ZZ; <
;ZZ< =
foreach[[ 
([[ 
var[[ 
item[[ 
in[[  

GlobalData[[! +
.[[+ ,
Current[[, 3
.[[3 4
History[[4 ;
.[[; <
Reverse[[< C
<[[C D
HistoryModel[[D P
>[[P Q
([[Q R
)[[R S
)[[S T
{\\ 
Items]] 
.]] 
Add]] 
(]] 
item]] 
)]] 
;]]  
}^^ 
}__ 	
publiccc 
asynccc 
voidcc !
SearchEntry_Completedcc /
(cc/ 0
stringcc0 6

searchTextcc7 A
)ccA B
{dd 	

SearchTextee 
=ee 

searchTextee #
;ee# $
ifff 
(ff 
!ff 
stringff 
.ff 
IsNullOrEmptyff %
(ff% &

SearchTextff& 0
)ff0 1
)ff1 2
{gg 
awaithh 
Globalhh 
.hh 
NavigationInstancehh /
.hh/ 0
PushModalAsynchh0 >
(hh> ?
newhh? B
	ModalPagehhC L
(hhL M
newhhM P
SearchResultPagehhQ a
(hha b

SearchTexthhb l
)hhl m
,hhm n

SearchTexthho y
)hhy z
)hhz {
;hh{ |
}ii 
}jj 	
publicll 
asyncll 
voidll 
Item_Selectedll '
(ll' (
objectll( .
senderll/ 5
,ll5 6(
SelectedItemChangedEventArgsll7 S
ellT U
)llU V
{mm 	
intnn 
indexnn 
=nn 
enn 
.nn 
SelectedItemIndexnn +
;nn+ ,
ifpp 
(pp 
indexpp 
>=pp 
$numpp 
&&pp 
indexpp #
<pp$ %
Itemspp& +
.pp+ ,
Countpp, 1
)pp1 2
{qq 
ifrr 
(rr 
Globalrr 
.rr 
Applicationrr &
.rr& '
HasInternetrr' 2
(rr2 3
)rr3 4
)rr4 5
awaitss 
Globalss  
.ss  !
NavigationInstancess! 3
.ss3 4
PushModalAsyncss4 B
(ssB C
newssC F
	ModalPagessG P
(ssP Q
newssQ T
SearchResultPagessU e
(sse f
Itemsssf k
[ssk l
indexssl q
]ssq r
.ssr s
Textsss w
)ssw x
,ssx y
Itemsssz 
[	ss �
index
ss� �
]
ss� �
.
ss� �
Text
ss� �
)
ss� �
)
ss� �
;
ss� �
elsett 
awaituu 
Globaluu  
.uu  !
Pageuu! %
.uu% &
DisplayAlertuu& 2
(uu2 3
Localizationuu3 ?
.uu? @
Warninguu@ G
,uuG H
LocalizationuuI U
.uuU V
NoConnectionuuV b
,uub c
Localizationuud p
.uup q
Canceluuq w
)uuw x
;uux y
(ww 
senderww 
asww 
Xamarinww "
.ww" #
Formsww# (
.ww( )
ListViewww) 1
)ww1 2
.ww2 3
SelectedItemww3 ?
=ww@ A
nullwwB F
;wwF G
}xx 
}yy 	
public{{ 
async{{ 
void{{ #
SuggestionItem_Selected{{ 1
({{1 2
object{{2 8
sender{{9 ?
,{{? @(
SelectedItemChangedEventArgs{{A ]
e{{^ _
){{_ `
{|| 	
int}} 
index}} 
=}} 
e}} 
.}} 
SelectedItemIndex}} +
;}}+ ,
if 
( 
index 
>= 
$num 
&& 
index #
<$ %
SuggestionItems& 5
.5 6
Count6 ;
); <
{
�� 
if
�� 
(
�� 
Global
�� 
.
�� 
Application
�� &
.
��& '
HasInternet
��' 2
(
��2 3
)
��3 4
)
��4 5
await
�� 
Global
��  
.
��  ! 
NavigationInstance
��! 3
.
��3 4
PushModalAsync
��4 B
(
��B C
new
��C F
	ModalPage
��G P
(
��P Q
new
��Q T
SearchResultPage
��U e
(
��e f
SuggestionItems
��f u
[
��u v
index
��v {
]
��{ |
.
��| }
Text��} �
)��� �
,��� �
SuggestionItems��� �
[��� �
index��� �
]��� �
.��� �
Text��� �
)��� �
)��� �
;��� �
else
�� 
await
�� 
Global
��  
.
��  !
Page
��! %
.
��% &
DisplayAlert
��& 2
(
��2 3
Localization
��3 ?
.
��? @
Warning
��@ G
,
��G H
Localization
��I U
.
��U V
NoConnection
��V b
,
��b c
Localization
��d p
.
��p q
Cancel
��q w
)
��w x
;
��x y
(
�� 
sender
�� 
as
�� 
Xamarin
�� "
.
��" #
Forms
��# (
.
��( )
ListView
��) 1
)
��1 2
.
��2 3
SelectedItem
��3 ?
=
��@ A
null
��B F
;
��F G
}
�� 
}
�� 	
public
�� 
void
�� 
RefreshSuggestion
�� %
(
��% &
string
��& ,
text
��- 1
)
��1 2
{
�� 	&
SearchSuggestionsVisible
�� $
=
��% &
true
��' +
;
��+ ,
var
�� 
newList
�� 
=
�� 
SearchProcessing
�� *
.
��* +'
GenerateSearchSuggestions
��+ D
(
��D E
)
��E F
.
��F G
FindAll
��G N
(
��N O
item
��O S
=>
��T V
item
��W [
.
��[ \
ToLowerInvariant
��\ l
(
��l m
)
��m n
.
��n o
Contains
��o w
(
��w x
text
��x |
.
��| }
ToLowerInvariant��} �
(��� �
)��� �
)��� �
||��� �
text��� �
.��� � 
ToLowerInvariant��� �
(��� �
)��� �
.��� �
Contains��� �
(��� �
item��� �
.��� � 
ToLowerInvariant��� �
(��� �
)��� �
)��� �
)��� �
;��� �
SuggestionItems
�� 
.
�� 
Clear
�� !
(
��! "
)
��" #
;
��# $
foreach
�� 
(
�� 
var
�� 
item
�� 
in
��  
newList
��! (
)
��( )
{
�� 
SuggestionItems
�� 
.
��  
Add
��  #
(
��# $
new
��$ '
HistoryModel
��( 4
(
��4 5
)
��5 6
{
��7 8
Text
��9 =
=
��> ?
item
��@ D
}
��E F
)
��F G
;
��G H
}
�� 
}
�� 	
}
�� 
}�� ��
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\SettingsViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
SettingsViewModel "
:# $
PropertyChangedBase% 8
{ 
private  
ObservableCollection $
<$ %
SettingsModel% 2
>2 3
items4 9
;9 :
private 
string 
version 
; 
public  
ObservableCollection #
<# $
SettingsModel$ 1
>1 2
Items3 8
{ 	
get 
=> 
items 
; 
set 
{ 
items 
= 
value 
; 
OnPropertyChanged !
(! "
)" #
;# $
} 
}   	
public""  
ObservableCollection"" #
<""# $
NListViewItem""$ 1
>""1 2
	ListItems""3 <
{""= >
get""? B
;""B C
set""D G
;""G H
}""I J
public$$ 
string$$ 
Version$$ 
{%% 	
get&& 
=>&& 
version&& 
;&& 
set'' 
{(( 
version)) 
=)) 
value)) 
;))  
OnPropertyChanged** !
(**! "
)**" #
;**# $
}++ 
},, 	
public.. 
Func.. 
<.. 
NListViewItem.. !
,..! "
View..# '
>..' (
ItemTemplate..) 5
=>..6 8
item..9 =
=>..> @
new..A D
SettingsViewCell..E U
(..U V
item..V Z
)..Z [
;..[ \
private11 
ICommand11 
gotoWWW11  
;11  !
public22 
ICommand22 
GotoWWW22 
{33 	
get44 
{55 
if66 
(66 
gotoWWW66 
==66 
null66 #
)66# $
gotoWWW77 
=77 
new77 !
ActionCommand77" /
(77/ 0
	parameter770 9
=>77: <
{88 
Device99 
.99 
OpenUri99 &
(99& '
new99' *
Uri99+ .
(99. /
$str99/ K
)99K L
)99L M
;99M N
}:: 
):: 
;:: 
return;; 
gotoWWW;; 
;;; 
}<< 
}== 	
public@@ 
SettingsViewModel@@  
(@@  !
)@@! "
{AA 	
ItemsBB 
=BB 
newBB  
ObservableCollectionBB ,
<BB, -
SettingsModelBB- :
>BB: ;
{CC 
newDD 
SettingsModelDD !
(DD! "
)DD" #
{DD$ %
NameDD& *
=DD+ ,
LocalizationDD- 9
.DD9 :
	Settings0DD: C
}DDD E
,DDE F
newEE 
SettingsModelEE !
(EE! "
)EE" #
{EE$ %
NameEE& *
=EE+ ,
LocalizationEE- 9
.EE9 :
	Settings2EE: C
}EED E
,EEE F
newFF 
SettingsModelFF !
(FF! "
)FF" #
{FF$ %
NameFF& *
=FF+ ,
LocalizationFF- 9
.FF9 :
	Settings4FF: C
}FFD E
,FFE F
newGG 
SettingsModelGG !
(GG! "
)GG" #
{GG$ %
NameGG& *
=GG+ ,
LocalizationGG- 9
.GG9 :
	Settings5GG: C
}GGD E
,GGE F
newHH 
SettingsModelHH !
(HH! "
)HH" #
{HH$ %
NameHH& *
=HH+ ,
LocalizationHH- 9
.HH9 :
AutoDownloadHH: F
,HHF G
DescriptionHHH S
=HHT U

GlobalDataHHV `
.HH` a
CurrentHHa h
.HHh i
AutoDownloadHHi u
?HHv w
Localization	HHx �
.
HH� �
Yes
HH� �
:
HH� �
Localization
HH� �
.
HH� �
No
HH� �
}
HH� �
,
HH� �
newII 
SettingsModelII !
(II! "
)II" #
{II$ %
NameII& *
=II+ ,
LocalizationII- 9
.II9 :
	Settings3II: C
,IIC D
DescriptionIIE P
=IIQ R

GlobalDataIIS ]
.II] ^
CurrentII^ e
.IIe f
IgnoreAutoFocusIIf u
?IIv w
Localization	IIx �
.
II� �
Yes
II� �
:
II� �
Localization
II� �
.
II� �
No
II� �
}
II� �
}JJ 
;JJ 
	ListItemsLL 
=LL 
newLL  
ObservableCollectionLL 0
<LL0 1
NListViewItemLL1 >
>LL> ?
(LL? @
)LL@ A
;LLA B
foreachMM 
(MM 
varMM 
itemMM 
inMM 
ItemsMM  %
)MM% &
{NN 
	ListItemsOO 
.OO 
AddOO 
(OO 
itemOO "
)OO" #
;OO# $
}PP 
VersionRR 
=RR 
$strRR 
+RR 
GlobalRR "
.RR" #
ApplicationRR# .
.RR. /

GetVersionRR/ 9
(RR9 :
)RR: ;
;RR; <
}SS 	
publicVV 
asyncVV 
SystemVV 
.VV 
	ThreadingVV %
.VV% &
TasksVV& +
.VV+ ,
TaskVV, 0
Item_SelectedVV1 >
(VV> ?
objectVV? E
senderVVF L
,VVL M(
SelectedItemChangedEventArgsVVN j
eVVk l
)VVl m
{WW 	
intXX 
indexXX 
=XX 
eXX 
.XX 
SelectedItemIndexXX +
;XX+ ,
ifZZ 
(ZZ 
indexZZ 
>=ZZ 
$numZZ 
&&ZZ 
indexZZ #
<ZZ$ %
ItemsZZ& +
.ZZ+ ,
CountZZ, 1
)ZZ1 2
{[[ 
if\\ 
(\\ 
e\\ 
.\\ 
SelectedItemIndex\\ '
>\\( )
$num\\* +
&&\\, .
e\\/ 0
.\\0 1
SelectedItem\\1 =
!=\\> @
null\\A E
)\\E F
{]] 
if^^ 
(^^ 
e^^ 
.^^ 
SelectedItemIndex^^ +
==^^, .
$num^^/ 0
)^^0 1
{__ 
foreach`` 
(``  !
string``! '
filepath``( 0
in``1 3

GlobalData``4 >
.``> ?
Current``? F
.``F G
Audios``G M
.``M N
Keys``N R
)``R S
{aa 
ifcc 
(cc  
!cc  !

GlobalDatacc! +
.cc+ ,
Currentcc, 3
.cc3 4
	AudioTagscc4 =
.cc= >
ContainsKeycc> I
(ccI J
filepathccJ R
)ccR S
)ccS T
{dd 
varee  #
tagee$ '
=ee( )

GlobalDataee* 4
.ee4 5
Currentee5 <
.ee< =
Audiosee= C
[eeC D
filepatheeD L
]eeL M
;eeM N
ifff  "
(ff# $
tagff$ '
.ff' (
Artistff( .
==ff/ 1
Localizationff2 >
.ff> ?
UnknownArtistff? L
)ffL M
{gg  !
FileInfohh$ ,
fileInfohh- 5
=hh6 7
newhh8 ;
FileInfohh< D
(hhD E
filepathhhE M
)hhM N
;hhN O
stringjj$ *
namejj+ /
=jj0 1
fileInfojj2 :
.jj: ;
Namejj; ?
.jj? @
Replacejj@ G
(jjG H
fileInfojjH P
.jjP Q
	ExtensionjjQ Z
,jjZ [
$strjj\ ^
)jj^ _
;jj_ `
stringkk$ *
[kk* +
]kk+ ,
splittedkk- 5
=kk6 7
namekk8 <
.kk< =
Splitkk= B
(kkB C
newkkC F
stringkkG M
[kkM N
]kkN O
{kkP Q
$strkkR W
,kkW X
$strkkY ^
,kk^ _
$strkk` d
,kkd e
$strkkf j
}kkk l
,kkl m
StringSplitOptions	kkn �
.
kk� � 
RemoveEmptyEntries
kk� �
)
kk� �
;
kk� �
stringmm$ *
artistmm+ 1
=mm2 3
splittedmm4 <
.mm< =
Lengthmm= C
==mmD F
$nummmG H
?mmI J
LocalizationmmK W
.mmW X
UnknownArtistmmX e
:mmf g
splittedmmh p
[mmp q
$nummmq r
]mmr s
;mms t
stringnn$ *
titlenn+ 0
=nn1 2
splittednn3 ;
[nn; <
splittednn< D
.nnD E
LengthnnE K
==nnL N
$numnnO P
?nnQ R
$numnnS T
:nnU V
$numnnW X
]nnX Y
;nnY Z

GlobalDataoo$ .
.oo. /
Currentoo/ 6
.oo6 7
	AudioTagsoo7 @
.oo@ A
AddooA D
(ooD E
filepathooE M
,ooM N
newooO R
MediaSourceTagooS a
(ooa b
)oob c
{ood e
Authoroof l
=oom n
artistooo u
,oou v
Titleoow |
=oo} ~
title	oo �
}
oo� �
)
oo� �
;
oo� �
}pp  !
}qq 
}rr 

GlobalDatass "
.ss" #
Currentss# *
.ss* +
SaveTagsss+ 3
(ss3 4
)ss4 5
;ss5 6
Globaltt 
.tt 
Applicationtt *
.tt* +
ShowSnackbartt+ 7
(tt7 8
Localizationtt8 D
.ttD E
ReadyttE J
)ttJ K
;ttK L
}uu 
elsevv 
ifvv 
(vv 
evv 
.vv 
SelectedItemIndexvv 0
==vv1 3
$numvv4 5
)vv5 6
{ww 
stringxx 
[xx 
]xx  
filesxx! &
=xx' (
	Directoryxx) 2
.xx2 3
GetFilesxx3 ;
(xx; <

GlobalDataxx< F
.xxF G
CurrentxxG N
.xxN O
DataPathxxO W
,xxW X
$strxxY b
)xxb c
;xxc d
foreachzz 
(zz  !
stringzz! '
filezz( ,
inzz- /
fileszz0 5
)zz5 6
{{{ 
File||  
.||  !
Delete||! '
(||' (
file||( ,
)||, -
;||- .
}}} 
UI 
. 
Global !
.! "
Application" -
.- .
ShowSnackbar. :
(: ;
Localization; G
.G H
ReadyH M
)M N
;N O
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
SelectedItemIndex
�� 0
==
��1 3
$num
��4 5
)
��5 6
{
�� 
Global
�� 
.
�� 
Application
�� *
.
��* +
AddFolderToScan
��+ :
(
��: ;
)
��; <
;
��< =
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
SelectedItemIndex
�� 0
==
��1 3
$num
��4 5
)
��5 6
{
�� 
string
�� 
newLang
�� &
=
��' (
await
��) .
Global
��/ 5
.
��5 6
Page
��6 :
.
��: ; 
DisplayActionSheet
��; M
(
��M N
Localization
��N Z
.
��Z [
	Settings5
��[ d
,
��d e
Localization
��f r
.
��r s
Cancel
��s y
,
��y z
null
��{ 
,�� �
Localization��� �
.��� �

LanguagePL��� �
,��� �
Localization��� �
.��� �

LanguageEN��� �
,��� �
Localization��� �
.��� �

LanguageRU��� �
)��� �
;��� �
if
�� 
(
�� 
newLang
�� #
==
��$ &
Localization
��' 3
.
��3 4

LanguagePL
��4 >
)
��> ?

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
CurrentLanguage
��/ >
=
��? @
$str
��A E
;
��E F
else
�� 
if
�� 
(
��  !
newLang
��! (
==
��) +
Localization
��, 8
.
��8 9

LanguageEN
��9 C
)
��C D

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
CurrentLanguage
��/ >
=
��? @
$str
��A E
;
��E F
else
�� 
if
�� 
(
��  !
newLang
��! (
==
��) +
Localization
��, 8
.
��8 9

LanguageRU
��9 C
)
��C D

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
CurrentLanguage
��/ >
=
��? @
$str
��A E
;
��E F
Localization
�� $
.
��$ %
RefreshLanguage
��% 4
(
��4 5
)
��5 6
;
��6 7

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SettingsChanges
��E T
)
��T U
;
��U V
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
SelectedItemIndex
�� 0
==
��1 3
$num
��4 5
)
��5 6
{
�� 
string
�� 
	newOption
�� (
=
��) *
await
��+ 0
Global
��1 7
.
��7 8
Page
��8 <
.
��< = 
DisplayActionSheet
��= O
(
��O P
Localization
��P \
.
��\ ]
AutoDownload
��] i
,
��i j
Localization
��k w
.
��w x
Cancel
��x ~
,
��~ 
null��� �
,��� �
Localization��� �
.��� �
Yes��� �
,��� �
Localization��� �
.��� �
No��� �
)��� �
;��� �
if
�� 
(
�� 
	newOption
�� %
==
��& (
Localization
��) 5
.
��5 6
Yes
��6 9
)
��9 :
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
AutoDownload
��/ ;
=
��< =
true
��> B
;
��B C
Items
�� !
[
��! "
$num
��" #
]
��# $
.
��$ %
Description
��% 0
=
��1 2
Localization
��3 ?
.
��? @
Yes
��@ C
;
��C D
}
�� 
else
�� 
if
�� 
(
��  !
	newOption
��! *
==
��+ -
Localization
��. :
.
��: ;
No
��; =
)
��= >
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
AutoDownload
��/ ;
=
��< =
false
��> C
;
��C D
Items
�� !
[
��! "
$num
��" #
]
��# $
.
��$ %
Description
��% 0
=
��1 2
Localization
��3 ?
.
��? @
No
��@ B
;
��B C
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
SettingsChanges
��E T
)
��T U
;
��U V
}
�� 
else
�� 
if
�� 
(
�� 
e
�� 
.
�� 
SelectedItemIndex
�� 0
==
��1 3
$num
��4 5
)
��5 6
{
�� 
string
�� 
	newOption
�� (
=
��) *
await
��+ 0
Global
��1 7
.
��7 8
Page
��8 <
.
��< = 
DisplayActionSheet
��= O
(
��O P
Localization
��P \
.
��\ ]
	Settings3
��] f
,
��f g
Localization
��h t
.
��t u
Cancel
��u {
,
��{ |
null��} �
,��� �
Localization��� �
.��� �
Yes��� �
,��� �
Localization��� �
.��� �
No��� �
)��� �
;��� �
if
�� 
(
�� 
	newOption
�� %
==
��& (
Localization
��) 5
.
��5 6
Yes
��6 9
)
��9 :
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
IgnoreAutoFocus
��/ >
=
��? @
true
��A E
;
��E F
Items
�� !
[
��! "
$num
��" #
]
��# $
.
��$ %
Description
��% 0
=
��1 2
Localization
��3 ?
.
��? @
Yes
��@ C
;
��C D
}
�� 
else
�� 
if
�� 
(
��  !
	newOption
��! *
==
��+ -
Localization
��. :
.
��: ;
No
��; =
)
��= >
{
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
IgnoreAutoFocus
��/ >
=
��? @
false
��A F
;
��F G
Items
�� !
[
��! "
$num
��" #
]
��# $
.
��$ %
Description
��% 0
=
��1 2
Localization
��3 ?
.
��? @
No
��@ B
;
��B C
}
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +

SaveConfig
��+ 5
(
��5 6
)
��6 7
;
��7 8
Global
�� 
.
�� 
Application
�� *
.
��* +
ShowSnackbar
��+ 7
(
��7 8
Localization
��8 D
.
��D E
Ready
��E J
)
��J K
;
��K L
}
�� 
}
�� 
(
�� 
sender
�� 
as
�� 
ListView
�� #
)
��# $
.
��$ %
SelectedItem
��% 1
=
��2 3
null
��4 8
;
��8 9
}
�� 
}
�� 	
}
�� 
}�� �U
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\TrackViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
{ 
public 

class 
TrackViewModel 
:  !
PropertyChangedBase" 5
{ 
private 
bool 
isRefreshing !
;! "
public  
ObservableCollection #
<# $

TrackModel$ .
>. /
Items0 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
public  
ObservableCollection #
<# $
NListViewItem$ 1
>1 2
	ListItems3 <
{= >
get? B
;B C
setD G
;G H
}I J
public 
bool 
IsRefreshing  
{ 	
get 
=> 
isRefreshing 
;  
set 
{ 
isRefreshing 
= 
value $
;$ %
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public   
Func   
<   
NListViewItem   !
,  ! "
View  # '
>  ' (
ItemTemplate  ) 5
{!! 	
get"" 
=>"" 
item"" 
=>"" 
new"" 
Views"" $
.""$ %
TV""% '
.""' (
	ViewCells""( 1
.""1 2
TrackViewCell""2 ?
(""? @
item""@ D
)""D E
;""E F
}## 	
private&& 
ICommand&& 
refresh&&  
;&&  !
public'' 
ICommand'' 
Refresh'' 
{(( 	
get)) 
{** 
if++ 
(++ 
refresh++ 
==++ 
null++ #
)++# $
refresh,, 
=,, 
new,, !
ActionCommand,," /
(,,/ 0
	parameter,,0 9
=>,,: <
{-- 
IsRefreshing.. $
=..% &
true..' +
;..+ ,
List// 
<// 

TrackModel// '
>//' (

beforeSort//) 3
=//4 5
new//6 9
List//: >
<//> ?

TrackModel//? I
>//I J
(//J K
)//K L
;//L M
foreach00 
(00  !
var00! $
track00% *
in00+ -

GlobalData00. 8
.008 9
Current009 @
.00@ A
Audios00A G
.00G H
Values00H N
)00N O
{11 

beforeSort22 &
.22& '
Add22' *
(22* +
new22+ .

TrackModel22/ 9
(229 :
track22: ?
)22? @
.22@ A
CheckChanges22A M
(22M N
)22N O
)22O P
;22P Q
}33 
Items44 
=44 
new44  # 
ObservableCollection44$ 8
<448 9

TrackModel449 C
>44C D
(44D E

beforeSort44E O
.44O P
OrderBy44P W
(44W X
item44X \
=>44] _
item44` d
.44d e
TrackString44e p
)44p q
)44q r
;44r s
IsRefreshing55 $
=55% &
false55' ,
;55, -
}66 
)66 
;66 
return77 
refresh77 
;77 
}88 
}99 	
public<< 
TrackViewModel<< 
(<< 
)<< 
{== 	
List>> 
<>> 

TrackModel>> 
>>> 

beforeSort>> '
=>>( )
new>>* -
List>>. 2
<>>2 3

TrackModel>>3 =
>>>= >
(>>> ?
)>>? @
;>>@ A
foreach?? 
(?? 
var?? 
track?? 
in?? !

GlobalData??" ,
.??, -
Current??- 4
.??4 5
Audios??5 ;
.??; <
Values??< B
.??B C
ToList??C I
(??I J
)??J K
)??K L
{@@ 

beforeSortAA 
.AA 
AddAA 
(AA 
newAA "

TrackModelAA# -
(AA- .
trackAA. 3
)AA3 4
.AA4 5
CheckChangesAA5 A
(AAA B
)AAB C
)AAC D
;AAD E
}BB 
ItemsCC 
=CC 
newCC  
ObservableCollectionCC ,
<CC, -

TrackModelCC- 7
>CC7 8
(CC8 9

beforeSortCC9 C
.CCC D
OrderByCCD K
(CCK L
itemCCL P
=>CCQ S
itemCCT X
.CCX Y
TrackStringCCY d
)CCd e
)CCe f
;CCf g
	ListItemsDD 
=DD 
newDD  
ObservableCollectionDD 0
<DD0 1
NListViewItemDD1 >
>DD> ?
(DD? @
)DD@ A
;DDA B
foreachFF 
(FF 
varFF 
itemFF 
inFF 
ItemsFF  %
)FF% &
{GG 
	ListItemsHH 
.HH 
AddHH 
(HH 
itemHH "
)HH" #
;HH# $
}II 
}JJ 	
publicNN 
voidNN 
TickNN 
(NN 
)NN 
{OO 	
ifPP 
(PP 
ItemsPP 
.PP 
CountPP 
!=PP 

GlobalDataPP )
.PP) *
CurrentPP* 1
.PP1 2
AudiosPP2 8
.PP8 9
CountPP9 >
)PP> ?
{QQ 
ItemsRR 
.RR 
ClearRR 
(RR 
)RR 
;RR 
	ListItemsSS 
.SS 
ClearSS 
(SS  
)SS  !
;SS! "
ListTT 
<TT 

TrackModelTT 
>TT  

beforeSortTT! +
=TT, -
newTT. 1
ListTT2 6
<TT6 7

TrackModelTT7 A
>TTA B
(TTB C
)TTC D
;TTD E
foreachUU 
(UU 
varUU 
trackUU "
inUU# %

GlobalDataUU& 0
.UU0 1
CurrentUU1 8
.UU8 9
AudiosUU9 ?
.UU? @
ValuesUU@ F
.UUF G
ToListUUG M
(UUM N
)UUN O
)UUO P
{VV 

beforeSortWW 
.WW 
AddWW "
(WW" #
newWW# &

TrackModelWW' 1
(WW1 2
trackWW2 7
)WW7 8
.WW8 9
CheckChangesWW9 E
(WWE F
)WWF G
)WWG H
;WWH I
}XX 
foreachYY 
(YY 
varYY 
itemYY !
inYY" $

beforeSortYY% /
.YY/ 0
OrderByYY0 7
(YY7 8
itemYY8 <
=>YY= ?
itemYY@ D
.YYD E
TrackStringYYE P
)YYP Q
)YYQ R
{ZZ 
Items[[ 
.[[ 
Add[[ 
([[ 
item[[ "
)[[" #
;[[# $
	ListItems\\ 
.\\ 
Add\\ !
(\\! "
Items\\" '
[\\' (
^\\( )
$num\\) *
]\\* +
)\\+ ,
;\\, -
}]] 
}^^ 
foreach__ 
(__ 
var__ 
model__ 
in__ !
Items__" '
.__' (
ToList__( .
(__. /
)__/ 0
)__0 1
{`` 
ifaa 
(aa 

GlobalDataaa 
.aa 
Currentaa &
.aa& '
Audiosaa' -
.aa- .
ContainsKeyaa. 9
(aa9 :
modelaa: ?
.aa? @
FilePathaa@ H
)aaH I
)aaI J
{bb 
varcc 
sourcecc 
=cc  

GlobalDatacc! +
.cc+ ,
Currentcc, 3
.cc3 4
Audioscc4 :
[cc: ;
modelcc; @
.cc@ A
FilePathccA I
]ccI J
;ccJ K
intdd 
indexdd 
=dd 
Itemsdd  %
.dd% &
IndexOfdd& -
(dd- .
modeldd. 3
)dd3 4
;dd4 5
ifee 
(ee 
modelee 
.ee 
Artistee $
!=ee% '
sourceee( .
.ee. /
Artistee/ 5
||ee6 8
modelee9 >
.ee> ?
Titleee? D
!=eeE G
sourceeeH N
.eeN O
TitleeeO T
)eeT U
{ff 
Itemsgg 
[gg 
indexgg #
]gg# $
.gg$ %
Titlegg% *
=gg+ ,
sourcegg- 3
.gg3 4
Titlegg4 9
;gg9 :
Itemshh 
[hh 
indexhh #
]hh# $
.hh$ %
Artisthh% +
=hh, -
sourcehh. 4
.hh4 5
Artisthh5 ;
;hh; <
}ii 
modeljj 
.jj 
CheckChangesjj &
(jj& '
)jj' (
;jj( )
	ListItemskk 
[kk 
indexkk #
]kk# $
=kk% &
modelkk' ,
;kk, -
}ll 
elsemm 
{nn 
Itemsoo 
.oo 
Removeoo  
(oo  !
modeloo! &
)oo& '
;oo' (
	ListItemspp 
.pp 
Removepp $
(pp$ %
modelpp% *
)pp* +
;pp+ ,
}qq 
}rr 
}tt 	
publicvv 
voidvv 
Track_Selectedvv "
(vv" #
objectvv# )
sendervv* 0
,vv0 1(
SelectedItemChangedEventArgsvv2 N
evvO P
)vvP Q
{ww 	
intxx 
indexxx 
=xx 
exx 
.xx 
SelectedItemIndexxx +
;xx+ ,
ifzz 
(zz 
indexzz 
>=zz 
$numzz 
&&zz 
indexzz #
<zz$ %
Itemszz& +
.zz+ ,
Countzz, 1
)zz1 2
{{{ 

GlobalData|| 
.|| 
Current|| "
.||" #
MediaPlayer||# .
.||. /
LoadPlaylist||/ ;
(||; <
Items||< A
.||A B
Select||B H
(||H I
item||I M
=>||N P
item||Q U
.||U V
FilePath||V ^
)||^ _
.||_ `
ToList||` f
(||f g
)||g h
,||h i
index||j o
,||o p
true||q u
,||u v
true||w {
)||{ |
;||| }
(}} 
sender}} 
as}} 
Xamarin}} "
.}}" #
Forms}}# (
.}}( )
ListView}}) 1
)}}1 2
.}}2 3
SelectedItem}}3 ?
=}}@ A
null}}B F
;}}F G
}~~ 
} 	
}
�� 
}�� �]
UD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\TV\Custom\PlayerPanelViewModel.cs
	namespace		 	
Newtone		
 
.		 
Mobile		 
.		 
UI		 
.		 

ViewModels		 &
.		& '
TV		' )
.		) *
Custom		* 0
{

 
public 

class  
PlayerPanelViewModel %
:& '
PropertyChangedBase( ;
{ 
private 
bool !
backgroundGridVisible *
;* +
private 
string 
title 
; 
private 
string 
artist 
; 
private 
ImageSource 
	trackBlur %
;% &
private 
ImageSource 

trackImage &
;& '
private 
ImageSource 

playButton &
;& '
private 
bool 
isPlayImage  
=! "
true# '
;' (
private 
string 
playedTrack "
=# $
$str% '
;' (
private 
bool 
isPanelVisible #
;# $
private 
INFocusElement 
nextFocusUp *
;* +
private 
INFocusElement 
nextFocusUp1 +
;+ ,
public 
bool !
BackgroundGridVisible )
{ 	
get 
=> !
backgroundGridVisible (
;( )
set 
{   !
backgroundGridVisible!! %
=!!& '
value!!( -
;!!- .
OnPropertyChanged"" !
(""! "
)""" #
;""# $
}## 
}$$ 	
public&& 
string&& 
Title&& 
{'' 	
get(( 
=>(( 
title(( 
;(( 
set)) 
{** 
title++ 
=++ 
value++ 
;++ 
OnPropertyChanged,, !
(,,! "
),," #
;,,# $
}-- 
}.. 	
public00 
string00 
Artist00 
{11 	
get22 
=>22 
artist22 
;22 
set33 
{44 
artist55 
=55 
value55 
;55 
OnPropertyChanged66 !
(66! "
)66" #
;66# $
}77 
}88 	
public:: 
ImageSource:: 

TrackImage:: %
{;; 	
get<< 
=><< 

trackImage<< 
;<< 
set== 
{>> 

trackImage?? 
=?? 
value?? "
;??" #
OnPropertyChanged@@ !
(@@! "
)@@" #
;@@# $
}AA 
}BB 	
publicDD 
ImageSourceDD 
	TrackBlurDD $
{EE 	
getFF 
=>FF 
	trackBlurFF 
;FF 
setGG 
{HH 
	trackBlurII 
=II 
valueII !
;II! "
OnPropertyChangedJJ !
(JJ! "
)JJ" #
;JJ# $
}KK 
}LL 	
publicNN 
ImageSourceNN 

PlayButtonNN %
{OO 	
getPP 
=>PP 

playButtonPP 
;PP 
setQQ 
{RR 

playButtonSS 
=SS 
valueSS "
;SS" #
OnPropertyChangedTT !
(TT! "
)TT" #
;TT# $
}UU 
}VV 	
publicXX 
boolXX 
IsPanelVisibleXX "
{YY 	
getZZ 
=>ZZ 
isPanelVisibleZZ !
;ZZ! "
set[[ 
{\\ 
isPanelVisible]] 
=]]  
value]]! &
;]]& '
OnPropertyChanged^^ !
(^^! "
)^^" #
;^^# $
}__ 
}`` 	
publicbb 
INFocusElementbb 
NextFocusUpbb )
{cc 	
getdd 
=>dd 
nextFocusUpdd 
;dd 
setee 
{ff 
nextFocusUpgg 
=gg 
valuegg #
;gg# $
OnPropertyChangedhh !
(hh! "
)hh" #
;hh# $
}ii 
}jj 	
publicll 
INFocusElementll 
NextFocusUp1ll *
{mm 	
getnn 
=>nn 
nextFocusUp1nn 
;nn  
setoo 
{pp 
nextFocusUp1qq 
=qq 
valueqq $
;qq$ %
OnPropertyChangedrr !
(rr! "
)rr" #
;rr# $
}ss 
}tt 	
privatexx 
ICommandxx 
playPauseCommandxx )
;xx) *
publicyy 
ICommandyy 
	PlayPauseyy !
{zz 	
get{{ 
{|| 
if}} 
(}} 
playPauseCommand}} $
==}}% '
null}}( ,
)}}, -
playPauseCommand~~ $
=~~% &
new~~' *
ActionCommand~~+ 8
(~~8 9
	parameter~~9 B
=>~~C E
{ 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
!=
��; =
null
��> B
)
��B C
{
�� 
if
�� 
(
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
	IsPlaying
��? H
)
��H I

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
Pause
��? D
(
��D E
)
��E F
;
��F G
else
��  

GlobalData
��  *
.
��* +
Current
��+ 2
.
��2 3
MediaPlayer
��3 >
.
��> ?
Play
��? C
(
��C D
)
��D E
;
��E F
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
playPauseCommand
�� '
;
��' (
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoPlayerCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoPlayer
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoPlayerCommand
�� %
==
��& (
null
��) -
)
��- .
gotoPlayerCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
async
��: ?
(
��@ A
	parameter
��A J
)
��J K
=>
��L N
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
!=
��; =
null
��> B
)
��B C
{
�� 
await
�� !
Global
��" (
.
��( ) 
NavigationInstance
��) ;
.
��; <
PushModalAsync
��< J
(
��J K
new
��K N
Views
��O T
.
��T U
TV
��U W
.
��W X
FullScreenPage
��X f
(
��f g
)
��g h
)
��h i
;
��i j
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoPlayerCommand
�� (
;
��( )
}
�� 
}
�� 	
public
�� "
PlayerPanelViewModel
�� #
(
��# $
)
��$ %
{
�� 	

PlayButton
�� 
=
�� 
ImageSource
�� $
.
��$ %
FromFile
��% -
(
��- .
$str
��. <
)
��< =
;
��= >

TrackImage
�� 
=
�� 
ImageSource
�� $
.
��$ %
FromFile
��% -
(
��- .
$str
��. >
)
��> ?
;
��? @
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
MediaSource
��# .
!=
��/ 1
null
��2 6
)
��6 7
{
�� 
Artist
�� 
=
�� 

GlobalData
�� #
.
��# $
Current
��$ +
.
��+ ,
MediaSource
��, 7
.
��7 8
Artist
��8 >
;
��> ?
Title
�� 
=
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
MediaSource
��+ 6
.
��6 7
Title
��7 <
;
��< =
}
�� 
if
�� 
(
�� 
playedTrack
�� 
!=
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaSourcePath
��2 A
)
��A B
{
�� 
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '
MediaSource
��' 2
.
��2 3
Image
��3 8
!=
��9 ;
null
��< @
&&
��A C

GlobalData
��D N
.
��N O
Current
��O V
.
��V W
MediaSource
��W b
.
��b c
Image
��c h
.
��h i
Length
��i o
>
��p q
$num
��r s
)
��s t
{
�� 

TrackImage
�� 
=
��  
ImageProcessing
��! 0
.
��0 1
	FromArray
��1 :
(
��: ;

GlobalData
��; E
.
��E F
Current
��F M
.
��M N
MediaSource
��N Y
.
��Y Z
Image
��Z _
)
��_ `
;
��` a
	TrackBlur
�� 
=
�� 
ImageProcessing
��  /
.
��/ 0
Blur
��0 4
(
��4 5

GlobalData
��5 ?
.
��? @
Current
��@ G
.
��G H
MediaSource
��H S
.
��S T
Image
��T Y
)
��Y Z
;
��Z [#
BackgroundGridVisible
�� )
=
��* +
true
��, 0
;
��0 1
}
�� 
else
�� 
{
�� 

TrackImage
�� 
=
��  
ImageSource
��! ,
.
��, -
FromFile
��- 5
(
��5 6
$str
��6 F
)
��F G
;
��G H#
BackgroundGridVisible
�� )
=
��* +
false
��, 1
;
��1 2
}
�� 
playedTrack
�� 
=
�� 

GlobalData
�� (
.
��( )
Current
��) 0
.
��0 1
MediaSourcePath
��1 @
;
��@ A
}
�� 
if
�� 
(
�� 
isPlayImage
�� 
&&
�� 

GlobalData
�� )
.
��) *
Current
��* 1
.
��1 2
MediaPlayer
��2 =
.
��= >
	IsPlaying
��> G
)
��G H
{
�� 

PlayButton
�� 
=
�� 
ImageSource
�� (
.
��( )
FromFile
��) 1
(
��1 2
$str
��2 A
)
��A B
;
��B C
isPlayImage
�� 
=
�� 
false
�� #
;
��# $
}
�� 
if
�� 
(
�� 
!
�� 
isPlayImage
�� 
&&
�� 
!
��  !

GlobalData
��! +
.
��+ ,
Current
��, 3
.
��3 4
MediaPlayer
��4 ?
.
��? @
	IsPlaying
��@ I
)
��I J
{
�� 

PlayButton
�� 
=
�� 
ImageSource
�� (
.
��( )
FromFile
��) 1
(
��1 2
$str
��2 @
)
��@ A
;
��A B
isPlayImage
�� 
=
�� 
true
�� "
;
��" #
}
�� 
}
�� 	
}
�� 
}�� �L
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\TV\ModalViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
.& '
TV' )
{ 
public 

class 
ModalViewModel 
:  !
PropertyChangedBase" 5
{ 
private 
string 

modalTitle !
;! "
private 
string 
badge 
; 
private 
bool 
badgeVisible !
;! "
private 
bool 
topPanelVisible $
;$ %
private 
INFocusElement 
focusElementUp -
;- .
private 
INFocusElement 
focusElementDown /
;/ 0
private 
INFocusElement 
focusElementFromUp 1
;1 2
private 
INFocusElement  
focusElementFromDown 3
;3 4
public 
string 

ModalTitle  
{ 	
get 
=> 

modalTitle 
; 
set 
{   

modalTitle!! 
=!! 
value!! "
;!!" #
OnPropertyChanged"" !
(""! "
)""" #
;""# $
}## 
}$$ 	
public&& 
string&& 
Badge&& 
{'' 	
get(( 
=>(( 
badge(( 
;(( 
set)) 
{** 
badge++ 
=++ 
value++ 
;++ 
OnPropertyChanged,, !
(,,! "
),," #
;,,# $
}-- 
}.. 	
public// 
bool// 
BadgeVisible//  
{00 	
get11 
=>11 
badgeVisible11 
;11  
set22 
{33 
badgeVisible44 
=44 
value44 $
;44$ %
OnPropertyChanged55 !
(55! "
)55" #
;55# $
}66 
}77 	
public99 
bool99 
TopPanelVisible99 #
{:: 	
get;; 
=>;; 
topPanelVisible;; "
;;;" #
set<< 
{== 
topPanelVisible>> 
=>>  !
value>>" '
;>>' (
OnPropertyChanged?? !
(??! "
)??" #
;??# $
}@@ 
}AA 	
publicCC 
boolCC 
BackButtonVisibleCC %
=>CC& (
DeviceCC) /
.CC/ 0
RuntimePlatformCC0 ?
==CC@ B
DeviceCCC I
.CCI J
iOSCCJ M
;CCM N
publicEE 
GridEE 
	ContainerEE 
{EE 
getEE  #
;EE# $
privateEE% ,
setEE- 0
;EE0 1
}EE2 3
publicFF 
boolFF !
DownloadButtonVisibleFF )
=>FF* ,
falseFF- 2
;FF2 3
publicHH 
INFocusElementHH 
FocusElementUpHH ,
{II 	
getJJ 
=>JJ 
focusElementUpJJ !
;JJ! "
setKK 
{LL 
focusElementUpMM 
=MM  
valueMM! &
;MM& '
OnPropertyChangedNN !
(NN! "
)NN" #
;NN# $
}OO 
}PP 	
publicRR 
INFocusElementRR 
FocusElementDownRR .
{SS 	
getTT 
=>TT 
focusElementDownTT #
;TT# $
setUU 
{VV 
focusElementDownWW  
=WW! "
valueWW# (
;WW( )
OnPropertyChangedXX !
(XX! "
)XX" #
;XX# $
}YY 
}ZZ 	
public\\ 
INFocusElement\\ 
FocusElementFromUp\\ 0
{]] 	
get^^ 
=>^^ 
focusElementFromUp^^ %
;^^% &
set__ 
{`` 
focusElementFromUpaa "
=aa# $
valueaa% *
;aa* +
OnPropertyChangedbb !
(bb! "
)bb" #
;bb# $
}cc 
}dd 	
publicff 
INFocusElementff  
FocusElementFromDownff 2
{gg 	
gethh 
=>hh  
focusElementFromDownhh '
;hh' (
setii 
{jj  
focusElementFromDownkk $
=kk% &
valuekk' ,
;kk, -
OnPropertyChangedll !
(ll! "
)ll" #
;ll# $
}mm 
}nn 	
privaterr 
ICommandrr 
toFullScreenrr %
;rr% &
publicss 
ICommandss 
ToFullScreenss $
{tt 	
getuu 
{vv 
ifww 
(ww 
toFullScreenww  
==ww! #
nullww$ (
)ww( )
toFullScreenxx  
=xx! "
newxx# &
ActionCommandxx' 4
(xx4 5
asyncxx5 :
(xx; <
	parameterxx< E
)xxE F
=>xxG I
{yy 
ifzz 
(zz 

GlobalDatazz &
.zz& '
Currentzz' .
.zz. /
MediaSourcezz/ :
!=zz; =
nullzz> B
)zzB C
{{{ 
await|| !
Global||" (
.||( )
NavigationInstance||) ;
.||; <
PushModalAsync||< J
(||J K
new||K N
FullScreenPage||O ]
(||] ^
)||^ _
)||_ `
;||` a
}}} 
}~~ 
)~~ 
;~~ 
return
�� 
toFullScreen
�� #
;
��# $
}
�� 
}
�� 	
private
�� 
ICommand
�� 
toDownloadPage
�� '
;
��' (
public
�� 
ICommand
�� 
ToDownloadPage
�� &
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
toDownloadPage
�� "
==
��# %
null
��& *
)
��* +
toDownloadPage
�� "
=
��# $
new
��% (
ActionCommand
��) 6
(
��6 7
async
��7 <
(
��= >
	parameter
��> G
)
��G H
=>
��I K
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X
DownloadPage
��Y e
(
��e f
)
��f g
,
��g h
Localization
��i u
.
��u v
TitleDownloads��v �
)��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� 
toDownloadPage
�� %
;
��% &
}
�� 
}
�� 	
private
�� 
ICommand
�� 
backCommand
�� $
;
��$ %
public
�� 
ICommand
�� 
BackCommand
�� #
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
backCommand
�� 
==
��  "
null
��# '
)
��' (
backCommand
�� 
=
��  !
new
��" %
ActionCommand
��& 3
(
��3 4
async
��4 9
(
��: ;
	parameter
��; D
)
��D E
=>
��F H
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PopModalAsync
��8 E
(
��E F
)
��F G
;
��G H
}
�� 
)
�� 
;
�� 
return
�� 
backCommand
�� "
;
��" #
}
�� 
}
�� 	
public
�� 
ModalViewModel
�� 
(
�� 
Grid
�� "
	container
��# ,
,
��, -
string
��. 4
title
��5 :
,
��: ;
bool
��< @
topPanelVisible
��A P
=
��Q R
true
��S W
)
��W X
{
�� 	

ModalTitle
�� 
=
�� 
title
�� 
;
�� 
TopPanelVisible
�� 
=
�� 
topPanelVisible
�� -
;
��- .
	Container
�� 
=
�� 
	container
�� !
;
��! "
}
�� 	
public
�� 
void
�� 
	Appearing
�� 
(
�� 
)
�� 
{
�� 	
}
�� 	
public
�� 
void
�� 
Disappearing
��  
(
��  !
)
��! "
{
�� 	
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
Badge
�� 
=
��  
DownloadProcessing
�� &
.
��& '

BadgeCount
��' 1
.
��1 2
ToString
��2 :
(
��: ;
)
��; <
;
��< =
BadgeVisible
�� 
=
��  
DownloadProcessing
�� -
.
��- .

BadgeCount
��. 8
>
��9 :
$num
��; <
;
��< =
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
&&
��- /
	Container
��0 9
.
��9 :
Children
��: B
[
��B C
$num
��C D
]
��D E
is
��F H
ITimerContent
��I V
content
��W ^
)
��^ _
content
�� 
.
�� 
Tick
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� ��
ID:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\TV\NormalViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
.& '
TV' )
{ 
public 

class 
NormalViewModel  
:! "
PropertyChangedBase# 6
{ 
private 
readonly 

TracksPage #

tracksPage$ .
=/ 0
new1 4

TracksPage5 ?
(? @
)@ A
;A B
private 
readonly 

ArtistPage #

artistPage$ .
=/ 0
new1 4

ArtistPage5 ?
(? @
)@ A
;A B
private 
PlaylistPage 
playlistPage )
;) *
private 
string 
	pageTitle  
;  !
private 
string 
searchPlaceholder (
;( )
private 
bool 
badgeSyncVisible %
;% &
private   
string   
	badgeSync    
;    !
private!! 
bool!! 
badgeVisible!! !
;!!! "
private"" 
string"" 
badge"" 
;"" 
private## 
int## 
currentButtonIndex## &
=##' (
-##) *
$num##* +
;##+ ,
private$$ 
bool$$ 
titleVisible$$ !
=$$" #
true$$$ (
;$$( )
private%% 
bool%% 
entryVisible%% !
=%%" #
false%%$ )
;%%) *
private&& 
string&& 
	entryText&&  
;&&  !
private(( 
bool(( 
tracksButtonToggled(( (
;((( )
private)) 
bool))  
artistsButtonToggled)) )
;))) *
private** 
bool** "
playlistsButtonToggled** +
;**+ ,
private++ 
bool++ !
settingsButtonToggled++ *
;++* +
private,, 
PlayerPanel,, 
playerPanel,, '
;,,' (
private-- 
IDisposable-- 
loopSubscription-- ,
;--, -
private// 
bool// 
searchCancelVisible// (
;//( )
private00  
ObservableCollection00 $
<00$ %
HistoryModel00% 1
>001 2
suggestionItems003 B
;00B C
private11 
bool11 $
searchSuggestionsVisible11 -
=11. /
false110 5
;115 6
private22 
bool22 
spinnerVisible22 #
;22# $
private44 
INFocusElement44 
focusElementUp44 -
;44- .
private55 
INFocusElement55 
focusElementDown55 /
;55/ 0
private66 
INFocusElement66 
focusElementFromUp66 1
;661 2
private77 
INFocusElement77  
focusElementFromDown77 3
;773 4
public;; 
string;; 
	PageTitle;; 
{<< 	
get== 
=>== 
	pageTitle== 
;== 
set>> 
{?? 
	pageTitle@@ 
=@@ 
value@@ !
;@@! "
OnPropertyChangedAA !
(AA! "
)AA" #
;AA# $
}BB 
}CC 	
publicEE 
boolEE 
BadgeSyncVisibleEE $
{FF 	
getGG 
=>GG 
badgeSyncVisibleGG #
;GG# $
setHH 
{II 
badgeSyncVisibleJJ  
=JJ! "
valueJJ# (
;JJ( )
OnPropertyChangedKK !
(KK! "
)KK" #
;KK# $
}LL 
}MM 	
publicOO 
stringOO 
	BadgeSyncOO 
{PP 	
getQQ 
=>QQ 
	badgeSyncQQ 
;QQ 
setRR 
{SS 
	badgeSyncTT 
=TT 
valueTT !
;TT! "
OnPropertyChangedUU !
(UU! "
)UU" #
;UU# $
}VV 
}WW 	
publicYY 
boolYY 
BadgeVisibleYY  
{ZZ 	
get[[ 
=>[[ 
badgeVisible[[ 
;[[  
set\\ 
{]] 
badgeVisible^^ 
=^^ 
value^^ $
;^^$ %
OnPropertyChanged__ !
(__! "
)__" #
;__# $
}`` 
}aa 	
publiccc 
stringcc 
Badgecc 
{dd 	
getee 
=>ee 
badgeee 
;ee 
setff 
{gg 
badgehh 
=hh 
valuehh 
;hh 
OnPropertyChangedii !
(ii! "
)ii" #
;ii# $
}jj 
}kk 	
publicmm 
Gridmm 
	Containermm 
{mm 
getmm  #
;mm# $
privatemm% ,
setmm- 0
;mm0 1
}mm2 3
publicoo 
booloo 
TracksButtonToggledoo '
{pp 	
getqq 
=>qq 
tracksButtonToggledqq &
;qq& '
setrr 
{ss 
tracksButtonToggledtt #
=tt$ %
valuett& +
;tt+ ,
OnPropertyChangeduu !
(uu! "
)uu" #
;uu# $
}vv 
}ww 	
publicyy 
boolyy  
ArtistsButtonToggledyy (
{zz 	
get{{ 
=>{{  
artistsButtonToggled{{ '
;{{' (
set|| 
{}}  
artistsButtonToggled~~ $
=~~% &
value~~' ,
;~~, -
OnPropertyChanged !
(! "
)" #
;# $
}
�� 
}
�� 	
public
�� 
bool
�� $
PlaylistsButtonToggled
�� *
{
�� 	
get
�� 
=>
�� $
playlistsButtonToggled
�� )
;
��) *
set
�� 
{
�� $
playlistsButtonToggled
�� &
=
��' (
value
��) .
;
��. /
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� #
SettingsButtonToggled
�� )
{
�� 	
get
�� 
=>
�� #
settingsButtonToggled
�� (
;
��( )
set
�� 
{
�� #
settingsButtonToggled
�� %
=
��& '
value
��( -
;
��- .
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
PlayerPanel
�� 
PlayerPanel
�� &
{
�� 	
get
�� 
=>
�� 
playerPanel
�� 
;
�� 
set
�� 
{
�� 
playerPanel
�� 
=
�� 
value
�� #
;
��# $
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
string
�� 
SearchPlaceholder
�� '
{
�� 	
get
�� 
=>
�� 
searchPlaceholder
�� $
;
��$ %
set
�� 
{
�� 
searchPlaceholder
�� !
=
��" #
value
��$ )
;
��) *
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
TitleVisible
��  
{
�� 	
get
�� 
=>
�� 
titleVisible
�� 
;
��  
set
�� 
{
�� 
titleVisible
�� 
=
�� 
value
�� $
;
��$ %
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
EntryVisible
��  
{
�� 	
get
�� 
=>
�� 
entryVisible
�� 
;
��  
set
�� 
{
�� 
entryVisible
�� 
=
�� 
value
�� $
;
��$ %
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
string
�� 
	EntryText
�� 
{
�� 	
get
�� 
=>
�� 
	entryText
�� 
;
�� 
set
�� 
{
�� 
	entryText
�� 
=
�� 
value
�� !
;
��! "
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $!
SearchCancelVisible
�� #
=
��$ %
	entryText
��& /
.
��/ 0
Length
��0 6
>
��7 8
$num
��9 :
;
��: ;
}
�� 
}
�� 	
public
�� 
bool
�� !
SearchCancelVisible
�� '
{
�� 	
get
�� 
=>
�� !
searchCancelVisible
�� &
;
��& '
set
�� 
{
�� !
searchCancelVisible
�� #
=
��$ %
value
��& +
;
��+ ,
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� "
ObservableCollection
�� #
<
��# $
HistoryModel
��$ 0
>
��0 1
SuggestionItems
��2 A
{
�� 	
get
�� 
=>
�� 
suggestionItems
�� "
;
��" #
set
�� 
{
�� 
suggestionItems
�� 
=
��  !
value
��" '
;
��' (
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� &
SearchSuggestionsVisible
�� ,
{
�� 	
get
�� 
=>
�� &
searchSuggestionsVisible
�� +
;
��+ ,
set
�� 
{
�� &
searchSuggestionsVisible
�� (
=
��) *
value
��+ 0
;
��0 1
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
bool
�� 
SpinnerVisible
�� "
{
�� 	
get
�� 
=>
�� 
spinnerVisible
�� !
;
��! "
set
�� 
{
�� 
spinnerVisible
�� 
=
��  
value
��! &
;
��& '
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
INFocusElement
�� 
FocusElementUp
�� ,
{
�� 	
get
�� 
=>
�� 
focusElementUp
�� !
;
��! "
set
�� 
{
�� 
focusElementUp
�� 
=
��  
value
��! &
;
��& '
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
INFocusElement
�� 
FocusElementDown
�� .
{
�� 	
get
�� 
=>
�� 
focusElementDown
�� #
;
��# $
set
�� 
{
�� 
focusElementDown
��  
=
��! "
value
��# (
;
��( )
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
INFocusElement
��  
FocusElementFromUp
�� 0
{
�� 	
get
�� 
=>
��  
focusElementFromUp
�� %
;
��% &
set
�� 
{
��  
focusElementFromUp
�� "
=
��# $
value
��% *
;
��* +
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
public
�� 
INFocusElement
�� "
FocusElementFromDown
�� 2
{
�� 	
get
�� 
=>
�� "
focusElementFromDown
�� '
;
��' (
set
�� 
{
�� "
focusElementFromDown
�� $
=
��% &
value
��' ,
;
��, -
OnPropertyChanged
�� !
(
��! "
)
��" #
;
��# $
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoPlayerCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoPlayer
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoPlayerCommand
�� %
==
��& (
null
��) -
)
��- .
gotoPlayerCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
async
��: ?
(
��@ A
	parameter
��A J
)
��J K
=>
��L N
{
�� 
if
�� 
(
�� 

GlobalData
�� &
.
��& '
Current
��' .
.
��. /
MediaSource
��/ :
!=
��; =
null
��> B
)
��B C
{
�� 
await
�� !
Global
��" (
.
��( ) 
NavigationInstance
��) ;
.
��; <
PushModalAsync
��< J
(
��J K
new
��K N
FullScreenPage
��O ]
(
��] ^
)
��^ _
)
��_ `
;
��` a
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoPlayerCommand
�� (
;
��( )
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoTracksCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoTracks
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoTracksCommand
�� %
==
��& (
null
��) -
)
��- .
gotoTracksCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
	parameter
��: C
=>
��D F
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
||
��4 6
(
��7 8
	parameter
��8 A
as
��B D
bool
��E I
?
��I J
)
��J K
==
��L N
true
��O S
)
��S T
{
�� 
SetContainer
�� (
(
��( )

tracksPage
��) 3
,
��3 4
Localization
��5 A
.
��A B
Tracks
��B H
)
��H I
;
��I J
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
�� 
gotoTracksCommand
�� (
;
��( )
}
�� 
}
�� 	
private
�� 
ICommand
��  
gotoArtistsCommand
�� +
;
��+ ,
public
�� 
ICommand
�� 
GotoArtists
�� #
{
�� 	
get
�� 
{
�� 
if
�� 
(
��  
gotoArtistsCommand
�� &
==
��' )
null
��* .
)
��. / 
gotoArtistsCommand
�� &
=
��' (
new
��) ,
ActionCommand
��- :
(
��: ;
	parameter
��; D
=>
��E G
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
||
��4 6
(
��7 8
	parameter
��8 A
as
��B D
bool
��E I
?
��I J
)
��J K
==
��L N
true
��O S
)
��S T
{
�� 
SetContainer
�� (
(
��( )

artistPage
��) 3
,
��3 4
Localization
��5 A
.
��A B
Artists
��B I
)
��I J
;
��J K
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
��  
gotoArtistsCommand
�� )
;
��) *
}
�� 
}
�� 	
private
�� 
ICommand
�� "
gotoPlaylistsCommand
�� -
;
��- .
public
�� 
ICommand
�� 
GotoPlaylists
�� %
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� "
gotoPlaylistsCommand
�� (
==
��) +
null
��, 0
)
��0 1"
gotoPlaylistsCommand
�� (
=
��) *
new
��+ .
ActionCommand
��/ <
(
��< =
	parameter
��= F
=>
��G I
{
�� 
if
�� 
(
��  
currentButtonIndex
�� .
!=
��/ 1
$num
��2 3
)
��3 4
{
�� 
if
�� 
(
��  
playlistPage
��  ,
==
��- /
null
��0 4
)
��4 5
playlistPage
��  ,
=
��- .
new
��/ 2
PlaylistPage
��3 ?
(
��? @
)
��@ A
;
��A B
SetContainer
�� (
(
��( )
playlistPage
��) 5
,
��5 6
Localization
��7 C
.
��C D
	Playlists
��D M
)
��M N
;
��N O
Toggle
�� "
(
��" #
$num
��# $
)
��$ %
;
��% &
}
�� 
}
�� 
)
�� 
;
�� 
return
�� "
gotoPlaylistsCommand
�� +
;
��+ ,
}
�� 
}
�� 	
private
�� 
ICommand
�� !
gotoSettingsCommand
�� ,
;
��, -
public
�� 
ICommand
�� 
GotoSettings
�� $
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� !
gotoSettingsCommand
�� '
==
��( *
null
��+ /
)
��/ 0!
gotoSettingsCommand
�� '
=
��( )
new
��* -
ActionCommand
��. ;
(
��; <
async
��< A
(
��A B
	parameter
��B K
)
��K L
=>
��M O
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X
SettingsPage
��Y e
(
��e f
)
��f g
,
��g h
Localization
��i u
.
��u v
Settings
��v ~
)
��~ 
)�� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� !
gotoSettingsCommand
�� *
;
��* +
}
�� 
}
�� 	
private
�� 
ICommand
�� !
gotoDownloadCommand
�� ,
;
��, -
public
�� 
ICommand
�� 
GotoDownload
�� $
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� !
gotoDownloadCommand
�� '
==
��( *
null
��+ /
)
��/ 0!
gotoDownloadCommand
�� '
=
��( )
new
��* -
ActionCommand
��. ;
(
��; <
async
��< A
(
��B C
	parameter
��C L
)
��L M
=>
��N P
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X
Views
��Y ^
.
��^ _
DownloadPage
��_ k
(
��k l
)
��l m
,
��m n
Localization
��o {
.
��{ |
TitleDownloads��| �
)��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� !
gotoDownloadCommand
�� *
;
��* +
}
�� 
}
�� 	
private
�� 
ICommand
�� 
gotoSearchCommand
�� *
;
��* +
public
�� 
ICommand
�� 

GotoSearch
�� "
{
�� 	
get
�� 
{
�� 
if
�� 
(
�� 
gotoSearchCommand
�� %
==
��& (
null
��) -
)
��- .
gotoSearchCommand
�� %
=
��& '
new
��( +
ActionCommand
��, 9
(
��9 :
async
��: ?
(
��? @
	parameter
��@ I
)
��I J
=>
��K M
{
�� 
await
�� 
Global
�� $
.
��$ % 
NavigationInstance
��% 7
.
��7 8
PushModalAsync
��8 F
(
��F G
new
��G J
	ModalPage
��K T
(
��T U
new
��U X

SearchPage
��Y c
(
��c d
)
��d e
,
��e f
Localization
��g s
.
��s t
Search
��t z
,
��z {
false��{ �
)��� �
)��� �
;��� �
}
�� 
)
�� 
;
�� 
return
�� 
gotoSearchCommand
�� (
;
��( )
}
�� 
}
�� 	
public
�� 
NormalViewModel
�� 
(
�� 
Grid
�� #
	container
��$ -
,
��- .
PlayerPanel
��/ :
panel
��; @
,
��@ A
INFocusElement
��B P 
focusElementFromUp
��Q c
,
��c d
INFocusElement
��e s#
focusElementFromDown��t �
)��� �
{
�� 	 
FocusElementFromUp
�� 
=
��   
focusElementFromUp
��! 3
;
��3 4"
FocusElementFromDown
��  
=
��! ""
focusElementFromDown
��# 7
;
��7 8
SuggestionItems
�� 
=
�� 
new
�� !"
ObservableCollection
��" 6
<
��6 7
HistoryModel
��7 C
>
��C D
(
��D E
)
��E F
;
��F G
	Container
�� 
=
�� 
	container
�� !
;
��! "
PlayerPanel
�� 
=
�� 
panel
�� 
;
��  
SpinnerVisible
�� 
=
�� 
true
�� !
;
��! "
	Directory
�� 
.
�� 
CreateDirectory
�� %
(
��% &

GlobalData
��& 0
.
��0 1
Current
��1 8
.
��8 9
	MusicPath
��9 B
)
��B C
;
��C D
GotoArtists
�� 
.
�� 
Execute
�� 
(
��  
true
��  $
)
��$ %
;
��% &
if
�� 
(
�� 
!
�� 
Global
�� 
.
�� 
Loaded
�� 
)
�� 
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadTags
��# +
(
��+ ,
)
��, -
;
��- .

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadSavedTracks
��# 2
(
��2 3
)
��3 4
;
��4 5
Task
�� 
task
�� 
=
�� 
Task
��  
.
��  !
Run
��! $
(
��$ %
async
��% *
(
��+ ,
)
��, -
=>
��. 0
{
�� 
if
�� 
(
�� 
CacheLoader
�� #
.
��# $
IsCacheAvailable
��$ 4
(
��4 5
)
��5 6
)
��6 7
CacheLoader
�� #
.
��# $
	LoadCache
��$ -
(
��- .
)
��. /
;
��/ 0
await
�� 
GlobalLoader
�� &
.
��& '
Load
��' +
(
��+ ,
)
��, -
;
��- .
}
�� 
)
�� 
;
�� 
task
�� 
.
�� 
ContinueWith
�� !
(
��! "
t
��" #
=>
��$ &
{
�� 

GlobalData
�� 
.
�� 
Current
�� &
.
��& '

LoadConfig
��' 1
(
��1 2
)
��2 3
;
��3 4
Global
�� 
.
�� 
Loaded
�� !
=
��" #
true
��$ (
;
��( )
if
�� 
(
�� 

GlobalData
�� "
.
��" #
Current
��# *
.
��* +
AutoDownload
��+ 7
&&
��8 :
Global
��; A
.
��A B
Application
��B M
.
��M N
HasInternet
��N Y
(
��Y Z
)
��Z [
)
��[ \
{
�� 
Task
�� 
.
�� 
Run
��  
(
��  !
async
��! &
(
��' (
)
��( )
=>
��* ,
{
�� 
YoutubeClient
�� )
client
��* 0
=
��1 2
new
��3 6
YoutubeClient
��7 D
(
��D E
)
��E F
;
��F G
foreach
�� #
(
��$ %
var
��% (
key
��) ,
in
��- /

GlobalData
��0 :
.
��: ;
Current
��; B
.
��B C!
WebToLocalPlaylists
��C V
.
��V W
Keys
��W [
.
��[ \
ToList
��\ b
(
��b c
)
��c d
)
��d e
{
�� 
if
��  "
(
��# $

GlobalData
��$ .
.
��. /
Current
��/ 6
.
��6 7
	Playlists
��7 @
.
��@ A
ContainsKey
��A L
(
��L M

GlobalData
��M W
.
��W X
Current
��X _
.
��_ `!
WebToLocalPlaylists
��` s
[
��s t
key
��t w
]
��w x
)
��x y
)
��y z 
DownloadProcessing
��$ 6
.
��6 7
AddRange
��7 ?
(
��? @
await
��@ E
client
��F L
.
��L M
	Playlists
��M V
.
��V W
GetVideosAsync
��W e
(
��e f
key
��f i
)
��i j
,
��j k

GlobalData
��l v
.
��v w
Current
��w ~
.
��~ "
WebToLocalPlaylists�� �
[��� �
key��� �
]��� �
,��� �
key��� �
,��� �
true��� �
)��� �
;��� �
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
	Appearing
�� 
(
�� 
)
�� 
{
�� 	
var
�� 
src
�� 
=
�� 
System
�� 
.
�� 
Reactive
�� %
.
��% &
Linq
��& *
.
��* +

Observable
��+ 5
.
��5 6
Timer
��6 ;
(
��; <
TimeSpan
��< D
.
��D E
Zero
��E I
,
��I J
TimeSpan
��K S
.
��S T
FromMilliseconds
��T d
(
��d e
$num
��e h
)
��h i
)
��i j
.
��j k
	Timestamp
��k t
(
��t u
)
��u v
;
��v w
loopSubscription
�� 
=
�� 
src
�� "
.
��" #
	Subscribe
��# ,
(
��, -
time
��- 1
=>
��2 4
Tick
��5 9
(
��9 :
)
��: ;
)
��; <
;
��< =
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
&&
��- /
	Container
��0 9
.
��9 :
Children
��: B
[
��B C
$num
��C D
]
��D E
is
��F H
IVisibleContent
��I X
)
��X Y
(
�� 
	Container
�� 
.
�� 
Children
�� #
[
��# $
$num
��$ %
]
��% &
as
��' )
IVisibleContent
��* 9
)
��9 :
.
��: ;
	Appearing
��; D
(
��D E
)
��E F
;
��F G
if
�� 
(
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
Audios
��# )
.
��) *
Count
��* /
==
��0 2
$num
��3 4
&&
��5 7

GlobalData
��8 B
.
��B C
Current
��C J
.
��J K
SavedTracks
��K V
.
��V W
Count
��W \
==
��] _
$num
��` a
)
��a b
{
�� 

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadTags
��# +
(
��+ ,
)
��, -
;
��- .
CacheLoader
�� 
.
�� 
	LoadCache
�� %
(
��% &
)
��& '
;
��' (

GlobalData
�� 
.
�� 
Current
�� "
.
��" #
LoadSavedTracks
��# 2
(
��2 3
)
��3 4
;
��4 5

GlobalData
�� 
.
�� 
Current
�� "
.
��" #

LoadConfig
��# -
(
��- .
)
��. /
;
��/ 0
}
�� 
}
�� 	
public
�� 
void
�� 
Disappearing
��  
(
��  !
)
��! "
{
�� 	
loopSubscription
�� 
?
�� 
.
�� 
Dispose
�� %
(
��% &
)
��& '
;
��' (
loopSubscription
�� 
=
�� 
null
�� #
;
��# $
}
�� 	
public
�� 
void
�� 
Tick
�� 
(
�� 
)
�� 
{
�� 	
SearchPlaceholder
�� 
=
�� 
Localization
��  ,
.
��, -
Search
��- 3
;
��3 4
Badge
�� 
=
��  
DownloadProcessing
�� &
.
��& '

BadgeCount
��' 1
.
��1 2
ToString
��2 :
(
��: ;
)
��; <
;
��< =
BadgeVisible
�� 
=
��  
DownloadProcessing
�� -
.
��- .

BadgeCount
��. 8
>
��9 :
$num
��; <
;
��< =
SpinnerVisible
�� 
=
�� 
	Container
�� &
.
��& '
Children
��' /
.
��/ 0
Count
��0 5
==
��6 8
$num
��9 :
||
��; =
!
��> ?
Global
��? E
.
��E F
Loaded
��F L
;
��L M
PlayerPanel
�� 
?
�� 
.
�� 
Tick
�� 
(
�� 
)
�� 
;
��  
foreach
�� 
(
�� 
var
�� 
children
�� !
in
��" $
	Container
��% .
.
��. /
Children
��/ 7
.
��7 8
ToList
��8 >
(
��> ?
)
��? @
)
��@ A
{
�� 
if
�� 
(
�� 
children
�� 
.
�� 
	IsVisible
�� &
&&
��' )
children
��* 2
is
��3 5
ITimerContent
��6 C
content
��D K
)
��K L
content
�� 
.
�� 
Tick
��  
(
��  !
)
��! "
;
��" #
}
�� 
}
�� 	
public
�� 
void
�� 
RefreshSuggestion
�� %
(
��% &
)
��& '
{
�� 	
string
�� 
searchedText
�� 
=
��  !
	EntryText
��" +
??
��, .
$str
��/ 1
;
��1 2
var
�� 
newList
�� 
=
�� 
SearchProcessing
�� *
.
��* +'
GenerateSearchSuggestions
��+ D
(
��D E
)
��E F
.
��F G
FindAll
��G N
(
��N O
item
�� 
=>
�� 
searchedText
�� $
.
��$ %
ToLowerInvariant
��% 5
(
��5 6
)
��6 7
.
��7 8
Contains
��8 @
(
��@ A
item
��A E
.
��E F
ToLowerInvariant
��F V
(
��V W
)
��W X
)
��X Y
||
��Z \
item
��] a
.
��a b
ToLowerInvariant
��b r
(
��r s
)
��s t
.
��t u
Contains
��u }
(
��} ~
searchedText��~ �
.��� � 
ToLowerInvariant��� �
(��� �
)��� �
)��� �
)��� �
;��� �
SuggestionItems
�� 
.
�� 
Clear
�� !
(
��! "
)
��" #
;
��# $
foreach
�� 
(
�� 
var
�� 
item
�� 
in
��  
newList
��! (
)
��( )
{
�� 
SuggestionItems
�� 
.
��  
Add
��  #
(
��# $
new
��$ '
HistoryModel
��( 4
(
��4 5
)
��5 6
{
��7 8
Text
��9 =
=
��> ?
item
��@ D
}
��E F
)
��F G
;
��G H
}
�� 
}
�� 	
public
�� 
async
�� 
void
�� %
SuggestionItem_Selected
�� 1
(
��1 2
object
��2 8
sender
��9 ?
,
��? @*
SelectedItemChangedEventArgs
��A ]
e
��^ _
)
��_ `
{
�� 	
int
�� 
index
�� 
=
�� 
e
�� 
.
�� 
SelectedItemIndex
�� +
;
��+ ,
if
�� 
(
�� 
index
�� 
>=
�� 
$num
�� 
&&
�� 
index
�� #
<
��$ %
SuggestionItems
��& 5
.
��5 6
Count
��6 ;
)
��; <
{
�� 
if
�� 
(
�� 
Global
�� 
.
�� 
Application
�� &
.
��& '
HasInternet
��' 2
(
��2 3
)
��3 4
)
��4 5
{
�� 
await
�� 
Global
��  
.
��  ! 
NavigationInstance
��! 3
.
��3 4
PushModalAsync
��4 B
(
��B C
new
��C F
	ModalPage
��G P
(
��P Q
new
��Q T
SearchResultPage
��U e
(
��e f
SuggestionItems
��f u
[
��u v
index
��v {
]
��{ |
.
��| }
Text��} �
)��� �
,��� �
SuggestionItems��� �
[��� �
index��� �
]��� �
.��� �
Text��� �
)��� �
)��� �
;��� �
}
�� 
else
�� 
await
�� 
Global
��  
.
��  !
Page
��! %
.
��% &
DisplayAlert
��& 2
(
��2 3
Localization
��3 ?
.
��? @
Warning
��@ G
,
��G H
Localization
��I U
.
��U V
NoConnection
��V b
,
��b c
Localization
��d p
.
��p q
Cancel
��q w
)
��w x
;
��x y
(
�� 
sender
�� 
as
�� 
ListView
�� #
)
��# $
.
��$ %
SelectedItem
��% 1
=
��2 3
null
��4 8
;
��8 9
}
�� 
}
�� 	
private
�� 
void
�� 
Toggle
�� 
(
�� 
int
�� 
buttonIndex
��  +
=
��, -
$num
��. /
)
��/ 0
{
�� 	!
TracksButtonToggled
�� 
=
��  !
buttonIndex
��" -
==
��. 0
$num
��1 2
;
��2 3"
ArtistsButtonToggled
��  
=
��! "
buttonIndex
��# .
==
��/ 1
$num
��2 3
;
��3 4$
PlaylistsButtonToggled
�� "
=
��# $
buttonIndex
��% 0
==
��1 3
$num
��4 5
;
��5 6#
SettingsButtonToggled
�� !
=
��" #
buttonIndex
��$ /
==
��0 2
$num
��3 4
;
��4 5 
currentButtonIndex
�� 
=
��  
buttonIndex
��! ,
;
��, -
}
�� 	
private
�� 
void
�� 
SetContainer
�� !
(
��! "
ContentView
��" -
content
��. 5
,
��5 6
string
��7 =
title
��> C
)
��C D
{
�� 	
if
�� 
(
�� 
!
�� 
	Container
�� 
.
�� 
Children
�� #
.
��# $
Contains
��$ ,
(
��, -
content
��- 4
)
��4 5
)
��5 6
	Container
�� 
.
�� 
Children
�� "
.
��" #
Add
��# &
(
��& '
content
��' .
)
��. /
;
��/ 0
else
�� 
{
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Remove
��# )
(
��) *
content
��* 1
)
��1 2
;
��2 3
	Container
�� 
.
�� 
Children
�� "
.
��" #
Add
��# &
(
��& '
content
��' .
)
��. /
;
��/ 0
}
�� 
if
�� 
(
�� 
content
�� 
is
�� 
INFocusContent
�� (
focusContent
��) 5
)
��5 6
{
�� 
FocusElementDown
��  
=
��! "
focusContent
��# /
.
��/ 0
BottomElement
��0 =
;
��= >
FocusElementUp
�� 
=
��  
focusContent
��! -
.
��- .

TopElement
��. 8
;
��8 9
focusContent
�� 
.
�� 

TopElement
�� '
.
��' (
NextFocusUp
��( 3
=
��4 5 
FocusElementFromUp
��6 H
;
��H I
focusContent
�� 
.
�� 
BottomElement
�� *
.
��* +
NextFocusDown
��+ 8
=
��9 :"
FocusElementFromDown
��; O
;
��O P
}
�� 
if
�� 
(
�� 
	Container
�� 
.
�� 
Children
�� "
.
��" #
Count
��# (
>
��) *
$num
��+ ,
)
��, -
{
�� 
foreach
�� 
(
�� 
var
�� 
children
�� %
in
��& (
	Container
��) 2
.
��2 3
Children
��3 ;
)
��; <
{
�� 
if
�� 
(
�� 
children
��  
.
��  !
	IsVisible
��! *
)
��* +
{
�� 
if
�� 
(
�� 
children
�� $
is
��% '
IVisibleContent
��( 7
)
��7 8
(
�� 
children
�� %
as
��& (
IVisibleContent
��) 8
)
��8 9
.
��9 :
Disappearing
��: F
(
��F G
)
��G H
;
��H I
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
false
��- 2
;
��2 3
}
�� 
if
�� 
(
�� 
children
��  
==
��! #
content
��$ +
)
��+ ,
{
�� 
if
�� 
(
�� 
children
�� $
is
��% '
IVisibleContent
��( 7
)
��7 8
(
�� 
children
�� %
as
��& (
IVisibleContent
��) 8
)
��8 9
.
��9 :
	Appearing
��: C
(
��C D
)
��D E
;
��E F
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
true
��- 1
;
��1 2
}
�� 
else
�� 
children
��  
.
��  !
	IsVisible
��! *
=
��+ ,
false
��- 2
;
��2 3
}
�� 
}
�� 
	PageTitle
�� 
=
�� 
title
�� 
;
�� 
}
�� 	
}
�� 
}�� � 
ID:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\TV\SearchViewModel.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 

ViewModels

 &
.

& '
TV

' )
{ 
public 

class 
SearchViewModel  
:! "
PropertyChangedBase# 6
{ 
private 
string 

searchText !
;! "
private  
ObservableCollection $
<$ %
NListViewItem% 2
>2 3
suggestionItems4 C
;C D
public 
bool 
SearchTextVisible %
{& '
get( +
;+ ,
private- 4
set5 8
;8 9
}: ;
public 
string 

SearchText  
{ 	
get 
=> 

searchText 
; 
set 
{ 

searchText 
= 
value "
;" #
OnPropertyChanged !
(! "
)" #
;# $
SearchTextVisible !
=" #

searchText$ .
.. /
Length/ 5
>6 7
$num8 9
;9 :
OnPropertyChanged !
(! "
(" #
)# $
=>% '
SearchTextVisible( 9
)9 :
;: ;
} 
}   	
public""  
ObservableCollection"" #
<""# $
NListViewItem""$ 1
>""1 2
SuggestionItems""3 B
{## 	
get$$ 
=>$$ 
suggestionItems$$ "
;$$" #
set%% 
{&& 
suggestionItems'' 
=''  !
value''" '
;''' (
OnPropertyChanged(( !
(((! "
)((" #
;((# $
})) 
}** 	
public,, 
Func,, 
<,, 
NListViewItem,, !
,,,! "
View,,# '
>,,' (
ItemTemplate,,) 5
=>,,6 8
item,,9 =
=>,,> @
new,,A D
SuggestionViewCell,,E W
(,,W X
item,,X \
),,\ ]
;,,] ^
public// 
SearchViewModel// 
(// 
)//  
{00 	
SuggestionItems11 
=11 
new11 ! 
ObservableCollection11" 6
<116 7
NListViewItem117 D
>11D E
(11E F
)11F G
;11G H
}22 	
public55 
void55 
RefreshSuggestion55 %
(55% &
)55& '
{66 	
string77 
searchedText77 
=77  !

SearchText77" ,
??77- /
$str770 2
;772 3
var88 
newList88 
=88 
SearchProcessing88 *
.88* +%
GenerateSearchSuggestions88+ D
(88D E
)88E F
.88F G
FindAll88G N
(88N O
item99 
=>99 
searchedText99 $
.99$ %
ToLowerInvariant99% 5
(995 6
)996 7
.997 8
Contains998 @
(99@ A
item99A E
.99E F
ToLowerInvariant99F V
(99V W
)99W X
)99X Y
||99Z \
item99] a
.99a b
ToLowerInvariant99b r
(99r s
)99s t
.99t u
Contains99u }
(99} ~
searchedText	99~ �
.
99� �
ToLowerInvariant
99� �
(
99� �
)
99� �
)
99� �
)
99� �
;
99� �
SuggestionItems;; 
.;; 
Clear;; !
(;;! "
);;" #
;;;# $
foreach<< 
(<< 
var<< 
item<< 
in<<  
newList<<! (
)<<( )
{== 
SuggestionItems>> 
.>>  
Add>>  #
(>># $
new>>$ '
SuggestionModel>>( 7
(>>7 8
)>>8 9
{>>: ;
Text>>< @
=>>A B
item>>C G
}>>H I
)>>I J
;>>J K
}?? 
}@@ 	
}BB 
}CC �0
XD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\ViewCells\ArtistGridItemViewModel.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 

ViewModels

 &
.

& '
	ViewCells

' 0
{ 
public 

class #
ArtistGridItemViewModel (
:) *
PropertyChangedBase+ >
{ 
private 
string 

artistName !
;! "
private 
string 

tracksText !
;! "
private 
ImageSource 
image !
;! "
private 
Xamarin 
. 
Forms 
. 
View "
View# '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 

ArtistName  
{ 	
get 
=> 

artistName 
; 
set 
{ 

artistName 
= 
value "
;" #
OnPropertyChanged !
(! "
)" #
;# $
} 
} 	
public 
string 

TracksText  
{   	
get!! 
=>!! 

tracksText!! 
;!! 
set"" 
{## 

tracksText$$ 
=$$ 
value$$ "
;$$" #
OnPropertyChanged%% !
(%%! "
)%%" #
;%%# $
}&& 
}'' 	
public)) 
ImageSource)) 
Image))  
{** 	
get++ 
=>++ 
image++ 
;++ 
set,, 
{-- 
image.. 
=.. 
value.. 
;.. 
OnPropertyChanged// !
(//! "
)//" #
;//# $
}00 
}11 	
private44 
ICommand44 
longPressedCommand44 +
;44+ ,
public55 
ICommand55 
LongPressedCommand55 *
{66 	
get77 
{88 
if99 
(99 
longPressedCommand99 &
==99' )
null99* .
)99. /
longPressedCommand:: &
=::' (
new::) ,
ActionCommand::- :
(::: ;
	parameter::; D
=>::E G
{;; 
ContextMenuBuilder<< *
.<<* +
BuildForArtist<<+ 9
(<<9 :
View<<: >
,<<> ?

ArtistName<<@ J
)<<J K
;<<K L
}== 
)== 
;== 
return?? 
longPressedCommand?? )
;??) *
}@@ 
}AA 	
privateCC 
ICommandCC 
pressedCommandCC '
;CC' (
publicDD 
ICommandDD 
PressedCommandDD &
{EE 	
getFF 
{GG 
ifHH 
(HH 
pressedCommandHH "
==HH# %
nullHH& *
)HH* +
pressedCommandII "
=II# $
newII% (
ActionCommandII) 6
(II6 7
asyncII7 <
(II= >
	parameterII> G
)IIG H
=>III K
{JJ 
awaitKK 
GlobalKK $
.KK$ %
NavigationInstanceKK% 7
.KK7 8
PushModalAsyncKK8 F
(KKF G
newKKG J
	ModalPageKKK T
(KKT U
newKKU X
CurrentTracksPageKKY j
(KKj k

GlobalDataKKk u
.KKu v
CurrentKKv }
.KK} ~
Artists	KK~ �
[
KK� �

ArtistName
KK� �
]
KK� �
,
KK� �
$str
KK� �
)
KK� �
,
KK� �

ArtistName
KK� �
)
KK� �
)
KK� �
;
KK� �
}LL 
)LL 
;LL 
returnMM 
pressedCommandMM %
;MM% &
}NN 
}OO 	
publicRR #
ArtistGridItemViewModelRR &
(RR& '
stringRR' -

artistNameRR. 8
,RR8 9
XamarinRR: A
.RRA B
FormsRRB G
.RRG H
ViewRRH L
viewRRM Q
)RRQ R
{SS 	

InitializeTT 
(TT 

artistNameTT !
,TT! "
viewTT# '
)TT' (
;TT( )
}UU 	
publicXX 
voidXX 

InitializeXX 
(XX 
stringXX %

artistNameXX& 0
,XX0 1
ViewXX2 6
viewXX7 ;
)XX; <
{YY 	
ViewZZ 
=ZZ 
viewZZ 
;ZZ 

ArtistName[[ 
=[[ 

artistName[[ #
;[[# $

TracksText\\ 
=\\ 
Localization\\ %
.\\% &
Tracks\\& ,
+\\- .
$str\\/ 3
+\\4 5

GlobalData\\6 @
.\\@ A
Current\\A H
.\\H I
Artists\\I P
[\\P Q

artistName\\Q [
]\\[ \
.\\\ ]
Count\\] b
;\\b c
Image]] 
=]] 
ImageSource]] 
.]]  
FromFile]]  (
(]]( )
$str]]) 9
)]]9 :
;]]: ;
foreach__ 
(__ 
string__ 
filePath__ $
in__% '

GlobalData__( 2
.__2 3
Current__3 :
.__: ;
Artists__; B
[__B C

artistName__C M
]__M N
)__N O
{`` 
varaa 
sourceaa 
=aa 

GlobalDataaa '
.aa' (
Currentaa( /
.aa/ 0
Audiosaa0 6
[aa6 7
filePathaa7 ?
]aa? @
;aa@ A
ifbb 
(bb 
sourcebb 
.bb 
Imagebb  
!=bb! #
nullbb$ (
)bb( )
{cc 
Imagedd 
=dd 
ImageProcessingdd +
.dd+ ,
	FromArraydd, 5
(dd5 6
sourcedd6 <
.dd< =
Imagedd= B
)ddB C
;ddC D
breakee 
;ee 
}ff 
}gg 
}hh 	
}jj 
}kk �C
ZD:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\ViewCells\PlaylistGridItemViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
.& '
	ViewCells' 0
{ 
public 

class %
PlaylistGridItemViewModel *
:+ ,
PropertyChangedBase- @
{ 
private 
string 
playlistName #
;# $
private 
string 

tracksText !
;! "
private 
string 
playlistUrl "
;" #
private 
ImageSource 
image !
;! "
private 
Xamarin 
. 
Forms 
. 
View "
View# '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
PlaylistName "
{ 	
get 
=> 
playlistName 
;  
set 
{ 
playlistName 
= 
value $
;$ %
OnPropertyChanged   !
(  ! "
)  " #
;  # $
}!! 
}"" 	
public$$ 
string$$ 
PlaylistUrl$$ !
{%% 	
get&& 
=>&& 
playlistUrl&& 
;&& 
set'' 
{(( 
playlistUrl)) 
=)) 
value)) #
;))# $
OnPropertyChanged** !
(**! "
)**" #
;**# $
}++ 
},, 	
public.. 
string.. 

TracksText..  
{// 	
get00 
=>00 

tracksText00 
;00 
set11 
{22 

tracksText33 
=33 
value33 "
;33" #
OnPropertyChanged44 !
(44! "
)44" #
;44# $
}55 
}66 	
public88 
ImageSource88 
Image88  
{99 	
get:: 
=>:: 
image:: 
;:: 
set;; 
{<< 
image== 
=== 
value== 
;== 
OnPropertyChanged>> !
(>>! "
)>>" #
;>># $
}?? 
}@@ 	
privateCC 
ICommandCC 
longPressedCommandCC +
;CC+ ,
publicDD 
ICommandDD 
LongPressedCommandDD *
{EE 	
getFF 
{GG 
ifHH 
(HH 
longPressedCommandHH &
==HH' )
nullHH* .
)HH. /
longPressedCommandII &
=II' (
newII) ,
ActionCommandII- :
(II: ;
	parameterII; D
=>IIE G
{JJ 
ifKK 
(KK 
stringKK "
.KK" #
IsNullOrEmptyKK# 0
(KK0 1
PlaylistUrlKK1 <
)KK< =
)KK= >
ContextMenuBuilderLL .
.LL. /
BuildForPlaylistLL/ ?
(LL? @
ViewLL@ D
,LLD E
PlaylistNameLLF R
)LLR S
;LLS T
}MM 
)MM 
;MM 
returnOO 
longPressedCommandOO )
;OO) *
}PP 
}QQ 	
privateSS 
ICommandSS 
pressedCommandSS '
;SS' (
publicTT 
ICommandTT 
PressedCommandTT &
{UU 	
getVV 
{WW 
ifXX 
(XX 
pressedCommandXX "
==XX# %
nullXX& *
)XX* +
pressedCommandYY "
=YY# $
newYY% (
ActionCommandYY) 6
(YY6 7
asyncYY7 <
(YY= >
	parameterYY> G
)YYG H
=>YYI K
{ZZ 
if[[ 
([[ 
string[[ "
.[[" #
IsNullOrEmpty[[# 0
([[0 1
PlaylistUrl[[1 <
)[[< =
)[[= >
{\\ 
await]] !
Global]]" (
.]]( )
NavigationInstance]]) ;
.]]; <
PushModalAsync]]< J
(]]J K
new]]K N
	ModalPage]]O X
(]]X Y
new]]Y \
CurrentTracksPage]]] n
(]]n o

GlobalData]]o y
.]]y z
Current	]]z �
.
]]� �
	Playlists
]]� �
[
]]� �
PlaylistName
]]� �
]
]]� �
,
]]� �
PlaylistName
]]� �
)
]]� �
,
]]� �
PlaylistName
]]� �
)
]]� �
)
]]� �
;
]]� �
}^^ 
else__ 
{`` 
awaitaa !
Globalaa" (
.aa( )
NavigationInstanceaa) ;
.aa; <
PushModalAsyncaa< J
(aaJ K
newaaK N
	ModalPageaaO X
(aaX Y
newaaY \
SearchResultPageaa] m
(aam n
PlaylistUrlaan y
)aay z
,aaz {
PlaylistName	aa| �
)
aa� �
)
aa� �
;
aa� �
}bb 
}cc 
)cc 
;cc 
returndd 
pressedCommanddd %
;dd% &
}ee 
}ff 	
publicii %
PlaylistGridItemViewModelii (
(ii( )
stringii) /
playlistNameii0 <
,ii< =
Xamarinii> E
.iiE F
FormsiiF K
.iiK L
ViewiiL P
viewiiQ U
)iiU V
{jj 	
Viewkk 
=kk 
viewkk 
;kk 
Imagell 
=ll 
ImageSourcell 
.ll  
FromFilell  (
(ll( )
$strll) 9
)ll9 :
;ll: ;
ifnn 
(nn 
playlistNamenn 
.nn 

StartsWithnn '
(nn' (
$strnn( 0
)nn0 1
)nn1 2
{oo 
PlaylistNamepp 
=pp 

GlobalDatapp )
.pp) *
Currentpp* 1
.pp1 2
RecomendedPlaylistspp2 E
.ppE F
KeysppF J
.ppJ K
FirstppK P
(ppP Q
itemppQ U
=>ppV X

GlobalDatappY c
.ppc d
Currentppd k
.ppk l
RecomendedPlaylistsppl 
[	pp �
item
pp� �
]
pp� �
==
pp� �
playlistName
pp� �
)
pp� �
;
pp� �
PlaylistUrlqq 
=qq 
playlistNameqq *
;qq* +
}rr 
elsess 
{tt 
PlaylistNameuu 
=uu 
playlistNameuu +
;uu+ ,

TracksTextvv 
=vv 
Localizationvv )
.vv) *
Tracksvv* 0
+vv1 2
$strvv3 7
+vv8 9

GlobalDatavv: D
.vvD E
CurrentvvE L
.vvL M
	PlaylistsvvM V
[vvV W
playlistNamevvW c
]vvc d
.vvd e
Countvve j
;vvj k
foreachxx 
(xx 
stringxx 
filePathxx  (
inxx) +

GlobalDataxx, 6
.xx6 7
Currentxx7 >
.xx> ?
	Playlistsxx? H
[xxH I
playlistNamexxI U
]xxU V
)xxV W
{yy 
MediaSourcezz 
sourcezz  &
=zz' (
nullzz) -
;zz- .
if|| 
(|| 
filePath||  
.||  !
Length||! '
==||( *
$num||+ -
)||- .
source}} 
=}}  

GlobalData}}! +
.}}+ ,
Current}}, 3
.}}3 4
SavedTracks}}4 ?
[}}? @
filePath}}@ H
]}}H I
;}}I J
else~~ 
source 
=  

GlobalData! +
.+ ,
Current, 3
.3 4
Audios4 :
[: ;
filePath; C
]C D
;D E
if
�� 
(
�� 
source
�� 
.
�� 
Image
�� $
!=
��% '
null
��( ,
&&
��- /
source
��0 6
.
��6 7
Image
��7 <
.
��< =
Length
��= C
>
��D E
$num
��F G
)
��G H
{
�� 
Image
�� 
=
�� 
ImageProcessing
��  /
.
��/ 0
	FromArray
��0 9
(
��9 :
source
��: @
.
��@ A
Image
��A F
)
��F G
;
��G H
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
^D:\Projekty\CS\Newtone\Newtone.Mobile.UI\ViewModels\ViewCells\SearchResultViewCellViewModel.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 

ViewModels &
.& '
	ViewCells' 0
{ 
public 

class )
SearchResultViewCellViewModel .
{		 
private 
ICommand 
downloadClicked (
;( )
public 
ICommand 
DownloadClicked '
{ 	
get 
{ 
if 
( 
downloadClicked #
==$ &
null' +
)+ ,
downloadClicked #
=$ %
new& )
ActionCommand* 7
(7 8
	parameter8 A
=>B D
{ 
ContextMenuBuilder *
.* + 
BuildForSearchResult+ ?
(? @
	parameter@ I
asJ L
XamarinM T
.T U
FormsU Z
.Z [
View[ _
,_ `
(a b
	parameterb k
asl n
CustomImageButton	o �
)
� �
.
� �
Tag
� �
)
� �
;
� �
} 
) 
; 
return 
downloadClicked &
;& '
} 
} 	
} 
} �J
AD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ArtistPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 

ArtistPage #
:$ %
ContentView& 1
,1 2
IVisibleContent3 B
,B C
ITimerContentD Q
{ 
private 
static 
IList 
< 
View !
>! "
generatedChildrens# 5
;5 6
private 
bool 
isInitializing #
=$ %
false& +
;+ ,
public 

ArtistPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
Init 
( 
) 
; 
} 	
public 
void 
	Appearing 
( 
) 
{ 	
} 	
public!! 
void!! 
Disappearing!!  
(!!  !
)!!! "
{"" 	
}$$ 	
public%% 
void%% 
Init%% 
(%% 
)%% 
{&& 	
isInitializing'' 
='' 
true'' !
;''! "
if(( 
((( 
generatedChildrens(( "
==((# %
null((& *
)((* +
{)) 
generatedChildrens** "
=**# $
new**% (
List**) -
<**- .
View**. 2
>**2 3
(**3 4
)**4 5
;**5 6
List++ 
<++ 
string++ 
>++ 

beforeSort++ '
=++( )
new++* -
List++. 2
<++2 3
string++3 9
>++9 :
(++: ;
)++; <
;++< =
string,, 
unknown,, 
=,,  
null,,! %
;,,% &
foreach.. 
(.. 
string.. 
artist..  &
in..' )

GlobalData..* 4
...4 5
Current..5 <
...< =
Artists..= D
...D E
Keys..E I
...I J
ToList..J P
(..P Q
)..Q R
)..R S
{// 
if00 
(00 
artist00 
==00 !
Localization00" .
.00. /
UnknownArtist00/ <
)00< =
unknown11 
=11  !
artist11" (
;11( )
else22 

beforeSort33 "
.33" #
Add33# &
(33& '
artist33' -
)33- .
;33. /
}44 
List66 
<66 
string66 
>66 
	afterSort66 &
=66' (

beforeSort66) 3
.663 4
OrderBy664 ;
(66; <
o66< =
=>66> @
o66A B
)66B C
.66C D
ToList66D J
(66J K
)66K L
;66L M
if88 
(88 
unknown88 
!=88 
null88 #
)88# $
	afterSort99 
.99 
Add99 !
(99! "
unknown99" )
)99) *
;99* +
int;; 
pos;; 
=;; 
$num;; 
;;; 
string<< 
model0<< 
=<< 
null<<  $
;<<$ %
foreach== 
(== 
string== 
artist==  &
in==' )
	afterSort==* 3
)==3 4
{>> 
if?? 
(?? 
pos?? 
==?? 
$num??  
)??  !
{@@ 
model0AA 
=AA  
artistAA! '
;AA' (
posBB 
=BB 
$numBB 
;BB  
}CC 
elseDD 
{EE 
XamarinFF 
.FF  
FormsFF  %
.FF% &
RelativeLayoutFF& 4
layoutFF5 ;
=FF< =
newFF> A
XamarinFFB I
.FFI J
FormsFFJ O
.FFO P
RelativeLayoutFFP ^
(FF^ _
)FF_ `
;FF` a
layoutGG 
.GG 
ChildrenGG '
.GG' (
AddGG( +
(GG+ ,
newGG, /
ArtistGridItemGG0 >
(GG> ?
thisGG? C
,GGC D
model0GGE K
)GGK L
,GGL M
nullGGN R
,GGR S
nullGGT X
,GGX Y

ConstraintGGZ d
.GGd e
RelativeToParentGGe u
(GGu v
parentGGv |
=>GG} 
parent
GG� �
.
GG� �
Width
GG� �
*
GG� �
$num
GG� �
)
GG� �
,
GG� �

Constraint
GG� �
.
GG� �
Constant
GG� �
(
GG� �
$num
GG� �
)
GG� �
)
GG� �
;
GG� �
layoutHH 
.HH 
ChildrenHH '
.HH' (
AddHH( +
(HH+ ,
newHH, /
ArtistGridItemHH0 >
(HH> ?
thisHH? C
,HHC D
artistHHE K
)HHK L
,HHL M

ConstraintHHN X
.HHX Y
RelativeToParentHHY i
(HHi j
parentHHj p
=>HHq s
parentHHt z
.HHz {
Width	HH{ �
*
HH� �
$num
HH� �
)
HH� �
,
HH� �
null
HH� �
,
HH� �

Constraint
HH� �
.
HH� �
RelativeToParent
HH� �
(
HH� �
parent
HH� �
=>
HH� �
parent
HH� �
.
HH� �
Width
HH� �
*
HH� �
$num
HH� �
)
HH� �
,
HH� �

Constraint
HH� �
.
HH� �
Constant
HH� �
(
HH� �
$num
HH� �
)
HH� �
)
HH� �
;
HH� �
generatedChildrensII *
.II* +
AddII+ .
(II. /
layoutII/ 5
)II5 6
;II6 7
posJJ 
=JJ 
$numJJ 
;JJ  
}KK 
}MM 
ifOO 
(OO 
posOO 
==OO 
$numOO 
)OO 
{PP 
XamarinQQ 
.QQ 
FormsQQ !
.QQ! "
RelativeLayoutQQ" 0
layoutQQ1 7
=QQ8 9
newQQ: =
XamarinQQ> E
.QQE F
FormsQQF K
.QQK L
RelativeLayoutQQL Z
(QQZ [
)QQ[ \
;QQ\ ]
layoutRR 
.RR 
ChildrenRR #
.RR# $
AddRR$ '
(RR' (
newRR( +
ArtistGridItemRR, :
(RR: ;
thisRR; ?
,RR? @
model0RRA G
)RRG H
,RRH I
nullRRJ N
,RRN O
nullRRP T
,RRT U

ConstraintRRV `
.RR` a
RelativeToParentRRa q
(RRq r
parentRRr x
=>RRy {
parent	RR| �
.
RR� �
Width
RR� �
)
RR� �
,
RR� �

Constraint
RR� �
.
RR� �
Constant
RR� �
(
RR� �
$num
RR� �
)
RR� �
)
RR� �
;
RR� �
generatedChildrensSS &
.SS& '
AddSS' *
(SS* +
layoutSS+ 1
)SS1 2
;SS2 3
}TT 
DeviceVV 
.VV #
BeginInvokeOnMainThreadVV .
(VV. /
(VV/ 0
)VV0 1
=>VV2 4
{WW 
	trackGridXX 
.XX 
ChildrenXX &
.XX& '
ClearXX' ,
(XX, -
)XX- .
;XX. /
generatedChildrensYY &
.YY& '
ForEachYY' .
(YY. /
	trackGridYY/ 8
.YY8 9
ChildrenYY9 A
.YYA B
AddYYB E
)YYE F
;YYF G
}ZZ 
)ZZ 
;ZZ 
}[[ 
else\\ 
{]] 
if^^ 
(^^ 
	trackGrid^^ 
.^^ 
Children^^ &
.^^& '
Count^^' ,
==^^- /
$num^^0 1
&&^^2 4
generatedChildrens^^5 G
?^^G H
.^^H I
Count^^I N
>^^O P
$num^^Q R
)^^R S
{__ 
Device`` 
.`` #
BeginInvokeOnMainThread`` 2
(``2 3
(``3 4
)``4 5
=>``6 8
generatedChildrens``9 K
.``K L
ForEach``L S
(``S T
	trackGrid``T ]
.``] ^
Children``^ f
.``f g
Add``g j
)``j k
)``k l
;``l m
}aa 
}bb 
isInitializingcc 
=cc 
falsecc "
;cc" #
}dd 	
publicff 
voidff 
Tickff 
(ff 
)ff 
{gg 	
ifhh 
(hh 

GlobalDatahh 
.hh 
Currenthh "
.hh" #
ArtistsNeedRefreshhh# 5
&&hh6 8
!hh9 :
isInitializinghh: H
&&hhI K
GlobalhhL R
.hhR S
LoadedhhS Y
)hhY Z
{ii 
generatedChildrensjj "
=jj# $
nulljj% )
;jj) *
Initll 
(ll 
)ll 
;ll 

GlobalDatamm 
.mm 
Currentmm "
.mm" #
ArtistsNeedRefreshmm# 5
=mm6 7
falsemm8 =
;mm= >
}nn 
}oo 	
}qq 
}rr �
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\CurrentPlaylistPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{		 
[

 
XamlCompilation

 
(

 "
XamlCompilationOptions

 +
.

+ ,
Compile

, 3
)

3 4
]

4 5
public 

partial 
class 
CurrentPlaylistPage ,
:- .
ContentView/ :
,: ;
ITimerContent< I
{ 
private 
readonly $
CurrentPlaylistViewModel 1
	ViewModel2 ;
;; <
public 
CurrentPlaylistPage "
(" #
)# $
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )$
CurrentPlaylistViewModel* B
;B C
} 	
public 
void 
	Appearing 
( 
) 
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
public 
void 
Disappearing  
(  !
)! "
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
public"" 
void"" 
Tick"" 
("" 
)"" 
{## 	
	ViewModel$$ 
?$$ 
.$$ 
Tick$$ 
($$ 
)$$ 
;$$ 
}&& 	
private)) 
void)) &
TrackListView_ItemSelected)) /
())/ 0
object))0 6
sender))7 =
,))= >(
SelectedItemChangedEventArgs))? [
e))\ ]
)))] ^
{** 	
	ViewModel++ 
?++ 
.++ &
TrackListView_ItemSelected++ 1
(++1 2
sender++2 8
,++8 9
e++: ;
)++; <
;++< =
},, 	
}.. 
}// �
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\CurrentTracksPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
CurrentTracksPage *
:+ ,
ContentView- 8
,8 9
ITimerContent: G
{ 
private "
CurrentTracksViewModel &
	ViewModel' 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
CurrentTracksPage  
(  !
List! %
<% &
string& ,
>, -
tracks. 4
,4 5
string6 <
playlistName= I
)I J
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
	ViewModel &
=' (
new) ,"
CurrentTracksViewModel- C
(C D
tracksD J
,J K
playlistNameL X
)X Y
;Y Z
} 	
public 
void 
Tick 
( 
) 
{ 	
	ViewModel 
? 
. 
Tick 
( 
) 
; 
} 	
private"" 
void"" &
TrackListView_ItemSelected"" /
(""/ 0
object""0 6
sender""7 =
,""= >(
SelectedItemChangedEventArgs""? [
e""\ ]
)""] ^
{## 	
	ViewModel$$ 
?$$ 
.$$ &
TrackListView_ItemSelected$$ 1
($$1 2
sender$$2 8
,$$8 9
e$$: ;
)$$; <
;$$< =
}%% 	
public'' 
void'' 
	Appearing'' 
('' 
)'' 
{(( 	
throw)) 
new)) #
NotImplementedException)) -
())- .
))). /
;))/ 0
}** 	
public,, 
void,, 
Disappearing,,  
(,,  !
),,! "
{-- 	
throw.. 
new.. #
NotImplementedException.. -
(..- .
)... /
;../ 0
}// 	
}11 
}22 �,
KD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\Custom\AudioSliderControl.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
Custom" (
{ 
public 

class 
AudioSliderControl #
:$ %
Slider& ,
{ 
private 
static 
AudioSliderControl )
Instance* 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public		 
static		 
readonly		 
BindableProperty		 /*
ValueWithoutBaseEventsProperty		0 N
=		O P
BindableProperty		Q a
.		a b
Create		b h
(		h i
$str			i �
,
		� �
typeof
		� �
(
		� �
double
		� �
)
		� �
,
		� �
typeof
		� �
(
		� � 
AudioSliderControl
		� �
)
		� �
,
		� �
null
		� �
,
		� �
propertyChanged
		� �
:
		� �-
OnValueWithoutBaseEventsChanged
		� �
)
		� �
;
		� �
public

 
static

 
readonly

 
BindableProperty

 /(
MaxWithoutBaseEventsProperty

0 L
=

M N
BindableProperty

O _
.

_ `
Create

` f
(

f g
$str

g }
,

} ~
typeof	

 �
(


� �
double


� �
)


� �
,


� �
typeof


� �
(


� � 
AudioSliderControl


� �
)


� �
,


� �
null


� �
,


� �
propertyChanged


� �
:


� �+
OnMaxWithoutBaseEventsChanged


� �
)


� �
;


� �
public 
double "
ValueWithoutBaseEvents ,
{ 	
get 
=> 
Value 
; 
set 
{ 
InvokeEvents 
= 
false $
;$ %
Value 
= 
value 
; 
OnPropertyChanged !
(! "
$str" )
)) *
;* +
} 
} 	
public 
double  
MaxWithoutBaseEvents *
{ 	
get 
=> 
Maximum 
; 
set 
{ 
InvokeEvents 
= 
false $
;$ %
Maximum 
= 
value 
;  
OnPropertyChanged !
(! "
$str" +
)+ ,
;, -
} 
}   	
private"" 
bool"" 
InvokeEvents"" !
{""" #
get""$ '
;""' (
set"") ,
;"", -
}"". /
public%% 
delegate%% 
void%% 
ValueChangedHandler%% 0
(%%0 1
object%%1 7
sender%%8 >
,%%> ?
ValueChangedArgs%%@ P
e%%Q R
)%%R S
;%%S T
public&& 
event&& 
ValueChangedHandler&& (
ValueNewChanged&&) 8
;&&8 9
public)) 
AudioSliderControl)) !
())! "
)))" #
{** 	
ValueChanged++ 
+=++ $
AudioSlider_ValueChanged++ 4
;++4 5
Instance,, 
=,, 
this,, 
;,, 
InvokeEvents-- 
=-- 
true-- 
;--  
}.. 	
private11 
void11 $
AudioSlider_ValueChanged11 -
(11- .
object11. 4
sender115 ;
,11; <!
ValueChangedEventArgs11= R
e11S T
)11T U
{22 	
if33 
(33 
InvokeEvents33 
)33 
ValueNewChanged44 
?44  
.44  !
Invoke44! '
(44' (
sender44( .
,44. /
new440 3
ValueChangedArgs444 D
(44D E
)44E F
{44G H
Value44I N
=44O P
e44Q R
.44R S
NewValue44S [
}44\ ]
)44] ^
;44^ _
InvokeEvents66 
=66 
true66 
;66  
}77 	
private88 
static88 
void88 +
OnValueWithoutBaseEventsChanged88 ;
(88; <
BindableObject88< J
bindable88K S
,88S T
object88U [
oldValue88\ d
,88d e
object88f l
newValue88m u
)88u v
{99 	
Instance:: 
.:: "
ValueWithoutBaseEvents:: +
=::, -
(::. /
double::/ 5
)::5 6
newValue::6 >
;::> ?
};; 	
private== 
static== 
void== )
OnMaxWithoutBaseEventsChanged== 9
(==9 :
BindableObject==: H
bindable==I Q
,==Q R
object==S Y
oldValue==Z b
,==b c
object==d j
newValue==k s
)==s t
{>> 	
Instance?? 
.??  
MaxWithoutBaseEvents?? )
=??* +
(??, -
double??- 3
)??3 4
newValue??4 <
;??< =
}@@ 	
publicCC 
classCC 
ValueChangedArgsCC %
{DD 	
publicEE 
doubleEE 
ValueEE 
{EE  !
getEE" %
;EE% &
setEE' *
;EE* +
}EE, -
}FF 	
}HH 
}II �#
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\Custom\CustomImageButton.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
Custom" (
{ 
public 

class 
CustomImageButton "
:# $
ImageButton% 0
{ 
public

 
event

 
EventHandler

 !
<

! "
ToggledEventArgs

" 2
>

2 3
Toggled

4 ;
;

; <
public 
static 
BindableProperty &
IsToggledProperty' 8
=9 :
BindableProperty 
. 
Create #
(# $
$str$ /
,/ 0
typeof1 7
(7 8
bool8 <
)< =
,= >
typeof? E
(E F
CustomImageButtonF W
)W X
,X Y
falseZ _
,_ `
propertyChanged$ 3
:3 4
OnIsToggledChanged5 G
)G H
;H I
public 
bool 
	IsToggled 
{ 	
set 
{ 
SetValue 
( 
IsToggledProperty ,
,, -
value. 3
)3 4
;4 5
}6 7
get 
{ 
return 
( 
bool 
) 
GetValue '
(' (
IsToggledProperty( 9
)9 :
;: ;
}< =
} 	
public 
static 
BindableProperty &
TagProperty' 2
=3 4
BindableProperty 
. 
Create #
(# $
$str$ )
,) *
typeof+ 1
(1 2
string2 8
)8 9
,9 :
typeof; A
(A B
CustomImageButtonB S
)S T
,T U
defaultV ]
(] ^
string^ d
)d e
)e f
;f g
public 
string 
Tag 
{ 	
set 
{ 
SetValue 
( 
TagProperty &
,& '
value( -
)- .
;. /
}0 1
get 
{ 
return 
( 
string  
)  !
GetValue! )
() *
TagProperty* 5
)5 6
;6 7
}8 9
} 	
public!! 
CustomImageButton!!  
(!!  !
)!!! "
{"" 	
Clicked## 
+=## %
CustomImageButton_Clicked## 0
;##0 1
}$$ 	
private'' 
static'' 
void'' 
OnIsToggledChanged'' .
(''. /
BindableObject''/ =
bindable''> F
,''F G
object''H N
oldValue''O W
,''W X
object''Y _
newValue''` h
)''h i
{(( 	
CustomImageButton)) 
toggleButton)) *
=))+ ,
())- .
CustomImageButton)). ?
)))? @
bindable))@ H
;))H I
bool** 
	isToggled** 
=** 
(** 
bool** "
)**" #
newValue**# +
;**+ ,
toggleButton-- 
.-- 
Toggled--  
?--  !
.--! "
Invoke--" (
(--( )
toggleButton--) 5
,--5 6
new--7 :
ToggledEventArgs--; K
(--K L
	isToggled--L U
)--U V
)--V W
;--W X
Debug.. 
... 
	WriteLine.. 
(.. 
$str.. /
+..0 1
	isToggled..2 ;
)..; <
;..< =
VisualStateManager00 
.00 
	GoToState00 (
(00( )
toggleButton00) 5
,005 6
	isToggled007 @
?00A B
$str00C N
:00O P
$str00Q Y
)00Y Z
;00Z [
}11 	
private33 
void33 %
CustomImageButton_Clicked33 .
(33. /
object33/ 5
sender336 <
,33< =
	EventArgs33> G
e33H I
)33I J
{44 	
VisualStateManager55 
.55 
	GoToState55 (
(55( )
this55) -
,55- .
	IsToggled55/ 8
?559 :
$str55; F
:55G H
$str55I Q
)55Q R
;55R S
}66 	
}88 
}99 �
ID:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\Custom\PlayerPanel.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
.

! "
Custom

" (
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
PlayerPanel $
:% &
ContentView' 2
,2 3
ITimerContent4 A
{ 
private  
PlayerPanelViewModel $
	ViewModel% .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
PlayerPanel 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' ) 
PlayerPanelViewModel* >
;> ?
backgroundImage 
. 
On 
< 
iOS "
>" #
(# $
)$ %
.% &
UseBlurEffect& 3
(3 4
BlurEffectStyle4 C
.C D
LightD I
)I J
;J K
} 	
public 
void 
Tick 
( 
) 
{ 	
	ViewModel 
? 
. 
Tick 
( 
) 
; 
} 	
public   
void   
	Appearing   
(   
)   
{!! 	
throw"" 
new"" #
NotImplementedException"" -
(""- .
)"". /
;""/ 0
}## 	
public%% 
void%% 
Disappearing%%  
(%%  !
)%%! "
{&& 	
throw'' 
new'' #
NotImplementedException'' -
(''- .
)''. /
;''/ 0
}(( 	
}** 
}++ �
ID:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\Custom\PressGestureMask.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
Custom" (
{ 
public 

class 
PressGestureMask !
:" #
Xamarin$ +
.+ ,
Forms, 1
.1 2
Image2 7
{ 
public

 
static

 
BindableProperty

 &"
PressedCommandProperty

' =
=

> ?
BindableProperty 
. 
Create #
(# $
$str$ 4
,4 5
typeof6 <
(< =
ICommand= E
)E F
,F G
typeofH N
(N O
PressGestureMaskO _
)_ `
)` a
;a b
public 
static 
BindableProperty &&
LongPressedCommandProperty' A
=B C
BindableProperty 
. 
Create #
(# $
$str$ 8
,8 9
typeof: @
(@ A
ICommandA I
)I J
,J K
typeofL R
(R S
PressGestureMaskS c
)c d
)d e
;e f
public 
event 
EventHandler !
LongPressed" -
;- .
public 
event 
EventHandler !
Pressed" )
;) *
public 
ICommand 
PressedCommand &
{ 	
get 
=> 
( 
ICommand 
) 
GetValue %
(% &"
PressedCommandProperty& <
)< =
;= >
set 
=> 
SetValue 
( "
PressedCommandProperty 2
,2 3
value4 9
)9 :
;: ;
} 	
public 
ICommand 
LongPressedCommand *
{ 	
get 
=> 
( 
ICommand 
) 
GetValue %
(% &&
LongPressedCommandProperty& @
)@ A
;A B
set 
=> 
SetValue 
( &
LongPressedCommandProperty 6
,6 7
value8 =
)= >
;> ?
} 	
public$$ 
void$$ 
HandleLongPress$$ #
($$# $
object$$$ *
sender$$+ 1
,$$1 2
	EventArgs$$3 <
e$$= >
)$$> ?
{%% 	
LongPressed&& 
?&& 
.&& 
Invoke&& 
(&&  
sender&&  &
,&&& '
e&&( )
)&&) *
;&&* +
LongPressedCommand'' 
?'' 
.''  
Execute''  '
(''' (
null''( ,
)'', -
;''- .
})) 	
public++ 
void++ 
HandlePress++ 
(++  
object++  &
sender++' -
,++- .
	EventArgs++/ 8
e++9 :
)++: ;
{,, 	
Pressed-- 
?-- 
.-- 
Invoke-- 
(-- 
sender-- "
,--" #
e--$ %
)--% &
;--& '
PressedCommand.. 
?.. 
... 
Execute.. #
(..# $
null..$ (
)..( )
;..) *
}// 	
}11 
}22 �
CD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\DownloadPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 
DownloadPage

 %
:

& '
ContentView

( 3
,

3 4
ITimerContent

5 B
{ 
private 
DownloadViewModel !
	ViewModel" +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
DownloadPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )
DownloadViewModel* ;
;; <
} 	
public 
void 
Tick 
( 
) 
{ 	
	ViewModel 
? 
. 
Tick 
( 
) 
; 
} 	
public 
void 
	Appearing 
( 
) 
{ 	
} 	
public!! 
void!! 
Disappearing!!  
(!!  !
)!!! "
{"" 	
}$$ 	
}&& 
}'' �
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\FirstStartPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
FirstStartPage		 '
:		( )
ContentPage		* 5
{

 
public 
static 
FirstStartPage $
Instance% -
{. /
get0 3
;3 4
private5 <
set= @
;@ A
}B C
public 
FirstStartPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
Instance 
= 
this 
; 
SetPage 
( 
new 
FirstStartSearch (
(( )
)) *
)* +
;+ ,
} 	
public 
void 
SetPage 
( 
ContentView '
view( ,
), -
{ 	
mainGrid 
. 
Children 
. 
Clear #
(# $
)$ %
;% &
mainGrid 
. 
Children 
. 
Add !
(! "
view" &
,& '
$num( )
,) *
$num+ ,
), -
;- .
} 	
} 
} �
RD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\FirstStart\FirstStartSearch.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "

FirstStart" ,
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
FirstStartSearch )
:* +
ContentView, 7
{ 
public

 
FirstStartSearch

 
(

  
)

  !
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\FullScreenPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
FullScreenPage '
:( )
ContentPage* 5
,5 6 
INavigationContainer7 K
{ 
private 
FullScreenViewModel #
	ViewModel$ -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
FullScreenPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
Padding 
= 
safeAreaInset #
;# $
	ViewModel 
= 
BindingContext &
as' )
FullScreenViewModel* =
;= >
	Appearing 
+= 
PageAppearing &
;& '
Disappearing 
+= 
PageDisappearing ,
;, -
audioSlider 
. 
ValueNewChanged '
+=( *'
AudioSlider_ValueNewChanged+ F
;F G
	trackBlur 
. 
On 
< 
iOS 
> 
( 
) 
.  
UseBlurEffect  -
(- .
BlurEffectStyle. =
.= >
Light> C
)C D
;D E
} 	
private!! 
void!! '
AudioSlider_ValueNewChanged!! 0
(!!0 1
object!!1 7
sender!!8 >
,!!> ?
Custom!!@ F
.!!F G
AudioSliderControl!!G Y
.!!Y Z
ValueChangedArgs!!Z j
e!!k l
)!!l m
{"" 	
	ViewModel## 
?## 
.## '
AudioSlider_ValueNewChanged## 2
(##2 3
e##3 4
)##4 5
;##5 6
}$$ 	
private&& 
void&& 
PageDisappearing&& %
(&&% &
object&&& ,
sender&&- 3
,&&3 4
	EventArgs&&5 >
e&&? @
)&&@ A
{'' 	
	ViewModel(( 
?(( 
.(( 
Disappearing(( #
(((# $
)(($ %
;((% &
})) 	
private++ 
void++ 
PageAppearing++ "
(++" #
object++# )
sender++* 0
,++0 1
	EventArgs++2 ;
e++< =
)++= >
{,, 	
	ViewModel-- 
?-- 
.-- 
	Appearing--  
(--  !
)--! "
;--" #
}.. 	
public00 
void00 
Block00 
(00 
)00 
{11 	
blocker22 
.22 
	IsVisible22 
=22 
true22  $
;22$ %
}33 	
public55 
void55 
Unblock55 
(55 
)55 
{66 	
blocker77 
.77 
	IsVisible77 
=77 
false77  %
;77% &
}88 	
public:: 
bool:: 
	IsBlocked:: 
(:: 
):: 
{;; 	
return<< 
blocker<< 
.<< 
	IsVisible<< $
;<<$ %
}== 	
}?? 
}@@ �
ID:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\LanguageSelectPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
LanguageSelectPage +
:, -
ContentPage. 9
{ 
public

 
LanguageSelectPage

 !
(

! "
)

" #
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �2
@D:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ModalPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
	ModalPage "
:# $
ContentPage% 0
,0 1 
INavigationContainer2 F
{ 
private 
IDisposable 
loopSubscription ,
;, -
private 
ModalViewModel 
	ViewModel (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
	ModalPage 
( 
ContentView $
content% ,
,, -
string. 4
title5 :
,: ;
bool< @
topPanelVisibleA P
=Q R
trueS W
,W X
boolY ]
playerPanelVisible^ p
=q r
trues w
)w x
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
page 
. 
Padding 
= 
safeAreaInset (
;( )
BindingContext 
= 
	ViewModel &
=' (
new) ,
ModalViewModel- ;
(; <
	container< E
,E F
titleG L
,L M
topPanelVisibleN ]
)] ^
;^ _
	container 
. 
Children 
. 
Add "
(" #
content# *
)* +
;+ ,
	Appearing!! 
+=!! 
PageAppearing!! &
;!!& '
Disappearing"" 
+="" 
PageDisappearing"" ,
;"", -
playerPanel$$ 
.$$ 
	IsVisible$$ !
=$$" #
playerPanelVisible$$$ 6
;$$6 7
	ViewModel%% 
.%% 
OnPropertyChanged%% '
(%%' (
(%%( )
)%%) *
=>%%+ -
	ViewModel%%. 7
.%%7 8!
DownloadButtonVisible%%8 M
)%%M N
;%%N O
}&& 	
private)) 
void)) 
PageDisappearing)) %
())% &
object))& ,
sender))- 3
,))3 4
	EventArgs))5 >
e))? @
)))@ A
{** 	
	ViewModel++ 
?++ 
.++ 
Disappearing++ #
(++# $
)++$ %
;++% &
loopSubscription,, 
?,, 
.,, 
Dispose,, %
(,,% &
),,& '
;,,' (
loopSubscription-- 
=-- 
null-- #
;--# $
}.. 	
private00 
void00 
PageAppearing00 "
(00" #
object00# )
sender00* 0
,000 1
	EventArgs002 ;
e00< =
)00= >
{11 	
var22 
src22 
=22 
System22 
.22 
Reactive22 %
.22% &
Linq22& *
.22* +

Observable22+ 5
.225 6
Timer226 ;
(22; <
TimeSpan22< D
.22D E
Zero22E I
,22I J
TimeSpan22K S
.22S T
FromMilliseconds22T d
(22d e
$num22e h
)22h i
)22i j
.22j k
	Timestamp22k t
(22t u
)22u v
;22v w
loopSubscription33 
=33 
src33 "
.33" #
	Subscribe33# ,
(33, -
time33- 1
=>332 4
Tick335 9
(339 :
)33: ;
)33; <
;33< =
	ViewModel44 
?44 
.44 
	Appearing44  
(44  !
)44! "
;44" #
}55 	
private77 
void77 
Tick77 
(77 
)77 
{88 	
if99 
(99 
playerPanel99 
!=99 
null99 #
)99# $
{:: 
Device;; 
.;; #
BeginInvokeOnMainThread;; .
(;;. /
(;;/ 0
);;0 1
=>;;2 4
playerPanel;;5 @
.;;@ A
	IsVisible;;A J
=;;K L

GlobalData;;M W
.;;W X
Current;;X _
.;;_ `
MediaSource;;` k
!=;;l n
null;;o s
);;s t
;;;t u
playerPanel<< 
?<< 
.<< 
Tick<< !
(<<! "
)<<" #
;<<# $
}== 
	ViewModel?? 
??? 
.?? 
Tick?? 
(?? 
)?? 
;?? 
}@@ 	
publicBB 
voidBB 
BlockBB 
(BB 
)BB 
{CC 	
blockerDD 
.DD 
	IsVisibleDD 
=DD 
trueDD  $
;DD$ %
}EE 	
publicGG 
voidGG 
UnblockGG 
(GG 
)GG 
{HH 	
blockerII 
.II 
	IsVisibleII 
=II 
falseII  %
;II% &
}JJ 	
publicLL 
boolLL 
	IsBlockedLL 
(LL 
)LL 
{MM 	
returnNN 
blockerNN 
.NN 
	IsVisibleNN $
;NN$ %
}OO 	
publicQQ 
TypeQQ 
GetContentTypeQQ "
(QQ" #
)QQ# $
{RR 	
returnSS 
	containerSS 
.SS 
ChildrenSS %
.SS% &
CountSS& +
==SS, .
$numSS/ 0
?SS1 2
nullSS3 7
:SS8 9
	containerSS: C
.SSC D
ChildrenSSD L
[SSL M
$numSSM N
]SSN O
.SSO P
GetTypeSSP W
(SSW X
)SSX Y
;SSY Z
}TT 	
}VV 
}WW �0
AD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\NormalPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 

NormalPage #
:$ %
ContentPage& 1
,1 2 
INavigationContainer3 G
{ 
private 
NormalViewModel 
	ViewModel  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 

NormalPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
page 
. 
Padding 
= 
safeAreaInset (
;( )
BindingContext 
= 
	ViewModel &
=' (
new) ,
NormalViewModel- <
(< =
	container= F
,F G
playerPanelH S
,S T
searchEntryU `
)` a
;a b
Global 
. 
NavigationInstance %
=& '
new( +
NavigationWrapper, =
(= >
this> B
.B C

NavigationC M
)M N
;N O
Global 
. 
Page 
= 
this 
; 
	Appearing 
+= 
PageAppearing &
;& '
Disappearing 
+= 
PageDisappearing ,
;, -
} 	
public!! 
void!! 
Block!! 
(!! 
)!! 
{"" 	
blocker## 
.## 
	IsVisible## 
=## 
true##  $
;##$ %
}$$ 	
public&& 
void&& 
Unblock&& 
(&& 
)&& 
{'' 	
blocker(( 
.(( 
	IsVisible(( 
=(( 
false((  %
;((% &
})) 	
public** 
bool** 
	IsBlocked** 
(** 
)** 
{++ 	
return,, 
blocker,, 
.,, 
	IsVisible,, $
;,,$ %
}-- 	
private00 
void00 
PageDisappearing00 %
(00% &
object00& ,
sender00- 3
,003 4
	EventArgs005 >
e00? @
)00@ A
{11 	
	ViewModel22 
?22 
.22 
Disappearing22 #
(22# $
)22$ %
;22% &
}33 	
private55 
void55 
PageAppearing55 "
(55" #
object55# )
sender55* 0
,550 1
	EventArgs552 ;
e55< =
)55= >
{66 	
	ViewModel77 
?77 
.77 
	Appearing77  
(77  !
)77! "
;77" #
}88 	
private:: 
async:: 
void:: 
Entry_Completed:: *
(::* +
object::+ 1
sender::2 8
,::8 9
	EventArgs::: C
e::D E
)::E F
{;; 	
if<< 
(<< 
!<< 
string<< 
.<< 
IsNullOrEmpty<< %
(<<% &
	ViewModel<<& /
?<</ 0
.<<0 1
	EntryText<<1 :
)<<: ;
)<<; <
{== 
await>> 
Global>> 
.>> 
NavigationInstance>> /
.>>/ 0
PushModalAsync>>0 >
(>>> ?
new>>? B
	ModalPage>>C L
(>>L M
new>>M P
SearchResultPage>>Q a
(>>a b
	ViewModel>>b k
?>>k l
.>>l m
	EntryText>>m v
)>>v w
,>>w x
	ViewModel	>>y �
?
>>� �
.
>>� �
	EntryText
>>� �
)
>>� �
)
>>� �
;
>>� �
}?? 
}@@ 	
privateAA 
voidAA 
Entry_FocusedAA "
(AA" #
objectAA# )
senderAA* 0
,AA0 1
FocusEventArgsAA2 @
eAAA B
)AAB C
{BB 	
	ViewModelCC 
.CC $
SearchSuggestionsVisibleCC .
=CC/ 0
trueCC1 5
;CC5 6
	ViewModelDD 
?DD 
.DD 
RefreshSuggestionDD (
(DD( )
)DD) *
;DD* +
}EE 	
privateGG 
voidGG 
Entry_UnfocusedGG $
(GG$ %
objectGG% +
senderGG, 2
,GG2 3
FocusEventArgsGG4 B
eGGC D
)GGD E
{HH 	
	ViewModelII 
.II $
SearchSuggestionsVisibleII .
=II/ 0
falseII1 6
;II6 7
}JJ 	
privateLL 
voidLL 
Entry_TextChangedLL &
(LL& '
objectLL' -
senderLL. 4
,LL4 5 
TextChangedEventArgsLL6 J
eLLK L
)LLL M
{MM 	
	ViewModelNN 
?NN 
.NN 
RefreshSuggestionNN (
(NN( )
)NN) *
;NN* +
}OO 	
privateQQ 
voidQQ '
SuggestionList_ItemSelectedQQ 0
(QQ0 1
objectQQ1 7
senderQQ8 >
,QQ> ?(
SelectedItemChangedEventArgsQQ@ \
eQQ] ^
)QQ^ _
{RR 	
	ViewModelSS 
?SS 
.SS #
SuggestionItem_SelectedSS .
(SS. /
senderSS/ 5
,SS5 6
eSS7 8
)SS8 9
;SS9 :
}TT 	
}VV 
}WW �
ED:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\PermissionPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
PermissionPage '
:( )
ContentPage* 5
{ 
public

 
PermissionPage

 
(

 
)

 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �t
CD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\PlaylistPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
PlaylistPage %
:& '
ContentView( 3
,3 4
IVisibleContent5 D
,D E
ITimerContentF S
{ 
private 
static 
IList 
< 
View !
>! "
generatedChildrens# 5
;5 6
private 
bool 
isInitializing #
=$ %
false& +
;+ ,
public 
PlaylistPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
Init 
( 
) 
; 
} 	
public 
void 
Init 
( 
) 
{ 	
isInitializing 
= 
true !
;! "
if   
(   
generatedChildrens   "
==  # %
null  & *
)  * +
{!! 
List"" 
<"" 
string"" 
>"" 

beforeSort"" '
=""( )
new""* -
List"". 2
<""2 3
string""3 9
>""9 :
("": ;
)""; <
;""< =
foreach$$ 
($$ 
string$$ 
playlist$$  (
in$$) +

GlobalData$$, 6
.$$6 7
Current$$7 >
.$$> ?
	Playlists$$? H
.$$H I
Keys$$I M
.$$M N
ToList$$N T
($$T U
)$$U V
)$$V W
{%% 

beforeSort&& 
.&& 
Add&& "
(&&" #
playlist&&# +
)&&+ ,
;&&, -
}'' 
List)) 
<)) 
string)) 
>)) 
	afterSort)) &
=))' (

beforeSort))) 3
.))3 4
OrderBy))4 ;
()); <
o))< =
=>))> @
o))A B
)))B C
.))C D
ToList))D J
())J K
)))K L
;))L M
generatedChildrens++ "
=++# $
new++% (
List++) -
<++- .
View++. 2
>++2 3
(++3 4
)++4 5
;++5 6
int,, 
pos,, 
=,, 
$num,, 
;,, 
string-- 
model0-- 
=-- 
null--  $
;--$ %
foreach// 
(// 
string// 
playlist//  (
in//) +
	afterSort//, 5
)//5 6
{00 
if11 
(11 
pos11 
==11 
$num11  
)11  !
{22 
model033 
=33  
playlist33! )
;33) *
pos44 
=44 
$num44 
;44  
}55 
else66 
{77 
Xamarin88 
.88  
Forms88  %
.88% &
RelativeLayout88& 4
layout885 ;
=88< =
new88> A
Xamarin88B I
.88I J
Forms88J O
.88O P
RelativeLayout88P ^
(88^ _
)88_ `
;88` a
layout99 
.99 
Children99 '
.99' (
Add99( +
(99+ ,
new99, /
PlaylistGridItem990 @
(99@ A
this99A E
,99E F
model099G M
)99M N
,99N O
null99P T
,99T U
null99V Z
,99Z [

Constraint99\ f
.99f g
RelativeToParent99g w
(99w x
parent99x ~
=>	99 �
parent
99� �
.
99� �
Width
99� �
*
99� �
$num
99� �
)
99� �
,
99� �

Constraint
99� �
.
99� �
Constant
99� �
(
99� �
$num
99� �
)
99� �
)
99� �
;
99� �
layout:: 
.:: 
Children:: '
.::' (
Add::( +
(::+ ,
new::, /
PlaylistGridItem::0 @
(::@ A
this::A E
,::E F
playlist::G O
)::O P
,::P Q

Constraint::R \
.::\ ]
RelativeToParent::] m
(::m n
parent::n t
=>::u w
parent::x ~
.::~ 
Width	:: �
*
::� �
$num
::� �
)
::� �
,
::� �
null
::� �
,
::� �

Constraint
::� �
.
::� �
RelativeToParent
::� �
(
::� �
parent
::� �
=>
::� �
parent
::� �
.
::� �
Width
::� �
*
::� �
$num
::� �
)
::� �
,
::� �

Constraint
::� �
.
::� �
Constant
::� �
(
::� �
$num
::� �
)
::� �
)
::� �
;
::� �
generatedChildrens<< *
.<<* +
Add<<+ .
(<<. /
layout<</ 5
)<<5 6
;<<6 7
pos== 
=== 
$num== 
;==  
}>> 
}?? 
ifAA 
(AA 
posAA 
==AA 
$numAA 
)AA 
{BB 
XamarinCC 
.CC 
FormsCC !
.CC! "
RelativeLayoutCC" 0
layoutCC1 7
=CC8 9
newCC: =
XamarinCC> E
.CCE F
FormsCCF K
.CCK L
RelativeLayoutCCL Z
(CCZ [
)CC[ \
;CC\ ]
layoutDD 
.DD 
ChildrenDD #
.DD# $
AddDD$ '
(DD' (
newDD( +
PlaylistGridItemDD, <
(DD< =
thisDD= A
,DDA B
model0DDC I
)DDI J
,DDJ K
nullDDL P
,DDP Q
nullDDR V
,DDV W

ConstraintDDX b
.DDb c
RelativeToParentDDc s
(DDs t
parentDDt z
=>DD{ }
parent	DD~ �
.
DD� �
Width
DD� �
)
DD� �
,
DD� �

Constraint
DD� �
.
DD� �
Constant
DD� �
(
DD� �
$num
DD� �
)
DD� �
)
DD� �
;
DD� �
generatedChildrensEE &
.EE& '
AddEE' *
(EE* +
layoutEE+ 1
)EE1 2
;EE2 3
}FF 
GenerateRecomendedHH "
(HH" #
)HH# $
;HH$ %
DeviceJJ 
.JJ #
BeginInvokeOnMainThreadJJ .
(JJ. /
(JJ/ 0
)JJ0 1
=>JJ2 4
{KK 
	trackGridLL 
.LL 
ChildrenLL &
.LL& '
ClearLL' ,
(LL, -
)LL- .
;LL. /
foreachMM 
(MM 
varMM  
itemMM! %
inMM& (
generatedChildrensMM) ;
.MM; <
ToListMM< B
(MMB C
)MMC D
)MMD E
{NN 
	trackGridOO !
.OO! "
ChildrenOO" *
.OO* +
AddOO+ .
(OO. /
itemOO/ 3
)OO3 4
;OO4 5
}PP 
}QQ 
)QQ 
;QQ 
}RR 
elseSS 
{TT 
ifUU 
(UU 
	trackGridUU 
.UU 
ChildrenUU &
.UU& '
CountUU' ,
==UU- /
$numUU0 1
&&UU2 4
generatedChildrensUU5 G
?UUG H
.UUH I
CountUUI N
>UUO P
$numUUQ R
)UUR S
{VV 
DeviceWW 
.WW #
BeginInvokeOnMainThreadWW 2
(WW2 3
(WW3 4
)WW4 5
=>WW6 8
generatedChildrensWW9 K
.WWK L
ForEachWWL S
(WWS T
	trackGridWWT ]
.WW] ^
ChildrenWW^ f
.WWf g
AddWWg j
)WWj k
)WWk l
;WWl m
}XX 
}YY 
isInitializingZZ 
=ZZ 
falseZZ "
;ZZ" #
}[[ 	
public\\ 
void\\ 
	Appearing\\ 
(\\ 
)\\ 
{]] 	
}__ 	
publicaa 
voidaa 
Disappearingaa  
(aa  !
)aa! "
{bb 	
}dd 	
publicff 
voidff 
Tickff 
(ff 
)ff 
{gg 	
ifhh 
(hh 

GlobalDatahh 
.hh 
Currenthh "
.hh" # 
PlaylistsNeedRefreshhh# 7
&&hh8 :
!hh; <
isInitializinghh< J
&&hhK M
GlobalhhN T
.hhT U
LoadedhhU [
)hh[ \
{ii 
ifjj 
(jj 
generatedChildrensjj &
!=jj' )
nulljj* .
)jj. /
generatedChildrenskk &
=kk' (
nullkk) -
;kk- .
Initmm 
(mm 
)mm 
;mm 

GlobalDatann 
.nn 
Currentnn "
.nn" # 
PlaylistsNeedRefreshnn# 7
=nn8 9
falsenn: ?
;nn? @
}oo 
}pp 	
privatess 
voidss 
GenerateRecomendedss '
(ss' (
)ss( )
{tt 	
ifuu 
(uu 
Globaluu 
.uu 
Applicationuu "
.uu" #
HasInternetuu# .
(uu. /
)uu/ 0
)uu0 1
{vv 

GlobalDataww 
.ww 
Currentww "
.ww" #
RecomendedPlaylistsww# 6
=ww7 8
RecomendedPlaylistsww9 L
.wwL M"
GetRecomendedPlaylistswwM c
(wwc d
)wwd e
;wwe f
}xx 
intzz 
poszz 
=zz 
$numzz 
;zz 
string{{ 
model0{{ 
={{ 
null{{  
;{{  !
foreach}} 
(}} 
var}} 
key}} 
in}} 

GlobalData}}  *
.}}* +
Current}}+ 2
.}}2 3
RecomendedPlaylists}}3 F
.}}F G
Keys}}G K
)}}K L
{~~ 
if 
( 
pos 
== 
$num 
) 
{
�� 
model0
�� 
=
�� 

GlobalData
�� '
.
��' (
Current
��( /
.
��/ 0!
RecomendedPlaylists
��0 C
[
��C D
key
��D G
]
��G H
;
��H I
pos
�� 
=
�� 
$num
�� 
;
�� 
}
�� 
else
�� 
{
�� 
Xamarin
�� 
.
�� 
Forms
�� !
.
��! "
RelativeLayout
��" 0
layout
��1 7
=
��8 9
new
��: =
Xamarin
��> E
.
��E F
Forms
��F K
.
��K L
RelativeLayout
��L Z
(
��Z [
)
��[ \
;
��\ ]
layout
�� 
.
�� 
Children
�� #
.
��# $
Add
��$ '
(
��' (
new
��( +!
PlaylistWebGridItem
��, ?
(
��? @
this
��@ D
,
��D E
model0
��F L
)
��L M
,
��M N
null
��O S
,
��S T
null
��U Y
,
��Y Z

Constraint
��[ e
.
��e f
RelativeToParent
��f v
(
��v w
parent
��w }
=>��~ �
parent��� �
.��� �
Width��� �
*��� �
$num��� �
)��� �
,��� �

Constraint��� �
.��� �
Constant��� �
(��� �
$num��� �
)��� �
)��� �
;��� �
layout
�� 
.
�� 
Children
�� #
.
��# $
Add
��$ '
(
��' (
new
��( +!
PlaylistWebGridItem
��, ?
(
��? @
this
��@ D
,
��D E

GlobalData
��F P
.
��P Q
Current
��Q X
.
��X Y!
RecomendedPlaylists
��Y l
[
��l m
key
��m p
]
��p q
)
��q r
,
��r s

Constraint
��t ~
.
��~ 
RelativeToParent�� �
(��� �
parent��� �
=>��� �
parent��� �
.��� �
Width��� �
*��� �
$num��� �
)��� �
,��� �
null��� �
,��� �

Constraint��� �
.��� � 
RelativeToParent��� �
(��� �
parent��� �
=>��� �
parent��� �
.��� �
Width��� �
*��� �
$num��� �
)��� �
,��� �

Constraint��� �
.��� �
Constant��� �
(��� �
$num��� �
)��� �
)��� �
;��� � 
generatedChildrens
�� &
.
��& '
Add
��' *
(
��* +
layout
��+ 1
)
��1 2
;
��2 3
pos
�� 
=
�� 
$num
�� 
;
�� 
}
�� 
}
�� 
if
�� 
(
�� 
pos
�� 
==
�� 
$num
�� 
)
�� 
{
�� 
Xamarin
�� 
.
�� 
Forms
�� 
.
�� 
RelativeLayout
�� ,
layout
��- 3
=
��4 5
new
��6 9
Xamarin
��: A
.
��A B
Forms
��B G
.
��G H
RelativeLayout
��H V
(
��V W
)
��W X
;
��X Y
layout
�� 
.
�� 
Children
�� 
.
��  
Add
��  #
(
��# $
new
��$ '!
PlaylistWebGridItem
��( ;
(
��; <
this
��< @
,
��@ A
model0
��B H
)
��H I
,
��I J
null
��K O
,
��O P
null
��Q U
,
��U V

Constraint
��W a
.
��a b
RelativeToParent
��b r
(
��r s
parent
��s y
=>
��z |
parent��} �
.��� �
Width��� �
)��� �
,��� �

Constraint��� �
.��� �
Constant��� �
(��� �
$num��� �
)��� �
)��� �
;��� � 
generatedChildrens
�� "
.
��" #
Add
��# &
(
��& '
layout
��' -
)
��- .
;
��. /
}
�� 
}
�� 	
}
�� 
}�� �
GD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\SearchResultPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
SearchResultPage		 )
:		* +
ContentView		, 7
{

 
private !
SearchResultViewModel %
	ViewModel& /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
SearchResultPage 
(  
string  &
searchedText' 3
)3 4
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
	ViewModel &
=' (
new) ,!
SearchResultViewModel- B
(B C
searchedTextC O
)O P
;P Q
} 	
private 
async 
void '
SearchListView_ItemSelected 6
(6 7
object7 =
sender> D
,D E(
SelectedItemChangedEventArgsF b
ec d
)d e
{ 	
await 
	ViewModel 
? 
. 
Item_Selected *
(* +
sender+ 1
,1 2
e3 4
)4 5
;5 6
} 	
private 
void (
SearchListView_ItemAppearing 1
(1 2
object2 8
sender9 ?
,? @#
ItemVisibilityEventArgsA X
eY Z
)Z [
{ 	
	ViewModel 
? 
. (
SearchListView_ItemAppearing 3
(3 4
e4 5
.5 6
	ItemIndex6 ?
)? @
;@ A
} 	
}!! 
}"" �
CD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\SettingsPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
SettingsPage %
:& '
ContentView( 3
{		 
private 
SettingsViewModel !
	ViewModel" +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
SettingsPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )
SettingsViewModel* ;
;; <
} 	
private 
async 
void %
SettingsList_ItemSelected 4
(4 5
object5 ;
sender< B
,B C(
SelectedItemChangedEventArgsD `
ea b
)b c
{ 	
await 
	ViewModel 
? 
. 
Item_Selected *
(* +
sender+ 1
,1 2
e3 4
)4 5
;5 6
} 	
} 
} �
AD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TracksPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 

TracksPage

 #
:

$ %
ContentView

& 1
,

1 2
ITimerContent

3 @
{ 
private 
TrackViewModel 
	ViewModel (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 

TracksPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )
TrackViewModel* 8
;8 9
} 	
public 
void 
Tick 
( 
) 
{ 	
	ViewModel 
? 
. 
Tick 
( 
) 
; 
} 	
private 
void &
TrackListView_ItemSelected /
(/ 0
object0 6
sender7 =
,= >(
SelectedItemChangedEventArgs? [
e\ ]
)] ^
{ 	
	ViewModel   
?   
.   
Track_Selected   %
(  % &
sender  & ,
,  , -
e  . /
)  / 0
;  0 1
}!! 	
public## 
void## 
	Appearing## 
(## 
)## 
{$$ 	
}&& 	
public(( 
void(( 
Disappearing((  
(((  !
)((! "
{)) 	
}++ 	
}-- 
}.. �
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ArtistPage.xaml.cs
	namespace		 	
Newtone		
 
.		 
Mobile		 
.		 
UI		 
.		 
Views		 !
.		! "
TV		" $
{

 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 

ArtistPage #
:$ %
ContentView& 1
,1 2
ITimerContent3 @
,@ A
INFocusContentB P
{ 
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 

ArtistPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 

artistList #
;# $
BottomElement 
= 

artistList &
;& '
} 	
public 
void 
	Appearing 
( 
) 
{ 	
} 	
public   
void   
Disappearing    
(    !
)  ! "
{!! 	
}## 	
public%% 
void%% 
FocusAction%% 
(%%  
)%%  !
{&& 	
throw'' 
new'' 
System'' 
.'' #
NotImplementedException'' 4
(''4 5
)''5 6
;''6 7
}(( 	
public** 
void** 
	FocusDown** 
(** 
)** 
{++ 	
throw,, 
new,, 
System,, 
.,, #
NotImplementedException,, 4
(,,4 5
),,5 6
;,,6 7
}-- 	
public// 
void// 
	FocusLeft// 
(// 
)// 
{00 	
throw11 
new11 
System11 
.11 #
NotImplementedException11 4
(114 5
)115 6
;116 7
}22 	
public44 
void44 

FocusRight44 
(44 
)44  
{55 	
throw66 
new66 
System66 
.66 #
NotImplementedException66 4
(664 5
)665 6
;666 7
}77 	
public99 
void99 
FocusUp99 
(99 
)99 
{:: 	
throw;; 
new;; 
System;; 
.;; #
NotImplementedException;; 4
(;;4 5
);;5 6
;;;6 7
}<< 	
public>> 
void>> 
Tick>> 
(>> 
)>> 
{?? 	
if@@ 
(@@ 

GlobalData@@ 
.@@ 
Current@@ "
.@@" #
ArtistsNeedRefresh@@# 5
&&@@6 8
!@@9 :
(@@: ;
BindingContext@@; I
as@@J L
ArtistViewModel@@M \
)@@\ ]
.@@] ^
IsInitializing@@^ l
&&@@m o
Global@@p v
.@@v w
Loaded@@w }
)@@} ~
{AA 
DeviceBB 
.BB #
BeginInvokeOnMainThreadBB .
(BB. /
(BB/ 0
BindingContextBB0 >
asBB? A
ArtistViewModelBBB Q
)BBQ R
.BBR S

InitializeBBS ]
)BB] ^
;BB^ _

GlobalDataCC 
.CC 
CurrentCC "
.CC" #
ArtistsNeedRefreshCC# 5
=CC6 7
falseCC8 =
;CC= >
}DD 
}EE 	
}GG 
}HH �
MD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\CurrentPlaylistPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
CurrentPlaylistPage		 ,
:		- .
ContentView		/ :
,		: ;
ITimerContent		< I
{

 
private 
readonly $
CurrentPlaylistViewModel 1
	ViewModel2 ;
;; <
public 
CurrentPlaylistPage "
(" #
)# $
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )$
CurrentPlaylistViewModel* B
;B C
} 	
public 
void 
	Appearing 
( 
) 
{ 	
} 	
public 
void 
Disappearing  
(  !
)! "
{ 	
} 	
public   
void   
Tick   
(   
)   
{!! 	
	ViewModel"" 
?"" 
."" 
Tick"" 
("" 
)"" 
;"" 
}$$ 	
}&& 
}'' �
KD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\CurrentTracksPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
.

! "
TV

" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
CurrentTracksPage *
:+ ,
ContentView- 8
,8 9
ITimerContent: G
,G H
INFocusContentI W
{ 
private "
CurrentTracksViewModel &
	ViewModel' 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
CurrentTracksPage  
(  !
List! %
<% &
string& ,
>, -
tracks. 4
,4 5
string6 <
playlistName= I
)I J
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 
currentList $
;$ %
BottomElement 
= 
currentList '
;' (
BindingContext 
= 
	ViewModel &
=' (
new) ,"
CurrentTracksViewModel- C
(C D
tracksD J
,J K
playlistNameL X
)X Y
;Y Z
currentList 
. 
Rerender  
(  !
)! "
;" #
} 	
public   
void   
Tick   
(   
)   
{!! 	
	ViewModel"" 
?"" 
."" 
Tick"" 
("" 
)"" 
;"" 
}$$ 	
public&& 
void&& 
	Appearing&& 
(&& 
)&& 
{'' 	
})) 	
public++ 
void++ 
Disappearing++  
(++  !
)++! "
{,, 	
}.. 	
public00 
void00 
	FocusLeft00 
(00 
)00 
{11 	
throw22 
new22 #
NotImplementedException22 -
(22- .
)22. /
;22/ 0
}33 	
public55 
void55 

FocusRight55 
(55 
)55  
{66 	
throw77 
new77 #
NotImplementedException77 -
(77- .
)77. /
;77/ 0
}88 	
public:: 
void:: 
FocusUp:: 
(:: 
):: 
{;; 	
throw<< 
new<< #
NotImplementedException<< -
(<<- .
)<<. /
;<</ 0
}== 	
public?? 
void?? 
	FocusDown?? 
(?? 
)?? 
{@@ 	
throwAA 
newAA #
NotImplementedExceptionAA -
(AA- .
)AA. /
;AA/ 0
}BB 	
publicDD 
voidDD 
FocusActionDD 
(DD  
)DD  !
{EE 	
throwFF 
newFF #
NotImplementedExceptionFF -
(FF- .
)FF. /
;FF/ 0
}GG 	
}II 
}JJ �
LD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\Custom\PlayerPanel.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
Custom% +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
PlayerPanel $
:% &
ContentView' 2
,2 3
ITimerContent4 A
{ 
private  
PlayerPanelViewModel $
	ViewModel% .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
NImageButton 

PlayButton &
=>' )

playButton* 4
;4 5
public 
NImageButton 
ImageButton '
=>( *

trackImage+ 5
;5 6
public 
PlayerPanel 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' ) 
PlayerPanelViewModel* >
;> ?
backgroundImage 
. 
On 
< 
iOS "
>" #
(# $
)$ %
.% &
UseBlurEffect& 3
(3 4
BlurEffectStyle4 C
.C D
LightD I
)I J
;J K
} 	
public 
void 
Tick 
( 
) 
{ 	
	ViewModel   
?   
.   
Tick   
(   
)   
;   
}!! 	
public## 
void## 
	Appearing## 
(## 
)## 
{$$ 	
throw%% 
new%% #
NotImplementedException%% -
(%%- .
)%%. /
;%%/ 0
}&& 	
public(( 
void(( 
Disappearing((  
(((  !
)((! "
{)) 	
throw** 
new** #
NotImplementedException** -
(**- .
)**. /
;**/ 0
}++ 	
}-- 
}.. �
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\FirstStartPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
.

! "
TV

" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
FirstStartPage '
:( )
ContentPage* 5
{ 
public 
FirstStartPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �!
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\FullScreenPage.xaml.cs
	namespace

 	
Newtone


 
.

 
Mobile

 
.

 
UI

 
.

 
Views

 !
.

! "
TV

" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
FullScreenPage '
:( )
ContentPage* 5
,5 6 
INavigationContainer7 K
{ 
private 
FullScreenViewModel #
	ViewModel$ -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
FullScreenPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
Padding 
= 
safeAreaInset #
;# $
	ViewModel 
= 
BindingContext &
as' )
FullScreenViewModel* =
;= >
	Appearing 
+= 
PageAppearing &
;& '
Disappearing 
+= 
PageDisappearing ,
;, -
audioSlider 
. 
ValueNewChanged '
+=( *'
AudioSlider_ValueNewChanged+ F
;F G
	trackBlur 
. 
On 
< 
iOS 
> 
( 
) 
.  
UseBlurEffect  -
(- .
BlurEffectStyle. =
.= >
Light> C
)C D
;D E
} 	
private!! 
void!! '
AudioSlider_ValueNewChanged!! 0
(!!0 1
object!!1 7
sender!!8 >
,!!> ?
Views!!@ E
.!!E F
Custom!!F L
.!!L M
AudioSliderControl!!M _
.!!_ `
ValueChangedArgs!!` p
e!!q r
)!!r s
{"" 	
	ViewModel## 
?## 
.## '
AudioSlider_ValueNewChanged## 2
(##2 3
e##3 4
)##4 5
;##5 6
}$$ 	
private&& 
void&& 
PageDisappearing&& %
(&&% &
object&&& ,
sender&&- 3
,&&3 4
	EventArgs&&5 >
e&&? @
)&&@ A
{'' 	
	ViewModel(( 
?(( 
.(( 
Disappearing(( #
(((# $
)(($ %
;((% &
})) 	
private++ 
void++ 
PageAppearing++ "
(++" #
object++# )
sender++* 0
,++0 1
	EventArgs++2 ;
e++< =
)++= >
{,, 	
FocusContext-- 
.-- 

UnfocusAll-- #
(--# $
)--$ %
;--% &

playButton.. 
... 

IsNFocused.. !
=.." #
true..$ (
;..( )
	ViewModel// 
?// 
.// 
	Appearing//  
(//  !
)//! "
;//" #
}00 	
public22 
void22 
Block22 
(22 
)22 
{33 	
blocker44 
.44 
	IsVisible44 
=44 
true44  $
;44$ %
}55 	
public77 
void77 
Unblock77 
(77 
)77 
{88 	
blocker99 
.99 
	IsVisible99 
=99 
false99  %
;99% &
}:: 	
public<< 
bool<< 
	IsBlocked<< 
(<< 
)<< 
{== 	
return>> 
blocker>> 
.>> 
	IsVisible>> $
;>>$ %
}?? 	
}AA 
}BB �
LD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\LanguageSelectPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
LanguageSelectPage +
:, -
ContentPage. 9
{ 
public

 
LanguageSelectPage

 !
(

! "
)

" #
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �@
CD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ModalPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
	ModalPage "
:# $
ContentPage% 0
,0 1 
INavigationContainer2 F
{ 
private 
IDisposable 
loopSubscription ,
;, -
private 
ModalViewModel 
	ViewModel (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
	ModalPage 
( 
ContentView $
content% ,
,, -
string. 4
title5 :
,: ;
bool< @
topPanelVisibleA P
=Q R
trueS W
,W X
boolY ]
playerPanelVisible^ p
=q r
trues w
)w x
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
page 
. 
Padding 
= 
safeAreaInset (
;( )
BindingContext 
= 
	ViewModel &
=' (
new) ,
ModalViewModel- ;
(; <
	container< E
,E F
titleG L
,L M
topPanelVisibleN ]
)] ^
;^ _
	container!! 
.!! 
Children!! 
.!! 
Add!! "
(!!" #
content!!# *
)!!* +
;!!+ ,
	Appearing## 
+=## 
PageAppearing## &
;##& '
Disappearing$$ 
+=$$ 
PageDisappearing$$ ,
;$$, -
playerPanel&& 
.&& 
	IsVisible&& !
=&&" #
playerPanelVisible&&$ 6
;&&6 7
	ViewModel'' 
.'' 
OnPropertyChanged'' '
(''' (
(''( )
)'') *
=>''+ -
	ViewModel''. 7
.''7 8!
DownloadButtonVisible''8 M
)''M N
;''N O
PageAppearing(( 
((( 
null(( 
,(( 
	EventArgs((  )
.(() *
Empty((* /
)((/ 0
;((0 1
})) 	
private,, 
void,, 
PageDisappearing,, %
(,,% &
object,,& ,
sender,,- 3
,,,3 4
	EventArgs,,5 >
e,,? @
),,@ A
{-- 	
	ViewModel.. 
?.. 
... 
Disappearing.. #
(..# $
)..$ %
;..% &
loopSubscription// 
?// 
.// 
Dispose// %
(//% &
)//& '
;//' (
loopSubscription00 
=00 
null00 #
;00# $
}11 	
private33 
void33 
PageAppearing33 "
(33" #
object33# )
sender33* 0
,330 1
	EventArgs332 ;
e33< =
)33= >
{44 	
var55 
src55 
=55 
System55 
.55 
Reactive55 %
.55% &
Linq55& *
.55* +

Observable55+ 5
.555 6
Timer556 ;
(55; <
TimeSpan55< D
.55D E
Zero55E I
,55I J
TimeSpan55K S
.55S T
FromMilliseconds55T d
(55d e
$num55e h
)55h i
)55i j
.55j k
	Timestamp55k t
(55t u
)55u v
;55v w
loopSubscription66 
=66 
src66 "
.66" #
	Subscribe66# ,
(66, -
time66- 1
=>662 4
Tick665 9
(669 :
)66: ;
)66; <
;66< =
	ViewModel77 
?77 
.77 
	Appearing77  
(77  !
)77! "
;77" #
FocusContext88 
.88 

UnfocusAll88 #
(88# $
)88$ %
;88% &
if:: 
(:: 
	container:: 
.:: 
Children:: !
[::! "
$num::" #
]::# $
is::% '
DownloadPage::( 4
)::4 5
{;; 

backButton<< 
.<< 

IsNFocused<< %
=<<& '
true<<( ,
;<<, -
}== 
else>> 
{?? 

backButton@@ 
.@@ 
	IsVisible@@ $
=@@% &
false@@' ,
;@@, -
ifAA 
(AA 
	containerAA 
.AA 
ChildrenAA &
[AA& '
$numAA' (
]AA( )
isAA* ,
INFocusContentAA- ;
focusContentAA< H
)AAH I
{BB 
focusContentCC  
.CC  !

TopElementCC! +
.CC+ ,
NextFocusUpCC, 7
=CC8 9
nullCC: >
;CC> ?
focusContentDD  
.DD  !
BottomElementDD! .
.DD. /
NextFocusDownDD/ <
=DD= >
playerPanelDD? J
.DDJ K
ImageButtonDDK V
;DDV W
(EE 
playerPanelEE  
.EE  !
BindingContextEE! /
asEE0 2 
PlayerPanelViewModelEE3 G
)EEG H
.EEH I
NextFocusUpEEI T
=EEU V
focusContentEEW c
.EEc d
BottomElementEEd q
;EEq r
(FF 
playerPanelFF  
.FF  !
BindingContextFF! /
asFF0 2 
PlayerPanelViewModelFF3 G
)FFG H
.FFH I
NextFocusUp1FFI U
=FFV W
focusContentFFX d
.FFd e
BottomElementFFe r
;FFr s
focusContentGG  
.GG  !

TopElementGG! +
.GG+ ,

IsNFocusedGG, 6
=GG7 8
trueGG9 =
;GG= >
}HH 
}II 
}JJ 	
privateLL 
voidLL 
TickLL 
(LL 
)LL 
{MM 	
ifNN 
(NN 
playerPanelNN 
!=NN 
nullNN #
)NN# $
{OO 
playerPanelPP 
?PP 
.PP 
TickPP !
(PP! "
)PP" #
;PP# $
}QQ 
	ViewModelSS 
?SS 
.SS 
TickSS 
(SS 
)SS 
;SS 
}TT 	
publicVV 
voidVV 
BlockVV 
(VV 
)VV 
{WW 	
blockerXX 
.XX 
	IsVisibleXX 
=XX 
trueXX  $
;XX$ %
}YY 	
public[[ 
void[[ 
Unblock[[ 
([[ 
)[[ 
{\\ 	
blocker]] 
.]] 
	IsVisible]] 
=]] 
false]]  %
;]]% &
}^^ 	
public`` 
bool`` 
	IsBlocked`` 
(`` 
)`` 
{aa 	
returnbb 
blockerbb 
.bb 
	IsVisiblebb $
;bb$ %
}cc 	
publicee 
Typeee 
GetContentTypeee "
(ee" #
)ee# $
{ff 	
returngg 
	containergg 
.gg 
Childrengg %
.gg% &
Countgg& +
==gg, .
$numgg/ 0
?gg1 2
nullgg3 7
:gg8 9
	containergg: C
.ggC D
ChildrenggD L
[ggL M
$numggM N
]ggN O
.ggO P
GetTypeggP W
(ggW X
)ggX Y
;ggY Z
}hh 	
}jj 
}kk �=
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\NormalPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 

NormalPage #
:$ %
ContentPage& 1
{ 
private 
NormalViewModel 
	ViewModel  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 

NormalPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
On 
< 
iOS 
> 
( 
) 
. 
SetUseSafeArea $
($ %
true% )
)) *
;* +
var 
safeAreaInset 
= 
On  "
<" #
iOS# &
>& '
(' (
)( )
.) *
SafeAreaInsets* 8
(8 9
)9 :
;: ;
page 
. 
Padding 
= 
safeAreaInset (
;( )
BindingContext 
= 
	ViewModel &
=' (
new) ,
NormalViewModel- <
(< =
	container= F
,F G
playerPanelH S
,S T
searchButtonU a
,a b
playerButtonc o
)o p
;p q
Global 
. 
NavigationInstance %
=& '
new( +
NavigationWrapper, =
(= >
this> B
.B C

NavigationC M
)M N
;N O
Global 
. 
Page 
= 
this 
; 
	Appearing 
+= 
PageAppearing &
;& '
Disappearing 
+= 
PageDisappearing ,
;, -
} 	
public"" 
void"" 
Block"" 
("" 
)"" 
{## 	
blocker$$ 
.$$ 
	IsVisible$$ 
=$$ 
true$$  $
;$$$ %
}%% 	
public'' 
void'' 
Unblock'' 
('' 
)'' 
{(( 	
blocker)) 
.)) 
	IsVisible)) 
=)) 
false))  %
;))% &
}** 	
public++ 
bool++ 
	IsBlocked++ 
(++ 
)++ 
{,, 	
return-- 
blocker-- 
.-- 
	IsVisible-- $
;--$ %
}.. 	
private11 
void11 
PageDisappearing11 %
(11% &
object11& ,
sender11- 3
,113 4
	EventArgs115 >
e11? @
)11@ A
{22 	
	ViewModel33 
?33 
.33 
Disappearing33 #
(33# $
)33$ %
;33% &
}44 	
private66 
void66 
PageAppearing66 "
(66" #
object66# )
sender66* 0
,660 1
	EventArgs662 ;
e66< =
)66= >
{77 	
	ViewModel88 
?88 
.88 
	Appearing88  
(88  !
)88! "
;88" #
FocusContext99 
.99 

UnfocusAll99 #
(99# $
)99$ %
;99% &
artistButton:: 
.:: 

IsNFocused:: #
=::$ %
true::& *
;::* +
(;; 
this;; 
.;; 
playerPanel;; 
.;; 
BindingContext;; ,
as;;- / 
PlayerPanelViewModel;;0 D
);;D E
.;;E F
NextFocusUp;;F Q
=;;R S
playerButton;;T `
;;;` a
(<< 
this<< 
.<< 
playerPanel<< 
.<< 
BindingContext<< ,
as<<- / 
PlayerPanelViewModel<<0 D
)<<D E
.<<E F
NextFocusUp1<<F R
=<<S T
playlistButton<<U c
;<<c d
playerButton>> 
.>> 
NextFocusDown>> &
=>>' (
this>>) -
.>>- .
playerPanel>>. 9
.>>9 :
ImageButton>>: E
;>>E F
trackButton?? 
.?? 
NextFocusDown?? %
=??& '
this??( ,
.??, -
playerPanel??- 8
.??8 9
ImageButton??9 D
;??D E
artistButton@@ 
.@@ 
NextFocusDown@@ &
=@@' (
this@@) -
.@@- .
playerPanel@@. 9
.@@9 :

PlayButton@@: D
;@@D E
playlistButtonAA 
.AA 
NextFocusDownAA (
=AA) *
thisAA+ /
.AA/ 0
playerPanelAA0 ;
.AA; <

PlayButtonAA< F
;AAF G
}BB 	
privateDD 
asyncDD 
voidDD 
Entry_CompletedDD *
(DD* +
objectDD+ 1
senderDD2 8
,DD8 9
	EventArgsDD: C
eDDD E
)DDE F
{EE 	
ifFF 
(FF 
!FF 
stringFF 
.FF 
IsNullOrEmptyFF %
(FF% &
	ViewModelFF& /
?FF/ 0
.FF0 1
	EntryTextFF1 :
)FF: ;
)FF; <
{GG 
awaitHH 
GlobalHH 
.HH 
NavigationInstanceHH /
.HH/ 0
PushModalAsyncHH0 >
(HH> ?
newHH? B
	ModalPageHHC L
(HHL M
newHHM P
ViewsHHQ V
.HHV W
SearchResultPageHHW g
(HHg h
	ViewModelHHh q
?HHq r
.HHr s
	EntryTextHHs |
)HH| }
,HH} ~
	ViewModel	HH �
?
HH� �
.
HH� �
	EntryText
HH� �
)
HH� �
)
HH� �
;
HH� �
}II 
}JJ 	
privateKK 
voidKK 
Entry_FocusedKK "
(KK" #
objectKK# )
senderKK* 0
,KK0 1
FocusEventArgsKK2 @
eKKA B
)KKB C
{LL 	
	ViewModelMM 
.MM $
SearchSuggestionsVisibleMM .
=MM/ 0
trueMM1 5
;MM5 6
	ViewModelNN 
?NN 
.NN 
RefreshSuggestionNN (
(NN( )
)NN) *
;NN* +
}OO 	
privateQQ 
voidQQ 
Entry_UnfocusedQQ $
(QQ$ %
objectQQ% +
senderQQ, 2
,QQ2 3
FocusEventArgsQQ4 B
eQQC D
)QQD E
{RR 	
	ViewModelSS 
.SS $
SearchSuggestionsVisibleSS .
=SS/ 0
falseSS1 6
;SS6 7
}TT 	
privateVV 
voidVV 
Entry_TextChangedVV &
(VV& '
objectVV' -
senderVV. 4
,VV4 5 
TextChangedEventArgsVV6 J
eVVK L
)VVL M
{WW 	
	ViewModelXX 
?XX 
.XX 
RefreshSuggestionXX (
(XX( )
)XX) *
;XX* +
}YY 	
private[[ 
void[[ '
SuggestionList_ItemSelected[[ 0
([[0 1
object[[1 7
sender[[8 >
,[[> ?(
SelectedItemChangedEventArgs[[@ \
e[[] ^
)[[^ _
{\\ 	
	ViewModel]] 
?]] 
.]] #
SuggestionItem_Selected]] .
(]]. /
sender]]/ 5
,]]5 6
e]]7 8
)]]8 9
;]]9 :
}^^ 	
}`` 
}aa �
HD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\PermissionPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
PermissionPage '
:( )
ContentPage* 5
{ 
public

 
PermissionPage

 
(

 
)

 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �
FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\PlaylistPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{		 
[

 
XamlCompilation

 
(

 "
XamlCompilationOptions

 +
.

+ ,
Compile

, 3
)

3 4
]

4 5
public 

partial 
class 
PlaylistPage %
:& '
ContentView( 3
,3 4
ITimerContent5 B
,B C
INFocusContentD R
{ 
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
PlaylistPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 
playlistList %
;% &
BottomElement 
= 
playlistList (
;( )
} 	
public 
void 
	Appearing 
( 
) 
{ 	
} 	
public 
void 
Disappearing  
(  !
)! "
{   	
}"" 	
public$$ 
void$$ 
FocusAction$$ 
($$  
)$$  !
{%% 	
throw&& 
new&& 
System&& 
.&& #
NotImplementedException&& 4
(&&4 5
)&&5 6
;&&6 7
}'' 	
public)) 
void)) 
	FocusDown)) 
()) 
))) 
{** 	
throw++ 
new++ 
System++ 
.++ #
NotImplementedException++ 4
(++4 5
)++5 6
;++6 7
},, 	
public.. 
void.. 
	FocusLeft.. 
(.. 
).. 
{// 	
throw00 
new00 
System00 
.00 #
NotImplementedException00 4
(004 5
)005 6
;006 7
}11 	
public33 
void33 

FocusRight33 
(33 
)33  
{44 	
throw55 
new55 
System55 
.55 #
NotImplementedException55 4
(554 5
)555 6
;556 7
}66 	
public88 
void88 
FocusUp88 
(88 
)88 
{99 	
throw:: 
new:: 
System:: 
.:: #
NotImplementedException:: 4
(::4 5
)::5 6
;::6 7
};; 	
public== 
void== 
Tick== 
(== 
)== 
{>> 	
if?? 
(?? 

GlobalData?? 
.?? 
Current?? "
.??" # 
PlaylistsNeedRefresh??# 7
&&??8 :
!??; <
(??< =
BindingContext??= K
as??L N
PlaylistViewModel??O `
)??` a
.??a b
IsInitializing??b p
&&??q s
Global??t z
.??z {
Loaded	??{ �
)
??� �
{@@ 
DeviceAA 
.AA #
BeginInvokeOnMainThreadAA .
(AA. /
(AA/ 0
BindingContextAA0 >
asAA? A
PlaylistViewModelAAB S
)AAS T
.AAT U

InitializeAAU _
)AA_ `
;AA` a

GlobalDataBB 
.BB 
CurrentBB "
.BB" # 
PlaylistsNeedRefreshBB# 7
=BB8 9
falseBB: ?
;BB? @
}CC 
}DD 	
}FF 
}GG �
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\SearchPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 

SearchPage		 #
:		$ %
ContentView		& 1
,		1 2
INFocusContent		3 A
{

 
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
private 
SearchViewModel 
	ViewModel  )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 

SearchPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 
screenKeyboard '
;' (
BottomElement 
= 
screenKeyboard *
;* +
	ViewModel 
= 
BindingContext &
as' )
SearchViewModel* 9
;9 :,
 ScreenKeyboard_OnKeyboardClicked ,
(, -
$str- /
)/ 0
;0 1
} 	
private 
async 
void ,
 ScreenKeyboard_OnKeyboardClicked ;
(; <
string< B
clickedButtonC P
)P Q
{ 	
if 
( 
clickedButton 
== 
NScreenKeyboard  /
./ 0
EnterButton0 ;
); <
{ 
if 
( 
! 
string 
. 
IsNullOrEmpty )
() *
	ViewModel* 3
.3 4

SearchText4 >
)> ?
)? @
{ 
await 
Global  
.  !
NavigationInstance! 3
.3 4
PushModalAsync4 B
(B C
newC F
	ModalPageG P
(P Q
newQ T
SearchResultPageU e
(e f
	ViewModelf o
.o p

SearchTextp z
)z {
,{ |
	ViewModel	} �
.
� �

SearchText
� �
)
� �
)
� �
;
� �
} 
} 
else   
if   
(   
clickedButton   !
==  " $
NScreenKeyboard  % 4
.  4 5
RemoveButton  5 A
)  A B
{!! 
if"" 
("" 
	ViewModel"" 
."" 

SearchText"" (
.""( )
Length"") /
>""0 1
$num""2 3
)""3 4
{## 
	ViewModel$$ 
.$$ 

SearchText$$ (
=$$) *
	ViewModel$$+ 4
.$$4 5

SearchText$$5 ?
[$$? @
$num$$@ A
..$$A C
^$$C D
$num$$D E
]$$E F
;$$F G
	ViewModel%% 
.%% 
RefreshSuggestion%% /
(%%/ 0
)%%0 1
;%%1 2
}&& 
}'' 
else(( 
{)) 
	ViewModel** 
.** 

SearchText** $
+=**% '
clickedButton**( 5
.**5 6
ToLowerInvariant**6 F
(**F G
)**G H
;**H I
	ViewModel++ 
.++ 
RefreshSuggestion++ +
(+++ ,
)++, -
;++- .
},, 
}-- 	
}.. 
}// �
JD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\SearchResultPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 
SearchResultPage

 )
:

* +
ContentView

, 7
,

7 8
INFocusContent

9 G
{ 
private !
SearchResultViewModel %
	ViewModel& /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
SearchResultPage 
(  
string  &
searchedText' 3
)3 4
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 
searchResultList )
;) *
BottomElement 
= 
searchResultList ,
;, -
BindingContext 
= 
	ViewModel &
=' (
new) ,!
SearchResultViewModel- B
(B C
searchedTextC O
)O P
;P Q
} 	
} 
} �

FD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\SettingsPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
SettingsPage %
:& '
ContentView( 3
,3 4
INFocusContent5 C
{		 
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
SettingsPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "

TopElement 
= 
	wwwButton "
;" #
BottomElement 
= 
settingsList (
;( )
} 	
} 
} �
DD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\TracksPage.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 

TracksPage

 #
:

$ %
ContentView

& 1
,

1 2
ITimerContent

3 @
,

@ A
INFocusContent

B P
{ 
private 
bool 
tick 
= 
false !
;! "
private 
TrackViewModel 
	ViewModel (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 

TopElement (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
INFocusElement 
BottomElement +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 

TracksPage 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
	ViewModel 
= 
BindingContext &
as' )
TrackViewModel* 8
;8 9

TopElement 
= 
	trackList "
;" #
BottomElement 
= 
	trackList %
;% &
} 	
public 
void 
Tick 
( 
) 
{ 	
if   
(   
!   
tick   
)   
{!! 
Device"" 
."" #
BeginInvokeOnMainThread"" .
("". /
(""/ 0
)""0 1
=>""2 4
{## 
tick$$ 
=$$ 
true$$ 
;$$  
	ViewModel%% 
?%% 
.%% 
Tick%% #
(%%# $
)%%$ %
;%%% &
tick&& 
=&& 
false&&  
;&&  !
}'' 
)'' 
;'' 
}(( 
})) 	
public** 
void** 
	Appearing** 
(** 
)** 
{++ 	
}-- 	
public// 
void// 
Disappearing//  
(//  !
)//! "
{00 	
}22 	
}44 
}55 �
RD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\ArtistGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
ArtistGridItem		 '
:		( )
ContentView		* 5
{

 
public 
ArtistGridItem 
( 
NListViewItem +
context, 3
)3 4
{ 	
InitializeComponent 
(  
)  !
;! "
( 
context 
as 
ArtistModel #
)# $
.$ %
View% )
=* +
this, 0
;0 1
BindingContext 
= 
context $
;$ %
} 	
} 
} �
TD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\PlaylistGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 
PlaylistGridItem

 )
:

* +
ContentView

, 7
{ 
public 
PlaylistGridItem 
(  
NListViewItem  -
context. 5
)5 6
{ 	
InitializeComponent 
(  
)  !
;! "
( 
context 
as 
PlaylistModel %
)% &
.& '
View' +
=, -
this. 2
;2 3
BindingContext 
= 
context $
;$ %
} 	
} 
} �
WD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\PlaylistWebGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[		 
XamlCompilation		 
(		 "
XamlCompilationOptions		 +
.		+ ,
Compile		, 3
)		3 4
]		4 5
public

 

partial

 
class

 
PlaylistWebGridItem

 ,
:

- .
ContentView

/ :
{ 
public 
PlaylistWebGridItem "
(" #
NListViewItem# 0
context1 8
)8 9
{ 	
InitializeComponent 
(  
)  !
;! "
( 
context 
as 
PlaylistModel %
)% &
.& '
View' +
=, -
this. 2
;2 3
BindingContext 
= 
context $
;$ %
} 	
} 
} �
XD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\SearchResultViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class  
SearchResultViewCell -
:. /
ContentView0 ;
{		 
public

  
SearchResultViewCell

 #
(

# $
NListViewItem

$ 1
context

2 9
)

9 :
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
context $
;$ %
} 	
} 
} �
TD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\SettingsViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
SettingsViewCell )
:* +
ContentView, 7
{		 
public

 
SettingsViewCell

 
(

  
NListViewItem

  -
context

. 5
)

5 6
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
context $
;$ %
this 
. 
LayoutChanged 
+= !*
SettingsViewCell_LayoutChanged" @
;@ A
} 	
private 
void *
SettingsViewCell_LayoutChanged 3
(3 4
object4 :
sender; A
,A B
SystemC I
.I J
	EventArgsJ S
eT U
)U V
{ 	
HorizontalOptions 
= 
LayoutOptions  -
.- .
StartAndExpand. <
;< =
} 	
} 
} �
VD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\SuggestionViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
SuggestionViewCell +
:, -
ContentView. 9
{		 
public

 
SuggestionViewCell

 !
(

! "
NListViewItem

" /
context

0 7
)

7 8
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
context $
;$ %
this 
. 
LayoutChanged 
+= !*
SettingsViewCell_LayoutChanged" @
;@ A
} 	
private 
void *
SettingsViewCell_LayoutChanged 3
(3 4
object4 :
sender; A
,A B
SystemC I
.I J
	EventArgsJ S
eT U
)U V
{ 	
HorizontalOptions 
= 
LayoutOptions  -
.- .
StartAndExpand. <
;< =
} 	
} 
} �
QD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\TV\ViewCells\TrackViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
TV" $
.$ %
	ViewCells% .
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
TrackViewCell &
:' (
ContentView) 4
{		 
public

 
TrackViewCell

 
(

 
NListViewItem

 *
context

+ 2
)

2 3
{ 	
InitializeComponent 
(  
)  !
;! "
BindingContext 
= 
context $
;$ %
} 	
} 
} �

OD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\ArtistGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
ArtistGridItem		 '
:		( )
ContentView		* 5
{

 
public 

ArtistPage 
Page 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
ArtistGridItem 
( 

ArtistPage (
page) -
,- .
string/ 5

artistName6 @
)@ A
{ 	
InitializeComponent 
(  
)  !
;! "
Page 
= 
page 
; 
BindingContext 
= 
new  #
ArtistGridItemViewModel! 8
(8 9

artistName9 C
,C D
thisE I
)I J
;J K
} 	
} 
} �
QD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\DownloadViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
DownloadViewCell )
:* +
ViewCell, 4
{ 
public

 
DownloadViewCell

 
(

  
)

  !
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �

QD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\PlaylistGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
PlaylistGridItem		 )
:		* +
ContentView		, 7
{

 
public 
PlaylistPage 
Page  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 
PlaylistGridItem 
(  
PlaylistPage  ,
page- 1
,1 2
string3 9
playlistName: F
)F G
{ 	
InitializeComponent 
(  
)  !
;! "
Page 
= 
page 
; 
BindingContext 
= 
new  %
PlaylistGridItemViewModel! :
(: ;
playlistName; G
,G H
thisI M
)M N
;N O
} 	
} 
} �

TD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\PlaylistWebGridItem.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public		 

partial		 
class		 
PlaylistWebGridItem		 ,
:		- .
ContentView		/ :
{

 
public 
PlaylistPage 
Page  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 
PlaylistWebGridItem "
(" #
PlaylistPage# /
page0 4
,4 5
string6 <
playlistName= I
)I J
{ 	
InitializeComponent 
(  
)  !
;! "
Page 
= 
page 
; 
BindingContext 
= 
new  %
PlaylistGridItemViewModel! :
(: ;
playlistName; G
,G H
thisI M
)M N
;N O
} 	
} 
} �
UD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\SearchResultViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class  
SearchResultViewCell -
:. /
ViewCell0 8
{ 
public

  
SearchResultViewCell

 #
(

# $
)

$ %
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �
QD:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\SettingsViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
SettingsViewCell )
:* +
ViewCell, 4
{ 
public

 
SettingsViewCell

 
(

  
)

  !
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} �
ND:\Projekty\CS\Newtone\Newtone.Mobile.UI\Views\ViewCells\TrackViewCell.xaml.cs
	namespace 	
Newtone
 
. 
Mobile 
. 
UI 
. 
Views !
.! "
	ViewCells" +
{ 
[ 
XamlCompilation 
( "
XamlCompilationOptions +
.+ ,
Compile, 3
)3 4
]4 5
public 

partial 
class 
TrackViewCell &
:' (
ViewCell) 1
{ 
public

 
TrackViewCell

 
(

 
)

 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} 