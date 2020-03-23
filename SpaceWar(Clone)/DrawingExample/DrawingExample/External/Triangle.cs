using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LineDraw
{
    class Triangle
    {
        Vector2 PointA;
        Vector2 PointB;
        Vector2 PointC;
        Color LineColor;
        float Width;

        public Triangle() { }
        public Triangle(float width, Color color, Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            Width = width;
            LineColor = color;
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;

        }

    }
}
