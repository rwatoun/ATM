
namespace ATM.Models
{
    using System;

    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double cardBalance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double cardBalance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.cardBalance = cardBalance;

        }

        public string getNum()
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin;
        }
        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }
        public double getCardBalance()
        {
            return cardBalance;
        }

        public void setCardNum(string newCardNum)
        {
            this.cardNum = newCardNum;
        }
        public void setPin(int newPin)
        {
            this.pin = newPin;
        }
        public void setFirstName(string newFirstName)
        {
            this.firstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            this.lastName = newLastName;
        }
        public void setCardBalance(double newCardBalance)
        {
            this.cardBalance = newCardBalance;
        }


    }
}