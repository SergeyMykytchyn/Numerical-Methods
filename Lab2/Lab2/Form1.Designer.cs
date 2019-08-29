namespace Lab2
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
            this.dataGridViewMatrix = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewQuadSol = new System.Windows.Forms.DataGridView();
            this.dataGridViewQuadMult = new System.Windows.Forms.DataGridView();
            this.btn_CALC_QUAD = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSeidelSol = new System.Windows.Forms.DataGridView();
            this.dataGridViewSeidelMult = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_CALC_SEIDEL = new System.Windows.Forms.Button();
            this.dataGridViewInvMatrix = new System.Windows.Forms.DataGridView();
            this.dataGridViewIdentity = new System.Windows.Forms.DataGridView();
            this.labelDET = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCond = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelNorm = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuadSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuadMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeidelSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeidelMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdentity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMatrix
            // 
            this.dataGridViewMatrix.AllowUserToAddRows = false;
            this.dataGridViewMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatrix.Location = new System.Drawing.Point(47, 69);
            this.dataGridViewMatrix.Name = "dataGridViewMatrix";
            this.dataGridViewMatrix.RowHeadersWidth = 31;
            this.dataGridViewMatrix.RowTemplate.Height = 24;
            this.dataGridViewMatrix.Size = new System.Drawing.Size(246, 215);
            this.dataGridViewMatrix.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Метод квадратного кореня";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Розв\'язок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "A * x";
            // 
            // dataGridViewQuadSol
            // 
            this.dataGridViewQuadSol.AllowUserToAddRows = false;
            this.dataGridViewQuadSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuadSol.Location = new System.Drawing.Point(387, 116);
            this.dataGridViewQuadSol.Name = "dataGridViewQuadSol";
            this.dataGridViewQuadSol.RowTemplate.Height = 24;
            this.dataGridViewQuadSol.Size = new System.Drawing.Size(400, 50);
            this.dataGridViewQuadSol.TabIndex = 4;
            // 
            // dataGridViewQuadMult
            // 
            this.dataGridViewQuadMult.AllowUserToAddRows = false;
            this.dataGridViewQuadMult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuadMult.Location = new System.Drawing.Point(387, 188);
            this.dataGridViewQuadMult.Name = "dataGridViewQuadMult";
            this.dataGridViewQuadMult.RowTemplate.Height = 24;
            this.dataGridViewQuadMult.Size = new System.Drawing.Size(400, 50);
            this.dataGridViewQuadMult.TabIndex = 5;
            // 
            // btn_CALC_QUAD
            // 
            this.btn_CALC_QUAD.Location = new System.Drawing.Point(521, 259);
            this.btn_CALC_QUAD.Name = "btn_CALC_QUAD";
            this.btn_CALC_QUAD.Size = new System.Drawing.Size(109, 40);
            this.btn_CALC_QUAD.TabIndex = 6;
            this.btn_CALC_QUAD.Text = "Обчислити";
            this.btn_CALC_QUAD.UseVisualStyleBackColor = true;
            this.btn_CALC_QUAD.Click += new System.EventHandler(this.btn_CALC_QUAD_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1046, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Метод Зейделя";
            // 
            // dataGridViewSeidelSol
            // 
            this.dataGridViewSeidelSol.AllowUserToAddRows = false;
            this.dataGridViewSeidelSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeidelSol.Location = new System.Drawing.Point(908, 116);
            this.dataGridViewSeidelSol.Name = "dataGridViewSeidelSol";
            this.dataGridViewSeidelSol.RowTemplate.Height = 24;
            this.dataGridViewSeidelSol.Size = new System.Drawing.Size(400, 50);
            this.dataGridViewSeidelSol.TabIndex = 8;
            // 
            // dataGridViewSeidelMult
            // 
            this.dataGridViewSeidelMult.AllowUserToAddRows = false;
            this.dataGridViewSeidelMult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeidelMult.Location = new System.Drawing.Point(908, 188);
            this.dataGridViewSeidelMult.Name = "dataGridViewSeidelMult";
            this.dataGridViewSeidelMult.RowTemplate.Height = 24;
            this.dataGridViewSeidelMult.Size = new System.Drawing.Size(400, 50);
            this.dataGridViewSeidelMult.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(905, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "0";
            // 
            // btn_CALC_SEIDEL
            // 
            this.btn_CALC_SEIDEL.Location = new System.Drawing.Point(1059, 255);
            this.btn_CALC_SEIDEL.Name = "btn_CALC_SEIDEL";
            this.btn_CALC_SEIDEL.Size = new System.Drawing.Size(109, 40);
            this.btn_CALC_SEIDEL.TabIndex = 11;
            this.btn_CALC_SEIDEL.Text = "Обчислити";
            this.btn_CALC_SEIDEL.UseVisualStyleBackColor = true;
            this.btn_CALC_SEIDEL.Click += new System.EventHandler(this.btn_CALC_SEIDEL_Click);
            // 
            // dataGridViewInvMatrix
            // 
            this.dataGridViewInvMatrix.AllowUserToAddRows = false;
            this.dataGridViewInvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvMatrix.Location = new System.Drawing.Point(72, 337);
            this.dataGridViewInvMatrix.Name = "dataGridViewInvMatrix";
            this.dataGridViewInvMatrix.RowTemplate.Height = 24;
            this.dataGridViewInvMatrix.Size = new System.Drawing.Size(417, 178);
            this.dataGridViewInvMatrix.TabIndex = 12;
            // 
            // dataGridViewIdentity
            // 
            this.dataGridViewIdentity.AllowUserToAddRows = false;
            this.dataGridViewIdentity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIdentity.Location = new System.Drawing.Point(580, 331);
            this.dataGridViewIdentity.Name = "dataGridViewIdentity";
            this.dataGridViewIdentity.RowTemplate.Height = 24;
            this.dataGridViewIdentity.Size = new System.Drawing.Size(396, 184);
            this.dataGridViewIdentity.TabIndex = 13;
            // 
            // labelDET
            // 
            this.labelDET.AutoSize = true;
            this.labelDET.Location = new System.Drawing.Point(1167, 337);
            this.labelDET.Name = "labelDET";
            this.labelDET.Size = new System.Drawing.Size(46, 17);
            this.labelDET.TabIndex = 14;
            this.labelDET.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(996, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Визначник";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(996, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Число обумовленостi";
            // 
            // labelCond
            // 
            this.labelCond.AutoSize = true;
            this.labelCond.Location = new System.Drawing.Point(1170, 383);
            this.labelCond.Name = "labelCond";
            this.labelCond.Size = new System.Drawing.Size(46, 17);
            this.labelCond.TabIndex = 17;
            this.labelCond.Text = "label8";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(996, 417);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 17);
            this.label.TabIndex = 18;
            this.label.Text = "Норма";
            // 
            // labelNorm
            // 
            this.labelNorm.AutoSize = true;
            this.labelNorm.Location = new System.Drawing.Point(1173, 417);
            this.labelNorm.Name = "labelNorm";
            this.labelNorm.Size = new System.Drawing.Size(46, 17);
            this.labelNorm.TabIndex = 19;
            this.labelNorm.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(776, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Кількість ітерацій";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "A^(-1)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(509, 417);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "AA^(-1)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 576);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelNorm);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelCond);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelDET);
            this.Controls.Add(this.dataGridViewIdentity);
            this.Controls.Add(this.dataGridViewInvMatrix);
            this.Controls.Add(this.btn_CALC_SEIDEL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewSeidelMult);
            this.Controls.Add(this.dataGridViewSeidelSol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_CALC_QUAD);
            this.Controls.Add(this.dataGridViewQuadMult);
            this.Controls.Add(this.dataGridViewQuadSol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMatrix);
            this.Name = "Form1";
            this.Text = "Розв\'язання систем лiнiйних рiвнянь";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuadSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuadMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeidelSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeidelMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdentity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewQuadSol;
        private System.Windows.Forms.DataGridView dataGridViewQuadMult;
        private System.Windows.Forms.Button btn_CALC_QUAD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewSeidelSol;
        private System.Windows.Forms.DataGridView dataGridViewSeidelMult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_CALC_SEIDEL;
        private System.Windows.Forms.DataGridView dataGridViewInvMatrix;
        private System.Windows.Forms.DataGridView dataGridViewIdentity;
        private System.Windows.Forms.Label labelDET;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCond;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelNorm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

