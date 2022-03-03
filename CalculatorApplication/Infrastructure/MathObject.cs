using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using System.Collections.Generic;

namespace CalculatorApplication.Infrastructure
{
    public abstract class MathObject : IMathObject
    {
        public TypesMathItems TypesMathObjects { get; set; }
        public PrioritiesOperation PrioritiesOperation { get; set; }
        public int NumberInLine { get; set; }


        public abstract List<TypesMathItems> ValidTypesOnLeft { get; }
        public abstract List<TypesMathItems> ValidTypesOnRight { get; }
        public IExpression MathActionParent { get; set; }

        public MathObject(IExpression mathActionParent)
        {
            MathActionParent = mathActionParent;
            NumberInLine = MathActionParent.Count == 0 ? 0 : MathActionParent.Last().NumberInLine + 1;

        }

        protected MathObject(IExpression mathActionParent, PrioritiesOperation prioritiesOperation) : this(mathActionParent)
        {
            PrioritiesOperation = prioritiesOperation;
        }

        protected MathObject(IExpression mathActionParent, PrioritiesOperation prioritiesOperation, int numberInLine) : this(mathActionParent, prioritiesOperation)
        {
            NumberInLine = numberInLine;
        }
    }
}
