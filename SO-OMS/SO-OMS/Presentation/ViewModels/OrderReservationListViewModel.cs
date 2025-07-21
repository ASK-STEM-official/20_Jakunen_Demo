using SO_OMS.Application.Usecases.Order;
using SO_OMS.Domain.Entities;
using SO_OMS.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SO_OMS.Presentation.ViewModels
{
    public class OrderReservationListViewModel
    {
        private readonly ListOrdersUseCase _useCase;

        public List<OrderListViewModel> Orders { get; private set; } = new List<OrderListViewModel>();
        public int ResultCount => Orders.Count;

        // 検索条件
        public string SearchReservationID { get; set; }
        public string SearchCustomerName { get; set; }
        public string SearchProductName { get; set; }
        public int? SearchCategoryID { get; set; }
        public string SearchStatus { get; set; }
        public DateTime? SearchFromDate { get; set; }
        public DateTime? SearchToDate { get; set; }

        public IEnumerable<KeyValuePair<int, string>> CategoryOptions => CategoryResolver.GetAll();
        public IEnumerable<string> StatusOptions => OrderStatusResolver.GetAll();

        public OrderReservationListViewModel(ListOrdersUseCase useCase)
        {
            _useCase = useCase;
        }

        public void LoadOrders()
        {
            var entities = _useCase.Execute(
                reservationId: string.IsNullOrWhiteSpace(SearchReservationID) ? null : SearchReservationID,
                customerName: string.IsNullOrWhiteSpace(SearchCustomerName) ? null : SearchCustomerName,
                productName: string.IsNullOrWhiteSpace(SearchProductName) ? null : SearchProductName,
                status: string.IsNullOrWhiteSpace(SearchStatus) ? null : SearchStatus,
                categoryId: SearchCategoryID == 0 ? null : SearchCategoryID,
                fromDate: SearchFromDate,
                toDate: SearchToDate
            );

            Orders = entities.Select(o => new OrderListViewModel
            {
                ReservationID = o.ReservationID,
                CustomerName = o.CustomerName,
                ProductName = o.GetProductName(),
                TotalQuantity = o.GetTotalQuantity(),
                ReservationDateTime = o.ReservationDateTime,
                OrderStatus = o.Status
            }).ToList();
        }
    }
}
