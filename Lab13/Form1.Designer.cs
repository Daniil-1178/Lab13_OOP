namespace Lab13
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.txtCurrentPath = new System.Windows.Forms.TextBox();
            this.btnGoUp = new System.Windows.Forms.Button();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.txtFilterFolders = new System.Windows.Forms.TextBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.txtFilterFiles = new System.Windows.Forms.TextBox();
            this.rtbInfoAndContent = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDrives.TabIndex = 0;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            // 
            // txtCurrentPath
            // 
            this.txtCurrentPath.Location = new System.Drawing.Point(12, 60);
            this.txtCurrentPath.Name = "txtCurrentPath";
            this.txtCurrentPath.ReadOnly = true;
            this.txtCurrentPath.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPath.TabIndex = 1;
            // 
            // btnGoUp
            // 
            this.btnGoUp.Location = new System.Drawing.Point(139, 11);
            this.btnGoUp.Name = "btnGoUp";
            this.btnGoUp.Size = new System.Drawing.Size(75, 23);
            this.btnGoUp.TabIndex = 2;
            this.btnGoUp.Text = "Назад";
            this.btnGoUp.UseVisualStyleBackColor = true;
            this.btnGoUp.Click += new System.EventHandler(this.btnGoUp_Click);
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.Location = new System.Drawing.Point(12, 97);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(244, 199);
            this.listBoxFolders.TabIndex = 3;
            this.listBoxFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFolders_SelectedIndexChanged);
            this.listBoxFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFolders_MouseDoubleClick);
            // 
            // txtFilterFolders
            // 
            this.txtFilterFolders.Location = new System.Drawing.Point(12, 302);
            this.txtFilterFolders.Name = "txtFilterFolders";
            this.txtFilterFolders.Size = new System.Drawing.Size(244, 20);
            this.txtFilterFolders.TabIndex = 4;
            this.txtFilterFolders.TextChanged += new System.EventHandler(this.txtFilterFolders_TextChanged);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(275, 97);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(244, 199);
            this.listBoxFiles.TabIndex = 5;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // txtFilterFiles
            // 
            this.txtFilterFiles.Location = new System.Drawing.Point(275, 302);
            this.txtFilterFiles.Name = "txtFilterFiles";
            this.txtFilterFiles.Size = new System.Drawing.Size(244, 20);
            this.txtFilterFiles.TabIndex = 6;
            this.txtFilterFiles.TextChanged += new System.EventHandler(this.txtFilterFiles_TextChanged);
            // 
            // rtbInfoAndContent
            // 
            this.rtbInfoAndContent.Location = new System.Drawing.Point(12, 344);
            this.rtbInfoAndContent.Name = "rtbInfoAndContent";
            this.rtbInfoAndContent.Size = new System.Drawing.Size(265, 94);
            this.rtbInfoAndContent.TabIndex = 7;
            this.rtbInfoAndContent.Text = "";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(535, 97);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(229, 199);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 8;
            this.pictureBoxPreview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.rtbInfoAndContent);
            this.Controls.Add(this.txtFilterFiles);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.txtFilterFolders);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.btnGoUp);
            this.Controls.Add(this.txtCurrentPath);
            this.Controls.Add(this.comboBoxDrives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.TextBox txtCurrentPath;
        private System.Windows.Forms.Button btnGoUp;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.TextBox txtFilterFolders;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.TextBox txtFilterFiles;
        private System.Windows.Forms.RichTextBox rtbInfoAndContent;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}

