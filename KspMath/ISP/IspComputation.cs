namespace KspMath.ISP
{
    using System.Linq;

    public static class IspComputation
    {
        /// <summary>
        /// Computes the combined Isp (in s) for the given input parameters.
        /// </summary>
        public static double ComputeCombinedIsp(IspParameters parameters)
        {
            if (parameters.EngineConfiguration.Count == 1)
            {
                return parameters.EngineConfiguration.First().EngineSpecificImpulse;
            }
            return parameters.EngineConfiguration.Sum(x => x.ComputeTotalTrust()) / parameters.EngineConfiguration.Sum(x => x.ComputeTotalTrust() / x.EngineSpecificImpulse);
        }
    }
}
