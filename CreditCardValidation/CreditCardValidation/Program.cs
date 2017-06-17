using System;


namespace CreditCardValidation
{
    
   class MainClass
    {
		 
        public static void Main(string[] args)
        {
            string strCCNumber;
            string result;

            Console.WriteLine("Please enter the credit card number");
            strCCNumber = Console.ReadLine();

            CreditCardValidator creditCard = new CreditCardValidator();
            result = creditCard.ValidateCreditCard(strCCNumber);
            Console.WriteLine(result);

        }
    }
}
