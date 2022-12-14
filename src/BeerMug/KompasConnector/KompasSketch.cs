using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerMug.Model;

namespace KompasConnector
{
    public class KompasSketch
    {
        /// <summary>
        /// 2D документ.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// Определенны эскиз.
        /// </summary>
        private ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Возвращает эскиз.
        /// </summary>
        public ksEntity Sketch { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="type">1 - YZ; 2 - XZ; 3 - XY.</param>
        public KompasSketch(ksPart part, int type, double offset = 0)
        {
            ksEntity plane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDefinition = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (type == 1)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            }
            else if (type == 2)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            }
            else
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            }

            planeDefinition.direction = true;
            planeDefinition.offset = offset;
            plane.Create();

            Sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)Sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            Sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
        }

        /// <summary>
        /// Завершить редактирование.
        /// </summary>
        public void EndEdit()
        {
            _sketchDefinition.EndEdit();
        }

        public void CreateCircle(Point2D center, double radius)
        {
            _document2D.ksCircle(center.X, center.Y, radius, 1);
        }

        public void CreateLineSeg(Point2D start, Point2D end, int style)
        {
            _document2D.ksLineSeg(start.X, start.Y, end.X, end.Y, style);
        }

        public void ArcBy3Point(Point2D start, Point2D middle, Point2D end)
        {
            _document2D.ksArcBy3Points(start.X, start.Y, middle.X, middle.Y, end.X, end.Y, 1);
        }

        public void CreateBezier(Point2D start, Point2D end)
        {
            _document2D.ksBezier(1, 2);
            _document2D.ksBezierPoint(start);
            _document2D.ksBezierPoint(end);
        }

        public void ArcByPoint(Point2D center, double rad, Point2D start, Point2D end)
        {
            _document2D.ksArcByPoint(center.X, center.Y, rad, start.X, start.Y, end.X, end.Y, 1, 1);
        }

        
    }
}
