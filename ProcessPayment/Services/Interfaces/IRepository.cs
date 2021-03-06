﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPayment.Services.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FindAll();

        Task<T> Find(int? id);

        Task Update(T t);

        Task Save(T t);

        Task Delete(int? id);

        Task<bool> Exist(int? id);

        Task<int> Count();

        Task AddRange(T[] t);
    }
}