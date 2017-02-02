using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Infrastructure.Data
{
   public class OrderContext:DbContext
    {
       public DbSet<Book> Books { get; set; }
    }
}
