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
    public class BeerMugBuilder
    {
        /// <summary>
        /// Сапр апи.
        /// </summary>
        private KompasConnector _connector = new KompasConnector();

        public void Builder(MugParameters mugParameters)
        {
            _connector.StartKompas();
            _connector.CreateDocument();
            _connector.SetProperties();
            var upperBottom = mugParameters.HighBottomDiametr/2;
            var neck = mugParameters.MugNeckDiametr/2;
            var bottomThickness = mugParameters.BottomThickness;
            var high = mugParameters.HeightNeckBottom;
            var wallThickness = mugParameters.WallThickness/2;
            var lowerBottom = mugParameters.BelowBottomDiametr/2;
            BuildBottom(lowerBottom, upperBottom, bottomThickness);
            BuildBody(upperBottom, bottomThickness, high, wallThickness, neck);
            BuildHand(high, neck, bottomThickness);
        }

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
            _connector.ExtrudeRotation(sketch);            
        }

        private void BuildBody(double upperBottom, double bottomThickness, double high, double wallThickness, double neck)
        {
            // Построение основы кружки

            //Создание осевой линии
            var centralStart = new Point2D(0, -250);
            var centralEnd = new Point2D(0, 250);

            // Переменная для дуги
            var atMiddle = -upperBottom*1.3;
            

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
            _connector.ExtrudeRotation(sketch);

            var atMiddle2 = upperBottom * 1.25;
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

        private void BuildHand(double high, double neck, double bottomThickness)
        {
            var sketch = _connector.CreateSketch(2);
            var start = new Point2D(-neck, -high);
            var end = new Point2D(-neck, -bottomThickness);
            var myRand = bottomThickness/2;
            var middle = new Point2D(myRand, myRand);
            sketch.ArcBy3Point(start, middle, end);
            sketch.EndEdit();
        }

    }
}
