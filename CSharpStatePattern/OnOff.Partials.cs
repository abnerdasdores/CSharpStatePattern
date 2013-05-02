using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStatePattern.Partials
{
    public abstract partial class OnOff
    {
        public abstract OnOff Switch();

        public partial class OnState : OnOff
        {
            public override string DisplayText
            {
                get { return "Ligado"; }
            }

            public override OnOff Switch()
            {
                return OnOff.Off;
            }
        }

        public partial class OffState : OnOff
        {
            public override string DisplayText
            {
                get { return "Desligado"; }
            }

            public override OnOff Switch()
            {
                return OnOff.On;
            }
        }
    }
}
