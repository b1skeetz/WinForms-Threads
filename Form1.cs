using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
            }
            MessageBox.Show("Text");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
            Properties.Settings.Default.BackColor = colorDialog1.Color;
            Properties.Settings.Default.Save();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int posY = 0;
            for(int i = 0; i < numericUpDown1.Value; i++)
            {
                TextBox text = new TextBox();
                text.Location = new System.Drawing.Point(32, 31 + posY);
                posY += 50;
                text.Name = "textBox" + i;
                text.Size = new System.Drawing.Size(118, 20);
                text.TabIndex = 2;
                
                Controls.Add(text);
                (Controls["textBox" + i] as TextBox).Text = "My number is " + i;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text.ToString());
        }

        bool isClicked = false;
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (!isClicked)
            {
                TextBox text = new TextBox();
                Panel panel = new Panel();
                Label label = new Label();
                Button button = new Button();
                (Controls["panel1"] as Panel).Controls.Clear();
                Controls.Remove((Controls["panel1"] as Panel));
                //panel.Controls.Remove(text);
                //panel.Controls.Remove(button);

                this.Size = new Size(this.Size.Width - 200, this.Size.Height);
                isClicked = true;
            }
            else if(isClicked == true)
            {
                TextBox text = new TextBox();
                Panel panel = new Panel();
                Label label = new Label();
                Button button = new Button();

                this.Size = new Size(this.Size.Width + 200, this.Size.Height);
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(71, 53);
                label.Name = "label1";
                label.Size = new System.Drawing.Size(50, 13);
                label.TabIndex = 1;
                label.Text = "Message";

                button.Location = new System.Drawing.Point(61, 126);
                button.Name = "button2";
                button.Size = new System.Drawing.Size(75, 23);
                button.TabIndex = 2;
                button.Text = "Show";
                button.UseVisualStyleBackColor = true;
                button.Click += new System.EventHandler(this.button2_Click_1);

                text.Location = new System.Drawing.Point(0, 84);
                text.Name = "textBox1";
                text.Size = new System.Drawing.Size(200, 20);
                text.TabIndex = 0;

                panel.Dock = System.Windows.Forms.DockStyle.Right;
                panel.Location = new System.Drawing.Point(600, 0);
                panel.Name = "panel1";
                panel.Size = new System.Drawing.Size(200, 450);
                panel.TabIndex = 2;

                
                Controls.Add(panel);
                panel.Controls.Add(button);
                panel.Controls.Add(label);
                panel.Controls.Add(text);

                isClicked = false;
            }
        }
    }
}
