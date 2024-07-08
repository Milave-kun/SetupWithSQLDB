namespace SetupWithSQLDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            txtID = new TextBox();
            txtName = new TextBox();
            txtAge = new TextBox();
            btnInsert = new Button();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 92);
            label1.Name = "label1";
            label1.Size = new Size(42, 32);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 149);
            label2.Name = "label2";
            label2.Size = new Size(83, 32);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 207);
            label3.Name = "label3";
            label3.Size = new Size(61, 32);
            label3.TabIndex = 2;
            label3.Text = "Age:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(404, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(363, 380);
            dataGridView1.TabIndex = 3;
            // 
            // txtID
            // 
            txtID.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtID.Location = new Point(154, 89);
            txtID.Name = "txtID";
            txtID.Size = new Size(193, 39);
            txtID.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(154, 149);
            txtName.Name = "txtName";
            txtName.Size = new Size(193, 39);
            txtName.TabIndex = 5;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(154, 207);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(193, 39);
            txtAge.TabIndex = 6;
            // 
            // btnInsert
            // 
            btnInsert.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInsert.Location = new Point(52, 315);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(130, 61);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoad.Location = new Point(217, 315);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(130, 61);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoad);
            Controls.Add(btnInsert);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtAge;
        private Button btnInsert;
        private Button btnLoad;
    }
}
