using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BussinesService;
using ToDoList.entities;

namespace ToDoList
{
    public partial class KayıtListe : Form
    {
        ToDoServis toDoServis = new ToDoServis();
        public KayıtListe()
        {
            InitializeComponent();
            toDoServis = new ToDoServis();
        }

        private void KayıtListe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TumListe();
            dataGridView1.Columns["ID"].Visible = false;
        }
        private List<ToDo> TumListe()
        {
            return toDoServis.kayıtListe();
        }

        private void btnTumListe_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TumListe();
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void btnTamamlandi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TumListe().Where(i=>i.durumAciklama == "Tamamlandı").ToList();
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void btnTamamlanamadi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TumListe().Where(i => i.durumAciklama == "Tamamlanamadı").ToList();
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TumListe().Where(i => i.durumAciklama == "İptal Edildi").ToList();
            dataGridView1.Columns["ID"].Visible = false;
        }
    }
}
