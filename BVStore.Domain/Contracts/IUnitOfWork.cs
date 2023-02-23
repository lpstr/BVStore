using BVStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVStore.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<Customer> CustomerRepository { get; }
        IGenericRepository<OrderProduct> OrderProductRepository { get; }
        void Save();
    }
}
