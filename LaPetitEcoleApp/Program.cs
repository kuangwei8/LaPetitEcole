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
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            
            //Console.CursorVisible = true; 
            MainPage mainPage = new MainPage();
            mainPage.homePage();
        }
    }
}
