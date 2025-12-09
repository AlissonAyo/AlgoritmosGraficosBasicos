using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            this.Load += FrmHome_Load;
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            CargarImagenFondo();
        }

        private void CargarImagenFondo()
        {
            try
            {
                // Buscar la imagen Fondo.png en el directorio de la solución
                string directorioBase = Path.GetDirectoryName(Application.StartupPath);
                string rutaImagen = Path.Combine(directorioBase, "Fondo.png");

                // Si no está en el directorio padre, buscar en el directorio de ejecución
                if (!File.Exists(rutaImagen))
                {
                    rutaImagen = Path.Combine(Application.StartupPath, "Fondo.png");
                }

                // Si aún no la encuentra, buscar en directorios padres
                if (!File.Exists(rutaImagen))
                {
                    string directorioPadre = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                    rutaImagen = Path.Combine(directorioPadre, "Fondo.png");
                }

                if (File.Exists(rutaImagen))
                {
                    // Cargar la imagen
                    Image imagenFondo = Image.FromFile(rutaImagen);
                    this.BackgroundImage = imagenFondo;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    // Si no se encuentra la imagen, usar color de fondo predeterminado
                    this.BackColor = Color.FromArgb(30, 60, 114);
                }
            }
            catch (Exception ex)
            {
                // En caso de error, usar color de fondo predeterminado
                this.BackColor = Color.FromArgb(30, 60, 114);
                MessageBox.Show("No se pudo cargar la imagen de fondo: " + ex.Message, 
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDDA frmDDA = FrmDDA.Instance;
            frmDDA.MdiParent = this;
            frmDDA.Show();
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuntoMedio frmPuntoMedio = FrmPuntoMedio.Instance;
            frmPuntoMedio.MdiParent = this;
            frmPuntoMedio.Show();
        }

        private void xiaolinWuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmXiaolinWu frmXiaolinWu = FrmXiaolinWu.Instance;
            frmXiaolinWu.MdiParent = this;
            frmXiaolinWu.Show();
        }

        private void segmentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCirculo8Segmentos frmCirculo8Segmentos = FrmCirculo8Segmentos.Instance;
            frmCirculo8Segmentos.MdiParent = this;
            frmCirculo8Segmentos.Show();
        }

        private void puntoMedioCirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCirculoPuntoMedio frmCirculoPuntoMedio = FrmCirculoPuntoMedio.Instance;
            frmCirculoPuntoMedio.MdiParent = this;
            frmCirculoPuntoMedio.Show();
        }

        private void polarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCirculoPolar frmCirculoPolar = FrmCirculoPolar.Instance;
            frmCirculoPolar.MdiParent = this;
            frmCirculoPolar.Show();
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFloodFill frmFloodFill = FrmFloodFill.Instance;
            frmFloodFill.MdiParent = this;
            frmFloodFill.Show();
        }

        private void scanlineFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScanlineFill frmScanlineFill = FrmScanlineFill.Instance;
            frmScanlineFill.MdiParent = this;
            frmScanlineFill.Show();
        }

        private void boundaryFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBoundaryFill frmBoundaryFill = FrmBoundaryFill.Instance;
            frmBoundaryFill.MdiParent = this;
            frmBoundaryFill.Show();
        }

        private void cohenSutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCohenSutherland frmCohenSutherland = FrmCohenSutherland.Instance;
            frmCohenSutherland.MdiParent = this;
            frmCohenSutherland.Show();
        }

        private void liangBarskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLiangBarsky frmLiangBarsky = FrmLiangBarsky.Instance;
            frmLiangBarsky.MdiParent = this;
            frmLiangBarsky.Show();
        }

        private void nichollLeeNichollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNichollLeeNicholl frmNichollLeeNicholl = FrmNichollLeeNicholl.Instance;
            frmNichollLeeNicholl.MdiParent = this;
            frmNichollLeeNicholl.Show();
        }

        private void dePolígonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Este evento se mantiene para compatibilidad
            // Ahora los algoritmos se acceden desde el submenú
        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRecortePoligono frmRecortePoligono = FrmRecortePoligono.Instance;
            frmRecortePoligono.MdiParent = this;
            frmRecortePoligono.Show();
        }

        private void weilerAthertonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWeilerAtherton frmWeilerAtherton = FrmWeilerAtherton.Instance;
            frmWeilerAtherton.MdiParent = this;
            frmWeilerAtherton.Show();
        }

        private void cyrusBeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCyrusBeck frmCyrusBeck = FrmCyrusBeck.Instance;
            frmCyrusBeck.MdiParent = this;
            frmCyrusBeck.Show();
        }
    }
}
