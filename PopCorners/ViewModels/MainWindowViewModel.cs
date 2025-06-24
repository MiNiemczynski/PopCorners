using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models.DTOs;
using PopCorners.ViewModels.Many;
using PopCorners.ViewModels.Many.ManyToMany;
using PopCorners.ViewModels.Single;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;
namespace PopCorners.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region TopAndSideMenuCommand

        // single
        public ICommand OpenProductionViewCommand { get => new BaseCommand(() => CreateView(new ProductionVM())); }
        public ICommand OpenGenreViewCommand { get => new BaseCommand(() => CreateView(new GenreVM())); }
        public ICommand OpenTagViewCommand { get => new BaseCommand(() => CreateView(new TagVM())); }
        public ICommand OpenAwardViewCommand { get => new BaseCommand(() => CreateView(new AwardVM())); }
        public ICommand OpenActorViewCommand { get => new BaseCommand(() => CreateView(new ActorVM())); }
        public ICommand OpenDirectorViewCommand { get => new BaseCommand(() => CreateView(new DirectorVM())); }
        public ICommand OpenPlatformViewCommand { get => new BaseCommand(() => CreateView(new PlatformVM())); }
        public ICommand OpenUserViewCommand { get => new BaseCommand(() => CreateView(new UserVM())); }
        public ICommand OpenSeasonViewCommand { get => new BaseCommand(() => CreateView(new SeasonVM())); }
        public ICommand OpenSeriesViewCommand { get => new BaseCommand(() => CreateView(new SeriesVM())); }

        // many 
        public ICommand OpenManyProductionsViewCommand { get => new BaseCommand(() => CreateView(new MProductionsVM())); }
        public ICommand OpenManyGenresViewModelCommand { get => new BaseCommand(() => CreateView(new MGenresVM())); }
        public ICommand OpenManyTagsViewModelCommand { get => new BaseCommand(() => CreateView(new MTagsVM())); }
        public ICommand OpenManyAwardsViewModelCommand { get => new BaseCommand(() => CreateView(new MAwardsVM())); }
        public ICommand OpenManyActorsViewModelCommand { get => new BaseCommand(() => CreateView(new MActorsVM())); }
        public ICommand OpenManyDirectorsViewModelCommand { get => new BaseCommand(() => CreateView(new MDirectorsVM())); }
        public ICommand OpenManyPlatformsViewModelCommand { get => new BaseCommand(() => CreateView(new MPlatformsVM())); }
        public ICommand OpenManyUsersViewModelCommand { get => new BaseCommand(() => CreateView(new MUsersVM())); }
        public ICommand OpenManySeasonsViewModelCommand { get => new BaseCommand(() => CreateView(new MSeasonsVM())); }
        public ICommand OpenManySeriesViewModelCommand { get => new BaseCommand(() => CreateView(new MSeriesVM())); }

        // many to many 
        public ICommand OpenManyToManyProductionCastsViewModelCommand { get => new BaseCommand(() => CreateView(new MProductionCastsVM())); }
        public ICommand OpenManyToManyProductionAwardsViewModelCommand { get => new BaseCommand(() => CreateView(new MProductionAwardsVM())); }
        public ICommand OpenManyToManyFavouritesViewModelCommand { get => new BaseCommand(() => CreateView(new MFavouritesVM())); }
        public ICommand OpenManyToManyReviewsViewModelCommand { get => new BaseCommand(() => CreateView(new MReviewsVM())); }
        public ICommand OpenManyToManyProductionTagsViewModelCommand { get => new BaseCommand(() => CreateView(new MProductionTagsVM())); }
        public ICommand OpenManyToManyProductionGenresViewModelCommand { get => new BaseCommand(() => CreateView(new MProductionGenresVM())); }

        #endregion


        public MainWindowViewModel()
        {
            Commands = new(CreateCommands());
            ManyToManyCommands = new(CreateManyToManyCommands());
            CommandSets = new(CreateCommandSets());
            Workspaces = new();
            Workspaces.CollectionChanged += OnWorkspacesChanged;
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<ActorDTO?>>(this, (sender, message) => HandleOpenActorVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<AwardDTO?>>(this, (sender, message) => HandleOpenAwardVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<DirectorDTO?>>(this, (sender, message) => HandleOpenDirectorVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<GenreDTO?>>(this, (sender, message) => HandleOpenGenreVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<PlatformDTO?>>(this, (sender, message) => HandleOpenPlatformVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<ProductionDTO?>>(this, (sender, message) => HandleOpenProductionVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<SeasonDTO?>>(this, (sender, message) => HandleOpenSeasonVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<SeriesDTO?>>(this, (sender, message) => HandleOpenSeriesVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<TagDTO?>>(this, (sender, message) => HandleOpenTagVM(message.Value, sender));
            WeakReferenceMessenger.Default.Register<ValueChangedMessage<UserDTO?>>(this, (sender, message) => HandleOpenUserVM(message.Value, sender));
        }

        #region Buttons in side bar

        public ReadOnlyCollection<CommandViewModel> Commands { get; set; }
        public ReadOnlyCollection<CommandViewModel> ManyToManyCommands { get; set; }
        public ReadOnlyCollection<CommandsSetDTO> CommandSets { get; set; }

        private List<CommandViewModel> CreateCommands()
        {
            return new()
            {
                new ("Production", OpenProductionViewCommand),
                new ("Productions", OpenManyProductionsViewCommand),
                new ("Genre", OpenGenreViewCommand),
                new ("Genres", OpenManyGenresViewModelCommand),
                new ("Tag", OpenTagViewCommand),
                new ("Tags", OpenManyTagsViewModelCommand),
                new ("Award", OpenAwardViewCommand),
                new ("Awards", OpenManyAwardsViewModelCommand),
                new ("Actor", OpenActorViewCommand),
                new ("Actors", OpenManyActorsViewModelCommand),
                new ("Director", OpenDirectorViewCommand),
                new ("Directors", OpenManyDirectorsViewModelCommand),
                new ("Platform", OpenPlatformViewCommand),
                new ("Platforms", OpenManyPlatformsViewModelCommand),
                new ("User", OpenUserViewCommand),
                new ("Users", OpenManyUsersViewModelCommand),
                new ("Season", OpenSeasonViewCommand),
                new ("Seasons", OpenManySeasonsViewModelCommand),
                new ("Series", OpenSeriesViewCommand),
                new ("Series", OpenManySeriesViewModelCommand)
            };
        }
        private List<CommandViewModel> CreateManyToManyCommands()
        {
            return new()
            {
                new("Production Casts",OpenManyToManyProductionCastsViewModelCommand),
                new("Production Awards",OpenManyToManyProductionAwardsViewModelCommand),
                new("Favourites",OpenManyToManyFavouritesViewModelCommand),
                new("Reviews",OpenManyToManyReviewsViewModelCommand),
                new("Production Genres",OpenManyToManyProductionGenresViewModelCommand),
                new("Production Tags",OpenManyToManyProductionTagsViewModelCommand)
            };
        }
        private List<CommandsSetDTO> CreateCommandSets()
        {
            return new()
            {
                new ("Productions", OpenProductionViewCommand, OpenManyProductionsViewCommand),
                new ("Genres", OpenGenreViewCommand, OpenManyGenresViewModelCommand),
                new ("Directors", OpenDirectorViewCommand, OpenManyDirectorsViewModelCommand),
                new ("Actors", OpenActorViewCommand, OpenManyActorsViewModelCommand),
                new ("Awards", OpenAwardViewCommand, OpenManyAwardsViewModelCommand),
                new ("Tags", OpenTagViewCommand, OpenManyTagsViewModelCommand),
                new ("Platforms", OpenPlatformViewCommand, OpenManyPlatformsViewModelCommand),
                new ("Users", OpenUserViewCommand, OpenManyUsersViewModelCommand),
                new ("Seasons", OpenSeasonViewCommand, OpenManySeasonsViewModelCommand),
                new ("Series", OpenSeriesViewCommand, OpenManySeriesViewModelCommand)
            };
        }


        #endregion

        #region Tabs

        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= onWorkspaceRequestClose;
        }

        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel? workspace = sender as WorkspaceViewModel;
            if (workspace != null)
            {
                Workspaces.Remove(workspace);
            }
        }

        #endregion

        #region Helepers

        private WorkspaceViewModel WorkspaceAlreadyExists(WorkspaceViewModel workspace)
        {
            foreach (WorkspaceViewModel workspaceVM in Workspaces)
                if (workspaceVM.DisplayName == workspace.DisplayName)
                    return workspaceVM;
            return null;
        }

        public void CreateView(WorkspaceViewModel workspace)
        {
            if (WorkspaceAlreadyExists(workspace) != null) workspace = WorkspaceAlreadyExists(workspace);
            else Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreateListView<WorkspaceViewModelType>() where WorkspaceViewModelType : WorkspaceViewModel, new()
        {
            WorkspaceViewModel? workspace = Workspaces.FirstOrDefault(vm => vm is WorkspaceViewModelType);
            if (workspace == null)
            {
                workspace = new WorkspaceViewModelType();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void HandleOpenActorVM(ActorDTO? selected, object sender)
        {
            if (selected == null) CreateView(new ActorVM());
            else CreateView(new ActorVM(selected));
        }
        private void HandleOpenAwardVM(AwardDTO? selected, object sender)
        {
            if (selected == null) CreateView(new AwardVM());
            else CreateView(new AwardVM(selected));
        }
        private void HandleOpenDirectorVM(DirectorDTO? selected, object sender)
        {
            if (selected == null) CreateView(new DirectorVM());
            else CreateView(new DirectorVM(selected));
        }
        private void HandleOpenGenreVM(GenreDTO? selected, object sender)
        {
            if (selected == null) CreateView(new GenreVM());
            else CreateView(new GenreVM(selected));
        }
        private void HandleOpenPlatformVM(PlatformDTO? selected, object sender)
        {
            if (selected == null) CreateView(new PlatformVM());
            else CreateView(new PlatformVM(selected));
        }
        private void HandleOpenProductionVM(ProductionDTO? selected, object sender)
        {
            if (selected == null) CreateView(new ProductionVM());
            else CreateView(new ProductionVM(selected));
        }
        private void HandleOpenSeasonVM(SeasonDTO? selected, object sender)
        {
            if (selected == null) CreateView(new SeasonVM());
            else CreateView(new SeasonVM(selected));
        }
        private void HandleOpenSeriesVM(SeriesDTO? selected, object sender)
        {
            if (selected == null) CreateView(new SeriesVM());
            else CreateView(new SeriesVM(selected));
        }
        private void HandleOpenTagVM(TagDTO? selected, object sender)
        {
            if (selected == null) CreateView(new TagVM());
            else CreateView(new TagVM(selected));
        }
        private void HandleOpenUserVM(UserDTO? selected, object sender)
        {
            if (selected == null) CreateView(new UserVM());
            else CreateView(new UserVM(selected));
        }

        #endregion
    }
}
