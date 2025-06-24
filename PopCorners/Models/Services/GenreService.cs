using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class GenreService : BaseService<GenreDTO, Genre>
    {
        public override void AddModel(Genre model)
        {
            DatabaseContext.Genres.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(GenreDTO model)
        {
            Genre genre = DatabaseContext.Genres.First(item => item.GenreId == model.GenreId);
            genre.IsActive = false;
            genre.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Genre model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Genre GetModel(int id)
        {
            return DatabaseContext.Genres.First(item => item.GenreId == id);
        }

        public override GenreDTO GetDTO(Genre model)
        {
            return new GenreDTO()
            {
                GenreId = model.GenreId,
                GenreName = model.GenreName,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }
        public override List<GenreDTO> GetModels()
        {
            IQueryable<Genre> genres = DatabaseContext.Genres.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Genre.GenreName):
                        genres = genres.Where(item => item.GenreName.Contains(SearchInput));
                        break;
                    case nameof(Genre.GenreId):
                        genres = genres.Where(item => item.GenreId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Genre.GenreName):
                    if (OrderAscending) genres = genres.OrderBy(item => item.GenreName);
                    else genres = genres.OrderByDescending(item => item.GenreName);
                    break;
                case nameof(Genre.GenreId):
                    if (OrderAscending) genres = genres.OrderBy(item => item.GenreId);
                    else genres = genres.OrderByDescending(item => item.GenreId);
                    break;
            }
            IQueryable<GenreDTO> genresDTO = genres.Select(item => new GenreDTO()
            {
                GenreId = item.GenreId,
                GenreName = item.GenreName,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return genresDTO.ToList();
        }

        public override Genre CreateModel()
        {
            return new Genre()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Genre model)
        {
            DatabaseContext.Genres.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Genre.GenreName),
                    DisplayName = "Name"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Genre.GenreId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
