using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStatePattern.Partials
{
    public abstract partial class OnOff : State<OnOff, OnOff.Values>
    {
        #region Underlying Values
        public enum Values
        {
            On,
            Off
        }
        #endregion

        #region States Values
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
        #endregion

        #region Base Constructor
        protected OnOff(Values value)
            : base(value)
        {
        }
        #endregion

        #region Operators
        public static implicit operator OnOff(OnOff.Values value)
        {
            return OnOff.States.Single(state => state.Value.Equals(value));
        }
        public static implicit operator OnOff(byte valueAsByte)
        {
            return OnOff.States.Single(state => ((byte)state.Value == valueAsByte));
        }
        #endregion

        #region Custom Constructors
        public partial class OnState : OnOff
        {
            protected internal OnState()
                : base(Values.On)
            {
            }
        }

        public partial class OffState : OnOff
        {
            protected internal OffState()
                : base(Values.Off)
            {
            }
        }
        #endregion
    }
}
