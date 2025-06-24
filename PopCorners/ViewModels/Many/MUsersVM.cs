using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MUsersVM : BaseManyViewModel<UserService, UserDTO, User>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<User> models;
        //public ObservableCollection<User> Models
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
        //private User? selectedModel;
        //public User? SelectedModel
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
        public MUsersVM() : base("Users")
        {
            //DisplayName = "Users";
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
        //    List<User> users = dbContext.Users.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<User>(users);
        //}
        //private void deleteRecord()
        //{
        //    User? record = findSelected();
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
        //    User? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("User not selected!");
        //    }
        //}
        //private User? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Users.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
