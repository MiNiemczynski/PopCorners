using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class PlatformService : BaseService<PlatformDTO, Platform>
    {
        public override void AddModel(Platform model)
        {
            DatabaseContext.Platforms.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(PlatformDTO model)
        {
            Platform platform = DatabaseContext.Platforms.First(item => item.PlatformId == model.PlatformId);
            platform.IsActive = false;
            platform.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Platform model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Platform GetModel(int id)
        {
            return DatabaseContext.Platforms.First(item => item.PlatformId == id);
        }

        public override PlatformDTO GetDTO(Platform model)
        {
            return new PlatformDTO()
            {
                PlatformId = model.PlatformId,
                PlatformName = model.PlatformName,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }
        public override List<PlatformDTO> GetModels()
        {
            IQueryable<Platform> platforms = DatabaseContext.Platforms.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Platform.PlatformName):
                        platforms = platforms.Where(item => item.PlatformName.Contains(SearchInput));
                        break;
                    case nameof(Platform.PlatformId):
                        platforms = platforms.Where(item => item.PlatformId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Platform.PlatformName):
                    if (OrderAscending) platforms = platforms.OrderBy(item => item.PlatformName);
                    else platforms = platforms.OrderByDescending(item => item.PlatformName);
                    break;
                case nameof(Platform.PlatformId):
                    if (OrderAscending) platforms = platforms.OrderBy(item => item.PlatformId);
                    else platforms = platforms.OrderByDescending(item => item.PlatformId);
                    break;
            }
            IQueryable<PlatformDTO> platformsDTO = platforms.Select(item => new PlatformDTO()
            {
                PlatformId = item.PlatformId,
                PlatformName = item.PlatformName,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return platformsDTO.ToList();
        }

        public override Platform CreateModel()
        {
            return new Platform()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Platform model)
        {
            DatabaseContext.Platforms.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Platform.PlatformName),
                    DisplayName = "Name"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Platform.PlatformId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
