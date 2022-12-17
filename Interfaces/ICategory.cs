using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface ICategory
    {
        public Task<CategoryModel> GetCategory(int id);
        public Task<List<CategoryModel>> GetCategories();
        public void CreateCategory(CategoryModel category);
        public void UpdateCategory(int id, CategoryModel category);
        public void DeleteCategory(int id);
        public bool CategoryExist(int id);
        public bool CategoryExistByName(string name);
    }
}
