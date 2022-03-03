using CalcLibrary.Interfaces;
using CalculatorApplication.Models.ActionClasses;
using CalculatorApplication.Models.MathFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Models
{
    public class Expression : IExpression
    {
        private List<IMathObject> _actions { get; set; }

        public int Count
        {
            get
            {
                return _actions.Count;
            }
        }

        public Expression()
        {
            _actions = new List<IMathObject>();

            Add(new Number(this, "0"));
        }

        public void Add(IMathObject mathObject)
        {
            _actions.Add(mathObject);
        }

        public IMathObject Last()
        {
            return _actions.Last();
        }

        public void Clear()
        {
            _actions.Clear();
        }

        public IMathObject GetPreviousElement(IMathObject mathObject)
        {
            return _actions.Where(x => x.NumberInLine < mathObject.NumberInLine).LastOrDefault();
        }

        public void RemovePreviousElement(IMathObject mathObject)
        {
            _actions.Remove(GetPreviousElement(mathObject));
        }

        public IMathObject GetNextElement(IMathObject mathObject)
        {
            return _actions.Where(x => x.NumberInLine > mathObject.NumberInLine).FirstOrDefault();
        }

        public void RemoveNextElement(IMathObject mathObject)
        {
            _actions.Remove(GetNextElement(mathObject));
        }

        public void ReplaceMathObject(IMathObject mathObject, IMathObject newMathObject)
        {
            newMathObject.NumberInLine=mathObject.NumberInLine;

            _actions.Insert(_actions.IndexOf(mathObject), newMathObject);
            _actions.Remove(mathObject);
        }

        public void Calculate()
        {
            var firstPrioriteActions = _actions.Where(x => x.PrioritiesOperation == Enums.PrioritiesOperation.First).ToList();

            MathOperation mathOperation;

            if (firstPrioriteActions != null)
            {

                foreach (var item in firstPrioriteActions)
                {
                    mathOperation = (MathOperation)item;
                    mathOperation.Run();
                }
            }

            var secondPrioriteActions = _actions.Where(x => x.PrioritiesOperation == Enums.PrioritiesOperation.Second).ToList();

            if (firstPrioriteActions != null)
            {
                foreach (var item in secondPrioriteActions)
                {
                    mathOperation = (MathOperation)item;
                    mathOperation.Run();
                }
            }
        }




    }
}
