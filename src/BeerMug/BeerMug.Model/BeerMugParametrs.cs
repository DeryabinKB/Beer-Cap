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
        /// Параметр ширины раковины. 
        /// </summary>
        private double _belowBottomDiametr;

        /// <summary>
        /// Параметр длины раковины.
        /// </summary>
        private double _highBottomDiametr;

        /// <summary>
        /// Параметр глубины.
        /// </summary>
        private double _bottomThickness;

        /// <summary>
        /// 
        /// </summary>
        private double _heightNeckBottom;

        /// <summary>
        /// Параметр сливного отверстия.
        /// </summary>
        private double _wallThickness;

        /// <summary>
        /// Параметр отверстия под кран.
        /// </summary>
        private double _mugNeckDiametr;

        /// <summary>
        /// Словарь перечисления параметров и ошибки
        /// </summary>
        public Dictionary<MugParametersType, string> Parameters =
            new Dictionary<MugParametersType, string>();

        /// <summary>
        /// Экземпляр класса CheckParameter
        /// </summary>
        private BeerMugParametr _parameterCheck = new BeerMugParametr();

        /// <summary>
        /// Возвращает и устанавливает значение ширины раковины
        /// </summary>
        public double BelowBottomDiametr
        {
            get
            {
                return _belowBottomDiametr;
            }
            set
            {
                const double min = 50;
                const double max = 70;
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.BelowBottomDiametr, Parameters);
                if (value + 30 == HighBottomDiametr)
                {
                    Parameters.Add(MugParametersType.BelowBottomDiametr,
                        "Below bottom diametr must be = high bottom diametr + 30");
                    throw new Exception();
                }
                _belowBottomDiametr = value;
            }
        }

        /// <summary>
        /// Верхний диаметр дна
        /// </summary>
        public double HighBottomDiametr
        {
            get
            {
                return _highBottomDiametr;
            }
            set
            {
                const double min = 80;
                const double max = 100;
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.HighBottomDiametr, Parameters);
                if (value - BelowBottomDiametr == 30)
                {
                    Parameters.Add(MugParametersType.HighBottomDiametr,
                        "High bottom diametr must be = below bottom diametr + 30");
                    throw new Exception();
                }
                _highBottomDiametr = value;
            }
        }

        /// <summary>
        /// Толщина дна
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
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.BottomThickness, Parameters);
                if (value * 10 == HeightNeckBottom)
                {
                    Parameters.Add(MugParametersType.BottomThickness,
                        "Bottom thickness must be = Height neck bottom * 0.1");
                    throw new Exception();
                }
                _bottomThickness = value;
            }
        }

        /// <summary>
        /// Высота от горла до дна пивной кружки
        /// </summary>
        public double HeightNeckBottom
        {
            get
            {
                return _heightNeckBottom;
            }
            set
            {
                const double min = 100;
                const double max = 165;
                double valueCheck = value;
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.HeightNeckBottom, Parameters);
                if (valueCheck * 0.1 == BottomThickness)
                {
                    Parameters.Add(MugParametersType.HeightNeckBottom,
                        "Height neck bottom must be = Bottom thickness * 10");
                    throw new Exception();
                }
                _heightNeckBottom = value;
            }
        }

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
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.WallThickness, Parameters);
                _wallThickness = value;
            }
        }

        public double MugNeckDiametr
        {
            get
            {
                return _mugNeckDiametr;
            }

            set
            {
                const double min = 80;
                const double max = 100;
                _parameterCheck.RangeCheck
                    (value, min, max,
                    MugParametersType.MugNeckDiametr, Parameters);
                _mugNeckDiametr = value;
            }
        }
    }
}