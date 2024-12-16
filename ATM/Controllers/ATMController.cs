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

        // Show balance
        public IActionResult Balance(string cardNum)
        {
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Card not recognized. Please try again.";
                return View("Index");
            }

            ViewBag.Balance = user.getCardBalance();
            ViewBag.CardNum = cardNum;
            return View("Pin");
        }

        [HttpPost]
        public IActionResult VerifyPin(string cardNum, int pin)
        {
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Card not recognized. Please try again.";
                return View("Index");
            }

            if (user.getPin() != pin)
            {
                ViewBag.ErrorMessage = "Incorrect PIN. Please try again.";
                ViewBag.CardNum = cardNum;
                return View("Pin");
            }

            // PIN is correct, proceed to show balance and options
            ViewBag.Balance = user.getCardBalance();
            ViewBag.CardNum = cardNum;
            return View("Balance");
        }


        // Deposit money
        public IActionResult Deposit(string cardNum, double amount)
        {
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Card not recognized.";
                return View("Index");
            }

            user.setCardBalance(user.getCardBalance() + amount);
            ViewBag.Balance = user.getCardBalance();
            return View("Balance");
        }

        // Withdraw money
        public IActionResult Withdraw(string cardNum, double amount)
        {
            var user = cardHolders.FirstOrDefault(c => c.getNum() == cardNum);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Card not recognized.";
                return View("Index");
            }

            if (user.getCardBalance() < amount)
            {
                ViewBag.ErrorMessage = "Insufficient funds.";
                return View("Balance");
            }

            user.setCardBalance(user.getCardBalance() - amount);
            ViewBag.Balance = user.getCardBalance();
            return View("Balance");
        }
    }
}
