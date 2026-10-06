using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр2
{
    internal class CountOperation : Operation
    {
        public override void Execute(List<Shape> shapes)
        {
            Console.WriteLine(shapes.Count);
        }
    }
}
