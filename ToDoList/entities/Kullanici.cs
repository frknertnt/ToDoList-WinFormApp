using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.entities
{
    public class Kullanici
    {
        public Guid id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        
    }
}
