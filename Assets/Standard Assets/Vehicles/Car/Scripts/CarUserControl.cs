using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public bool canMove = true;

        public GameObject panel;
        public bool reachedEndGame = false;
        public int crashes = 0;
        public int toxicCrashes = 0;

        public Text crashedText;
        public Text toxicText;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void Start()
        {
            panel.SetActive(false);
        }

        private void FixedUpdate()
        {

            if (canMove)
            {
                // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif

        
            } else
            {
                m_Car.canMove = false;
                m_Car.Move(0,0, 0, 1);
            }
         }

        private void Update()
        {
            if (reachedEndGame)
            {
                toxicText.text = toxicCrashes.ToString();
                crashedText.text = crashes.ToString();
                panel.SetActive(true);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "EndGame")
            {
                canMove = false;
                reachedEndGame = true;
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.isTrigger)
            {
                if (other.tag == "Wall")
                {
                    Debug.Log("bateu");
                    crashes++;
                }

                if (other.tag == "Toxic")
                {
                    Debug.Log("bateu");
                    toxicCrashes++;
                }
            }
        }
    }


}
