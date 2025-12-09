using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmRellenos : Form
    {
        private static FrmRellenos _instance;
        Graphics g;
        Pen pen = new Pen(Color.Black, 2);
        private List<Point> puntosClick1 = new List<Point>();
        private List<Point> puntosClick2 = new List<Point>();
        private List<Point> puntosClick3 = new List<Point>();
        
        // Algoritmos de relleno
        AlgoritmoRelleno algoritmoFloodFill = new AlgoritmoRelleno();
        AlgoritmoScanline algoritmoScanline = new AlgoritmoScanline();
        AlgoritmoBoundaryFill algoritmoBoundary = new AlgoritmoBoundaryFill();
        
        public static FrmRellenos Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmRellenos();
                }
                return _instance;
            }
        }

        public FrmRellenos()
        {
            InitializeComponent();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // Flood Fill - requiere crear polígono con clicks
            puntosClick1.Add(new Point(e.X, e.Y));
            g = picCanvas.CreateGraphics();
            g.DrawRectangle(pen, e.X, e.Y, 1, 1);

            if (puntosClick1.Count >= 3)
            {
                // Dibujar el polígono
                using (Graphics gr = picCanvas.CreateGraphics())
                {
                    gr.DrawPolygon(pen, puntosClick1.ToArray());
                }

                // Aplicar flood fill en el centro del polígono
                var centro = CalcularCentro(puntosClick1);
                var coordenadas = puntosClick1.Select(p => (p.X, p.Y)).ToList();
                algoritmoFloodFill.RellenarFigura(picCanvas, centro.X, centro.Y, coordenadas);
                
                puntosClick1.Clear();
            }
        }

        private void picCanvas2_MouseClick(object sender, MouseEventArgs e)
        {
            // Scanline Fill - requiere crear polígono con clicks
            puntosClick2.Add(new Point(e.X, e.Y));
            g = picCanvas2.CreateGraphics();
            g.DrawRectangle(pen, e.X, e.Y, 1, 1);

            if (puntosClick2.Count >= 3)
            {
                var coordenadas = puntosClick2.Select(p => (p.X, p.Y)).ToList();
                algoritmoScanline.RellenarScanline(picCanvas2, coordenadas);
                puntosClick2.Clear();
            }
        }

        private void picCanvas3_MouseClick(object sender, MouseEventArgs e)
        {
            // Boundary Fill - requiere crear polígono con clicks
            puntosClick3.Add(new Point(e.X, e.Y));
            g = picCanvas3.CreateGraphics();
            g.DrawRectangle(pen, e.X, e.Y, 1, 1);

            if (puntosClick3.Count >= 3)
            {
                // Dibujar el borde del polígono
                algoritmoBoundary.DibujarBorde(picCanvas3, puntosClick3);
                
                // Aplicar boundary fill en el centro
                var centro = CalcularCentro(puntosClick3);
                algoritmoBoundary.RellenarBoundary(picCanvas3, centro.X, centro.Y);
                
                puntosClick3.Clear();
            }
        }

        private Point CalcularCentro(List<Point> puntos)
        {
            int x = puntos.Sum(p => p.X) / puntos.Count;
            int y = puntos.Sum(p => p.Y) / puntos.Count;
            return new Point(x, y);
        }

        private void FrmRellenos_Load(object sender, EventArgs e)
        {

        }
    }
}