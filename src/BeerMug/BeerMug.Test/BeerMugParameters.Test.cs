using BeerMug.Model;
using NUnit.Framework;

namespace BeerMug.Test
{
    [TestFixture]
    public class BeerMugParametersTest
    {
        private MugParameters _mugParameters;

        public void FieldsData(double belowBottom, double highBottom, double neck, 
            double high, double bottomThickness, double wallThickness)
        {
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
        }

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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness);
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

        [TestCase(Description = "Позитивный тест геттера BelowBottomDiametrMin")]
        public void Test_BelowBottomDiametrMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 50;
            var actual = _mugParameters.BelowBottomDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 50");
        }

        [TestCase(Description = "Позитивный тест геттера BelowBottomDiametrMax")]
        public void Test_BelowBottomDiametrMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 70;
            var actual = _mugParameters.BelowBottomDiametrMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 70");
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametrMin")]
        public void Test_HighBottomDiametrMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            var actual = _mugParameters.HighBottomDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 80");
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametrMax")]
        public void Test_HighBottomDiametrMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 100;
            var actual = _mugParameters.HighBottomDiametrMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }

        [TestCase(Description = "Позитивный тест геттера BottomThicknessMin")]
        public void Test_BottomThicknessMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 10;
            var actual = _mugParameters.BottomThicknessMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 10");
        }

        [TestCase(Description = "Позитивный тест геттера BottomThicknessMax")]
        public void Test_BottomThicknessMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = "16,5";
            var actual = _mugParameters.BottomThicknessMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 16.5");
        }

        [TestCase(Description = "Позитивный тест геттера HighMin")]
        public void Test_HighMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 100;
            var actual = _mugParameters.HighMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }

        [TestCase(Description = "Позитивный тест геттера HighMam")]
        public void Test_HighMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 165;
            var actual = _mugParameters.HighMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 165");
        }

        [TestCase(Description = "Позитивный тест геттера WallThicknessMin")]
        public void Test_WallThicknessMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 5;
            var actual = _mugParameters.WallThicknessMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 5");
        }

        [TestCase(Description = "Позитивный тест геттера WallThicknessMax")]
        public void Test_WallThicknessMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 7;
            var actual = _mugParameters.WallThicknessMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 7");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametrMin")]
        public void Test_MugNeckDiametrMin_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            var actual = _mugParameters.MugNeckDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 80");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametrMax")]
        public void Test_MugNeckDiametrMax_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 100;
            var actual = _mugParameters.MugNeckDiametrMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }
    }
}