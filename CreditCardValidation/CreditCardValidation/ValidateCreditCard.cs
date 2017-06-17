using System;
namespace CreditCardValidation
{
    public class ValidateCreditCard
    {
        
			public static string ValidateCreditCard(string strCCNumber)
			{
				string resultStatus = string.Empty;
				string strCardType = string.Empty;
				// Length and Pattern validation
				if (string.IsNullOrEmpty(strCCNumber))
				{
					return "Enter a card number";
				}
				int ccNumLength = strCCNumber.Length;
				if ((strCCNumber.Substring(0, 2) == "34" || (strCCNumber.Substring(0, 2) == "37")) && (ccNumLength == 15))
				{ strCardType = "AMEX: "; }
				if ((int.Parse(strCCNumber.Substring(0, 2)) >= 51 && int.Parse(strCCNumber.Substring(0, 2)) <= 55) && (ccNumLength == 16))
				{ strCardType = "MasterCard: "; }
				if ((strCCNumber.Substring(0, 1) == "4") && (ccNumLength == 13 || ccNumLength == 16))
				{ strCardType = "VISA: "; }
				if ((strCCNumber.Substring(0, 4) == "6011") && (ccNumLength == 16))
				{ strCardType = "Discover: "; }
				else { strCardType = "Unknown: "; }

				//Luhn validation
				int index = 0;
				int sum = 0;
				foreach (int digit in strCCNumber.Reverse())
				{
					int temp = (index % 2 == 0 ? digit - 48 : (digit - 48) * 2);
					sum += temp >= 9 ? temp - 9 : temp;
					index++;
				}

				if ((sum > 0) && (sum % 10 == 0))
				{ resultStatus = strCardType + strCCNumber + "(Valid)"; }
				else { resultStatus = strCardType + strCCNumber + "(Invalid)"; }

				return resultStatus;
			
		}
    }
}
