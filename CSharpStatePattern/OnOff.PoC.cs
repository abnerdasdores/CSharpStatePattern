using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpStatePattern.PoC
{
    /// <summary>
    /// This class is used as proof of concept of how to implement the state pattern in CSharp
    /// </summary>
    public abstract class OnOff
    {
        #region Undelying Values
        public enum Values
        {
            On,
            Off
        }
        #endregion

        #region State Values
        private static OnOff on = new OnState();
        public static OnOff On
        {
            get { return on; }
        }

        private static OnOff off = new OffState();
        public static OnOff Off
        {
            get { return off; }
        }

        public static IEnumerable<OnOff> States
        {
            get
            {
                yield return OnOff.On;
                yield return OnOff.Off;
            }
        }
        #endregion

        #region Operators
        public static implicit operator OnOff(Values value)
        {
            return OnOff.States.Single(s => s.Value == value);
        }
        public static implicit operator Values(OnOff state)
        {
            return state.Value;
        }
        public static implicit operator OnOff(byte valueAsByte)
        {
            return OnOff.States.Single(s => (byte)s.Value == valueAsByte);
        }
        public static implicit operator byte(OnOff state)
        {
            return (byte)state.Value;
        }
        #endregion

        #region Constructors
        protected OnOff(Values value)
        {
            this.value = value;
        }
        #endregion

        #region Properties
        protected Values value;
        public Values Value
        {
            get { return value; }
        }

        public abstract string DisplayText
        {
            get;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
        #endregion

        #region Custom Members
        public abstract OnOff Switch();
        #endregion

        # region On State Type
        public class OnState : OnOff
        {
            internal OnState()
                : base(Values.On)
            {
            }

            public override string DisplayText
            {
                get { return "Ligado"; }
            }
            
            public override OnOff Switch()
            {
                return OnOff.Off;
            }
        }
        #endregion

        #region Off State Type
        public class OffState : OnOff
        {
            internal OffState()
                : base(Values.Off)
            {
            }

            public override string DisplayText
            {
                get { return "Desligado"; }
            }
            
            public override OnOff Switch()
            {
                return OnOff.On;
            }
        }
        #endregion
    }
}