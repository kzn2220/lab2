using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр2
{
    internal abstract class Shape
    {
        public abstract override string ToString();

        public static Shape TryParse(string line)
        {
            return (Shape)Point.TryParse(line)
            ?? (Shape)Line.TryParse(line)
            ?? (Shape)Circle.TryParse(line);
        }
    }
}
