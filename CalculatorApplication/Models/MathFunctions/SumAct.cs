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
    internal class SumAct : MathObject
    {
        public override List<TypesMathItems> ValidTypesOnLeft { get; } = new List<TypesMathItems>() { TypesMathItems.Number };
        public override List<TypesMathItems> ValidTypesOnRight { get; }
        public override IMathAction MathActionParent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override float GetValue()
        {
            throw new NotImplementedException();
        }

        public override IMathObject StartCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
