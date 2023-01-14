using BeerMug.Model;
using NUnit.Framework;

namespace BeerMug.Test
{
    [TestFixture]
    public class BeerMugParametersTest
    {
        public void FieldsData(double belowBottom, double highBottom, double neck, 
            double high, double bottomThickness, double wallThickness, MugParameters mugParameters)
        {
            mugParameters.MugNeckDiametr = neck;
            mugParameters.HighBottomDiametr = highBottom;
            mugParameters.High = high;
            mugParameters.BottomThickness = bottomThickness;
            mugParameters.WallThickness = wallThickness;
            mugParameters.BelowBottomRadius = belowBottom;
        }

        [TestCase(Description = "Позитивный тест геттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Get_CorrectValue()
        {
            MugParameters mugParameters = new MugParameters();
            
            double belowBottom = 50;
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness, mugParameters);
            Assert.AreEqual(expected, mugParameters.BelowBottomRadius, "Значение должно входить в " +
                                                                        "диапазон от 50 до 70");/// диаметр верхнего дна -30 = диаметр нижнего дна
        }

        [TestCase(50, Description = "Позитивный тест сеттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(belowBottom, highBottom, neck,
                high, bottomThickness, wallThickness, mugParameters);
            Assert.AreEqual(value, mugParameters.BelowBottomRadius,
                "Значение должно входить в диапазон от 50 до 70");
        }

        [TestCase(30, Description = "Негативный тест сеттера BelowBottomRadius")]
        [TestCase(90, Description = "Негативный тест сеттера BelowBottomRadius")]

        public void Test_BelowBottomRadius_Set_IncorrectValue(double wrongBelowBottomRadius)
        {
            MugParameters mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "Должно возникать исключение, если значение не входит в " +
            "диапазон от 50 до 70");
        }

        [TestCase(60, Description = "Негативный тест сеттера BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_IncorrectValueAddiction(double wrongBelowBottomRadius)
        {
            MugParameters _mugParameters = new MugParameters();
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness, _mugParameters);
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "Диаметр нижнего дна должен быть на 30 мешьше верхнего дна диаметра");///диаметр нижнего дна +30 = диаметр верхнего дна
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Get_CorrectValue()
        {
            MugParameters _mugParameters = new MugParameters();
            double expected = 80;
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness, _mugParameters);
            var actual = expected;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 80 до 100");

        }

        [TestCase(80, Description = "Позитивный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness, mugParameters);
            Assert.AreEqual(value, mugParameters.HighBottomDiametr,
                "Значение должно входить в диапазон от 80 до 100");

        }

        [TestCase(40, Description = "Негативный тест сеттера HighBottomDiametr")]
        [TestCase(120, Description = "Негативный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValue(double wrongHighBottomDiametr)
        {
            MugParameters mugParameters = new MugParameters();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 80 до 100");
        }

        [TestCase(80, Description = "Негативный тест сеттера HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValueAddiction(double wrongHighBottomDiametr)
        {
            MugParameters mugParameters = new MugParameters();
            mugParameters.MugNeckDiametr = 90;
            Assert.Throws<Exception>(() =>
            {
                mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "Диаметр нижнего дна должен быть равен диаметру горла кружки");///диаметр нижнего дна к диаметр кружки = 1 к 1
        }

        [TestCase(Description = "Позитивный тест геттера BottomThickness")]
        public void Test_BottomThickness_Get_CorrectValue()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 10;
            mugParameters.High = 100;
            mugParameters.BottomThickness = expected;
            var actual = mugParameters.BottomThickness = expected;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 10 до 16,5"); /// 1 к 10 10 = 100
        }

        [TestCase(10, Description = "Позитивный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness, mugParameters);
            Assert.AreEqual(value, mugParameters.BottomThickness,
                "Значение должно входить в диапазон от 10 до 16,5"); ///1 к 10
        }

        [TestCase(12, Description = "Негативный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValueAddiction(double wrongBottomThickness)
        {
            MugParameters mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            FieldsData(50, highBottom, neck,
                high, bottomThickness, wallThickness, mugParameters);
            Assert.Throws<Exception>(() =>
            {
                mugParameters.BottomThickness = wrongBottomThickness;
            }, "Высота дна должна быть в 10 раз меньше высоты кружки");/// 1 к 10
        }

        [TestCase(8, Description = "Негативный тест сеттера BottomThickness")]
        [TestCase(20, Description = "Негативный тест сеттера BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValue(double wrongBottomThickness)
        {
            MugParameters mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                mugParameters.BottomThickness = wrongBottomThickness;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 10 до 16,5");
        }

        [TestCase(Description = "Позитивный тест геттера High")]
        public void Test_High_Get_CorrectValue()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 100;
            mugParameters.High = expected;
            var actual = mugParameters.High;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 100 до 165");

        }

        [TestCase(100, Description = "Позитивный тест сеттера High")]
        public void Test_High_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            mugParameters.High = 100;
            Assert.AreEqual(value, mugParameters.High,
                "Значение должно входить в диапазон от 100 до 165");

        }

        [TestCase(80, Description = "Негативный тест сеттера High")]
        [TestCase(180, Description = "Негативный тест сеттера High")]
        public void Test_High_Set_IncorrectValue(double wrongHigh)
        {
            MugParameters mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                mugParameters.High = wrongHigh;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 100 до 165");
        }

        [TestCase(Description = "Позитивный тест геттера WallThickness")]
        public void Test_WallThickness_Get_CorrectValue()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 5;
            mugParameters.WallThickness = expected;
            var actual = mugParameters.WallThickness;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 5 до 7");
        }

        [TestCase(5, Description = "Позитивный тест сеттера WallThickness")]
        public void Test_WallThickness_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            mugParameters.WallThickness = 5;
            Assert.AreEqual(value, mugParameters.WallThickness,
                "Значение должно входить в диапазон от 5 до 7");
        }

        [TestCase(1, Description = "Негативный тест сеттера WallThickness")]
        [TestCase(10, Description = "Негативный тест сеттера WallThickness")]

        public void Test_WallThickness_Set_IncorrectValue(double wrongWallThickness)
        {
            MugParameters mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                mugParameters.WallThickness = wrongWallThickness;
            }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 5 до 7");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametr")]
        public void Test_MugNeckDiametr_Get_CorrectValue()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 80;
            mugParameters.MugNeckDiametr = expected;
            var actual = mugParameters.MugNeckDiametr;
            Assert.AreEqual(expected, actual, "Значение должно входить в " +
                                              "диапазон от 80 до 100");
        }

        [TestCase(80, Description = "Позитивный тест сеттера MugNeckDiametr")]
        public void Test_MugNeckDiametr_Set_CorrectValue(double value)
        {
            MugParameters mugParameters = new MugParameters();
            mugParameters.MugNeckDiametr = 80;
            Assert.AreEqual(value, mugParameters.MugNeckDiametr,
                "Значение должно входить в диапазон от 80 до 100");
        }

        [TestCase(70, Description = "Негативный тест сеттера MugNeckDiametr")]
        [TestCase(110, Description = "Негативный тест сеттера MugNeckDiametr")]

        public void Test_MugNeckDiametr_Set_IncorrectValue(double wrongMugNeckDiametr)
        {
            MugParameters mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    mugParameters.MugNeckDiametr = wrongMugNeckDiametr;
                }, "Должно возникать исключение, если значение не входит в " +
                   "диапазон от 80 до 100");
        }

        [TestCase(Description = "Позитивный тест геттера BelowBottomDiametrMin")]
        public void Test_BelowBottomDiametrMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 50;
            var actual = mugParameters.BelowBottomDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 50");
        }

        [TestCase(Description = "Позитивный тест геттера BelowBottomDiameterMax")]
        public void Test_BelowBottomDiametrMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 70;
            var actual = mugParameters.BelowBottomDiameterMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 70");
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametrMin")]
        public void Test_HighBottomDiametrMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 80;
            var actual = mugParameters.HighBottomDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 80");
        }

        [TestCase(Description = "Позитивный тест геттера HighBottomDiametrMax")]
        public void Test_HighBottomDiametrMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 100;
            var actual = mugParameters.HighBottomDiametrMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }

        [TestCase(Description = "Позитивный тест геттера BottomThicknessMin")]
        public void Test_BottomThicknessMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 10;
            var actual = mugParameters.BottomThicknessMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 10");
        }

        [TestCase(Description = "Позитивный тест геттера BottomThicknessMax")]
        public void Test_BottomThicknessMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = "16,5";
            var actual = mugParameters.BottomThicknessMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 16.5");
        }

        [TestCase(Description = "Позитивный тест геттера HighMin")]
        public void Test_HighMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 100;
            var actual = mugParameters.HighMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }

        [TestCase(Description = "Позитивный тест геттера HighMax")]
        public void Test_HighMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 165;
            var actual = mugParameters.HighMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 165");
        }

        [TestCase(Description = "Позитивный тест геттера WallThicknessMin")]
        public void Test_WallThicknessMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 5;
            var actual = mugParameters.WallThicknessMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 5");
        }

        [TestCase(Description = "Позитивный тест геттера WallThicknessMax")]
        public void Test_WallThicknessMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 7;
            var actual = mugParameters.WallThicknessMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 7");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametrMin")]
        public void Test_MugNeckDiametrMin_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 80;
            var actual = mugParameters.MugNeckDiametrMin;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 80");
        }

        [TestCase(Description = "Позитивный тест геттера MugNeckDiametrMax")]
        public void Test_MugNeckDiametrMax_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = 100;
            var actual = mugParameters.MugNeckDiametrMax;
            Assert.AreEqual(expected, actual, "Значение должно быть равно 100");
        }

        [TestCase(Description = "Позитивный тест геттера MugType")]
        public void Test_MugType_Get_Value()
        {
            MugParameters mugParameters = new MugParameters();
            var expected = "Round shape";
            var actual = mugParameters.MugType;
            Assert.AreEqual(expected, actual, "Значение должно быть равно Round shape");
        }
    }
}