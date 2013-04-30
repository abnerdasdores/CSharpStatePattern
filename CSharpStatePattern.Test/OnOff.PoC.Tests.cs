using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CSharpStatePattern.PoC.Test
{
    [TestFixture]
    public class OnOffPoCTests
    {
        [Test]
        public void TestOnIsOn()
        {
            var on1 = OnOff.On;
            var on2 = OnOff.On;
            Assert.AreEqual(on1, on2);
        }
        [Test]
        public void TestOffIsOff()
        {
            var off1 = OnOff.Off;
            var off2 = OnOff.Off;
            Assert.AreEqual(off1, off2);
        }
        [Test]
        public void TestOnIsNotOff()
        {
            var on = OnOff.On;
            var off = OnOff.Off;
            Assert.AreNotEqual(on, off);
        }
        [Test]
        public void TestOnOffSwitches()
        {
            var on = OnOff.On;
            var off = OnOff.Off;

            var onSwitched = on.Switch();
            var offSwitched = off.Switch();

            Assert.AreEqual(on, offSwitched);
            Assert.AreEqual(off, onSwitched);
        }
        [Test]
        public void TestSwitchStatement()
        {
            var on = OnOff.On;
            switch (on.Value)
            {
                case OnOff.Values.On:
                    Assert.Pass();
                    break;
                default:
                    Assert.Fail();
                    break;
            }
            var off = OnOff.On;
            switch (off.Value)
            {
                case OnOff.Values.Off:
                    Assert.Pass();
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }
        [Test]
        public void TestCastValueToByte()
        {
            var onValueAsByte = (byte)OnOff.On.Value;
            var onValue = (OnOff.Values)onValueAsByte;
            Assert.AreEqual(OnOff.On.Value, onValue);
        }
        [Test]
        public void TestStates()
        {
            var states = OnOff.States;
            Assert.NotNull(states);

            var statesOn = states.SingleOrDefault(s => s == OnOff.On);
            Assert.AreEqual(statesOn, OnOff.On);
            
            var statesOff = states.SingleOrDefault(s => s == OnOff.Off);
            Assert.AreEqual(statesOff, OnOff.Off);
        }
        [Test]
        public void TestExplicitCastFromValue()
        {
            var on = OnOff.On;
            var onValue = OnOff.On.Value;
            var onValueCastToOnOff = (OnOff)onValue;
            Assert.AreEqual(on, onValueCastToOnOff);
        }
        [Test]
        public void TestImplicitCastFromValue()
        {
            var on = OnOff.On;
            var onValue = OnOff.On.Value;
            OnOff onValueCastToOnOff = onValue;
            Assert.AreEqual(on, onValueCastToOnOff);
        }
        [Test]
        public void TestExplicitCastToValue()
        {
            var on = OnOff.On;
            var onValue = OnOff.On.Value;
            var onCastToValue = (OnOff.Values)on;
            Assert.AreEqual(onValue, onCastToValue);
        }
        [Test]
        public void TestImplicitCastToValue()
        {
            var on = OnOff.On;
            var onValue = OnOff.On.Value;
            OnOff.Values onCastToValue = on;
            Assert.AreEqual(onValue, onCastToValue);
        }
        [Test]
        public void TestExplicitCastFromByte()
        {
            var on = OnOff.On;
            var onValueAsByte = (byte)OnOff.On.Value;
            var onValueAsByteCastToOnOff = (OnOff)onValueAsByte;
            Assert.AreEqual(on, onValueAsByteCastToOnOff);
        }
        [Test]
        public void TestImplicitCastFromByte()
        {
            var on = OnOff.On;
            var onValueAsByte = (byte)OnOff.On.Value;
            OnOff onValueAsByteCastToOnOff = onValueAsByte;
            Assert.AreEqual(on, onValueAsByteCastToOnOff);
        }
        [Test]
        public void TestExplicitCastToByte()
        {
            var on = OnOff.On;
            var onValueAsByte = (byte)OnOff.On.Value;
            var onCastToByte = (byte)on;
            Assert.AreEqual(onValueAsByte, onCastToByte);
        }
        [Test]
        public void TestToString()
        {
            var onValueAsString = OnOff.Values.On.ToString();
            var onStateAsString = OnOff.On.ToString();
            Assert.AreEqual(onValueAsString, onStateAsString);
            
            var offValueAsString = OnOff.Values.Off.ToString();
            var offStateAsString = OnOff.Off.ToString();
            Assert.AreEqual(offValueAsString, offStateAsString);
        }
        [Test]
        public void TestDisplayText()
        {
            var onDisplayText = OnOff.On.DisplayText;
            var offDisplayText = OnOff.Off.DisplayText;
            Assert.AreEqual("Ligado", onDisplayText);
            Assert.AreEqual("Desligado", offDisplayText);
        }
    }
}
