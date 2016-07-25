namespace Sharp_File_Parser
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMeta = new System.Windows.Forms.TabPage();
            this.tabGameState = new System.Windows.Forms.TabPage();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.txtGameState = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMeta.SuspendLayout();
            this.tabGameState.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Browser";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(7, 19);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(662, 23);
            this.txtFileName.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(675, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 478);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File View";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMeta);
            this.tabControl1.Controls.Add(this.tabGameState);
            this.tabControl1.Location = new System.Drawing.Point(7, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMeta
            // 
            this.tabMeta.Controls.Add(this.txtMeta);
            this.tabMeta.Location = new System.Drawing.Point(4, 24);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeta.Size = new System.Drawing.Size(739, 422);
            this.tabMeta.TabIndex = 0;
            this.tabMeta.Text = "Meta";
            this.tabMeta.UseVisualStyleBackColor = true;
            // 
            // tabGameState
            // 
            this.tabGameState.Controls.Add(this.txtGameState);
            this.tabGameState.Location = new System.Drawing.Point(4, 24);
            this.tabGameState.Name = "tabGameState";
            this.tabGameState.Padding = new System.Windows.Forms.Padding(3);
            this.tabGameState.Size = new System.Drawing.Size(739, 422);
            this.tabGameState.TabIndex = 1;
            this.tabGameState.Text = "Game State";
            this.tabGameState.UseVisualStyleBackColor = true;
            // 
            // txtMeta
            // 
            this.txtMeta.Location = new System.Drawing.Point(7, 7);
            this.txtMeta.Multiline = true;
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.ReadOnly = true;
            this.txtMeta.Size = new System.Drawing.Size(726, 409);
            this.txtMeta.TabIndex = 0;
            // 
            // txtGameState
            // 
            this.txtGameState.Location = new System.Drawing.Point(7, 7);
            this.txtGameState.Name = "txtGameState";
            this.txtGameState.ReadOnly = true;
            this.txtGameState.Size = new System.Drawing.Size(726, 409);
            this.txtGameState.TabIndex = 0;
            this.txtGameState.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharp File Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.tabMeta.PerformLayout();
            this.tabGameState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeta;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.TabPage tabGameState;
        private System.Windows.Forms.RichTextBox txtGameState;
    }
}

