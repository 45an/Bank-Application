using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace BankApplication
{
    class Program
    {


        public static void Main(string[] args)
        {
            // Skapar arrays med användarnamn och pinkod

            string[] accountNames = { "Muse", "Krille", "Mbappe", "Alpha", "Sandra" };
            int[] pinCodes = { 1234, 6578, 9012, 2345, 6789 };

            // Skapar en lista av olika bankkonto till varje UserName
            List<Account> bankaccounts = new List<Account>
            {
                new Account { UserName = "Muse", AccountType = "Personkonto", Balance = 1020.53m },
                new Account { UserName = "Muse", AccountType = "Sparkonto", Balance = 5037.50m },
                new Account { UserName = "Krille", AccountType = "Personkonto", Balance = 2020.30m },
                new Account { UserName = "Krille", AccountType = "Sparkonto", Balance = 6000m },
                new Account { UserName = "Krille", AccountType = "Reskonto", Balance = 16000m },
                new Account { UserName = "Mbappe", AccountType = "Personkonto", Balance = 4075.50m },
                new Account { UserName = "Mbappe", AccountType = "Sparkonto", Balance = 7000m },
                new Account { UserName = "Mbappe", AccountType = "IKSKonto", Balance = 5000m },
                new Account { UserName = "Mbappe", AccountType = "Shoppingkonto", Balance = 2000m },
                new Account { UserName = "Alpha", AccountType = "Personkonto", Balance = 4323.43m },
                new Account { UserName = "Alpha", AccountType = "Sparkonto", Balance = 4000 },
                new Account { UserName = "Alpha", AccountType = "Investeringskonto", Balance = 7000m },
                new Account { UserName = "Alpha", AccountType = "Gamingkonto", Balance = 2000m },
                new Account { UserName = "Sandra", AccountType = "Personkonto", Balance = 5223.50m },
                new Account { UserName = "Sandra", AccountType = "Sparkonto", Balance = 7000m },
                new Account { UserName = "Sandra", AccountType = "Matkonto", Balance = 3000m },

            };



            // kallar in login metoden
            LogIn(accountNames, pinCodes, bankaccounts);
            
        }

        static void LogIn(string[] accountNames, int[] pinCodes, List<Account> bankaccounts)
        {
            // Sätter max attempt för inloggningen på 3 försök
            int maxAttempts = 3;

            while (maxAttempts > 0)
            {
                // Be användaren att ange användarnamn och personlig kod
                Console.WriteLine("---- Välkomen till The Wealthy Bank ----");
                Console.Write("Ange användarnamn: ");
                string userName = Console.ReadLine();
                Console.Write("Ange ditt PIN-kod: ");
                string password = Console.ReadLine();

               
                // Lägg till en try-catch-block för att hantera tänkbara felaktiga inmatningar från användaren.
                try
                {   // använda Array.IndexOf() för att hitta användarindexet och jämföra det med pinkodens arrayen.
                    int index = Array.IndexOf(accountNames, userName);
                    if (index >= 0 && pinCodes[index] == int.Parse(password))

                    {
                        
                        Console.WriteLine("\nInloggning lyckades!");
                        MainMenu(bankaccounts, userName, accountNames, pinCodes);
                        return;
                    }
                   
                    else
                    {
                        // Om inloggningen inte går igenom, decrement nummret för försök 
                        maxAttempts--;
                        Console.WriteLine("\nInloggning misslyckades, Du har {0} försök kvar.", maxAttempts);
                        

                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInmatningen är fel, Vad vänligen och skriv in med siffror");
                }
                
                if (maxAttempts == 0)
                {
                    
                    Console.WriteLine("Du har överskridit det maximala antalet inloggningsförsök. Var god och försök igen ");
                    Environment.Exit(0);

                }




            }

            // Menysystem för användaren
            
            static void MainMenu(List<Account> bankaccounts, string userName, string[] accountNames, int[] pinCodes)
            {
                bool mainMenu = true;
                while (mainMenu)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"--- Välkomen tillbaka {userName}  ----");
                    Console.WriteLine("1. Se dina konto och saldo");
                    Console.WriteLine("2. Överföring mellan konton");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");

                    // Användaren ska välja ett av alternativerna
                    Console.Write("===> ");
                    string choices = Console.ReadLine();
                    switch (choices)
                    {
                        case "1":
                            Console.Clear();
                            ViewAccounts(bankaccounts, userName, accountNames, pinCodes);
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            TransferBetweenAccounts(bankaccounts, userName, accountNames, pinCodes);
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            WithDrawMoney(bankaccounts, userName, accountNames, pinCodes);
                            Console.Clear();
                            break;
                        case "4":
                            Console.Clear();
                            LogOut(accountNames, pinCodes, bankaccounts);
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Ogiltgt val, Vad god och försök igen");
                            MainMenu(bankaccounts, userName, accountNames, pinCodes);
                            break;
                    }
                }

            }
            


            static void ViewAccounts(List<Account> bankaccounts, string userName, string[] accountNames, int[] pinCodes)
            {
                Console.WriteLine($"\nDina konton och saldo {userName}:");

                // Loop genom kontolistan och hitta kontona som tillhör användaren.

                for (int i = 0; i < bankaccounts.Count; i++)
                {
                    // kontrollerar för varje index om bankaccounts[i].UserName är lika med variabeln userName.
                    Account account = bankaccounts[i];
                    if (bankaccounts[i].UserName == userName)
                    {
                        // Skriv ut kontotypen och saldot för användarens konton
                        Console.WriteLine($"{i}.{bankaccounts[i].AccountType}: {bankaccounts[i].Balance:C}");
                    }
                }

                Console.WriteLine("\nTryck enter för att komma till huvudmenyn.");
                Console.Write("===>");
                Console.ReadLine();
                MainMenu(bankaccounts, userName, accountNames, pinCodes);

            }


            static void TransferBetweenAccounts(List<Account> bankaccounts, string userName, string[] accountNames, int[] pinCodes)
            {


                Console.WriteLine("\nVilket konto vill du ta pengar från?");

                // Loopa genom kontolistan och hitta kontona som tillhör användaren som är inloggad just nu.

                for (int i = 0; i < bankaccounts.Count; i++)
                {
                    // kontrollerar för varje index om bankaccounts[i].UserName är lika med variabeln userName.
                    if (bankaccounts[i].UserName == userName)
                  {
                        // Skriv ut kontotypen och saldot för användarens konton
                        Console.WriteLine($"{i}. {bankaccounts[i].AccountType}: {bankaccounts[i].Balance:C}");
                  }

                }


                try
                {
                    Console.Write("Ange ditt val: ");
                    int sourceAccountIndex = int.Parse(Console.ReadLine());
                    Account sourceAccount = bankaccounts[sourceAccountIndex - 1];
                    /* 
                   * Det betyder att det valda kontot som användaren har valt att ta ut pengar från plockas ut från listan med konton (Accounts) 
                   * genom att använda indexet (sourcetaccountindex) som användaren har angivit. sourceAccount är en variabel som håller referensen till det valda kontot.
                   */

                    Console.WriteLine("\nVilket konto vill du flytta pengar till?");

                    // Loopa genom kontolistan och hitta kontona som tillhör användaren som är inloggad just nu.
                    for (int i = 0; i < bankaccounts.Count; i++)
                    {
                        // kontrollerar för varje index om bankaccounts[i].UserName är lika med variabeln userName.
                        if (bankaccounts[i].UserName == userName)
                        {
                            // Skriv ut kontotypen och saldot för användarens konton
                            Console.WriteLine($"{i}. {bankaccounts[i].AccountType}: {bankaccounts[i].Balance:C}");
                        }
                    }


                    Console.Write("Ange ditt val: ");
                    int targetAccountIndex = int.Parse(Console.ReadLine());
                    Account targetAccount = bankaccounts[targetAccountIndex - 1];
                    /* 
                   * Det betyder att det valda kontot som användaren har valt att ta ut pengar från plockas ut från listan med konton (Accounts) 
                   * genom att använda indexet (targetaccountindex) som användaren har angivit. targetAccount är en variabel som håller referensen till det valda kontot.
                   */
                    Console.Write("Ange belopp: ");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    // om beloppet är större än det finns på kontot 
                    if (amount > sourceAccount.Balance)
                    {
                        Console.WriteLine("Du har inte tillräckligt med pengar på kontot.");
                        Console.WriteLine("Tryck enter för att komma till huvudmenyn.");
                        Console.Write("===>");
                        Console.ReadLine();
                        MainMenu(bankaccounts, userName, accountNames, pinCodes);
                        return;
                    }
                    else
                    {
                        // Överföring av pengar mellan två konto
                        sourceAccount.Balance -= amount;
                        targetAccount.Balance += amount;
                        Console.WriteLine($"\nÖverföringen på {amount:C} genomfördes.");
                        Console.WriteLine("Tryck enter för att komma till huvudmenyn.");
                        Console.Write("===>");
                        Console.ReadLine();
                        MainMenu(bankaccounts, userName, accountNames, pinCodes);

                    }

                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    MainMenu(bankaccounts, userName, accountNames, pinCodes);
                }


            }



            static void WithDrawMoney(List<Account> bankaccounts, string userName, string[] accountNames, int[] pinCodes)
            {
                Console.WriteLine("Vilket konto vill du ta ut pengar från?");

                // Loopa genom kontolistan och hitta kontona som tillhör användaren som är inloggad just nu.

                for (int i = 0; i < bankaccounts.Count; i++)
                {
                    // kontrollerar för varje index om bankaccounts[i].UserName är lika med variabeln userName.
                    if (bankaccounts[i].UserName == userName)
                    {
                        // Skriv ut kontotypen och saldot för användarens konton
                        Console.WriteLine($"{i}. {bankaccounts[i].AccountType}: {bankaccounts[i].Balance:C}");
                    }
                    
                }


                // Lägg till en try-catch-block för att hantera tänkbara felaktiga inmatningar från användaren
                try
                {
                    Console.Write("Ange ditt val: ");
                    int withDrawIndex = int.Parse(Console.ReadLine());
                   /* 
                   * Det betyder att det valda kontot som användaren har valt att ta ut pengar från plockas ut från listan med konton (Accounts) 
                   * genom att använda indexet (withDrawIndex) som användaren har angivit. selectedAccount är en variabel som håller referensen till det valda kontot.
                   */
                    Account selectedAccount = bankaccounts[withDrawIndex];
                    //kontrollerar  om värdet på "withDrawIndex" är större eller lika med -1 och mindre än antalet element i listan "bankaccounts",
                    if (withDrawIndex >= -1 && withDrawIndex < bankaccounts.Count)
                    {
                        
                       
                        Console.Write("Ange belopp att ta ut: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        // Kontrollera så att användaren har tillräckligt med pengar på kontot
                        if (amount > selectedAccount.Balance)
                        {
                            Console.WriteLine("Du har inte tillräckligt med pengar på kontot.");
                        }
                        // Om användaren har pengar på konton så valideras pinkoden
                        else
                        {
                            // Sätter max attempt för inloggningen på 3 försök
                            int maxAttempts = 3;
                            // Lägger till en while-loop för att verifiera användarnamnet och pinkoden som användaren matar in
                            while (maxAttempts > 0)
                            {
                                Console.Write("Ange din pinkod för att bekräfta: ");
                                int passWord = int.Parse(Console.ReadLine());

                                // använda Array.IndexOf() för att hitta användarindexet och jämföra det med pinkoden arrayen.

                                int passwordIndex = Array.IndexOf(pinCodes, passWord);
                                /* Om inloggningen lyckades fortsätt med resten av funktionen
                                 där användaren tar ut pengar från det valda kontot.
                                */
                                if (passwordIndex >= 0 && accountNames[passwordIndex] == userName)
                                {
                                    selectedAccount.Balance -= amount;
                                    Console.WriteLine($"{amount:C} har tagits ut från {selectedAccount.AccountType}. Nytt saldo: {selectedAccount.Balance:C}");
                                    Console.WriteLine($"Ditt nya saldo är {selectedAccount.Balance:C}.");
                                    Console.WriteLine("Tryck enter för att gå tillbaka till huvudmenyn.");
                                    Console.Write("===>");
                                    Console.ReadLine();
                                    MainMenu(bankaccounts, userName, accountNames, pinCodes);
                                    return;
                                    
                                }
                                // Inloggningen inte är lyckad, decrementera maxAttempts och ge användaren en ny chans att logga in.
                                 
                                else
                                {
                                    maxAttempts--;
                                    Console.WriteLine("\nInloggning misslyckades, Du har {0} försök kvar.", maxAttempts);
                                }
                            }
                            if (maxAttempts == 0)
                            {

                                Console.WriteLine("Du har överskridit det maximala antalet inloggningsförsök.Var god och försök igen ");
                                    return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt val, vänligen försök igen");
                        Console.WriteLine();
                        WithDrawMoney(bankaccounts, userName, accountNames, pinCodes);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Inmatningen är fel, vänligen skriv in siffror");
                    Console.WriteLine();
                    WithDrawMoney(bankaccounts, userName, accountNames, pinCodes);
                }
            }

            // Utloggning system

            static void LogOut(string[] accountNames, int[] pinCodes, List<Account> accounts)
            {
                Console.WriteLine("Utloggning lyckades. Välkommen åter!");
                LogIn(accountNames, pinCodes, accounts);
            }


        }
        /*
         Detta är en klass för ett konto. Egenskaperna som den har är UserName, AccountType och Balance. UserName och AccountType är strings
         medan Balance är ett decimaltal. Har också en privat variabel som "balance" som används för att hålla reda på saldot samt
         en getter/setter för att komma åt och ändra saldot.
        */
        public class Account
        {
            public string UserName { get; set; }
            public string AccountType { get; set; }
            private decimal balance;
            
            public decimal Balance
            {
                get { return this.balance; }
                set { this.balance = value; }
            }
        }
        



    }
}