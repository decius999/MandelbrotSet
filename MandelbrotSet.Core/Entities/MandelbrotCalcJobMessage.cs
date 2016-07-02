namespace MandelbrotSet.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MandelbrotCalcJobMessage
    {
        
        public MandelbrotCalcJobMessage(ComplexNumber z, ComplexNumber c, int maxIteration, int row, int column)
        {
            Z = z;
            C = c;
            MaxIteration = maxIteration;
            Row = row;
            Column = column;
        }

        public ComplexNumber Z { get; }
        public ComplexNumber C { get; }
        public int MaxIteration { get; }
        public int Row { get; }
        public int Column { get; }
    }
}
