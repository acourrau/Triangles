using System;

namespace TriangleApi.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            
            Point test = obj as Point;
            return (test.X == X && test.Y == Y);
        }

        public override string ToString() {
            return "(" + X + "," + Y + ")";
        }

        public override int GetHashCode() {
            return HashCode.Combine(X, Y);
        }
    }
}