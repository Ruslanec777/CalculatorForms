using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApplication.Infrastructure
{
    public abstract class MathObject : IMathObject
    {
        public TypesMathItems TypesMathObjects { get; set; }
        public PrioritiesOperation PrioritiesOperation { get; set; }
        public int NumberInLine { get; set; }


        public abstract List<TypesMathItems> ValidTypesOnLeft { get; }
        public abstract List<TypesMathItems> ValidTypesOnRight { get; }
        public IMathAction MathActionParent { get; set; }
        public IMathObject PreviousElement { get; set; }

        public MathObject(IMathAction mathActionParent)
        {
            MathActionParent = mathActionParent;
        }
        
    }
}
