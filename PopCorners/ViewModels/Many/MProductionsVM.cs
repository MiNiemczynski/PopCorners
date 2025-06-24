using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
namespace PopCorners.ViewModels.Many
{
    public class MProductionsVM : BaseManyViewModel<ProductionService, ProductionDTO, Production>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<ProductionDTO> models;
        //public ObservableCollection<ProductionDTO> Models
        //{
        //    get => models;
        //    set
        //    {
        //        if (value != models)
        //        {
        //            models = value;
        //            OnPropertyChanged(() => Models);
        //        }
        //    }
        //}
        //private ProductionDTO? selectedModel;
        //public ProductionDTO? SelectedModel
        //{
        //    get => selectedModel;
        //    set
        //    {
        //        if (value != selectedModel)
        //        {
        //            selectedModel = value;
        //            OnPropertyChanged(() => SelectedModel);
        //        }
        //    }
        //}

        //public string selectedTime
        //{
        //    get
        //    {
        //        int? hours = selectedModel.Time / 60;
        //        int? minutes = selectedModel.Time % 60;
        //        return $"{hours}h : {minutes}m";
        //    }
        //}
        //public ICommand RefreshCommand { get; }
        //public ICommand EditCommand { get; }
        //public ICommand DeleteCommand { get; }

        public List<SerialMovieComboBoxDTO> SerialMovieOptions { get; set; }

        public MProductionsVM() : base("Productions")
        {
            //DisplayName = "Productions";
            //RefreshCommand = new BaseCommand(() => init());
            //EditCommand = new BaseCommand(() => editRecord());
            //DeleteCommand = new BaseCommand(() => deleteRecord());
            //init();
            SerialMovieOptions = new()
            {
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.All,
                    OptionName = "All"
                },
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.Movie,
                    OptionName = "Movies"
                },
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.Series,
                    OptionName = "Series"
                }
            };
        }

        public bool HasPlatform
        {
            get => Service.HasPlatform;
            set
            {
                if (value != Service.HasPlatform)
                {
                    Service.HasPlatform = value;
                    OnPropertyChanged(() => HasPlatform);
                }
            }
        }
        public SerialMovieEnum SerialMovie
        {
            get => Service.SerialMovieOption;
            set
            {
                if (value != Service.SerialMovieOption)
                {
                    Service.SerialMovieOption = value;
                    OnPropertyChanged(() => SerialMovie);
                }
            }
        }

        protected override void ClearFilters()
        {
            HasPlatform = false;
            SerialMovie = SerialMovieEnum.All;
            SetDefaultSearchOption();
            Refresh();
        }


        //private static string episodeString(string? series, int? season, int? episode)
        //{
        //    string? e, s;
        //    if (season < 10) s = "0" + season.ToString();
        //    else s = season.ToString();
        //    if (episode < 10) e = "0" + episode.ToString();
        //    else e = episode.ToString();
        //    return (episode == null) ? " " : $"{series}: S{s} E{e}";
        //}

        //private void init()
        //{
        //    dbContext = new DatabaseContext();

        //    IQueryable<Production> productions = dbContext.Productions
        //        .Include(item => item.Director)
        //        .Include(item => item.Platform)
        //        .Include(item => item.Season).ThenInclude(item => item.Series)
        //        .Where(item => item.IsActive == true);

        //    IQueryable<ProductionDTO> productionDTOs = productions.Select(item => new ProductionDTO()
        //    {
        //        ProductionId = item.ProductionId,
        //        Title = item.Title,
        //        Year = item.ReleaseYear,
        //        Time = item.Duration,
        //        Director = new DirectorDTO()
        //        {
        //            FullName = item.Director.FullName
        //        },
        //        Platform = new PlatformDTO()
        //        {
        //            PlatformName = item.Platform.PlatformName
        //        },
        //        Series = new SeriesDTO()
        //        {
        //            Title = item.Season.Series.Title
        //        },

        //        //Series = item.Season.Series,

        //        //Series = episodeString(item.Season.Series.Title,
        //        //                        item.Season.SeasonNumber,
        //        //                        item.EpisodeNumber),
        //        CreationDate = item.CreationDate,
        //        EditionDate = item.EditionDate
        //    });

        //    Models = new ObservableCollection<ProductionDTO>(productionDTOs.ToList());

        //    //List<Production> productions = dbContext.Productions.Where(item => item.IsActive ?? false).ToList();
        //    //Models = new ObservableCollection<Production>(productions);
        //}
        //private void deleteRecord()
        //{
        //    Production? record = findSelected();
        //    if (record != null)
        //    {
        //        record.IsActive = false;
        //        record.DeletionDate = DateTime.Now;
        //        dbContext.SaveChanges();
        //        init();
        //    }
        //}
        //private void editRecord()
        //{
        //    Production? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Production not selected!");
        //    }
        //}
        //private Production? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Productions.FirstOrDefault(item => item.ProductionId == selectedModel.ProductionId);
        //}
    }
}
