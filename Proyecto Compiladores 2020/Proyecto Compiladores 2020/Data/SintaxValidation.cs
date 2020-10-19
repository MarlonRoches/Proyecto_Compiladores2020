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
				case 0:
					//IrA Estado 0
					return Estado0(_lookahead);
				case 1:
					//IrA Estado 1
					return Estado1(_lookahead);
				case 2:
					//IrA Estado 2
					return Estado2(_lookahead);
				case 3:
					//IrA Estado 3
					return Estado3(_lookahead);
				case 4:
					//IrA Estado 4
					return Estado4(_lookahead);
				case 5:
					//IrA Estado 5
					return Estado5(_lookahead);
				case 6:
					//IrA Estado 6
					return Estado6(_lookahead);
				case 7:
					//IrA Estado 7
					return Estado7(_lookahead);
				case 8:
					//IrA Estado 8
					return Estado8(_lookahead);
				case 9:
					//IrA Estado 9
					return Estado9(_lookahead);
				case 10:
					//IrA Estado 10
					return Estado10(_lookahead);
				case 11:
					//IrA Estado 11
					return Estado11(_lookahead);
				case 12:
					//IrA Estado 12
					return Estado12(_lookahead);
				case 13:
					//IrA Estado 13
					return Estado13(_lookahead);
				case 14:
					//IrA Estado 14
					return Estado14(_lookahead);
				case 15:
					//IrA Estado 15
					return Estado15(_lookahead);
				case 16:
					//IrA Estado 16
					return Estado16(_lookahead);
				case 17:
					//IrA Estado 17
					return Estado17(_lookahead);
				case 18:
					//IrA Estado 18
					return Estado18(_lookahead);
				case 19:
					//IrA Estado 19
					return Estado19(_lookahead);
				case 20:
					//IrA Estado 20
					return Estado20(_lookahead);
				case 21:
					//IrA Estado 21
					return Estado21(_lookahead);
				case 22:
					//IrA Estado 22
					return Estado22(_lookahead);
				case 23:
					//IrA Estado 23
					return Estado23(_lookahead);
				case 24:
					//IrA Estado 24
					return Estado24(_lookahead);
				case 25:
					//IrA Estado 25
					return Estado25(_lookahead);
				case 26:
					//IrA Estado 26
					return Estado26(_lookahead);
				case 27:
					//IrA Estado 27
					return Estado27(_lookahead);
				case 28:
					//IrA Estado 28
					return Estado28(_lookahead);
				case 29:
					//IrA Estado 29
					return Estado29(_lookahead);
				case 30:
					//IrA Estado 30
					return Estado30(_lookahead);
				case 31:
					//IrA Estado 31
					return Estado31(_lookahead);
				case 32:
					//IrA Estado 32
					return Estado32(_lookahead);
				case 33:
					//IrA Estado 33
					return Estado33(_lookahead);
				case 34:
					//IrA Estado 34
					return Estado34(_lookahead);
				case 35:
					//IrA Estado 35
					return Estado35(_lookahead);
				case 36:
					//IrA Estado 36
					return Estado36(_lookahead);
				case 37:
					//IrA Estado 37
					return Estado37(_lookahead);
				case 38:
					//IrA Estado 38
					return Estado38(_lookahead);
				case 39:
					//IrA Estado 39
					return Estado39(_lookahead);
				case 40:
					//IrA Estado 40
					return Estado40(_lookahead);
				case 41:
					//IrA Estado 41
					return Estado41(_lookahead);
				case 42:
					//IrA Estado 42
					return Estado42(_lookahead);
				case 43:
					//IrA Estado 43
					return Estado43(_lookahead);
				case 44:
					//IrA Estado 44
					return Estado44(_lookahead);
				case 45:
					//IrA Estado 45
					return Estado45(_lookahead);
				case 46:
					//IrA Estado 46
					return Estado46(_lookahead);
				case 47:
					//IrA Estado 47
					return Estado47(_lookahead);
				case 48:
					//IrA Estado 48
					return Estado48(_lookahead);
				case 49:
					//IrA Estado 49
					return Estado49(_lookahead);
				case 50:
					//IrA Estado 50
					return Estado50(_lookahead);
				case 51:
					//IrA Estado 51
					return Estado51(_lookahead);
				case 52:
					//IrA Estado 52
					return Estado52(_lookahead);
				case 53:
					//IrA Estado 53
					return Estado53(_lookahead);
				case 54:
					//IrA Estado 54
					return Estado54(_lookahead);
				case 55:
					//IrA Estado 55
					return Estado55(_lookahead);
				case 56:
					//IrA Estado 56
					return Estado56(_lookahead);
				case 57:
					//IrA Estado 57
					return Estado57(_lookahead);
				case 58:
					//IrA Estado 58
					return Estado58(_lookahead);
				case 59:
					//IrA Estado 59
					return Estado59(_lookahead);
				case 60:
					//IrA Estado 60
					return Estado60(_lookahead);
				case 61:
					//IrA Estado 61
					return Estado61(_lookahead);
				case 62:
					//IrA Estado 62
					return Estado62(_lookahead);
				case 63:
					//IrA Estado 63
					return Estado63(_lookahead);
				case 64:
					//IrA Estado 64
					return Estado64(_lookahead);
				case 65:
					//IrA Estado 65
					return Estado65(_lookahead);
				case 66:
					//IrA Estado 66
					return Estado66(_lookahead);
				case 67:
					//IrA Estado 67
					return Estado67(_lookahead);
				case 68:
					//IrA Estado 68
					return Estado68(_lookahead);
				case 69:
					//IrA Estado 69
					return Estado69(_lookahead);
				case 70:
					//IrA Estado 70
					return Estado70(_lookahead);
				case 71:
					//IrA Estado 71
					return Estado71(_lookahead);
				case 72:
					//IrA Estado 72
					return Estado72(_lookahead);
				case 73:
					//IrA Estado 73
					return Estado73(_lookahead);
				case 74:
					//IrA Estado 74
					return Estado74(_lookahead);
				case 75:
					//IrA Estado 75
					return Estado75(_lookahead);
				case 76:
					//IrA Estado 76
					return Estado76(_lookahead);
				case 77:
					//IrA Estado 77
					return Estado77(_lookahead);
				case 78:
					//IrA Estado 78
					return Estado78(_lookahead);
				case 79:
					//IrA Estado 79
					return Estado79(_lookahead);
				case 80:
					//IrA Estado 80
					return Estado80(_lookahead);
				case 81:
					//IrA Estado 81
					return Estado81(_lookahead);
				case 82:
					//IrA Estado 82
					return Estado82(_lookahead);
				case 83:
					//IrA Estado 83
					return Estado83(_lookahead);
				case 84:
					//IrA Estado 84
					return Estado84(_lookahead);
				case 85:
					//IrA Estado 85
					return Estado85(_lookahead);
				case 86:
					//IrA Estado 86
					return Estado86(_lookahead);
				case 87:
					//IrA Estado 87
					return Estado87(_lookahead);
				case 88:
					//IrA Estado 88
					return Estado88(_lookahead);
				case 89:
					//IrA Estado 89
					return Estado89(_lookahead);
				case 90:
					//IrA Estado 90
					return Estado90(_lookahead);
				case 91:
					//IrA Estado 91
					return Estado91(_lookahead);
				case 92:
					//IrA Estado 92
					return Estado92(_lookahead);
				case 93:
					//IrA Estado 93
					return Estado93(_lookahead);
				case 94:
					//IrA Estado 94
					return Estado94(_lookahead);
				case 95:
					//IrA Estado 95
					return Estado95(_lookahead);
				case 96:
					//IrA Estado 96
					return Estado96(_lookahead);
				case 97:
					//IrA Estado 97
					return Estado97(_lookahead);
				case 98:
					//IrA Estado 98
					return Estado98(_lookahead);
				case 99:
					//IrA Estado 99
					return Estado99(_lookahead);
				case 100:
					//IrA Estado 100
					return Estado100(_lookahead);
				case 101:
					//IrA Estado 101
					return Estado101(_lookahead);
				case 102:
					//IrA Estado 102
					return Estado102(_lookahead);
				case 103:
					//IrA Estado 103
					return Estado103(_lookahead);
				case 104:
					//IrA Estado 104
					return Estado104(_lookahead);
				case 105:
					//IrA Estado 105
					return Estado105(_lookahead);
				case 106:
					//IrA Estado 106
					return Estado106(_lookahead);
				case 107:
					//IrA Estado 107
					return Estado107(_lookahead);
				case 108:
					//IrA Estado 108
					return Estado108(_lookahead);
				case 109:
					//IrA Estado 109
					return Estado109(_lookahead);
				case 110:
					//IrA Estado 110
					return Estado110(_lookahead);
				case 111:
					//IrA Estado 111
					return Estado111(_lookahead);
				case 112:
					//IrA Estado 112
					return Estado112(_lookahead);
				case 113:
					//IrA Estado 113
					return Estado113(_lookahead);
				case 114:
					//IrA Estado 114
					return Estado114(_lookahead);
				case 115:
					//IrA Estado 115
					return Estado115(_lookahead);
				case 116:
					//IrA Estado 116
					return Estado116(_lookahead);
				case 117:
					//IrA Estado 117
					return Estado117(_lookahead);
				case 118:
					//IrA Estado 118
					return Estado118(_lookahead);
				case 119:
					//IrA Estado 119
					return Estado119(_lookahead);
				case 120:
					//IrA Estado 120
					return Estado120(_lookahead);
				case 121:
					//IrA Estado 121
					return Estado121(_lookahead);
				case 122:
					//IrA Estado 122
					return Estado122(_lookahead);
				case 123:
					//IrA Estado 123
					return Estado123(_lookahead);
				case 124:
					//IrA Estado 124
					return Estado124(_lookahead);
				case 125:
					//IrA Estado 125
					return Estado125(_lookahead);
				case 126:
					//IrA Estado 126
					return Estado126(_lookahead);
				case 127:
					//IrA Estado 127
					return Estado127(_lookahead);
				case 128:
					//IrA Estado 128
					return Estado128(_lookahead);
				case 129:
					//IrA Estado 129
					return Estado129(_lookahead);
				case 130:
					//IrA Estado 130
					return Estado130(_lookahead);
				case 131:
					//IrA Estado 131
					return Estado131(_lookahead);
				case 132:
					//IrA Estado 132
					return Estado132(_lookahead);
				case 133:
					//IrA Estado 133
					return Estado133(_lookahead);
				case 134:
					//IrA Estado 134
					return Estado134(_lookahead);
				case 135:
					//IrA Estado 135
					return Estado135(_lookahead);
				case 136:
					//IrA Estado 136
					return Estado136(_lookahead);
				case 137:
					//IrA Estado 137
					return Estado137(_lookahead);
				case 138:
					//IrA Estado 138
					return Estado138(_lookahead);
				case 139:
					//IrA Estado 139
					return Estado139(_lookahead);
				case 140:
					//IrA Estado 140
					return Estado140(_lookahead);
				case 141:
					//IrA Estado 141
					return Estado141(_lookahead);
				case 142:
					//IrA Estado 142
					return Estado142(_lookahead);
				case 143:
					//IrA Estado 143
					return Estado143(_lookahead);
				case 144:
					//IrA Estado 144
					return Estado144(_lookahead);
				case 145:
					//IrA Estado 145
					return Estado145(_lookahead);
				case 146:
					//IrA Estado 146
					return Estado146(_lookahead);
				case 147:
					//IrA Estado 147
					return Estado147(_lookahead);
				case 148:
					//IrA Estado 148
					return Estado148(_lookahead);
				case 149:
					//IrA Estado 149
					return Estado149(_lookahead);
				case 150:
					//IrA Estado 150
					return Estado150(_lookahead);
				case 151:
					//IrA Estado 151
					return Estado151(_lookahead);
				case 152:
					//IrA Estado 152
					return Estado152(_lookahead);
				case 153:
					//IrA Estado 153
					return Estado153(_lookahead);
				case 154:
					//IrA Estado 154
					return Estado154(_lookahead);
				case 155:
					//IrA Estado 155
					return Estado155(_lookahead);
				case 156:
					//IrA Estado 156
					return Estado156(_lookahead);
				case 157:
					//IrA Estado 157
					return Estado157(_lookahead);
				case 158:
					//IrA Estado 158
					return Estado158(_lookahead);
				case 159:
					//IrA Estado 159
					return Estado159(_lookahead);
				case 160:
					//IrA Estado 160
					return Estado160(_lookahead);
				case 161:
					//IrA Estado 161
					return Estado161(_lookahead);
				case 162:
					//IrA Estado 162
					return Estado162(_lookahead);
				case 163:
					//IrA Estado 163
					return Estado163(_lookahead);
				case 164:
					//IrA Estado 164
					return Estado164(_lookahead);
				case 165:
					//IrA Estado 165
					return Estado165(_lookahead);
				case 166:
					//IrA Estado 166
					return Estado166(_lookahead);
				case 167:
					//IrA Estado 167
					return Estado167(_lookahead);
				case 168:
					//IrA Estado 168
					return Estado168(_lookahead);
				case 169:
					//IrA Estado 169
					return Estado169(_lookahead);
				case 170:
					//IrA Estado 170
					return Estado170(_lookahead);
				case 171:
					//IrA Estado 171
					return Estado171(_lookahead);
				case 172:
					//IrA Estado 172
					return Estado172(_lookahead);
				case 173:
					//IrA Estado 173
					return Estado173(_lookahead);
				case 174:
					//IrA Estado 174
					return Estado174(_lookahead);
				case 175:
					//IrA Estado 175
					return Estado175(_lookahead);
				case 176:
					//IrA Estado 176
					return Estado176(_lookahead);
				case 177:
					//IrA Estado 177
					return Estado177(_lookahead);
				case 178:
					//IrA Estado 178
					return Estado178(_lookahead);
				case 179:
					//IrA Estado 179
					return Estado179(_lookahead);


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
