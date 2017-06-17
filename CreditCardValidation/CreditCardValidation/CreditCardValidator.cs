using System;
using System.Linq;
namespace CreditCardValidation
{
    public class CreditCardValidator
    {
  	    public string ValidateCreditCard(string strCCNumber)
			{
				string resultStatus = string.Empty;
				string strCardType = "Unknown: ";

				// Length and Credit card pattern's validation
				if (string.IsNullOrEmpty(strCCNumber))
				{
					return "Enter a card number";
				}
                strCCNumber = strCCNumber.Replace(" ", "");
				int ccNumLength = strCCNumber.Length;


		            if ((strCCNumber.Substring(0, 2) == "34" || (strCCNumber.Substring(0, 2) == "37")) && (ccNumLength == 15))
		            { strCardType = "AMEX: "; }
					if ((strCCNumber.Substring(0, 2) == "51" || (strCCNumber.Substring(0, 2) == "52")
                         || (strCCNumber.Substring(0, 2) == "53")|| (strCCNumber.Substring(0, 2) == "54")
                         || (strCCNumber.Substring(0, 2) == "55")) && (ccNumLength == 16))		
		            { strCardType = "MasterCard: "; }
					if ((strCCNumber.Substring(0, 1) == "4") && (ccNumLength == 13 || ccNumLength == 16))
					{ strCardType = "VISA: "; }
					if ((strCCNumber.Substring(0, 4) == "6011") && (ccNumLength == 16))
					{ strCardType = "Discover: "; }

				//Luhn validation
				int index = 0;
				int sum = 0;
                foreach (int number in strCCNumber.Where((e) => e >= '0' && e <= '9').Reverse())
				{
					int temp = (index % 2 == 0 ? number - 48 : (number - 48) * 2);
					sum += temp >= 9 ? temp - 9 : temp;
					index++;
				}

				if(sum ==0 || (sum % 10 != 0)) { resultStatus = strCardType + strCCNumber + "(Invalid)"; }
				else if (sum % 10 == 0)
				{ resultStatus = strCardType + strCCNumber + "(Valid)"; }
			

				return resultStatus;
			}
		}
}
