using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<Category> GetAsync(int id)
        //{
        //    var res =await _dbContext.Categories.FindAsync(id);

        //    return res;

        //}
    }
}
