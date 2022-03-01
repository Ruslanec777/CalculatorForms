using CalcLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Interfaces
{
    public interface IMathObject
    {
        TypesMathItems TypesMathObjects { get; set; }
        PrioritiesOperation PrioritiesOperation { get; set; }
        int NumberInLine { get; set; }

        IMathAction MathActionParent { get; set; }

        //string Text { get; set; }

        /// <summary>
        /// Допустимые типы слева
        /// </summary>
        List<TypesMathItems> ValidTypesOnLeft { get; }

        /// <summary>
        /// Допустимые типы справа
        /// </summary>
        List<TypesMathItems> ValidTypesOnRight { get; }

        IMathObject PreviousElement { get; set; }

    }
}
