using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Student : EntityBase
    {

        public Guid DepartmentKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //-----------------------------------------------
        //relationships

        public Department DepartmentSection { get; set; }

    }
}
