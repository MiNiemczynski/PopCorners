using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MGenresVM : BaseManyViewModel<GenreService, GenreDTO, Genre>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<Genre> models;
        //public ObservableCollection<Genre> Models
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
        //private Genre? selectedModel;
        //public Genre? SelectedModel
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
        public MGenresVM() : base("Genres")
        {
            //DisplayName = "Genres";
            //RefreshCommand = new BaseCommand(() => init());
            //EditCommand = new BaseCommand(() => editRecord());
            //DeleteCommand = new BaseCommand(() => deleteRecord());
            //init();
        }

        protected override void ClearFilters()
        {
            SetDefaultSearchOption();
            Refresh();
        }

        //private void init()
        //{
        //    dbContext = new DatabaseContext();
        //    List<Genre> genres = dbContext.Genres.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<Genre>(genres);
        //}
        //private void deleteRecord()
        //{
        //    Genre? record = findSelected();
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
        //    Genre? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    } 
        //    else
        //    {
        //        Debug.WriteLine("Genre not selected!");
        //    }
        //}
        //private Genre? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Genres.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
