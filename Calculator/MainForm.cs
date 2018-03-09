using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {

        bool LastIsOperator;
        string LastOperator = string.Empty;
        bool LastIsP;
        bool LastIsComma;

        double lastResoult = 0;
        char[] variablesNames = { 'x', 'y', 'z', 'w', 'v' };
        char[] listOfOperators = { '*', '+', '-', '/', '^', '!' };

        Dictionary<char, double> variableValues; 
        
        public MainForm()
        {
            InitializeComponent();
            this.LastIsComma = false;
            this.LastIsOperator = false;
            this.LastIsP = false;

            variableValues = new Dictionary<char, double>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var r in variablesNames)
            {
                this.variableValues[r] = 0;
            }
        }

        private void DelBtnEvent(object sender, EventArgs e)
        {
            string newInput = string.Empty;
            for (int i = 0; i < (this.InputBox.Text.Length - 1); i++)
            {
                newInput += this.InputBox.Text[i];
            } 
            this.InputBox.Text = newInput;
        }

        private void NumButtonEvent(object sender, EventArgs e)
        {
            string input = ((Button)sender).Text;

            this.InputBox.Text += this.inputedValueValidate(input);

        }

        private string inputedValueValidate(string input)
        {
            //change into real mul
            if (input == "X")
            {
                input = "*";
            }
            else if (input == "n!")
            {
                input = "!";
            }
            else if(input == ",")
            {
                input = ".";
            }


            if (input == "." && (LastIsOperator || this.InputBox.Text.Length == 0))
            {
                input = "0.";

                this.LastIsP = false;
                this.LastIsOperator = false;
                this.LastIsComma = true;
            }
            else if (input == ".")
            {
                if (LastIsComma)
                {
                    return string.Empty;
                }


                this.LastIsP = false;
                this.LastIsOperator = false;
                this.LastIsComma = true;
            }
            else if ((input == "+" || input == "-" || input == "/" || input == "*" || input == "!" || input == "^"))
            {
                if (LastIsOperator)
                {
                    changeLastOperator(input);
                    return string.Empty;
                }
                this.LastOperator = input;

                this.LastIsP = false;
                this.LastIsOperator = true;
            }
            else if (input == "(" && !this.LastIsP)
            {
                this.LastIsOperator = true;
                this.LastIsP = true;
            }
            else if (input == ")" && this.LastIsP)
            {
                return string.Empty;
            }
            else
            {

                this.LastIsP = false;
                this.LastIsOperator = false;
                this.LastIsComma = false;
            }

            return input;
        }
        private void changeLastOperator(string newOperator)
        {
            string newInput = string.Empty;
            for (int i = 0; i < this.InputBox.Text.Length - this.LastOperator.Length; i++)
            {
                newInput += this.InputBox.Text[i]; 
            }

            for(int i = this.InputBox.Text.Length - this.LastOperator.Length; i< this.InputBox.Text.Length - this.LastOperator.Length + newOperator.Length; i++)
            {
                newInput += newOperator; 
            }

            this.InputBox.Text = newInput;
        }

        private void DelAllBtn_Click(object sender, EventArgs e)
        {
            this.InputBox.Text = string.Empty;
        }

        private void TrigonometicFunctions(object sender, EventArgs e)
        {
            string input = ((Button)sender).Text;
            input += "(";


            this.InputBox.Text += input;
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //implement later for key press

            if (char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if(Char.IsDigit(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '\b' || e.KeyChar == '^' || this.variablesNames.Contains(e.KeyChar))
            {
                this.inputedValueValidate(e.KeyChar.ToString());
            }
            else
            {
                string temp = string.Empty;
                for (int i = 0; i < this.InputBox.Text.Length - 1; i++)
                    temp += this.InputBox.Text[i];

                this.InputBox.Text = temp;
            }
        }
        

        private void InputKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string res = checkForVariables();
                INode root = Parser.ParseString(res);
                this.lastResoult = root.GetResult();
                this.InputBox.Text = this.lastResoult.ToString();
            }
            else if(e.KeyCode == Keys.OemBackslash || e.KeyCode == Keys.Delete)
            {
                //InputBox.Text = 
            }
        }

        private void EquBtn_Click(object sender, EventArgs e)
        {
            this.InputBox.Text = checkForVariables();
            INode root = Parser.ParseString(this.InputBox.Text);
            this.lastResoult = root.GetResult();
            this.InputBox.Text = this.lastResoult.ToString();
        }

        private string checkForVariables()
        {
            string input = this.InputBox.Text;
            string checkedInput = string.Empty;
            string[] temp;

            foreach (char variableName in this.variablesNames)
            {
                temp = input.Split(variableName);

                if(temp.Length > 1)
                {
                    for(int i = 0; i < temp.Length; i++)
                    {
                        checkedInput += temp[i];

                        if (i < temp.Length - 1)
                        {
                            checkedInput += this.variableValues[variableName];
                        }
                    }

                    input = checkedInput;
                    checkedInput = string.Empty;
                }
            }

            return checkedInput = input;
            
        }

        private void xValue_TextChanged(object sender, EventArgs e)
        {
            double parseRes;
            Double.TryParse(xValue.Text, out parseRes);
            this.variableValues['x'] = parseRes;
        }

        private void yValue_TextChanged(object sender, EventArgs e)
        {
            double parseRes;
            Double.TryParse(xValue.Text, out parseRes);
            this.variableValues['y'] = parseRes;
        }

        private void zValue_TextChanged(object sender, EventArgs e)
        {
            double parseRes;
            Double.TryParse(xValue.Text, out parseRes);
            this.variableValues['z'] = parseRes;
        }

        private void wValue_TextChanged(object sender, EventArgs e)
        {
            double parseRes;
            Double.TryParse(xValue.Text, out parseRes);
            this.variableValues['w'] = parseRes;
        }

        private void vValue_TextChanged(object sender, EventArgs e)
        {
            double parseRes;
            Double.TryParse(xValue.Text, out parseRes);
            this.variableValues['v'] = parseRes;
        }

        private void LastRes_Click(object sender, EventArgs e)
        {
            this.InputBox.Text = this.lastResoult.ToString();
        }

        private void InputBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if( Char.IsDigit(e.KeyChar) || this.listOfOperators.Contains(e.KeyChar) || this.variablesNames.Contains(e.KeyChar) || e.KeyChar == ')' || e.KeyChar == '(')
            {
                e.Handled = true;
                this.InputBox.Text += e.KeyChar;
            }
            else if( (e.KeyChar == '\n' || e.KeyChar == '\r') && this.InputBox.Text.Length > 0)
            {
                string t = this.checkForVariables();
                INode n = Parser.ParseString(t);
                this.lastResoult = n.GetResult();
                this.InputBox.Text = this.lastResoult.ToString();
            }
            else if (e.KeyChar  == '\b' && this.InputBox.Text.Length > 0)
            {
               this.InputBox.Text = this.InputBox.Text.Remove(this.InputBox.Text.Length-1,1);
            }
            

            e.Handled = true;
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    this.InputBox.Text = File.ReadAllText(file);
                    //size = text.Length;
                }
                catch (IOException)
                {
                }
            }
        }

        private void OutputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    File.WriteAllText(file, this.InputBox.Text);
                    //size = text.Length;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
