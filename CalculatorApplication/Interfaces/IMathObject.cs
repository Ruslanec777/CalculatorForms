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
        public int NumberInLine { get; set; }
        public string StringRepresentation { get; set; }

        /// <summary>
        /// Допустимые типы слева
        /// </summary>
        public List<TypesMathItems> ValidTypesOnLeft { get;  }

        /// <summary>
        /// Допустимые типы справа
        /// </summary>
        public List<TypesMathItems> ValidTypesOnRight { get;  }
        public abstract float GetValue();
    }
}
