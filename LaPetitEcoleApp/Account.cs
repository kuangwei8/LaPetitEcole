using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LaPetitEcoleApp
{
    class Account
    {

        //properties
        private const string AccountFile = @"AccountRepository.json";
        public string UserName { get; set; }
        public string Type { get; set; }
        public string ClassRoom { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }

        //method 

        public void GenerateAccount()
        {
            Console.Clear();
            Console.WriteLine("Create your Account with La Petite Ecole");

            Account account = new Account();

            Console.WriteLine("User Name");
            account.UserName = Console.ReadLine();

            Console.WriteLine("-Press 1 to Create Teacher Account \n-Press 2 to Create Parent Account");
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.KeyChar == '1') account.Type = "Teacher";
            else if (cki.KeyChar == '2') account.Type = "Parent";
            else
            {
                Console.Beep();
                Console.Clear();
                GenerateAccount();
            }

            Console.WriteLine
                ("Choose your Class Room \n 1 - Red Room \n 2 - Blue Room \n 3 - Teal Room" );
            ConsoleKeyInfo cki2 = Console.ReadKey();
            if (cki2.KeyChar == '1') account.ClassRoom = "Red";
            else if (cki2.KeyChar == '2') account.ClassRoom = "Blue";
            else if (cki2.KeyChar == '3') account.ClassRoom = "Teal"; 
            else
            {
                Console.Beep();
                Console.Clear();
                GenerateAccount();

            }
            //Email
            Console.WriteLine("You Email Address");
            account.EmailAddress = Console.ReadLine();

            //Password
            Console.WriteLine("Password");
            account.Password = Console.ReadLine();
            Console.WriteLine("Confirm Password");
            account.Password2 = Console.ReadLine();

            // Validating User Input 
            bool IsValidate = verifyUserInput
                (account.UserName, account.EmailAddress, account.Password, account.Password2);

            string existingJson = File.ReadAllText(AccountFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(existingJson);

            if (IsValidate)
            {
                accounts.Add(account);
                string output = JsonConvert.SerializeObject(accounts, Formatting.Indented);

                using (var tw = new StreamWriter(AccountFile, append: false))
                {
                    tw.WriteLine(output);
                    tw.Close();
                }

                Console.Clear();
                Console.WriteLine("Account Created, Press 0 to return to main page, press any other key to exit");

                ConsoleKeyInfo cki3 = Console.ReadKey();
                if (cki3.KeyChar == '0')
                {
                    Console.Clear();
                    MainPage mainPage = new MainPage();
                    mainPage.homePage();
                }
            }

            static bool verifyUserInput
               (string username, string email, string password, string password2)
            {
                bool Valid = true;
                //user name
                if (String.IsNullOrEmpty(username))
                {
                    Console.Clear();
                    Console.WriteLine("Username can't be empty, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;

                }

                //email
                if (String.IsNullOrEmpty(email))
                {
                    Console.Clear();
                    Console.WriteLine("Email address can't be empty, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                var emailcheck = new EmailAddressAttribute();
                if (!emailcheck.IsValid(email))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Email Address, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                // password
                if (String.IsNullOrEmpty(password))
                {
                    Console.Clear();
                    Console.WriteLine("Password can't be empty, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                if (String.IsNullOrEmpty(password2))
                {
                    Console.Clear();
                    Console.WriteLine("Passwords can't be empty, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                if (password.Length < 6)
                {
                    Console.Clear();
                    Console.WriteLine("Password Needs to be more than 6 characters, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                if (password != password2)
                {
                    Console.Clear();
                    Console.WriteLine("Password entered don't Match, press any key to try again");
                    Console.ReadLine();
                    Account account = new Account();
                    account.GenerateAccount();
                    Valid = false;
                }

                return Valid;
            }


        }
    }
}
