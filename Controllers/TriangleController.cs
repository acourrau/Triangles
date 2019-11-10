using TriangleApi.Models;
using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace TriangleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriangleController : ControllerBase
   {
        private const int TRIANGLE_SIZE = 10;
        enum Rows {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6
        }

        [HttpGet]
        [Route("{id}")]
        public object Get(string id) {
            try {
                int col = Int32.Parse(id.Substring(1));
                int row = -1;
                Rows choice;
                if (Enum.TryParse(id.Substring(0, 1), true, out choice)) {
                    row = (int) choice;
                }
                else {
                    throw new Exception();
                }

                if (col <= 0 || col > 12) {
                    throw new Exception();
                }
                
                Triangle result = new Triangle(col, row, TRIANGLE_SIZE);
                result.name = id;
                return result;
            } catch {
                return "Error: Could not find that triangle.";
            }
        }

        [HttpGet]
        [Route("{x1}/{y1}/{x2}/{y2}/{x3}/{y3}")]
        public object Get(int x1, int y1, int x2, int y2, int x3, int y3) {
            Triangle tri = new Triangle(x1, y1, x2, y2, x3, y3);

            ArrayList errors = new ArrayList();
            errors = validatePoints(tri);

            if (errors.Count == 0) {
                tri.name = TriangleName(tri); 
                return tri;
            }
            else {
                return errors;
            }
        }

        private ArrayList validatePoints(Triangle tri) {
            ArrayList msgs = new ArrayList();
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            bool correctOrientation = false;
            foreach (Point v in tri.points) {
                // if you input a triangle like (0, 0), (15, 0), (15, 15), it's valid, just the wrong size
                // Also disallow negative coordinates
                if (v.X % TRIANGLE_SIZE != 0 || v.Y % TRIANGLE_SIZE != 0 || v.X < 0 || v.Y < 0) {
                    msgs.Add("Point " + v.ToString() + " is invalid.");
                }
                if (v.X > maxX) {
                    maxX = v.X;
                }
                if (v.Y > maxY) {
                    maxY = v.Y;
                }
                if (v.X < minX) {
                    minX = v.X;
                }
                if (v.Y < minY) {
                    minY = v.Y;
                }

                // Short-circuit, if we've already determined that the triangle has the correct 
                // hypotenuse, we don't need to waste memory or cycles re-checking it
                if (!correctOrientation && tri.HasPoint(new Point(v.X + TRIANGLE_SIZE, v.Y + TRIANGLE_SIZE))) {
                    correctOrientation = true;
                }
            }

            if (!correctOrientation) {
                msgs.Add("Invalid triangle, does not have the correct orientation.");
            }

            if (tri.HasOverlappingPoints()) {
                msgs.Add("Invalid triangle, has overlapping points.");
            }

            // Ensure points are appropriately spaced in X and Y
            if (maxX - minX != TRIANGLE_SIZE) {
                msgs.Add("Invalid triangle, width does not match triangle size.");
            }
            if (maxY - minY != TRIANGLE_SIZE) {
                msgs.Add("Invalid triangle, height does not match triangle size.");
            }

            return msgs;
        }

        private string TriangleName(Triangle tri) {
            int highestX = int.MinValue;
            int secondX = int.MinValue;
            int highestY = int.MinValue;

            foreach(Point p in tri.points) {
                if (p.X >= highestX) {
                    secondX = highestX;
                    highestX = p.X;
                }
                if (p.Y > highestY) {
                    highestY = p.Y;
                }
            }

            string col = ((highestX + secondX) / TRIANGLE_SIZE).ToString();
            string row = (string)Enum.GetName(typeof(Rows), (int)(highestY / TRIANGLE_SIZE));

            return row + col;
        }
    }
}