namespace ConsoleApp1
{
    interface ICarVisitor : ICarPartVisitor
    {
        void VisitCar(string make, string model);
    }
}