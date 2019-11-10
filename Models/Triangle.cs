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