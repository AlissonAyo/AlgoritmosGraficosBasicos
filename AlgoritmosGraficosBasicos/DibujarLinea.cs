using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal abstract class DibujarLinea : TablaPuntos
    {
        public int x1, y1, x2, y2;

        public DibujarLinea()
        {
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
        }
        public void ObtenerPuntos(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public abstract void CalcularPuntos(PictureBox picCanvas, Pen pen);

       

    }
}
