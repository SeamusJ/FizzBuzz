using System;
using FizzBuzzTdd.Wrappers;
using FluentAssertions;
using Moq;
using Xunit;

namespace FizzBuzzTdd.Tests
{
    public class ApplicationTests
    {
        private readonly Mock<IFizzBuzzer> _fizzBuzzer;
        private readonly Mock<IConsoleWrapper> _consoleWrapper;
        private readonly Application _application;
        private string _output;

        public ApplicationTests()
        {
            _output = "";
            _fizzBuzzer = MockFizzBuzzer();
            _consoleWrapper = MockConsoleWrapper();
            _application = new Application(_fizzBuzzer.Object, _consoleWrapper.Object);
        }

        [Fact]
        public void Run_ShouldCallBuzzFifteenTimes()
        {
            _application.Run();

            _fizzBuzzer.Verify(fb => fb.Buzz(It.IsAny<int>()), Times.Exactly(15));
            _fizzBuzzer.Verify(fb => fb.Buzz(1), Times.Once);
            _fizzBuzzer.Verify(fb => fb.Buzz(2), Times.Once);
            _fizzBuzzer.Verify(fb => fb.Buzz(3), Times.Once);
            _fizzBuzzer.Verify(fb => fb.Buzz(15), Times.Once);
        }

        [Fact]
        public void Run_ShouldPrintOutput()
        {
            _application.Run();

            _consoleWrapper.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(15));
            _output.Should().Be("1\r\n" + 
                                "2\r\n" +
                                "3\r\n" +
                                "4\r\n" +
                                "5\r\n" +
                                "6\r\n" +
                                "7\r\n" +
                                "8\r\n" +
                                "9\r\n" +
                                "10\r\n" +
                                "11\r\n" +
                                "12\r\n" +
                                "13\r\n" +
                                "14\r\n" +
                                "15\r\n");
        }

        private Mock<IFizzBuzzer> MockFizzBuzzer()
        {
            var fizzBuzzer = new Mock<IFizzBuzzer>();
            Func<int, string> buzz = (number) => number.ToString();
            fizzBuzzer.Setup(fb => fb.Buzz(It.IsAny<int>())).Returns(buzz);
            return fizzBuzzer;
        }

        private Mock<IConsoleWrapper> MockConsoleWrapper()
        {
            var consoleWrapper = new Mock<IConsoleWrapper>();
            Action<string> writeLine = (output) =>
            {
                _output += output + "\r\n";
            };

            consoleWrapper.Setup(console => console.WriteLine(It.IsAny<string>())).Callback(writeLine);
            return consoleWrapper;
        }
    }
}
