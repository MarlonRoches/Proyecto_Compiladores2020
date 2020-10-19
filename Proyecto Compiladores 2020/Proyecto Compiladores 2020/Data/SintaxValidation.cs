using System;
using System.Collections.Generic;
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
		// calcular lookahead
		// 
		// obtener lista de tokens
		// error: leer hasta ; y seguir
		// des stackear estados


		public void Parser(List<KeyValuePair<string, string>> _Aceptados)
		{

			StackDeConsumo.Push(0);
			Entrada = _Aceptados;
			for (int i = _Aceptados.Count - 1; i >= 0; i--)
			{
				StackDeEntrada.Push(_Aceptados[i].Key);
			}
			var actual = StackDeEntrada.Peek();
			var resultado = Estado0(actual);
		}

		
		public bool Err()
		{
			//consumr hasta encontrar un ; o un }
			//consumir la de consumo hasta encontrar un ; o un {
			//
			return false;
		}

		void CargarDiccionario()
		{
			
		}
		void IrA(int numEstado, string _lookahead) 
		{
			switch (numEstado)
			{
				case 0:
					//IrA Estado 0
					Estado0(_lookahead);
					break;
				case 1:
					//IrA Estado 1
					Estado1(_lookahead);
					break;
				case 2:
					//IrA Estado 2
					Estado2(_lookahead);
					break;
				case 3:
					//IrA Estado 3
					Estado3(_lookahead);
					break;
				case 4:
					//IrA Estado 4
					Estado4(_lookahead);
					break;
				case 5:
					//IrA Estado 5
					Estado5(_lookahead);
					break;
				case 6:
					//IrA Estado 6
					Estado6(_lookahead);
					break;
				case 7:
					//IrA Estado 7
					Estado7(_lookahead);
					break;
				case 8:
					//IrA Estado 8
					Estado8(_lookahead);
					break;
				case 9:
					//IrA Estado 9
					Estado9(_lookahead);
					break;
				case 10:
					//IrA Estado 10
					Estado10(_lookahead);
					break;
				case 11:
					//IrA Estado 11
					Estado11(_lookahead);
					break;
				case 12:
					//IrA Estado 12
					Estado12(_lookahead);
					break;
				case 13:
					//IrA Estado 13
					Estado13(_lookahead);
					break;
				case 14:
					//IrA Estado 14
					Estado14(_lookahead);
					break;
				case 15:
					//IrA Estado 15
					Estado15(_lookahead);
					break;
				case 16:
					//IrA Estado 16
					Estado16(_lookahead);
					break;
				case 17:
					//IrA Estado 17
					Estado17(_lookahead);
					break;
				case 18:
					//IrA Estado 18
					Estado18(_lookahead);
					break;
				case 19:
					//IrA Estado 19
					Estado19(_lookahead);
					break;
				case 20:
					//IrA Estado 20
					Estado20(_lookahead);
					break;
				case 21:
					//IrA Estado 21
					Estado21(_lookahead);
					break;
				case 22:
					//IrA Estado 22
					Estado22(_lookahead);
					break;
				case 23:
					//IrA Estado 23
					Estado23(_lookahead);
					break;
				case 24:
					//IrA Estado 24
					Estado24(_lookahead);
					break;
				case 25:
					//IrA Estado 25
					Estado25(_lookahead);
					break;
				case 26:
					//IrA Estado 26
					Estado26(_lookahead);
					break;
				case 27:
					//IrA Estado 27
					Estado27(_lookahead);
					break;
				case 28:
					//IrA Estado 28
					Estado28(_lookahead);
					break;
				case 29:
					//IrA Estado 29
					Estado29(_lookahead);
					break;
				case 30:
					//IrA Estado 30
					Estado30(_lookahead);
					break;
				case 31:
					//IrA Estado 31
					Estado31(_lookahead);
					break;
				case 32:
					//IrA Estado 32
					Estado32(_lookahead);
					break;
				case 33:
					//IrA Estado 33
					Estado33(_lookahead);
					break;
				case 34:
					//IrA Estado 34
					Estado34(_lookahead);
					break;
				case 35:
					//IrA Estado 35
					Estado35(_lookahead);
					break;
				case 36:
					//IrA Estado 36
					Estado36(_lookahead);
					break;
				case 37:
					//IrA Estado 37
					Estado37(_lookahead);
					break;
				case 38:
					//IrA Estado 38
					Estado38(_lookahead);
					break;
				case 39:
					//IrA Estado 39
					Estado39(_lookahead);
					break;
				case 40:
					//IrA Estado 40
					Estado40(_lookahead);
					break;
				case 41:
					//IrA Estado 41
					Estado41(_lookahead);
					break;
				case 42:
					//IrA Estado 42
					Estado42(_lookahead);
					break;
				case 43:
					//IrA Estado 43
					Estado43(_lookahead);
					break;
				case 44:
					//IrA Estado 44
					Estado44(_lookahead);
					break;
				case 45:
					//IrA Estado 45
					Estado45(_lookahead);
					break;
				case 46:
					//IrA Estado 46
					Estado46(_lookahead);
					break;
				case 47:
					//IrA Estado 47
					Estado47(_lookahead);
					break;
				case 48:
					//IrA Estado 48
					Estado48(_lookahead);
					break;
				case 49:
					//IrA Estado 49
					Estado49(_lookahead);
					break;
				case 50:
					//IrA Estado 50
					Estado50(_lookahead);
					break;
				case 51:
					//IrA Estado 51
					Estado51(_lookahead);
					break;
				case 52:
					//IrA Estado 52
					Estado52(_lookahead);
					break;
				case 53:
					//IrA Estado 53
					Estado53(_lookahead);
					break;
				case 54:
					//IrA Estado 54
					Estado54(_lookahead);
					break;
				case 55:
					//IrA Estado 55
					Estado55(_lookahead);
					break;
				case 56:
					//IrA Estado 56
					Estado56(_lookahead);
					break;
				case 57:
					//IrA Estado 57
					Estado57(_lookahead);
					break;
				case 58:
					//IrA Estado 58
					Estado58(_lookahead);
					break;
				case 59:
					//IrA Estado 59
					Estado59(_lookahead);
					break;
				case 60:
					//IrA Estado 60
					Estado60(_lookahead);
					break;
				case 61:
					//IrA Estado 61
					Estado61(_lookahead);
					break;
				case 62:
					//IrA Estado 62
					Estado62(_lookahead);
					break;
				case 63:
					//IrA Estado 63
					Estado63(_lookahead);
					break;
				case 64:
					//IrA Estado 64
					Estado64(_lookahead);
					break;
				case 65:
					//IrA Estado 65
					Estado65(_lookahead);
					break;
				case 66:
					//IrA Estado 66
					Estado66(_lookahead);
					break;
				case 67:
					//IrA Estado 67
					Estado67(_lookahead);
					break;
				case 68:
					//IrA Estado 68
					Estado68(_lookahead);
					break;
				case 69:
					//IrA Estado 69
					Estado69(_lookahead);
					break;
				case 70:
					//IrA Estado 70
					Estado70(_lookahead);
					break;
				case 71:
					//IrA Estado 71
					Estado71(_lookahead);
					break;
				case 72:
					//IrA Estado 72
					Estado72(_lookahead);
					break;
				case 73:
					//IrA Estado 73
					Estado73(_lookahead);
					break;
				case 74:
					//IrA Estado 74
					Estado74(_lookahead);
					break;
				case 75:
					//IrA Estado 75
					Estado75(_lookahead);
					break;
				case 76:
					//IrA Estado 76
					Estado76(_lookahead);
					break;
				case 77:
					//IrA Estado 77
					Estado77(_lookahead);
					break;
				case 78:
					//IrA Estado 78
					Estado78(_lookahead);
					break;
				case 79:
					//IrA Estado 79
					Estado79(_lookahead);
					break;
				case 80:
					//IrA Estado 80
					Estado80(_lookahead);
					break;
				case 81:
					//IrA Estado 81
					Estado81(_lookahead);
					break;
				case 82:
					//IrA Estado 82
					Estado82(_lookahead);
					break;
				case 83:
					//IrA Estado 83
					Estado83(_lookahead);
					break;
				case 84:
					//IrA Estado 84
					Estado84(_lookahead);
					break;
				case 85:
					//IrA Estado 85
					Estado85(_lookahead);
					break;
				case 86:
					//IrA Estado 86
					Estado86(_lookahead);
					break;
				case 87:
					//IrA Estado 87
					Estado87(_lookahead);
					break;
				case 88:
					//IrA Estado 88
					Estado88(_lookahead);
					break;
				case 89:
					//IrA Estado 89
					Estado89(_lookahead);
					break;
				case 90:
					//IrA Estado 90
					Estado90(_lookahead);
					break;
				case 91:
					//IrA Estado 91
					Estado91(_lookahead);
					break;
				case 92:
					//IrA Estado 92
					Estado92(_lookahead);
					break;
				case 93:
					//IrA Estado 93
					Estado93(_lookahead);
					break;
				case 94:
					//IrA Estado 94
					Estado94(_lookahead);
					break;
				case 95:
					//IrA Estado 95
					Estado95(_lookahead);
					break;
				case 96:
					//IrA Estado 96
					Estado96(_lookahead);
					break;
				case 97:
					//IrA Estado 97
					Estado97(_lookahead);
					break;
				case 98:
					//IrA Estado 98
					Estado98(_lookahead);
					break;
				case 99:
					//IrA Estado 99
					Estado99(_lookahead);
					break;
				case 100:
					//IrA Estado 100
					Estado100(_lookahead);
					break;
				case 101:
					//IrA Estado 101
					Estado101(_lookahead);
					break;
				case 102:
					//IrA Estado 102
					Estado102(_lookahead);
					break;
				case 103:
					//IrA Estado 103
					Estado103(_lookahead);
					break;
				case 104:
					//IrA Estado 104
					Estado104(_lookahead);
					break;
				case 105:
					//IrA Estado 105
					Estado105(_lookahead);
					break;
				case 106:
					//IrA Estado 106
					Estado106(_lookahead);
					break;
				case 107:
					//IrA Estado 107
					Estado107(_lookahead);
					break;
				case 108:
					//IrA Estado 108
					Estado108(_lookahead);
					break;
				case 109:
					//IrA Estado 109
					Estado109(_lookahead);
					break;
				case 110:
					//IrA Estado 110
					Estado110(_lookahead);
					break;
				case 111:
					//IrA Estado 111
					Estado111(_lookahead);
					break;
				case 112:
					//IrA Estado 112
					Estado112(_lookahead);
					break;
				case 113:
					//IrA Estado 113
					Estado113(_lookahead);
					break;
				case 114:
					//IrA Estado 114
					Estado114(_lookahead);
					break;
				case 115:
					//IrA Estado 115
					Estado115(_lookahead);
					break;
				case 116:
					//IrA Estado 116
					Estado116(_lookahead);
					break;
				case 117:
					//IrA Estado 117
					Estado117(_lookahead);
					break;
				case 118:
					//IrA Estado 118
					Estado118(_lookahead);
					break;
				case 119:
					//IrA Estado 119
					Estado119(_lookahead);
					break;
				case 120:
					//IrA Estado 120
					Estado120(_lookahead);
					break;
				case 121:
					//IrA Estado 121
					Estado121(_lookahead);
					break;
				case 122:
					//IrA Estado 122
					Estado122(_lookahead);
					break;
				case 123:
					//IrA Estado 123
					Estado123(_lookahead);
					break;
				case 124:
					//IrA Estado 124
					Estado124(_lookahead);
					break;
				case 125:
					//IrA Estado 125
					Estado125(_lookahead);
					break;
				case 126:
					//IrA Estado 126
					Estado126(_lookahead);
					break;
				case 127:
					//IrA Estado 127
					Estado127(_lookahead);
					break;
				case 128:
					//IrA Estado 128
					Estado128(_lookahead);
					break;
				case 129:
					//IrA Estado 129
					Estado129(_lookahead);
					break;
				case 130:
					//IrA Estado 130
					Estado130(_lookahead);
					break;
				case 131:
					//IrA Estado 131
					Estado131(_lookahead);
					break;
				case 132:
					//IrA Estado 132
					Estado132(_lookahead);
					break;
				case 133:
					//IrA Estado 133
					Estado133(_lookahead);
					break;
				case 134:
					//IrA Estado 134
					Estado134(_lookahead);
					break;
				case 135:
					//IrA Estado 135
					Estado135(_lookahead);
					break;
				case 136:
					//IrA Estado 136
					Estado136(_lookahead);
					break;
				case 137:
					//IrA Estado 137
					Estado137(_lookahead);
					break;
				case 138:
					//IrA Estado 138
					Estado138(_lookahead);
					break;
				case 139:
					//IrA Estado 139
					Estado139(_lookahead);
					break;
				case 140:
					//IrA Estado 140
					Estado140(_lookahead);
					break;
				case 141:
					//IrA Estado 141
					Estado141(_lookahead);
					break;
				case 142:
					//IrA Estado 142
					Estado142(_lookahead);
					break;
				case 143:
					//IrA Estado 143
					Estado143(_lookahead);
					break;
				case 144:
					//IrA Estado 144
					Estado144(_lookahead);
					break;
				case 145:
					//IrA Estado 145
					Estado145(_lookahead);
					break;
				case 146:
					//IrA Estado 146
					Estado146(_lookahead);
					break;
				case 147:
					//IrA Estado 147
					Estado147(_lookahead);
					break;
				case 148:
					//IrA Estado 148
					Estado148(_lookahead);
					break;
				case 149:
					//IrA Estado 149
					Estado149(_lookahead);
					break;
				case 150:
					//IrA Estado 150
					Estado150(_lookahead);
					break;
				case 151:
					//IrA Estado 151
					Estado151(_lookahead);
					break;
				case 152:
					//IrA Estado 152
					Estado152(_lookahead);
					break;
				case 153:
					//IrA Estado 153
					Estado153(_lookahead);
					break;
				case 154:
					//IrA Estado 154
					Estado154(_lookahead);
					break;
				case 155:
					//IrA Estado 155
					Estado155(_lookahead);
					break;
				case 156:
					//IrA Estado 156
					Estado156(_lookahead);
					break;
				case 157:
					//IrA Estado 157
					Estado157(_lookahead);
					break;
				case 158:
					//IrA Estado 158
					Estado158(_lookahead);
					break;
				case 159:
					//IrA Estado 159
					Estado159(_lookahead);
					break;
				case 160:
					//IrA Estado 160
					Estado160(_lookahead);
					break;
				case 161:
					//IrA Estado 161
					Estado161(_lookahead);
					break;
				case 162:
					//IrA Estado 162
					Estado162(_lookahead);
					break;
				case 163:
					//IrA Estado 163
					Estado163(_lookahead);
					break;
				case 164:
					//IrA Estado 164
					Estado164(_lookahead);
					break;
				case 165:
					//IrA Estado 165
					Estado165(_lookahead);
					break;
				case 166:
					//IrA Estado 166
					Estado166(_lookahead);
					break;
				case 167:
					//IrA Estado 167
					Estado167(_lookahead);
					break;
				case 168:
					//IrA Estado 168
					Estado168(_lookahead);
					break;
				case 169:
					//IrA Estado 169
					Estado169(_lookahead);
					break;
				case 170:
					//IrA Estado 170
					Estado170(_lookahead);
					break;
				case 171:
					//IrA Estado 171
					Estado171(_lookahead);
					break;
				case 172:
					//IrA Estado 172
					Estado172(_lookahead);
					break;
				case 173:
					//IrA Estado 173
					Estado173(_lookahead);
					break;
				case 174:
					//IrA Estado 174
					Estado174(_lookahead);
					break;
				case 175:
					//IrA Estado 175
					Estado175(_lookahead);
					break;
				case 176:
					//IrA Estado 176
					Estado176(_lookahead);
					break;

				default:
					Err();
					break;
			}
		}

		#region Estados
		public bool Estado0(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "const":
					//desplazamiento a d5
					//consume const
					StackDeEntrada.Pop();
					StackDeConsumo.Push(5);
					return Estado5(StackDeEntrada.Peek());
				case "class":
					//desplazamiento a d6
					//consume class
					StackDeEntrada.Pop();
					StackDeConsumo.Push(6);
					return Estado6(StackDeEntrada.Peek());
				case "interface":
					//desplazamiento a d7
					//consume interface
					StackDeEntrada.Pop();
					StackDeConsumo.Push(7);
					return Estado7(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					Simbolos += $"{_lookahead} ";
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Program":
					//irA 1
					return Estado1(StackDeEntrada.Peek());
				case "Decl":
					//irA 2
					return Estado2(StackDeEntrada.Peek());
				case "Type":
					//irA 3
					return Estado3(StackDeEntrada.Peek());
				case "FRoot":
					//irA 4
					return Estado4(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado1(string _lookahead)
		{
			switch (_lookahead)
			{
				case "$":
					//irA acc
					return true;
				default:
					Err(); return false;
			}
		}
		public bool Estado2(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "const":
					//desplazamiento a d5
					//consume const
					StackDeEntrada.Pop();
					StackDeConsumo.Push(5);
					return Estado5(StackDeEntrada.Peek());
				case "class":
					//desplazamiento a d6
					//consume class
					StackDeEntrada.Pop();
					StackDeConsumo.Push(6);
					return Estado6(StackDeEntrada.Peek());
				case "interface":
					//desplazamiento a d7
					//consume interface
					StackDeEntrada.Pop();
					StackDeConsumo.Push(7);
					return Estado7(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "$":
					//reduccion a r2
					return Estado2(StackDeEntrada.Peek());
				case "Program":
					//irA 15
					return Estado15(StackDeEntrada.Peek());
				case "Decl":
					//irA 2
					return Estado2(StackDeEntrada.Peek());
				case "Type":
					//irA 3
					return Estado3(StackDeEntrada.Peek());
				case "FRoot":
					//irA 4
					return Estado4(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado3(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
				//conflicto a d16 / r12
				//consume ident
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado4(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d18
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(18);
					return Estado18(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado5(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 19
					return Estado19(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado6(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d20
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(20);
					return Estado20(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado7(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d21
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(21);
					return Estado21(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado8(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r8
					return Estado8(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado9(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r9
					return Estado9(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r9
					return Estado9(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado10(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r11
					Simbolos=Simbolos.Replace("void","FRoot");
					//quito el 10 de mi pila
					StackDeConsumo.Pop();
					//IRA
					var PicoDePila = StackDeConsumo.Peek().ToString();
					var nombre = $"Estado{StackDeConsumo.Peek().ToString()}";
					var mi = this.GetType().GetMethod($"Estado{StackDeConsumo.Peek().ToString()}" );
					var resultado = mi.Invoke(this, null);
					return Estado11(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado11(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r16
					return Estado16(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r16
					return Estado16(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado12(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r17
					return Estado17(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r17
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado13(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r18
					return Estado18(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r18
					return Estado18(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado14(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r19
					return Estado19(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r19
					return Estado19(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado15(string _lookahead)
		{
			switch (_lookahead)
			{
				case "$":
					//reduccion a r1
					return Estado1(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado16(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d22
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(22);
					return Estado22(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado17(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r10
					return Estado10(StackDeEntrada.Peek());
				case "[]":
					//reduccion a r10
					return Estado10(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado18(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d23
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(23);
					return Estado23(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado19(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d24
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(24);
					return Estado24(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado20(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r21
					return Estado21(StackDeEntrada.Peek());
				case ":":
					//desplazamiento a d26
					//consume :
					StackDeEntrada.Pop();
					StackDeConsumo.Push(26);
					return Estado26(StackDeEntrada.Peek());
				case "Heritage":
					//irA 25
					return Estado25(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado21(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d27
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(27);
					return Estado27(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado22(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "const":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "class":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "void":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "int":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "double":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "string":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				case "$":
					//reduccion a r3
					return Estado3(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado23(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 28
					return Estado28(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado24(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d30
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(30);
					return Estado30(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado25(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d31
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(31);
					return Estado31(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado26(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d32
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(32);
					return Estado32(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado27(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "}":
					//reduccion a r30
					return Estado30(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 36
					return Estado36(StackDeEntrada.Peek());
				case "FRoot":
					//irA 35
					return Estado35(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "Proto":
					//irA 33
					return Estado33(StackDeEntrada.Peek());
				case "Prototype":
					//irA 34
					return Estado34(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado28(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d37
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(37);
					return Estado37(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado29(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d38
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(38);
					return Estado38(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado30(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "const":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "class":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "void":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "int":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "double":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "string":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				case "$":
					//reduccion a r5
					return Estado5(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado31(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "const":
					//desplazamiento a d43
					//consume const
					StackDeEntrada.Pop();
					StackDeConsumo.Push(43);
					return Estado43(StackDeEntrada.Peek());
				case "}":
					//reduccion a r25
					return Estado25(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 41
					return Estado41(StackDeEntrada.Peek());
				case "FRoot":
					//irA 42
					return Estado42(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "FieldP":
					//irA 39
					return Estado39(StackDeEntrada.Peek());
				case "Field":
					//irA 40
					return Estado40(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado32(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r23
					return Estado23(StackDeEntrada.Peek());
				case ",":
					//desplazamiento a d45
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(45);
					return Estado45(StackDeEntrada.Peek());
				case "HeritageP":
					//irA 44
					return Estado44(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado33(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d46
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(46);
					return Estado46(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado34(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "}":
					//reduccion a r30
					return Estado30(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 36
					return Estado36(StackDeEntrada.Peek());
				case "FRoot":
					//irA 35
					return Estado35(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "Proto":
					//irA 47
					return Estado47(StackDeEntrada.Peek());
				case "Prototype":
					//irA 34
					return Estado34(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado35(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d48
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(48);
					return Estado48(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado36(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r12
					return Estado12(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado37(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 49
					return Estado49(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado38(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r14
					return Estado14(StackDeEntrada.Peek());
				case ",":
					//desplazamiento a d51
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(51);
					return Estado51(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado39(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d52
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(52);
					return Estado52(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado40(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "const":
					//desplazamiento a d43
					//consume const
					StackDeEntrada.Pop();
					StackDeConsumo.Push(43);
					return Estado43(StackDeEntrada.Peek());
				case "}":
					//reduccion a r25
					return Estado25(StackDeEntrada.Peek());
				case "void":
					//desplazamiento a d10
					//consume void
					StackDeEntrada.Pop();
					StackDeConsumo.Push(10);
					return Estado10(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 41
					return Estado41(StackDeEntrada.Peek());
				case "FRoot":
					//irA 42
					return Estado42(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "FieldP":
					//irA 53
					return Estado53(StackDeEntrada.Peek());
				case "Field":
					//irA 40
					return Estado40(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado41(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
				//conflicto a d54 / r12
				//consume ident
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado42(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d55
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(55);
					return Estado55(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado43(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 56
					return Estado56(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado44(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r20
					return Estado20(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado45(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d57
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(57);
					return Estado57(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado46(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "const":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "class":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "void":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "int":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "double":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "string":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				case "$":
					//reduccion a r7
					return Estado7(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado47(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r29
					return Estado29(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado48(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d58
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(58);
					return Estado58(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado49(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "const":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "class":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "void":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "int":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "double":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "string":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				case "$":
					//reduccion a r4
					return Estado4(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado50(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
				//conflicto a d9 / r33
				//consume ident
				case ";":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "(":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "const":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "class":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "{":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "}":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "void":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "int":
				//conflicto a d11 / r33
				//consume int
				case "double":
				//conflicto a d12 / r33
				//consume double
				case "bool":
				//conflicto a d13 / r33
				//consume bool
				case "string":
				//conflicto a d14 / r33
				//consume string
				case "if":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "while":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "for":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "break":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "return":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "System":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "else":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "-":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "!":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "this":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "New":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "null":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "$":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "Type":
					//irA 60
					return Estado60(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "SBPV":
					//irA 59
					return Estado59(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado51(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 61
					return Estado61(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado52(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "const":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "class":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "void":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "int":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "double":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "string":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				case "$":
					//reduccion a r6
					return Estado6(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado53(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r24
					return Estado24(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado54(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d62
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(62);
					return Estado62(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado55(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d63
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(63);
					return Estado63(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado56(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d64
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(64);
					return Estado64(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado57(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r23
					return Estado23(StackDeEntrada.Peek());
				case ",":
					//desplazamiento a d45
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(45);
					return Estado45(StackDeEntrada.Peek());
				case "HeritageP":
					//irA 65
					return Estado65(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado58(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 66
					return Estado66(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado59(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case ";":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "(":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "const":
				//conflicto a d68 / r35
				//consume const
				case "class":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "{":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "}":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "void":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "int":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "double":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "string":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "if":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "while":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "for":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "break":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "return":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "System":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "else":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "-":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "!":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "this":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "New":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "null":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "$":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "SBPC":
					//irA 67
					return Estado67(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado60(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d69
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(69);
					return Estado69(StackDeEntrada.Peek());
				case "[]":
					//desplazamiento a d17
					//consume []
					StackDeEntrada.Pop();
					StackDeConsumo.Push(17);
					return Estado17(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado61(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r13
					return Estado13(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado62(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "const":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "}":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "void":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "int":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "double":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				case "string":
					//reduccion a r26
					return Estado26(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado63(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d9
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(9);
					return Estado9(StackDeEntrada.Peek());
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "Type":
					//irA 29
					return Estado29(StackDeEntrada.Peek());
				case "Formals":
					//irA 70
					return Estado70(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado64(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d71
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(71);
					return Estado71(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado65(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//reduccion a r22
					return Estado22(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado66(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d72
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(72);
					return Estado72(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado67(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "}":
					//reduccion a r37
					return Estado37(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "SBPS":
					//irA 73
					return Estado73(StackDeEntrada.Peek());
				case "Stmt":
					//irA 74
					return Estado74(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado68(string _lookahead)
		{
			switch (_lookahead)
			{
				case "int":
					//desplazamiento a d11
					//consume int
					StackDeEntrada.Pop();
					StackDeConsumo.Push(11);
					return Estado11(StackDeEntrada.Peek());
				case "double":
					//desplazamiento a d12
					//consume double
					StackDeEntrada.Pop();
					StackDeConsumo.Push(12);
					return Estado12(StackDeEntrada.Peek());
				case "bool":
					//desplazamiento a d13
					//consume bool
					StackDeEntrada.Pop();
					StackDeConsumo.Push(13);
					return Estado13(StackDeEntrada.Peek());
				case "string":
					//desplazamiento a d14
					//consume string
					StackDeEntrada.Pop();
					StackDeConsumo.Push(14);
					return Estado14(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 103
					return Estado103(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado69(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d104
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(104);
					return Estado104(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado70(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d105
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(105);
					return Estado105(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado71(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "const":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "}":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "void":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "int":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "double":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				case "string":
					//reduccion a r28
					return Estado28(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado72(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d106
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(106);
					return Estado106(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado73(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//desplazamiento a d107
					//consume }
					StackDeEntrada.Pop();
					StackDeConsumo.Push(107);
					return Estado107(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado74(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "}":
					//reduccion a r37
					return Estado37(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "SBPS":
					//irA 108
					return Estado108(StackDeEntrada.Peek());
				case "Stmt":
					//irA 74
					return Estado74(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado75(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d109
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(109);
					return Estado109(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado76(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case ";":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "(":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "{":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "}":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "if":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "while":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "for":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "break":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "return":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "System":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "else":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "-":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "!":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "this":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "New":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				case "null":
					//reduccion a r39
					return Estado39(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado77(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d110
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(110);
					return Estado110(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado78(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d111
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(111);
					return Estado111(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado79(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d112
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(112);
					return Estado112(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado80(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d113
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(113);
					return Estado113(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado81(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 114
					return Estado114(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado82(string _lookahead)
		{
			switch (_lookahead)
			{
				case ".":
					//desplazamiento a d115
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(115);
					return Estado115(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado83(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case ";":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "(":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "{":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "}":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "if":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "while":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "for":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "break":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "return":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "System":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "else":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "-":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "!":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "this":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "New":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				case "null":
					//reduccion a r46
					return Estado46(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado84(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ";":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "(":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ")":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "{":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "}":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ",":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "if":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "while":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "for":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "break":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "return":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "System":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ".":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "else":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "=":
					//desplazamiento a d116
					//consume =
					StackDeEntrada.Pop();
					StackDeConsumo.Push(116);
					return Estado116(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "||":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ">":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "-":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "/":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "%":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "!":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "this":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "New":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "null":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado85(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case ";":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "(":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case ")":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "{":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "}":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case ",":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "if":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "while":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "for":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "break":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "return":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "System":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "else":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "!=":
					//desplazamiento a d117
					//consume !=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(117);
					return Estado117(StackDeEntrada.Peek());
				case "-":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "!":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "this":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "New":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				case "null":
					//reduccion a r52
					return Estado52(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado86(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case ";":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "(":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case ")":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "{":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "}":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case ",":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "if":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "while":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "for":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "break":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "return":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "System":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "else":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "||":
					//desplazamiento a d118
					//consume ||
					StackDeEntrada.Pop();
					StackDeConsumo.Push(118);
					return Estado118(StackDeEntrada.Peek());
				case "-":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "!":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "this":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "New":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				case "null":
					//reduccion a r54
					return Estado54(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado87(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case ";":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "(":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case ")":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "{":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "}":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case ",":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "if":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "while":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "for":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "break":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "return":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "System":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "else":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "||":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case ">":
					//desplazamiento a d119
					//consume >
					StackDeEntrada.Pop();
					StackDeConsumo.Push(119);
					return Estado119(StackDeEntrada.Peek());
				case ">=":
					//desplazamiento a d120
					//consume >=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(120);
					return Estado120(StackDeEntrada.Peek());
				case "-":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "!":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "this":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "New":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				case "null":
					//reduccion a r56
					return Estado56(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado88(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case ";":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "(":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case ")":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "{":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "}":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case ",":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "if":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "while":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "for":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "break":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "return":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "System":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "else":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "||":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case ">":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "-":
				//conflicto a d121 / r59
				//consume -
				case "!":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "this":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "New":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				case "null":
					//reduccion a r59
					return Estado59(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado89(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case ";":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "(":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case ")":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "{":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "}":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case ",":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "if":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "while":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "for":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "break":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "return":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "System":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "else":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "||":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case ">":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "-":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "/":
					//desplazamiento a d122
					//consume /
					StackDeEntrada.Pop();
					StackDeConsumo.Push(122);
					return Estado122(StackDeEntrada.Peek());
				case "%":
					//desplazamiento a d123
					//consume %
					StackDeEntrada.Pop();
					StackDeConsumo.Push(123);
					return Estado123(StackDeEntrada.Peek());
				case "!":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "this":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "New":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				case "null":
					//reduccion a r61
					return Estado61(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado90(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case ";":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "(":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case ")":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "{":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "}":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case ",":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "if":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "while":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "for":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "break":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "return":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "System":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "else":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "||":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case ">":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "-":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "/":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "%":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "!":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "this":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "New":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				case "null":
					//reduccion a r64
					return Estado64(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado91(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 124
					return Estado124(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado92(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 126
					return Estado126(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado93(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ";":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "(":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ")":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "{":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "}":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ",":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "if":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "while":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "for":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "break":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "return":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "System":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ".":
					//desplazamiento a d127
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					return Estado127(StackDeEntrada.Peek());
				case "else":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "||":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ">":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "-":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "/":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "%":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "!":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "this":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "New":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				case "null":
					//reduccion a r67
					return Estado67(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado94(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ";":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "(":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ")":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "{":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "}":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ",":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "if":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "while":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "for":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "break":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "return":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "System":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ".":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "else":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "||":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ">":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "-":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "/":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "%":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "!":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "this":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "New":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				case "null":
					//reduccion a r70
					return Estado70(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado95(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 128
					return Estado128(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado96(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ";":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "(":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ")":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "{":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "}":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ",":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "if":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "while":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "for":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "break":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "return":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "System":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ".":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "else":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "||":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ">":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "-":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "/":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "%":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "!":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "this":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "New":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				case "null":
					//reduccion a r72
					return Estado72(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado97(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d129
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(129);
					return Estado129(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado98(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ";":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "(":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ")":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "{":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "}":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ",":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "if":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "while":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "for":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "break":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "return":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "System":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ".":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "else":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "||":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ">":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "-":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "/":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "%":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "!":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "this":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "New":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				case "null":
					//reduccion a r75
					return Estado75(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado99(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ";":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ")":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "{":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "}":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ",":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "if":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "while":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "for":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "break":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "return":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "System":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ".":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "else":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "||":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ">":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "-":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "/":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "%":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "!":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "this":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "New":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				case "null":
					//reduccion a r76
					return Estado76(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado100(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ";":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "(":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ")":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "{":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "}":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ",":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "if":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "for":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "break":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "return":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "System":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ".":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "else":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "||":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ">":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "-":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "/":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "%":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "!":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "this":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "New":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				case "null":
					//reduccion a r77
					return Estado77(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado101(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ";":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "(":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ")":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "{":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "}":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ",":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "if":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "while":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "break":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "return":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "System":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ".":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "else":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "||":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ">":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "-":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "/":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "%":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "!":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "this":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "New":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				case "null":
					//reduccion a r78
					return Estado78(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado102(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ";":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "(":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ")":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "{":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "}":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ",":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "if":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "while":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "for":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "return":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "System":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ".":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "else":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "||":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ">":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "-":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "/":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "%":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "!":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "this":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "New":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				case "null":
					//reduccion a r79
					return Estado79(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado103(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d130
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(130);
					return Estado130(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado104(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
				//conflicto a d9 / r33
				//consume ident
				case ";":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "(":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "const":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "class":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "{":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "}":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "void":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "int":
				//conflicto a d11 / r33
				//consume int
				case "double":
				//conflicto a d12 / r33
				//consume double
				case "bool":
				//conflicto a d13 / r33
				//consume bool
				case "string":
				//conflicto a d14 / r33
				//consume string
				case "if":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "while":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "for":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "break":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "return":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "System":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "else":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "-":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "!":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "this":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "New":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "null":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "$":
					//reduccion a r33
					return Estado33(StackDeEntrada.Peek());
				case "Type":
					//irA 60
					return Estado60(StackDeEntrada.Peek());
				case "CnsTp":
					//irA 8
					return Estado8(StackDeEntrada.Peek());
				case "SBPV":
					//irA 131
					return Estado131(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado105(string _lookahead)
		{
			switch (_lookahead)
			{
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 132
					return Estado132(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado106(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "}":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "void":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "int":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "double":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				case "string":
					//reduccion a r31
					return Estado31(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado107(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case ";":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "(":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "const":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "class":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "{":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "}":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "void":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "int":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "double":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "string":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "if":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "while":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "for":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "break":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "return":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "System":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "else":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "-":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "!":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "this":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "New":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "null":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				case "$":
					//reduccion a r15
					return Estado15(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado108(string _lookahead)
		{
			switch (_lookahead)
			{
				case "}":
					//reduccion a r36
					return Estado36(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado109(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case ";":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "(":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "{":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "}":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "if":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "while":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "for":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "break":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "return":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "System":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "else":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "-":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "!":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "this":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "New":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				case "null":
					//reduccion a r38
					return Estado38(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado110(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 133
					return Estado133(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado111(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 134
					return Estado134(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado112(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 135
					return Estado135(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado113(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case ";":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "(":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "{":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "}":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "if":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "while":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "for":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "break":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "return":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "System":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "else":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "-":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "!":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "this":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "New":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				case "null":
					//reduccion a r43
					return Estado43(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado114(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d136
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(136);
					return Estado136(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado115(string _lookahead)
		{
			switch (_lookahead)
			{
				case "out":
					//desplazamiento a d137
					//consume out
					StackDeEntrada.Pop();
					StackDeConsumo.Push(137);
					return Estado137(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado116(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 138
					return Estado138(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado117(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 139
					return Estado139(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado118(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 140
					return Estado140(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado119(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 141
					return Estado141(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado120(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 142
					return Estado142(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado121(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 143
					return Estado143(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado122(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 144
					return Estado144(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado123(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 145
					return Estado145(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado124(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ";":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "(":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ")":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "{":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "}":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ",":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "if":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "while":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "for":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "break":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "return":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "System":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ".":
					//desplazamiento a d127
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					return Estado127(StackDeEntrada.Peek());
				case "else":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "||":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ">":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "-":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "/":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "%":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "!":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "this":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "New":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				case "null":
					//reduccion a r65
					return Estado65(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado125(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ";":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "(":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ")":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "{":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "}":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ",":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "if":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "while":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "for":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "break":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "return":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "System":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ".":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "else":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "||":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ">":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "-":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "/":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "%":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "!":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "this":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "New":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				case "null":
					//reduccion a r73
					return Estado73(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado126(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ";":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "(":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ")":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "{":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "}":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ",":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "if":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "while":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "for":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "break":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "return":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "System":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ".":
					//desplazamiento a d127
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(127);
					return Estado127(StackDeEntrada.Peek());
				case "else":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "||":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ">":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "-":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "/":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "%":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "!":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "this":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "New":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				case "null":
					//reduccion a r66
					return Estado66(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado127(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d146
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(146);
					return Estado146(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado128(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d147
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(147);
					return Estado147(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado129(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d148
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(148);
					return Estado148(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado130(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d149
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(149);
					return Estado149(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado131(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case ";":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "(":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "const":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "class":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "{":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "}":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "void":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "int":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "double":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "string":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "if":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "while":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "for":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "break":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "return":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "System":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "else":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "-":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "!":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "this":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "New":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "null":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				case "$":
					//reduccion a r32
					return Estado32(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado132(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "const":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "}":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "void":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "int":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "double":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				case "string":
					//reduccion a r27
					return Estado27(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado133(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d150
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(150);
					return Estado150(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado134(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d151
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(151);
					return Estado151(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado135(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d152
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(152);
					return Estado152(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado136(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case ";":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "(":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "{":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "}":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "if":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "while":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "for":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "break":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "return":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "System":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "else":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "-":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "!":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "this":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "New":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				case "null":
					//reduccion a r44
					return Estado44(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado137(string _lookahead)
		{
			switch (_lookahead)
			{
				case ".":
					//desplazamiento a d153
					//consume .
					StackDeEntrada.Pop();
					StackDeConsumo.Push(153);
					return Estado153(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado138(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case ";":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "(":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case ")":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "{":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "}":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case ",":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "if":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "while":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "for":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "break":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "return":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "System":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "else":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "!=":
					//desplazamiento a d117
					//consume !=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(117);
					return Estado117(StackDeEntrada.Peek());
				case "-":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "!":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "this":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "New":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				case "null":
					//reduccion a r51
					return Estado51(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado139(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case ";":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "(":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case ")":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "{":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "}":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case ",":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "if":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "while":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "for":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "break":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "return":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "System":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "else":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "||":
					//desplazamiento a d118
					//consume ||
					StackDeEntrada.Pop();
					StackDeConsumo.Push(118);
					return Estado118(StackDeEntrada.Peek());
				case "-":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "!":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "this":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "New":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				case "null":
					//reduccion a r53
					return Estado53(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado140(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case ";":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "(":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case ")":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "{":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "}":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case ",":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "if":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "while":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "for":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "break":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "return":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "System":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "else":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "||":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case ">":
					//desplazamiento a d119
					//consume >
					StackDeEntrada.Pop();
					StackDeConsumo.Push(119);
					return Estado119(StackDeEntrada.Peek());
				case ">=":
					//desplazamiento a d120
					//consume >=
					StackDeEntrada.Pop();
					StackDeConsumo.Push(120);
					return Estado120(StackDeEntrada.Peek());
				case "-":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "!":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "this":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "New":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				case "null":
					//reduccion a r55
					return Estado55(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado141(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case ";":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "(":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case ")":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "{":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "}":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case ",":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "if":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "while":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "for":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "break":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "return":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "System":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "else":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "||":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case ">":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "-":
				//conflicto a d121 / r57
				//consume -
				case "!":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "this":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "New":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				case "null":
					//reduccion a r57
					return Estado57(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado142(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case ";":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "(":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case ")":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "{":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "}":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case ",":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "if":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "while":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "for":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "break":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "return":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "System":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "else":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "||":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case ">":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "-":
				//conflicto a d121 / r58
				//consume -
				case "!":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "this":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "New":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				case "null":
					//reduccion a r58
					return Estado58(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado143(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case ";":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "(":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case ")":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "{":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "}":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case ",":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "if":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "while":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "for":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "break":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "return":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "System":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "else":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "||":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case ">":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "-":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "/":
					//desplazamiento a d122
					//consume /
					StackDeEntrada.Pop();
					StackDeConsumo.Push(122);
					return Estado122(StackDeEntrada.Peek());
				case "%":
					//desplazamiento a d123
					//consume %
					StackDeEntrada.Pop();
					StackDeConsumo.Push(123);
					return Estado123(StackDeEntrada.Peek());
				case "!":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "this":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "New":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				case "null":
					//reduccion a r60
					return Estado60(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado144(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case ";":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "(":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case ")":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "{":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "}":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case ",":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "if":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "while":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "for":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "break":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "return":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "System":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "else":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "||":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case ">":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "-":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "/":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "%":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "!":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "this":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "New":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				case "null":
					//reduccion a r62
					return Estado62(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado145(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case ";":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "(":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case ")":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "{":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "}":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case ",":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "if":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "while":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "for":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "break":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "return":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "System":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "else":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "||":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case ">":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "-":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "/":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "%":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "!":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "this":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "New":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				case "null":
					//reduccion a r63
					return Estado63(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado146(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ";":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "(":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ")":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "{":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "}":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ",":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "if":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "while":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "for":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "break":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "return":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "System":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ".":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "else":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "=":
					//desplazamiento a d154
					//consume =
					StackDeEntrada.Pop();
					StackDeConsumo.Push(154);
					return Estado154(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "||":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ">":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "-":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "/":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "%":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "!":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "this":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "New":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				case "null":
					//reduccion a r69
					return Estado69(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado147(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ";":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "(":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ")":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "{":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "}":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ",":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "if":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "while":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "for":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "break":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "return":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "System":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ".":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "else":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "||":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ">":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "-":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "/":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "%":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "!":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "this":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "New":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				case "null":
					//reduccion a r71
					return Estado71(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado148(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d155
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(155);
					return Estado155(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado149(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case ";":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "(":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "const":
				//conflicto a d68 / r35
				//consume const
				case "class":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "{":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "}":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "void":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "int":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "double":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "string":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "if":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "while":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "for":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "break":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "return":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "System":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "else":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "-":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "!":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "this":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "New":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "null":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "$":
					//reduccion a r35
					return Estado35(StackDeEntrada.Peek());
				case "SBPC":
					//irA 156
					return Estado156(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado150(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "Stmt":
					//irA 157
					return Estado157(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado151(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "Stmt":
					//irA 158
					return Estado158(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado152(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 159
					return Estado159(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado153(string _lookahead)
		{
			switch (_lookahead)
			{
				case "println":
					//desplazamiento a d160
					//consume println
					StackDeEntrada.Pop();
					StackDeConsumo.Push(160);
					return Estado160(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado154(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d125
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(125);
					return Estado125(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 161
					return Estado161(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado155(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ";":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "(":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ")":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "{":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "}":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ",":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "if":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "while":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "for":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "break":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "return":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "System":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ".":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "else":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "||":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ">":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "-":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "/":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "%":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "!":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "this":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "New":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				case "null":
					//reduccion a r74
					return Estado74(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado156(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case ";":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "(":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "const":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "class":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "{":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "}":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "interface":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "void":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "int":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "double":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "bool":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "string":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "if":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "while":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "for":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "break":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "return":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "System":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "else":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "-":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "!":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "this":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "New":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "null":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				case "$":
					//reduccion a r34
					return Estado34(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado157(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case ";":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "(":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "{":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "}":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "if":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "while":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "for":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "break":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "return":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "System":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "else":
				//conflicto a d163 / r48
				//consume else
				case "-":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "!":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "this":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "New":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "null":
					//reduccion a r48
					return Estado48(StackDeEntrada.Peek());
				case "ElseStmt":
					//irA 162
					return Estado162(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado158(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case ";":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "(":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "{":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "}":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "if":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "while":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "for":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "break":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "return":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "System":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "else":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "-":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "!":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "this":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "New":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				case "null":
					//reduccion a r41
					return Estado41(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado159(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d164
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(164);
					return Estado164(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado160(string _lookahead)
		{
			switch (_lookahead)
			{
				case "(":
					//desplazamiento a d165
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(165);
					return Estado165(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado161(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ";":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "(":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ")":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "{":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "}":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ",":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "if":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "while":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "for":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "break":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "return":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "System":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ".":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "else":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "!=":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "||":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ">":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case ">=":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "-":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "/":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "%":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "!":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "this":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "New":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				case "null":
					//reduccion a r68
					return Estado68(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado162(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case ";":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "(":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "{":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "}":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "if":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "while":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "for":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "break":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "return":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "System":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "else":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "-":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "!":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "this":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "New":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				case "null":
					//reduccion a r40
					return Estado40(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado163(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "Stmt":
					//irA 166
					return Estado166(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado164(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 167
					return Estado167(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado165(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 168
					return Estado168(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado166(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case ";":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "(":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "{":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "}":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "if":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "while":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "for":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "break":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "return":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "System":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "else":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "-":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "!":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "this":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "New":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				case "null":
					//reduccion a r47
					return Estado47(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado167(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d169
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(169);
					return Estado169(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado168(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r50
					return Estado50(StackDeEntrada.Peek());
				case ",":
					//desplazamiento a d171
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(171);
					return Estado171(StackDeEntrada.Peek());
				case "ExPrint":
					//irA 170
					return Estado170(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado169(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case ";":
					//desplazamiento a d76
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(76);
					return Estado76(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "{":
					//desplazamiento a d50
					//consume {
					StackDeEntrada.Pop();
					StackDeConsumo.Push(50);
					return Estado50(StackDeEntrada.Peek());
				case "if":
					//desplazamiento a d77
					//consume if
					StackDeEntrada.Pop();
					StackDeConsumo.Push(77);
					return Estado77(StackDeEntrada.Peek());
				case "while":
					//desplazamiento a d78
					//consume while
					StackDeEntrada.Pop();
					StackDeConsumo.Push(78);
					return Estado78(StackDeEntrada.Peek());
				case "for":
					//desplazamiento a d79
					//consume for
					StackDeEntrada.Pop();
					StackDeConsumo.Push(79);
					return Estado79(StackDeEntrada.Peek());
				case "break":
					//desplazamiento a d80
					//consume break
					StackDeEntrada.Pop();
					StackDeConsumo.Push(80);
					return Estado80(StackDeEntrada.Peek());
				case "return":
					//desplazamiento a d81
					//consume return
					StackDeEntrada.Pop();
					StackDeConsumo.Push(81);
					return Estado81(StackDeEntrada.Peek());
				case "System":
					//desplazamiento a d82
					//consume System
					StackDeEntrada.Pop();
					StackDeConsumo.Push(82);
					return Estado82(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "StmtBlock":
					//irA 83
					return Estado83(StackDeEntrada.Peek());
				case "Stmt":
					//irA 172
					return Estado172(StackDeEntrada.Peek());
				case "Expr":
					//irA 75
					return Estado75(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado170(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//desplazamiento a d173
					//consume )
					StackDeEntrada.Pop();
					StackDeConsumo.Push(173);
					return Estado173(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado171(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//desplazamiento a d84
					//consume ident
					StackDeEntrada.Pop();
					StackDeConsumo.Push(84);
					return Estado84(StackDeEntrada.Peek());
				case "(":
					//desplazamiento a d95
					//consume (
					StackDeEntrada.Pop();
					StackDeConsumo.Push(95);
					return Estado95(StackDeEntrada.Peek());
				case "-":
					//desplazamiento a d91
					//consume -
					StackDeEntrada.Pop();
					StackDeConsumo.Push(91);
					return Estado91(StackDeEntrada.Peek());
				case "!":
					//desplazamiento a d92
					//consume !
					StackDeEntrada.Pop();
					StackDeConsumo.Push(92);
					return Estado92(StackDeEntrada.Peek());
				case "this":
					//desplazamiento a d96
					//consume this
					StackDeEntrada.Pop();
					StackDeConsumo.Push(96);
					return Estado96(StackDeEntrada.Peek());
				case "New":
					//desplazamiento a d97
					//consume New
					StackDeEntrada.Pop();
					StackDeConsumo.Push(97);
					return Estado97(StackDeEntrada.Peek());
				case "intConstant":
					//desplazamiento a d98
					//consume intConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(98);
					return Estado98(StackDeEntrada.Peek());
				case "doubleConstant":
					//desplazamiento a d99
					//consume doubleConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(99);
					return Estado99(StackDeEntrada.Peek());
				case "boolConstant":
					//desplazamiento a d100
					//consume boolConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(100);
					return Estado100(StackDeEntrada.Peek());
				case "stringConstant":
					//desplazamiento a d101
					//consume stringConstant
					StackDeEntrada.Pop();
					StackDeConsumo.Push(101);
					return Estado101(StackDeEntrada.Peek());
				case "null":
					//desplazamiento a d102
					//consume null
					StackDeEntrada.Pop();
					StackDeConsumo.Push(102);
					return Estado102(StackDeEntrada.Peek());
				case "Expr":
					//irA 174
					return Estado174(StackDeEntrada.Peek());
				case "ExprOr":
					//irA 85
					return Estado85(StackDeEntrada.Peek());
				case "ExprOrP":
					//irA 86
					return Estado86(StackDeEntrada.Peek());
				case "ExprAnd":
					//irA 87
					return Estado87(StackDeEntrada.Peek());
				case "ExprAndP":
					//irA 88
					return Estado88(StackDeEntrada.Peek());
				case "ExprEquals":
					//irA 89
					return Estado89(StackDeEntrada.Peek());
				case "ExprEqualsP":
					//irA 90
					return Estado90(StackDeEntrada.Peek());
				case "ExprComp":
					//irA 93
					return Estado93(StackDeEntrada.Peek());
				case "ExprCompP":
					//irA 94
					return Estado94(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado172(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case ";":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "(":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "{":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "}":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "if":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "while":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "for":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "break":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "return":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "System":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "else":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "-":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "!":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "this":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "New":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				case "null":
					//reduccion a r42
					return Estado42(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado173(string _lookahead)
		{
			switch (_lookahead)
			{
				case ";":
					//desplazamiento a d175
					//consume ;
					StackDeEntrada.Pop();
					StackDeConsumo.Push(175);
					return Estado175(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado174(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r50
					return Estado50(StackDeEntrada.Peek());
				case ",":
					//desplazamiento a d171
					//consume ,
					StackDeEntrada.Pop();
					StackDeConsumo.Push(171);
					return Estado171(StackDeEntrada.Peek());
				case "ExPrint":
					//irA 176
					return Estado176(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado175(string _lookahead)
		{
			switch (_lookahead)
			{
				case "ident":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case ";":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "(":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "{":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "}":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "if":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "while":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "for":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "break":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "return":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "System":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "else":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "-":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "!":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "this":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "New":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "intConstant":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "doubleConstant":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "boolConstant":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "stringConstant":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				case "null":
					//reduccion a r45
					return Estado45(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}
		public bool Estado176(string _lookahead)
		{
			switch (_lookahead)
			{
				case ")":
					//reduccion a r49
					return Estado49(StackDeEntrada.Peek());
				default:
					Err(); return false;
			}
		}

		#endregion

	}
}
