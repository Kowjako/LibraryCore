using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace LibraryCore
{
    public partial class Form4 : Form
    {
        string library;
        string path1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\wro.txt";
        string path2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\war.txt";
        string path3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\gd.txt";
        string editpath1 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\wro.txt";
        string editpath2 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\war.txt";
        string editpath3 = @"C:\Users\LaptopMSI\Documents\visual studio 2015\Projects\LibraryCore\LibraryCore\Library\take\gd.txt";

        public Form4()
        {
            InitializeComponent();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string nazwa = textBox1.Text;
            if (library == "wro")
            {
                using (StreamReader sr = new StreamReader(editpath1))
                {
                    string book;
                    while ((book = await sr.ReadLineAsync()) != null)
                    {
                        if (book == nazwa)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    DeleteBook(editpath1, nazwa);
                    AddBook(path1, nazwa);
                }
            }
            if (library == "war")
            {
                using (StreamReader sr = new StreamReader(editpath2))
                {
                    string book;
                    while ((book = await sr.ReadLineAsync()) != null)
                    {
                        if (book == nazwa)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    DeleteBook(editpath2, nazwa);
                    AddBook(path2, nazwa);
                }
            }
            if (library == "gd")
            {
                using (StreamReader sr = new StreamReader(editpath3))
                {
                    string book;
                    while ((book = await sr.ReadLineAsync()) != null)
                    {
                        if (book == nazwa)
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    DeleteBook(editpath3, nazwa);
                    AddBook(path3, nazwa);
                }
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
                    if (line == book) continue;
                    else
                        books.Add(line);
                }
            }
            if (books.Count == 0)
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    await sw.WriteLineAsync("");
                }
            else
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    for (int i = 0; i < books.Count; i++) await sw.WriteLineAsync(books[i]);
                }
        }
        private async void AddBook(string path, string book)
        {
            using(StreamWriter sw = new StreamWriter(path,true,System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(book);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            library = "wro";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            library = "gd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            library = "war";
        }
    }
}
