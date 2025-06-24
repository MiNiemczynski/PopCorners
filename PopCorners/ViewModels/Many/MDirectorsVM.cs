using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MDirectorsVM : BaseManyViewModel<DirectorService, DirectorDTO, Director>
    {
        //    protected DatabaseContext dbContext { get; private set; }
        //    private ObservableCollection<Director> models;
        //    public ObservableCollection<Director> Models
        //    {
        //        get => models;
        //        set
        //        {
        //            if (value != models)
        //            {
        //                models = value;
        //                OnPropertyChanged(() => Models);
        //            }
        //        }
        //    }
        //    private Director? selectedModel;
        //    public Director? SelectedModel
        //    {
        //        get => selectedModel;
        //        set
        //        {
        //            if (value != selectedModel)
        //            {
        //                selectedModel = value;
        //                OnPropertyChanged(() => SelectedModel);
        //            }
        //        }
        //    }
        //    public ICommand RefreshCommand { get; }
        //    public ICommand EditCommand { get; }
        //    public ICommand DeleteCommand { get; }
        public MDirectorsVM() : base("Directors")
        {
            //DisplayName = "Directors";
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
        //    List<Director> directors = dbContext.Directors.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<Director>(directors);
        //}
        //private void deleteRecord()
        //{
        //    Director? record = findSelected();
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
        //    Director? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Director not selected!");
        //    }
        //}
        //private Director? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Directors.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
