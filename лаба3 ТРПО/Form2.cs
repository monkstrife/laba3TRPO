using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace лаба3_ТРПО
{
    public partial class Form2 : Form
    {
        private Brush ColorPoint;
        private Pen ColorLine;

        public Brush ColPoint
        {
            get
            {
                return ColorPoint;
            }
        }

        public Pen ColLine
        {
            get
            {
                return ColorLine;
            }
        }

        public Form2(Brush ColorPoint, Pen ColorLine)
        {
            InitializeComponent();
            this.ColorPoint = ColorPoint;
            this.ColorLine = ColorLine;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem == "Красный")
                {
                    ColorPoint = Brushes.Red;
                }
                else if (comboBox1.SelectedItem == "Синий")
                {
                    ColorPoint = Brushes.Blue;
                }
                else if (comboBox1.SelectedItem == "Зелёный")
                {
                    ColorPoint = Brushes.Green;
                }
            }
            if (comboBox2.SelectedItem != null)
            {
                if (comboBox2.SelectedItem == "Красный")
                {
                    ColorLine = Pens.Red;
                }
                else if (comboBox2.SelectedItem == "Синий")
                {
                    ColorLine = Pens.Blue;
                }
                else if (comboBox2.SelectedItem == "Зелёный")
                {
                    ColorLine = Pens.Green;
                }
            }
            this.Close();
        }
    }
}
