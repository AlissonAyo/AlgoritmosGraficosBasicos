using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoCohenSutherland : AlgoritmoDDA
    {
        // Definición de códigos para las regiones del rectángulo
       
        private const int INSIDE = 0; // Código para el interior del rectángulo 
        private const int LEFT = 1;   // Código para el lado izquierdo del rectángulo
        private const int RIGHT = 2;  // Código para el lado derecho del rectángulo
        private const int BOTTOM = 4; // Código para el lado inferior del rectángulo
        private const int TOP = 8;    // Código para el lado superior del rectángulo
        Point[] puntos;
        Pen Pen = new Pen(Color.Red, 3);

        public void DibujarLinea(int x1, int y1, int x2, int y2, int xmax, int ymax, int xmin, int ymin, PictureBox picCanvas)
        {
           
            puntos = DibujarLineaCohen(x1, y1, x2, y2, xmax, ymax, xmin, ymin);
            if (puntos != null && puntos.Length == 2)
            {
                EscribirCoordenadas(puntos[0].X, puntos[0].Y);
                EscribirCoordenadas(puntos[1].X, puntos[1].Y);
                ObtenerPuntos(puntos[0].X, puntos[0].Y, puntos[1].X, puntos[1].Y);
                CalcularPuntos(picCanvas, Pen);
            }
        }

        public int Codificar(int xmax, int ymax, int xmin, int ymin, int x, int y)
        {
            int codigo = INSIDE;
            if (x < xmin) // A la izquierda del rectángulo
            {
                codigo |= LEFT;
            }
            else if (x > xmax) // A la derecha del rectángulo
            {
                codigo |= RIGHT;
            }
            if (y < ymin) // Por encima del rectángulo
            {
                codigo |= TOP;
            }
            else if (y > ymax) // Por debajo del rectángulo
            {
                codigo |= BOTTOM;
            }
            return codigo;

        }
        public Point[] DibujarLineaCohen(int x1, int y1, int x2, int y2, int xmax, int ymax, int xmin, int ymin)
        {
            int codigo1 = Codificar(xmax, ymax, xmin, ymin, x1, y1);
            int codigo2 = Codificar(xmax, ymax, xmin, ymin, x2, y2);
            while (true)
            {
                if ((codigo1 | codigo2) == 0) // Ambos puntos están dentro del rectángulo
                {

                    break;
                }
                else if ((codigo1 & codigo2) != 0) // Ambos puntos están fuera del rectángulo en la misma dirección
                {
                    break;
                }
                else
                {
                    // Al menos uno de los puntos está fuera del rectángulo
                    int codigoFuera = (codigo1 != 0) ? codigo1 : codigo2;
                    int x = 0, y = 0;
                    // Encontrar el punto de intersección con el borde del rectángulo
                    if ((codigoFuera & TOP) != 0) // Punto por encima del rectángulo
                    {
                        x = x1 + (x2 - x1) * (ymin - y1) / (y2 - y1);
                        y = ymin;
                    }
                    else if ((codigoFuera & BOTTOM) != 0) // Punto por debajo del rectángulo
                    {
                        x = x1 + (x2 - x1) * (ymax - y1) / (y2 - y1);
                        y = ymax;
                    }
                    else if ((codigoFuera & LEFT) != 0) // Punto a la izquierda del rectángulo
                    {
                        y = y1 + (y2 - y1) * (xmin - x1) / (x2 - x1);
                        x = xmin;
                    }
                    else if ((codigoFuera & RIGHT) != 0) // Punto a la derecha del rectángulo
                    {
                        y = y1 + (y2 - y1) * (xmax - x1) / (x2 - x1);
                        x = xmax;
                    }
                    // Actualizar el punto fuera del rectángulo
                    if (codigoFuera == codigo1)
                    {
                        x1 = x;
                        y1 = y;
                        codigo1 = Codificar(xmax, ymax, xmin, ymin, x1, y1);
                    }
                    else
                    {
                        x2 = x;
                        y2 = y;
                        codigo2 = Codificar(xmax, ymax, xmin, ymin, x2, y2);
                    }

                }
            }
            return new Point[] { new Point(x1, y1), new Point(x2, y2) };
        }
    }
}
