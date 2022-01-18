using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Mahmoud
{
    // Test Cases:
    // Addition
    // Subtraction
    // Multiplication
    // Division
    // Continous operation: (operation can be added to output)
    // Clear entry: (Clears second entry #, not first entry # or operator)
    // Clear: (Clears all entries and operators)

    public partial class Form1 : Form
    {
        // Global variables for calculator logic
        private String operation = "";
        private String scientificOperation = "";
        private decimal outputValue = 0;
        private bool operationInputted = false;
        private bool equalInputted = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            // Method for button clicking event
            // Replace default value "0" when button clicked
            // After operation, clear textBox_output
            if ((textBox_Output.Text == "0") || operationInputted)
            {
                textBox_Output.Clear();
            }

            // Create a button object to hold the value of button clicked
            Button button = (Button)sender;

            // Check if decimal point has been inputted already
            if (button.Text == ".")
            {
                // if textBox DOES NOT contain ".", append "."
                if (!textBox_Output.Text.Contains("."))
                {
                    textBox_Output.Text = textBox_Output.Text + button.Text;
                }
            } else
            {
                textBox_Output.Text = textBox_Output.Text + button.Text;
            }

            operationInputted = false;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(outputValue != 0)
            {
                // Replicate equalButton function when operator is performed after 
                // a previous operator
                buttonEqual.PerformClick();
                operation = button.Text;
                outputLabel.Text = outputValue + " " + operation;
                operationInputted = true;

            } else
            {
                // type cast on textBox_output (string) to double data type
                //outputValue = Double.Parse(textBox_Output.Text);
                // Check if integer is already selected for calculation
                operation = button.Text;
                outputValue = Decimal.Parse(textBox_Output.Text);
                outputLabel.Text = outputValue + " " + operation;
                operationInputted = true;
            }
           
        }

        private void clearEntry_button_Click(object sender, EventArgs e)
        {
            // Set current entry to zero
            textBox_Output.Text = "0";
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            // Set current entry AND total output to zero
            textBox_Output.Text = "0";
            outputValue = 0;
            outputLabel.Text = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Calculate operations with the operation variable as the condition
            // Execute when an operation is selected (operationInputted is TRUE)
            switch(operation)
            {
                case "+":
                    outputLabel.Text = (textBox_Output.Text);
                    textBox_Output.Text = (outputValue + decimal.Parse(textBox_Output.Text)).ToString();
                    break;
                case "-":
                    outputLabel.Text = (textBox_Output.Text);
                    textBox_Output.Text = (outputValue - decimal.Parse(textBox_Output.Text)).ToString();
                    break;
                case "*":
                    outputLabel.Text = (textBox_Output.Text);
                    textBox_Output.Text = (outputValue * decimal.Parse(textBox_Output.Text)).ToString();
                    break;
                case "/":
                    outputLabel.Text = (textBox_Output.Text);
                    textBox_Output.Text = (outputValue / decimal.Parse(textBox_Output.Text)).ToString();
                    break;
                default:
                    break;
            }
            outputValue = decimal.Parse(textBox_Output.Text);
            outputLabel.Text = "";
            operation = "";
            operationInputted = true;
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 245;
            textBox_Output.Width = 205;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On calculator start up
            this.Width = 245;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set form width and textbox width 
            this.Width = 350;
            textBox_Output.Width = 305;
        }

        // Possible Feature: strip menu item for currency converter?

        private void scientificOperator_click(object sender, EventArgs e)
        {
            // Similar concept to operator_click(), but for scientific buttons
            Button button = (Button)sender;
            String x = "";
            scientificOperation = button.Text;

            if (textBox_Output.Text != "0")
            {
                switch(scientificOperation)
                {
                    case "1/x":
                        textBox_Output.Text = (1 / Decimal.Parse(textBox_Output.Text)).ToString();
                        outputLabel.Text = (textBox_Output.Text);
                        break;
                    case "sqrt":
                        x = textBox_Output.Text;
                        textBox_Output.Text = (Math.Sqrt(Double.Parse(textBox_Output.Text))).ToString();
                        outputLabel.Text = ("Sqrt(" + x + ") = " + textBox_Output.Text);
                        break;
                    case "x^2":
                        textBox_Output.Text = (Math.Pow(Double.Parse(textBox_Output.Text), 2)).ToString();
                        outputLabel.Text = (textBox_Output.Text);
                        break;
                    case "x^3":
                        textBox_Output.Text = (Math.Pow(Double.Parse(textBox_Output.Text), 3)).ToString();
                        outputLabel.Text = (textBox_Output.Text);
                        break;
                    case "%":
                        textBox_Output.Text = (Double.Parse(textBox_Output.Text) / 100).ToString();
                        outputLabel.Text = (textBox_Output.Text);
                        break;
                    case "Sin":
                        x = textBox_Output.Text;
                        textBox_Output.Text = (Math.Sin(Double.Parse(textBox_Output.Text))).ToString();
                        outputLabel.Text = ("Sin(" + x + ") = " + textBox_Output.Text);
                        break;
                    case "Cos":
                        x = textBox_Output.Text;
                        textBox_Output.Text = (Math.Cos(Double.Parse(textBox_Output.Text))).ToString();
                        outputLabel.Text = ("Cos(" + x + ") = " + textBox_Output.Text);
                        break;
                    case "Tan":
                        x = textBox_Output.Text;
                        textBox_Output.Text = (Math.Tan(Double.Parse(textBox_Output.Text))).ToString();
                        outputLabel.Text = ("Tan(" + x + ") = " + textBox_Output.Text);
                        break;
                    default:
                        break;
                }
                outputValue = decimal.Parse(textBox_Output.Text);
                scientificOperation = "";
                operationInputted = true;

                // Feature fix: limit decimal places in output or put in scientific notation
            }
        }

        // Possible feature: Event for currency conversion?

    }
}
