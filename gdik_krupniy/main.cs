using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gdik_krupniy
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(inputText, emailPattern);
            int emailCount = matches.Count;
            label2.Text = $"{emailCount}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(inputText, emailPattern);

            HashSet<string> uniqueEmails = new HashSet<string>();
            foreach (Match match in matches)
            {
                uniqueEmails.Add(match.Value);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить уникальные e-mail адреса";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, uniqueEmails);
                    MessageBox.Show($"Уникальные e-mail адреса успешно сохранены в файл: {saveFileDialog.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                }
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            auth auth = (auth)Application.OpenForms["auth"];
            auth.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Открыть текстовый файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    textBox1.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                }
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
