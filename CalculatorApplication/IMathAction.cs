using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Interfaces
{
    internal interface IMathAction
    {
        List<IMathObject> _actions { get; set; }
    }
}
