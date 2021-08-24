using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Modulo4.Models;

namespace Modulo4.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public override IEnumerable<User> GetAll()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var users = new List<User>();

            _connection.Query<User, Role, User>(query, (user, role) =>
            {
                var usr = users.FirstOrDefault(u => u.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    usr.AddRole(role);
                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return usr;
            }, splitOn: "Id");

            return users;

        }

    }
}