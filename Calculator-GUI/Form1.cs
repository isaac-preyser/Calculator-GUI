using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Calculator_GUI
{
    public partial class Form1 : Form
    {
        //lists that save numbers for the calculator. the first one saves the inputted numbers, the second saves the saved numbers after an operation has been selected. 
        List<float> inputtedNumber = new List<float>(); //this list takes the numbers from the numpad that the user inputs and saves them.

        //TODO: **DONE**    Make inputtedNumber use int32, and then output label converts to string. 
        //TODO: check if List<T>.Insert pushes or overwrites data. Calculate() is messed up.    *Note* it pushes data. I need to delete the entry and then insert in that location. **DONE**
        //TODO: rewrite case '=' in Calculate(). It's broken. **FIXED**
        //TODO: make output a rounded float, so then outputs can be decimals. **DONE**
        //TODO: add a 'C' button to clear the memory of the calculator. 
        //TODO add extended math functions. 



        List<float> savedNumbers = new List<float>();   //this list contains formatted numbers the computer can use in calculations. these numbers are derived from the inputtedNumber by essentially concatenating all the numbers. 
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


        public List<float> Cache(float input)
        {


            //create list
            
            inputtedNumber.Add(input);

            //add input number to the label

            output.Text += input;
            output.Refresh();


            //output list to be used in other methods. 

            return inputtedNumber;
            

        }

        public void ParseNumber(char oper)
        {
            string concatList = ""; //this is to smush all the numbers together into one string, to then be parsed into a proper number. 

            bool numListCheck = false;

            foreach (var value in inputtedNumber)
            {
                concatList += Convert.ToString(value);

            }

            float numToAdd = 0;

            if (concatList != "")
            {
                numToAdd = Single.Parse(concatList);

                numListCheck = true;    //checks if this code has been run, so numbers don't get written if there is no number passed into the method. 

            }
            if (numListCheck == true)
            {
                savedNumbers.Add(numToAdd); //saves formatted number from inputtedNumber and saves it in SavedNumbers for calculation later.

            }
             pendingOperations.Add(oper); //saves operation to the op list for calculation later, in this case the final operation.
            inputtedNumber.Clear();
        }


        public void Calculate(char oper)
        {
            //this method is to be run if the cache method detects an operator; this method will detect which operator it is, and point it to the correct operation. This method will also store the inputted number as one, to be properly manipulated by the System.Math class. 


            /*
             * Design for Calculate()-
             *  initalize working number, for calculations later
             *  run ParseNumber(), which turns the list of characters in inputtedNumber into a string and then into an integer in savedNumbers. It also saves the appropriate operation to the pendingOperations list, at the corresponding index. 
             *
             *  for each saved value in pendingOperations:  
             *                                              initalize vars a and b, they serve as the pointers that tell the computer to look at a certain index of both lists. 
             *                                              they help keep track of where the output of our work goes.
             *                                              enter into a switch statement, where the character value of var value (the current location in pendingOperations we are)
             *                                              is read, and the corresponding operation based on the symbol is carried out.
             *                                              next, remove the saved value at index b. (this will become location a for the next run through.)
             *                                              save the output of the work carried out previously at index b.
             *                                              repeat this until case '=' is true, where the current output of the last operation is displayed, and the loop is stopped. Following this, clear all lists and save the worked number at index 0 of next savednumbers. 
             * 
             * 
             * 
             * 
             */

            //as of right now, this method is broken.

            float workingNumber = 0;

            
            
            if (oper == '=')
            {

                foreach (var value in pendingOperations)
                {
                    int a = pendingOperations.IndexOf(value); //finds the index of the current operation, to load in the correctly corresponding number value in savedNumbers.
                    int b = a + 1;

                    switch (value)
                    {
                        case '+':
                            workingNumber = savedNumbers[a] + savedNumbers[b];
                            savedNumbers.Remove(b);
                            savedNumbers.Insert(b, workingNumber); //insert now worked on number in the location of b, which will be a on the next time through. This allows for operations such as 4 + 5 + 6, by going 4 + 5 = 9, and then 9 + 6 = 15.
                            break;
                        case '-':
                            workingNumber = savedNumbers[a] - savedNumbers[b];
                            savedNumbers.Remove(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case 'x':
                            workingNumber = savedNumbers[a] * savedNumbers[b];
                            savedNumbers.Remove(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '/':
                            workingNumber = savedNumbers[a] / savedNumbers[b];
                            savedNumbers.Remove(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '=': 
                            output.Text = Convert.ToString(workingNumber);
                            savedNumbers.Clear();
                            savedNumbers.Add(workingNumber);    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
                            inputtedNumber.Clear();
                            output.Refresh();
                            break;

                    }
                }
                return;
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
            float number = 1;


            //this is button one. winforms messed up and named this the wrong thing. 

            Cache(number);

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //local vars
            float number = 2;

            //this is button 2. same issue as above.
            Cache(number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float number = 3;

            //button 3
            Cache(number);
        }

        private void nmbr4_Click(object sender, EventArgs e)
        {

            float number = 4;

            //button 4
            Cache(number);
        }

        private void nmbr5_Click(object sender, EventArgs e)
        {

            float number = 5;

            //button 5
            Cache(number);
        }

        private void nmbr6_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 6;

            Cache(number);
        }

        private void nmbr7_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 7;

            Cache(number);
        }

        private void nmbr8_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 8;

            Cache(number);
        }

        private void nmbr9_Click(object sender, EventArgs e)
        {
            //local vars 
            float number = 9;

            Cache(number);
        }

        private void nmbr0_Click(object sender, EventArgs e)
        {
            //local vars 
            float number = 0;

            Cache(number);
        }

        private void operEquals_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '=';

            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Calculate(op);
            pendingOperations.Clear(); //has to be done after the foreach loop that depends on pendingOperations, to be safe. 
            Console.WriteLine("equals done"); //done for debugging, remove later. 


        }

        private void operAdd_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '+';

            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("add done"); //done for debugging, remove later. 
        }

        private void operSubtract_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '-';

            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("subtract done"); //done for debugging, remove later. 
        }

        private void operMult_Click(object sender, EventArgs e)
        {
            //local vars
            char op = 'x';
            
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("multiply done"); //done for debugging, remove later. 
        }
        private void operDiv_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '/';
            
            
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("divide done"); //done for debugging, remove later. 
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //do nothing on label click, this should only be used for outputting numbers. possibly could be used as a clear function. 
            return;
        }
    }
}
