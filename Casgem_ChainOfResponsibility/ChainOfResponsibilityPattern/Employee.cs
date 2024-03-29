﻿using Casgem_ChainOfResponsibility.Models;

namespace Casgem_ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee Supervisor)
        {
            this.NextApprover = Supervisor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel req);

    }
}
