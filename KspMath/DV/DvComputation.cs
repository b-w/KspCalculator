namespace KspMath.DV
{
    using System;
    using System.Linq;
    using KspMath.ISP;

    public static class DvComputation
    {
        public static double ComputeDeltaV(DvParameters parameters)
        {
            var ispParams = new IspParameters()
            {
                EngineConfiguration = parameters.EngineConfiguration.ToList()
            };
            var combinedIsp = IspComputation.ComputeCombinedIsp(ispParams);

            return combinedIsp * Math.Log(parameters.RocketMassTotal / parameters.RocketMassDry) * parameters.Gravity;
        }
    }
}
