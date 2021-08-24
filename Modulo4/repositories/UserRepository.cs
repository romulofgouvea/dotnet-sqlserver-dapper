using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Modulo4.Models;

namespace Modulo4.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public User Get(int id) => _connection.Get<User>(id);
        public IEnumerable<User> GetAll() => _connection.GetAll<User>();
        public void Insert(User user) => _connection.Insert(user);
        public void Update(User user) => _connection.Update(user);
        public void Delete(int id)
        {
            var user = _connection.Get<User>(id);
            _connection.Delete(user);
        }

    }
}