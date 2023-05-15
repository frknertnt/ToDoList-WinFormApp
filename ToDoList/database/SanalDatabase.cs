using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.entities;

namespace ToDoList.database
{
    public static class SanalDatabase
    {
        public static List<Kullanici> kullaniciTablo;
        public static List<ToDo> todoTablo;

        static SanalDatabase()
        {
            kullaniciTablo = new List<Kullanici>();
            kullaniciTablo.Add(new Kullanici() { id = Guid.NewGuid(), KullaniciAdi = "test1", Sifre = "1" });
            todoTablo = new List<ToDo>();   

        }
    }
}
