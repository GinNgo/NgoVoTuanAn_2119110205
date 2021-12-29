

using Cau1.EmloyeeDALL;
using Cau1.EmloyeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmloyeeBAL
{
    public class EmployeeBUS
    {
        EmployeeDAL dep = new EmployeeDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> lstCus = dep.ReadEmployee();
            return lstCus;
        }
        public void NewEmployee(EmployeeBEL emp)
        {
            dep.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeBEL emp)
        {
            dep.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeBEL emp)
        {
            dep.EditEmployee(emp);
        }
    }
}
