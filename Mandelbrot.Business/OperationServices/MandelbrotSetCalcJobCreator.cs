using MandelbrotSet.Core.Entities;
using MandelbrotSet.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet.Business
{
    public class MandelbrotSetCalcJobCreator : IMandelbrotSetCalcJobCreator
    {
        public List<MandelbrotCalcJobMessage> GetMandelbrotCalcJobs(int maxIteration, double width, double height, double length, double radius)
        {
            var result = new List<MandelbrotCalcJobMessage>();
            var startPoint = new ComplexNumber(0, 0);
            
            for (int row =  0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    double real = (col - width / radius) * length / width;
                    double imaginary = (row - height / radius) * length / width;

                    result.Add(new MandelbrotCalcJobMessage(startPoint, new ComplexNumber(real, imaginary), maxIteration, row, col));
                }
            }

            return result;
        }
    }
}
