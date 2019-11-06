using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace LaPetitEcoleApp
{
    class ClassRoom
    {
        private const string AccountFile = @"AccountRepository.json";
        private const string RedRoom = @"RedRoomRepository.json";
        private const string BlueRoom = @"BlueRoomRepository.json";
        private const string TealRoom = @"TealRoomRepository.json";

        public string Lunch { get; set; }
        public string Activity { get; set; }
        public string Homework { get; set; }
        public string DT { get; set; }  
        public void viewClass(int id)
        {
            string existingJson = File.ReadAllText(AccountFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(existingJson);

            Console.WriteLine($"Welcome back {accounts[id].UserName} ");


            if (accounts[id].ClassRoom == "Red")
            {
                Console.WriteLine("Welcome to the Red Class Room" );
                Console.WriteLine("Press 1 to Post Daily \nPress 2 to View Post");
                ConsoleKeyInfo cki =Console.ReadKey();

                string redRoomJson = File.ReadAllText(RedRoom);
                List<ClassRoom> redRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(redRoomJson);

                if (cki.KeyChar == '1')
                {
                    redRoomRepo.Add(createDaily());
                    string output = JsonConvert.SerializeObject(redRoomRepo, Formatting.Indented);
                    using (var tw = new StreamWriter(RedRoom, append: false))
                    {
                        tw.WriteLine(output);
                        tw.Close();
                    }
                }
                if (cki.KeyChar == '2')
                {
                    viewPost();
                }

            }

            if(accounts[id].ClassRoom == "Blue")
            {
                Console.WriteLine("Welcom to the Blue Class Room");
                Console.WriteLine("Press 1 to Post Daily \nPress 2 to View Post");
                ConsoleKeyInfo cki = Console.ReadKey();

                string blueRoomJson = File.ReadAllText(BlueRoom);
                List<ClassRoom> blueRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(blueRoomJson);

                if(cki.KeyChar == '1')
                {
                    blueRoomRepo.Add(createDaily());
                    string output = JsonConvert.SerializeObject(blueRoomRepo, Formatting.Indented); ;
                    using (var tw = new StreamWriter(BlueRoom, append: false))
                    {
                        tw.WriteLine(output);
                        tw.Close();
                    }
                }
                if(cki.KeyChar == '2')
                {
                    viewPost();
                }
              

            }

            if(accounts[id].ClassRoom == "Teal")
            {
                Console.WriteLine("Welcom to the Teal Class Room");
                Console.WriteLine("Press 1 to Post Daily \nPress 2 to View Post");
                ConsoleKeyInfo cki = Console.ReadKey();

                string tealRoomJson = File.ReadAllText(TealRoom);
                List<ClassRoom> tealRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(tealRoomJson);

                if(cki.KeyChar == '1')
                {
                    tealRoomRepo.Add(createDaily());
                    string output = JsonConvert.SerializeObject(tealRoomRepo, Formatting.Indented);
                    using (var tw = new StreamWriter(TealRoom, append: false))
                    {
                        tw.WriteLine(output);
                        tw.Close();
                    }

                }
                if(cki.KeyChar == '2')
                {
                    viewPost();
                }
               
            }

        }

        public ClassRoom createDaily()
        {
            ClassRoom classRoom = new ClassRoom();
            classRoom.DT = DateTime.Today.ToShortDateString();
            Console.WriteLine("Post Lunch");
            classRoom.Lunch = Console.ReadLine();
            Console.WriteLine("Post Activity");
            classRoom.Activity = Console.ReadLine();
            Console.WriteLine("Post Homework");
            classRoom.Homework = Console.ReadLine();

            //Console.WriteLine("Press 0 to confirm and Post");
            //ConsoleKeyInfo cki = Console.ReadKey();

            //if (cki.KeyChar == '0') 
                
            return classRoom;

        }

        public void viewPost()
        {

        }
    }
}
