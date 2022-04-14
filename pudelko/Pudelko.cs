using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        #region Properties
        private readonly double a, b, c;
        public double A 
        {
            get
            {
                double temporaryNumber = a;
                if (unit == UnitOfMeasure.centimeter)
                {
                    temporaryNumber = a / 100;
                }
                else if (unit == UnitOfMeasure.milimeter)
                {
                    temporaryNumber = a / 1000;
                }
                return GetRoundedProperties(temporaryNumber);
            }
        }
        public double B
        {
            get
            {
                double temporaryNumber = b;
                if (unit == UnitOfMeasure.centimeter)
                {
                    temporaryNumber = b / 100;
                }
                else if (unit == UnitOfMeasure.milimeter)
                {
                    temporaryNumber = b / 1000;
                }
                return GetRoundedProperties(temporaryNumber);
            }
        }
        public double C
        {
            get
            {
                double temporaryNumber = c;
                if (unit == UnitOfMeasure.centimeter)
                {
                    temporaryNumber = c / 100;
                }
                else if (unit == UnitOfMeasure.milimeter)
                {
                    temporaryNumber = c / 1000;
                }
                return GetRoundedProperties(temporaryNumber);
            }
        }
        public UnitOfMeasure unit { get; set; }
        public double Objetosc { get => Math.Round(A * B * C, 9); }
        public double Pole { get => Math.Round(2*((A*B)+(A*C)+(B*C)), 6); }
        #endregion
        #region Constructor
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unit = unit;
            this.a = a.GetValueOrDefault(GetDefaultValue());
            this.b = b.GetValueOrDefault(GetDefaultValue());
            this.c = c.GetValueOrDefault(GetDefaultValue());
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (A > 10 || B > 10 || C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            if (unit == UnitOfMeasure.meter)
                return $"{A.ToString("0.000", CultureInfo.InvariantCulture)} m \u00D7 {B.ToString("0.000", CultureInfo.InvariantCulture)} m \u00D7 {C.ToString("0.000", CultureInfo.InvariantCulture)} m";
            else if (unit == UnitOfMeasure.centimeter)
                return ToString("cm");
            else return ToString("mm");
        }
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            switch (format)
            {
                case "cm":
                    return $"{String.Format(formatProvider,"{0:0.0}", A * 100)} cm \u00D7 {String.Format(formatProvider,"{0:0.0}", B * 100)} cm \u00D7 {String.Format(formatProvider,"{0:0.0}", C * 100)} cm";
                case "mm":
                    return $"{String.Format(formatProvider,"{0:0}", A * 1000)} mm \u00D7 {String.Format(formatProvider,"{0:0}", B * 1000)} mm \u00D7 {String.Format(formatProvider,"{0:0}", C * 1000)} mm";
                case "m":
                    return ToString();
                default:
                    throw new FormatException();
            }
        }
        #endregion
        #region Metody wyznaczania a,b,c
        private double GetDefaultValue()
        {
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    return 100;
                case UnitOfMeasure.centimeter:
                    return 10;
                default:
                    return 0.1;
            }
        }

        public static double GetRoundedProperties(double x)
        {
           return Math.Round(x, 3);
        }

        #endregion
        #region Enum
        public enum UnitOfMeasure
        {
            meter,
            centimeter,
            milimeter
        }
        #endregion
        #region Equals
        public bool Equals(Pudelko? other)
        {
            if(ReferenceEquals(null, other)) return false;
            return (this.Objetosc == other.Objetosc) && (this.Pole == other.Pole);
        }
        public override bool Equals(object? obj)
        {
            return this.Equals(obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C);
        }
        #endregion
        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !p1.Equals(p2);
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {

        }
    }
}
