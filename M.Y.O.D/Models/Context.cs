using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace M.Y.O.D.Models
{
    public class Context : DbContext
    {

        public Context()
            : base("name=Context")
        {
        }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<logIn>LogIns { get; set; }
        public virtual DbSet<menu_item> Menu_items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }


} 