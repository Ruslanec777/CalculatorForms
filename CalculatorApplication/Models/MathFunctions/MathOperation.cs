using CalcLibrary.Enums;
using CalcLibrary.Interfaces;
using CalculatorApplication.Infrastructure;
using CalculatorApplication.Models.ActionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Models.MathFunctions
{
    public class MathOperation : MathObject
    {
        public MathOperation(IExpression mathActionParent, TypesMathItems typesMathItems) : base(mathActionParent)
        {
            TypesMathObjects = typesMathItems;

            if (MathActionParent.GetPreviousElement(this).TypesMathObjects != TypesMathItems.Number)
            {
                MathActionParent.RemovePreviousElement(this);
            }

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

                default:
                    throw new Exception();
            }
        }
        public override List<TypesMathItems> ValidTypesOnLeft => throw new NotImplementedException();

        public override List<TypesMathItems> ValidTypesOnRight => throw new NotImplementedException();

        public void Run()
        {
            Number numberPrev;
            Number numberNext;
            Number newNumber;

            switch (TypesMathObjects)
            {
                case TypesMathItems.Sum:
                    GetPrevAndNext(out numberPrev, out numberNext);

                    newNumber = new Number(MathActionParent, (numberPrev.Value + numberNext.Value).ToString());

                    CorrectionExpression(newNumber);

                    break;

                case TypesMathItems.Sub:
                    GetPrevAndNext(out numberPrev, out numberNext);

                    newNumber = new Number(MathActionParent, (numberPrev.Value - numberNext.Value).ToString());

                    CorrectionExpression(newNumber);

                    break;

                case TypesMathItems.Mult:
                    GetPrevAndNext(out numberPrev, out numberNext);
                    newNumber = new Number(MathActionParent, (numberPrev.Value * numberNext.Value).ToString());

                    CorrectionExpression(newNumber);

                    break;

                case TypesMathItems.Dev:
                    GetPrevAndNext(out numberPrev, out numberNext);

                    newNumber = new Number(MathActionParent, (numberPrev.Value / numberNext.Value).ToString());

                    CorrectionExpression(newNumber);

                    break;

                case TypesMathItems.Percentage:
                    numberPrev = (Number)MathActionParent.GetPreviousElement(this);
                    newNumber = new Number(MathActionParent, (numberPrev.Value / 100).ToString());

                    MathActionParent.RemovePreviousElement(this);
                    MathActionParent.ReplaceMathObject(this, newNumber);
                    break;

                default:
                    throw new Exception();
            }
        }

        private void CorrectionExpression(Number newNumber)
        {
            MathActionParent.RemovePreviousElement(this);
            MathActionParent.RemoveNextElement(this);

            newNumber.isCompletedResult=true;

            MathActionParent.ReplaceMathObject(this, newNumber);
        }

        private void GetPrevAndNext(out Number numberPrev, out Number numberNext)
        {
            numberPrev = (Number)MathActionParent.GetPreviousElement(this);
            numberNext = (Number)MathActionParent.GetNextElement(this);
        }
    }
}
