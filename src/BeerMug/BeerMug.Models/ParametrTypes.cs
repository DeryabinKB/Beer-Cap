using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
    /// <summary>
    /// Перечисление параметров пивной кружки
    /// </summary>
    public enum MugParametersType
    {

        /// <summary>
        /// Диаметр дна кружки снизу.
        /// </summary>
        BelowBottomDiameter,

        /// <summary>
        /// Диаметр дна кружки сверху.
        /// </summary>
        HighBottomDiameter,

        /// <summary>
        /// Толщина дна.
        /// </summary>
        BottomThickness,

        /// <summary>
        /// Высота от горла кружки до дна.
        /// </summary>
        High,

        /// <summary>
        /// Толщина стенок кружки.
        /// </summary>
        WallThickness,

        /// <summary>
        /// Диаметр внешней части горла кружки.
        /// </summary>
        MugNeckDiametr
    }
}
