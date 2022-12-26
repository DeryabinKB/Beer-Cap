using BeerMug.Model;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        /// <param name="capType">Тип крышки пивной кружки.</param>
        public void Builder(MugParameters mugParameters, string capType)
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
            if (capType == "Faceted shape")
            {
                BuildFacetedBody(upperBottom, bottomThickness, high, wallThickness, neck);
            }
            if (capType == "Round shape")
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

        private void BuildFacetedBody(double upperBottom, double bottomThickness, double high, double wallThickness, double neck)
        {
            BuildRoundBody(upperBottom, bottomThickness, high, wallThickness, neck);
            //var sketch = _connector.CreateSketch(2, bottomThickness);
            //var pointStart = new Point2D(neck + 5, 0);

            //var pointMiddle = new Point2D(neck, 5);
            //sketch.CreateLineSeg(pointStart, pointMiddle, 3);

            //var pointEnd = new Point2D(neck + 5, 10);
            //sketch.CreateLineSeg(pointMiddle, pointEnd, 3);
            //sketch.EndEdit();
            //_connector.Extrude(sketch, high, true);

            ////var sketchHandleUnevenness = _connector.CreateSketch
            ////    (_ksPart, planeYOZ, out var sketchHandleUnevennessDefinition);
            ////_connector = sketchHandleUnevennessDefinition.BeginEdit();
            //////Дистанция от середины окружности, вырезающих грани у отвертки.
            ////double _radius = 20 / 16 * 23;
            ////for (int i = 0; i < 360; i += 60)
            ////{
            ////    ksDocument2D.ksCircle(CartesianFromPolar(true, _radius, i),
            ////        CartesianFromPolar(false, _radius, i), D, 1);
            ////}
            ////sketchHandleUnevennessDefinition.EndEdit();
            ////_kompasWrapper.CutExtrusion(_ksPart, sketchHandleUnevenness, false,
            ////    Direction_Type.dtReverse, Lh);
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

        /// <summary>
        /// Построение крышки с ручкой кольцом.
        /// </summary>
        /// <param name="high">Высота кружки.</param>
        /// <param name="neck">Радиус горла кружки.</param>
        /// <param name="wallThickness">Толщина стенок кружки.</param>
        private void BuildHandleRingCap(double high, double neck, double wallThickness)
        {
            BuildCapBase(high, neck, wallThickness);
            var sketch = _connector.CreateSketch(3, high);
            var pointAxisX = new Point2D(0, 0);
            var pointAxisY = new Point2D(0, 5);
            sketch.CreateLineSeg(pointAxisX, pointAxisY, 3);
            var circle = new Point2D(neck / 2, 0);
            sketch.CreateCircle(circle, 6);
            sketch.EndEdit();
            _connector.ExtrudeRotation180(sketch);
        }

        /// <summary>
        /// Построение основы крышки.
        /// </summary>
        /// <param name="high">Высота кружки.</param>
        /// <param name="neck">Радиус горла кружки.</param>
        /// <param name="wallThickness">Толщина стен кружки.</param>
        private void BuildCapBase(double high, double neck, double wallThickness)
        {
            var sketch = _connector.CreateSketch(2);
            var pointAxisX = new Point2D(0, -high - 5);
            var pointAxisY = new Point2D(0, -high);
            sketch.CreateLineSeg(pointAxisX, pointAxisY, 3);
            var pointOne = new Point2D(0, -high);
            var pointTwo = new Point2D(neck - wallThickness - 5, -high);
            sketch.CreateLineSeg(pointOne, pointTwo, 1);
            var pointThree = new Point2D(neck - wallThickness - 2, -high + 5);
            sketch.CreateLineSeg(pointTwo, pointThree, 1);
            var pointFour = new Point2D(neck - wallThickness - 0.5, -high - 0.5);
            sketch.CreateLineSeg(pointThree, pointFour, 1);
            var pointFive = new Point2D(neck + 6, -high - 0.5);
            sketch.CreateLineSeg(pointFour, pointFive, 1);
            var pointSix = new Point2D(neck - neck / 3, -high - 5);
            sketch.CreateLineSeg(pointFive, pointSix, 1);
            var pointSeven = new Point2D(0, -high - 8);
            sketch.CreateLineSeg(pointSix, pointSeven, 1);
            sketch.EndEdit();
            _connector.ExtrudeRotation360(sketch);
        }

        /// <summary>
        /// Построение крышки с ручкой выдавленным кругом.
        /// </summary>
        /// <param name="high">Высота кружки.</param>
        /// <param name="neck">Радиус горла кружки.</param>
        /// <param name="wallThickness">Толщина стенок кружки.</param>
        private void BuildHandleCircleCap(double high, double neck, double wallThickness)
        {
            BuildCapBase(high, neck, wallThickness);
            var sketch = _connector.CreateSketch(3, high);
            var pointAxisX = new Point2D(0, 0);
            var pointAxisY = new Point2D(0, 5);
            sketch.CreateLineSeg(pointAxisX, pointAxisY, 3);
            var circle = new Point2D(0, 0);
            sketch.CreateCircle(circle, 6);
            sketch.EndEdit();
            _connector.Extrude(sketch, wallThickness*6, true);
        }
    }
}
