using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    class MActorsVM : BaseManyViewModel<ActorService, ActorDTO, Actor>
    {
        public MActorsVM() : base("Actors")
        {

        }
    }
}
