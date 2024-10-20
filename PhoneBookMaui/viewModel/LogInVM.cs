
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneBookMaui.viewModel
{
    internal class LogInVM : ObservableObject
    {
        private string? email;
        private string? password;
        private string? errorMessage;

        public LogInVM()
        {

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
