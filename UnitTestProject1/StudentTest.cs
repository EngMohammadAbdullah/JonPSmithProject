using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    [TestClass]
    public class StudentTest
    {
        EntitiesContext dbContext;
        public StudentTest()
        {
            dbContext = new EntitiesContext();
        }
        [TestMethod]
        public void Test_Intiating_Object()
        {
            Department department = new Department()
            {
                Name = "AI",
                Specialist = "Artifitial" ,
                
            };

            dbContext.Departments.Add(department);
            dbContext.SaveChanges();

            Student student = new Student()
            {
                FirstName = "Mohamed",
                LastName = "Abdullah",
                DepartmentKey = department.Key
            };

            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            Assert.IsTrue(Guid.TryParse(student.Key.ToString(), out Guid key));
        }
    }
}
