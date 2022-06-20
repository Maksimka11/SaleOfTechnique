namespace SaleOfTechnique
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.btnTr1 = new System.Windows.Forms.Button();
            this.btnTr2 = new System.Windows.Forms.Button();
            this.btnTr3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.btnCl1 = new System.Windows.Forms.Button();
            this.btnCl2 = new System.Windows.Forms.Button();
            this.btnCl3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTechnique = new System.Windows.Forms.DataGridView();
            this.btnTech1 = new System.Windows.Forms.Button();
            this.btnTech2 = new System.Windows.Forms.Button();
            this.btnTech3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnique)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сделки";
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.Location = new System.Drawing.Point(15, 25);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.Size = new System.Drawing.Size(688, 101);
            this.dgvTransaction.TabIndex = 1;
            // 
            // btnTr1
            // 
            this.btnTr1.Location = new System.Drawing.Point(15, 132);
            this.btnTr1.Name = "btnTr1";
            this.btnTr1.Size = new System.Drawing.Size(75, 23);
            this.btnTr1.TabIndex = 2;
            this.btnTr1.Text = "Добавить";
            this.btnTr1.UseVisualStyleBackColor = true;
            this.btnTr1.Click += new System.EventHandler(this.btnTr1_Click);
            // 
            // btnTr2
            // 
            this.btnTr2.Location = new System.Drawing.Point(105, 132);
            this.btnTr2.Name = "btnTr2";
            this.btnTr2.Size = new System.Drawing.Size(99, 23);
            this.btnTr2.TabIndex = 3;
            this.btnTr2.Text = "Редактировать";
            this.btnTr2.UseVisualStyleBackColor = true;
            this.btnTr2.Click += new System.EventHandler(this.btnTr2_Click);
            // 
            // btnTr3
            // 
            this.btnTr3.Location = new System.Drawing.Point(219, 132);
            this.btnTr3.Name = "btnTr3";
            this.btnTr3.Size = new System.Drawing.Size(75, 23);
            this.btnTr3.TabIndex = 4;
            this.btnTr3.Text = "Удалить";
            this.btnTr3.UseVisualStyleBackColor = true;
            this.btnTr3.Click += new System.EventHandler(this.btnTr3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Клиенты";
            // 
            // dgvClient
            // 
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(15, 183);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(688, 101);
            this.dgvClient.TabIndex = 6;
            // 
            // btnCl1
            // 
            this.btnCl1.Location = new System.Drawing.Point(15, 290);
            this.btnCl1.Name = "btnCl1";
            this.btnCl1.Size = new System.Drawing.Size(75, 23);
            this.btnCl1.TabIndex = 7;
            this.btnCl1.Text = "Добавить";
            this.btnCl1.UseVisualStyleBackColor = true;
            this.btnCl1.Click += new System.EventHandler(this.btnCl1_Click);
            // 
            // btnCl2
            // 
            this.btnCl2.Location = new System.Drawing.Point(105, 290);
            this.btnCl2.Name = "btnCl2";
            this.btnCl2.Size = new System.Drawing.Size(99, 23);
            this.btnCl2.TabIndex = 8;
            this.btnCl2.Text = "Редактировать";
            this.btnCl2.UseVisualStyleBackColor = true;
            this.btnCl2.Click += new System.EventHandler(this.btnCl2_Click);
            // 
            // btnCl3
            // 
            this.btnCl3.Location = new System.Drawing.Point(219, 290);
            this.btnCl3.Name = "btnCl3";
            this.btnCl3.Size = new System.Drawing.Size(75, 23);
            this.btnCl3.TabIndex = 9;
            this.btnCl3.Text = "Удалить";
            this.btnCl3.UseVisualStyleBackColor = true;
            this.btnCl3.Click += new System.EventHandler(this.btnCl3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Техника";
            // 
            // dgvTechnique
            // 
            this.dgvTechnique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnique.Location = new System.Drawing.Point(15, 342);
            this.dgvTechnique.Name = "dgvTechnique";
            this.dgvTechnique.Size = new System.Drawing.Size(688, 101);
            this.dgvTechnique.TabIndex = 11;
            // 
            // btnTech1
            // 
            this.btnTech1.Location = new System.Drawing.Point(15, 449);
            this.btnTech1.Name = "btnTech1";
            this.btnTech1.Size = new System.Drawing.Size(75, 23);
            this.btnTech1.TabIndex = 12;
            this.btnTech1.Text = "Добавить";
            this.btnTech1.UseVisualStyleBackColor = true;
            this.btnTech1.Click += new System.EventHandler(this.btnTech1_Click);
            // 
            // btnTech2
            // 
            this.btnTech2.Location = new System.Drawing.Point(105, 449);
            this.btnTech2.Name = "btnTech2";
            this.btnTech2.Size = new System.Drawing.Size(99, 23);
            this.btnTech2.TabIndex = 13;
            this.btnTech2.Text = "Редактировать";
            this.btnTech2.UseVisualStyleBackColor = true;
            this.btnTech2.Click += new System.EventHandler(this.btnTech2_Click);
            // 
            // btnTech3
            // 
            this.btnTech3.Location = new System.Drawing.Point(219, 449);
            this.btnTech3.Name = "btnTech3";
            this.btnTech3.Size = new System.Drawing.Size(75, 23);
            this.btnTech3.TabIndex = 14;
            this.btnTech3.Text = "Удалить";
            this.btnTech3.UseVisualStyleBackColor = true;
            this.btnTech3.Click += new System.EventHandler(this.btnTech3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 491);
            this.Controls.Add(this.btnTech3);
            this.Controls.Add(this.btnTech2);
            this.Controls.Add(this.btnTech1);
            this.Controls.Add(this.dgvTechnique);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCl3);
            this.Controls.Add(this.btnCl2);
            this.Controls.Add(this.btnCl1);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTr3);
            this.Controls.Add(this.btnTr2);
            this.Controls.Add(this.btnTr1);
            this.Controls.Add(this.dgvTransaction);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Продажа компьютерной техники";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnique)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.Button btnTr1;
        private System.Windows.Forms.Button btnTr2;
        private System.Windows.Forms.Button btnTr3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.Button btnCl1;
        private System.Windows.Forms.Button btnCl2;
        private System.Windows.Forms.Button btnCl3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTechnique;
        private System.Windows.Forms.Button btnTech1;
        private System.Windows.Forms.Button btnTech2;
        private System.Windows.Forms.Button btnTech3;
    }
}