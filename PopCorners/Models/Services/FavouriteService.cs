using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class FavouriteService : BaseService<FavouriteDTO, Favourite>
    {
        public override void AddModel(Favourite model)
        {
            DatabaseContext.Favourites.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(FavouriteDTO model)
        {
            Favourite productionCast = DatabaseContext.Favourites.First(item => item.FavouritesId == model.FavouriteId);
            DatabaseContext.Favourites.Remove(productionCast);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Favourite model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Favourite GetModel(int id)
        {
            return DatabaseContext.Favourites.First(item => item.FavouritesId == id);
        }
        public override FavouriteDTO GetDTO(Favourite model)
        {
            return new FavouriteDTO()
            {
                FavouriteId = model.FavouritesId,
                User = new UserDTO()
                {
                    UserId = model.UserId,
                    Username = model.User.Username,
                    Email = model.User.Email,
                    Password = model.User.Password,
                    CreationDate = model.User.CreationDate,
                    EditionDate = model.User.EditionDate
                },
                Production = new ProductionDTO()
                {
                    ProductionId = model.ProductionId,
                    Title = model.Production.Title,
                    Year = model.Production.ReleaseYear,
                    Time = model.Production.Duration,
                    Description = model.Production.Description,
                    CreationDate = model.Production.CreationDate,
                    EditionDate = model.Production.EditionDate
                },
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<FavouriteDTO> GetModels()
        {
            IQueryable<Favourite> productionCasts = DatabaseContext.Favourites;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(Favourite.Title):
                //        productionCasts = productionCasts.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(Favourite.ReleaseYear):
                //        productionCasts = productionCasts.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(Favourite.Director):
                //        productionCasts = productionCasts.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionCasts = productionCasts.Include(pc => pc.Favourites).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.Favourites.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(Favourite.Platform):
                //        productionCasts = productionCasts.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(Favourite.FavouriteId):
                //        productionCasts = productionCasts.Where(item => item.FavouriteId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<FavouriteDTO> productionCastsDTO = productionCasts.Select(item => new FavouriteDTO()
            {
                FavouriteId = item.FavouritesId,
                Production = new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Production.Title,
                    Year = item.Production.ReleaseYear,
                    Time = item.Production.Duration,
                    CreationDate = item.Production.CreationDate,
                    EditionDate = item.Production.EditionDate
                },
                User = new UserDTO()
                {
                    UserId = item.UserId,
                    Username = item.User.Username,
                    Email = item.User.Email,
                    Password = item.User.Password,
                    CreationDate = item.User.CreationDate,
                    EditionDate = item.User.EditionDate
                },
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return productionCastsDTO.ToList();
        }

        public override Favourite CreateModel()
        {
            return new Favourite();
        }

        public override void UpdateModel(Favourite model)
        {
            DatabaseContext.Favourites.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Favourite.FavouritesId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
