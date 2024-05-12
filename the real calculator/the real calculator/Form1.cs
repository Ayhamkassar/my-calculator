using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace the_real_calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string Operator = "";
        bool isOperator = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //==============monitor==============
        private void text1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (text1.Text == "0" || isOperator)
                {
                    text1.Clear(); 
                }
                text1.Text += e.KeyChar;
                isOperator = false;
            }
            else if (e.KeyChar == '.')
            {
                
                if (!text1.Text.Contains("."))
                {
                    text1.Text += e.KeyChar;
                }
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                PLUS.PerformClick(); 
                Operator = e.KeyChar.ToString();
                label.Text = $"{result} {Operator}";
                isOperator = true;
            }
            else if (e.KeyChar == '=' || e.KeyChar == '\r')
            {
     
                EQUAL.PerformClick();
            }
            else if (e.KeyChar == '\b')
            {
                DELETE.PerformClick();
            }
            text1.SelectionStart = text1.Text.Length;
            text1.SelectionLength = 0;
            text1.Focus();
            e.Handled = true;
        }
        private void text1_TextChanged(object sender, EventArgs e)
        {
        }
        // ==============Delete Buttons==============
        private void DELETE_Click(object sender, EventArgs e)
        {
            if (text1.Text.Length > 0)
            {
                text1.Text =text1.Text.Remove(text1.Text.Length -1, 1);
            }
            if (text1.Text == "")
            {
                text1.Text ="0";
            }
        }
        private void C_button_Click(object sender, EventArgs e)
        {
            text1.Text = "0";
            result = 0;
        }
        //==============Methods Buttons==============
        private void PLUS_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result != 0)
            {
                EQUAL.PerformClick();
                Operator = button.Text;
                label.Text = result + " " + Operator;
                isOperator = true;
            }
            else
            {
                Operator = button.Text;
                result = double.Parse(text1.Text);
                label.Text = result + " " + Operator;
                isOperator = true;
            }
        }
        private void EQUAL_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Operator)
                {
                    case "+":
                        text1.Text = (result + double.Parse(text1.Text)).ToString();
                        break;
                    case "-":
                        text1.Text = (result - double.Parse(text1.Text)).ToString();
                        break;
                    case "*":
                        text1.Text = (result * double.Parse(text1.Text)).ToString();
                        break;
                    case "/":
                        double divisor = double.Parse(text1.Text);
                        if (divisor == 0)
                            throw new DivideByZeroException();
                        text1.Text = (result / divisor).ToString();
                        break;
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Can't divide by zero");
            }

            result = double.Parse(text1.Text);
            label.Text = "";
        }


        //==============NUMBERS==============

        private void N1_Click(object sender, EventArgs e)
        {
            Button a = (Button)(sender);
            text1.Text += a.Text;
            if (text1.Text[0] == '0') text1.Text = Numbers.Remove(text1.Text,0);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            if (!text1.Text.Contains("."))
            {
                text1.Text = text1.Text + ".";
            }
        }


    }
}
