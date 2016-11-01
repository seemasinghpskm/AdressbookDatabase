using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressbookDatabase
{
    class AddressContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
    }
}
