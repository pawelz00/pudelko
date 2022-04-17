using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        public enum UnitOfMeasure
        {
            meter,
            centimeter,
            milimeter
        }
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
                return GetRoundedProp(temporaryNumber);
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
                return GetRoundedProp(temporaryNumber);
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
                return GetRoundedProp(temporaryNumber);
            }
        }
        public UnitOfMeasure unit { get; set; }
        public double Objetosc { get => Math.Round(A * B * C, 9); }
        public double Pole { get => Math.Round(2*((A*B)+(A*C)+(B*C)), 6); }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unit = unit;
            this.a = a.GetValueOrDefault(GetDefaultValue());
            this.b = b.GetValueOrDefault(GetDefaultValue());
            this.c = c.GetValueOrDefault(GetDefaultValue());
            if (a <= MinValue(unit) || b <= MinValue(unit) || c <= MinValue(unit))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (A > 10 || B > 10 || C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private double MinValue(UnitOfMeasure u)
        {
            if (u == UnitOfMeasure.milimeter) return 1;
            else if (u == UnitOfMeasure.centimeter) return 0.01;
            else return 0.001;
        }
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
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "cm":
                    return $"{String.Format(formatProvider,"{0:0.0}",100*A)} cm \u00D7 {String.Format(formatProvider,"{0:0.0}",100*B)} cm \u00D7 {String.Format(formatProvider,"{0:0.0}",100*C)} cm";
                case "mm":
                    return $"{String.Format(formatProvider,"{0:0}",1000*A)} mm \u00D7 {String.Format(formatProvider,"{0:0}",1000*B)} mm \u00D7 {String.Format(formatProvider,"{0:0}",1000*C)} mm";
                case "m":
                    return ToString();
                case null:
                    return ToString();
                default:
                    throw new FormatException();
            }
        }
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

        public static double GetRoundedProp(double x)
        {
           var y = x * 1000; y = (int)y; y /= 1000;
           return Math.Round(y, 3);
        }
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
        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !p1.Equals(p2);
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            var p1arr = (double[])p1;
            var p2arr = (double[])p2;
            Array.Sort(p1arr);
            Array.Sort(p2arr);
            return new Pudelko(p1arr[0]+ p2arr[0], p1arr[1]+ p2arr[1], p1arr[2]+ p2arr[2]);
        }
        public static explicit operator double[](Pudelko p)
        {
            double[] result = new double[3];
            result[0] = p.A; result[1] = p.B; result[2] = p.C;
            return result;
        }
        public static implicit operator Pudelko(ValueTuple<int,int,int> v) => new Pudelko(v.Item1, v.Item2, v.Item3, UnitOfMeasure.milimeter);
        public IEnumerator<double> GetEnumerator()
        {
            for(int i = 0; i < 3; i++)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Pudelko? other)
        {
            throw new NotImplementedException();
        }
        private double[] array = new double[3];
        public double this[int index] 
        {
            get
            {
                if (index < 0 || index >= array.Length) throw new ArgumentOutOfRangeException("index");
                if (index == 0) return this.A;
                else if (index == 1) return this.B;
                else return this.C;
            }
        }
    }
}
