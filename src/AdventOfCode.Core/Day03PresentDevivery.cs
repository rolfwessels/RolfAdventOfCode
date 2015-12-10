using System;
using System.Collections.Generic;

namespace AdventOfCode.Core
{
    public class Day03PresentDevivery
    {
        private readonly Dictionary<Point, int> locations;
        private Point _currentLocation;

        public Day03PresentDevivery()
        {
            locations = new Dictionary<Point, int>();
            _currentLocation = new Point(0, 0);
            AddOrUpdateLocation(_currentLocation);
        }

        public int Calculate(string directions)
        {
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case '>' :
                        SetLocation(_currentLocation.Right());
                        break;
                    case 'v':
                        SetLocation(_currentLocation.Down());
                        break;
                    case '^':
                        SetLocation(_currentLocation.Up());
                        break;
                    case '<':
                        SetLocation(_currentLocation.Left());
                        break;
                }
            }
            return locations.Count;
        }

        #region Private Methods

        private void SetLocation(Point newLocation)
        {
            _currentLocation = newLocation;
            AddOrUpdateLocation(_currentLocation);
        }

        private void AddOrUpdateLocation(Point point)
        {
            if (locations.ContainsKey(point))
            {
                locations[point]++;
                return;
            }
            locations.Add(point, 1);
        }

        #endregion

        #region Nested type: Point

        public class Point
        {
            private readonly int _x;
            private readonly int _y;

            public Point(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public int X
            {
                get { return _x; }
            }

            public int Y
            {
                get { return _y; }
            }

            #region Equality members

            protected bool Equals(Point other)
            {
                return _x == other._x && _y == other._y;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Point) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (_x*397) ^ _y;
                }
            }


            public override string ToString()
            {
                return string.Format("[{0},{1}]", X, Y);
            }

            #endregion

            public Point Down()
            {
                return new Point(X,Y+1);
            }

            public Point Up()
            {
                return new Point(X, Y - 1);
            }

            public Point Right()
            {
                return new Point(X + 1, Y );
            }
            public Point Left()
            {
                return new Point(X - 1, Y );
            }
        }

        #endregion
    }
}