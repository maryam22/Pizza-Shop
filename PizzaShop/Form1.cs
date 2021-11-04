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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            var klant = new Klant(textBox1.Text);
            var extras = new List<ExtraType>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                extras.Add((ExtraType)item);
            }
            
            var drank = new Frisdrank((DrankType)comboBox6.SelectedIndex, Convert.ToInt32(numericUpDown4.Value));
            var pizza = new Pizza(comboBox1.Text, decimal.Parse(comboBox2.Text));
            MaatType maat;
            if(radioButton1.Checked)
            {
                maat = MaatType.Klein;
            }
            else
            {

                maat = MaatType.Groote;
            }
            //var pasta = new Pasta();
            var bestelGerecht = new BestelGerecht(pizza,maat, extras);
            var dessert = new Dessert((DessertType)comboBox3.SelectedIndex, Convert.ToInt32(numericUpDown4.Value));
            Bestelling bestelling = new Bestelling(klant, bestelGerecht,drank,dessert, Convert.ToInt32( numericUpDown2.Value));
            MessageBox.Show(bestelling.ToString());
            listBox1.Items.Add(bestelling);




        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
