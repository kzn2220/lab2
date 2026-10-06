using System.Collections.Generic;
using System.IO;

namespace пр2
{
    internal class ShapeReader
    {
        public static List<Shape> ReadFromFile(string path)
        {
            var shapes = new List<Shape>();
            int lineNumber = 0;

            foreach (string line in File.ReadLines(path))
            {
                lineNumber++;
                string trimmed = line.Trim().TrimStart('\uFEFF');

                if (trimmed.Length == 0)
                    continue;

                Shape shape = Shape.TryParse(trimmed);

                if (shape == null)
                {
                    Logger.Print($"Строка {lineNumber}: не удалось распарсить «{trimmed}»");
                }
                else
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }
    }
}