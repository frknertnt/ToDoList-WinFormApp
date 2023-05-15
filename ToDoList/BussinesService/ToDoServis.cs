using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.database;
using ToDoList.entities;

namespace ToDoList.BussinesService
{
    public class ToDoServis
    {
        public int KayıtKontrol()
        {
            return SanalDatabase.todoTablo.Count;
        }
        public List<ToDo> kayıtListe()
        {
            return SanalDatabase.todoTablo;
        }
        public int kayıtYeni(ToDo data )
        {
            try
            {
                SanalDatabase.todoTablo.Add(data);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
