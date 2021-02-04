using System;
using System.Collections.Generic;

namespace BuilderPattern3
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class CatalogueItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public List<Category> Categories { get; set; }

        public CatalogueItem()
        {
            // if we don't supply any Categories, we need a constructed
            // List here, Otherwise we'll get a null ref when we attempt
            // to access it.
            Categories = new List<Category>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Price: {Price}, Name: {Name}, Description: {Descripton}";    
        }
    }

    public static class CatalogueItemBuilder
    {
        public static CatalogueItem CreateBuilder()
        {
            return new CatalogueItem();
        }

        public static CatalogueItem WithId(this CatalogueItem cItem, int id)
        {
            cItem.Id = id;
            return cItem;
        }

        public static CatalogueItem WithName(this CatalogueItem cItem, string name)
        {
            cItem.Name = name;
            return cItem;
        }

        public static CatalogueItem WithPrice(this CatalogueItem cItem, double price)
        {
            cItem.Price = price;
            return cItem;
        }

        public static CatalogueItem WithDescription(this CatalogueItem cItem, string Description)
        {
            cItem.Descripton = Description;
            return cItem;
        }

        public static CatalogueItem WithCategories(this CatalogueItem cItem, List<Category> categories)
        {
            cItem.Categories = categories;
            return cItem;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // CatalogueItem version 1
            var catalogueItemV1 = CatalogueItemBuilder
                                    .CreateBuilder()
                                    .WithId(1)
                                    .WithName("V1 catalogue item")
                                    .WithPrice(9.99);

            // CatalogueItem version 2
            var catalogueItemV2 = CatalogueItemBuilder
                                    .CreateBuilder()
                                    .WithId(2)
                                    .WithName("V2 catalogue item")
                                    .WithPrice(12.99)
                        .WithDescription("A V2 catalogue item, which has a description, too");

            // CatalogueItem version 3
            var categoryList = new List<Category>() {
                new Category() { CategoryId = 1, CategoryName ="Toys"},
                new Category() { CategoryId = 2, CategoryName ="Games"},
                new Category() { CategoryId = 3, CategoryName ="Videos"},
            };

            var catalogueItemV3 = CatalogueItemBuilder
                                .CreateBuilder()
                                .WithId(3)
                                .WithName("V3 catalogue item")
                                .WithPrice(12.99)
                                .WithDescription("A V3 catalogue item, which has a description and some categories")
                        .WithCategories(categoryList);

            Console.WriteLine(catalogueItemV1);
            Console.WriteLine(catalogueItemV2);
            Console.WriteLine(catalogueItemV3);

        }
    }
}
