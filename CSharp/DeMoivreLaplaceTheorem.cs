using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.m9studio.ProbabilityTheory
{
    /// <summary>
    /// De Moivre–Laplace theorem.
    /// </summary>
    /// <remarks>
    /// <b>Formulas:</b>
    /// <br/> p = 1 - q;
    /// <br/> q = 1 - p;
    /// <br/> x = (k - np) / √(npq);
    /// <br/> F(x) = 1 /  √(2𝜋) * e^(-x² / 2);
    /// <br/> P = 1 / √(npq) * F(x);
    /// </remarks>
    public class DeMoivreLaplaceTheorem
    {
        private int _n = 0, _k = 0;
        private double _p = 0;
        /// <summary>
        /// √(npq)
        /// </summary>
        /// <remarks>
        /// This formula is used in different calculations, 
        /// which is why it is placed in a separate property.
        /// </remarks>
        private double npq { get => Math.Sqrt(n * p * q); }
        /// <summary>
        /// Number of tests.
        /// </summary>
        /// <exception cref="Exception">
        /// An exception occurs if the assigned value is less than 0 and 'k'.
        /// </exception>
        public int n 
        { 
            get => _n;
            set
            {
                if (value < k)
                    throw new Exception("The value of 'n' must be greater than 0 and greater than the value of 'k';");
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
        /// Number of events.
        /// </summary>
        /// <exception cref="Exception">
        /// An exception occurs if the assigned value e is in the range from 0 to the value 'n' .
        /// </exception>
        public int k 
        { 
            get => _k;
            set
            {
                if (value < 0 || value > n)
                    throw new Exception("The value of 'k' must be from 0 to the value of 'n' inclusive;");
                else
                {
                    EventHandlerCancelled e = new EventHandlerCancelled();
                    EventEdit_k?.Invoke(this, k, value, e);
                    if (!e.Cancelled)
                        _k = value;
                }
            }
        }
        /// <summary>
        /// The probability that the event will occur.
        /// </summary>
        /// <remarks>
        /// p = 1 - q
        /// </remarks>
        /// <exception cref="Exception">
        /// An exception occurs if the value we are trying to assign to the property is not in the range from 0 to 1.
        /// </exception>
        public double p 
        { 
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
        /// The probability that the event will not occur
        /// </summary>
        /// <remarks>
        /// q = 1 - p
        /// </remarks>
        /// <exception cref="Exception">
        /// An exception occurs if the value we are trying to assign to the property is not in the range from 0 to 1.
        /// </exception>
        public double q 
        {
            get => 1 - _p;
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception("The value of 'p' must be from 0 to 1;");
                else
                {
                    EventHandlerCancelled e = new EventHandlerCancelled();
                    EventEdit_q?.Invoke(this, q, value, e);
                    if (!e.Cancelled)
                        _p = 1 - value;
                }
            }
        }
        /// <summary>
        /// The value required for the Laplace formula.
        /// </summary>
        /// <remarks>
        /// x = (k - np) / √(npq)
        /// </remarks>
        public double x { get => (k - n * p) / npq; }
        /// <summary>
        /// Laplace function.
        /// </summary>
        /// <remarks>
        /// F(x) = 1 /  √(2𝜋) * e^(-x² / 2)
        /// </remarks>
        public double Fx { get => F(x); }
        /// <summary>
        /// Laplace function.
        /// </summary>
        /// <param name="x">The value required for the Laplace formula.</param>
        /// <remarks>
        /// F(x) = 1 /  √(2𝜋) * e^(-x² / 2)
        /// </remarks>
        static public double F(double x) => Math.Exp(-(Math.Pow(x, 2) / 2)) / Math.Sqrt(2 * Math.PI);
        /// <summary>
        /// Probability that 'k' events will occur in 'n' trials.
        /// </summary>
        /// <remarks>
        /// P = 1 / √(npq) * F(x)
        /// </remarks>
        public double P { get => Fx / npq; }
        
        /// <summary>
        /// Data change event in the object.
        /// </summary>
        public event DelegateEventDouble<DeMoivreLaplaceTheorem>? EventEdit_n, EventEdit_k, EventEdit_p, EventEdit_q;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="n">Number of tests.</param>
        /// <param name="k">Number of events.</param>
        /// <param name="p">The probability that the event will occur.</param>
        public DeMoivreLaplaceTheorem(int n, int k, double p)
        {
            this.n = n;
            this.k = k;
            this.p = p;
        }
    }
}
