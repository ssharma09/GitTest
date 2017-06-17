using NUnit.Framework;
using System;
namespace CreditCardValidation
{
    [TestFixture()]
    public class CreditCardTests
    {
		CreditCardValidator creditCard = new CreditCardValidator();

        [Test()]
        public void ShouldBeVisaValidCase1()
        {
           
            var result = creditCard.ValidateCreditCard("4111111111111111");

            Assert.That(result, Is.EqualTo("VISA: 4111111111111111(Valid)"));

        }
		[Test()]
		public void ShouldBeVisaInvalid()
		{
			
			var result = creditCard.ValidateCreditCard("4111111111111");

			Assert.That(result, Is.EqualTo("VISA: 4111111111111(Invalid)"));

		}
		[Test()]
		public void ShouldBeVisaValidCase2()
		{
			
			var result = creditCard.ValidateCreditCard("4012888888881881");

			Assert.That(result, Is.EqualTo("VISA: 4012888888881881(Valid)"));

		}
		[Test()]
		public void ShouldBeAmexValid()
		{
			
			var result = creditCard.ValidateCreditCard("378282246310005");

			Assert.That(result, Is.EqualTo("AMEX: 378282246310005(Valid)"));

		}
		[Test()]
		public void ShouldBeDiscoverValid()
		{
			;
			var result = creditCard.ValidateCreditCard("6011111111111117");

			Assert.That(result, Is.EqualTo("Discover: 6011111111111117(Valid)"));

		}
        [Test()]
		public void ShouldBeMastercardValid()
		{
			
			var result = creditCard.ValidateCreditCard("5105105105105100");

			Assert.That(result, Is.EqualTo("MasterCard: 5105105105105100(Valid)"));

		}
		[Test()]
		public void ShouldBeMasterCardInvalid()
		{
			
			var result = creditCard.ValidateCreditCard("5105105105105106");

			Assert.That(result, Is.EqualTo("MasterCard: 5105105105105106(Invalid)"));

		}

        [Test()]
		public void ShouldBeUnknownInvalid()
		{
			
			var result = creditCard.ValidateCreditCard("9111111111111111");

			Assert.That(result, Is.EqualTo("Unknown: 9111111111111111(Invalid)"));

		}
		[Test()]
		public void ShouldBeValidatedWithSpaces()
		{

			var result = creditCard.ValidateCreditCard("4408 0412 3456 7893");

			Assert.That(result, Is.EqualTo("VISA: 4408041234567893(Valid)"));

		}
		[Test()]
		public void ShouldBeValidatedForCharacterString()
		{

			var result = creditCard.ValidateCreditCard("dasdadadaddadasd");

			Assert.That(result, Is.EqualTo("Unknown: dasdadadaddadasd(Invalid)"));

		}

    }
}
