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
      [3] valuetype Homework2IL.HundledExceptions exception
    )

    ldarg.1      // problem
    newobj       instance void Homework2IL.CalculatorProblem::.ctor()
    stind.ref

    ldarg.0      // args
    call         bool Homework2IL.Parser::CheckArgLength(string[])
    ldc.i4.0
    ceq
    brfalse.s    TryParseOperationOrQuit

    
    ldc.i4.2
    stloc.s      exception
    br.s         return

    TryParseOperationOrQuit: ldarg.0      // args
    ldc.i4.1
    ldelem.ref
    ldloca.s     operation
    call         bool Homework2IL.Parser::TryParseOperationOrQuit(string, valuetype Homework2IL.CalculatorOperation&)
    ldc.i4.0
    ceq

    brfalse.s    TryParseArgOrQuit

    ldc.i4.1
    stloc.s      exception
    br.s         return

    TryParseArgOrQuit: ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    ldloca.s     val1
    call         bool Homework2IL.Parser::TryParseArgOrQuit(string, int32&)
    brfalse.s    operation
    ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    ldloca.s     val2
    call         bool Homework2IL.Parser::TryParseArgOrQuit(string, int32&)
    ldc.i4.0
    ceq
    br.s         create
    operation: ldc.i4.1

    create: brfalse.s    createCaclculatorProblem
    ldc.i4.3
    stloc.s      exception
    br.s         return

    createCaclculatorProblem: ldarg.1      // problem
    ldloc.1      // val1
    ldloc.0      // operation
    ldloc.2      // val2
    newobj       instance void Homework2IL.CalculatorProblem::.ctor(int32, valuetype Homework2IL.CalculatorOperation, int32)
    stind.ref

    ldc.i4.0
    stloc.s      exception
    br.s         return

    return: ldloc.s      exception  ret

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

    ldarg.0      // arg
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     plus
    
    ldarg.0      // arg   
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     minus
    
    ldarg.0      // arg 
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     multiply
    
    ldarg.0      // arg  
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     divide  
    br.s         wrongOperation

    plus: ldc.i4.1
    stloc.0      // V_0
    br.s         ret_true

    minus: ldc.i4.2
    stloc.0      // V_0
    br.s         ret_true

    multiply: ldc.i4.3
    stloc.0      // V_0
    br.s         ret_true

    divide: ldc.i4.4
    stloc.0      // V_0
    br.s         ret_true

    wrongOperation: ldc.i4.0
    stloc.0      // V_0

    ret_true: ldc.i4.1
    
    brtrue.s     operation

    operation: ldarg.1      // operation
    ldloc.0      // V_0
    stind.i1

    ldarg.1      // operation
    ldind.u1
    ldc.i4.0
    cgt.un
    stloc.1      // V_1
    br.s         return

    return: ldloc.1      // V_1
    ret

  } // end of method Parser::TryParseOperationOrQuit

  .method private hidebysig static bool
    CheckArgLength(
      string[] args
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
