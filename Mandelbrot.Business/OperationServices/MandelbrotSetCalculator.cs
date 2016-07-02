namespace MandelbrotSet.Business
{
    using Core;
    using Core.Interfaces;
    using MandelbrotSet.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MandelbrotSetCalculator : IMandelbrotSetCalculator
    {
        private ComplexNumber CalcFormula(ComplexNumber z, ComplexNumber c) => z * z - c;

        public MandelbrotResult Calculation(MandelbrotCalcJobMessage message)
        {
            var lastIteration = message.MaxIteration;
            var z = message.Z;

            for (int i = 0; i < message.MaxIteration; i++)
            {
                z = CalcFormula(z, message.C);

                if (z.Amount > 2.0)
                {
                    lastIteration = i;
                    break;
                }
            }

            //Console.WriteLine(z);

            return new MandelbrotResult(message.Row, message.Column, lastIteration % 10);
        }
    }
}
