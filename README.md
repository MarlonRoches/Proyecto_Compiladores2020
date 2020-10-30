
# Proyecto_Compiladores2020

# Mini-Java (Analizador Sintáctico)
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
                                Field->static CnsTp ident ;
                                Proto->Prototype Proto
                                Proto->''
                                Prototype->Type ident ( Formals ) ;
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


## Programadores ✒️
    ○ Marlon Roches
    ○ Alexander Villatoro
## Creado en 🛠️
    ● Aplicación en Consola y en .NET Framework Version 4.7.2

