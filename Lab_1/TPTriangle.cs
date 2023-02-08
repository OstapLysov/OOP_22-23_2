using System;

namespace Lab5
{
    internal class TPTriangle
    {
        protected double _cathetusA = 0;
        protected double _cathetusB = 0;

        public double CathetusA { get => _cathetusA; set => _cathetusA = Math.Abs(value); }
        public double CathetusB { get => _cathetusB; set => _cathetusB = Math.Abs(value); }
        public TPTriangle()
        {
            this.CathetusA = 3;
            this.CathetusB = 4;
        }
        public TPTriangle(double cathetusA, double cathetusB)
        {
            this.CathetusA = Math.Abs(cathetusA);
            this.CathetusB = Math.Abs(cathetusB);
        }
        public TPTriangle(TPTriangle other)
        {
            this.CathetusA = other.CathetusA;
            this.CathetusB = other.CathetusB;
        }
        virtual public double GetArea()
        {
            return this.CathetusA * this.CathetusB / 2;
        }
        virtual public double GetPerimeter()
        {
            return this.CathetusA + this.CathetusB + Math.Sqrt(this.CathetusA * this.CathetusA + this.CathetusB * this.CathetusB);
        }
        public bool Equals(TPTriangle other)
        {
            if (other == null) { return false; }

            if (this.CathetusA.Equals(other.CathetusA) && this.CathetusB.Equals(other.CathetusB))
            {
                return true;
            }
            return false;
        }

        public static TPTriangle operator +(TPTriangle left, TPTriangle right)
        {
            return new TPTriangle(left.CathetusA + right.CathetusA, left.CathetusB + right.CathetusB);
        }
        public static TPTriangle operator -(TPTriangle left, TPTriangle right)
        {
            return new TPTriangle(left.CathetusA - right.CathetusA, left.CathetusB - right.CathetusB);
        }
        public static TPTriangle operator *(TPTriangle left, double right) =>
            new TPTriangle(left.CathetusA * right, left.CathetusB * right);
        public override string ToString()
        {
            return string.Format("(Cathetus A: {0}, Cathetus B: {1}, Hypotenuse: {2})",
                                 Math.Round(this.CathetusA, 2), Math.Round(this.CathetusB, 2),
                                 Math.Round(Math.Sqrt(this.CathetusA * this.CathetusA + this.CathetusB * this.CathetusB), 2));
        }
    }
}
