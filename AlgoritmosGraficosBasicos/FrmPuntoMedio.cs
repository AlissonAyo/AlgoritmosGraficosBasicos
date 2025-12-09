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
    public partial class FrmPuntoMedio : Form
    {
        private static FrmPuntoMedio _instance;
        Graphics g;
        Pen pen = new Pen(Color.Black, 2);
        DibujarLinea objdibujarLinea;

        public static FrmPuntoMedio Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmPuntoMedio();
                }
                return _instance;
            }
        }

        public FrmPuntoMedio()
        {
            InitializeComponent();
        }

        private void btnCalcularLinea_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtX1.Text) || string.IsNullOrWhiteSpace(txtY1.Text) ||
                    string.IsNullOrWhiteSpace(txtXf.Text) || string.IsNullOrWhiteSpace(txtYf.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener las coordenadas de los TextBox
                int x1 = int.Parse(txtX1.Text);
                int y1 = int.Parse(txtY1.Text);
                int x2 = int.Parse(txtXf.Text);
                int y2 = int.Parse(txtYf.Text);

                // Limpiar el canvas
                g = picCanvas.CreateGraphics();
                g.Clear(Color.White);

                // Crear instancia del algoritmo de Bresenham
                objdibujarLinea = new AlgortimoBresenham();
                objdibujarLinea.ObtenerPuntos(x1, y1, x2, y2);
                objdibujarLinea.CalcularPuntos(picCanvas, pen);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese solo números válidos en las coordenadas.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los TextBox
            txtX1.Clear();
            txtY1.Clear();
            txtXf.Clear();
            txtYf.Clear();

            // Limpiar el canvas
            g = picCanvas.CreateGraphics();
            g.Clear(Color.White);

            // Limpiar las coordenadas guardadas si existe una instancia
            if (objdibujarLinea != null)
            {
                objdibujarLinea.BorrarCoordenadas();
            }
        }
    }
}