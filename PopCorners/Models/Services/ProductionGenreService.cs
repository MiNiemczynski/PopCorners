using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ProductionGenreService : BaseService<ProductionGenreDTO, ProductionGenre>
    {
        public override void AddModel(ProductionGenre model)
        {
            DatabaseContext.ProductionGenres.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductionGenreDTO model)
        {
            ProductionGenre productionGenre = DatabaseContext.ProductionGenres.First(item => item.ProductionGenreId == model.ProductionGenreId);
            DatabaseContext.ProductionGenres.Remove(productionGenre);
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(ProductionGenre model)
        {
            DatabaseContext.ProductionGenres.Remove(model);
            DatabaseContext.SaveChanges();
        }

        public override ProductionGenre GetModel(int id)
        {
            return DatabaseContext.ProductionGenres.First(item => item.ProductionGenreId == id);
        }

        public override ProductionGenreDTO GetDTO(ProductionGenre model)
        {
            return new ProductionGenreDTO()
            {
                ProductionGenreId = model.ProductionGenreId,
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
                Genre = new GenreDTO()
                {
                    GenreId = model.GenreId,
                    GenreName = model.Genre.GenreName,
                    CreationDate = model.Genre.CreationDate,
                    EditionDate = model.Genre.EditionDate
                }
            };
        }
        public override List<ProductionGenreDTO> GetModels()
        {
            IQueryable<ProductionGenre> productionGenres = DatabaseContext.ProductionGenres;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                //switch (SearchProperty)
                //{
                //    case nameof(ProductionGenre.Title):
                //        productionGenres = productionGenres.Where(item => item.Title.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionGenre.ReleaseYear):
                //        productionGenres = productionGenres.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                //        break;
                //    case nameof(ProductionGenre.Director):
                //        productionGenres = productionGenres.Where(item => item.Director.FullName.Contains(SearchInput));
                //        break;
                //    case nameof(Actor.FullName):
                //        productionGenres = productionGenres.Include(pc => pc.ProductionGenres).ThenInclude(a => a.Actor)
                //        .Where(pc => pc.ProductionGenres.All(a => a.Actor.FullName.Contains(SearchInput)));
                //        break;
                //    case nameof(ProductionGenre.Platform):
                //        productionGenres = productionGenres.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                //        break;
                //    case nameof(ProductionGenre.ProductionGenreId):
                //        productionGenres = productionGenres.Where(item => item.ProductionGenreId.ToString().Contains(SearchInput));
                //        break;
                //}
            }
            IQueryable<ProductionGenreDTO> productionGenresDTO = productionGenres.Select(item => new ProductionGenreDTO()
            {
                ProductionGenreId = item.ProductionGenreId,
                Production = new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Production.Title,
                    Year = item.Production.ReleaseYear,
                    Time = item.Production.Duration,
                    CreationDate = item.Production.CreationDate,
                    EditionDate = item.Production.EditionDate
                },
                Genre = new GenreDTO()
                {
                    GenreId = item.GenreId,
                    GenreName = item.Genre.GenreName,
                    CreationDate = item.Genre.CreationDate,
                    EditionDate = item.Genre.EditionDate
                }
            });
            return productionGenresDTO.ToList();
        }

        public override ProductionGenre CreateModel()
        {
            return new ProductionGenre();
        }

        public override void UpdateModel(ProductionGenre model)
        {
            DatabaseContext.ProductionGenres.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(ProductionGenre.ProductionGenreId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
