using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
            DataSet ds = new DataSet();
            DBAccs db = new DBAccs();
            db.OpenConnection();
            label13.Text = "Dobrodosli " + db.KorisnikTEMP + ", vas nivo privilegija je " + Convert.ToString(db.Privilegije());
            db.Adapter().Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            db.CloseConnection();


            

            comboBox1.Items.Add("sifra");
            comboBox1.Items.Add("Marka");
            comboBox1.Items.Add("Model");
            comboBox1.Items.Add("Kvar");
            comboBox1.Items.Add("ImePrezime");
            comboBox1.Items.Add("BrojTelefona");
            comboBox1.Items.Add("IMEI");
            comboBox1.Items.Add("Serviser");
            comboBox1.Items.Add("Cena");
            comboBox1.Items.Add("Korisnik");
            comboBox1.Items.Add("Datum");

            comboBox2.Items.Add("Marka");
            comboBox2.Items.Add("Model");
            comboBox2.Items.Add("Kvar");
            comboBox2.Items.Add("ImePrezime");
            comboBox2.Items.Add("BrojTelefona");
            comboBox2.Items.Add("IMEI");
            comboBox2.Items.Add("Serviser");
            comboBox2.Items.Add("Cena");
            comboBox2.Items.Add("Korisnik");

            comboBox3.Items.Add("sifra");
            comboBox3.Items.Add("Marka");
            comboBox3.Items.Add("Model");
            comboBox3.Items.Add("Kvar");
            comboBox3.Items.Add("ImePrezime");
            comboBox3.Items.Add("BrojTelefona");
            comboBox3.Items.Add("IMEI");
            comboBox3.Items.Add("Serviser");
            comboBox3.Items.Add("Cena");
            comboBox3.Items.Add("Korisnik");
            comboBox3.Items.Add("Datum");


            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBAccs db = new DBAccs();
            db.OpenConnection();
            
            DataSet ds = new DataSet();
            db.Search(comboBox1.SelectedItem.ToString(), textBox1.Text).Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DBAccs db = new DBAccs();
            
            db.OpenConnection();
            db.Insert(textBox2.Text, textBox5.Text, textBox3.Text, textBox4.Text, textBox7.Text, textBox6.Text, textBox9.Text, textBox8.Text);
            
            MessageBox.Show("Uspesno je uneto!");

            DataSet ds = new DataSet();
           
           
            db.Adapter().Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            db.CloseConnection();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            DBAccs db = new DBAccs();
            db.OpenConnection();
            if (db.Privilegije() == 1)
            {
                db.Update(comboBox2.SelectedItem.ToString(), textBox10.Text, comboBox3.SelectedItem.ToString(), textBox11.Text);

                MessageBox.Show("Uspesno je promenjeno!");

                DataSet ds = new DataSet();


                db.Adapter().Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Nemate dozvolu da menjate podatke!");
            }

            db.CloseConnection();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBAccs db = new DBAccs();
            db.OpenConnection();
            if (db.Privilegije() == 1)
            {
                if (String.IsNullOrEmpty(Convert.ToString(textBox12.Text)))
                {
                    MessageBox.Show("Greska, unos je prazan!");
                }
                else
                {
                    db.Delete(Convert.ToInt32(textBox12.Text));

                    MessageBox.Show("Uspesno je obrisano!");

                    DataSet ds = new DataSet();


                    db.Adapter().Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Nemate dozvolu da menjate podatke!");
            }

            db.CloseConnection();

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBAccs db = new DBAccs();
            db.OpenConnection();
            if (db.Privilegije() == 1)
            {
                this.Hide();
                Users f = new Users();
                f.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                f.Show();
            }


        }
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
