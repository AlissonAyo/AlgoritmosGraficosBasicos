using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ayo_Alisson_Algoritmos
{
    /// <summary>
    /// Algoritmo Weiler-Atherton simplificado para recorte de polígonos
    /// Usa el mismo método confiable que Cyrus-Beck para recorte por bordes
    /// </summary>
    internal class AlgoritmoWeilerAtherton : TablaPuntos
    {
        public List<Point> RecortarPoligono(List<Point> poligono, int xmin, int ymin, int xmax, int ymax)
        {
            if (poligono == null || poligono.Count < 3)
                return new List<Point>();

            // Recortar contra cada borde usando el método que funciona
            List<Point> resultado = new List<Point>(poligono);

            // Recortar contra cada borde del rectángulo
            resultado = RecortarContraBordeVertical(resultado, xmin, true);   // Borde izquierdo
            resultado = RecortarContraBordeVertical(resultado, xmax, false);  // Borde derecho
            resultado = RecortarContraBordeHorizontal(resultado, ymin, true); // Borde superior
            resultado = RecortarContraBordeHorizontal(resultado, ymax, false);// Borde inferior

            return resultado;
        }

        private List<Point> RecortarContraBordeVertical(List<Point> poligono, int x, bool izquierda)
        {
            List<Point> resultado = new List<Point>();

            for (int i = 0; i < poligono.Count; i++)
            {
                Point actual = poligono[i];
                Point siguiente = poligono[(i + 1) % poligono.Count];

                bool actualDentro = izquierda ? actual.X >= x : actual.X <= x;
                bool siguienteDentro = izquierda ? siguiente.X >= x : siguiente.X <= x;

                if (actualDentro && siguienteDentro)
                {
                    resultado.Add(siguiente);
                }
                else if (actualDentro && !siguienteDentro)
                {
                    Point interseccion = InterseccionVertical(actual, siguiente, x);
                    if (interseccion != Point.Empty)
                        resultado.Add(interseccion);
                }
                else if (!actualDentro && siguienteDentro)
                {
                    Point interseccion = InterseccionVertical(actual, siguiente, x);
                    if (interseccion != Point.Empty)
                        resultado.Add(interseccion);
                    resultado.Add(siguiente);
                }
            }

            return resultado;
        }

        private List<Point> RecortarContraBordeHorizontal(List<Point> poligono, int y, bool arriba)
        {
            List<Point> resultado = new List<Point>();

            for (int i = 0; i < poligono.Count; i++)
            {
                Point actual = poligono[i];
                Point siguiente = poligono[(i + 1) % poligono.Count];

                bool actualDentro = arriba ? actual.Y >= y : actual.Y <= y;
                bool siguienteDentro = arriba ? siguiente.Y >= y : siguiente.Y <= y;

                if (actualDentro && siguienteDentro)
                {
                    resultado.Add(siguiente);
                }
                else if (actualDentro && !siguienteDentro)
                {
                    Point interseccion = InterseccionHorizontal(actual, siguiente, y);
                    if (interseccion != Point.Empty)
                        resultado.Add(interseccion);
                }
                else if (!actualDentro && siguienteDentro)
                {
                    Point interseccion = InterseccionHorizontal(actual, siguiente, y);
                    if (interseccion != Point.Empty)
                        resultado.Add(interseccion);
                    resultado.Add(siguiente);
                }
            }

            return resultado;
        }

        private Point InterseccionVertical(Point p1, Point p2, int x)
        {
            if (p2.X == p1.X) return Point.Empty;

            double t = (double)(x - p1.X) / (p2.X - p1.X);
            if (t < 0 || t > 1) return Point.Empty;

            int y = (int)(p1.Y + t * (p2.Y - p1.Y));
            return new Point(x, y);
        }

        private Point InterseccionHorizontal(Point p1, Point p2, int y)
        {
            if (p2.Y == p1.Y) return Point.Empty;

            double t = (double)(y - p1.Y) / (p2.Y - p1.Y);
            if (t < 0 || t > 1) return Point.Empty;

            int x = (int)(p1.X + t * (p2.X - p1.X));
            return new Point(x, y);
        }
    }
}
