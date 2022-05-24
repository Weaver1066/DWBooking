using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWBooking.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DWUnitTest
{
    [TestClass]
    public class ClientUnitTest
    {
        private Client _client;

        [TestInitialize]

        public void BeforeTest()
        {
            _client = new Client("Nadina Al-Hajid", "22324252", "Nadina@Gmail.com");
        }
        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("Nadina Al-Hajid", _client.Name);
            _client.Name = "Fatima Jensen";
            Assert.AreEqual("Fatima Jensen", _client.Name);
            try
            {
                _client.Name = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Navn kan ikke være tomt", ex.Message);
            }
        }

        [TestMethod]
        public void TestPhone()
        {
            Assert.AreEqual("22324252", _client.Phone);
            try
            {
                _client.Phone = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Telefon kan ikke være tomt", ex.Message);
            }

            try
            {
                _client.Phone = "sdagsasd";
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("nummeret skal være 8 tal", e.Message);
            }
        }

        [TestMethod]

        public void TestEmail()
        {
            Assert.AreEqual("Nadina@Gmail.com", _client.Email);
            try
            {
                _client.Email = "hasd23com";
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Dette er ikke en valid email", e.Message);
            }
        }
    }
}
