using CalcLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Models.MathFunctions
{
    internal class SumAct : MathObject
    {
        public override List<TypesMathItems> ValidTypesOnLeft { get; }=new List<TypesMathItems>() { TypesMathItems.Number };
        public override List<TypesMathItems> ValidTypesOnRight { get ; }

        public override float GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
