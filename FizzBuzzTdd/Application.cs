using FizzBuzzTdd.Wrappers;

namespace FizzBuzzTdd
{
    public class Application
    {
        private readonly IFizzBuzzer _fizzBuzzer;
        private readonly IConsoleWrapper _console;

        public Application(IFizzBuzzer fizzBuzzer, IConsoleWrapper console)
        {
            _fizzBuzzer = fizzBuzzer;
            _console = console;
        }

        public void Run()
        {
            for (var i = 1; i <= 15; i++)
            {
                var result = _fizzBuzzer.Buzz(i);
                _console.WriteLine(result);
            }
        }
    }
}
