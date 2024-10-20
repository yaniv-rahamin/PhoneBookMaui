using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookMaui.model;
namespace PhoneBookMaui.services
{
    internal interface IUsers
    {
        List<User>? GetUsers();//החזרת רשימה האנשים
        bool AddUser(User user);
        bool DeleteUser(User user);
        bool EditUser(User user);
        List<User>? FindUserByName(Predicate<string> condition);            
    }
}
