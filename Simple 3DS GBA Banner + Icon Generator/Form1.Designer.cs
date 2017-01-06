namespace Simple_3DS_GBA_Banner___Icon_Generator
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.aboutButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.romButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.identifiedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.banner2Box = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.banner1Box = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.romBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveImagesDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banner2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(397, 372);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 0;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(12, 372);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(378, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save images to...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // romButton
            // 
            this.romButton.Location = new System.Drawing.Point(13, 343);
            this.romButton.Name = "romButton";
            this.romButton.Size = new System.Drawing.Size(459, 23);
            this.romButton.TabIndex = 3;
            this.romButton.Text = "Load ROM and download image...";
            this.romButton.UseVisualStyleBackColor = true;
            this.romButton.Click += new System.EventHandler(this.romButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.identifiedLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.banner2Box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.banner1Box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.iconBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 307);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previews";
            // 
            // identifiedLabel
            // 
            this.identifiedLabel.AutoSize = true;
            this.identifiedLabel.Location = new System.Drawing.Point(6, 283);
            this.identifiedLabel.Name = "identifiedLabel";
            this.identifiedLabel.Size = new System.Drawing.Size(24, 13);
            this.identifiedLabel.TabIndex = 8;
            this.identifiedLabel.Text = "n/a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Banner 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Identified game : ";
            // 
            // banner2Box
            // 
            this.banner2Box.Location = new System.Drawing.Point(103, 180);
            this.banner2Box.Name = "banner2Box";
            this.banner2Box.Size = new System.Drawing.Size(256, 64);
            this.banner2Box.TabIndex = 4;
            this.banner2Box.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Banner 1";
            // 
            // banner1Box
            // 
            this.banner1Box.Location = new System.Drawing.Point(170, 19);
            this.banner1Box.Name = "banner1Box";
            this.banner1Box.Size = new System.Drawing.Size(128, 128);
            this.banner1Box.TabIndex = 2;
            this.banner1Box.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Icon";
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(58, 70);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(48, 48);
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status : ";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(52, 327);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(92, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "waiting for ROM...";
            // 
            // romBrowseDialog
            // 
            this.romBrowseDialog.DefaultExt = "gba";
            this.romBrowseDialog.Filter = "GBA ROMs|*.gba|Others|*.*";
            this.romBrowseDialog.Title = "Load a GBA ROM...";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 407);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.romButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.aboutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple 3DS GBA Banner + Icon Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banner2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button romButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.PictureBox banner2Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox banner1Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.OpenFileDialog romBrowseDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label identifiedLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.FolderBrowserDialog saveImagesDialog;
    }
}

