using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Modulo4.Models
{
    [Table("[Category]")]
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }

    }
}