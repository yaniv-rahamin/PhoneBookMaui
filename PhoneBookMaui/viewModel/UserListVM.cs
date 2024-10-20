using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhoneBookMaui.model;
using PhoneBookMaui.services;
using PhoneBookMaui.view;


namespace PhoneBookMaui.viewModel
{

    [QueryProperty(nameof(User), "user")]
    [QueryProperty(nameof(EdUser), "eduser")]
    internal class UserListVM : ObservableObject
    {
        private string? name;
        private ObservableCollection<User>? usersCollection;
        private List<User>? usersList;
        private UserService? userService;
        private User? user;
        private string? searchText;
        private User? selectedUser;
        private User? edUser;
        

        public UserListVM()
        {

            userService = new UserService();
            usersList = userService.GetUsers();

            usersCollection = new ObservableCollection<User>();
            foreach (User user in usersList)
                usersCollection.Add(user);

            EditUserCommand = new Command(async () => { await MoveToEditPage(); });
            DeleteCommand = new Command<User>(deleteUser);
            


        }

        private void deleteUser(User user)
        {
            if (userService!=null && userService.DeleteUser(user))
            {
                usersCollection?.Remove(user);
                usersList?.Remove(user);    
            }
            
        }
            

        public ObservableCollection<User>? UsersCollection
        {
            get => usersCollection;
            set
            {
                if (usersCollection != value)
                { usersCollection = value; OnPropertyChanged(); }
            }
        }

        public ICommand EditUserCommand {  get; set; }
        public ICommand DeleteCommand {  get; set; } 
       

        public User? User
        {
            get => user;
            set
            {
                if (user != value)
                {
                    user = value;

                    if (userService?.AddUser(user) == true)
                    {
                        UsersCollection?.Add(user);  
                    }

                    OnPropertyChanged(nameof(User));
                }
            }
        }
        public string? SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    FilterUsers(searchText);
                    OnPropertyChanged();
                }
            }
        }

        public User SelectedUser 
        { 
            get => selectedUser;
            set
            {
                if(selectedUser != value)
                { selectedUser = value; OnPropertyChanged(); }  
            } 
        }

        public User? EdUser
        {
            get => edUser;
            set
            {
                edUser = value;
                userService.EditUser(edUser);
                usersList = userService.GetUsers();
                usersCollection = new ObservableCollection<User>();
                foreach (User user in usersList)
                    usersCollection.Add(user);
                OnPropertyChanged(nameof(UsersCollection));
                SelectedUser = null;
            }
            
        }

        private void FilterUsers(string? searchText)
        {

            if (string.IsNullOrWhiteSpace(searchText))
            {
                UsersCollection = new ObservableCollection<User>(usersList);   
            }
            else
            {
                var filteredUsers = usersList?.Where(user => user.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                UsersCollection = new ObservableCollection<User>(filteredUsers);
            }
        }

        

        public async Task MoveToEditPage()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("EdUser", SelectedUser);
            await Shell.Current.GoToAsync("/EditUser",data);
            
        }

    }
}
