namespace Lime
{
    partial class filterWorkers
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
            this.dataGridViewDirectory = new System.Windows.Forms.DataGridView();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDirectory
            // 
            this.dataGridViewDirectory.AllowUserToAddRows = false;
            this.dataGridViewDirectory.AllowUserToDeleteRows = false;
            this.dataGridViewDirectory.AllowUserToOrderColumns = true;
            this.dataGridViewDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDirectory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDirectory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDirectory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDirectory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDirectory.Location = new System.Drawing.Point(39, 28);
            this.dataGridViewDirectory.Margin = new System.Windows.Forms.Padding(30, 3, 0, 3);
            this.dataGridViewDirectory.Name = "dataGridViewDirectory";
            this.dataGridViewDirectory.RowHeadersVisible = false;
            this.dataGridViewDirectory.RowHeadersWidth = 51;
            this.dataGridViewDirectory.RowTemplate.Height = 24;
            this.dataGridViewDirectory.ShowCellErrors = false;
            this.dataGridViewDirectory.ShowCellToolTips = false;
            this.dataGridViewDirectory.ShowEditingIcon = false;
            this.dataGridViewDirectory.ShowRowErrors = false;
            this.dataGridViewDirectory.Size = new System.Drawing.Size(1392, 710);
            this.dataGridViewDirectory.TabIndex = 3;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(1461, 28);
            this.button_save.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(185, 33);
            this.button_save.TabIndex = 11;
            this.button_save.Text = "ОК";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1461, 118);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 581);
            this.textBox1.TabIndex = 12;
            this.textBox1.Visible = false;
            // 
            // filterWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 763);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dataGridViewDirectory);
            this.Name = "filterWorkers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подобрать команду";
            this.Load += new System.EventHandler(this.filterWorkers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDirectory;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox1;
    }
}