namespace KspMath.DVStages
{
    using System.Collections.Generic;

    public class DvStagesParameters
    {
        /// <summary>
        /// Configuration of the stages.
        /// The last stage in the collection is considered to be the
        /// first stage which fires on launch.
        /// </summary>
        public ICollection<StageConfiguration> @StageConfiguration { get; set; }

        /// <summary>
        /// The gravity constant (in m/s^2).
        /// </summary>
        public double Gravity { get; set; }
    }
}
