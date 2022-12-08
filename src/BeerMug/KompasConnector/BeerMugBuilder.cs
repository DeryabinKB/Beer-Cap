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
            var wallThickness = mugParameters.WallThickness;
            var lowerBottom = mugParameters.BelowBottomDiametr/2;
            BuildBottom(lowerBottom, upperBottom, bottomThickness);
            //BuildBody(upperBottom, bottomThickness, high, wallThickness);
        }

        private void BuildBottom(double lowerBottom, double upperBottom, double bottomThickness)
        {
            //Осевая линия
            var centralStart = new Point2D(0, -250);
            var centralEnd = new Point2D(0, 250);
            var sketch = _connector.CreateSketch(2);
            sketch.CreateLineSeg(centralStart, centralEnd, 3);

            //Нижняя прямая
            var pointBelow = new Point2D(0, 0);
            var pointBelowEnd = new Point2D(lowerBottom, 0);
            var pointBelowBezier = new Point2D(lowerBottom, 0);
            var pointUpperBezier = new Point2D(upperBottom, -bottomThickness);
            var check = lowerBottom + (upperBottom - lowerBottom) / 2;
            var pointMiddle = new Point2D(check, bottomThickness / 8);
            sketch.CreateLineSeg(pointBelow, pointBelowEnd, 1);
            sketch.ArcBy3Point(pointBelowBezier, pointMiddle, pointUpperBezier);
            sketch.EndEdit();
            _connector.ExtrudeRotation(sketch);

            ////Верхний радиус
            //var pointUpper = new Point2D(0, 0);
            //var pointUpperEnd = new Point2D(upperBottom, bottomThickness);
            //sketch = _connector.CreateSketch(3, bottomThickness);
            //sketch.CreateLineSeg(pointUpper, pointUpperEnd, 1);
            //sketch.EndEdit();
            //_connector.ExtrudeRotation(sketch);

            //Их соединение
            
        }

        //private void BuildBody(double upperBottom, double bottomThickness, double high, double wallThickness)
        //{
        //    var pointUpperBezier = new Point2D(upperBottom, -bottomThickness);
        //    var pointStart = new Point2D(upperBottom, -bottomThickness);
        //    var pointEnd = new Point2D(upperBottom, -high);
        //    var pointMiddle = new Point2D(0, high/2);
        //    var sketch = _connector.CreateSketch(2);
        //    sketch.ArcBy3Point(pointStart, pointMiddle, pointEnd);
        //    sketch.EndEdit();
        //    _connector.ExtrudeRotation(sketch);
        //}

    }
}
