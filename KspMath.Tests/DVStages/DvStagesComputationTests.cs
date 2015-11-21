namespace KspMath.Tests.DVStages
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KspMath;
    using KspMath.DVStages;

    [TestClass]
    public class DvStagesComputationTests
    {
        const double DOUBLE_DELTA = 0.00001;

        [TestMethod]
        public void StagesDeltaVComputation_SingleStage_Test()
        {
            // arrange

            var config = new StageConfiguration()
            {
                Isp = 400,
                Mass = 3.72,
                MassDry = 1.72
            };
            var dvsParams = new DvStagesParameters()
            {
                StageConfiguration = new List<StageConfiguration> { config },
                Gravity = 9.81
            };

            // act

            var deltaV = DvStagesComputation.ComputeTotalDeltaV(dvsParams);

            // assert

            Assert.AreEqual(3026.9711571518373483535490968191, deltaV, DOUBLE_DELTA);
        }

        [TestMethod]
        public void StagesDeltaVComputation_TwoStages_Test()
        {
            // arrange

            var config1 = new StageConfiguration()
            {
                Isp = 400,
                Mass = 3.72,
                MassDry = 1.72
            };
            var config2 = new StageConfiguration()
            {
                Isp = 320,
                Mass = 4,
                MassDry = 0.5
            };
            var dvsParams = new DvStagesParameters()
            {
                StageConfiguration = new List<StageConfiguration> { config1, config2 },
                Gravity = 9.81
            };

            // act

            var deltaV = DvStagesComputation.ComputeTotalDeltaV(dvsParams);

            // assert

            Assert.AreEqual(4922.9827747677664446259746267666, deltaV, DOUBLE_DELTA);
        }

        [TestMethod]
        public void StagesDeltaVComputation_ThreeStages_Test()
        {
            // arrange

            var config1 = new StageConfiguration()
            {
                Isp = 400,
                Mass = 3.72,
                MassDry = 1.72
            };
            var config2 = new StageConfiguration()
            {
                Isp = 320,
                Mass = 4,
                MassDry = 0.5
            };
            var config3 = new StageConfiguration()
            {
                Isp = 350,
                Mass = 8,
                MassDry = 2.5
            };
            var dvsParams = new DvStagesParameters()
            {
                StageConfiguration = new List<StageConfiguration> { config1, config2, config3 },
                Gravity = 9.81
            };

            // act

            var deltaV = DvStagesComputation.ComputeTotalDeltaV(dvsParams);

            // assert

            Assert.AreEqual(6401.4039336090279419356785724899, deltaV, DOUBLE_DELTA);
        }
    }
}
