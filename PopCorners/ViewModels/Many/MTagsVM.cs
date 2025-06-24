using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MTagsVM : BaseManyViewModel<TagService, TagDTO, Tag>
    {
        //protected DatabaseContext dbContext { get; private set; }
        //private ObservableCollection<Tag> models;
        //public ObservableCollection<Tag> Models
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
        //private Tag? selectedModel;
        //public Tag? SelectedModel
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
        public MTagsVM() : base("Tags")
        {
            //DisplayName = "Tags";
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
        //    List<Tag> tags = dbContext.Tags.Where(item => item.IsActive ?? false).ToList();
        //    Models = new ObservableCollection<Tag>(tags);
        //}
        //private void deleteRecord()
        //{
        //    Tag? record = findSelected();
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
        //    Tag? record = findSelected();
        //    if (record != null)
        //    {
        //        // pomysł 1: utworzyć zmienną MainWindowVM i użyć metody createView() - nie działa 
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Tag not selected!");
        //    }
        //}
        //private Tag? findSelected()
        //{
        //    dbContext = new DatabaseContext();
        //    return dbContext.Tags.FirstOrDefault(item => item == selectedModel);
        //}
    }
}
