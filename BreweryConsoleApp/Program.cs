using System;
using System.Diagnostics;
using System.IO;

namespace BreweryConsoleApp
{
    class Program
    {
        public static TraceSource TRACE;
        static void Main(string[] args)
        {
            TRACE = new TraceSource("Brewery");
            TRACE.Listeners.Add(
                new TextWriterTraceListener(
                    new StreamWriter(@"c:\Logfiler\Brewery.txt")));
            TRACE.Listeners.Add(new ConsoleTraceListener());


            TRACE.Switch = new SourceSwitch("Brewery", "all");

            BreweryWorker worker = new BreweryWorker();
            worker.Start();

            Console.WriteLine("Simulation finished - look in logfile");
            Console.ReadLine();
        }
    }
}
