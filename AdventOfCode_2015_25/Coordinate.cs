using System;

namespace AdventOfCode_2015_25
{
    public sealed class Coordinate : IEquatable<Coordinate>, IComparable<Coordinate>
    {
        public int Row;
        public int Column;

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static implicit operator Coordinate((int Row, int Column) coordinate)
        {
            return new Coordinate(coordinate.Row, coordinate.Column);
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate ? Equals(obj as Coordinate) : false;
        }

        public bool Equals(Coordinate other)
        {
            if (Row != other.Row)
                return false;

            if (Column != other.Column)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode()
                 + Column.GetHashCode();
        }

        public override string ToString()
        {
            return $"({Row}, {Column})";
        }

        public int CompareTo(Coordinate other)
        {
            if (Equals(other))
                return 0;

            if (Row + Column < other.Row + other.Column)
                return -1;

            if (Column < other.Column)
                return -1;

            return 1;
        }

        public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
            => coordinate1.Equals(coordinate2);

        public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
            => !(coordinate1 == coordinate2);

        public static bool operator <(Coordinate coordinate1, Coordinate coordinate2)
            => coordinate1.CompareTo(coordinate2) < 0;

        public static bool operator <=(Coordinate coordinate1, Coordinate coordinate2)
            => coordinate1.CompareTo(coordinate2) <= 0;

        public static bool operator >(Coordinate coordinate1, Coordinate coordinate2)
            => coordinate1.CompareTo(coordinate2) > 0;

        public static bool operator >=(Coordinate coordinate1, Coordinate coordinate2)
            => coordinate1.CompareTo(coordinate2) >= 0;
    }
}
