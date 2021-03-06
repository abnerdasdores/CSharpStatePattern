﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CSharpStatePattern
{
    /// <summary>
    /// Base class for State pattern implementation
    /// </summary>
    public abstract class State<TState, TValues>
        where TValues : struct, IConvertible
        where TState : State<TState, TValues>
    {
        #region State Values
        public static IEnumerable<TState> states = null;
        public static IEnumerable<TState> States
        {
            get
            {
                if (states == null) 
                {
                    var stateType = typeof(TState);
                    var staticProperties = stateType.GetProperties(BindingFlags.Static | BindingFlags.Public);
                    var stateProperties = staticProperties.Where(p => p.PropertyType == stateType);
                    states = stateProperties.Select(p => p.GetValue(null, null)).Cast<TState>();
                }
                return states;
            }
        }
        #endregion

        #region Operators
        public static implicit operator State<TState, TValues>(TValues value)
        {
            return State<TState, TValues>.States.Single(state => state.Value.Equals(value));
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

        #region Constructors
        protected State(TValues value)
        {
            this.value = value;
        }
        #endregion

        #region Properties
        protected TValues value;
        public TValues Value
        {
            get { return value; }
        }

        public virtual string DisplayText
        {
            get { return Value.ToString(); }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
        #endregion
    }
}