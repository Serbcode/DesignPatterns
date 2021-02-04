using System;

namespace FactoryMethodPattern2
{
    class Program
    {
        static int Main(string[] args)
        {
            IVehicle vehicle = new VehicleFactory().CreateVehicle(VehicleType.ThreeWheeler);
            vehicle.Print();
            return 0;
        }
    }
}
