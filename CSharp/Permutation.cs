using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.m9studio.ProbabilityTheory.New
{
    /// <summary>
    /// A combinatorics method for calculating permutation.
    /// </summary>
    /// <remarks>
    /// <b>Formulas:</b>
    /// <br/> c = n!;
    /// </remarks>
    public class Permutation : Combinatorics
    {
        /// <summary>
        /// Number of options.
        /// </summary>
        /// <remarks>
        /// c = n!;
        /// </remarks>
        public override long c {
            get
            {
                long a = 1;
                for (int i = 0; i < n; i++)
                    a *= a - i;
                return a;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="n">The final number of anything.</param>
        public Permutation(int n) : base(n, 1) => EventEdit_m += m_EventHandler;
        private void m_EventHandler (Combinatorics sender, int ValueOld, int ValueNew, EventHandlerCancelled e) => e.Cancel();
    }
}
