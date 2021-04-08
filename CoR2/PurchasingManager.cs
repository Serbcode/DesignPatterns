using System;

namespace CoR2
{
    public class PurchasingManager : Approver
    {
        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Price < 2500)
                Console.WriteLine("{0} approved purchase request #{1}\n", this.GetType().Name, purchaseOrder.RequestNumber);
            else
            {
                if (Supervisor != null)
                {
                    Supervisor.ProcessRequest(purchaseOrder);
                }
            }
        }
    }
}
