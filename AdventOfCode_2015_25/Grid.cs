using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2015_25
{
    public class Grid
    {
        private const long _initialValue = 20151125;

        private Dictionary<Coordinate, long> _cache = new Dictionary<Coordinate, long>()
        {
            { new Coordinate(1,1), _initialValue }
        };

        public long At(Coordinate coordinate)
        {
            if (coordinate.Row < 0)
                throw new ArgumentOutOfRangeException(nameof(coordinate.Row));

            if (coordinate.Column < 0)
                throw new ArgumentOutOfRangeException(nameof(coordinate.Column));

            if (!_cache.ContainsKey(coordinate))
                Fill(LatestCoordinate(), coordinate);

            return _cache[coordinate];
        }

        public long At(int row, int column) => At((row, column));

        public static Coordinate Previous(Coordinate coordinate)
        {
            if (coordinate.Row == 1 && coordinate.Column == 1)
                throw new ArgumentOutOfRangeException(nameof(coordinate), "No previous coordinate.");

            var testColumn = coordinate.Column - 1;
            var newRow = testColumn == 0 ? 1 : coordinate.Row + 1;
            var newColumn = testColumn == 0 ? coordinate.Row - 1 : testColumn;

            return (newRow, newColumn);
        }

        public static Coordinate Previous(int row, int column) => Previous((row, column));

        public static Coordinate Next(Coordinate coordinate)
        {
            var testRow = coordinate.Row - 1;
            var newColumn = testRow == 0 ? 1 : coordinate.Column + 1;
            var newRow = testRow == 0 ? coordinate.Column + 1 : testRow;

            return (newRow, newColumn);
        }

        private Coordinate LatestCoordinate() => _cache.Keys.MaxBy(k => k.Row + k.Column)
                                                            .MaxBy(k => k.Column)
                                                            .FirstOrDefault();

        private void Fill(Coordinate start, Coordinate finish)
        {
            //vulnerable to mis-ordering of arguments; could be solved by making Coordinate implement IComparable<ICoordinate>
            var previous = start;
            var current = Next(start);

            while (current <= finish)
            {
                _cache[current] = (At(previous) * 252533) % 33554393;
                previous = current;
                current = Next(current);
            }
        }
    }
}
