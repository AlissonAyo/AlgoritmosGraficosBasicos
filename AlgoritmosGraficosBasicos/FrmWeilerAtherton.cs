using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmWeilerAtherton : Form
    {
        private static FrmWeilerAtherton _instance;
        private AlgoritmoWeilerAtherton algoritmo = new AlgoritmoWeilerAtherton();
        private List<Point> puntosClick = new List<Point>();
        private List<Point> figuraActual = null;
        private List<Point> figuraRecortada = null;
        private Graphics g;
        private Pen penOriginal = new Pen(Color.Blue, 2);
        private Pen penRecortado = new Pen(Color.Green, 3);
        private Pen penRectangulo = new Pen(Color.Black, 2);
        private bool dibujarPoligono = false;
        
        // Rectángulo de recorte predefinido
        private int xmin = 150;
        private int ymin = 100;
        private int xmax = 450;
        private int ymax = 400;

        public static FrmWeilerAtherton Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmWeilerAtherton();
                }
                return _instance;
            }
        }

        public FrmWeilerAtherton()
        {
            InitializeComponent();
            this.FormClosing += FrmWeilerAtherton_FormClosing;
        }

        private void FrmWeilerAtherton_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiberarRecursos();
        }

        private void LiberarRecursos()
        {
            if (g != null)
            {
                g.Dispose();
                g = null;
            }
            
            if (penOriginal != null)
            {
                penOriginal.Dispose();
                penOriginal = null;
            }
            
            if (penRecortado != null)
            {
                penRecortado.Dispose();
                penRecortado = null;
            }
            
            if (penRectangulo != null)
            {
                penRectangulo.Dispose();
                penRectangulo = null;
            }
        }

        private void DibujarRectanguloRecorte()
        {
            if (picCanvas != null && picCanvas.IsHandleCreated)
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                g.DrawRectangle(penRectangulo, xmin, ymin, xmax - xmin, ymax - ymin);
                
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                {
                    g.DrawString("Área de Recorte", font, Brushes.Black, xmin + 10, ymin + 10);
                }
            }
        }

        private void RedibujarTodo()
        {
            if (picCanvas != null && picCanvas.IsHandleCreated)
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                g.Clear(Color.White);
                
                DibujarRectanguloRecorte();
                
                if (figuraActual != null && figuraActual.Count >= 3)
                {
                    g.DrawPolygon(penOriginal, figuraActual.ToArray());
                    
                    foreach (var punto in figuraActual)
                    {
                        g.FillEllipse(Brushes.Blue, punto.X - 3, punto.Y - 3, 6, 6);
                    }
                }
                
                if (puntosClick.Count > 0)
                {
                    foreach (var punto in puntosClick)
                    {
                        g.FillEllipse(Brushes.Blue, punto.X - 3, punto.Y - 3, 6, 6);
                    }
                    
                    if (puntosClick.Count > 1)
                    {
                        for (int i = 0; i < puntosClick.Count - 1; i++)
                        {
                            g.DrawLine(penOriginal, puntosClick[i], puntosClick[i + 1]);
                        }
                    }
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (figuraActual == null || figuraActual.Count < 3)
            {
                MessageBox.Show("Debes dibujar al menos un polígono primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RedibujarTodo();
            
            figuraRecortada = algoritmo.RecortarPoligono(figuraActual, xmin, ymin, xmax, ymax);
            
            if (figuraRecortada.Count == 0)
            {
                lblResultado.Text = "RESULTADOS:\n\nPolígono\ncompletamente\nFUERA";
                MessageBox.Show("El polígono está completamente FUERA del área de recorte", 
                              "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (TodosPuntosDentro(figuraActual))
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.Green)))
                {
                    g.FillPolygon(brush, figuraRecortada.ToArray());
                }
                g.DrawPolygon(penRecortado, figuraRecortada.ToArray());
                
                lblResultado.Text = $"RESULTADOS:\n\nPolígono\ncompletamente\nDENTRO\n{figuraRecortada.Count} vértices";
                MessageBox.Show($"El polígono está completamente DENTRO del área de recorte\n\n" +
                              $"No requiere recorte\nVértices: {figuraRecortada.Count}", 
                              "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                
                DibujarRectanguloRecorte();
                g.DrawPolygon(penOriginal, figuraActual.ToArray());
                
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.Green)))
                {
                    g.FillPolygon(brush, figuraRecortada.ToArray());
                }
                g.DrawPolygon(penRecortado, figuraRecortada.ToArray());
                
                lblResultado.Text = $"RESULTADOS:\n\nPolígono\nRECORTADO\n\nOriginal: {figuraActual.Count}\nRecortado: {figuraRecortada.Count}";
                MessageBox.Show($"Polígono recortado exitosamente!\n\n" +
                              $"Vértices originales: {figuraActual.Count}\n" +
                              $"Vértices recortados: {figuraRecortada.Count}", 
                              "Recorte Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool TodosPuntosDentro(List<Point> puntos)
        {
            foreach (var punto in puntos)
            {
                if (punto.X < xmin || punto.X > xmax || punto.Y < ymin || punto.Y > ymax)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            puntosClick.Clear();
            figuraActual = null;
            figuraRecortada = null;
            lblResultado.Text = "";
            
            if (g != null) g.Dispose();
            g = picCanvas.CreateGraphics();
            g.Clear(Color.White);
            DibujarRectanguloRecorte();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (figuraActual != null) return;
                
                puntosClick.Add(new Point(e.X, e.Y));
                RedibujarTodo();
            }
            else if (e.Button == MouseButtons.Right && puntosClick.Count >= 3)
            {
                figuraActual = new List<Point>(puntosClick);
                puntosClick.Clear();
                
                RedibujarTodo();
            }
        }

        private void FrmWeilerAtherton_Load(object sender, EventArgs e)
        {
            this.Text = "Algoritmo Weiler-Atherton - Recorte de Polígonos";
            lblResultado.Text = "";
            DibujarRectanguloRecorte();
        }

        private void FrmWeilerAtherton_Paint(object sender, PaintEventArgs e)
        {
            RedibujarTodo();
        }
    }
}
