using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Payment>> LoadAllPaymentProperties()
        {
            return await DataContext.Payments.Include(x => x.PaymentState).ToListAsync();
        }
    }
}