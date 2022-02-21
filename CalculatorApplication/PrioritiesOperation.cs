using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Enums
{
    /// <summary>
    /// приоритет выше ,чем меньше int у enum
    /// </summary>
    public enum PrioritiesOperation
    {
        /// <summary>
        /// ( )
        /// </summary>
        Brackets,
        /// <summary>
        /// 1/x ,x^2 , √x ,%
        /// </summary>
        Primary,

        /// <summary>
        /// * , /
        /// </summary>
        Multiplicative,

        /// <summary>
        /// + ,-
        /// </summary>
        Additive

    }
}
