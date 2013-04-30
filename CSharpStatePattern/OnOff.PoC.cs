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
        #region Values
        public enum Values
        {
            On,
            Off
        }
        #endregion

        #region States
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

        #region Shared Base Members
        protected OnOff(Values value, string displayText)
        {
            this.value = value;
            this.displayText = displayText;
        }

        protected OnOff(Values value)
            : this(value, value.ToString())
        {
        }

        protected Values value;
        public Values Value
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

        #region Shared Custom Members
        public abstract OnOff Switch();
        #endregion

        # region On State
        public class OnState : OnOff
        {
            internal OnState()
                : base(Values.On, "Ligado")
            {
            }
            
            public override OnOff Switch()
            {
                return OnOff.Off;
            }
        }
        #endregion

        #region Off State
        public class OffState : OnOff
        {
            internal OffState()
                : base(Values.Off, "Desligado")
            {
            }
            
            public override OnOff Switch()
            {
                return OnOff.On;
            }
        }
        #endregion
    }
}