using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern1
{
    internal class HardwareBox : Product
    {
        private List<Product> products = new List<Product>();

        public HardwareBox(string name, float cost) : base(name, cost)
        {
        }

        public override void Add(Product product)
        {
            products.Add(product);
        }

        public override void Remove(Product product)
        {
            product.Remove(product);
        }

        public override bool IsComposite()
        {
            return true;
        }

        protected override float GetCost()
        {
            float res = this.cost;

            foreach (Product p in products)
            {
                res += p.Cost;    
            }

            return res;
        }
    }
}
