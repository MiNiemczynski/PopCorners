using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ProductionAwardService : BaseService<ProductionAwardDTO, ProductionAward>
    {
        public override void AddModel(ProductionAward model)
        {
            DatabaseContext.ProductionAwards.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductionAwardDTO model)
        {
            ProductionAward productionAward = DatabaseContext.ProductionAwards.First(item => item.ProductionAwardId == model.ProductionAwardId);
            DatabaseContext.ProductionAwards.Remove(productionAward);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(ProductionAward model)
        {
            DatabaseContext.ProductionAwards.Remove(model);
            DatabaseContext.SaveChanges();
        }

        public override ProductionAward GetModel(int id)
        {
            return DatabaseContext.ProductionAwards.First(item => item.ProductionAwardId == id);
        }

        public override ProductionAwardDTO GetDTO(ProductionAward model)
        {
            return new ProductionAwardDTO()
            {
                ProductionAwardId = model.ProductionAwardId,
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
                Award = new AwardDTO()
                {
                    AwardId = model.AwardId,
                    AwardName = model.Award.AwardName,
                    Year = model.Award.Year,
                    CreationDate = model.Award.CreationDate,
                    EditionDate = model.Award.EditionDate
                },
                AwardDate = model.AwardDate
            };
        }
        public override List<ProductionAwardDTO> GetModels()
        {
            IQueryable<ProductionAward> productionAwards = DatabaseContext.ProductionAwards;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(ProductionAward.Title):
                //        productionAwards = productionAwards.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionAward.ReleaseYear):
                //        productionAwards = productionAwards.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(ProductionAward.Director):
                //        productionAwards = productionAwards.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionAwards = productionAwards.Include(pc => pc.ProductionAwards).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.ProductionAwards.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(ProductionAward.Platform):
                //        productionAwards = productionAwards.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionAward.ProductionAwardId):
                //        productionAwards = productionAwards.Where(item => item.ProductionAwardId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<ProductionAwardDTO> productionAwardsDTO = productionAwards.Select(item => new ProductionAwardDTO()
            {
                ProductionAwardId = item.ProductionAwardId,
                Production = new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Production.Title,
                    Year = item.Production.ReleaseYear,
                    Time = item.Production.Duration,
                    CreationDate = item.Production.CreationDate,
                    EditionDate = item.Production.EditionDate
                },
                Award = new AwardDTO()
                {
                    AwardId = item.AwardId,
                    AwardName = item.Award.AwardName,
                    Year = item.Award.Year,
                    CreationDate = item.Award.CreationDate,
                    EditionDate = item.Award.EditionDate
                },
                AwardDate = item.AwardDate
            });
            return productionAwardsDTO.ToList();
        }

        public override ProductionAward CreateModel()
        {
            return new ProductionAward();
        }

        public override void UpdateModel(ProductionAward model)
        {
            DatabaseContext.ProductionAwards.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(ProductionAward.ProductionAwardId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
