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
            string title = @"
                                                     _                    _              
     \    / _  |  _  _  ._ _   _   _|_  _   |   _.  |_) _ _|_ o _|_  _   |_  _  _  |  _  
      \/\/ (/_ | (_ (_) | | | (/_   |_ (_)  |_ (_|  |  (/_ |_ |  |_ (/_  |_ (_ (_) | (/_                                                                                   
";
            Console.WriteLine(title);
            string message1 = "Please login with your email address and password";
            Console.WriteLine(message1.PadLeft(message1.Length+20));
            Console.WriteLine();

            string message2 = "Email Address"; 
            Console.WriteLine(message2);
            string email = Console.ReadLine().Trim();
            string message3 = "Password";
            Console.WriteLine(message3);
            string password = Console.ReadLine().Trim();
            Console.WriteLine("Press 0. To confirm and login");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar == '0')
            {
                verification(email, password);
            }

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

            if (IsValid)
            {
                Console.Clear();
                int id = Int32.Parse(accountId);
              
                if(accounts[id].Type == "Teacher")
                {
                    ClassRoom classRoom = new ClassRoom();
                    classRoom.viewClassasTeacher(id); 

                }
                if(accounts[id].Type == "Parent")
                {
                    ClassRoom classRoom = new ClassRoom();
                    classRoom.viewClassasParent(id);

                }
            }
            else
            {
                Console.Clear();
                string message = "Invalid Email or Password, Please try again";
                string message1 = "Press 0 to go back";
                Console.WriteLine(message.PadLeft(message.Length+20));
                Console.WriteLine(message1.PadLeft(message1.Length+30));
                ConsoleKeyInfo cki = Console.ReadKey(); 

                if(cki.KeyChar == '0')
                {
                    Login();
                }
 
            }

        }
    }
}
