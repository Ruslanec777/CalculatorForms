using CalcLibrary.Interfaces;
using CalculatorApplication.Models.ActionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Models
{
    public class MathAction :IMathAction
    {
        private List<IMathObject> _actions { get; set; }

        public MathAction()
        {
            _actions = new List<IMathObject>();

            Add( new Number (this ,"0" )) ;
        }

        public void Add(IMathObject mathObject)
        {
            mathObject.NumberInLine = _actions.Count==0 ? 0 : _actions.Last().NumberInLine + 1;
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
    }
}
