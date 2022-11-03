using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int add = int.Parse(textBox1.Text);
            int sum = int.Parse(textBox2.Text);
            Account acc = new Account(sum);
            int res = add - sum;
            listBox1.Items.Add($"Остаток: {res}");
            acc.RegisterHandler(PrintSimpleMessage);
            acc.Take(sum);
            
            void PrintSimpleMessage(string message) => MessageBox.Show(message);
        }
        public class Account
        {
            public delegate void AccountHandler(string message);
            int sum;
            // Создаем переменную делегата
            AccountHandler taken;
            public Account(int sum) => this.sum = sum;
            // Регистрируем делегат
            public void RegisterHandler(AccountHandler del)
            {
                taken = del;
            }
            public void Add(int sum) => this.sum += sum;
            public void Take(int sum)
            {
                if (this.sum >= sum)
                {
                    this.sum -= sum;
                    // вызываем делегат, передавая ему сообщение
                    taken?.Invoke($"Со счета списано {sum} у.е.");
                }
                else
                {
                    taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int add = int.Parse(textBox1.Text);
            Account acc = new Account(add);
            acc.Add(add);
            listBox1.Items.Add($"На вашем счету: {add}");
        }
    }
    
}
