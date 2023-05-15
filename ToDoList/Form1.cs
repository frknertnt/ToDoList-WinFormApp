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

namespace ToDoList
{
    public partial class Form1 : Form
    {
        Form t;
        public Form1()
        {
            InitializeComponent();
        }
        private void ButonAcKapa(bool kontrol)
        {
            foreach (Control item in grpBoxIslemListe.Controls)
            {
                if (item is Button)
                {
                    ((Button)item).Enabled = false;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tm_zamanla.Interval = 15000;
            tm_zamanla.Tick += Tm_zamanla_Tick;
            tm_zamanla.Start();

            ButonAcKapa(false);

            SistemGiris kontrol = new SistemGiris();
            kontrol.MdiParent = this;
            kontrol.StartPosition = FormStartPosition.CenterScreen; 
            kontrol.Show(); 
        }

        private void Tm_zamanla_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();//ne varsa bellekten düşer
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["YeniKayit"] != null)
            {
                t = Application.OpenForms["YeniKayit"];
                t.Focus();
            }
            else
            {
                t = new YeniKayit();
                t.MdiParent = this;
                t.Show();
            }
        }

        private void btnKayitListe_Click(object sender, EventArgs e)
        {
            ToDoServis toDoServis = new ToDoServis();
            if (toDoServis.KayıtKontrol() > 0)
            {
                KayıtListe kayit = new KayıtListe   ();
                kayit.MdiParent = this;
                kayit.Show();
            }
            else
                MessageBox.Show("Listelenecek kayıt bulunamadı", "Bilgilendirme");
        }
    }
}
