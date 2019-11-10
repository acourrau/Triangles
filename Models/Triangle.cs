using System;

namespace TriangleApi.Models
{
    public class Triangle
    {
        public string name { get; set; }
        public Point[] points { get ; set; }
        
        public Triangle(Point vert1, Point vert2, Point vert3) {
            points = new Point[3];
            points[0] = vert1;
            points[1] = vert2;
            points[2] = vert3;
        }

        public Triangle(string name, Point vert1, Point vert2, Point vert3) {
            this.name = name;
            points = new Point[3];
            points[0] = vert1;
            points[1] = vert2;
            points[2] = vert3;
        }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3) {
            points = new Point[3];
            points[0] = new Point(x1, y1);
            points[1] = new Point(x2, y2);
            points[2] = new Point(x3, y3);
        }

        public Triangle(int col, int row, int triangle_size) {
            points = new Point[3];

            // Point 1x = floor((col-1)/2) * TRIANGLE_SIZE
            // Point 1y = (row - 1) * TRIANGLE_SIZE
            points[0] = new Point(triangle_size * (int)(Math.Floor((double) ((col - 1)/2)) ), 
                                 triangle_size * (row - 1));
            // Point 2x = floor((col)/2) * TRIANGLE_SIZE
            // Point 2y = ((col % 2) + (row - 1)) * TRIANGLE_SIZE
            points[1] = new Point(triangle_size * (int)(Math.Floor((double) (col/2) )),
                                 triangle_size * ((col % 2) + (row - 1)) );
            // Point 3x = (floor((col-1)/2) + 1) * TRIANGLE_SIZE
            // Point 3y = row * TRIANGLE_SIZE
            points[2] = new Point(triangle_size * ((int)(Math.Floor((double) ((col - 1)/2))) + 1),
                                 triangle_size * row);
        }

        public string TriangleName(Triangle tri) {
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

        public bool HasPoint(Point test) {
            foreach(Point p in points) {
                if (p.Equals(test)) {
                    return true;
                }
            }
            return false;
        }

        public bool HasOverlappingPoints() {
            return (points[0].Equals(points[1]) || 
                    points[0].Equals(points[2]) ||
                    points[1].Equals(points[2]));
        }

        public override string ToString() {
            return points[0].ToString() + "," + points[1].ToString() + "," + points[2].ToString();
        }
    }
}