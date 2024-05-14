using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gdik_krupniy
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "LOGIN")
            {
                if (textBox2.Text == "PAROL")
                {
                    this.Hide();
                    main main = new main();
                    main.Show();
                    if (this.BackColor == SystemColors.ControlDark)
                    {
                        main.BackColor = SystemColors.ControlDark;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный Пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверный логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == SystemColors.Control)
            {
                this.BackColor = SystemColors.ControlDark;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }
    }
}
