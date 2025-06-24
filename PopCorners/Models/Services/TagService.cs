using PopCorners.Models.Contexts;
using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    public class TagService : BaseService<TagDTO, Tag>
    {
        public override void AddModel(Tag model)
        {
            DatabaseContext.Tags.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(TagDTO model)
        {
            Tag tag = DatabaseContext.Tags.First(item => item.TagId == model.TagId);
            tag.IsActive = false;
            tag.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }
        public override void DeleteModel(Tag model)
        {
            model.IsActive = false;
            model.DeletionDate = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Tag GetModel(int id)
        {
            return DatabaseContext.Tags.First(item => item.TagId == id);
        }
        public override TagDTO GetDTO(Tag model)
        {
            return new TagDTO()
            {
                TagId = model.TagId,
                TagName = model.TagName,
                CreationDate = model.CreationDate,
                EditionDate = model.EditionDate
            };
        }

        public override List<TagDTO> GetModels()
        {
            IQueryable<Tag> tags = DatabaseContext.Tags.Where(item => item.IsActive ?? false);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                switch (SearchProperty)
                {
                    case nameof(Tag.TagName):
                        tags = tags.Where(item => item.TagName.Contains(SearchInput));
                        break;
                    case nameof(Tag.TagId):
                        tags = tags.Where(item => item.TagId.ToString().Contains(SearchInput));
                        break;
                }
            }
            switch (OrderProperty)
            {
                case nameof(Tag.TagName):
                    if (OrderAscending) tags = tags.OrderBy(item => item.TagName);
                    else tags = tags.OrderByDescending(item => item.TagName);
                    break;
                case nameof(Tag.TagId):
                    if (OrderAscending) tags = tags.OrderBy(item => item.TagId);
                    else tags = tags.OrderByDescending(item => item.TagId);
                    break;
            }
            IQueryable<TagDTO> tagsDTO = tags.Select(item => new TagDTO()
            {
                TagId = item.TagId,
                TagName = item.TagName,
                CreationDate = item.CreationDate,
                EditionDate = item.EditionDate
            });
            return tagsDTO.ToList();
        }

        public override Tag CreateModel()
        {
            return new Tag()
            {
                IsActive = true,
                CreationDate = DateTime.Now
            };
        }

        public override void UpdateModel(Tag model)
        {
            DatabaseContext.Tags.Update(model);
            DatabaseContext.SaveChanges();
        }

        public override List<SearchComboBoxDTO> GetSearchOptions()
        {
            return new List<SearchComboBoxDTO>
            {
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Tag.TagName),
                    DisplayName = "Name"
                },
                new SearchComboBoxDTO
                {
                    PropertyName = nameof(Tag.TagId),
                    DisplayName = "ID"
                }
            };
        }
    }
}
