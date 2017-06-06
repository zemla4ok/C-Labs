using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_1
{
    class SQLCustomerRepository : IRepository<Customer>
    {
        private CustomerContext db;
        public SQLCustomerRepository()
        {
            this.db = new CustomerContext();
        }
        public IEnumerable<Customer> GetList()
        {
            return db.Customers;
        }
        public Customer GetItem(int id)
        {
            return db.Customers.Find(id);
        }
        public void Create(Customer item)
        {
            db.Customers.Add(item);
        }
        public void Update(Customer item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    db.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
