namespace FizzBuzzTdd
{
    public interface IFizzBuzzer
    {
        string Buzz(int number);
    }

    public class FizzBuzzer : IFizzBuzzer
    {
        public string Buzz(int number)
        {
            var result = $"{FizzIfDivisibleByThree(number)}{BuzzIfDivisibleByFive(number)}";

            return result != "" ? result : number.ToString();
        }

        private string FizzIfDivisibleByThree(int number)
        {
            return IsDivisibleByThree(number) ? "Fizz" : "";
        }

        private string BuzzIfDivisibleByFive(int number)
        {
            return IsDivisibleByFive(number) ? "Buzz" : "";
        }

        private bool IsDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }

        private bool IsDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }
    }
}
