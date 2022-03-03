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
        public bool isCompletedResult = false;

        //public string Text1;

        public double Value { get; set; }

        public string Text
        {
            get
            {
                return Value.ToString();
            }

            set
            {
                Value = Convert.ToDouble(value);
            }
        }

        public Number(IExpression mathActionParent) : base(mathActionParent, PrioritiesOperation.impracticable)
        {
            Text = "0";
        }

        public Number(IExpression mathActionParent, string text) : this(mathActionParent)
        {
            Text = text;
        }

        public Number(IExpression mathActionParent, string text, bool isCompletedResult) : base(mathActionParent, PrioritiesOperation.impracticable)
        {
            Text = text;
            this.isCompletedResult = isCompletedResult;
        }

        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();

    }
}
