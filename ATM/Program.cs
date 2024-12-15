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
        double cardBalance = cardBalance;

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

    public void setCardNum(int newCardNum)
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

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setCardBalance(deposit);
            Console.WriteLine("Thank you for your money. Your new balance is: " + currentUser.getCardBalance());

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = double.Parse(Console.ReadLine());
            // Check if the user has enough money

            if (currentUser.getCardBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient funds :(");
            }
            else
            {
                currentUser.setCardBalance(currentUser.getCardBalance() - withdrawal);
                ConsoleWriteLine("You're good to go! Thank you.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getCardBalance())
        }
    }
}
