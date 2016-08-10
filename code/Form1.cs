using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = new String(TextEncrypt(textBox1.Text, textBox2.Text));
        }
        private char[] TextEncrypt(string content, string secretKey)
        {
            char[] data = content.ToCharArray();
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return data;
        }
        private string TextDecrypt(char[] data, string secretKey)
        {
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = TextDecrypt(TextEncrypt(textBox1.Text, textBox2.Text), textBox2.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IList<ids1> ids1 = new List<ids1> ();
            ids1.Add(new ids1() { id = 1 });
            ids1.Add(new ids1() { id = 2 });
            ids1.Add(new ids1() { id = 3 });
            ids1.Add(new ids1() { id = 4 });
            ids1.Add(new ids1() { id = 5 });

            IEnumerable<ids1> ids11 = ids1;

            IList<ids2> ids2 = new List<ids2>();
            ids2.Add(new ids2() { id=1,id1 = ids1.First(ie => ie.id == 1)});
            ids2.Add(new ids2() { id=2,id1 = ids1.First(ie => ie.id == 3) });

            IEnumerable<ids2> ids22 = ids2;
           // DB.Questions.Where(qu1 => et.Questions.Count(etq1 => etq1.Question.ID == qu1.ID) == 0)
           ////     .ToList()
            //    .ForEach(req => notExistQuestions.Add(req));
            //ids22.ToList().ForEach(x => ids11.Where(i1=>i1.Equals(x.id1)).ToList().ForEach(i11=>Console.Out.WriteLine(i11.id)));
            //ids11.Where(i1 => ids22.Count(i2 => i2.id1.Equals(i1)) > 0).ToList().ForEach(i11 => Console.Out.WriteLine(i11.id));
            ids11.Where(i1 => ids22.Count(i2 => i2.id1.Equals(i1)) == 0).ToList().ForEach(i11 => Console.Out.WriteLine(i11.id));
        }
    }

    public class ids1
    {
        public int id { get; set; }
    }

    public class ids2
    {
        public int id { get; set; }
        public ids1 id1 { get; set; }
    }
}
