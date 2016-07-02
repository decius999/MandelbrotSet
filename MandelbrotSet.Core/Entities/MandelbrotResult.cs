namespace MandelbrotSet.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MandelbrotResult
    {
        public MandelbrotResult(int row, int column, int colorCode)
        {
            Row = row;
            Column = column;
            ColorCode = colorCode;
        }

        public int Row { get; }
        public int Column { get; }
        public int ColorCode { get; }
    }
}
