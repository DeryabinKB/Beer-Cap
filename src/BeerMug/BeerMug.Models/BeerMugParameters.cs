using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
    /// <summary>
    /// Класс параметры пивной кружки.
    /// </summary>
    public class MugParameters
    {
        /// <summary>
        /// Диаметр нижнего дна пивной кружки. 
        /// </summary>
        private double _belowBottomDiameter;

        /// <summary>
        /// Диаметр верхнего дна пивной кружки.
        /// </summary>
        private double _highBottomDiameter;

        /// <summary>
        /// Толщина дна пивной кружки.
        /// </summary>
        private double _bottomThickness;

        /// <summary>
        /// Высота пивной кружки
        /// </summary>
        private double _high;

        /// <summary>
        /// Толщина стенок пивной кружки.
        /// </summary>
        private double _wallThickness;

        /// <summary>
        /// Диамитер горла кружки.
        /// </summary>
        private double _mugNeckDiameter;

        /// <summary>
        /// Словарь перечисления ошибки.
        /// </summary>
        public Dictionary<MugParametersType, string> Errors =
            new Dictionary<MugParametersType, string>();

        /// <summary>
        /// Экземпляр класса BeerMugParametr.
        /// </summary>
        private BeerMugParameter _beerMigParameter = new BeerMugParameter();

        /// <summary>
        /// Установка и возврат значения нижнего дна пивной кружки.
        /// </summary>
        public double BelowBottomRadius
        {
            get
            {
                return _belowBottomDiameter;
            }
            set
            {
                const double min = 50;
                const double max = 70;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.BelowBottomDiameter, Errors);
               if (value + 30 != HighBottomDiametr)
                {
                    Errors.Add(MugParametersType.BelowBottomDiameter,
                        "Below bottom diametr must be equal high bottom diametr - 30");
                    throw new Exception();
                }
                _belowBottomDiameter = value;
            }
        }

        /// <summary>
        /// Установка и возврат значения верхнего дна пивной кружки.
        /// </summary>
        public double HighBottomDiametr
        {
            get
            {
                return _highBottomDiameter;
            }
            set
            {
                const double min = 80;
                const double max = 100;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.HighBottomDiameter, Errors);
                if (value != MugNeckDiametr)
                {
                    Errors.Add(MugParametersType.HighBottomDiameter,
                        "High bottom diametr must be equal below bottom diametr + 30 \n " +
                        "High bottom diametr must be equal outer diametr");
                    throw new Exception();
                }
                _highBottomDiameter = value;
            }
        }

        /// <summary>
        /// Установка и возврат значения толщины дна.
        /// </summary>
        public double BottomThickness
        {
            get
            {
                return _bottomThickness;
            }
            set
            {
                const double min = 10;
                const double max = 16.5;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.BottomThickness, Errors);
                if (value * 10 != High)
                {
                    Errors.Add(MugParametersType.BottomThickness,
                        "Bottom thickness must be equal Height neck bottom * 0.1");
                    throw new Exception();
                }
                _bottomThickness = value;
            }
        }

        /// <summary>
        /// Установка и возврат значения высоты от горла до дна пивной кружки.
        /// </summary>
        public double High
        {
            get
            {
                return _high;
            }
            set
            {
                const double min = 100;
                const double max = 165;
                double valueCheck = value;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.High, Errors);
                _high = value;
            }
        }

        /// <summary>
        /// Установка и возврат значения толщины стенок пивной кружки.
        /// </summary>
        public double WallThickness
        {
            get
            {
                return _wallThickness;
            }
            set
            {
                const double min = 5;
                const double max = 7;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.WallThickness, Errors);
                _wallThickness = value;
            }
        }

        /// <summary>
        /// Установка и возврат значения диаметра горлышка кружки.
        /// </summary>
        public double MugNeckDiametr
        {
            get
            {
                return _mugNeckDiameter;
            }
            set
            {
                const double min = 80;
                const double max = 100;
                _beerMigParameter.RangeCheck
                    (value, min, max,
                    MugParametersType.MugNeckDiametr, Errors);
                _mugNeckDiameter = value;
            }
        }
    }
}