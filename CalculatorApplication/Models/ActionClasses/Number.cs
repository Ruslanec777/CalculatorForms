using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using CalculatorApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Models.ActionClasses
{
    public class Number : MathObject
    {
        public Number(IMathAction mathActionParent, string text) : base(mathActionParent)
        {
            Value = double.Parse(text);

        }

        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();

        public override IMathAction MathActionParent { get; set; }

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
