using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern2
{
    public enum VehicleType
    {
        TwoWheeler, FourWheeler, ThreeWheeler
    }

    public interface IVehicle
    {
        public void Print();
    }

    public class TwoWheeler : IVehicle
    {
        public void Print() => Console.WriteLine("I am 2 Wheeler");
    }

    public class FourWheeler : IVehicle
    {
        public void Print() => Console.WriteLine("I am 4 Wheeler");
    }

    public class ThreeWheeler : IVehicle
    {
        public void Print() => Console.WriteLine("I am 3 Wheeler");
    }

    public class VehicleFactory
    {
        public IVehicle CreateVehicle(VehicleType vehicleType)
        {
            IVehicle vehicle = vehicleType switch
            {
                VehicleType.TwoWheeler => new TwoWheeler(),
                VehicleType.FourWheeler => new FourWheeler(),
                VehicleType.ThreeWheeler => new ThreeWheeler(),
                _ => throw new NotImplementedException()
            };

            return vehicle;            
        }
    }

}
