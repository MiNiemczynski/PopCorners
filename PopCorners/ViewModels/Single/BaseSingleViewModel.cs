using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models.Services;
using System.Windows.Input;

namespace PopCorners.ViewModels.Single
{
    public class BaseSingleViewModel<ServiceType, DtoType, ModelType>
        : BaseServiceViewModel<ServiceType, DtoType, ModelType>
        where ServiceType : BaseService<DtoType, ModelType>, new()
        where DtoType : class
        where ModelType : class, new()
    {
        private ModelType _Model;
        public ModelType Model
        {
            get => _Model;
            set
            {
                if (_Model != value)
                {
                    _Model = value;
                    OnPropertyChanged(() => Model);
                }
            }
        }
        public ICommand NewCommand { get; set; }
        public ICommand DuplicateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public new string DisplayName { get; set; }
        public BaseSingleViewModel(string displayName) : base(displayName)
        {
            DisplayName = displayName;
            _Model = Service.CreateModel();
            NewCommand = new BaseCommand(() => New());
            SaveCommand = new BaseCommand(() => Save());
            DuplicateCommand = new BaseCommand(() => Duplicate());
            DeleteCommand = new BaseCommand(() => Delete());
            CancelCommand = new BaseCommand(() => Cancel());
        }
        protected void New()
        {
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<DtoType?>(null));
        }
        protected virtual void Save()
        {
            Service.AddModel(Model);
            OnRequestClose();
            New();
        }
        protected void Update()
        {
            Service.UpdateModel(Model);
        }
        protected void Cancel()
        {
            OnRequestClose();
        }
        protected virtual void Duplicate()
        {
            DtoType original = Service.GetDTO(Model);
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<DtoType?>(original));
        }
        protected void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
