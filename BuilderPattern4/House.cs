using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern4
{
    public enum RoofType
    {
        Type1, Type2, Type3
    }


    public class House
    {
        public int Walls { get; set; }
        public int Windows { get; set; }
        public int Doors { get; set; }
        public RoofType Roof { get; set; }

        public bool WithGarage { get; set; }
        public bool WithSwimmingPool { get; set; }
        public bool WithFancyStatues { get; set; }
        public bool WithGarden { get; set; }
        public bool WithSauna { get; set; }

        public void Dump()
        {
            Console.WriteLine("{0, -20} {1, 5}", "Walls", this.Walls);
            Console.WriteLine("{0, -20} {1, 5}", "Windows", this.Windows);
            Console.WriteLine("{0, -20} {1, 5}", "Doors", this.Doors);
            Console.WriteLine("{0, -20} {1, 5}", "Roof", this.Roof.ToString("G"));

            Console.WriteLine("{0, -20} {1, 5:N1}", "WithGarage", this.WithGarage);
            Console.WriteLine("{0, -20} {1, 5:N1}", "WithSwimmingPool", this.WithSwimmingPool);
            Console.WriteLine("{0, -20} {1, 5:N1}", "WithFancyStatues", this.WithFancyStatues);
            Console.WriteLine("{0, -20} {1, 5:N1}", "WithGarden", this.WithGarden);
            Console.WriteLine("{0, -20} {1, 5:N1}", "WithSauna", this.WithSauna);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Walls: {Walls}, Windows: {Windows}, Doors: {Doors}, Roof: {Roof}, Garage: {WithGarage}, SwimmingPool: {WithSwimmingPool}, FancyStatues: {WithFancyStatues}, Garden: {WithGarden}, Sauna: {WithSauna}";
        }
    }


    public interface IHouseBuilder
    {
        IHouseBuilder BuildWalls(int walls);
        IHouseBuilder BuildWindows(int windows);
        IHouseBuilder BuildDoors(int doors);
        IHouseBuilder BuildRoof(RoofType roofType);
        IHouseBuilder BuildGarage();
        IHouseBuilder BuildSwimmingPool();
        IHouseBuilder BuildFancyStatues();
        IHouseBuilder BuildGarden();
        IHouseBuilder BuildSauna();
        House Build();
    }

    // строитель знает как делать все этапы стройки
    public class HouseBuilder : IHouseBuilder
    {
        private readonly House house;

        public HouseBuilder()
        {
            house = new House();
        }

        public House Build()
        {
            return house;
        }

        public IHouseBuilder BuildDoors(int doors)
        {
            house.Doors = doors;
            return this;
        }

        public IHouseBuilder BuildFancyStatues()
        {
            house.WithFancyStatues = false;
            return this;
        }

        public IHouseBuilder BuildGarage()
        {
            house.WithGarage = false;
            return this;
        }

        public IHouseBuilder BuildGarden()
        {
            house.WithGarden = true;
            return this;
        }

        public IHouseBuilder BuildRoof(RoofType roofType)
        {
            house.Roof = roofType;
            return this;
        }

        public IHouseBuilder BuildSauna()
        {
            house.WithSauna = false;
            return this;
        }

        public IHouseBuilder BuildSwimmingPool()
        {
            house.WithSwimmingPool = false;
            return this;
        }

        public IHouseBuilder BuildWalls(int walls)
        {
            house.Walls = walls;
            return this;
        }

        public IHouseBuilder BuildWindows(int windows)
        {
            house.Windows = windows;
            return this;
        }
    }


    // менеджер знает порядок в котором строится дом
    public class BuilderManager
    {
        private readonly IHouseBuilder houseBuilder;
        public House House { get; }

        public BuilderManager(IHouseBuilder houseBuilder)
        {
            if (houseBuilder == null) throw new ArgumentNullException(nameof(houseBuilder));

            House = houseBuilder
                .BuildWalls(4)
                .BuildRoof(RoofType.Type3)
                .BuildWindows(12)
                .BuildDoors(5)
                .Build();
        }
    }
}
