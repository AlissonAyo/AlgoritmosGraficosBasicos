using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmBoundaryFill : Form
    {
        private static FrmBoundaryFill _instance;
        Graphics g;
        Pen pen = new Pen(Color.Black, 2);
        private List<Point> puntosClick = new List<Point>();
        private AlgoritmoSutherlandHodgman algoritmoRecorte = new AlgoritmoSutherlandHodgman();
        private bool dibujarPoligono = false;
        private List<Point> figuraActual = null;
        private List<Point> figuraRecortada = null;
        private Pen penOriginal = new Pen(Color.Blue, 2);
        private Pen penRecortado = new Pen(Color.Purple, 3);
        private Pen penRectangulo = new Pen(Color.Black, 2);
        
        // Rectángulo de recorte predefinido
        private int xmin = 150;
        private int ymin = 100;
        private int xmax = 450;
        private int ymax = 400;

        public static FrmBoundaryFill Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmBoundaryFill();
                }
                return _instance;
            }
        }

        public FrmBoundaryFill()
        {
            InitializeComponent();
            InicializarComponentes();
            this.FormClosing += FrmBoundaryFill_FormClosing;
        }

        private void FrmBoundaryFill_FormClosing(object sender, FormClosingEventArgs e)
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
            
            if (pen != null)
            {
                pen.Dispose();
                pen = null;
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

        private void InicializarComponentes()
        {
            // Agregar items al ComboBox
            cmbFiguras.Items.AddRange(new string[] 
            {
                "Seleccionar figura...",
                "Triángulo",
                "Cuadrado", 
                "Pentágono",
                "Hexágono",
                "Círculo",
                "Personalizado"
            });
            
            cmbFiguras.SelectedIndex = 0;
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

        private void cmbFiguras_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCanvas();
            
            if (cmbFiguras.SelectedIndex == 0) return;
            
            string figuraSeleccionada = cmbFiguras.SelectedItem.ToString();
            
            switch (figuraSeleccionada)
            {
                case "Triángulo":
                    figuraActual = CrearTriangulo();
                    break;
                case "Cuadrado":
                    figuraActual = CrearCuadrado();
                    break;
                case "Pentágono":
                    figuraActual = CrearPentagono();
                    break;
                case "Hexágono":
                    figuraActual = CrearHexagono();
                    break;
                case "Círculo":
                    figuraActual = CrearCirculo();
                    break;
                case "Personalizado":
                    dibujarPoligono = true;
                    puntosClick.Clear();
                    figuraActual = null;
                    MessageBox.Show("Haz clicks para crear tu figura:\n\n• Click IZQUIERDO: Agregar puntos\n• Click DERECHO: Finalizar (mín. 3 puntos)", 
                                  "Modo Personalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (figuraActual != null)
            {
                RedibujarTodo();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (figuraActual == null || figuraActual.Count < 3)
            {
                MessageBox.Show("Primero selecciona o dibuja una figura", "Aviso", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            figuraRecortada = algoritmoRecorte.RecortarPoligono(figuraActual, xmin, ymin, xmax, ymax);
            
            RedibujarTodo();
            
            if (figuraRecortada != null && figuraRecortada.Count >= 3)
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                
                g.DrawPolygon(penRecortado, figuraRecortada.ToArray());
                
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.Purple)))
                {
                    g.FillPolygon(brush, figuraRecortada.ToArray());
                }
                
                MessageBox.Show($"Polígono recortado con Boundary Fill!\n\n" +
                              $"Vértices originales: {figuraActual.Count}\n" +
                              $"Vértices recortados: {figuraRecortada.Count}", 
                              "Recorte Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El polígono está completamente FUERA del área de recorte", 
                              "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            LimpiarCanvas();
            cmbFiguras.SelectedIndex = 0;
            figuraActual = null;
            figuraRecortada = null;
            dibujarPoligono = false;
            puntosClick.Clear();
        }

        private List<Point> CrearTriangulo()
        {
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            return new List<Point>
            {
                new Point(centro.X, centro.Y - 100),
                new Point(centro.X - 100, centro.Y + 100),
                new Point(centro.X + 100, centro.Y + 100)
            };
        }

        private List<Point> CrearCuadrado()
        {
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            int lado = 150;
            return new List<Point>
            {
                new Point(centro.X - lado/2, centro.Y - lado/2),
                new Point(centro.X + lado/2, centro.Y - lado/2),
                new Point(centro.X + lado/2, centro.Y + lado/2),
                new Point(centro.X - lado/2, centro.Y + lado/2)
            };
        }

        private List<Point> CrearPentagono()
        {
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            int radio = 100;
            List<Point> puntos = new List<Point>();
            
            for (int i = 0; i < 5; i++)
            {
                double angulo = (Math.PI * 2 * i / 5) - Math.PI / 2;
                int x = (int)(centro.X + radio * Math.Cos(angulo));
                int y = (int)(centro.Y + radio * Math.Sin(angulo));
                puntos.Add(new Point(x, y));
            }
            
            return puntos;
        }

        private List<Point> CrearHexagono()
        {
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            int radio = 100;
            List<Point> puntos = new List<Point>();
            
            for (int i = 0; i < 6; i++)
            {
                double angulo = Math.PI * 2 * i / 6;
                int x = (int)(centro.X + radio * Math.Cos(angulo));
                int y = (int)(centro.Y + radio * Math.Sin(angulo));
                puntos.Add(new Point(x, y));
            }
            
            return puntos;
        }

        private List<Point> CrearCirculo()
        {
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            int radio = 100;
            List<Point> puntos = new List<Point>();
            
            for (int i = 0; i < 36; i++)
            {
                double angulo = Math.PI * 2 * i / 36;
                int x = (int)(centro.X + radio * Math.Cos(angulo));
                int y = (int)(centro.Y + radio * Math.Sin(angulo));
                puntos.Add(new Point(x, y));
            }
            
            return puntos;
        }

        private void LimpiarCanvas()
        {
            figuraRecortada = null;
            
            if (picCanvas != null && picCanvas.IsHandleCreated)
            {
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                g.Clear(Color.White);
                DibujarRectanguloRecorte();
            }
            
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dibujarPoligono) 
                return;

            if (e.Button == MouseButtons.Left)
            {
                puntosClick.Add(new Point(e.X, e.Y));
                RedibujarTodo();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (puntosClick.Count < 3)
                {
                    MessageBox.Show("Necesitas al menos 3 puntos para crear un polígono.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                figuraActual = new List<Point>(puntosClick);
                puntosClick.Clear();
                dibujarPoligono = false;
                
                RedibujarTodo();
                
                MessageBox.Show($"Figura personalizada creada con {figuraActual.Count} puntos.\n\nAhora presiona CALCULAR para recortar.", 
                              "Polígono Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmBoundaryFill_Load(object sender, EventArgs e)
        {
            this.Text = "Algoritmo Boundary Fill - Relleno por Límites con Recorte";
            DibujarRectanguloRecorte();
        }

        private void FrmBoundaryFill_Paint(object sender, PaintEventArgs e)
        {
            RedibujarTodo();
        }
    }
}