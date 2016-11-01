using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressbookDatabase
{
    public partial class frmAdressBook : Form
    {
        public frmAdressBook()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPostOrt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new AddressContext())
            {
                var adress = new Address
                {
                    ForstaNamn = txtForstaNamn.Text,
                    EfterNamn = txtEfterNamn.Text,
                    Gatudress = txtGatudress.Text,
                    PostNummer = txtPostNummer.Text,
                    Postort = txtPostOrt.Text,
                    Telefon = txtTelefon.Text,
                    Epost = txtEpost.Text,
                    Fodelsedag = DateTime.Parse(dateFodelsedag.Text)
                };

                db.Addresses.Add(adress);
                db.SaveChanges();
                MessageBox.Show("Information Saved");
                txtID.Clear();
                txtForstaNamn.Clear();
                txtEfterNamn.Clear();
                txtGatudress.Clear();
                txtPostNummer.Clear();
                txtPostOrt.Clear();
                txtTelefon.Clear();
                txtEpost.Clear();
                dateFodelsedag.ResetText();


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var db = new AddressContext())
            {
                string strSelected = listBox1.SelectedItem.ToString();
                int intID = int.Parse(strSelected.Split('.')[0]);
                var adress = db.Addresses.SingleOrDefault(data => data.AddressId.Equals(intID));
                if (adress != null)
                {

                    //adress.AddressId = intID;
                    adress.ForstaNamn = txtForstaNamn.Text;
                    adress.EfterNamn = txtEfterNamn.Text;
                    adress.Gatudress = txtGatudress.Text;
                    adress.PostNummer = txtPostNummer.Text;
                    adress.Postort = txtPostOrt.Text;
                    adress.Telefon = txtTelefon.Text;
                    adress.Epost = txtEpost.Text;
                    adress.Fodelsedag = DateTime.Parse(dateFodelsedag.Text);
                    db.SaveChanges();
                
                }
                
                   
                
                //db.SaveChanges();
                MessageBox.Show("Information Updated");

                txtID.Clear();
                txtForstaNamn.Clear();
                txtEfterNamn.Clear();
                txtGatudress.Clear();
                txtPostNummer.Clear();
                txtPostOrt.Clear();
                txtTelefon.Clear();
                txtEpost.Clear();
                dateFodelsedag.ResetText();
                txtID.Enabled = false;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            using (var db = new AddressContext())
            {
                var adres = (from d1 in db.Addresses
                            where d1.AddressId == id
                            select d1).First();

                db.Addresses.Remove(adres);
                db.SaveChanges();
                MessageBox.Show("Information Deleted");


                txtID.Clear();
                txtForstaNamn.Clear();
                txtEfterNamn.Clear();
                txtGatudress.Clear();
                txtPostNummer.Clear();
                txtPostOrt.Clear();
                txtTelefon.Clear();
                txtEpost.Clear();
                dateFodelsedag.ResetText();
                txtID.Enabled = false;
            }
            }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var db = new AddressContext())
            {
                var names = from name in db.Addresses
                            where name.ForstaNamn.Contains(txtSearch.Text)
                            select name;

                foreach (var item in names)
                {
                    listBox1.Items.Add(string.Format("{0}.{1} {2}", item.AddressId, item.ForstaNamn, item.EfterNamn));
                }
                
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            string strSelected = listBox1.SelectedItem.ToString();
            int intID = int.Parse(strSelected.Split('.')[0]);
            using (var db =new AddressContext())
            {
                var adress =(from adress1 in db.Addresses
                            where adress1.AddressId==intID
                    select adress1).First();
                txtID.Text = adress.AddressId.ToString();
                txtForstaNamn.Text =adress.ForstaNamn ;
                txtEfterNamn.Text = adress.EfterNamn;
                txtGatudress.Text = adress.Gatudress;
                txtPostNummer.Text = adress.PostNummer;
                txtPostOrt.Text = adress.Postort;
                txtTelefon.Text = adress.Telefon;
                txtEpost.Text = adress.Epost;
                dateFodelsedag.Value = adress.Fodelsedag;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;
        }
    }
    }

