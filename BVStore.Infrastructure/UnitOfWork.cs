using BVStore.Domain.Contracts;
using BVStore.Domain.Entities;
using BVStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BVStoreDbContext context;

        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<OrderProduct> orderProductRepository;


        public UnitOfWork(BVStoreDbContext dicontext)
        {
            this.context = dicontext;
        }

        public IGenericRepository<OrderProduct> OrderProductRepository
        {
            get
            {

                if (this.orderProductRepository == null)
                {
                    this.orderProductRepository = new GenericRepository<OrderProduct>(context);
                }
                return orderProductRepository;
            }
        }
        public IGenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public IGenericRepository<Order> OrderRepository
        {
            get
            {

                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
