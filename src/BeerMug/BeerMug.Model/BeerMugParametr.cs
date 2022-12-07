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
        /// Проверка диапазона.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="parameters"></param>
        /// <param name="errors"></param>
        public void RangeCheck(double value, double min, double max,
           MugParametersType parameters, Dictionary<MugParametersType, string> errors)
        {
            errors.Remove(parameters);
            if (value < min || value > max)
            {
                errors.Add(parameters, "Out of range");
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}