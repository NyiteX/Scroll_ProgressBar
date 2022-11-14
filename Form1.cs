using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Basic_Window : Form
    {
        Point p;
        
        public Basic_Window()
        {
            InitializeComponent();

            backgroundWorker1.RunWorkerAsync();
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);

            BackColor = Color.FromArgb(220,220,220);

            textBox1.MouseWheel += MyMouseWheel;
            //MouseWheel += textBox1_MouseMove;
        }

        //Basic_Window
        private void Basic_Window_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void Basic_Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }

        //Basic_buttons
        private void X_Button_MouseEnter(object sender, EventArgs e)
        {
            X_Button.BorderStyle = BorderStyle.Fixed3D;
            X_Button.BackColor = Color.Thistle;
        }
        private void X_Button_MouseLeave(object sender, EventArgs e)
        {
            X_Button.BorderStyle = BorderStyle.FixedSingle;
            X_Button.BackColor = Color.WhiteSmoke;
        }
        private void X_Button_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void Read_File()
        {
            try
            {
                if(File.Exists("test.txt"))
                using (StreamReader F = new StreamReader("test.txt"))
                {
                    textBox1.Text = F.ReadToEnd();
                }
            }
            catch(Exception E) { MessageBox.Show(E.Message); }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value;
            int g = trackBar2.Value;
            int b = trackBar3.Value;
            BackColor = Color.FromArgb(r,g,b);
            label1.Text = "Red " + r;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value;
            int g = trackBar2.Value;
            int b = trackBar3.Value;
            BackColor = Color.FromArgb(r, g, b);
            label2.Text = "Green " + g;
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value;
            int g = trackBar2.Value;
            int b = trackBar3.Value;
            BackColor = Color.FromArgb(r, g, b);
            label3.Text = "Blue " + b;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button_next_Click(object sender, EventArgs e)
        {
            button_next.Visible = false;
            button_prev.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;
            textBox1.Visible = true;
            progressBar1.Visible = true;
            Read_File();
        }
        private void button_prev_Click(object sender, EventArgs e)
        {
            button_prev.Visible = false;
            button_next.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;
            textBox1.Visible = false;
            progressBar1.Visible = false;
        }
        //Mouse_click progressBar
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //progressBar1.Maximum = textBox1.Lines.Length - 5;
            //progressBar1.Value = textBox1.GetFirstCharIndexOfCurrentLine() / textBox1.Lines.Length;                   
        }
        //Scroll!!11 progressBar
        private void MyMouseWheel(object sender, MouseEventArgs e)
        {
                if (e.Delta > 0 && textBox1.Lines.Length > 5)
                {
                    progressBar1.Maximum = textBox1.Lines.Length-2;
                    if (progressBar1.Value + e.Delta / 40 * -1 >= progressBar1.Minimum)
                        progressBar1.Value += e.Delta / 40 * -1;
                }
                else if (e.Delta < 0 && textBox1.Lines.Length > 5)
                {
                    progressBar1.Maximum = textBox1.Lines.Length-2;
                    if (progressBar1.Value + e.Delta / 40 * -1 <= progressBar1.Maximum)
                        progressBar1.Value += e.Delta / 40 * -1;
                }
        }
    }
}
