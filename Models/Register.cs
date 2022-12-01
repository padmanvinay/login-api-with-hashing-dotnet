using System.Security.Cryptography;
namespace User.Models
{
    public class Register
    {
        public Guid id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string employeeName { get; set; }
        public string city { get; set; }
        public string department { get; set; }
    }
}