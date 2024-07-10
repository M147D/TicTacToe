namespace ClienteTicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn00 = new System.Windows.Forms.Button();
            this.btn01 = new System.Windows.Forms.Button();
            this.btn02 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn22 = new System.Windows.Forms.Button();
            this.btn21 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnUnir = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn00
            // 
            this.btn00.Location = new System.Drawing.Point(12, 61);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(79, 63);
            this.btn00.TabIndex = 0;
            this.btn00.Text = "button1";
            this.btn00.UseVisualStyleBackColor = true;
            // 
            // btn01
            // 
            this.btn01.Location = new System.Drawing.Point(111, 61);
            this.btn01.Name = "btn01";
            this.btn01.Size = new System.Drawing.Size(79, 63);
            this.btn01.TabIndex = 1;
            this.btn01.Text = "button2";
            this.btn01.UseVisualStyleBackColor = true;
            // 
            // btn02
            // 
            this.btn02.Location = new System.Drawing.Point(208, 61);
            this.btn02.Name = "btn02";
            this.btn02.Size = new System.Drawing.Size(79, 63);
            this.btn02.TabIndex = 2;
            this.btn02.Text = "button3";
            this.btn02.UseVisualStyleBackColor = true;
            // 
            // btn12
            // 
            this.btn12.Location = new System.Drawing.Point(208, 144);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(79, 63);
            this.btn12.TabIndex = 5;
            this.btn12.Text = "button6";
            this.btn12.UseVisualStyleBackColor = true;
            // 
            // btn11
            // 
            this.btn11.Location = new System.Drawing.Point(111, 144);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(79, 63);
            this.btn11.TabIndex = 4;
            this.btn11.Text = "button5";
            this.btn11.UseVisualStyleBackColor = true;
            // 
            // btn10
            // 
            this.btn10.Location = new System.Drawing.Point(12, 144);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(79, 63);
            this.btn10.TabIndex = 3;
            this.btn10.Text = "button4";
            this.btn10.UseVisualStyleBackColor = true;
            // 
            // btn22
            // 
            this.btn22.Location = new System.Drawing.Point(208, 225);
            this.btn22.Name = "btn22";
            this.btn22.Size = new System.Drawing.Size(79, 63);
            this.btn22.TabIndex = 8;
            this.btn22.Text = "button9";
            this.btn22.UseVisualStyleBackColor = true;
            // 
            // btn21
            // 
            this.btn21.Location = new System.Drawing.Point(111, 225);
            this.btn21.Name = "btn21";
            this.btn21.Size = new System.Drawing.Size(79, 63);
            this.btn21.TabIndex = 7;
            this.btn21.Text = "button8";
            this.btn21.UseVisualStyleBackColor = true;
            // 
            // btn20
            // 
            this.btn20.Location = new System.Drawing.Point(12, 225);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(79, 63);
            this.btn20.TabIndex = 6;
            this.btn20.Text = "button7";
            this.btn20.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(30, 318);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnUnir
            // 
            this.btnUnir.Location = new System.Drawing.Point(192, 318);
            this.btnUnir.Name = "btnUnir";
            this.btnUnir.Size = new System.Drawing.Size(75, 23);
            this.btnUnir.TabIndex = 10;
            this.btnUnir.Text = "Unir";
            this.btnUnir.UseVisualStyleBackColor = true;
            this.btnUnir.Click += new System.EventHandler(this.btnUnir_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(131, 20);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 359);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnUnir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btn22);
            this.Controls.Add(this.btn21);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn12);
            this.Controls.Add(this.btn11);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn02);
            this.Controls.Add(this.btn01);
            this.Controls.Add(this.btn00);
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.Button btn01;
        private System.Windows.Forms.Button btn02;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn22;
        private System.Windows.Forms.Button btn21;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnUnir;
        private System.Windows.Forms.Label lblEstado;
    }
}

