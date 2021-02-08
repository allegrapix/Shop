﻿using MediatR;

namespace Shop.WithRepository.Application.CompletePayment
{
    public class CompletePaymentRequest : IRequest
    {
        public int SaleId { get; set; }
    }
}