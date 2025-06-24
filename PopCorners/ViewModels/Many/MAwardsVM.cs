using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MAwardsVM : BaseManyViewModel<AwardService, AwardDTO, Award>
    {
        //    protected DatabaseContext dbContext { get; private set; }
        //    private ObservableCollection<Award> models;
        //    public ObservableCollection<Award> Models
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
        //    private Award? selectedModel;
        //    public Award? SelectedModel
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
        public MAwardsVM() : base("Awards")
        {
            //DisplayName = "Awards";
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
        //    List<Award> awards = dbContext.Awards.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<Award>(awards);
        //}
        //private void deleteRecord()
        //{
        //    Award? record = findSelected();
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
        //    Award? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Award not selected!");
        //    }
        //}
        //private Award? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Awards.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
