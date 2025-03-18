using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace воздушные_шары
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private Graphics gr;

        public Form1()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            this.BackColor = Color.White;
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Случайное количество окружностей
            int count = rnd.Next(20);

            for (int i = 0; i < count; i++)
            {
                // Случайные параметры окружности
                int radius = rnd.Next(100);
                int x = rnd.Next(this.ClientSize.Width - radius);
                int y = rnd.Next(this.ClientSize.Height - radius);

                // Случайный цвет
                Color color = Color.FromArgb(
                    rnd.Next(256),
                    rnd.Next(256),
                    rnd.Next(256));

                // Создаем кисть для заливки
                using (SolidBrush brush = new SolidBrush(color))
                {
                    // Рисуем закрашенную окружность
                    e.Graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
