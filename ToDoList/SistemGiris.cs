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
    public partial class SistemGiris : Form
    {
        public SistemGiris()
        {
            InitializeComponent();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.Yellow;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.White;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) || !string.IsNullOrEmpty(txtPassword.Text))
            {
                KullaniciServis kullaniciServis = new KullaniciServis();
                Kullanici kullaniciKontrol = kullaniciServis.kontrol(txtUsername.Text, txtPassword.Text);
                if (kullaniciKontrol != null)
                {
                    Form anaform = Application.OpenForms["Form1"];
                    Panel solPanel = (Panel)anaform.Controls["pnlIslemListesi"];
                    GroupBox gbIslemListe = (GroupBox)solPanel.Controls["grpBoxIslemListe"];
                    foreach (Control item in gbIslemListe.Controls)
                    {
                        if(item is Button)
                            item.Enabled = true;
                    }
                    MessageBox.Show($"Merhaba {kullaniciKontrol.KullaniciAdi}","Bilgilendirme",MessageBoxButtons.OK);
                    this.Close();
                }
                else
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre", "Hata");
            }
            else
                MessageBox.Show("Lütfen giriş bilgilerinizi eksiksiz olarak giriniz", "Bilgilendirme");
        }
    }
}
