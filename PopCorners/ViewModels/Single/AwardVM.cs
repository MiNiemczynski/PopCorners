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
    public class AwardVM : BaseSingleViewModel<AwardService, AwardDTO, Award>
    {
        public int AwardId
        {
            get => Model.AwardId;
            set
            {
                if (Model.AwardId != value)
                {
                    Model.AwardId = value;
                    OnPropertyChanged(() => AwardId);
                }
            }
        }
        public string AwardName
        {
            get => Model.AwardName;
            set
            {
                if (Model.AwardName != value)
                {
                    Model.AwardName = value;
                    OnPropertyChanged(() => AwardName);
                }
            }
        }
        public int Year
        {
            get => Model.Year;
            set
            {
                if (Model.Year != value)
                {
                    Model.Year = value;
                    OnPropertyChanged(() => Year);
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
        public AwardVM() : base("Award")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public AwardVM(AwardDTO selected) : base(selected.AwardName ?? "Award")
        {
            AwardId = selected.AwardId;
            AwardName = selected.AwardName ?? "";
            Year = selected.Year;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            AwardDTO original = Service.GetDTO(Model);
            AwardDTO copy = new AwardDTO()
            {
                AwardId = 0,
                AwardName = "Copy_" + original.AwardName,
                Year = original.Year,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<AwardDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.AwardName))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // imię musi być niepustym stringiem
                }
                if (Model.Year.GetType() != typeof(int) || Model.Year <= 0)
                {
                    Debug.WriteLine("[!] Rok musi być niepustym typem int");
                    return; // rok musi być int
                }
                Debug.WriteLine("Zapisano: " + Model.AwardName);

                if (IsExisting) Update();
                else Save();
            }
        }
    }
}
