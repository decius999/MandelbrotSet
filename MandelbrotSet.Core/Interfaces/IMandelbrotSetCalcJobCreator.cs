namespace MandelbrotSet.Core.Interfaces
{
    using System.Collections.Generic;
    using MandelbrotSet.Core.Entities;

    public interface IMandelbrotSetCalcJobCreator
    {
        List<MandelbrotCalcJobMessage> GetMandelbrotCalcJobs(int maxIteration, double width, double height, double length, double radius);
    }
}