using Casgem_ChainOfResponsibility.Dal;
using Casgem_ChainOfResponsibility.Models;

namespace Casgem_ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class Treasurer : Employee
    {
        Context c = new Context();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount<=50000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Buğra Dost";
                customerProcess.Description = "Müşteri tarafından talep ettiği tutar Veznedar tarafından ödendi";
                c.CustomerProcesses.Add(customerProcess); 
                c.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Buğra Dost";
                customerProcess.Description = "Müşteri tarafından talep edilen tutat günlük ödeme bakiyemi aştığı için işlemi şube müdür yardımcısına yönlendirdim";
                c.CustomerProcesses.Add(customerProcess);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
