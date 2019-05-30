using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DbContextTest
    {

        EntitiesContext context = new EntitiesContext();

        [TestMethod]
        public void ConnectionStringFromAppSettingsIsNotNull()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["dbTest"].ToString();
            Assert.IsNotNull(connectionString);
        }

        [TestMethod]
        public void TestingConnectionString()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["dbTest"].ToString();
            //context.Database.Connection.Open();

            //Assert.AreEqual(context.Database.Connection.State, ConnectionState.Open);

        }




      //  [TestMethod]       
        //public void AddingEntityToDatabase()
        //{
        //    var count = context.Students.Count();



        //    var student = new Student()
        //    {
               
        //        FirstName = "Mohamed",
        //        LastName = "Abdullah"
        //    };

        //    context.Students.Add(student);
        //    context.SaveChanges();

        //    context.Students.Remove(student);
        //    context.SaveChanges();

        //    Assert.AreEqual(count, context.Students.Count());
        //}


    }
}
