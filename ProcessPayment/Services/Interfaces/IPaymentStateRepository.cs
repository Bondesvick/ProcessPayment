﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessPayment.Models;

namespace ProcessPayment.Services.Interfaces
{
    internal interface IPaymentStateRepository : IRepository<PaymentState>
    {
    }
}