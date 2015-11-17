﻿namespace KspMath.TWR
{
    using System;

    public class TwrEngineConfiguration
    {
        /// <summary>
        /// Trust (in kN) for a single engine in the configuration.
        /// </summary>
        public double EngineTrust { get; set; }

        /// <summary>
        /// Number of engines in the configuration.
        /// </summary>
        public int EngineCount { get; set; }

        /// <summary>
        /// Angle (in degrees) for the engines in the configuration.
        /// </summary>
        public double EngineAngle { get; set; }

        /// <summary>
        /// Computes the total amount of effective trust (in kN) for the configuration.
        /// </summary>
        /// <returns></returns>
        public double ComputeTotalTrust()
        {
            return Math.Cos(EngineAngle * (Math.PI / 180)) * EngineTrust * EngineCount;
        }
    }
}
