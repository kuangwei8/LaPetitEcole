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
            string message = "Welcome to La Petite Ecole Montreal";
            Console.WriteLine(message.PadLeft(message.Length+25));
            Console.WriteLine();
            string message1 = "Press 1 to Login";
            string message2 = "Press 2 to Create New Account"; 
            Console.WriteLine(message1.PadLeft(message1.Length+10));
            Console.WriteLine(message2.PadLeft(message2.Length+10)); 
            string message3 = "Press any other key to exit";
            Console.WriteLine(message3.PadLeft(message3.Length+10));
         
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
