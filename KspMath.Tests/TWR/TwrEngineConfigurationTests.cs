namespace KspMath.Tests.TWR
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KspMath.TWR;

    [TestClass]
    public class TwrEngineConfigurationTests
    {
        const double DOUBLE_DELTA = 0.00001;

        [TestMethod]
        public void TwrEngineConfig_SingleEngine_ProvidesSingleEngineTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 0
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(220, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_MultipleEngines_ProvideNTimesTheTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 3,
                EngineAngle = 0
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(660, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_NoEngines_ProvidesNoTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 0,
                EngineAngle = 0
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(0, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_ZeroDegreeAngle_ProvidesFullTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 0
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(220, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_NinetyDegreeAngle_ProvidesNoTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 90
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(0, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_OneEightyDegreeAngle_ProvidesReverseTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 180
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(-220, trust, DOUBLE_DELTA);
        }

        [TestMethod]
        public void TwrEngineConfig_AngledEngine_ProvidesLessTrust()
        {
            // arrange

            var config = new TwrEngineConfiguration()
            {
                EngineTrust = 220,
                EngineCount = 1,
                EngineAngle = 15
            };

            // act

            var trust = config.ComputeTotalTrust();

            // assert

            Assert.AreEqual(212.50368178359502308494350394036, trust, DOUBLE_DELTA);
        }
    }
}
