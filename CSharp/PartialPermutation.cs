using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.m9studio.ProbabilityTheory.New
{
    /// <summary>
    /// A combinatorics method for calculating partial permutation.
    /// </summary>
    /// <remarks>
    /// <b>Formulas:</b>
    /// <br/> c = n * (n - 1) * .. * (n - m + 1);
    /// </remarks>
    public class PartialPermutation : Combinatorics
    {
        /// <summary>
        /// Number of options.
        /// </summary>
        /// <remarks>
        /// c = n * (n - 1) * .. * (n - m + 1);
        /// </remarks>
        public override long c
        {
            get
            {
                long a = 1;
                for (int i = 0; i < m; i++)
                    a *= n - i;
                return a;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="n">The final number of anything.</param>
        /// <param name="m">'m' is the number taken from 'n' elements.</param>
        public PartialPermutation(int n, int m) : base(n, m) { }
    }
}
