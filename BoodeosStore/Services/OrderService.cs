using AutoMapper;
using BVStore.Domain.Contracts;
using BVStore.Domain.Entities;
using BVStore.Domain.Enums;
using BVStore.Domain.Models;
using BVStore.Infrastructure;

namespace BVStore.API.Services
{
    //Class to hold methods for order interactions 
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for making an order
        /// </summary>
        /// <returns></returns>
        public ShippingSlip ProcessOrder(OrderDTO orderDTO)
        {
            ShippingSlip result = new ShippingSlip();
            //Validate order
            if (ValidationService.IsOrderValid(orderDTO))
            {
                //Get Customer
                Customer? customerEntity = _unitOfWork.CustomerRepository.GetByID(orderDTO.CustomerId);

                if (customerEntity != null)
                {
                    //Check if order contains membership
                    ApplyMembership(orderDTO, customerEntity);

                    //Process order to DB and generate shipping slip if necessary
                    result = ProcessOrder(orderDTO, customerEntity);
                }
                else
                {
                    //ToDo return error?
                }
            }

            return result;
        }

        public Order MapOrderEntity(Customer customerEntity, OrderDTO orderDTO)
        {
            Order order = new Order();

            order = _mapper.Map<Order>(orderDTO);

            order.Customer = customerEntity;

            return order;
        }

        public List<OrderProduct> GetOrderProductEntities(OrderDTO orderDTO, Order orderEntity)
        {
            List<OrderProduct> orderProductEntities = new List<OrderProduct>();

            foreach (var product in orderDTO.Products)
            {
                Product productEntity = _unitOfWork.ProductRepository.GetByID(product.ProductId);

                OrderProduct op = new OrderProduct();

                op.Product = productEntity;
                op.UnitPrice = product.PricePerUnit;
                op.Quantity = product.Quantity;
                op.Order = orderEntity;

                orderProductEntities.Add(op);
            }

            return orderProductEntities;
        }

        private void SaveOrder(Order orderEntity, List<OrderProduct> orderProductEntities)
        {
            try
            {
                _unitOfWork.OrderRepository.Insert(orderEntity);
                orderProductEntities.ForEach(o => _unitOfWork.OrderProductRepository.Insert(o));
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ShippingSlip GenerateShippingSlip(int orderId, string customerName, string address, List<ProductDTO> items)
        {
            ShippingSlip shippingSlip = new ShippingSlip();

            shippingSlip.OrderId = orderId;
            shippingSlip.CustomerName = customerName;
            shippingSlip.Address = address;
            shippingSlip.Products = items;

            return shippingSlip;
        }

        public ShippingSlip ProcessOrder(OrderDTO orderDTO, Customer customerEntity)
        {
            ShippingSlip shippingSlip = new ShippingSlip();
            //Map order entity
            Order orderEntity = MapOrderEntity(customerEntity, orderDTO);

            //Map products in order
            List<OrderProduct> orderProductEntities = GetOrderProductEntities(orderDTO, orderEntity);

            //Save order
            SaveOrder(orderEntity, orderProductEntities);

            //Extract physical products
            List<OrderProduct> productsToShip = orderProductEntities.Where(p => p.Product.ProductType == ProductType.Physical).ToList();

            //Generate shipping slip if any physical products
            if(productsToShip.Any())
            {
                List<ProductDTO> itemsForShipping = _mapper.Map<List<ProductDTO>>(productsToShip);
                shippingSlip = GenerateShippingSlip(orderEntity.OrderId, customerEntity.Name, customerEntity.Address, itemsForShipping);
            }
            
            return shippingSlip;
        }

        /// <summary>
        /// Apply membership to customer if purchased
        /// </summary>
        public void ApplyMembership(OrderDTO order, Customer customerEntity)
        {
            ProductType? membershipType = order.Products.FirstOrDefault(p =>
                                                p.ProductType == ProductType.PremiumMembership
                                                || p.ProductType == ProductType.BookMembership
                                                || p.ProductType == ProductType.VideoMembership)?.ProductType;

            //If there is membership - activate it in customer profile

            if (membershipType != null && membershipType.HasValue)
            {
                customerEntity.MembershipType = membershipType.Value.ToMembership();
                //ToDo decide if we save here or after all the details are saved into DB
                //_unitOfWork.Save();
            }
        }

        public List<OrderDTO> GetOrders(int customerId)
        {
            List<OrderDTO> result = new List<OrderDTO>();
            var orders = _unitOfWork.OrderRepository.Get(p=>p.Customer.Id.Equals(customerId));

            result = _mapper.Map<List<OrderDTO>>(orders);

            return result;
        }
    }
}
