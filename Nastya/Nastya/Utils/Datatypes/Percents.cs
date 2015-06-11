using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Utils.Datatypes
{
    public class Percents
    {
        public const double MaxValue = 100;
        public const double MinValue = 0;
        private readonly double _percents;

        public Percents(double percents)
        {
            _percents = percents;
        }


        //Value MUST be more than minBound and less than maxBound
        public static Percents CountPercents(double minBound, double maxBound, double value)
        {
            var newMaxBound = (maxBound - minBound);
            var newValue = value - minBound;
            var res = (Percents.MaxValue - Percents.MinValue) / newMaxBound * newValue;
            return new Percents(res);
        }

        public static Percents operator +(Percents c1, Percents c2)
        {
            double res = c1._percents + c2._percents;
            if (!CheckBounds(res))
                throw new ValueOverflowException(String.Format("After addition value is {0}, MaxValue is {1}", res, MaxValue));
            return new Percents(res);
        }

        public static Percents operator -(Percents c1, Percents c2)
        {
            double res = c1._percents - c2._percents;
            if (!CheckBounds(res))
                throw new ValueOverflowException(String.Format("After subtraction value is {0}, MinValue is {1}", res, MinValue));
            return new Percents(res);
        }

        public static Percents operator /(Percents c1, Percents c2)
        {
            if (c2._percents == 0)
                throw new DivideByZeroException();
            double res = c1._percents / c2._percents;
            if (!CheckBounds(res))
                throw new ValueOverflowException(String.Format("After division value is {0}, MaxValue is {1}", res, MaxValue));
            return new Percents(res);
        }

        public static Percents operator *(Percents c1, Percents c2)
        {
            double res = c1._percents * c2._percents;
            if (!CheckBounds(res))
                throw new ValueOverflowException(String.Format("After multiplication value is {0}, MaxValue is {1}", res, MaxValue));
            return new Percents(res);
        }

        public static bool operator >(Percents c1, Percents c2)
        {
            return c1._percents > c2._percents;
        }

        public static bool operator <(Percents c1, Percents c2)
        {
            return c1._percents < c2._percents;
        }

        public static bool operator <=(Percents c1, Percents c2)
        {
            return c1._percents <= c2._percents;
        }

        public static bool operator >=(Percents c1, Percents c2)
        {
            return c1._percents >= c2._percents;
        }



        private static bool CheckBounds(double num)
        {
            return num <= MaxValue && num >= MinValue;
        }

        public class ValueOverflowException : Exception
        {

            public ValueOverflowException(string message)
        : base(message)
            {
            }

        }
    }
}
