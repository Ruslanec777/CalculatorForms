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
        public bool isCompletedResult= false;

        //public string Text1;

        public Number(IMathAction mathActionParent) : base(mathActionParent)
        {
            Text = "0";
        }

        public Number(IMathAction mathActionParent, string text): this(mathActionParent)
        {
            Text = text;
        }

        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();


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
