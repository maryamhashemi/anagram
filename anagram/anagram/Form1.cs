using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace anagram
{
    public partial class Form1 : Form
    {
        bool isfind;
        DataTable words = new DataTable();
        public Form1(DataTable words)
        {
            InitializeComponent();
            isfind = false;
            this.words = words;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            isfind = false;
            listView1.Items.Clear();
            if(textBox1.Text == "")
            {
                MessageBox.Show("لطفا لغت خود را وارد کنید");
            }
            else
            {
                var myregex = new Regex(@"^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF\u200C\u200F ]+$");
                if (myregex.IsMatch(textBox1.Text))
                {
                    string word = textBox1.Text;
                    int wordSize = word.Count();
                    string sortedword = new string(word.OrderBy(c => c).ToArray());

                    for (int i = 0; i < words.Rows.Count; i++)
                    {
                        if (words.Rows[i]["sorted"].ToString() == sortedword)
                        {
                            listView1.Items.Add(words.Rows[i]["moeinWords"].ToString());
                            isfind = true;
                        }
                    }
                    //Permute(wordchar, 0, wordSize - 1);
                    //permute(word);
                    if (isfind == false)
                    {
                        MessageBox.Show("هیچ آناگرامی پیدا نشد");
                    }
               }
               else
               {
                    MessageBox.Show("لطفازبان صفحه کلید خود را به فارسی تغییر دهید");
               }
            }   
        }

        /*private  void Permute(char[] word, int start, int finish)
        {
            /*if (start == finish)
            {
                byte[] utfb = Encoding.UTF8.GetBytes(word);
                byte[] resb = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-1256"), utfb);
                string result = Encoding.GetEncoding("windows-1256").GetString(resb);


                for (int i=0; i<words.Rows.Count; i++)
                {
                    if(words.Rows[i]["moeinWords"].ToString() == result)
                    {
                        listView1.Items.Add(result);
                        isfind = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = start; i <= finish; ++i)
                {
                    char temp = word[start];
                    word[start] = word[i];
                    word[i] = temp;

                    Permute(word, start + 1, finish);

                    temp = word[start];
                    word[start] = word[i];
                    word[i] = temp;
                }
            }
        }  // Permute() */

        /*public void permute(string word)
        {
            int wordSize = word.Count();
            char[] wordchar = word.ToCharArray();
            int[] p = new int[wordSize];

            for(int k=0; k<wordSize; k++)
            {
                p[k] = 0;
            }

            int i = 1, j = 0;
            while(i<wordSize)
            {
                if(p[i]<i)
                {
                    j = (i % 2) * p[i];
                    //swap
                    char temp = wordchar[i];
                    wordchar[i] = wordchar[j];
                    wordchar[j] = temp;

                    //listView1.Items.Add(wordchar.ToString());
                    Console.WriteLine(wordchar.ToString());
                    p[i]++;
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    i++;
                }

            }
            
        }*/

    }
}
