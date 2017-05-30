using System;

namespace ConsoleApp1
{
    class Engine
    {
        private float power;
        private float cylinderVolume;


        private const float WorkingTemperature = 90.0f;
        private float temperature = 20.0f;

        public Engine(float power, float cylinderVolume)
        {
            this.power = power;
            this.cylinderVolume = cylinderVolume;
        }


        public void Accept(ICarPartVisitor visitor)
        {
            visitor.VisitEngine(this.power,this.cylinderVolume,this.temperature);
        }

        public void Run(TimeSpan time)
        {
            TimeSpan heatingTime = GetHeatingTime();
            if (time > heatingTime)
            {
                this.temperature = WorkingTemperature;
            }
            else
            {
                double temperatureDelta = WorkingTemperature - this.temperature;
                double timeRatio = time.TotalMinutes / heatingTime.TotalMinutes;
                this.temperature += (float) (temperatureDelta * timeRatio);
            }
        }

        private TimeSpan GetHeatingTime()
        {
            return new TimeSpan(1,10,0);
        }
    }
}