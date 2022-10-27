using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m9studio.ProbabilityTheory
{
    /// <summary>
    /// An object for storing data for a Discrete Random Variable object.
    /// </summary>
    public class DiscreteRandomVariableData
    {
        private double _x = 0, _p = 0;
        /// <summary>
        /// Random value.
        /// </summary>
        public double x
        {
            get => _x;
            set
            {
                EventHandlerCancelled e = new EventHandlerCancelled();
                EventEdit_x?.Invoke(this, x, value, e);
                if (!e.Cancelled)
                    _x = value;
                    
            }
        }
        /// <summary>
        /// The probability that there will be a random value.
        /// </summary>
        /// <exception cref="Exception">
        /// An exception occurs if the value we are trying to assign to the property is not in the range from 0 to 1.
        /// </exception>
        public double p {
            get => _p;
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception("The value of 'p' must be from 0 to 1;");
                else
                {
                    EventHandlerCancelled e = new EventHandlerCancelled();
                    EventEdit_p?.Invoke(this, p, value, e);
                    if (!e.Cancelled)
                        _p = value;
                }
            }
        }
        /// <summary>
        /// Data change event in the object.
        /// </summary>
        public event DelegateEventDouble<DiscreteRandomVariableData>? EventEdit_p, EventEdit_x;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">Random value.</param>
        /// <param name="p">The probability that there will be a random value.</param>
        public DiscreteRandomVariableData(double x, double p)
        {
            this.x = x;
            this.p = p;
        }
    }
}
