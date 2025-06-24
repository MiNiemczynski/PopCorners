using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class SeriesService : BaseService<SeriesDTO, Series>
    {
        public bool HasDescription { get; set; }
        public bool NoSeasons { get; set; }
        public SeriesService()
        {
            HasDescription = false;
            NoSeasons = true;
        }
        public override void AddModel(Series model)
        {
            DatabaseContext.Series.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(SeriesDTO model)
        {
            Series series = DatabaseContext.Series.First(item => item.SeriesId == model.SeriesId);
            series.IsActive = false;
            series.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Series model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Series GetModel(int id)
        {
            return DatabaseContext.Series.First(item => item.SeriesId == id);
        }
        public override SeriesDTO GetDTO(Series model)
        {
            return new SeriesDTO()
            {
                SeriesId = model.SeriesId,
                Title = model.Title,
                Seasons = model.Seasons.Select(item => new SeasonDTO()
                {
                    SeasonId = item.SeasonId,
                    SeasonNumber = item.SeasonNumber,
                    Episodes = item.Productions.Select(item => new ProductionDTO()
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
                    EpisodesCount = item.Productions.Count(),
                    CreationDate = item.CreationDate,
                    EditionDate = item.EditionDate
                }).ToList(),
                Description = model.Description,
                SeasonsCount = model.Seasons.Count(),
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<SeriesDTO> GetModels()
        {
            IQueryable<Series> series = DatabaseContext.Series.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Series.Title):
                        series = series.Where(item => item.Title.Contains(SearchInput));
                        break;
                    case nameof(Series.Description):
                        series = series.Where(item => item.Description.Contains(SearchInput));
                        break;
                    case nameof(Series.SeriesId):
                        series = series.Where(item => item.SeriesId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Series.Title):
                    if (OrderAscending) series = series.OrderBy(item => item.Title);
                    else series = series.OrderByDescending(item => item.Title);
                    break;
                case nameof(Series.Description):
                    if (OrderAscending) series = series.OrderBy(item => item.Description);
                    else series = series.OrderByDescending(item => item.Description);
                    break;
                case nameof(Series.SeriesId):
                    if (OrderAscending) series = series.OrderBy(item => item.SeriesId);
                    else series = series.OrderByDescending(item => item.SeriesId);
                    break;
            }
            if (HasDescription)
            {
                series = series.Where(item => !string.IsNullOrEmpty(item.Description));
            }
            if (!NoSeasons)
            {
                series = series.Where(item => item.Seasons.Count() > 0);
            }
            IQueryable<SeriesDTO> seriesDTO = series.Select(item => new SeriesDTO()
            {
                SeriesId = item.SeriesId,
                Title = item.Title,
                Seasons = item.Seasons.Select(item => new SeasonDTO()
                {
                    SeasonId = item.SeasonId,
                    SeasonNumber = item.SeasonNumber,
                    Episodes = item.Productions.Select(item => new ProductionDTO()
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
                    EpisodesCount = item.Productions.Count(),
                    CreationDate = item.CreationDate,
                    EditionDate = item.EditionDate
                }).ToList(),
                Description = item.Description,
                SeasonsCount = item.Seasons.Count(),
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return seriesDTO.ToList();
        }

        public override Series CreateModel()
        {
            return new Series()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Series model)
        {
            DatabaseContext.Series.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Series.Title),
                    DisplayName = "Title"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Series.Description),
                    DisplayName = "Description"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Series.SeriesId),
                    DisplayName = "ID"
                }
            };
        }

        public List<ComboBoxDTO> GetComboBoxSeasons(int seriesId)
        {
            List<ComboBoxDTO> seasons = DatabaseContext.Seasons
                .Where(item => item.SeriesId == seriesId)
                .Where(item => item.IsActive ?? false)
                .Select(item => new ComboBoxDTO()
                {
                    ID = item.SeasonId,
                    Title = "Season " + item.SeasonNumber.ToString()
                }).ToList();
            return seasons;
        }
        public List<SeasonDTO> GetSeasonsDTO(int seriesId)
        {
            List<SeasonDTO> seasons = DatabaseContext.Seasons
                .Where(item => item.SeriesId == seriesId)
                .Where(item => item.IsActive ?? false)
                .Select(model => new SeasonDTO()
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
                }).ToList();
            return seasons;
        }
    }
}
