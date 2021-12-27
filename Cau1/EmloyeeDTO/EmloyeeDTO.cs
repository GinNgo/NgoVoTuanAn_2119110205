using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmloyeeDTO
{
    public class EmloyeeDTO
    {
        public string IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public bool Gender { get; set; }
        public string PlaceBirth { get; set; }
        public DepartmentDTO Department { get; set; }
        public string IdDepartment { get { return Department.Name; } }
    }
}
