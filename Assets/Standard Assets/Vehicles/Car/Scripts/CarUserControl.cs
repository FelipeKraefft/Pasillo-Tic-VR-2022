using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public GameObject padreControles;
        public GameObject GM;

        public Joystick joystickH;

        private CarController m_Car; // the car controller we want to use

        public bool mobile = false;

        public float vSpeed;
        public float hSpeed;

        public float h;
        public float v;

        

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void Start()
        {
            padreControles = GameObject.FindGameObjectWithTag("PadreControles");
            if (!mobile)
            {
                //en nuevas escenas (o viejas) en que no exista PadreControles
                if (padreControles)
                {
                    padreControles.SetActive(false);
                }
                
            }
            else
            {

            }
        }

  
        private void FixedUpdate()
        {
            if (mobile)
            {
                //para el mobile y usar el joystick le paso a m_car los parámetros directamente, no uso el crossplatform
                h = joystickH.Horizontal;
                v = joystickH.Vertical;
            }
            else
            {
                //pass the input to the car!
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
                //Debug.Log("No Mobile input h: " + h + " - v: " + v);
            }

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
