using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressbookDatabase
{
    public class Address
    {
        public int AddressId { get; set; }
        public string ForstaNamn { get; set; }
        public string EfterNamn { get; set; }
        public string Gatudress { get; set; }
        public string PostNummer { get; set; }
        public string Postort { get; set; }
        public string Telefon { get; set; }
        public string Epost { get; set; }
        public DateTime Fodelsedag { get; set; }


            
    }
}
