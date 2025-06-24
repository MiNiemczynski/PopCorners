using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class UserService : BaseService<UserDTO, User>
    {
        public override void AddModel(User model)
        {
            DatabaseContext.Users.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(UserDTO model)
        {
            User user = DatabaseContext.Users.First(item => item.UserId == model.UserId);
            user.IsActive = false;
            user.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(User model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override User GetModel(int id)
        {
            return DatabaseContext.Users.First(item => item.UserId == id);
        }
        public override UserDTO GetDTO(User model)
        {
            return new UserDTO()
            {
                UserId = model.UserId,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<UserDTO> GetModels()
        {
            IQueryable<User> users = DatabaseContext.Users.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(User.Username):
                        users = users.Where(item => item.Username.Contains(SearchInput));
                        break;
                    case nameof(User.Email):
                        users = users.Where(item => item.Email.Contains(SearchInput));
                        break;
                    case nameof(User.Password):
                        users = users.Where(item => item.Password.Contains(SearchInput));
                        break;
                    case nameof(User.UserId):
                        users = users.Where(item => item.UserId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(User.Username):
                    if (OrderAscending) users = users.OrderBy(item => item.Username);
                    else users = users.OrderByDescending(item => item.Username);
                    break;
                case nameof(User.Email):
                    if (OrderAscending) users = users.OrderBy(item => item.Email);
                    else users = users.OrderByDescending(item => item.Email);
                    break;
                case nameof(User.Password):
                    if (OrderAscending) users = users.OrderBy(item => item.Password);
                    else users = users.OrderByDescending(item => item.Password);
                    break;
                case nameof(User.UserId):
                    if (OrderAscending) users = users.OrderBy(item => item.UserId);
                    else users = users.OrderByDescending(item => item.UserId);
                    break;
            }
            IQueryable<UserDTO> usersDTO = users.Select(item => new UserDTO()
            {
                UserId = item.UserId,
                Username = item.Username,
                Email = item.Email,
                Password = item.Password,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return usersDTO.ToList();
        }

        public override User CreateModel()
        {
            return new User()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(User model)
        {
            DatabaseContext.Users.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(User.Username),
                    DisplayName = "Username"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(User.Email),
                    DisplayName = "E-mail"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(User.Password),
                    DisplayName = "Password"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(User.UserId),
                    DisplayName = "ID"
                }
            };
        }
    }
}

