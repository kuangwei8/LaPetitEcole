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

        public void viewClassasTeacher(int id)
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
                    Console.WriteLine("Press 0 to Post and return to the previous page");
                    ConsoleKeyInfo cki1 = Console.ReadKey(); 
                    if(cki1.KeyChar == '0')
                    {
                        string output = JsonConvert.SerializeObject(redRoomRepo, Formatting.Indented);
                        using (var tw = new StreamWriter(RedRoom, append: false))
                        {
                            tw.WriteLine(output);
                            tw.Close();
                        }
                        Console.Clear();
                        viewClassasTeacher(id);
                    }
                }
                if (cki.KeyChar == '2')
                {
                    viewPost(RedRoom);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.ReadKey();
                    Console.Clear();
                    viewClassasTeacher(id);
                }

            }

            if (accounts[id].ClassRoom == "Blue")
            {
                Console.WriteLine("Welcome to the Blue Class Room");
                Console.WriteLine("Press 1 to Post Daily \nPress 2 to View Post");
                ConsoleKeyInfo cki = Console.ReadKey();

                string blueRoomJson = File.ReadAllText(BlueRoom);
                List<ClassRoom> blueRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(blueRoomJson);

                if (cki.KeyChar == '1')
                {
                    blueRoomRepo.Add(createDaily());
                    Console.WriteLine("Press 0 to Post and return to the previous page");
                    ConsoleKeyInfo cki1 = Console.ReadKey();
                    if (cki1.KeyChar == '0')
                    {
                        string output = JsonConvert.SerializeObject(blueRoomRepo, Formatting.Indented);
                        using (var tw = new StreamWriter(BlueRoom, append: false))
                        {
                            tw.WriteLine(output);
                            tw.Close();
                        }
                        Console.Clear();
                        viewClassasTeacher(id);
                    }
                }
                if (cki.KeyChar == '2')
                {
                    viewPost(RedRoom);
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear(); 
                    viewClassasTeacher(id);
                }

            }


            if(accounts[id].ClassRoom == "Teal")
            {
                Console.WriteLine("Welcome to the Teal Class Room");
                Console.WriteLine("Press 1 to Post Daily \nPress 2 to View Post");
                ConsoleKeyInfo cki = Console.ReadKey();

                string tealRoomJson = File.ReadAllText(TealRoom);
                List<ClassRoom> tealRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(tealRoomJson);

                if(cki.KeyChar == '1')
                {
                    tealRoomRepo.Add(createDaily());
                    Console.WriteLine("Press 0 to Post and return to the previous page");
                    ConsoleKeyInfo cki1 = Console.ReadKey();

                    if (cki1.KeyChar == '0')
                    {
                        string output = JsonConvert.SerializeObject(tealRoomRepo, Formatting.Indented);
                        using (var tw = new StreamWriter(TealRoom, append: false))
                        {
                            tw.WriteLine(output);
                            tw.Close();
                        }
                        Console.Clear();
                        viewClassasTeacher(id);
                    }

                }
                if(cki.KeyChar == '2')
                {
                    viewPost(TealRoom);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.ReadKey();
                    Console.Clear();
                    viewClassasTeacher(id);
                }
               
            }

        }

        public ClassRoom createDaily()
        {
            Console.Clear(); 
            ClassRoom classRoom = new ClassRoom();
            classRoom.DT = DateTime.Today.ToShortDateString();
            Console.WriteLine("Post Lunch");
            classRoom.Lunch = Console.ReadLine();
            Console.WriteLine("Post Activity");
            classRoom.Activity = Console.ReadLine();
            Console.WriteLine("Post Homework");
            classRoom.Homework = Console.ReadLine();
                
            return classRoom;

        }

        public void viewClassasParent(int id)
        {
            string existingJson = File.ReadAllText(AccountFile);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(existingJson);

            Console.WriteLine($"Welcome back {accounts[id].UserName} ");

            if (accounts[id].ClassRoom == "Red")
            {
                Console.WriteLine("Welcome to the Red Class Room");
                Console.WriteLine("Press 1 to view Today's daily");
                ConsoleKeyInfo cki = Console.ReadKey();

                string redRoomJson = File.ReadAllText(RedRoom);
                List<ClassRoom> redRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(redRoomJson);

                if (cki.KeyChar == '1')
                {
                    viewPost(RedRoom);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.ReadKey();
                    Console.Clear();
                    viewClassasParent(id); 
                }
            }

            if (accounts[id].ClassRoom == "Blue")
            {
                Console.WriteLine("Welcome to the Blue Class Room");
                Console.WriteLine("Press 1 to view Today's daily");
                ConsoleKeyInfo cki = Console.ReadKey();

                string blueRoomJson = File.ReadAllText(BlueRoom);
                List<ClassRoom> blueRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(blueRoomJson);

                if (cki.KeyChar == '1')
                {
                    viewPost(BlueRoom);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.ReadKey();
                    Console.Clear(); 
                    viewClassasParent(id);
                }

            }

            if (accounts[id].ClassRoom == "Teal")
            {
                Console.WriteLine("Welcome to the Teal Class Room");
                Console.WriteLine("Press 1 to view Today's daily");
                ConsoleKeyInfo cki = Console.ReadKey();

                string tealRoomJson = File.ReadAllText(TealRoom);
                List<ClassRoom> tealRoomRepo = JsonConvert.DeserializeObject<List<ClassRoom>>(tealRoomJson);

                if (cki.KeyChar == '1')
                {
                    viewPost(TealRoom);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the previous page");
                    Console.ReadKey();
                    Console.Clear(); 
                    viewClassasParent(id);
                }
            }
        }

        public void viewPost(string room)
        {
            Console.Clear();
            using (StreamReader r = new StreamReader(room))
            {
                string json = r.ReadToEnd();
                List<ClassRoom> classRooms = JsonConvert.DeserializeObject<List<ClassRoom>>(json);
                Console.WriteLine(classRooms[classRooms.Count-1].GetDaily());
            }
        }

        public string GetDaily()
        {
            return  $"Here is a Peek into our day at school \n" +
                $"Lunch: {this.Lunch} \n" +
                $"Activity: {this.Activity} \n" +
                $"Homework: {this.Homework}";
        }
    }
}
