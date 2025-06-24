using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ReviewService : BaseService<ReviewDTO, Review>
    {
        public override void AddModel(Review model)
        {
            DatabaseContext.Reviews.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ReviewDTO model)
        {
            Review productionCast = DatabaseContext.Reviews.First(item => item.ReviewId == model.ReviewId);
            DatabaseContext.Reviews.Remove(productionCast);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Review model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Review GetModel(int id)
        {
            return DatabaseContext.Reviews.First(item => item.ReviewId == id);
        }
        public override ReviewDTO GetDTO(Review model)
        {
            return new ReviewDTO()
            {
                ReviewId = model.ReviewId,
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
                User = new UserDTO()
                {
                    UserId = model.UserId,
                    Username = model.User.Username,
                    Email = model.User.Email,
                    Password = model.User.Password,
                    CreationDate = model.User.CreationDate,
                    EditionDate = model.User.EditionDate
                },
                Comment = model.Comment,
                Rating = model.Rating,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }
        public override List<ReviewDTO> GetModels()
        {
            IQueryable<Review> productionCasts = DatabaseContext.Reviews;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(Review.Title):
                //        productionCasts = productionCasts.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(Review.ReleaseYear):
                //        productionCasts = productionCasts.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(Review.Director):
                //        productionCasts = productionCasts.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionCasts = productionCasts.Include(pc => pc.Reviews).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.Reviews.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(Review.Platform):
                //        productionCasts = productionCasts.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(Review.ReviewId):
                //        productionCasts = productionCasts.Where(item => item.ReviewId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<ReviewDTO> productionCastsDTO = productionCasts.Select(item => new ReviewDTO()
            {
                ReviewId = item.ReviewId,
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
                Comment = item.Comment,
                Rating = item.Rating,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return productionCastsDTO.ToList();
        }

        public override Review CreateModel()
        {
            return new Review();
        }

        public override void UpdateModel(Review model)
        {
            DatabaseContext.Reviews.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Review.ReviewId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
