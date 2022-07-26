﻿using PlainDI.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlainDI.UnitTest.TestClientProperties {
    [TestClass]
    public class TestClientPropertiesInvalidPrimitiveType {
        /*
         * Client inject-> IA
         * 
         * A
         */

        public interface IService { }

        public class Client {
            [Inject] string service { get; set; }
        }

        [TestMethod]
        public void TestClientProperties_InvalidPrimitiveType() {
            Assert.ThrowsException<MissingMethodException>(() => Injector.Get<Client>(), "PlainDI does not throw exception where invalid Inject type exists");
        }
    }
}
