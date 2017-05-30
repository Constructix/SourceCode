namespace ConsoleApp1
{
    class CarToStringVisitor : ICarVisitor
    {
        private string carDetails;
        private string engineDetails;
        private string report;
        private int seatsCount;
        public string GetCarDescription()
        {
            return string.Format($"{carDetails} {engineDetails} {seatsCount}");
        }

        public void VisitEngine(float power, float cylinderVolume, float temperature)
        {
            engineDetails = string.Format($" {cylinderVolume}cc {power}kW");
        }

        public void VisitSeat(string name, int capacity)
        {
            this.seatsCount += capacity;
        }
        public void VisitCar(string make, string model)
        {
            carDetails = string.Format($"{make} {model}");
        }
    }
}