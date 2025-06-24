using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PopCorners.ViewModels.Single
{
    public class SeriesVM : BaseSingleViewModel<SeriesService, SeriesDTO, Series>
    {
        public int SeriesId
        {
            get => Model.SeriesId;
            set
            {
                if (Model.SeriesId != value)
                {
                    Model.SeriesId = value;
                    OnPropertyChanged(() => SeriesId);
                }
            }
        }
        public string Title
        {
            get => Model.Title;
            set
            {
                if (Model.Title != value)
                {
                    Model.Title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO> seasons;
        public ObservableCollection<ComboBoxDTO> Seasons
        {
            get => seasons;
            set
            {
                if (seasons != value)
                {
                    seasons = value;
                    OnPropertyChanged(() => Seasons);
                }
            }
        }
        public string? Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged(() => Description);
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
        private int selectedSeasonId;
        public int SelectedSeasonId
        {
            get => selectedSeasonId;
            set
            {
                if (value != 0 && selectedSeasonId != value)
                {
                    List<SeasonDTO> seasons = Service.GetSeasonsDTO(SeriesId);
                    SeasonDTO? season = seasons.FirstOrDefault(item => item.SeasonId == value);

                    selectedSeasonId = value;
                    WeakReferenceMessenger.Default.Send(new ValueChangedMessage<SeasonDTO?>(season));
                }
            }
        }
        public ICommand ValidateCommand { get; set; }
        public bool IsExisting { get; set; }
        public SeriesVM() : base("Series")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public SeriesVM(SeriesDTO selected) : base(selected.Title ?? "Series")
        {
            SeriesId = selected.SeriesId;
            Title = selected.Title ?? "";
            Seasons = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeasons(SeriesId));
            Description = selected.Description ?? "";
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            SeriesDTO original = Service.GetDTO(Model);
            SeriesDTO copy = new SeriesDTO()
            {
                SeriesId = 0,
                Title = "Copy_" + original.Title,
                Seasons = original.Seasons,
                Description = original.Description,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<SeriesDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.Title))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // Tytuł musi być niepustym stringiem
                }
                if (string.IsNullOrEmpty(Model.Description))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // Opis musi być niepustym stringiem
                }

                Debug.WriteLine("Zapisano: " + Model.Title);

                if (IsExisting) Update();
                else Save();
            }
        }
    }
}
