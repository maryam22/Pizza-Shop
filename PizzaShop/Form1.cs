using Pizza_Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PizzaShop
{
    public partial class Form1 : Form
    {
        //Total price

        Store myStore = new Store();
        decimal runningTotal = 0;




        //sql connection
        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\MARYAM;Initial Catalog=project;Integrated Security= True;");

        public Form1()
        {
            InitializeComponent();
        }

        //make an order
        private void button1_Click_1(object sender, EventArgs e)
        {
            var isValid = ValidateControls();

            if (!isValid)
            {
                return;
            }
            var klant = new Klant(textBox1.Text);
            var extras = new List<ExtraType>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                extras.Add((ExtraType)item);
            }

            var drank = new Frisdrank((DrankType)comboBox6.SelectedIndex, Convert.ToInt32(numericUpDown4.Value));

            Gerecht gerecht;

            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                gerecht = new Pizza(comboBox1.Text, decimal.Parse(comboBox2.Text));
            }
            else if (!string.IsNullOrEmpty(comboBox4.Text) && !string.IsNullOrEmpty(comboBox5.Text))
            {
                gerecht = new Pasta(comboBox1.Text, decimal.Parse(comboBox5.Text), "Description");
            }
            else
            {
                gerecht = null;
            }

            MaatType maat;
            if (radioButton1.Checked)
            {
                maat = MaatType.Klein;
            }
            else
            {
                maat = MaatType.Groote;
            }

            BestelGerecht bestelGerecht = new BestelGerecht(gerecht, maat, extras);
            var dessert = new Dessert((DessertType)comboBox3.SelectedIndex,
                Convert.ToInt32(numericUpDown4.Value));
            Bestelling bestelling = new Bestelling(
                klant, bestelGerecht, drank, dessert,
                Convert.ToInt32(numericUpDown2.Value)
                );
            MessageBox.Show(bestelling.ToString());
            listBox1.Items.Add(bestelling);
            //Total Price 
            myStore.BestelingList.Add(bestelling);
          

            //Database

            con.Open();

            var cmd = new SqlCommand("insert into Pizza values('" + comboBox1.Text + "', '" + comboBox2.Text + "')", con);
            var cm = new SqlCommand("insert into Klant values('" + textBox1.Text + "')", con);
            var vm = new SqlCommand("insert into Dessert values('" + comboBox3.SelectedIndex + "','" + numericUpDown2.Value + "')", con);
            var nm = new SqlCommand("insert into Drank values('" + comboBox6.SelectedIndex + "','" + numericUpDown4.Value + "')", con);
            cmd.ExecuteNonQuery();
            cm.ExecuteNonQuery();
            vm.ExecuteNonQuery();
            nm.ExecuteNonQuery();

            con.Close();

            //make form empty

            Empty();


            //make total price

         
            runningTotal += myStore.Checkout();
            textBox2.Text ="€" + runningTotal.ToString();



        }

        private bool ValidateControls()
        {
            var errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorMessage.AppendLine("* Please enter klant name.");
            }

            if (string.IsNullOrEmpty(comboBox1.Text) )
            {
                errorMessage.AppendLine("* Please select a pizza.");
            }

            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                errorMessage.AppendLine("* Please enter a price.");
            }

            if (numericUpDown2.Value == 0)
            {
                errorMessage.AppendLine("* Please select a quantity.");
            }

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString());
                return false;
            }
            return true;
        }

        public void Empty()
        {
            textBox1.Text = "";
            checkedListBox1.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            radioButton1.Checked = false;
            numericUpDown2.Value = 0;
            numericUpDown4.Value = 0;

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
