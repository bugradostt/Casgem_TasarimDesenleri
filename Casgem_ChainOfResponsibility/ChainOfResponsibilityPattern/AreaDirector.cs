using Casgem_ChainOfResponsibility.Dal;
using Casgem_ChainOfResponsibility.Models;

namespace Casgem_ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class AreaDirector : Employee
    {
        Context c = new Context();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {

            if (req.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Hakan Dost";
                customerProcess.Description = "Müşteri tarafından talep ettiği tutar Bölge Müdürü tarafından ödendi";
                c.CustomerProcesses.Add(customerProcess);
                c.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.EmployeeName = "Hakan Dost";
                customerProcess.Description = "Müşteri tarafından talep edilen tutat günlük ödeme bakiyemi aştığı için işlem gerçekleştirilemedi!";
                c.CustomerProcesses.Add(customerProcess);
                c.SaveChanges();
            }
        }
    }
}
