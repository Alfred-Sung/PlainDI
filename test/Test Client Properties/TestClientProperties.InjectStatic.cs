﻿using Injection.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Injection.UnitTest.TestClientProperties {
    [TestClass]
    public class TestClientPropertiesInjectStatic {
        [Injectable(typeof(Service))] public interface IService { }

        public class Service : IService { }

        public class Client {
            [Inject] static IService Service { get; set; }

            public Client() => Console.WriteLine("Client initialized!");

            public IService GetService() => Service;
        }

        [TestMethod]
        public void TestClientProperties_InjectStatic() {
            Client client = Injector.Get<Client>();

            Assert.IsNotNull(client, "Injected client cannot be null");
            Assert.IsInstanceOfType(client, typeof(Client), "Incorrect instance of client object");

            Service service = (Service)client.GetService();
            Assert.IsNotNull(service, "Injected service cannot be null");
        }
    }
}
