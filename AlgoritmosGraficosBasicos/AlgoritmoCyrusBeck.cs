using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ayo_Alisson_Algoritmos
{
    /// <summary>
    /// Algoritmo de Recorte Simple basado en Cyrus-Beck
    /// Recorta polígonos convexos contra rectángulos
    /// </summary>
    internal class AlgoritmoCyrusBeck : TablaPuntos
    {
        public List<Point> RecortarPoligono(List<Point> poligono, int xmin, int ymin, int xmax, int ymax)
        {
            if (poligono == null || poligono.Count < 3)
                return new List<Point>();

            // Verificar si el polígono es convexo
            if (!EsConvexo(poligono))
            {
                // Si no es convexo, usar método alternativo
                return RecortarPoligonoNoConvexo(poligono, xmin, ymin, xmax, ymax);
            }

            List<Point> resultado = new List<Point>();

            // Definir los bordes del rectángulo con sus normales
            List<Edge> bordes = new List<Edge>
            {
                new Edge(new Point(xmin, ymin), new Point(xmax, ymin), new Point(0, -1)),  // Superior
                new Edge(new Point(xmax, ymin), new Point(xmax, ymax), new Point(1, 0)),   // Derecho
                new Edge(new Point(xmax, ymax), new Point(xmin, ymax), new Point(0, 1)),   // Inferior
                new Edge(new Point(xmin, ymax), new Point(xmin, ymin), new Point(-1, 0))   // Izquierdo
            };

            // Recortar cada arista del polígono
            for (int i = 0; i < poligono.Count; i++)
            {
                Point p1 = poligono[i];
                Point p2 = poligono[(i + 1) % poligono.Count];

                double tEntrada = 0;
                double tSalida = 1;
                Point d = new Point(p2.X - p1.X, p2.Y - p1.Y);

                bool visible = true;

                foreach (var borde in bordes)
                {
                    Point w = new Point(p1.X - borde.P1.X, p1.Y - borde.P1.Y);
                    double numerador = -(borde.Normal.X * w.X + borde.Normal.Y * w.Y);
                    double denominador = borde.Normal.X * d.X + borde.Normal.Y * d.Y;

                    if (Math.Abs(denominador) < 0.00001)
                    {
                        // Línea paralela al borde
                        if (numerador < 0)
                        {
                            visible = false;
                            break;
                        }
                    }
                    else
                    {
                        double t = numerador / denominador;

                        if (denominador < 0)
                        {
                            // Línea entrando
                            tEntrada = Math.Max(tEntrada, t);
                        }
                        else
                        {
                            // Línea saliendo
                            tSalida = Math.Min(tSalida, t);
                        }

                        if (tEntrada > tSalida)
                        {
                            visible = false;
                            break;
                        }
                    }
                }

                if (visible && tEntrada <= tSalida)
                {
                    if (tEntrada > 0)
                    {
                        int x = (int)(p1.X + tEntrada * d.X);
                        int y = (int)(p1.Y + tEntrada * d.Y);
                        resultado.Add(new Point(x, y));
                    }
                    else
                    {
                        resultado.Add(p1);
                    }

                    if (tSalida < 1)
                    {
                        int x = (int)(p1.X + tSalida * d.X);
                        int y = (int)(p1.Y + tSalida * d.Y);
                        resultado.Add(new Point(x, y));
                    }
                    else
                    {
                        resultado.Add(p2);
                    }
                }
            }

            // Eliminar puntos duplicados
            return EliminarDuplicados(resultado);
        }

        private List<Point> RecortarPoligonoNoConvexo(List<Point> poligono, int xmin, int ymin, int xmax, int ymax)
        {
            // Para polígonos no convexos, usar recorte por bordes
            List<Point> resultado = new List<Point>(poligono);

            // Recortar contra cada borde
            resultado = RecortarContraBordeVertical(resultado, xmin, true);
            resultado = RecortarContraBordeVertical(resultado, xmax, false);
            resultado = RecortarContraBordeHorizontal(resultado, ymin, true);
            resultado = RecortarContraBordeHorizontal(resultado, ymax, false);

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

        private bool EsConvexo(List<Point> poligono)
        {
            if (poligono.Count < 3) return false;

            bool signoPositivo = false;
            bool signoNegativo = false;

            for (int i = 0; i < poligono.Count; i++)
            {
                Point p1 = poligono[i];
                Point p2 = poligono[(i + 1) % poligono.Count];
                Point p3 = poligono[(i + 2) % poligono.Count];

                int cruz = ProductoCruz(p1, p2, p3);

                if (cruz > 0) signoPositivo = true;
                if (cruz < 0) signoNegativo = true;

                if (signoPositivo && signoNegativo)
                    return false;
            }

            return true;
        }

        private int ProductoCruz(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p2.Y) - (p2.Y - p1.Y) * (p3.X - p2.X);
        }

        private List<Point> EliminarDuplicados(List<Point> puntos)
        {
            List<Point> resultado = new List<Point>();
            Point? anterior = null;

            foreach (var punto in puntos)
            {
                if (anterior == null || !PuntosIguales(anterior.Value, punto))
                {
                    resultado.Add(punto);
                    anterior = punto;
                }
            }

            return resultado;
        }

        private bool PuntosIguales(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) < 2 && Math.Abs(p1.Y - p2.Y) < 2;
        }

        private class Edge
        {
            public Point P1 { get; set; }
            public Point P2 { get; set; }
            public Point Normal { get; set; }

            public Edge(Point p1, Point p2, Point normal)
            {
                P1 = p1;
                P2 = p2;
                Normal = normal;
            }
        }
    }
}
