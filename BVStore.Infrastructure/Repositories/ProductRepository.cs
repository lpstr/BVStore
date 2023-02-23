//using BVStore.Domain.Contracts;
//using BVStore.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace BVStore.Infrastructure.Repositories
//{
//    public class ProductRepository : GenericRepository<Product>, IProductRepository
//    {
//        private readonly BVStoreDbContext _dbContext;
//        public ProductRepository(BVStoreDbContext dbContext) : base(dbContext)
//        {
//            _dbContext = dbContext;
//        }


//        public void Delete(Product entityToDelete)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(object id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, string includeProperties = "")
//        {
//            var items = _dbContext.Products.ToList();
//            return items;
//        }

//        public Product GetByID(object id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(Product entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Product entityToUpdate)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
