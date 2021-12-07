
//TODO: **DONE**    Make inputtedNumber use int32, and then output label converts to string. 

//TODO: check if List<T>.Insert pushes or overwrites data. Calculate() is messed up.    *Note* it pushes data. I need to delete the entry and then insert in that location. **DONE**

//TODO: rewrite case '=' in Calculate(). It's broken. **FIXED**

//TODO: make output a rounded float, so then outputs can be decimals. **DONE**

//NOTE: Visual Studio 2022's auto code completion is extremely more intuitive than VS2019. I'd highly recommend upgrading to it. 

//TODO: add a 'C' button to clear the memory of the calculator. **DONE**

//TODO: consider automatically clearing saved number if an op is not inputted after a result. same with clear(), and how it outputs "cleared", and when the user inputs the next info, it concatenates onto "cleared" instead of clearing the message. This could be achieved with a bool that is tripped after completing an op, and checks everytime a number is inputted. e.g. 

/*
 * Complete Op- save output to index 0 of saved nums
 * set bool clrOnNewNum to true (make this a global var, or the equivalent in c# so it can be checked everywhere)
 * check on input of new digits if clrOnNewNum is true
 * if true:
 *      clear lists
 *      clear output.label
 *      carry on w/ normal output
 *      
 *      **DONE**
 */

//TODO add negative number identifier to allow for the input of negative numbers. **DONE**

//TODO make said identifier toggleable by the user- e.g. allow the user to turn it on, and reset it without having the click CLR. **DONE**

//TODO make a new method to clear the lists. this is purely quality of life. **DONE**
//TODO add extended math functions. **DONE**
//-----^^ DONE ^^---------- vv TODO vv --------------------------

//TODO: add sin, cos, tan **this would be worthless without a decimal button** 
//TODO: add a decimanl button. 
/*possible implementations:
 * add a button that parses existing values before the decimal and save it to a string. add the next inputted values to the string, after a "." . e.g: input:: 1234, button decimal pressed, save 1234 in a string, add a period/decimal. reflect in the outputlabel. continue accepting inputs, but change the way inputted number is parsed to allow decimals, potenitally using sinlge.parse when complete and op is inputted concat inputted number to saved int and place after the decimal. parse. 
 * 
 * 
 */
//TODO: add a decimal input button. **note this would be a headache to implement because I would have to parse out the decimal point, figure out where it is, and figure out a way to place in the point in the float at the right spot. Maybe I could try multiplying by base 10 values eg 1, .1, .01, .001 etc**

//TODO: implement try/catch to catch unhandled exceptions, and prompt the user to try inputting their calculation again. With WinForms, I am hesitant to put in this work, as the math functions seems to hold their own against things like dividing by 0. 
//TODO: look at ways to port the program to other platforms. **note mono c# transpiler is wildly outdated and does not support many of the newish features I use in this calculator)**
//POSSIBILTITY: Look at reconfiguring the list to hold tuples, that then hold numbers along with their respective ops. This would increase performance, as it would cut the time looking in the lists. However, no person in their right mind is going to try to shove a billion operations down the program in one go, thus reducing the benefits of cutting the big O notation down. This also would increase reliability, as it would reduce the likelihood that an extra number or op gets put into the list. 
//POSSIBILITY: Look at creating  my own data type to bundle together ops and values into one list. 
//POSSIBILITY: Look at reconfiguring the front-end to use WPF instead of WinForms. WPF would require more XML-based knowledge, but this edges ever closer to flutter and other front-end tools so it's better for the industry. However, this comes at the drawback of lost compatability, as it would require .NET 3 or above- alienating platforms below Windows XP SP2. 


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
using System.Net.Http.Headers;
using System.Net.Http;


namespace Calculator_GUI
{
    public partial class CalcWindow : Form
    {
        //globals

        Random rand = new Random();

        //lists that save numbers for the calculator. the first one saves the inputted numbers, the second saves the saved numbers after an operation has been selected. 
        List<float> inputtedNumber = new List<float>(); //this list takes the numbers from the numpad that the user inputs and saves them.
        List<float> savedNumbers = new List<float>();   //this list contains formatted numbers the computer can use in calculations. these numbers are derived from the inputtedNumber by essentially concatenating all the numbers. 
        List<char> pendingOperations = new List<char>();    //this list contains the operations that need to be conducted. The idea behind this is that item 0 of saved numbers will have a corresponding operation at item 0 of this list. Upon clicking equals, the computer will load the first operation, i.e. add, and then load the first and second numbers. it will then perform that operation. then, if there is another operation, it will load the output of the previous operation, and perform it with the next saved number. this chain will repeat until there are no more operations to carry out. 

        char[] charArr;

        bool clrOnNum = false;

        bool isNumNeg = false; //used to check if the negative number button has been clicked. 

        bool firstRun = true;

        bool clrHistOnNextNum = false;

        bool hasDecimalBeenInserted = false;

        string outString = ""; //used for history outputs  


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


        private void ClearLists()
        {
            savedNumbers.Clear();
            pendingOperations.Clear();
            inputtedNumber.Clear();
        }
        
        
        
        public List<float> Cache(float input)
        {

            firstRun = false; // at this point it is not first run. This check is so the neg-number toggle doesnt break if the user starts the program and clicks negative. 
            
            clrOnNum = false; //reset clear on num

            //create list
            
            inputtedNumber.Add(input);

            //add input number to the label

            output.Text += input;
            output.Refresh();


            //output list to be used in other methods. 

            return inputtedNumber;
            

        }

        public void ParseNumber(char oper) /* some of the code in here is redundant */
        {
            clrOnNum = false; //reset clrOnNum

            string concatList = ""; //this is to smush all the numbers together into one string, to then be parsed into a proper number. 

            bool numListCheck = false;


            foreach (var value in charArr) /* lmao this implementation is funny and I was mega small brain 2*/
            {
                if (value == '1' || value == '2' || value == '3' || value == '4' || value == '5' || value == '6' || value == '7' || value == '8' || value == '9' || value == '0' || value == '.' )
                {
                    concatList += Convert.ToString(value);
                }
            }

            float numToAdd = 0;

            if (concatList != "")
            {
                numToAdd = Single.Parse(concatList);

                numListCheck = true;    //checks if this code has been run, so numbers don't get written if there is no number passed into the method. 

            }
            if (isNumNeg == true) 
            { 
                numToAdd *= -1; 
                isNumNeg = false;   
            }
            
            if (numListCheck == true)
            {
                savedNumbers.Add(numToAdd); //saves formatted number from inputtedNumber and saves it in SavedNumbers for calculation later.

            }
             pendingOperations.Add(oper); //saves operation to the op list for calculation later, in this case the final operation.
            inputtedNumber.Clear();
            hasDecimalBeenInserted = false;
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
            

            if (pendingOperations.Count > savedNumbers.Count)
            {
                int amtOfFillNeeded = pendingOperations.Count - savedNumbers.Count;
                for (int i = 0; i < amtOfFillNeeded; i++)
                {
                    savedNumbers.Add(0);
                }
            }

            outString += Convert.ToString(savedNumbers[0]); //always add the first input to the output string. 

            if (oper == '=')
            {

                foreach (var value in pendingOperations) /*   O(n)   */
                {
                    int a = pendingOperations.IndexOf(value); //finds the index of the current operation, to load in the correctly corresponding number value in savedNumbers.
                    int b = a + 1;

                    switch (value)
                    {
                        case '+':
                            workingNumber = savedNumbers[a] + savedNumbers[b];
                            outString += $" + " + savedNumbers[b];
                            savedNumbers.RemoveAt(b);
                            savedNumbers.Insert(b, workingNumber); //insert now worked on number in the location of b, which will be a on the next time through. This allows for operations such as 4 + 5 + 6, by going 4 + 5 = 9, and then 9 + 6 = 15. e.g. savednums: [0] = 4, [1] = 5, [2] = 6, go [0] + [1], save out to [1], then increment so [1] takes the spot of [0], and a new number fills for [1]. 
                            break;
                        case '-':
                            workingNumber = savedNumbers[a] - savedNumbers[b];
                            outString += $" - " + savedNumbers[b]; 
                            savedNumbers.RemoveAt(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case 'x':
                            workingNumber = savedNumbers[a] * savedNumbers[b];
                            outString += $" x " + savedNumbers[b];
                            savedNumbers.RemoveAt(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '/':
                            workingNumber = savedNumbers[a] / savedNumbers[b];
                            outString += $" / " + savedNumbers[b];
                            savedNumbers.RemoveAt(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '^':
                            workingNumber = Convert.ToSingle(Math.Pow(Convert.ToDouble(savedNumbers[a]), Convert.ToDouble(savedNumbers[b])));
                            outString += $" ^ " + savedNumbers[b];
                            savedNumbers.RemoveAt(b);
                            savedNumbers.Insert(b, workingNumber);
                            break;
                        case '=':
                            output.Text = Convert.ToString(workingNumber);
                            savedNumbers.Clear();
                            savedNumbers.Add(workingNumber);    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
                            outString += $" = " + workingNumber;
                            inputtedNumber.Clear();
                            output.Refresh();
                            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                            //reset neg number button
                            isNumNeg = false;
                            negButton.BackColor = Color.Transparent;
                            if (clrHistOnNextNum == true)
                            {
                                outHistory.Nodes.Clear();
                            }
                            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
                            outHistory.ExpandAll();
                            outString = "";
                            hasDecimalBeenInserted = false;
                            break;

                    }
                }
                return;
            }


        }




        public CalcWindow()
        {
            InitializeComponent();
            output.Text = "";
            ToolTip historyWarn = new ToolTip();
            historyWarn.SetToolTip(outHistory, "You must press \"CLR\" in order to start a new calculation with a history item. ");
            historyWarn.AutomaticDelay = 500;
            historyWarn.ReshowDelay = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Local vars.. 
            float number = 1; //not sure if these should really be stored as floats honestly. This might use more memory than is really needed. 


            //this is button one. winforms messed up and named this the wrong thing. 

            //clears the lists and resets the output box if user inputs a number instead of an op when the number is saved after the next operation. (so the user can go 3 + 3 = 6, + 4 = 10. however if the user goes 3 + 3 = 6, then inputs 3 + 4, it won't output 67.)
            if(clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }


            Cache(number);

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //local vars
            float number = 2;



            //this is button 2. same issue as above.

            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float number = 3;

            //button 3

            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr4_Click(object sender, EventArgs e)
        {

            float number = 4;

            //button 4

            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr5_Click(object sender, EventArgs e)
        {

            float number = 5;

            //button 5

            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr6_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 6;


            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr7_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 7;


            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr8_Click(object sender, EventArgs e)
        {
            //local vars
            float number = 8;


            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr9_Click(object sender, EventArgs e)
        {
            //local vars 
            float number = 9;


            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void nmbr0_Click(object sender, EventArgs e)
        {
            //local vars 
            float number = 0;

            //some of the DRY-est code i've ever written
            if (clrOnNum == true)
            {
                ClearLists();
                output.Text = "";
                output.Refresh();
            }

            Cache(number);
        }

        private void operEquals_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '=';

            charArr = output.Text.ToArray();
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Calculate(op);
            pendingOperations.Clear(); //has to be done after the foreach loop that depends on pendingOperations, to be safe. 
            Console.WriteLine("equals done"); //done for debugging, RemoveAt later. 


        }

        private void operAdd_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '+';

            charArr = output.Text.ToArray(); //put number into charArr for parsing later, before the op is added to the screen. 
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("add done"); //done for debugging, remove later. 
        }

        private void operSubtract_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '-';

            charArr = output.Text.ToArray();
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("subtract done"); //done for debugging, remove later. 
        }

        private void operMult_Click(object sender, EventArgs e)
        {
            //local vars
            char op = 'x';

            charArr = output.Text.ToArray();
            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
            Console.WriteLine("multiply done"); //done for debugging, remove later. 
        }
        private void operDiv_Click(object sender, EventArgs e)
        {
            //local vars
            char op = '/';

            charArr = output.Text.ToArray();
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            //CLR Button- clears all data in all lists. 
            inputtedNumber.Clear();
            pendingOperations.Clear();
            savedNumbers.Clear();
            output.Text = "Cleared.";
            output.Refresh();
            clrOnNum = true;
            //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
        }

        private void negButton_Click(object sender, EventArgs e)
        {
            if (isNumNeg == true)
            {
             
                isNumNeg = false;
                negButton.BackColor = Color.Transparent;
                string source = output.Text;
                string replacement = source.TrimStart('-');
                output.Text = replacement;
                output.Refresh();
            } else
            {
                //time to write some terrible code that may or may not work 
                if (firstRun == false) /* this check prevents an unhandled exception, because if the user clicks neg right after starting the program, it will check the 0 index of saved numbers, which at this point doesn't exist, triggering the exception. */
                {
                    try
                    {
                        if (inputtedNumber.Count == 0 && savedNumbers[0] < 0)
                        {
                            //this makes a negative number positive. 
                            savedNumbers[0] *= -1; //this should only activate if an output has been delivered, and the user wants to invert it. 
                            Console.WriteLine("Inverted!"); //done for debugging, remove later.
                            isNumNeg = false;
                            negButton.BackColor = Color.Transparent;
                            output.Text = Convert.ToString(savedNumbers[0]);
                            output.Refresh();
                            return; //do not run below code. 
                        }
                        if (inputtedNumber.Count == 0 && savedNumbers[0] > 0) /*  a continuation of the above shoddy code  */
                        {
                            //this makes a positive number positive. 
                            savedNumbers[0] *= -1; //this should only activate if an output has been delivered, and the user wants to invert it.
                            Console.WriteLine("Inverted!"); //done for debugging, remove later.
                            isNumNeg = false;   //DO NOT SET THIS TO TRUE! or else it will force the next inputted number to be inverted. 
                            negButton.BackColor = Color.LightGray; //however, light up the neg button to give the user the illusion they did something. 
                            output.Text = Convert.ToString(savedNumbers[0]);
                            output.Refresh();
                            return; //don't run below code. 
                        }
                    }
                    catch
                    {
                        output.Text = "An error occured while trying to carry out that action, please try again.";
                        ClearLists();
                    }
                }   
                isNumNeg = true;
                negButton.BackColor = Color.LightGray;
                output.Text = "-" + output.Text;
                output.Refresh();
            }
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {

            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
               workingNmbr = Single.Parse(output.Text);
            }
            double result = Math.Sqrt(workingNmbr);
            outString = $"sqrt(" + workingNmbr + ")=" + result;
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
                workingNmbr = Single.Parse(output.Text);
            }

            double result = Math.Pow(workingNmbr, 2);
            outString = $"sqr(" + workingNmbr + ")=" + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            //^x button

            //local vars
            char op = '^';


            output.Text = $"{op}";
            output.Refresh();
            ParseNumber(op);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RNG button
            double result = rand.Next(0,2048);

            //ripped from case '=' in calculate
            outString = $"RNG = " + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            double result = Math.PI;

            //ripped from case '=' in calculate
            outString = $"Pi = " + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void openCurrencyConv_Click(object sender, EventArgs e)
        {
            this.Hide();
            CurrencyConv form = new CurrencyConv();
            form.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //factorial button 
            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
                workingNmbr = Single.Parse(output.Text);
            }
            decimal num = Convert.ToDecimal(workingNmbr); 
            decimal n = num;
            try
            {
                for (decimal i = n - 1; i > 0; i--)
                {
                    n *= i;
                }
            } catch
            {
                output.Text = "The inputted number was too large to calculate.";
            }
            

            //using a decimal as a means to store larger numbers (96-bit decimal comapared to 64-bit long)
            decimal result = n; //this easily leads to integer overflows, could implement system.numerics datatype BigInt to have theoreticaly infinite room, at the cost of more memory usage.   
            outString = $""+workingNmbr+"! = " + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void outHistory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedHistory = Convert.ToString(e.Node.Text).Trim('{', '}');
            string[] trimmed = selectedHistory.Split(' ');

            try{    
                float selected = Single.Parse(trimmed.Last());
                inputtedNumber.Clear();
                output.Text = trimmed.Last(); //note if you want to begin a new calculation using a saved number, YOU MUST PRESS CLEAR.
                savedNumbers.Add(selected);
            }
            catch
            {
                output.Text= "An error occured. Please try your calculation again.";
                ClearLists();
            }
            



        }

        private void historyClear_Click(object sender, EventArgs e)
        {
            outHistory.Nodes.Clear();
            outHistory.Nodes.Add("Cleared!");
            clrHistOnNextNum = true;    
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void insertDecimal_Click(object sender, EventArgs e)
        {
            if (hasDecimalBeenInserted == false)
            {
                output.Text += '.';
                hasDecimalBeenInserted = true;
            }
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
                workingNmbr = Single.Parse(output.Text);
            }

            double result = Math.Sin(workingNmbr);
            outString = $"sin(" + workingNmbr + ")=" + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
                workingNmbr = Single.Parse(output.Text);
            }

            double result = Math.Cos(workingNmbr);
            outString = $"cos(" + workingNmbr + ")=" + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            float workingNmbr = 0;
            if (output.Text.Length > 0)
            {
                workingNmbr = Single.Parse(output.Text);
            }

            double result = Math.Tan(workingNmbr);
            outString = $"tan(" + workingNmbr + ")=" + result;
            if (clrHistOnNextNum == true)
            {
                outHistory.Nodes.Clear();
            }
            outHistory.Nodes.Add(new TreeNode(Convert.ToString(outString)));
            outHistory.ExpandAll();
            //ripped from case '=' in calculate

            output.Text = Convert.ToString(result);
            savedNumbers.Clear();
            savedNumbers.Add(Convert.ToSingle(result));    //clears savedNumbers, and saves the output as the first number, so one could go 1+1 = 2, and then go +3 = and recieve 5. TODO: add a CLEAR button.
            inputtedNumber.Clear();
            output.Refresh();
            clrOnNum = true; //setup for auto-clearing if user begins inputting a new calculation immediately. 
                             //reset neg number button
            isNumNeg = false;
            negButton.BackColor = Color.Transparent;
            hasDecimalBeenInserted = false;
        }
    }
}
