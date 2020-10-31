
# Proyecto_Compiladores2020

# Mini-Java (Analizador Léxico)

## Descripción

Es un analizador léxico para una mini compilador creado en C# para el lenguaje de programación Java. Su función se lleva acabo en esta fase es la parte del análisis léxico y consiste en reconocer tokens segun el orden de lectura del archivo, y en base a expresiones regulares el programa separará los tokens como correctos o errores.

## Tabla de Contenido 

- [Fase 1](#fase-1).
- [Fase 2](#fase-2).
- [Objetivo](#objetivo-general).
- [Estructura Lexicográfica](#estructura-lexicográfica-%EF%B8%8F).
- [Laboratorio A](#laboratorio-a).
- [Programadores](#programadores-%EF%B8%8F).
- [Creado en](#creado-en-%EF%B8%8F).

## Flujo del Programa
        ● Pasos
        1. Se inicia la consola con el nombre de minij.exe
        2. Se hace un Drag 'n Drop del archivo que contenga el codigo de mini-java o se escribe la ruta de donde este el archivo.
        3. Despues se da un "enter" para poder ejecutar el programa.
        4. Se muestra la lista de los errores en consola si en el caso del archivo contenga alguno, de lo contrario no demostraría ningún error.
        5. Se creará un archivo de salida que contenga el mismo nombre del archivo que contiene el código de mini-java, con la diferencia de 
           que este archivo de salida va a contener la extensión ".out" en la misma ruta de donde esté el archivo de prueba.
## Fase 1

#### Objetivo General 
En el primer proyecto de programación en clase de Compiladores, ustedes iniciarán su compilador con la aplicación del análisis léxico. Para la primera tarea del front-end, crearán un escáner para el lenguaje de programación asignado. El escáner irá reconociendo los tokens en el orden en que se leen, hasta el final del archivo.  Para cada lenguaje, el escáner determinará sus atributos adecuadamente (estos eventualmente serán utilizados por otros componentes de su compilador) para que la información sobre cada símbolo deba estar correctamente impresa. 

### Estructura Lexicográfica ⚙️
#### Palabras Reservadas
    ● void,int,double,boolean,string,class,const,interface,null,this,extends,implements,for,while,if,else,return,break,New,System,out,println
#### Identificadores
    ● Un identificador es una secuencia de letras, dígitos y signo dólar. Puede comenzar con cualquiera excepto un número. 
Ejemplos de Identificadores Correctos e Incorrectos

    ●Correctos: 
        ○ flag
        ○ aux1
        ○ item1
    ●Incorrectos:
        ○ 20item
        ○ _listGrades

#### Case Sensitive 
    ● El mini compilador detecta si una palabra reservada esta en mayuscula; ya sea mayuscula esta palabra sera un identificador y si esta en minusculas se detectará como palabra reservada. 
    Por Ejemplo:
    ● else es una palabra reservada, pero ELSE es un identificador
#### Espacios en Blanco
    ● Son los espacios, tabuladores y saltos de línea que sirven para separar los tokens deseados. Para las palabras claves y los identificadores deben de  separarse por espacios en blanco o señalando que no es ni palabra reservada ni un identificador. 
    Por Ejemplo:
    ● "if ( 23 this se escanea como cuatro tokens, al igual que if(23this"
####  Comentarios (Varias Lineas)
    ● Si se inica con "/*" y termina con "*/" cualquier texto o codigo se permite en un comentario, excepto el de secuencia */ que pone fin al comentario actual. Estos comentarios de varias lineas no se anidan.
#### Comentarios (Una sola línea)
    ● Si se inicia con "//" para comentar todo lo que este en esa linea, permite simbolos dentro de estos.
    
## Constantes    
#### Operadores
    ● + - * / % < <= > >= = == != && || ! ; , . [ ] ( ) { } [] () {}
#### Booleanas
    ● true o false
#### Enteros (Base 10 o Base 16)
    ● Se expresa en decimal(Base 10)
        ○ Es una secuencia de digitos decimales (0-9).
        
    ● Se expresa en Hexadecimales(Base 16)
        ○ Un entero Hexadecimal se comienza por un 0x o 0X, seguido por una secuencia de digitos hexadecimales, en los cuales los digitos hexadecimales incluyen los digitos y las letras de la "a" a la "f"(ya sea en minúsculas o mayúsculas). 
#### Double
    ● Es una secuencia de digitos seguidos de un punto("."), seguido de otra secuencia de digitos o nada.
        ○ Por Ejemplo: 20. y 0.22.
    ● En las constantes dobles en la notación cientifica, el punto(".") es requerido y el signo del exponente es opcional, ya que si no se especifica el signo se agarra como "+".
#### String o Cadena de Caracteres
    ● Es una secuencia de caracteres que estan dentro de unas comillas dobles "". 
      El string no puede contener una linea nueva, doble comillas o un carácter nulo.
      Un constante string debe comenzar y finalar en una misma línea, y no puede partirse en líneas múltiples.
        ○ Por Ejemplo: "Está es una cadena de caracteres que no tiene su doble comilla; Esta no es parte de la cadena de arriba // Todos deben ser identificadores
# Laboratorio A
#### Objetivo General
    Este laboratorio consistirá en analizar sintácticamente un programa escrito en el lenguaje asignado, implementando el método de análisis sintáctico descendente recursivo.
    Deberán hacer uso de su analizador léxico de la fase anterior. La finalidad es poder determinar que el programa fuente escrito está sintácticamente correcto utilizando   
    este metodo.
### Gramática de Mini-Java
                Program            -> Decl Program’

                Program’        -> Program | ε

                Decl            -> VariableDecl | FunctionDecl

                VariableDecl    -> Variable ; 

                Variable        -> Type ident

                Type            -> int Type’ | double Type’| boolean Type’| string Type’ | ident Type’ 

                Type’            -> [] Type’ | ε

                FunctionDecl    -> Type ident ( Formals ) Stmt | void  ident ( Formals ) Stmt

                Formals            -> Variable Variable’ |  ε

                Variable’        -> , Variable | ε

                Stmt            -> Stmt' Stmt |ϵ

                Stmt'              -> if Stmt | While Stmt | Expr ;

                IfStmt            -> if ( Expr ) Stmt ifStmt’

                IfStmt’            -> else Stmt | ε

                WhileStmt        -> while ( Expr ) Stmt

                Expr             -> B Expr'

                Expr'            -> || B Expr' | ϵ

                B                -> C B'

                B'                -> && C | ϵ

                C                -> D C'

                C'                -> == D C' | !=D C' | ϵ

                D                -> E D' 

                D'                -> <E D' | <=E D' | >E D' | >=E D' | ϵ  

                E                -> F E'

                E'                -> +F E' | -F E' | ϵ 

                F                -> G F' 

                F'                -> *G F' | /G F' | %G F' | ϵ 

                G                -> !Expr | -Expr | H

                H                -> I H' 

                H'                -> [Expr] Igual' H' | . ident Igual' H' | ϵ

                I                 -> (Expr) | New(ident) | Constant | ident Igual' | this 

                Igual'             -> = Expr | ϵ

                Constant        -> intCostant | doubleConstant | boolConstant | stringConstant | null

####  Manejo de Errores           

        Se manejo de dos diferentes formas:
             1. Declaración de Variables: Si viene un token que no termina con ";" esto nos da a decir que estos tokens son de la otra función.
                Se hace un backtracking porque asi se sabe que se tiene que ir a la otra función. Si la primera expresión esta buena, esta se analiza 
                y se sigue con la siguiente, de una forma recursiva. Cuando se usa el backtracking, se regresa a las tokens que teniamos y luego 
                de regresar los tokens ya se tendría listos para poder analizarlos otra vez pero apartir de la otra producción. 
                
             2. Declaración de Funciones: Si existe un error, lo que te tiene que decir el anazalizador el token que deberia estar esperando y demuestra
                el que token que esta mal escrito. No va a sacar error a toda la linea si no que nos demostrara el valor que debería de ir.
                Conforme se este derivando la expresión y encuentre el token que acepta o no aceptam si lo acepta no demuestra nada, y si no lo acepta,
                va a tirar un error diciendo el valor que deberia de aparecer y el valor incorrecto

####  Output

La salida de los tokens aceptados se demostrará en un archivo ".tout". Si salieron duplicados es porque se aceptaron en varias producciones y en otras tambien.

####  Archivos de Prueba
```java
int Metodo() while(a + b)/*(true || false);
void Metodo2 (boolean numero, string lol , string xd, int flag) */
if ( flag3 && true == false % !flag4 && -true % false ) a + b;
```
```java
string Prueba;
string[] PruebaArr;
int[] numeroArr ;int numero ;
boolean flag;boolean []flagArr;
```
```java
Car[] Mercedez hola;
string Prueba;
string[] PruebaArr;
int[] numeroArr ;int numero ;
boolean flag;boolean []flagArr;
```
```java
carro[] auto gola ;
 int a;
 int b;
 int Metodo() while(a + b) hola ;
boolean flag1;
 boolean flag2;
 boolean flag3;
void Metodo2 (boolean numero, string lol , string xd, int flag) if ( flag3 && true == false % !flag4 && -true % false ) a + b; 
boolean flag4;
 void Metodo3 (int flag) while(a + b) if ( flag3 && true == false % !flag4 && -true % false );
 ```
 ```java
 void Metodo(boolean numero, string lol , string xd, int flag) 
if ( flag || true || false ) else if ( flag || true || false ) a + c;
 ```
 ```java
 Car[] Mercedez hola; //tira error por que tiene un hola de mas, se irá mas adelante a la siguiente produccin y dirá lo que esperaba
string Prueba;
string[] PruebaArr;
int[] numeroArr ;int numero ;
boolean flag;boolean []flagArr;
```

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

