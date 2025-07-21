using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SO_OMS.Application.Usecases
{
    public class ListOrdersUseCase
    {
        private readonly IOrderReservationRepository _orderReservationRepository;

        public ListOrdersUseCase(IOrderReservationRepository orderReservationRepository)
        {
            _orderReservationRepository = orderReservationRepository;
        }

        public List<OrderReservation> Execute(
            string reservationId = null,
            string customerName = null,
            string productName = null,
            string status = null,
            int? categoryId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null
        )
        {
            return _orderReservationRepository.Search(
                reservationId,
                customerName,
                productName,
                status,
                categoryId,
                fromDate,
                toDate
            );
        }
    }
}
