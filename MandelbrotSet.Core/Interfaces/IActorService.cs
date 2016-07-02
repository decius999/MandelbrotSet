namespace Mandelbrot.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MandelbrotSet.Core.Entities;

    public interface IActorService
    {
        Task<List<MandelbrotResult>> CalcAsync(List<MandelbrotCalcJobMessage> calcJobs, int maxIteration, Action<List<MandelbrotResult>> draw);
        void CreateActorSystem(string addressAndPort);
    }
}