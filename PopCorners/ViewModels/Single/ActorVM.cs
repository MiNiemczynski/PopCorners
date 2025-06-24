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
    public class ActorVM : BaseSingleViewModel<ActorService, ActorDTO, Actor>
    {
        public int ActorId
        {
            get => Model.ActorId;
            set
            {
                if (Model.ActorId != value)
                {
                    Model.ActorId = value;
                    OnPropertyChanged(() => ActorId);
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
        public ActorVM() : base("Actor")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public ActorVM(ActorDTO selected) : base(selected.FullName ?? "Actor")
        {
            ActorId = selected.ActorId;
            FullName = selected.FullName ?? "";
            BirthDate = selected.BirthDate;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            ActorDTO original = Service.GetDTO(Model);
            ActorDTO copy = new ActorDTO()
            {
                ActorId = 0,
                FullName = "Copy_" + original.FullName,
                BirthDate = original.BirthDate,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<ActorDTO?>(copy));
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

                //List<ActorDTO> models = Service.GetModels();
                //foreach (ActorDTO model in models)
                //    if (model.ActorId == Model.ActorId)
                //    {
                //        Debug.WriteLine("[!] ID nie może się powtarzać");
                //        return; // id nie może się powtórzyć
                //    }

                //if (Model.BirthDate >= DateOnly.FromDateTime(DateTime.Now) || Model.BirthDate == null)
                //{
                //    Debug.WriteLine("[!] Data musi być przeszła");
                //    return; // data musi być przeszła
                //}
            }
        }
    }
}
