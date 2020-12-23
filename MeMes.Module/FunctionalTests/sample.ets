;#DropDB MeMesEasyTest

#Application MeMesWin
#Application MeMesWeb
#IfDef MeMesWin

*Action About...
 
*Action OK

#EndIf

#IfDef MeMesWeb
!Action Navigation(My Details)
#EndIf
