namespace KspMath.TWR
{
    using System.Linq;

    public static class TwrComputation
    {
        public static double ComputeTwr(TwrParameters parameters)
        {
            return parameters.EngineConfiguration.Sum(x => x.ComputeTotalTrust()) / (parameters.RocketMass * parameters.Gravity);
        }
    }
}
