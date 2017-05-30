namespace ConsoleApp1
{
    interface ICarPartVisitor
    {
        void VisitEngine(float power, float cylinderVolume, float temperature);
        void VisitSeat(string name, int capacity);
    }
}