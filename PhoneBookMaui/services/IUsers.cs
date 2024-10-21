using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookMaui.model;

namespace PhoneBookMaui.services
{ 
    public interface IUsers
    {
        public List<User>? GetUsers();//החזרת רשימה האנשים
        public bool AddUser(User user);
        public bool DeleteUser(User user);
        public bool EditUser(User user);
        public List<User>? FindUserByName(Predicate<string> condition);            
    }
}
