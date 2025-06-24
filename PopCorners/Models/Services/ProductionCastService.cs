using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ProductionCastService : BaseService<ProductionCastDTO, ProductionCast>
    {
        public override void AddModel(ProductionCast model)
        {
            DatabaseContext.ProductionCasts.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductionCastDTO model)
        {
            ProductionCast productionCast = DatabaseContext.ProductionCasts.First(item => item.ProductionCastId == model.ProductionCastId);
            DatabaseContext.ProductionCasts.Remove(productionCast);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(ProductionCast model)
        {
            DatabaseContext.ProductionCasts.Remove(model);
            DatabaseContext.SaveChanges();
        }

        public override ProductionCast GetModel(int id)
        {
            return DatabaseContext.ProductionCasts.First(item => item.ProductionCastId == id);
        }

        public override ProductionCastDTO GetDTO(ProductionCast model)
        {
            return new ProductionCastDTO()
            {
                ProductionCastId = model.ProductionCastId,
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
                Actor = new ActorDTO()
                {
                    ActorId = model.ActorId,
                    FullName = model.Actor.FullName,
                    BirthDate = model.Actor.BirthDate,
                    CreationDate = model.Actor.CreationDate,
                    EditionDate = model.Actor.EditionDate
                },
                Role = model.ActorRole
            };
        }
        public override List<ProductionCastDTO> GetModels()
        {
            IQueryable<ProductionCast> productionCasts = DatabaseContext.ProductionCasts;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(ProductionCast.Title):
                //        productionCasts = productionCasts.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionCast.ReleaseYear):
                //        productionCasts = productionCasts.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(ProductionCast.Director):
                //        productionCasts = productionCasts.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionCasts = productionCasts.Include(pc => pc.ProductionCasts).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.ProductionCasts.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(ProductionCast.Platform):
                //        productionCasts = productionCasts.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionCast.ProductionCastId):
                //        productionCasts = productionCasts.Where(item => item.ProductionCastId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<ProductionCastDTO> productionCastsDTO = productionCasts.Select(item => new ProductionCastDTO()
            {
                ProductionCastId = item.ProductionCastId,
                Production = new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Production.Title,
                    Year = item.Production.ReleaseYear,
                    Time = item.Production.Duration,
                    CreationDate = item.Production.CreationDate,
                    EditionDate = item.Production.EditionDate
                },
                Actor = new ActorDTO()
                {
                    ActorId = item.ActorId,
                    FullName = item.Actor.FullName,
                    BirthDate = item.Actor.BirthDate,
                    CreationDate = item.Actor.CreationDate,
                    EditionDate = item.Actor.EditionDate
                },
                Role = item.ActorRole
            });
            return productionCastsDTO.ToList();
        }

        public override ProductionCast CreateModel()
        {
            return new ProductionCast();
        }

        public override void UpdateModel(ProductionCast model)
        {
            DatabaseContext.ProductionCasts.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(ProductionCast.ProductionCastId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
