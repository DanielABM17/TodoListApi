using Microsoft.EntityFrameworkCore;
using Models;


namespace DAL.Context
{
   public  class ToDoContext : DbContext
    {


    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }

      

    }

  

}
