using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace пр2
{
    internal class Line : Shape
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return string.Format("Line({0}, {1})", Start, End);
        }

        public static Line TryParse(string line)
        {
            var m = Regex.Match(line,
                @"^Line\s*\(\s*Point\s*\(\s*([-+]?\d*\.?\d+)\s*,\s*([-+]?\d*\.?\d+)\s*\)\s*,\s*Point\s*\(\s*([-+]?\d*\.?\d+)\s*,\s*([-+]?\d*\.?\d+)\s*\)\s*\)$");
            if (!m.Success) return null;
            try
            {
                var p1 = new Point(
                    double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture),
                    double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture));
                var p2 = new Point(
                    double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture),
                    double.Parse(m.Groups[4].Value, CultureInfo.InvariantCulture));
                return new Line(p1, p2);
            }
            catch { return null; }
        }
    }
}
