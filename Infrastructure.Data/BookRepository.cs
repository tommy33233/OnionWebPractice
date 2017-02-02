using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Interfaces;

namespace Infrastructure.Data
{
   public class BookRepository:IBookRepository
   {
       private OrderContext db;

       public BookRepository()
       {
            this.db=new OrderContext();
       }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public Book GetBook(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetBookList()
        {
            return db.Books;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Book item)
        {
            db.Entry(item).State=EntityState.Modified;
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
