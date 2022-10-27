using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m9studio.ProbabilityTheory
{
    /// <summary>
    /// Event Handler.
    /// </summary>
    public class EventHandlerCancelled
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EventHandlerCancelled() { }
        /// <summary>
        /// Event cancellation status.
        /// </summary>
        public bool Cancelled = false;
        /// <summary>
        /// Event cancellation function.
        /// </summary>
        public void Cancel() => Cancelled = true;
        /// <summary>
        /// Function for setting event cancellation.
        /// </summary>
        /// <param name="cancelled">The value indicates whether the event will be canceled.</param>
        public void SetCancelled(bool cancelled) => Cancelled = cancelled;
        /// <summary>
        /// Function for getting information about event cancellation.
        /// </summary>
        /// <returns>Event cancellation status.</returns>
        public bool IsCancelled() => Cancelled;
    }
}
