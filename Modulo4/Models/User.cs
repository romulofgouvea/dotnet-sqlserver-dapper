using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Modulo4.Models
{
    [Table("[User]")]
    public class User : BaseModel
    {
        public User() => Roles = new List<Role>();

        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Role> Roles { get; set; }

        public void AddRole(Role role)
        {
            if (role != null)
            {
                Roles.Add(role);
            }
        }
    }
}