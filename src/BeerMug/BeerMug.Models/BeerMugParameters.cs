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
        /// Разница между верхним и нижним диаметрами дна.
        /// </summary>
        private const double _bottomsDiametersDifferences = 30;

        /// <summary>
        /// Во сколько раз высоты кружки больше толщины дна.
        /// </summary>
        private const double _highBiggerBottomThicknessIn = 10;

        /// <summary>
        /// Минимальное значение нижнего дна пивной кружки. 
        /// </summary>
        private const double _belowBottomDiameterMin = 50;

        /// <summary>
        /// Максимальное значение нижнего дна пивной кружки. 
        /// </summary>
        private const double _belowBottomDiameterMax = 70;

        /// <summary>
        /// Диаметр верхнего дна пивной кружки.
        /// </summary>
        private double _highBottomDiameter;

        /// <summary>
        /// Диаметр верхнего дна пивной кружки минимальное значение.
        /// </summary>
        private double _highBottomDiameterMin = 80;

        /// <summary>
        /// Диаметр верхнего дна пивной кружки максимальное значение.
        /// </summary>
        private double _highBottomDiameterMax = 100;

        /// <summary>
        /// Толщина дна пивной кружки .
        /// </summary>
        private double _bottomThickness;

        /// <summary>
        /// Толщина дна пивной кружки минимальное значение.
        /// </summary>
        private double _bottomThicknessMin = 10;

        /// <summary>
        /// Толщина дна пивной кружки максимальное значение.
        /// </summary>
        private string _bottomThicknessMax = "16,5";

        /// <summary>
        /// Высота пивной кружки.
        /// </summary>
        private double _high;

        /// <summary>
        /// Высота пивной кружки минимальное значение.
        /// </summary>
        private double _highMin = 100;

        /// <summary>
        /// Высота пивной кружки максимальное значение.
        /// </summary>
        private double _highMax = 165;

        /// <summary>
        /// Толщина стенок пивной кружки.
        /// </summary>
        private double _wallThickness;

        /// <summary>
        /// Толщина стенок пивной кружки минимальное значение.
        /// </summary>
        private double _wallThicknessMin = 5;

        /// <summary>
        /// Толщина стенок пивной кружки максимальное значение.
        /// </summary>
        private double _wallThicknessMax = 7;

        /// <summary>
        /// Диамитер горла кружки.
        /// </summary>
        private double _mugNeckDiameter;

        /// <summary>
        /// Диамитер горла кружки минимальное значение.
        /// </summary>
        private double _mugNeckDiameterMin = 80;

        /// <summary>
        /// Диамитер горла кружки максимальное значение.
        /// </summary>
        private double _mugNeckDiameterMax = 100;

        /// <summary>
        /// Тип кружки.
        /// </summary>
        private string _mugShapeType = "Round shape";

        /// <summary>
        /// Словарь перечисления ошибки.
        /// </summary>
        public Dictionary<MugParametersType, string> Errors =
            new Dictionary<MugParametersType, string>();

        /// <summary>
        /// Экземпляр класса BeerMugParametr.
        /// </summary>
        private BeerMugParameter _beerMugParameter = new BeerMugParameter();

        /// <summary>
        /// Возврат типа кружки.
        /// </summary>
        public string MugType
        {
            get
            {
                return _mugShapeType;
            }
        }

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
                _beerMugParameter.RangeCheck
                    (value, _belowBottomDiameterMin, _belowBottomDiameterMax,
                    MugParametersType.BelowBottomDiameter, Errors);
               if (value + _bottomsDiametersDifferences != HighBottomDiametr)
                {
                    Errors.Add(MugParametersType.BelowBottomDiameter,
                        "Below bottom diametr must be equal high bottom diametr - " + 
                        _bottomsDiametersDifferences);
                    throw new Exception();
                }
                _belowBottomDiameter = value;
            }
        }

        /// <summary>
        /// Возврат минимального значения диаметра нижнего дна.
        /// </summary>
        public double BelowBottomDiametrMin
        {
            get { return _belowBottomDiameterMin; }
        }

        /// <summary>
        /// Возврат максимального значения диаметра нижнего дна.
        /// </summary>
        public double BelowBottomDiameterMax
        {
            get
            {
                return _belowBottomDiameterMax;
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
                _beerMugParameter.RangeCheck
                    (value, _highBottomDiameterMin, _highBottomDiameterMax,
                    MugParametersType.HighBottomDiameter, Errors);
                if (value != MugNeckDiametr)
                {
                    Errors.Add(MugParametersType.HighBottomDiameter,
                        "High bottom diameter must be equal below bottom diameter + " + 
                        _bottomsDiametersDifferences + " \n " +
                        "High bottom diameter must be equal outer diameter");
                    throw new Exception();
                }
                _highBottomDiameter = value;
            }
        }

        /// <summary>
        /// Возрат минимального значения высоты.
        /// </summary>
        public double HighBottomDiametrMin
        {
            get
            {
                return _highBottomDiameterMin;
            }
        }

        /// <summary>
        /// Возрат максимального значения высоты.
        /// </summary>
        public double HighBottomDiametrMax
        {
            get
            {
                return _highBottomDiameterMax;
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
                var max = 16.5;
                _beerMugParameter.RangeCheck
                    (value, _bottomThicknessMin, max,
                    MugParametersType.BottomThickness, Errors);
                if (value * _highBiggerBottomThicknessIn != High)
                {
                    Errors.Add(MugParametersType.BottomThickness,
                        "Bottom thickness must be equal Height neck bottom / " + _highBiggerBottomThicknessIn);
                    throw new Exception();
                }
                _bottomThickness = value;
            }
        }
        /// <summary>
        /// Возрат минимального значения толщины дна.
        /// </summary>
        public double BottomThicknessMin
        {
            get
            {
                return _bottomThicknessMin;
            }
        }

        /// <summary>
        /// Возрат максимального значения толщины дна.
        /// </summary>
        public string BottomThicknessMax
        {
            get
            {
                return _bottomThicknessMax;
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
                double valueCheck = value;
                _beerMugParameter.RangeCheck
                    (value, _highMin, _highMax,
                    MugParametersType.High, Errors);
                _high = value;
            }
        }

        /// <summary>
        /// Возрат минимального значения высоты.
        /// </summary>
        public double HighMin
        {
            get
            {
                return _highMin;
            }
        }

        /// <summary>
        /// Возрат максимального значения высоты.
        /// </summary>
        public double HighMax
        {
            get
            {
                return _highMax;
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
               _beerMugParameter.RangeCheck
                    (value, WallThicknessMin, WallThicknessMax,
                    MugParametersType.WallThickness, Errors);
                _wallThickness = value;
            }
        }

        /// <summary>
        /// Возрат максимального значения толщины стен.
        /// </summary>
        public double WallThicknessMin
        {
            get
            {
                return _wallThicknessMin;
            }
        }

        /// <summary>
        /// Возрат минимального значения толщины стен.
        /// </summary>
        public double WallThicknessMax
        {
            get
            {
                return _wallThicknessMax;
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
               
                _beerMugParameter.RangeCheck
                    (value, MugNeckDiametrMin, MugNeckDiametrMax,
                    MugParametersType.MugNeckDiametr, Errors);
                _mugNeckDiameter = value;
            }
        }

        /// <summary>
        /// Возрат минимального значения диаметра горла кружки.
        /// </summary>
        public double MugNeckDiametrMin
        {
            get
            {
                return _mugNeckDiameterMin;
            }
        }

        /// <summary>
        /// Возрат максимального значения диаметра горла кружки.
        /// </summary>
        public double MugNeckDiametrMax
        {
            get
            {
                return _mugNeckDiameterMax;
            }
        }
    }
}