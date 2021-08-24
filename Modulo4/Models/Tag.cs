using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Modulo4.Models
{
    [Table("[Tag]")]
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}