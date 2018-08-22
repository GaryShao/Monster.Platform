using System;

namespace Monster.UnitTest
{
    public struct Point: IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;

        public int Y;

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
