﻿namespace Shop.WithRepository.Domain
{
    public class ProductWithReservations : Product
    {
        public int ReservationCount { get; set; }
    }
}