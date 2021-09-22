// Type: HomeWork.Calculator 
// Assembly: Homework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DA6C4637-1FAE-489E-AA7F-591995C695BF
// Location: C:\Users\user\Desktop\dotNetRepository\HomeWorkRepository\Homework\Homework\bin\Debug\net5.0\Homework.dll
// Sequence point data from C:\Users\user\Desktop\dotNetRepository\HomeWorkRepository\Homework\Homework\bin\Debug\net5.0\Homework.pdb

.class public abstract sealed auto ansi beforefieldinit
  Homework2IL.Calculator
    extends System.Object
{

  .method public hidebysig static int32
    Calculate(
      int32 val1,
      valuetype Homework2IL.CalculatorOperation operation,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result,
      [1] int32 V_1,
      [2] int32 V_2
    )

    // [6 9 - 6 10]
    IL_0000: nop

    // [7 13 - 13 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [7 36 - 13 14]
    IL_0004: nop

    IL_0005: ldarg.1      // operation
    IL_0006: ldc.i4.1
    IL_0007: sub
    IL_0008: switch       (IL_001b, IL_0027, IL_0021)
    IL_0019: br.s         IL_002d

    // [9 45 - 9 56]
    IL_001b: ldarg.0      // val1
    IL_001c: ldarg.2      // val2
    IL_001d: add
    IL_001e: stloc.1      // V_1
    IL_001f: br.s         IL_0033

    // [10 49 - 10 60]
    IL_0021: ldarg.0      // val1
    IL_0022: ldarg.2      // val2
    IL_0023: mul
    IL_0024: stloc.1      // V_1
    IL_0025: br.s         IL_0033

    // [11 46 - 11 57]
    IL_0027: ldarg.0      // val1
    IL_0028: ldarg.2      // val2
    IL_0029: sub
    IL_002a: stloc.1      // V_1
    IL_002b: br.s         IL_0033

    // [12 22 - 12 33]
    IL_002d: ldarg.0      // val1
    IL_002e: ldarg.2      // val2
    IL_002f: div
    IL_0030: stloc.1      // V_1
    IL_0031: br.s         IL_0033

    IL_0033: ldc.i4.1
    IL_0034: brtrue.s     IL_0037

    // [7 13 - 13 15]
    IL_0036: nop

    IL_0037: ldloc.1      // V_1
    IL_0038: stloc.0      // result

    // [15 13 - 15 27]
    IL_0039: ldloc.0      // result
    IL_003a: stloc.2      // V_2
    IL_003b: br.s         IL_003d

    // [16 9 - 16 10]
    IL_003d: ldloc.2      // V_2
    IL_003e: ret

  } // end of method Calculator::Calculate
} // end of class HomeWork.Calculator
