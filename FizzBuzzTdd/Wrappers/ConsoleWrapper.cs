using System;

namespace FizzBuzzTdd.Wrappers
{
    public interface IConsoleWrapper
    {
        void WriteLine(string output);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
