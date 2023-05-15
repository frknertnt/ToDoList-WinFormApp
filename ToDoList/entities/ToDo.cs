using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.entities
{
    public class ToDo
    {
        [DisplayName("ID")]
        public Guid Id { get; set; }
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Kısa Açıklama")]
        public string kisaAciklama { get; set; }
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Önem Derecesi")]
        public int onemDerece { get; set; }
        [DisplayName("Durum")]
        public string durumAciklama { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime olusturmaTarih { get; set; }
    }
}
