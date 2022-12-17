using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Services
{
    public class CategoryServices : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context= context;
        }

        public bool CategoryExist(int id)
        {
            return ( _context.tbl_Category?.Any(c => c.Id == id)).GetValueOrDefault();
        }
        public bool CategoryExistByName(string name)
        {
            return (_context.tbl_Category?.Any(c => c.Name == name)).GetValueOrDefault();
        }
        public void CreateCategory(CategoryModel category)
        {
            _context.tbl_Category.Add(category);
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = _context.tbl_Category.Find(id);
            if (category != null)
            {
                _context.tbl_Category.Remove(category);
                _context.SaveChanges();
            }
        }
        public async Task<List<CategoryModel>> GetCategories()
        {
            return await _context.tbl_Category.ToListAsync();
        }
        public async Task<CategoryModel> GetCategory(int id)
        {
            return await _context.tbl_Category.FindAsync(id);
        }
        public void UpdateCategory(int id, CategoryModel category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
