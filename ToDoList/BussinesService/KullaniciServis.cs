using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.database;
using ToDoList.entities;

namespace ToDoList.BussinesService
{
    public class KullaniciServis
    {
        public Kullanici kontrol(string kullaniciadi, string sifre)
        {
            return SanalDatabase.kullaniciTablo.Where(i=>i.KullaniciAdi == kullaniciadi && i.Sifre == sifre).FirstOrDefault();//ya ilgili nesneyi bul dön ya da defaultu olan nesnenin default halini dön
        }
    }
}
