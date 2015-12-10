using System;
using System.Linq;

namespace AdventOfCode.Core
{
    public class Day02WrappingPaper
    {
        public int Calculate(string dimensions)
        {
            return dimensions.Split('\n').Sum(line => CalculateLine(line.Trim()));
        }

        private static int CalculateLine(string dimensions)
        {
            var dim = dimensions.Split('x').Select(x => Convert.ToInt32(x)).ToArray();
            var sqr = new[] {dim[0]*dim[1], dim[1]*dim[2], dim[2]*dim[0]};
            return sqr.Sum(x => 2*x) + sqr.Min();
        }
    }
}