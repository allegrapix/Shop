﻿using System;

namespace Shop.WithRepository.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }

        public OrderState State { get; set; }

        public Payment Payment { get; set; }
    }
}