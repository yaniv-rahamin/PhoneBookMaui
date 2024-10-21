using PhoneBookMaui.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMaui.services
{
    public class UserService : IUsers
    {
        
        private List<User>? users;

        public UserService()
        {
            InitUser();
             
        }

        private void InitUser()
        {
            users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name="sigal",
                    FName ="salom",
                    Email = "sigal@email.com",
                    PhoneNumber ="0521234567",
                    Image = "sigal.jpg"
                                        
                },
                new User()
                {
                    Id = 2,
                    Name="gil",
                    FName ="golan",
                    Email = "gil@email.com",
                    PhoneNumber ="0527654321",
                    Image = "gil.jpg"
                },
                new User()
                {
                    Id = 3,
                    Name="david",
                    FName ="hamelch",
                    Email = "david@email.com",
                    PhoneNumber ="0547654321",
                    Image = "david.jpg"
                },
                new User()
                {
                    Id=4,
                    Name="yael",
                    FName ="dan",
                    Email = "yael@email.com",
                    PhoneNumber ="0501234567",
                    Image = "yael.jpg" 
                }

            };
            
        }

      
        public List<User>? GetUsers()
        {
            return users?.ToList();
        }

        public bool AddUser(User user)
        {
            if(users !=null)
            {
                if (user.Image == null)
                    user.Image = "default_image.png";
                users.Add(user);
                return true;
            }
            return false;  
        }

        public bool DeleteUser(User user)
        {
            //foreach (User u in users)
            //{
            //    if (u.Id == user.Id)
            //        return users.Remove(u);
            //}
            //return false;
            return users.Remove(users.Find((x) => x.Id == user.Id));
        }

        public bool EditUser(User user)
        {
            foreach(User u in users)
            {
                if (user.Id == u.Id)
                {
                    u.Name = user.Name;
                    u.FName = user.FName;    
                    u.PhoneNumber = user.PhoneNumber;
                    return true;    
                }
            }
            return false;
        }

        public List<User> FindUserByName(Predicate<string> condition)
        {
            return users?.Where(x => condition(x.Name)).ToList();
        }
    }
}
