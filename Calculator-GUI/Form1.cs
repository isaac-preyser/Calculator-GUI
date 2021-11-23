using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator_GUI
{
    public partial class Form1 : Form
    {
        //lists that save numbers for the calculator. the first one saves the inputted numbers, the second saves the saved numbers after an operation has been selected. 
        List<int> inputtedNumber = new List<int>(); //this list takes the numbers from the numpad that the user inputs and saves them.

        //TODO: Make inputtedNumber use int32, and then output label converts to string.
        //TODO: check if List<T>.Insert pushes or overwrites data. Calculate() is messed up. 
        //TODO: rewrite case '=' in Calculate(). It's broken. 

        List<int> savedNumbers = new List<int>();   //this list contains formatted numbers the computer can use in calculations. these numbers are derived from the inputtedNumber by essentially concatenating all the numbers. 
        List<char> pendingOperations = new List<char>();    //this list contains the operations that need to be conducted. The idea behind this is that item 0 of saved numbers will have a corresponding operation at item 0 of this list. Upon clicking equals, the computer will load the first operation, i.e. add, and then load the first and second numbers. it will then perform that operation. then, if there is another operation, it will load the output of the previous operation, and perform it with the next saved number. this chain will repeat until there are no more operations to carry out. 

        //should look like: 
        /*
         * Read: pendingOps[i] .... == '+'
         * Perform Math.Add on savedNumbers[i] and savedNumbers[i + 1] 
         * Output: = sum of savedNumbers i and i+1, save to output variable
         * i++
         * Read: next pendingOps ... == '-'
         * Perform Math.Subtract on output and savedNumbers[i+1]
         * Output: some output, save to output variable
         * i++
         * Read next pendingOps ... == '='
         * Perform no task- display current output to label. 
         * loop ends- '=' is always last in the op list. 
         * 
         */


        public List<int> Cache(int input)
        {


            //create list
            
            inputtedNumber.Add(input);

            //add input number to the label

            output.Text += input;
            output.Refresh();


            //output list to be used in other methods. 

            return inputtedNumber;
            

        }

        public void Calculate(char oper)
        {
            //this method is to be run if the cache method detects an operator; this method will detect which operator it is, and point it to the correct operation. This method will also store the inputted number as one, to be properly manipulated by the System.Math class. 

            //as of right now, this method is broken.

            int workingNumber = 0;

            string concatList = ""; //this is to smush all the numbers together into one string, to then be parsed into a proper number. 



            if (oper == '=')
            {
                foreach (var value in inputtedNumber)
                {
                    concatList += Convert.ToString(value);

                }

                int numToAdd;
                if (concatList != "")
                {
                    numToAdd = Int32.Parse(concatList);

                } else
                {
                    numToAdd = 0;
                }
                savedNumbers.Add(numToAdd); //saves formatted number from inputtedNumber and saves it in SavedNumbers for calculation later.
                pendingOperations.Add('='); //saves operation to the op list for calculation later, in this case the final operation.
                inputtedNumber.Clear(); 

                foreach (var value in pendingOperations)
                {
                    int a = pendingOperations.IndexOf(value); //finds the index of the current operation, to load in the correctly corresponding number value in savedNumbers.
                    int b = a + 1;

                    switch (value)
                    {
                        case '+':
                            workingNumber = savedNumbers[a] + savedNumbers[b];
                            savedNumbers.Insert(b, workingNumber); //insert now worked on number in the location of b, which will be a on the next time through. This allows for operations such as 4 + 5 + 6, by going 4 + 5 = 9, and then 9 + 6 = 15.
                            break;
                        case '-':
                            workingNumber = savedNumbers[a] - savedNumbers[b];
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case 'x':
                            workingNumber = savedNumbers[a] * savedNumbers[b];
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '/':
                            workingNumber = savedNumbers[a] / savedNumbers[b];
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '=': 
                            output.Text = Convert.ToString(workingNumber);
                            savedNumbers.Clear();
                            savedNumbers.Add(workingNumber);    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
                            inputtedNumber.Clear();
                            pendingOperations.Clear();
                            
                            
                            output.Refresh();
                            return;



                    }





                }
                return;
            }

            if (oper == '+')
            {
                foreach (var value in inputtedNumber)
                {
                    concatList += Convert.ToString(value);

                }

                int numToAdd;
                if (concatList != "")
                {
                    numToAdd = Int32.Parse(concatList);

                }
                else
                {
                    numToAdd = 0;
                }
                savedNumbers.Add(numToAdd); //saves formatted number from inputtedNumber and saves it in SavedNumbers for calculation later.
                pendingOperations.Add('+'); //saves operation to the op list for calculation later.
                inputtedNumber.Clear();
                return;

            }


            if (oper == '-')
            {
                return;
            }


            if (oper == 'x')
            {
                return;
            }

            if (oper == '/')
            {
                return; 
            } else
            {
                throw new Exception("the inputted operation was has not been coded yet, or the operation is not possible");
            }
        }




        public Form1()
        {
            InitializeComponent();
            output.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Local vars.. 
            int number = 1;


            //this is button one. winforms messed up and named this the wrong thing. 

            Cache(number);

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //local vars
            int number = 2;

            //this is button 2. same issue as above.
            Cache(number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number = 3;

            //button 3
            Cache(number);
        }

        private void nmbr4_Click(object sender, EventArgs e)
        {

            int number = 4;

            //button 4
            Cache(number);
        }

        private void nmbr5_Click(object sender, EventArgs e)
        {

            int number = 5;

            //button 5
            Cache(number);
        }

        private void nmbr6_Click(object sender, EventArgs e)
        {
            //local vars
            int number = 6;

            Cache(number);
        }

        private void nmbr7_Click(object sender, EventArgs e)
        {
            //local vars
            int number = 7;

            Cache(number);
        }

        private void nmbr8_Click(object sender, EventArgs e)
        {
            //local vars
            int number = 8;

            Cache(number);
        }

        private void nmbr9_Click(object sender, EventArgs e)
        {
            //local vars 
            int number = 9;

            Cache(number);
        }

        private void nmbr0_Click(object sender, EventArgs e)
        {
            //local vars 
            int number = 0;

            Cache(number);
        }

        private void operEquals_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '=';

            output.Text = $"{op}";
            output.Refresh();
            Calculate(op);
            


        }

        private void operAdd_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '+';

            output.Text = $"{op}";
            output.Refresh();
            Calculate(op);
        }

        private void operSubtract_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '-';

            output.Text = $"{op}";
            output.Refresh();
        }

        private void operMult_Click(object sender, EventArgs e)
        {
            //local vars
            char op = 'x';
            
            output.Text = $"{op}";
            output.Refresh();
        }
        private void operDiv_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '/';
            
            
            output.Text = $"{op}";
            output.Refresh();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //do nothing on label click, this should only be used for outputting numbers. possibly could be used as a clear function. 
            return;
        }
    }
}
