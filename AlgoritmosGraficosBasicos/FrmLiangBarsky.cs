using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmLiangBarsky : Form
    {
        private static FrmLiangBarsky _instance;
        private AlgoritmoLiangBarsky algoritmo = new AlgoritmoLiangBarsky();
        private List<Point> puntosLineaActual = new List<Point>();
        private List<(Point p1, Point p2)> lineasDibujadas = new List<(Point, Point)>();
        private Graphics g;
        private Pen penOriginal = new Pen(Color.Blue, 2);
        private Pen penRecortada = new Pen(Color.Red, 3);
        private Pen penRectangulo = new Pen(Color.Black, 2);
        
        // Rectángulo de recorte predefinido
        private int xmin = 150;
        private int ymin = 100;
        private int xmax = 450;
        private int ymax = 400;

        public static FrmLiangBarsky Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmLiangBarsky();
                }
                return _instance;
            }
        }

        public FrmLiangBarsky()
        {
            InitializeComponent();
        }

        private void DibujarRectanguloRecorte()
        {
            if (picCanvas != null && picCanvas.IsHandleCreated)
            {
                g = picCanvas.CreateGraphics();
                
                // Dibujar rectángulo de recorte
                g.DrawRectangle(penRectangulo, xmin, ymin, xmax - xmin, ymax - ymin);
                
                // Dibujar etiquetas
                Font font = new Font("Arial", 10, FontStyle.Bold);
                g.DrawString("Área de Recorte", font, Brushes.Black, xmin + 10, ymin + 10);
            }
        }

        private void RedibujarTodo()
        {
            if (picCanvas != null && picCanvas.IsHandleCreated)
            {
                g = picCanvas.CreateGraphics();
                g.Clear(Color.White);
                
                // Redibujar rectángulo
                DibujarRectanguloRecorte();
                
                // Redibujar todas las líneas originales
                foreach (var linea in lineasDibujadas)
                {
                    g.DrawLine(penOriginal, linea.p1, linea.p2);
                    
                    // Dibujar puntos
                    g.FillEllipse(Brushes.Blue, linea.p1.X - 3, linea.p1.Y - 3, 6, 6);
                    g.FillEllipse(Brushes.Blue, linea.p2.X - 3, linea.p2.Y - 3, 6, 6);
                }
                
                // Redibujar línea actual si hay un punto
                if (puntosLineaActual.Count == 1)
                {
                    g.FillEllipse(Brushes.Blue, puntosLineaActual[0].X - 3, puntosLineaActual[0].Y - 3, 6, 6);
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (lineasDibujadas.Count == 0)
            {
                MessageBox.Show("Debes dibujar al menos una línea primero");
                return;
            }

            // Redibujar todo
            RedibujarTodo();
            
            string resultado = "RESULTADOS:\n\n";
            int lineaNum = 1;
            
            // Procesar cada línea
            foreach (var linea in lineasDibujadas)
            {
                // Aplicar algoritmo Liang-Barsky
                Point[] lineaRecortada = algoritmo.RecortarLinea(
                    linea.p1.X, linea.p1.Y,
                    linea.p2.X, linea.p2.Y,
                    xmin, ymin, xmax, ymax
                );
                
                if (lineaRecortada != null && lineaRecortada.Length == 2)
                {
                    // Dibujar línea recortada en rojo
                    g.DrawLine(penRecortada, lineaRecortada[0], lineaRecortada[1]);
                    resultado += $"Línea {lineaNum}: VISIBLE\n";
                }
                else
                {
                    resultado += $"Línea {lineaNum}: FUERA\n";
                }
                lineaNum++;
            }
            
            lblResultado.Text = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            puntosLineaActual.Clear();
            lineasDibujadas.Clear();
            lblResultado.Text = "Haz 2 clicks para cada línea que quieras dibujar";
            
            g = picCanvas.CreateGraphics();
            g.Clear(Color.White);
            DibujarRectanguloRecorte();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            puntosLineaActual.Add(new Point(e.X, e.Y));
            
            g = picCanvas.CreateGraphics();
            // Dibujar punto
            g.FillEllipse(Brushes.Blue, e.X - 3, e.Y - 3, 6, 6);
            
            if (puntosLineaActual.Count == 2)
            {
                // Dibujar la línea
                g.DrawLine(penOriginal, puntosLineaActual[0], puntosLineaActual[1]);
                
                // Guardar la línea
                lineasDibujadas.Add((puntosLineaActual[0], puntosLineaActual[1]));
                
                lblResultado.Text = $"{lineasDibujadas.Count} línea(s) dibujada(s).\nHaz 2 clicks para otra línea o presiona CALCULAR";
                
                // Limpiar puntos actuales para la siguiente línea
                puntosLineaActual.Clear();
            }
            else
            {
                lblResultado.Text = $"Punto 1 de línea {lineasDibujadas.Count + 1}.\nHaz click para el segundo punto";
            }
        }

        private void FrmLiangBarsky_Load(object sender, EventArgs e)
        {
            this.Text = "Algoritmo Liang-Barsky - Recorte de Líneas";
            lblResultado.Text = "Haz 2 clicks para cada línea que quieras dibujar";
            DibujarRectanguloRecorte();
        }

        private void FrmLiangBarsky_Paint(object sender, PaintEventArgs e)
        {
            RedibujarTodo();
        }
    }
}
