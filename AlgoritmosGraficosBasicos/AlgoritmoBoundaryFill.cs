using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoBoundaryFill : TablaPuntos
    {
        private Color colorRelleno = Color.Red;
        private Color colorBorde = Color.Black;
        private Color colorFondo = Color.White;

        public void RellenarBoundary(PictureBox picCanvas, int x, int y)
        {
            if (x < 0 || x >= picCanvas.Width || y < 0 || y >= picCanvas.Height)
                return;

            // Obtener el color del pixel actual
            Bitmap bitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(colorFondo);
            }

            // Si ya hay una imagen en el PictureBox, usarla como base
            if (picCanvas.Image != null)
            {
                bitmap = new Bitmap(picCanvas.Image);
            }

            RellenarRecursivo(bitmap, x, y);

            picCanvas.Image = bitmap;
        }

        private void RellenarRecursivo(Bitmap bitmap, int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            Color pixelColor = bitmap.GetPixel(x, y);

            // Si el pixel no es del color de fondo o ya está rellenado, detener
            if (pixelColor.ToArgb() != colorFondo.ToArgb() || pixelColor.ToArgb() == colorRelleno.ToArgb())
                return;

            // Rellenar el pixel actual
            bitmap.SetPixel(x, y, colorRelleno);
            EscribirCoordenadas(x, y);

            // Aplicar recursión en las 4 direcciones
            RellenarRecursivo(bitmap, x + 1, y);     // Derecha
            RellenarRecursivo(bitmap, x - 1, y);     // Izquierda
            RellenarRecursivo(bitmap, x, y + 1);     // Abajo
            RellenarRecursivo(bitmap, x, y - 1);     // Arriba
        }

        public void DibujarBorde(PictureBox picCanvas, List<Point> puntos)
        {
            if (puntos == null || puntos.Count < 3)
                return;

            Bitmap bitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(colorFondo);
                
                // Dibujar el contorno del polígono
                using (Pen pen = new Pen(colorBorde, 2))
                {
                    g.DrawPolygon(pen, puntos.ToArray());
                }
            }

            picCanvas.Image = bitmap;
        }

        public void SetColores(Color relleno, Color borde, Color fondo)
        {
            colorRelleno = relleno;
            colorBorde = borde;
            colorFondo = fondo;
        }
    }
}