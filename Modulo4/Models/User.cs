using Dapper.Contrib.Extensions;

namespace Modulo4.Models
{
    [Table("[User]")]
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}