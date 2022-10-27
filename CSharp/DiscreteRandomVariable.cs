using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m9studio.ProbabilityTheory
{
    /// <summary>
    /// Discrete Random Variable.
    /// </summary>
    /// <remarks>
    /// <b>Formulas:</b>
    /// <br/> p1 + .. + pn = 1;
    /// <br/> M(x) = p1 * x1 + .. + pn * xn;
    /// <br/> D(x) = M(x^2) - M(x)^2;
    /// <br/> G(x) = √D(x);
    /// </remarks>
    /// <exception cref="Exception">
    /// An exception may occur if you change the values of 'p' in the DiscreteRandomVariableData objects, 
    /// and the sum of all 'p' contained in the internal collection is greater than 1.
    /// </exception>
    public class DiscreteRandomVariable : IEnumerable<DiscreteRandomVariableData>
    {
        private List<DiscreteRandomVariableData> data = new List<DiscreteRandomVariableData>();
        private double data_pCheck() => data_pCheck(0);
        private double data_pCheck(double a)
        {
            foreach (DiscreteRandomVariableData b in this.data)
                a += b.p;
            return a;
        }
        private void data_pEvent(DiscreteRandomVariableData obj, double OldValue, double NewValue, EventHandlerCancelled e)
        {
            if (data_pCheck(NewValue - OldValue) > 1)
            {
                e.Cancel();
                throw new Exception("Array of 'p' values greater than 1;");
            }
        }
        private double _Mx(int pow)
        {
            double a = 0;
            foreach (DiscreteRandomVariableData b in this.data)
                a += b.p * Math.Pow(b.x, pow);
            return a;
        }
        /// <summary>
        /// Method for adding a DiscreteRandomVariableData object.
        /// </summary>
        /// <remarks>
        /// If, when adding your object, the sum of all 'p' is greater than 1, 
        /// then the operation will not be performed and false will be returned.
        /// </remarks>
        /// <param name="data">
        /// A DiscreteRandomVariableData object containing information for further calculations.
        /// </param>
        /// <returns>Returns true or false according to whether the object was added successfully.</returns>
        public bool Add(DiscreteRandomVariableData data)
        {
            if (data_pCheck(data.p) > 1)
                return false;
            EventHandlerCancelled e = new EventHandlerCancelled();
            EventAdd?.Invoke(this, data, Length, e);
            if (!e.Cancelled)
            {
                this.data.Add(data);
                data.EventEdit_p += data_pEvent;
            }
            return !e.Cancelled;
        }
        /// <summary>
        /// Method for deleting an object from a collection.
        /// </summary>
        /// <param name="index">Index of the object being deleted.</param>
        /// <returns>Returns true or false, depending on whether the object was deleted;</returns>
        public bool Remove(int index)
        {
            if(index >= this.data.Count || index < 0)
                return false;
            DiscreteRandomVariableData a = data[index];
            EventHandlerCancelled e = new EventHandlerCancelled();
            EventAdd?.Invoke(this, a, Length, e);
            if (!e.Cancelled)
            {
                a.EventEdit_p -= data_pEvent;
                data.RemoveAt(index);
            }
            return !e.Cancelled;
        }
        /// <summary>
        /// Collection Length.
        /// </summary>
        public int Length { get=>data.Count; }
        /// <summary>
        /// Method of getting an object from a collection by its index.
        /// </summary>
        /// <param name="index">Index of the received object.</param>
        /// <returns>Requested object.</returns>
        /// <exception cref="Exception">
        /// An exception occurs if 'index' is not in the range from 0 to the value of 'Length'.
        /// </exception>
        public DiscreteRandomVariableData Get(int index)
        {
            if (index < 0 || index >= this.data.Count)
                    throw new Exception("The 'index' parameter must take a value from 0 to 'Length';");
            return data[index];
        }
        /// <summary>
        /// Expected value.
        /// </summary>
        /// <remarks>
        /// M(x) = p1 * x1 + .. + pn * xn;
        /// </remarks>
        public double Mx { get => _Mx(1); }
        /// <summary>
        /// Variance.
        /// </summary>
        /// <remarks>
        /// D(x) = M(x^2) - M(x)^2;
        /// </remarks>
        public double Dx { get=> _Mx(2) - Math.Pow(Mx, 2); }
        /// <summary>
        /// Standard deviation.
        /// </summary>
        /// <remarks>
        /// G(x) = √D(x);
        /// </remarks>
        public double Gx { get => Math.Sqrt(Dx); }
        /// <summary>
        /// Method of the IEnumerable interface.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<DiscreteRandomVariableData> GetEnumerator()
        {
            return ((IEnumerable<DiscreteRandomVariableData>)data).GetEnumerator();
        }
        /// <summary>
        /// Method of the IEnumerable interface.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }
        /// <summary>
        /// Data change event in the object.
        /// </summary>
        public event DelegateEventVoid<DiscreteRandomVariable, DiscreteRandomVariableData>? EventAdd, EventRemove;
    }
}
