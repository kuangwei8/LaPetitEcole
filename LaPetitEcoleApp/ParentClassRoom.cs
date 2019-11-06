using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace LaPetitEcoleApp
{
    public class ParentClassRoom
    {
        private const string AccountFile = @"AccountRepository.json";
        private const string RedRoomRepo = @"RedRoomRepository.json";
        private const string BlueRoomRepo = @"BlueRoomRepository.json";
        private const string TealRoomRepo = @"TealRoomRepository.json";

        public void viewClass(int id)
        {
            string existingJson = File.ReadAllText(AccountFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(existingJson);

            Console.WriteLine($"Welcome back {accounts[id].UserName} ");

            if (accounts[id].ClassRoom == "Red")
            {
                Console.WriteLine("Welcome to the Red Class Room");

            }

            if (accounts[id].ClassRoom == "Blue")
            {
                Console.WriteLine("Welcom to the Blue Class Room");
            }

            if (accounts[id].ClassRoom == "Teal")
            {
                Console.WriteLine("Welcom to the Teal Class Room");

            }

        }
    }
}
