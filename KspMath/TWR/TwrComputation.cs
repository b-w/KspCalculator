namespace KspMath.TWR
{
    using System.Linq;

    public static class TwrComputation
    {
        /// <summary>
        /// Computes the trust-to-weight ratio for the given input parameters.
        /// </summary>
        public static double ComputeTwr(TwrParameters parameters)
        {
            return parameters.EngineConfiguration.Sum(x => x.ComputeTotalTrust()) / (parameters.RocketMass * parameters.Gravity);
        }
    }
}
