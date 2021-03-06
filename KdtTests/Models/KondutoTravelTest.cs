﻿using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoTravelTest
    {
        [TestMethod]
        public void SerializeTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoTravel>(Properties.Resources.flight).ToJson();
            String actualJSON = null;
            KondutoTravel flight = KondutoFlightFactory.CreateFlight();

            try
            {
                actualJSON = flight.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("flight should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "flight serialization failed");
            KondutoTravel flightFromJSON = KondutoModel.FromJson<KondutoTravel>(expectedJSON);
            Assert.AreEqual(flight, flightFromJSON, "flight deserialization failed");
        }
    }
}
