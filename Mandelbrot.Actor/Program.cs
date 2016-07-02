using Akka.Actor;
using Akka.Cluster.Routing;
using Akka.Configuration;
using Akka.Routing;
using MandelbrotSet.Business;
using MandelbrotSet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet.Actor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("mandelbrot"))
            {
                var props = Props.Create<MandelbrotCalculationActor>().WithRouter(new ClusterRouterPool(
                    new SmallestMailboxPool(100000000),
                    new ClusterRouterPoolSettings(100000, true, 100)));

                var actor = system.ActorOf(props, "calc");

                Console.ReadKey();
            }
        }
    }
}
