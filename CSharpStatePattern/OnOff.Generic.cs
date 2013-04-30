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

        #region Shared Base Members
        protected OnOff(Values value, string displayText)
            : base(value, displayText)
        {
        }

        protected OnOff(Values value)
            : this(value, value.ToString())
        {
        }
        #endregion

        #region Shared Custom Members
        public abstract OnOff Switch();
        #endregion

        #region OnState Type
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

        #region OffState Type
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
