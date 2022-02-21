using CalcLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Models
{
    public class MathAction :IMathAction
    {
        public List<IMathObject> _actions { get; set; }
    }
}
