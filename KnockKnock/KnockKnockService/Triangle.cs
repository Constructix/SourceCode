namespace Services
{
    public class Triangle
    {
        public int SideA { get; }
        public int SideB { get; }
        public int SideC { get; }

        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }


        public static string TriangleType(Triangle triangle)
        {
            if (triangle.SideA  == triangle.SideB && triangle.SideA == triangle.SideC && triangle.SideB == triangle.SideC)
                return Constants.TriangleTypes.Equilateral;
            else if (triangle.SideA == triangle.SideB || triangle.SideA == triangle.SideC || triangle.SideB == triangle.SideC)
                return Constants.TriangleTypes.Isosceles;
            else if (triangle.SideA != triangle.SideB || triangle.SideA != triangle.SideC || triangle.SideB != triangle.SideC)
                return Constants.TriangleTypes.Scalene;
            return Constants.TriangleTypes.Error;
        }
    }
}