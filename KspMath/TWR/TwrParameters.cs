namespace KspMath.TWR
{
    using System.Collections.Generic;

    public class TwrParameters
    {
        /// <summary>
        /// The engine configuration.
        /// </summary>
        public ICollection<TwrEngineConfiguration> EngineConfiguration { get; set; }

        /// <summary>
        /// The mass (in t) of the rocket.
        /// </summary>
        public double RocketMass { get; set; }

        /// <summary>
        /// The gravity constant (in m/s^2).
        /// </summary>
        public double Gravity { get; set; }
    }
}
