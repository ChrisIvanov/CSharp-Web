using System;
using System.Text;
using System.Threading;

namespace Lab
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IChronometer chronometer = new Chronometer();

            var command = Console.ReadLine();
            while (command.ToLower() != "exit")
            {
                switch (command.ToLower())
                {
                    case "start":
                        chronometer.Start();
                        break;

                    case "stop":
                        chronometer.Stop();
                        break;

                    case "lap":
                        Console.WriteLine(chronometer.Lap()); 
                        break;

                    case "laps":
                        var laps = chronometer.Laps;

                        if (laps.Count != 0)
                        {
                            var sb = new StringBuilder();

                            for (int i = 0; i < laps.Count; i++)
                            {
                                sb.AppendLine($"{i}. {laps[i]}");
                            }

                            Console.WriteLine("Laps:");
                            Console.WriteLine(sb);
                        }
                        else
                        {
                            Console.WriteLine("Laps: no laps");
                        }
                        
                        break;

                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;

                    case "reset":
                        chronometer.Reset();
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
