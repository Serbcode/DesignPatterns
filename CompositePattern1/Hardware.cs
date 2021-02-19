using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern1
{
    internal class Hardware : Product
    {
        public Hardware(string name, float cost) : base(name, cost)
        {
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override string ToString()
        {
            return $"Hardware: {this.Name}, Price: {this.Cost}";
        }

        protected override float GetCost()
        {
            return this.cost;
        }
    }
}
