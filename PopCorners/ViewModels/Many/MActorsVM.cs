using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    class MActorsVM : BaseManyViewModel<ActorService, ActorDTO, Actor>
    {
        public MActorsVM() : base("Actors")
        {
            //WeakReferenceMessenger.Default.Register<ValueChangedMessage<Actor?>>(this, (sender, message) => DeleteActorVM(message.Value));
        }
        //private void DeleteActorVM(Actor model)
        //{
        //    Models.Remove(model);
        //}
        protected override void ClearFilters()
        {
            SetDefaultSearchOption();
            Refresh();
        }
    }
}
