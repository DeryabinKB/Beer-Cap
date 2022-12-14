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
        public void Builder(MugParameters mugParameters)
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
            BuildBody(upperBottom, bottomThickness, high, wallThickness, neck);
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

        private void BuildBody(double upperBottom, double bottomThickness, double high, double wallThickness, double neck)
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
        /// Создание ручки пивной кружки.
        /// </summary>
        /// <param name="high">Высота пивной кружки.</param>
        /// <param name="neck">Радиус горла пивной кружки</param>
        /// <param name="bottomThickness">Толщина дна пивной кружки</param>
        private void BuildHandle(double high, double neck, double bottomThickness)
        {
            //Ручка кругом
            var sketch = _connector.CreateSketch(2, neck + bottomThickness / 2.85);
            var pointOne = new Point2D(0, -high / 2 - 5);
            var PointTwo = new Point2D(100, -high / 2 - 5);
            var circleCoord = new Point2D(0, -high * 0.78);
            sketch.CreateLineSeg(pointOne, PointTwo, 3);
            sketch.CreateCircle(circleCoord, bottomThickness / 3);

            ////ручка дугой
            //var sketch = _connector.CreateSketch(2);
            //var pointOne = new Point2D(0, -high/2-5);
            //var PointTwo = new Point2D(100, -high / 2-5);
            //sketch.CreateLineSeg(pointOne, PointTwo, 3);

            //var circleStart = new Point2D(neck, -high + bottomThickness);
            //var circleEnd = new Point2D(neck, -bottomThickness*2);
            //var middle = neck * 2.5;
            //var circleMiddle = new Point2D(middle, -middle);
            //sketch.ArcBy3Point(circleStart, circleMiddle, circleEnd);


            //// Ручка прямыми
            //var sketch = _connector.CreateSketch(2);

            //var middleHigh = new Point2D(-neck - bottomThickness * 7, -high - 10);
            //var middleDown = new Point2D(-neck - bottomThickness * 6, -bottomThickness - 20);
            //var start = new Point2D(-neck , -high);
            //var end = new Point2D(-neck, -bottomThickness - 10);
            //sketch.CreateLineSeg(start, middleHigh, 1);
            //sketch.CreateLineSeg(middleHigh, middleDown, 1);
            //sketch.CreateLineSeg(middleDown, end, 1);
            sketch.EndEdit();
            //_connector.Extrude(sketch, 3, true);
            _connector.ExtrudeRotation180(sketch);
        }
    }
}
