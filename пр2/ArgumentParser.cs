using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр2
{
    internal class ArgumentParser
    {
        public static ProgramOptions Parse(string[] args)
        {
            var opts = new ProgramOptions();
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-f":
                    case "--file":
                        if (i + 1 < args.Length) opts.FilePath = args[++i];
                        break;
                    case "-o":
                    case "--oper":
                        if (i + 1 < args.Length) opts.Operation = args[++i];
                        break;
                }
            }
            return opts;
        }
    }
}
