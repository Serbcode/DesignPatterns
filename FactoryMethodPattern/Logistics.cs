using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    public abstract class Logistics
    {
        // factory method
        public abstract Transport CreateTransport();
    }

    public class RoadLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Track();
        }
    }

    public class SeaLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Ship();
        }
    }

    public class TrainLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Train();
        }
    }

    public class PlainLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Plain();
        }
    }

}
