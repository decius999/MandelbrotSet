namespace MandelbrotSet.Business
{
    using Akka.Actor;
    using Core;
    using Core.Entities;
    using Mandelbrot.Business.OperationServices;
    using Mandelbrot.Core.Interfaces;
    using MandelbrotSet.Core.Interfaces;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class MandelbrotService : IMandelbrotService
    {
        private readonly IActorService _actorService;
        private readonly IMandelbrotSetCalcJobCreator _calcJobCreator;

        public MandelbrotService(IActorService actorService, IMandelbrotSetCalcJobCreator calcJobCreator)
        {
            _actorService = actorService;
            _calcJobCreator = calcJobCreator;
        }

        public async Task<List<MandelbrotResult>> CalculateAsync(int height, int width, int maxIteration, Action<List<MandelbrotResult>> draw)
        {
            var calcJobs = _calcJobCreator.GetMandelbrotCalcJobs(maxIteration, width, height, 2.0, 4.0);
            _actorService.CreateActorSystem("localhost:8011");
            return await _actorService.CalcAsync(calcJobs, maxIteration, draw);
        }
    }
}
