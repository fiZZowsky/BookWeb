using BookWeb.Data;
using BookWeb.Models;
using BookWeb.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookWeb.Repositories.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly AplicationDbContext context;

        public CategoryService(AplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Category model)
        {
            try
            {
                context.categories.Add(model);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var data = this.FindById(Id);
                if(data == null)
                    return false;

                context.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Category FindById(int Id)
        {
            return context.categories.Find(Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return context.categories.ToList();
        }

        public bool Update(Category model)
        {
            try
            {
                context.categories.Update(model);
                context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
