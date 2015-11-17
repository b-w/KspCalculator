namespace KspMath.Tests.ISP
{
    using System.Collections.Generic;
    using KspMath.ISP;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IspComputationTests
    {
        const double DOUBLE_DELTA = 0.00001;

        [TestMethod]
        public void CombinedIsp_Simple_Test()
        {
            // arrange

            var config1 = new EngineConfiguration()
            {
                EngineTrust = 200,
                EngineCount = 1,
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
            var ispParams = new IspParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config1, config2 }
            };

            // act

            var combinedIsp = IspComputation.ComputeCombinedIsp(ispParams);

            // assert

            Assert.AreEqual(284.17910447761194029850746268657, combinedIsp, DOUBLE_DELTA);
        }

        [TestMethod]
        public void CombinedIsp_Complex_Test()
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
            var ispParams = new IspParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config1, config2 }
            };

            // act

            var combinedIsp = IspComputation.ComputeCombinedIsp(ispParams);

            // assert

            Assert.AreEqual(296.47058823529411764705882352941, combinedIsp, DOUBLE_DELTA);
        }
    }
}
