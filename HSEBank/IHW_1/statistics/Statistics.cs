using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.statistics
{
    internal class Statistics
    {
        private readonly Dictionary<string, List<Double>> data = new();

        public void RunCommand(TimingCommandDecorator command)
        {
            command.Execute();
            string name = command.CommandName;
            double duration = command.Duration;
        }
        public void SaveTime(string name, double duration)
        {
            if (!data.ContainsKey(name))
                data[name] = new List<double>();

            data[name].Add(duration);
        }

        public void Report()
        {
            foreach (var (scenario, duration) in data)
            {
                var avg = duration.Average();
                Console.WriteLine($"{scenario}: Avg {avg:mm\\:ss\\.fff}, Total {duration.Count}");
            }
        }
    }
}
