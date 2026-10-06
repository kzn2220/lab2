using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace пр2
{
    internal class Point : Shape
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Point({0}, {1})", X, Y);
        }

        public static Point TryParse(string line)
        {
            var m = Regex.Match(line,
                @"^Point\s*\(\s*([-+]?\d*\.?\d+)\s*,\s*([-+]?\d*\.?\d+)\s*\)$");
            if (!m.Success) return null;
            try
            {
                return new Point(
                    double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture),
                    double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture));
            }
            catch { return null; }
        }
    }
}
