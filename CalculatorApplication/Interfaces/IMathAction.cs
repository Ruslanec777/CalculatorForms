using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Interfaces
{
    public interface IExpression
    {
        void Add(IMathObject mathObject);
        IMathObject Last();
        void Clear();
        IMathObject GetPreviousElement(IMathObject mathObject);
        void RemovePreviousElement(IMathObject mathObject);
        IMathObject GetNextElement(IMathObject mathObject);
        void RemoveNextElement(IMathObject mathObject);
        void ReplaceMathObject(IMathObject mathObject, IMathObject newMathObject1);
        void Calculate();
        int Count { get; }
    }
}
