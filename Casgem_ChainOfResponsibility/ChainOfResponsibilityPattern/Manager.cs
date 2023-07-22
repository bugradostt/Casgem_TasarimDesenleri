using Casgem_ChainOfResponsibility.Dal;
using Casgem_ChainOfResponsibility.Models;

namespace Casgem_ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class Manager : Employee
    {
        Context c = new Context();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {

            if (req.Amount <= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Baran Dost";
                customerProcess.Description = "Müşteri tarafından talep ettiği tutar Şube Müdürü tarafından ödendi";
                c.CustomerProcesses.Add(customerProcess);
                c.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Baran Dost";
                customerProcess.Description = "Müşteri tarafından talep edilen tutat günlük ödeme bakiyemi aştığı için işlemi bölge müdürüne yönlendirdim";
                c.CustomerProcesses.Add(customerProcess);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
