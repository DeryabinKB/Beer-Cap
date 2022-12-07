using Beer_mug.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeerMug.Model
{
    /// <summary>
    /// Класс параметры пивной кружки.
    /// </summary>
    public class MugParameters
    {
        /// <summary>
        /// Хранение типов параметров и их значений.
        /// </summary>
        private readonly Dictionary<MugParametersType, MugParameter> _parameters;

        /// <summary>
        /// Конструктор пивной кружки.
        /// </summary>
        public MugParameters()
        {
            _parameters = new Dictionary<MugParametersType, MugParameter>()
            {
                { MugParametersType.BelowBottomDiametr, new MugParameter(60, 50, 70) },
                { MugParametersType.HighBottomDiametr, new MugParameter(90, 80, 100) },
                { MugParametersType.BottomThickness, new MugParameter(13, 10, 16.5) },
                { MugParametersType.HeightNeckBottom, new MugParameter(130, 100, 165) },
                { MugParametersType.WallThickness, new MugParameter(6, 5, 7) },
                { MugParametersType.MugNeckDiametr, new MugParameter(90, 29.75, 45.5) },
            };
        }

        /// <summary>
        /// Установка значения параметра.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetParameterValue(MugParametersType type, double value)
        {
            if (!_parameters.TryGetValue(type, out var parameter)) return;

            CheckDependencies(type, value);
            parameter.Value = value;
        }

        /// <summary>
        /// Получение значения параметра.
        /// </summary>
        /// <param name="type">Тип параметра пивной кружки.</param>
        /// <returns>Значение параметра.</returns>
        /// <exception cref="Exception">Если параметр не существует.</exception>
        public double GetParameterValue(MugParametersType type)
        {
            if (_parameters.TryGetValue(type, out var parameter))
            {
                return parameter.Value;
            }
            throw new Exception("Parameter does not exist");
        }

        /// <summary>
        /// Checks dependent parameters.
        /// </summary>
        /// <param name="type">Тип параметра пивной кружки.</param>
        /// <param name="value">Значение параметра.</param>
        /// <exception cref="Exception">Если значение параметра некорректно.</exception>
        private void CheckDependencies(MugParametersType type, double value)
        {
            switch (type)
            {
                case MugParametersType.BottomThickness:
                    {
                        _parameters.TryGetValue(MugParametersType.HeightNeckBottom, out var parameter);
                        if (value + parameter.Value * 10 != parameter.Value)
                        {
                            throw new Exception(
                                "Height depends on the bottom thickness in the ratio (Bottom thickness * 10)");
                        }
                        break;
                    }
                case MugParametersType.HighBottomDiametr:
                    {
                        _parameters.TryGetValue(MugParametersType.MugNeckDiametr, out var parameter);
                        if (value + parameter.Value * 1 == parameter.Value)
                        {
                            throw new Exception(
                                "High bottom diametr depends on the Mug neck diametr in the ratio (Bottom diametr * 1)");
                        }
                        break;
                    }
                case MugParametersType.BelowBottomDiametr:
                    {
                        _parameters.TryGetValue(MugParametersType.HighBottomDiametr, out var parameter);
                        if (value + (parameter.Value + 30) == parameter.Value)
                        {
                            throw new Exception(
                                "Below bottom diametr depends on the Mug neck diametr in the ratio (Below bottom diametr +30)");
                        }
                        break;
                    }
                        default:
                    {
                        return;
                    }
            }
        }
    }
}
