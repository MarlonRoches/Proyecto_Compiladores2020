using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Compiladores_2020.Data
{
	class SintaxValidation
	{
		private static SintaxValidation _instance = null;
		public static SintaxValidation Instance
		{
			get
			{
				if (_instance == null) _instance = new SintaxValidation();
				return _instance;
			}
		}
		//programar cada estado de la tabla
		// obtener la pila 
		int pasos = 0;
		static Stack<int> StackDeConsumo = new Stack<int>();
		string Simbolos = "";
		Dictionary<int, string> Reducciones = new Dictionary<int, string>();
		static Stack<string> StackDeEntrada = new Stack<string>();
		static List<string> Pasos = new List<string>();
		static List<KeyValuePair<string, string>> Entrada;
		string reduccion = "";
		string reducido = "";
		int unStack = 0;
		// calcular lookahead
		// 
		// obtener lista de tokens
		// error: leer hasta ; y seguir
		// des stackear estados


		public void Parser(List<KeyValuePair<string, string>> _Aceptados)
		{

			StackDeConsumo.Push(0);
			Entrada = _Aceptados;
			StackDeEntrada.Push("$");
			for (int i = _Aceptados.Count - 1; i >= 0; i--)
			{
				StackDeEntrada.Push(_Aceptados[i].Key);
			}
			var actual = StackDeEntrada.Peek();
			CargarDiccionario();
			var resultado = Estado0(actual);

			var xdd = 0;
		}


		public bool Err()
		{
			//consumr hasta encontrar un ; o un } en la stack de entrada
			//consumir la de consumo hasta encontrar un ; o un { de reversa y quitar los n pasos
			//
			return false;
		}

		void CargarDiccionario()
		{
			Reducciones.Add(0, "Start↓Program");
			Reducciones.Add(1, "Program↓Decl Program");
			Reducciones.Add(2, "Program↓Decl");
			Reducciones.Add(3, "Decl↓Type ident ;");
			Reducciones.Add(4, "Decl↓FRoot ident ( Formals ) StmtBlock");
			Reducciones.Add(5, "Decl↓static CnsTp ident ;");
			Reducciones.Add(6, "Decl↓class ident Heritage HeritageI {​​​​ FieldP }​​​​");
			Reducciones.Add(7, "Decl↓interface ident {​​​​ Proto }​​​​");
			Reducciones.Add(8, "Type↓CnsTp");
			Reducciones.Add(9, "Type↓ident");
			Reducciones.Add(10, "Type↓Type []");
			Reducciones.Add(11, "FRoot↓void");
			Reducciones.Add(12, "FRoot↓Type");
			Reducciones.Add(13, "Formals↓Type ident , Formals");
			Reducciones.Add(14, "Formals↓Type ident");
			Reducciones.Add(15, "StmtBlock↓{​​​​ SBPV SBPC SBPS }​​​​");
			Reducciones.Add(16, "CnsTp↓int");
			Reducciones.Add(17, "CnsTp↓double");
			Reducciones.Add(18, "CnsTp↓boolean");
			Reducciones.Add(19, "CnsTp↓string");
			Reducciones.Add(20, "Heritage↓extends ident");
			Reducciones.Add(21, "Heritage↓''");
			Reducciones.Add(22, "HeritageI↓implements ident HeritageD");
			Reducciones.Add(23, "HeritageI↓''");
			Reducciones.Add(24, "HeritageD↓, ident HeritageD");
			Reducciones.Add(25, "HeritageD↓''");
			Reducciones.Add(26, "FieldP↓Field FieldP");
			Reducciones.Add(27, "FieldP↓''");
			Reducciones.Add(28, "Field↓Type ident ;");
			Reducciones.Add(29, "Field↓FRoot ident ( Formals ) StmtBlock");
			Reducciones.Add(30, "Field↓static CnsTp ident ;");
			Reducciones.Add(31, "Proto↓Prototype Proto");
			Reducciones.Add(32, "Proto↓''");
			Reducciones.Add(33, "Prototype↓FRoot ident ( Formals ) ;");
			Reducciones.Add(34, "SBPV↓Type ident ; SBPV");
			Reducciones.Add(35, "SBPV↓''");
			Reducciones.Add(36, "SBPC↓static CnsTp ident ; SBPC");
			Reducciones.Add(37, "SBPC↓''");
			Reducciones.Add(38, "SBPS↓Stmt SBPS");
			Reducciones.Add(39, "SBPS↓''");
			Reducciones.Add(40, "Stmt↓Expr ;");
			Reducciones.Add(41, "Stmt↓;");
			Reducciones.Add(42, "Stmt↓if ( Expr ) Stmt ElseStmt");
			Reducciones.Add(43, "Stmt↓while ( Expr ) Stmt");
			Reducciones.Add(44, "Stmt↓for ( Expr ; Expr ; Expr ) Stmt");
			Reducciones.Add(45, "Stmt↓break ;");
			Reducciones.Add(46, "Stmt↓return Expr ;");
			Reducciones.Add(47, "Stmt↓System . out . println ( Expr ExPrint ) ;");
			Reducciones.Add(48, "Stmt↓StmtBlock");
			Reducciones.Add(49, "ElseStmt↓else Stmt");
			Reducciones.Add(50, "ElseStmt↓''");
			Reducciones.Add(51, "ExPrint↓, Expr ExPrint");
			Reducciones.Add(52, "ExPrint↓''");
			Reducciones.Add(53, "Expr↓ident = ExprOr");
			Reducciones.Add(54, "Expr↓ExprOr");
			Reducciones.Add(55, "ExprOr↓ExprOr != ExprOrP");
			Reducciones.Add(56, "ExprOr↓ExprOrP");
			Reducciones.Add(57, "ExprOrP↓ExprOrP || ExprAnd");
			Reducciones.Add(58, "ExprOrP↓ExprAnd");
			Reducciones.Add(59, "ExprAnd↓ExprAnd > ExprAndP");
			Reducciones.Add(60, "ExprAnd↓ExprAnd >= ExprAndP");
			Reducciones.Add(61, "ExprAnd↓ExprAndP");
			Reducciones.Add(62, "ExprAndP↓ExprAndP - ExprEquals");
			Reducciones.Add(63, "ExprAndP↓ExprEquals");
			Reducciones.Add(64, "ExprEquals↓ExprEquals / ExprEqualsP");
			Reducciones.Add(65, "ExprEquals↓ExprEquals % ExprEqualsP");
			Reducciones.Add(66, "ExprEquals↓ExprEqualsP");
			Reducciones.Add(67, "ExprEqualsP↓- ExprComp");
			Reducciones.Add(68, "ExprEqualsP↓! ExprComp");
			Reducciones.Add(69, "ExprEqualsP↓ExprComp");
			Reducciones.Add(70, "ExprComp↓ExprComp . ident = ExprCompP");
			Reducciones.Add(71, "ExprComp↓ExprComp . ident");
			Reducciones.Add(72, "ExprComp↓ExprCompP");
			Reducciones.Add(73, "ExprCompP↓( Expr )");
			Reducciones.Add(74, "ExprCompP↓this");
			Reducciones.Add(75, "ExprCompP↓ident");
			Reducciones.Add(76, "ExprCompP↓New ( ident )");
			Reducciones.Add(77, "ExprCompP↓intConstant");
			Reducciones.Add(78, "ExprCompP↓doubleConstant");
			Reducciones.Add(79, "ExprCompP↓boolConstant");
			Reducciones.Add(80, "ExprCompP↓stringConstant");
			Reducciones.Add(81, "ExprCompP↓null.Add");
		}
		bool IrA(int numEstado, string _lookahead)
		{
			switch (numEstado)
			{
				
				default:
					return Err();
			}
		}
		bool Conflictos()
		{
			return false;
		}
		#region Estados
		
		#endregion

	}
}
