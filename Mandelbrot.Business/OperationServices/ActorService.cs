namespace Mandelbrot.Business.OperationServices
{
    using Akka.Actor;
    using Core.Interfaces;
    using MandelbrotSet.Core.Entities;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActorService : IActorService
    {
        private ActorSelection _actor;
        private ActorSystem _system;

        public void CreateActorSystem(string addressAndPort)
        {
            _system = ActorSystem.Create("mandelbrot");
            _actor = _system.ActorSelection($"akka.tcp://mandelbrot@{addressAndPort}/user/calc");
        }

        public async Task<List<MandelbrotResult>> CalcAsync(List<MandelbrotCalcJobMessage> calcJobs, int maxIteration, Action<List<MandelbrotResult>> draw)
        {
            int counter = 0;
            var result = new List<MandelbrotResult>();
            var tasks = new ConcurrentBag<Task<MandelbrotResult>>();

            try
            {
                foreach (var job in calcJobs)
                {
                    Console.WriteLine(counter++);
                    tasks.Add(_actor.Ask<MandelbrotResult>(job));

                    if (tasks.Count > 2000)
                    {
                        await Task.WhenAll(tasks.ToList());
                        result = tasks.Select(s => s.Result).ToList();
                        draw?.Invoke(result);
                        tasks = new ConcurrentBag<Task<MandelbrotResult>>();
                    }
                }

            }
            catch
            {
            }
            return result;
        }
    }
}
