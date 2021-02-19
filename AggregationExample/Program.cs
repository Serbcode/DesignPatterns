using System;

namespace AggregationExample
{
    public class Address
    {
        private readonly string city;
        private readonly string state;
        private readonly string country;
        private readonly int street;

        public Address(string City, string State, string Country, int Street)
        {
            city = City;
            state = State;
            country = Country;
            street = Street;
        }

        public override string ToString()
        {
            return $"City: {city}, State:{state}, Country:{country}, Street: {street}";
        }
    }

    /* Student HAS Address */

    /// <summary>
    /// Class Student has property Address -> aggregation.
    /// </summary>
    public class Student 
    {
        private readonly int roll;
        private readonly string name;
        public Address Address { get; }

        public Student(int Roll, string Name, Address address)
        {
            roll = Roll;
            name = Name;
            this.Address = address;
        }
    }

    // Why we need Aggregation?
    // To maintain code re-usability! Use Address class in another class again:

    /// <summary>
    /// Class College has Address property as well. CODE RE-USE!
    /// </summary>
    public class College
    {
        private readonly string collegeName;
        public Address Address { get; }

        public College(string CollegeName, Address address)
        {
            collegeName = CollegeName;
            this.Address = address;
        }
    }



    // Aggregation example with Car and Engine.

    public abstract class Engine { }

    public class Car
    {
        private readonly Engine engine;

        public Car(Engine engine)
        {
            this.engine = engine;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(3, "Steve Vai", new Address("Magnolia", "Arkansas", "Columbia", 71));
            Console.WriteLine(student.Address);

            College college = new College("Dartmouth College", new Address("Hanover", "Minnesota", "Winona", 12));
            Console.WriteLine(college.Address);
        }
    }
}
