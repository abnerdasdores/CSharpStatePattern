using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStatePattern.Partials
{
    public abstract partial class OnOff
    {
        public abstract OnOff Switch();

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
    }
}
