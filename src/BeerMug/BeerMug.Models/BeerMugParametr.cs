using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
    /// <summary>
    /// Класс для обработки значений параметра пивной кружки.
    /// </summary>
    public class BeerMugParametr
    {
        /// <summary>
        /// Проверка диапазона.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="min">Минимальное значение параметра.</param>
        /// <param name="max">Максимальное значение параметра</param>
        /// <param name="parameters">Тип параметра.</param>
        /// <param name="errors">Текст ошибок.</param>
        public void RangeCheck(double value, double min, double max,
           MugParametersType parameters, Dictionary<MugParametersType, string> errors)
        {
            errors.Remove(parameters);
            if (value < min || value > max)
            {
                errors.Add(parameters, "One filed data is out of range");
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}