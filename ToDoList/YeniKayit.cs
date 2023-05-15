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
    public partial class YeniKayit : Form
    {
        public YeniKayit()
        {
            InitializeComponent();
        }

        private void btnKayit_Enter(object sender, EventArgs e)
        {

        }

        private void btnKayit_Leave(object sender, EventArgs e)
        {

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            ToDoServis toDoServis = new ToDoServis();
            int sonuc = toDoServis.kayıtYeni(new entities.ToDo()
            {
                Id = Guid.NewGuid(),
                Baslik = txtBaslik.Text,
                kisaAciklama = txtKisa.Text,
                durumAciklama = cmbDurum.SelectedItem.ToString(),
                onemDerece = int.Parse(txtDerece.Text),
                olusturmaTarih = DateTime.Now,
            });
            if (sonuc > 0)
            {

                MessageBox.Show("Kayıt ekleme işlemi başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Yeni kayıt ekleme işlemine devam etmek ister misiniz", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Form kayitListe = Application.OpenForms["KayıtListe"];
                    if (kayitListe == null)
                    {
                        kayitListe = new KayıtListe();
                        kayitListe.MdiParent = Application.OpenForms["Form1"];
                        kayitListe.StartPosition = FormStartPosition.CenterScreen;
                        kayitListe.Show();
                        this.Close();
                    }
                    else
                    {
                        GroupBox liste = (GroupBox)kayitListe.Controls["grpBoxListe"];
                        DataGridView  grdliste = (DataGridView)liste.Controls["dataGridView1"];
                        List<ToDo> guncelliste = toDoServis.kayıtListe();
                        grdliste.DataSource = null;
                        grdliste.DataSource = guncelliste;
                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Kayıt ekleme işleminde hata", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
