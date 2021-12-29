using Cau1.DepartmentDALL;
using Cau1.DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmloyeeBAL
{
    public class DepartmentBUS
    {
        DepartmentDAL dep = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> lstdep = dep.ReadDepartmentList();
            return lstdep;
        }
    }
}
