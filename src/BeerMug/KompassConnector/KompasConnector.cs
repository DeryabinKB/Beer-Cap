using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BeerMug.Model;

namespace KompasConnector
{
    /// <summary>
    /// Класс запуска Компас 3D и его библиотек.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект Компас API.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Модель.
        /// </summary>
        public ksPart _part;

        /// <summary>
        /// Документ Компас 3D.
        /// </summary>
        private ksDocument3D _document;

        /// <summary>
        /// Запуск Компас 3D.
        /// </summary>
        /// <exception cref="Exception">При неудачной попытке отрыть Компас 3D
        /// бросается исключение</exception>
        public void StartKompas()
        {
            try
            {
                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }

                if (_kompas != null) return;
                {
                    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                    StartKompas();
                    if (_kompas == null)
                    {
                        throw new Exception("Can't open Kompas3D.");
                    }
                }
            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Создание документа в Компас 3D.
        /// </summary>
        /// <exception cref="ArgumentException">При неудачной попытке создать документ в Компас 3D 
        /// бросается исключение</exception>
        public void CreateDocument()
        {
            try
            {
                _document = (ksDocument3D)_kompas.Document3D();
                _document.Create();
                _document = (ksDocument3D)_kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Can't build detail.");
            }
        }

        /// <summary>
        /// Установка свойст детали.
        /// </summary>
        public void SetProperties()
        {
            _part = (ksPart)_document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Mug";
            _part.SetAdvancedColor(296955, 0.8, 0.8, 0.8, 0.8);
            _part.Update();
        }

        /// <summary>
        /// Создания скетча.
        /// </summary>
        /// <param name="type">Плоскость скетча.</param>
        /// <param name="offset">Отступ скетча от начала координат.</param>
        /// <returns>Скетч.</returns>
        public KompasSketch CreateSketch(int type, double offset = 0)
        {
            return new KompasSketch(_part, type, offset);
        }

        /// <summary>
        /// Выдавливание скетча.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        /// <param name="depth">Глубина выдавливания.</param>
        /// <param name="type">Направление выдавливания.</param>
        public void Extrude(KompasSketch kompasSketch, double depth, bool type)
        {
            ksEntity extrudeEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrudeDefinition =
                (ksBaseExtrusionDefinition)extrudeEntity.GetDefinition();
            if (type == false)
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrudeDefinition.SetSideParam(type, (short)End_Type.etBlind, depth);
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            extrudeEntity.Create();
        }

        /// <summary>
        /// Вырезание выдавливанием.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        /// <param name="depth">Глубина выдавливания.</param>
        /// <param name="type">Направление выдавливания</param>
        public void CutExtrude(KompasSketch kompasSketch, double depth, bool type)
        {
            ksEntity extrudeEntity = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition extrudeDefinition = (ksCutExtrusionDefinition)extrudeEntity.GetDefinition();
            if (type == false)
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            ksExtrusionParam extrudeParam = (ksExtrusionParam)extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = depth;
            extrudeEntity.Create();
        }

        /// <summary>
        /// Выдавливание вращением на 360 градусов.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        public void ExtrudeRotation360(KompasSketch kompasSketch)
        {
            ksEntity bossRotated = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition bossRotatedDefinition = (ksBossRotatedDefinition)bossRotated.GetDefinition();
            bossRotatedDefinition.directionType = (short)Direction_Type.dtNormal;
            bossRotatedDefinition.SetSketch(kompasSketch.Sketch);
            bossRotatedDefinition.SetSideParam(true, 360);
            bossRotated.Create();
        }

        /// <summary>
        /// Выдавливание вращением на 180 градусов.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        public void ExtrudeRotation180(KompasSketch kompasSketch)
        {
            ksEntity bossRotated = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition bossRotatedDefinition = (ksBossRotatedDefinition)bossRotated.GetDefinition();
            bossRotatedDefinition.directionType = (short)Direction_Type.dtNormal;
            bossRotatedDefinition.SetSketch(kompasSketch.Sketch);
            bossRotatedDefinition.SetSideParam(true, 180);
            bossRotated.Create();
        }

        /// <summary>
        /// Выдавливание вращением на 178 градусов.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        public void ExtrudeRotation178(KompasSketch kompasSketch)
        {
            ksEntity bossRotated = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition bossRotatedDefinition = (ksBossRotatedDefinition)bossRotated.GetDefinition();
            bossRotatedDefinition.directionType = (short)Direction_Type.dtNormal;
            bossRotatedDefinition.SetSketch(kompasSketch.Sketch);
            bossRotatedDefinition.SetSideParam(true, 178.5);
            bossRotated.Create();
        }

        /// <summary>
        /// Скругления на ребрах окружностей.
        /// </summary>
        /// <param name="radius"> Угол скругления.</param>
        public void Fillet(double radius)
        {
            var roundedEdges = GetCylinderFaces();
            if (roundedEdges.Count.Equals(0))
            {
                throw new Exception("Edge collection is empty.");
            }

            var filletEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDefinition = (ksFilletDefinition)filletEntity.GetDefinition();
            ksEntityCollection items = (ksEntityCollection)filletDefinition.array();

            filletDefinition.radius = radius;
            roundedEdges.ForEach(edge => items.Add(edge));
            filletEntity.Create();
        }

        /// <summary>
        /// Возвращает все цилиндрические грани детали.
        /// </summary>
        /// <returns> Список цилиндрических граней.</returns>
        private List<ksFaceDefinition> GetCylinderFaces()
        {
            var body = (ksBody)_part.GetMainBody();
            var faces = (ksFaceCollection)body.FaceCollection();

            var facesCount = faces.GetCount();
            if (facesCount == 0)
            {
                return new List<ksFaceDefinition>();
            }
            var cylinderFaces = new List<ksFaceDefinition>();
            var i = 0;
            while (faces.Next() != null)
            {
                var currentFace = (ksFaceDefinition)faces.GetByIndex(i);
                if (currentFace.IsValid())
                {
                    cylinderFaces.Add(currentFace);
                }

                ++i;
            }
            return cylinderFaces;
        }

        /// <summary>
        /// Вырезание выдавливанием вокруг.
        /// </summary>
        /// <param name="kompasSketch">Скетч.</param>
        public void CutExtrudeRotation(KompasSketch kompasSketch, int angle)
        {
            ksEntity bossRotated = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutRotated);
            ksCutRotatedDefinition bossRotatedDefinition = (ksCutRotatedDefinition)bossRotated.GetDefinition();
            bossRotatedDefinition.directionType = (short)Direction_Type.dtNormal;
            bossRotatedDefinition.SetSketch(kompasSketch.Sketch);
            bossRotatedDefinition.SetSideParam(true, angle);
            bossRotated.Create();
        }
        
        /// <summary>
        /// Функция, рассчитывающая координату точки по ее расстоянию и углу от другой точки.
        /// (Переводит из полярных координат в Декартовые).
        /// </summary>
        /// <param name="isX">Рассчитывает ли функция X или Y: true - X, false - Y.</param>
        /// <param name="radius">Расстояние между точками.</param>
        /// <param name="angle">Угол, по которому точка исказилась относительно другой точки.</param>
        /// <param name="x0">Положение по Х для первой точки.</param>
        /// <param name="y0">Положение по Y для первой точки.</param>
        /// <returns>Координату X или Y.</returns>
        public double CartesianFromPolar(bool isX, double radius, double angle,
            double x0 = 0, double y0 = 0)
        {
            if (isX)
            {
                return x0 + radius * Math.Cos(angle * (Math.PI / 180.0));
            }
            else
            {
                return y0 + radius * Math.Sin(angle * (Math.PI / 180.0));
            }
        }
    }
}