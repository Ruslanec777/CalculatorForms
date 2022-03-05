using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using CalculatorApplication.Infrastructure;
using System;
using System.Collections.Generic;

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
                if (IsNegativ)
                {
                    return "-" + Value.ToString();
                }
                else
                {
                    return Value.ToString();
                }
            }

            set
            {

                Value = Convert.ToDouble((IsNegativ & value[0]!='-' ? "-" : "") + value);
            }
        }
        /// <summary>
        /// знак числа true ->negativ
        /// </summary>
        public bool IsNegativ { get; set; }

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

        public void ChangeSign()
        {
            IsNegativ = !IsNegativ;
            Value = -1 * Value;
        }

        public void SetPsitive()
        {
            IsNegativ = true;
        }

        public void SetNegative()
        {
            IsNegativ = true;
        }

    }
}
