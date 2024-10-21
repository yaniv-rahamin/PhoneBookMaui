
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using PhoneBookMaui.model;

namespace PhoneBookMaui.viewModel
{
    public class LogInVM : ObservableObject
    {
        private string? email;
        private string? password;
        private string? errorMessage;
        

        public ICommand? RegisterCommand { get; set; }
        public ICommand? LogInCommand { get; set; }  

        public LogInVM()
        {
            LogInCommand = new Command(async() => await LoginToApp());
            RegisterCommand = new Command(async () => await NavigateToReg());

        }

        private async Task LoginToApp()
        {
            
            string mail = Preferences.Default.Get<string>("mail", null);
            string savepassword = Preferences.Default.Get<string>("password", null);
            User user = new User()
            { 
                Email = mail,
                Password = savepassword,    
            };


            if (email == mail && savepassword == password)
            {
                App.user = user;
                Preferences.Default.Set<string>("userObj", JsonSerializer.Serialize(user));    
                await Shell.Current.GoToAsync("///ListUser");
            }
            else
                await Shell.Current.DisplayAlert("Login", "Login Faild!", "ok");

        }

        private async Task NavigateToReg()
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); HandleEroror("email"); }
        }
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); HandleEroror("password"); }
        }
        public string ErrorMessage
        {
            get => errorMessage;

            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        private void HandleEroror(string type)
        {
            switch (type)
            {
                case "email":
                    if (!IsValidEmail())
                        ErrorMessage = "מייל לא תקין";
                    else
                        ErrorMessage = string.Empty;
                    break;
                case "password":
                    if (!IsValidPassword())
                        ErrorMessage = "סיסמא לא תקינה";
                    else
                        ErrorMessage = string.Empty;
                    break;
            }
            OnPropertyChanged(nameof(HasErrorBtn));
        }
        public bool HasErrorBtn
        {
            get
            {
                return !string.IsNullOrEmpty(Password) && IsValidPassword() && !string.IsNullOrEmpty(Email) && IsValidEmail() ;
            }
        }
        private bool IsValidEmail()
        {
            // Regular expression to validate an email address
            Regex reg = new Regex(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
            return reg.IsMatch(Email);
        }

        private bool IsValidPassword()
        {
            // Regular expression to match at least 6 characters, 
            // at least one non-alphanumeric character, and at least one non-numeric character
            Regex reg = new Regex(@"^(?=.*[^A-Za-z0-9])(?=.*[^0-9]).{6,}$");
            return reg.IsMatch(Password);
        }

    }
}
