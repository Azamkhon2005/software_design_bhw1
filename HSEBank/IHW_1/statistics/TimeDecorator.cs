using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHW_1.statistics
{
    






    // Декоратор для измерения времени
    internal class TimingCommandDecorator : ICommand
    {
        private readonly ICommand _command;
        private  double duration = 0;
        public TimingCommandDecorator(ICommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public void Execute()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _command.Execute();
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения команды '{_command.GetType().Name}': {stopwatch.ElapsedMilliseconds} мс");
            duration = stopwatch.ElapsedMilliseconds;
        }
        public double Duration {  get { return duration; } }
        public string CommandName { get { return nameof( _command ); } }
    }

    
}
