// Type: HomeWork.CalculatorProblem 
// Assembly: Homework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA6C4637-1FAE-489E-AA7F-591995C695BF
// Location: C:\Users\user\Desktop\dotNetRepository\HomeWorkRepository\Homework\Homework\bin\Debug\net5.0\Homework.dll
// Sequence point data from C:\Users\user\Desktop\dotNetRepository\HomeWorkRepository\Homework\Homework\bin\Debug\net5.0\Homework.pdb

.class public auto ansi beforefieldinit
  Homework2IL.CalculatorProblem
    extends System.Object
{

  .field private initonly int32 '<Val1>k__BackingField'
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState)
      = (01 00 00 00 00 00 00 00 ) // ........
      // int32(0) // 0x00000000

  .field private initonly int32 '<Val2>k__BackingField'
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState)
      = (01 00 00 00 00 00 00 00 ) // ........
      // int32(0) // 0x00000000

  .field private initonly valuetype Homework2IL.CalculatorOperation '<Operation>k__BackingField'
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .custom instance void [System.Runtime]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggerBrowsableState)
      = (01 00 00 00 00 00 00 00 ) // ........
      // int32(0) // 0x00000000

  .method public hidebysig specialname instance int32
    get_Val1() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 8

    // [5 27 - 5 31]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        int32 Homework2IL.CalculatorProblem::'<Val1>k__BackingField'
    IL_0006: ret

  } // end of method CalculatorProblem::get_Val1

  .method public hidebysig specialname instance int32
    get_Val2() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 8

    // [6 27 - 6 31]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        int32 Homework2IL.CalculatorProblem::'<Val2>k__BackingField'
    IL_0006: ret

  } // end of method CalculatorProblem::get_Val2

  .method public hidebysig specialname instance valuetype Homework2IL.CalculatorOperation
    get_Operation() cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 8

    // [7 48 - 7 52]
    IL_0000: ldarg.0      // this
    IL_0001: ldfld        valuetype Homework2IL.CalculatorOperation Homework2IL.CalculatorProblem::'<Operation>k__BackingField'
    IL_0006: ret

  } // end of method CalculatorProblem::get_Operation

  .method public hidebysig specialname rtspecialname instance void
    .ctor(
      int32 val1,
      valuetype Homework2IL.CalculatorOperation operation,
      int32 val2
    ) cil managed
  {
    .maxstack 8

    // [9 9 - 9 84]
    IL_0000: ldarg.0      // this
    IL_0001: call         instance void System.Object::.ctor()
    IL_0006: nop

    // [10 9 - 10 10]
    IL_0007: nop

    // [11 13 - 11 25]
    IL_0008: ldarg.0      // this
    IL_0009: ldarg.1      // val1
    IL_000a: stfld        int32 Homework2IL.CalculatorProblem::'<Val1>k__BackingField'

    // [12 13 - 12 35]
    IL_000f: ldarg.0      // this
    IL_0010: ldarg.2      // operation
    IL_0011: stfld        valuetype Homework2IL.CalculatorOperation Homework2IL.CalculatorProblem::'<Operation>k__BackingField'

    // [13 13 - 13 25]
    IL_0016: ldarg.0      // this
    IL_0017: ldarg.3      // val2
    IL_0018: stfld        int32 Homework2IL.CalculatorProblem::'<Val2>k__BackingField'

    // [14 9 - 14 10]
    IL_001d: ret

  } // end of method CalculatorProblem::.ctor

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    // [16 9 - 16 35]
    IL_0000: ldarg.0      // this
    IL_0001: call         instance void System.Object::.ctor()
    IL_0006: nop

    // [17 9 - 17 10]
    IL_0007: nop

    // [17 11 - 17 12]
    IL_0008: ret

  } // end of method CalculatorProblem::.ctor

  .property instance int32 Val1()
  {
    .get instance int32 Homework2IL.CalculatorProblem::get_Val1()
  } // end of property CalculatorProblem::Val1

  .property instance int32 Val2()
  {
    .get instance int32 Homework2IL.CalculatorProblem::get_Val2()
  } // end of property CalculatorProblem::Val2

  .property instance valuetype Homework2IL.CalculatorOperation Operation()
  {
    .get instance valuetype Homework2IL.CalculatorOperation Homework2IL.CalculatorProblem::get_Operation()
  } // end of property CalculatorProblem::Operation
} // end of class HomeWork.CalculatorProblem
