using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using BeerMug.Model;
using KompasConnector;

namespace BeerMug.StressTest
{
    class StressTest
    {
        private static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var beerMugBuilder = new BeerMugBuilder();
            var beerMugParameters = new MugParameters();
            double highBottom = 90;
            double neck = 90;
            double high = 132.5;
            double bottomThickness = 13.25;
            double wallThickness = 6;
            double belowBottom = 60;
            beerMugParameters.MugNeckDiametr = neck;
            beerMugParameters.HighBottomDiametr = highBottom;
            beerMugParameters.BelowBottomRadius = belowBottom;
            beerMugParameters.High = high;
            beerMugParameters.BottomThickness = bottomThickness;
            beerMugParameters.WallThickness = wallThickness;
            var streamWriter = new StreamWriter($"StressTest.txt", true);
            var modelCounter = 0;
            var computerInfo = new ComputerInfo();
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ulong usedMemory = 0;
            while (usedMemory * 0.96 <= computerInfo.TotalPhysicalMemory)
            {
                beerMugBuilder.Builder(beerMugParameters, "Round shape");
                usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory);
                streamWriter.WriteLine(
                    $"{++modelCounter}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}\t{cpuCounter.NextValue()}%");
                streamWriter.Flush();
            }
            stopWatch.Stop();
            streamWriter.WriteLine("END");
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}