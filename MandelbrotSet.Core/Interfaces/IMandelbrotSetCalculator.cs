namespace MandelbrotSet.Core.Interfaces
{
    using MandelbrotSet.Core.Entities;

    public interface IMandelbrotSetCalculator
    {
        MandelbrotResult Calculation(MandelbrotCalcJobMessage message);
    }
}