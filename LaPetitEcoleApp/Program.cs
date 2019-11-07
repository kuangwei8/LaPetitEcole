using System;
using System.Text;


namespace LaPetitEcoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.SetWindowSize(100, 30);
            Console.SetWindowSize(100, 30);
            Console.CursorSize = 100;
            Console.CursorVisible = true; 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            
        
            MainPage mainPage = new MainPage();
            mainPage.homePage();
        }
    }
}
