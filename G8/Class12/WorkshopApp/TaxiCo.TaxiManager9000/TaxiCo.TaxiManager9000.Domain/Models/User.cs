using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Enums;

namespace TaxiCo.TaxiManager9000.Domain.Models
{
    public class User : BaseEntity
    {
        public User() {}

        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        private string _username;
        public string Username 
        {
            get => _username;
            set => _username = value.ToLower();
        }
        public string Password { get; set; }
        public Role Role { get; set; }
        public override string Print()
        {
            return $"{Username} with the role of {Role}";
        }
    }
}