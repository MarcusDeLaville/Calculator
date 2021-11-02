using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : MaterialForm
    {
        public CalculatorForm()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Yellow800, Primary.Yellow800, Accent.Red400, TextShade.WHITE);

            InitializeComponent();
        }

        private double a;
        private double b;
        private string oper;
        private double result;

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void button_OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            if (a != 0.0)
            {
                b = Convert.ToDouble(button.Text);
                display.Text = $"{a} {oper} {b}";
            }
            else
            {
                display.Text += button.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            display.Clear();

            a = 0.0;
            b = 0.0;
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            a = Convert.ToDouble(display.Text);
            oper = button.Text;
            display.Clear();
        }

        private void Calculation_Click(object sender, EventArgs e)
        {
           /* b = Convert.ToDouble(display.Text);*/

            switch (oper)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
            }

            a = result;
            b = 0.0;

            display.Text = result.ToString();
        }
    }
}
