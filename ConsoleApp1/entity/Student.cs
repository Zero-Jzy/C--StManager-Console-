using System;

namespace ConsoleApp1.entity
{
    public class Student
    {
        public Student(string rollNumber, string name, string email, string phone)
        {
            RollNumber = rollNumber;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public Student()
        {
        }

        public string RollNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public override string ToString()
        {
            return $"|{RollNumber,-15}|{Name,-15}|{Email,-15}|{Phone,-15}|";
        }
    }
}