using System;

using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;

namespace DristorApp.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepository<Order, int>
    {

    }

}