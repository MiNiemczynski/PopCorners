using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MSeasonsVM : BaseManyViewModel<SeasonService, SeasonDTO, Season>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<SeasonDTO> models;
        //public ObservableCollection<SeasonDTO> Models
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
        //private SeasonDTO? selectedModel;
        //public SeasonDTO? SelectedModel
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
        //public ICommand RefreshCommand { get; }
        //public ICommand EditCommand { get; }
        //public ICommand DeleteCommand { get; }

        public bool NoEpisodes
        {
            get => Service.NoEpisodes;
            set
            {
                if (value != Service.NoEpisodes)
                {
                    Service.NoEpisodes = value;
                    OnPropertyChanged(() => NoEpisodes);
                }
            }
        }
        public MSeasonsVM() : base("Seasons")
        {
            //DisplayName = "Seasons";
            //RefreshCommand = new BaseCommand(() => init());
            //EditCommand = new BaseCommand(() => editRecord());
            //DeleteCommand = new BaseCommand(() => deleteRecord());
            //init();
        }

        protected override void ClearFilters()
        {
            NoEpisodes = true;
            SetDefaultSearchOption();
            Refresh();
        }

        //private void init()
        //{
        //    dbContext = new DatabaseContext();

        //    IQueryable<Season> seasons = dbContext.Seasons
        //        .Include(item => item.Series)
        //        .Where(item => item.IsActive == true);

        //    IQueryable<SeasonDTO> seasonsDTOs = seasons.Select(item => new SeasonDTO()
        //    {
        //        SeasonId = item.SeasonId,
        //        Series = new SeriesDTO()
        //        {
        //            Title = item.Series.Title
        //        },
        //        Number = item.SeasonNumber,
        //        //Episodes = (ICollection<Production>)item.Productions.Select(episode => new SimpleProductionsDTO()
        //        //{
        //        //    ProductionId = episode.ProductionId,
        //        //    Title = episode.Title,
        //        //    Year = episode.ReleaseYear
        //        //}).ToList(),
        //        Description = item.Description,
        //        Episodes = item.Productions.Select(production => new ProductionDTO()
        //        {
        //            Title = production.Title,
        //        }).ToList(),
        //        CreationDate = item.CreationDate,
        //        EditionDate = item.EditionDate
        //    });

        //    Models = new ObservableCollection<SeasonDTO>(seasonsDTOs.ToList());
        //}
        //private void deleteRecord()
        //{
        //    Season? record = findSelected();
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
        //    Season? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Season not selected!");
        //    }
        //}
        //private Season? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Seasons.FirstOrDefault(item => item.SeasonId == selectedModel.SeasonId);
        //}
    }
}
