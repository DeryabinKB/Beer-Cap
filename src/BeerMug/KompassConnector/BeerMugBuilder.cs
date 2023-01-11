using BeerMug.Model;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasConnector
{
    /// <summary>
    /// Класс построения пивной кружки.
    /// </summary>
    public class BeerMugBuilder
    {
        /// <summary>
        /// Компас коннектор.
        /// </summary>
        private KompasConnector _connector = new KompasConnector();

        /// <summary>
        /// Построение кружки по её параметрам.
        /// </summary>
        /// <param name="mugParameters">Параметры пивной кружки.</param>
        /// <param name="shapeType">Тип крышки пивной кружки.</param>
        public void Builder(MugParameters mugParameters, string shapeType)
        {
            _connector.StartKompas();
            _connector.CreateDocument();
            _connector.SetProperties();
            var upperBottom = mugParameters.HighBottomDiametr/2;
            var neck = mugParameters.MugNeckDiametr/2;
            var bottomThickness = mugParameters.BottomThickness;
            var high = mugParameters.High;
            var wallThickness = mugParameters.WallThickness/2;
            var lowerBottom = mugParameters.BelowBottomRadius/2;
            BuildBottom(lowerBottom, upperBottom, bottomThickness);
            if (shapeType == "Faceted shape")
            {
                BuildFacetedBody(upperBottom, bottomThickness, high, wallThickness, neck);
            }
            if (shapeType == "Round shape")
            {
                BuildRoundBody(upperBottom, bottomThickness, high, wallThickness, neck);
            }
            BuildHandle(high, neck, bottomThickness);
            _connector.Fillet(wallThickness/5);
        }

        /// <summary>
        /// Построение основания пивной кружки.
        /// </summary>
        /// <param name="lowerBottom">Нижний радиус пивной кружки.</param>
        /// <param name="upperBottom">Верхний радиус пивной кружки.</param>
        /// <param name="bottomThickness">Толщина дна.</param>
        private void BuildBottom(double lowerBottom, double upperBottom, double bottomThickness)
        {
            //Осевая линия
            var centralStart = new Point2D(0, -250);
            var centralEnd = new Point2D(0, 250);
            //Создание скетча на осях
            var sketch = _connector.CreateSketch(2);
            sketch.CreateLineSeg(centralStart, centralEnd, 3);
            //Нижняя прямая
            var pointBelow = new Point2D(0, 0);
            var pointBelowEnd = new Point2D(lowerBottom, 0);
            var pointBelowBezier = new Point2D(lowerBottom, 0);
            var pointUpperBezier = new Point2D(upperBottom, -bottomThickness);
            var check = lowerBottom + (upperBottom - lowerBottom) / 2;
            var pointMiddle = new Point2D(check, bottomThickness / 20);
            sketch.CreateLineSeg(pointBelow, pointBelowEnd, 1);
            sketch.ArcBy3Point(pointBelowBezier, pointMiddle, pointUpperBezier);
            sketch.EndEdit();
            _connector.ExtrudeRotation360(sketch);            
        }

        /// <summary>
        /// Построение тела пивной кружки.
        /// </summary>
        /// <param name="upperBottom">Верхний радиус дна кружки.</param>
        /// <param name="bottomThickness">Нижний радиус дна кружки.</param>
        /// <param name="high">Высота кружки.</param>
        /// <param name="wallThickness">Толщина стенок кружки.</param>
        /// <param name="neck">Радиус горла кружки.</param>
        private void BuildRoundBody(double upperBottom, double bottomThickness, double high, double wallThickness, double neck)
        {
            // Построение основы кружки
            //Создание осевой линии
            var centralStart = new Point2D(0, -250);
            var centralEnd = new Point2D(0, 250);
            // Переменная для дуги
            var atMiddle = -upperBottom*1.2;
            // Переменные дуги на верхнем основании дна
            var pointStart = new Point2D(upperBottom, -bottomThickness);
            var pointMiddle = new Point2D(-atMiddle, atMiddle);
            var pointEnd = new Point2D(upperBottom, -high);
            // Создание скетча
            var sketch = _connector.CreateSketch(2);
            ////Построение осевой линии
            sketch.CreateLineSeg(centralStart, centralEnd, 3);
            ////Создание дуг
            sketch.ArcBy3Point(pointStart, pointMiddle, pointEnd);
            sketch.EndEdit();
            _connector.ExtrudeRotation360(sketch);
            var atMiddle2 = upperBottom * 1.1;
            //Переменные внутренней стенки кружки
            var insideStart = new Point2D(upperBottom - wallThickness, -bottomThickness);
            var insadeMiddle = new Point2D(atMiddle2, -atMiddle2);
            var insideEnd = new Point2D(upperBottom - wallThickness, -high);
            sketch = _connector.CreateSketch(2);
            sketch.CreateLineSeg(centralStart, centralEnd, 3);
            sketch.ArcBy3Point(insideStart, insadeMiddle, insideEnd);
            sketch.EndEdit();
            _connector.CutExtrudeRotation(sketch, 360);
        }

        /// <summary>
        /// Построение гранёной пивной кружки.
        /// </summary>
        /// <param name="upperBottom">Радиус верхнего дна кружки.</param>
        /// <param name="bottomThickness">Толщина дна кружки.</param>
        /// <param name="high">Высота кружки.</param>
        /// <param name="wallThickness">Толщина стенок кружки.</param>
        /// <param name="neck">Радиус горла кружки.</param>
        private void BuildFacetedBody(double upperBottom, double bottomThickness, double high, double wallThickness, double neck)
        {
            BuildRoundBody(upperBottom, bottomThickness, high, wallThickness, neck);
            KompasSketch sketch = _connector.CreateSketch(3, high);
            //Дистанция от середины окружности, вырезающих грани у отвертки.
            if (high <= 110)
            {
                for (int i = 0; i < 360; i += 20)
                {
                    var pointOne = new Point2D(_connector.CartesianFromPolar(true, neck + 15, i),
                        _connector.CartesianFromPolar(false, neck + 15, i));
                    sketch.CreateCircle(pointOne, 10);
                }
            }
            if (high > 110 && high <= 140)
            {
                for (int i = 0; i < 360; i += 20)
                {
                    var pointOne = new Point2D(_connector.CartesianFromPolar(true, neck + 16, i),
                        _connector.CartesianFromPolar(false, neck + 16, i));
                    sketch.CreateCircle(pointOne, 10);
                }
            }
            if (high > 140)
            {
                for (int i = 0; i < 360; i += 20)
                {
                    var pointOne = new Point2D(_connector.CartesianFromPolar(true, neck + 18, i),
                        _connector.CartesianFromPolar(false, neck + 18, i));
                    sketch.CreateCircle(pointOne, 10);
                }
            }
            sketch.EndEdit();
            _connector.CutExtrude(sketch, 500, true);
        }

        /// <summary>
        /// Создание ручки пивной кружки.
        /// </summary>
        /// <param name="high">Высота пивной кружки.</param>
        /// <param name="neck">Радиус горла пивной кружки.</param>
        /// <param name="bottomThickness">Толщина дна пивной кружки.</param>
        private void BuildHandle(double high, double neck, double bottomThickness)
        {
            double step;
            if (high > 125)
            {
                step = 4.4;
            }
            else if (high < 115)
            {
                step = 2.6;
            }
            else
            {
                step = 3;
            }
            var sketch = _connector.CreateSketch(2, neck + bottomThickness / 2.85 - step);
            var pointOne = new Point2D(0, -high / 2 - 5);
            var PointTwo = new Point2D(100, -high / 2 - 5);
            sketch.CreateLineSeg(pointOne, PointTwo, 3);
            var circleCoord3 = new Point2D(0, -high * 0.17);
            sketch.CreateCircle(circleCoord3, bottomThickness / 2.5);
            sketch.EndEdit();
            if (high > 130)
            {
                _connector.ExtrudeRotation178(sketch);
            }
            else
            {
                _connector.ExtrudeRotation180(sketch);
            }
        }
    }
}
