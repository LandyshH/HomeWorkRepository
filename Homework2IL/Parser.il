.class public abstract sealed auto ansi beforefieldinit
  Homework2IL.Parser
    extends System.Object
{

  .method public hidebysig static valuetype Homework2IL.HundledExceptions
    ParseArguments(
      string[] args,
      [out] class Homework2IL.CalculatorProblem& problem
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] valuetype Homework2IL.CalculatorOperation operation,
      [1] int32 val1,
      [2] int32 val2,
      [3] bool V_3,
      [4] valuetype Homework2IL.HundledExceptions V_4,
      [5] bool V_5,
      [6] bool V_6
    )

    // [10 13 - 10 47]
    IL_0001: ldarg.1      // problem
    IL_0002: newobj       instance void Homework2IL.CalculatorProblem::.ctor()
    IL_0007: stind.ref

    // [11 13 - 11 39]
    IL_0008: ldarg.0      // args
    IL_0009: call         bool Homework2IL.Parser::CheckArgLength(class [System.Runtime]System.Collections.Generic.IReadOnlyCollection`1<string>)
    IL_000e: ldc.i4.0
    IL_000f: ceq
    IL_0011: stloc.3      // V_3

    IL_0012: ldloc.3      // V_3
    IL_0013: brfalse.s    IL_001a

    // [11 40 - 11 80]
    IL_0015: ldc.i4.2
    IL_0016: stloc.s      V_4
    IL_0018: br.s         IL_0068

    // [12 13 - 12 70]
    IL_001a: ldarg.0      // args
    IL_001b: ldc.i4.1
    IL_001c: ldelem.ref
    IL_001d: ldloca.s     operation
    IL_001f: call         bool Homework2IL.Parser::TryParseOperationOrQuit(string, valuetype Homework2IL.CalculatorOperation&)
    IL_0024: ldc.i4.0
    IL_0025: ceq
    IL_0027: stloc.s      V_5

    IL_0029: ldloc.s      V_5
    IL_002b: brfalse.s    IL_0032

    // [12 71 - 12 111]
    IL_002d: ldc.i4.1
    IL_002e: stloc.s      V_4
    IL_0030: br.s         IL_0068

    // [13 13 - 13 104]
    IL_0032: ldarg.0      // args
    IL_0033: ldc.i4.0
    IL_0034: ldelem.ref
    IL_0035: ldloca.s     val1
    IL_0037: call         bool Homework2IL.Parser::TryParseArgOrQuit(string, int32&)
    IL_003c: brfalse.s    IL_004d
    IL_003e: ldarg.0      // args
    IL_003f: ldc.i4.2
    IL_0040: ldelem.ref
    IL_0041: ldloca.s     val2
    IL_0043: call         bool Homework2IL.Parser::TryParseArgOrQuit(string, int32&)
    IL_0048: ldc.i4.0
    IL_0049: ceq
    IL_004b: br.s         IL_004e
    IL_004d: ldc.i4.1
    IL_004e: stloc.s      V_6

    IL_0050: ldloc.s      V_6
    IL_0052: brfalse.s    IL_0059

    // [14 17 - 14 60]
    IL_0054: ldc.i4.3
    IL_0055: stloc.s      V_4
    IL_0057: br.s         IL_0068

    // [15 13 - 15 68]
    IL_0059: ldarg.1      // problem
    IL_005a: ldloc.1      // val1
    IL_005b: ldloc.0      // operation
    IL_005c: ldloc.2      // val2
    IL_005d: newobj       instance void Homework2IL.CalculatorProblem::.ctor(int32, valuetype Homework2IL.CalculatorOperation, int32)
    IL_0062: stind.ref

    // [16 13 - 16 46]
    IL_0063: ldc.i4.0
    IL_0064: stloc.s      V_4
    IL_0066: br.s         IL_0068

    // [17 9 - 17 10]
    IL_0068: ldloc.s      V_4
    IL_006a: ret

  } // end of method Parser::ParseArguments

  .method private hidebysig static bool
    TryParseOperationOrQuit(
      string arg,
      [out] valuetype Homework2IL.CalculatorOperation& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] valuetype Homework2IL.CalculatorOperation V_0,
      [1] bool V_1
    )

    // [20 9 - 20 10]
    IL_0000: nop

    // [21 13 - 28 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [21 29 - 28 14]
    IL_0004: nop

    IL_0005: ldarg.0      // arg
    IL_0006: ldstr        "+"
    IL_000b: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldarg.0      // arg
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_003f
    IL_001f: ldarg.0      // arg
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0043
    IL_002c: ldarg.0      // arg
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_0047
    IL_0039: br.s         IL_004b

    // [23 24 - 23 48]
    IL_003b: ldc.i4.1
    IL_003c: stloc.0      // V_0
    IL_003d: br.s         IL_004f

    // [24 24 - 24 49]
    IL_003f: ldc.i4.2
    IL_0040: stloc.0      // V_0
    IL_0041: br.s         IL_004f

    // [25 24 - 25 52]
    IL_0043: ldc.i4.3
    IL_0044: stloc.0      // V_0
    IL_0045: br.s         IL_004f

    // [26 24 - 26 50]
    IL_0047: ldc.i4.4
    IL_0048: stloc.0      // V_0
    IL_0049: br.s         IL_004f

    // [27 22 - 27 23]
    IL_004b: ldc.i4.0
    IL_004c: stloc.0      // V_0
    IL_004d: br.s         IL_004f

    IL_004f: ldc.i4.1
    IL_0050: brtrue.s     IL_0053

    // [21 13 - 28 15]
    IL_0052: nop

    IL_0053: ldarg.1      // operation
    IL_0054: ldloc.0      // V_0
    IL_0055: stind.i1

    // [30 13 - 30 35]
    IL_0056: ldarg.1      // operation
    IL_0057: ldind.u1
    IL_0058: ldc.i4.0
    IL_0059: cgt.un
    IL_005b: stloc.1      // V_1
    IL_005c: br.s         IL_005e

    // [31 9 - 31 10]
    IL_005e: ldloc.1      // V_1
    IL_005f: ret

  } // end of method Parser::TryParseOperationOrQuit

  .method private hidebysig static bool
    CheckArgLength(
      class [System.Runtime]System.Collections.Generic.IReadOnlyCollection`1<string> args
    ) cil managed
  {
    .maxstack 2

    ldarg.0  
    ldlen
    ldc.i4.3
    ceq
    brfalse.s    message
    ldc.i4.1
    ret
    message: ldstr        "The program requires 3 arguments, but was {0}"
    ldarg.0
    ldlen
    box          [System.Runtime]System.Int32
    call         string [System.Runtime]System.String::Format(string, object)
    call         void [System.Console]System.Console::WriteLine(string)
    ldc.i4.0
    ret

  } // end of method Parser::CheckArgLength

  .method private hidebysig static bool
    TryParseArgOrQuit(
      string arg,
      [out] int32& val
    ) cil managed
  {
    .maxstack 2

    ldarg.0      // arg
    ldarg.1      // val
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    brfalse.s    message
    ldc.i4.1
    ret
    message: ldstr        "Value is not int: "
    ldarg.0      // arg
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)
    IL_0021: ldc.i4.0
    IL_0026: ret
  } 
} 
