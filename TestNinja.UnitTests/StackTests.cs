using System.Collections;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int?> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<int?>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void Count_WhenCalled_GivesCorrectValue(int numberOfElementsToAdd)
        {
            for (var i = 0; i < numberOfElementsToAdd; i++)
            {
                _stack.Push(i);
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
            _stack.Push(1);

            Assert.That(_stack.Count, Is.EqualTo(1));
            Assert.That(_stack.Peek, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_ReturnsLastElementAdded()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.That(_stack.Pop(), Is.EqualTo(3));
        }

        [Test]
        public void Pop_WhenCalled_DecreasesTheSizeOfTheStack()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Peek_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnsTheLastElementAdded()
        {
            _stack.Push(1);
            _stack.Push(2);
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenCalled_DoesntPopTheLastElement()
        {
            _stack.Push(1);
            _stack.Push(2);

            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
