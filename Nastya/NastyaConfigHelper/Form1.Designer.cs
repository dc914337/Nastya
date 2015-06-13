namespace NastyaConfigHelper
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.thresholdNud = new System.Windows.Forms.NumericUpDown();
            this.wordSequencesResultRtb = new System.Windows.Forms.RichTextBox();
            this.genSeqBtn = new System.Windows.Forms.Button();
            this.orderedCbx = new System.Windows.Forms.CheckBox();
            this.wordsTxt = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNud)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 430);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.thresholdNud);
            this.tabPage1.Controls.Add(this.wordSequencesResultRtb);
            this.tabPage1.Controls.Add(this.genSeqBtn);
            this.tabPage1.Controls.Add(this.orderedCbx);
            this.tabPage1.Controls.Add(this.wordsTxt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(484, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sequence";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comparer threshold:";
            // 
            // thresholdNud
            // 
            this.thresholdNud.DecimalPlaces = 3;
            this.thresholdNud.Location = new System.Drawing.Point(357, 31);
            this.thresholdNud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thresholdNud.Name = "thresholdNud";
            this.thresholdNud.Size = new System.Drawing.Size(120, 20);
            this.thresholdNud.TabIndex = 4;
            this.thresholdNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // wordSequencesResultRtb
            // 
            this.wordSequencesResultRtb.Location = new System.Drawing.Point(6, 55);
            this.wordSequencesResultRtb.Name = "wordSequencesResultRtb";
            this.wordSequencesResultRtb.Size = new System.Drawing.Size(475, 343);
            this.wordSequencesResultRtb.TabIndex = 3;
            this.wordSequencesResultRtb.Text = "";
            // 
            // genSeqBtn
            // 
            this.genSeqBtn.Location = new System.Drawing.Point(344, 4);
            this.genSeqBtn.Name = "genSeqBtn";
            this.genSeqBtn.Size = new System.Drawing.Size(133, 23);
            this.genSeqBtn.TabIndex = 2;
            this.genSeqBtn.Text = "Add sequence";
            this.genSeqBtn.UseVisualStyleBackColor = true;
            this.genSeqBtn.Click += new System.EventHandler(this.genSeqBtn_Click);
            // 
            // orderedCbx
            // 
            this.orderedCbx.AutoSize = true;
            this.orderedCbx.Location = new System.Drawing.Point(8, 32);
            this.orderedCbx.Name = "orderedCbx";
            this.orderedCbx.Size = new System.Drawing.Size(64, 17);
            this.orderedCbx.TabIndex = 1;
            this.orderedCbx.Text = "Ordered";
            this.orderedCbx.UseVisualStyleBackColor = true;
            // 
            // wordsTxt
            // 
            this.wordsTxt.Location = new System.Drawing.Point(8, 6);
            this.wordsTxt.Name = "wordsTxt";
            this.wordsTxt.Size = new System.Drawing.Size(330, 20);
            this.wordsTxt.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 442);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox wordSequencesResultRtb;
        private System.Windows.Forms.Button genSeqBtn;
        private System.Windows.Forms.CheckBox orderedCbx;
        private System.Windows.Forms.TextBox wordsTxt;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown thresholdNud;
    }
}

