using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m9studio.ProbabilityTheory
{
    public delegate void DelegateEventInt<T>(T sender, int ValueOld, int ValueNew, EventHandlerCancelled e);
    public delegate void DelegateEventLong<T>(T sender, long ValueOld, long ValueNew, EventHandlerCancelled e);
    public delegate void DelegateEventDouble<T>(T sender, double ValueOld, double ValueNew, EventHandlerCancelled e);
    public delegate void DelegateEventVoid<T,G>(T sender, G obj, int index, EventHandlerCancelled e);
}
