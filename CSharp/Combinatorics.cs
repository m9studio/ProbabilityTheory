using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m9studio.ProbabilityTheory
{
    /// <summary>
    /// Abstract class for storing basic combinatorics functions.
    /// </summary>
    public abstract class Combinatorics
    {
        private int _n = 0, _m = 0;
        /// <summary>
        /// Number of options.
        /// </summary>
        /// <remarks>
        /// In the descendants, this parameter is changed for different methods of calculating 'c' by the values 'm' and 'n'.
        /// </remarks>
        public virtual long c { get; }
        /// <summary>
        /// The final number of anything.
        /// </summary>
        /// <exception cref="Exception">
        /// An exception occurs if the assigned value is less than 0 and smaller values are 'm'.
        /// </exception>
        public int n 
        {
            get => _n; 
            set
            {
                if (value < 0 || value < m)
                    throw new Exception("The value of 'n' must be greater than 0 and greater than or equal to 'm';");
                else
                {
                    EventHandlerCancelled e = new EventHandlerCancelled();
                    EventEdit_n?.Invoke(this, n, value, e);
                    if (!e.Cancelled)
                        _n = value;
                }
            }
        }
        /// <summary>
        /// 'm' is the number taken from 'n' elements.
        /// </summary>
        /// <exception cref="Exception">
        /// An exception occurs if the assigned value is less than 0 or greater than the value 'n'.
        /// </exception>
        public int m
        {
            get => _m;
            set
            {
                if(value < 0 || value > n)
                    throw new Exception("The value of 'm' must be greater than 0 and less than or equal to 'n';");
                else
                {
                    EventHandlerCancelled e = new EventHandlerCancelled();
                    EventEdit_m?.Invoke(this, m, value, e);
                    if (!e.Cancelled)
                        _m = value;
                }
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="n">The final number of anything.</param>
        /// <param name="m">'m' is the number taken from 'n' elements.</param>
        public Combinatorics(int n, int m)
        {
            this.n = n;
            this.m = m;
        }
        /// <summary>
        /// Data change event in the object.
        /// </summary>
        public event DelegateEventInt<Combinatorics>? EventEdit_m, EventEdit_n;
    }
}
