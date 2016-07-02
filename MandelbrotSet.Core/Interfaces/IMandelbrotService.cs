namespace MandelbrotSet.Core.Interfaces
{
    using MandelbrotSet.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMandelbrotService
    {
        Task<List<MandelbrotResult>> CalculateAsync(int height, int width, int maxIteration, Action<List<MandelbrotResult>> draw);
    }
}