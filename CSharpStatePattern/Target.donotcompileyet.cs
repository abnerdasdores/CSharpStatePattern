using System;
using System.Linq;
using System.Collections.Generic;
using CSharpStatePattern;

namespace CSharpStatePattern.Final
{
    /// <summary>
    /// This is how I want the final version of a State to be
    /// </summary>
    [State]
    public abstract class OnOff : State
    {
        public abstract OnOff Switch();

        public class OnState : OnOff
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

        public class OffState : OnOff
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