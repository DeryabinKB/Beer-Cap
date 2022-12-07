using BeerMug.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompasConnector
{
    public class BeerMugBuilder
    {
        /// <summary>
        /// Сапр апи.
        /// </summary>
        private KompasConnector _apiService = new KompasConnector();

        public void Builder(MugParameters mugParameters)
        {
            _apiService.StartKompas();
            _apiService.CreateDocument();
            _apiService.SetProperties();

        }
    }
}
