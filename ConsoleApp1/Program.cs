using System;
using System.Collections;
using System.Text.RegularExpressions;
using ConsoleApp1.entity;
using ConsoleApp1.model;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly StudentModel Model = new StudentModel();

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------Menu----------\n" +
                                  "1. Add new student.\n" +
                                  "2. Print students. \n" +
                                  "3. Sreach by name.\n" +
                                  "4. Delete st.\n" +
                                  "0. Exit");
                var choose = Console.ReadLine();
                if (choose == "0")
                {
                    break;
                }
                switch (choose)
                {
                    case "1":
                        Program.Create();
                        break;
                    case "2":
                        Program.PrintAllSt();
                        break;
                    case "3":
                        Program.SreachByName();
                        break;
                    case "4":
                        Program.DeleteSt();
                        break;
                    default:
                        break;
                }
            }
            
        }

        private static void Create()
        {
            Console.WriteLine("Enter rollNumber");
            var rollNumber = Console.ReadLine();
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Phone");
            var phone = Console.ReadLine();
            var st = new Student(rollNumber, name, email, phone);
            StudentModel.CreateStudent(st);
        }

        private static void PrintAllSt()
        {
            ArrayList list = StudentModel.GetAllStudent();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|", "RolNumber", "Name", "Email", "Phone");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var stu in list)
            {
                Console.WriteLine(stu.ToString());
            }
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void SreachByName()
        {
            Console.WriteLine("Enter your ..ccc:");
            var regex = Console.ReadLine();

            var list = StudentModel.GetAllStudent();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|", "RolNumber", "Name", "Email", "Phone");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (Student stu in list)
            {
                var match = Regex.Match(stu.Name, regex);
                if (match.Success)
                {
                    Console.WriteLine(stu.ToString());
                }
            }
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void DeleteSt()
        {
            Console.WriteLine("Enter rollNumber: ");
            var rollNumber = Console.ReadLine();
            StudentModel.DeleteSt(rollNumber);
        }
    }
}