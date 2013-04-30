using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CSharpStatePattern.Generic
{
    /// <summary>
    /// This class is used as proof of concept of how to implement the state pattern in CSharp
    /// </summary>
    public abstract class State<TState, TValues>
        where TValues : struct, IConvertible
    {
        public static IEnumerable<State<TState, TValues>> states = null;
        public static IEnumerable<State<TState, TValues>> States
        {
            get
            {
                if (states == null) 
                {
                    var stateType = typeof(TState);
                    var staticProperties = stateType.GetProperties(BindingFlags.Static | BindingFlags.Public);
                    var stateProperties = staticProperties.Where(p => p.DeclaringType.IsSubclassOf(stateType));
                    states = stateProperties.Select(p => p.GetValue(null, null)).Cast<State<TState, TValues>>();
                }
                return states;
            }
        }

        #region Operators
        public static implicit operator State<TState, TValues>(TValues value)
        {
            return State<TState, TValues>.States.Single(s => s.Value.Equals(value));
        }
        public static implicit operator TValues(State<TState, TValues> state)
        {
            return state.Value;
        }
        public static implicit operator State<TState, TValues>(byte valueAsByte)
        {
            return State<TState, TValues>.States.Single(state => (state.Value.ToByte(CultureInfo.InvariantCulture) == valueAsByte));
        }
        public static implicit operator byte(State<TState, TValues> state)
        {
            return state.Value.ToByte(CultureInfo.InvariantCulture);
        }
        #endregion

        #region Shared Base Members
        protected State(TValues value, string displayText)
        {
            this.value = value;
            this.displayText = displayText;
        }

        protected State(TValues value)
            : this(value, value.ToString())
        {
        }

        protected TValues value;
        public TValues Value
        {
            get { return value; }
        }

        protected string displayText;
        public string DisplayText
        {
            get { return displayText; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
        #endregion
    }
}