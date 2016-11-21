using FizzBuzzTdd.Wrappers;

namespace FizzBuzzTdd
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new Application(new FizzBuzzer(), new ConsoleWrapper());

            app.Run();
        }
    }
}
