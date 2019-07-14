using System;
using System.Collections;
using ConsoleApp1.entity;
using MySql.Data.MySqlClient;

namespace ConsoleApp1.model
{
    public class StudentModel
    {
        public static MySqlConnection GetDb()
        {
            const string ServerName = "localhost";
            const string DatabaseName = "c#-tutorial";
            const string Username = "root";
            const string password = "";
            var cnnString = $"Server={ServerName};Database={DatabaseName};Uid={Username};Pwd={password};SslMode=none";

            var conn = new MySqlConnection(cnnString);
            conn.Open();
            return conn;
        }

        public static ArrayList GetAllStudent()
        {
            var conn = GetDb();
            var sql = "Select * from students";
            var command = new MySqlCommand(sql, conn);

            var list = new ArrayList();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var rollNumber = reader.GetString(0);
                var name = reader.GetString(1);
                var email = reader.GetString(2);
                var phone = reader.GetString(3);
                
                var student = new Student(rollNumber, name, email, phone);
                list.Add(student);
            }
            conn.Close();
            return list;
        }

        public static void CreateStudent(Student student)
        {
            var conn = GetDb();
            var sql =
                "insert into students (rollNumber, name, email, phone ) values (@rollNumber, @name, @email, @phone)";
            var command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("@rollNumber", student.RollNumber);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@phone", student.Phone);
            var rowCount = command.ExecuteNonQuery();

            Console.WriteLine(rowCount > 0 ? "Succees" : "Erros");
            conn.Close();
        }

        public static void DeleteSt(string rollNumber)
        {
            var conn = GetDb();
            var sql = "Delete from students where rollNumber = @rollNumber ";
            var command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@rollNumber", rollNumber);

            var rowCount = command.ExecuteNonQuery();

            Console.WriteLine(rowCount > 0 ? "Succees" : "Erros");
            conn.Close();
        }
    }
}