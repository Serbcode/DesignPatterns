using System;

namespace BuilderPattern4
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                смысл шаблона Builder (Строитель/Построитель), в вынесении логики создания сложного объекта из клиентского кода.
                Далее, можно расширить функциональность шаблона:
                - создать различные билдеры для различных модификаций конечного продукта: GardenHouseBuilder - создает дом с садом, GarageHouseBuilder - дом с гаражом.
                - создать менеджера билдеров, который знает в какой последовательности должен строится дом.
                и т. д.
            */

            House house = new HouseBuilder()
                .BuildDoors(3)
                .BuildRoof(RoofType.Type2)
                .BuildWalls(14)
                .BuildGarden()
                .Build();

            house.Dump();

            // если порядок действий  важен - BuilderManager знает последовательность
            var dom = new BuilderManager(new HouseBuilder()).House;

            dom.Dump();
        }
    }
}
