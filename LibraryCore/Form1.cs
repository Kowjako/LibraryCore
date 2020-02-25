using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
namespace LibraryCore
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<Reader> ReaderList = new List<Reader>();
        List<Book> PayBooks = new List<Book>();
        List<Worker> WorkerList = new List<Worker>(4)
        {
            new Worker("Anna Krzysiek"),
            new Worker("Maciej Buk"),
            new Worker("Malgorzata Popiel"),
            new Worker("Mieczyslaw Kopacz"),
        };
        string path1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\wro.txt";
        string path2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\war.txt";
        string path3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\gd.txt";
        string userfile = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\users.txt";
        string editpath1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\wro.txt";
        string editpath2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\war.txt";
        string editpath3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\gd.txt";
        string pay = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\pay.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            RefreshBoxes();
            RefreshList();
            using (StreamReader sr = new StreamReader(pay))
            {
                richTextBox8.Text = await sr.ReadToEndAsync();
            }
            richTextBox1.Text = (WorkerList[GenerateWorker()].DisplayInfo()).ToString();       
        }
        private int GenerateWorker()
        {
            Random r = new Random();
            int tmp = r.Next(4);
            return tmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if(f2.ShowDialog() == DialogResult.OK)
            {
                Reader _tmp = f2.GetReader();
                ReaderList.Add(_tmp);
                richTextBox1.Text += $"\nZarejestrowany nowy użytkownik : {_tmp.Name}";
                try
                {
                    using(StreamWriter sr = new StreamWriter(userfile,true,System.Text.Encoding.Default))
                    {
                        string line = $"{_tmp.Name}";
                        sr.WriteLine(line);
                        sr.WriteLine("0");
                    }
                }
                catch(Exception)
                {
                    richTextBox1.Text += "Wystąpił Błąd :)";
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\nWszyscy użytkownicy: \n";
            using (StreamReader sr = new StreamReader(userfile))
            {
                richTextBox1.Text += await sr.ReadToEndAsync();
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;         
            bool flag = false;
            int j = 0;
            using (StreamReader sr = new StreamReader(userfile,System.Text.Encoding.Default))
            {
                string line;
                string rachunek;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (j == 1) j++;
                    if (line == login)
                    {
                        richTextBox1.Text += $"\nJestes zalogowany {line}";
                        flag = true;
                        j = 1;
                    }
                    if (j == 2)
                    {
                        rachunek = line;
                        label5.Text = rachunek + " PLN";
                        ReaderList.Add(new Reader(login, Convert.ToInt32(rachunek)));
                        break;
                    }
                } 
                if(!flag) richTextBox1.Text += $"\nNie istnieje takiego użytkownika"; else
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button7.Enabled = true;
                }  
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                RefreshBoxes();
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            if (f4.ShowDialog() == DialogResult.OK)
            {
                RefreshBoxes();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button7.Enabled = false;
            richTextBox1.Text += $"\nDo widzenia, {textBox1.Text}, zapraszamy ponownie!";
            textBox1.Text = "";
            label5.Text = "0 PLN";
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            int oldsum = ReaderList[0].sum;
            Form5 f5 = new Form5();
            if (f5.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(pay))
                {
                    richTextBox8.Text = await sr.ReadToEndAsync();
                }
                PayBooks.Add(f5.AddPayBook()); 
                label5.Text = Convert.ToString(f5.AddSum()) + " PLN";
                ReaderList[0].sum = f5.AddSum();
                richTextBox1.Text += "\nTwoj aktualny stan srodkow : " + Convert.ToString(ReaderList[0].sum);
            }
            RefreshUser(ReaderList[0].Name, ReaderList[0].sum, oldsum);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://t.me/maybedot");
        }
        private async void RefreshBoxes()
        {
            using (StreamReader sr = new StreamReader(editpath1))
            {
                richTextBox3.Text = await sr.ReadToEndAsync();
            }
            using (StreamReader sr = new StreamReader(editpath2))
            {
                richTextBox5.Text = await sr.ReadToEndAsync();
            }
            using (StreamReader sr = new StreamReader(editpath3))
            {
                richTextBox7.Text = await sr.ReadToEndAsync();
            }
            using (StreamReader sr = new StreamReader(path1))
            {
                richTextBox2.Text = await sr.ReadToEndAsync();
            }
            using (StreamReader sr = new StreamReader(path2))
            {
                richTextBox4.Text = await sr.ReadToEndAsync();
            }
            using (StreamReader sr = new StreamReader(path3))
            {
                richTextBox6.Text = await sr.ReadToEndAsync();
            }
        }
        private async void RefreshList()
        {
            using (StreamReader sr = new StreamReader(pay))
            {
                string author = await sr.ReadLineAsync();
                string name = await sr.ReadLineAsync();
                string cost = await sr.ReadLineAsync();
                await sr.ReadLineAsync();
                PayBooks.Add(new LibraryCore.Book(Convert.ToInt32(cost),name,author));
            }
        }
        private async void RefreshUser(string name, int newsum, int oldsum)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(userfile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == Convert.ToString(oldsum)) lines.Add(Convert.ToString(newsum));
                    else
                        lines.Add(line);
                }
            }
            using (StreamWriter sw = new StreamWriter(userfile, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < lines.Count; i++) await sw.WriteLineAsync(lines[i]);
            }
        }
    }
}

