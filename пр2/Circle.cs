using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace пр2
{
    internal class Circle : Shape
    {
        public Point Center { get; }
        public double Radius { get; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Circle({0}, {1})", Center, Radius);
        }

        public static Circle TryParse(string line)
        {
            var m = Regex.Match(line,
                @"^Circle\s*\(\s*Point\s*\(\s*([-+]?\d*\.?\d+)\s*,\s*([-+]?\d*\.?\d+)\s*\)\s*,\s*([-+]?\d*\.?\d+)\s*\)$");
            if (!m.Success) return null;
            try
            {
                var c = new Point(
                    double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture),
                    double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture));
                double r = double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture);
                return new Circle(c, r);
            }
            catch { return null; }
        }
    }
}