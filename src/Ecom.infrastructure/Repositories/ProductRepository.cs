﻿using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDBContext context):base(context) 
        { 
        }

        public Task<bool> AddAsync()
        {
            throw new NotImplementedException();
        }
    }
}
