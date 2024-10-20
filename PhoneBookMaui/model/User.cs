using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMaui.model
{
    internal class User
    {       
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? FName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image {  get; set; }
        public string FullName => $"{Name} {FName}";
    }

}
