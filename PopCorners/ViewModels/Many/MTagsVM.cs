using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MTagsVM : BaseManyViewModel<TagService, TagDTO, Tag>
    {
        public MTagsVM() : base("Tags")
        {

        }
    }
}
