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
    public class MathFunction : MathObject
    {
        public MathFunction(IMathAction mathActionParent , TypesMathItems typesMathItems) : base(mathActionParent)
        {
            TypesMathObjects = typesMathItems;

            switch (TypesMathObjects)
            {
                case TypesMathItems.Number:
                    PrioritiesOperation = PrioritiesOperation.impracticable;
                    break;
                case TypesMathItems.Sum:
                    PrioritiesOperation = PrioritiesOperation.Second;

                    break;
                case TypesMathItems.Sub:
                    PrioritiesOperation = PrioritiesOperation.Second;

                    break;
                case TypesMathItems.Mult:
                    PrioritiesOperation = PrioritiesOperation.First;

                    break;
                case TypesMathItems.Dev:
                    PrioritiesOperation = PrioritiesOperation.First;

                    break;
                case TypesMathItems.Percentage:
                    PrioritiesOperation = PrioritiesOperation.WithoutDelay;

                    break;
                case TypesMathItems.Result:
                    PrioritiesOperation = PrioritiesOperation.WithoutDelay;

                    break;
                default:
                    break;
            }
        }
        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();

    }
}
