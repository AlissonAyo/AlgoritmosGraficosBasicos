using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmCirculo8Segmentos : Form
    {
        private static FrmCirculo8Segmentos _instance;
        private AlgoritmoCirculo8Segmentos algoritmo = new AlgoritmoCirculo8Segmentos();
        private Graphics g;
        private Pen pen = new Pen(Color.Blue, 2);
        private int xCentro, yCentro, radio;
        private bool centroSeleccionado = false;

        public static FrmCirculo8Segmentos Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmCirculo8Segmentos();
                }
                return _instance;
            }
        }

        public FrmCirculo8Segmentos()
        {
            InitializeComponent();
            this.FormClosing += FrmCirculo8Segmentos_FormClosing;
        }

        private void FrmCirculo8Segmentos_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void FrmCirculo8Segmentos_Load(object sender, EventArgs e)
        {
            this.Text = "Algoritmo de Círculo - 8 Segmentos (Bresenham)";
            lblResultado.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                xCentro = int.Parse(txtXCentro.Text);
                yCentro = int.Parse(txtYCentro.Text);
                radio = int.Parse(txtRadio.Text);

                if (radio <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                g.Clear(Color.White);

                // Dibujar el círculo
                algoritmo.DibujarCirculo(picCanvas, xCentro, yCentro, radio, pen);

                // Dibujar el centro
                g.FillEllipse(Brushes.Red, xCentro - 3, yCentro - 3, 6, 6);

                var puntos = algoritmo.ObtenerPuntosCirculo(xCentro, yCentro, radio);
                
                lblResultado.Text = $"RESULTADOS:\n\n" +
                                  $"Centro: ({xCentro}, {yCentro})\n" +
                                  $"Radio: {radio}\n" +
                                  $"Puntos: {puntos.Count}\n" +
                                  $"Algoritmo: 8 Segmentos";

                MessageBox.Show($"Círculo dibujado exitosamente!\n\n" +
                              $"Centro: ({xCentro}, {yCentro})\n" +
                              $"Radio: {radio}\n" +
                              $"Puntos generados: {puntos.Count}", 
                              "Círculo Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtXCentro.Clear();
            txtYCentro.Clear();
            txtRadio.Clear();
            lblResultado.Text = "";
            centroSeleccionado = false;

            if (g != null) g.Dispose();
            g = picCanvas.CreateGraphics();
            g.Clear(Color.White);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!centroSeleccionado)
            {
                // Primer click: establecer centro
                xCentro = e.X;
                yCentro = e.Y;
                txtXCentro.Text = xCentro.ToString();
                txtYCentro.Text = yCentro.ToString();
                
                if (g != null) g.Dispose();
                g = picCanvas.CreateGraphics();
                g.FillEllipse(Brushes.Red, xCentro - 3, yCentro - 3, 6, 6);
                
                centroSeleccionado = true;
            }
            else
            {
                // Segundo click: calcular radio y dibujar
                int dx = e.X - xCentro;
                int dy = e.Y - yCentro;
                radio = (int)Math.Sqrt(dx * dx + dy * dy);
                txtRadio.Text = radio.ToString();
                
                if (radio > 0)
                {
                    algoritmo.DibujarCirculo(picCanvas, xCentro, yCentro, radio, pen);
                    
                    var puntos = algoritmo.ObtenerPuntosCirculo(xCentro, yCentro, radio);
                    
                    lblResultado.Text = $"RESULTADOS:\n\n" +
                                      $"Centro: ({xCentro}, {yCentro})\n" +
                                      $"Radio: {radio}\n" +
                                      $"Puntos: {puntos.Count}\n" +
                                      $"Algoritmo: 8 Segmentos";
                }
                
                centroSeleccionado = false;
            }
        }

        private void FrmCirculo8Segmentos_Paint(object sender, PaintEventArgs e)
        {
            // Redibujar si es necesario
        }
    }
}
