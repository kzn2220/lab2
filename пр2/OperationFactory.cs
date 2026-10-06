using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр2
{
    internal class OperationFactory
    {
        public static Operation Create(string name)
        {
            switch (name?.ToLower())
            {
                case "print": return new PrintOperation();
                case "count": return new CountOperation();
                default: return null;
            }
        }
    }
}
