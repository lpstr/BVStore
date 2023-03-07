using BVStore.Domain.Models;

namespace BVStore.API.Services
{
    public static class ValidationService
    {
        public static bool IsOrderValid(OrderDTO order)
        {
            bool result = false;

            //Must include customer id, at least 1 product , orderID
            if (order.CustomerId <= 0 || order.OrderId <= 0 || order.Products.Count <= 0 || order.TotalPrice <= 0)
            {
                return result;
            }

            result = true;

            return result;
        }
    }
}
