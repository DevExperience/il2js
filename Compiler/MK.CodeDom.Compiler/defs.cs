﻿/*
il2js Compiler - JavaScript VM for .NET
Copyright (C) 2012 Michael Kolarz

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace MK.CodeDom.Compiler {
	public enum OpCodeValue : short {
		#region
		Nop = 0, Break = 1, Ldarg_0 = 2, Ldarg_1 = 3, Ldarg_2 = 4, Ldarg_3 = 5, Ldloc_0 = 6, Ldloc_1 = 7, Ldloc_2 = 8, Ldloc_3 = 9, Stloc_0 = 10, Stloc_1 = 11, Stloc_2 = 12, Stloc_3 = 13, Ldarg_S = 14, Ldarga_S = 15, Starg_S = 16, Ldloc_S = 17, Ldloca_S = 18, Stloc_S = 19, Ldnull = 20, Ldc_I4_M1 = 21, Ldc_I4_0 = 22, Ldc_I4_1 = 23, Ldc_I4_2 = 24, Ldc_I4_3 = 25, Ldc_I4_4 = 26, Ldc_I4_5 = 27, Ldc_I4_6 = 28, Ldc_I4_7 = 29, Ldc_I4_8 = 30, Ldc_I4_S = 31, Ldc_I4 = 32, Ldc_I8 = 33, Ldc_R4 = 34, Ldc_R8 = 35, Dup = 37, Pop = 38, Jmp = 39, Call = 40, Calli = 41, Ret = 42, Br_S = 43, Brfalse_S = 44, Brtrue_S = 45, Beq_S = 46, Bge_S = 47, Bgt_S = 48, Ble_S = 49, Blt_S = 50, Bne_Un_S = 51, Bge_Un_S = 52, Bgt_Un_S = 53, Ble_Un_S = 54, Blt_Un_S = 55, Br = 56, Brfalse = 57, Brtrue = 58, Beq = 59, Bge = 60, Bgt = 61, Ble = 62, Blt = 63, Bne_Un = 64, Bge_Un = 65, Bgt_Un = 66, Ble_Un = 67, Blt_Un = 68, Switch = 69, Ldind_I1 = 70, Ldind_U1 = 71, Ldind_I2 = 72, Ldind_U2 = 73, Ldind_I4 = 74, Ldind_U4 = 75, Ldind_I8 = 76, Ldind_I = 77, Ldind_R4 = 78, Ldind_R8 = 79, Ldind_Ref = 80, Stind_Ref = 81, Stind_I1 = 82, Stind_I2 = 83, Stind_I4 = 84, Stind_I8 = 85, Stind_R4 = 86, Stind_R8 = 87, Add = 88, Sub = 89, Mul = 90, Div = 91, Div_Un = 92, Rem = 93, Rem_Un = 94, And = 95, Or = 96, Xor = 97, Shl = 98, Shr = 99, Shr_Un = 100, Neg = 101, Not = 102, Conv_I1 = 103, Conv_I2 = 104, Conv_I4 = 105, Conv_I8 = 106, Conv_R4 = 107, Conv_R8 = 108, Conv_U4 = 109, Conv_U8 = 110, Callvirt = 111, Cpobj = 112, Ldobj = 113, Ldstr = 114, Newobj = 115, Castclass = 116, Isinst = 117, Conv_R_Un = 118, Unbox = 121, Throw = 122, Ldfld = 123, Ldflda = 124, Stfld = 125, Ldsfld = 126, Ldsflda = 127, Stsfld = 128, Stobj = 129, Conv_Ovf_I1_Un = 130, Conv_Ovf_I2_Un = 131, Conv_Ovf_I4_Un = 132, Conv_Ovf_I8_Un = 133, Conv_Ovf_U1_Un = 134, Conv_Ovf_U2_Un = 135, Conv_Ovf_U4_Un = 136, Conv_Ovf_U8_Un = 137, Conv_Ovf_I_Un = 138, Conv_Ovf_U_Un = 139, Box = 140, Newarr = 141, Ldlen = 142, Ldelema = 143, Ldelem_I1 = 144, Ldelem_U1 = 145, Ldelem_I2 = 146, Ldelem_U2 = 147, Ldelem_I4 = 148, Ldelem_U4 = 149, Ldelem_I8 = 150, Ldelem_I = 151, Ldelem_R4 = 152, Ldelem_R8 = 153, Ldelem_Ref = 154, Stelem_I = 155, Stelem_I1 = 156, Stelem_I2 = 157, Stelem_I4 = 158, Stelem_I8 = 159, Stelem_R4 = 160, Stelem_R8 = 161, Stelem_Ref = 162, Ldelem = 163, Stelem = 164, Unbox_Any = 165, Conv_Ovf_I1 = 179, Conv_Ovf_U1 = 180, Conv_Ovf_I2 = 181, Conv_Ovf_U2 = 182, Conv_Ovf_I4 = 183, Conv_Ovf_U4 = 184, Conv_Ovf_I8 = 185, Conv_Ovf_U8 = 186, Refanyval = 194, Ckfinite = 195, Mkrefany = 198, Ldtoken = 208, Conv_U2 = 209, Conv_U1 = 210, Conv_I = 211, Conv_Ovf_I = 212, Conv_Ovf_U = 213, Add_Ovf = 214, Add_Ovf_Un = 215, Mul_Ovf = 216, Mul_Ovf_Un = 217, Sub_Ovf = 218, Sub_Ovf_Un = 219, Endfinally = 220, Leave = 221, Leave_S = 222, Stind_I = 223, Conv_U = 224, Prefix7 = 248, Prefix6 = 249, Prefix5 = 250, Prefix4 = 251, Prefix3 = 252, Prefix2 = 253, Prefix1 = 254, Prefixref = 255, Arglist = -512, Ceq = -511, Cgt = -510, Cgt_Un = -509, Clt = -508, Clt_Un = -507, Ldftn = -506, Ldvirtftn = -505, Ldarg = -503, Ldarga = -502, Starg = -501, Ldloc = -500, Ldloca = -499, Stloc = -498, Localloc = -497, Endfilter = -495, Unaligned = -494, Volatile = -493, Tailcall = -492, Initobj = -491, Constrained = -490, Cpblk = -489, Initblk = -488, Rethrow = -486, Sizeof = -484, Refanytype = -483, Readonly = -482,
		#endregion
	}
	public partial class ILParser {
		private static OpCode[] byteCodes = new OpCode[] {
#region
//0
OpCodes.Nop,
//1
OpCodes.Break,
//2
OpCodes.Ldarg_0,
//3
OpCodes.Ldarg_1,
//4
OpCodes.Ldarg_2,
//5
OpCodes.Ldarg_3,
//6
OpCodes.Ldloc_0,
//7
OpCodes.Ldloc_1,
//8
OpCodes.Ldloc_2,
//9
OpCodes.Ldloc_3,
//10
OpCodes.Stloc_0,
//11
OpCodes.Stloc_1,
//12
OpCodes.Stloc_2,
//13
OpCodes.Stloc_3,
//14
OpCodes.Ldarg_S,
//15
OpCodes.Ldarga_S,
//16
OpCodes.Starg_S,
//17
OpCodes.Ldloc_S,
//18
OpCodes.Ldloca_S,
//19
OpCodes.Stloc_S,
//20
OpCodes.Ldnull,
//21
OpCodes.Ldc_I4_M1,
//22
OpCodes.Ldc_I4_0,
//23
OpCodes.Ldc_I4_1,
//24
OpCodes.Ldc_I4_2,
//25
OpCodes.Ldc_I4_3,
//26
OpCodes.Ldc_I4_4,
//27
OpCodes.Ldc_I4_5,
//28
OpCodes.Ldc_I4_6,
//29
OpCodes.Ldc_I4_7,
//30
OpCodes.Ldc_I4_8,
//31
OpCodes.Ldc_I4_S,
//32
OpCodes.Ldc_I4,
//33
OpCodes.Ldc_I8,
//34
OpCodes.Ldc_R4,
//35
OpCodes.Ldc_R8,
OpCodes.Nop,
//37
OpCodes.Dup,
//38
OpCodes.Pop,
//39
OpCodes.Jmp,
//40
OpCodes.Call,
//41
OpCodes.Calli,
//42
OpCodes.Ret,
//43
OpCodes.Br_S,
//44
OpCodes.Brfalse_S,
//45
OpCodes.Brtrue_S,
//46
OpCodes.Beq_S,
//47
OpCodes.Bge_S,
//48
OpCodes.Bgt_S,
//49
OpCodes.Ble_S,
//50
OpCodes.Blt_S,
//51
OpCodes.Bne_Un_S,
//52
OpCodes.Bge_Un_S,
//53
OpCodes.Bgt_Un_S,
//54
OpCodes.Ble_Un_S,
//55
OpCodes.Blt_Un_S,
//56
OpCodes.Br,
//57
OpCodes.Brfalse,
//58
OpCodes.Brtrue,
//59
OpCodes.Beq,
//60
OpCodes.Bge,
//61
OpCodes.Bgt,
//62
OpCodes.Ble,
//63
OpCodes.Blt,
//64
OpCodes.Bne_Un,
//65
OpCodes.Bge_Un,
//66
OpCodes.Bgt_Un,
//67
OpCodes.Ble_Un,
//68
OpCodes.Blt_Un,
//69
OpCodes.Switch,
//70
OpCodes.Ldind_I1,
//71
OpCodes.Ldind_U1,
//72
OpCodes.Ldind_I2,
//73
OpCodes.Ldind_U2,
//74
OpCodes.Ldind_I4,
//75
OpCodes.Ldind_U4,
//76
OpCodes.Ldind_I8,
//77
OpCodes.Ldind_I,
//78
OpCodes.Ldind_R4,
//79
OpCodes.Ldind_R8,
//80
OpCodes.Ldind_Ref,
//81
OpCodes.Stind_Ref,
//82
OpCodes.Stind_I1,
//83
OpCodes.Stind_I2,
//84
OpCodes.Stind_I4,
//85
OpCodes.Stind_I8,
//86
OpCodes.Stind_R4,
//87
OpCodes.Stind_R8,
//88
OpCodes.Add,
//89
OpCodes.Sub,
//90
OpCodes.Mul,
//91
OpCodes.Div,
//92
OpCodes.Div_Un,
//93
OpCodes.Rem,
//94
OpCodes.Rem_Un,
//95
OpCodes.And,
//96
OpCodes.Or,
//97
OpCodes.Xor,
//98
OpCodes.Shl,
//99
OpCodes.Shr,
//100
OpCodes.Shr_Un,
//101
OpCodes.Neg,
//102
OpCodes.Not,
//103
OpCodes.Conv_I1,
//104
OpCodes.Conv_I2,
//105
OpCodes.Conv_I4,
//106
OpCodes.Conv_I8,
//107
OpCodes.Conv_R4,
//108
OpCodes.Conv_R8,
//109
OpCodes.Conv_U4,
//110
OpCodes.Conv_U8,
//111
OpCodes.Callvirt,
//112
OpCodes.Cpobj,
//113
OpCodes.Ldobj,
//114
OpCodes.Ldstr,
//115
OpCodes.Newobj,
//116
OpCodes.Castclass,
//117
OpCodes.Isinst,
//118
OpCodes.Conv_R_Un,
OpCodes.Nop,
OpCodes.Nop,
//121
OpCodes.Unbox,
//122
OpCodes.Throw,
//123
OpCodes.Ldfld,
//124
OpCodes.Ldflda,
//125
OpCodes.Stfld,
//126
OpCodes.Ldsfld,
//127
OpCodes.Ldsflda,
//128
OpCodes.Stsfld,
//129
OpCodes.Stobj,
//130
OpCodes.Conv_Ovf_I1_Un,
//131
OpCodes.Conv_Ovf_I2_Un,
//132
OpCodes.Conv_Ovf_I4_Un,
//133
OpCodes.Conv_Ovf_I8_Un,
//134
OpCodes.Conv_Ovf_U1_Un,
//135
OpCodes.Conv_Ovf_U2_Un,
//136
OpCodes.Conv_Ovf_U4_Un,
//137
OpCodes.Conv_Ovf_U8_Un,
//138
OpCodes.Conv_Ovf_I_Un,
//139
OpCodes.Conv_Ovf_U_Un,
//140
OpCodes.Box,
//141
OpCodes.Newarr,
//142
OpCodes.Ldlen,
//143
OpCodes.Ldelema,
//144
OpCodes.Ldelem_I1,
//145
OpCodes.Ldelem_U1,
//146
OpCodes.Ldelem_I2,
//147
OpCodes.Ldelem_U2,
//148
OpCodes.Ldelem_I4,
//149
OpCodes.Ldelem_U4,
//150
OpCodes.Ldelem_I8,
//151
OpCodes.Ldelem_I,
//152
OpCodes.Ldelem_R4,
//153
OpCodes.Ldelem_R8,
//154
OpCodes.Ldelem_Ref,
//155
OpCodes.Stelem_I,
//156
OpCodes.Stelem_I1,
//157
OpCodes.Stelem_I2,
//158
OpCodes.Stelem_I4,
//159
OpCodes.Stelem_I8,
//160
OpCodes.Stelem_R4,
//161
OpCodes.Stelem_R8,
//162
OpCodes.Stelem_Ref,
//163
OpCodes.Ldelem,
//164
OpCodes.Stelem,
//165
OpCodes.Unbox_Any,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
//179
OpCodes.Conv_Ovf_I1,
//180
OpCodes.Conv_Ovf_U1,
//181
OpCodes.Conv_Ovf_I2,
//182
OpCodes.Conv_Ovf_U2,
//183
OpCodes.Conv_Ovf_I4,
//184
OpCodes.Conv_Ovf_U4,
//185
OpCodes.Conv_Ovf_I8,
//186
OpCodes.Conv_Ovf_U8,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
//194
OpCodes.Refanyval,
//195
OpCodes.Ckfinite,
OpCodes.Nop,
OpCodes.Nop,
//198
OpCodes.Mkrefany,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
//208
OpCodes.Ldtoken,
//209
OpCodes.Conv_U2,
//210
OpCodes.Conv_U1,
//211
OpCodes.Conv_I,
//212
OpCodes.Conv_Ovf_I,
//213
OpCodes.Conv_Ovf_U,
//214
OpCodes.Add_Ovf,
//215
OpCodes.Add_Ovf_Un,
//216
OpCodes.Mul_Ovf,
//217
OpCodes.Mul_Ovf_Un,
//218
OpCodes.Sub_Ovf,
//219
OpCodes.Sub_Ovf_Un,
//220
OpCodes.Endfinally,
//221
OpCodes.Leave,
//222
OpCodes.Leave_S,
//223
OpCodes.Stind_I,
//224
OpCodes.Conv_U,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
OpCodes.Nop,
//248
OpCodes.Prefix7,
//249
OpCodes.Prefix6,
//250
OpCodes.Prefix5,
//251
OpCodes.Prefix4,
//252
OpCodes.Prefix3,
//253
OpCodes.Prefix2,
//254
OpCodes.Prefix1,
//255
OpCodes.Prefixref, 
#endregion
		};
		//index=512+code
		private static OpCode[] shortCodes = new OpCode[]{
#region
			//-512
OpCodes.Arglist,
//-511
OpCodes.Ceq,
//-510
OpCodes.Cgt,
//-509
OpCodes.Cgt_Un,
//-508
OpCodes.Clt,
//-507
OpCodes.Clt_Un,
//-506
OpCodes.Ldftn,
//-505
OpCodes.Ldvirtftn,
OpCodes.Nop,
//-503
OpCodes.Ldarg,
//-502
OpCodes.Ldarga,
//-501
OpCodes.Starg,
//-500
OpCodes.Ldloc,
//-499
OpCodes.Ldloca,
//-498
OpCodes.Stloc,
//-497
OpCodes.Localloc,
OpCodes.Nop,
//-495
OpCodes.Endfilter,
//-494
OpCodes.Unaligned,
//-493
OpCodes.Volatile,
//-492
OpCodes.Tailcall,
//-491
OpCodes.Initobj,
//-490
OpCodes.Constrained,
//-489
OpCodes.Cpblk,
//-488
OpCodes.Initblk,
OpCodes.Nop,
//-486
OpCodes.Rethrow,
OpCodes.Nop,
//-484
OpCodes.Sizeof,
//-483
OpCodes.Refanytype,
//-482
OpCodes.Readonly,
 
#endregion
		};
	}
}
