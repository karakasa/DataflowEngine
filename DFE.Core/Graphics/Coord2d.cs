using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DFE.Core.Graphics
{
    [DebuggerDisplay($"({{X}}, {{Y}})")]
    public struct Coord2d : IEquatable<Coord2d>
    {
        public double X;
        public double Y;

        public override bool Equals(object obj)
            => obj is Coord2d d && Equals(d);

        public bool Equals(Coord2d other)
            => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Coord2d left, Coord2d right)
            => left.Equals(right);
        public static bool operator !=(Coord2d left, Coord2d right)
            => !(left == right);
        public override string ToString()
            => $"({X}, {Y})";
    }
}
