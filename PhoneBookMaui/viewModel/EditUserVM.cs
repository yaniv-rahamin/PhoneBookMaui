using PhoneBookMaui.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneBookMaui.viewModel
{
    [QueryProperty(nameof(EditUser),"EdUser")]
    public class EditUserVM : ObservableObject
    {
        private string? name;
        private string? fName;
        //private string? email;        
        private string? phoneNumber;
        private string? errorMessage;
        private bool hasErrorBtn;
        public List<string> Prefix { get; set; }
        private string? selectedPrefix;
        private User? editUser;
        


        public ICommand AddUserCommand { get; set; }

        public EditUserVM()
        {
            Prefix = new List<string>();
            Prefix.Add("050");
            Prefix.Add("052");
            Prefix.Add("054");
            AddUserCommand = new Command(async () => { await AddUserToList(); });
        }

        private async Task AddUserToList()
        {
            User user = new User()
            {
                Name = Name,
                FName = FName,
                PhoneNumber = selectedPrefix + PhoneNumber,
                Id=editUser.Id

            };
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("eduser", user);
            await Shell.Current.GoToAsync("///ListUser", data);

        }

        public string SelectedPrefix
        {
            get => selectedPrefix;
            set { if (selectedPrefix != value) { selectedPrefix = value; OnPropertyChanged(); } }
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
        //public string Email
        //{
        //    get => email;
        //    set { email = value; OnPropertyChanged(); HandleEroror("email"); }
        //}


        public string PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(); HandleEroror("phone"); }
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

        public bool HasErrorBtn
        {
            get
            {

                return !string.IsNullOrEmpty(Name) && IsValidName(Name) && !string.IsNullOrEmpty(PhoneNumber) && IsValidPhone();
            }
        }

        public User EditUser { 
            get => editUser;
            set { 
                if (editUser != value) 
                {
                    editUser = value;
                    Name = editUser.Name;
                    FName = editUser.FName;
                    SelectedPrefix = editUser.PhoneNumber.Substring(0, 3);
                    PhoneNumber = editUser.PhoneNumber.Substring(3);
                    OnPropertyChanged(Name);
                    OnPropertyChanged(fName);
                    OnPropertyChanged(PhoneNumber);
                    OnPropertyChanged(SelectedPrefix);

                } 
            }
        }

        private void HandleEroror(string type)
        {
            switch (type)
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
            return PhoneNumber.Length == 7;
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

