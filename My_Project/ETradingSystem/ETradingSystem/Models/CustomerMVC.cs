using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETradingSystem.Models
{
    public class CustomerMVC
    {
        public int customer_id { get; set; }

        public string customer_name { get; set; }

        public DateTime dob { get; set; }

        public int phone_no { get; set; }

        public int account_balance { get; set; }
    }

public class UserAccount

    {

        public decimal AccountBalance { get; set; } // User's account balance

        // Function to simulate a user buying a product

        public string BuyProduct(decimal productPrice)

        {

            if (AccountBalance >= productPrice)

            {

                // User has enough money, deduct the product price from account balance

                AccountBalance -= productPrice;

                return "Thank you for shopping";

            }

            else

            {

                // Insufficient funds in the account

                return "Please update your account";

            }

        }

    }

}