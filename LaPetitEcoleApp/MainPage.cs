using System;
using System.Collections.Generic;
using System.Text;

namespace LaPetitEcoleApp
{
    class MainPage
    {
        public void homePage()
        {
            Console.Title = "Welcome";
            string title = @"
              .__                               
__  _  __ ____ |  |   ____  ____   _____   ____  
\ \/ \/ // __ \|  | _/ ___\/  _ \ /     \_/ __ \ 
 \     /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/ 
  \/\_/  \___  >____/\___  >____/|__|_|  /\___  >
             \/          \/            \/     \/ 
";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title, Console.ForegroundColor);
            Console.WriteLine("Welcome to La Petite Ecole Montreal");
            Console.WriteLine("Press 1 to Login");
            Console.WriteLine("Press 2 to Create New Account");
            Console.WriteLine("Press any other key to exit");

            ConsoleKeyInfo cki = Console.ReadKey();


            if (cki.KeyChar == '1')
            {
                LoginVerification loginVerification = new LoginVerification();
                loginVerification.Login();
            }

            if (cki.KeyChar == '2')
            {
                Account account = new Account();
                account.GenerateAccount();
            }


        }
    }
}
