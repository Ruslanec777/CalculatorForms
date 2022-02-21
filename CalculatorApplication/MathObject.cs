using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using System.Collections.Generic;

namespace CalcLibrary.Models
{
    public abstract class MathObject : IMathObject
    {
        private float Value { get; set; }
        public TypesMathItems TypesMathObjects { get; set; }
        public PrioritiesOperation PrioritiesOperation { get; set; }
        public int NumberInLine { get; set; }
        public string StringRepresentation { get; set; }
        public abstract List<TypesMathItems> ValidTypesOnLeft { get; }
        public abstract List<TypesMathItems> ValidTypesOnRight { get; }

        public abstract float GetValue();
    }
}
