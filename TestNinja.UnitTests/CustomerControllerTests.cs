using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ShouldReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // Exact match.
            Assert.That(result, Is.TypeOf<NotFound>());

            // Can also do this. Also consider derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ShouldReturnOk()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
