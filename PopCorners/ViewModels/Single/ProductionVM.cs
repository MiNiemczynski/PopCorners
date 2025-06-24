using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PopCorners.ViewModels.Single
{
    public class ProductionVM : BaseSingleViewModel<ProductionService, ProductionDTO, Production>
    {
        public int ProductionId
        {
            get => Model.ProductionId;
            set
            {
                if (Model.ProductionId != value)
                {
                    Model.ProductionId = value;
                    OnPropertyChanged(() => ProductionId);
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
        public int Year
        {
            get => Model.ReleaseYear;
            set
            {
                if (Model.ReleaseYear != value)
                {
                    Model.ReleaseYear = value;
                    OnPropertyChanged(() => Year);
                }
            }
        }
        public int? Time
        {
            get => Model.Duration;
            set
            {
                if (Model.Duration != value)
                {
                    Model.Duration = value;
                    OnPropertyChanged(() => Time);
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
        public Director? Director
        {
            get => Model.Director;
            set
            {
                if (Model.Director != value)
                {
                    Model.Director = value;
                    OnPropertyChanged(() => Director);
                }
            }
        }
        public Platform? Platform
        {
            get => Model.Platform;
            set
            {
                if (Model.Platform != value)
                {
                    Model.Platform = value;
                    OnPropertyChanged(() => Platform);
                }
            }
        }
        public Season? Season
        {
            get => Model.Season;
            set
            {
                if (Model.Season != value)
                {
                    Model.Season = value;
                    OnPropertyChanged(() => Season);
                }
            }
        }
        public int? EpisodeNumber
        {
            get => Model.EpisodeNumber;
            set
            {
                if (Model.EpisodeNumber != value)
                {
                    Model.EpisodeNumber = value;
                    OnPropertyChanged(() => EpisodeNumber);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO> directors;
        public ObservableCollection<ComboBoxDTO> Directors
        {
            get => directors;
            set
            {
                if (directors != value)
                {
                    directors = value;
                    OnPropertyChanged(() => Directors);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO> platforms;
        public ObservableCollection<ComboBoxDTO> Platforms
        {
            get => platforms;
            set
            {
                if (platforms != value)
                {
                    platforms = value;
                    OnPropertyChanged(() => Platforms);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO> series;
        public ObservableCollection<ComboBoxDTO> Series
        {
            get => series;
            set
            {
                if (series != value)
                {
                    series = value;
                    OnPropertyChanged(() => Series);
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
        public int? SelectedDirectorId
        {
            get => Model.DirectorId;
            set
            {
                if (Model.DirectorId != value)
                {
                    Model.DirectorId = value;
                    OnPropertyChanged(() => SelectedDirectorId);
                }
            }
        }
        public int? SelectedPlatformId
        {
            get => Model.PlatformId;
            set
            {
                if (Model.PlatformId != value)
                {
                    Model.PlatformId = value;
                    OnPropertyChanged(() => SelectedPlatformId);
                }
            }
        }
        public int? SelectedSeriesId
        {
            get => Model.PlatformId;
            set
            {
                if (value != Model.PlatformId && value != 0)
                {
                    Model.PlatformId = value;
                    UpdateSeasons((int)value);
                    OnPropertyChanged(() => SelectedSeriesId);
                }
            }
        }
        public int? SelectedSeasonId
        {
            get => Model.SeasonId;
            set
            {
                if (Model.SeasonId != value)
                {
                    Model.SeasonId = value;
                    OnPropertyChanged(() => SelectedSeasonId);
                }
            }
        }

        public ICommand ValidateCommand { get; set; }
        public bool IsExisting { get; set; }
        public ProductionVM() : base("Production")
        {
            Directors = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxDirectors());
            Platforms = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxPlatforms());
            Series = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeries());

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public ProductionVM(ProductionDTO selected) : base(selected.Title ?? "Production")
        {
            ProductionId = selected.ProductionId;
            Title = selected.Title ?? "";
            Year = selected.Year;
            Time = selected.Time;
            EpisodeNumber = selected.EpisodeNumber;
            if (selected.Director != null) SelectedDirectorId = selected.Director.DirectorId;
            if (selected.Platform != null) SelectedPlatformId = selected.Platform.PlatformId;
            if (selected.Season != null)
            {
                SelectedSeasonId = selected.Season.SeasonId;
                SelectedSeriesId = selected.Season.Series.SeriesId;
            }
            Directors = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxDirectors());
            Platforms = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxPlatforms());
            Series = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeries());
            if (selected.Season != null) Seasons = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeasons(SelectedSeriesId));
            Description = selected.Description;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            ProductionDTO original = Service.GetDTO(Model);
            ProductionDTO copy = new ProductionDTO()
            {
                ProductionId = 0,
                Title = "Copy_" + original.Title,
                Year = original.Year,
                Time = original.Time,
                Description = original.Description,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<ProductionDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.Title))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return;
                }
                if (Model.ReleaseYear.GetType() != typeof(int) || Model.ReleaseYear <= 0)
                {
                    Debug.WriteLine("[!] Rok musi być niepustym typem int");
                    return;
                }

                Debug.WriteLine("Zapisano: " + Model.Title);

                try
                {
                    if (IsExisting) Update();
                    else Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops... Something went wrong...\n" + ex.ToString(), "Error");
                }
            }
        }
        public void UpdateSeasons(int value)
        {
            Seasons = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeasons(value));
        }
    }
}
