using Microsoft.EntityFrameworkCore;
using PopCorners.Helpers;
using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ProductionService : BaseService<ProductionDTO, Production>
    {
        public bool HasPlatform { get; set; }
        public SerialMovieEnum SerialMovieOption { get; set; }
        public ProductionService()
        {
            HasPlatform = false;
            SerialMovieOption = SerialMovieEnum.All;
        }
        public override void AddModel(Production model)
        {
            DatabaseContext.Productions.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductionDTO model)
        {
            Production production = DatabaseContext.Productions.First(item => item.ProductionId == model.ProductionId);
            production.IsActive = false;
            production.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Production model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Production GetModel(int id)
        {
            return DatabaseContext.Productions.First(item => item.ProductionId == id);
        }
        public override ProductionDTO GetDTO(Production model)
        {
            return new ProductionDTO()
            {
                ProductionId = model.ProductionId,
                Title = model.Title,
                Year = model.ReleaseYear,
                Time = model.Duration,
                Description = model.Description,
                Director = model.Director,
                Platform = model.Platform,
                Season = model.Season,
                Series = model.Season.Series,
                EpisodeNumber = model.EpisodeNumber,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<ProductionDTO> GetModels()
        {
            IQueryable<Production> productions = DatabaseContext.Productions.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Production.Title):
                        productions = productions.Where(item => item.Title.Contains(SearchInput));
                        break;
                    case nameof(Production.ReleaseYear):
                        productions = productions.Where(item => item.ReleaseYear.ToString().Contains(SearchInput));
                        break;
                    case nameof(Production.Director):
                        productions = productions.Where(item => item.Director.FullName.Contains(SearchInput));
                        break;
                    case nameof(Actor.FullName):
                        productions = productions.Include(pc => pc.ProductionCasts).ThenInclude(a => a.Actor)
                        .Where(pc => pc.ProductionCasts.All(a => a.Actor.FullName.Contains(SearchInput)));
                        break;
                    case nameof(Production.Platform):
                        productions = productions.Where(item => item.Platform.PlatformName.Contains(SearchInput));
                        break;
                    case nameof(Production.ProductionId):
                        productions = productions.Where(item => item.ProductionId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Production.Title):
                    if (OrderAscending) productions = productions.OrderBy(item => item.Title);
                    else productions = productions.OrderByDescending(item => item.Title);
                    break;
                case nameof(Production.ReleaseYear):
                    if (OrderAscending) productions = productions.OrderBy(item => item.ReleaseYear);
                    else productions = productions.OrderByDescending(item => item.ReleaseYear);
                    break;
                case nameof(Production.Director):
                    if (OrderAscending) productions = productions.OrderBy(item => item.Director.FullName);
                    else productions = productions.OrderByDescending(item => item.Director.FullName);
                    break;
                case nameof(Actor.FullName):
                    if (OrderAscending) productions = productions.Include(pc => pc.ProductionCasts).ThenInclude(a => a.Actor)
                            .OrderBy(pc => pc.ProductionCasts.Select(pcItem => pcItem.Actor.FullName).FirstOrDefault());
                    else productions = productions.Include(pc => pc.ProductionCasts).ThenInclude(a => a.Actor)
                            .OrderByDescending(pc => pc.ProductionCasts.Select(pcItem => pcItem.Actor.FullName).FirstOrDefault());
                    break;
                case nameof(Production.Platform):
                    if (OrderAscending) productions = productions.OrderBy(item => item.Platform.PlatformName);
                    else productions = productions.OrderByDescending(item => item.Platform.PlatformName);
                    break;
                case nameof(Production.ProductionId):
                    if (OrderAscending) productions = productions.OrderBy(item => item.ProductionId);
                    else productions = productions.OrderByDescending(item => item.ProductionId);
                    break;
            }
            if (HasPlatform)
            {
                productions = productions.Where(item => !string.IsNullOrEmpty(item.Platform.PlatformName));
            }
            switch (SerialMovieOption)
            {
                case SerialMovieEnum.Movie:
                    productions = productions.Where(item => item.SeasonId == null);
                    break;
                case SerialMovieEnum.Series:
                    productions = productions.Where(item => item.SeasonId != null);
                    break;
            }
            IQueryable<ProductionDTO> productionsDTO = productions.Select(model => new ProductionDTO()
            {
                ProductionId = model.ProductionId,
                Title = model.Title,
                Year = model.ReleaseYear,
                Time = model.Duration,
                Description = model.Description,
                Director = model.Director,
                Platform = model.Platform,
                Season = model.Season,
                Series = model.Season.Series,
                EpisodeNumber = model.EpisodeNumber,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            });
            return productionsDTO.ToList();
        }

        public override Production CreateModel()
        {
            return new Production()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Production model)
        {
            DatabaseContext.Productions.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Production.Title),
                    DisplayName = "Title"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Production.ReleaseYear),
                    DisplayName = "Year"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Production.Director),
                    DisplayName = "Director"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Actor.FullName),
                    DisplayName = "Actor"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Production.Platform),
                    DisplayName = "Platform"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Production.ProductionId),
                    DisplayName = "ID"
                }
            };
        }

        public List<ComboBoxDTO> GetComboBoxDirectors()
        {
            List<ComboBoxDTO> models = DatabaseContext.Directors.Where(item => item.IsActive ?? false)
                .Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.DirectorId,
                    Title = item.FullName
                }).ToList();
            return models;
        }
        public List<ComboBoxDTO> GetComboBoxPlatforms()
        {
            List<ComboBoxDTO> models = DatabaseContext.Platforms.Where(item => item.IsActive ?? false)
                .Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.PlatformId,
                    Title = item.PlatformName
                }).ToList();
            return models;
        }
        public List<ComboBoxDTO> GetComboBoxSeries()
        {
            List<ComboBoxDTO> models = DatabaseContext.Series.Where(item => item.IsActive ?? false)
                .Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.SeriesId,
                    Title = item.Title
                }).ToList();
            return models;
        }
        public List<ComboBoxDTO>? GetComboBoxSeasons(int? seriesId)
        {
            List<ComboBoxDTO> models = DatabaseContext.Seasons.Where(item => item.IsActive ?? false)
                .Where(item => item.IsActive ?? false)
                .Where(item => item.SeriesId == seriesId)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.SeasonId,
                    Title = "Season " + item.SeasonNumber
                }).ToList();
            return models;
        }

        //public Series GetSeries(int seriesId)
        //{
        //    Series series = DatabaseContext.Series.FirstOrDefault(item => item.SeriesId == seriesId);
        //    return series;
        //}
    }
}
