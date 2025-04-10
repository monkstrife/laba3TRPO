
using System.Drawing;
using System.Windows.Forms;

namespace лаба3_ТРПО
{
    public partial class Form1 : Form
    {
        Form2 settingsForm = new Form2(Brushes.Red, Pens.Red);
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            t.Interval = 30;
            t.Tick += Form1_MovePoints;

            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Form1_MovePoints(object sender, EventArgs e)
        {
            panel1.MovePoints(sender, e);
        }

        void Refresh_setting()
        {
            panel1.setColor(settingsForm.ColPoint, settingsForm.ColLine);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                panel1.MovePointsTo("Up");
                return true;
            }
            else if (keyData == Keys.Down)
            {
                panel1.MovePointsTo("Down");
                return true;
            }
            else if (keyData == Keys.Left)
            {
                panel1.MovePointsTo("Left");
                return true;
            }
            else if (keyData == Keys.Right)
            {
                panel1.MovePointsTo("Right");
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                panel1.clearPanel();
                return true;
            }
            else if (keyData == Keys.Space)
            {
                t.Enabled = !t.Enabled;
                return true;
            }
            else if (keyData == Keys.Oemplus)
            {
                panel1.SpeedUp();
                return true;
            }
            else if (keyData == Keys.OemMinus)
            {
                panel1.SpeedDown();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.AR_Form1_MouseClick();

            if (button1.BackColor == Color.White)
                button1.BackColor = Color.Green;
            else
                button1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show the settings form

            while (settingsForm.ShowDialog() == DialogResult.Retry)
            {
                settingsForm.Dispose();
            }
            Refresh_setting();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.AR_ClosedCurveHandler();

            if (button4.BackColor == Color.White)
                button4.BackColor = Color.Green;
            else
                button4.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.AR_PolygonHandler();

            if (button3.BackColor == Color.White)
                button3.BackColor = Color.Green;
            else
                button3.BackColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.AR_BeziersHandler();

            if (button8.BackColor == Color.White)
                button8.BackColor = Color.Green;
            else
                button8.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.AR_FillClosedCurveHandler();

            if (button7.BackColor == Color.White)
                button7.BackColor = Color.Green;
            else
                button7.BackColor = Color.White;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.clearPanel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t.Enabled = !t.Enabled;
        }
    }
}
