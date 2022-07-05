using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControlDesktop : MonoBehaviour
    {
        //public Joystick joystickH;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }
        
        private void FixedUpdate()
        {
            // pass the input to the car! 
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Debug.Log(h + " - " + v);

            //para el mobile y usar el joystick le paso a m_car los parámetros directamente, no uso el crossplatform
            //float h = joystickH.Horizontal;
            //float v = joystickH.Vertical;
            m_Car.Move(h, v, v, 0f);

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
