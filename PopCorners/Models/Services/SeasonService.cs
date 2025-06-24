using PopCorners.Helpers;
using PopCorners.Models.Contexts;
using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class SeasonService : BaseService<SeasonDTO, Season>
    {
        public bool NoEpisodes { get; set; }
        public SerialMovieEnum SerialMovieOption { get; set; }
        public SeasonService()
        {
            NoEpisodes = true;
        }
        public override void AddModel(Season model)
        {
            DatabaseContext.Seasons.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(SeasonDTO model)
        {
            Season season = DatabaseContext.Seasons.First(item => item.SeasonId == model.SeasonId);
            season.IsActive = false;
            season.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Season model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Season GetModel(int id)
        {
            return DatabaseContext.Seasons.First(item => item.SeasonId == id);
        }
        public override SeasonDTO GetDTO(Season model)
        {
            return new SeasonDTO()
            {
                SeasonId = model.SeasonId,
                Series = model.Series,
                SeasonNumber = model.SeasonNumber,
                Episodes = model.Productions.Select(item => new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Title,
                    Year = item.ReleaseYear,
                    Time = item.Duration,
                    Description = item.Description,
                    DirectorName = item.Director.FullName,
                    PlatformName = item.Platform.PlatformName,
                    CreationDate = item.CreationDate,
                    EditionDate = item.EditionDate
                }).ToList(),
                EpisodesCount = model.Productions.Count(),
                Description = model.Description,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }
        public override List<SeasonDTO> GetModels()
        {
            IQueryable<Season> seasons = DatabaseContext.Seasons.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Season.SeasonNumber):
                        seasons = seasons.Where(item => item.SeasonNumber.ToString().Contains(SearchInput));
                        break;
                    case nameof(Season.Description):
                        seasons = seasons.Where(item => item.Description.Contains(SearchInput));
                        break;
                    case nameof(Season.SeasonId):
                        seasons = seasons.Where(item => item.SeasonId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Season.SeasonNumber):
                    if (OrderAscending) seasons = seasons.OrderBy(item => item.SeasonNumber);
                    else seasons = seasons.OrderByDescending(item => item.SeasonNumber);
                    break;
                case nameof(Season.Description):
                    if (OrderAscending) seasons = seasons.OrderBy(item => item.Description);
                    else seasons = seasons.OrderByDescending(item => item.Description);
                    break;
                case nameof(Season.SeasonId):
                    if (OrderAscending) seasons = seasons.OrderBy(item => item.SeasonId);
                    else seasons = seasons.OrderByDescending(item => item.SeasonId);
                    break;
            }
            if (!NoEpisodes)
            {
                seasons = seasons.Where(item => item.Productions.Count() > 0);
            }
            IQueryable<SeasonDTO> seasonsDTO = seasons.Select(model => new SeasonDTO()
            {
                SeasonId = model.SeasonId,
                Series = model.Series,
                SeasonNumber = model.SeasonNumber,
                Episodes = model.Productions.Select(item => new ProductionDTO()
                {
                    ProductionId = item.ProductionId,
                    Title = item.Title,
                    Year = item.ReleaseYear,
                    Time = item.Duration,
                    Description = item.Description,
                    DirectorName = item.Director.FullName,
                    PlatformName = item.Platform.PlatformName,
                    CreationDate = item.CreationDate,
                    EditionDate = item.EditionDate
                }).ToList(),
                EpisodesCount = model.Productions.Count(),
                Description = model.Description,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            });
            return seasonsDTO.ToList();
        }

        public override Season CreateModel()
        {
            return new Season()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Season model)
        {
            DatabaseContext.Seasons.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Season.SeasonNumber),
                    DisplayName = "Number"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Season.Description),
                    DisplayName = "Description"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Season.SeasonId),
                    DisplayName = "ID"
                }
            };
        }
        public Series? GetSeries(int seriesId)
        {
            Series? series = DatabaseContext.Series.FirstOrDefault(item => item.SeriesId == seriesId);
            return series;
        }
        public List<ComboBoxDTO> GetComboBoxSeries()
        {
            List<ComboBoxDTO> series = DatabaseContext.Series.Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.SeriesId,
                    Title = item.Title
                }).ToList();
            return series;
        }
        public List<ComboBoxDTO> GetComboBoxEpisodes(int seasonId)
        {
            List<ComboBoxDTO> episodes = DatabaseContext.Productions
                .Where(item => item.SeasonId == seasonId)
                .Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.ProductionId,
                    Title = item.Title
                }).ToList();
            return episodes;
        }
        public List<ProductionDTO> GetEpisodesDTO(int seasonId)
        {
            List<ProductionDTO> episodes = DatabaseContext.Productions
                .Where(item => item.SeasonId == seasonId)
                .Where(item => item.IsActive ?? false)
                .Select(model => new ProductionDTO()
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
                    CreationDate = model.CreationDate,
                    EditionDate = model.EditionDate
                }).ToList();
            return episodes;
        }
    }
}
