using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
namespace LibraryCore
{
    public partial class Form5 : Form
    {
        string pay = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\pay.txt";
        string userfile = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\users.txt";
        public Form5()
        {
            InitializeComponent();
        }
        public int AddSum()
        {
            using (StreamReader sr = new StreamReader(userfile, System.Text.Encoding.Default))
            {
                string line;
                string rachunek;
                int j = 0;
                int fullsum = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (j == 1) j++;
                    if (line == textBox1.Text)
                    {
                        j = 1;
                    }
                    if (j == 2)
                    {
                        rachunek = line;
                        fullsum = Convert.ToInt32(rachunek) + Convert.ToInt32(textBox4.Text);
                        break;
                    }
                }
                return fullsum;
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string seller = textBox1.Text;
            string name = textBox5.Text;
            string cena = textBox4.Text;
            string autor = textBox3.Text;
            
            using (StreamWriter sw = new StreamWriter(pay, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(autor);
                sw.WriteLine(name);
                sw.WriteLine(cena);
                sw.WriteLine();
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        public Book AddPayBook()
        {
            return new Book(Convert.ToInt32(textBox4.Text), textBox5.Text, textBox3.Text);
        }
    }
}
