using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class ActorService : BaseService<ActorDTO, Actor>
    {
        public override void AddModel(Actor model)
        {
            DatabaseContext.Actors.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ActorDTO model)
        {
            Actor actor = DatabaseContext.Actors.First(item => item.ActorId == model.ActorId);
            actor.IsActive = false;
            actor.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Actor model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Actor GetModel(int id)
        {
            return DatabaseContext.Actors.First(item => item.ActorId == id);
        }

        public override ActorDTO GetDTO(Actor model)
        {
            return new ActorDTO()
            {
                ActorId = model.ActorId,
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<ActorDTO> GetModels()
        {
            IQueryable<Actor> actors = DatabaseContext.Actors.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Actor.FullName):
                        actors = actors.Where(item => item.FullName.Contains(SearchInput));
                        break;
                    case nameof(Actor.BirthDate):
                        actors = actors.Where(item => item.BirthDate.ToString().Contains(SearchInput));
                        break;
                    case nameof(Actor.ActorId):
                        actors = actors.Where(item => item.ActorId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Actor.FullName):
                    if (OrderAscending) actors = actors.OrderBy(item => item.FullName);
                    else actors = actors.OrderByDescending(item => item.FullName);
                    break;
                case nameof(Actor.BirthDate):
                    if (OrderAscending) actors = actors.OrderBy(item => item.BirthDate);
                    else actors = actors.OrderByDescending(item => item.BirthDate);
                    break;
                case nameof(Actor.ActorId):
                    if (OrderAscending) actors = actors.OrderBy(item => item.ActorId);
                    else actors = actors.OrderByDescending(item => item.ActorId);
                    break;
            }
            IQueryable<ActorDTO> actorsDTO = actors.Select(item => new ActorDTO()
            {
                ActorId = item.ActorId,
                FullName = item.FullName,
                BirthDate = item.BirthDate,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return actorsDTO.ToList();
        }

        public override Actor CreateModel()
        {
            return new Actor()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Actor model)
        {
            DatabaseContext.Actors.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Actor.FullName),
                    DisplayName = "Name"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Actor.BirthDate),
                    DisplayName = "Birth Date"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Actor.ActorId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
