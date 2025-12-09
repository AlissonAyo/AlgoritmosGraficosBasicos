using System;
using System.Drawing;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoNichollLeeNicholl : TablaPuntos
    {
        // Códigos de región similares a Cohen-Sutherland
        private const int INSIDE = 0;
        private const int LEFT = 1;
        private const int RIGHT = 2;
        private const int BOTTOM = 4;
        private const int TOP = 8;

        private int ComputeCode(int x, int y, int xmin, int ymin, int xmax, int ymax)
        {
            int code = INSIDE;
            
            if (x < xmin)
                code |= LEFT;
            else if (x > xmax)
                code |= RIGHT;
                
            if (y < ymin)
                code |= TOP;
            else if (y > ymax)
                code |= BOTTOM;
                
            return code;
        }

        public Point[] RecortarLinea(int x0, int y0, int x1, int y1, int xmin, int ymin, int xmax, int ymax)
        {
            int code0 = ComputeCode(x0, y0, xmin, ymin, xmax, ymax);
            int code1 = ComputeCode(x1, y1, xmin, ymin, xmax, ymax);
            
            bool accept = false;
            
            while (true)
            {
                if ((code0 | code1) == 0)
                {
                    // Ambos puntos dentro
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != 0)
                {
                    // Ambos puntos fuera en la misma región
                    break;
                }
                else
                {
                    // Calcular intersección
                    int x = 0, y = 0;
                    int codeOut = (code0 != 0) ? code0 : code1;
                    
                    // Calcular punto de intersección con el borde del rectángulo
                    if ((codeOut & TOP) != 0)
                    {
                        x = x0 + (x1 - x0) * (ymin - y0) / (y1 - y0);
                        y = ymin;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        x = x0 + (x1 - x0) * (ymax - y0) / (y1 - y0);
                        y = ymax;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        y = y0 + (y1 - y0) * (xmax - x0) / (x1 - x0);
                        x = xmax;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        y = y0 + (y1 - y0) * (xmin - x0) / (x1 - x0);
                        x = xmin;
                    }
                    
                    // Reemplazar el punto fuera con el punto de intersección
                    if (codeOut == code0)
                    {
                        x0 = x;
                        y0 = y;
                        code0 = ComputeCode(x0, y0, xmin, ymin, xmax, ymax);
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        code1 = ComputeCode(x1, y1, xmin, ymin, xmax, ymax);
                    }
                }
            }
            
            if (accept)
            {
                return new Point[] { new Point(x0, y0), new Point(x1, y1) };
            }
            
            return null;
        }
    }
}
