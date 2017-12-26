using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            DBAccs db = new DBAccs();
            db.OpenConnection();
            label1.Text = "Dobrodosli " + db.KorisnikTEMP + ", vas nivo privilegija je " + Convert.ToString(db.Privilegije());
            db.AdapterKorisnik().Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            db.CloseConnection();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            DBAccs db = new DBAccs();

            db.OpenConnection();
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Sva polja moraju biti popunjena");
            }
            else if(db.Provera(textBox1.Text) > 0)
            {
                MessageBox.Show("Username je zauzet");
            }
            else
            {


                db.InsertKorisnik(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);

                MessageBox.Show("Uspesno je uneto!");

                DataSet ds = new DataSet();


                db.AdapterKorisnik().Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            db.CloseConnection();
        }

        
    }
}
