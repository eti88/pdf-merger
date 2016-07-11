namespace PdfMerger
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
            this.butContinua = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btSofoflia2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSofoflia3 = new System.Windows.Forms.Button();
            this.txtPathBox2 = new System.Windows.Forms.TextBox();
            this.txtPathBox = new System.Windows.Forms.TextBox();
            this.btSfoglia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkMergeLists = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSofoflia4 = new System.Windows.Forms.Button();
            this.txtPathBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btSofoflia5 = new System.Windows.Forms.Button();
            this.txtPathBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butContinua
            // 
            this.butContinua.Location = new System.Drawing.Point(573, 309);
            this.butContinua.Name = "butContinua";
            this.butContinua.Size = new System.Drawing.Size(75, 23);
            this.butContinua.TabIndex = 0;
            this.butContinua.Text = "Continue";
            this.butContinua.UseVisualStyleBackColor = true;
            this.butContinua.Click += new System.EventHandler(this.butContinua_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(478, 309);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 280);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(636, 23);
            this.progressBar.Step = 30;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(12, 244);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(541, 20);
            this.txtOutputPath.TabIndex = 6;
            // 
            // btSofoflia2
            // 
            this.btSofoflia2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSofoflia2.Location = new System.Drawing.Point(573, 241);
            this.btSofoflia2.Name = "btSofoflia2";
            this.btSofoflia2.Size = new System.Drawing.Size(75, 23);
            this.btSofoflia2.TabIndex = 7;
            this.btSofoflia2.Text = "Sfoglia";
            this.btSofoflia2.UseVisualStyleBackColor = true;
            this.btSofoflia2.Click += new System.EventHandler(this.btSofoflia2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dove salvare i pdf uniti:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Percorso cartella Input:";
            // 
            // btSofoflia3
            // 
            this.btSofoflia3.Enabled = false;
            this.btSofoflia3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSofoflia3.Location = new System.Drawing.Point(573, 95);
            this.btSofoflia3.Name = "btSofoflia3";
            this.btSofoflia3.Size = new System.Drawing.Size(75, 23);
            this.btSofoflia3.TabIndex = 11;
            this.btSofoflia3.Text = "Sfoglia";
            this.btSofoflia3.UseVisualStyleBackColor = true;
            this.btSofoflia3.Click += new System.EventHandler(this.btSofoflia3_Click);
            // 
            // txtPathBox2
            // 
            this.txtPathBox2.Enabled = false;
            this.txtPathBox2.Location = new System.Drawing.Point(12, 98);
            this.txtPathBox2.Name = "txtPathBox2";
            this.txtPathBox2.Size = new System.Drawing.Size(541, 20);
            this.txtPathBox2.TabIndex = 10;
            // 
            // txtPathBox
            // 
            this.txtPathBox.Location = new System.Drawing.Point(12, 23);
            this.txtPathBox.Name = "txtPathBox";
            this.txtPathBox.Size = new System.Drawing.Size(541, 20);
            this.txtPathBox.TabIndex = 1;
            // 
            // btSfoglia
            // 
            this.btSfoglia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSfoglia.Location = new System.Drawing.Point(573, 20);
            this.btSfoglia.Name = "btSfoglia";
            this.btSfoglia.Size = new System.Drawing.Size(75, 23);
            this.btSfoglia.TabIndex = 2;
            this.btSfoglia.Text = "Sfoglia";
            this.btSfoglia.UseVisualStyleBackColor = true;
            this.btSfoglia.Click += new System.EventHandler(this.btSfoglia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Percorso cartella Input:";
            // 
            // checkMergeLists
            // 
            this.checkMergeLists.AutoSize = true;
            this.checkMergeLists.Location = new System.Drawing.Point(16, 49);
            this.checkMergeLists.Name = "checkMergeLists";
            this.checkMergeLists.Size = new System.Drawing.Size(103, 17);
            this.checkMergeLists.TabIndex = 13;
            this.checkMergeLists.Text = "Unire file da liste";
            this.checkMergeLists.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkMergeLists.UseVisualStyleBackColor = true;
            this.checkMergeLists.CheckedChanged += new System.EventHandler(this.checkMergeLists_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Percorso cartella Input:";
            // 
            // btSofoflia4
            // 
            this.btSofoflia4.Enabled = false;
            this.btSofoflia4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSofoflia4.Location = new System.Drawing.Point(573, 140);
            this.btSofoflia4.Name = "btSofoflia4";
            this.btSofoflia4.Size = new System.Drawing.Size(75, 23);
            this.btSofoflia4.TabIndex = 15;
            this.btSofoflia4.Text = "Sfoglia";
            this.btSofoflia4.UseVisualStyleBackColor = true;
            this.btSofoflia4.Click += new System.EventHandler(this.btSofoflia4_Click);
            // 
            // txtPathBox3
            // 
            this.txtPathBox3.Enabled = false;
            this.txtPathBox3.Location = new System.Drawing.Point(12, 143);
            this.txtPathBox3.Name = "txtPathBox3";
            this.txtPathBox3.Size = new System.Drawing.Size(541, 20);
            this.txtPathBox3.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Percorso cartella Input:";
            // 
            // btSofoflia5
            // 
            this.btSofoflia5.Enabled = false;
            this.btSofoflia5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSofoflia5.Location = new System.Drawing.Point(573, 186);
            this.btSofoflia5.Name = "btSofoflia5";
            this.btSofoflia5.Size = new System.Drawing.Size(75, 23);
            this.btSofoflia5.TabIndex = 18;
            this.btSofoflia5.Text = "Sfoglia";
            this.btSofoflia5.UseVisualStyleBackColor = true;
            this.btSofoflia5.Click += new System.EventHandler(this.btSofoflia5_Click);
            // 
            // txtPathBox4
            // 
            this.txtPathBox4.Enabled = false;
            this.txtPathBox4.Location = new System.Drawing.Point(12, 189);
            this.txtPathBox4.Name = "txtPathBox4";
            this.txtPathBox4.Size = new System.Drawing.Size(541, 20);
            this.txtPathBox4.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 341);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSofoflia5);
            this.Controls.Add(this.txtPathBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btSofoflia4);
            this.Controls.Add(this.txtPathBox3);
            this.Controls.Add(this.checkMergeLists);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSofoflia3);
            this.Controls.Add(this.txtPathBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSofoflia2);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.btSfoglia);
            this.Controls.Add(this.txtPathBox);
            this.Controls.Add(this.butContinua);
            this.Name = "Form1";
            this.Text = "Pdf Merger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butContinua;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btSofoflia2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSofoflia3;
        private System.Windows.Forms.TextBox txtPathBox2;
        private System.Windows.Forms.TextBox txtPathBox;
        private System.Windows.Forms.Button btSfoglia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkMergeLists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSofoflia4;
        private System.Windows.Forms.TextBox txtPathBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSofoflia5;
        private System.Windows.Forms.TextBox txtPathBox4;
    }
}

