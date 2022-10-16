using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.m9studio.ProbabilityTheory
{
    /// <summary>
    /// Event Handler.
    /// </summary>
    public class EventHandler
    {
        private double _Old, _New;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Old">The old value of the changed variable.</param>
        /// <param name="New">New value of the changed variable.</param>
        public EventHandler(double Old, double New)
        {
            _New = New;
            _Old = Old;
        }
        /// <summary>
        /// The old value of the changed variable.
        /// </summary>
        public double Old { get => _Old; }
        /// <summary>
        /// New value of the changed variable.
        /// </summary>
        public double New { get => _New; }
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
