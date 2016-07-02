namespace MandelbrotSet.Business
{
    using Akka.Actor;
    using Core.Interfaces;
    using MandelbrotSet.Core;
    using MandelbrotSet.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MandelbrotCalculationActor : ReceiveActor
    {
        private readonly IMandelbrotSetCalculator _mandelbrotCalculator;
        public MandelbrotCalculationActor()
        {
            _mandelbrotCalculator = new MandelbrotSetCalculator();
            Console.WriteLine("Created: " + Self.Path);
            Receive();
        }

        private void Receive()
        {
            this.Receive<MandelbrotCalcJobMessage>(message =>
            {
                var result = _mandelbrotCalculator.Calculation(message);
                this.Sender.Tell(result);
            });
        }
    }
}
