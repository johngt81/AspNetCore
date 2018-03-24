using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekocakeApp.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IEnumerable<Category> Categories => _appDBContext.Categories;

    }
}
