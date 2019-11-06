using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace LaPetitEcoleApp
{
    public class LoginVerification
    {

        private const string AccountFile = @"AccountRepository.json";

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Weclom to La Petite Ecole, please login with your email address and password");
            Console.WriteLine("Email Address");
            string email = Console.ReadLine().Trim();
            Console.WriteLine("Password");
            string password = Console.ReadLine().Trim();
            Console.WriteLine("Press 0. To confirm and login");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar == '0') verification(email, password);

        }

        public void verification(string email, string password)
        {
            string existingJson = File.ReadAllText(AccountFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(existingJson);


            bool IsValid = false;
            string accountId = "none";
            for (int i = 0; i < accounts.Count; i++)
            {

                if (accounts[i].EmailAddress == email)
                {
                    string passwordValidating = accounts[i].Password;
                    if (password == passwordValidating)
                    {
                        accountId = i.ToString();
                        Console.WriteLine("login");
                        IsValid = true;
                    }
                }
            }

            if (IsValid == true)
            {
                Console.Clear();
                int id = Int32.Parse(accountId);
              
                if(accounts[id].Type == "Teacher")
                {
                    ClassRoom classRoom = new ClassRoom();
                    classRoom.viewClass(id); 

                }
                if(accounts[id].Type == "Parent")
                {
                    ParentClassRoom parentClassRoom = new ParentClassRoom();
                    parentClassRoom.viewClass(id);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Email or Password, Please try again");
                Console.ReadLine();
                Login();
            }

        }
    }
}
