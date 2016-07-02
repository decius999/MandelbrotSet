namespace MandelbrotSet.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ComplexNumber
    {
        public ComplexNumber()
        {

        }
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber Add(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);

        public ComplexNumber Sub(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);

        public ComplexNumber Mult(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);

        public double Amount => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        public override string ToString()
            => Imaginary >= 0 ? $"z = {Real} + {Imaginary}i" : $"z = {Real} - {(-1) * Imaginary}i";

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber().Add(a, b);

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber().Sub(a, b);

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber().Mult(a, b);
    }
}
