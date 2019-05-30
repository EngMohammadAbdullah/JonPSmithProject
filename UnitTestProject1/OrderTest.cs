using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.OrderServies;
using ServiceLayer.OrderServies.Extenstions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    [TestClass]
    public class OrderTest:IDisposable
    {
        EntitiesContext _Context;

        public OrderTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var options = new DbContextOptionsBuilder<EntitiesContext>()
                            .UseInMemoryDatabase("EntitiesContext")
                            .UseInternalServiceProvider(serviceProvider)
                            .Options;
            _Context = new EntitiesContext(options);
            _Context.Database.EnsureCreated();
            Seed(_Context);
        }
        [TestMethod]
        public void Excute_Test()
        {

            var query = new OrderService(_Context);
            //act 
            var result = query.GetOrders();
            //Assert
            Assert.IsInstanceOfType(result, typeof(IList<Order>));
        }

        [TestMethod]
        public void Excute_Should_Return_All_Customers()
        {
            
     
            var query = new OrderService(_Context);
            //act 
            var result = query.GetOrders();
            //Assert
            Assert.AreEqual(3, result.Count);
        }

        private void Seed(EntitiesContext context)
        {

            var order = new[]
            {
                new Order{

                    Client =new Client{FirstName="Mohamed",LastName="Abdullah"},
                    Employee=new Employee{FirstName="Mohamed",Email="alkaser314@gmail.com",
                    PhoneNumber="0465134255",LastName="Abdullah" },
                    Items=new List<Item>{
                        new Item { Color="Red",width=20},
                        new Item { Color="Green",width=30}
                    }

                },
                 new Order{

                    Client =new Client{FirstName="Hasan",LastName="Abdullah"},
                    Employee=new Employee{FirstName="Hasan",Email="Hasan@gmail.com",
                    PhoneNumber="0459987978",LastName="Abdullah" },
                    Items=new List<Item>{
                        new Item { Color="parpel",width=20},
                        new Item { Color="Page",width=40}
                    }

                },
                      new Order{

                    Client =new Client{FirstName="Ammar",LastName="Abdullah"},
                    Employee=new Employee{FirstName="Ammar",Email="Ammar@gmail.com",
                    PhoneNumber="046512222222",LastName="Abdullah" },
                    Items=new List<Item>{
                        new Item { Color="Blue",width=20},
                        new Item { Color="White",width=40}
                    }

                }

            };
            context.Orders.AddRange(order);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Database.EnsureDeleted();
            _Context.Dispose();
        }
    }


}



