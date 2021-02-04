using System;

namespace BuilderPattern
{
    // This is the product class for Toy.
    public class Toy
    {
        public string Model { get; set; }
        public string Head { get; set; }
        public string Limbs { get; set; }
        public string Body { get; set; }
        public string Legs { get; set; }
        public void Dump()
        {
            Console.WriteLine($"Model: {Model}, Head: {Head}, Body: {Body}, Limbs: {Limbs}, Legs: {Legs}");
        }
    }

    // This is our IToyBuilder interface which will be implemented by the ConcreteBuilder classes.
    public interface IToyBuilder
    {
        public void SetModel();
        public void SetHead();
        public void SetLimbs();
        public void SetBody();
        public void SetLegs();
        public Toy GetToy();
    }

    // Below, we have 2 concrete classes for our two types of toys.
    public class ToyBuilderA : IToyBuilder
    {
        private Toy toy = new Toy();

        public void SetBody()
        {
            toy.Body = "plastic";
        }

        public void SetHead()
        {
            toy.Head = "1";
        }

        public void SetLegs()
        {
            toy.Legs = "2";
        }

        public void SetLimbs()
        {
            toy.Limbs = "4";
        }

        public void SetModel()
        {
            toy.Model = "TOY A";
        }

        public Toy GetToy()
        {
            return toy;
        }

    }

    public class ToyBuilderB : IToyBuilder
    {
        private Toy toy = new Toy();

        public Toy GetToy()
        {
            return toy;
        }

        public void SetBody()
        {
            toy.Body = "Steel";
        }

        public void SetHead()
        {
            toy.Head = "1";
        }

        public void SetLegs()
        {
            toy.Legs = "2";
        }

        public void SetLimbs()
        {
            toy.Limbs = "4";
        }

        public void SetModel()
        {
            toy.Model = "TOY B";
        }
    }

    // class which will be responsible for the construction of an object using the Builder Interface.
    public class ToyCreator
    {
        private IToyBuilder toyBuilder;

        public ToyCreator(IToyBuilder builder)
        {
            toyBuilder = builder;
        }

        public void CreateToy()
        {
            toyBuilder.SetModel();
            toyBuilder.SetBody();
            toyBuilder.SetHead();
            toyBuilder.SetLegs();
            toyBuilder.SetLimbs();
        }

        public Toy GetToy()
        {
            return toyBuilder.GetToy();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var toyACreator = new ToyCreator(new ToyBuilderA());
            toyACreator.CreateToy();
            toyACreator.GetToy().Dump();

            var toyBCreator = new ToyCreator(new ToyBuilderB());
            toyBCreator.CreateToy();
            toyBCreator.GetToy().Dump();

            Console.ReadKey();
        }
    }
}
