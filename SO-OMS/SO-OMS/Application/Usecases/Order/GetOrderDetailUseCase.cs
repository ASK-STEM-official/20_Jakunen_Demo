using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Utils;
using SO_OMS.Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SO_OMS.Application.Usecases.Order
{
    public class GetOrderDetailUseCase
    {
        private readonly IOrderReservationRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IOrderStatusHistoryRepository _statusHistoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryResolver _categoryResolver;

        public GetOrderDetailUseCase(
            IOrderReservationRepository orderRepo,
            ICustomerRepository customerRepo,
            IOrderStatusHistoryRepository statusHistoryRepo,
            IProductRepository productRepo,
            ICategoryResolver categoryResolver)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _statusHistoryRepo = statusHistoryRepo;
            _productRepo = productRepo;
            _categoryResolver = categoryResolver;
        }

        public OrderDetailViewModel Execute(string reservationId)
        {
            var order = _orderRepo.FindById(reservationId);
            if (order == null) return null;

            var customer = _customerRepo.FindById(order.CustomerID);
            if (customer == null) return null;

            var latestHistory = _statusHistoryRepo.FindLatestByReservationId(reservationId);

            var itemViewModels = new List<OrderItemViewModel>();
            foreach (var item in order.Items)
            {
                var product = _productRepo.GetById(item.ProductID);
                var taxRate = _categoryResolver.ResolveTaxRate(product.CategoryID);

                itemViewModels.Add(new OrderItemViewModel
                {
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    TaxRate = taxRate,
                    Subtotal = item.Subtotal
                });
            }

            var viewModel = new OrderDetailViewModel
            {
                ReservationID = order.ReservationID,
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                ShippingAddress = order.ShippingAddress,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                ChangeDateTime = latestHistory?.ChangeDateTime,
                ReservationDate = order.ReservationDateTime,
                ImportedDateTime = order.ImportedDateTime,
                TotalAmount = order.TotalAmount,
                Items = itemViewModels
            };

            return viewModel;
        }
    }
}

