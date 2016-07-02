using Akka.Actor;
using MandelbrotSet.Business;
using MandelbrotSet.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mandelbrot.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxIteration = 100;
            var watch = Stopwatch.StartNew();

            var result = new MandelbrotService().CalculateAsync(100, 100, maxIteration, null).Result;

            watch.Stop();
            Console.WriteLine("Ready...: " + watch.ElapsedMilliseconds);

            Console.ReadKey();
        }


    }
}
