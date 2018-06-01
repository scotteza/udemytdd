using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_WhenCalledWithMultipleOf5And3_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_WhenCalledWithMultipleOf5AndNot3_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_WhenCalledWithMultipleOf3AndNot5_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(6);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_WhenCalledWithNumberThatIsNotAMultipleOf3AndNotAMultipleOf5_ReturnTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(7);

            Assert.That(result, Is.EqualTo("7"));
        }
    }
}
