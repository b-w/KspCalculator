namespace KspMath.DVStages
{
    using System;

    public static class DvStagesComputation
    {
        /// <summary>
        /// Computes the total delta-v for the given rocket configuration.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static double ComputeTotalDeltaV(DvStagesParameters parameters)
        {
            double runningTotalMass = 0d, runningTotalDv = 0d;
            foreach (var stage in parameters.StageConfiguration)
            {
                runningTotalDv += stage.Isp * Math.Log((runningTotalMass + stage.Mass) / (runningTotalMass + stage.MassDry)) * parameters.Gravity;
                runningTotalMass += stage.Mass;
            }
            return runningTotalDv;
        }
    }
}
