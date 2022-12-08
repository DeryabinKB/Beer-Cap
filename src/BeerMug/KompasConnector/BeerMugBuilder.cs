using BeerMug.Model;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //var upperBottom = double.Parse(mugParameters.Parameters[MugParametersType.BelowBottomDiametr]);
            //var bottomThickness = double.Parse(mugParameters.Parameters[MugParametersType.BottomThickness]);
            //var high = double.Parse(mugParameters.Parameters[MugParametersType.HeightNeckBottom]);
            //var wallThickness = double.Parse(mugParameters.Parameters[MugParametersType.WallThickness]);
            BuildBottom(50, 80, 10);
        }

        private void BuildBottom(double lowerBottom, double upperBottom, double bottomThickness)
        {
            var pointBelow = new Point3D(0, 0, 0);
            var pointUpper = new Point3D(100, 0, 0);
            var sketchBelow = _connector.CreateSketch(3);
            sketchBelow.CreateCircle(pointBelow, lowerBottom);
            sketchBelow.EndEdit();
            var sketch = _connector.CreateSketch(3);
            sketch.CreateCircle(pointUpper, upperBottom);
            sketch.EndEdit();


        }
    }
}
