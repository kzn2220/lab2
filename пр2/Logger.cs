using System;
using System.IO;

namespace пр2
{
    internal static class Logger
    {
        private static TextWriter _errorWriter;

        public static void Configure(string logPath, bool echoToConsole)
        {
            string dir = Path.GetDirectoryName(logPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var fileWriter = new StreamWriter(logPath, append: true)
            {
                AutoFlush = true
            };

            if (echoToConsole)
            {
                var originalError = Console.Error;
                _errorWriter = new MultiWriter(originalError, fileWriter);
            }
            else
            {
                _errorWriter = fileWriter;
            }

            Console.SetError(_errorWriter);
        }

        public static void Print(string message)
        {
            Console.Error.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        public static void Shutdown()
        {
            Console.Error.Flush();
            Console.Error.Close();
        }

        private class MultiWriter : TextWriter
        {
            private readonly TextWriter _a;
            private readonly TextWriter _b;

            public MultiWriter(TextWriter a, TextWriter b)
            {
                _a = a;
                _b = b;
            }

            public override System.Text.Encoding Encoding => _a.Encoding;

            public override void Write(char value)
            {
                _a.Write(value);
                _b.Write(value);
            }

            public override void Write(string value)
            {
                _a.Write(value);
                _b.Write(value);
            }

            public override void WriteLine(string value)
            {
                _a.WriteLine(value);
                _b.WriteLine(value);
            }

            public override void Flush()
            {
                _a.Flush();
                _b.Flush();
            }
        }
    }
}