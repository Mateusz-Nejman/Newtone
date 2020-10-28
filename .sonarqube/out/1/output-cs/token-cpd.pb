�5
7D:\Projekty\CS\Newtone\LocalizationGenerator\Program.cs
	namespace 	!
LocalizationGenerator
 
{ 
class 	
Program
 
{		 
static

 
void

 
Main

 
(

 
)

 
{ 	
XmlDocument 
doc 
= 
new !
XmlDocument" -
(- .
). /
;/ 0
doc
.
Load
(
$str
)
;
var 
root 
= 
doc 
. 
SelectSingleNode +
(+ ,
$str, 2
)2 3
;3 4
string 
buffer 
= 
$str G
;G H
string 
propertyBuffer !
=" #
$str$ &
;& '

Dictionary 
< 
string 
, 
string %
>% &
dict' +
=, -
new. 1

Dictionary2 <
<< =
string= C
,C D
stringE K
>K L
(L M
)M N
;N O
List 
< 
string 
> 
names 
=  
new! $
List% )
<) *
string* 0
>0 1
(1 2
)2 3
;3 4
foreach 
( 
XmlNode 
item !
in" $
root% )
.) *
SelectNodes* 5
(5 6
$str6 <
)< =
)= >
{ 
string 
name 
= 
item "
." #

Attributes# -
[- .
$str. 4
]4 5
.5 6
	InnerText6 ?
;? @
string 
value 
= 
item #
.# $
SelectSingleNode$ 4
(4 5
$str5 <
)< =
.= >
	InnerText> G
;G H
dict 
. 
Add 
( 
name 
, 
value $
)$ %
;% &
names 
. 
Add 
( 
name 
) 
;  
} 
names 
. 
Sort 
( 
) 
; 
foreach   
(   
var   
name   
in    
names  ! &
)  & '
{!! 
string"" 
value"" 
="" 
dict"" #
[""# $
name""$ (
]""( )
;"") *
buffer## 
+=## 
$"## 
public string ## *
{##* +
name##+ /
}##/ 0
 = \"##0 5
{##5 6
value##6 ;
}##; <
\";\n##< A
"##A B
;##B C
propertyBuffer$$ 
+=$$ !
$"$$" $O
C/// <summary>\n/// Wyszukuje zlokalizowany ciąg podobny do ciągu $$$ e
{$$e f
value$$f k
}$$k l
\n/// </summary>\n$$l ~
"$$~ 
;	$$ �
propertyBuffer%% 
+=%% !
$"%%" $!
public static string %%$ 9
{%%9 :
name%%: >
}%%> ?2
& {{ get {{ return CurrentLocalization.%%? e
{%%e f
name%%f j
}%%j k
	; }} }}\n%%k t
"%%t u
;%%u v
}&& 
buffer(( 
+=(( 
$str(( 
;(( 
string)) 
template)) 
=)) 
File)) "
.))" #
ReadAllText))# .
()). /
$str))/ A
)))A B
;))B C
template** 
=** 
template** 
.**  
Replace**  '
(**' (
$str**( 0
,**0 1
propertyBuffer**2 @
+**A B
$str**C G
+**H I
buffer**J P
)**P Q
;**Q R
File++ 
.++ 
WriteAllText++ 
(++ 
$str++ ^
,++^ _
template++` h
)++h i
;++i j
Generate-- 
(-- 
$str-- 
)-- 
;-- 
Generate.. 
(.. 
$str.. 
).. 
;.. 
Console// 
.// 
	WriteLine// 
(// 
$str// #
)//# $
;//$ %
}00 	
static22 
void22 
Generate22 
(22 
string22 #
lang22$ (
)22( )
{33 	
XmlDocument44 
doc44 
=44 
new44 !
XmlDocument44" -
(44- .
)44. /
;44/ 0
doc55 
.55 
Load55 
(55 
$str55 \
+55] ^
lang55_ c
+55d e
$str55f m
)55m n
;55n o
var77 
root77 
=77 
doc77 
.77 
SelectSingleNode77 +
(77+ ,
$str77, 2
)772 3
;773 4
string99 
buffer99 
=99 
$str99 X
+99Y Z
lang99[ _
.99_ `
ToUpper99` g
(99g h
)99h i
+99j k
$str	99l �
+
99� �
lang
99� �
.
99� �
ToUpper
99� �
(
99� �
)
99� �
+
99� �
$str
99� �
;
99� �
foreach;; 
(;; 
XmlNode;; 
item;; !
in;;" $
root;;% )
.;;) *
SelectNodes;;* 5
(;;5 6
$str;;6 <
);;< =
);;= >
{<< 
string== 
name== 
=== 
item== "
.==" #

Attributes==# -
[==- .
$str==. 4
]==4 5
.==5 6
	InnerText==6 ?
;==? @
string>> 
value>> 
=>> 
item>> #
.>># $
SelectSingleNode>>$ 4
(>>4 5
$str>>5 <
)>>< =
.>>= >
	InnerText>>> G
;>>G H
buffer?? 
+=?? 
$"?? 
this.?? !
{??! "
name??" &
}??& '
 = \"??' ,
{??, -
value??- 2
}??2 3
\";\n??3 8
"??8 9
;??9 :
}@@ 
bufferBB 
+=BB 
$strBB 
;BB 
FileCC 
.CC 
WriteAllTextCC 
(CC 
$strCC [
+CC\ ]
langCC^ b
.CCb c
ToUpperCCc j
(CCj k
)CCk l
+CCm n
$strCCo t
,CCt u
bufferCCv |
)CC| }
;CC} ~
}DD 	
}EE 
}FF 