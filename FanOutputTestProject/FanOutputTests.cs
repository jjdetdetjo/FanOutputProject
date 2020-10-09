using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FanOutputLibrary;

namespace FanOutputTests
{
    [TestClass]
    public class FanOutputTests
    {

        //Tests that the expected exception is thrown when the Navn property is less than 2 characters long
        [TestMethod]
        public void FanOutputWithInvalidNavn()
        {
            try
            {
                FanOutput testOutput = new FanOutput("E", 20, 50);
                Assert.Fail("An exception should be thrown here");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Navn skal minimum være på 2 karakterer", e.Message);
            }
        }

        //Tests that the FanOutput object is successfully created when the Navn property is at least 2 characters long
        //and that Get for works for Navn
        [TestMethod]
        public void FanOutputWithValidNavn()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 50);
                Assert.AreEqual("Et", testOutput.Navn);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        //Tests that the expected exception is thrown when the Temp property value is lower than the allowed value of 15
        [TestMethod]
        public void FanOutputWithInvalidLowTemp()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 14, 50);
                Assert.Fail("An exception should be thrown here");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Temperaturen er for lav", e.Message);
            }
        }

        //Tests that the expected exception is thrown when the Temp property value is higher than the allowed value of 25
        [TestMethod]
        public void FanOutputWithInvalidHighTemp()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 26, 50);
                Assert.Fail("An exception should be thrown here");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Temperaturen er for høj", e.Message);
            }
        }

        //Tests that the FanOutput object is successfully created with the lowest allowed Temp property value of 15
        //and that Get works for Temp
        [TestMethod]
        public void FanOutputWithValidLowTemp()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 15, 50);
                Assert.AreEqual(15, testOutput.Temp);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        //Tests that the FanOutput object is successfully created with the highest allowed Temp property value of 25
        //and that Get works for Temp
        [TestMethod]
        public void FanOutputWithValidHighTemp()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 25, 50);
                Assert.AreEqual(25, testOutput.Temp);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        //Tests that the expected exception is thrown when the Fugt property value is lower than the allowed value of 30
        [TestMethod]
        public void FanOutputWithInvalidLowFugt()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 29);
                Assert.Fail("An exception should be thrown here");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Fugtigheden er for lav", e.Message);
            }
        }

        //Tests that the expected exception is thrown when the Fugt property value is higher than the allowed value of 80
        [TestMethod]
        public void FanOutputWithInvalidHighFugt()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 81);
                Assert.Fail("An exception should be thrown here");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Fugtigheden er for høj", e.Message);
            }
        }

        //Tests that the FanOutput object is successfully created with the lowest allowed Fugt property value of 30
        //and that Get works for Fugt
        [TestMethod]
        public void FanOutputWithValidLowFugt()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 30);
                Assert.AreEqual(30, testOutput.Fugt);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        //Tests that the FanOutput object is successfully created with the highest allowed Fugt property value of 80
        //and that Get works for Fugt
        [TestMethod]
        public void FanOutputWithValidHighFugt()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 80);
                Assert.AreEqual(80, testOutput.Fugt);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        //Tests that Set and Get works for the Id property on an object
        [TestMethod]
        public void FanOutputSetAndGetId()
        {
            try
            {
                FanOutput testOutput = new FanOutput("Et", 20, 80);
                testOutput.Id = 1;
                Assert.AreEqual(1, testOutput.Id);
            }
            catch (Exception e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }

        [TestMethod]
        public void CreateEmptyFanOutput()
        {
            try
            {
                FanOutput testOutput = new FanOutput();
                Assert.AreEqual(null, testOutput.Navn);
            }
            catch (Exception e)
            {
                Assert.Fail("No exception should be thrown here");
            }
        }
    }
}
