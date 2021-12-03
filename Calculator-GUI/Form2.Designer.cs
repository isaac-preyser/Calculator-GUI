
namespace Calculator_GUI
{
    partial class CurrencyConv
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
            this.toLabel = new System.Windows.Forms.Label();
            this.openCalc = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.testOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(161, 80);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(16, 13);
            this.toLabel.TabIndex = 0;
            this.toLabel.Text = "to";
            this.toLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // openCalc
            // 
            this.openCalc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCalc.Location = new System.Drawing.Point(175, 208);
            this.openCalc.Name = "openCalc";
            this.openCalc.Size = new System.Drawing.Size(97, 41);
            this.openCalc.TabIndex = 24;
            this.openCalc.Text = "Calculator";
            this.openCalc.UseVisualStyleBackColor = true;
            this.openCalc.Click += new System.EventHandler(this.openCalc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // convertButton
            // 
            this.convertButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertButton.Location = new System.Drawing.Point(238, 53);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(103, 65);
            this.convertButton.TabIndex = 26;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(111, 97);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 27;
            // 
            // testOutput
            // 
            this.testOutput.AutoSize = true;
            this.testOutput.Location = new System.Drawing.Point(488, 80);
            this.testOutput.Name = "testOutput";
            this.testOutput.Size = new System.Drawing.Size(56, 13);
            this.testOutput.TabIndex = 28;
            this.testOutput.Text = "testOutput";
            // 
            // CurrencyConv
            // 
            this.ClientSize = new System.Drawing.Size(767, 278);
            this.Controls.Add(this.testOutput);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.openCalc);
            this.Controls.Add(this.toLabel);
            this.Name = "CurrencyConv";
            this.Text = "CurrencyConv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Button openCalc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label testOutput;
    }
}