using System;
using System.Collections.Generic;
using System.IO;

namespace пр2
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "пр2",
                "log.txt");

            Logger.Configure(logPath, echoToConsole: true);

            try
            {
                var opts = ArgumentParser.Parse(args);

                if (opts.FilePath == null)
                {
                    Logger.Print("Ошибка: не указан -f/--file");
                    return 1;
                }
                if (opts.Operation == null)
                {
                    Logger.Print("Ошибка: не указан -o/--oper");
                    return 1;
                }
                if (!File.Exists(opts.FilePath))
                {
                    Logger.Print($"Ошибка: файл не найден: {opts.FilePath}");
                    return 1;
                }

                List<Shape> shapes = ShapeReader.ReadFromFile(opts.FilePath);

                Operation operation = OperationFactory.Create(opts.Operation);
                if (operation == null)
                {
                    Logger.Print($"Ошибка: неизвестная операция: {opts.Operation}");
                    return 1;
                }

                operation.Execute(shapes);
                return 0;
            }
            finally
            {
                Logger.Shutdown();
            }
        }
    }
}