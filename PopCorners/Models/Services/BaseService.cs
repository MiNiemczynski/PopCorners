using PopCorners.Models.Contexts;
using PopCorners.Models.DTOs;

namespace PopCorners.Models.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="DtoType">DTO do wyświetlenia na liście</typeparam>
    /// <typeparam name="ModelType">Model do dodania/edycji</typeparam>    
    public abstract class BaseService<DtoType, ModelType>
        where ModelType : new()
    {
        protected DatabaseContext DatabaseContext { get; set; }
        public string? SearchInput { get; set; }
        public string? SearchProperty { get; set; }
        public string? OrderProperty { get; set; }
        public bool OrderAscending { get; set; }
        public BaseService()
        {
            DatabaseContext = new DatabaseContext();
            OrderAscending = true;
        }
        public abstract List<DtoType> GetModels();
        public abstract ModelType GetModel(int id);
        public abstract void AddModel(ModelType model);
        public abstract void UpdateModel(ModelType model);
        public abstract void DeleteModel(DtoType model);
        public abstract void DeleteModel(ModelType model);
        public abstract List<SearchComboBoxDTO> GetSearchOptions();
        public abstract DtoType GetDTO(ModelType model);
        public virtual ModelType CreateModel()
        {
            return new ModelType();
        }
    }
}
