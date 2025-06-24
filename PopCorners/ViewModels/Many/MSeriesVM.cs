using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MSeriesVM : BaseManyViewModel<SeriesService, SeriesDTO, Series>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<SeriesDTO> models;
        //public ObservableCollection<SeriesDTO> Models
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
        //private SeriesDTO? selectedModel;
        //public SeriesDTO? SelectedModel
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

        public bool HasDescription
        {
            get => Service.HasDescription;
            set
            {
                if (value != Service.HasDescription)
                {
                    Service.HasDescription = value;
                    OnPropertyChanged(() => HasDescription);
                }
            }
        }
        public bool NoSeasons
        {
            get => Service.NoSeasons;
            set
            {
                if (value != Service.NoSeasons)
                {
                    Service.NoSeasons = value;
                    OnPropertyChanged(() => NoSeasons);
                }
            }
        }

        //public ICommand RefreshCommand { get; }
        //public ICommand EditCommand { get; }
        //public ICommand DeleteCommand { get; }
        public MSeriesVM() : base("All Series")
        {
            //DisplayName = "Series";
            //RefreshCommand = new BaseCommand(() => init());
            //EditCommand = new BaseCommand(() => editRecord());
            //DeleteCommand = new BaseCommand(() => deleteRecord());
            //init();
        }

        protected override void ClearFilters()
        {
            HasDescription = false;
            NoSeasons = true;
            SetDefaultSearchOption();
            Refresh();
        }

        //private void init()
        //{
        //    dbContext = new DatabaseContext();

        //    IQueryable<Series> series = dbContext.Series
        //        .Include(item => item.Seasons)
        //        .Where(item => item.IsActive == true);

        //    IQueryable<SeriesDTO> seriesDTOs = series.Select(item => new SeriesDTO()
        //    {
        //        SeriesId = item.SeriesId,
        //        Title = item.Title,
        //        Description = item.Description,
        //        Seasons = item.Seasons.Select(season => new SeasonDTO()
        //        {
        //            Number = season.SeasonNumber
        //        }).ToList(),
        //        CreationDate = item.CreationDate,
        //        EditionDate = item.EditionDate
        //    });

        //    Models = new ObservableCollection<SeriesDTO>(seriesDTOs.ToList());
        //}
        //private void deleteRecord()
        //{
        //    Series? record = findSelected();
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
        //    Series? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Serie not selected!");
        //    }
        //}
        //private Series? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Series.FirstOrDefault(item => item.SeriesId == selectedModel.SeriesId);
        //}
    }
}
