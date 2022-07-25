﻿using Injection.Attributes;
using Injection.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Injection.UnitTest.TestServiceFields {
    [TestClass]
    public class TestServiceFieldsInvalidAbstractType {
        public abstract class A { }

        [Injectable(typeof(Service))] public interface IService { }

        public class Service : IService {
            [Inject] A A;

            public Service() => Console.WriteLine("Service initialized!");
        }

        public class Client {
            [Inject] IService service;

            public Client() => Console.WriteLine("Client initialized!");

            public IService GetService() => service;
        }

        [TestMethod]
        public void TestServiceFields_InvalidAbstractType() {
            Assert.ThrowsException<NoImplementationException>(() => Injector.Get<Client>(), "Injection does not throw exception where invalid Inject type exists");
        }
    }
}
