namespace Ayo_Alisson_Algoritmos
{
    partial class FrmCirculo8Segmentos
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.txtYCentro = new System.Windows.Forms.TextBox();
            this.lblYCentro = new System.Windows.Forms.Label();
            this.txtXCentro = new System.Windows.Forms.TextBox();
            this.lblXCentro = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(600, 500);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCirculo8Segmentos_Paint);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(94)))));
            this.pnlMenu.Controls.Add(this.lblResultado);
            this.pnlMenu.Controls.Add(this.lblInstrucciones);
            this.pnlMenu.Controls.Add(this.grpDatos);
            this.pnlMenu.Controls.Add(this.btnReiniciar);
            this.pnlMenu.Controls.Add(this.btnCalcular);
            this.pnlMenu.Controls.Add(this.lblTitulo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(630, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 524);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "8 SEGMENTOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.txtRadio);
            this.grpDatos.Controls.Add(this.lblRadio);
            this.grpDatos.Controls.Add(this.txtYCentro);
            this.grpDatos.Controls.Add(this.lblYCentro);
            this.grpDatos.Controls.Add(this.txtXCentro);
            this.grpDatos.Controls.Add(this.lblXCentro);
            this.grpDatos.ForeColor = System.Drawing.Color.White;
            this.grpDatos.Location = new System.Drawing.Point(15, 70);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(170, 120);
            this.grpDatos.TabIndex = 1;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del Círculo";
            // 
            // lblXCentro
            // 
            this.lblXCentro.AutoSize = true;
            this.lblXCentro.Location = new System.Drawing.Point(10, 25);
            this.lblXCentro.Name = "lblXCentro";
            this.lblXCentro.Size = new System.Drawing.Size(56, 13);
            this.lblXCentro.TabIndex = 0;
            this.lblXCentro.Text = "X Centro:";
            // 
            // txtXCentro
            // 
            this.txtXCentro.Location = new System.Drawing.Point(75, 22);
            this.txtXCentro.Name = "txtXCentro";
            this.txtXCentro.Size = new System.Drawing.Size(80, 20);
            this.txtXCentro.TabIndex = 1;
            // 
            // lblYCentro
            // 
            this.lblYCentro.AutoSize = true;
            this.lblYCentro.Location = new System.Drawing.Point(10, 55);
            this.lblYCentro.Name = "lblYCentro";
            this.lblYCentro.Size = new System.Drawing.Size(56, 13);
            this.lblYCentro.TabIndex = 2;
            this.lblYCentro.Text = "Y Centro:";
            // 
            // txtYCentro
            // 
            this.txtYCentro.Location = new System.Drawing.Point(75, 52);
            this.txtYCentro.Name = "txtYCentro";
            this.txtYCentro.Size = new System.Drawing.Size(80, 20);
            this.txtYCentro.TabIndex = 3;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(10, 85);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(38, 13);
            this.lblRadio.TabIndex = 4;
            this.lblRadio.Text = "Radio:";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(75, 82);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(80, 20);
            this.txtRadio.TabIndex = 5;
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnCalcular.FlatAppearance.BorderSize = 0;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(15, 200);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(170, 35);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "CALCULAR";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.Location = new System.Drawing.Point(15, 245);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(170, 35);
            this.btnReiniciar.TabIndex = 3;
            this.btnReiniciar.Text = "REINICIAR";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.ForeColor = System.Drawing.Color.White;
            this.lblInstrucciones.Location = new System.Drawing.Point(15, 290);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(170, 60);
            this.lblInstrucciones.TabIndex = 4;
            this.lblInstrucciones.Text = "Click 1: Centro\nClick 2: Radio\n\nO ingresa los valores\ny presiona CALCULAR";
            this.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblResultado
            // 
            this.lblResultado.ForeColor = System.Drawing.Color.White;
            this.lblResultado.Location = new System.Drawing.Point(15, 360);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(170, 150);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.Text = "";
            // 
            // FrmCirculo8Segmentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(830, 524);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.picCanvas);
            this.Name = "FrmCirculo8Segmentos";
            this.Text = "Círculo - 8 Segmentos";
            this.Load += new System.EventHandler(this.FrmCirculo8Segmentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TextBox txtXCentro;
        private System.Windows.Forms.Label lblXCentro;
        private System.Windows.Forms.TextBox txtYCentro;
        private System.Windows.Forms.Label lblYCentro;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblResultado;
    }
}
