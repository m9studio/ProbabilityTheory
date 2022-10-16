using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.m9studio.ProbabilityTheory
{
    /// <summary>
    /// A combinatorics method for calculating combinations.
    /// </summary>
    /// <remarks>
    /// <b>Formulas:</b>
    /// <br/> c = n! / (m! * (n - m)!);
    /// </remarks>
    public class Combination : Combinatorics
    {
        /// <summary>
        /// Number of options.
        /// </summary>
        /// <remarks>
        /// c = n! / (m! * (n - m)!);
        /// </remarks>
        public override long c
        {
            get
            {
                long a = 1;
                long b = 1;
                for (int i = 0; i < m; i++)
                    a *= n - i;
                for (int i = 2; i <= m; i++)
                    b *= i;
                return a / b;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="n">The final number of anything.</param>
        /// <param name="m">'m' is the number taken from 'n' elements.</param>
        public Combination(int n, int m) : base(n, m) { }
    }
}
