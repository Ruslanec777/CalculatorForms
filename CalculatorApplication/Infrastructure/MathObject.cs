using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApplication.Infrastructure
{
    public abstract class MathObject : IMathObject
    {

        public double Value { get; set; }
        public TypesMathItems TypesMathObjects { get; set; }
        public PrioritiesOperation PrioritiesOperation { get; set; }
        public int NumberInLine { get; set; }

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
        public abstract List<TypesMathItems> ValidTypesOnLeft { get; }
        public abstract List<TypesMathItems> ValidTypesOnRight { get; }
        public IMathAction MathActionParent { get; set; }
        public IMathObject PreviousElement { get; set; }

        public abstract float GetValue();

        public MathObject(IMathAction mathActionParent)
        {
            MathActionParent = mathActionParent;
        }
        public abstract IMathObject StartCalculation();
    }
}
