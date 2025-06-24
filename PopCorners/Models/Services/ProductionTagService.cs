using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ProductionTagService : BaseService<ProductionTagDTO, ProductionTag>
    {
        public override void AddModel(ProductionTag model)
        {
            DatabaseContext.ProductionTags.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductionTagDTO model)
        {
            ProductionTag productionTag = DatabaseContext.ProductionTags.First(item => item.ProductionTagId == model.ProductionTagId);
            DatabaseContext.ProductionTags.Remove(productionTag);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(ProductionTag model)
        {
            DatabaseContext.ProductionTags.Remove(model);
            DatabaseContext.SaveChanges();
        }

        public override ProductionTag GetModel(int id)
        {
            return DatabaseContext.ProductionTags.First(item => item.ProductionTagId == id);
        }
        public override ProductionTagDTO GetDTO(ProductionTag model)
        {
            return new ProductionTagDTO()
            {
                ProductionTagId = model.ProductionTagId,
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
                Tag = new TagDTO()
                {
                    TagId = model.TagId,
                    TagName = model.Tag.TagName,
                    CreationDate = model.Tag.CreationDate,
                    EditionDate = model.Tag.EditionDate
                }
            };
        }
        public override List<ProductionTagDTO> GetModels()
        {
            IQueryable<ProductionTag> productionTags = DatabaseContext.ProductionTags;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(ProductionTag.Title):
                //        productionTags = productionTags.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionTag.ReleaseYear):
                //        productionTags = productionTags.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(ProductionTag.Director):
                //        productionTags = productionTags.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionTags = productionTags.Include(pc => pc.ProductionTags).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.ProductionTags.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(ProductionTag.Platform):
                //        productionTags = productionTags.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionTag.ProductionTagId):
                //        productionTags = productionTags.Where(item => item.ProductionTagId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<ProductionTagDTO> productionTagsDTO = productionTags.Select(item => new ProductionTagDTO()
            {
                ProductionTagId = item.ProductionTagId,
                Production = new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Production.Title,
                    Year = item.Production.ReleaseYear,
                    Time = item.Production.Duration,
                    CreationDate = item.Production.CreationDate,
                    EditionDate = item.Production.EditionDate
                },
                Tag = new TagDTO()
                {
                    TagId = item.TagId,
                    TagName = item.Tag.TagName,
                    CreationDate = item.Tag.CreationDate,
                    EditionDate = item.Tag.EditionDate
                }
            });
            return productionTagsDTO.ToList();
        }

        public override ProductionTag CreateModel()
        {
            return new ProductionTag();
        }

        public override void UpdateModel(ProductionTag model)
        {
            DatabaseContext.ProductionTags.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(ProductionTag.ProductionTagId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
