using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_ShouldSetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void Log_InvalidErrorText_ShouldThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            // Equivalent to:
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>);
        }

        [Test]
        public void Log_ValidError_RaisesErrorLogEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

    }
}
