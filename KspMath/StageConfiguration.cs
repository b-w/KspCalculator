namespace KspMath
{
    public class StageConfiguration
    {
        /// <summary>
        /// Total mass of the stage (in t).
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Dry mass of the stage (in t).
        /// </summary>
        public double MassDry { get; set; }

        /// <summary>
        /// Combined specific impulse (in s) of all engines in the stage.
        /// </summary>
        public double Isp { get; set; }
    }
}
