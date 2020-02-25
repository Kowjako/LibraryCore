using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
namespace LibraryCore
{
    public partial class Form3 : Form
    {
        string library;
        string path1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\wro.txt";
        string path2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\war.txt";
        string path3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\gd.txt";
        string editpath1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\wro.txt";
        string editpath2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\war.txt";
        string editpath3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\gd.txt";
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            library = "wro";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            library = "gd";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            library = "war";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text;
            if (library == "wro")
            {
                using (StreamReader sr = new StreamReader(path1))
                {
                    string book;
                    while((book = await sr.ReadLineAsync())!=null)
                    {
                        if(book == nazwa)
                        {
                            using(StreamWriter sw = new StreamWriter(editpath1,true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(book);
                            }
                        }

                    }
                }
                DeleteBook(path1, nazwa);
            }
            if (library == "war")
            {
                using (StreamReader sr = new StreamReader(path2))
                {
                    string book;
                    while ((book = await sr.ReadLineAsync()) != null)
                    {
                        if (book == nazwa)
                        {
                            using (StreamWriter sw = new StreamWriter(editpath2, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(book);
                            }
                        }

                    }
                }
                DeleteBook(path2, nazwa);
            }
            if (library == "gd")
            {
                using (StreamReader sr = new StreamReader(path3))
                {
                    string book;
                    while ((book = await sr.ReadLineAsync()) != null)
                    {
                        if (book == nazwa)
                        {
                            using (StreamWriter sw = new StreamWriter(editpath3, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(book);
                            }
                        }

                    }
                }
                DeleteBook(path3, nazwa);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private async void DeleteBook(string path, string book)
        {
            List<string> books = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == book) continue; else
                    books.Add(line);
                }
            }
            using(StreamWriter sw = new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                for (int i = 0; i < books.Count; i++) await sw.WriteLineAsync(books[i]);
            }
        }
    }
}
