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
    public class PlatformVM : BaseSingleViewModel<PlatformService, PlatformDTO, Platform>
    {
        public int PlatformId
        {
            get => Model.PlatformId;
            set
            {
                if (Model.PlatformId != value)
                {
                    Model.PlatformId = value;
                    OnPropertyChanged(() => PlatformId);
                }
            }
        }
        public string PlatformName
        {
            get => Model.PlatformName;
            set
            {
                if (Model.PlatformName != value)
                {
                    Model.PlatformName = value;
                    OnPropertyChanged(() => PlatformName);
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
        public PlatformVM() : base("Platform")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public PlatformVM(PlatformDTO selected) : base(selected.PlatformName ?? "Platform")
        {
            PlatformId = selected.PlatformId;
            PlatformName = selected.PlatformName ?? "";
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            PlatformDTO original = Service.GetDTO(Model);
            PlatformDTO copy = new PlatformDTO()
            {
                PlatformId = 0,
                PlatformName = "Copy_" + original.PlatformName,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<PlatformDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.PlatformName))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // nazwa musi być niepustym stringiem
                }
                Debug.WriteLine("Zapisano: " + Model.PlatformName);

                if (IsExisting) Update();
                else Save();
            }
        }
    }
}
