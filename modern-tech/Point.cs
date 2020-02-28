using System;
using System.Diagnostics.CodeAnalysis;

namespace modern_tech
{
    public struct Point{

        private double _x;
        private double _y;
        private double? _distance;

        public double X {
            readonly  get => _x;
            private set => _x = value;
        }
        public double Y {
            readonly get => _y;
            private set => _y = value;
        }

        public readonly double Distance {
            get {
                if (!_distance.HasValue)
                    _distance = Math.Sqrt(X * X + Y * Y);

                return _distance.Value;
            }
        }

        // Assign using tuples!
        public Point(double x, double y) => 
            (this._x, this._y, this._distance) = (x, y, default);

        public static bool operator ==(Point left, Point right) => 
            (left.X, left.Y) == (right.X, right.Y);

        public static bool operator !=(Point left, Point right) => 
           (left.X, left.Y) != (right.X, right.Y);

        public override bool Equals(object obj) {
            return obj switch {
                null => false,
                Point otherPt => (this == otherPt),
                _ => false
            };
        }

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

        public void SwapCoords() => (X, Y) = (Y, X);

        //public void SwapCoords() {
        //    double tmp = X;
        //    X = Y;
        //    Y = tmp;
        //}

    }
}
