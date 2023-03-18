using BookWeb.Models;

namespace BookWeb.Repositories.Abstract
{
    public interface ICategoryService
    {
        bool Add(Category model);
        bool Update(Category model);
        bool Delete(int Id);
        Category FindById(int Id);

        IEnumerable<Category> GetAll();
    }
}
