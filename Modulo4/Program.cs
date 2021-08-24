
using Dapper.Contrib.Extensions;
using Modulo4.Models;
using System;
using System.Data.SqlClient;

namespace Modulo4
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            Console.WriteLine("Módulo 4 - Mão na massa");

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                //ReadUsers(connection);
                //ReadUser(connection, 2);
                //var user = new User
                //{
                //    Bio = "a",
                //    Email = "a@a.com",
                //    Image = "https://",
                //    Name = "Aaa",
                //    PasswordHash = "Pass",
                //    Slug = "sluga"
                //};
                //InsertUser(connection, user);
            }
        }

        static void ReadUsers(SqlConnection connection)
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        static void ReadUser(SqlConnection connection, int id)
        {
            var user = connection.Get<User>(id);
            Console.WriteLine(user.Name);

        }

        static void InsertUser(SqlConnection connection, User user)
        {
            connection.Insert(user);
            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        static void UpdateUser(SqlConnection connection, User user)
        {
            connection.Update(user);
            Console.WriteLine("Atualizado com sucesso!");
        }

        static void UpdateUser(SqlConnection connection, int id)
        {
            var user = connection.Get<User>(id);
            connection.Delete(user);

            Console.WriteLine("Deletado com sucesso!");
        }

    }
}
