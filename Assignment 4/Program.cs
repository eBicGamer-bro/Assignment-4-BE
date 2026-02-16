using System.Reflection.Metadata;
using System.Text;

namespace Assignment_4
{
    internal class Program
    {
        struct BankAccount
        {
            string name;
            string accountNumber;
            string pin;
            double balance;
            StringBuilder transactions = new StringBuilder();
                public BankAccount(string name, string accountNumber, string pin, double balance = 0.0)
                {
                    this.name = name;
                    this.accountNumber = accountNumber;
                    this.pin = pin;
                    this.balance = balance;
                }
                public void CheckBalance()
                {
                    Console.WriteLine($"Your current balance is: {balance}");
                }
                public void Deposit(double amount)
                {
                    if(amount <= 0)
                    {
                        Console.WriteLine("Deposit amount must be greater than zero.");
                        return;
                    }
                balance += amount;
                transactions.AppendLine($"Date: {DateTime.Now}  Transaction Type: Deposit  Amount: {amount}  New Balance: {balance}");
                Console.WriteLine("Deposit Successfull!");

            }
            public void Withdraw(double amount)
            {
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds.");
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be greater than zero.");
                }
                else
                {
                    balance -= amount;
                    transactions.AppendLine($"Date: {DateTime.Now}  Transaction Type: Withdraw  Amount: {amount}  New Balance: {balance}");
                    Console.WriteLine("Withdraw Successfull!");
                }
                
            }
                public string getAccountNumber()
            {
                return accountNumber;
            }
                public string getName()
            {
                return name;
            }
                public string getPin()
            {
                return pin;
            }
                public string getTransaction()
            {
                return transactions.ToString();
            }

            }
        static bool CheckName(string name)
        {
            if (name.Length == 0)
                return false;
            for (int i = 0; i < name.Length; i++)
                if (!(name[i] >= 'A' && name[i] <= 'Z') && !(name[i] >= 'a' && name[i] <= 'z'))
                    return false;
            return true;
        }
        static bool CheckNum(string number) {
            for (int i = 0; i<number.Length; i++)
                if (!(number[i] >= '0' && number[i] <= '9'))
                    return false;
            return true;

        }
        static bool PinChecker(string pin, string accountPin)
        {
            int pin1, pin2;
            if (!int.TryParse(pin, out pin1))
                return false;
            pin2 = int.Parse(accountPin);
            if (pin1 == pin2)
                return true;
            return false;

        }
        static void CreateAccount(List<BankAccount> accounts)
        {
            string name,accountNumber,pin;
      
            while (true)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                if (!CheckName(name))
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }
                 
                break;
            }
            while (true) {
                Console.Write("Enter a PIN (4 digits): ");
                pin = Console.ReadLine();
                if (!CheckNum(pin))
                {
                    Console.WriteLine("Invalid PIN! Only digits!");
                    continue;
                }
                else if(pin.Length!=4)
                {
                    Console.WriteLine("Invalid PIN! Has to be 4 digits!");
                    continue;
                }
                break;
            }
            do
            {
                bool flag = true;
                accountNumber = Random.Shared.Next(1000000, 9999999).ToString();
                for(int i = 0; i < accounts.Count; i++)
                {
                    if (accountNumber == accounts[i].getAccountNumber())
                    {flag = false; break;}
                }
                if(flag)
                break;
            } while (true);
            accounts.Add(new BankAccount(name, accountNumber, pin));
            Console.WriteLine($"Account Created Successfully! Your account number is {accountNumber}");
        }
        static void Login(List<BankAccount> accounts)
        {
            string accountNumber, pin;
            bool flag = false;
            Console.Write("Enter Your Account Number: ");
            accountNumber = Console.ReadLine();
            int i;
            for(i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].getAccountNumber() == accountNumber)
                {
                    flag = true;
                    break;
                }
            }
            if(!flag)
            {
                Console.WriteLine("Account Not Found!\n Returning...");
                return;
            }
            while (true)
            {
                Console.Write("Enter Your PIN: ");
                pin = Console.ReadLine();
                if (PinChecker(pin, accounts[i].getPin()))
                    break;
                Console.WriteLine("Invalid PIN!");
            }
            Console.WriteLine($"Welcome {accounts[i].getName()}!");
            accounts[i] = Interface(accounts[i]);

        }
        static BankAccount Interface(BankAccount account)
        {
            int choice;
            double amount;
            while (true)
            {
                Console.WriteLine("1) Check Balance\n2) Withdraw\n3) Deposit\n4) View Transaction\n5) Logout");
                Console.Write("\nEnter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input Type!");
                    continue;
                }
                switch (choice)
                {
                    case 1: account.CheckBalance(); break;
                    case 2: { 
                            while (true)
                            { Console.Write("Enter the amount you want to withdraw: ");
                                if (!double.TryParse(Console.ReadLine(), out amount))
                                {
                                    Console.WriteLine("Invalid Input Type!");
                                    continue;
                                }
                                break;
                            }
                            account.Withdraw(amount);
                            }; 
                        break;
                    case 3: { 
                            while (true)
                            { Console.Write("Enter the amount you want to deposit: ");
                                if (!double.TryParse(Console.ReadLine(), out amount))
                                {
                                    Console.WriteLine("Invalid Input Type!");
                                    continue;
                                }
                                break;
                            }
                            account.Deposit(amount);
                            }; break;
                    case 4: Console.WriteLine(account.getTransaction());break;
                    case 5: return account;
                    default: Console.WriteLine("Invalid Choice!"); break;
                }

            }

        }
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            int choice;
            Console.WriteLine("Welcome to Bank Managment System!\n");
            while (true)
            {
                Console.WriteLine("1) Create an account\n2) Login\n3) Exit");
                Console.Write("\nEnter your choice: ");
                if(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input Type!");
                    continue;
                }
                switch (choice)
                {
                    case 1: CreateAccount(accounts);break;
                    case 2: Login(accounts);break;
                    case 3: Console.WriteLine("Exiting the Program...");return;
                    default: Console.WriteLine("Invalid Choice!");break;
                }
            }
           
        }
    }
}

    

