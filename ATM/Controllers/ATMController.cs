using Microsoft.AspNetCore.Mvc;
using ATM.Models;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Controllers
{
    public class ATMController : Controller
    {
        // Simulated "database"
        static List<cardHolder> cardHolders = new List<cardHolder>
        {
            new cardHolder("45327772818527395", 1234, "John", "Doe", 150.31),
            new cardHolder("45327672881527392", 3210, "Ashley", "Jones", 321.13)
        };

        // Display the Home page
        public IActionResult Index()
        {
            return View();
        }

        // Validate Card Number and PIN
        [HttpPost]
        public IActionResult Login(string cardNum, int pin)
        {
            // Validate both card number and PIN
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum && c.getPin() == pin);

            if (user == null)
            {
                // If invalid, return an error message to the Index view
                ViewBag.ErrorMessage = "Invalid Card Number or PIN. Please try again.";
                return View("Index");
            }

            // If valid, pass user data to the Balance view
            ViewBag.Balance = user.getCardBalance();
            ViewBag.CardNum = cardNum;
            return View("Balance");
        }

        // This method is only when the pin is verified.
        public IActionResult Balance(string cardNum)
        {
            // Find the user by card number
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);

            // Pass balance and card number to the view
            ViewBag.Balance = user.getCardBalance();
            ViewBag.CardNum = cardNum;

            // Return the Balance view
            return View();
        }


        // // Deposit money
        // public IActionResult Deposit(string cardNum, double amount)
        // {
        //     var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
        //     if (user == null)
        //     {
        //         ViewBag.ErrorMessage = "Card not recognized.";
        //         return View("Index");
        //     }

        //     user.setCardBalance(user.getCardBalance() + amount);
        //     ViewBag.Balance = user.getCardBalance();
        //     return View("Balance");
        // }

        // // Withdraw money
        // public IActionResult Withdraw(string cardNum, double amount)
        // {
        //     var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
        //     if (user == null)
        //     {
        //         ViewBag.ErrorMessage = "Card not recognized.";
        //         return View("Index");
        //     }

        //     if (user.getCardBalance() < amount)
        //     {
        //         ViewBag.ErrorMessage = "Insufficient funds.";
        //         return View("Balance");
        //     }

        //     user.setCardBalance(user.getCardBalance() - amount);
        //     ViewBag.Balance = user.getCardBalance();
        //     return View("Balance");
        // }
    }
}
