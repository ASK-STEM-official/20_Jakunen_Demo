using SO_OMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SO_OMS.Application.Interfaces
{
    public interface IOrderReservationRepository
    {
        List<OrderReservation> GetAll();

        List<OrderReservation> Search(
            string reservationId = null,
            string customerName = null,
            string productName = null,
            string status = null,
            int? categoryId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null
        );

        OrderReservation FindById(string reservationId);
    }
}
