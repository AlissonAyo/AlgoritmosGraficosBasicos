using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmCirculoPuntoMedio : Form
    {
        private static FrmCirculoPuntoMedio _instance;
        private AlgoritmoCirculoPuntoMedio algoritmo = new AlgoritmoCirculoPuntoMedio();
        private Graphics g;
        private Pen pen = new Pen(Color.Green, 2);
        private int xCentro, yCentro, radio;
        private bool centroSeleccionado = false;

        public static FrmCirculoPuntoMedio Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmCirculoPuntoMedio();
                }
                return _instance;
            }
        }

        public FrmCirculoPuntoMedio()
        {
            InitializeComponent();
            this.FormClosing += FrmCirculoPuntoMedio_FormClosing;
        }

        private void FrmCirculoPuntoMedio_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FrmCirculoPuntoMedio_Load(object sender, EventArgs e)
        {
            this.Text = "Algoritmo de Círculo - Punto Medio";
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
                                  $"Algoritmo: Punto Medio";

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
                                      $"Algoritmo: Punto Medio";
                }
                
                centroSeleccionado = false;
            }
        }

        private void FrmCirculoPuntoMedio_Paint(object sender, PaintEventArgs e)
        {
            // Redibujar si es necesario
        }
    }
}
