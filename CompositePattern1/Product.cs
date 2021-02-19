using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern1
{
    internal abstract class Product
    {
        protected readonly float cost;

        public string Name { get; }
        public float Cost { get { return GetCost(); }}

        protected abstract float GetCost();

        public Product(string name, float cost)
        {
            this.Name = name;
            this.cost = cost;
        }

        public virtual void Add(Product product) { }

        public virtual void Remove(Product product) { }

        public abstract bool IsComposite();

    }
}
