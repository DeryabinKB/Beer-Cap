using BeerMug.Model;
using NUnit.Framework;

namespace BeerMug.Test
{
    [TestFixture]
    public class MugTest
    {
        private MugParameters _mugParameters;

        [TestCase(Description = "Позитивный тест геттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(expected, _mugParameters.BelowBottomRadius, "Значение должно входить в " +
                                                                        "диапазон от 50 до 70");/// диаметр верхнего дна -30 = диаметр нижнего дна
        }

        [TestCase(50, Description = "Позитивный тест сеттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.BelowBottomRadius,
                "Значение должно входить в диапазон от 50 до 70");
        }

        [TestCase(30, Description = "Негативный тест сеттера BelowBottomRadius")]
        [TestCase(90, Description = "Негативный тест сеттера BelowBottomRadius")]

        public void Test_BelowBottomRadius_Set_IncorrectValue(double wrongBelowBottomRadius)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "Должно возникать исключение, если значение не входит в " +
            "диапазон от 50 до 70");
        }

        [TestCase(60, Description = "Негативный тест сеттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_IncorrectValueAddiction(double wrongBelowBottomRadius)
        {
            _mugParameters = new MugParameters();
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "Диаметр нижнего дна должен быть на 30 мешьше верхнего дна диаметра");///диаметр нижнего дна +30 = диаметр верхнего дна
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            var actual = _mugParameters.HighBottomDiametr;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 80 до 100");

        }

        [TestCase(80, Description = "Позитивный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.HighBottomDiametr,
                "Значение должно входить в диапазон от 80 до 100");

        }

        [TestCase(40, Description = "Негативный тест сеттера HighBottomDiametr")]
        [TestCase(120, Description = "Негативный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValue(double wrongHighBottomDiametr)
        {
            _mugParameters = new MugParameters();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 80 до 100");
        }

        [TestCase(80, Description = "Негативный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValueAddiction(double wrongHighBottomDiametr)
        {
            _mugParameters = new MugParameters();
            _mugParameters.MugNeckDiametr = 90;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "Диаметр нижнего дна должен быть равен диаметру горла кружки");///диаметр нижнего дна к диаметр кружки = 1 к 1
        }

        [TestCase(Description = "Позитивный тест геттера BottomThickness")]
        public void Test_BottomThickness_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 10;
            _mugParameters.High = 100;
            _mugParameters.BottomThickness = expected;
            var actual = _mugParameters.BottomThickness = expected;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 10 до 16,5"); /// 1 к 10 10 = 100
        }

        [TestCase(10, Description = "Позитивный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.BottomThickness,
                "Значение должно входить в диапазон от 10 до 16,5"); ///1 к 10
        }

        [TestCase(12, Description = "Негативный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValueAddiction(double wrongBottomThickness)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.BottomThickness = wrongBottomThickness;
            }, "Высота дна должна быть в 10 раз меньше высоты кружки");/// 1 к 10
        }

        [TestCase(8, Description = "Негативный тест сеттера BottomThickness")]
        [TestCase(20, Description = "Негативный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValue(double wrongBottomThickness)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.BottomThickness = wrongBottomThickness;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 10 до 16,5");
        }

        [TestCase(Description = "Позитивный тест геттера High")]
        public void Test_High_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 100;
            _mugParameters.High = expected;
            var actual = _mugParameters.High;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 100 до 165");

        }

        [TestCase(100, Description = "Позитивный тест сеттера High")]
        public void Test_High_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.High = 100;
            Assert.AreEqual(value, _mugParameters.High,
                "Значение должно входить в диапазон от 100 до 165");

        }

        [TestCase(80, Description = "Негативный тест сеттера High")]
        [TestCase(180, Description = "Негативный тест сеттера High")]
        public void Test_High_Set_IncorrectValue(double wrongHigh)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.High = wrongHigh;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 100 до 165");
        }

        [TestCase(Description = "Позитивный тест геттера WallThickness")]
        public void Test_WallThickness_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 5;
            _mugParameters.WallThickness = expected;
            var actual = _mugParameters.WallThickness;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 5 до 7");
        }

        [TestCase(5, Description = "Позитивный тест сеттера WallThickness")]
        public void Test_WallThickness_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.WallThickness = 5;
            Assert.AreEqual(value, _mugParameters.WallThickness,
                "Значение должно входить в диапазон от 5 до 7");
        }

        [TestCase(1, Description = "Негативный тест сеттера WallThickness")]
        [TestCase(10, Description = "Негативный тест сеттера WallThickness")]

        public void Test_WallThickness_Set_IncorrectValue(double wrongWallThickness)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.WallThickness = wrongWallThickness;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 5 до 7");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametr")]
        public void Test_MugNeckDiametr_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            _mugParameters.MugNeckDiametr = expected;
            var actual = _mugParameters.MugNeckDiametr;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 80 до 100");
        }

        [TestCase(80, Description = "Позитивный тест сеттера MugNeckDiametr")]
        public void Test_MugNeckDiametr_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.MugNeckDiametr = 80;
            Assert.AreEqual(value, _mugParameters.MugNeckDiametr,
                "Значение должно входить в диапазон от 80 до 100");
        }

        [TestCase(70, Description = "Негативный тест сеттера MugNeckDiametr")]
        [TestCase(110, Description = "Негативный тест сеттера MugNeckDiametr")]

        public void Test_MugNeckDiametr_Set_IncorrectValue(double wrongMugNeckDiametr)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    _mugParameters.MugNeckDiametr = wrongMugNeckDiametr;
                }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 80 до 100");
        }

        /// <summary>
        /// Позитивный тест геттера X.
        /// </summary>
        [Test(Description = "Позитивный тест геттера X.")]
        public void TestXGet_CorrectValue()
        {
            const int value = 10;
            var point2D = new Point2D(value, 5);
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
            var point2D = new Point2D(5, value);
            var actual = point2D.Y;
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// Позитивный тест метода Equals.
        /// </summary>
        [Test(Description = "Позитивный тест метода Equals.")]
        public void TestEquals_CorrectValue()
        {
            var expected = new Point2D(0, 0);
            var actual = new Point2D(0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}