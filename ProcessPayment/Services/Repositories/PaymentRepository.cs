using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessPayment.Data;
using ProcessPayment.Models;
using ProcessPayment.Services.Interfaces;

namespace ProcessPayment.Services.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}