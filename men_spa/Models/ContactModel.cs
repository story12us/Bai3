using System;
using Dapper;
namespace men_spa.Models
{
    [Table("contact")]
    public class ContactModel
    {
        [Key]
        [IgnoreInsert]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}
