using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Ayo_Alisson_Algoritmos
{
    public partial class FrmRecorteDeLíneas : Form
    {
        private static FrmRecorteDeLíneas _instance;
        private Point[] vertices = new Point[4]; // Array para almacenar los vértices del recuadro de recorte
        private Point puntoInicio; // Punto de inicio de la línea a recortar
        private Point puntoFin; // Punto final de la línea a recortar
        private int clickCount = 0; // Contador de clicks para determinar el inicio y fin de la línea
        Pen pen = new Pen(Color.Black, 2); 
        private const int TAMANIO = 1; // Tamaño del recuadro de recorte
        AlgoritmoCohenSutherland algoritmoCohenSutherland = new AlgoritmoCohenSutherland(); // Instanciamos el algoritmo de Cohen-Sutherland
        AlgoritmoDDA algoritmoDDA = new AlgoritmoDDA(); // Instanciamos el algoritmo DDA
        public static FrmRecorteDeLíneas Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmRecorteDeLíneas();
                }
                return _instance;
            }
        }
        public FrmRecorteDeLíneas()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
           
            int centrox = picCanvas.Width / 2;
            int centroy = picCanvas.Height / 2;

            vertices[0] = new Point(centrox - 50, centroy - 50); // Esquina superior izquierda
            vertices[1] = new Point(centrox + 50, centroy - 50); // Esquina superior derecha
            vertices[2] = new Point(centrox + 50, centroy + 50); // Esquina inferior derecha
            vertices[3] = new Point(centrox - 50, centroy + 50); // Esquina inferior izquierda
            algoritmoDDA.ObtenerPuntos(vertices[0].X, vertices[0].Y, vertices[1].X, vertices[1].Y);
            algoritmoDDA.CalcularPuntos(picCanvas,pen);
            algoritmoDDA.ObtenerPuntos(vertices[1].X, vertices[1].Y, vertices[2].X, vertices[2].Y);
            algoritmoDDA.CalcularPuntos(picCanvas,pen);
            algoritmoDDA.ObtenerPuntos(vertices[2].X, vertices[2].Y, vertices[3].X, vertices[3].Y);
            algoritmoDDA.CalcularPuntos(picCanvas, pen);
            algoritmoDDA.ObtenerPuntos(vertices[3].X, vertices[3].Y, vertices[0].X, vertices[0].Y);
            algoritmoDDA.CalcularPuntos(picCanvas, pen);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {

            // Almacenar los puntos de la línea a recortar
            if (clickCount == 0)
            {
                puntoInicio = e.Location;
                clickCount++;
            }
            else if (clickCount == 1)
            {
                puntoFin = e.Location;
                clickCount = 0;

                // Obtener los límites del recuadro de recorte
                int xmin = Math.Min(vertices[0].X, vertices[2].X);
                int xmax = Math.Max(vertices[0].X, vertices[2].X);
                int ymin = Math.Min(vertices[0].Y, vertices[2].Y);
                int ymax = Math.Max(vertices[0].Y, vertices[2].Y);
                algoritmoDDA.ObtenerPuntos(puntoInicio.X, puntoInicio.Y, puntoFin.X, puntoFin.Y);
                algoritmoDDA.CalcularPuntos(picCanvas, pen);


                algoritmoCohenSutherland.DibujarLinea(
                    puntoInicio.X, puntoInicio.Y,
                    puntoFin.X, puntoFin.Y,
                    xmax, ymax, xmin, ymin,
                    picCanvas
                );
            }
        
            
        }
    }
}
