namespace KspMath.DV
{
    using System.Collections.Generic;

    public class DvParameters
    {
        /// <summary>
        /// The engine configuration.
        /// </summary>
        public ICollection<EngineConfiguration> @EngineConfiguration { get; set; }

        /// <summary>
        /// The total mass (in t) of the rocket.
        /// </summary>
        public double RocketMassTotal { get; set; }

        /// <summary>
        /// The dry mass (in t) of the rocket.
        /// </summary>
        public double RocketMassDry { get; set; }

        /// <summary>
        /// The gravity constant (in m/s^2).
        /// </summary>
        public double Gravity { get; set; }
    }
}
