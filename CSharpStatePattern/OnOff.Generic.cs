using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStatePattern.Generic
{
    public abstract class OnOff : State<OnOff, OnOff.Values>
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

        #region Constructors
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

        #region Custom Members
        public abstract OnOff Switch();
        #endregion

        #region OnState Type
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

        #region OffState Type
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
