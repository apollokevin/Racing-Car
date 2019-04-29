using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControlMP : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public int playerNum = 1;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void Update()
        {

            // pass the input to the car!
            string hpl = "Horizontal" + playerNum.ToString();
            string vpl = "Vertical" + playerNum.ToString();
            string bpl = "Brake" + playerNum.ToString();
            float h = CrossPlatformInputManager.GetAxis(hpl);
            float v = CrossPlatformInputManager.GetAxis(vpl);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis(bpl);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
