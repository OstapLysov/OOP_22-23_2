using Lab5;

namespace Lab1
{
    class TPPiramid : TPTriangle
    {
        protected double _height = 0;
        public double Height { get => _height; set => _height = Math.Abs(value); }
        public TPPiramid() { this.Height = 5; }
        public TPPiramid(double cathetusA, double cathetusB, double height) : base(cathetusA, cathetusB)
        {
            this.Height = height;
        }
        public TPPiramid(TPPiramid other)
        {
            this._cathetusA = other.CathetusA;
            this._cathetusB = other.CathetusB;
            this._height = other.Height;
        }

        override public double GetArea()
        {
            //S_3 = √p(p - a)(p - b)(p - c)
            double hypotenuse1 = Math.Sqrt(CathetusA * CathetusA + CathetusB * CathetusB);
            double hypotenuse2 = Math.Sqrt(CathetusA * CathetusA + Height * Height);
            double hypotenuse3 = Math.Sqrt(Height * Height + CathetusB * CathetusB);
            double p = (hypotenuse1 + hypotenuse2 + hypotenuse3) / 2;
            double S = Math.Sqrt(p * (p - hypotenuse1) * (p - hypotenuse2) * (p - hypotenuse3));
            return CathetusA * CathetusB / 2 + CathetusA * Height / 2 + CathetusB * Height / 2 + S;
        }
        override public double GetPerimeter()
        {
            double hypotenuse1 = Math.Sqrt(CathetusA * CathetusA + CathetusB * CathetusB);
            double hypotenuse2 = Math.Sqrt(CathetusA * CathetusA + Height * Height);
            double hypotenuse3 = Math.Sqrt(Height * Height + CathetusB * CathetusB);

            return CathetusA + CathetusB + Height + hypotenuse1 + hypotenuse2 + hypotenuse3;
        }
        public double GetVolume()
        {
            return (Height * (CathetusA + CathetusB + Height) / 2) / 3;
        }
        public bool Equals(TPPiramid other)
        {
            if (other == null) { return false; }

            if (this.CathetusA.Equals(other.CathetusA) && this.CathetusB.Equals(other.CathetusB) && this.Height.Equals(other.Height))
            {
                return true;
            }
            return false;
        }

        public static TPPiramid operator +(TPPiramid left, TPPiramid right)
        {
            return new TPPiramid(left.CathetusA + right.CathetusA, left.CathetusB + right.CathetusB, left.Height + right.Height);
        }
        public static TPPiramid operator -(TPPiramid left, TPPiramid right)
        {
            return new TPPiramid(left.CathetusA - right.CathetusA, left.CathetusB - right.CathetusB, left.Height - right.Height);
        }
        public static TPPiramid operator *(TPPiramid left, double right) =>
            new TPPiramid(left.CathetusA * right, left.CathetusB * right, left.Height * right);
        public override string ToString()
        {
            return string.Format("(Cathetus A: {0}, Cathetus B: {1}, Height: {2} Base hypotenuse: {3})",
                                 Math.Round(this.CathetusA, 2), Math.Round(this.CathetusB, 2), Math.Round(this.Height, 2),
                                 Math.Round(Math.Sqrt(this.CathetusA * this.CathetusA + this.CathetusB * this.CathetusB), 2));
        }
    }
}
