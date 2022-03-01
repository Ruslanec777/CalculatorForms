using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using CalculatorApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Models.MathFunctions
{
    public class MathFunction : MathObject
    {
        public MathFunction(IMathAction mathActionParent , string SymbolOfFunc) : base(mathActionParent)
        {
        }

        public TypesMathItems TypesMathItems { get; set; }

        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();

        public MathFunction()
        {

        }


    }
}
