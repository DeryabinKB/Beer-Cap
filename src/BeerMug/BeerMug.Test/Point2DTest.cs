using BeerMug.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Test
{
    internal class Point2DTest
    {
        /// <summary>
        /// Позитивный тест геттера X.
        /// </summary>
        [Test(Description = "Позитивный тест геттера X.")]
        public void TestXGet_CorrectValue()
        {
            const int value = 10;
            var point2D = new Model.Point2D(value, 5);
            var actual = point2D.X;
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// Позитивный тест геттера Y.
        /// </summary>
        [Test(Description = "Позитивный тест геттера Y.")]
        public void TestYGet_CorrectValue()
        {
            const int value = 10;
            var point2D = new Model.Point2D(5, value);
            var actual = point2D.Y;
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// Позитивный тест метода Equals.
        /// </summary>
        [Test(Description = "Позитивный тест метода Equals.")]
        public void TestEquals_CorrectValue()
        {
            var expected = new Model.Point2D(0, 0);
            var actual = new Model.Point2D(0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
