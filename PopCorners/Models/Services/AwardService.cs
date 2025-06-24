using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class AwardService : BaseService<AwardDTO, Award>
    {
        public override void AddModel(Award model)
        {
            DatabaseContext.Awards.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(AwardDTO model)
        {
            Award award = DatabaseContext.Awards.First(item => item.AwardId == model.AwardId);
            award.IsActive = false;
            award.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Award model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Award GetModel(int id)
        {
            return DatabaseContext.Awards.First(item => item.AwardId == id);
        }
        public override AwardDTO GetDTO(Award model)
        {
            return new AwardDTO()
            {
                AwardId = model.AwardId,
                AwardName = model.AwardName,
                Year = model.Year,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<AwardDTO> GetModels()
        {
            IQueryable<Award> awards = DatabaseContext.Awards.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Award.AwardName):
                        awards = awards.Where(item => item.AwardName.Contains(SearchInput));
                        break;
                    case nameof(Award.Year):
                        awards = awards.Where(item => item.Year.ToString().Contains(SearchInput));
                        break;
                    case nameof(Award.AwardId):
                        awards = awards.Where(item => item.AwardId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Award.AwardName):
                    if (OrderAscending) awards = awards.OrderBy(item => item.AwardName);
                    else awards = awards.OrderByDescending(item => item.AwardName);
                    break;
                case nameof(Award.Year):
                    if (OrderAscending) awards = awards.OrderBy(item => item.Year);
                    else awards = awards.OrderByDescending(item => item.Year);
                    break;
                case nameof(Award.AwardId):
                    if (OrderAscending) awards = awards.OrderBy(item => item.AwardId);
                    else awards = awards.OrderByDescending(item => item.AwardId);
                    break;
            }
            IQueryable<AwardDTO> awardsDTO = awards.Select(item => new AwardDTO()
            {
                AwardId = item.AwardId,
                AwardName = item.AwardName,
                Year = item.Year,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return awardsDTO.ToList();
        }

        public override Award CreateModel()
        {
            return new Award()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Award model)
        {
            DatabaseContext.Awards.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Award.AwardName),
                    DisplayName = "Title"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Award.Year),
                    DisplayName = "Year"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Award.AwardId),
                    DisplayName = "ID"
                }
            };
        }

    }
}
