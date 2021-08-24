﻿
using Dapper.Contrib.Extensions;
using Modulo4.Models;
using Modulo4.Repositories;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo4
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            Console.WriteLine("Módulo 4 - Mão na massa");

            using var connection = new SqlConnection(CONNECTION_STRING);

            var userRepository = new Repository<User>(connection);
            userRepository.GetAll()
                .ToList()
                .ForEach(user => Console.WriteLine(user.Name));


            var roleRepository = new Repository<Role>(connection);
            roleRepository.GetAll()
                .ToList()
                .ForEach(role => Console.WriteLine(role.Name));
        }
    }
}
