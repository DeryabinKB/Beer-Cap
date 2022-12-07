using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
        public enum MugParametersType
        {

            /// <summary>
            /// Диаметр дна кружки снизу.
            /// </summary>
            BelowBottomDiametr,

            /// <summary>
            /// Диаметр дна кружки сверху.
            /// </summary>
            HighBottomDiametr,

            /// <summary>
            /// Толщина дна.
            /// </summary>
            BottomThickness,

            /// <summary>
            /// Высота от горла кружки до дна.
            /// </summary>
            HeightNeckBottom,

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

