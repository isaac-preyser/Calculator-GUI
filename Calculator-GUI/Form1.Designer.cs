
namespace Calculator_GUI
{
    partial class CalcWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Output History:");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcWindow));
            this.nmbr1 = new System.Windows.Forms.Button();
            this.nmbr2 = new System.Windows.Forms.Button();
            this.nmbr3 = new System.Windows.Forms.Button();
            this.nmbr4 = new System.Windows.Forms.Button();
            this.nmbr5 = new System.Windows.Forms.Button();
            this.nmbr6 = new System.Windows.Forms.Button();
            this.nmbr7 = new System.Windows.Forms.Button();
            this.nmbr8 = new System.Windows.Forms.Button();
            this.nmbr9 = new System.Windows.Forms.Button();
            this.nmbr0 = new System.Windows.Forms.Button();
            this.operEquals = new System.Windows.Forms.Button();
            this.operAdd = new System.Windows.Forms.Button();
            this.operSubtract = new System.Windows.Forms.Button();
            this.operMult = new System.Windows.Forms.Button();
            this.operDiv = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.negButton = new System.Windows.Forms.Button();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.buttonSqr = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.openCurrencyConv = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.outHistory = new System.Windows.Forms.TreeView();
            this.historyClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.insertDecimal = new System.Windows.Forms.Button();
            this.sinButton = new System.Windows.Forms.Button();
            this.cosButton = new System.Windows.Forms.Button();
            this.tanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nmbr1
            // 
            this.nmbr1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr1.Location = new System.Drawing.Point(14, 63);
            this.nmbr1.Name = "nmbr1";
            this.nmbr1.Size = new System.Drawing.Size(43, 41);
            this.nmbr1.TabIndex = 0;
            this.nmbr1.Text = "1";
            this.nmbr1.UseVisualStyleBackColor = true;
            this.nmbr1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nmbr2
            // 
            this.nmbr2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr2.Location = new System.Drawing.Point(63, 63);
            this.nmbr2.Name = "nmbr2";
            this.nmbr2.Size = new System.Drawing.Size(43, 41);
            this.nmbr2.TabIndex = 1;
            this.nmbr2.Text = "2";
            this.nmbr2.UseVisualStyleBackColor = true;
            this.nmbr2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // nmbr3
            // 
            this.nmbr3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr3.Location = new System.Drawing.Point(112, 63);
            this.nmbr3.Name = "nmbr3";
            this.nmbr3.Size = new System.Drawing.Size(43, 41);
            this.nmbr3.TabIndex = 2;
            this.nmbr3.Text = "3";
            this.nmbr3.UseVisualStyleBackColor = true;
            this.nmbr3.Click += new System.EventHandler(this.button2_Click);
            // 
            // nmbr4
            // 
            this.nmbr4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr4.Location = new System.Drawing.Point(14, 110);
            this.nmbr4.Name = "nmbr4";
            this.nmbr4.Size = new System.Drawing.Size(43, 41);
            this.nmbr4.TabIndex = 3;
            this.nmbr4.Text = "4";
            this.nmbr4.UseVisualStyleBackColor = true;
            this.nmbr4.Click += new System.EventHandler(this.nmbr4_Click);
            // 
            // nmbr5
            // 
            this.nmbr5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr5.Location = new System.Drawing.Point(63, 110);
            this.nmbr5.Name = "nmbr5";
            this.nmbr5.Size = new System.Drawing.Size(43, 41);
            this.nmbr5.TabIndex = 4;
            this.nmbr5.Text = "5";
            this.nmbr5.UseVisualStyleBackColor = true;
            this.nmbr5.Click += new System.EventHandler(this.nmbr5_Click);
            // 
            // nmbr6
            // 
            this.nmbr6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr6.Location = new System.Drawing.Point(112, 110);
            this.nmbr6.Name = "nmbr6";
            this.nmbr6.Size = new System.Drawing.Size(43, 41);
            this.nmbr6.TabIndex = 5;
            this.nmbr6.Text = "6";
            this.nmbr6.UseVisualStyleBackColor = true;
            this.nmbr6.Click += new System.EventHandler(this.nmbr6_Click);
            // 
            // nmbr7
            // 
            this.nmbr7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr7.Location = new System.Drawing.Point(14, 157);
            this.nmbr7.Name = "nmbr7";
            this.nmbr7.Size = new System.Drawing.Size(43, 41);
            this.nmbr7.TabIndex = 6;
            this.nmbr7.Text = "7";
            this.nmbr7.UseVisualStyleBackColor = true;
            this.nmbr7.Click += new System.EventHandler(this.nmbr7_Click);
            // 
            // nmbr8
            // 
            this.nmbr8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr8.Location = new System.Drawing.Point(63, 157);
            this.nmbr8.Name = "nmbr8";
            this.nmbr8.Size = new System.Drawing.Size(43, 41);
            this.nmbr8.TabIndex = 7;
            this.nmbr8.Text = "8";
            this.nmbr8.UseVisualStyleBackColor = true;
            this.nmbr8.Click += new System.EventHandler(this.nmbr8_Click);
            // 
            // nmbr9
            // 
            this.nmbr9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr9.Location = new System.Drawing.Point(112, 157);
            this.nmbr9.Name = "nmbr9";
            this.nmbr9.Size = new System.Drawing.Size(43, 41);
            this.nmbr9.TabIndex = 8;
            this.nmbr9.Text = "9";
            this.nmbr9.UseVisualStyleBackColor = true;
            this.nmbr9.Click += new System.EventHandler(this.nmbr9_Click);
            // 
            // nmbr0
            // 
            this.nmbr0.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmbr0.Location = new System.Drawing.Point(14, 204);
            this.nmbr0.Name = "nmbr0";
            this.nmbr0.Size = new System.Drawing.Size(43, 41);
            this.nmbr0.TabIndex = 9;
            this.nmbr0.Text = "0";
            this.nmbr0.UseVisualStyleBackColor = true;
            this.nmbr0.Click += new System.EventHandler(this.nmbr0_Click);
            // 
            // operEquals
            // 
            this.operEquals.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operEquals.Location = new System.Drawing.Point(112, 204);
            this.operEquals.Name = "operEquals";
            this.operEquals.Size = new System.Drawing.Size(43, 41);
            this.operEquals.TabIndex = 10;
            this.operEquals.Text = "=";
            this.operEquals.UseVisualStyleBackColor = true;
            this.operEquals.Click += new System.EventHandler(this.operEquals_Click);
            // 
            // operAdd
            // 
            this.operAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operAdd.Location = new System.Drawing.Point(161, 63);
            this.operAdd.Name = "operAdd";
            this.operAdd.Size = new System.Drawing.Size(43, 41);
            this.operAdd.TabIndex = 11;
            this.operAdd.Text = "+";
            this.operAdd.UseVisualStyleBackColor = true;
            this.operAdd.Click += new System.EventHandler(this.operAdd_Click);
            // 
            // operSubtract
            // 
            this.operSubtract.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operSubtract.Location = new System.Drawing.Point(161, 110);
            this.operSubtract.Name = "operSubtract";
            this.operSubtract.Size = new System.Drawing.Size(43, 41);
            this.operSubtract.TabIndex = 12;
            this.operSubtract.Text = "-";
            this.operSubtract.UseVisualStyleBackColor = true;
            this.operSubtract.Click += new System.EventHandler(this.operSubtract_Click);
            // 
            // operMult
            // 
            this.operMult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operMult.Location = new System.Drawing.Point(161, 157);
            this.operMult.Name = "operMult";
            this.operMult.Size = new System.Drawing.Size(43, 41);
            this.operMult.TabIndex = 13;
            this.operMult.Text = "x";
            this.operMult.UseVisualStyleBackColor = true;
            this.operMult.Click += new System.EventHandler(this.operMult_Click);
            // 
            // operDiv
            // 
            this.operDiv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operDiv.Location = new System.Drawing.Point(161, 204);
            this.operDiv.Name = "operDiv";
            this.operDiv.Size = new System.Drawing.Size(43, 41);
            this.operDiv.TabIndex = 14;
            this.operDiv.Text = "/";
            this.operDiv.UseVisualStyleBackColor = true;
            this.operDiv.Click += new System.EventHandler(this.operDiv_Click);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.BackColor = System.Drawing.SystemColors.Control;
            this.output.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.ForeColor = System.Drawing.SystemColors.ControlText;
            this.output.Location = new System.Drawing.Point(63, 25);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(102, 17);
            this.output.TabIndex = 15;
            this.output.Text = "placeholder text";
            this.output.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 41);
            this.button1.TabIndex = 16;
            this.button1.Text = "CLR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // negButton
            // 
            this.negButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.negButton.Location = new System.Drawing.Point(210, 63);
            this.negButton.Name = "negButton";
            this.negButton.Size = new System.Drawing.Size(43, 41);
            this.negButton.TabIndex = 17;
            this.negButton.Text = "NEG";
            this.negButton.UseVisualStyleBackColor = true;
            this.negButton.Click += new System.EventHandler(this.negButton_Click);
            // 
            // sqrtButton
            // 
            this.sqrtButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqrtButton.Location = new System.Drawing.Point(210, 157);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(43, 41);
            this.sqrtButton.TabIndex = 18;
            this.sqrtButton.Text = "√";
            this.sqrtButton.UseVisualStyleBackColor = true;
            this.sqrtButton.Click += new System.EventHandler(this.sqrtButton_Click);
            // 
            // buttonSqr
            // 
            this.buttonSqr.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSqr.Location = new System.Drawing.Point(210, 110);
            this.buttonSqr.Name = "buttonSqr";
            this.buttonSqr.Size = new System.Drawing.Size(43, 41);
            this.buttonSqr.TabIndex = 19;
            this.buttonSqr.Text = "x^2";
            this.buttonSqr.UseVisualStyleBackColor = true;
            this.buttonSqr.Click += new System.EventHandler(this.buttonSqr_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(210, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 41);
            this.button2.TabIndex = 20;
            this.button2.Text = "^x";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(259, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 41);
            this.button3.TabIndex = 21;
            this.button3.Text = "RNG";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(259, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 41);
            this.button4.TabIndex = 22;
            this.button4.Text = "π";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // openCurrencyConv
            // 
            this.openCurrencyConv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openCurrencyConv.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCurrencyConv.Location = new System.Drawing.Point(259, 203);
            this.openCurrencyConv.Name = "openCurrencyConv";
            this.openCurrencyConv.Size = new System.Drawing.Size(92, 41);
            this.openCurrencyConv.TabIndex = 23;
            this.openCurrencyConv.Text = "Currency";
            this.openCurrencyConv.UseVisualStyleBackColor = true;
            this.openCurrencyConv.Click += new System.EventHandler(this.openCurrencyConv_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(259, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 41);
            this.button5.TabIndex = 24;
            this.button5.Text = "x!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // outHistory
            // 
            this.outHistory.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.outHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outHistory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.outHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.outHistory.Location = new System.Drawing.Point(362, 25);
            this.outHistory.Name = "outHistory";
            treeNode1.Checked = true;
            treeNode1.Name = "prevOutputs";
            treeNode1.NodeFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Output History:";
            this.outHistory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.outHistory.ShowPlusMinus = false;
            this.outHistory.ShowRootLines = false;
            this.outHistory.Size = new System.Drawing.Size(176, 220);
            this.outHistory.TabIndex = 25;
            this.outHistory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.outHistory_AfterSelect);
            // 
            // historyClear
            // 
            this.historyClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.historyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyClear.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.historyClear.Location = new System.Drawing.Point(489, 221);
            this.historyClear.Name = "historyClear";
            this.historyClear.Size = new System.Drawing.Size(49, 24);
            this.historyClear.TabIndex = 26;
            this.historyClear.Text = "RESET";
            this.historyClear.UseVisualStyleBackColor = false;
            this.historyClear.Click += new System.EventHandler(this.historyClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Calculator-GUI by Isaac Preyser";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // insertDecimal
            // 
            this.insertDecimal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertDecimal.Location = new System.Drawing.Point(63, 204);
            this.insertDecimal.Name = "insertDecimal";
            this.insertDecimal.Size = new System.Drawing.Size(43, 41);
            this.insertDecimal.TabIndex = 28;
            this.insertDecimal.Text = ".";
            this.insertDecimal.UseVisualStyleBackColor = true;
            this.insertDecimal.Click += new System.EventHandler(this.insertDecimal_Click);
            // 
            // sinButton
            // 
            this.sinButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinButton.Location = new System.Drawing.Point(308, 62);
            this.sinButton.Name = "sinButton";
            this.sinButton.Size = new System.Drawing.Size(43, 41);
            this.sinButton.TabIndex = 29;
            this.sinButton.Text = "sin";
            this.sinButton.UseVisualStyleBackColor = true;
            this.sinButton.Click += new System.EventHandler(this.sinButton_Click);
            // 
            // cosButton
            // 
            this.cosButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cosButton.Location = new System.Drawing.Point(308, 109);
            this.cosButton.Name = "cosButton";
            this.cosButton.Size = new System.Drawing.Size(43, 41);
            this.cosButton.TabIndex = 30;
            this.cosButton.Text = "cos ";
            this.cosButton.UseVisualStyleBackColor = true;
            this.cosButton.Click += new System.EventHandler(this.cosButton_Click);
            // 
            // tanButton
            // 
            this.tanButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tanButton.Location = new System.Drawing.Point(308, 156);
            this.tanButton.Name = "tanButton";
            this.tanButton.Size = new System.Drawing.Size(43, 41);
            this.tanButton.TabIndex = 31;
            this.tanButton.Text = "tan";
            this.tanButton.UseVisualStyleBackColor = true;
            this.tanButton.Click += new System.EventHandler(this.tanButton_Click);
            // 
            // CalcWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 273);
            this.Controls.Add(this.tanButton);
            this.Controls.Add(this.cosButton);
            this.Controls.Add(this.sinButton);
            this.Controls.Add(this.insertDecimal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.historyClear);
            this.Controls.Add(this.outHistory);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.openCurrencyConv);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonSqr);
            this.Controls.Add(this.sqrtButton);
            this.Controls.Add(this.negButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.operDiv);
            this.Controls.Add(this.operMult);
            this.Controls.Add(this.operSubtract);
            this.Controls.Add(this.operAdd);
            this.Controls.Add(this.operEquals);
            this.Controls.Add(this.nmbr0);
            this.Controls.Add(this.nmbr9);
            this.Controls.Add(this.nmbr8);
            this.Controls.Add(this.nmbr7);
            this.Controls.Add(this.nmbr6);
            this.Controls.Add(this.nmbr5);
            this.Controls.Add(this.nmbr4);
            this.Controls.Add(this.nmbr3);
            this.Controls.Add(this.nmbr2);
            this.Controls.Add(this.nmbr1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalcWindow";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nmbr1;
        private System.Windows.Forms.Button nmbr2;
        private System.Windows.Forms.Button nmbr3;
        private System.Windows.Forms.Button nmbr4;
        private System.Windows.Forms.Button nmbr5;
        private System.Windows.Forms.Button nmbr6;
        private System.Windows.Forms.Button nmbr7;
        private System.Windows.Forms.Button nmbr8;
        private System.Windows.Forms.Button nmbr9;
        private System.Windows.Forms.Button nmbr0;
        private System.Windows.Forms.Button operEquals;
        private System.Windows.Forms.Button operAdd;
        private System.Windows.Forms.Button operSubtract;
        private System.Windows.Forms.Button operMult;
        private System.Windows.Forms.Button operDiv;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button negButton;
        private System.Windows.Forms.Button sqrtButton;
        private System.Windows.Forms.Button buttonSqr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button openCurrencyConv;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TreeView outHistory;
        private System.Windows.Forms.Button historyClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button insertDecimal;
        private System.Windows.Forms.Button sinButton;
        private System.Windows.Forms.Button cosButton;
        private System.Windows.Forms.Button tanButton;
    }
}

