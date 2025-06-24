using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PopCorners.ViewModels.Many
{
    public abstract class BaseManyViewModel<ServiceType, DtoType, ModelType>
        : BaseServiceViewModel<ServiceType, DtoType, ModelType>
        where ServiceType : BaseService<DtoType, ModelType>, new()
        where DtoType : class
        where ModelType : new()
    {
        private ObservableCollection<DtoType> _Models;
        public ObservableCollection<DtoType> Models
        {
            get => _Models;
            set
            {
                if (_Models != value)
                {
                    _Models = value;
                    OnPropertyChanged(() => Models);
                }
            }
        }
        public List<SearchComboBoxDTO> SearchOption { get; set; }
        public List<SearchComboBoxDTO> OrderOption { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }
        public string? SearchInput
        {
            get => Service.SearchInput;
            set
            {
                if (Service.SearchInput != value)
                {
                    Service.SearchInput = value;
                    OnPropertyChanged(() => SearchInput);
                }
            }
        }
        public string? SearchProperty
        {
            get => Service.SearchProperty;
            set
            {
                if (Service.SearchProperty != value)
                {
                    Service.SearchProperty = value;
                    OnPropertyChanged(() => SearchProperty);
                }
            }
        }
        public string? OrderProperty
        {
            get => Service.OrderProperty;
            set
            {
                if (Service.OrderProperty != value)
                {
                    Service.OrderProperty = value;
                    OnPropertyChanged(() => OrderProperty);
                }
            }
        }
        public bool OrderAscending
        {
            get => Service.OrderAscending;
            set
            {
                if (Service.OrderAscending != value)
                {
                    Service.OrderAscending = value;
                    OnPropertyChanged(() => OrderAscending);
                }
            }
        }
        private DtoType? _SelectedModel;
        public DtoType? SelectedModel
        {
            get => _SelectedModel;
            set
            {
                if (_SelectedModel != value)
                {
                    _SelectedModel = value;
                    OnPropertyChanged(() => SelectedModel);
                }
            }
        }
        public BaseManyViewModel(string displayName) : base(displayName)
        {
            _Models = default!;
            Refresh();
            RefreshCommand = new BaseCommand(() => Refresh());
            AddCommand = new BaseCommand(() => New());
            EditCommand = new BaseCommand(() => Edit());
            DeleteCommand = new BaseCommand(() => Delete());
            FilterCommand = new BaseCommand(() => Refresh());
            ClearFilterCommand = new BaseCommand(() => ClearFilters());
            SearchOption = Service.GetSearchOptions();
            OrderOption = Service.GetSearchOptions();
            SetDefaultSearchOption();
        }
        public void SetDefaultSearchOption()
        {
            SearchProperty = SearchOption.FirstOrDefault()?.PropertyName;
            OrderProperty = OrderOption.FirstOrDefault()?.PropertyName;
            SearchInput = "";
        }
        public void Refresh()
        {
            Models = new ObservableCollection<DtoType>(Service.GetModels());
        }
        public void New()
        {
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<DtoType?>(null));
        }
        public void Edit()
        {
            if (SelectedModel != null)
                WeakReferenceMessenger.Default.Send(new ValueChangedMessage<DtoType?>(SelectedModel));
        }
        private void Delete()
        {
            if (SelectedModel != null)
            {
                Service.DeleteModel(SelectedModel);
                Models.Remove(SelectedModel);
            }
        }
        protected abstract void ClearFilters();
    }
}
