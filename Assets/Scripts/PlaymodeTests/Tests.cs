using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {

        clock m_clock;

        GameObject m_HourNeedle, m_MinutesNeedle, m_SecondsNeedle, m_clockObject;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_HourNeedle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            m_MinutesNeedle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            m_SecondsNeedle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            m_clockObject = GameObject.Instantiate(new GameObject());
            m_clockObject.AddComponent<clock>();
            var m_ClockComponent = m_clockObject.GetComponent<clock>();
            m_ClockComponent.hoursTransform = m_HourNeedle.transform;
            m_ClockComponent.minutesTransform = m_MinutesNeedle.transform;
            m_ClockComponent.secondsTransform = m_SecondsNeedle.transform;
        }
        [UnityTest]
        public IEnumerator SecondNeedleLocalRotationChangingEverySecondOnDiscrete()
        {
            var SecondNeedleLocalRotation = m_SecondsNeedle.transform.localRotation;
            yield return new WaitForSeconds(1.0f);
            var SecondNeedleNewLocalRotation = m_SecondsNeedle.transform.localRotation;
            Assert.AreNotEqual(SecondNeedleLocalRotation, SecondNeedleNewLocalRotation);
        }
        [UnityTest]
        public IEnumerator MinuteNeedleLocalRotationChangingAfterMinuteOnDiscrete()
        {
            var MinuteNeedleLocalRotation = m_MinutesNeedle.transform.localRotation;
            yield return new WaitForSeconds(1.0f);
            var MinuteNeedleNewLocalRotation = m_MinutesNeedle.transform.localRotation;
            Assert.AreEqual(MinuteNeedleLocalRotation, MinuteNeedleNewLocalRotation);
        }
        [UnityTest]
        public IEnumerator HourNeedleLocalRotationChangingAfterHourOnDiscrete()
        {
            var HourNeedleLocalRotation = m_HourNeedle.transform.localRotation;
            yield return new WaitForSeconds(1.0f);
            var HourNeedleNewLocalRotation = m_HourNeedle.transform.localRotation;
            Assert.AreEqual(HourNeedleLocalRotation, HourNeedleNewLocalRotation);
        }

        [UnityTest]
        public IEnumerator SecondNeedleLocalRotationChangingEverySecondOnContinous()
        {
            var m_ClockComponent = m_clockObject.GetComponent<clock>();
            m_ClockComponent.continuous = true;
            var SecondNeedleLocalRotation = m_SecondsNeedle.transform.localRotation;
            yield return null;
            var SecondNeedleNewLocalRotation = m_SecondsNeedle.transform.localRotation;
            Assert.AreNotEqual(SecondNeedleLocalRotation, SecondNeedleNewLocalRotation);
        }
        [UnityTest]
        public IEnumerator MinutesNeedleLocalRotationChangingEverySecondOnContinous()
        {
            var m_ClockComponent = m_clockObject.GetComponent<clock>();
            m_ClockComponent.continuous = true;
            var MinuteNeedleLocalRotation = m_MinutesNeedle.transform.localRotation;
            yield return null;
            var MinuteNeedleNewLocalRotation = m_MinutesNeedle.transform.localRotation;
            Assert.AreNotEqual(MinuteNeedleLocalRotation, MinuteNeedleNewLocalRotation);
        }

        [UnityTest]
        public IEnumerator HourNeedleLocalRotationChangingEverySecondOnContinous()
        {
            var m_ClockComponent = m_clockObject.GetComponent<clock>();
            m_ClockComponent.continuous = true;
            var HourNeedleLocalRotation = m_HourNeedle.transform.localRotation;
            yield return null;
            var HourNeedleNewLocalRotation = m_HourNeedle.transform.localRotation;
            Assert.AreNotEqual(HourNeedleLocalRotation, HourNeedleNewLocalRotation);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}
