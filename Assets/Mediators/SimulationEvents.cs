using System;

namespace Inspirit.Mediators.Simulations
{
    /// <summary>
    /// Callbacks for the app to communicate with the simulations
    /// <para>Authors: Rohith</para>
    /// </summary>
    public class SimulationEvents
    {
        /// <summary>
        /// Called when the help button is pressed from the Overlay
        /// </summary>
        public static Action OnHelp;

        /// <summary>
        /// Called when the simulation is loaded or restarted
        /// </summary>
        public static Action OnLoad;
    }
}
