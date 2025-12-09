namespace Ayo_Alisson_Algoritmos
{
    partial class FrmHome
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xiaolinWuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioCirculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floodFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanlineFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteGeométricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteDeLíneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liangBarskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nichollLeeNichollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dePolígonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weilerAthertonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cyrusBeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineasToolStripMenuItem,
            this.circulosToolStripMenuItem,
            this.rellenoToolStripMenuItem,
            this.recorteGeométricoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lineasToolStripMenuItem
            // 
            this.lineasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDAToolStripMenuItem,
            this.puntoMedioToolStripMenuItem,
            this.xiaolinWuToolStripMenuItem});
            this.lineasToolStripMenuItem.Name = "lineasToolStripMenuItem";
            this.lineasToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.lineasToolStripMenuItem.Text = "Líneas";
            this.lineasToolStripMenuItem.Click += new System.EventHandler(this.lineasToolStripMenuItem_Click);
            // 
            // dDAToolStripMenuItem
            // 
            this.dDAToolStripMenuItem.Name = "dDAToolStripMenuItem";
            this.dDAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dDAToolStripMenuItem.Text = "D.D.A.";
            this.dDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.puntoMedioToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // xiaolinWuToolStripMenuItem
            // 
            this.xiaolinWuToolStripMenuItem.Name = "xiaolinWuToolStripMenuItem";
            this.xiaolinWuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xiaolinWuToolStripMenuItem.Text = "Xiaolin Wu";
            this.xiaolinWuToolStripMenuItem.Click += new System.EventHandler(this.xiaolinWuToolStripMenuItem_Click);
            // 
            // circulosToolStripMenuItem
            // 
            this.circulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segmentosToolStripMenuItem,
            this.puntoMedioCirculoToolStripMenuItem,
            this.polarToolStripMenuItem});
            this.circulosToolStripMenuItem.Name = "circulosToolStripMenuItem";
            this.circulosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.circulosToolStripMenuItem.Text = "Círculos";
            // 
            // segmentosToolStripMenuItem
            // 
            this.segmentosToolStripMenuItem.Name = "segmentosToolStripMenuItem";
            this.segmentosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.segmentosToolStripMenuItem.Text = "8 Segmentos";
            this.segmentosToolStripMenuItem.Click += new System.EventHandler(this.segmentosToolStripMenuItem_Click);
            // 
            // puntoMedioCirculoToolStripMenuItem
            // 
            this.puntoMedioCirculoToolStripMenuItem.Name = "puntoMedioCirculoToolStripMenuItem";
            this.puntoMedioCirculoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.puntoMedioCirculoToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioCirculoToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioCirculoToolStripMenuItem_Click);
            // 
            // polarToolStripMenuItem
            // 
            this.polarToolStripMenuItem.Name = "polarToolStripMenuItem";
            this.polarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.polarToolStripMenuItem.Text = "Polar";
            this.polarToolStripMenuItem.Click += new System.EventHandler(this.polarToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floodFillToolStripMenuItem,
            this.scanlineFillToolStripMenuItem,
            this.boundaryFillToolStripMenuItem});
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // floodFillToolStripMenuItem
            // 
            this.floodFillToolStripMenuItem.Name = "floodFillToolStripMenuItem";
            this.floodFillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.floodFillToolStripMenuItem.Text = "Flood Fill";
            this.floodFillToolStripMenuItem.Click += new System.EventHandler(this.floodFillToolStripMenuItem_Click);
            // 
            // scanlineFillToolStripMenuItem
            // 
            this.scanlineFillToolStripMenuItem.Name = "scanlineFillToolStripMenuItem";
            this.scanlineFillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scanlineFillToolStripMenuItem.Text = "Scanline Fill";
            this.scanlineFillToolStripMenuItem.Click += new System.EventHandler(this.scanlineFillToolStripMenuItem_Click);
            // 
            // boundaryFillToolStripMenuItem
            // 
            this.boundaryFillToolStripMenuItem.Name = "boundaryFillToolStripMenuItem";
            this.boundaryFillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boundaryFillToolStripMenuItem.Text = "Boundary Fill";
            this.boundaryFillToolStripMenuItem.Click += new System.EventHandler(this.boundaryFillToolStripMenuItem_Click);
            // 
            // recorteGeométricoToolStripMenuItem
            // 
            this.recorteGeométricoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recorteDeLíneasToolStripMenuItem,
            this.dePolígonosToolStripMenuItem});
            this.recorteGeométricoToolStripMenuItem.Name = "recorteGeométricoToolStripMenuItem";
            this.recorteGeométricoToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.recorteGeométricoToolStripMenuItem.Text = "Recorte Geométrico";
            // 
            // recorteDeLíneasToolStripMenuItem
            // 
            this.recorteDeLíneasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cohenSutherlandToolStripMenuItem,
            this.liangBarskyToolStripMenuItem,
            this.nichollLeeNichollToolStripMenuItem});
            this.recorteDeLíneasToolStripMenuItem.Name = "recorteDeLíneasToolStripMenuItem";
            this.recorteDeLíneasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recorteDeLíneasToolStripMenuItem.Text = "De líneas";
            // 
            // cohenSutherlandToolStripMenuItem
            // 
            this.cohenSutherlandToolStripMenuItem.Name = "cohenSutherlandToolStripMenuItem";
            this.cohenSutherlandToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cohenSutherlandToolStripMenuItem.Text = "Cohen-Sutherland";
            this.cohenSutherlandToolStripMenuItem.Click += new System.EventHandler(this.cohenSutherlandToolStripMenuItem_Click);
            // 
            // liangBarskyToolStripMenuItem
            // 
            this.liangBarskyToolStripMenuItem.Name = "liangBarskyToolStripMenuItem";
            this.liangBarskyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.liangBarskyToolStripMenuItem.Text = "Liang-Barsky";
            this.liangBarskyToolStripMenuItem.Click += new System.EventHandler(this.liangBarskyToolStripMenuItem_Click);
            // 
            // nichollLeeNichollToolStripMenuItem
            // 
            this.nichollLeeNichollToolStripMenuItem.Name = "nichollLeeNichollToolStripMenuItem";
            this.nichollLeeNichollToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nichollLeeNichollToolStripMenuItem.Text = "Nicholl-Lee-Nicholl";
            this.nichollLeeNichollToolStripMenuItem.Click += new System.EventHandler(this.nichollLeeNichollToolStripMenuItem_Click);
            // 
            // dePolígonosToolStripMenuItem
            // 
            this.dePolígonosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sutherlandHodgmanToolStripMenuItem,
            this.weilerAthertonToolStripMenuItem,
            this.cyrusBeckToolStripMenuItem});
            this.dePolígonosToolStripMenuItem.Name = "dePolígonosToolStripMenuItem";
            this.dePolígonosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dePolígonosToolStripMenuItem.Text = "De polígonos";
            this.dePolígonosToolStripMenuItem.Click += new System.EventHandler(this.dePolígonosToolStripMenuItem_Click);
            // 
            // sutherlandHodgmanToolStripMenuItem
            // 
            this.sutherlandHodgmanToolStripMenuItem.Name = "sutherlandHodgmanToolStripMenuItem";
            this.sutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sutherlandHodgmanToolStripMenuItem.Text = "Sutherland-Hodgman";
            this.sutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.sutherlandHodgmanToolStripMenuItem_Click);
            // 
            // weilerAthertonToolStripMenuItem
            // 
            this.weilerAthertonToolStripMenuItem.Name = "weilerAthertonToolStripMenuItem";
            this.weilerAthertonToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.weilerAthertonToolStripMenuItem.Text = "Weiler-Atherton";
            this.weilerAthertonToolStripMenuItem.Click += new System.EventHandler(this.weilerAthertonToolStripMenuItem_Click);
            // 
            // cyrusBeckToolStripMenuItem
            // 
            this.cyrusBeckToolStripMenuItem.Name = "cyrusBeckToolStripMenuItem";
            this.cyrusBeckToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cyrusBeckToolStripMenuItem.Text = "Cyrus-Beck";
            this.cyrusBeckToolStripMenuItem.Click += new System.EventHandler(this.cyrusBeckToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(834, 411);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmHome";
            this.Text = "Algoritmos Gráficos Básicos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xiaolinWuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioCirculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floodFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanlineFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundaryFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteGeométricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteDeLíneasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohenSutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liangBarskyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nichollLeeNichollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dePolígonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weilerAthertonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cyrusBeckToolStripMenuItem;
    }
}