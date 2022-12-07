using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMug.Model
{
    public class BeerMugParametr
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Возврат и установка значения параметра.
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (IsRangeOut(value))
                {
                    throw new ArgumentException($"Value should be bigger than {_minValue} and lower than {_maxValue}"); // Не могу понять где он переприсваивает, уже весь путь прогнал через отладку и всё равно нихера и ещё одна ошибка - не пашет валидация
                }
                _value = value;
            }
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        private readonly double _minValue = 0;

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        private readonly double _maxValue = 150;

        /// <summary>
        /// Конструктор пивной кружки.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        public BeerMugParametr(double value, double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Проверка принадлежности параметра к диапазону допустимых значений.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <returns></returns>
        private bool IsRangeOut(double value)
        {
            return value < _minValue || value > _maxValue;
        }
    }
}