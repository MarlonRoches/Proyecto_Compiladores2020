
# Proyecto_Compiladores2020

# Mini-Java (Analizador Sintáctico)

- [Fase 2](#fase-2).
- [Manejo de Errores](#manejo-de-errores).

## Fase 2
### Gramatica Fase 2 Mini-Java

                                              Start->Program
                                              Program->Decl Program
                                              Program->Decl
                                              Decl->Type ident ;
                                              Decl->Type ident ( Formals ) StmtBlock
                                              Decl->void ident ( Formals ) StmtBlock
                                              Decl->static CnsTp ident ;
                                              Decl->class ident Heritage HeritageI { FieldP }
                                              Decl->interface ident { Proto }
                                              Type->CnsTp
                                              Type->ident
                                              Type->Type []
                                              Formals->Type ident , Formals
                                              Formals->Type ident
                                              StmtBlock->{ SBPV SBPC SBPS }
                                              CnsTp->int
                                              CnsTp->double
                                              CnsTp->boolean
                                              CnsTp->string
                                              Heritage->extends ident
                                              Heritage->''
                                              HeritageI->implements ident HeritageD
                                              HeritageI->''
                                              HeritageD->, ident HeritageD
                                              HeritageD->''
                                              FieldP->Field FieldP
                                              FieldP->''
                                              Field->Type ident ;
                                              Field->Type ident ( Formals ) StmtBlock
                                              Field->void ident ( Formals ) StmtBlock" 
                                              Field->static CnsTp ident ;
                                              Proto->Prototype Proto
                                              Proto->''
                                              Prototype->Type ident ( Formals ) ;
                                              Prototype->void ident ( Formals ) ;
                                              SBPV->Type ident ; SBPV
                                              SBPV->''
                                              SBPC->static CnsTp ident ; SBPC
                                              SBPC->''
                                              SBPS->Stmt SBPS
                                              SBPS->''
                                              Stmt->Expr ;
                                              Stmt->;
                                              Stmt->if ( Expr ) Stmt ElseStmt
                                              Stmt->while ( Expr ) Stmt
                                              Stmt->for ( Expr ; Expr ; Expr ) Stmt
                                              Stmt->break ;
                                              Stmt->return Expr ;
                                              Stmt->System . out . println ( Expr ExPrint ) ;
                                              Stmt->StmtBlock
                                              ElseStmt->else Stmt
                                              ElseStmt->''
                                              ExPrint->, Expr ExPrint
                                              ExPrint->''
                                              Expr->Expr - Expr
                                              Expr->Expr / Expr
                                              Expr->Expr % Expr
                                              Expr->- Expr
                                              Expr-> Expr > Expr
                                              Expr->Expr >= Expr
                                              Expr->Expr != Expr
                                              Expr->Expr || Expr
                                              Expr->! Expr
                                              Expr->New ( ident )
                                              Expr->LValue
                                              Expr->LValue = Expr
                                              Expr->Constant
                                              Expr->this
                                              Expr->( Expr )
                                              LValue->Expr . ident
                                              LValue->ident
                                              Constant->intConstant
                                              Constant->stringConstant
                                              Constant->boolConstant
                                              Constant->doubleConstant
                                              Constant->null

### Tabla de Estados

<a href="https://docs.google.com/spreadsheets/d/1KT8kXKfLwkojqElmsG2XVfTTgeOCfz21sXeF841lnOA/edit?usp=sharing">
    <img align="left" alt="Shubhamdeep Jha | Excel" width="26px" src="https://github.com/sempostma/office365-icons/blob/master/svg/excel.svg" />
</a>
-Presione el icono para ver la tabla de símbolos

### Manejo de Errores

Según el libro del dragón, nos da a entender que el manejo de errores o recuperación de errores en un analizar sintáctico se da al momento de encontrar un token en el cual no tenga relación con la gramática dada, al momento de encontrar un error, ese token se manda a imprimir como una cadena errónea y se elimina de la entrada.  El analizador seguirá analizando el siguiente token hasta que uno tenga relación con la gramática, si el siguiente token no tiene ninguna relación con la gramática, este se tomara como un error también hasta que el analizador encontré un token correcto este seguirá con su análisis normal.

## Programadores ✒️
    ○ Marlon Roches
    ○ Alexander Villatoro
## Creado en 🛠️
    ● Aplicación en Consola y en .NET Framework Version 4.7.2

