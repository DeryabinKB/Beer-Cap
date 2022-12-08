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
            var upperBottom = 80;
            var lowerBottom = 50;
            var bottomThickness = 10;
            var high = 100;
            var wallThickness = 5;
            //var upperBottom = mugParameters.HighBottomDiametr;
            //var bottomThickness = mugParameters.BottomThickness;
            //var high = mugParameters.HeightNeckBottom;
            //var wallThickness = mugParameters.WallThickness;
            //var lowerBottom = mugParameters.BelowBottomDiametr;
            BuildBottom(lowerBottom, upperBottom, bottomThickness);
            BuildBody(upperBottom, bottomThickness, high, wallThickness);
        }

        private void BuildBottom(double lowerBottom, double upperBottom, double bottomThickness)
        {
            //Осевая линия
            var centralStart = new Point2D(0, -250);
            var centralEnd = new Point2D(0, 250);
            var sketch = _connector.CreateSketch(2);
            sketch.CreateLineSeg(centralStart, centralEnd, 3);
            sketch.EndEdit();

            //Нижняя прямая
            var pointBelow = new Point2D(0, 0);
            var pointBelowEnd = new Point2D(0, lowerBottom);
            sketch = _connector.CreateSketch(3);
            sketch.CreateLineSeg(pointBelow, pointBelowEnd, 1);
            sketch.EndEdit();
            _connector.ExtrudeRotation(sketch);

            //Верхний радиус
            var pointUpper = new Point2D(0, 0);
            var pointUpperEnd = new Point2D(upperBottom, bottomThickness);
            sketch = _connector.CreateSketch(3, bottomThickness);
            sketch.CreateLineSeg(pointUpper, pointUpperEnd, 1);
            sketch.EndEdit();
            _connector.ExtrudeRotation(sketch);

            //Их соединение
            var pointBelowBezier = new Point2D(lowerBottom, 0);
            var pointUpperBezier = new Point2D(upperBottom, -bottomThickness);
            var check = lowerBottom + (upperBottom - lowerBottom)/2;
            var pointMiddle = new Point2D(check, bottomThickness/8);
            sketch = _connector.CreateSketch(2);
            sketch.ArcBy3Point(pointBelowBezier, pointMiddle, pointUpperBezier);
            sketch.EndEdit();
            _connector.ExtrudeRotation(sketch);
        }

        private void BuildBody(double upperBottom, double bottomThickness, double high, double wallThickness)
        {
            var pointStart = new Point2D(upperBottom, -bottomThickness);
            var pointEnd = new Point2D(upperBottom, -high);
            var sketch = _connector.CreateSketch(2);
            sketch.CreateLineSeg(pointStart, pointEnd, 1);
            sketch.EndEdit();
            _connector.ExtrudeRotation(sketch);
        }

    }
}
