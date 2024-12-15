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
            currentUser.setCardBalance(currentUser.getCardBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is: " + currentUser.getCardBalance());

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = double.Parse(Console.ReadLine());
            // Check if the user has enough money

            if (currentUser.getCardBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds :(");
            }
            else
            {
                currentUser.setCardBalance(currentUser.getCardBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getCardBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("45327772818527395", 1234, "John", "Doe", 150.31));
        cardHolders.Add(new cardHolder("45327672881527392", 3210, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("51283322818527395", 9999, "Antony", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("60117772818527215", 2468, "Muneb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("34907772818521495", 4826, "Dawn", "Smith", 54.27));

        // Prompting the user!
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against DB
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }


            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");

            }

        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pin not recognized. Please try again.");
                }


            }
            catch
            {
                Console.WriteLine("Pin not recognized. Please try again.");

            }

        }
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " !");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    option = 0;
                    break;
                case 2:
                    withdraw(currentUser);
                    option = 0;
                    break;
                case 3:
                    balance(currentUser);
                    option = 0;
                    break;
                case 4:
                    break;

            }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");

    }
}
