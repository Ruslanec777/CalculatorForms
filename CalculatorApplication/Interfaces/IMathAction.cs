using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Interfaces
{
    public interface IMathAction
    {
        void Add(IMathObject mathObject);
        IMathObject Last();
        void Clear();
    }
}
