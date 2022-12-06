using System;

public class cardHolder
{
    string cardNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public string getNum()
    {
        return cardNumber;
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

    public double getBalance()
    {
        return balance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            currentUser.balance += depositAmount;
            Console.WriteLine("Your new balance is: " + currentUser.balance);
        }
        
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double withrawal = Convert.ToDouble(Console.ReadLine());
            if (currentUser.getBalance()< withrawal)
            {
                Console.WriteLine("Insufficient balance :/");
            }
            else
            {
                currentUser.balance -= withrawal;
                Console.WriteLine("Your new balance is: " + currentUser.balance);
            }
        }
        
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        cardHolders.Add(new cardHolder("123456789", 1234, "Oktay", "Dak", 1000));

        //Promt user

        Console.WriteLine("Welcome to the DAK ATM");

        Console.WriteLine("Please insert your debit card:");

        string debitCardNum = "";

        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();

                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNum);
                
                if (currentUser != null)
                
                {
                    break;
                }
                
                else
                {
                    Console.WriteLine("Invalid card number. Please try again.");
                }
                
            }
            catch
            {
                Console.WriteLine("Invalid card number. Please try again.");
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
                    Console.WriteLine("Incorrect pin. Please try again.");
                }

            }

            catch
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }
        }
        Console.WriteLine("Welcome" + currentUser.getLastName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch{ }

            if(option == 1) 
            { 
                deposit(currentUser); 
            }
            else if(option == 2) 
            {
                withdraw(currentUser ); 
            }
            else if(option == 3) 
            { 
                balance(currentUser); 
            }
            else if(option == 4) 
            { 
                break; 
            }
            else 
            { 
                option = 0; 
            }
        }

        while (option != 4);

        Console.WriteLine("Thank you! Have a nice day :)");
    }
}