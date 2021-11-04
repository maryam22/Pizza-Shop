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

        SqlConnection con = new SqlConnection(@"Data Source=LENOVO\MARYAM;Initial Catalog=project;Integrated Security= True;");

        public Form1()
        {
            InitializeComponent();
        }

        //make an order
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Order Pizza

            var klant = new Klant(textBox1.Text);
            var extras = new List<ExtraType>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                extras.Add((ExtraType)item);
            }

            var drank = new Frisdrank((DrankType)comboBox6.SelectedIndex, Convert.ToInt32(numericUpDown4.Value));
            var pizza = new Pizza(comboBox1.Text, decimal.Parse(comboBox2.Text));
            MaatType maat;
            if (radioButton1.Checked)
            {
                maat = MaatType.Klein;
            }
            else
            {

                maat = MaatType.Groote;
            }
            //var pasta = new Pasta();
            var bestelGerecht = new BestelGerecht(pizza, maat, extras);
            var dessert = new Dessert((DessertType)comboBox3.SelectedIndex, Convert.ToInt32(numericUpDown4.Value));
            Bestelling bestelling = new Bestelling(klant, bestelGerecht, drank, dessert, Convert.ToInt32(numericUpDown2.Value));
            MessageBox.Show(bestelling.ToString());
            listBox1.Items.Add(bestelling);

            //Database

            con.Open();

            var cmd = new SqlCommand("insert into Pizza values('" + comboBox1.Text + "', '" + comboBox2.Text + "')", con);
            var cm = new SqlCommand("insert into Klant values('" + textBox1.Text + "')", con);
            var vm = new SqlCommand("insert into Dessert values('" + comboBox3.SelectedIndex + "','"+ numericUpDown2.Value + "')", con);
            var nm = new SqlCommand("insert into Drank values('" + comboBox6.SelectedIndex + "','" + numericUpDown4.Value + "')", con);
            var result = cmd.ExecuteNonQuery();
            var res = cm.ExecuteNonQuery();
            var resu = vm.ExecuteNonQuery();
            var resul = nm.ExecuteNonQuery();

            con.Close();

            //make form empty

            empty();

        }

        public void empty()
        {
            textBox1.Text ="";
            checkedListBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            radioButton1.Checked = false;
            numericUpDown2.Value = 0;
            numericUpDown4.Value = 0;

        }

        

      
    }
}
