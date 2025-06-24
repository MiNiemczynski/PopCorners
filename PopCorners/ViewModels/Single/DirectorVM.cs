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
    class DirectorVM : BaseSingleViewModel<DirectorService, DirectorDTO, Director>
    {
        public int DirectorId
        {
            get => Model.DirectorId;
            set
            {
                if (Model.DirectorId != value)
                {
                    Model.DirectorId = value;
                    OnPropertyChanged(() => DirectorId);
                }
            }
        }
        public string FullName
        {
            get => Model.FullName;
            set
            {
                if (Model.FullName != value)
                {
                    Model.FullName = value;
                    OnPropertyChanged(() => FullName);
                }
            }
        }
        public DateOnly? BirthDate
        {
            get => Model.BirthDate;
            set
            {
                if (Model.BirthDate != value)
                {
                    Model.BirthDate = value;
                    OnPropertyChanged(() => BirthDate);
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
        public DirectorVM() : base("Director")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public DirectorVM(DirectorDTO selected) : base(selected.FullName ?? "Director")
        {
            DirectorId = selected.DirectorId;
            FullName = selected.FullName ?? "";
            BirthDate = selected.BirthDate;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            DirectorDTO original = Service.GetDTO(Model);
            DirectorDTO copy = new DirectorDTO()
            {
                DirectorId = 0,
                FullName = "Copy_" + original.FullName,
                BirthDate = original.BirthDate,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<DirectorDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.FullName))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // imię musi być niepustym stringiem
                }

                Debug.WriteLine("Zapisano: " + Model.FullName);

                if (IsExisting) Update();
                else Save();
            }
        }
    }
}
