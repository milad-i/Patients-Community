using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface ICategory
    {
        Task<CategoryModel> GetCategory(int id);
        Task<List<CategoryModel>> GetCategories();
        void CreateCategory(CategoryModel category);
        void UpdateCategory(int id, CategoryModel category);
        void DeleteCategory(int id);
        bool CategoryExist(int id);
        bool CategoryExistByName(string name);
    }
}
