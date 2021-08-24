using Dapper.Contrib.Extensions;

namespace Modulo4.Models
{
    [Table("[Role]")]
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}