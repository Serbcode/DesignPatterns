using System;

namespace CoR2
{
    public class HeadChef : Approver
    {
        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Price < 1000)
            {
                Console.WriteLine("{0} approved purchase request #{1}\n", this.GetType().Name, purchaseOrder.RequestNumber);
            }
            else
            {
                if (Supervisor != null)
                    Supervisor.ProcessRequest(purchaseOrder);
            }
        }
    }
}
