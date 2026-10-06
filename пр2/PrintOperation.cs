using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр2
{
    internal class PrintOperation : Operation
    {
        public override void Execute(List<Shape> shapes)
        {
            foreach (var s in shapes)
                Console.WriteLine(s);
        }
    }
}
