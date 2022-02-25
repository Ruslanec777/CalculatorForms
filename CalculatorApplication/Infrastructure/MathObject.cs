using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
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
        public string StringRepresentation
        {
            get
            {
                return Value.ToString();
            }

            set { }
        }
        public abstract List<TypesMathItems> ValidTypesOnLeft { get; }
        public abstract List<TypesMathItems> ValidTypesOnRight { get; }
        public abstract IMathAction MathActionParent { get; set; }
        public IMathObject PreviousElement { get; set; }

        public abstract float GetValue();

        public MathObject(IMathAction mathActionParent)
        {
            MathActionParent=mathActionParent;
        }

        public void AddYourselfToActionQueue()
        {
            PreviousElement = MathActionParent.Actions.LastOrDefault();

            NumberInLine = PreviousElement.NumberInLine + 1;
            MathActionParent.Actions.Add(this);
        }
        public abstract IMathObject StartCalculation();
    }
}
