using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace PopCorners.ViewModels.Single
{
    public class UserVM : BaseSingleViewModel<UserService, UserDTO, User>
    {
        public int UserId
        {
            get => Model.UserId;
            set
            {
                if (Model.UserId != value)
                {
                    Model.UserId = value;
                    OnPropertyChanged(() => UserId);
                }
            }
        }
        public string Username
        {
            get => Model.Username;
            set
            {
                if (Model.Username != value)
                {
                    Model.Username = value;
                    OnPropertyChanged(() => Username);
                }
            }
        }
        public string Email
        {
            get => Model.Email;
            set
            {
                if (Model.Email != value)
                {
                    Model.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string Password
        {
            get => Model.Password;
            set
            {
                if (Model.Password != value)
                {
                    Model.Password = value;
                    OnPropertyChanged(() => Password);
                }
            }
        }
        public DateTime CreationDate
        {
            get => Model.CreationDate;
            set
            {
                if (Model.CreationDate != value)
                {
                    Model.CreationDate = value;
                    OnPropertyChanged(() => CreationDate);
                }
            }
        }
        public DateTime? EditionDate
        {
            get => Model.EditionDate;
            set
            {
                if (Model.EditionDate != value)
                {
                    Model.EditionDate = value;
                    OnPropertyChanged(() => EditionDate);
                }
            }
        }
        public ICommand ValidateCommand { get; set; }
        public bool IsExisting { get; set; }
        public UserVM() : base("User")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public UserVM(UserDTO selected) : base(selected.Username ?? "User")
        {
            UserId = selected.UserId;
            Username = selected.Username ?? "";
            Email = selected.Email;
            Password = selected.Password;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            UserDTO original = Service.GetDTO(Model);
            UserDTO copy = new UserDTO()
            {
                UserId = 0,
                Username = "Copy_" + original.Username,
                Email = original.Email,
                Password = original.Password,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<UserDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.Username))
                {
                    Debug.WriteLine("[!] Nazwa użytkownika musi być niepustym typem string");
                    return; // imię musi być niepustym stringiem
                }
                if (string.IsNullOrEmpty(Model.Email))
                {
                    Debug.WriteLine("[!] E-mail użytkownika musi być niepustym typem string");
                    return; // email musi być niepustym stringiem
                }
                if (string.IsNullOrEmpty(Model.Password))
                {
                    Debug.WriteLine("[!] Hasło musi być niepustym typem string");
                    return; // hasło musi być niepustym stringiem
                }
                Debug.WriteLine("Zapisano: " + Model.Username);

                if (IsExisting) Update();
                else Save();

            }
        }
    }
}
