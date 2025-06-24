using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class DirectorService : BaseService<DirectorDTO, Director>
    {
        public override void AddModel(Director model)
        {
            DatabaseContext.Directors.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(DirectorDTO model)
        {
            Director director = DatabaseContext.Directors.First(item => item.DirectorId == model.DirectorId);
            director.IsActive = false;
            director.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Director model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Director GetModel(int id)
        {
            return DatabaseContext.Directors.First(item => item.DirectorId == id);
        }

        public override DirectorDTO GetDTO(Director model)
        {
            return new DirectorDTO()
            {
                DirectorId = model.DirectorId,
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }
        public override List<DirectorDTO> GetModels()
        {
            IQueryable<Director> directors = DatabaseContext.Directors.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Director.FullName):
                        directors = directors.Where(item => item.FullName.Contains(SearchInput));
                        break;
                    case nameof(Director.BirthDate):
                        directors = directors.Where(item => item.BirthDate.ToString().Contains(SearchInput));
                        break;
                    case nameof(Director.DirectorId):
                        directors = directors.Where(item => item.DirectorId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Director.FullName):
                    if (OrderAscending) directors = directors.OrderBy(item => item.FullName);
                    else directors = directors.OrderByDescending(item => item.FullName);
                    break;
                case nameof(Director.BirthDate):
                    if (OrderAscending) directors = directors.OrderBy(item => item.BirthDate);
                    else directors = directors.OrderByDescending(item => item.BirthDate);
                    break;
                case nameof(Director.DirectorId):
                    if (OrderAscending) directors = directors.OrderBy(item => item.DirectorId);
                    else directors = directors.OrderByDescending(item => item.DirectorId);
                    break;
            }
            IQueryable<DirectorDTO> directorsDTO = directors.Select(item => new DirectorDTO()
            {
                DirectorId = item.DirectorId,
                FullName = item.FullName,
                BirthDate = item.BirthDate,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return directorsDTO.ToList();
        }

        public override Director CreateModel()
        {
            return new Director()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Director model)
        {
            DatabaseContext.Directors.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Director.FullName),
                    DisplayName = "Name"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Director.BirthDate),
                    DisplayName = "Birth Date"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Director.DirectorId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
