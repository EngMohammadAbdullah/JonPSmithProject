using Autofac;
using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class StudentEntity
    {
        public readonly IEntityRepository<Student> MockStudentsRepository;
        IQueryable<Student> students = new List<Student>
            {
                new Student(){
                FirstName="Mohamed",LastName="Abdullah"
                } , new Student(){
                FirstName="Hasan",LastName="Abdullah"
                } ,
                 new Student(){ 
                FirstName="Ammar",LastName="Abdullah"
                } ,
                    new Student(){
                FirstName="Shaza",LastName="Abdullah"
                }
            }.AsQueryable<Student>();
        public StudentEntity()
        {



            Mock<IEntityRepository<Student>> mockStudentRepository =
                new Mock<IEntityRepository<Student>>();


            mockStudentRepository.Setup(mr => mr.GetAll()).Returns(students);
            Expression<Func<Student, bool>> expr = s => s.Key.Equals(new Guid("06af9aa3-afcb-4e11-b893-1a610acd44f6"));
            // It.IsAny<Expression<Func<Student, bool>>>()
            mockStudentRepository.Setup(mr =>
            mr.FindBy(expr))
            .Returns((Student student) => students.Where(x => x.Key.Equals(student.Key)).Select(x => x).AsQueryable<Student>());


            // Allows us to test saving a product
            // Allows us to test saving a product

            mockStudentRepository.
                Setup(mr => mr.Add(It.IsAny<Student>())).Returns(

                (Student target) =>

                {
                    DateTime now = DateTime.Now;

                    if (target.Key.Equals(default(Guid)))
                    {

                        target.Key = Guid.NewGuid();

                        students.ToList<Student>().Add(target);

                    }

                    else
                    {
                        var original = students.Where(q => Guid.Equals(q.Key, target.Key)).Single();

                        if (original == null)
                        {
                            return false;
                        }



                        original.FirstName = target.FirstName;

                        original.LastName = target.LastName;



                    }



                    return true;

                });



            // Complete the setup of our Mock Product Repository

            this.MockStudentsRepository = mockStudentRepository.Object;
        }

        [TestMethod]
        public void CanReturnStudentByKey()
        {


            var student = new Student()
            {
                Key = new Guid("06af9aa3-afcb-4e11-b893-1a610acd44f6"),
                FirstName = "Shaza",
                LastName = "Abdullah"
            };
            // return a product by Name

            //mockProductRepository.Setup(mr => mr.FindByName(It.IsAny<string>())).Returns((string s) => products.Where(x => x.Name == s).Single());

            var mock = new Mock<IEntityRepository<Student>>();



            var ff = mock.Setup(mr =>
            mr.FindBy(It.IsAny<Expression<Func<Student, bool>>>()))
               .Returns((Expression<Func<Student, bool>> i) => students.Where(s => s.Key.Equals(i)).AsQueryable<Student>());

            var qurable = mock.Object.FindBy(x => x.Key.Equals(new Guid("06af9aa3-afcb-4e11-b893-1a610acd44f6")));

            Assert.IsNotNull(qurable.FirstOrDefault());

        }

        //private static IContainer RegisterServices(ContainerBuilder builder)
        //{


        //    // EF DbContext
        //    builder.RegisterType<EntitiesContext>()
        //           .As<DbContext>();


        //    // Register repositories by using Autofac's OpenGenerics feature
        //    // More info: http://code.google.com/p/autofac/wiki/OpenGenerics
        //    builder.RegisterGeneric(typeof(EntityRepository<>))
        //           .As(typeof(IEntityRepository<>));



        //    return builder.Build();
        //}
    }
}
