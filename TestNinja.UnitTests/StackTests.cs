using System.Collections;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void Count_WhenCalled_GivesCorrectValue(int numberOfElementsToAdd)
        {
            for (var i = 0; i < numberOfElementsToAdd; i++)
            {
                _stack.Push(i.ToString());
            }

            Assert.That(_stack.Count, Is.EqualTo(numberOfElementsToAdd));
        }

        [Test]
        public void Push_WhenNullParameterUsed_ThrowsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenCalledWithValidArgument_PushesElementOntoStack()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
            Assert.That(_stack.Peek, Is.EqualTo("a"));
        }

        [Test]
        public void Pop_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_ReturnsLastElementAdded()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Pop(), Is.EqualTo("c"));
        }

        [Test]
        public void Pop_WhenCalled_DecreasesTheSizeOfTheStack()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnsTheLastElementAdded()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_WhenCalled_DoesntPopTheLastElement()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
