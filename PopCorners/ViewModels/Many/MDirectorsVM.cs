using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MDirectorsVM : BaseManyViewModel<DirectorService, DirectorDTO, Director>
    {
        public MDirectorsVM() : base("Directors")
        {
        }
    }
}
