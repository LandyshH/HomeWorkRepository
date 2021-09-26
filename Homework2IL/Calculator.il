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
 
    ldarg.1      // operation
    ldc.i4.1
    sub
    switch       (plus, minus, multiply)
    br.s         divide

    plus: ldarg.0      // val1
    ldarg.2      // val2
    add ret

    multiply: ldarg.0      // val1
    ldarg.2      // val2
    mul ret
   
    minus: ldarg.0      // val1
    ldarg.2      // val2
    sub ret

    divide: ldarg.0 // val1
    ldarg.2      // val2
    div ret
  }
} 
