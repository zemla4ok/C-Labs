using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_1
{
    class CQLOrderRepository : IRepository<Order>
    {
        private CustomerContext db;
        public CQLOrderRepository()
        {
            this.db=new CustomerContext();
        }
        public IEnumerable<Order> GetList()
        {
            return db.Orders;
        }
        public Order GetItem(int id)
        {
            return this.db.Orders.Find(id);
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }
        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
