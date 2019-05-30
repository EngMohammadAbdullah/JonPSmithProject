using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Department : EntityBase
    {

        public string Name { get; set; }
        public string Specialist { get; set; }


        public virtual ICollection<Student> DepartmentSudent { get; set; }
        public Department()
        {
            DepartmentSudent = new HashSet<Student>();

        }
    }
}
