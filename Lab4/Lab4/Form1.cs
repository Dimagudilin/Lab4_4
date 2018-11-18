using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        public void textBoxFileReadTime(object sender, EventArgs e)
        {
            Text = "Таймер";
        }

        public void textBoxFileReadCount(object sender, EventArgs e)
        {
            Text = "Уникальные слова";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовые файлы|*.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
            Stopwatch t = new Stopwatch();
                t.Start();
                //Чтение файла в виде строки
                string text = File.ReadAllText(fd.FileName, Encoding.GetEncoding(1251));
                //Разделительные символы для чтения из файла
                char[] separators =
                new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится
                if (!list.Contains(str)) list.Add(str);
                }
                t.Stop();
                textBox1.Text = t.Elapsed.ToString();
                textBox2.Text = list.Count.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Слово для поиска
            string word = this.textBox3.Text.Trim();

            //Если слово для поиска не пусто
            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                //Слово для поиска в верхнем регистре
                string wordUpper = word.ToUpper();
                //Временные результаты поиска
                List<string> tempList = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                this.listBox1.BeginUpdate();
                this.listBox1.Items.Clear();
                foreach (string str in list)
                {
                   // this.listBox1.Items.Add(str);
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }

                t.Stop();
                this.textBox4.Text = t.Elapsed.ToString();
               
                //Очистка списка
                
                
                //Вывод результатов поиска
                foreach (string str in tempList)
                {
                    this.listBox1.Items.Add(str);
                    
                }
                this.listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
