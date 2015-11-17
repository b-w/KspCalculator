namespace KspMath.Tests.TWR
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KspMath.TWR;

    [TestClass]
    public class TwrComputationTests
    {
        const double DOUBLE_DELTA = 0.00001;

        [TestMethod]
        public void TwrComputation_Simple_Test()
        {
            // arrange

            var config = new EngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 0
            };
            var twrParams = new TwrParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config },
                RocketMass = 15,
                Gravity = 9.81
            };

            // act

            var ratio = TwrComputation.ComputeTwr(twrParams);

            // assert

            Assert.AreEqual(1.4950730547060822290180088345226, ratio, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrComputation_Complex_Test()
        {
            // arrange

            var config1 = new EngineConfiguration()
            {
                EngineTrust = 200,
                EngineCount = 6,
                EngineAngle = 0
            };
            var config2 = new EngineConfiguration()
            {
                EngineTrust = 1500,
                EngineCount = 1,
                EngineAngle = 0
            };
            var twrParams = new TwrParameters()
            {
                EngineConfiguration = new List<EngineConfiguration> { config1, config2 },
                RocketMass = 130.94,
                Gravity = 9.81
            };

            // act

            var ratio = TwrComputation.ComputeTwr(twrParams);

            // assert

            Assert.AreEqual(2.1019501893857120636526569351044, ratio, DOUBLE_DELTA);
        }
    }
}
