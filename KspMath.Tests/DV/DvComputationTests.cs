namespace KspMath.Tests.DV
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KspMath.DV;

    [TestClass]
    public class DvComputationTests
    {
        const double DOUBLE_DELTA = 0.00001;

        [TestMethod]
        public void DeltaVComputation_Simple_Test()
        {
            // arrange

            var config = new EngineConfiguration()
            {
                EngineCount = 1,
                EngineSpecificImpulse = 270,
                EngineTrust = 168.75
            };
            var dvParams = new DvParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config },
                RocketMassTotal = 3.72,
                RocketMassDry = 1.72,
                Gravity = 9.81
            };

            // act

            var deltaV = DvComputation.ComputeDeltaV(dvParams);

            // assert

            Assert.AreEqual(2043.2055310774902101386456403529, deltaV, DOUBLE_DELTA);
        }

        [TestMethod]
        public void DeltaVComputation_Complex_Test()
        {
            // arrange

            var config1 = new EngineConfiguration()
            {
                EngineTrust = 200,
                EngineCount = 6,
                EngineAngle = 0,
                EngineSpecificImpulse = 320
            };
            var config2 = new EngineConfiguration()
            {
                EngineTrust = 1500,
                EngineCount = 1,
                EngineAngle = 0,
                EngineSpecificImpulse = 280
            };
            var dvParams = new DvParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config1, config2 },
                RocketMassTotal = 38,
                RocketMassDry = 14,
                Gravity = 9.81
            };

            // act

            var deltaV = DvComputation.ComputeDeltaV(dvParams);

            // assert

            Assert.AreEqual(2904.0977546991996025652614950563, deltaV, DOUBLE_DELTA);
        }
    }
}
