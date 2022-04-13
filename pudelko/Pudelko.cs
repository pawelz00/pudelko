using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pudelko
{
    public enum UnitOfMeasure
    {
        meter,
        centimeter,
        milimeter
    }
    public sealed class Pudelko
    {
        private readonly double a = 0.1, b = 0.1, c = 0.1;
        public UnitOfMeasure unit { get; set; }
        public double changeToMeters(UnitOfMeasure unit, double x)
        {
            if (unit == UnitOfMeasure.milimeter)
                return Math.Round(x * 1000, 3);
            else if (unit == UnitOfMeasure.centimeter)
                return Math.Round(x * 100, 3);
            else return Math.Round(x, 3);
        }
        public double A { get => changeToMeters(unit, a); }
        public double B { get => changeToMeters(unit, b); }
        public double C { get => changeToMeters(unit, c); }
        public Pudelko() => unit = UnitOfMeasure.meter;
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
        {
            if ((a < 0 || b < 0 || c < 0) || (a > 10 || b > 10 || c > 10))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.a = a; this.b = b; this.c = c;
        }
        public override string ToString()
        {
            return $"{A.ToString("0.000", CultureInfo.InvariantCulture)} m × {B.ToString("0.000", CultureInfo.InvariantCulture)} m × {C.ToString("0.000", CultureInfo.InvariantCulture)} m";
        }
        //public override string ToString(string format)
        //{

        //}
        //public string ToString(string? format, IFormatProvider? formatProvider)
        //{
        //    return a.ToString(format, formatProvider);
        //}
    }
}
