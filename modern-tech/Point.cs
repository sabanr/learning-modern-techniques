using System;

namespace modern_tech
{
    public class Point {

        private double _x;
        private double _y;
        private double? _distance;

        public double X {
            get => _x;
            private set => _x = value;
        }
        public double Y {
            get => _y;
            private set => _y = value;
        }

        public double Distance {
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
            var mc = 11;

            return mc * X.GetHashCode() * Y.GetHashCode();
        }

        public void SwapCoords() => (X, Y) = (Y, X);

        //public void SwapCoords() {
        //    double tmp = X;
        //    X = Y;
        //    Y = tmp;
        //}

    }
}
