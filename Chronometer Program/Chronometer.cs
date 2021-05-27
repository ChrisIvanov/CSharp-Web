using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab
{
    public class Chronometer : IChronometer
    {
        private static DateTime chronometerTime = DateTime.Now;
        private static List<string> lapCounter = new List<string>();
        private static DateTime startTime = DateTime.Now;
        private static bool isStarted = new bool();
        private static TimeSpan difference = new TimeSpan();
        private static TimeSpan actualTime = new TimeSpan();

        public Chronometer()
        {
            isStarted = false;
            startTime = DateTime.Now;
            chronometerTime = DateTime.Now;
            lapCounter = new List<string>();
        }

        public string GetTime => lapCounter[lapCounter.Count - 1].ToString();

        public List<string> Laps => lapCounter;

        public string Lap()
        {
            if (isStarted)
            {
                chronometerTime = DateTime.Now;
                difference = chronometerTime - startTime;
                actualTime = TimeSpan.FromMinutes(difference.TotalMinutes);
                lapCounter.Add(actualTime.ToString());

                return actualTime.ToString();
            }

            return "Please Start chronometer first!";
        }

        public void Reset()
        {
            this.Stop();
            chronometerTime = DateTime.Now;
            startTime = DateTime.Now;

            lapCounter.Clear();
        }

        public void Start()
        {
            if (!isStarted)
            {
                isStarted = true;
                chronometerTime = DateTime.Now;
                startTime = DateTime.Now;

                return;
            }

            Console.WriteLine("Chronometer is already started");
        }

        public void Stop()
        {
            if (isStarted)
            {
                isStarted = false;
                difference = chronometerTime - startTime;
                actualTime = TimeSpan.FromMinutes(difference.TotalMinutes);
                return;
            }

            Console.WriteLine("Please Start Chronometer before Stopping!");
        }
    }
}
