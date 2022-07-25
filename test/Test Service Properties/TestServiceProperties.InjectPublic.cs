﻿using Injection.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Injection.UnitTest.TestServiceProperties {
    [TestClass]
    public class TestServicePropertiesInjectPublic {
        [Injectable(typeof(A))] public interface IA { }

        public class A : IA { }

        [Injectable(typeof(Service))] public interface IService { }

        public class Service : IService {
            [Inject] public IA A { get; set; }

            public Service() => Console.WriteLine("Service initialized!");

            public IA GetA() => A;
        }

        public class Client {
            [Inject] IService service;

            public Client() => Console.WriteLine("Client initialized!");

            public IService GetService() => service;
        }

        [TestMethod]
        public void TestServiceProperties_InjectPublic() {
            Client client = Injector.Get<Client>();

            Assert.IsNotNull(client, "Injected client cannot be null");
            Assert.IsInstanceOfType(client, typeof(Client), "Incorrect instance of client object");

            Service service = (Service)client.GetService();
            Assert.IsNotNull(service, "Injected service cannot be null");

            A A = (A)service.GetA();
            Assert.IsNotNull(A, "Injected service cannot be null");
        }
    }
}
