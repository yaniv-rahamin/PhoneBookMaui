 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 
namespace PhoneBookMaui.viewModel
{
    internal class SignUserVM:ObservableObject
    {
        private string? name;
        private string? fName;
        private string? email;
        private string? password;
        private string? phoneNumber;
        private string? errorMessage;
        private bool hasErrorBtn;
        public List<string>Prefix {  get; set; }
        private string? selectedPrefix;

        public SignUserVM()
        {
            Prefix = new List<string>();
            Prefix.Add("050");
            Prefix.Add("052");
            Prefix.Add("054");
        }

        public string SelectedPrefix 
        { 
            get => selectedPrefix;
            set { selectedPrefix = value; OnPropertyChanged();}
        }

        public string Name 
        { 
            get => name;
            set { if (name != value) { name = value; OnPropertyChanged(); OnPropertyChanged(FullName); HandleEroror("name"); } } 
        }

  
        public string FName
        {
            get => fName;
            set { fName = value; OnPropertyChanged(); OnPropertyChanged(FullName); HandleEroror("fName"); } 
        }
        public string FullName
        {
            get => $"{name} {fName}";

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

        public string PhoneNumber 
        { 
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(); HandleEroror("phone"); }
        }
        public string ErrorMessage
        {
            get => errorMessage;

            set { if (errorMessage != value) 
                { errorMessage = value;
                    OnPropertyChanged(); }}
        }

        public bool HasErrorBtn
        {
            get
            {

                return !string.IsNullOrEmpty(Name) && IsValidName(Name) && !string.IsNullOrEmpty(Password) && IsValidPassword() && !string.IsNullOrEmpty(Email) && IsValidEmail() && !string.IsNullOrEmpty(PhoneNumber) && IsValidPhone();
            }
        }

        

        private void HandleEroror(string type)
        {
            switch(type)
            {
                case "name":
                    if (!IsValidName(Name))
                        ErrorMessage = "יש להוסיף שם פרטי המכיל רק אותיות ולפחות 2 אותיות";
                    else
                        ErrorMessage = string.Empty;
                    break;
                case "fName":
                    if (!IsValidName(FName))
                        ErrorMessage = "יש להוסיף שם משפחה המכיל רק אותיות ולפחות 2 אותיות";
                    else
                        ErrorMessage = string.Empty;
                    break;
                case "email":
                    if (!IsValidEmail())
                        ErrorMessage = "מייל לא תקין";
                    else
                        ErrorMessage = string.Empty;
                    break;
                case "password":
                    if (!IsValidPassword())
                        ErrorMessage = "סיסמא תקינה מכילה 6 תווים לפחות ותו אחד שהוא לא אות ולא ספרה";
                    else
                        ErrorMessage = string.Empty;
                    break;
                case "phone":
                    if (!IsValidPhone())
                        ErrorMessage = "מספר טלפון מכיל 7 ספרות בדיוק";
                    else
                        ErrorMessage = string.Empty;
                    break;
            }
            OnPropertyChanged(nameof(HasErrorBtn));                   
        }


        private bool IsValidPhone()
        {            
            return PhoneNumber.Length==7;
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

        private bool IsValidName(string value)
        {
            // Regular expression to check if the name:
            // 1. Starts with a letter.
            // 2. Contains only letters.
            // 3. Is more than 2 characters long
            Regex reg = new Regex(@"^[a-zA-Z]{2,}$");
            return reg.IsMatch(value);

        }
    }   
}
