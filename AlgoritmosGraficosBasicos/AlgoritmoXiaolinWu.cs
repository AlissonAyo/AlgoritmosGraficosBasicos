using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoXiaolinWu : DibujarLinea
    {
        // Función para obtener la parte fraccional de un número
        private float FraccionParte(float x)
        {
            return x - (float)Math.Floor(x);
        }

        // Función para obtener la parte entera de un número
        private int ParteEntera(float x)
        {
            return (int)Math.Floor(x);
        }

        // Función para intercambiar dos valores
        private void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public override void CalcularPuntos(PictureBox picCanvas, Pen pen)
        {
            bool empinada = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
            
            int px1 = x1, py1 = y1, px2 = x2, py2 = y2;

            // Si la línea es empinada, intercambiamos x e y
            if (empinada)
            {
                Intercambiar(ref px1, ref py1);
                Intercambiar(ref px2, ref py2);
            }

            // Asegurar que vamos de izquierda a derecha
            if (px1 > px2)
            {
                Intercambiar(ref px1, ref px2);
                Intercambiar(ref py1, ref py2);
            }

            float dx = px2 - px1;
            float dy = py2 - py1;
            float gradiente = dy / dx;

            // Manejar primer punto final
            int xend = px1;
            float yend = py1 + gradiente * (xend - px1);
            float xgap = 1 - FraccionParte(px1 + 0.5f);
            int xpxl1 = xend; // esto será usado en el bucle principal
            int ypxl1 = ParteEntera(yend);

            if (empinada)
            {
                GraficarPixelConIntensidad(picCanvas, ypxl1, xpxl1, (1 - FraccionParte(yend)) * xgap, pen.Color);
                GraficarPixelConIntensidad(picCanvas, ypxl1 + 1, xpxl1, FraccionParte(yend) * xgap, pen.Color);
                EscribirCoordenadas(ypxl1, xpxl1);
            }
            else
            {
                GraficarPixelConIntensidad(picCanvas, xpxl1, ypxl1, (1 - FraccionParte(yend)) * xgap, pen.Color);
                GraficarPixelConIntensidad(picCanvas, xpxl1, ypxl1 + 1, FraccionParte(yend) * xgap, pen.Color);
                EscribirCoordenadas(xpxl1, ypxl1);
            }

            float intery = yend + gradiente; // primera intersección y para el bucle principal

            // Manejar segundo punto final
            xend = px2;
            yend = py2 + gradiente * (xend - px2);
            xgap = FraccionParte(px2 + 0.5f);
            int xpxl2 = xend; // esto será usado en el bucle principal
            int ypxl2 = ParteEntera(yend);

            if (empinada)
            {
                GraficarPixelConIntensidad(picCanvas, ypxl2, xpxl2, (1 - FraccionParte(yend)) * xgap, pen.Color);
                GraficarPixelConIntensidad(picCanvas, ypxl2 + 1, xpxl2, FraccionParte(yend) * xgap, pen.Color);
                EscribirCoordenadas(ypxl2, xpxl2);
            }
            else
            {
                GraficarPixelConIntensidad(picCanvas, xpxl2, ypxl2, (1 - FraccionParte(yend)) * xgap, pen.Color);
                GraficarPixelConIntensidad(picCanvas, xpxl2, ypxl2 + 1, FraccionParte(yend) * xgap, pen.Color);
                EscribirCoordenadas(xpxl2, ypxl2);
            }

            // Bucle principal
            if (empinada)
            {
                for (int x = xpxl1 + 1; x < xpxl2; x++)
                {
                    GraficarPixelConIntensidad(picCanvas, ParteEntera(intery), x, 1 - FraccionParte(intery), pen.Color);
                    GraficarPixelConIntensidad(picCanvas, ParteEntera(intery) + 1, x, FraccionParte(intery), pen.Color);
                    EscribirCoordenadas(ParteEntera(intery), x);
                    intery += gradiente;

                    // Pequeña pausa para visualización
                    Task.Delay(1).Wait();
                }
            }
            else
            {
                for (int x = xpxl1 + 1; x < xpxl2; x++)
                {
                    GraficarPixelConIntensidad(picCanvas, x, ParteEntera(intery), 1 - FraccionParte(intery), pen.Color);
                    GraficarPixelConIntensidad(picCanvas, x, ParteEntera(intery) + 1, FraccionParte(intery), pen.Color);
                    EscribirCoordenadas(x, ParteEntera(intery));
                    intery += gradiente;

                    // Pequeña pausa para visualización
                    Task.Delay(1).Wait();
                }
            }
        }
    }
}