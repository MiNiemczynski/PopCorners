using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MPlatformsVM : BaseManyViewModel<PlatformService, PlatformDTO, Platform>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<Platform> models;
        //public ObservableCollection<Platform> Models
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
        //private Platform? selectedModel;
        //public Platform? SelectedModel
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
        public MPlatformsVM() : base("Platforms")
        {
            //DisplayName = "Platforms";
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
        //    List<Platform> platforms = dbContext.Platforms.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<Platform>(platforms);
        //}
        //private void deleteRecord()
        //{
        //    Platform? record = findSelected();
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
        //    Platform? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Platform not selected!");
        //    }
        //}
        //private Platform? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Platforms.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
