namespace FindArt
{
    partial class FileDialog
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rdbtnDir = new System.Windows.Forms.RadioButton();
            this.rdbtbnItunes = new System.Windows.Forms.RadioButton();
            this.gboxOptions = new System.Windows.Forms.GroupBox();
            this.gboxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(16, 88);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(354, 20);
            this.txtFile.TabIndex = 0;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(12, 9);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(298, 20);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "Music Directory / iTunes Library File:";
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(91, 114);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(90, 35);
            this.btnBegin.TabIndex = 2;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(222, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(377, 86);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // rdbtnDir
            // 
            this.rdbtnDir.AutoSize = true;
            this.rdbtnDir.Checked = true;
            this.rdbtnDir.Location = new System.Drawing.Point(6, 10);
            this.rdbtnDir.Name = "rdbtnDir";
            this.rdbtnDir.Size = new System.Drawing.Size(98, 17);
            this.rdbtnDir.TabIndex = 5;
            this.rdbtnDir.TabStop = true;
            this.rdbtnDir.Text = "Music Directory";
            this.rdbtnDir.UseMnemonic = false;
            this.rdbtnDir.UseVisualStyleBackColor = true;
            // 
            // rdbtbnItunes
            // 
            this.rdbtbnItunes.AutoSize = true;
            this.rdbtbnItunes.Location = new System.Drawing.Point(6, 33);
            this.rdbtbnItunes.Name = "rdbtbnItunes";
            this.rdbtbnItunes.Size = new System.Drawing.Size(110, 17);
            this.rdbtbnItunes.TabIndex = 6;
            this.rdbtbnItunes.Text = "iTunes Library File";
            this.rdbtbnItunes.UseVisualStyleBackColor = true;
            // 
            // gboxOptions
            // 
            this.gboxOptions.Controls.Add(this.rdbtnDir);
            this.gboxOptions.Controls.Add(this.rdbtbnItunes);
            this.gboxOptions.Location = new System.Drawing.Point(16, 32);
            this.gboxOptions.Name = "gboxOptions";
            this.gboxOptions.Size = new System.Drawing.Size(294, 51);
            this.gboxOptions.TabIndex = 7;
            this.gboxOptions.TabStop = false;
            // 
            // FileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 155);
            this.Controls.Add(this.gboxOptions);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFile);
            this.Name = "FileDialog";
            this.Text = "Select how to find your music";
            this.gboxOptions.ResumeLayout(false);
            this.gboxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rdbtnDir;
        private System.Windows.Forms.RadioButton rdbtbnItunes;
        private System.Windows.Forms.GroupBox gboxOptions;
    }
}