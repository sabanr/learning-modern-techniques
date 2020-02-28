using System;

namespace modern_tech
{
    public readonly struct Point{

        public double X { get; }
        public double Y { get; }

        public double Distance {
            get;
        }

        // Assign using tuples!
        public Point(double x, double y) => 
            (X, Y, Distance) = (x, y, Math.Sqrt(x * x + y * y));

        public static bool operator ==(Point left, Point right) => 
            (left.X, left.Y) == (right.X, right.Y);

        public static bool operator !=(Point left, Point right) => 
           (left.X, left.Y) != (right.X, right.Y);

        public override bool Equals(object? obj) => obj switch
        {
            null => false,
            Point otherPt => (this == otherPt),
            _ => false
        };

        public override int GetHashCode() {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int hashingBase = (int) 2166136261;
                const int hashingMultiplier = 16777619;

                int hash = hashingBase;
                hash = (hash * hashingMultiplier) ^ X.GetHashCode() ;
                hash = (hash * hashingMultiplier) ^ Y.GetHashCode();
                return hash;
            }
        }

        public Point SwapCoords() => new Point(Y, X);

        //public void SwapCoords() {
        //    double tmp = X;
        //    X = Y;
        //    Y = tmp;
        //}

    }
}
