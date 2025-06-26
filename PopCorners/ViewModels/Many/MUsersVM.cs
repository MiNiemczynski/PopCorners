using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MUsersVM : BaseManyViewModel<UserService, UserDTO, User>
    {
        public MUsersVM() : base("Users")
        {

        }
    }
}
