.method public hidebysig static void  SelectionSort(int32[] arr) cil managed
{
    // Code size       57 (0x39) 
    .maxstack  4
    .locals init (int32 V_0,
        int32 V_1,
        int32 V_2,
        int32 V_3)
    IL_0000:  ldc.i4.0 							pust contant                | 0
    IL_0001:  stloc.0 							store local variable 0      | int i = 0
    IL_0002:  br.s       IL_0032 				jump to prog line 0032

    IL_0004:  ldloc.0 							load local variable 0 		| i
    IL_0005:  stloc.1 							store local variale 1 		| leaste = i;
    IL_0006:  ldloc.0							load local variable 0 		| i
    IL_0007:  ldc.i4.1 							push contant 				| 1
    IL_0008:  add								add two top stack elems     | i + 1
    IL_0009:  stloc.2 							store local variable 2      | j = i + 1
    IL_000a:  br.s       IL_001a 				jump to prog line 001a 

    IL_000c:  ldarg.0 							load local arg 0 			| arr
    IL_000d:  ldloc.2 							load local variable 2 		| j
    IL_000e:  ldelem.i4 						load local array elem 		| arr[j]
    IL_000f:  ldarg.0 							load local arg 0 			| arr
    IL_0010:  ldloc.1 							load local variable 1 		| least
    IL_0011:  ldelem.i4 						load local array elem 		| arr[least]
    IL_0012:  bge.s      IL_0016 				jump if larger than jump to prog line 0016

    IL_0014:  ldloc.2 							load local variable 2 		| j
    IL_0015:  stloc.1 							store local variable 1 		| least = j
    IL_0016:  ldloc.2 							load local variable 2 		| j
    IL_0017:  ldc.i4.1 							push contant 				| 1
    IL_0018:  add 								add two top stack elems 	| j + 1
    IL_0019:  stloc.2 							store local variable 2 		| j =  j + 1
    IL_001a:  ldloc.2 							load local variable 2 		| j
    IL_001b:  ldarg.0 							load local arg 0 			| arr
    IL_001c:  ldlen 							the length of arr 			| arr.length
    IL_001d:  conv.i4 							convert to int 				| (int)
    IL_001e:  blt.s      IL_000c 				jump to prog line 000c if lt 

    IL_0020:  ldarg.0 							load local arg 0 			| arr
    IL_0021:  ldloc.0 							load local variable 0 		| i
    IL_0022:  ldelem.i4 						load local array elem 		| arr[i]
    IL_0023:  stloc.3 							store local variable 3      | tmp = arr[i]
    IL_0024:  ldarg.0 							load local variable 0 		| arr
    IL_0025:  ldloc.0 							local local variable 0 		| i
    IL_0026:  ldarg.0 							load local arg 0 			| arr
    IL_0027:  ldloc.1 							load local variable 1 		| least
    IL_0028:  ldelem.i4 						load local array elem 		| arr[least]
    IL_0029:  stelem.i4 						store local array elem 		| arr[i] = arr[least]
    IL_002a:  ldarg.0 							load local arg 0 			| arr
    IL_002b:  ldloc.1 							load local variable 1		| least
    IL_002c:  ldloc.3 							load local variable 3 		| tmp
    IL_002d:  stelem.i4 						store local array elem 		| arr[least] = tmp
    IL_002e:  ldloc.0 							load local variable 0 		| i
    IL_002f:  ldc.i4.1 							push contant 				| 1
    IL_0030:  add 								add two top stack elems 	| i + 1
    IL_0031:  stloc.0 							store local variable 0 		| i = i + 1
    IL_0032:  ldloc.0 							load local variable 0       | i
    IL_0033:  ldarg.0 							load ldarg.0                | arr
    IL_0034:  ldlen 							get length of array         | arr.length
    IL_0035:  conv.i4 							cast to int                 | (int)
    IL_0036:  blt.s      IL_0004 				jump to progline 4 if lt    | if (i < (int) arr.length)

    IL_0038:  ret 								return
} // end of method Selsort::SelectionSort