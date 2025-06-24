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
    public class SeasonVM : BaseSingleViewModel<SeasonService, SeasonDTO, Season>
    {
        public int SeasonId
        {
            get => Model.SeasonId;
            set
            {
                if (Model.SeasonId != value)
                {
                    Model.SeasonId = value;
                    OnPropertyChanged(() => SeasonId);
                }
            }
        }
        public Series Series
        {
            get => Model.Series;
            set
            {
                if (Model.Series != value)
                {
                    Model.Series = value;
                    OnPropertyChanged(() => Series);
                }
            }
        }
        public int SeasonNumber
        {
            get => Model.SeasonNumber;
            set
            {
                if (Model.SeasonNumber != value)
                {
                    Model.SeasonNumber = value;
                    OnPropertyChanged(() => SeasonNumber);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO>? episodes;
        public ObservableCollection<ComboBoxDTO>? Episodes
        {
            get => episodes;
            set
            {
                if (episodes != value)
                {
                    episodes = value;
                    OnPropertyChanged(() => Episodes);
                }
            }
        }
        private ObservableCollection<ComboBoxDTO> allSeries;
        public ObservableCollection<ComboBoxDTO> AllSeries
        {
            get => allSeries;
            set
            {
                if (allSeries != value)
                {
                    allSeries = value;
                    OnPropertyChanged(() => allSeries);
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
        private int selectedEpisodeId;
        public int SelectedEpisodeId
        {
            get => selectedEpisodeId;
            set
            {
                if (value != 0 && selectedEpisodeId != value)
                {
                    List<ProductionDTO> episodes = Service.GetEpisodesDTO(SeasonId);
                    ProductionDTO? episode = episodes.FirstOrDefault(item => item.ProductionId == value);

                    selectedEpisodeId = value;
                    WeakReferenceMessenger.Default.Send(new ValueChangedMessage<ProductionDTO?>(episode));
                }
            }
        }
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
        public ICommand ValidateCommand { get; set; }
        public bool IsExisting { get; set; }
        public SeasonVM() : base("Season")
        {
            AllSeries = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeries());
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public SeasonVM(SeasonDTO selected) : base(("S" + selected.SeasonNumber/* + " of " + selected.Series.Title*/) ?? "Season")
        {
            SeasonId = selected.SeasonId;
            SeasonNumber = selected.SeasonNumber;
            Series = selected.Series;
            Episodes = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxEpisodes(SeasonId));
            AllSeries = new ObservableCollection<ComboBoxDTO>(Service.GetComboBoxSeries());
            Description = selected.Description;
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            SeasonDTO copy = new SeasonDTO()
            {
                SeasonId = 0,
                SeasonNumber = Model.SeasonNumber,
                Description = "Copy_" + Model.Description,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<SeasonDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.Description))
                {
                    Debug.WriteLine("[!] Opis musi być niepustym typem string");
                    return;
                }
                if (Model.SeasonNumber.GetType() != typeof(int) || Model.SeasonNumber <= 0)
                {
                    Debug.WriteLine("[!] Numer sezonu musi być typu numerycznego");
                    return;
                }
                Debug.WriteLine("Zapisano: S" + Model.SeasonNumber);

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
    }
}
