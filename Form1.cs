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
    public partial class Calculator : Form
    {
        //keeps track of whether you're starting a new number
        bool buttonPressed = false;
        //stores which of the two numbers in the operation is being used
        int varnum = 1;
        //stores which operation is being performed
        int operation = 0;
        //checks for error
        bool error = false;
        Calculation cal = new Calculation(0, 0);

        public void buttonPush()
        {
            buttonPressed = true;
            txtStoredNumber.Text = txtOperation.Text;
            txtOperation.Focus();
        }
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    txtOperation.Text = cal.addition(cal.getv1(), Convert.ToDouble(txtOperation.Text)).ToString();
                    break;
                case 2:
                    txtOperation.Text = cal.subtract(cal.getv1(), Convert.ToDouble(txtOperation.Text)).ToString();
                    break;
                case 3:
                    txtOperation.Text = cal.multiply(cal.getv1(), Convert.ToDouble(txtOperation.Text)).ToString();
                    break;
                case 4:
                    if (Convert.ToDouble(txtOperation.Text) == 0)
                    {
                        txtOperation.Text = "You cannot divide by zero.";
                        error = true;
                    }
                    else txtOperation.Text = cal.divide(cal.getv1(), Convert.ToDouble(txtOperation.Text)).ToString();
                    /*
                     *this block doesn't work
                    try
                    {
                        //for some reason doesn't generate an exception when you divide by 0
                        double result = cal.divide(cal.getv1(), Convert.ToDouble(txtOperation.Text));
                        txtOperation.Text = result.ToString();
                    }
                    //for some reason doesn't work and doesn't catch the exception
                    catch
                    {
                        error = true;
                        txtOperation.Text = "You cannot divide by zero.";
                    }
                    */
                    break;
              }
            varnum = 1;
            txtOperator.Text = "";
            txtStoredNumber.Text = "";
            operation = 0;
        }

        private void txtOperation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(error == true)
            {
                txtOperation.Text = "";
                error = false;
            }
            char ch = e.KeyChar;
            if(buttonPressed)
            {
                if (varnum == 1)
                {
                    txtStoredNumber.Text = Convert.ToDouble(txtOperation.Text).ToString();
                    varnum = 2;
                    cal.setv1(Convert.ToDouble(txtOperation.Text));
                }
                buttonPressed = false;
                txtOperation.Text = "";
            }
            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            operation = 1;
            txtOperator.Text = "+";
            buttonPush();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            operation = 2;
            txtOperator.Text = "-";
            buttonPush();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            operation = 3;
            txtOperator.Text = "x";
            buttonPush();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            operation = 4;
            txtOperator.Text = "/";
            buttonPush();
        }
    }
}
