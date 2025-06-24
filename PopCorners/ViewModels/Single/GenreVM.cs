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
    public class GenreVM : BaseSingleViewModel<GenreService, GenreDTO, Genre>
    {
        public int GenreId
        {
            get => Model.GenreId;
            set
            {
                if (Model.GenreId != value)
                {
                    Model.GenreId = value;
                    OnPropertyChanged(() => GenreId);
                }
            }
        }
        public string GenreName
        {
            get => Model.GenreName;
            set
            {
                if (Model.GenreName != value)
                {
                    Model.GenreName = value;
                    OnPropertyChanged(() => GenreName);
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
        public GenreVM() : base("Genre")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public GenreVM(GenreDTO selected) : base(selected.GenreName ?? "Genre")
        {
            GenreId = selected.GenreId;
            GenreName = selected.GenreName ?? "";
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            GenreDTO original = Service.GetDTO(Model);
            GenreDTO copy = new GenreDTO()
            {
                GenreId = 0,
                GenreName = "Copy_" + original.GenreName,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<GenreDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.GenreName))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // imię musi być niepustym stringiem
                }

                Debug.WriteLine("Zapisano: " + Model.GenreName);

                if (IsExisting) Update();
                else Save();

            }
        }

    }
}
