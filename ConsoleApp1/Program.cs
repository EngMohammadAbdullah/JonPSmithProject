using DatabaseContext.Entities.Core;
using DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ConsoleApp1
{
    class Program
    {
        static EntitiesContext _context = new EntitiesContext();
        static void Main(string[] args)
        {


        

                //var client = CreateClient();
            ////_context.Clients.Add(client);
            //var address = CreateAddress();
            //var employee = CreateEmployee(address);
            ////_context.Employees.Add(employee);


            //var department = new Department
            //{
            //    Name = "Ai",
            //    Specialist = "It"
            //};

            //_context.Departments.Add(department);


            //var order = new Order
            //{
            //    Client = client,
            //    ClientKey = client.Key,
            //    Employee = employee,

            //    Items = new List<Item>()
            //     {
            //         new Item
            //            {

            //                Color = "Red",
            //                width = 20d,
            //                Name = "Table"
            //            },
            //          new Item
            //            {

            //                Color = "Green",
            //                width = 40d,
            //                Name = "Chair"
            //            }
            //     },
            //    Address = address



            //};

            //_context.Orders.Add(order);


            //_context.SaveChanges();



            var updatedOrder = _context.Orders.Include(p => p.Client)
                .Include(p => p.Employee).Include(p => p.Items).Last();
            // _context.Entry(order1).State = EntityState.Unchanged;
            // _context.Orders.Attach(order1);


            updatedOrder.Items = new List<Item>
            {

                new Item{CustomerOrder = updatedOrder, OrderKey = updatedOrder.Key,Color="Red"},
                new Item{CustomerOrder = updatedOrder,OrderKey = updatedOrder.Key,Color="Green"},
            };

                     
            _context.SaveChanges();


            
                //try
            //{

            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    foreach (var entry in ex.Entries)
            //    {
            //        if (entry.Entity is Item)
            //        {Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException: 'Database operation expected to affect 1 row(s) but actually affected 0 row(s
            //            var proposedValues = entry.CurrentValues;
            //            var databaseValues = entry.GetDatabaseValues();

            //            foreach (var property in proposedValues.Properties)
            //            {


            //                var proposedValue = proposedValues[property];
            //                // var databaseValue = databaseValues[property];

            //                // TODO: decide which value should be written to database
            //                if (property.Name.Equals("OrderKey"))
            //                {
            //                    proposedValues[property] = proposedValue;
            //                }

            //            }

            //            // Refresh original values to bypass next concurrency check
            //            entry.OriginalValues.SetValues(databaseValues);
            //        }
            //        else
            //        {
            //            throw new NotSupportedException(
            //                "Don't know how to handle concurrency conflicts for "
            //                + entry.Metadata.Name);
            //        }
            //    }
            //}


            Console.ReadLine();
        }



        static Address CreateAddress()
        {

            return new Address
            {

                City = "Temse",
                StreetName = "Oeverstraat"
            };
        }
        static Employee CreateEmployee(Address address)
        {
            Employee employee = new Employee()
            {
                FirstName = "Shaza",
                LastName = "Abdullah",
                Email = "alkaser314@gmail.com",
                PhoneNumber = "0465134255",
                Address = address


            };
            return employee;
        }

        static Client CreateClient()
        {

            return new Client()
            {
                FirstName = "Memo",
                LastName = "Abdulllah"
            };


        }

        static Item CreateItem()
        {

            return new Item()
            {

                Color = "Red",
                width = 20d,
                Name = "Table"
            };
        }
    }
}
