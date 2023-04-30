using System;
using System.Security.AccessControl;
using System.Text;
//Створити клас, що містить методи додавання, віднімання, множення та ділення раціональних дробів
//та такі ж методи для роботи з комплексними числами.
//Для випадку раціональних дробів та випадку комплексних чисел передбачити відповідні інтерфейси.
namespace Lab_3
{
    interface IRationalFraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public void Set(int numerator, int denominator);
    }
    interface IComplex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
    }
    internal class Calculator
    {
        public static T Add<T>(IRationalFraction left, IRationalFraction right)
        where T : IRationalFraction, new()
        {
            T result = new T();

            int numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;

            result.Set(numerator, denominator);

            return result;
        }
        public static T Subtract<T>(IRationalFraction left, IRationalFraction right)
        where T : IRationalFraction, new()
        {
            T result = new T();

            int numerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
            int denominator = left.Denominator * right.Denominator;

            result.Set(numerator, denominator);

            return result;
        }
        public static T Multiply<T>(IRationalFraction left, IRationalFraction right)
        where T : IRationalFraction, new()
        {
            T result = new T();

            int numerator = left.Numerator * right.Numerator;
            int denominator = left.Denominator * right.Denominator;

            result.Set(numerator, denominator);

            return result;
        }
        public static T Divide<T>(IRationalFraction left, IRationalFraction right)
        where T : IRationalFraction, new()
        {
            if (right.Numerator == 0) throw new DivideByZeroException();

            T temp = new T();
            temp.Set(right.Denominator, right.Numerator);

            return Multiply<T>(left, temp);
        }
        public static T Add<T>(IComplex left, IComplex right)
        where T : IComplex, new()
        {
            T result = new T();

            result.Real = left.Real + right.Real;
            result.Imaginary = left.Imaginary + right.Imaginary;

            return result;
        }
        public static T Subtract<T>(IComplex left, IComplex right)
        where T : IComplex, new()
        {
            T result = new T();

            result.Real = left.Real - right.Real;
            result.Imaginary = left.Imaginary - right.Imaginary;

            return result;
        }
        public static T Multiply<T>(IComplex left, IComplex right)
        where T : IComplex, new()
        {
            T result = new T();

            (var a, var b, var c, var d) = (left.Real, left.Imaginary, right.Real, right.Imaginary);

            result.Real = a * c - b * d;
            result.Imaginary = b * c + a * d;

            return result;
        }
        public static T Divide<T>(IComplex left, IComplex right)
        where T : IComplex, new()
        {

            (var a, var b, var c, var d) = (left.Real, left.Imaginary, right.Real, right.Imaginary);

            if(c == 0 && d == 0) throw new DivideByZeroException();

            T result = new T();

            result.Real = (a * c + b * d) / (c * c + d * d);
            result.Imaginary = (b * c - a * d) / (c * c + d * d);

            return result;
        }
    }

    internal class Fraction : IRationalFraction
    {
        private int _numerator = 0;
        private int _denominator = 1;
        public int Numerator { get { return _numerator; } set { _numerator = value; Simplify(); } }
        public int Denominator { get { return _denominator; } set { _denominator = value; Simplify(); } }
        public void Set(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            Simplify();
        }

        public Fraction()
        {
            _numerator = 0;
            _denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GetGCD(Numerator, Denominator);
            if (gcd == 0) gcd = 1;
            _numerator /= gcd;
            _denominator /= gcd;

            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }
        }
        static int GetGCD(int a, int b)
        {
            if (a == 0)
                return b;
            return Math.Abs(GetGCD(b % a, a));
        }
        public override string ToString()
        {
            if (_denominator == 0)
            {
                if (_numerator > 0) return "inf";
                if (_numerator < 0) return "-inf";
                return "undefined";
            }
            if (_numerator == 0) return "0";
            if (_denominator == 1) return _numerator.ToString();
            return $"{_numerator}/{_denominator}";
        }
    }

    internal class Complex : IComplex
    {
        public Complex()
        {
            Real = 0;
            Imaginary = 0;
        }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Real { get; set; }
        public double Imaginary { get; set; }
        public override string ToString()
        {
            if(Imaginary == 0) return Real.ToString();
            return $"{Math.Round(Real, 2)}+{Math.Round(Imaginary, 2)}i";
        }
    }
}
