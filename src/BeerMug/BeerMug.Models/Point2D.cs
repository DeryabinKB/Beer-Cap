using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
    /// <summary>
    /// Класс для задачи координат в двумерном пространстве
    /// </summary>
    public class Point2D : IEquatable<Point2D>
    {
        /// <summary>
        /// Значение точки x.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Значение точки y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Присвоение координат.
        /// </summary>
        /// <param name="x">Координата х.</param>
        /// <param name="y">Координата у.</param>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Проверка на равенство объектов класса.
        /// </summary>
        /// <param name="expected">Сравниваемый объект.</param>
        /// <returns>Возвращает true, если элементы равны,
        /// false - если элементы не равны.</returns>
        public bool Equals(Point2D expected)
        {
            return expected != null &&
                   expected.X.Equals(X) &&
                   expected.Y.Equals(Y);
        }
    }
}
